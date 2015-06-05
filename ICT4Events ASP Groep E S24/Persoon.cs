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
        //dit zijn nog de oude fields
        protected string rfidCode;
        protected string naam;
        protected DateTime geboorteDatum;

        protected string gebruikersnaam;
        protected string voornaam;
        protected string achternaam;
        protected string wachtwoord;
        protected string tussenVoegsel;
        protected string straat;
        protected string huisNr;
        protected string woonplaats;

        //Properties
        public string RfidCode
        {
            get { return rfidCode; }
        }

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
        }

        public string Voornaam
        {
            get { return voornaam; }
        }
        public string Achternaam
        {
            get { return achternaam; }
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
        }

        public string Naam
        {
            get { return naam; }
        }

        public DateTime GeboorteDatum
        {
            get { return geboorteDatum; }
        }

        //Constructors
        // dit wordt de nieuwe constructor van persoon
        public Persoon(string voornaam, string tussenVoegsel, string achternaam, string straat, string huisNr, string woonplaats, string gebruikersnaam, string wachtwoord, string email)
        {
            this.voornaam = voornaam;
            this.tussenVoegsel = tussenVoegsel;
            this.achternaam = achternaam;
            this.straat = straat;
            this.huisNr = huisNr;
            this.woonplaats = woonplaats;
        }
        
        public Persoon(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
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
