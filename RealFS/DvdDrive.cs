namespace Stekloplastik.RealFS;

public sealed class DvdDrive : IconFolder
{
    public DvdDrive() 
        : base("D:", null, null)
    {
        ImageIndex = IconFolderIndex.Dvd;
        OnOpen += (ref bool cancel) =>
        {
            cancel = true;
            MessageBox.Show("Insert disc into D:", "D:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        };
    }
}