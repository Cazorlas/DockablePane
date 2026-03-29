using Autodesk.Revit.UI;
using DockablePaneDemo.Revit.Views;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DockablePaneDemo
{
    public class App : IExternalApplication
    {
        #region Properties, fields,...
        private readonly string pathFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        private Autodesk.Revit.UI.RibbonPanel? _ribbonPanel = null!;
        private UIControlledApplication _app = null!;
        private string _tabName = "DockablePane";
        public static DockablePaneId DockablePaneId => new DockablePaneId(DockablePanePage.PaneGuid);
        #endregion

        #region Interface events: IExternalApplication
        public Result OnStartup(UIControlledApplication application)
        {
            // Assign value
            _app = application;

            // Create tabPanel
            InitializeTabPanel(_tabName);

            // Create RibbonPanel          
            var commandRibbonPanel = application.CreateRibbonPanel(_tabName, "Demo");

            // Initialize dockable panes
            SetupDockablePane(application);

            // Register buttons onto ribbonPanel
            DemoRibbonPanel(commandRibbonPanel);

            return Result.Succeeded;
        } 

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        #endregion

        #region Panels
        private void DemoRibbonPanel(RibbonPanel commandRibbonPanel)
        {
            var pushButtonData = new PushButtonData("ShowDockablePane",
                "Dockable pane",
                pathFolder,
                "DockablePaneDemo.Revit.Commands.ShowDockablePaneCommand");

            var pushButton = commandRibbonPanel.AddItem(pushButtonData) as PushButton;
        }
        #endregion Panels 

        #region Other register
        private static void SetupDockablePane(UIControlledApplication application)
        {
            // Register a dockable pane
            var page = new DockablePanePage();
            application.RegisterDockablePane(DockablePaneId, "Dockblepane", page);

            // If you have more dockable panes, you can register them here

        }
        #endregion

        #region Initialization
        private void InitializeTabPanel(string tabName)
        {
            try
            {
                _app.CreateRibbonTab(_tabName);

            }
            catch (Exception ex)
            {
                Debug.Print($"Error: {ex.Message}");
            }
        }
        #endregion Initialization
    }
    
}
