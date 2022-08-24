using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ChessEngine.Data.Models;

namespace ChessEngine.Controls
{
    /// <summary>
    /// Interaction logic for ChessFigureView.xaml
    /// </summary>
    public partial class ChessFigureView : UserControl
    {
        public static readonly DependencyProperty FigureProperty
            = DependencyProperty.Register("Figure", 
                typeof(ChessFigure), 
                typeof(ChessFigureView));

        public static readonly DependencyProperty DragInitCommandProperty
            = DependencyProperty.Register("DragInitCommand",
                typeof(ICommand),
                typeof(ChessFigureView));

        public static readonly DependencyProperty DragOverCommandProperty
            = DependencyProperty.Register("DragOverCommand",
                typeof(ICommand),
                typeof(ChessFigureView));

        public ChessFigureView()
        {
            this.InitializeComponent();
        }

        public ChessFigure Figure
        {
            get => (ChessFigure)this.GetValue(FigureProperty);
            set => this.SetValue(FigureProperty, value);
        }

        public ICommand DragInitCommand
        {
            get => (ICommand)this.GetValue(DragInitCommandProperty);
            set => this.SetValue(DragInitCommandProperty, value);
        }

        public ICommand DragOverCommand
        {
            get => (ICommand)this.GetValue(DragOverCommandProperty);
            set => this.SetValue(DragOverCommandProperty, value);
        }

        private void Figure_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragInitCommand.Execute(this.Figure);
        }

        private void Figure_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.DragOverCommand.Execute(this.Figure);
        }
    }
}
