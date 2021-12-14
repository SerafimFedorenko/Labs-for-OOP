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
    public partial class MileageByPeriod : Form
    {
        Car car;
        public MileageByPeriod()
        {
            InitializeComponent();
        }
        public MileageByPeriod(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void MileageByPeriod_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{car.GetMileageForPeriod(monthCalendar1.SelectionEnd, monthCalendar2.SelectionEnd)} км";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(car);
            formResults.Show();
            Close();
        }
    }
}
