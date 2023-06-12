namespace Stekloplastik;

public class DesktopShortcut : Control
{
    public event Action? Activated;

    private string _Title;
    public string Title
    {
        get => _Title;
        set
        {
            _Title = value;
            _titleLabel.Text = value;
        }
    }

    private Bitmap? _Icon;
    public Bitmap? Icon
    {
        get => _Icon;
        set
        {
            if (_Icon != null)
                _Icon.Dispose();
            _Icon = value;

            _iconBox.Image = value;
        }
    }

    private Label _titleLabel;
    private PictureBox _iconBox;

    public DesktopShortcut(string title, Bitmap? icon = null)
    {
        _Title = title;
        _Icon = icon;

        MinimumSize = new Size(64, 64);
        if (Parent != null)
            BackColor = Parent.BackColor;
        // AutoSize = true;

        _iconBox = new PictureBox
        {
            Image = icon,
            Size = new Size(64, 64),
            SizeMode = PictureBoxSizeMode.StretchImage
        };  

        _titleLabel = new Label
        {
            Text = title,
            MaximumSize = new Size(64, 1024),
            AutoSize = true,
            Font = new Font("Comic Sans MS", 8),
            Location = new Point(0, 64 + 5),
            TextAlign = ContentAlignment.MiddleCenter
        };

        _iconBox.DoubleClick += (_, _) => Activated?.Invoke();
        _titleLabel.DoubleClick += (_, _) => Activated?.Invoke();

        Size = new Size(64, 64 + 5 + _titleLabel.Height + 5);

        Controls.Add(_iconBox);
        Controls.Add(_titleLabel);
    }
}