using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Muiframework
{
    public partial class CustomSlider : UserControl
    {
        public CustomSlider()
        {
            InitializeComponent();
            SliderControl.ValueChanged += SliderControl_ValueChanged; // Attach event handler
        }

        // DependencyProperty for the Slider Value
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(double),
                typeof(CustomSlider),
                new PropertyMetadata(0.0, OnValueChanged));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomSlider customSlider)
            {
                // Synchronize the Slider's Value with the DependencyProperty
                customSlider.SliderControl.Value = (double)e.NewValue;

                // Update the ChatBubble text
                customSlider.ChatBubbleText.Text = ((double)e.NewValue).ToString("F0");
            }
        }

        private void SliderControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update the DependencyProperty when Slider value changes
            if (e.OriginalSource == SliderControl)
            {
                Value = e.NewValue; // This triggers the OnValueChanged callback
            }
        }

        // DependencyProperty for Label Text
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(CustomSlider),
                new PropertyMetadata("Volume", OnLabelTextChanged));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        private static void OnLabelTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomSlider customSlider)
            {
                customSlider.LabelTextBlock.Text = e.NewValue?.ToString();
            }
        }

        // DependencyProperty for Icon Source
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register(
                "IconSource",
                typeof(ImageSource),
                typeof(CustomSlider),
                new PropertyMetadata(null, OnIconSourceChanged));

        public ImageSource IconSource
        {
            get => (ImageSource)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        private static void OnIconSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomSlider customSlider)
            {
                customSlider.IconImage.Source = (ImageSource)e.NewValue;
            }
        }
    }
}
