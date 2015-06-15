using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class MateriaalverhuurForm : System.Web.UI.Page
    {
        static Administratie administratie = new Administratie();

        protected void Page_Load(object sender, EventArgs e)
        {
            // je gaat ieder item (iedere string) in de list van materiaalsoorten af
            // en je stopt ze stuk voor stuk in de items van ddlHuuritem
            if(!Page.IsPostBack)
            {
                // geef alle categorieën
                ddlHuurItemType.Items.Clear();                
                foreach(string huurItem in administratie.DatabaseKoppeling.VraagMateriaalSoortOp())
                {
                    ddlHuurItemType.Items.Add(huurItem);
                }
                // en alle merken daarbij + volgnummers
                VulMerken();
            }
            
        }

        protected void ddlHuurItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
           // de merken moeten op dat moment geladen worden
            VulMerken();
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

        protected void btnKiesHuurItem_Click(object sender, EventArgs e)
        {
            // wijs het product aan de huidige huurder
            // selecteer deze huurder op zijn gebruikersnaam en voeg aan die huurder het item toe
            // zet ook het huuritem op isgehuurd

            Ververs();
        }

        protected void ddlMerken_SelectedIndexChanged(object sender, EventArgs e)
        {
            // vul alle mogelijke volgnummers die ze kunnen kiezen
            VulVolgnummers();
        }

        private void VulVolgnummers()
        {
            ddlVolgnummers.Items.Clear();
            if(ddlMerken.SelectedItem != null && ddlHuurItemType.SelectedItem != null)
            {
                foreach (Huuritem h in administratie.GeefProducten(ddlMerken.SelectedItem.ToString(), ddlHuurItemType.SelectedItem.ToString()))
                {
                    if(!h.IsGehuurd)
                    {
                        ddlVolgnummers.Items.Add(h.VolgNummer.ToString());
                    }
                }
            }
        }

        private void VulMerken()
        {
            ddlMerken.Items.Clear();
            if(ddlHuurItemType.SelectedItem != null)
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
                foreach(Huuritem h in administratie.HuidigeBezoeker.HuurMateriaal)
                {
                    lbGekozenItems.Items.Add(h.ToString());
                }
            }
        }
    }
}