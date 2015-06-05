using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Categorie
    {
        //Fields
        private string naam;
        private List<Bestand> bestanden;
        private List<Categorie> categorieen;

        //Properties
        public string Naam
        {
            get { return naam; }
        }

        public List<Bestand> Bestanden
        {
            get { return bestanden; }
        }

        public List<Categorie> Categorieen
        {
            get { return categorieen; }
        }

        //Constructor
        public Categorie(Bezoeker bezoeker, string naam)
        {
            this.naam = naam;
            bestanden = new List<Bestand>();
            categorieen = new List<Categorie>();
        }

        //Methodes
        //Deze methode wordt gebruikt om een bestand toe te voegen
        public bool VoegBestandToe(Bestand bestand)
        {
            bool succes = true;
            foreach (Bestand b in bestanden)
            {
                if (b.Pad == bestand.Pad)
                {
                    succes = false;
                }
            }
            if (succes)
            {
                bestanden.Add(bestand);
            }
            return succes;
        }
    }
}
