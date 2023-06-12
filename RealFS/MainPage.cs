namespace Stekloplastik.RealFS;

public class MainPage : Folder
{
    public override string? Path => "urpc/";
    public MainPage() 
        : base("urpc", new Folder[] { new CDrive(), new DvdDrive() }, null)
    {

    }
}