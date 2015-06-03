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
        DatabaseKoppeling dbKoppeling;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbKoppeling = new DatabaseKoppeling();
        }

        protected void btnMaakBezoeker_Click(object sender, EventArgs e)
        {
            if(dbKoppeling.TestDatabase() == true)
            {
                string message = "Connectie Gelukt";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                string message = "Allah Akbar Geen Connectie";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
    }
}