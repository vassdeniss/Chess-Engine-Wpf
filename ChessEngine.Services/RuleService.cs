using ChessEngine.Data.Models;
using ChessEngine.Data.Models.Enums;
using ChessEngine.Services.Interfaces;

namespace ChessEngine.Services
{
    public class RuleService : IRuleService
    {
        public MoveInfo CheckLegalMove(Square[,] board, Pawn source, ChessFigure destination)
        {
            if (this.ColorMatch(source, destination))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(true);
            move.SourceRow = source.Row;
            move.SourceColumn = source.Column;
            move.DestinationRow = destination.Row;
            move.DestinationColumn = destination.Column;

            if (destination.Name != "Empty")
            {
                move.TakenFigureRow = destination.Row;
                move.TakenFigureColumn = destination.Column;
            }

            if (source.Color == Color.White)
            {
                // One move forward
                if (source.Row - destination.Row == 1)
                {
                    // Does not move diagonally and square is empty
                    if (source.Column == destination.Column 
                        && destination.Name == "Empty")
                    {
                        move.IsAllowed = true;
                        return move;
                    }

                    // Does move diagonally and square is not empty and piece is different color
                    if (Math.Abs(destination.Column - source.Column) == 1 
                        && !this.ColorMatch(source, destination))
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                }
            }

            if (source.Color == Color.Black)
            {
                // One move forward
                if (source.Row - destination.Row == -1)
                {
                    // Does not move diagonally and square is empty
                    if (source.Column == destination.Column
                        && destination.Name == "Empty")
                    {
                        move.IsAllowed = true;
                        return move;
                    }

                    // Does move diagonally and square is not empty and piece is different color
                    if (Math.Abs(destination.Column - source.Column) == 1
                        && !this.ColorMatch(source, destination))
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                }
            }

            return new MoveInfo(false);
        }

        public MoveInfo CheckLegalMove(Square[,] board, Knight source, ChessFigure destination)
        {
            if (ColorMatch(source, destination))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(true);
            move.SourceRow = source.Row;
            move.SourceColumn = source.Column;
            move.DestinationRow = destination.Row;
            move.DestinationColumn = destination.Column;

            if (destination.Name != "Empty")
            {
                move.TakenFigureRow = destination.Row;
                move.TakenFigureColumn = destination.Column;
            }

            // Vertical G
            if (Math.Abs(source.Row - destination.Row) == 2
                && Math.Abs(source.Column - destination.Column) == 1)
            {
                return move;
            }

            // Horizontal G
            if (Math.Abs(source.Row - destination.Row) == 1
                && Math.Abs(source.Column - destination.Column) == 2)
            {
                return move;
            }

            return new MoveInfo(false);
        }

        public MoveInfo CheckLegalMove(Square[,] board, ChessFigure source, ChessFigure destination)
        {
            return new MoveInfo(false);
        }

        private bool ColorMatch(ChessFigure a, ChessFigure b)
        {
            if (a.Name == "Empty" || b.Name == "Empty")
            {
                return false;
            }

            return a.Color == b.Color;
        }
    }
}
