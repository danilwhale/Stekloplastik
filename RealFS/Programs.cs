namespace Stekloplastik.RealFS;

public sealed class Programs : Folder
{
    public override string? Path => "C:/Program Files";
    public Programs() 
        : base("Program Files", null, null)
    {
        OnOpen += (ref bool cancel) =>
        {
            cancel = true;
            MessageBox.Show("WIP");
        };
    }
}