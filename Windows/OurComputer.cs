namespace Stekloplastik.Windows;

public sealed class OurComputer : WindowContent
{
    public override string Title => "Our Computer";
    public override Bitmap? Icon => Resources.GetBitmap("nash_calculyator.png");

    MenuStrip menuStrip;
    TextBox pathBox;

    public OurComputer()
    {
        menuStrip = new MenuStrip
        {
            Size = new Size(Width, 16)
        };
        menuStrip.Items.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("file"),
            new ToolStripMenuItem("edit") { Enabled = false },
            new ToolStripMenuItem("what about pc"),
            new ToolStripMenuItem("home"),
            new ToolStripMenuItem(Resources.GetBitmap("steklopaketopitlogo.png")) { Alignment = ToolStripItemAlignment.Right }
        });

        pathBox = new TextBox
        {
            Dock = DockStyle.Top,
            Text = "urpc/"
        };

        Controls.Add(pathBox);
        Controls.Add(menuStrip);

    }
}