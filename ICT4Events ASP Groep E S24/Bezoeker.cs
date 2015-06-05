using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Bezoeker : Persoon
    {
        //Fields
        protected bool aanwezig = false;
        private Hoofdboeker hoofdboeker;
        private List<Huuritem> huurMateriaal;

        //Properties
        public bool Aanwezig
        {
            get { return aanwezig; }
            set { aanwezig = value; }
        }

        public Hoofdboeker Hoofdboeker
        {
            get { return hoofdboeker; }
        }

        public List<Huuritem> HuurMateriaal
        {
            get { return huurMateriaal; }
            set { huurMateriaal = value; }
        }

        //Constructors
        public Bezoeker(string gebruikersnaam, string wachtwoord, DateTime geboortedatum, string naam, string achternaam, string rfidcode, bool aanwezig)
            : base(gebruikersnaam, wachtwoord, geboortedatum,naam, achternaam, rfidcode)
        {
            this.aanwezig = aanwezig;
            this.hoofdboeker = null; //de hoofdboeker is hijzelf
            huurMateriaal = new List<Huuritem>();
        }

        public Bezoeker(string gebruikersnaam, string wachtwoord, DateTime geboortedatum, string naam, string achternaam, bool aanwezig, string rfid)
            : base(gebruikersnaam, wachtwoord, geboortedatum, naam, achternaam, rfid)
        {
            this.aanwezig = aanwezig;
            this.hoofdboeker = null; //de hoofdboeker is hijzelf
            huurMateriaal = new List<Huuritem>();
        }

        public Bezoeker(string gebruikersnaam, string wachtwoord, DateTime geboortedatum, Hoofdboeker hoofdboeker, string naam, string achternaam, string rfidcode, bool aanwezig)
            : base(gebruikersnaam, wachtwoord, geboortedatum, naam, achternaam)
        {
            this.aanwezig = aanwezig;
            this.hoofdboeker = hoofdboeker;
            huurMateriaal = new List<Huuritem>();
        }

        //Methodes
        public void LeegMateriaal(Bezoeker b)
        {
            foreach(Huuritem h in huurMateriaal)
            {
                h.IsGehuurd = false;
            }
            b.huurMateriaal.Clear();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
