using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Persoon
    {
        //Fields
        protected static int lastRfidCode = 0;
        protected string rfidCode;
        protected string gebruikersnaam;
        protected string naam;
        protected string achternaam;
        protected DateTime geboorteDatum;
        protected string wachtwoord;

        //Properties
        public string RfidCode
        {
            get { return rfidCode; }
        }

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
        }

        public string Naam
        {
            get { return naam; }
        }
        public string Achternaam
        {
            get { return achternaam; }
        }
        public DateTime GeboorteDatum
        {
            get { return geboorteDatum; }
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
        }

        //Constructors
        public Persoon(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
            this.geboorteDatum = geboorteDatum;
            this.naam = naam;
            this.achternaam = achternaam;
            RfidGenerator();
        }

        public Persoon(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam, string rfidCode)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
            this.geboorteDatum = geboorteDatum;
            this.naam = naam;
            this.achternaam = achternaam;
            this.rfidCode = rfidCode;
        }

        //Methodes
        //Deze methode maakt een nieuw RFID aan
        private string RfidGenerator()
        {
            lastRfidCode++;
            rfidCode = lastRfidCode.ToString();
            while (rfidCode.Length < 6)
            {
                rfidCode = "0" + rfidCode;
            }
            return rfidCode;
        }

        //Deze methode checkt of het ingevulde wachtwoord overeenkomt met het wachtwoord van de gebruiker
        public bool CheckWachtwoord(string invWachtwoord)
        {
            if (invWachtwoord == wachtwoord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return gebruikersnaam;
        }
    }
}
