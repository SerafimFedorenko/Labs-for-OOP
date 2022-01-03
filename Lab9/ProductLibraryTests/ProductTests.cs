using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLibrary;

namespace ProductLibrary.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [DataTestMethod()]
        [DataRow("Беляш", 1.5, "Чебурек", 1.15, 2.65)]
        [DataRow("Пельмени, 0,5кг", 1.65, "Доширак", 1.05, 2.7)]
        [DataRow("Помидор", 0.65, "Гуляш", 1.05, 1.7)]
        [DataRow("Пицца", 3.25, "Спагетти", 15.05, 18.3)]
        [DataRow("Йогурт", 1.25, "Бургер", 5.05, 6.3)]
        [DataRow("Хлебцы", 1.05, "Греча", 3.95, 5)]
        [DataRow("Хачапури", 9, "Салат", 5, 14)]
        public void ProductSumTest(string name1, double price1, string name2, double price2, double expSum)
        {
            Product Belyash = new Product(name1, price1);
            Product Cheburek = new Product(name2, price2);
            Assert.AreEqual(Cheburek + Belyash, expSum, 0.1);
        }

        [DataTestMethod()]
        [DataRow("Масло", 1.15, 9, 10.35)]
        [DataRow("Бананы", 0.65, 10, 6.5)]
        [DataRow("Чай", 0.95, 10, 9.5)]
        [DataRow("Ряженка", 0.8, 5, 4)]
        [DataRow("Наггетсы, 0,5 кг", 4.65, 2, 9.3)]
        [DataRow("Креветки, 1 кг", 10.85, 10, 108.5)]
        [DataRow("Рыбные палочки, 1 кг", 3.05, 5, 15.25)]
        public void ProductMultTest(string name1, double price1, int quantity, double expMult)
        {
            Product product = new Product(name1, price1);
            Product expProduct = new Product(name1, expMult);
            Assert.AreEqual((product * quantity).Price, expProduct.Price);
        }
        [TestMethod]
        public void ExceptionTest()
        {
            try
            {
                Product product1 = new Product("", 100);
            }
            catch(InvalidProductException ex)
            {
                Assert.AreEqual("Имя товара не содердит ни одного символа", ex.Message);
            }
            try
            {
                Product product1 = new Product("Чебурек", 1000000);
            }
            catch (InvalidProductException ex)
            {
                Assert.AreEqual("Слишком большая стоимость товара (больше 10000)", ex.Message);
            }
        }
    }
}