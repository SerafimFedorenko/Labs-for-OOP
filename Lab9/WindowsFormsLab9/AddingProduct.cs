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
    public partial class AddingProduct : Form
    {
        Shop shop;
        public AddingProduct(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price;
            if(Double.TryParse(textBox2.Text, out price))
            {
                try
                {
                    Product product = new Product(textBox1.Text, price);
                    product *= (int)numericUpDown1.Value;
                    shop.AddProduct(product);
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
