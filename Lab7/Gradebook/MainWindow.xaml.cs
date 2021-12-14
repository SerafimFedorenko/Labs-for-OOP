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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentLibrary;

namespace Gradebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Group group = new Group();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Group group)
        {
            InitializeComponent();
            this.group = group;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddingStudent addingStudent = new AddingStudent(group);
            addingStudent.Show();
            Close();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            InputGrant inputGrant = new InputGrant(group);
            inputGrant.Show();
            Close();
        }
    }
}
