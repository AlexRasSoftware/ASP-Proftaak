﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Huuritem
    {
        //Fields
        private string naam;
        private string type;
        private int prijs;
        private bool isGehuurd;
        private int volgnummer;
        private string merk;
        private string serie;
        private string categorie;

        //Methodes
        public string Naam
        {
            get { return naam; }
        }

        public string Serie
        {
            get { return serie; }
        }

        public string Merk
        {
            get { return merk; }
        }

        public string Type
        {
            get { return type; }
        }

        public int VolgNummer
        {
            get { return volgnummer; }
        }

        public int Prijs
        {
            get { return prijs; }
            set { prijs = Prijs; }
        }

        public bool IsGehuurd
        {
            get { return isGehuurd; }
            set { isGehuurd = value; }
        }

        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        //Constructor
        public Huuritem(string naam, string type, int prijs, bool isGehuurd)
        {
            this.naam = naam;
            this.type = type;
            this.prijs = prijs;
            this.isGehuurd = isGehuurd;
        }

        // nieuwste huuritem
        public Huuritem(string merk, string serie, int volgnummer, string categorie, bool isGehuurd)
        {
            this.merk = merk;
            this.serie = serie;
            this.volgnummer = volgnummer;
            this.categorie = categorie;
            this.isGehuurd = isGehuurd;
        }

        public override string ToString()
        {
            return this.categorie + " " + this.merk + " " + this.volgnummer;
        }
    }
}
