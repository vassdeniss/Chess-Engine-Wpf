namespace ChessEngine.Data.Models
{
    public class MoveInfo
    {
        public MoveInfo(bool isAllowed = false)
        {
            this.IsAllowed = isAllowed;
        }

        public bool IsAllowed { get; set; }
    }
}
