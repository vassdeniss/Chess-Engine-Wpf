using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class Queen : ChessFigure
    {
        public Queen(int row, int column, Color color)
            : base(row, column, color)
        {
            this.Name = "Queen";
            this.Image = $@"D:\Chest\Projects\WPF\ChessEngine\ChessEngine\Images\{this.Color.ToString().ToLower()}-{this.Name.ToLower()}.png";
        }
    }
}
