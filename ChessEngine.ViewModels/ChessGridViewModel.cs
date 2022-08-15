using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

using ChessEngine.Data.Models;
using ChessEngine.Services.Interfaces;

namespace ChessEngine.ViewModels
{
    public class ChessGridViewModel
    {
        private readonly IBoardGeneratorService boardGenerator;
        private ICommand initCommand;

        public ChessGridViewModel(IBoardGeneratorService boardGenerator)
        {
            this.boardGenerator = boardGenerator;

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

        public void Initialise(object data)
        {
            Square[,] board = this.boardGenerator.Generate();
            foreach (Square square in board)
            {
                this.ChessGrid.Add(square);
            }
        }
    }
}
