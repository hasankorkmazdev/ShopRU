using ShopRu.Common.Enums;
using ShopRu.Common.Models.Abstraction;

namespace ShopRu.Common.Models
{
    public class User : BaseModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string FullName { get { return $"{this.Name} {this.Surname}"; } }

        public UserType UserType { get; set; }
    }
}
