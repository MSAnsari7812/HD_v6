using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalenderWebControl : System.Web.UI.UserControl
{
    public string SelectedDate {
        get {
            return HiddenField1.Value;
        }
        set {
            try
            {
                HiddenField1.Value = value;
                if (HiddenField1.Value.Length == 0)
                    TextBox1.Text = "";
                else
                {
                    DateTime dt = Convert.ToDateTime(HiddenField1.Value);
                    TextBox1.Text = dt.ToString("dd/MM/yyyy");
                }
            }
            catch {
                TextBox1.Text = "";
            }
        }
   }

    public bool ImageButtonIcon {
        get {

            return ImageButton1.Visible;
        }
        set {

            ImageButton1.Visible = value;

        }
    }



    public string SelectedDateStr
    {
        get
        {
            return TextBox1.Text;
        }
        set
        {
            TextBox1.Text = value;
           
        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible == false)
            Calendar1.Visible = true;
        else
            Calendar1.Visible = false;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        HiddenField1.Value = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
       TextBox1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        Calendar1.Visible = false;
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date < DateTime.Now.Date)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
        //if (e.Day.IsOtherMonth)
        //{
        //    e.Day.IsSelectable = false;
        //   // e.Cell.BackColor = System.Drawing.Color.LightGray;
        //}
        //else
        //{
        //    //e.Cell.BackColor = System.Drawing.Color.LightYellow;
        //}
    }
}