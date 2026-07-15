/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using RestSharp;

using metadatalibrary;

using afiprotfat_unict.Models;
using afiprotfat_unict.Exceptions;

namespace afiprotfat_unict.Client {

    public class Client : IClient {

        private readonly IDataAccess _dbConnection;

        private readonly Uri _endpoint;

        private readonly string _channel;
        private readonly string _operatorId;

        private readonly Lazy<Dictionary<int, string>> _invoicekindCache = new Lazy<Dictionary<int, string>>();
        private readonly Lazy<Dictionary<int, string>> _invoicettachmentkindCache = new Lazy<Dictionary<int, string>>();

        private readonly RestClient _restClient;

        public Client(IDataAccess dbConnection, string operatorId, Uri endpoint, string channel) {

            _dbConnection = dbConnection ?? throw new ArgumentException(nameof(dbConnection));

            _endpoint = endpoint;

            _channel = !string.IsNullOrWhiteSpace(channel) ? channel : throw new ArgumentException(nameof(channel));
            _operatorId = !string.IsNullOrWhiteSpace(operatorId) ? operatorId : throw new ArgumentException(nameof(operatorId));

            _invoicekindCache = new Lazy<Dictionary<int, string>>(() => _dbConnection.RUN_SELECT("invoicekind", "*", null, null, null, false)
                .AsEnumerable()
                .Where(row => row["active"].ToString().ToLowerInvariant() == "s")
                .ToDictionary(row => (int)row["idinvkind"], row => row["description"].ToString()));
            _invoicettachmentkindCache = new Lazy<Dictionary<int, string>>(() => _dbConnection.RUN_SELECT("invoiceattachmentkind", "*", null, null, null, false)
                .AsEnumerable()
                .Where(row => row["active"].ToString().ToLowerInvariant() == "s")
                .ToDictionary(row => (int)row["idachmentkind"], row => row["title"].ToString()));

            _restClient = new RestClient(_endpoint);
            _dbConnection.Open();
        }

        public Client(IDataAccess dbConnection, Config cfg) : this(
            dbConnection,
            cfg?.Operator,
            cfg?.Endpoint,
            cfg?.Channel) {
        }

        private string GetAttachmentFromRow(IDataAccess conn, DataRow Curr, string tableName)
        {
            if (Curr["attachment"] == DBNull.Value && Curr["idfilestorage"] == DBNull.Value)
                return string.Empty;

            // File preso dall'attachment o dal MongoDb
            byte[] ByteArray = { };

            if (Curr["attachment"] != DBNull.Value)
            {
                // Attachment
                ByteArray = (byte[])Curr["attachment"];
            }
            else
            {
                // MongoDb
                ByteArray = metaeasylibrary.HttpFileStorage.DownloadFile(conn, tableName, Curr["idfilestorage"].ToString()).GetAwaiter().GetResult();
                if (ByteArray == null)
                    return string.Empty;
            }

            return Convert.ToBase64String(ByteArray);
        }

        public string Protocollo(
            InvoiceParameters invoice,
            RegistryParameters registry,
            string address,
            IEnumerable<DataRow> invoiceattachments,
            string officeId) {

            DatiFatt body;

            try {
                body = new DatiFatt() {
                    Attach = invoiceattachments.Select(attachmentRow => new Attach() {
                        Base64 = GetAttachmentFromRow(this._dbConnection, attachmentRow, attachmentRow.Table.TableName),// Convert.ToBase64String((byte[])attachmentRow["attachment"]) ?? string.Empty,
                        Nome = attachmentRow["filename"].ToString() ?? string.Join("_", _invoicettachmentkindCache.Value.TryGetValue((int)attachmentRow["idattachmentkind"], out var title) ? title.ToString() : string.Empty, Guid.NewGuid().ToString()),
                    }).ToList(),
                    CFOper = _operatorId,
                    DataProt = invoice.docdate.ToString(),
                    Indirizzo = address,
                    Mezzo = _channel,
                    Oggetto = string.Join(", ", _invoicekindCache.Value.TryGetValue(invoice.idinvkind, out string description) ? description : string.Empty, invoice.yinv, invoice.ninv),
                    PartitaIva = registry.p_iva ?? registry.foreigncf ?? throw new InvalidDataException("Identificativo fiscale mancante"),
                    RagSoc = registry.title,
                    //Tipo = 0
                    UOR = officeId,
                };
            }
            catch (Exception e) {

                throw new RequestBuildingException($"Impossibile formare la richiesta di protocollazione: {e.Message}", e);
            }

            RestRequest request = new RestRequest("protocollo", Method.POST);
            request.AddJsonBody(body);

            IRestResponse<ProtResponse> response;

            try {
                response = _restClient.Execute<ProtResponse>(request);
            }
            catch (Exception e) {

                throw new ResponseDeserializationException("Risposta del servizio di protocollazione non valida", e);
            }

            if (response.ResponseStatus != ResponseStatus.Completed) {

                throw new CommunicationException($"Comunicazione con il servizio di protocollazione non completata ({response.ResponseStatus})");
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK) {

                throw new ServerException($"Errore sulla comunicazione con il servizio di protocollazione ({response.StatusCode})", new Exception(response.Content));
            }

            if (response.Data.Status != true) {

                throw new ServerException($"Errore sul servizio di protocollazione: {response.Data.Message}");
            }

            return response.Data.NumProt;
        }

        public void Dispose() {
            _dbConnection?.Close();
        }
    }
}
