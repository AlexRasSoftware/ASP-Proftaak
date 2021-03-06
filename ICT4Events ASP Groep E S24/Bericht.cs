﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Bericht : IComparable<Bericht>
    {
        //Fields
        private int id;
        private List<Like> likes;
        private string titel;
        private List<Rapportage> rapportages;
        private string tekst;
        private List<Reactie> reacties;
        private Account auteur;
        private DateTime datumGepost;
        private Bestand bestand;
        private BerichtSoort berichtSoort;
        private static DatabaseKoppeling databaseKoppeling = new DatabaseKoppeling();

        //Properties
        public List<Like> Likes
        {
            get { return likes; }
        }

        public string Titel
        {
            get { return titel; }
        }

        public List<Rapportage> Rapportages
        {
            get { return rapportages; }
        }

        public DateTime DatumGepost
        {
            get { return datumGepost; }
        }

        public string Tekst
        {
            get { return tekst; }
        }

        public List<Reactie> Reacties
        {
            get { return reacties; }
        }

        public Account Auteur
        {
            get { return auteur; }
        }


        public int BerichtSoort
        {
            get { return (int)berichtSoort; }
        }

        public int Id
        {
            get { return id; }
        }

        public Bericht(string tekst, Account auteur)
        {
            this.tekst = tekst;
            this.auteur = auteur;
            datumGepost = DateTime.Now;
            this.berichtSoort = (BerichtSoort)0;
            reacties = new List<Reactie>();
            likes = new List<Like>();
            rapportages = new List<Rapportage>();
            id = -1;
        }

        public Bericht(string tekst, Account auteur, Bestand bestand, int berichtSoort)
        {
            this.tekst = tekst;
            this.auteur = auteur;
            datumGepost = DateTime.Now;
            this.berichtSoort = (BerichtSoort)berichtSoort;
            this.bestand = bestand;
            reacties = new List<Reactie>();
            likes = new List<Like>();
            rapportages = new List<Rapportage>();
            id = -1;
        }

        //public Bericht(string tekst, Account auteur, DateTime datumGepost, int berichtSoort, int id)
        //{
        //    this.tekst = tekst;
        //    this.auteur = auteur;
        //    this.datumGepost = datumGepost;
        //    this.berichtSoort = (BerichtSoort)berichtSoort;
        //    this.id = id;
        //    //reacties
        //    //rapportages
        //    //likes
        //    reacties = databaseKoppeling.AlleReactiesVanBericht(id.ToString());
        //    rapportages = new List<Rapportage>();
        //    likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
        //}

        public Bericht(string tekst, Account auteur, DateTime datumGepost, int berichtSoort, int id)
        {
            this.tekst = tekst;
            this.auteur = auteur;
            this.datumGepost = datumGepost;
            this.berichtSoort = (BerichtSoort)berichtSoort;
            this.id = id;
            if (id > Administratie.hoogsteIdBericht)
            {
                Administratie.hoogsteIdBericht = id;
            }
            reacties = databaseKoppeling.AlleReactiesVanBericht(id);
            reacties.Sort();
            likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
        }

        public Bericht(string tekst, Account auteur, DateTime datumGepost, int berichtSoort, int id, Bestand bestand)
        {
            this.tekst = tekst;
            this.auteur = auteur;
            this.datumGepost = datumGepost;
            this.berichtSoort = (BerichtSoort)berichtSoort;
            this.id = id;
            this.bestand = bestand;
            if (id > Administratie.hoogsteIdBericht)
            {
                Administratie.hoogsteIdBericht = id;
            }
            reacties = databaseKoppeling.AlleReactiesVanBericht(id);
            reacties.Sort();
            likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
        }

        //Methodes
        public override string ToString()
        {
            return auteur.Gebruikersnaam + " (" + datumGepost + "): " + tekst;
        }

        //Met deze persoon kun je een bericht liken
        public bool BerichtLiken(Account invPersoon)
        {
            foreach (Like l in likes)
            {
                if (invPersoon == l.Liker)
                {
                    return false;
                }
            }
            bool temp = databaseKoppeling.LikeBericht(this.id, invPersoon);
            likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
            return temp;
        }

        public bool BerichtUnliken(Account invPersoon)
        {
            Like tempLike = null;
            foreach (Like l in likes)
            {
                if (invPersoon.Gebruikersnaam == l.Liker.Gebruikersnaam)
                {
                    tempLike = l;
                }
            }
            bool temp = databaseKoppeling.UnLikeBericht(tempLike.Id);
            likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
            return temp;
        }

        public bool CheckBerichtGeliked(Account invPersoon)
        {
            likes = databaseKoppeling.AlleLikesVanBericht(id.ToString());
            foreach (Like l in likes)
            {
                if (l.Liker.Gebruikersnaam == invPersoon.Gebruikersnaam)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReactieToevoegen(string tekst, Account plaatser)
        {
            bool temp = databaseKoppeling.PlaatsReactieOpBericht(plaatser, this.id, tekst);
            reacties = databaseKoppeling.AlleReactiesVanBericht(id);
            reacties.Sort();
            return temp;
        }

        //Deze methode rapporteerd berichten of posts
        public bool Rapporteren(string reden, Persoon rapporteur)
        {
            foreach (Rapportage r in rapportages)
            {
                if (r.Rapporteur == rapporteur)
                {
                    return false;
                }
            }
            rapportages.Add(new Rapportage(reden, rapporteur));
            return true;
        }

        //Deze methode sorteert berichten datum
        public int CompareTo(Bericht other)
        {
            if (datumGepost > other.DatumGepost)
            {
                return -1;
            }
            else if (datumGepost < other.DatumGepost)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool HeeftEenBestand()
        {
            if ((int)berichtSoort > 0)
            {
                return true;
            }
            return false;
        }

        public string GeefBestandPad()
        {
            return bestand.Pad;
        }

        public Reactie ReactieZoekenMetToString(string inv)
        {
            foreach (Reactie r in reacties)
            {
                if (r.ToString() == inv)
                {
                    return r;
                }
            }
            return null;
        }

        //Deze methode verwijderd een reactie
        public bool ReactieVerwijder(Reactie reactie)
        {
            bool temp = databaseKoppeling.ReactieVerwijderen(reactie.Id);
            reacties = databaseKoppeling.AlleReactiesVanBericht(id);
            reacties.Sort();
            return temp;
        }

        
    }
}
