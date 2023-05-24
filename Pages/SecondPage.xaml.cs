using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
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
using WpfApp2;
using WpfApp2.Classes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        private Frame Frame;
        private string pathToImg;
        public SecondPage(string date, Frame Frame, DaysView day)
        {
            InitializeComponent();
            this.Frame = Frame;
            Label.Content = date;

            if(System.IO.Path.GetFileName(day.Image.Source.ToString()) == "Byrger.jpeg")
            {
                first.IsChecked = true;
            }
            else if (System.IO.Path.GetFileName(day.Image.Source.ToString()) == "Rus.jpeg")
            {
                second.IsChecked = true;
            }
            else if (System.IO.Path.GetFileName(day.Image.Source.ToString()) == "uico.jpeg")
            {
                third.IsChecked = true;
            }
            else if (System.IO.Path.GetFileName(day.Image.Source.ToString()) == "byter.jpeg")
            {
                fouth.IsChecked = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new FirstPage((string)Label.Content, Frame);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            pathToImg = ((sender as RadioButton).Content as Image).Source.ToString();
            SaveButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var list = Json.Deserialize();
            var entity = list.FirstOrDefault(element => element.date == Label.Content.ToString());
            if (entity == null)
            {
                list.Add(new ModelDay
                {
                    date = (string)Label.Content,
                    pathToImg = this.pathToImg
                });
            }
            else
            {
                list.Remove(entity);
                entity.pathToImg = pathToImg;
                list.Add(entity);
            }
            Json.Serialize(list);
            BackButton_Click(null, null);
        }
    }
}
