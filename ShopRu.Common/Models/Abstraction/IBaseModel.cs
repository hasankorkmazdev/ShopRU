namespace ShopRu.Common.Models.Abstraction
{
    public interface IBaseModel<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
