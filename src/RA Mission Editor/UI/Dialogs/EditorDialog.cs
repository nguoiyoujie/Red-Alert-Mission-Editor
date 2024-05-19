using RA_Mission_Editor.MapData;
using RA_Mission_Editor.Renderers;
using System;
using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Dialogs
{
  public partial class EditorDialog : Form
  {
    public EditorDialog(MainEditor form)
    {
      InitializeComponent();
      Form = form;
    }

    public Map Map { get; private set; }
    public MainEditor Form { get; }


    public void SetMap(Map map)
    {
      Map = map;
      ttControl_Basic.SetMap(map);
      ttControl_Houses.SetMap(map);
      ttControl_Tutorial.SetMap(map);
      ttControl_Triggers.SetMap(map);
      ttControl_TeamTypes.SetMap(map);
      ttControl_Globals.SetMap(map);
      ttControl_Reference.SetMap(map);
      RefreshTab();
    }

    public void AttachRenderer(MapCanvas canvas) 
    {
      ttControl_TeamTypes.AttachRenderer(canvas);
    }

    public void SetSelectionToBasic()
    {
      tabSelection.SelectedTab = pageBasic;
    }

    public void SetSelectionToHouses()
    {
      tabSelection.SelectedTab = pageHouses;
    }

    public void SetSelectionToTutorial()
    {
      tabSelection.SelectedTab = pageTutorial;
    }

    public void SetSelectionToTriggers()
    {
      tabSelection.SelectedTab = pageTriggers;
    }

    public void SetSelectionToTeamTypes()
    {
      tabSelection.SelectedTab = pageTeamTypes;
    }

    public void SetSelectionToGlobals()
    {
      tabSelection.SelectedTab = pageGlobals;
    }

    private void tabSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefreshTab();
    }

    public void RefreshTab()
    { 
      if (Map == null) { return; }
      else if (tabSelection.SelectedTab == pageBasic)
      {
        //ttControl_Basic.ResetList();
      }
      else if (tabSelection.SelectedTab == pageHouses)
      {
        //ttControl_Houses.ResetList();
      }
      else if (tabSelection.SelectedTab == pageTutorial)
      {
        ttControl_Tutorial.RefreshView();
      }
      else if (tabSelection.SelectedTab == pageTriggers)
      {
        ttControl_Triggers.ResetSelections();
      }
      else if (tabSelection.SelectedTab == pageTeamTypes)
      {
        ttControl_TeamTypes.ResetSelections();
      }
      else if (tabSelection.SelectedTab == pageGlobals)
      {
        ttControl_Globals.RefreshView();
      }
    }
  }
}
