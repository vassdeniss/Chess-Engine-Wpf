using ChessEngine.Common;

namespace ChessEngine.Data.Models
{
    public class MoveInfo
    {
        public MoveInfo(bool isAllowed)
        {
            this.IsAllowed = isAllowed;

            this.SourceRow = GlobalConstants.OffBoard;
            this.SourceColumn = GlobalConstants.OffBoard;
            this.DestinationRow = GlobalConstants.OffBoard;
            this.DestinationColumn = GlobalConstants.OffBoard;
        }

        public bool IsAllowed { get; set; }

        public int SourceRow { get; set; }

        public int SourceColumn { get; set; }

        public int DestinationRow { get; set; }

        public int DestinationColumn { get; set; }

        public int TakenFigureRow { get; set; }

        public int TakenFigureColumn { get; set; }
    }
}
