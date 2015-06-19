using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Reactie : IComparable<Reactie>
    {
        //Fields
        private int id;
        private Account plaatser;
        private string inhoud;
        private bool gerapporteerd;
        private DateTime datumGeplaatst;

        //Properties
        public Account Plaatser
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
        public Reactie(Account plaatser, string inhoud)
        {
            gerapporteerd = false;
            datumGeplaatst = DateTime.Now;
            this.plaatser = plaatser;
            this.inhoud = inhoud;
            this.id = -1;
        }

        public Reactie(Account plaatser, string inhoud, int id, DateTime datumGeplaatst)
        {
            this.plaatser = plaatser;
            this.inhoud = inhoud;
            this.id = id;
            this.datumGeplaatst = datumGeplaatst;
            if (id > Administratie.hoogsteIdReactie)
            {
                Administratie.hoogsteIdReactie = id;
            }
        }

        //Methode
        public string ToString()
        {
            return plaatser.Gebruikersnaam + ": " + inhoud;
        }

        public int CompareTo(Reactie other)
        {
            if (datumGeplaatst > other.DatumGeplaatst)
            {
                return -1;
            }
            else if (datumGeplaatst < other.DatumGeplaatst)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
