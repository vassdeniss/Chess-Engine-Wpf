using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class Knight : ChessFigure
    {
        public Knight(int row, int column, Color color) 
            : base(row, column, color)
        {
            this.Name = "Knight";
            this.Image = $@"D:\Chest\Projects\WPF\ChessEngine\ChessEngine\Images\{this.Color.ToString().ToLower()}-{this.Name.ToLower()}.png";
        }
    }
}
