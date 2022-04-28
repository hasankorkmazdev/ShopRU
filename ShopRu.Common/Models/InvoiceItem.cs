using ShopRu.Common.Enums;
using ShopRu.Common.Models.Abstraction;

namespace ShopRu.Common.Models
{
    public class InvoiceItem : BaseModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public InvoiceItemCategoryType CategoryType { get; set; }
        public decimal Price { get; set; }
    }
}
