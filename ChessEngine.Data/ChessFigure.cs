using ChessEngine.Data.Common.Models;
using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public abstract class ChessFigure : BasePositionModel
    {
        protected ChessFigure(int row, int column, Color color)
        {
            this.Row = row;
            this.Column = column;
            this.Color = color;
        }

        public string Name { get; set; } = default!;

        public string Image { get; set; }

        public Color Color { get; set; }
    }
}
