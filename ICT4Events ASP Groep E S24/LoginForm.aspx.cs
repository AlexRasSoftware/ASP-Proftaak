using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class LoginForm : System.Web.UI.Page
    {
        Administratie administratie = new Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            administratie.HaalAlleAccountsOp();
        }

        protected void btnInloggen_Click(object sender, EventArgs e)
        {
            if (tbGebruikersnaam.Text.Length > 0 && tbWachtwoord.Text.Length > 0)
            {
                Account tempAccount = administratie.CheckGebruikersnaam(tbGebruikersnaam.Text);
                if (tempAccount != null)
                {
                    if (tempAccount.Wachtwoord == tbWachtwoord.Text)
                    {
                        GeefMessage("Succesvol");
                        Doorverwijzen(tempAccount.Accounttype);
                        administratie.NuIngelogdeAccount = tempAccount;
                    }
                }
            }
        }

        public void Doorverwijzen(string accounttype)
        {
            if (accounttype == "gebruiker")
            {
                Response.Redirect("MediaSharingForm.aspx");
            }
            if (accounttype == "admin")
            {
                Response.Redirect("SysteemkiezerForm.aspx");
            }
            if (accounttype == "controleur")
            {
                Response.Redirect("ToegangscontroleForm.aspx");
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

        protected void tbWachtwoord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}