using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    /// <summary>
    /// Класс продукт, содержащий наименование, цену продукта и количество товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string name;
        /// <summary>
        /// Цена товара
        /// </summary>
        public double price;
        /// <summary>
        /// Конструктор класса product с присваиванием значений полям наименование, цена продукта и количество товара
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Product(string name,double price)
        {
            this.name = name;
            this.price = price;
        }
        /// <summary>
        /// Оператор +, перегруженный для сложения двух товаров
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <returns></returns>
        public static double operator +(Product prod1, Product prod2)
        {
            return prod1.price + prod2.price;
        }
        /// <summary>
        /// Оператор +, перегруженный для сложения товара и числа
        /// </summary>
        /// <param name="num"></param>
        /// <param name="prod2"></param>
        /// <returns></returns>
        public static double operator +(double num, Product prod2)
        {
            return num + prod2.price;
        }
        /// <summary>
        /// Оператор *, перегруженный для умножения двух товаров
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static Product operator *(Product prod1, int quantity)
        {
            prod1.price = quantity * prod1.price;
            return prod1;
        }
    }
}
