using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class InschrijfForm : System.Web.UI.Page
    {
        DatabaseKoppeling dbKoppeling = new DatabaseKoppeling();
        Administratie administratie = new Administratie();
        List<Bezoeker> inschrijvers = new List<Bezoeker>();
        List<Plaats> tempPlaatsen = new List<Plaats>();
        Hoofdboeker hBoeker;

        protected void Page_Load(object sender, EventArgs e)
        {
            tempPlaatsen = dbKoppeling.HaalPlaatsenOp("dummy");
            VulPlaatsen();
            if(hBoeker != null)
            {
                LaatHboekerZien();
            }
        }

        protected void btnMaakBezoeker_Click(object sender, EventArgs e)
        {
            // het idee van alle inschrijvers maken is dat het pas definitief wordt op het einde van de inschrijving. Dan gaat alles pas naar de database 
            
            // als er al een hoofdboeker is gemaakt en er wordt op maakbezoeker geklikt dan wordt de oude vervangen. 
            if(hBoeker != null)
            {
                if (tbVoornaam.Text != "")
                {
                    if (tbTussenvoegsel.Text != "")
                    {
                        inschrijvers.Clear();
                        hBoeker = new Hoofdboeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);
                        GeefMessage("persoon vervangen");
                    }
                    else
                    {
                        // tussenvoegsel leeg laten
                        hBoeker = new Hoofdboeker(tbVoornaam.Text, "", tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);
                    }
                }
                else
                {
                    GeefMessage("Geen Voornaam Ingevuld");
                    return;
                }
                inschrijvers.Add(hBoeker);
                LaatHboekerZien();
            }
            else
            {
                if (tbVoornaam.Text != "")
                {
                    if (tbTussenvoegsel.Text != "")
                    {
                        hBoeker = new Hoofdboeker(tbVoornaam.Text, tbTussenvoegsel.Text, tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);
                        GeefMessage("persoon aangemaakt");
                    }
                    else
                    {
                        hBoeker = new Hoofdboeker(tbVoornaam.Text, "", tbAchternaam.Text, tbStraat.Text, tbHuisnr.Text, tbWoonplaats.Text, tbGebruikersnaam.Text, tbWachtwoord.Text, tbEmail.Text, null, tbBanknr.Text);
                    }
                }
                else
                {
                    GeefMessage("Geen Voornaam Ingevuld");
                    return;
                }
                // na alle checks pas de inschrijver toevoegen returnen als het fout gaat. 
                // in dat geval wordt de rest niet uitgevoerd.
                inschrijvers.Add(hBoeker);
                LaatHboekerZien();
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
            foreach (Plaats p in tempPlaatsen)
            {
                // als een plaats niet bezet is dan mag deze toegevoegd worden.
                if (!p.Bezet)
                {
                    ddlPlaatsen.Items.Add(p.ToString());
                }
            }
        }

        private void LaatHboekerZien()
        {
            lbPlaatsen.Items.Clear();
            lbPlaatsen.Items.Add(hBoeker.Voornaam);
        }

        // voeg plaats toe
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}