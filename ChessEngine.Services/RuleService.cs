using ChessEngine.Data.Models;
using ChessEngine.Data.Models.Enums;
using ChessEngine.Services.Interfaces;

namespace ChessEngine.Services
{
    public class RuleService : IRuleService
    {
        public MoveInfo CheckLegalMove(Square[,] board, Pawn source, ChessFigure destination)
        {
            MoveInfo move = new MoveInfo();
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
                        && destination.Name != "Empty" 
                        && destination.Color != source.Color)
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
                        && destination.Name != "Empty"
                        && destination.Color != source.Color)
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                }
            }

            return move;
        }

        public MoveInfo CheckLegalMove(Square[,] board, ChessFigure source, ChessFigure destination)
        {
            return new MoveInfo();
        }
    }
}
