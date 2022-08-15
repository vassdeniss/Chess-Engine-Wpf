using ChessEngine.Data.Common.Models.Interfaces;

namespace ChessEngine.Data.Common.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public string Id { get; set; } = default!;
    }
}
