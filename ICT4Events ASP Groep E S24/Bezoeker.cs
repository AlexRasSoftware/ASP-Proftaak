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
        private Administratie administratie = new Administratie();
        private List<Plaats> gekozenPlaatsen;
        private DatabaseKoppeling dbKoppeling = new DatabaseKoppeling();


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

        public List<Plaats> GekozenPlaatsen
        {
            get { return gekozenPlaatsen; }
            set { gekozenPlaatsen = value; }
        }

        public List<Huuritem> HuurMateriaal
        {
            get { return huurMateriaal; }
            set { huurMateriaal = value; }
        }

        //Constructors
        // de nieuwe constructor voor bezoeker
        public Bezoeker(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string gebruikernaam, string wachtwoord, string email, Hoofdboeker hoofdboeker)
            :base(voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, gebruikernaam, wachtwoord, email)
        {
            this.hoofdboeker = hoofdboeker;
            huurMateriaal = new List<Huuritem>();
            gekozenPlaatsen = new List<Plaats>();
        }
        
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

        public bool VoegProductToe(Huuritem huurItem, string gebrNaam)
        {
            if(!dbKoppeling.HuurProduct(huurItem.Categorie, huurItem.Merk, huurItem.VolgNummer, gebrNaam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool VerwijderProduct(Huuritem huurItem, string gebrNaam)
        {
            if (!dbKoppeling.VerwijderProduct(huurItem.Categorie, huurItem.Merk, huurItem.VolgNummer, gebrNaam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Methods
        public bool VoegPlaatsToe(Plaats plaats, string gebruikersNaam)
        {
            // als de plaats al een keer is gekozen kan deze niet toegevoegd worden
            foreach (Plaats p in gekozenPlaatsen)
            {
                if (p.PlaatsNummer == plaats.PlaatsNummer)
                {
                    return false;
                }
            }
            // daarna moet de plek aan de database worden toegevoegd
            if (!dbKoppeling.PlekAanReservering(plaats.PlaatsNummer, gebruikersNaam))
            {
                return false;
            }
            gekozenPlaatsen.Add(plaats);
            return true;
        }

        public bool VerwijderPlaats(Plaats plaats, string gebruikersNaam)
        {
            foreach (Plaats p in gekozenPlaatsen)
            {
                if (p.PlaatsNummer == plaats.PlaatsNummer)
                {
                    if (!dbKoppeling.PlekUitReservering(plaats.PlaatsNummer, gebruikersNaam))
                    {
                        return false;
                    }
                    gekozenPlaatsen.Remove(plaats);
                    return true;
                }
            }
            // hierbij moeten de gegevens ook uit de database worden verwijderd
            return false;
        }

        public int AantalPersonen()
        {
            int totaal = 0;
            foreach (Plaats p in gekozenPlaatsen)
            {
                totaal += p.Capaciteit;
            }
            return totaal;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
