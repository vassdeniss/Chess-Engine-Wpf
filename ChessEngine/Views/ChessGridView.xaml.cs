using System.Windows;
using System.Windows.Controls;

using Autofac;

using ChessEngine.ViewModels;

namespace ChessEngine.Views
{
    /// <summary>
    /// Interaction logic for ChessGridView.xaml
    /// </summary>
    public partial class ChessGridView : Page
    {
        public ChessGridView()
        {
            this.InitializeComponent();
            this.DataContext = Bootstrapper.Container.Resolve<ChessGridViewModel>();
            //MessageBox.Show("In memory of my grandma...\nMay she rest in peace...", "Message from the developer", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
