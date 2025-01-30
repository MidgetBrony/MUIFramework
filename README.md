# Muiframework

## Overview
Muiframework is a **custom UI framework** designed for **MelonLoader**, primarily serving as a **UI system for Desktop Mate**. It provides a robust set of **custom UI controls, animations, and helper utilities** tailored for **WPF applications**.

This framework is licensed under **GPLv3**, ensuring open-source freedom and accessibility.

Muiframework also relies on **MFrameworkLoader** ([GitHub](https://github.com/MidgetBrony/MFrameWorkLoader)), which ensures that .NET 6.0 assemblies are properly loaded in the MelonLoader environment for **Desktop Mate**. This removes the need to manually bundle all WPF dependencies.

---

## Features
- **Custom UI Components**: Includes sliders, buttons, checkboxes, numeric up-downs, combo boxes, and more.
- **Custom Buttons with Icons**: Fully customizable buttons with **embedded icons**.
- **Custom Animations**: Fade-in, scale effects, and smooth UI transitions.
- **Tooltip Enhancements**: Animated tooltips with fade-in and fade-out effects.
- **Tab Controls & List Views**: Fully featured tab systems and list views.
- **Collapsible Panels**: Expander-based sections for an optimized UI.
- **Toast Notifications**: Floating, timed notifications for quick alerts.
- **Theme & Font Support**: Uses a custom **SmoochSansLight** font and a resource dictionary for styling.
- **MelonLoader Support**: Built to function within **MelonLoader modding environments**.
- **WPF Window Creation**: Dynamically generates **customizable windows**.
- **Integration with MFrameworkLoader**: Ensures **.NET 6.0 runtime libraries** are properly loaded.
- **Custom Controls Added**:
  - **CustomLabel**: Custom styled labels
  - **CustomCheckBox**: Themed checkbox component
  - **CustomTextBox**: Enhanced textbox with styling
  - **CreateRadioButtonGroup**: Radio button groups with auto-styling
  - **CreateCustomProgressBar**: Custom progress bar with smooth visuals
  - **CreateCustomSlider**: Themed sliders with dynamic behavior
  - **CreateCollapsiblePanel**: Expander-based collapsible sections
  - **CreateButtonIcon**: Custom button supporting icons
  - **CreateCustomTabControl**: Fully featured tab control system
  - **CreateCustomListView**: Styled list views with improved appearance
  - **CreateNumericUpDown**: Custom numeric up/down input
  - **CreateWindow**: Dynamically create custom windows

---

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/YOUR_GITHUB/Muiframework.git
   ```
2. Add the **Muiframework.dll** to your MelonLoader **Mods** directory.
3. Download and install **MFrameworkLoader** ([GitHub](https://github.com/MidgetBrony/MFrameWorkLoader)) to ensure **.NET 6.0 libraries** are properly loaded.
4. Ensure all dependencies (e.g., WPF libraries) are included in your **MelonLoader** setup.

---

## Usage

### UI Factory
`UIFactory` provides methods to create **custom controls**:

#### Creating a Custom Button
```csharp
Button myButton = UIFactory.CreateButton("Click Me", 150, 50, MyButton_Click);
```

#### Creating a Button with an Icon
```csharp
Button iconButton = UIFactory.CreateButtonIcon("Save", 150, 50, "Icons/Save.png", MyButton_Click);
```

#### Creating a Custom Slider
```csharp
CustomSlider volumeSlider = UIFactory.CreateCustomSlider(400, 50, "Volume", null, 0, 100, 50, OnSliderChanged);
```

#### Creating a Custom Numeric Up-Down
```csharp
CustomNumericUpDown numericControl = UIFactory.CreateNumericUpDown(150, 0, 100, 1, 50, OnValueChanged);
```

#### Adding a Tooltip
```csharp
UIHelper.AddTooltip(myButton, "Click to execute action");
```

#### Showing a Toast Notification
```csharp
UIHelper.ShowToast("Action Completed!");
```

#### Creating a Window with Custom UI
```csharp
UIFactory.CreateWindow("My Custom Window", 800, 600, grid => {
    grid.Children.Add(myButton);
    grid.Children.Add(iconButton);
});
```

---

## UI Helper Functions
`UIHelper` provides **utility methods** to enhance UI interactions.

#### Applying Animations
```csharp
UIHelper.ApplyFadeInAnimation(myButton);
UIHelper.ApplyScaleAnimation(myButton);
```

#### Getting a Custom Font
```csharp
FontFamily customFont = UIHelper.GetFontFamily("SmoochSansLight");
```

#### Custom Tooltip Handling
```csharp
UIHelper.AddTooltip(myButton, "Click to perform action");
```

---

## Debugging & Testing
A **UITesting** project is included to help debug UI elements. This is **not required** for regular builds and can be ignored if you're just using Muiframework within **Desktop Mate**.

---

## License
**Muiframework** is licensed under **GPLv3**. You are free to use, modify, and distribute it under the same license.

---

## Contributors
**MidgetBrony**

**Pull Requests are Welcome!** 🚀

