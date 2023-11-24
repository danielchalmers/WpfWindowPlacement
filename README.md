# WpfWindowPlacement [![NuGet](https://img.shields.io/nuget/v/WpfWindowPlacement.svg)](https://www.nuget.org/packages/WpfWindowPlacement)

[WINDOWPLACEMENT](https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowplacement) helpers for WPF.

## Example

Define a [`WindowPlacement`](WpfWindowPlacement/WindowPlacement.cs) property.

```csharp
using WpfWindowPlacement;
WindowPlacement MyPlacement { get; set; }
```

Now use it in the XAML attached property or code-behind functions.

### XAML

```xaml
xmlns:wp="clr-namespace:WpfWindowPlacement;assembly=WpfWindowPlacement"

<!-- Update size, position, and state on SourceInitialized and Closing -->
wp:WindowPlacementProperties.Placement="{Binding MyPlacement}"
```

### Code-behind

```csharp
using WpfWindowPlacement;

// Get window size, position, and state, and assign to MyPlacement.
MyPlacement = WindowPlacementFunctions.GetPlacement(this);

// Set window size, position, and state to the value of MyPlacement.
WindowPlacementFunctions.SetPlacement(this, MyPlacement);
```

## License

[MIT License](LICENSE.md)
