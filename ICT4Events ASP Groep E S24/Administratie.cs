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
        private static List<Bericht> berichten = new List<Bericht>();
        private static int countGemaakt = 0;
        private static DatabaseKoppeling databaseKoppeling = new DatabaseKoppeling();
        protected static int lastRfidCode = 0;
        private static List<Bezoeker> inschrijvers = new List<Bezoeker>();
        private static Bezoeker huidigeBezoeker = null;
        private static Account nuIngelogdeAccount = null;
        private static List<Account> accounts = new List<Account>();
        private static List<Plaats> plaatsen = databaseKoppeling.HaalPlaatsenOp("dummy");

        public static int hoogsteIdBericht = 0;

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
            get { return AlleHuurItems(); }
            set { HuurMateriaal = value; }
        }


        public Bezoeker HuidigeBezoeker
        {
            get { return huidigeBezoeker; }
            set { huidigeBezoeker = value; }
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
        public List<Huuritem> AlleHuurItems()
        {
            List<Huuritem> alleItems = new List<Huuritem>();
            foreach(Huuritem h in databaseKoppeling.HaalGehuurdeItems())
            {
                alleItems.Add(h);
            }
            foreach(Huuritem h in databaseKoppeling.HaalNietGehuurdeItems())
            {
                alleItems.Add(h);
            }
            return alleItems;
        }       
        
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
                if (naam == e.Naam)
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

        public List<Bericht> VraagAlleBerichtenOp()
        {
            List<Bericht> tempList = databaseKoppeling.VraagBerichtenOpVanEvent();
            tempList.Sort();
            return tempList;         
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


        public Account GeefAccountDoorId(int id)
        {
            foreach (Account a in accounts)
            {
                if (id == a.Id)
                {
                    return a;
                }
            }
            return null;
        }

        public List<Huuritem> GeefAlleMerken(string categorieNaam)
        {
            List<Huuritem> merken = new List<Huuritem>();
            foreach (Huuritem h in AlleHuurItems())
            {               
                if (h.Categorie == categorieNaam)
                {
                    bool bestaat = false;
                    foreach (Huuritem hm in merken)
                    {
                        if (h.Merk == hm.Merk)
                        {
                            bestaat = true;
                        }
                    }
                    if (!bestaat)
                    {
                        merken.Add(h);
                    }
                }                
            }
            return merken;
        }

        public List<Huuritem> GeefMerken(string categorieNaam)
        {
            // geef de huuritems voor een bepaalde categorie
            // waarbij je van elk merk maar 1 hebt
            List<Huuritem> merken = new List<Huuritem>();
            foreach(Huuritem h in HuurMateriaal)
            {
                if(!h.IsGehuurd)
                {
                    if (h.Categorie == categorieNaam)
                    {
                        bool bestaat = false;
                        foreach (Huuritem hm in merken)
                        {
                            if (h.Merk == hm.Merk)
                            {
                                bestaat = true;
                            }
                        }
                        if (!bestaat)
                        {
                            merken.Add(h);
                        }
                    }         
                }                           
            }
            return merken;
        }

        public List<Huuritem> GeefAlleProducten(string merk, string categorie)
        {
            List<Huuritem> items = new List<Huuritem>();
            foreach (Huuritem h in HuurMateriaal)
            {               
                if (h.Categorie == categorie && h.Merk == merk)
                {
                    items.Add(h);
                }                
            }
            return items;
        }

        public List<Huuritem> GeefProducten(string merk, string categorie)
        {
            List<Huuritem> items = new List<Huuritem>();
            foreach(Huuritem h in HuurMateriaal)
            {
                if(!h.IsGehuurd)
                {
                    if (h.Categorie == categorie && h.Merk == merk)
                    {
                        items.Add(h);
                    }
                }
            }
            return items;
        }

        public Huuritem GeefProductExemplaar(string productString)
        {
            foreach(Huuritem h in AlleHuurItems())
            {
                if(h.ToString() == productString)
                {
                    return h;
                }
            }
            return null;
        }

        public Huuritem GeefProductExemplaar(string categorie, string merk, int volgnummer)
        {
            foreach (Huuritem h in AlleHuurItems())
            {
                if (h.Categorie == categorie && h.Merk == merk && h.VolgNummer == volgnummer)
                {
                    return h;
                }
            }
            return null;
        }


        public bool NieuwTekstBericht(string tekst, Account auteur)
        {
            return databaseKoppeling.NieuwTekstBericht(tekst, auteur);
        }

        public List<Plaats> GeefAllePlaatsen()
        {
            List<Plaats> plaatsen = new List<Plaats>();
            foreach (Plaats p in this.Plaatsen)
            {
                bool bestaat = false;
                foreach (Plaats pl in databaseKoppeling.HaalPlaatsenOp(databaseKoppeling.HaalEvent().Naam))
                {
                    if (p.LocatieNaam == pl.LocatieNaam)
                    {
                        bestaat = true;
                    }
                }
                if (!bestaat)
                {
                    plaatsen.Add(p);
                }
            }
            return plaatsen;
        }
    }
}
