using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class AanwezigenForm : System.Web.UI.Page
    {
        private DatabaseKoppeling database;
        protected void Page_Load(object sender, EventArgs e)
        {
            database = new DatabaseKoppeling();
            VerversLijst();
        }

        private void VerversLijst()
        {
            ListBoxPersonen.Items.Clear();
            foreach (string s in database.CalamiteitenLijst())
            {
                ListBoxPersonen.Items.Add(s);
            }
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Server.MapPath("aanwezigen.txt"), String.Empty);
            using (StreamWriter personen = new StreamWriter(Server.MapPath("aanwezigen.txt"), true))
            {
                foreach (object o in ListBoxPersonen.Items)
                {
                    personen.WriteLine(o.ToString());
                }
            }
            string filePath = Server.MapPath("aanwezigen.txt");
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();

                Response.ClearHeaders();

                Response.ClearContent();

                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                Response.AddHeader("Content-Length", file.Length.ToString());

                Response.ContentType = "text/plain";

                Response.Flush();

                Response.TransmitFile(file.FullName);

                Response.End();
            }
        }

        protected void ButtonTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("ToegangscontroleForm.aspx");
        }
    }
}