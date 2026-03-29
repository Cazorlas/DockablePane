using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;

namespace DockablePaneDemo.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class DockablePaneDemoCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Show/Hide dockable pane
            try
            {
                var dockablePane = commandData.Application.GetDockablePane(App.DockablePaneId);
                if (dockablePane != null)
                {
                    if (dockablePane.IsShown()) dockablePane.Hide();
                    else dockablePane.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dockable pane toggle: {ex.Message}","Error");
            }

            return Result.Succeeded;
        }
    }
}
