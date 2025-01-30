using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Muiframework
{
    public partial class CustomNumericUpDown : UserControl
    {
        public CustomNumericUpDown()
        {
            InitializeComponent();
        }

        // ✅ Define an Event for Value Changes
        public event RoutedPropertyChangedEventHandler<int> ValueChanged;

        // DependencyProperty for Value
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value", typeof(int), typeof(CustomNumericUpDown),
                new PropertyMetadata(0, OnValueChanged));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, Math.Max(MinValue, Math.Min(MaxValue, value)));
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomNumericUpDown control)
            {
                control.NumericTextBox.Text = control.Value.ToString();

                // ✅ Fire the ValueChanged event when the value updates
                control.ValueChanged?.Invoke(control, new RoutedPropertyChangedEventArgs<int>((int)e.OldValue, (int)e.NewValue));
            }
        }

        // DependencyProperty for Minimum Value
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(CustomNumericUpDown), new PropertyMetadata(0));

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        // DependencyProperty for Maximum Value
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(CustomNumericUpDown), new PropertyMetadata(100));

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        // DependencyProperty for Step Size
        public static readonly DependencyProperty StepSizeProperty =
            DependencyProperty.Register("StepSize", typeof(int), typeof(CustomNumericUpDown), new PropertyMetadata(1));

        public int StepSize
        {
            get => (int)GetValue(StepSizeProperty);
            set => SetValue(StepSizeProperty, value);
        }

        // Increase Value
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Value += StepSize;
        }

        // Decrease Value
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Value -= StepSize;
        }

        // Validate Numeric Input
        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        // Ensure Value is Within Range on Lost Focus
        private void NumericTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericTextBox.Text, out int newValue))
            {
                Value = newValue;
            }
            else
            {
                NumericTextBox.Text = Value.ToString();
            }
        }
    }
}
