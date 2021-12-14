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
    public partial class AverageInspections : Form
    {
        Car car;
        public AverageInspections()
        {
            InitializeComponent();
        }
        public AverageInspections(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan((int)numericUpDown1.Value, 0, 0, 0, 0);
            Dictionary<TypeOfInspection, double> quatities = car.GetAverageQuantityOfInspections(timeSpan);
            textBox1.Text = $"{quatities[TypeOfInspection.TireInflation]}";
            textBox2.Text = $"{quatities[TypeOfInspection.OilLevel]}";
            textBox3.Text = $"{quatities[TypeOfInspection.WasherWaterLevel]}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(car);
            formResults.Show();
            Close();
        }
    }
}
