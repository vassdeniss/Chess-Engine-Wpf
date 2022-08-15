using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class Empty : ChessFigure
    {
        public Empty(int row, int column) 
            : base(row, column, Color.NoColor)
        {
            this.Name = "Empty";
        }
    }
}
