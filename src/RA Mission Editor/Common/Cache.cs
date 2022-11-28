using System;
using System.Collections.Generic;
using System.IO;

namespace RA_Mission_Editor.Common
{
  public class Cache<T>
  {
    private readonly static Dictionary<string, T> _store = new Dictionary<string, T>();
		private static Func<Stream, string, T> _creator = (_, __) => default(T);

		public static T Load(string filename)
		{
			T ret = default(T);
			if (!_store.TryGetValue(filename, out ret))
			{
				FileStream s = File.OpenRead(filename);
				ret = _creator(s, filename);
				if (Equals(ret, default(T)))
					_store.Add(filename, ret);
			}
			return ret;
		}

		public static T Load(string id, Stream source)
		{
			T ret = default(T);
			if (!_store.TryGetValue(id, out ret))
			{
				ret = _creator(source, id);
				if (Equals(ret, default(T)))
					_store.Add(id, ret);
			}
			return ret;
		}

		public static void Clear()
    {
			_store.Clear();
    }

		public static void SetCreateFunction(Func<Stream, string, T> fn)
    {
			_creator = fn ?? ((_, __) => default(T));
    }
	}
}
