# WpfWindowPlacement
[WINDOWPLACEMENT](https://msdn.microsoft.com/en-us/library/windows/desktop/ms632611.aspx) helpers for WPF.

Available from NuGet: https://nuget.org/packages/WpfWindowPlacement.

## How to use
### Code-behind
Include namespace.

    using WpfWindowPlacement;

Define a [`WindowPlacement`](WpfWindowPlacement/WindowPlacement.cs) property.

    WindowPlacement MyPlacement { get; set; }
	
Get window size, position, and state, and assign to `MyPlacement`.  
This must be called after the window has been initialized.

    MyPlacement = WindowPlacementFunctions.GetPlacement(this);

Set window size, position, state to `MyPlacement`.

    WindowPlacementFunctions.SetPlacement(this, MyPlacement);

### XAML
Include namespace.

    xmlns:wp="clr-namespace:WpfWindowPlacement;assembly=WpfWindowPlacement"

Bind window size, position, and state to a [`WindowPlacement`](WpfWindowPlacement/WindowPlacement.cs) property.

    wp:WindowPlacementProperties.Placement="{Binding MyPlacement}"

Enable placement tracking.

    wp:WindowPlacementProperties.TrackPlacement="True"


## License
[MIT License](LICENSE.md).
