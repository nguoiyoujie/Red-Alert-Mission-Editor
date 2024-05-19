using System.Collections.Generic;

namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class TrackedActionsList
  {
    private Map _map { get; set; }
    private readonly List<ITrackedAction> _actions = new List<ITrackedAction>(1028);
    public int Current = -1;

    public int Capacity = 1028;

    public TrackedActionsList(Map map)
    {
      _map = map;
    }

    public void Push(ITrackedAction action)
    {
      if (Current < 0)
      {
        // everything was undone
        _actions.Clear();
      }
      else if (_actions.Count - 1 > Current)
      {
        for (int i = _actions.Count - 1; i > Current; i--)
        _actions.RemoveAt(i);
      }

      if (_actions.Count > Capacity)
      {
        _actions.RemoveAt(0);
      }
      _actions.Add(action);
      Current++;
      _map.UndoRedoChanged?.Invoke();
    }

    public ITrackedAction Undo()
    {
      if (Current <= -1) { return null; }
      if (_actions.Count == 0) { return null; }
      try
      {
        ITrackedAction t = _actions[Current];
        t?.Undo();
        Current--;
        _map.UndoRedoChanged?.Invoke();
        return t;
      }
      catch
      {
        return null;
      }
    }

    public ITrackedAction Redo()
    {
      if (Current >= _actions.Count - 1) { return null; }
      if (_actions.Count == 0) { return null; }
      try
      {
        ITrackedAction t = _actions[Current + 1];
        t?.Do();
        Current++;
        _map.UndoRedoChanged?.Invoke();
        return t;
      }
      catch
      {
        return null;
      }
    }

    public bool CanUndo()
    {
      if (Current <= -1) { return false; }
      if (_actions.Count == 0) { return false; }
      return true;
    }

    public bool CanRedo()
    {
      if (Current >= _actions.Count - 1) { return false; }
      if (_actions.Count == 0) { return false; }
      return true;
    }

    public ITrackedAction PeekUndo()
    {
      if (Current <= -1) { return null; }
      if (_actions.Count == 0) { return null; }
      return _actions[Current];
    }

    public ITrackedAction PeekRedo()
    {
      if (Current >= _actions.Count - 1) { return null; }
      if (_actions.Count == 0) { return null; }
      return _actions[Current + 1];
    }

    public ITrackedAction this[int index] => _actions[index];

    public void Clear() { _actions.Clear(); Current = -1; }
  }
}