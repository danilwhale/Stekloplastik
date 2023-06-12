namespace Stekloplastik.RealFS;

public class File
{
    public string Name { get; }
    public event Action? OnOpen;

    public File(string name)
    {
        Name = name;
        OnOpen = OnOpenDefaultHandler;
    }

    public File(string name, Action? onOpen)
    {
        Name = name;
        OnOpen = onOpen;
    }

    private static void OnOpenDefaultHandler()
    {
        MessageBox.Show(
            "None application can't open this file format", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    internal void InvokeOnOpen()
    {
        OnOpen?.Invoke();
    }
}