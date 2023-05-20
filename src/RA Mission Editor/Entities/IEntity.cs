using RA_Mission_Editor.RulesData;
using RA_Mission_Editor.RulesData.Ruleset;

namespace RA_Mission_Editor.Entities
{
  public interface IOwnedEntity : IEntity
  {
    string Owner { get; }
  }

  public interface IEntity
  {
    string ID { get; }
    EditorSelectMode SelectMode { get; }
    IEntityType GetEntityType(Rules rules);
  }

  public interface IEntity<T> : IEntity where T : IEntityType
  {
    new T GetEntityType(Rules rules);
  }

  public interface ILocatable
  {
    int Cell { get; set; }
  }

  public interface IValueParsable<T>
  {
    string GetValueAsString();
    bool Parse(string value);
  }

  public interface IKeyValueParsable<T>
  {
    string GetKeyAsString();
    string GetValueAsString();
    bool Parse(string key, string value);
  }
  
}
