namespace ShopRu.Common.Models.Abstraction
{
    public abstract class BaseModel<TPrimaryKey> : IBaseModel<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

    }
}
