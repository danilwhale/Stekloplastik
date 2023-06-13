namespace Stekloplastik;

public static class Resources
{
    public const string AppResourcesPath = "Stekloplastik.Resources.";
    public static Bitmap GetBitmap(string name)
    {
        var asm = typeof(Resources).Assembly;
        var stream = asm.GetManifestResourceStream(AppResourcesPath + name);

        if (stream != null)
        {
            return new Bitmap(stream);
        }

        throw new ArgumentException("Resource not found", nameof(name));
    }

    public static Cursor GetCursor(string name)
    {
        var asm = typeof(Resources).Assembly;
        var stream = asm.GetManifestResourceStream(AppResourcesPath + name);

        if (stream != null)
        {
            return new Cursor(stream);
        }

        throw new ArgumentException("Resource not found", nameof(name));
    }

    public static Icon GetIcon(string name)
    {
        var asm = typeof(Resources).Assembly;
        var stream = asm.GetManifestResourceStream(AppResourcesPath + name);

        if (stream != null)
        {
            return new Icon(stream);
        }

        throw new ArgumentException("Resource not found", nameof(name));
    }
}