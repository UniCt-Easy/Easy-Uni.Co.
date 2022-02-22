
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Web.Configuration;
using Backend.Components;
using Backend.Security;
using Token = Backend.Security.Token;

namespace Backend.CommonBackend
{

    /// <summary>
    /// Il dispatcher dei dati.
    /// </summary>
    public class Dispatcher : IDisposable {

        private const string DIPARTIMENTO = "amm";

        public IEasyDataAccess conn;
        private EasyConn ec;
        private IEntityDispatcher dispatcher;
        private CQueryHelper qhc;

        public Dispatcher(IEasyDataAccess conn) {
            this.conn = conn;

        }
        /// <summary>
        /// Inizializza il dispatcher.
        /// </summary>
        /// <param name="DSN">Nome della sorgente dati.</param>
        /// <param name="Server">Indirizzo del server</param>
        /// <param name="Database">Nome del database.</param>
        /// <param name="User">Nome dell'account utente.</param>
        /// <param name="Password">Password dell'account utente.</param>
        /// <param name="Esercizio">Anno d'esercizio.</param>
        /// <param name="DataContabile">Data contabile.</param>
        public Dispatcher() {
        }

        /// <summary>
        /// Create a system connection. Get it from pool if exists a free connection
        /// </summary>
        public void createDbConnection() {
            string error;
            string detail;

            string DNS = "EasyPay";
            string Server = WebConfigurationManager.AppSettings["DBServer"];
            string Database = WebConfigurationManager.AppSettings["DBName"];
            string User = WebConfigurationManager.AppSettings["DBUser"];
            string Password = getCleanPassword(WebConfigurationManager.AppSettings["DBPassword"]);
            string DIPARTIMENTO = WebConfigurationManager.AppSettings["DBDipartimento"]; ;
            int Esercizio = DateTime.Now.Year;
            DateTime DataContabile = DateTime.Now; // TODO deve essere passata dal client

            // Prende connessione dal pool di connessioni già aperte
            ec = ConnPool.getConn(DNS, Server, Database, User, Password, DIPARTIMENTO, Esercizio, DataContabile, out error, out detail);
			if (!string.IsNullOrEmpty(error))
				throw new Exception(error);
            conn = ec.eda;
        }

        private string getCleanPassword(string pwd){
            //return pwd;   // 22 gen 2021 --> Abilitare scommentando riga, quando si ha la pwd in chiaro su web.config
            SystemConfig systemConfig = Token.decodeSystemConfig(pwd);
            return systemConfig.password;
        }

        /// <summary>
        /// Distrugge il dispatcher. rilascia la connessione del pool
        /// </summary>
        public void Dispose() {
         
            qhc = null;
            dispatcher = null;
            // Rilascio la connessione, quindi recupero EasyConn e ne faccio la Release.
            // la quale non chiude o distrugge, ma toglie il lock
            if (ec != null) ec.Release();
           
            return;

            // VECCHIO CODICE, prima del pool
            //if (conn == null) return;
            //conn.Close();
            //conn.Destroy();
            //qhc = null;
            //dispatcher = null;
            //conn = null;
        }

        internal void createPoolConnection() {
            string error;
            string detail;
            string DNS = "EasyPay";
            string Server = WebConfigurationManager.AppSettings["DBServer"];
            string Database = WebConfigurationManager.AppSettings["DBName"];
            string User = WebConfigurationManager.AppSettings["DBUser"];
            string Password = getCleanPassword(WebConfigurationManager.AppSettings["DBPassword"]);
            string DIPARTIMENTO = WebConfigurationManager.AppSettings["DBDipartimento"]; ;
            int Esercizio = DateTime.Now.Year;
            DateTime DataContabile = DateTime.Now;
            ConnPool.createConnPool(DNS, Server, Database, User, Password, DIPARTIMENTO, Esercizio, DataContabile, out error, out detail);
        }

        /// <summary>
        /// Connessione al database.
        /// </summary>
        public virtual IEasyDataAccess Connection {
            get {
                return conn;
            }
        }

        /// <summary>
        /// Assistente per la generazione delle query su database.
        /// </summary>
        public virtual QueryHelper QueryHelper {
            get {
                return conn.GetQueryHelper();
            }
        }

        /// <summary>
        /// Assistente per la generazione delle query in memoria.
        /// </summary>
        public virtual CQueryHelper CQueryHelper {
            get {
                if (qhc == null) qhc = new CQueryHelper();
                return qhc;
            }
        }

        /// <summary>
        /// Restituisce un metadato.
        /// </summary>
        /// <param name="name">Nome del metadato.</param>
        /// <returns>Il metadato identificato dal nome fornito oppure un metadato standard.</returns>
        public virtual MetaData GetMeta(string name) {
            if (string.IsNullOrEmpty(name)) return null;


            if (dispatcher == null) {
                dispatcher = new Meta_EasyDispatcher(conn);
            }

            if (isMetaDataPortale(name)){
                return new Meta_Portale((DataAccess)conn, (MetaDataDispatcher)dispatcher, name);
            }

            return dispatcher.Get(name);
        }

        /// <summary>
        /// ritorna true se la tabella tableName  fa parte delle tabelle con MetaDato c# gestito da Portale
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private bool isMetaDataPortale(string tableName)
        {
            if (CacheMDLW.metaDataCache_tablesManaged.ContainsKey(tableName)){
                return true;
            }
            return false;
        }

    }

}
