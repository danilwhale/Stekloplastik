namespace Stekloplastik.RealFS;

public sealed class System32 : Folder
{
    public System32() 
        : base("System32", null, null)
    {
        OnOpen += (ref bool cancel) =>
        {
            cancel = true;

            MessageBox.Show(
                "FILE SECURITY SYSTEM:\n" +
                "Detected suspicious attempt to open system files.\n" +
                "Exitting after pressing OK to secure the data",
                "File Security System(TM)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            Application.Exit();
        };
    }
}