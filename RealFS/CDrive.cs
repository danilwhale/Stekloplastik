namespace Stekloplastik.RealFS;

public sealed class CDrive : IconFolder
{
    public override string? Path => "C:/";
    public CDrive() 
        : base(
            "C:", 
            new Folder[] { new SteplOT32(), new Programs() }, 
            new File[] { new File("bootsect.dat") })
    {
        ImageIndex = IconFolderIndex.Disk;
    }
}