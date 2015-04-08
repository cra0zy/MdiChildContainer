using System.Timers;
using System;
using Gtk;

[System.ComponentModel.ToolboxItem (true)]
public partial class MDIChildWindow : VBox
{
	public Timer timer = new Timer(10);
	MDIChildContainer container;
	Fixed fixedLayout;
	public Widget ContentWidget;
	Widget tmpwidget;
	public int curx = 0, cury = 0;
	int minw = 100, minh = 100;
	int x, y, w, h;

    public MDIChildWindow (Fixed fixedLayout, MDIChildContainer container, Widget widget, int x, int y, string title, int minw, int minh, int width, int height)
    {
		this.container = container;
		this.fixedLayout = fixedLayout;
        this.ContentWidget = widget;
        this.minw = minw;
        this.minh = minh;
		this.x = x;
        this.y = y;
        this.w = Math.Max(minw, width);
        this.h = Math.Max(minh, height);

        this.Build ();

        label1.Text = title;
        eventbox_content.Add (this.ContentWidget);

		tmpwidget = new Gtk.Button ();
		tmpwidget.WidthRequest = 1;
		tmpwidget.HeightRequest = 1;

        ReloadTheme ();
		this.ShowAll ();
	}

    public void ReloadTheme()
    {
        eventbox1.ModifyBg (StateType.Normal, container.BorderColor);
        eventbox3.ModifyBg (StateType.Normal, container.BorderColor);
        eventbox4.ModifyBg (StateType.Normal, container.BorderColor);
        eventbox6.ModifyBg (StateType.Normal, container.BorderColor);
        borderbottomright.ModifyBg (StateType.Normal, container.BorderColor);
        borderbottom.ModifyBg (StateType.Normal, container.BorderColor);
        borderright.ModifyBg (StateType.Normal, container.BorderColor);
        bordertopleft.ModifyBg (StateType.Normal, container.BorderColor);
        borderleft.ModifyBg (StateType.Normal, container.BorderColor);
        bordertop.ModifyBg (StateType.Normal, container.BorderColor);
        borderbottomleft.ModifyBg (StateType.Normal, container.BorderColor);
        bordertopright.ModifyBg (StateType.Normal, container.BorderColor);
        label1.ModifyFg (StateType.Normal, container.TextColor);

        image1.Pixbuf = container.MaximizeImageNormal;
        image3.Pixbuf = container.CloseImageNormal;
    }

	public string Title
	{
        get {
            return label1.Text;
        }
        set {
            label1.Text = value;
        }
	}

