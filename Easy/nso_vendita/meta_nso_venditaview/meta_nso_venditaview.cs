
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


using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_nso_venditaview {
    public class Meta_nso_venditaview : Meta_easydata {
        public Meta_nso_venditaview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "nso_venditaview") {
            ListingTypes.Add("default");
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "idnso_vendita DESC";
            }
            return base.GetSorting(ListingType);
        }
        private string[] mykey = new string[] { "idnso_vendita" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "buyer_name", "Cliente", nPos++);
                DescribeAColumn(T, "protocoldate", "Data Ricezione", nPos++);
                DescribeAColumn(T, "adate", "Data Emissione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "codice_ipa", "codice IPA", nPos++);
                DescribeAColumn(T, "ipa", "IPA", nPos++);
                DescribeAColumn(T, "riferimento_amministrazione", "Riferimento amministrazione", nPos++);
                DescribeAColumn(T, "NSO_status", "Stato", nPos++);
                DescribeAColumn(T, "total", "Importo Totale Ordine", nPos++);
                DescribeAColumn(T, "tax_total", "Totale Tasse Ordine", nPos++);
                DescribeAColumn(T, "arrivalprotocolnum", "Num. Protocollo entrata", nPos++);
                DescribeAColumn(T, "filename", "Nome File", nPos++);
                DescribeAColumn(T, "zipfilename", "Nome File Compresso", nPos++);
                DescribeAColumn(T, "idnso_vendita", "Num.File", nPos++);
                DescribeAColumn(T, "utente_rifiutata", "Utente rifiuto", nPos++);
                DescribeAColumn(T, "data_rifiutata", "Data rifiuto", nPos++);
                DescribeAColumn(T, "rejectreason", "Annotazioni su rifiuto o accettazione", nPos++);
                DescribeAColumn(T, "utente_accettata", "Utente accettazione", nPos++);
                DescribeAColumn(T, "data_accettata", "Data accettazione", nPos++);
                DescribeAColumn(T, "existsestimate", "Ordine creato in contabilità", nPos++);
                DescribeAColumn(T, "tipodocumento", "Tipo Documento NSO", nPos++);
                DescribeAColumn(T, "data_ricezione", "Data Ricezione NSO", nPos++);
                DescribeAColumn(T, "idsdi_status", ".id stato", -1);
                DescribeAColumn(T, "flag_unseen", ".flag a bit", -1);
                DescribeAColumn(T, "exist_se", ".Scarto esito non visto", -1);
                DescribeAColumn(T, "exist_mt", ".Metadati non visto", -1);
                DescribeAColumn(T, "exist_ec", ".Esito committente non visto", -1);
                DescribeAColumn(T, "exist_dt", ".Decorrenza termini non visto", -1);
                DescribeAColumn(T, "ec_sent", ".esito committente inviato", -1);
                DescribeAColumn(T, "ec_number", ".Numero progressivo per trasm. esito", -1);
            }
        }
    }
}
