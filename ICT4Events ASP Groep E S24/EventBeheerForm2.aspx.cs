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
        private static Administratie administartie;
        private static DatabaseKoppeling database;
        private Event huidigEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                administartie = new Administratie();
                database = new DatabaseKoppeling();
                huidigEvent = database.HaalEvent();
                refreshPlaatsbeheerddl();
                refreshEventBeheerddl();
                refreshGebruikerlb();
                //refreshMateriaalddl1();
                VulCategorieen();
            }
        }

        protected void refreshGebruikerlb()
        {
            lbGebruikers.Items.Clear();
            foreach(Account a in database.HaalAlleAccountsOp())
            {
                if(a.Geactiveerd == true)
                {
                    lbGebruikers.Items.Add(a.Gebruikersnaam);
                }              
            }
        }

        protected void refreshPlaatsbeheerddl()
        {
            List<Plaats> plaatsen = database.HaalPlaatsenOp("dummy");
            foreach (Plaats p in plaatsen)
            {
                lblPlaatsLocatie.Text = p.LocatieNaam;
                selectedPlaats = p;
                break;
            }
            foreach(Plaats p in plaatsen)
            {
                ddlPlaatsnummers.Items.Add(p.PlaatsNummer);
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
            Response.Redirect("LoginForm.aspx");
        }

        protected void btnPlaatsAanpassen_Click(object sender, EventArgs e)
        {
            string plaatsNr = "";
            int cap = 1;
            string error = "Er is een fout opgetreden. /n Vraag Siebren voor meer info.";
            
            try
            {
                bool err = false;
                plaatsNr = ddlPlaatsnummers.SelectedItem.ToString();
                foreach (char ch in tbPlaCap.Text)
                {
                    if (!Char.IsDigit(ch))
                    {
                        err = true;
                        break;
                    }
                }
                if (!err)
                {
                    cap = Convert.ToInt32(tbPlaCap.Text);

                    if (!database.PlaatsCapAanpassen(out error, plaatsNr, cap) || !err)
                    {
                        cap = Convert.ToInt32(tbPlaCap.Text);
                        ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript",
                            "alert(\"" + error + "\");", true);
                    }
                    else refreshPlaatsbeheerddl();
                }
                else refreshPlaatsbeheerddl();
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "ServerControlScript",
                        "alert(\"" + ex.ToString() + "\");", true);
            }
            
        }

        /*protected void ddlPlaNaam_SelectedIndexChanged(object sender, EventArgs e)
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
        }*/

        

        protected void btnZoek_Click(object sender, EventArgs e)
        {
            lbGebruikers.Items.Clear();
            List<Account> bez=new List<Account>();
            if (tbZoekGebruiker.Text != null && tbZoekGebruiker.Text != "")
            {
                
                foreach (Account a in database.HaalAlleAccountsOp())
                {
                    // deze manier werkt nog hoofdlettergevoelig ik
                    // denk dat dit niet heel handig is is eigenlijk een could have
                    if(a.Geactiveerd == true)
                    {
                        if (a.Gebruikersnaam.ToUpper().Contains(tbZoekGebruiker.Text.ToUpper()) ||
                            tbZoekGebruiker.Text.ToUpper().Contains(a.Gebruikersnaam.ToUpper()))
                        {
                            bez.Add(a);
                        }
                    }
                }
                if (bez != null)
                {
                    foreach (Account acc in bez)
                    {
                        lbGebruikers.Items.Add(acc.Gebruikersnaam);
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
                database.VerwijderGebruiker(lbGebruikers.SelectedItem.ToString());
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
            VulMerken();
            
        }

        protected void ddlMateriaalMerk_SelectedIndexChanged(object sender, EventArgs e)
        {
            VulVolgnummers();            
        }

        protected void ddlMateriaalVolgnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                else if (beginDatum > eindDatum) 
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Data kloppen niet. /n De begindatum mag niet later zijn dan de einddatum.\");", true);
                }
                else
                {
                    string exc = "";
                    eventVoor = this.huidigEvent;
                    eventNa = new Event(tbEvNaam.Text, beginDatum, eindDatum, tbEvLocatie.Text);
                    if (!database.WijzigEvent(out exc, eventNa))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"" + exc + "\");", true);
                    }
                    else
                    {
                        huidigEvent = database.HaalEvent();
                        refreshEventBeheerddl();
                        refreshPlaatsbeheerddl();
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
            //Huuritem huurInvoer;
            //bool notnumber = false;
            //string error = "In volgnummer staat geen nummer";
            //foreach (char ch in tbMaVolgnummer.Text)
            //{
            //    if (!Char.IsNumber(ch))
            //    {
            //        notnumber = true;
            //        break;
            //    }
            //}
            //if (tbMaType.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"Vul een Type in.\");", true);
            //}
            //else if (tbMaMerk.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"Vul een merk in.\");", true);
            //}
            //else if (tbMaVolgnummer.Text == "" || notnumber)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"" + error + "\");", true);
            //}
            //else
            //{
            //    try
            //    {
            //        string exc = "";
            //        huurInvoer = new Huuritem(tbMaMerk.Text, tbMaType.Text, Convert.ToInt32(tbMaVolgnummer.Text), tbMaType.Text, false);
            //        huurInvoer.Prijs = Convert.ToInt32(tbMaPrijs.Text);
            //        if (!database.VoegMateriaalToe(out exc, huurInvoer))
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"" + exc + "\");", true);
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"" + ex.ToString() + "\");", true);
            //    }
            //}

            if(ddlMateriaalType.SelectedItem != null && tbMaMerk.Text != "" && tbMaVolgnummer.Text != "")
            {
                if (!database.NieuwProduct(ddlMateriaalType.SelectedItem.ToString(), tbMaMerk.Text, Convert.ToInt32(tbMaVolgnummer.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Product kon niet worden toegevoegd\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Selecteer een type en vul een nieuw merk en volgnummer in.\");", true);
            }
            VulMerken();
        }

        protected void btnPasMaAan_Click(object sender, EventArgs e)
        {
            //Huuritem huVoor;
            //Huuritem huNa;
            //int ey = 0;
            //string error = "In volgnummer staat geen nummer";
            //bool notnumber=false;
           
            //try
            //{
            //    foreach (char ch in tbMaVolgnummer.Text)
            //    {
            //        if(!Char.IsNumber(ch))
            //        {
            //            notnumber = true;
            //            break;
            //        }
            //    }
            //    if (tbMaType.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //                "ServerControlScript",
            //                    "alert(\"Vul een Type in.\");", true);
            //    }
            //    else if (tbMaMerk.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //                "ServerControlScript",
            //                    "alert(\"Vul een merk in.\");", true);
            //    }
            //    else if (tbMaVolgnummer.Text == "" || notnumber)
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(),
            //                "ServerControlScript",
            //                    "alert(\"" + error + "\");", true);
            //    }
            //    else
            //    {
            //        string exc = "";

            //        huNa = new Huuritem(tbMaMerk.Text, tbMaType.Text, Convert.ToInt32(tbMaVolgnummer.Text), tbMaType.Text, false);
            //        huNa.Prijs = Convert.ToInt32(tbMaPrijs.Text);
            //        huVoor = new Huuritem(ddlMateriaalMerk.SelectedItem.ToString(), ddlMateriaalType.SelectedItem.ToString(), Convert.ToInt32(ddlMateriaalVolgnr.SelectedItem.ToString()), tbMaType.Text, false);
            //         if (!database.wijzigHuuritem(out exc, huVoor, huNa))
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(),
            //                "ServerControlScript",
            //                    "alert(\"" + exc + "\");", true);
            //        }
            //        else
            //        {
            //            refreshMateriaalddl1();
            //        }
            //    }
            //}
            //catch
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //            "ServerControlScript",
            //                "alert(\"De data kloppen niet.\");", true);
            //}

            if(ddlMateriaalType.SelectedItem != null && ddlMateriaalMerk.SelectedItem != null && tbMaPrijs.Text != "")
            {
                if (!database.UpdateMateriaalPrijs(ddlMateriaalType.SelectedItem.ToString(), ddlMateriaalMerk.SelectedItem.ToString(), Convert.ToInt32(tbMaPrijs.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                            "alert(\"Product kon niet geupdate worden\");", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                            "alert(\"Product prijs gewijzigd\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                            "alert(\"Selecteer een type en een merk en vul een nieuwe prijs in\");", true);
            }

        }

        private void VulCategorieen()
        {
            ddlMateriaalType.Items.Clear();
            foreach (string huurItem in administartie.DatabaseKoppeling.VraagMateriaalSoortOp())
            {
                ddlMateriaalType.Items.Add(huurItem);
            }
            VulMerken();
            VulVolgnummers();
        }

        private void VulMerken()
        {
            ddlMateriaalMerk.Items.Clear();
            if (ddlMateriaalType.SelectedItem != null)
            {
                foreach (string s in database.HaalAlleMerken(ddlMateriaalType.SelectedItem.ToString()))
                {
                    ddlMateriaalMerk.Items.Add(s);
                }
                VulVolgnummers();
            }
        }

        private void VulVolgnummers()
        {
            ddlMateriaalVolgnr.Items.Clear();
            if (ddlMateriaalMerk.SelectedItem != null && ddlMateriaalType.SelectedItem != null)
            {
                foreach (Huuritem h in administartie.GeefAlleProducten(ddlMateriaalMerk.SelectedItem.ToString(), ddlMateriaalType.SelectedItem.ToString()))
                {
                    ddlMateriaalVolgnr.Items.Add(h.VolgNummer.ToString());                    
                }
            }
        }

        protected void ddlPlaatsnummers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnNieuwType_Click(object sender, EventArgs e)
        {
            // insert een nieuwe categorie in de database
            if(tbMaType.Text != "")
            {
                if (!database.NieuweCategorie(tbMaType.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"categorie kon niet worden aangemaakt.\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                            "ServerControlScript",
                                "alert(\"Vul een Type in.\");", true);
            }
            VulCategorieen();
        }

        protected void btnNieuwMerk_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnNieuwMerk_Click1(object sender, EventArgs e)
        {
            if(ddlMateriaalType.SelectedItem != null && tbMaMerk.Text != "")
            {
                if (!database.NieuwMerk(ddlMateriaalType.SelectedItem.ToString(), tbMaMerk.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript",
                                    "alert(\"Merk kon niet aangemaakt worden\");", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript",
                                    "alert(\"Merk is aangemaakt\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript",
                                    "alert(\"Selecteer een type en vul een merk in\");", true);
            }
            VulMerken();
        }

        protected void btnVolgnr_Click(object sender, EventArgs e)
        {
            
            if(ddlMateriaalType.SelectedItem != null && ddlMateriaalMerk.SelectedItem != null && tbMaVolgnummer.Text != "")
            {
                if (!database.NieuwVolgnummer(ddlMateriaalType.SelectedItem.ToString(), ddlMateriaalMerk.SelectedItem.ToString(), Convert.ToInt32(tbMaVolgnummer.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                    "ServerControlScript",
                                        "alert(\"Volgnummer kon niet aangemaakt worden\");", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                    "ServerControlScript",
                                        "alert(\"Volgnummer is toegevoegd\");", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                    "ServerControlScript",
                                        "alert(\"Selecteer een materiaal en een merk en vul vervolgens een volgnummer\");", true);
            }
                
            VulVolgnummers();
        }
        
    }
}