using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    /// <summary>
    /// Класс - магазин, хранит список покупок и действия над ним
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Список покупок
        /// </summary>
        public List<Product> shoppingList = new List<Product>(){};
        /// <summary>
        /// Конструктор класса Shop
        /// </summary>
        public Shop()
        {

        }
        /// <summary>
        /// Метод, добавляющий породукт в список покупок
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            shoppingList.Add(product);
        }
        /// <summary>
        /// Метод, вычисляющий общую сумму покупок
        /// </summary>
        public double CalcSum()
        {
            double sumOfProducts = 0;
            foreach (Product product in shoppingList)
            {
                sumOfProducts += product;
            }
            return sumOfProducts;
        }
    }
}
