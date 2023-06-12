namespace Stekloplastik.RealFS;

public sealed class SteplOT32 : Folder
{
    public override string? Path => "C:/SteplOT32";
    public SteplOT32() 
        : base(
            "SteplOT32", 
            new Folder[] { new System32() }, 
            new File[] { new File("system.ini"), new File("notepad.exe"), new File("stelpinit.exe") })
    {
    }
}