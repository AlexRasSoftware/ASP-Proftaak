using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Hoofdboeker : Bezoeker
    {
        //Fields
        private string rekeningNummer;
        private string adres;

        public string RekeningNummer
        {
            get { return rekeningNummer; }
            set { rekeningNummer = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        //Constructor
        public Hoofdboeker(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string rekeningNummer, string adres, string naam, string achternaam,string rfidcode, bool aanwezig)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam, rfidcode, aanwezig)
        {
            this.rekeningNummer = rekeningNummer;
            this.adres = adres;
        }

        public Hoofdboeker(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string rekeningNummer, string adres, string naam, string achternaam, bool aanwezig, string rfid)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam, aanwezig, rfid)
        {
            this.rekeningNummer = rekeningNummer;
            this.adres = adres;            
        }

        //Methods
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
