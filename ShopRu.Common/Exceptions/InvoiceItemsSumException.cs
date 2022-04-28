namespace ShopRu.Common.Exceptions
{
    [Serializable]
    public class InvoiceItemsSumException : Exception
    {
        public InvoiceItemsSumException() : base("Sum of InvoiceItems Cannot be less than 0") { }

    }
}
