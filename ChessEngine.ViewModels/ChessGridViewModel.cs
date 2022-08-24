using System.Collections.ObjectModel;
using System.Windows.Input;

using ChessEngine.Data.Models;
using ChessEngine.Services.Interfaces;

namespace ChessEngine.ViewModels
{
    // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable CS8618 
    // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class ChessGridViewModel
    {
        private readonly IBoardGeneratorService boardGeneratorService;
        private readonly IRuleService ruleService;
        private ICommand initCommand;
        private ICommand dragInitCommand;
        private ICommand dragOverCommand;
        private Square[,] board;
        private ChessFigure selectedFigure;

        public ChessGridViewModel(IBoardGeneratorService boardGeneratorService, IRuleService ruleService)
        {
            this.boardGeneratorService = boardGeneratorService;
            this.ruleService = ruleService;

            this.ChessGrid = new ObservableCollection<Square>();
        }

        public ObservableCollection<Square> ChessGrid { get; set; }

        public ICommand InitialiseCommand
        {
            get
            {
                if (this.initCommand == null)
                {
                    this.initCommand = new RelayCommand<object>(this.Initialise);
                }
                    
                return this.initCommand;
            }
        }

        public ICommand DragInitialiseCommand
        {
            get
            {
                if (this.dragInitCommand == null)
                {
                    this.dragInitCommand = new RelayCommand<ChessFigure>(this.DragInitialise);
                }

                return this.dragInitCommand;
            }
        }

        public ICommand DragOverCommand
        {
            get
            {
                if (this.dragOverCommand == null)
                {
                    this.dragOverCommand = new RelayCommand<ChessFigure>(this.DragOver);
                }

                return this.dragOverCommand;
            }
        }

        public void Initialise(object data)
        {
            this.board = this.boardGeneratorService.Generate();
            foreach (Square square in board)
            {
                this.ChessGrid.Add(square);
            }
        }

        public void DragInitialise(ChessFigure figure)
        {
            this.selectedFigure = figure;
        }

        public void DragOver(ChessFigure figure)
        {
            // Get the figure with the appropriate runtime type
            dynamic dynamicFigure = this.selectedFigure;

            // Check if the move is valid
            if (!this.ruleService.CheckLegalMove(this.board, dynamicFigure, figure).IsAllowed)
            {
                return;
            }

            // Get the two squares
            Square sourceSquare = this.board[this.selectedFigure.Row, this.selectedFigure.Column];
            Square destinationSquare = this.board[figure.Row, figure.Column];
            
            // Get the squares indices
            int sourceIndex = this.ChessGrid.IndexOf(sourceSquare);
            int destinationIndex = this.ChessGrid.IndexOf(destinationSquare);

            // Remove the piece from the source tile
            Square newSourceSquare = new Square(sourceSquare.Row,
                sourceSquare.Column,
                sourceSquare.Color,
                new Empty(sourceSquare.Row, sourceSquare.Column));
            this.ChessGrid[sourceIndex] = newSourceSquare;

            // Move the piece to the destination tile
            this.selectedFigure.Row = destinationSquare.Row;
            this.selectedFigure.Column = destinationSquare.Column;
            Square newDestinationSquare = new Square(destinationSquare.Row,
                destinationSquare.Column,
                destinationSquare.Color,
                this.selectedFigure);
            this.ChessGrid[destinationIndex] = newDestinationSquare;

            // Update the board
            this.board[sourceSquare.Row, sourceSquare.Column] = newSourceSquare;
            this.board[destinationSquare.Row, destinationSquare.Column] = newDestinationSquare;
        }
    }
}
