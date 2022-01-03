using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLibrary;

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
        public List<Product> ShoppingList = new List<Product>() { };
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
            if(product == null)
            {
                throw new InvalidProductException("Товар не определён");
            }
            ShoppingList.Add(product);
        }
        /// <summary>
        /// Метод, вычисляющий общую сумму покупок
        /// </summary>
        public double CalcSum()
        {
            if(ShoppingList.Count == 0)
            {
                throw new InvalidProductException("Товаров нет в списке");
            }
            double sumOfProducts = 0;
            foreach (Product product in ShoppingList)
            {
                sumOfProducts += product;
            }
            return sumOfProducts;
        }
        /// <summary>
        /// Переопределение метода тустринг
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Итого: " + CalcSum() + " руб.";
        }
    }
}