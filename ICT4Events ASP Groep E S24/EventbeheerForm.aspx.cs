using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class EventbeheerForm : System.Web.UI.Page
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
            btnGebruikerZeker.Enabled = false;
            btnGebruikerNee.Enabled = false;
            timer.Tick += timer_Tick;
        }

        
        #region ToEvent
        

        protected void btnToEvent4_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent3_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent2_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent1_Click(object sender, EventArgs e)
        {
            ToEvent();
        }
        #endregion
        private void ToEvent()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav1').scrollIntoView();", true);
        }       
        #region ToGebruiker
        protected void btnToGebruiker1_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker2_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker3_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker4_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }
        #endregion
        private void ToGebruiker()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav2').scrollIntoView();", true);
        }
        #region ToMateriaal
        protected void btnToMateriaal1_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal2_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal3_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal4_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }
        #endregion
        private void ToMateriaal()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav3').scrollIntoView();", true);
        }       
        #region ToPlaats
        protected void Button4_Click(object sender, EventArgs e)
        {
            ToPlaats();
        }
        #endregion
        private void ToPlaats()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav4').scrollIntoView();", true);
        }
        
        

        #region Event
        private void refreshCbEvents()
        {
            ddlEvent.Items.Clear();
            foreach (Event ev in administratie.Events)
            {
                ddlEvent.Items.Add(ev.Naam);
            }
            ddlEvent.SelectedIndex = 0;
        }

        protected void btnEventPasAan_Click(object sender, EventArgs e)
        {

        }//event aanpassen

        protected void btnEventVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventPlaatsenVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventMateriaalVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventAanmaken_Click(object sender, EventArgs e)
        {

        }

        protected void btnDatabaseConnectie_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        //timer voor zeker knop
        private void timer_Tick(object sender, EventArgs e)
        {

            btnGebruikerZeker.Enabled = true;
            timer.Enabled = false;

        }

        #region Gebruiker
        protected void btnGebruikerVerwijder_Click(object sender, EventArgs e)
        {
            if (lbGebruiker.SelectedItem == null)
            {
                throw new Exception("Oeps, er is geen gebruiker geselecteerd.");
            }
            else
            {
                this.btnGebruikerNee.Enabled = true;
                this.btnGebruikerVerwijder.Enabled = false;
                this.lbGebruiker.Enabled = false;
                timer.Interval = interval;
                timer.Tick += timer_Tick;
                timer.Enabled = true;
            }
        }

        protected void btnGebruikerZeker_Click(object sender, EventArgs e)
        {
            lbGebruiker.Enabled = true;
            this.btnGebruikerNee.Enabled = false;
            this.btnGebruikerZeker.Enabled = false;
            btnGebruikerVerwijder.Enabled = true;
            string verwijderen = lbGebruiker.SelectedItem.ToString().Substring(0, lbGebruiker.SelectedItem.ToString().IndexOf(","));
            foreach (Persoon p in administratie.GeefEvent(ddlEvent.Text).Personen)
            {
                if (verwijderen == p.RfidCode)
                {
                    administratie.DeleteGebruiker(p.Gebruikersnaam);
                    administratie.GeefEvent(ddlEvent.Text).Personen.Remove(p);
                    break;
                }
            }
            updateEventTab();
        }

        protected void btnGebruikerNee_Click(object sender, EventArgs e)
        {
            this.btnGebruikerNee.Enabled = false;
            this.btnGebruikerZeker.Enabled = false;
            this.btnGebruikerVerwijder.Enabled = true;
            lbGebruiker.Enabled = true;
            timer.Enabled = false;
        }
        #endregion

        #region Materiaal
        protected void btnMateriaalVoegToe_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Plaats
        protected void btnPlaatsVoegToe_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void updateEventTab()
        {
            tbEventStartdatum.Text = administratie.GeefEvent(ddlEvent.SelectedValue).BeginDatum.ToString();
            tbEventEinddatum.Text = administratie.GeefEvent(ddlEvent.SelectedValue).EindDatum.ToString();
            tbEventNaam.Text = administratie.GeefEvent(ddlEvent.SelectedValue).Naam;
            tbEventPlaats.Text = administratie.GeefEvent(ddlEvent.SelectedValue).Plaats;
            tbEventAdres.Text = administratie.GeefEvent(ddlEvent.SelectedValue).Adres;
            ddlEventDeelnemers.Items.Clear();
            ddlEventPlaatsen.Items.Clear();
            ddlEventMateriaal.Items.Clear();
            lbGebruiker.Items.Clear();
            lbMateriaal.Items.Clear();
            ddlMateriaalSoort.SelectedIndex = 0;
            lbPlaatsHuidig.Items.Clear();
            foreach (Persoon p in administratie.GeefEvent(ddlEvent.Text).Personen)
            {
                if (p is Bezoeker)
                {
                    ddlEventDeelnemers.Items.Add(p.Naam + " " + p.Achternaam + ", " + p.RfidCode);
                    ddlEventDeelnemers.SelectedIndex = 0;
                }
            }
            foreach (Plaats p in database.HaalPlaatsenOp(administratie.HuidigEvent.Naam))
            {
                ddlEventPlaatsen.Items.Add(p.PlaatsNummer);
                ddlEventPlaatsen.SelectedIndex = 0;
            }
            foreach (Huuritem h in database.HaalHuuritemsOp(administratie.HuidigEvent.Naam))
            {
                ddlEventMateriaal.Items.Add(h.Naam + ", " + h.Type);
                ddlEventMateriaal.SelectedIndex = 0;
            }

            foreach (Persoon p in administratie.GeefEvent(ddlEvent.Text).Personen)
            {
                if (p is Bezoeker)
                {
                    Bezoeker b = p as Bezoeker;
                    string info = p.RfidCode + ", " + p.Naam + " " + p.Achternaam + ", " + p.Gebruikersnaam + ", " + administratie.GeefPlaats(b, administratie.GeefEvent(ddlEvent.Text));
                    lbGebruiker.Items.Add(info);

                }
            }
            foreach (Huuritem h in database.HaalHuuritemsOp(administratie.HuidigEvent.Naam))
            {
                string status;
                if (h.IsGehuurd)
                {
                    status = "Gehuurd";
                }
                else
                {
                    status = "Niet gehuurd";
                }

                string toevoegen = h.Naam + ", " + h.Type + ", " + status + "\n";
                lbMateriaal.Items.Add(toevoegen);
            }
            foreach (Plaats p in database.HaalPlaatsenOp(administratie.HuidigEvent.Naam))
            {
                if (p.Huurder != null)
                {
                    string info = p.PlaatsNummer + ", " + p.AantalPersonen + " personen, " + p.Huurder.Gebruikersnaam + ", € " + p.Prijs;
                    lbPlaatsHuidig.Items.Add(info);
                }
                else
                {
                    string info = p.PlaatsNummer + ", " + p.AantalPersonen + " personen, " + "Niet verhuurd, " + "€ " + p.Prijs;
                    lbPlaatsHuidig.Items.Add(info);
                }

            }
        }
    }
}