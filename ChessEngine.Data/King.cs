using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class King : ChessFigure
    {
        public King(int row, int column, Color color)
            : base(row, column, color)
        {
            this.Name = "King";
            this.Image = $@"D:\Chest\Projects\WPF\ChessEngine\ChessEngine\Images\{this.Color.ToString().ToLower()}-{this.Name.ToLower()}.png";
        }
    }
}
