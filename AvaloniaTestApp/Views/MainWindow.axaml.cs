using Avalonia.Controls;
using Avalonia.Controls.Diagnostics;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Input;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Element_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        var toolTip = new ToolTip() { Content = "testing tooltip" };
        var parentControl = sender as Control;
        ToolTip.SetTip(parentControl, toolTip);
        ToolTip.SetIsOpen(parentControl, true);
        if (toolTip is IPopupHostProvider popupHostProvider && popupHostProvider.PopupHost is not null)
        {
            popupHostProvider.PopupHost.ConfigurePosition(
                parentControl,
                PlacementMode.AnchorAndGravity,
                e.GetPosition(parentControl),
                PopupAnchor.TopLeft,
                PopupGravity.BottomRight
            );
        }
    }
}