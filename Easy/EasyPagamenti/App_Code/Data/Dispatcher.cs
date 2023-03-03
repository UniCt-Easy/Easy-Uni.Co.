
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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

namespace EasyPagamenti.Data {

    /// <summary>
    /// Il dispatcher dei dati.
    /// </summary>
    public class Dispatcher :IDisposable {

        private const string DIPARTIMENTO = "amm";//"amministrazione";//"amm";

        private Easy_DataAccess conn;
        private Meta_EasyDispatcher dispatcher;
        private CQueryHelper qhc;

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
        public Dispatcher(string DSN, string Server, string Database, string User, string Password, int Esercizio, DateTime DataContabile) {
            string error;
            string detail;

            conn = Easy_DataAccess.getEasyDataAccess(DSN, Server, Database, User, Password, DIPARTIMENTO, Esercizio, DataContabile, out error, out detail);
        }

        /// <summary>
        /// Distrugge il dispatcher.
        /// </summary>
        public void Dispose() {
            if (conn == null) return;
            conn.Close();
            conn.Destroy();

            qhc = null;
            dispatcher = null;
            conn = null;
        }

        /// <summary>
        /// Connessione al database.
        /// </summary>
        public Easy_DataAccess Connection {
            get {
                return conn;
            }
        }

        /// <summary>
        /// Assistente per la generazione delle query su database.
        /// </summary>
        public QueryHelper QueryHelper {
            get {
                return conn.GetQueryHelper();
            }
        }

        /// <summary>
        /// Assistente per la generazione delle query in memoria.
        /// </summary>
        public CQueryHelper CQueryHelper {
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
        public MetaData GetMeta(string name) {
            if (string.IsNullOrEmpty(name)) return null;

            if (dispatcher == null) {
                dispatcher = new Meta_EasyDispatcher(conn);
            }

            return dispatcher.Get(name);
        }

    }
}

