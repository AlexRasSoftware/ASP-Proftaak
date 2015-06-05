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
