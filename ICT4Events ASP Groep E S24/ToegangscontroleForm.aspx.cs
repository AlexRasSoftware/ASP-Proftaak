using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class ToegangscontroleForm : System.Web.UI.Page
    {
        private Administratie administratie;
        private DatabaseKoppeling database;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxCheckIn.Focus();
            administratie = new Administratie();
            database = new DatabaseKoppeling();
            RefreshData();
            if (administratie.NuIngelogdeAccount == null || administratie.NuIngelogdeAccount.Gebruikersnaam != "admin")
            {
                if (administratie.NuIngelogdeAccount == null || administratie.NuIngelogdeAccount.Gebruikersnaam != "controleur")
                {
                    Response.Redirect("LoginForm.aspx");
                }
            }
        }

        private void RefreshData()
        {
            ListBoxAanwezig.Items.Clear();
            ListBoxAfwezig.Items.Clear();
            foreach (string s in database.HaalAanwezigenOp())
            {
                ListBoxAanwezig.Items.Add(s);
            }
            foreach (string s in database.HaalAfwezigenOp())
            {
                ListBoxAfwezig.Items.Add(s);
            }

            LabelAanwezigen.Text = ListBoxAanwezig.Items.Count.ToString();
            LabelAfwezig.Text = ListBoxAfwezig.Items.Count.ToString();
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

        protected void TextBoxCheckIn_TextChanged(object sender, EventArgs e)
        {
            if (database.CheckInOut(TextBoxCheckIn.Text))
            {
                GeefMessage("In/Uitchecken is gelukt.");
            }
            else
            {
                GeefMessage("In/Uitchecken is niet gelukt.");
            }
            RefreshData();
            TextBoxCheckIn.Text = "";
        }

        protected void ButtonTerug_Click(object sender, EventArgs e)
        {
            if (administratie.NuIngelogdeAccount.Gebruikersnaam == "admin")
            {
                Response.Redirect("SysteemkiezerForm.aspx");
            }
            Response.Redirect("LoginForm.aspx");
        }

        protected void ButtonCalamiteit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AanwezigenForm.aspx");
        }
    }
}