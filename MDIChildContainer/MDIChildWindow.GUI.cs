public partial class MDIChildWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action MaximizeAction;
	
	private global::Gtk.EventBox eventbox1;
	
	private global::Gtk.Fixed fixed3;
	
	private global::Gtk.EventBox borderbottomright;
	
	private global::Gtk.EventBox borderbottom;
	
	private global::Gtk.EventBox borderright;
	
	private global::Gtk.EventBox bordertopleft;
	
	private global::Gtk.EventBox borderleft;
	
	private global::Gtk.EventBox bordertop;
	
	private global::Gtk.Alignment alignment3;
	
	private global::Gtk.EventBox borderbottomleft;
	
	private global::Gtk.EventBox bordertopright;
	
	public Gtk.EventBox eventbox_content;
	
	private global::Gtk.EventBox eventbox3;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.EventBox eventbox4;
	
	private global::Gtk.Image image1;
	
	private global::Gtk.Alignment alignment4;
	
	private global::Gtk.EventBox eventbox6;
	
	private global::Gtk.Image image3;
	
	private global::Gtk.Alignment alignment2;

	protected virtual void Build ()
	{
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
		this.MaximizeAction = new global::Gtk.Action ("MaximizeAction", null, null, "Maximize");
		w2.Add (this.MaximizeAction, null);
		this.UIManager.InsertActionGroup (w2, 0);
		this.WidthRequest = 480;
		this.HeightRequest = 320;
		this.Name = "GGEngine.MDIChildWindow";
		// Container child GGEngine.MDIChildWindow.Gtk.Container+ContainerChild
		this.eventbox1 = new global::Gtk.EventBox ();
		this.eventbox1.WidthRequest = 480;
		this.eventbox1.HeightRequest = 320;
		this.eventbox1.Name = "eventbox1";
		// Container child eventbox1.Gtk.Container+ContainerChild
		this.fixed3 = new global::Gtk.Fixed ();
		this.fixed3.Name = "fixed3";
		this.fixed3.HasWindow = false;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.borderbottomright = new global::Gtk.EventBox ();
		this.borderbottomright.WidthRequest = 16;
		this.borderbottomright.HeightRequest = 16;
		this.borderbottomright.Name = "borderbottomright";
		this.fixed3.Add (this.borderbottomright);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.borderbottomright]));
		w3.X = 464;
		w3.Y = 304;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.borderbottom = new global::Gtk.EventBox ();
		this.borderbottom.WidthRequest = 448;
		this.borderbottom.HeightRequest = 16;
		this.borderbottom.Name = "borderbottom";
		this.fixed3.Add (this.borderbottom);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.borderbottom]));
		w4.X = 16;
		w4.Y = 304;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.borderright = new global::Gtk.EventBox ();
		this.borderright.WidthRequest = 16;
		this.borderright.HeightRequest = 288;
		this.borderright.Name = "borderright";
		this.fixed3.Add (this.borderright);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.borderright]));
		w5.X = 464;
		w5.Y = 16;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.bordertopleft = new global::Gtk.EventBox ();
		this.bordertopleft.WidthRequest = 16;
		this.bordertopleft.HeightRequest = 16;
		this.bordertopleft.Name = "bordertopleft";
		this.fixed3.Add (this.bordertopleft);
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.borderleft = new global::Gtk.EventBox ();
		this.borderleft.WidthRequest = 16;
		this.borderleft.HeightRequest = 288;
		this.borderleft.Name = "borderleft";
		this.fixed3.Add (this.borderleft);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.borderleft]));
		w7.Y = 16;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.bordertop = new global::Gtk.EventBox ();
		this.bordertop.WidthRequest = 448;
		this.bordertop.HeightRequest = 16;
		this.bordertop.Name = "bordertop";
		// Container child bordertop.Gtk.Container+ContainerChild
		this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment3.Name = "alignment3";
		this.bordertop.Add (this.alignment3);
		this.fixed3.Add (this.bordertop);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.bordertop]));
		w9.X = 16;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.borderbottomleft = new global::Gtk.EventBox ();
		this.borderbottomleft.WidthRequest = 16;
		this.borderbottomleft.HeightRequest = 16;
		this.borderbottomleft.Name = "borderbottomleft";
		this.fixed3.Add (this.borderbottomleft);
		global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.borderbottomleft]));
		w10.Y = 304;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.bordertopright = new global::Gtk.EventBox ();
		this.bordertopright.WidthRequest = 16;
		this.bordertopright.HeightRequest = 16;
		this.bordertopright.Name = "bordertopright";
		this.fixed3.Add (this.bordertopright);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.bordertopright]));
		w11.X = 464;
		// Container child fixed3.Gtk.Fixed+FixedChild
        this.eventbox_content = new global::Gtk.EventBox ();
        this.eventbox_content.WidthRequest = 472;
        this.eventbox_content.HeightRequest = 290;
        this.eventbox_content.Name = "eventbox2";
        this.fixed3.Add (this.eventbox_content);
		global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.eventbox_content]));
		w12.X = 4;
		w12.Y = 26;
		// Container child fixed3.Gtk.Fixed+FixedChild
		this.eventbox3 = new global::Gtk.EventBox ();
		this.eventbox3.WidthRequest = 472;
		this.eventbox3.HeightRequest = 20;
		this.eventbox3.Name = "eventbox3";
		// Container child eventbox3.Gtk.Container+ContainerChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		// Container child hbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = "label1";
		this.hbox1.Add (this.label1);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
		w13.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.eventbox4 = new global::Gtk.EventBox ();
		this.eventbox4.Name = "eventbox4";
		// Container child eventbox4.Gtk.Container+ContainerChild
		this.image1 = new global::Gtk.Image ();
		this.image1.Name = "image1";
		this.image1.Xalign = 0F;
		this.image1.Yalign = 0F;
        this.image1.Pixbuf = container.MaximizeImageNormal;
		this.eventbox4.Add (this.image1);
		this.hbox1.Add (this.eventbox4);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.eventbox4]));
		w15.Position = 2;
		w15.Expand = false;
		w15.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment4.WidthRequest = 7;
		this.alignment4.Name = "alignment4";
		this.hbox1.Add (this.alignment4);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment4]));
		w16.Position = 3;
		w16.Expand = false;
		w16.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.eventbox6 = new global::Gtk.EventBox ();
		this.eventbox6.Name = "eventbox6";
		// Container child eventbox6.Gtk.Container+ContainerChild
		this.image3 = new global::Gtk.Image ();
		this.image3.Name = "image3";
		this.image3.Xalign = 0F;
		this.image3.Yalign = 0F;
        this.image3.Pixbuf = container.CloseImageNormal;
		this.eventbox6.Add (this.image3);
		this.hbox1.Add (this.eventbox6);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.eventbox6]));
		w18.Position = 4;
		w18.Expand = false;
		w18.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
		this.alignment2.WidthRequest = 3;
		this.alignment2.Name = "alignment2";
		this.hbox1.Add (this.alignment2);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment2]));
		w19.Position = 5;
		w19.Expand = false;
		this.eventbox3.Add (this.hbox1);
		this.fixed3.Add (this.eventbox3);
		global::Gtk.Fixed.FixedChild w21 = ((global::Gtk.Fixed.FixedChild)(this.fixed3 [this.eventbox3]));
		w21.X = 4;
		w21.Y = 4;
		this.eventbox1.Add (this.fixed3);
		this.Add (this.eventbox1);
		this.Hide ();
		this.eventbox1.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.borderbottomright.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBorderbottomrightButtonPressEvent);
		this.borderbottomright.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.borderbottom.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBorderbottomButtonPressEvent);
		this.borderbottom.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.borderright.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBorderrightButtonPressEvent);
		this.borderright.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.bordertopleft.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnEventbox5ButtonPressEvent);
		this.bordertopleft.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.borderleft.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBorderleftButtonPressEvent);
		this.borderleft.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.bordertop.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBordertopButtonPressEvent);
		this.bordertop.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.borderbottomleft.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBottomleftButtonPressEvent);
		this.borderbottomleft.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnButtonReleased);
		this.bordertopright.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnBordertoprightButtonPressEvent);
		this.eventbox3.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnButtonMovePressed);
		this.eventbox4.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnEventbox4ButtonPressEvent);
		this.eventbox4.EnterNotifyEvent += new global::Gtk.EnterNotifyEventHandler (this.OnEventbox4EnterNotifyEvent);
		this.eventbox4.LeaveNotifyEvent += new global::Gtk.LeaveNotifyEventHandler (this.OnEventbox4LeaveNotifyEvent);
		this.eventbox6.EnterNotifyEvent += new global::Gtk.EnterNotifyEventHandler (this.OnEventbox6EnterNotifyEvent);
		this.eventbox6.LeaveNotifyEvent += new global::Gtk.LeaveNotifyEventHandler (this.OnEventbox6LeaveNotifyEvent);
		this.eventbox6.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnEventbox6ButtonPressEvent);
	}
}
