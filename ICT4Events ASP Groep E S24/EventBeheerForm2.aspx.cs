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
        private Administratie administartie;
        private DatabaseKoppeling database;
        private Event huidigEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            administartie = new Administratie();
            database = new DatabaseKoppeling();
            huidigEvent = database.HaalEvent();
            refreshPlaatsbeheerddl();
            refreshEventBeheerddl();
            refreshGebruikerlb();
            refreshMateriaalddl1();
        }

        protected void refreshGebruikerlb()
        {
            lbGebruikers.Items.Clear();
            List<string> bezoekers = new List<string>();

            foreach (string s in database.HaalAanwezigenOp())
            {
               bezoekers.Add(s);
            }

            foreach (string e in database.HaalAfwezigenOp())
            {
                bezoekers.Add(e);
            }

            foreach (string x in bezoekers)
            {
                lbGebruikers.Items.Add(x);
            }
        }

        protected void refreshPlaatsbeheerddl()
        {
            ddlPlaNaam.Items.Clear();
            foreach (Plaats p in database.HaalPlaatsenOp("Event"))
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
            tbEvNaam.Text = database.HaalEvent().Naam;
            tbEvDatStart.Text = database.HaalEvent().BeginDatum.ToShortDateString();
            tbEvDaEind.Text = database.HaalEvent().EindDatum.ToShortDateString();
            tbEvLocatie.Text = database.HaalEvent().Plaats;
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
                database.DeleteGebruiker(lbGebruikers.SelectedValue);
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
            tbMaMerk.Text = "";
            tbMaPrijs.Text = "";
            tbMaVolgnummer.Text = "";
            tbMaType.Text = ddlMateriaalType.SelectedValue;
            foreach (Huuritem h in database.HaalHuuritemsOp(database.HaalEvent().Naam))
            {
                if (h.Type == ddlMateriaalType.SelectedValue)
                {
                    ddlMateriaalMerk.Items.Add(h.Merk);
                }
            }
        }

        protected void ddlMateriaalMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMateriaalVolgnr.Items.Clear();
            tbMaMerk.Text = ddlMateriaalMerk.SelectedValue;
            tbMaPrijs.Text = "";
            tbMaVolgnummer.Text = "";
            tbMaType.Text = ddlMateriaalType.SelectedValue;
            foreach (Huuritem h in database.HaalHuuritemsOp(database.HaalEvent().Naam))
            {
                if (h.Type == ddlMateriaalType.SelectedValue && h.Merk==ddlMateriaalMerk.SelectedValue)
                {
                    ddlMateriaalVolgnr.Items.Add(h.VolgNummer.ToString());
                }
            }
        }

        protected void ddlMateriaalVolgnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMateriaalVolgnr.Items.Clear();
            tbMaMerk.Text = ddlMateriaalMerk.SelectedValue;
            tbMaPrijs.Text = "";
            tbMaVolgnummer.Text = ddlMateriaalVolgnr.SelectedValue;
            tbMaType.Text = ddlMateriaalType.SelectedValue;
            foreach (Huuritem h in database.HaalHuuritemsOp(database.HaalEvent().Naam))
            {
                if (h.Type == ddlMateriaalType.SelectedValue && 
                    h.Merk == ddlMateriaalMerk.SelectedValue &&
                    h.VolgNummer.ToString() == ddlMateriaalVolgnr.SelectedValue)
                {
                    ddlMateriaalVolgnr.Items.Add(h.VolgNummer.ToString());
                    tbMaPrijs.Text = h.Prijs.ToString();
                    break;
                }
            }
        }
        private void refreshMateriaalddl1()
        {
            List<Huuritem> huuritems = new List<Huuritem>();

            foreach (Huuritem h in database.HaalGehuurdeItems())
            {
                huuritems.Add(h);
            }

            foreach (Huuritem e in database.HaalNietGehuurdeItems())
            {
                huuritems.Add(e);
            }

            foreach (Huuritem t in huuritems)
            {
                ddlMateriaalType.Items.Add(t.Categorie);
                ddlMateriaalMerk.Items.Add(t.Merk);
                ddlMateriaalVolgnr.Items.Add(t.VolgNummer.ToString());
            }
        }

        protected void btnPasEvAan_Click(object sender, EventArgs e)
        {
            DateTime eindDatum = new DateTime();
            DateTime beginDatum = new DateTime();
            try
            {
                Event eventVoor;
                Event eventNa;
                beginDatum = Convert.ToDateTime(tbEvDatStart.Text);
                eindDatum = Convert.ToDateTime(tbEvDaEind.Text);
                if (tbEvNaam.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Vul een naam in.\");", true);
                }
                else if (tbEvLocatie.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Vul een locatie in.\");", true);
                }
                else
                {
                    string exc = "";
                    eventVoor = this.huidigEvent;
                    eventNa = new Event(tbEvNaam.Text, beginDatum, eindDatum, tbEvLocatie.Text);
                    if (!database.WijzigEvent(out exc, eventVoor, eventNa))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\""+ exc +"\");", true);
                    }
                    else
                    {
                        huidigEvent = database.HaalEvent();
                        refreshEventBeheerddl();
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript",
                            "alert(\"De data kloppen niet.\");", true); 
            }
            
        }

        protected void btnVoegMaToe_Click(object sender, EventArgs e)
        {

        }

        protected void btnPasMaAan_Click(object sender, EventArgs e)
        {
            Huuritem huVoor;
            Huuritem huNa;
            int ey = 0;
            string error="";
            bool notnumber=false;
           
            try
            {
                try
                {
                    ey = Convert.ToInt32(tbMaVolgnummer.Text);
                    notnumber = false;
                }
                catch (Exception ex)
                {
                    notnumber = true;
                    error = ex.ToString();
                }
                if (tbMaType.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Vul een Type in.\");", true);
                }
                else if (tbMaMerk.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Vul een merk in.\");", true);
                }
                else if (tbMaVolgnummer.Text == "" || notnumber)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"" + error + "\");", true);
                }
                else
                {
                    string exc = "";

                    huNa = new Huuritem(tbMaMerk.Text, tbMaType.Text, Convert.ToInt32(tbMaVolgnummer.Text), tbMaType.Text, false);
                    huNa.Prijs = Convert.ToInt32(tbMaPrijs.Text);
                    huVoor = new Huuritem(ddlMateriaalMerk.SelectedValue, ddlMateriaalType.SelectedValue, Convert.ToInt32(ddlMateriaalVolgnr.SelectedValue), tbMaType.Text, false);
                    if (!database.wijzigHuuritem(out exc, huVoor, huNa))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"" + exc + "\");", true);
                    }
                    else
                    {
                        refreshMateriaalddl1();
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript",
                            "alert(\"De data kloppen niet.\");", true);
            }
        }
        
    }
}