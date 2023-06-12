namespace Stekloplastik.Windows;

public sealed class OurComputer : WindowContent
{
    Button button;

    public OurComputer()
    {
        button = new Button
        {
            Size = new Size(200, 64),
            Text = "пр люди"
        };
        Controls.Add(button);
    }
}