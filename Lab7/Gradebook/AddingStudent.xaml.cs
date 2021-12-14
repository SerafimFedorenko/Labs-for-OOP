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
    /// Логика взаимодействия для AddingStudent.xaml
    /// </summary>
    public partial class AddingStudent : Window
    {
        Group group;
        public AddingStudent()
        {
            InitializeComponent();
        }
        public AddingStudent(Group group)
        {
            InitializeComponent();
            this.group = group;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBox1.Text;
            bool passOnTime;
            List<int> grades = new List<int>
            {
                phonesList1.SelectedIndex + 1,
                phonesList2.SelectedIndex + 1,
                phonesList3.SelectedIndex + 1,
                phonesList4.SelectedIndex + 1,
                phonesList5.SelectedIndex + 1
            };
            if((bool)checkBox1.IsChecked)
            {
                passOnTime = true;
            }
            else
            {
                passOnTime = false;
            }
            TypeOfStudent studentType = (TypeOfStudent)comboBox1.SelectedIndex;
            Student student = StudentFabric.GetStudent(grades, passOnTime, name, studentType);
            group.AddStudent(student);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(group);
            mainWindow.Show();
            Close();
        }
    }
}
