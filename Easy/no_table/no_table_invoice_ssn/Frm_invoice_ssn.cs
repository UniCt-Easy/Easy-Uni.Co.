
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TesseraSanitaria;

namespace no_table_invoice_ssn {

    public partial class Frm_invoice_ssn : Form {

        private const int SP_TIMEOUT = 10000;
        private const string DT_NAME = "DatiTesseraSanitaria";

        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;

        private Proprietario proprietario;
        private string partitaIVA;

        public Frm_invoice_ssn() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;

            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            DataTable dtLicense = Conn.RUN_SELECT("license", "cf, p_iva", null, null, null, false);
            if (dtLicense == null || dtLicense.Rows.Count == 0) {
                QueryCreator.ShowError(this, "Errore del database.", Conn.LastError);
                return;
            }

            var license = dtLicense.First();
            var codiceFiscale = license.Field<string>("cf");
            partitaIVA = license.Field<string>("p_iva");

            DataTable dtConfig = Conn.RUN_SELECT("uniconfig", "ssn_codregione, ssn_codasl, ssn_codssa", null, null, null, false);
            if (dtConfig == null || dtConfig.Rows.Count == 0) {
                QueryCreator.ShowError(this, "Errore del database.", Conn.LastError);
                return;
            }

            var config = dtConfig.First();
            var codiceRegione = config.Field<string>("ssn_codregione");
            var codiceASL = config.Field<string>("ssn_codasl");
            var codiceSSA = config.Field<string>("ssn_codssa");

            proprietario = new Proprietario() {
                CodiceRegione = codiceRegione,
                CodiceASL = codiceASL,
                CodiceSSA = codiceSSA,
                CodiceFiscale = codiceFiscale
            };
        }

        private void btnEstraiFatture_Click(object sender, EventArgs e) {
            var paramName = new string[] { "ayear", "idsor01", "idsor02", "idsor03", "idsor04", "idsor05" };
            var paramType = new SqlDbType[] { SqlDbType.SmallInt, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
            var paramLength = new int[] { sizeof(short), sizeof(int), sizeof(int), sizeof(int), sizeof(int), sizeof(int) };
            var paramDirection = new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input };
            var paramValues = new object[] { Conn.GetEsercizio(), DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value };

            string errore;

            var exp = Conn.CallSPParameterDataSet("exp_tesserasanitaria", paramName, paramType, paramLength, paramDirection, ref paramValues, SP_TIMEOUT, out errore);
            if (exp == null || exp.Tables.Count == 0) {
                QueryCreator.ShowError(this, "Errore del database.", errore);

                btnInvia.Enabled = false;
            }
            else {
                var dt = exp.Tables[0];
                dt.TableName = DT_NAME;

                DS.Merge(dt);

                foreach (DataColumn dc in dt.Columns) dc.Caption = string.Empty;
                dt.Columns["NumDocumento"].Caption = "Numero documento";
                dt.Columns["dataEmissione"].Caption = "Data emissione";
                dt.Columns["datapagamento"].Caption = "Data pagamento";
                dt.Columns["cf"].Caption = "Codice fiscale";
                dt.Columns["importo"].Caption = "Importo";

                HelpForm.SetDataGrid(gridFatture, dt);

                btnInvia.Enabled = (dt.Rows.Count > 0);
            }
        }

