using Stekloplastik.Windows;

namespace Stekloplastik;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        timeLabel.Text = DateTime.Now.ToShortTimeString();
    }

    private void UpdateTimeLabel(object? sender, EventArgs ev)
    {
        timeLabel.Text = DateTime.Now.ToShortTimeString();
    }

    private void ToggleStartMenu(object? sender, EventArgs ev)
    {
        startMenu.Visible = !startMenu.Visible;
    }
}
