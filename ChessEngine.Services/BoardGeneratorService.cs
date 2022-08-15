using ChessEngine.Data.Models;
using ChessEngine.Data.Models.Enums;
using ChessEngine.Services.Interfaces;

using static ChessEngine.Common.GlobalConstants;

namespace ChessEngine.Services
{
    public class BoardGeneratorService : IBoardGeneratorService
    {
        public Square[,] Generate()
        {
            Square[,] board = new Square[BoardRows, BoardColumns];
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    Square square;
                    ChessFigure figure = this.GetFigure(i, j);

                    if ((i + j) % 2 == 0)
                    {
                        square = new Square(i, j, Color.White, figure);
                    }
                    else
                    {
                        square = new Square(i, j, Color.Black, figure);
                    }

                    board[i, j] = square;
                }
            }

            return board;
        }

        private ChessFigure GetFigure(int row, int col)
        {
            ChessFigure figure = new Empty(row, col);

            if (row == 0)
            {
                if (col == 0 || col == 7)
                {
                    figure = new Rook(row, col, Color.Black);
                }

                if (col == 1 || col == 6)
                {
                    figure = new Knight(row, col, Color.Black);
                }

                if (col == 2 || col == 5)
                {
                    figure = new Bishop(row, col, Color.Black);
                }

                if (col == 4)
                {
                    figure = new King(row, col, Color.Black);
                }

                if (col == 3)
                {
                    figure = new Queen(row, col, Color.Black);
                }
            }

            if (row == 1)
            {
                figure = new Pawn(row, col, Color.Black);
            }

            if (row == 6)
            {
                figure = new Pawn(row, col, Color.White);
            }

            if (row == 7)
            {
                if (col == 0 || col == 7)
                {
                    figure = new Rook(row, col, Color.White);
                }

                if (col == 1 || col == 6)
                {
                    figure = new Knight(row, col, Color.White);
                }

                if (col == 2 || col == 5)
                {
                    figure = new Bishop(row, col, Color.White);
                }

                if (col == 4)
                {
                    figure = new King(row, col, Color.White);
                }

                if (col == 3)
                {
                    figure = new Queen(row, col, Color.White);
                }
            }

            return figure;
        }
    }
}
