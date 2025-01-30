using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Muiframework
{
    public static class UIHelper
    {
        private static readonly ResourceDictionary _resources = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Muiframework;component/Resources.xaml", UriKind.Absolute)
        };

        // Get Font from Resources
        public static FontFamily GetFontFamily(string key)
        {
            return _resources[key] as FontFamily ?? new FontFamily("Arial");
        }

        // Apply Fade-In Animation
        public static void ApplyFadeInAnimation(UIElement element, double durationSeconds = 0.3)
        {
            var fadeIn = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSeconds),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            element.BeginAnimation(UIElement.OpacityProperty, fadeIn);
        }

        // Apply Scale Animation
        public static void ApplyScaleAnimation(UIElement element, double durationSeconds = 0.3)
        {
            var scaleTransform = new ScaleTransform(1, 1);
            element.RenderTransform = scaleTransform;
            element.RenderTransformOrigin = new Point(0.5, 0.5);

            var scaleUp = new DoubleAnimation
            {
                From = 0.8,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationSeconds),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUp);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUp);
        }

        // Add Tooltip with Fade Effect
        public static void AddTooltip(UIElement element, string tooltipText)
        {
            if (element is FrameworkElement frameworkElement)
            {
                var tooltip = new ToolTip
                {
                    Content = tooltipText,
                    Background = Brushes.Black,
                    Foreground = Brushes.White,
                    FontSize = 14,
                    FontFamily = GetFontFamily("SmoochSansLight"),
                    Padding = new Thickness(5),
                    Opacity = 0 // Start hidden
                };

                frameworkElement.ToolTip = tooltip;

                var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.2));
                var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.2));

                tooltip.Opened += (s, e) => tooltip.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                tooltip.Closed += (s, e) => tooltip.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            }
        }

        // Show Toast Notification
        public static void ShowToast(string message, double width = 250, double height = 50, int durationMs = 3000)
        {
            var toast = new Window
            {
                Width = width,
                Height = height,
                Topmost = true,
                Background = Brushes.Black,
                Foreground = Brushes.White,
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Opacity = 0.8,
                ResizeMode = ResizeMode.NoResize
            };

            var textBlock = new TextBlock
            {
                Text = message,
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.White
            };

            toast.Content = textBlock;

            toast.Show();

            Task.Delay(durationMs).ContinueWith(_ => toast.Dispatcher.Invoke(toast.Close));
        }
    }
}