	[GLib.ConnectBefore]
	protected void OnButtonMovePressed (object sender, EventArgs e)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = Math.Max (0, x);
		y = Math.Max (0, y);
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);
		
		ResetCursor ();
		fixedLayout.Add (tmpwidget);
		fixedLayout.Move (tmpwidget, curx + w, cury + h);
		tmpwidget.Show ();

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx || my2 != my)
					{
						x =  x - mx + mx2;
						y = y - my + my2;

						mx = mx2;
						my = my2;

						curx = Math.Max(0, x);
						cury = Math.Max(0, y);
						fixedLayout.Move (this, curx, cury);
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	[GLib.ConnectBefore]
	protected void OnButtonReleased (object sender, EventArgs e)
	{
		timer.Stop ();
		fixedLayout.Remove (tmpwidget);
	}

	public void ResetCompenents()
	{
		eventbox1.WidthRequest = this.WidthRequest;
		eventbox1.HeightRequest = this.HeightRequest;

        eventbox_content.WidthRequest = this.WidthRequest - 8;
        eventbox_content.HeightRequest = this.HeightRequest - 30;

		eventbox3.WidthRequest = this.WidthRequest - 8;

		fixed3.Move (borderbottomright, this.WidthRequest - 16, this.HeightRequest - 16);

		borderbottom.WidthRequest = this.WidthRequest - 32;
		fixed3.Move (borderbottom, 16, this.HeightRequest - 16);

		borderright.HeightRequest = this.HeightRequest - 32;
		fixed3.Move (borderright, this.WidthRequest - 16, 16);

		borderleft.HeightRequest = this.HeightRequest - 32;

		bordertop.WidthRequest = this.WidthRequest - 32;
		
		fixed3.Move (borderbottomleft, 0, this.HeightRequest - 16);

		fixed3.Move (bordertopright, this.WidthRequest - 16, 0);

		ResetCursor ();
	}

	public void ResetCursor()
	{
		bordertopleft.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.TopLeftCorner);
		borderleft.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.LeftSide);
		borderbottomright.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.BottomRightCorner);
		borderbottom.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.BottomSide);
		borderright.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.RightSide);
		bordertop.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.TopSide);
		borderbottomleft.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.BottomLeftCorner);
		bordertopright.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.TopRightCorner);
	}

	protected void OnBorderbottomrightButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx || my2 != my)
					{
						w = w - mx + mx2;
						h = h - my + my2;

						mx = mx2;
						my = my2;

						this.WidthRequest = Math.Max(w, minw);
						this.HeightRequest = Math.Max(h, minh);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBorderbottomButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(my2 != my)
					{
						h = h - my + my2;
						my = my2;
						this.HeightRequest = Math.Max(h, minh);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBorderrightButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx)
					{
						w = w - mx + mx2;
						mx = mx2;
						this.WidthRequest = Math.Max(w, minw);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnEventbox5ButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();
		int tmpw = w + x, tmph = h + y;

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx || my2 != my)
					{
						x = x - mx + mx2;
						y = y - my + my2;

						w = tmpw - Math.Max(0, x);
						h = tmph - Math.Max(0, y);

						mx = mx2;
						my = my2;

						curx = Math.Min(tmpw - minw, Math.Max(0, x));
						cury = Math.Min(tmph - minh, Math.Max(0, y));
						fixedLayout.Move (this, Math.Min(tmpw - minw, Math.Max(0, x)), Math.Min(tmph - minh, Math.Max(0, y)));

						this.WidthRequest = Math.Max(w, minw);
						this.HeightRequest = Math.Max(h, minh);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBorderleftButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);
		
		x = curx;
		y = cury;
		w = this.WidthRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();
		int tmpw = w + x;

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx)
					{
						x = x - mx + mx2;
						w = tmpw - Math.Max(0, x);
						mx = mx2;
						
						curx = Math.Min(tmpw - minw, Math.Max(0, x));
						fixedLayout.Move (this, Math.Min(tmpw - minw, Math.Max(0, x)), cury);
						this.WidthRequest = Math.Max(w, minw);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBordertopButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);

		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();
		int tmph = h + y;

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(my2 != my)
					{
						y = y - my + my2;
						h = tmph - Math.Max(0, y);
						my = my2;

						cury = Math.Min(tmph - minh, Math.Max(0, y));
						fixedLayout.Move (this, curx, Math.Min(tmph - minh, Math.Max(0, y)));
						this.HeightRequest = Math.Max(h, minh);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBottomleftButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);

		x = curx;
		y = cury;
		w = this.WidthRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();
		int tmpw = w + x;

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(mx2 != mx || my2 != my)
					{
						x = x - mx + mx2;
						w = tmpw - Math.Max(0, x);
						mx = mx2;
						
						h = h - my + my2;
						my = my2;

						curx = Math.Min(tmpw - minw, Math.Max(0, x));
						fixedLayout.Move (this, Math.Min(tmpw - minw, Math.Max(0, x)), cury);
						this.WidthRequest = Math.Max(w, minw);
						this.HeightRequest = Math.Max(h, minh);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnBordertoprightButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
		int mx, my;
		Gdk.Display.Default.GetPointer (out mx, out my);
		fixedLayout.Remove (this);
		fixedLayout.Add (this);

		x = curx;
		y = cury;
		w = this.WidthRequest;
		h = this.HeightRequest;
		fixedLayout.Move (this, curx, cury);

		ResetCursor ();
		int tmph = h + y;

		timer.Stop ();
		timer = new Timer(10);
		timer.Elapsed += delegate 
		{
			try
			{
				Gtk.Application.Invoke (delegate {

					int mx2, my2;
					Gdk.Display.Default.GetPointer (out mx2, out my2);

					if(my2 != my || mx2 != mx)
					{
						y = y - my + my2;
						w = w - mx + mx2;
						h = tmph - Math.Max(0, y);
						my = my2;
						mx = mx2;

						cury = Math.Min(tmph - minh, Math.Max(0, y));
						fixedLayout.Move (this, curx, Math.Min(tmph - minh, Math.Max(0, y)));
						this.HeightRequest = Math.Max(h, minh);
						this.WidthRequest = Math.Max(w, minw);

						ResetCompenents();
						fixedLayout.ShowAll();
					}
				});
			}
			catch { }
		};
		timer.Start();
	}

	protected void OnEventbox4ButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
        image1.Pixbuf = container.MaximizeImageNormal;
		container.MaximizeWindow (this);
	}

	protected void OnEventbox4EnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
	{
        image1.Pixbuf = container.MaximizeImageHover;
	}

	protected void OnEventbox4LeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
	{
        image1.Pixbuf = container.MaximizeImageNormal;
	}

	protected void OnEventbox6EnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
	{
        image3.Pixbuf = container.CloseImageHover;
	}

	protected void OnEventbox6LeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
	{
        image3.Pixbuf = container.CloseImageNormal;
	}

	protected void OnEventbox6ButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
	{
        container.RemoveWindow (this.ContentWidget);
	}
}

