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
        //navigate
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
        private void ToEvent()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav1').scrollIntoView();", true);
        }  
        #endregion
        #region ToGebruiker
        private void ToGebruiker()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav2').scrollIntoView();", true);
        }
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
        #region ToMateriaal
        private void ToMateriaal()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav3').scrollIntoView();", true);
        }  
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
        #region ToPlaats
        private void ToPlaats()
        {
            this.ClientScript.RegisterStartupScript(this.GetType(),
                "navigate", "document.getElementById('nav4').scrollIntoView();", true);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            ToPlaats();
        }
        #endregion

        /*  ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", 
            "alert(\"[message]\");", true);
        */

        //under the hood things
        #region Event
        protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEventTab();
        }

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
            foreach (Event ev in administratie.Events)
            {
                if (ev == administratie.GeefEvent(ddlEvent.Text))
                {
                    ev.Naam = tbEventNaam.Text;

                    try{ ev.BeginDatum = Convert.ToDateTime(tbEventStartdatum.Text);}
                    catch { ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript",
                            "alert(\"Woops, dat is geen Datum.\");", true); }

                    try { ev.EindDatum = Convert.ToDateTime(tbEventEinddatum.Text); }
                    catch { ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript",
                            "alert(\"Woops, dat is geen Datum.\");", true); }
                    ev.Plaats = tbEventPlaats.Text;
                    ev.Adres = tbEventAdres.Text;
                    break;
                }
            }
            refreshCbEvents();
            updateEventTab();
        }//event aanpassen

        protected void btnEventVerwijder_Click(object sender, EventArgs e)
        {
            if (ddlEvent.Items.Count == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Dit is het laatste event!\");", true); 
                //MessageBox.Show("Dit is het laatste event!");
            }
            else
            {
                foreach (Event ev in administratie.Events)
                {
                    if (ev == administratie.GeefEvent(ddlEvent.Text))
                    {
                        if (!database.DeleteEvent(ev.Naam))
                            ScriptManager.RegisterStartupScript(this, GetType(), 
                                "ServerControlScript", "alert(\"Database opslag mislukt.\");", true); 
                            //MessageBox.Show("Database opslag mislukt;");
                        else administratie.Events.Remove(ev);
                        break;
                    }
                }
                refreshCbEvents();
                updateEventTab();
            }
        }
        
        protected void btnEventPlaatsenVerwijder_Click(object sender, EventArgs e)
        {
            foreach (Plaats p in administratie.GeefEvent(ddlEvent.Text).Plaatsen)
            {
                if (p.PlaatsNummer.ToString() == ddlEventPlaatsen.Text)
                {
                    if (!database.DeletePlaats(p.PlaatsNummer)) 
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"DatabaseKoppeling ging fout.\");", true);
                        //MessageBox.Show("DatabaseKoppeling ging fout.");
                    else administratie.GeefEvent(ddlEvent.Text).Plaatsen.Remove(p);
                    break;
                }
            }
            updateEventTab();
        }

        protected void btnEventMateriaalVerwijder_Click(object sender, EventArgs e)
        {
            if (ddlEventMateriaal.Text != "")
            {
                string teverwijderen = ddlEventMateriaal.Text.Substring(0, ddlEventMateriaal.Text.IndexOf(","));
                foreach (Huuritem h in administratie.GeefEvent(ddlEvent.Text).HuurMateriaal)
                {
                    if (h.Naam == teverwijderen)
                    {
                        if (!database.DeleteMateriaal(h.Naam)) 
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"DatabaseKoppeling ging fout.\");", true);
                            //MessageBox.Show("Database koppeling ging fout.");
                        else administratie.GeefEvent(ddlEvent.Text).HuurMateriaal.Remove(h);
                        break;
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Er is geen materiaal om te verwijderen.\");", true);
                //MessageBox.Show("Er is geen materiaal om te verwijderen.");
            }
            updateEventTab();
        }

        protected void btnEventAanmaken_Click(object sender, EventArgs e)
        {
            DateTime einddatum = Convert.ToDateTime(tbEventEinddatum);
            DateTime begindatum = Convert.ToDateTime(tbEventStartdatum);
            if (administratie.VoegEventToe(tbEventNaam.Text, begindatum, einddatum, tbEventPlaats.Text, tbEventAdres.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Event succesvol toegevoegd.\");", true);
                //MessageBox.Show("Event succesvol toegevoegd");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Er bestaat al een event met die naam.\");", true);
                //MessageBox.Show("Er bestaat al een event met die naam.");
            }
            refreshCbEvents();
            updateEventTab();
        }

        protected void btnDatabaseConnectie_Click(object sender, EventArgs e)
        {

        }
        #endregion 
        
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
            if (tbPlaatsPrijs.Text != "" && administratie.IsDigitsOnly(tbPlaatsPrijs.Text))
            {
                administratie.GeefEvent(ddlEvent.Text).Plaatsen.Add(new Plaats(Convert.ToInt32(tbPlaatsPrijs.Text), null, cbGeluidsoverlast.Checked, Convert.ToInt32(cbGeluidsoverlast.Checked), false, "0099"));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript",
            "alert(\"Voer a.u.b. een geldig getal in zonder decimalen.\");", true);
                //MessageBox.Show("Voer a.u.b. een geldig getal in zonder decimalen");
            }
            updateEventTab();
        }

        #endregion

        
        
        #region under the hood extra
        //timer voor zeker knop
        private void timer_Tick(object sender, EventArgs e)
        {
            btnGebruikerZeker.Enabled = true;
            timer.Enabled = false;
        }

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

        #endregion
    }
}