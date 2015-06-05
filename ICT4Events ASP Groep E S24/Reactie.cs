using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Reactie
    {
        //Fields
        private static int reactienummer;
        private int id;
        private Persoon plaatser;
        private string inhoud;
        private bool gerapporteerd;
        private DateTime datumGeplaatst;

        //Properties
        public int Reactienummer
        {
            get { return reactienummer; }
        }

        public Persoon Plaatser
        {
            get { return plaatser; }
        }

        public string Inhoud
        {
            get { return inhoud; }
        }

        public DateTime DatumGeplaatst
        {
            get { return datumGeplaatst; }
        }

        public bool Gerapporteerd
        {
            get { return gerapporteerd; }
        }

        //Constructor
        public Reactie(Persoon plaatser, string inhoud)
        {
            gerapporteerd = false;
            datumGeplaatst = DateTime.Now;
            this.plaatser = plaatser;
            this.inhoud = inhoud;
            this.id = -1;
        }

        public Reactie(Persoon plaatser, string inhoud, int id, DateTime datumGeplaatst)
        {
            this.plaatser = plaatser;
            this.inhoud = inhoud;
            this.id = id;
            this.datumGeplaatst = datumGeplaatst;
        }

        //Methode
        public string ToString()
        {
            return plaatser.Gebruikersnaam + ": " + inhoud;
        }
    }
}
