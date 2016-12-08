using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ContactManager.Model;
using ContactManager.Presenters;
using ContactManager.Views;

namespace ContactManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            DataContext = new ApplicationPresenter(this, new ContactRepository());
        }

        public void AddTab<T>(PresenterBase<T> presenter)
        {
            TabItem newTab = null;
            for (var i = 0; i < tabs.Items.Count; i++)
            {
                var existingTab = (TabItem) tabs.Items[i];
                if (existingTab.DataContext.Equals(presenter))
                {
                    tabs.Items.Remove(existingTab);
                    newTab = existingTab;
                    break;
                }
            }
            if (newTab == null)
            {
                newTab = new TabItem();
                var headerBinding = new Binding(presenter.TabHeaderPath);
                BindingOperations.SetBinding(
                    newTab,
                    HeaderedContentControl.HeaderProperty,
                    headerBinding
                );
                newTab.DataContext = presenter;
                newTab.Content = presenter.View;
            }
            tabs.Items.Insert(0, newTab);
            newTab.Focus();
        }

        public void RemoveTab<T>(PresenterBase<T> presenter)
        {
            for (var i = 0; i < tabs.Items.Count; i++)
            {
                var item = (TabItem) tabs.Items[i];
                if (item.DataContext.Equals(presenter))
                {
                    tabs.Items.Remove(item);
                    break;
                }
            }
        }
    }
}