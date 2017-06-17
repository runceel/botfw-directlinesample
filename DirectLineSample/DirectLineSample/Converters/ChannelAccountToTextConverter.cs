using System;
using System.Globalization;
using Microsoft.Bot.Connector.DirectLine;
using Xamarin.Forms;

namespace DirectLineSample.Converters
{
    public class ChannelAccountToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var channelAccount = (ChannelAccount)value;
            return string.IsNullOrEmpty(channelAccount.Name) ? channelAccount.Id : channelAccount.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
