using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
namespace RA_Mission_Editor.FileFormats
{
	public class IniFile : VirtualTextFile
	{
		public List<IniSection> Sections { get; set; }

		public IniFile(Stream baseStream, string filename, int baseOffset, long fileSize, bool isBuffered = true) 
			: base(baseStream, filename, baseOffset, fileSize, isBuffered)
		{
			Sections = new List<IniSection>();
			Parse();
		}

		public IniFile(string data) : base(new MemoryStream(1024), null, 0, data.Length, false)
		{
			Sections = new List<IniSection>();
			LoadFromString(data);
			Parse();
		}

		private void Parse()
		{
			IniSection section = null;
			while (CanRead)
			{
				ProcessLine(ReadLine(), ref section);
			}
		}

		public IniSection GetSection(string sectionName)
		{
			return Sections.Find(x => x.Name == sectionName);
		}

		public IniSection GetSectionX(string sectionName)
    {
			IniSection r = GetSection(sectionName);
			if (r == null)
				throw new Exception($"File does not contain [{sectionName}] section!");
			return r;
		}

		public IniSection GetOrCreateSection(string sectionName, string insertAfter = null)
		{
			var ret = Sections.Find(x => x.Name == sectionName);
			if (ret == null)
			{
				int insertIdx = (insertAfter != null) ? Sections.FindIndex(section => section.Name == insertAfter) : -1;

				ret = new IniSection(sectionName);
				if (insertIdx != -1)
				{
					Sections.Insert(insertIdx, ret);
					ret.Index = insertIdx;
					// move up all section indices
					for (int i = insertIdx + 1; i < Sections.Count; i++)
						Sections[i].Index++;
				}
				else
				{
					Sections.Add(ret);
					ret.Index = Sections.Count;
				}
			}
			return ret;
		}

		private int ProcessLine(string line, ref IniSection section)
		{
			IniSection.FixLine(ref line);
			if (line.Length == 0) return 0;

			// Test if this line contains start of new section i.e. matches [*]
			if ((line[0] == '[') && (line[line.Length - 1] == ']'))
			{
				string sectionName = line.Substring(1, line.Length - 2);
				var iniSection = new IniSection(sectionName, Sections.Count);
				Sections.Add(iniSection);
				section = iniSection;
			}
			else if (section != null)
			{
				return section.ParseLine(line);
			}
			return 0;
		}

		public class IniSection
		{
			public int Index { get; set; }
			public string Name { get { return HeaderLine.SectionHeader; } set { HeaderLine.SectionHeader = value; } }
			public IniLine HeaderLine;
			public List<KeyValuePair<string, IniLine>> OrderedEntries = new List<KeyValuePair<string, IniLine>>();
			public Dictionary<string, IniLine> SortedEntries = new Dictionary<string, IniLine>();

			public struct IniLine
			{
				public string SectionHeader;
				public string Key;
				public string Value;
				public string Comment;

				public const char CHAR_SECTIONHEAD = '[';
				public const char CHAR_SECTIONHEADEND = ']';
				public const char CHAR_COMMENT = ';';
				public const char CHAR_EQUAL = '=';
				public const char CHAR_WHITESPACE = ' ';

				public IniLine(string line) { this = default; Parse(line); }

				public IniLine(string sheader, string key, string value = "", string comment = "")
				{
					SectionHeader = sheader;
					Key = key;
					Value = value;
					Comment = comment;
				}

				public void Parse(string line)
				{
					StringBuilder sb_header = new StringBuilder();
					StringBuilder sb_key = new StringBuilder();
					StringBuilder sb_value = new StringBuilder();
					StringBuilder sb_comment = new StringBuilder();

					StringBuilder sb_holder = new StringBuilder();

					StringBuilder curr_sb = sb_holder;

					bool _in_header = false;
					bool _after_header = false;
					bool _after_equal = false;
					bool _in_comment = false;

					line = line.Trim();

					int i = 0;
					while (i < line.Length)
					{
						char c = line[i];
						switch (c)
						{
							case CHAR_COMMENT:
								if (!_in_comment) // enter comment mode
								{
									curr_sb = sb_comment;
									_in_comment = true;
								}
								else // just fill
									curr_sb.Append(c);
								break;

							case CHAR_SECTIONHEAD:
								if (!_in_comment) // not in comment
								{
									if (!_in_header && i == 0) // Header opening should be first non-whitespace character
									{
										curr_sb = sb_header;
										_in_header = true;
									}
								}
								else // just fill
									curr_sb.Append(c);
								break;


							case CHAR_SECTIONHEADEND:
								if (!_in_comment) // not in comment
								{
									sb_holder.Clear();

									if (_in_header && !_after_header)
									{
										curr_sb = sb_holder;
										_after_header = true;
									}
								}
								else // just fill
									curr_sb.Append(c);
								break;

							case CHAR_EQUAL:
								if (!(_in_header ^ _after_header || _in_comment || _after_equal)) // not inside header or comment
								{
									sb_key.Append(sb_holder); // acculmulated holder string
									curr_sb = sb_value;
									_after_equal = true;
								}
								else // just fill
									curr_sb.Append(c);
								break;
							default:
								curr_sb.Append(c);
								break;
						}
						i++;
					}

					SectionHeader = sb_header.ToString().Trim();
					Key = sb_key.ToString().Trim();
					Value = sb_value.ToString().Trim();
					Comment = sb_comment.ToString().Trim();

				}

