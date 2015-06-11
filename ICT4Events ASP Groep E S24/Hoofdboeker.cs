﻿using System;
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
        private List<Plaats> gekozenPlaatsen;

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

        public List<Plaats> GekozenPlaatsen
        {
            get { return gekozenPlaatsen; }
            set { gekozenPlaatsen = value; }
        }

        //Constructor        
        public Hoofdboeker(string gebruikersnaam, string wachtwoord, DateTime geboorteDatum, string rekeningNummer, string adres, string naam, string achternaam, bool aanwezig, string rfid)
            : base(gebruikersnaam, wachtwoord, geboorteDatum, naam, achternaam, aanwezig, rfid)
        {
            this.rekeningNummer = rekeningNummer;
            this.adres = adres;            
        }

        // dit wordt de nieuwe constructor van hoofdboeker dit komt door het ERD
        public Hoofdboeker(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisNr, string woonplaats, string gebruikersnaam, string wachtwoord, string email, Hoofdboeker hoofdboeker, string bankNr)
            : base(voornaam, tussenvoegsel, achternaam, straat, huisNr, woonplaats, gebruikersnaam, wachtwoord, email, hoofdboeker)
        {
            this.rekeningNummer = bankNr;
            gekozenPlaatsen = new List<Plaats>();
        }

        public bool VoegPlaatsToe(Plaats plaats)
        {
            // als de plaats al een keer is gekozen kan deze niet toegevoegd worden
            foreach(Plaats p in gekozenPlaatsen)
            {
                if(p.PlaatsNummer == plaats.PlaatsNummer)
                {
                    return false;
                }
            }
            gekozenPlaatsen.Add(plaats);
            return true;
        
        }

        public bool VerwijderPlaats(Plaats plaats)
        {
            foreach(Plaats p in gekozenPlaatsen)
            {
                if(p.PlaatsNummer == plaats.PlaatsNummer)
                {
                    gekozenPlaatsen.Remove(plaats);
                    return true;
                }
            }
            return false;
        }

        public int AantalPersonen()
        {
            int totaal = 0;
            foreach(Plaats p in gekozenPlaatsen)
            {
                totaal += p.Capaciteit;
            }
            return totaal;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
