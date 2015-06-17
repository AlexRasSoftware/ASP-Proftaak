﻿using System;
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
    }
}