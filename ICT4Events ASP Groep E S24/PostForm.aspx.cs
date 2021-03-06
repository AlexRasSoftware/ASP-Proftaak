﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class PostForm : System.Web.UI.Page
    {
        Administratie administratie = new Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HerlaadGegevens();
            }
        }

        private void HerlaadGegevens()
        {
            lbReacties.Items.Clear();
            lbGebruikersnaam.Text = administratie.TempBericht.Auteur.Gebruikersnaam;
            lbTekst.Text = administratie.TempBericht.Tekst;
            lbDatum.Text = "Geplaatst op: " + administratie.TempBericht.DatumGepost.ToString();
            lbLikes.Text = administratie.TempBericht.Likes.Count.ToString() + " Mens(en) vinden dit netjes.";
            if (administratie.TempBericht.CheckBerichtGeliked(administratie.NuIngelogdeAccount))
            {
                btnLike.Text = "Niet meer zo netjes";
            }
            else
            {
                btnLike.Text = "Netjes";
            }
            foreach (Reactie r in administratie.TempBericht.Reacties)
            {
                lbReacties.Items.Add(r.ToString());
            }
            if (administratie.TempBericht.Auteur.Gebruikersnaam == administratie.NuIngelogdeAccount.Gebruikersnaam || administratie.NuIngelogdeAccount.Gebruikersnaam == "admin")
            {
                btnVerwijderBericht.Visible = true;
                btnVerwijderReactie.Visible = true;
            }
            else
            {
                btnVerwijderBericht.Visible = false;
                btnVerwijderReactie.Visible = false;
            }
            if (administratie.TempBericht.BerichtSoort == 1)
            {
                imgBox.Visible = true;
                string pad = administratie.TempBericht.GeefBestandPad();
                imgBox.ImageUrl = pad;
            }
            else
            {
                imgBox.Visible = false;
            }
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            if (!administratie.TempBericht.CheckBerichtGeliked(administratie.NuIngelogdeAccount))
            {
                if (administratie.TempBericht.BerichtLiken(administratie.NuIngelogdeAccount))
                {
                    HerlaadGegevens();
                }
            }
            else
            {
                if (administratie.TempBericht.BerichtUnliken(administratie.NuIngelogdeAccount))
                {
                    HerlaadGegevens();
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tbReactie.Text.Length > 0 && administratie.NuIngelogdeAccount != null)
            {
                administratie.TempBericht.ReactieToevoegen(tbReactie.Text, administratie.NuIngelogdeAccount);
                tbReactie.Text = "";
                HerlaadGegevens();
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("MediaSharingForm.aspx");
        }

        protected void btnVerwijderReactie_Click(object sender, EventArgs e)
        {
            if (lbReacties.SelectedIndex >= 0)
            {
                Reactie tempReactie = administratie.TempBericht.ReactieZoekenMetToString(lbReacties.SelectedItem.Text);
                if (tempReactie != null)
                {
                    if (administratie.TempBericht.ReactieVerwijder(tempReactie))
                    {
                        HerlaadGegevens();
                    }
                }
            }
        }

        protected void btnVerwijderBericht_Click(object sender, EventArgs e)
        {
            if (administratie.VerwijderBericht(administratie.TempBericht))
            {
                Response.Redirect("MediaSharingForm.aspx");
            }
        }
    }
}