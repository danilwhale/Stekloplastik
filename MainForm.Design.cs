using Timer = System.Windows.Forms.Timer;

namespace Stekloplastik;

public sealed partial class MainForm
{
    #nullable disable
    Panel taskbar;
    Button spusk;
    Label timeLabel;
    Timer timeLabelUpdater;
    StartMenuPanel startMenu;
    Desktop desktop;
    #nullable enable

    private void InitializeComponent()
    {
        Text = ProductName + " Opit";

        FormBorderStyle = FormBorderStyle.FixedSingle;
        ClientSize = new Size(800, 600);

        // BackgroundImage = Resources.GetBitmap("desktop.png");
        // BackgroundImageLayout = ImageLayout.Stretch;
        BackColor = Color.DarkGray;

        Icon = Resources.GetIcon("icon.ico");
        Cursor = Resources.GetCursor("cursor.cur");

        MaximizeBox = false;

        taskbar = new Panel
        {
            Dock = DockStyle.Bottom,
            Size = new Size(Size.Width, 32),
            BackColor = Color.FromArgb(128, 153, 255),
            ForeColor = Color.White
        };

        spusk = CreateImageButton(
            Resources.GetBitmap("spusk.png"), 
            Resources.GetBitmap("spusk_hover.png"), 
            Resources.GetBitmap("spusk_pressed.png")
        );
        spusk.Dock = DockStyle.Left;
        spusk.Size = new Size(88, 32);

        spusk.Click += ToggleStartMenu;

        timeLabel = new Label
        {
            Dock = DockStyle.Right,
            
            Text = "00:00",
            Font = new Font("Comic Sans MS", 12, FontStyle.Italic),
            TextAlign = ContentAlignment.MiddleCenter,
            BackgroundImage = Resources.GetBitmap("separator_panel_bg.png"),
            BackgroundImageLayout = ImageLayout.Stretch
        };

        timeLabelUpdater = new Timer
        {
            Enabled = true,
            Interval = 1000
        };
        timeLabelUpdater.Tick += UpdateTimeLabel;

        startMenu = new StartMenuPanel
        {
            Location = new Point(0, 192)
        };

        desktop = new Desktop()
        {
            Dock = DockStyle.Fill
        };

        taskbar.Controls.AddRange(new Control[] 
        {
            spusk, timeLabel
        });
        Controls.AddRange(new Control[]
        {
            taskbar, startMenu, desktop
        });
    }

    public static Button CreateImageButton(Bitmap normal, Bitmap hover, Bitmap pressed)
    {
        var button = new Button
        {
            BackgroundImage = normal,
            BackgroundImageLayout = ImageLayout.Stretch
        };

        button.MouseEnter += (_, _) =>
        {
            button.BackgroundImage = hover;
        };
        button.MouseLeave += (_, _) =>
        {
            button.BackgroundImage = normal;
        };
        button.MouseUp += (_, _) =>
        {
            button.BackgroundImage = hover;
        };
        button.MouseDown += (_, _) =>
        {
            button.BackgroundImage = pressed;
        };

        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;

        return button;
    }
}