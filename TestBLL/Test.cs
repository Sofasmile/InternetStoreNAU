using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL.Server;
using Moq;
using DAL;
using AutoMapper;
using BLL.Infrastructure;
using BLL;

namespace TestBLL
{
    [TestClass]
    public class Test
    {
        private Category_Operation CatgO;
        private User_Operation UserO;
        private Product_Operation ProdO;
        Mock<IUnit_Of_Work> mockConteiner;
        Mock<Database_Context> mockModel;
        Mock<Repository<DB_Category>> mockCategories;
        Mock<Repository<DB_User>> mockUsers;
        Mock<Repository<DB_Product>> mockProducts;

        public void Data()
        {
            mockConteiner = new Mock<IUnit_Of_Work>();
            mockModel = new Mock<Database_Context>();
            mockCategories = new Mock<Repository<DB_Category>>();
            mockProducts = new Mock<Repository<DB_Product>>();
            mockUsers = new Mock<Repository<DB_User>>();
            CatgO = new Category_Operation();
            UserO = new User_Operation();
            ProdO = new Product_Operation();
        }

        [TestMethod]
        public void TestGetCategories()
        {
            Mapper_Config.Initialize();
            Data();
            List<DB_Category> categories = new List<DB_Category>();
            DB_Category catg1 = new DB_Category();
            DB_Category catg2 = new DB_Category();
            categories.Add(catg1);
            categories.Add(catg2);

            mockConteiner.Setup(a => a.Categories).Returns(mockCategories.Object);
            mockCategories.Setup(a => a.Get()).Returns(categories);
            List<Category> result = new List<Category>();
            result = Mapper.Map<List<DB_Category>, List<Category>>(categories);

            NUnit.Framework.Assert.AreEqual(result.Capacity, CatgO.GetAllCategories().Capacity);
        }

        [TestMethod]
        public void TestGetProducts()
        {
            Mapper_Config.Initialize();
            Data();
            List<DB_Product> products = new List<DB_Product>();
            DB_Product p1 = new DB_Product();
            DB_Product p2 = new DB_Product();
            products.Add(p1);
            products.Add(p2);

            mockConteiner.Setup(a => a.Products).Returns(mockProducts.Object);
            mockProducts.Setup(a => a.Get()).Returns(products);
            List<Product> result = new List<Product>();
            result = Mapper.Map<List<DB_Product>, List<Product>>(products);

            NUnit.Framework.Assert.AreEqual(result.Capacity, ProdO.GetAllProducts().Capacity);
        }

        [TestMethod]
        public void TestCheckTitle()
        {
            Data();
            List<DB_Category> categories = new List<DB_Category>();
            DB_Category catg1 = new DB_Category();
            DB_Category catg2 = new DB_Category();
            categories.Add(catg1);
            categories.Add(catg2);

            mockConteiner.Setup(a => a.Categories).Returns(mockCategories.Object);
            mockCategories.Setup(a => a.Get()).Returns(categories);

            NUnit.Framework.Assert.AreEqual(true, CatgO.CheckTitle(null));

        }

        [TestMethod]
        public void TestCheckPost()
        {
            Mapper_Config.Initialize();
            Data();
            List<DB_Product> products = new List<DB_Product>();
            DB_Product p1 = new DB_Product();
            DB_Product p2 = new DB_Product();
            products.Add(p1);
            products.Add(p2);

            mockConteiner.Setup(a => a.Products).Returns(mockProducts.Object);
            mockProducts.Setup(a => a.Get()).Returns(products);
            List<Product> result = new List<Product>();
            result = Mapper.Map<List<DB_Product>, List<Product>>(products);

            NUnit.Framework.Assert.AreEqual(true, ProdO.CheckCode(null));
        }

        [TestMethod]
        public void TestCheckUser()
        {
            Mapper_Config.Initialize();
            Data();
            List<DB_User> users = new List<DB_User>();
            DB_User u1 = new DB_User();
            DB_User u2 = new DB_User();
            users.Add(u1);
            users.Add(u2);

            mockConteiner.Setup(a => a.Users).Returns(mockUsers.Object);
            mockUsers.Setup(a => a.Get()).Returns(users);
            List<User> result = new List<User>();
            result = Mapper.Map<List<DB_User>, List<User>>(users);

            NUnit.Framework.Assert.AreEqual(true, UserO.CheckUser(null,null));
        }

        [TestMethod]
        public void TestGetProduct()
        {
            Data();
            List<DB_Product> products = new List<DB_Product>();
            DB_Product p1 = new DB_Product();
            products.Add(p1);

            mockConteiner.Setup(a => a.Products).Returns(mockProducts.Object);
            mockProducts.Setup(a => a.Get()).Returns(products);
            Product result = new Product();
            result = Mapper.Map<DB_Product, Product>(p1);

            NUnit.Framework.Assert.AreEqual(result.ProductID, ProdO.GetProduct(0).ProductID);
        }

        [TestMethod]
        public void TestGetCategory()
        {
            Data();
            List<DB_Category> categories = new List<DB_Category>();
            DB_Category catg1 = new DB_Category();
            categories.Add(catg1);

            mockConteiner.Setup(a => a.Categories).Returns(mockCategories.Object);
            mockCategories.Setup(a => a.Get()).Returns(categories);
            Category result = new Category();
            result = Mapper.Map<DB_Category, Category>(catg1);
            
            NUnit.Framework.Assert.AreEqual(result.CategoryID, CatgO.GetCategory(0).CategoryID);
        }

        [TestMethod]
        public void TestGetUser()
        {
            Data();
            List<DB_User> users = new List<DB_User>();
            DB_User u1= new DB_User();
            users.Add(u1);

            mockConteiner.Setup(a => a.Users).Returns(mockUsers.Object);
            mockUsers.Setup(a => a.Get()).Returns(users);
            User result = new User();
            result = Mapper.Map<DB_User, User>(u1);
            
            NUnit.Framework.Assert.AreEqual(result.Id, UserO.GetUser(0).Id);
        }

    }
}
