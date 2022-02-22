
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


using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.CommonBackend;
using Backend.Extensions;
using metadatalibrary;
using metaeasylibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using progettocosto_functions;
using System.Diagnostics;
using System.Security;
using System.Web.Configuration;
using Backend.Components;

namespace Backend.Controllers {



    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("segreterie"), Authorize, EnableCors("*", "*", "*")]
    public class SegreterieController : ApiController {


        public class protcollaPrms {
            public string dsProtocolloSeg { get; set; }
            public string tableName { get; set; }

        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("protocolla")]
        public IHttpActionResult protocolla(protcollaPrms prms) {
            var dispatcher = HttpContext.Current.getDataDispatcher();

            string tProtocollo = "protocollo";
            string editType = "seg";
            string protnumeroField = "protnumero";
            string protannoField = "protanno";
            string dataannullamentoField = "dataannullamento";

            var ds = prms.dsProtocolloSeg;
            var tableName = prms.tableName;

            int protnumero = getProtNumber();
            int protanno = getProtAnno();
            DataSet myds = DataSetSerializer.deserialize(JObject.Parse(ds), dispatcher);
            // protocollo potrebbe avere 2 righe, prendo quelal in stato added, la'ltra potrebbe essere quelal da nullificare
            foreach (DataRow r in myds.Tables[tProtocollo].Rows) {
                if (r.RowState == DataRowState.Added && r[dataannullamentoField] == DBNull.Value) {
                    myds.Tables[tProtocollo].Rows[0][protnumeroField] = protnumero;
                    myds.Tables[tProtocollo].Rows[0][protannoField] = protanno;
                }
            }

            // salvo su tabella referenziata
            myds.Tables[tableName].Rows[0][protnumeroField] = protnumero;
            myds.Tables[tableName].Rows[0][protannoField] = protanno;

            // sul meta della tab principale invocherò la post
            var outDs = DataUtils.createEmptyDataSet(tProtocollo, editType);
            // 4. Travasa i dati del ds proveninte dal client, su quello appena generato del server
            foreach (DataTable table in outDs.Tables) {
                // solo se ovviamente la tabella esiste
                DataTable dtInput = myds.Tables[table.TableName];
                if (dtInput != null) {
                    // merge preservando lo stato delle righe
                    table.Merge(dtInput, true);
                    // copio le prop di autoincremento
                    RowChange.CopyAutoIncrementProperties(dtInput, table);
                }
            }

            var meta = dispatcher.GetMeta(tProtocollo);
            var postData = meta.Get_PostData();
            postData.initClass(outDs, dispatcher.Connection);

            //salva i dati ed ottiene un eventuale elenco di messaggi
            ProcedureMessageCollection myMessages = postData.DO_POST_SERVICE();
            var success = myMessages.Count == 0;
            var canIgnore = success;
            var dsSerialized = DataUtils.dataSetToJSon(outDs);
            var messagesSerialized = DataSetSerializer.serializeMessages(myMessages);
            // costrusico risposta da mandare al client con il ds e i messaggi eventuali più altre info utili
            var result = DataUtils.getJsonSaveDataSetAnswer(dsSerialized, messagesSerialized, success, canIgnore);

            //invio risposta al client
            return Content(HttpStatusCode.OK, result);
        }

        private int getProtNumber() {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            var conn = dispatcher.conn;
            string query = "select max(protnumero) from protocollo";
            DataTable dtPaged = conn.SQLRunner(query);
            DataRow dtrow = dtPaged.Rows[0];
            return dtrow[0] == DBNull.Value ? 1 : (int) dtrow[0] + 1;
        }

        private int getProtAnno() {
            return DateTime.Now.Year;
        }


    }

}
