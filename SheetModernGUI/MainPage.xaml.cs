using Sheet.ModernGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls;

namespace Sheet.ModernGUI
{
    public sealed partial class MainPage
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.LoadLabels();
        }

        private void NotesTree_SelectedItemChanged(object sender, WinRTXamlToolkit.Controls.RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null && e.NewValue is NoteViewModel)
            {
                viewModel.SelectedNote = e.NewValue as NoteViewModel;
                DeselectTree(SearchResultsTree);
            }
        }

        private void SearchResultTree_SelectedItemChanged(object sender, WinRTXamlToolkit.Controls.RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null && e.NewValue is NoteViewModel)
            {
                viewModel.SelectedNote = e.NewValue as NoteViewModel;
                DeselectTree(NotesTree);
            }
        }

        private void CloseNote_Click(object sender, RoutedEventArgs e)
        {
            DeselectTree(NotesTree);
            DeselectTree(SearchResultsTree);
        }

        private void DeselectTree(TreeView tree)
        {
            TreeViewItem selectedItem = tree.SelectedContainer;
            if (selectedItem != null)
            {
                selectedItem.IsSelected = false;
            }
        }
    }
}
