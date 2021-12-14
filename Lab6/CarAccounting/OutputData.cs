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
    public partial class OutputData : Form
    {
        Car car = new Car();
        public OutputData()
        {
            InitializeComponent();
        }
        public OutputData(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void DomainUpDown1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void OutputData_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < car.Mileages.Count; i++)
            {
                richTextBox1.Text += $"{i}. {car.Mileages[i].timeStart.ToShortDateString()}" +
                    $"- {car.Mileages[i].timeFinish.ToShortDateString()}; дистанция: {car.Mileages[i].distance} км\n";
            }
            for (int i = 0; i < car.Inspections.Count; i++)
            {
                richTextBox2.Text += $"{i}. {car.Inspections[i].timeOfInspection.ToShortDateString()};" +
                    $"проверка: {car.Inspections[i].TypeToString()}\n";
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(car);
            form1.Show();
            Close();
        }
    }
}
