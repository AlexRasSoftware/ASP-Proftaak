using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class DatabaseKoppeling
    {
        private OracleConnection conn;
        private OracleCommand command;
        string user = "dbi318713"; //Dit is de gebruikersnaam
        string pw = "V7brKp3nww"; //Dit is het wachtwoord
        //private static Administratie administratie = new Administratie();
        public DatabaseKoppeling()
        {
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
        }

        public bool TestDatabase()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}