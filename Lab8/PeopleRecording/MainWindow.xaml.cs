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
using PeopleLib;

namespace PeopleRecording
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Catalog catalog = new Catalog();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReadingWindow readingWindow = new ReadingWindow(catalog);
            readingWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(catalog.People.Count == 0)
            {
                MessageBox.Show("Нет данных");
            }
            else
            {
                OutputingWindow outputingWindow = new OutputingWindow(catalog);
                outputingWindow.Show();
                Close();
            }
        }
    }
}
