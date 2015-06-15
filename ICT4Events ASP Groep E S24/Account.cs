using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Account
    {
        //Fields
        private int id;
        private string gebruikersnaam;
        private string email;
        private string activatiehash;
        private bool geactiveerd;
        private string wachtwoord;
        private string accounttype;

        //properties

        public int Id
        {
            get { return id; }
        }
        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Activatiehash
        {
            get { return activatiehash; }
        }

        public bool Geactiveerd
        {
            get { return geactiveerd; }
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
        }

        public string Accounttype
        {
            get { return accounttype; }
        }

        //constructor
        public Account(int id, string gebruikersnaam, string email, string activatiehash, bool geactiveerd, string wachtwoord, string accounttype)
        {
            this.id = id;
            this.gebruikersnaam = gebruikersnaam;
            this.email = email;
            this.activatiehash = activatiehash;
            this.geactiveerd = geactiveerd;
            this.wachtwoord = wachtwoord;
            this.accounttype = accounttype;
        }
    }
}
