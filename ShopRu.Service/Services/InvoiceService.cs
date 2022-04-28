using ShopRu.Common.Exceptions;
using ShopRu.Common.Models;
using ShopRu.Service.Services.Abstraction;

namespace ShopRu.Service.Services
{
    public class InvoiceService : IInvoiceService
    {


        public decimal ApplyDiscountOnInvoice(Invoice invoice)
        {
            var amountDiscount = ApplyAmountDiscount(invoice);
            var userDiscount = ApplyUserDiscount(invoice);
            return (invoice.InvoiceItems.Sum(x => x.Price) - amountDiscount - userDiscount);
        }

        private decimal ApplyAmountDiscount(Invoice invoice)
        {
            var invoiceAmount = invoice.InvoiceItems.Sum(x => x.Price);
            if (invoiceAmount <= 0)
                throw new InvoiceItemsSumException();
            var amountDiscount = (invoiceAmount / 100) * 5;
            invoice.Discounts.Add(new Discount()
            {
                Id = Guid.NewGuid(),
                Name = "Amount Discount",
                Amount = amountDiscount,
            });
            return amountDiscount;

        }


        private decimal ApplyUserDiscount(Invoice invoice)
        {
            if (invoice.User == null)
            {
                throw new InvoiceUserNullException();
            }
            decimal discountRate = 0;
            decimal totalDiscount = 0;
            switch (invoice.User.UserType)
            {
                case Common.Enums.UserType.Employee:
                    discountRate = 0.3M;
                    break;
                case Common.Enums.UserType.AffilateOfTheStore:
                    discountRate = 0.1M;
                    break;
                case Common.Enums.UserType.Customer:
                    discountRate = 0.05M;
                    break;
            }
            invoice.InvoiceItems.ForEach(x =>
            {
                if (x.CategoryType == Common.Enums.InvoiceItemCategoryType.Grocery)
                    totalDiscount += (x.Price * discountRate);
            });
            invoice.Discounts.Add(new Discount()
            {
                Id = Guid.NewGuid(),
                Name = "Total Discount",
                Amount = totalDiscount,
            });
            return totalDiscount;
        }
    }
}
