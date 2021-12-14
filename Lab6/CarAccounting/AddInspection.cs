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
    public partial class AddInspection : Form
    {
        Car car = new Car();
        public AddInspection()
        {
            InitializeComponent();
        }
        public AddInspection(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime timeOfInspection = monthCalendar1.SelectionStart;
            TypeOfInspection typeOfInspection = (TypeOfInspection)listBox1.SelectedIndex;
            Inspection inspection = new Inspection(typeOfInspection, timeOfInspection);
            car.Inspections.Add(inspection);
        }

        private void AddInspection_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData(car);
            addData.Show();
            Close();
        }
    }
}
