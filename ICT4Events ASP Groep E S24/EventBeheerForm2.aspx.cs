using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class EventBeheerForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imbtnCalendarStart_Click(object sender, ImageClickEventArgs e)
        {
            if (calStart.Visible) calStart.Visible = false;
            else calStart.Visible = true;
        }

        protected void imbtnCalendarEind_Click(object sender, ImageClickEventArgs e)
        {
            if (calEind.Visible) calEind.Visible = false;
            else calEind.Visible = true;
        }

        protected void calStart_SelectionChanged(object sender, EventArgs e)
        {
            tbEvDatStart.Text = calStart.SelectedDate.ToShortDateString();
            calStart.Visible = false;
        }

        protected void calEind_SelectionChanged(object sender, EventArgs e)
        {
            tbEvDaEind.Text = calEind.SelectedDate.ToShortDateString();
            calEind.Visible = false;
        }
    }
}