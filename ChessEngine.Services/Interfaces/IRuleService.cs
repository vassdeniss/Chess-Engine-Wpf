using ChessEngine.Data.Models;

namespace ChessEngine.Services.Interfaces
{
    public interface IRuleService
    {
        MoveInfo CheckLegalMove(Square[,] board, Pawn source, ChessFigure destination);

        MoveInfo CheckLegalMove(Square[,] board, Knight source, ChessFigure destination);

        MoveInfo CheckLegalMove(Square[,] board, Bishop source, ChessFigure destination);

        MoveInfo CheckLegalMove(Square[,] board, Rook source, ChessFigure destination);

        MoveInfo CheckLegalMove(Square[,] board, ChessFigure source, ChessFigure destination);
    }
}
