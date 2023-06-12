namespace Stekloplastik;

public class StartMenuPanel : Panel
{
    Label usernameLabel;
    Button shutdownButton;
    PictureBox adminImage;
    Panel appsPanel;
    Label noAppsLabel;

    public StartMenuPanel()
    {
        Visible = false;

        Size = new Size(272, 376);
        BackColor = Color.FromArgb(128, 153, 255);
        ForeColor = Color.White;

        usernameLabel = new Label
        {
            Location = new Point(80, 20),
            Size = new Size(Width - 80, 36),

            Font = new Font("Comic Sans MS", 14, FontStyle.Italic),
            Text = "Администратор",
            TextAlign = ContentAlignment.MiddleLeft
        };

        adminImage = new PictureBox
        {
            Image = Resources.GetBitmap("user.png"),
            Size = new Size(64, 64),
            Location = new Point(8, 8)
        };

        appsPanel = new Panel
        {
            BackColor = Color.FromArgb(102, 128, 230),
            Location = new Point(8, 96),
            Size = new Size(256, 208)
        };

        noAppsLabel = new Label
        {
            Location = new Point(16, 60),
            Size = new Size(224, 80),
            Font = new Font("Comic Sans MS", 15),
            ForeColor = Color.White,
            Text = "у вас нету программ\nхдддд",
        };

        shutdownButton = Form1.CreateImageButton(
            Resources.GetBitmap("shutdown.png"),
            Resources.GetBitmap("shutdown_hover.png"),
            Resources.GetBitmap("shutdown_pressed.png")
        );
        shutdownButton.Location = new Point(144, 320);
        shutdownButton.Size = new Size(112, 32);
        shutdownButton.Click += (_, _) => Application.Exit();

        appsPanel.Controls.Add(noAppsLabel);

        Controls.Add(usernameLabel);
        Controls.Add(adminImage);
        Controls.Add(appsPanel);
        Controls.Add(shutdownButton);
    }
}