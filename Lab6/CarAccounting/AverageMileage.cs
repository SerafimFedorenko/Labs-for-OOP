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
    public partial class AverageMileage : Form
    {
        Car car;
        public AverageMileage()
        {
            InitializeComponent();
        }
        public AverageMileage(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void AverageMileage_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"{car.GetAverageMileageBetweenTireInflations()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(car);
            formResults.Show();
            Close();
        }
    }
}
