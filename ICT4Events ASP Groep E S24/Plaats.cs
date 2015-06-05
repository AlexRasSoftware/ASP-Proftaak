using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Plaats
    {
        // Fields
        private static int plaatsNummerTeller = 0;
        private string plaatsNummer;
        private int prijs;
        private Hoofdboeker huurder;
        private bool geluidsOverlast;
        private int aantalPersonen;
        private bool bezet;

        //Properties
        public string PlaatsNummer
        {
            get { return plaatsNummer; }
        }

        public int AantalPersonen
        {
            get { return aantalPersonen; }
        }

        public bool Bezet // heet verhuurd in het erd
        {
            get { return bezet; }
            set { bezet = value; }
        }

        public Hoofdboeker Huurder
        {
            get { return huurder; }
        }

        public int Prijs
        {
            get { return prijs; }
        }

        //Constructor
        // huurder wordt hier even niet meer gebruikt dus een huurder van een plaats kun
        // je dus ook niet meer opvragen
        public Plaats(int prijs, Hoofdboeker huurder, bool geluidsOverlast, int aantalPersonen, bool bezet, string plaatsnummer)
        {
            this.prijs = prijs;
            this.huurder = huurder;
            this.geluidsOverlast = geluidsOverlast;
            this.aantalPersonen = aantalPersonen;
            this.plaatsNummer = plaatsnummer;
            this.bezet = bezet;
        }

        //Methodes
        public override string ToString()
        {
            string geluidsOV = "nee";
            if (this.geluidsOverlast) geluidsOV = "ja";
            return "PlaatsNr: " + this.plaatsNummer + ", " + "Aantal Personen " + this.aantalPersonen + ", geluidsoverlast: " + geluidsOV + ", € " + prijs.ToString();
        }

        //Deze methode genereert een plaatsnummer wordt niet meer gebruikt
        private string PlaatsNummerGenerator()
        {
            // 1 ophogen bij een nieuwe plaats
            plaatsNummerTeller++;
            plaatsNummer = plaatsNummerTeller.ToString();
            while (plaatsNummer.Length < 4)
            {
                plaatsNummer = "0" + plaatsNummer;
            }
            return plaatsNummer;
        }
    }
}
