# WpfWindowPlacement
[SetWindowPlacement](https://msdn.microsoft.com/en-us/library/windows/desktop/ms633544.aspx) and [GetWindowPlacement](https://msdn.microsoft.com/en-us/library/windows/desktop/ms633518.aspx) helpers for WPF applications.

Available from NuGet: https://www.nuget.org/packages/WpfWindowPlacement.

## How to use
### Code-behind:
Include the namespace.

    using WpfWindowPlacement;

Define a `WindowPlacement` property.

    WindowPlacement PlacementProperty { get; set; }
	
Get window size, position, state and assign to `PlacementProperty`.  
This has to be called after the window has been initialized.

	PlacementProperty = WindowPlacementFunctions.GetPlacement(this);

Set window size, position, state to `PlacementProperty`.

	WindowPlacementFunctions.SetPlacement(this, PlacementProperty);

### XAML:
Include the namespace.

    xmlns:wp="clr-namespace:WpfWindowPlacement;assembly=WpfWindowPlacement"

Bind window size, position, state to a `WindowPlacement` property.

	wp:WindowPlacementProperties.Placement="{Binding PlacementProperty}"

Enable placement tracking.

	wp:WindowPlacementProperties.TrackPlacement="True"


## License
Licensed with the [MIT License](LICENSE.md).