using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Database;

namespace Recommendation.Tests
{
    [TestClass()]
    public class RecommendationEngineTests
    {
        [TestMethod()]
        public void GetRecommendedProductsTest1()
        {
            Mock<DBManager> mockDatabase = new Mock<DBManager>();
            List<Product> productList = new List<Product>
            {
                new Product
                {
                    Name = "Produkt A",
                },
                new Product
                {
                    Name = "Produkt B",
                },
                new Product
                {
                    Name = "Produkt C",
                }
            };
            mockDatabase.Setup(x => x.GetAllRatings()).Returns(new List<Rating>());
            mockDatabase.Setup(X => X.GetAllProducts()).Returns(productList);
            var engine = new RecommendationEngine(mockDatabase.Object);
            var result = engine.GetRecommendedProducts(1, 5);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod()]
        public void GetRecommendedProductsTest2()
        {
            Mock<DBManager> mockDatabase = new Mock<DBManager>();
            List<Product> productList = new List<Product>
            {
                new Product
                {
                    Name = "Produkt A",
                },
                new Product
                {
                    Name = "Produkt B",
                },
                new Product
                {
                    Name = "Produkt C",
                },
                new Product
                {
                    Name = "Produkt D",
                },
                new Product
                {
                    Name = "Produkt E",
                },
                new Product
                {
                    Name = "Produkt F",
                }
            };
            mockDatabase.Setup(x => x.GetAllRatings()).Returns(new List<Rating>());
            mockDatabase.Setup(X => X.GetAllProducts()).Returns(productList);
            var engine = new RecommendationEngine(mockDatabase.Object);
            var result = engine.GetRecommendedProducts(1, 5);
            Assert.AreEqual(5, result.Count());
            CollectionAssert.AllItemsAreNotNull(result.ToList());
        }

        [TestMethod()]
        public void GetRecommendedProductsTest3()
        {
            Mock<DBManager> mockDatabase = new Mock<DBManager>();
            List<Product> productList = new List<Product>
            {
                new Product
                {
                    Name = "Produkt A",
                    Product_Id = 1,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt B",
                    Product_Id = 2,
                    Category_Id = 2,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 5
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt C",
                    Product_Id = 3,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 1
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt D",
                    Product_Id = 4,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                }
            };
            List<Rating> ratingList = new List<Rating>
            {
                new Rating
                {
                    Rating_Id = 1,
                    User_id = 1,
                    Product_Id = 1,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 2,
                    User_id = 1,
                    Product_Id = 2,
                    Value = 5
                },
                new Rating
                {
                    Rating_Id = 3,
                    User_id = 1,
                    Product_Id = 3,
                    Value = 1
                }
            };
            mockDatabase.Setup(x => x.GetAllRatings()).Returns(ratingList);
            mockDatabase.Setup(X => X.GetAllProducts()).Returns(productList);
            mockDatabase.Setup(x => x.GetProductById(It.IsAny<int>())).Returns((int Id) => (from Product prod in productList
                                                                                            where prod.Product_Id.Equals(Id)
                                                                                            select prod).First());
            var engine = new RecommendationEngine(mockDatabase.Object);
            var result = engine.GetRecommendedProducts(1, 5);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod()]
        public void GetRecommendedProductsTest4()
        {
            Mock<DBManager> mockDatabase = new Mock<DBManager>();
            List<Product> productList = new List<Product>
            {
                new Product
                {
                    Name = "Produkt A",
                    Product_Id = 1,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt B",
                    Product_Id = 2,
                    Category_Id = 2,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 5
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt C",
                    Product_Id = 3,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 1
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt D",
                    Product_Id = 4,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt E",
                    Product_Id = 5,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 15
                        }
                    }
                },new Product
                {
                    Name = "Produkt F",
                    Product_Id = 6,
                    Category_Id = 2,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                }
                ,new Product
                {
                    Name = "Produkt G",
                    Product_Id = 7,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 15
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt H",
                    Product_Id = 8,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                }
            };
            List<Rating> ratingList = new List<Rating>
            {
                new Rating
                {
                    Rating_Id = 1,
                    User_id = 1,
                    Product_Id = 1,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 2,
                    User_id = 1,
                    Product_Id = 2,
                    Value = 5
                },
                new Rating
                {
                    Rating_Id = 3,
                    User_id = 1,
                    Product_Id = 3,
                    Value = 1
                }
            };
            mockDatabase.Setup(x => x.GetAllRatings()).Returns(ratingList);
            mockDatabase.Setup(X => X.GetAllProducts()).Returns(productList);
            mockDatabase.Setup(x => x.GetProductById(It.IsAny<int>())).Returns((int Id) => (from Product prod in productList
                                                                                            where prod.Product_Id.Equals(Id)
                                                                                            select prod).First());
            var engine = new RecommendationEngine(mockDatabase.Object);
            var result = engine.GetRecommendedProducts(1, 5);
            Assert.AreEqual(5, result.Count());
            CollectionAssert.AllItemsAreNotNull(result.ToList());
        }

        [TestMethod()]
        public void GetRecommendedProductsTest5()
        {
            Mock<DBManager> mockDatabase = new Mock<DBManager>();
            List<Product> productList = new List<Product>
            {
                new Product
                {
                    Name = "Produkt A",
                    Product_Id = 1,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt B",
                    Product_Id = 2,
                    Category_Id = 1,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt C",
                    Product_Id = 3,
                    Category_Id = 2,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt D",
                    Product_Id = 4,
                    Category_Id = 2,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt E",
                    Product_Id = 5,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt F",
                    Product_Id = 6,
                    Category_Id = 3,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt G",
                    Product_Id = 7,
                    Category_Id = 4,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt H",
                    Product_Id = 8,
                    Category_Id = 4,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt I",
                    Product_Id = 9,
                    Category_Id = 5,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 10
                        }
                    }
                },
                new Product
                {
                    Name = "Produkt J",
                    Product_Id = 10,
                    Category_Id = 5,
                    Ratings =
                    {
                        new Rating
                        {
                            Value = 20
                        }
                    }
                }
            };
            List<Rating> ratingList = new List<Rating>
            {
                new Rating
                {
                    Rating_Id = 1,
                    User_id = 1,
                    Product_Id = 1,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 2,
                    User_id = 1,
                    Product_Id = 3,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 3,
                    User_id = 1,
                    Product_Id = 5,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 4,
                    User_id = 1,
                    Product_Id = 7,
                    Value = 10
                },
                new Rating
                {
                    Rating_Id = 5,
                    User_id = 1,
                    Product_Id = 9,
                    Value = 10
                }
            };
            mockDatabase.Setup(x => x.GetAllRatings()).Returns(ratingList);
            mockDatabase.Setup(X => X.GetAllProducts()).Returns(productList);
            mockDatabase.Setup(x => x.GetProductById(It.IsAny<int>())).Returns((int Id) => (from Product prod in productList
                                                                                            where prod.Product_Id.Equals(Id)
                                                                                            select prod).First());
            var expected = (from Product prod in productList
                            where prod.Product_Id % 2 == 0
                            select prod).ToList();
            var engine = new RecommendationEngine(mockDatabase.Object);
            var result = engine.GetRecommendedProducts(1, 5).ToList();
            Assert.AreEqual(5, result.Count());
            CollectionAssert.AllItemsAreNotNull(result);
            CollectionAssert.AreEqual(expected, result);
            
        }
    }
}