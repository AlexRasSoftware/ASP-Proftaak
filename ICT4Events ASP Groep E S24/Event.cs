using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Event
    {
        //Fields
        private string naam;
        private DateTime beginDatum;
        private DateTime eindDatum;
        private string plaats;
        private string adres;
        private List<Persoon> personen;
        private List<Plaats> plaatsen;
        private List<Huuritem> huurMateriaal;
        private List<Reservering> reserveringen;
        private List<Categorie> categorieen;
        private List<Bericht> berichten;
        private static DatabaseKoppeling databaseKoppeling = new DatabaseKoppeling();

        //Properties
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public DateTime BeginDatum
        {
            get { return beginDatum; }
            set { beginDatum = value; }
        }

        public DateTime EindDatum
        {
            get { return eindDatum; }
            set { eindDatum = value; }
        }

        public string Plaats
        {
            get { return plaats; }
            set { plaats = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public List<Persoon> Personen
        {
            get { return personen; }
        }

        public List<Plaats> Plaatsen
        {
            get { return plaatsen; }
        }

        public List<Huuritem> HuurMateriaal
        {
            get { return huurMateriaal; }
        }

        public List<Reservering> Reserveringen
        {
            get { return reserveringen; }
        }

        public List<Categorie> Categorieen
        {
            get { return categorieen; }
        }

        public List<Bericht> Berichten
        {
            get { return berichten; }
        }

        public DatabaseKoppeling DatabaseKoppeling
        {
            get { return databaseKoppeling; }
        }

        //Constructor
        public Event(string naam, DateTime datumStart, DateTime datumEinde, string plaats)
        {
            this.naam = naam;
            this.beginDatum = datumStart;
            this.eindDatum = datumEinde;
            this.plaats = plaats;
        }
        
        public Event(string naam, DateTime beginDatum, DateTime eindDatum, string plaats, string adres)
        {
            this.naam = naam;
            this.beginDatum = beginDatum;
            this.eindDatum = eindDatum;
            this.plaats = plaats;
            this.adres = adres;
            personen = new List<Persoon>();
            TestDataPersonen();
            plaatsen = new List<Plaats>();
            TestDataPlaatsen();
            huurMateriaal = new List<Huuritem>();
            TestDataHuurmateriaal();
            reserveringen = new List<Reservering>();
            categorieen = new List<Categorie>();
            berichten = new List<Bericht>();
        }

        //Methodes
        private void TestDataPersonen()
        {       
            ////Beheerder aanmaken
            //personen.Add(new Beheerder("Admin", "Admin", new DateTime(1996, 9, 27),"Ad","Min"));
            //personen.Add(new Beheerder("Frank", "Haver", new DateTime(1996, 2, 15), "Frank", "Haver"));

            ////Hoofdboeker aanmaken
            //personen.Add(new Hoofdboeker("Peter", "Schepers", new DateTime(1980, 5, 20), "162784929","Peter","Schepers"));
            //personen.Add(new Hoofdboeker("Sven", "Henderickx", new DateTime(1996, 5, 11), "123456789", "Sven", "Henderickx"));
            
            ////Bezoekers aanmaken
            //personen.Add(new Bezoeker("Henny", "Hanssen", new DateTime(1996, 12, 15), GeefHoofdboeker("Peter"),"Henny","Hanssen"));
            //personen.Add(new Bezoeker("Anja", "Haas", new DateTime(1998, 3, 18), GeefHoofdboeker("Peter"),"Anja","Haas"));
            //personen.Add(new Bezoeker("Siebren", "Weertman", new DateTime(1995, 4, 8), GeefHoofdboeker("Sven"), "Siebren", "Weertman"));

            ////Controleur aanmaken
            //personen.Add(new Controleur("Alex", "Ras", new DateTime(1995, 5, 22),"Alex","Ras"));
            //personen.Add(new Controleur("Kevin", "Kopp", new DateTime(1996, 6, 14), "Kevin", "Kopp"));
        }

        private void TestDataPlaatsen()
        {
            

        }

        private void TestDataHuurmateriaal()
        {
            //Huurmateriaal aanmaken
            huurMateriaal.Add(new Huuritem("Canon 1024M", "Fotocamera", 50, false));
            huurMateriaal.Add(new Huuritem("Sony 800D", "Fotocamera", 50, false));
            huurMateriaal.Add(new Huuritem("LG B120", "Videocamera", 60, false));
            huurMateriaal.Add(new Huuritem("Samsung C800", "Videocamera", 60, false));

        }

        // Hoofdboeker kan worden opgezocht via gebuikersnaam
        private Hoofdboeker GeefHoofdboeker(string gebruikersNaam)
        {
            foreach (Persoon p in personen)
            {
                if (p is Hoofdboeker && p.Gebruikersnaam == gebruikersNaam)
                {
                    Hoofdboeker h = p as Hoofdboeker;
                    return h;
                }
            }
            return null;
        }

        //Hier wordt een plaats opgevragen
        public Plaats GeefPlaats(string plaatsnummer)
        {
            foreach (Plaats p in databaseKoppeling.HaalPlaatsenOp(naam))
            {
                if (p.PlaatsNummer == plaatsnummer)
                {
                    return p;
                }
            }
            return null;
        }

        //Deze methode checkt of het RFID van een persoon overeenkomt met zijn naam
        public Persoon CheckGebruikersNaamRfid(string inv)
        {
            foreach (Persoon p in personen)
            {
                if (inv == p.Gebruikersnaam || inv == p.RfidCode)
                {
                    return p;
                }
            }
            return null;
        }

        //Deze methode retourneert het gezochte huuritem als het bestaat
        public Huuritem GeefHuuritem(string itemNaam)
        {
            foreach (Huuritem h in databaseKoppeling.HaalHuuritemsOp(naam))
            {
                if (h.Naam == itemNaam)
                {
                    return h;
                }
            }
            return null;
        }

        //Met deze method wordt een persoon toegevoegd
        public bool VoegPersoonToe(Persoon persoon)
        {
            foreach (Persoon p in personen)
            {
                if (p.Gebruikersnaam == persoon.Gebruikersnaam)
                {
                    return false;
                }
            }
            personen.Add(persoon);
            return true;
        }

        public void VoegPersonenToe(List<Persoon> personen)
        {
            foreach (Persoon p in personen)
            {
                this.personen.Add(p);
            }
        }

        public void VoegBerichtenToe(List<Bericht> berichten)
        {
            foreach (Bericht b in berichten)
            {
                this.berichten.Add(b);
            }
        }

        // kijken of de gebruikersnaam van een persoon al in de lijst van personen zit
        // functie heeft zelfde functie als voegPersoonToe alleen voegt deze methode
        // de persoon niet toe.
        public bool CheckPersoon(Persoon persoon)
        {
            // Frank: de list van personen in event bestaat niet meer dus deze moet uit de databasekoppeling
            
            foreach (Persoon p in databaseKoppeling.HaalPersonenOp("SME"))
            {
                if (p.Gebruikersnaam == persoon.Gebruikersnaam)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return naam + ", " + beginDatum.Day + adres;
        }

        //Met deze methode worden berichten gezocht
        public List<Bericht> BerichtenZoeken(string inv)
        {
            inv = inv.ToLower();
            List<Bericht> tempList = new List<Bericht>();
            if (inv.Length > 0)
            {
                foreach (Bericht b in Berichten)
                {
                    if (b.Tekst.ToLower().IndexOf(inv) >= 0 || b.Auteur.Gebruikersnaam.ToLower().IndexOf(inv) >= 0)
                    {
                        tempList.Add(b);
                    }
                }
            }
            return tempList;
        }

        //Deze methode gebruikt de ToString methode op een bericht
        public Bericht GeefBerichtDoorToString(string inv)
        {
            foreach (Bericht b in berichten)
            {
                if (b.ToString() == inv)
                {
                    return b;
                }
            }
            return null;
        }

        //Deze mehtode verwijderd een bericht
        public void VerwijderBericht(Bericht bericht)
        {
            foreach (Bericht b in berichten)
            {
                if (b == bericht)
                {
                    berichten.Remove(bericht);
                    return;
                }
            }
        }

        //Deze methode vraagt een list op van alle gerapporteerde berichten
        public List<Bericht> AlleGerapporteerdeBerichten()
        {
            List<Bericht> tempList = new List<Bericht>();
            foreach (Bericht b in berichten)
            {
                if (b.Rapportages.Count > 0)
                {
                    tempList.Add(b);
                }
            }
            return tempList;
        }

        public List<Bericht> GeefBerichtenVanSoort(int berichtSoort)
        {
            if (berichtSoort == 0)
            {
                return berichten;
            }
            else if (berichtSoort == 1)
            {
                List<Bericht> tempList = new List<Bericht>();
                foreach (Bericht b in berichten)
                {
                    if (b.BerichtSoort == berichtSoort - 1)
                    {
                        tempList.Add(b);
                    }
                }
                return tempList;
            }
            else if (berichtSoort == 2)
            {
                List<Bericht> tempList = new List<Bericht>();
                foreach (Bericht b in berichten)
                {
                    if (b.BerichtSoort == berichtSoort - 1)
                    {
                        tempList.Add(b);
                    }
                }
                return tempList;
            }
            return null;
        }

        public void PlaatsVoorReservering(int reserveringID, List<string> geselecteerdePlaatsen)
        {
            foreach(string s in geselecteerdePlaatsen)
            {
                databaseKoppeling.WijsPlaatsAanReservering(reserveringID, s);
            }
        }

        public void ItemAanReservering(int reserveringID, List<string> gekozenItems)
        {
            foreach(string s in gekozenItems)
            {
                databaseKoppeling.WijsItemAanReservering(reserveringID, s);
            }
        }
    }
}
