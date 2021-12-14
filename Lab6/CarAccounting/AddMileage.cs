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
    public partial class AddMileage : Form
    {
        Car car = new Car();
        public AddMileage()
        {
            InitializeComponent();
        }
        public AddMileage(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mileage mileage = new Mileage((double)numericUpDown1.Value, monthCalendar1.SelectionEnd, monthCalendar2.SelectionEnd);
            car.Mileages.Add(mileage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData(car);
            addData.Show();
            Close();
        }
    }
}
