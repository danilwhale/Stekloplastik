namespace Stekloplastik.Windows;

public sealed class WhatAboutComputer : WindowContent
{
    public override string Title => "What About Computer(TM)";
    public override Bitmap? Icon => Resources.GetBitmap("che_po_kompy.png");

    readonly TabControl tabControl;

    public WhatAboutComputer()
    {   
        tabControl = new TabControl
        {
            Dock = DockStyle.Fill,
            Alignment = TabAlignment.Bottom
        };

        TabPage mainPage = new()
        {
            Text = "Main"
        };
        mainPage.Controls.Add(
            new PictureBox
            {
                Image = Resources.GetBitmap("stekloplastiklogo.png"),
                Location = new Point(15, 15),
                Size = new Size(72, Height - (15 + 15)),
                SizeMode = PictureBoxSizeMode.StretchImage
            }
        );
        
        tabControl.TabPages.Add(mainPage);

        Controls.Add(tabControl);
    }
}
