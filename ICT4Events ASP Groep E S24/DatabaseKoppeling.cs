using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class DatabaseKoppeling
    {
        private static Administratie administratie = new Administratie();
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

        // dit is het nieuwe huurmateriaal
        public List<Huuritem> HaalGehuurdeItems()
        {
            List<Huuritem> tempHuurItems = new List<Huuritem>();
            try
            {
                conn.Open();
                string query = "SELECT p.MERK, p.SERIE, pe.VOLGNUMMER, c.NAAM FROM PRODUCT p, PRODUCTCAT c, PRODUCTEXEMPLAAR pe WHERE pe.PRODUCT_ID = p.ID AND p.PRODUCTCAT_ID = c.ID AND pe.ID IN (SELECT PRODUCTEXEMPLAAR_ID FROM VERHUUR)";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string merk = Convert.ToString(dataReader["MERK"]);
                    string serie = Convert.ToString(dataReader["SERIE"]);
                    int volgnummer = Convert.ToInt32(dataReader["VOLGNUMMER"]);
                    string categorie = Convert.ToString(dataReader["NAAM"]);
                    tempHuurItems.Add(new Huuritem(merk, serie, volgnummer, categorie, true));                            
                }
                return tempHuurItems;
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }                    
        }

        public List<Huuritem> HaalNietGehuurdeItems()
        {
            List<Huuritem> tempHuurItems = new List<Huuritem>();
            try
            {
                conn.Open();
                string query = "SELECT p.MERK, p.SERIE, pe.VOLGNUMMER, c.NAAM FROM PRODUCT p, PRODUCTCAT c, PRODUCTEXEMPLAAR pe WHERE pe.PRODUCT_ID = p.ID AND p.PRODUCTCAT_ID = c.ID AND pe.ID NOT IN (SELECT PRODUCTEXEMPLAAR_ID FROM VERHUUR)";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string merk = Convert.ToString(dataReader["MERK"]);
                    string serie = Convert.ToString(dataReader["SERIE"]);
                    int volgnummer = Convert.ToInt32(dataReader["VOLGNUMMER"]);
                    string categorie = Convert.ToString(dataReader["NAAM"]);
                    tempHuurItems.Add(new Huuritem(merk, serie, volgnummer, categorie, false));
                }
                return tempHuurItems;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


        // dit is het oude huurmateriaal
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

        public Event HaalEvent()
        {
            Event tempEvent = null;
            try
            {
                conn.Open();
                string query = "SELECT e.NAAM AS EVENTNAAM, DATUMSTART, DATUMEINDE, l.NAAM AS LOCATIENAAM  FROM EVENT e, LOCATIE l WHERE e.LOCATIE_ID = l.ID";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string naam = Convert.ToString(dataReader["EVENTNAAM"]);
                    DateTime beginDatum = Convert.ToDateTime(dataReader["DATUMSTART"]);
                    DateTime eindDatum = Convert.ToDateTime(dataReader["DATUMEINDE"]);
                    string plaats = Convert.ToString(dataReader["LOCATIENAAM"]);
                    tempEvent = (new Event(naam, beginDatum, eindDatum, plaats, "Rachelsmolen 1"));
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
            string aanwezig = null;
            try
            {
                conn.Open();
                string query = "SELECT AANWEZIG FROM RESERVERING_POLSBANDJE WHERE POLSBANDJE_ID = (SELECT ID FROM POLSBANDJE WHERE BARCODE = " + barcode + ")";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    aanwezig = Convert.ToString(datareader["AANWEZIG"]);
                }

                if (aanwezig == "0")
                {
                    query = "UPDATE RESERVERING_POLSBANDJE SET \"AANWEZIG\" = 1 WHERE \"POLSBANDJE_ID\" = (SELECT \"ID\" FROM POLSBANDJE WHERE \"BARCODE\" = " + barcode + ")";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                    return true;
                }
                else if(aanwezig == "1")
                {
                    query = "UPDATE RESERVERING_POLSBANDJE SET \"AANWEZIG\" = 0 WHERE \"POLSBANDJE_ID\" = (SELECT \"ID\" FROM POLSBANDJE WHERE \"BARCODE\" = " + barcode + ")";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
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

        public List<Bericht> VraagBerichtenOpVanEvent()
        {
            List<Bericht> tempList = new List<Bericht>();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Bericht";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["ID"]);
                    int accountId = Convert.ToInt32(dataReader["ACCOUNT_ID"]);
                    Account auteur = administratie.GeefAccountDoorId(accountId);
                    DateTime datumGepost = Convert.ToDateTime(dataReader["DATUM"]);
                    string berichtSoort = Convert.ToString(dataReader["BERICHT_SOORT"]);
                    int soort = 0;
                    if(berichtSoort == "foto")
                    {
                        soort = 1;
                    }
                    if (berichtSoort == "video")
                    {
                        soort = 2;
                    }
                    if (berichtSoort == "muziek")
                    {
                        soort = 3;
                    }
                    string tekst = Convert.ToString(dataReader["TEKST"]);
                    tempList.Add(new Bericht(tekst, auteur, datumGepost, soort, id));
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
                    int accountid = Convert.ToInt32(dataReader["account_id"]);
                    int reactieId = Convert.ToInt32(dataReader["id"]);
                    int berichtenId = Convert.ToInt32(dataReader["bericht_id"]);
                    string tekst = Convert.ToString(dataReader["tekst"]);
                    tempList.Add(new Reactie(administratie.GeefAccountDoorId(accountid), tekst, berichtenId));
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
                string query = "SELECT * FROM \"LIKE\" WHERE bericht_id = '" + berichtId + "'";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["id"]);
                    int accountId = Convert.ToInt32(dataReader["account_id"]);
                    tempList.Add(new Like(administratie.GeefAccountDoorId(accountId), id));
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

        //Deze methode vraagt alle materiaalsoorten op, waar de PRODUCTCAT_ID null is.
        public List<string> VraagMateriaalSoortOp()
        {
            List<string> categorienamen = new List<string>();
            try
            {
                conn.Open();
                string query = "SELECT NAAM FROM PRODUCTCAT WHERE PRODUCTCAT_ID IS NULL";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string naam = Convert.ToString(datareader["NAAM"]);
                    categorienamen.Add(naam);
                }
                return categorienamen;
            }
            catch (Exception ex)
            {
                return null;
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Account> HaalAlleAccountsOp()
        {
            List<Account> tempAccounts = new List<Account>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM account";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    int id = Convert.ToInt32(datareader["ID"]);
                    string gebruikersnaam = Convert.ToString(datareader["GEBRUIKERSNAAM"]);
                    string email = Convert.ToString(datareader["EMAIL"]);
                    string activatiehash = Convert.ToString(datareader["ACTIVATIEHASH"]);
                    bool geactiveerd = ConvertIntToBool(Convert.ToInt32(datareader["GEACTIVEERD"]));
                    string wachtwoord = Convert.ToString(datareader["WACHTWOORD"]);
                    string accounttype = Convert.ToString(datareader["ACCOUNTTYPE"]);
                    tempAccounts.Add(new Account(id, gebruikersnaam, email, activatiehash, geactiveerd, wachtwoord, accounttype));
                }
                return tempAccounts;
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

        public bool ConvertIntToBool(int number)
        {
            if (number == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<string> CalamiteitenLijst()
        {
            List<string> personen = new List<string>();
            try
            {
                conn.Open();
                string query = "SELECT VOORNAAM,TUSSENVOEGSEL,ACHTERNAAM,STRAAT,HUISNR,WOONPLAATS FROM PERSOON WHERE ID IN (SELECT PERSOON_ID FROM RESERVERING WHERE ID IN (SELECT RESERVERING_ID FROM RESERVERING_POLSBANDJE WHERE AANWEZIG = 1))";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string voornaam = Convert.ToString(datareader["VOORNAAM"]);
                    string tussenvoegsel = Convert.ToString(datareader["TUSSENVOEGSEL"]);
                    string achternaam = Convert.ToString(datareader["ACHTERNAAM"]);
                    string straat = Convert.ToString(datareader["STRAAT"]);
                    string huisnr = Convert.ToString(datareader["HUISNR"]);
                    string woonplaats = Convert.ToString(datareader["WOONPLAATS"]);
                    personen.Add(voornaam + ' ' + tussenvoegsel + ' ' + achternaam + " uit " + woonplaats + ", " + straat + " " + huisnr);
                }
                return personen;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        #region reserveringssysteem
        
        // hier wordt een stored procedure aangeroepen waarbij ook een reservering en een polsbandje aan een persoon wordt gekoppeld
        public bool NieuweHoofdboeker(string voornaam, string tussenvoegsel, string achternaam,
            string straat, string huisnr, string woonplaats, string banknr,
            string gebruikersnaam, string email, string activehash, int geactiveerd,
            string wachtwoord, string accounttype, out string error)
        {
            error = "";
            try
            {
                command = new OracleCommand("NIEUWEHOOFDBOEKER", conn);
                command.CommandType = CommandType.StoredProcedure;
                // voor de persoon tabel
                command.Parameters.Add("P_VOORNAAM", OracleDbType.Varchar2).Value = voornaam;
                command.Parameters.Add("P_TUSSENVOEGSEL", OracleDbType.Varchar2).Value = tussenvoegsel;
                command.Parameters.Add("P_ACHTERNAAM", OracleDbType.Varchar2).Value = achternaam;
                command.Parameters.Add("P_STRAAT", OracleDbType.Varchar2).Value = straat;
                command.Parameters.Add("P_HUISNR", OracleDbType.Varchar2).Value = huisnr;
                command.Parameters.Add("P_WOONPLAATS", OracleDbType.Varchar2).Value = woonplaats;
                command.Parameters.Add("P_BANKNR", OracleDbType.Varchar2).Value = banknr;
                // voor de account tabel
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersnaam;
                command.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = email;
                command.Parameters.Add("P_ACTIVATIEHASH", OracleDbType.Varchar2).Value = null;
                command.Parameters.Add("P_GEACTIVEERD", OracleDbType.Int32).Value = 0;
                command.Parameters.Add("P_WACHTWOORD", OracleDbType.Varchar2).Value = wachtwoord;
                command.Parameters.Add("P_ACCOUNTTYPE", OracleDbType.Varchar2).Value = "gebruiker";

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
                error = "Gebruikersnaam Bestaat Al";
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // hier wordt een stored procedure aangeroepen waarbij ook een reservering en een polsbandje aan een persoon wordt gekoppeld
        public bool NieuweBezoeker(string hbGebrNm, string voornaam, string tussenvoegsel, string achternaam,
            string straat, string huisnr, string woonplaats, string banknr,
            string gebruikersnaam, string email, string activehash, int geactiveerd,
            string wachtwoord, string accounttype, out string error)
        {
            error = "";
            try
            {
                command = new OracleCommand("NIEUWEBEZOEKER", conn);
                command.CommandType = CommandType.StoredProcedure;
                // geef mee wat de gebruikersnaam van de hoofdboeker is om aan de juiste reservering te koppelen
                command.Parameters.Add("P_HBGEBRNM", OracleDbType.Varchar2).Value = hbGebrNm;
                // voor de persoon tabel
                command.Parameters.Add("P_VOORNAAM", OracleDbType.Varchar2).Value = voornaam;
                command.Parameters.Add("P_TUSSENVOEGSEL", OracleDbType.Varchar2).Value = tussenvoegsel;
                command.Parameters.Add("P_ACHTERNAAM", OracleDbType.Varchar2).Value = achternaam;
                command.Parameters.Add("P_STRAAT", OracleDbType.Varchar2).Value = straat;
                command.Parameters.Add("P_HUISNR", OracleDbType.Varchar2).Value = huisnr;
                command.Parameters.Add("P_WOONPLAATS", OracleDbType.Varchar2).Value = woonplaats;
                command.Parameters.Add("P_BANKNR", OracleDbType.Varchar2).Value = banknr;
                // voor de account tabel
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersnaam;
                command.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = email;
                command.Parameters.Add("P_ACTIVATIEHASH", OracleDbType.Varchar2).Value = null;
                command.Parameters.Add("P_GEACTIVEERD", OracleDbType.Int32).Value = 0;
                command.Parameters.Add("P_WACHTWOORD", OracleDbType.Varchar2).Value = wachtwoord;
                command.Parameters.Add("P_ACCOUNTTYPE", OracleDbType.Varchar2).Value = "gebruiker";

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
                error = "Gebruikersnaam Bestaat Al";
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // methode voegt een plek aan een reservering toe in de database via een SP
        public bool PlekAanReservering(string plekNummer, string gebruikersNaam)
        {
            try
            {
                command = new OracleCommand("PLEKAANRESERVERING", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PLEKNUMMER", OracleDbType.Varchar2).Value = plekNummer;
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersNaam;

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // deze methode verwijderd een plek uit een reservering dmv een SP
        public bool PlekUitReservering(string plekNummer, string gebruikersNaam)
        {
            try
            {
                command = new OracleCommand("PLEKUITRESERVERING", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_PLEKNUMMER", OracleDbType.Varchar2).Value = plekNummer;
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersNaam;

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // deze methode huurt een product in de database dmv een SP
        public bool HuurProduct(string categorie, string merk, int volgnummer, string gebruikersNaam)
        {
            try
            {
                command = new OracleCommand("HUURPRODUCT", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATEGORIE", OracleDbType.Varchar2).Value = categorie;
                command.Parameters.Add("P_MERK", OracleDbType.Varchar2).Value = merk;
                command.Parameters.Add("P_VOLGNUMMER", OracleDbType.Int32).Value = volgnummer;
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersNaam;

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // deze methode verwijdert een 'verhuring' dmv een SP
        public bool VerwijderProduct(string categorie, string merk, int volgnummer, string gebruikersNaam)
        {
            try
            {
                command = new OracleCommand("VERWIJDERPRODUCT", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATEGORIE", OracleDbType.Varchar2).Value = categorie;
                command.Parameters.Add("P_MERK", OracleDbType.Varchar2).Value = merk;
                command.Parameters.Add("P_VOLGNUMMER", OracleDbType.Int32).Value = volgnummer;
                command.Parameters.Add("P_GEBRUIKERSNAAM", OracleDbType.Varchar2).Value = gebruikersNaam;

                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region Eventbeheer
        public bool WijzigEvent(out string exc, Event evNa)
        {
            bool kay = false;
            try
            {
                conn.Open();
                string query = "update LOCATIE set naam=:naam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("naam", evNa.Plaats));
                command.ExecuteNonQuery();

                ///////////////////////

                query = "update EVENT set naam=:naam, datumStart=TO_DATE('" +
                    evNa.BeginDatum.Day + "/" + evNa.BeginDatum.Month +
                    "/" + evNa.BeginDatum.Year + "', 'dd/mm/yyyy'),datumEinde=TO_DATE('" +
                    evNa.EindDatum.Day + "/" + evNa.EindDatum.Month + "/" + evNa.EindDatum.Year +
                    "', 'dd/mm/yyyy')";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("naam", evNa.Naam));
                command.ExecuteNonQuery();

                kay = true;
            }
            catch (Exception ex)
            {
                exc = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            exc="";
            return kay;
        }

        public bool wijzigHuuritem(out string exc, Huuritem huVoor, Huuritem huNa)
        {
            bool kay = false;
            try
            {
                conn.Open();
                string query = "update PRODUCTCAT set naam=:naam where naam=:oldnaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("naam", huNa.Categorie));
                command.Parameters.Add(new OracleParameter("oldnaam", huVoor.Categorie));
                command.ExecuteNonQuery();

                ///////////////////////

                query = "update PRODUCT set merk=:merk where merk=:oldmerk and productcat_id = " +
                    "(select id from PRODUCTCAT where naam=:naam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("merk", huNa.Merk));
                command.Parameters.Add(new OracleParameter("naam", huNa.Categorie));
                command.Parameters.Add(new OracleParameter("oldmerk", huVoor.Merk));
                command.ExecuteNonQuery();

                ///////////////////////////

                //query = "update PRODUCTEXEMPLAAR set volgnummer=:volgnr where volgnummer=:oldvolgnr" +
                //    "and product_id=(select id from PRODUCT where naam=:oldmerk and productcat_id = " +
                //    "(select id from PRODUCTCAT where naam=:naam))";
                //command = new OracleCommand(query, conn);
                //command.Parameters.Add(new OracleParameter("naam", huNa.Naam));
                //command.Parameters.Add(new OracleParameter("oldmerk", huVoor.Merk));
                //command.Parameters.Add(new OracleParameter("volgnr", huNa.VolgNummer));
                //command.Parameters.Add(new OracleParameter("oldvolgnr", huVoor.VolgNummer));
                //command.ExecuteNonQuery();

                kay = true;
            }
            catch (Exception ex)
            {
                exc = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            exc = "";
            return kay;
        }

        public bool NieuweCategorie(string categorieNaam)
        {
            try
            {
                command = new OracleCommand("NIEUWEPRODUCTCAT", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATNAAM", OracleDbType.Varchar2).Value = categorieNaam;
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
                
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool NieuwProduct(string categorieNaam, string merkNaam, int volgnummer)
        {
            try
            {
                command = new OracleCommand("NIEUWPRODUCT", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATNAAM", OracleDbType.Varchar2).Value = categorieNaam;
                command.Parameters.Add("P_MERKNAAM", OracleDbType.Varchar2).Value = merkNaam;
                command.Parameters.Add("P_VOLGNUMMER", OracleDbType.Int32).Value = volgnummer;
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool NieuwMerk(string catnaam, string merk)
        {
            try
            {
                command = new OracleCommand("NIEUWMERK", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATNAAM", OracleDbType.Varchar2).Value = catnaam;
                command.Parameters.Add("P_MERK", OracleDbType.Varchar2).Value = merk;
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool NieuwVolgnummer(string catnaam, string merk, int volgnummer)
        {
            try
            {
                command = new OracleCommand("NIEUWVOLGNUMMER", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_CATNAAM", OracleDbType.Varchar2).Value = catnaam;
                command.Parameters.Add("P_MERK", OracleDbType.Varchar2).Value = merk;
                command.Parameters.Add("P_VOLGNR", OracleDbType.Int32).Value = volgnummer;
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(command);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool VoegMateriaalToe(out string exc, Huuritem huuritem)
        {
            bool kay = false;
            try
            {
                /*conn.Open();
                string query = "insert PRODUCTCAT set naam=:naam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("naam", huuritem.Naam));
                command.ExecuteNonQuery();

                ///////////////////////

                conn.Open();
                query = "update PRODUCT set merk=:merk where naam=:oldmerk and productcat_id = " +
                    "(select id from PRODUCTCAT where naam=:naam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("merk", huNa.Merk));
                command.Parameters.Add(new OracleParameter("naam", huNa.Naam));
                command.Parameters.Add(new OracleParameter("oldmerk", huVoor.Merk));
                command.ExecuteNonQuery();

                ///////////////////////////

                conn.Open();
                query = "update PRODUCTEXEMPLAAR set volgnummer=:volgnr where volgnummer=:oldvolgnr" +
                    "and product_id=(select id from PRODUCT where naam=:oldmerk and productcat_id = " +
                    "(select id from PRODUCTCAT where naam=:naam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("naam", huNa.Naam));
                command.Parameters.Add(new OracleParameter("oldmerk", huVoor.Merk));
                command.Parameters.Add(new OracleParameter("volgnr", huNa.VolgNummer));
                command.Parameters.Add(new OracleParameter("oldvolgnr", huVoor.VolgNummer));
                command.ExecuteNonQuery();
                */
                kay = true;
            }
            catch (Exception ex)
            {
                exc = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            exc = "";
            return kay;
        }
        public bool DeleteMateriaal(string materiaalNaam, out string exc)
        {
            bool kay = false;
            try
            {
                conn.Open();
                string query = "DELETE FROM HuurItem WHERE naam = " + materiaalNaam;
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                exc = "";
                kay =  true;
            }
            catch (Exception ex)
            {
                exc = ex.ToString();
                kay = false;
            }
            finally
            {
                conn.Close();
                
            }
            return kay;
        }


        public bool NieuwTekstBericht(string tekst, Account auteur)
        {
            try
            {
                int nieuweId = Administratie.hoogsteIdBericht + 1;
                conn.Open();
                string query = "INSERT INTO Bericht(id, account_id, tekst, datum, bericht_soort) VALUES ('" + nieuweId + "', '" + auteur.Id + "', '" + tekst + "', SYSDATE, 'bericht')";
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

        public bool LikeBericht(int berichtId, Account liker)
        {
            try
            {
                int nieuweId = Administratie.hoogsteIdLike + 1;
                conn.Open();
                string query = "INSERT INTO \"LIKE\"(ACCOUNT_ID, BERICHT_ID, ID) VALUES (" + liker.Id + ", " + berichtId+ ", " + nieuweId + ")";
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

        public bool PlaatsReactieOpBericht(Account plaatser, int berichtId, string tekst)
        {
            try
            {
                int nieuweId = Administratie.hoogsteIdReactie + 1;
                conn.Open();
                string query = "INSERT INTO Reactie(id, bericht_id, account_id, tekst) VALUES ('" + nieuweId + "', '" + berichtId + "', '" + plaatser.Id + "', '" + tekst + "')";
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

        public bool UnLikeBericht(int id)
        {
            try
            {
                int nieuweId = Administratie.hoogsteIdLike + 1;
                conn.Open();
                string query = "DELETE FROM \"LIKE\" WHERE id = '" + id.ToString() + "'";
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

        public bool PlaatsCapAanpassen(out string exc, string plaatsNr, int cap)
        {
            bool kay = false;
            try
            {
                conn.Open();
                string query = "update PLEK set CAPACITEIT=:cap where NUMMER=:nummer";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("cap", cap));
                command.Parameters.Add(new OracleParameter("nummer", plaatsNr));
                command.ExecuteNonQuery();

                kay = true;
            }
            catch (Exception ex)
            {
                exc = ex.ToString();
            }
            finally
            {
                exc = "";
                
                conn.Close();
            }
            return kay;
        }

        public bool VerwijderGebruiker(string gebruikersNaam)
        {
            try
            {
                conn.Open();
                string query = "UPDATE ACCOUNT SET GEACTIVEERD = 0 WHERE GEBRUIKERSNAAM = :gebruikersNaam";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("gebruikersNaam", gebruikersNaam));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateMateriaalPrijs(string categorieNaam, string merk, int prijs)
        {
            try
            {
                conn.Open();
                string query = "UPDATE PRODUCT SET PRIJS = :prijs WHERE merk = :merk AND productcat_ID = (SELECT ID FROM PRODUCTCAT WHERE NAAM = :categorienaam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("prijs", prijs));
                command.Parameters.Add(new OracleParameter("merk", merk));
                command.Parameters.Add(new OracleParameter("categorienaam", categorieNaam));
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> HaalAlleMerken(string catnaam)
        {
            List<string> tempList = new List<string>();
            try
            {
                conn.Open();
                string query = "SELECT DISTINCT(MERK) FROM PRODUCT WHERE PRODUCTCAT_ID = (SELECT ID FROM PRODUCTCAT WHERE NAAM = :catnaam)";
                command = new OracleCommand(query, conn);
                command.Parameters.Add(new OracleParameter("catnaam", catnaam));
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    tempList.Add(Convert.ToString(dataReader["MERK"]));
                }
                return tempList;
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }


        }

        #endregion
    }
}