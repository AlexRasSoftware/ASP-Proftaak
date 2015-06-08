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
        Administratie administratie;
        List<Persoon> inschrijvers;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbKoppeling = new DatabaseKoppeling();
            administratie = new Administratie();
            inschrijvers = new List<Persoon>();
        }

        protected void btnMaakBezoeker_Click(object sender, EventArgs e)
        {
            //inschrijvers.Add()
            foreach(Event ev in dbKoppeling.HaalAlleEvenementen())
            {
                lbPlaatsen.Items.Add(ev.Naam);
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
    }
}