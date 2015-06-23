using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class SysteemkiezerForm : System.Web.UI.Page
    {
        private Administratie administratie;
        protected void Page_Load(object sender, EventArgs e)
        {
            administratie = new Administratie();
            if (administratie.NuIngelogdeAccount == null || administratie.NuIngelogdeAccount.Gebruikersnaam != "admin")
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        protected void ButtonMedia_Click(object sender, EventArgs e)
        {
            Response.Redirect("MediaSharingForm.aspx");
        }

        protected void ButtonToegang_Click(object sender, EventArgs e)
        {
            Response.Redirect("ToegangscontroleForm.aspx");
        }

        protected void ButtonBeheer_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventbeheerForm2.aspx");
        }

        protected void ButtonTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }
    }
}