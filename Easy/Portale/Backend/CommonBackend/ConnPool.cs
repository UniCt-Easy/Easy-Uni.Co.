
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Backend.CommonBackend
{
	/// <summary>
	/// Singolo EasyDataAccess del pool di connessioni
	/// Restituisce una EasyDataAccess complessa ovvero un la Locked e CreationDate
	/// </summary>
	public class EasyConn
	{ 
		public IEasyDataAccess eda { get; set; }
		public bool locked { get; set; }
		public DateTime creationDate { get; set; }
		
		/// <summary>
		/// Costruttore della connessione che è il j-esimo elemento del pool
		/// Nasce locked dal chiamante
		/// Riceve una data di creazione che potrebbe servire per il riciclo
		/// </summary>
		/// <param name="DNS"></param>
		/// <param name="Server"></param>
		/// <param name="Database"></param>
		/// <param name="User"></param>
		/// <param name="Password"></param>
		/// <param name="Dipartimento"></param>
		/// <param name="Esercizio"></param>
		/// <param name="DataContabile"></param>
		/// <param name="error"></param>
		/// <param name="detail"></param>
		public EasyConn(string DNS, string Server, string Database, string User, string Password, string Dipartimento, int Esercizio, DateTime DataContabile, out string error, out string detail)
		{
			eda = Easy_DataAccess.getEasyDataAccess(DNS, Server, Database, User, Password, Dipartimento, Esercizio, DataContabile, out error, out detail);
            // la prima volta in assoluto è null.
            if (CacheMDLW.dbStructureCache != null) {
                eda.setStructures(CacheMDLW.dbStructureCache);
            }
			locked = true;
			creationDate = DateTime.Now;
		}

		/// <summary>
		/// La Connessione non viene né chiusa né distrutta ma viene messa a disposizione di altri utilizzatori
		/// </summary>
		public void Release()
		{
            // salvo nella cache la struttura che sarà stata calcolata.
            // -> in prod potrebbe non servire perchè già calcolata
            foreach (var k in eda.getStructures()) {
	            if (CacheMDLW.dbStructureCache.ContainsKey(k.Key)) continue;
	            CacheMDLW.dbStructureCache.Add(k.Key,k.Value);
            }
            // ripulisco lastError e seguendo la lettura. poichè essa stessa esegue reset.
            var lastError = eda.LastError;
            locked = false;
        }

		/// <summary>
		/// Elimino dal pool di connessioni
		/// </summary>
		public void CloseDestroy()
		{
			eda.Close();
			eda.Destroy();
		}
	}

	/// <summary>
	/// 
	/// </summary>
    public static class ConnPool
    {
		// INTERVALLO DI TEMPO IN ORE PER LA CANCELLAZIONE
		private static readonly int clearInterval = 1;
        // NUMERO DI CONNESSIONI NEL POOL INIZIALE
        private static readonly int connPoolNumberInit = 5;

        /// <summary>
        /// Il dictionary contiene un array di EasyConnection allo stesso (Server, Database, Dipartimento)
        /// </summary>
        private static Dictionary<string, List<EasyConn>> EasyDataAccessDict = new Dictionary<string, List<EasyConn>>();

		/// <summary>
		/// Prende la connessione dal Dictionary di connessioni
		/// La chiave del Dictionary è la stringa "Server_Database_Dipartimento"
		/// Se non esiste una KeyValuePair nel Dictionary lo crea e lo aggiunge al Dictionary
		/// creando un pool con almeno un EasyDataAccess che sarà locked perchè già in uso dal chiamante
		/// </summary>
		/// <param name="DNS"></param>
		/// <param name="Server"></param>
		/// <param name="Database"></param>
		/// <param name="User"></param>
		/// <param name="Password"></param>
		/// <param name="Dipartimento"></param>
		/// <param name="Esercizio"></param>
		/// <param name="DataContabile"></param>
		/// <param name="error"></param>
		/// <param name="detail"></param>
		/// <returns></returns>
		public static EasyConn getConn(string DNS, string Server, string Database, string User, string Password, string Dipartimento, int Esercizio, DateTime DataContabile, out string error, out string detail)
		{
			// Ad ogni passaggio dovremmo rimuovere le connessioni "vecchie"
			// TryClear();

			// GET CONN KEY
			string conn_key = getConnKey(Server, Database, Dipartimento);
			error = null;
			detail = null;

                // SE NON ESISTE LA CHIAVE
                if (!EasyDataAccessDict.ContainsKey(conn_key)) {
                    // CREO UNA NUOVA CONNESSIONE CHE E' LA PRIMA DEL POOL DI QUELLA CHIAVE/TUPLA
                    EasyConn ec = new EasyConn(DNS, Server, Database, User, Password, Dipartimento, Esercizio, DataContabile, out error, out detail);
                    EasyDataAccessDict[conn_key] = new List<EasyConn>();
                    EasyDataAccessDict[conn_key].Add(ec);
                    return ec;
                }
                else {

                     lock (EasyDataAccessDict) {
                        // ALTRIMENTI ALL'INTERNO DI QUEL POOL CERCO UNA CONNESSIONE LIBERA CON QUELLA TUPLA, e che non abbia errori di apertura appesi
                        EasyConn ec = EasyDataAccessDict[conn_key].Where(w => (w.locked == false && (w.eda != null && !w.eda.openError))).FirstOrDefault();

                            if (ec == null) {
                                // SE NESSUNA CONNESSIONE E' LIBERA (SONO TUTTE LOCKED) NE CREO UN'ALTRA LIBERA
                                // IN QUEL POOL (CARATTERIZZATO DA CONNESSIONI TUTTE ALLO STESSO Server/DB/Dip
                                ec = new EasyConn(DNS, Server, Database, User, Password, Dipartimento, Esercizio, DataContabile, out error, out detail);
                                EasyDataAccessDict[conn_key].Add(ec);
                            }
                          
                            // metto lock sulla connessione, perchè se esiste l'ho presa dal pool in cui era ovviamente a false
                            ec.locked = true;
                            return ec;
                    }  
          
            }

		}

        public static void createConnPool(string DNS, string Server, string Database, string User, string Password, string Dipartimento, int Esercizio, DateTime DataContabile, out string error, out string detail) {
            string conn_key = getConnKey(Server, Database, Dipartimento);
            error = null;
            detail = null;
            int[] numberConn = new int[connPoolNumberInit];

            if (!EasyDataAccessDict.ContainsKey(conn_key)) {
                // CREO UNA NUOVA CONNESSIONE CHE E' LA PRIMA DEL POOL DI QUELLA CHIAVE/TUPLA
                EasyDataAccessDict[conn_key] = new List<EasyConn>();
            }

            // loop per creare pool di n connessisoni libere
            foreach (int i in numberConn) {
                EasyConn ec = new EasyConn(DNS, Server, Database, User, Password, Dipartimento, Esercizio, DataContabile, out error, out detail);
                ec.locked = false;
                EasyDataAccessDict[conn_key].Add(ec);
            }
        }

		/// <summary>
		/// Ad ogni passaggio cerca le connessioni più vecchie di un intervallo scelto e se non utilizzate (locked) le rimuove
		/// </summary>
		[Obsolete]
		private static void TryClear()
		{
			// PER OGNI ELEMENTO DEL DIZIONARIO
			foreach (KeyValuePair<string, List<EasyConn>> entry in EasyDataAccessDict)
			{
				// PER OGNI CONNESSIONE DEL POOL
				foreach (EasyConn ec in entry.Value)
				{
					// SE SCADUTA LA CONNESSIONE e NESSUNO LA STA USANDO
					if (ec.creationDate < DateTime.Now.AddHours(-clearInterval) && !ec.locked)
					{
						// Chiudi e distruggi la connection
						ec.CloseDestroy();
						// Elimina la EasyConn dalla list
						entry.Value.Remove(ec);
					}
				}
				// SE NON CI SONO CONNESSIONI NEL POOL DELLA TUPLA NON RIMUOVO LA TUPLA PERCHE' E' VEROSIMILE CHE NE VERRANNO CREATE ALTRE
				// OVVERO MI ASPETTO 10 TUPLE CON VARIE DI CONNESSIONI NEL POOL
				//if (entry.Value.Count == 0)
				//{
				//	EasyDataAccessDict.Remove(entry.Key);
				//}
			}
		}

		/// <summary>
		/// Calcola Connection Key con:
		/// Server (IP)
		/// Database (nome, es: unirc_easy)
		/// Dipartimento (prima si avevano più dipartimenti per database, adesso (fine 2019) solo uno ma lo lasciamo per completezza)
		/// </summary>
		/// <param name="DNS"></param>
		/// <param name="Server"></param>
		/// <param name="Database"></param>
		/// <param name="Dipartimento"></param>
		/// <returns></returns>
		private static string getConnKey(string Server, string Database, string Dipartimento)
		{ 
			return string.Format("{0}_{1}_{2}", Server, Database, Dipartimento);
		}

	}
}
