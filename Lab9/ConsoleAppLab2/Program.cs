using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLibrary;

namespace ConsoleAppLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop theShop = new Shop();
            Product product;
            Product product1;
            Product product2;
            string check = "";
            string menuItem;
            double sum;
            int quantity;
            string name;
            double price;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine("1. Добавить товар (c указанием количества);");
                Console.WriteLine("2. Вычислить сумму двух товаров (без добавления в список покупок);");
                Console.WriteLine("3. Посмотреть чек;");
                Console.WriteLine("4. Выход.");
                menuItem = Console.ReadLine();
                Console.Clear();
                switch (menuItem)
                {
                    case "1":
                        Console.WriteLine("Введите наименование товара");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите цену товара");
                        price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите количество товара");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        product = new Product(name, price);
                        product = product * quantity;
                        theShop.AddProduct(product);
                        check += name + "\n           " + quantity + " X " + price.ToString("0.00") +
                            "\n              =" + (price * quantity).ToString("0.00") + "\n" + "----------------------\n";
                        break;
                    case "2":
                        Console.WriteLine("Введите наименование первого товара");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите цену первого товара");
                        price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите количество товара");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        product1 = new Product(name, price);
                        product1 *= quantity;
                        Console.WriteLine("Введите наименование второго товара");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите цену второго товара");
                        price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите количество товара");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        product2 = new Product(name, price);
                        product2 *= quantity;
                        sum = product1 + product2;
                        Console.WriteLine("Сумма двух товаров: " + sum);
                        break;
                    case "3":
                        Console.WriteLine(check);
                        Console.WriteLine("Всего: " + theShop.CalcSum() + " руб.");
                        break;
                    case "4":
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Введён неверный пункт меню");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
            while (menuItem != "4");
        }
    }
}