using ChessEngine.Data.Common.Models;
using ChessEngine.Data.Models.Enums;

namespace ChessEngine.Data.Models
{
    public class Square : BasePositionModel
    {
        public Square(int row, int column, Color color, ChessFigure figure)
        {
            this.Row = row;
            this.Column = column;
            this.Color = color;
            this.Figure = figure;
        }

        public Color Color { get; set; }

        public ChessFigure? Figure { get; set; }
    }
}
