using Muiframework;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UITesting
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UIFactory.CreateWindow("MateChat - Showcase", 800, 600, contentGrid =>
            {
                // ScrollViewer for overflow handling
                var scrollViewer = new ScrollViewer
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                    Margin = new Thickness(10)
                };

                // Grid to arrange controls
                var grid = new Grid { Margin = new Thickness(10) };
                for (int i = 0; i < 15; i++) grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                for (int i = 0; i < 2; i++) grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                int rowIndex = 0;

                // Add controls with tooltips
                grid.Children.Add(AddControlWithLabel("ComboBox:", UIFactory.CreateCustomComboBox(200, 30, new[] { "Option 1", "Option 2", "Option 3" }, 16, ComboBox_SelectionChanged), "Select an option from the dropdown.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Button with Icon:", UIFactory.CreateButtonIcon("Test", 150, 50, "", TestButton_Click), "Click to perform an action.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Regular Button:", UIFactory.CreateButton("Basic", 150, 50, BasicButton_Click), "A simple button.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Custom Slider:", UIFactory.CreateCustomSlider(400, 200, "Volume", null, 0, 1000, 50, Slider_ValueChanged), "Adjust volume level.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Custom CheckBox:", UIFactory.CreateCustomCheckBox("Enable Feature", 16, CheckBox_Click), "Enable or disable the feature.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Custom TextBox:", UIFactory.CreateCustomTextBox(200, 30, "Enter text here...", 16), "Enter some text here.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Numeric UpDown:", UIFactory.CreateNumericUpDown(150, 0, 100, 1, 50, NumericUpDown_ValueChanged), "Increase or decrease the value.", ref rowIndex));
                grid.Children.Add(AddControlWithLabel("Progress Bar:", UIFactory.CreateCustomProgressBar(250, 20, 50), "Shows the current progress.", ref rowIndex));

                // Set Grid as ScrollViewer content
                scrollViewer.Content = grid;

                // Add ScrollViewer to main content grid
                contentGrid.Children.Add(scrollViewer);
            });
        }

        // Utility to add control with label and tooltip
        private static UIElement AddControlWithLabel(string labelText, UIElement control, string tooltipText, ref int rowIndex)
        {
            var panel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5) };

            var label = new TextBlock
            {
                Text = labelText,
                FontSize = 16,
                FontFamily = new FontFamily("SmoochSansLight"),
                Foreground = Brushes.White
            };

            // Add tooltip
            UIHelper.AddTooltip(control, tooltipText);

            panel.Children.Add(label);
            panel.Children.Add(control);

            Grid.SetRow(panel, rowIndex++);
            return panel;
        }

        // --- Event Handlers ---
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void TestButton_Click(object sender, RoutedEventArgs e) { MessageBox.Show("Test Button Clicked!"); }
        private void BasicButton_Click(object sender, RoutedEventArgs e) { MessageBox.Show("Basic Button Clicked!"); }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { }
        private void CheckBox_Click(object sender, RoutedEventArgs e) { }
        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e) { }
    }
}
