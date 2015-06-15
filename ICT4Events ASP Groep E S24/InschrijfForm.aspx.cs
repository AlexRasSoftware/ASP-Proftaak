using System;
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
        DatabaseKoppeling dbKoppeling = new DatabaseKoppeling();
        Administratie administratie = new Administratie();
        List<Bezoeker> inschrijvers = new List<Bezoeker>();

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                VulPlaatsen();
                
                // geef alle categorieën
                ddlHuurItemType.Items.Clear();
                foreach (string huurItem in administratie.DatabaseKoppeling.VraagMateriaalSoortOp())
                {
                    ddlHuurItemType.Items.Add(huurItem);
                }
            }
           
            // hier wordt een nieuwe reservering aangemaakt in de database

        }

        protected void btnMaakBezoeker_Click(object sender, EventArgs e)
        {
        // het idee van alle inschrijvers maken is dat het pas definitief wordt op het einde van de inschrijving. Dan gaat alles pas naar de database 
            
        // als er al een hoofdboeker is gemaakt en er wordt op maakbezoeker geklikt dan wordt de oude vervangen. 
            if (tbVoornaam.Text != "")
            {
                if (tbTussenvoegsel.Text != "")
                {
                    // er is een nieuwe hoofdboeker 
                    administratie.HuidigeHoofdboeker = new Hoofdboeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);                      
                }
                else
                {
                    // tussenvoegsel leeg laten
                    administratie.HuidigeHoofdboeker = new Hoofdboeker(tbVoornaam.Text, "", tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);                        
                }
                // maak hier nu ook een hoofdboeker aan in de database
                string error = "";
                if(!dbKoppeling.NieuweBezoeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text,
                    tbBanknr.Text, tbGebruikersnaam.Text, tbEmail.Text, null, 0, tbWachtwoord.Text, "gebruiker", out error))
                {
                    GeefMessage(error);
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
            if(administratie.HuidigeHoofdboeker != null)
            {
                // als de nieuwe plaats nog niet in het lijstje van plaatsen voorkomt, voeg deze dan toe
                string plaats = ddlPlaatsen.SelectedItem.ToString();
                // lees startpositie van deze plaats uit daarom ook - 10
                string plaatsNummer = plaats.Substring(10, plaats.IndexOf(",", 10) - 10);

                if (!administratie.HuidigeHoofdboeker.VoegPlaatsToe(administratie.GeefPlaats(plaatsNummer)))
                {
                    GeefMessage("Plaats is al toegevoegd");
                }
                else
                {
                    lbPlaatsen.Items.Clear();
                    foreach (Plaats p in administratie.HuidigeHoofdboeker.GekozenPlaatsen)
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
                if (!administratie.HuidigeHoofdboeker.VerwijderPlaats(administratie.GeefPlaats(plaatsNummer)))
                {
                    GeefMessage("Plaats is niet gevonden");
                }
                else
                {
                    // plaats wordt hier verwijderd
                    lbPlaatsen.Items.Clear();
                    foreach (Plaats p in administratie.HuidigeHoofdboeker.GekozenPlaatsen)
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
            for(int i = 1; i<administratie.HuidigeHoofdboeker.AantalPersonen(); i++)
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
                foreach (Huuritem h in administratie.HuidigeHuurder.HuurMateriaal)
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
            foreach(Huuritem h in administratie.HuurMateriaal)
            {
                if (ddlHuurItemType.SelectedItem.ToString() == h.Categorie)
                {
                    if (ddlMerken.SelectedItem.ToString() == h.Merk)
                    {
                        if (Convert.ToInt32(ddlVolgnummers.SelectedItem.ToString()) == h.VolgNummer)
                        {
                            if(!h.IsGehuurd)
                            {
                                lbGekozenItems.Items.Add(h.ToString());
                                h.IsGehuurd = true;
                                // koppel hier het huuritem aan de bezoeker
                            }
                            else
                            {
                                GeefMessage("item is al gehuurd");
                            }
                        }
                    }
                }                
            }
        }

        protected void btnVerwijderItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnBevestig_Click(object sender, EventArgs e)
        {

        }

            
    }
}