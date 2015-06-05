using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    class Controleur : Persoon
    {
        //Constructor
        // de nieuwe constructor voor controleur
        public Controleur(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string gebruikernaam, string wachtwoord, string email)
            :base(voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, gebruikernaam, wachtwoord, email)
        {

        }
        
        public Controleur(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam)
        {

        }

        public Controleur(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string naam, string achternaam, string rfid)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam, rfid)
        {

        }

        //Methode
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
