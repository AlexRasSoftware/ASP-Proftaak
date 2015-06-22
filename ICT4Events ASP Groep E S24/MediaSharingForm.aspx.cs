using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class MediaSharingForm : System.Web.UI.Page
    {
        Administratie administratie = new Administratie();
        string fromRootToPhotos = @"C:\Users\Sven\Documents\school\S2\PTS2\Github ASP.NET ICT4Events\ASP-Proftaak\ICT4Events ASP Groep E S24\foto\";

        protected void Page_Load(object sender, EventArgs e)
        {
            administratie.HaalAlleAccountsOp();
            //administratie.NuIngelogd = new Persoon();
            if (!IsPostBack)
            {
                HerlaadGegevens();
            }
            //GeefMessage(Convert.ToString(Administratie.hoogsteIdBericht));
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

        public void HerlaadGegevens()
        {
            lbPosts.Items.Clear();
            foreach (Bericht b in administratie.VraagAlleBerichtenOp())
            {
                lbPosts.Items.Add(b.ToString());
            }
        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (administratie.NuIngelogdeAccount != null && tbBericht.Text.Length > 0)
            {
                if (true)
                {
                    //if (administratie.NieuwBestandBericht(tbBericht.Text, administratie.NuIngelogdeAccount, pad))
                    //{
                    //    HerlaadGegevens();
                    //}
                    //return;
                }
                if (administratie.NieuwTekstBericht(tbBericht.Text, administratie.NuIngelogdeAccount))
                {
                    GeefMessage("Geslaagd");
                    HerlaadGegevens();
                }
                else
                {
                    GeefMessage("Niet gelukt");
                }
            }
        }

        protected void btnReageerMeer_Click(object sender, EventArgs e)
        {
            if (lbPosts.SelectedIndex >= 0)
            {
                if (administratie.GeefBerichtDoorToString(lbPosts.SelectedItem.Text) != null)
                {
                    Response.Redirect("PostForm.aspx");
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }

        protected void btUploadBestand_Click(object sender, EventArgs e)
        {
            if (fuUpload.HasFile)
            {
                if ((fuUpload.PostedFile.ContentType == "image/jpeg") ||
                    (fuUpload.PostedFile.ContentType == "image/png") ||
                    (fuUpload.PostedFile.ContentType == "image/bmp") ||
                    (fuUpload.PostedFile.ContentType == "image/gif"))
                {
                    if (Convert.ToInt64(fuUpload.PostedFile.ContentLength) < 10000000)
                    {
                        string photoFolder = Path.Combine(fromRootToPhotos, User.Identity.Name);

                        if (!Directory.Exists(photoFolder))
                            Directory.CreateDirectory(photoFolder);

                        string extension = Path.GetExtension(fuUpload.FileName);
                        string uniqueFileName = Path.ChangeExtension(fuUpload.FileName, DateTime.Now.Ticks.ToString());

                        fuUpload.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));

                        GeefMessage("<font color='Green'>Successfully uploaded " + fuUpload.FileName + "</font>");
                    }
                    else
                        GeefMessage("File must be less than 10 MB.");
                }
                else
                    GeefMessage("File must be of type jpeg, jpg, png, bmp, or gif.");
            }
            else
                GeefMessage("No file selected to upload.");
        }
    }
}