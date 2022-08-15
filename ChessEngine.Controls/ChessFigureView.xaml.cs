using System.Windows;
using System.Windows.Controls;

using ChessEngine.Data.Models;

namespace ChessEngine.Controls
{
    /// <summary>
    /// Interaction logic for ChessFigureView.xaml
    /// </summary>
    public partial class ChessFigureView : UserControl
    {
        public static readonly DependencyProperty FigureProperty
            = DependencyProperty.Register("Figure", typeof(ChessFigure), typeof(ChessFigureView));

        public ChessFigureView()
        {
            this.InitializeComponent();
        }

        public ChessFigure Figure
        {
            get => (ChessFigure)this.GetValue(FigureProperty);
            set => this.SetValue(FigureProperty, value);
        }
    }
}
