using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class MediaSharingForm : System.Web.UI.Page
    {
        Administratie administratie = new Administratie();

        protected void Page_Load(object sender, EventArgs e)
        {
            administratie.HaalAlleAccountsOp();
            //administratie.NuIngelogd = new Persoon();
            if (!IsPostBack)
            {
                HerlaadGegevens();
                rbKiesFilter.SelectedIndex = 0;
            }
            //GeefMessage(Convert.ToString(Administratie.hoogsteIdBericht));
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {

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

        public void HerlaadGegevens()
        {
            lbPosts.Items.Clear();
            bool bestandBericht = false;
            string pad = "";
            foreach (Bericht b in administratie.VraagAlleBerichtenOp())
            {
                lbPosts.Items.Add(b.ToString());
            }
        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (administratie.NuIngelogdeAccount != null && tbBericht.Text.Length > 0)
            {
                string pad = "";
                bool bestandBericht = false;
                if (fuUpload.HasFile)
                {
                    pad = @"~/foto/" + fuUpload.FileName;
                    bestandBericht = true;
                }
                if (bestandBericht)
                {
                    if (administratie.NieuwBestandBericht(tbBericht.Text, administratie.NuIngelogdeAccount, pad))
                    {
                        pad = "";
                        bestandBericht = false;
                        HerlaadGegevens();
                        tbBericht.Text = "";
                    }
                    return;
                }
                if (administratie.NieuwTekstBericht(tbBericht.Text, administratie.NuIngelogdeAccount))
                {
                    GeefMessage("Geslaagd");
                    HerlaadGegevens();
                }
                else
                {
                    GeefMessage("Niet gelukt");
                }
            }
        }

        protected void btnReageerMeer_Click(object sender, EventArgs e)
        {
            if (lbPosts.SelectedIndex >= 0)
            {
                if (administratie.GeefBerichtDoorToString(lbPosts.SelectedItem.Text) != null)
                {
                    Response.Redirect("PostForm.aspx");
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }

        protected void btUploadBestand_Click(object sender, EventArgs e)
        {
            
        }

        protected void tbZoeken_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (tbZoeken.Text.Length > 0 && administratie.BerichtenZoeken(tbZoeken.Text) != null)
            {
                lbPosts.Items.Clear();
                foreach (Bericht b in administratie.BerichtenZoeken(tbZoeken.Text))
                {
                    lbPosts.Items.Add(b.ToString());
                }
            }
            else
            {
                HerlaadGegevens();
            }
        }
    }
}