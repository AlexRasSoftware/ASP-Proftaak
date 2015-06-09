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
        DatabaseKoppeling databasekoppeling = new DatabaseKoppeling();


        protected void Page_Load(object sender, EventArgs e)
        {
            // je gaat ieder item (iedere string) in de list van materiaalsoorten af
            // en je stopt ze stuk voor stuk in de items van ddlHuuritem
            foreach (string s in databasekoppeling.VraagMateriaalSoortOp())
            {
                ddlHuurItemType.Items.Add(s);
            }

            foreach (string h in databasekoppeling.VraagHuuritemsOp(Convert.ToString(ddlHuurItemType.SelectedItem)))
            {
                ddlHuurItems.Items.Add(h);
            }
        }

        protected void ddlHuurItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeefMessage("Hij doet het");
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
    }
}