namespace Stekloplastik.RealFS;

public class IconFolder : Folder
{
    public IconFolder(string name, Folder[]? subfolders = null, File[]? subfiles = null) : base(name, subfolders, subfiles)
    {
    }

    public IconFolderIndex ImageIndex { get; set; }
}