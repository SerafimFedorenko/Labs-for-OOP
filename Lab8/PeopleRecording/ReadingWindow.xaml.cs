using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
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
    /// Логика взаимодействия для ReadingWindow.xaml
    /// </summary>
    public partial class ReadingWindow : Window
    {
        Catalog catalog;
        public ReadingWindow()
        {
            InitializeComponent();
        }
        public ReadingWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
            ReadFile();
        }
        private void ReadFile()
        {
            string filename = @"D:\лабы 2 курс\ООП\Lab8\People.txt";
            List<string> text = File.ReadAllLines(filename).ToList();
            textBox1.Clear();
            foreach(string line in text)
            {
                textBox1.AppendText(line + "\n");
            }
            ProcessText(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filename = @"D:\лабы 2 курс\ООП\Lab8\People.txt";
            File.WriteAllText(filename, textBox1.Text);
            ReadFile();
        }

        private void ProcessText(List<string> text)
        {
            Catalog catalog = new Catalog();
            List<string> words = new List<string>();
            foreach(string line in text)
            {
                Human human = null;
                words = line.Split(' ').ToList();
                
                if (words[2] == "студент")
                {
                    List<int> grades = GetGradesOrSalaries(words, 5);
                    human = new Student(words[0], Convert.ToInt32(words[1]), words[3], words[4], grades);
                }
                else
                {
                    if(words[2] == "школьник")
                    {
                        List<int> grades = GetGradesOrSalaries(words, 5);
                        human = new Schooler(words[0], Convert.ToInt32(words[1]), words[3], Convert.ToInt32(words[4]), grades);
                    }
                    else
                    {
                        List<int> salaries = GetGradesOrSalaries(words, 4);
                        human = new Worker(words[0], Convert.ToInt32(words[1]), words[2], words[3], salaries.ToArray());
                    }
                }
                catalog.Add(human);
            }
            this.catalog = catalog;
        }
        private List<int> GetGradesOrSalaries(List<string> words, int index)
        {
            List<int> gradesOrSalaries = new List<int>();
            for (int i = 5; i < words.Count; i++)
            {
                gradesOrSalaries.Add(Convert.ToInt32(words[i]));
            }
            return gradesOrSalaries;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(catalog);
            mainWindow.Show();
            Close();
        }
    }
}
