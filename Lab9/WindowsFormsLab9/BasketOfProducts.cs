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

namespace WindowsFormsLab9
{
    public partial class BasketOfProducts : Form
    {
        Shop shop;
        public BasketOfProducts(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
            foreach (Product product in shop.ShoppingList)
            {
                richTextBox1.Text += product + "\n";
            }
            richTextBox1.Text += shop + "\n";
        }
    }
}
