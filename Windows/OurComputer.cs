namespace Stekloplastik.Windows;

public sealed class OurComputer : WindowContent
{
    MenuStrip menuStrip;

    public OurComputer()
    {
        menuStrip = new MenuStrip
        {
            Size = new Size(Width, 16)
        };
        menuStrip.Items.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("file"),
            new ToolStripMenuItem("edit") { Enabled = false }
        });

        Controls.Add(menuStrip);
    }
}