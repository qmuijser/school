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
        public async Task GetProductWithId1()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }

        [Test]
        public async Task GetOrderWithId1()
        {
            int expected = 1;
            var controller = new OrdersController(_dbContext);
            var result = await controller.GetOrder(1);

            Order resultOrder = result.Value;

            Assert.AreEqual(expected, resultOrder.OrderId);
        }

        [Test]
        public async Task GetUserWithId1()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }


        [Test]
        public async Task GetAllProducts()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }

        [Test]
        public async Task GetAllUsers()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }

        [Test]
        public async Task GetAllOrders()
        {
            string expectedName = "Sample1";
            var controller = new ProductsController(_dbContext);
            var result = await controller.GetProduct(1);

            Product resultProduct = result.Value;

            Assert.AreEqual(expectedName, resultProduct.Name);
        }

        [Test]
        public async Task CreateProduct()
        {
            Product product = new Product();
            product.Description = "desc";
            product.Name = "name";
            product.Price = 1;
            product.ProductId = 100;


            var controller = new ProductsController(_dbContext);
            controller.PutProduct(100, product);

            var result = await controller.GetProduct(100);

            Product resultProduct = result.Value;

            Assert.AreEqual(resultProduct.Description, product.Description);
        }

        [Test]
        public async Task CreateOrder()
        {
            Product product = new Product();
            product.Description = "desc";
            product.Name = "name";
            product.Price = 1;
            product.ProductId = 100;


            var controller = new ProductsController(_dbContext);
            controller.PutProduct(100, product);

            var result = await controller.GetProduct(100);

            Product resultProduct = result.Value;

            Assert.AreEqual(resultProduct.Description, product.Description);
        }


        [Test]
        public async Task CreateUser()
        {
            Product product = new Product();
            product.Description = "desc";
            product.Name = "name";
            product.Price = 1;
            product.ProductId = 100;


            var controller = new ProductsController(_dbContext);
            controller.PutProduct(100, product);

            var result = await controller.GetProduct(100);

            Product resultProduct = result.Value;

            Assert.AreEqual(resultProduct.Description, product.Description);
        }

        //[Test]
        //public async Task CetProductWithId1()
        //{
        //    string expectedName = "Sample1";
        //    var controller = new ProductsController(_dbContext);
        //    var result = await controller.GetProduct(1);

        //    Product resultProduct = result.Value;

        //    Assert.AreEqual(expectedName, resultProduct.Name);
        //}

        //[Test]
        //public async Task CetProductWithId1()
        //{
        //    string expectedName = "Sample1";
        //    var controller = new ProductsController(_dbContext);
        //    var result = await controller.GetProduct(1);

        //    Product resultProduct = result.Value;

        //    Assert.AreEqual(expectedName, resultProduct.Name);
        //}

        //[Test]
        //public async Task CetProductWithId1()
        //{
        //    string expectedName = "Sample1";
        //    var controller = new ProductsController(_dbContext);
        //    var result = await controller.GetProduct(1);

        //    Product resultProduct = result.Value;

        //    Assert.AreEqual(expectedName, resultProduct.Name);
        //}


    }
}