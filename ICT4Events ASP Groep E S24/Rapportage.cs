using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Rapportage
    {
        //Fields
        private Persoon rapporteur;
        private string reden;

        //Properties
        public Persoon Rapporteur
        {
            get { return rapporteur; }
        }

        public string Reden
        {
            get { return reden; }
        }

        //Constructor
        public Rapportage(string reden, Persoon rapporteur)
        {
            this.reden = reden;
            this.rapporteur = rapporteur;
        }

        //Methode
        public string ToString()
        {
            return rapporteur.Gebruikersnaam + ": " + reden;
        }
    }
}
