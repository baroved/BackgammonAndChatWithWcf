using ChatFinalProjectWcf.Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChatFinalProjectWcf.Convertor
{
    public class Convert : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Cell cell = (Cell)value;

            ObservableCollection<Ellipse> col = new ObservableCollection<Ellipse>();

            for (int i = 0; i < cell.SoldierAmount; i++)
            {
                Ellipse e = new Ellipse();
                e.Width = 30;
                e.Height = 30;
                switch (cell.color)
                {
                    case Proxy.Color.Red:
                        e.Fill = new SolidColorBrush(Colors.Red);
                        break;
                    case Proxy.Color.Black:
                        e.Fill = new SolidColorBrush(Colors.Black);
                        break;
                }

                col.Add(e);
            }

            return col;
            
        }
    }
}
