using ShopRu.Common.Models.Abstraction;

namespace ShopRu.Common.Models
{
    public class Discount : BaseModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
