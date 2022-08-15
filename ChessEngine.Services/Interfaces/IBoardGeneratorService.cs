using ChessEngine.Data.Models;

namespace ChessEngine.Services.Interfaces
{
    public interface IBoardGeneratorService
    {
        Square[,] Generate();   
    }
}
