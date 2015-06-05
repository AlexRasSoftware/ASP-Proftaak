using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class ToegangscontroleForm : System.Web.UI.Page
    {
        private Administratie administratie;
        private DatabaseKoppeling database;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxCheckIn.Focus();
            administratie = new Administratie();
            database = new DatabaseKoppeling();
            //RefreshData(administratie.HuidigEvent.Naam);
        }

        protected void ButtonCheckInUit_Click(object sender, EventArgs e)
        {
            administratie.CheckInUit(TextBoxCheckIn.Text, administratie.HuidigEvent);
        }

        private void RefreshData(string eventnaam)
        {
            int aantalaanwezig = 0;
            int aantalafwezig = 0;
            ListBoxAanwezig.Items.Clear();
            ListBoxAfwezig.Items.Clear();
            foreach (Persoon p in database.HaalPersonenOp(eventnaam))
            {
                if (p is Bezoeker && !(p is Hoofdboeker))
                {
                    Bezoeker b = p as Bezoeker;
                    if (b.Aanwezig)
                    {
                        ListBoxAanwezig.Items.Add(b.ToString());
                        aantalaanwezig++;
                    }
                    else
                    {
                        ListBoxAfwezig.Items.Add(b.ToString());
                        aantalafwezig++;
                    }
                }
                LabelAanwezigen.Text = aantalaanwezig.ToString();
                LabelAfwezig.Text = aantalafwezig.ToString();
            }
        }
    }
}