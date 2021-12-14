using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentLibrary;

namespace Gradebook
{
    /// <summary>
    /// Логика взаимодействия для InputGrant.xaml
    /// </summary>
    public partial class InputGrant : Window
    {
        Group group;
        public InputGrant()
        {
            InitializeComponent();
        }
        public InputGrant(Group group)
        {
            InitializeComponent();
            this.group = group;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double minGrant = Convert.ToDouble(textBox1.Text);
            OutputData outputData = new OutputData(minGrant, group);
            outputData.Show();
            Close();
        }
    }
}
