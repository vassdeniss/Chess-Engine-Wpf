using ChessEngine.Data.Common.Models.Interfaces;

namespace ChessEngine.Data.Common.Models
{
    public abstract class BasePositionModel : BaseModel, IBasePositionModel
    {
        public int Row { get; set; }

        public int Column { get; set; }
    }
}
