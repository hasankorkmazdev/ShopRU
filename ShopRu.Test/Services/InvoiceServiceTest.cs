using NUnit.Framework;
using ShopRu.Common.Exceptions;
using ShopRu.Common.Models;
using ShopRu.Service.Services;
using ShopRu.Service.Services.Abstraction;
using System;
using System.Collections.Generic;
namespace ShopRu.Test.Services
{

    public class InvoiceServiceTest
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceServiceTest()
        {
            _invoiceService = new InvoiceService();
        }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        [SetUp]
        public void Setup()
        {
            MockData();
        }

        [Test]
        public void AmountCheckForEmployee()
        {
            var discountTotal = _invoiceService.ApplyDiscountOnInvoice(Invoices[0]);
            Assert.AreEqual(225, discountTotal);
        }

        [Test]
        public void AmountCheckForCustomer()
        {
            var discountTotal = _invoiceService.ApplyDiscountOnInvoice(Invoices[1]);
            Assert.AreEqual(275, discountTotal);
        }
        [Test]
        public void AmountCheckForStoreAffilate()
        {
            var discountTotal = _invoiceService.ApplyDiscountOnInvoice(Invoices[2]);
            Assert.AreEqual(265, discountTotal);
        }
        [Test]
        public void HandleUserNull()
        {
            Assert.Throws<InvoiceUserNullException>(() => _invoiceService.ApplyDiscountOnInvoice(Invoices[3]));
        }

        [Test]
        public void HandleInvoiceItemsSumException()
        {
            Assert.Throws<InvoiceItemsSumException>(() => _invoiceService.ApplyDiscountOnInvoice(Invoices[4]));
        }

        private void MockData()
        {
            var _invoices = new List<Invoice>() { };
            _invoices.Add(new Invoice()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,

                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hasan",
                    Surname = "Korkmaz",
                    UserType = Common.Enums.UserType.Employee,
                },
                InvoiceItems = new List<InvoiceItem>()
                {
                    new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Kivi"
                    },
                     new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Armut"
                    },
                      new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Other,
                        Price=100,
                        Name="Sabun"
                    },
                }
            });
            _invoices.Add(new Invoice()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Celal",
                    Surname = "Şengör",
                    UserType = Common.Enums.UserType.Customer,
                },
                InvoiceItems = new List<InvoiceItem>()
                {
                    new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Kivi"
                    },
                     new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Armut"
                    },
                      new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Other,
                        Price=100,
                        Name="Sabun"
                    },
                }
            });
            _invoices.Add(new Invoice()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "İlber",
                    Surname = "Ortaylı",
                    UserType = Common.Enums.UserType.AffilateOfTheStore,
                },
                InvoiceItems = new List<InvoiceItem>()
                {
                    new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Kivi"
                    },
                     new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Armut"
                    },
                      new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Other,
                        Price=100,
                        Name="Sabun"
                    },
                }
            });
            _invoices.Add(new Invoice()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User = null,
                InvoiceItems = new List<InvoiceItem>()
                {
                    new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Kivi"
                    },
                     new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Grocery,
                        Price=100,
                        Name="Armut"
                    },
                      new InvoiceItem()
                    {
                        Id=Guid.NewGuid(),
                        CategoryType=Common.Enums.InvoiceItemCategoryType.Other,
                        Price=100,
                        Name="Sabun"
                    },
                }
            }
            );
            _invoices.Add(new Invoice()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cüneyt",
                    Surname = "Özdemir",
                    UserType = Common.Enums.UserType.AffilateOfTheStore,
                }
            }
            );
            Invoices = _invoices;
        }
    }
}
