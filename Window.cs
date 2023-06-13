namespace Stekloplastik;

public sealed class Window : Panel
{
    private string _Title;
    public string Title
    {
        get => _Title;
        set
        {
            _Title = value;
            windowTitle.Text = _Title;
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
            windowIcon.Image = _Icon;
        }
    }
    public bool AllowClose { get; set; }

    private readonly Panel topping;
    private readonly Button closeWindowButton;
    private readonly Label windowTitle;
    private readonly PictureBox windowIcon;
    private readonly Panel _content;

    private bool _canBeMoved = false;
    private Point _offset = Point.Empty;

    public Window(string title, Bitmap? icon = null, bool allowClose = true)
    {
        Size = new Size(400, 300);
        _Title = title;
        _Icon = icon;
        AllowClose = allowClose;

        topping = new Panel
        {
            Dock = DockStyle.Top,
            Size = new Size(Width, 32),
            BackColor = Color.FromArgb(128, 153, 255)
        };

        closeWindowButton = MainForm.CreateImageButton(
            Resources.GetBitmap("close.png"),
            Resources.GetBitmap("close_h.png"),
            Resources.GetBitmap("close_p.png")
        );
        closeWindowButton.Size = new Size(32, 32);
        closeWindowButton.Location = new Point(topping.Width - 32, 0);
        closeWindowButton.Anchor = AnchorStyles.Right;
        closeWindowButton.Click += (_, _) => { if (AllowClose) Dispose(true); };

        windowIcon = new PictureBox
        {
            Image = icon,
            Size = new Size(32, 32),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Anchor = AnchorStyles.Left
        };

        windowTitle = new Label
        {
            Location = new Point(32 + 5, 0),
            Size = new Size(Width - 64, 32),
            Text = title,
            Font = new Font("Comic Sans MS", 12, FontStyle.Italic),
            ForeColor = Color.White,
            Anchor = AnchorStyles.Left,
            TextAlign = ContentAlignment.MiddleLeft
        };
        windowTitle.MouseDown += (_, _) =>
        {
            _offset = new Point(Location.X - Cursor.Position.X, Location.Y - Cursor.Position.Y);
            _canBeMoved = true;
            if (Parent != null)
            {
                Parent.Controls.SetChildIndex(this, 0);
            }
        };
        windowTitle.MouseUp += (_, _) => _canBeMoved = false;
        windowTitle.MouseMove += (_, _) => { if (_canBeMoved) Movew(); };

        _content = new Panel
        {
            Location = new Point(0, 32),
            Size = new Size(Width, Height - 32),
            Dock = DockStyle.Fill,
            BackColor = Color.White
        };

        topping.Controls.Add(closeWindowButton);
        topping.Controls.Add(windowTitle);
        topping.Controls.Add(windowIcon);

        Controls.Add(topping);
        Controls.Add(_content);
    }

    public Window(WindowContent content)
        : this(content.Title, content.Icon)
    {
        ShowContent(content);
    }

    public void ShowContent(WindowContent content)
    {
        content.Window = this;
        content.Location = new Point(0, 32);
        _content.Controls.Clear();
        _content.Controls.Add(content);
    }

    private void Movew()
    {
        Location = new Point(Cursor.Position.X + _offset.X, Cursor.Position.Y + _offset.Y);
    }
}