using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Beheerder : Persoon
    {
        // Constructors
        // nieuwe constructor van beheerder
        public Beheerder(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string gebruikernaam, string wachtwoord, string email)
            :base(voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, gebruikernaam, wachtwoord, email)
        {

        }

        public Beheerder(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam)
        {

        }

        public Beheerder(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam, string rfid)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam, rfid)
        {

        }

        //Methodes
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
