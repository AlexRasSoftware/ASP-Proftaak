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
        DatabaseKoppeling database;
        private Administratie administratie;
        Timer timer;
        int interval = 3000;
        protected void Page_Load(object sender, EventArgs e)
        {
            administratie = new Administratie();
            database = new DatabaseKoppeling();
            refreshCbEvents();
            timer = new Timer();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void refreshCbEvents()
        {
            ddlEvents.Items.Clear();
            foreach (Event ev in administratie.Events)
            {
                ddlEvents.Items.Add(ev.Naam);
            }
            ddlEvents.SelectedIndex = 0;
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