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
        private Plaats selectedPlaats;
        private Event selectedEvent;
        private Administratie administartie;
        protected void Page_Load(object sender, EventArgs e)
        {
            administartie = new Administratie();
            refreshPlaatsbeheerddl();
            refreshEventBeheerddl();
        }

        protected void refreshGebruikerlb()
        {
            lbGebruikers.Items.Clear();
            foreach (Bezoeker b in administartie.Inschrijvers)
            {
                lbGebruikers.Items.Add(b.Gebruikersnaam);
            }
        }

        protected void refreshPlaatsbeheerddl()
        {
            ddlPlaNaam.Items.Clear();
            foreach (Plaats p in administartie.Plaatsen)
            {
                ddlPlaNaam.Items.Add(p.LocatieNaam);
            }
            if (ddlPlaNaam.SelectedIndex >=0)
            {
                ddlPlaNaam.SelectedIndex = 0;
            }
        }
        protected void refreshEventBeheerddl()
        {
            ddlEvents.Items.Clear();
            foreach (Event ev in administartie.Events)
            {
                ddlEvents.Items.Add(ev.Naam);
            }
            if (ddlEvents.SelectedIndex >= 0)
            {
                ddlEvents.SelectedIndex = 0;
            }

        }
        #region calendars
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
        #endregion

        protected void btnNavLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.asp");
        }

        protected void btnPlaatsAanpassen_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPlaNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Plaats p in administartie.Plaatsen)
            {
                if (p.LocatieNaam == ddlPlaNaam.SelectedValue)
                {
                    selectedPlaats = p;
                    lblPlaCap.Text = p.Capaciteit.ToString();
                    lblPlaNr.Text = p.PlaatsNummer.ToString();
                    tbPlaPrijs.Text = p.Prijs.ToString();
                    break;
                }
            }
        }

        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Event ev in administartie.Events)
            {
                if (ev.Naam==ddlEvents.SelectedValue)
                {
                    selectedEvent = ev;
                    tbEvNaam.Text = ev.Naam;
                    tbEvDatStart.Text = ev.BeginDatum.ToShortDateString();
                    tbEvDaEind.Text = ev.EindDatum.ToShortDateString();
                    tbEvLocatie.Text = ev.Plaats;
                    break;
                }
            }
        }

        protected void btnZoek_Click(object sender, EventArgs e)
        {
            lbGebruikers.Items.Clear();
            List<Bezoeker> bez=new List<Bezoeker>();
            if (tbZoekGebruiker.Text != null && tbZoekGebruiker.Text != "")
            {
                foreach (Bezoeker b in administartie.Inschrijvers)
                {
                    if (b.Gebruikersnaam.Contains(tbZoekGebruiker.Text) ||
                        tbZoekGebruiker.Text.Contains(b.Gebruikersnaam))
                    {
                        bez.Add(b);
                    }
                }
                if (bez != null)
                {
                    foreach (Bezoeker b in bez)
                    {
                        lbGebruikers.Items.Add(b.Gebruikersnaam);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript",
                            "alert(\"Er is geen gebruiker met deze naam.\");", true);
                }
            }
        }

        protected void btnGebResetList_Click(object sender, EventArgs e)
        {
            refreshGebruikerlb();
        }

        protected void btnVerwijderGebr_Click(object sender, EventArgs e)
        {
            if (lbGebruikers.SelectedValue != null)
            {
                foreach (Bezoeker b in administartie.Inschrijvers)
                {
                    if (b.Gebruikersnaam == lbGebruikers.SelectedValue)
                    {
                        administartie.Inschrijvers.Remove(b);
                    }
                }
                refreshGebruikerlb();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), 
                        "ServerControlScript",
                            "alert(\"Selecteer een gebruiker.\");", true); 
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMateriaalMerk.Items.Clear();
            ddlMateriaalVolgnr.Items.Clear();
            List<string> merken = new List<string>();
            List<int> volgnrs = new List<int>();
            tbMaMerk.Text = "";
            /*foreach (Huuritem h in administartie.HuurMateriaal)
            {
                if(h.){

                }
            }*/
        }
    }
}