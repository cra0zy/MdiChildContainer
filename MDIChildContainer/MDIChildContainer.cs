using System.Collections.Generic;
using System;
using Gtk;
using Gdk;

[System.ComponentModel.ToolboxItem (true)]
public partial class MDIChildContainer : VBox
{
    Pixbuf _maximizeImageNormal = new Pixbuf (null, "Icons.maximize.png");
    Pixbuf _maximizeImageHover = new Pixbuf (null, "Icons.maximize2.png");
    Pixbuf _maximizeImageDown = new Pixbuf (null, "Icons.maximize.png");

    Pixbuf _restoreImageNormal = new Pixbuf (null, "Icons.restore.png");
    Pixbuf _restoreImageHover = new Pixbuf (null, "Icons.restore2.png");
    Pixbuf _restoreImageDown = new Pixbuf (null, "Icons.restore.png");

    Pixbuf _closeImageNormal = new Pixbuf (null, "Icons.close.png");
    Pixbuf _closeImageHover = new Pixbuf (null, "Icons.close2.png");
    Pixbuf _closeImageDown = new Pixbuf (null, "Icons.close.png");

    Color _borderColor = new Color(60, 60, 60);
    Color _textColor = new Color (255, 255, 255);
    List<MDIChildWindow> _children;

    public Pixbuf MaximizeImageNormal
    {
        get { return _maximizeImageNormal; }
        set {
            _maximizeImageNormal = value;
        }
    }

    public Pixbuf MaximizeImageHover
    {
        get { return _maximizeImageHover; }
        set {
            _maximizeImageHover = value;
        }
    }

    public Pixbuf MaximizeImageDown
    {
        get { return _maximizeImageDown; }
        set {
            _maximizeImageDown = value;
        }
    }

    public Pixbuf RestoreImageNormal
    {
        get { return _restoreImageNormal; }
        set {
            _restoreImageNormal = value;
        }
    }

    public Pixbuf RestoreImageHover
    {
        get { return _restoreImageHover; }
        set {
            _restoreImageHover = value;
        }
    }

    public Pixbuf RestoreImageDown
    {
        get { return _restoreImageDown; }
        set {
            _restoreImageDown = value;
        }
    }

    public Pixbuf CloseImageNormal
    {
        get { return _closeImageNormal; }
        set {
            _closeImageNormal = value;
        }
    }

    public Pixbuf CloseImageHover
    {
        get { return _closeImageHover; }
        set {
            _closeImageHover = value;
        }
    }

    public Pixbuf CloseImageDown
    {
        get { return _closeImageDown; }
        set {
            _closeImageDown = value;
        }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set {
            _borderColor = value;
        }
    }

    public Color TextColor
    {
        get { return _textColor; }
        set {
            _textColor = value;
        }
    }

    public List<MDIChildWindow> MDIChildWindows {
        get { return _children; }
    }

    public bool Maximized {
        get { return max; }
    }

    bool max;
	MDIChildWindow mwidget;

	public MDIChildContainer ()
	{
		this.Build ();

        eventbox_titlebar.ModifyBg (StateType.Normal, BorderColor);
        eventbox_restore.ModifyBg (StateType.Normal, BorderColor);
        eventbox_close.ModifyBg (StateType.Normal, BorderColor);
        label_title.ModifyFg (StateType.Normal, TextColor);

        _children = new List<MDIChildWindow>();
        max = false;
	}

    public void AddWindow(Widget widget, string title)
	{
        UnMaximizeWindow();

        MDIChildWindow child = new MDIChildWindow (fixed1, this, widget, 0, 0, title, 100, 100, 480, 320);
        _children.Add (child);
        fixed1.Add (child);
        child.Show ();

        child.ResetCursor ();
    }

    public void RemoveWindow (MDIChildWindow mwidget)
    {
        if (max)
        {
            eventbox1.Remove(mwidget.ContentWidget);
            this.mwidget = null;
        }

        fixed1.Remove (mwidget);
        _children.Remove (mwidget);
        this.ShowAll ();
    }

	public void RefreshLabel ()
	{
		if(max)
            label_title.Text = mwidget.Title;
	}

    public void RefreshTheme ()
    {
        foreach (MDIChildWindow child in _children)
            child.ReloadTheme();
    }

    public void UnMaximizeWindow ()
    {
        if (max) {
            eventbox1.Remove (mwidget.ContentWidget);
            mwidget.eventbox_content.Add (mwidget.ContentWidget);
            max = false;
            notebook1.CurrentPage = 0;
        }
    }

	public void MaximizeWindow (MDIChildWindow mwidget)
    {
        UnMaximizeWindow();

        fixed1.Remove (mwidget);
        fixed1.Add (mwidget);
        fixed1.Move (mwidget, mwidget.curx, mwidget.cury);

        max = true;
        this.mwidget = mwidget;

        RefreshLabel ();

        mwidget.eventbox_content.Remove (mwidget.ContentWidget);
        eventbox1.Add (mwidget.ContentWidget);
        mwidget.ShowAll ();

        notebook1.CurrentPage = 1;
        eventbox1.ShowAll ();
	}

	protected void Restore_Enter (object o, EnterNotifyEventArgs args)
	{
        image_restore.Pixbuf = RestoreImageHover;
	}

    protected void Restore_Leave (object o, LeaveNotifyEventArgs args)
	{
        image_restore.Pixbuf = RestoreImageNormal;
    }

    protected void Restore_Pressed (object o, ButtonPressEventArgs args)
    {
        eventbox1.Remove (mwidget.ContentWidget);
        mwidget.eventbox_content.Add (mwidget.ContentWidget);
        max = false;
        notebook1.CurrentPage = 0;
    }

    protected void Close_Enter (object o, EnterNotifyEventArgs args)
	{
        image_close.Pixbuf = CloseImageHover;
	}

	protected void Close_Leave (object o, LeaveNotifyEventArgs args)
	{
        image_close.Pixbuf = CloseImageNormal;
	}

    protected void Close_Pressed (object o, ButtonPressEventArgs args)
	{
		RemoveWindow (mwidget);
		mwidget = null;
		max = false;
		notebook1.CurrentPage = 0;
	}
}