				public string Print()
				{
					StringBuilder sb = new StringBuilder();
					if (SectionHeader != null && SectionHeader.Length > 0)
					{
						sb.Append(CHAR_SECTIONHEAD);
						sb.Append(SectionHeader);
						sb.Append(CHAR_SECTIONHEADEND);
						sb.Append(CHAR_WHITESPACE);
					}
					if (Key != null && Key.Length > 0)
					{
						sb.Append(Key);
						sb.Append(CHAR_EQUAL);
						sb.Append(Value);
						sb.Append(CHAR_WHITESPACE);
					}
					if (Comment != null && Comment.Length > 0)
					{
						sb.Append(CHAR_COMMENT);
						sb.Append(Comment);
					}
					string raw = sb.ToString();
					return raw;
				}

			}

			/*
			public class IniValue
			{
				private string value;
				public IniValue(string value)
				{
					this.value = value;
				}

				public override string ToString()
				{
					return value;
				}
				public static implicit operator IniValue(string value)
				{
					return new IniValue(value);
				}
				public static implicit operator string(IniValue val)
				{
					return val.value;
				}
				public void Set(string value)
				{
					this.value = value;
				}
				public override bool Equals(object obj)
				{
					return value.Equals(obj.ToString());
				}
				protected bool Equals(IniValue other)
				{
					return string.Equals(value, other.value);
				}

				public override int GetHashCode()
				{
					return value != null ? value.GetHashCode() : 0;
				}
			}
			*/
			//public Dictionary<string, IniValue> SortedEntries { get; set; }
			//public List<KeyValuePair<string, IniValue>> OrderedEntries { get; set; }

			static NumberFormatInfo culture = CultureInfo.InvariantCulture.NumberFormat;

			public IniSection(string name = "", int index = -1)
			{
				SortedEntries = new Dictionary<string, IniLine>();
				OrderedEntries = new List<KeyValuePair<string, IniLine>>();
				Name = name;
				Index = index;
			}

			public override string ToString()
			{
				var sb = new StringBuilder();
				sb.AppendLine(HeaderLine.Print());
				foreach (var v in OrderedEntries)
				{
					sb.AppendLine(v.Value.Print());
				}
				return sb.ToString();
			}

			public void Clear()
			{
				SortedEntries.Clear();
				OrderedEntries.Clear();
			}

			public int ParseLines(IEnumerable<string> lines)
			{
				return lines.Sum(line => ParseLine(line));
			}

			public int ParseLine(string line)
			{
				// ignore comments
				if (line[0] == ';') return 0;
				string key;
				int pos = line.IndexOf("=", StringComparison.Ordinal);
				if (pos != -1)
				{
					key = line.Substring(0, pos);
					string value = line.Substring(pos + 1);
					FixLine(ref key);
					FixLine(ref value);
					SetValue(key, value, false);
					return 1;
				}
				return 0;
			}

			public void SetValue(string key, string value, bool @override = true)
			{
				if (!SortedEntries.ContainsKey(key))
				{
					IniLine line = new IniLine(null, key, value, null);
					OrderedEntries.Add(new KeyValuePair<string, IniLine>(key, line));
					SortedEntries[key] = line;
				}
				else if (@override)
				{
					IniLine line = SortedEntries[key];
					line.Value = value;
					SortedEntries[key] = line;
					OrderedEntries.RemoveAll(e => e.Key == key);
					OrderedEntries.Add(new KeyValuePair<string, IniLine>(key, line));
				}
			}

			public void RemoveValue(string key)
			{
				if (SortedEntries.ContainsKey(key))
				{
					OrderedEntries.RemoveAll(e => e.Key == key);
					SortedEntries.Remove(key);
				}
			}

			public static void FixLine(ref string line)
			{
				int start = 0;

				while (start < line.Length && (line[start] == ' ' || line[start] == '\t'))
					start++;

				int end = line.IndexOf(';', start);
				if (end == -1) end = line.Length;

				while (end > 1 && (line[end - 1] == ' ' || line[end - 1] == '\t'))
					end--;

				line = line.Substring(start, Math.Max(end - start, 0));
			}

