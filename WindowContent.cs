namespace Stekloplastik;

public class WindowContent : Control
{
    public Window? Window { get; set; }
    public virtual string Title => "";
    public virtual Bitmap? Icon => null;

    public WindowContent()
    {
        Size = new Size(400, 300 - 32);
    }
}