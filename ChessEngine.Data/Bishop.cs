using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class Bishop : ChessFigure
    {
        public Bishop(int row, int column, Color color)
            : base(row, column, color)
        {
            this.Name = "Bishop";
            this.Image = $@"D:\Chest\Projects\WPF\ChessEngine\ChessEngine\Images\{this.Color.ToString().ToLower()}-{this.Name.ToLower()}.png";
        }
    }
}
