﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    // zet de plaatsen die je huurt, alle personen, de artikelen die elke persoon huurt tijdelijk in administratie
    // als de inschrijving wordt afgerond voeg dan dmv PLSQL alles aan de database
    public partial class InschrijfForm : System.Web.UI.Page
    {
        static DatabaseKoppeling dbKoppeling;
        static Administratie administratie;
        static List<Bezoeker> inschrijvers;
        private static string gebruikersNaam;
        private static int aantalPersonen;
        private static string hoofdBoeker;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                administratie = new Administratie();
                dbKoppeling = new DatabaseKoppeling();
                inschrijvers = new List<Bezoeker>();
                aantalPersonen = -1;
                tbEmail.Text = "";
                tbWachtwoord.Text = "";
                VulPlaatsen();               
                // geef alle categorieën
                VulCategorieen();
            }
           
            // hier wordt een nieuwe reservering aangemaakt in de database

        }

        protected void btnMaakBezoeker_Click(object sender, EventArgs e)
        {
        // het idee van alle inschrijvers maken is dat het pas definitief wordt op het einde van de inschrijving. Dan gaat alles pas naar de database 
            
        // als er al een hoofdboeker is gemaakt en er wordt op maakbezoeker geklikt dan wordt de oude vervangen. 
            
            if (tbVoornaam.Text != "")
            {        
                if(tbGebruikersnaam.Text != "")
                {
                    gebruikersNaam = tbGebruikersnaam.Text;   
                    if(tbAchternaam.Text != "")
                    {
                        // maak hier nu ook een hoofdboeker aan in de database
                        string error = "";
                        if(aantalPersonen == -1)
                        {
                            if (!dbKoppeling.NieuweHoofdboeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text,
                            tbBanknr.Text, tbGebruikersnaam.Text, tbEmail.Text, null, 0, tbWachtwoord.Text, "gebruiker", out error))
                            {
                                GeefMessage(error);
                            }
                            else
                            {
                                administratie.HuidigeBezoeker = new Hoofdboeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text,
                            tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);
                                GeefMessage("Hoofdboeker Aangemaakt");
                                hoofdBoeker = tbGebruikersnaam.Text;
                            }
                        }
                        else
                        {
                            if(!dbKoppeling.NieuweBezoeker(hoofdBoeker, tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text,
                            tbBanknr.Text, tbGebruikersnaam.Text, tbEmail.Text, null, 0, tbWachtwoord.Text, "gebruiker", out error))
                            {
                                GeefMessage(error);
                            }
                            else
                            {
                                administratie.HuidigeBezoeker = new Bezoeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text,
                                    tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null);
                                GeefMessage("Bezoeker Aangemaakt");
                            }
                        }                       
                    }                 
                }
                else
                {
                    GeefMessage("Voer een gebruikersnaam in");
                }                
            }
            else
            {
                GeefMessage("Geen Voornaam Ingevuld");
                return;
            }
                          
        }

        public void GeefMessage(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        private void VulPlaatsen()
        {
            ddlPlaatsen.Items.Clear();
            foreach (Plaats p in administratie.Plaatsen)
            {
                // als een plaats niet bezet is dan mag deze toegevoegd worden.
                if(!p.Bezet)
                {
                    ddlPlaatsen.Items.Add(p.ToString());
                }
            }
        }


        // voeg plaats toe
        protected void btnVoegPlaatsToe_Click(object sender, EventArgs e)
        {
            if(administratie.HuidigeBezoeker != null)
            {
                // als de nieuwe plaats nog niet in het lijstje van plaatsen voorkomt, voeg deze dan toe
                string plaats = ddlPlaatsen.SelectedItem.ToString();
                // lees startpositie van deze plaats uit daarom ook - 10
                string plaatsNummer = plaats.Substring(10, plaats.IndexOf(",", 10) - 10);
                // kijk eerst of een plaats nog niet bestaat voeg m toe als dit niet zo is
                if (!administratie.HuidigeBezoeker.VoegPlaatsToe(administratie.GeefPlaats(plaatsNummer), gebruikersNaam)) 
                {
                    GeefMessage("Plaats is al toegevoegd");
                }
                else
                {
                    lbPlaatsen.Items.Clear();
                    foreach (Plaats p in administratie.HuidigeBezoeker.GekozenPlaatsen)
                    {
                        lbPlaatsen.Items.Add(p.ToString());
                    }
                    VulPersonen();
                    
                }                               
            }
            else
            {
                GeefMessage("Maak eerst een hoofdboeker");
            }          
        }       


        protected void btnVerwijderPlaats_Click(object sender, EventArgs e)
        {
            if(lbPlaatsen.SelectedItem != null)
            {
                // gekozen plaats mag niet null zijn. 
                string plaats = lbPlaatsen.SelectedItem.ToString();
                // lees startpositie van deze plaats uit daarom ook - 10
                string plaatsNummer = plaats.Substring(10, plaats.IndexOf(",", 10) - 10);
                if (!administratie.HuidigeBezoeker.VerwijderPlaats(administratie.GeefPlaats(plaatsNummer), gebruikersNaam))
                {
                    GeefMessage("Plaats is niet gevonden");
                }
                else
                {
                    // plaats wordt hier verwijderd dus ook uit de database
                    lbPlaatsen.Items.Clear();
                    foreach (Plaats p in administratie.HuidigeBezoeker.GekozenPlaatsen)
                    {
                        lbPlaatsen.Items.Add(p.ToString());
                    }
                    VulPersonen();
                }
            }
            else
            {
                GeefMessage("Selecteer eerst een plaats");
            }
        }

        private void VulPersonen()
        {
            // als er iets met de plaatsen veranderd dan moet deze methode worden aangeroepen
            ddlMeerderePersonen.Items.Clear();
            for(int i = 1; i<administratie.HuidigeBezoeker.AantalPersonen(); i++)
            {
                ddlMeerderePersonen.Items.Add(Convert.ToString(i));
            }
        }

        protected void btnMateriaalHuren_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.open('MateriaalVerhuurForm.aspx','_blank')");
            Response.Write("</script>");
        }

        protected void ddlHuurItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VulMerken();
        }

        private void VulCategorieen()
        {
            ddlHuurItemType.Items.Clear();
            foreach (string huurItem in administratie.DatabaseKoppeling.VraagMateriaalSoortOp())
            {
                ddlHuurItemType.Items.Add(huurItem);
            }
            VulMerken();
            VulVolgnummers();
        }

        private void VulMerken()
        {
            ddlMerken.Items.Clear();
            if (ddlHuurItemType.SelectedItem != null)
            {
                foreach (Huuritem h in administratie.GeefMerken(ddlHuurItemType.SelectedItem.ToString()))
                {
                    ddlMerken.Items.Add(h.Merk);
                }
                VulVolgnummers();
            }
        }

        private void Ververs()
        {
            lbGekozenItems.Items.Clear();
            {
                foreach (Huuritem h in administratie.HuidigeBezoeker.HuurMateriaal)
                {
                    lbGekozenItems.Items.Add(h.ToString());
                }
            }
        }

        private void VulVolgnummers()
        {
            ddlVolgnummers.Items.Clear();
            if (ddlMerken.SelectedItem != null && ddlHuurItemType.SelectedItem != null)
            {
                foreach (Huuritem h in administratie.GeefProducten(ddlMerken.SelectedItem.ToString(), ddlHuurItemType.SelectedItem.ToString()))
                {
                    if (!h.IsGehuurd)
                    {
                        ddlVolgnummers.Items.Add(h.VolgNummer.ToString());
                    }
                }
            }
        }

        protected void ddlMerken_SelectedIndexChanged(object sender, EventArgs e)
        {
            // vul alle mogelijke volgnummers die ze kunnen kiezen
            VulVolgnummers();
        }

        protected void btnKiesHuurItem_Click(object sender, EventArgs e)
        {
            string categorie = ddlHuurItemType.SelectedItem.ToString();
            string merk = ddlMerken.SelectedItem.ToString();
            int volgnummer = Convert.ToInt32(ddlVolgnummers.SelectedItem.ToString());
            Huuritem h = administratie.GeefProductExemplaar(categorie, merk, volgnummer);
            if(administratie.HuidigeBezoeker != null)
            {
                if (!administratie.HuidigeBezoeker.VoegProductToe(h, gebruikersNaam))
                {
                    GeefMessage("huuritem is al gehuurd");
                }
                else
                {
                    lbGekozenItems.Items.Add(h.ToString());
                }
            }
            else
            {
                GeefMessage("Maak eerst een bezoeker aan");
            }

        }

        protected void btnVerwijderItem_Click(object sender, EventArgs e)
        {
            if(lbGekozenItems.SelectedItem != null)
            {
                Huuritem h = administratie.GeefProductExemplaar(lbGekozenItems.SelectedItem.ToString());
                if (administratie.HuidigeBezoeker != null)
                {
                    if (!administratie.HuidigeBezoeker.VerwijderProduct(h, gebruikersNaam))
                    {
                        GeefMessage("verwijderen niet gelukt");
                    }
                    else
                    {
                        lbGekozenItems.Items.Remove(h.ToString());
                    }
                }
            }           
        }

        protected void btnBevestig_Click(object sender, EventArgs e)
        {
            if (aantalPersonen == -1)
            {
                if (lbPlaatsen.Items.Count != 0)
                {
                    if (!chbMeederePersonen.Checked)
                    {
                        // ga terug naar het inlogform
                        Response.Redirect("LoginForm.aspx");
                    }
                    else
                    {
                        // alle vakjes die de bezoeker nodig heeft moeten disabled worden
                        aantalPersonen = Convert.ToInt32(ddlMeerderePersonen.SelectedItem.ToString());
                        aantalPersonen--;
                        DisableControls();
                    }
                }
                else
                {
                    GeefMessage("Je moet wel een plek selecteren");
                }
            }
            else
            {
                if(aantalPersonen == 0)
                {
                    Response.Redirect("LoginForm.aspx");
                }
                else
                {
                    GeefMessage(Convert.ToString(aantalPersonen));
                    aantalPersonen--;
                    DisableControls();
                }               
            }
        } 
        
        private void DisableControls()
        {            
            tbVoornaam.Text = "";
            tbTussenvoegsel.Text = "";
            tbAchternaam.Text = "";
            tbStraat.Text = "";
            tbHuisnr.Text = "";
            tbWoonplaats.Text = "";
            tbBanknr.Text = "";
            tbGebruikersnaam.Text = "";
            tbEmail.Text = "";
            tbWachtwoord.Text = "";
            lbGekozenItems.Items.Clear();

            tbBanknr.Enabled = false;
            ddlPlaatsen.Enabled = false;
            lbGekozenItems.Enabled = false;
            btnVoegPlaatsToe.Enabled = false;
            btnVerwijderPlaats.Enabled = false;
            chbMeederePersonen.Enabled = false;
            ddlMeerderePersonen.Enabled = false;

            administratie.HuidigeBezoeker = null;
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
    }
}