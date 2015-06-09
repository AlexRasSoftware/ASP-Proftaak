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
        protected void Page_Load(object sender, EventArgs e)
        {
            Administratie administratie = new Administratie();
            //administratie.NuIngelogd = new Persoon();
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

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {

        }
    }
}