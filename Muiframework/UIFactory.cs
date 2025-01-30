using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;


namespace Muiframework
{
    public static class UIFactory
    {
        /// <summary>
        /// Create Label with specified content, font size, width, and height
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fontSize"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Label CreateLabel(string content, double fontSize, double width = double.NaN, double height = double.NaN)
        {
            return new Label
            {
                Content = content,
                FontSize = fontSize,
                FontFamily = UIHelper.GetFontFamily("SmoochSansLight"),
                Foreground = Brushes.White,
                Width = width,
                Height = height,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };
        }

        /// <summary>
        /// Create CheckBox with specified content, font size, and click handler
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fontSize"></param>
        /// <param name="clickHandler"></param>
        /// <returns></returns>
        public static CheckBox CreateCustomCheckBox(string content, double fontSize, RoutedEventHandler clickHandler = null)
        {
            var checkBox = new CheckBox
            {
                Content = content,
                FontSize = fontSize,
                FontFamily = UIHelper.GetFontFamily("SmoochSansLight"),
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            if (clickHandler != null)
            {
                checkBox.Click += clickHandler;
            }

            return checkBox;
        }

        /// <summary>
        /// Create TextBox with specified width, height, placeholder text, and font size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="placeholder"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public static TextBox CreateCustomTextBox(double width, double height, string placeholder = "", double fontSize = 14)
        {
            var textBox = new TextBox
            {
                Width = width,
                Height = height,
                FontSize = fontSize,
                FontFamily = UIHelper.GetFontFamily("SmoochSansLight"),
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                BorderBrush = Brushes.DarkGray,
                BorderThickness = new Thickness(2),
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5),
                Text = placeholder
            };

            // Clear placeholder on focus
            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = Brushes.White;
                }
            };

