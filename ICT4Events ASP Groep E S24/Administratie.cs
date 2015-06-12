using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Administratie
    {
        // Fields
        private static List<Event> events = new List<Event>();
        private static Persoon nuIngelogd = null;
        private static Event huidigEvent = null;
        private static Bericht tempBericht = null;
        private static int countGemaakt = 0;
        private static DatabaseKoppeling databaseKoppeling = new DatabaseKoppeling();
        protected static int lastRfidCode = 0;
        private static List<Bezoeker> inschrijvers = new List<Bezoeker>();
        private static Hoofdboeker huidigeHoofdboeker = null;
        private static Bezoeker huidigeHuurder = null;
        private static Account nuIngelogdeAccount = null;
        private static List<Account> accounts = new List<Account>();
        private static List<Plaats> plaatsen = databaseKoppeling.HaalPlaatsenOp("dummy");
        private static List<Huuritem> huurMateriaal = databaseKoppeling.HaalHuuritemsOp("dummy");

        //Properties
        public List<Event> Events
        {
            get { return events; }
        }

        public List<Plaats> Plaatsen
        {
            get { return plaatsen; }
            set { plaatsen = value; }
        }

        public Account NuIngelogdeAccount
        {
            get { return nuIngelogdeAccount; }
            set { nuIngelogdeAccount = value; }
        }

        public List<Huuritem> HuurMateriaal
        {
            get { return huurMateriaal; }
            set { huurMateriaal = value; }
        }

        public Hoofdboeker HuidigeHoofdboeker
        {
            get { return huidigeHoofdboeker; }
            set { huidigeHoofdboeker = value; }
        }

        public Bezoeker HuidigeHuurder
        {
            get { return huidigeHuurder; }
            set { huidigeHuurder = value; }
        }

        public Persoon NuIngelogd
        {
            get { return nuIngelogd; }
            set { nuIngelogd = value; }
        }

        public Bericht TempBericht
        {
            get { return tempBericht; }
            set { tempBericht = value; }
        }

        public Event HuidigEvent
        {
            get { return huidigEvent; }
            set { huidigEvent = value; }
        }

        public DatabaseKoppeling DatabaseKoppeling
        {
            get { return databaseKoppeling; }
            set { databaseKoppeling = value; }
        }

        public List<Bezoeker> Inschrijvers
        {
            get { return inschrijvers; }
            set { inschrijvers = value; }
        }
        // Constructor
        public Administratie()
        {
            if (countGemaakt == 0)
            {

            }
            countGemaakt++; 
            //databaseKoppeling = new DatabaseKoppeling();
        }

        //Methodes
       

        //Deze methode zoekt naar bestaande events
        public Event GeefEvent(string eventNaam)
        {
            foreach (Event e in events)
            {
                if (e.Naam == eventNaam)
                {
                    return e;
                }
            }
            return null;
        }

        //Met deze methode worden gebruikers opgevraagd uit een event
        public Persoon CheckGebruikersInEvent(string inv)
        {
            foreach (Event e in events)
            {
                if (e.CheckGebruikersNaamRfid(inv) != null)
                {
                    return e.CheckGebruikersNaamRfid(inv);
                }
            }
            return null;

        }

        //Met deze methode kun je de plaats(en) van een bezoeker opvragen
        public string GeefPlaats(Bezoeker b, Event e)
        {
            string plaatsen = "";
            foreach (Plaats p in e.Plaatsen)
            {
                if (p.Huurder == b.Hoofdboeker || p.Huurder == b as Hoofdboeker)
                {
                    if (p.Huurder != null)
                    {
                        if (plaatsen == "")
                        {
                            plaatsen = p.PlaatsNummer;
                        }
                        else
                        {
                            plaatsen = plaatsen + ", " + p.PlaatsNummer;
                        }
                    }
                    
                }
            }

            if (plaatsen != "")
            {
                return plaatsen;
            }
            return "";
        }

        //Deze methode wordt gebruikt om een event toe te voegen
        public bool VoegEventToe(string naam, DateTime beginDatum, DateTime eindDatum, string plaats, string adres)
        {
            foreach (Event e in events)
            {
                if(naam == e.Naam)
                {
                    return false;
                }
            }
            events.Add(new Event(naam, beginDatum, eindDatum, plaats, adres));
            return true;
        }

        //Deze methode kijkt of de ingevoerde data alleen uit getallen bestaat
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
                    
            }

            return true;
        }

        public void HaalAlleEventsOp()
        {
            events.Clear();
            List<Event> tempEvent = new List<Event>();
            tempEvent = databaseKoppeling.HaalAlleEvenementen();
            foreach (Event e in tempEvent)
            {
                events.Add(e);
            }
        }

        public void VoegAlleGebruikersToeAanEvent(string eventNaam)
        {
            foreach (Event e in events)
            {
                if (eventNaam == e.Naam)
                {
                    e.Personen.Clear();
                    e.VoegPersonenToe(databaseKoppeling.HaalPersonenOp(e.Naam));
                }
            }
        }

        public void HaalAlleAccountsOp()
        {
            accounts = databaseKoppeling.HaalAlleAccountsOp();
        }

        public void VraagAlleBerichtenOp(string eventNaam)
        {
            huidigEvent.Berichten.Clear();
            huidigEvent.VoegBerichtenToe(databaseKoppeling.VraagBerichtenOpVanEvent(eventNaam));

            
        }

        public string RfidGenerator()
        {
            lastRfidCode++;
            string rfidCode = "";
            rfidCode = lastRfidCode.ToString();
            while (rfidCode.Length < 6)
            {
                rfidCode = "0" + rfidCode;
            }
            return rfidCode;
        }

        public bool DeleteGebruiker(string naam)
        {
            return databaseKoppeling.DeleteGebruiker(naam);
        }

        public Account CheckGebruikersnaam(string inv)
        {
            foreach (Account a in accounts)
            {
                if (inv == a.Gebruikersnaam)
                {
                    return a;
                }
            }
            return null;
        }


        public Plaats GeefPlaats(string plaatsNummer)
        {
            foreach (Plaats p in Plaatsen)
            {
                if (p.PlaatsNummer == plaatsNummer)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
