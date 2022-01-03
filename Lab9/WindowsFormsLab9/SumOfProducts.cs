using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductLibrary;
using ExceptionLibrary;

namespace WindowsFormsLab9
{
    public partial class SumOfProducts : Form
    {
        public SumOfProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price1, price2;
            if(Double.TryParse(textBox3.Text, out price1) && Double.TryParse(textBox4.Text, out price2))
            {
                try
                {
                    Product product1 = new Product(textBox1.Text, price1);
                    product1 *= (int)numericUpDown1.Value;
                    Product product2 = new Product(textBox2.Text, price2);
                    product2 *= (int)numericUpDown2.Value;
                    MessageBox.Show($"Сумма товаров {product1.Name} и {product2.Name}: {product1 + product2}");
                }
                catch(InvalidProductException ex)
                {
                    MessageBox.Show(ex.Message + "\n Стоимость товара:" + ex.Price);
                }
            }
            else
            {
                MessageBox.Show("Некорректная цена");
            }
        }
    }
}