            // Restore placeholder if empty on losing focus
            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.Foreground = Brushes.DarkGray;
                }
            };

            return textBox;
        }

        /// <summary>
        /// Create RadioButton group with specified options, font size, and selection changed handler
        /// </summary>
        /// <param name="options"></param>
        /// <param name="fontSize"></param>
        /// <param name="selectionChanged"></param>
        /// <returns></returns>
        public static StackPanel CreateRadioButtonGroup(string[] options, double fontSize, RoutedEventHandler selectionChanged = null)
        {
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5)
            };

            foreach (var option in options)
            {
                var radioButton = new RadioButton
                {
                    Content = option,
                    FontSize = fontSize,
                    FontFamily = UIHelper.GetFontFamily("SmoochSansLight"),
                    Foreground = Brushes.White,
                    Margin = new Thickness(5)
                };

                if (selectionChanged != null)
                {
                    radioButton.Checked += selectionChanged;
                }

                stackPanel.Children.Add(radioButton);
            }

            return stackPanel;
        }

        /// <summary>
        /// Create ProgressBar with specified width, height, and initial value
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public static ProgressBar CreateCustomProgressBar(double width, double height, double initialValue = 0)
        {
            return new ProgressBar
            {
                Width = width,
                Height = height,
                Value = initialValue,
                Foreground = new SolidColorBrush(Color.FromRgb(134, 206, 203)),
                Background = Brushes.Gray,
                BorderBrush = Brushes.DarkGray,
                BorderThickness = new Thickness(2),
                Margin = new Thickness(5)
            };
        }

        /// <summary>
        /// Create Slider with specified width, height, label text, icon source, value range, initial value, and value changed handler
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="labelText"></param>
        /// <param name="iconSource"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="initialValue"></param>
        /// <param name="valueChangedHandler"></param>
        /// <returns></returns>
        public static CustomSlider CreateCustomSlider( double width, double height, string labelText, ImageSource iconSource, double minValue, double maxValue, double initialValue, RoutedPropertyChangedEventHandler<double> valueChangedHandler = null)
        {
            // Instantiate the CustomSlider
            var customSlider = new CustomSlider
            {
                Width = width,
                Height = height,
                LabelText = labelText,
                IconSource = iconSource,
                Value = initialValue
            };

            // Set the slider's value range
            customSlider.SliderControl.Minimum = minValue;
            customSlider.SliderControl.Maximum = maxValue;
            customSlider.SliderControl.Value = initialValue;

            // Attach the ValueChanged event handler, if provided
            if (valueChangedHandler != null)
            {
                customSlider.SliderControl.ValueChanged += valueChangedHandler;
            }

            return customSlider;
        }

        /// <summary>
        /// Create Button with specified content, width, height, and click handler
        /// </summary>
        /// <param name="content"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="clickHandler"></param>
        /// <returns></returns>
        public static Button CreateButton(string content, double width, double height, RoutedEventHandler clickHandler)
        {
            var button = new Button
            {
                Width = width,
                Height = height,
                Margin = new Thickness(10),
                FontWeight = FontWeights.Bold,
                FontFamily = UIHelper.GetFontFamily("SmoochSansLight"), // Use the font from Resources
                FontSize = height - 28,
                Content = content // Set the button's content
            };

            // Create a ControlTemplate for the button
            var controlTemplate = new ControlTemplate(typeof(Button));
            var gridFactory = new FrameworkElementFactory(typeof(Grid));

            // Add the image as the background
            var imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetValue(Image.SourceProperty, new System.Windows.Media.Imaging.BitmapImage(
                new Uri("pack://application:,,,/Muiframework;component/Images/BlankButton.png", UriKind.Absolute)));
            imageFactory.SetValue(Image.StretchProperty, Stretch.Uniform);
            gridFactory.AppendChild(imageFactory);

            // Add the text content (on top)
            var contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.MarginProperty, new Thickness(5));

            // Ensure text is on top
            contentPresenterFactory.SetValue(Panel.ZIndexProperty, 1);
            gridFactory.AppendChild(contentPresenterFactory);

            controlTemplate.VisualTree = gridFactory;
            button.Template = controlTemplate;

            // Attach the Click event handler
            button.Click += clickHandler;

            return button;
        }

        /// <summary>
        /// Create Collapsible Panel with specified header and content
        /// </summary>
        /// <param name="header"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Expander CreateCollapsiblePanel(string header, UIElement content)
        {
            return new Expander
            {
                Header = header,
                Content = content,
                Background = Brushes.Gray,
                Foreground = Brushes.White,
                BorderBrush = Brushes.DarkGray,
                BorderThickness = new Thickness(2),
                Margin = new Thickness(5)
            };
        }

        /// <summary>
        /// Create Button with specified content, width, height, icon URI, and click handler
        /// </summary>
        /// <param name="content"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="iconUri"></param>
        /// <param name="clickHandler"></param>
        /// <returns></returns>
        public static Button CreateButtonIcon(string content, double width, double height, string iconUri, RoutedEventHandler clickHandler)
        {
            // Use default icon if iconUri is null or empty
            string resolvedIconUri = string.IsNullOrWhiteSpace(iconUri)
                ? "pack://application:,,,/Muiframework;component/Images/Default.png" // Default icon path
                : iconUri;

            var button = new Button
            {
                Width = width,
                Height = height,
                Margin = new Thickness(10),
                FontWeight = FontWeights.Bold,
                FontFamily = UIHelper.GetFontFamily("SmoochSansLight"), // Use the font from Resources
                FontSize = height / 3 // Dynamically adjust font size based on height
            };

            // Create a ControlTemplate for the button
            var controlTemplate = new ControlTemplate(typeof(Button));
            var gridFactory = new FrameworkElementFactory(typeof(Grid));

            // Add the image as the background
            var imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetValue(Image.SourceProperty, new System.Windows.Media.Imaging.BitmapImage(
                new Uri("pack://application:,,,/Muiframework;component/Images/BlankButton.png", UriKind.Absolute)));
            imageFactory.SetValue(Image.StretchProperty, Stretch.Uniform); // Maintain aspect ratio
            gridFactory.AppendChild(imageFactory); // Add background image first

            // Create a StackPanel for the icon and text
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            stackPanelFactory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            stackPanelFactory.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);

            // Add the icon to the StackPanel
            var iconFactory = new FrameworkElementFactory(typeof(Image));
            iconFactory.SetValue(Image.SourceProperty, new System.Windows.Media.Imaging.BitmapImage(new Uri(resolvedIconUri, UriKind.RelativeOrAbsolute)));
            iconFactory.SetValue(Image.WidthProperty, height / 3.2); // Adjust icon size to be proportional
            iconFactory.SetValue(Image.HeightProperty, height / 3.2);
            iconFactory.SetValue(Image.MarginProperty, new Thickness(5, 0, 1, 0)); // Reduced spacing for better alignment
            iconFactory.SetValue(Image.StretchProperty, Stretch.Uniform); // Maintain aspect ratio
            stackPanelFactory.AppendChild(iconFactory);

            // Add the text content to the StackPanel
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, content);
            textBlockFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Black); // Set text to black
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, height / 3);
            textBlockFactory.SetValue(TextBlock.FontFamilyProperty,  UIHelper.GetFontFamily("SmoochSansLight"));
            textBlockFactory.SetValue(TextBlock.MarginProperty, new Thickness(0, 0, 0, 0)); // Reduced margin for closer text
            stackPanelFactory.AppendChild(textBlockFactory);

            // Add the StackPanel to the Grid
            gridFactory.AppendChild(stackPanelFactory); // Add StackPanel second, so it's on top

            // Set the ControlTemplate's visual tree
            controlTemplate.VisualTree = gridFactory;
            button.Template = controlTemplate;

            // Attach the Click event handler
            button.Click += clickHandler;

            return button;
        }

        /// <summary>
        /// Create ComboBox with specified width, height, items, font size, and selection changed handler
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="items"></param>
        /// <param name="fontSize"></param>
        /// <param name="selectionChangedHandler"></param>
        /// <returns></returns>
        public static CustomComboBox CreateCustomComboBox(double width, double height, IEnumerable<string> items, double fontSize, SelectionChangedEventHandler selectionChangedHandler = null)
        {
            // Instantiate the CustomComboBox
            var customComboBox = new CustomComboBox
            {
                Width = width,
                Height = height,
                FontSize = fontSize // Set the font size dynamically
            };

            // Add items to the CustomComboBox
            foreach (var item in items)
            {
                customComboBox.AddItem(item);
            }

            // Attach the SelectionChanged event handler, if provided
            if (selectionChangedHandler != null)
            {
                customComboBox.SelectionChanged += selectionChangedHandler;
            }

            return customComboBox;
        }

        /// <summary>
        /// Create CustomTabControl with specified width, height, and tabs
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tabs"></param>
        /// <returns></returns>
        public static TabControl CreateCustomTabControl(double width, double height, Dictionary<string, UIElement> tabs)
        {
            var tabControl = new TabControl
            {
                Width = width,
                Height = height,
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(2),
                Margin = new Thickness(5)
            };

            foreach (var tab in tabs)
            {
                var tabItem = new TabItem
                {
                    Header = tab.Key,
                    Content = tab.Value
                };
                tabControl.Items.Add(tabItem);
            }

            return tabControl;
        }

        /// <summary>
        /// Create ListView with specified width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ListView CreateCustomListView(double width, double height)
        {
            var listView = new ListView
            {
                Width = width,
                Height = height,
                Background = Brushes.Transparent,
                Foreground = Brushes.White,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(2),
                Margin = new Thickness(5),
                FontFamily =  UIHelper.GetFontFamily("SmoochSansLight"),
            };

            return listView;
        }

        /// <summary>
        /// Create Numeric UpDown control with specified width, min, max, step, initial value, and value changed handler
        /// </summary>
        /// <param name="width"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="step"></param>
        /// <param name="initialValue"></param>
        /// <param name="valueChangedHandler"></param>
        /// <returns></returns>
        public static CustomNumericUpDown CreateNumericUpDown(double width, int min, int max, int step, int initialValue, RoutedPropertyChangedEventHandler<int> valueChangedHandler = null)
        {
            var numericUpDown = new CustomNumericUpDown
            {
                Width = width,
                MinValue = min,
                MaxValue = max,
                StepSize = step,
                Value = initialValue
            };

            // ✅ Attach the correct event handler if provided
            if (valueChangedHandler != null)
            {
                numericUpDown.ValueChanged += valueChangedHandler;
            }

            return numericUpDown;
        }


        /// <summary>
        /// Create a custom window with a title, width, height, and content setup
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="setupContent"></param>
        public static void CreateWindow(string title, double width, double height, Action<Grid> setupContent)
        {
            Thread uiThread = new Thread(() =>
            {
                var window = new Window
                {
                    Title = title,
                    Width = width,
                    Height = height,
                    Background = Brushes.Transparent, // Transparent background for rounded edges
                    WindowStyle = WindowStyle.None,   // Remove default title bar
                    AllowsTransparency = true,       // Allow transparency for custom borders and shadow
                    ResizeMode = ResizeMode.NoResize // Disable resizing
                };

                // Create a border for the rounded edges of the form
                var border = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(96, 96, 96)), // Form background color
                    CornerRadius = new CornerRadius(5), // Rounded corners for the form
                    BorderBrush = new SolidColorBrush(Color.FromRgb(200,200,200)),  // Brushes.White, // White border for the form
                    BorderThickness = new Thickness(2), // Thickness for the outer border
                    Effect = new DropShadowEffect // Add a soft shadow effect
                    {
                        Color = Colors.Black,
                        Direction = 315,
                        ShadowDepth = 5,
                        Opacity = 0.4,
                        BlurRadius = 15
                    },
                    Margin = new Thickness(18) // Let the shadow extend beyond the window bounds
                };

                var dockPanel = new DockPanel();

                var titleBar = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(80, 80, 80)),
                    Height = 30,
                    BorderBrush = new SolidColorBrush(Color.FromRgb(200, 200, 200)),  // Brushes.White, // White border for the form
                    BorderThickness = new Thickness(2), // Thickness for the outer border
                    CornerRadius = new CornerRadius(5, 5, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(-2)
                };

                var titleBarContent = new Grid();

                var titleText = new TextBlock
                {
                    Text = title,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(20, 0, 0, 0),
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = UIHelper.GetFontFamily("SmoochSansLight"), // Use the font from Resources
                    FontSize = 22
                };
                titleBarContent.Children.Add(titleText);

                titleBarContent.MouseLeftButtonDown += (s, e) =>
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        window.DragMove();
                    }
                };

                var closeButton = new Button
                {
                    Content = "X",
                    Width = 30,
                    Height = 30,
                    FontWeight = FontWeights.Bold,
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top, // Moves the button upwards
                    Margin = new Thickness(0, -1.5, 0, 0), // Adjusts position: -5 to move up, 10 to push right
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.Transparent,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                // Define a custom ControlTemplate
                var closeButtonTemplate = new ControlTemplate(typeof(Button));

                // Outer border (transparent for all states)
                var outerBorder = new FrameworkElementFactory(typeof(Border));
                outerBorder.SetValue(Border.BackgroundProperty, Brushes.Transparent);
                outerBorder.SetValue(Border.BorderBrushProperty, Brushes.Transparent);
                outerBorder.SetValue(Border.BorderThicknessProperty, new Thickness(0));

                // Add TextBlock for the "X" content
                var textBlock = new FrameworkElementFactory(typeof(TextBlock));
                textBlock.SetValue(TextBlock.TextProperty, "X");
                textBlock.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.White));
                textBlock.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                textBlock.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                textBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

                // Append the TextBlock to the Border
                outerBorder.AppendChild(textBlock);

                // Set the ControlTemplate's visual tree
                closeButtonTemplate.VisualTree = outerBorder;

                // Apply the ControlTemplate to the button
                closeButton.Template = closeButtonTemplate;

                // Close window on click
                closeButton.Click += (s, e) => window.Close();

                titleBarContent.Children.Add(closeButton);
                titleBar.Child = titleBarContent;

                DockPanel.SetDock(titleBar, Dock.Top);
                dockPanel.Children.Add(titleBar);

                var contentGrid = new Grid();
                DockPanel.SetDock(contentGrid, Dock.Bottom);
                dockPanel.Children.Add(contentGrid);

                setupContent?.Invoke(contentGrid);

                border.Child = dockPanel;
                window.Content = border;
                window.Show();
                System.Windows.Threading.Dispatcher.Run();
            });

            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.IsBackground = true;
            uiThread.Start();
        }
    }
}
