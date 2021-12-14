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
    /// Логика взаимодействия для OutputData.xaml
    /// </summary>
    public partial class OutputData : Window
    {
        Group group;
        double minGrant;
        public OutputData()
        {
            InitializeComponent();
        }
        public OutputData(double minGrant, Group group)
        {
            InitializeComponent();
            this.group = group;
            this.minGrant = minGrant;
            OutputAverageGrantAndGrade();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(group);
            mainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            List<Student> passedOnTimePaidStudents = group.GetPassedOnTimePaidStudents();
            foreach (Student student in passedOnTimePaidStudents)
            {
                textBox1.Text += student + "; средний балл:" + student.GetAverageGrade() + "; стипендия: " +
                    student.GetGrant(minGrant) + " руб." + ";\n";
            }
        }
        private void OutputAverageGrantAndGrade()
        {
            textBox2.Text = "" + group.GetAverageGrade();
            textBox3.Text = "" + group.GetAverageGrant(minGrant);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            foreach (Student student in group.Students)
            {
                textBox1.Text += student + "; средний балл:" + student.GetAverageGrade() + "; стипендия: " +
                    student.GetGrant(minGrant) + " руб." + ";\n";
            }
        }
    }
}
