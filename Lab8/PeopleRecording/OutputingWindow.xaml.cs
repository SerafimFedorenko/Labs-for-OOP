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
using PeopleLib;

namespace PeopleRecording
{
    /// <summary>
    /// Логика взаимодействия для OutputingWindow.xaml
    /// </summary>
    public partial class OutputingWindow : Window
    {
        Catalog catalog;
        public OutputingWindow()
        {
            InitializeComponent();
        }
        public OutputingWindow(Catalog catalog)
        {
            this.catalog = catalog;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Document.Blocks.Clear();
            TextRange rangeOfWord;
            foreach (Human human in catalog.People)
            {
                if(human is Schooler)
                {
                    Schooler schooler = (Schooler)human;
                    if(schooler.CheckExcellentLittleSchooler())
                    {
                        rangeOfWord = new TextRange(textBox1.Document.ContentEnd, textBox1.Document.ContentEnd);
                        rangeOfWord.Text = human.GetInformation();
                        rangeOfWord.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);
                        textBox1.AppendText("\n");
                        continue;
                    }
                }
                rangeOfWord = new TextRange(textBox1.Document.ContentEnd, textBox1.Document.ContentEnd);
                rangeOfWord.Text = human.GetInformation();
                rangeOfWord.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                textBox1.AppendText("\n");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(catalog);
            mainWindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox1.Document.Blocks.Clear();
            List<Worker> workers = catalog.GetWorkersSorted();
            foreach (Worker worker in workers)
            {
                textBox1.AppendText(worker.GetInformation());
                textBox1.AppendText("\n");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox1.Document.Blocks.Clear();
            List<Schooler> schoolers = catalog.GetMoreOnlyTwoSchoolers();
            foreach(Schooler schooler in schoolers)
            {
                textBox1.AppendText(schooler.GetInformation());
                textBox1.AppendText("\n");
            }
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox1.Document.Blocks.Clear();
            string uni = textBox2.Text;
            List<Student> students = catalog.GetFlunkeysInUni(uni);
            foreach (Student student in students)
            {
                textBox1.AppendText(student.GetInformation());
                textBox1.AppendText("\n");
            }
            MessageBox.Show($"Количество двоечников в {uni}: {students.Count}");
        }
    }
}
