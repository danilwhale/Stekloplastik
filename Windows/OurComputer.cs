using Stekloplastik.RealFS;

namespace Stekloplastik.Windows;

public sealed class OurComputer : WindowContent
{
    public override string Title => "Our Computer";
    public override Bitmap? Icon => Resources.GetBitmap("nash_calculyator.png");

    MenuStrip menuStrip;
    TextBox pathBox;
    ListView folderListView;

    Folder? higherFolder;
    Folder currentFolder = null!;
    List<Folder> _cachedFolders = new List<Folder>();
    List<RealFS.File> _cachedFiles = new List<RealFS.File>();

    public OurComputer()
    {
        menuStrip = new MenuStrip
        {
            Size = new Size(Width, 16)
        };

        ToolStripMenuItem homeMenuItem = new ToolStripMenuItem("home");
        homeMenuItem.Click += (_, _) => OpenFolder(new MainPage());

        menuStrip.Items.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("file"),
            new ToolStripMenuItem("edit") { Enabled = false },
            new ToolStripMenuItem("what about pc"),
            homeMenuItem,
            new ToolStripMenuItem(Resources.GetBitmap("steklopaketopitlogo.png")) { Alignment = ToolStripItemAlignment.Right }
        });

        pathBox = new TextBox
        {
            Dock = DockStyle.Top,
            Text = "urpc/",
            Enabled = false
        };

        folderListView = new ListView
        {
            Dock = DockStyle.Fill,
            GridLines = true,
            ShowGroups = false,
            View = View.Details
        };
        folderListView.Columns.AddRange(new ColumnHeader[]
        {
            new ColumnHeader { Text = "Name", Width = 256 },
            new ColumnHeader { Text = "Type", Width = 120 }
        });
        folderListView.SmallImageList = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit,
            ImageSize = new Size(24, 24)
        };
        folderListView.SmallImageList.Images.AddRange(new Image[]
        {
            Resources.GetBitmap("file.png"),
            Resources.GetBitmap("folder.png"),
            Resources.GetBitmap("up.png"),
            Resources.GetBitmap("disk.png"),
            Resources.GetBitmap("dvd.png")
        });
        folderListView.ItemActivate += HandleFSItem;

        OpenFolder(new MainPage());

        Controls.Add(folderListView);
        Controls.Add(pathBox);
        Controls.Add(menuStrip);
    }

    private void OpenFolder(Folder folder)
    {
        bool cancel = false;
        folder.InvokeOnOpen(ref cancel);
        if (cancel) return;

        folderListView.Items.Clear();
        _cachedFiles.Clear();
        _cachedFolders.Clear();

        currentFolder = folder;
        pathBox.Text = folder.Path;

        if (higherFolder != null && currentFolder.Path != "urpc/")
            CreateItem(IconFolderIndex.Up, "..", "");

        if (folder.Subfolders != null)
        {
            foreach (var subfolder in folder.Subfolders)
            {
                _cachedFolders.Add(subfolder);
                if (subfolder is IconFolder iconFolder)
                    CreateItem(iconFolder.ImageIndex, iconFolder.Name, "Directory");
                else
                    CreateItem(IconFolderIndex.Folder, subfolder.Name, "Directory");
            }
        }
        if (folder.Subfiles != null)
        {
            foreach (var subfile in folder.Subfiles)
            {
                _cachedFiles.Add(subfile);
                CreateItem(IconFolderIndex.File, subfile.Name, "File");
            }
        }
    }
    private void CreateItem(IconFolderIndex imageIndex, string name, string type)
    {
        folderListView.Items.Add(new ListViewItem(
            new string[] { name, type },
            (int)imageIndex
        ));
    }

    private void HandleFSItem(object? sender, EventArgs ev)
    {
        if (folderListView.FocusedItem == null) return;

        var item = folderListView.FocusedItem;
        if (item.SubItems.Count < 2) return;

        if (item.SubItems[0].Text == ".." && higherFolder != null)
        {
            OpenFolder(higherFolder);
        }

        switch (item.SubItems[1].Text)
        {
            case "Directory":
                var dir = _cachedFolders.FirstOrDefault(d => d.Name == item.Text);
                if (dir != null)
                {
                    higherFolder = currentFolder;
                    OpenFolder(dir);
                }
                break;
            case "File":
                var file = _cachedFiles.FirstOrDefault(f => f.Name == item.Text);
                if (file != null)
                {
                    file.InvokeOnOpen();
                }
                break;
        }
    }
}