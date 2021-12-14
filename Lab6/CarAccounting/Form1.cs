using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarLibrary;

namespace CarAccounting
{
    public partial class Form1 : Form
    {
        Car car = new Car();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Car car)
        {
            this.car = car;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData(car);
            addData.Show();
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutputData outputData = new OutputData(car);
            outputData.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(car);
            formResults.Show();
            Close();
        }
    }
}
