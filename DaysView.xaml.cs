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
using WpfApp2.Classes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Days.xaml
    /// </summary>
    public partial class DaysView : UserControl
    {
        public DaysView(int Number, string? PathImg)
        {
            InitializeComponent();
            var list = Json.Deserialize();
            LabelNumber.Content = Number;
            if (PathImg != null)
            {
                Uri uri = new Uri(PathImg);
                Image.Source = new BitmapImage(uri);
            }
        }
    }
}
