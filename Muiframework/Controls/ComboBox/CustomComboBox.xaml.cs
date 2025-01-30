using System.Windows;
using System.Windows.Controls;

namespace Muiframework
{
    /// <summary>
    /// Interaction logic for CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : UserControl
    {
        public CustomComboBox()
        {
            InitializeComponent();
        }

        // Dependency Property for FontSize
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(CustomComboBox),
                new PropertyMetadata(14.0, OnFontSizeChanged)); // Default font size is 14

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomComboBox customComboBox)
            {
                customComboBox.ComboBoxControl.FontSize = (double)e.NewValue;
            }
        }

        // Method to add items to the ComboBox
        public void AddItem(string itemContent)
        {
            ComboBoxControl.Items.Add(new ComboBoxItem { Content = itemContent });
        }

        // Expose SelectionChanged event
        public event SelectionChangedEventHandler SelectionChanged
        {
            add => ComboBoxControl.SelectionChanged += value;
            remove => ComboBoxControl.SelectionChanged -= value;
        }
    }
}
