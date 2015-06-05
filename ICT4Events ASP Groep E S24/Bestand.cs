using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Bestand
    {
        //private string naam;
        //private Persoon maker;
        //private int likes;
        private string pad;
        //private int aantalKeerGerapporteerd;
        //private int aantalKeerBekeken;
        //private List<Reactie> reacties;
        //Fields

        
        public string Pad
        {
            get { return pad; }
        }

        //Constructor
        public Bestand(string pad)
        {
            
            this.pad = pad;
            
        }

        //Methodes
        //Met deze methode kun je een reactie toevoegen
    }
}
