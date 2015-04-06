using Gtk;

public partial class MDIChildContainer
{
    Notebook notebook1;
    ScrolledWindow scrolledwindow1;
    Fixed fixed1;
    Label label1, label2, label_title;
    VBox vbox2;
    EventBox eventbox1, eventbox_titlebar, eventbox_restore, eventbox_close;
    HBox hbox1;
    Image image_restore, image_close;
    Alignment alignment5, alignment6;

    protected virtual void Build()
    {
        BorderWidth = 0;

        notebook1 = new Notebook();
        notebook1.CurrentPage = 0;
        notebook1.ShowTabs = false;
        notebook1.BorderWidth = 0;
        notebook1.ShowBorder = false;

        scrolledwindow1 = new ScrolledWindow();
        scrolledwindow1.CanFocus = true;
        scrolledwindow1.ShadowType = ShadowType.None;
        scrolledwindow1.BorderWidth = 0;

        Viewport w1 = new Viewport();
        w1.ShadowType = ShadowType.None;
        w1.BorderWidth = 0;

        fixed1 = new Fixed();
        fixed1.HasWindow = true;
        w1.Add(fixed1);
        scrolledwindow1.Add(w1);
        notebook1.Add(scrolledwindow1);

        label1 = new Label();
        notebook1.SetTabLabel(scrolledwindow1, label1);
        label1.ShowAll();

        vbox2 = new VBox();

        eventbox_titlebar = new EventBox();
        eventbox_titlebar.HeightRequest = 24;

        hbox1 = new HBox();

        label_title = new Label();
        hbox1.Add(label_title);
        Box.BoxChild w5 = ((Box.BoxChild)(hbox1[label_title]));
        w5.Position = 1;

        eventbox_restore = new EventBox();

        image_restore = new Image();
        image_restore.Pixbuf = RestoreImageNormal;
        eventbox_restore.Add(image_restore);
        hbox1.Add(eventbox_restore);
        Box.BoxChild w7 = ((Box.BoxChild)(hbox1[eventbox_restore]));
        w7.Position = 2;
        w7.Expand = false;
        w7.Fill = false;

        alignment5 = new Alignment(0.5F, 0.5F, 1F, 1F);
        alignment5.WidthRequest = 7;
        hbox1.Add(alignment5);
        Box.BoxChild w8 = ((Box.BoxChild)(hbox1[alignment5]));
        w8.Position = 3;
        w8.Expand = false;
        w8.Fill = false;

        eventbox_close = new EventBox();

        image_close = new Image();
        image_close.Pixbuf = CloseImageNormal;
        eventbox_close.Add(image_close);
        hbox1.Add(eventbox_close);
        Box.BoxChild w10 = ((Box.BoxChild)(hbox1[eventbox_close]));
        w10.Position = 4;
        w10.Expand = false;
        w10.Fill = false;

        alignment6 = new Alignment(0.5F, 0.5F, 1F, 1F);
        alignment6.WidthRequest = 3;
        hbox1.Add(alignment6);
        Box.BoxChild w11 = ((Box.BoxChild)(hbox1[alignment6]));
        w11.Position = 5;
        w11.Expand = false;
        w11.Fill = false;
        eventbox_titlebar.Add(hbox1);
        vbox2.Add(eventbox_titlebar);
        Box.BoxChild w13 = ((Box.BoxChild)(vbox2[eventbox_titlebar]));
        w13.Position = 0;
        w13.Expand = false;
        w13.Fill = false;

        eventbox1 = new EventBox();
        vbox2.Add(eventbox1);
        Box.BoxChild w14 = ((Box.BoxChild)(vbox2[eventbox1]));
        w14.Position = 1;
        notebook1.Add(vbox2);
        Notebook.NotebookChild w15 = ((Notebook.NotebookChild)(notebook1[vbox2]));
        w15.Position = 1;

        label2 = new Label();
        notebook1.SetTabLabel(vbox2, label2);
        label2.ShowAll();
        Add(notebook1);
        Hide();

        eventbox_restore.EnterNotifyEvent += Restore_Enter;
        eventbox_restore.LeaveNotifyEvent += Restore_Leave;
        eventbox_restore.ButtonPressEvent += Restore_Pressed;

        eventbox_close.EnterNotifyEvent += Close_Enter;
        eventbox_close.LeaveNotifyEvent += Close_Leave;
        eventbox_close.ButtonPressEvent += Close_Pressed;
    }
}
