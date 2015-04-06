using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
    int i = 0;

    public MainWindow()
        : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnNewActionActivated(object sender, EventArgs e)
    {
        TextView textview1 = new TextView();
        textview1.Buffer.Text = i + " + " + i + " = " + (2 * i);
        mdichildcontainer1.AddWindow (textview1, "Sweet Window " + i);
        i++;
    }
}
