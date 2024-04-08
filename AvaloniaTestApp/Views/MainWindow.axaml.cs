using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Diagnostics;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Input;
using Avalonia.Media;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Element_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        var popup = new Popup
        {
            Child = new ContentControl(){ Content = "Test tooltip" },
            PlacementTarget = sender as Control,
            Placement = PlacementMode.Pointer,
            WindowManagerAddShadowHint = true,
            PlacementConstraintAdjustment = PopupPositionerConstraintAdjustment.All,
            IsLightDismissEnabled = true,
        };
        
        ((ISetLogicalParent)popup).SetParent(sender as Control);

        popup.Open();
        // this is added to show that there is no corner radius and border shadow applied as per underlying OS
        (popup.Host as PopupRoot).Background = Brushes.Gray;
    }
}