using Stekloplastik.Windows;

namespace Stekloplastik;

public partial class Form1 : Form
{
    public Form1()
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
