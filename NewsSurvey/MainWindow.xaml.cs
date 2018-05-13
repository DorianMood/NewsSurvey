using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using NewsSurvey.Classes;
using System.IO;
using Newtonsoft.Json;

namespace NewsSurvey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<News> newsList;
        const string FILE_LOCATION = "news.json";
        int current = 0;

        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader(FILE_LOCATION))
            {
                string json = reader.ReadToEnd();
                newsList = JsonConvert.DeserializeObject<List<News>>(json);
            }
            SetElement(current);
        }

        private void SetElement(int index)
        {
            textCurrent.Text = index.ToString();
            SetText(newsList[index].Text);
        }

        private void SetText(string text)
        {
            textNews.Document.Blocks.Clear();
            textNews.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            current = current < newsList.Count - 1 ? current + 1 : current;
            SetElement(current);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            current = current > 0 ? current - 1 : current;
            SetElement(current);

        }

        private void textCurrent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                current = Convert.ToInt32(textCurrent.Text) >= 0 && Convert.ToInt32(textCurrent.Text) < newsList.Count ? Convert.ToInt32(textCurrent.Text) : current;
                SetElement(current);
                textCurrent.Text = current.ToString();
            }
        }
        private void textCurrent_GotFocus(object sender, RoutedEventArgs e)
        {
            textCurrent.SelectAll();
            textCurrent.Focus();
        }
    }
}