			public static string FixLine(string line)
			{
				string copy = line;
				FixLine(ref copy);
				return copy;
			}

			public bool HasKey(string keyName)
			{
				return SortedEntries.ContainsKey(keyName);
			}

			public bool ReadBool(string key, bool defaultValue = false)
			{
				return ReadString(key).GetAsBool(defaultValue);
			}

			public string ReadString(string key, string defaultValue = "")
			{
				IniLine line;
				if (SortedEntries.TryGetValue(key, out line))
					return line.Value;
				else
					return defaultValue;
			}

			public int ReadInt(string key, int defaultValue = 0)
			{
				int ret;
				if (int.TryParse(ReadString(key), out ret))
					return ret;
				else
					return defaultValue;
			}

			public short ReadShort(string key, short defaultValue = 0)
			{
				short ret;
				if (short.TryParse(ReadString(key), out ret))
					return ret;
				else
					return defaultValue;
			}

			public float ReadFloat(string key, float defaultValue = 0.0f)
			{
				float ret;
				if (float.TryParse(ReadString(key).Replace(',', '.'), NumberStyles.Any, culture, out ret))
					return ret;
				else
					return defaultValue;
			}

			public double ReadDouble(string key, double defaultValue = 0.0)
			{
				double ret;
				if (double.TryParse(ReadString(key).Replace(',', '.'), NumberStyles.Any, culture, out ret))
					return ret;
				else
					return defaultValue;
			}

			public T ReadEnum<T>(string key, T @default)
			{
				if (HasKey(key))
					return (T)Enum.Parse(typeof(T), ReadString(key));
				return @default;
			}

			public List<string> ReadList(string key)
			{
				return ReadString(key).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			}

			public string ConcatenatedValues()
			{
				var sb = new StringBuilder();
				foreach (var v in OrderedEntries)
					sb.Append(v.Value);
				return sb.ToString();
			}

			public void WriteTo(StreamWriter sw)
			{
				sw.WriteLine(HeaderLine.Print());
				foreach (var v in OrderedEntries)
				{
					sw.WriteLine(v.Value.Print());
				}
			}
		}

		public void Save(string filename)
		{
			var sw = new StreamWriter(filename, false, Encoding.Default, 64 * 1024);
			foreach (IniSection section in Sections)
			{
				// skip sections with no entries
				if (section.OrderedEntries.Count != 0)
				{
					section.WriteTo(sw);
					if (section != Sections.Last())
						sw.WriteLine();
				}
			}
			sw.Flush();
			sw.Dispose();
		}

		public void LoadFromString(string data)
		{
			var sw = new StreamWriter(this.BaseStream, Encoding.ASCII);
			sw.Write(data);
			sw.Flush();
			BaseStream.Position = 0;
		}

		public string SaveToString()
		{
			string ret = string.Empty;
			using (MemoryStream m = new MemoryStream())
			{
				var sw = new StreamWriter(m, Encoding.ASCII);
				foreach (IniSection section in Sections)
				{
					// skip sections with no entries
					if (section.OrderedEntries.Count != 0)
					{
						section.WriteTo(sw);
						if (section != Sections.Last())
							sw.WriteLine();
					}
				}
				sw.Flush();
				m.Position = 0;
				ret = m.ReadAllText();
			}
			return ret;
		}

		/// <summary>
		/// Merges (and overrides) the entries from given ini files with this
		/// </summary>
		/// <param name="ini"></param>
		public void MergeWith(IniFile ini)
		{
			if (ini == null) return;

			foreach (var v in ini.Sections)
			{
				var ownSection = GetOrCreateSection(v.Name);
				// numbered arrays are 'appended' instead of overwritten
				if (IsObjectArray(v.Name))
				{
					try
					{
						int number = 1 + int.Parse(ownSection.OrderedEntries.Last().Key);
						foreach (var kvp in v.OrderedEntries)
							ownSection.SetValue(number++.ToString(), kvp.Value.Value);
					}
					catch (FormatException)
					{
						foreach (var kvp in v.OrderedEntries)
							ownSection.SetValue(kvp.Key, kvp.Value.Value);
					}
				}
				else
					foreach (var kvp in v.OrderedEntries)
						ownSection.SetValue(kvp.Key, kvp.Value.Value);
			}
		}

		private bool IsObjectArray(string p)
		{
			return false;
				/*
				new[] {
				"BuildingTypes",
				"AircraftTypes",
				"InfantryTypes",
				"OverlayTypes",
				"TerrainTypes",
				"SmudgeTypes",
				"VehicleTypes",
			}.Contains(p);
				*/
		}
	}

}
