using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Models;
using api.Controllers;
using NUnit.Framework;

namespace UnitTestsApi
{
    public class DbContextTests
    {
        private DatabaseContext _dbContext;


        public DbContextTests()
        {
            setup();
        }

        [SetUp]
        public void setup()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>()
               .EnableSensitiveDataLogging()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new DatabaseContext(builder.Options);

            //Creating the mock products for tests
            var products = Enumerable.Range(1, 10)
            .Select(i => new Product { ProductId = i, Name = $"Sample{i}", Description = $"Sample{i}", Price = 0 });

            //Creating the mock users for tests 
            var users = Enumerable.Range(1, 10)
           .Select(i => new User { UserId = i, Username = $"user{i}", Password = $"pass{i}", Phone = "phone", Email = $"email{i}@outlook.com" });

            //creating the mock orders for tests
            var orders = Enumerable.Range(1, 10)
            .Select(i => new Order { OrderId = i, CustomerId = i, Total = "0", PostalCode = "postal", Adres = "adres", HouseNumber = $"{i}", OrderDate = new DateTime(), OrderProducts = new List<OrderLine>() });

            //creating the mock orders for tests
            var orderlines = Enumerable.Range(1, 10)
           .Select(i => new OrderLine { OrderId = i, ProductId = i, Amount = i });

            //add all the mock data to the inmemory db
            context.Product.AddRange(products);
            context.Order.AddRange(orders);
            context.User.AddRange(users);
            context.OrderLine.AddRange(orderlines);


            int changed = context.SaveChanges();
            //set dbcontext
            _dbContext = context;
        }

        [Test]
        public async Task CreateProductTest()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }
    }
}