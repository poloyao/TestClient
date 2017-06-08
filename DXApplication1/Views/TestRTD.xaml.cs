using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DXApplication1.Views
{
    /// <summary>
    /// TestRTD.xaml 的交互逻辑
    /// </summary>
    public partial class TestRTD : UserControl
    {
        public TestRTD()
        {
            InitializeComponent();
        }
    }

    public class CarIcoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.ToString() == string.Empty)
            { }
            else
            {
                return "/DXApplication1;component/Img/car1.png";
            }
            return null;
            
         }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


}
