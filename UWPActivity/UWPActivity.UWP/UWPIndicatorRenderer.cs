using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;
using UWPActivity;
using UWPActivity.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(UWPIndicator), typeof(UWPIndicatorRenderer))]
namespace UWPActivity.UWP
{
    public class UWPIndicatorRenderer : ViewRenderer<UWPIndicator, ProgressRing>
    {
        ProgressRing _progressRing;
        protected override void OnElementChanged(ElementChangedEventArgs<UWPIndicator> e)
        {
            try
            {
                base.OnElementChanged(e);

                if (Control != null)
                    return;

                _progressRing = new ProgressRing();

                if (e.NewElement != null)
                {
                    _progressRing.IsActive = Element.IsRunning;
                    _progressRing.Visibility = Element.IsRunning ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
                    var xfColor = Element.Color;
                    _progressRing.Foreground = xfColor.ToUwpSolidColorBrush();
                    SetNativeControl(_progressRing);
                }

                //if (Control == null)
                //{
                //    _progressRing = new ProgressRing();
                //    _progressRing.IsActive = true;
                //    _progressRing.Visibility = Visibility.Visible;
                //    _progressRing.IsEnabled = true;
                //    SetNativeControl(_progressRing);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName == nameof(ActivityIndicator.Color))
                {
                    _progressRing.Foreground = Element.Color.ToUwpSolidColorBrush();
                }
                if (e.PropertyName == nameof(ActivityIndicator.IsRunning))
                {
                    _progressRing.IsActive = Element.IsRunning;
                    _progressRing.Visibility = Element.IsRunning ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
                }
                if (e.PropertyName == nameof(ActivityIndicator.WidthRequest))
                {
                    _progressRing.Width = Element.WidthRequest > 0 ? Element.WidthRequest : 20;
                    UpdateNativeControl();
                }
                if (e.PropertyName == nameof(ActivityIndicator.HeightRequest))
                {
                    _progressRing.Height = Element.HeightRequest > 0 ? Element.HeightRequest : 20;
                    UpdateNativeControl();
                }
                if (_progressRing.Height != _progressRing.Width)
                {
                    double min = Math.Min(Element.HeightRequest, Element.WidthRequest);
                    if (min <= 0)
                    {
                        min = Math.Max(Element.HeightRequest, Element.WidthRequest);
                    }
                    if (min > 0)
                    {
                        _progressRing.Height = _progressRing.Width = min;
                        _progressRing.MaxHeight = _progressRing.MaxWidth = min;
                        UpdateNativeControl();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
