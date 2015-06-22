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
        private int id;
        private int berichtId;
        //private int aantalKeerGerapporteerd;
        //private int aantalKeerBekeken;
        //private List<Reactie> reacties;
        //Fields

        
        public string Pad
        {
            get { return pad; }
        }

        public int Id
        {
            get { return id; }
        }

        public int BerichtId
        {
            get { return berichtId; }
        }

        //Constructor
        public Bestand(int id, string pad, int berichtId)
        {
            this.berichtId = berichtId;
            this.id = id;
            this.pad = pad;
            if (id > Administratie.hoogsteIdBestand)
            {
                Administratie.hoogsteIdBestand = id;
            }
            
        }

        //Methodes
        //Met deze methode kun je een reactie toevoegen
    }
}
