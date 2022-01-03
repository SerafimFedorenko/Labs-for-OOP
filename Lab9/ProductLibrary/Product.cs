using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLibrary;

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
        public string Name { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Конструктор класса product с присваиванием значений полям наименование, цена продукта и количество товара
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Product(string name, double price)
        {
            if(name == "")
            {
                throw new InvalidProductException("Имя товара не содердит ни одного символа");
            }
            if (price == 0)
            {
                throw new InvalidProductException("Нулевая стоимость товара", price);
            }
            if (price > 10000)
            {
                throw new InvalidProductException("Слишком большая стоимость товара (больше 10000)", price);
            }
            Name = name;
            Price = price;
        }
        /// <summary>
        /// Оператор +, перегруженный для сложения двух товаров
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <returns></returns>
        public static double operator +(Product prod1, Product prod2)
        {
            if(prod1 == null || prod2 == null)
            {
                throw new InvalidProductException("Один или оба из товаров не определены");
            }
            return prod1.Price + prod2.Price;
        }
        /// <summary>
        /// Оператор +, перегруженный для сложения товара и числа
        /// </summary>
        /// <param name="num"></param>
        /// <param name="prod2"></param>
        /// <returns></returns>
        public static double operator +(double num, Product prod2)
        {
            if (num > 100000)
            {
                throw new InvalidProductException("Слишком большая прибавляемая стоимость (больше 100000)");
            }
            if (prod2 == null)
            {
                throw new InvalidProductException("Товаров не определён");
            }
            return num + prod2.Price;
        }
        /// <summary>
        /// Оператор *, перегруженный для умножения двух товаров
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static Product operator *(Product prod1, int quantity)
        {
            if (quantity == 0)
            {
                throw new InvalidProductException("Некоректное количество товаров");
            }
            if(quantity > 1000)
            {
                throw new InvalidProductException("Слишком много товаров (больше 1000)");
            }
            if (prod1 == null)
            {
                throw new InvalidProductException("Товар не определён");
            }
            prod1.Price = quantity * prod1.Price;
            return prod1;
        }
        /// <summary>
        /// Переопределение метода тустринг
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(this == null)
            {
                throw new InvalidProductException("Товар не определён");
            }
            return Name + " " + Price + " руб.";
        }
    }
}