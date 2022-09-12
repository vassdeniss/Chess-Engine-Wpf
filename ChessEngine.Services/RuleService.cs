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

            MoveInfo move = this.RegisterMoveData(source, destination);

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
            if (this.ColorMatch(source, destination))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = this.RegisterMoveData(source, destination);

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

        public MoveInfo CheckLegalMove(Square[,] board, Bishop source, ChessFigure destination)
        {
            if (this.ColorMatch(source, destination))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = this.RegisterMoveData(source, destination);

            int deltaRow = source.Row - destination.Row;
            int deltaColumn = source.Column - destination.Column;
            if (Math.Abs(deltaRow) != Math.Abs(deltaColumn))
            {
                return new MoveInfo(false);
            }

            if (deltaRow > 0 && deltaColumn > 0) // Up left
            {
                for (int i = source.Row - 1, j = source.Column - 1; i != destination.Row; i--, j--)
                {
                    if (!this.IsEmptySquare(board[i, j]))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow < 0 && deltaColumn < 0) // Down Right
            {
                for (int i = source.Row + 1, j = source.Column + 1; i != destination.Row; i++, j++)
                {
                    if (!this.IsEmptySquare(board[i, j]))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow > 0 && deltaColumn < 0) // Up right
            {
                for (int i = source.Row - 1, j = source.Column + 1; i != destination.Row; i--, j++)
                {
                    if (!this.IsEmptySquare(board[i, j]))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow < 0 && deltaColumn > 0) // Down left
            {
                for (int i = source.Row + 1, j = source.Column - 1; i != destination.Row; i++, j--)
                {
                    if (!this.IsEmptySquare(board[i, j]))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            return new MoveInfo(false);
        }

        public MoveInfo CheckLegalMove(Square[,] board, ChessFigure source, ChessFigure destination)
        {
            return new MoveInfo(false);
        }

        private MoveInfo RegisterMoveData(ChessFigure source, ChessFigure destination)
        {
            MoveInfo move = new MoveInfo(false);
            move.SourceRow = source.Row;
            move.SourceColumn = source.Column;
            move.DestinationRow = destination.Row;
            move.DestinationColumn = destination.Column;

            if (destination.Name == "Empty")
            {
                return move;
            }

            move.TakenFigureRow = destination.Row;
            move.TakenFigureColumn = destination.Column;

            return move;
        }

        private bool IsEmptySquare(ChessFigure figure)
        {
            return figure.Name == "Empty";
        }

        private bool IsEmptySquare(Square square)
        {
            return square.Figure?.Name == "Empty";
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
