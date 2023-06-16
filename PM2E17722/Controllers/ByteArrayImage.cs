using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using System.IO;

namespace PM2E17722.Controllers
{
    public class ByteArrayImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource image = null;

            if (value != null)
            {
                byte[] bytesImage = (byte[])value;
                var stream = new MemoryStream(bytesImage);
                image = ImageSource.FromStream(()=> stream);
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
