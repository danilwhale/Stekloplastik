using Stekloplastik.Windows;

namespace Stekloplastik;

public sealed class Desktop : Panel
{
    DesktopShortcut ourComputerShortcut;
    FlowLayoutPanel shortcuts;

    public Desktop()
    {
        shortcuts = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown
        };

        ourComputerShortcut = new DesktopShortcut(
            "Our Computer",
            Resources.GetBitmap("nash_calculyator.png")
        );
        ourComputerShortcut.Activated += () =>
        {
            var window = new Window(new OurComputer());
            Controls.Add(window);
            Controls.SetChildIndex(window, 0);
        };

        shortcuts.Controls.Add(ourComputerShortcut);
        Controls.Add(shortcuts);
        Controls.SetChildIndex(shortcuts, Controls.Count - 1);
    }
}