using Autodesk.Revit.UI;
using System.Windows;

namespace DockablePaneDemo.Revit.Views
{
    /// <summary>
    /// Interaction logic for DockablePanePage.xaml
    /// </summary>
    public partial class DockablePanePage : Window, IDockablePaneProvider
    {
        /// <summary>Unique GUID for this dockable pane.</summary>
        public static readonly Guid PaneGuid = new("12D977B9-6D7B-4DE8-BAE4-6508CA2A255C");
        public DockablePanePage()
        {
            InitializeComponent();     
        }

        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this;
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
#if !REVIT2019
                MinimumWidth = 400
#endif
            };
        }
    }
}
