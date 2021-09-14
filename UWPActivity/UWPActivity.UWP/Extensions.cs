using System;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UWPActivity.UWP
{
    public static class Extensions
    {
        public static Color ToUwPColor(this Xamarin.Forms.Color color)
        {
            return Color.FromArgb(
                Convert.ToByte(color.A * 255),
                Convert.ToByte(color.R * 255),
                Convert.ToByte(color.G * 255),
                Convert.ToByte(color.B * 255));
        }

        public static SolidColorBrush ToUwpSolidColorBrush(this Xamarin.Forms.Color color)
        {
            return new SolidColorBrush(color.ToUwPColor());
        }
    }
}
