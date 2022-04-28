namespace ShopRu.Common.Exceptions
{
    [Serializable]
    public class InvoiceUserNullException : ArgumentNullException
    {
        public InvoiceUserNullException() : base("User", "Invoice User Not Null") { }
    }
}
