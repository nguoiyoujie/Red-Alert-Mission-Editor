﻿using RA_Mission_Editor.FileFormats;
using RA_Mission_Editor.MapData;

namespace RA_Mission_Editor.RulesData.Ruleset
{
  public class VanillaRules : Rules
  {
    public VanillaRules()
    {

    }

    protected VirtualFileSystem FileSystem;

    public override void LoadRules(VirtualFileSystem vfs)
    {
      FileSystem = vfs;
      GameRules = vfs.OpenFile<IniFile>("rules.ini");
      if (GameRules != null)
      {
        IniFile addf = vfs.OpenFile<IniFile>("aftermath.ini");
        GameRules.MergeWith(addf);
      }

      LanguageText = vfs.OpenFile<LanguageFile>("conquer.eng");
    }

    public override void ApplyRules()
    {
      // new units?
      Buildings.ClearRulesAdditions();
      Vessels.ClearRulesAdditions();
      Units.ClearRulesAdditions();
      Infantries.ClearRulesAdditions();
      Aircrafts.ClearRulesAdditions();
      Houses.ClearRulesAdditions();

      //UpdateTechnoTypeNames(null);
    }

    public override void ApplyRulesWithMap(Map map)
    {
      UpdateTechnoTypeNames(map);
    }

    public virtual void UpdateTechnoTypeNames(Map map)
    {
      // apply Name= etc.
      foreach (var s in Buildings.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.IsFake ? s.TrueID : s.ID, map?.SourceFile);
      }

      foreach (var s in Vessels.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Units.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Infantries.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }

      foreach (var s in Aircrafts.GetAll())
      {
        s.RulesName = ReadString(s.ID, "Name", out _, s.FullName, map?.SourceFile);
        s.RulesImage = ReadString(s.ID, "Image", out _, s.ID, map?.SourceFile);
      }
    }

  }
}