        private void btnInvia_Click(object sender, EventArgs e) {
            var dt = DS.Tables[DT_NAME];
            if (dt == null || dt.Rows.Count == 0) return;

            // Prepara i documenti per l'invio
            var documenti = new Dictionary<InvoiceKey, DocumentoSpesa>();
            foreach (DataRow dr in dt.Rows) {
                var invoiceKey = new InvoiceKey() {
                    idinvkind = dr.Field<int>("idinvkind"),
                    yinv = dr.Field<short>("yinv"),
                    ninv = dr.Field<int>("ninv")
                };

                DocumentoSpesa documento;
                if (!documenti.ContainsKey(invoiceKey)) {
                    documento = new DocumentoSpesa() {
                        CodiceFiscale = dr.Field<string>("cf"),
                        DataPagamento = dr.Field<DateTime>("datapagamento"),
                        PagamentoAnticipato = dr.Field<int>("flagPagamentoAnticipato"),

                        DocumentoFiscale = new DocumentoFiscale() {
                            PartitaIVA = partitaIVA,
                            DataEmissione = dr.Field<DateTime>("dataEmissione"),
                            NumeroDocumentoFiscale = new NumeroDocumentoFiscale() {
                                Dispositivo = dr.Field<int>("dispositivo"),
                                NumeroDocumento = dr.Field<string>("NumDocumento")
                            }
                        },

                        Spesa = new List<VoceSpesa>()
                    };

                    documenti.Add(invoiceKey, documento);
                }
                else {
                    documento = documenti[invoiceKey];
                }

                var spesa = new VoceSpesa() {
                    Importo = dr.Field<double>("importo")
                };

                switch (dr.Field<string>("ssntipospesa")) {
                    case "TK": spesa.TipoSpesa = TipoSpesa.Ticket; break;
                    case "FC": spesa.TipoSpesa = TipoSpesa.Farmaco; break;
                    case "FV": spesa.TipoSpesa = TipoSpesa.FarmacoVeterinario; break;
                    case "AD": spesa.TipoSpesa = TipoSpesa.DispositivoMedico; break;
                    case "AS": spesa.TipoSpesa = TipoSpesa.Servizi; break;
                    case "SR": spesa.TipoSpesa = TipoSpesa.AssistenzaSpecialistica; break;
                    case "CT": spesa.TipoSpesa = TipoSpesa.CureTermali; break;
                    case "PI": spesa.TipoSpesa = TipoSpesa.ProtesicaIntegrativa; break;
                    case "IC": spesa.TipoSpesa = TipoSpesa.ChirurgiaEstetica; break;
                    case "AA": spesa.TipoSpesa = TipoSpesa.Altro; break;
                }

                switch (dr.Field<string>("ssnflagtipospesa")) {
                    case "T": if (spesa.TipoSpesa == TipoSpesa.Ticket) spesa.FlagTipoSpesa = FlagTipoSpesa.ProntoSoccorso; break;
                    case "V": if (spesa.TipoSpesa == TipoSpesa.AssistenzaSpecialistica) spesa.FlagTipoSpesa = FlagTipoSpesa.Intramoenia; break;
                    default: spesa.FlagTipoSpesa = null; break;
                }

                documento.Spesa.Add(spesa);
            }

            // Crea la connessione al servizio web
            string errore;
            var servizio = Servizio.Create(out errore);
            if (servizio == null) {
                QueryCreator.ShowError(this, "Impossibile connettersi al servizio.", errore);
                return;
            }

            // Invia i documenti ed acquisisce il numero di protocollo o gli errori di invio
            var messaggi = new Dictionary<string, List<Messaggio>>();
            var protocolli = new Dictionary<InvoiceKey, string>();
            foreach (var invoiceKey in documenti.Keys) {
                var documento = documenti[invoiceKey];
                try {
                    var body = new InserimentoRequestBody() {
                        Opzionale1 = null,
                        Opzionale2 = null,
                        Opzionale3 = null,
                        PinCode = null,
                        Proprietario = proprietario,
                        DocumentoSpesa = documento
                    };

                    var request = new InserimentoRequest(body);
                    var response = servizio.Inserimento(request);

                    messaggi.Add(documento.DocumentoFiscale.NumeroDocumentoFiscale.NumeroDocumento, response.body.Messaggi);

                    if (response.body.Esito != EsitoChiamata.Completata) continue;

                    protocolli.Add(invoiceKey, response.body.Protocollo);
                }
                catch (Exception ex) {
                    QueryCreator.ShowException(ex);
                }
            }

            // Aggiorna le fatture, aggiungendo il numero di protocollo
            foreach (var invoiceKey in protocolli.Keys) {
                var numeroProtocollo = protocolli[invoiceKey];

                var filter = QHS.AppAnd(
                    QHS.CmpEq("idinvkind", invoiceKey.idinvkind),
                    QHS.CmpEq("yinv", invoiceKey.yinv),
                    QHS.CmpEq("ninv", invoiceKey.ninv)
                );
                Conn.RUN_SELECT_INTO_TABLE(DS.invoice, null, filter, null, false);

                var filterC = QHC.AppAnd(
                    QHC.CmpEq("idinvkind", invoiceKey.idinvkind),
                    QHC.CmpEq("yinv", invoiceKey.yinv),
                    QHC.CmpEq("ninv", invoiceKey.ninv)
                );
                var dr = DS.invoice.First(filterC);
                if (dr == null) continue; // TODO: gestire l'eventualità aggiungendo un errore all'elenco.

                dr.SetField("ssn_nprot", numeroProtocollo);
            }

            // Salva i dati
            var postData = new Easy_PostData();
            postData.InitClass(DS, Conn);
            postData.DO_POST();

            // Visualizza i messaggi ritornati dal servizio
            FrmErrori.Show(this, messaggi);
        }

    }

    class InvoiceKey {
        public int idinvkind { get; set; }
        public short yinv { get; set; }
        public int ninv { get; set; }

        public override int GetHashCode() {
            int hashcode = 23;
            hashcode = (hashcode * 37) + idinvkind;
            hashcode = (hashcode * 37) + yinv;
            hashcode = (hashcode * 37) + ninv;

            return hashcode;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;

            var invoiceKey = obj as InvoiceKey;
            if (invoiceKey == null) return false;

            return
                idinvkind == invoiceKey.idinvkind &&
                yinv == invoiceKey.yinv &&
                ninv == invoiceKey.ninv;
        }
    }

}
