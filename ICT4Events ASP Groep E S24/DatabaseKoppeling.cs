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
        Administratie administratie;
        private OracleConnection conn;
        private OracleCommand command;
        string user = "dbi318713"; //Dit is de gebruikersnaam
        string pw = "V7brKp3nww"; //Dit is het wachtwoord
        //private static Administratie administratie = new Administratie();
        public DatabaseKoppeling()
        {
            administratie = new Administratie();
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

        // in het tweede gedeelte doen we niets met eventnaam
        public List<Plaats> HaalPlaatsenOp(string eventnaam)
        {
            List<Plaats> plaatsen = new List<Plaats>();
            try
            {
                conn.Open();
                // query van alle plaatsen met de eventueel bijbehorende
                // hoofdboekers
                string query = "SELECT p.nummer, p.capaciteit, p.gehuurd, l.naam FROM PLEK p, LOCATIE l WHERE l.ID = p.locatie_id";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                // dataReader gaat record voor record omlaag totdat 
                // er niets meer is.
                while (dataReader.Read())
                {
                    // getal tussen haakjes is de gewenste kolom :D
                    string plaatsnummer = Convert.ToString(dataReader["NUMMER"]);
                    int capaciteit = Convert.ToInt32(dataReader["CAPACITEIT"]);
                    int gehuurd = Convert.ToInt32(dataReader["GEHUURD"]);
                    string lnaam = Convert.ToString(dataReader["NAAM"]);
                    bool isGehuurd;
                    if(gehuurd == 1)
                    {
                        isGehuurd = true;
                    }
                    else
                    {
                        isGehuurd = false;
                    }
                    Plaats p = new Plaats(plaatsnummer, lnaam, capaciteit, isGehuurd);
                    plaatsen.Add(p);
                }
                return plaatsen;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Persoon> HaalPersonenOp(string eventNaam)
        {
            // in deze methode doen we nog niets met RFID
            List<Persoon> personen = new List<Persoon>();
            try
            {
                conn.Open();
                // met deze query krijg je alle hoofdboekers
                // in de where staat nu 'SME' dit moet veranderen in de variabele van huidigevent

                // geef alle hoofdboekers van het !!!SME event!!!
                string query = "SELECT * FROM PERSOON p, HOOFDBOEKER h, BEZOEKER b WHERE p.RFID = h.RFID and h.RFID = b.RFID and p.Event_ID = (SELECT ID FROM EVENT WHERE naam = '" + eventNaam + "')";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int anwezig = Convert.ToInt32(dataReader["Aanwezig"]);
                    bool aanwezig = false;
                    if (anwezig == 0)
                    {
                        aanwezig = false;
                    }
                    else
                    {
                        aanwezig = true;
                    }
                    personen.Add(new Hoofdboeker(Convert.ToString(dataReader["Gebruikersnaam"]), Convert.ToString(dataReader["Wachtwoord"]), Convert.ToDateTime(dataReader["Geboortedatum"]), Convert.ToString(dataReader["Reknr"]), Convert.ToString(dataReader["Adres"]), Convert.ToString(dataReader["Naam"]), Convert.ToString(dataReader["Achternaam"]), aanwezig, Convert.ToString(dataReader["rfid"])));
                }

                //geef alle controleurs van het SME event
                query = "SELECT * FROM PERSOON p, CONTROLEUR c WHERE p.RFID = c.RFID and p.Event_id = (Select ID FROM EVENT WHERE naam = '" + eventNaam + "')";
                command = new OracleCommand(query, conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    personen.Add(new Controleur(Convert.ToString(dataReader["Gebruikersnaam"]), Convert.ToString(dataReader["Wachtwoord"]), Convert.ToDateTime(dataReader["Geboortedatum"]), Convert.ToString(dataReader["Naam"]), Convert.ToString(dataReader["Achternaam"]), Convert.ToString(dataReader["rfid"])));
                }

                // geef alle beheerders van het SME event
                query = "SELECT * FROM PERSOON p, Beheerder b WHERE p.RFID = b.RFID and p.Event_id = (Select ID FROM EVENT WHERE naam = '" + eventNaam + "')";
                command = new OracleCommand(query, conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    personen.Add(new Beheerder(Convert.ToString(dataReader["Gebruikersnaam"]), Convert.ToString(dataReader["Wachtwoord"]), Convert.ToDateTime(dataReader["Geboortedatum"]), Convert.ToString(dataReader["Naam"]), Convert.ToString(dataReader["Achternaam"]), Convert.ToString(dataReader["rfid"])));
                }

                // geef alle bezoekers van het SME event
                query = "SELECT * FROM PERSOON p, Bezoeker b WHERE p.RFID = b.RFID and p.Event_id = (Select ID FROM EVENT WHERE naam = '" + eventNaam + "')";
                command = new OracleCommand(query, conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int anwezig = Convert.ToInt32(dataReader["Aanwezig"]);
                    bool aanwezig = false;
                    if (anwezig == 0)
                    {
                        aanwezig = false;
                    }
                    else
                    {
                        aanwezig = true;
                    }
                    personen.Add(new Bezoeker(Convert.ToString(dataReader["Gebruikersnaam"]), Convert.ToString(dataReader["Wachtwoord"]), Convert.ToDateTime(dataReader["Geboortedatum"]), Convert.ToString(dataReader["Naam"]), Convert.ToString(dataReader["Achternaam"]), aanwezig, Convert.ToString(dataReader["rfid"])));
                }
                return personen;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }


        public List<Huuritem> HaalHuuritemsOp(string eventNaam)
        {
            List<Huuritem> tempHuuritem = new List<Huuritem>();
            try
            {
                conn.Open();
                //Deze query haalt alle huuritems op
                string query = "SELECT * FROM HUURITEM";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string naam = Convert.ToString(dataReader["Naam"]);
                    string type = Convert.ToString(dataReader["Type"]);
                    int prijs = Convert.ToInt32(dataReader["Prijs"]);
                    int verhuurd = Convert.ToInt32(dataReader["Verhuurd"]);
                    bool gehuurd = false;
                    if (verhuurd == 0)
                    {
                        gehuurd = false;
                    }
                    else
                    {
                        gehuurd = true;
                    }
                    Huuritem h = new Huuritem(naam, type, prijs, gehuurd);
                    tempHuuritem.Add(h);
                }
                return tempHuuritem;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Event> HaalAlleEvenementen()
        {
            List<Event> tempEvent = new List<Event>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM EVENT";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string naam = Convert.ToString(dataReader["NAAM"]);
                    DateTime beginDatum = Convert.ToDateTime(dataReader["DATUMSTART"]);
                    DateTime eindDatum = Convert.ToDateTime(dataReader["DATUMEINDE"]);
                    tempEvent.Add(new Event(naam, beginDatum, eindDatum, "Veghel"));
                }
                return tempEvent;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public bool CheckInOut(string barcode)
        {
            int aanwezig = 0;
            try
            {
                conn.Open();
                string query = "SELECT AANWEZIG FROM RESERVERING_POLSBANDJE WHERE POLSBANDJE_ID = (SELECT ID FROM POLSBANDJE WHERE BARCODE = " + barcode + ")";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    aanwezig = Convert.ToInt32(datareader["AANWEZIG"]);
                }

                if (aanwezig == 0)
                {
                    query = "UPDATE RESERVERING_POLSBANDJE SET \"AANWEZIG\" = 1 WHERE \"POLSBANDJE_ID\" = (SELECT \"ID\" FROM POLSBANDJE WHERE \"BARCODE\" = " + barcode + ")";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    query = "UPDATE RESERVERING_POLSBANDJE SET \"AANWEZIG\" = 0 WHERE \"POLSBANDJE_ID\" = (SELECT \"ID\" FROM POLSBANDJE WHERE \"BARCODE\" = " + barcode + ")";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //alert van fout
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Bericht> VraagBerichtenOpVanEvent(string eventNaam)
        {
            List<Bericht> tempList = new List<Bericht>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM bericht WHERE event_id = (SELECT id FROM event WHERE naam = '" + eventNaam + "')";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string persoonRfid = Convert.ToString(dataReader["persoon_rfid"]);
                    DateTime date = Convert.ToDateTime(dataReader["plaatsdatum"]);
                    int id = Convert.ToInt32(dataReader["id"]);
                    string tekst = Convert.ToString(dataReader["bericht"]);
                    int berichtSoort = Convert.ToInt32(dataReader["berichtsoort"]);
                    tempList.Add(new Bericht(tekst, administratie.HuidigEvent.CheckGebruikersNaamRfid(persoonRfid), date, berichtSoort, id));
                }
                return tempList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Reactie> AlleReactiesVanBericht(string berichtId)
        {
            List<Reactie> tempList = new List<Reactie>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Reactie WHERE bericht_id = '" + berichtId + "'";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string persoonRfid = Convert.ToString(dataReader["persoon_rfid"]);
                    int reactieId = Convert.ToInt32(dataReader["id"]);
                    int berichtenId = Convert.ToInt32(dataReader["bericht_id"]);
                    DateTime plaatsDatum = Convert.ToDateTime(dataReader["plaatsdatum"]);
                    string tekst = Convert.ToString(dataReader["tekst"]);
                    tempList.Add(new Reactie(administratie.HuidigEvent.CheckGebruikersNaamRfid(persoonRfid), tekst, berichtenId, plaatsDatum));
                }
                return tempList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public List<Like> AlleLikesVanBericht(string berichtId)
        {
            List<Like> tempList = new List<Like>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM likes WHERE bericht_id = '" + berichtId + "'";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["bericht_id"]);
                    string persoonRfid = Convert.ToString(dataReader["persoon_rfid"]);
                    tempList.Add(new Like(administratie.HuidigEvent.CheckGebruikersNaamRfid(persoonRfid), id));
                }
                return tempList;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public void BezetPlaats(string locatienummer)
        {
            try
            {
                conn.Open();
                string query = "UPDATE PLAATS SET VERHUURD = 1 WHERE LOCATIENUMMER =" + locatienummer;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void OnBezetPlaats(string locatienummer)
        {
            try
            {
                conn.Open();
                string query = "UPDATE PLAATS SET VERHUURD = 0 WHERE LOCATIENUMMER =" + locatienummer;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void ReserveerHuuritem(string huurItemNaam)
        {
            try
            {
                conn.Open();
                string query = "UPDATE HUURITEM SET VERHUURD = 1 WHERE naam = '" + huurItemNaam + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void GeefHuuritemVrij(string huurItemNaam)
        {
            try
            {
                conn.Open();
                string query = "UPDATE HUURITEM SET VERHUURD = 0 WHERE naam = '" + huurItemNaam + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteGebruiker(string gebnaam)
        {
            foreach (Persoon p in HaalPersonenOp("SME"))
            {
                if (p is Bezoeker)
                {
                    Bezoeker b = p as Bezoeker;
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM persoon WHERE gebruikernaam = " + gebnaam;
                        command = new OracleCommand(query, conn);
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return false;
        }

        public bool DeleteEvent(string eventNaam)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM Event WHERE naam = " + eventNaam;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool DeletePlaats(string locatienr)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM plaats WHERE locatienummer = " + locatienr;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteMateriaal(string materiaalNaam)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM HuurItem WHERE naam = " + materiaalNaam;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public int GeefReserveringID()
        {
            int reserveringid = 0;
            try
            {
                conn.Open();
                string query = "SELECT MAX(ID) + 1 FROM RESERVERING";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    reserveringid = Convert.ToInt32(dataReader[0]);
                }
                return reserveringid;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        public int GeefEventID(string eventNaam)
        {
            int EventID = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT ID FROM EVENT WHERE naam = '" + eventNaam + "'";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    EventID = Convert.ToInt32(dataReader[0]);
                }
                return EventID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                // Frank: connectie hoeft alleen gesloten te worden als hij niet via een andere methode is aangeroepen.
            }
            return 0;
        }

        public string GeefVolgendeRFID()
        {
            int hoogsteRFID = 0;
            try
            {
                conn.Open();
                string query = "SELECT MAX(RFID) FROM PERSOON";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    hoogsteRFID = Convert.ToInt32(dataReader[0]);
                }
                return BerekenVolgendeRFID(hoogsteRFID);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return "";
        }

        public bool MaakPersoon(Persoon p, string eventNaam)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO PERSOON(RFID, Event_ID, Naam, Achternaam, Gebruikersnaam, Wachtwoord, Geboortedatum) VALUES('" + p.RfidCode + "'," + GeefEventID(eventNaam) + " , '" + p.Naam + "', '" + p.Achternaam + "', '" + p.Gebruikersnaam + "', '" + p.Wachtwoord + "', TO_DATE('" + p.GeboorteDatum.Day + "/" + p.GeboorteDatum.Month + "/" + p.GeboorteDatum.Year + "', 'dd/mm/yyyy'))";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool MaakHoofdboeker(Hoofdboeker h)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO HOOFDBOEKER(RFID, Adres, Reknr) VALUES('" + h.RfidCode + "', '" + h.Adres + "', '" + h.RekeningNummer + "')";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool MaakBezoeker(Bezoeker b, int reservering_ID)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO BEZOEKER(RFID, Reservering_ID, Aanwezig) VALUES('" + b.RfidCode + "', " + reservering_ID + ", " + 0 + ")";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public bool MaakReservering(int reservering_ID, string hoofdboeker_RFID)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO RESERVERING(ID, Hoofdboeker_RFID) VALUES(" + reservering_ID + ", '" + hoofdboeker_RFID + "')";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public void WijsPlaatsAanReservering(int reserveringID, string locatieNummer)
        {
            try
            {
                conn.Open();
                string query = "UPDATE PLAATS SET RESERVERING_ID = " + reserveringID + "WHERE LOCATIENUMMER = '" + locatieNummer + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void WijsItemAanReservering(int reserveringID, string itemNaam)
        {
            try
            {
                conn.Open();
                string query = "UPDATE HUURITEM SET RESERVERING_ID = " + reserveringID + "WHERE NAAM = '" + itemNaam + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public int HuuritemPrijsReservering(int reservering_ID)
        {
            int huurItemPrijs = 0;
            try
            {
                conn.Open();
                string query = "SELECT SUM(h.prijs) AS HUURITEMPRIJS FROM RESERVERING r LEFT JOIN HUURITEM h ON r.ID = h.Reservering_ID WHERE r.ID =" + reservering_ID;
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    huurItemPrijs = Convert.ToInt32(dataReader[0]);
                }
                return huurItemPrijs;
            }
            catch
            {
                // hier geen messagebox weergeven want het zou kunnen dat de prijs niet 
                // kan worden geconverteerd naar een int omdat er een nullwaarde wordt gelezen
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        public int PlaatsPrijsReservering(int reservering_ID)
        {
            int plaatsprijs = 0;
            try
            {
                conn.Open();
                string query = "SELECT SUM(p.prijs) AS PLAATSPRIJS FROM RESERVERING r LEFT JOIN PLAATS p ON r.ID = p.RESERVERING_ID WHERE r.ID =" + reservering_ID;
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    plaatsprijs = Convert.ToInt32(dataReader[0]);
                }
                return plaatsprijs;
            }
            catch
            {
                // hier geen messagebox weergeven want het zou kunnen dat de prijs niet 
                // kan worden geconverteerd naar een int omdat er een nullwaarde wordt gelezen
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        private string BerekenVolgendeRFID(int hoogsteRFID) // hier kan een getal als 1000 inkomen dit moet 00001001 worden.
        {
            hoogsteRFID++;
            string rfidCode = "";
            rfidCode = hoogsteRFID.ToString();
            while (rfidCode.Length < 8)
            {
                rfidCode = "0" + rfidCode;
            }
            return rfidCode;
        }

        public List<string> HaalAanwezigenOp()
        {
            List<string> aanwezigen = new List<string>();

            try
            {
                conn.Open();
                string query = "SELECT a.GEBRUIKERSNAAM, p.BARCODE FROM ACCOUNT a, POLSBANDJE p, RESERVERING_POLSBANDJE r WHERE p.ID = r.POLSBANDJE_ID AND r.ACCOUNT_ID = a.ID AND a.ACCOUNTTYPE NOT IN('admin','controleur') AND r.AANWEZIG = 1";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string naam = Convert.ToString(datareader["GEBRUIKERSNAAM"]);
                    string barcode = Convert.ToString(datareader["BARCODE"]);
                    string resultaat = naam + ", " + barcode;
                    aanwezigen.Add(resultaat);
                }
                return aanwezigen;
            }
            catch(Exception ex)
            {
                return null;
                //alert van fout
            }
            finally
            {
                conn.Close();
            }
        }
        public List<string> HaalAfwezigenOp()
        {
            List<string> afwezigen = new List<string>();

            try
            {
                conn.Open();
                string query = "SELECT a.GEBRUIKERSNAAM, p.BARCODE FROM ACCOUNT a, POLSBANDJE p, RESERVERING_POLSBANDJE r WHERE p.ID = r.POLSBANDJE_ID AND r.ACCOUNT_ID = a.ID AND a.ACCOUNTTYPE NOT IN('admin','controleur') AND r.AANWEZIG = 0";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string naam = Convert.ToString(datareader["GEBRUIKERSNAAM"]);
                    string barcode = Convert.ToString(datareader["BARCODE"]);
                    string resultaat = naam + ", " + barcode;
                    afwezigen.Add(resultaat);
                }
                return afwezigen;
            }
            catch (Exception ex)
            {
                return null;
                //alert van fout
            }
            finally
            {
                conn.Close();
            }
        }
    }
}