using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events_ASP_Groep_E_S24
{
    public partial class EventbeheerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        #region ToEvent
        

        protected void btnToEvent4_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent3_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent2_Click(object sender, EventArgs e)
        {
            ToEvent();
        }

        protected void btnToEvent1_Click(object sender, EventArgs e)
        {
            ToEvent();
        }
        #endregion
        private void ToEvent()
        {

        }       
        #region ToGebruiker
        protected void btnToGebruiker1_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker2_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker3_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }

        protected void btnToGebruiker4_Click(object sender, EventArgs e)
        {
            ToGebruiker();
        }
        #endregion
        private void ToGebruiker()
        {

        }
        #region ToMateriaal
        protected void btnToMateriaal1_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal2_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal3_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }

        protected void btnToMateriaal4_Click(object sender, EventArgs e)
        {
            ToMateriaal();
        }
        #endregion
        private void ToMateriaal()
        {

        }       
        #region ToPlaats
        protected void Button4_Click(object sender, EventArgs e)
        {
            ToPlaats();
        }
        #endregion
        private void ToPlaats()
        {

        }
        
        #region Event
        protected void ddlEventPasAan_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventPlaatsenVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventMateriaalVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnEventAanmaken_Click(object sender, EventArgs e)
        {

        }

        protected void btnDatabaseConnectie_Click(object sender, EventArgs e)
        {

        }
        #endregion 

        #region Gebruiker
        protected void btnGebruikerVerwijder_Click(object sender, EventArgs e)
        {

        }

        protected void btnGebruikerZeker_Click(object sender, EventArgs e)
        {

        }

        protected void btnGebruikerNee_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Materiaal
        protected void btnMateriaalVoegToe_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Plaats
        protected void btnPlaatsVoegToe_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}