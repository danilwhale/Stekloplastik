using Stekloplastik.Windows;

namespace Stekloplastik;

public sealed class Desktop : Panel
{
    PictureBox ourComputerShortcut;
    FlowLayoutPanel shortcuts;

    public Desktop()
    {
        shortcuts = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            BackColor = Color.Transparent
        };

        ourComputerShortcut = new PictureBox
        {
            Image = Resources.GetBitmap("nash_calculyator.png"),
            Size = new Size(64, 64)
        };
        ourComputerShortcut.Click += (_, _) =>
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