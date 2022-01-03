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
    public partial class Form1 : Form
    {
        Shop shop = new Shop();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Shop shop)
        {
            this.shop = shop;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingProduct addingProduct = new AddingProduct(shop);
            addingProduct.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SumOfProducts sumOfProducts = new SumOfProducts();
            sumOfProducts.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(shop.ShoppingList.Count > 0)
            {
                
                try
                {
                    BasketOfProducts basketOfProducts = new BasketOfProducts(shop);
                    basketOfProducts.Show();
                }
                catch(InvalidProductException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Корзина пуста");
            }
            
        }
    }
}
