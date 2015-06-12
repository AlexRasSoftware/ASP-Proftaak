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
        List<string> gekozenItems = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // je gaat ieder item (iedere string) in de list van materiaalsoorten af
            // en je stopt ze stuk voor stuk in de items van ddlHuuritem
            if (Page.IsPostBack == false)
            {
                foreach (string s in databasekoppeling.VraagMateriaalSoortOp())
                {
                    ddlHuurItemType.Items.Add(s);
                }
            }
            this.Session["selectedcategorie"] = ddlHuurItemType.SelectedItem;
            this.Session["gekozenitems"] = ddlHuurItems.SelectedItem;

            ddlHuurItems.Items.Clear();
            foreach (string h in databasekoppeling.VraagHuuritemsOp(Session["selectedcategorie"].ToString()))
            {
                ddlHuurItems.Items.Add(h);
            }

            lbGekozenItems.Items.Clear();
            foreach (string g in gekozenItems)
            {
                lbGekozenItems.Items.Add(g);
            }
        }

        protected void ddlHuurItemType_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnKiesCategorie_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnKiesHuurItem_Click(object sender, EventArgs e)
        {
            gekozenItems.Add(Session["gekozenitems"].ToString());
        }
    }
}