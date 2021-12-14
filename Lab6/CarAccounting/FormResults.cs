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
    public partial class FormResults : Form
    {
        Car car;
        public FormResults()
        {
            InitializeComponent();
        }
        public FormResults(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AverageMileage averageMileage = new AverageMileage(car);
            averageMileage.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AverageInspections averageInspections = new AverageInspections(car);
            averageInspections.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MileageByPeriod mileageByPeriod = new MileageByPeriod(car);
            mileageByPeriod.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(car);
            form1.Show();
            Close();
        }
    }
}
