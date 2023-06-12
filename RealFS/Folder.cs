namespace Stekloplastik.RealFS;

public class Folder
{
    public virtual string? Path { get; set; }
    public string Name { get; }
    public Folder[]? Subfolders { get; }
    public File[]? Subfiles { get; }
    public event FolderOpennedDelegate? OnOpen;

    public Folder(string name, Folder[]? subfolders = null, File[]? subfiles = null)
    {
        Name = name;
        Subfolders = subfolders;
        Subfiles = subfiles;
    }

    internal void InvokeOnOpen(ref bool cancel)
    {
        if (OnOpen != null)
        {
            OnOpen.Invoke(ref cancel);
        }
        else
        {
            cancel = false;
        }
    }
}