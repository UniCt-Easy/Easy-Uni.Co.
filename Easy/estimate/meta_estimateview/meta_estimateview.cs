
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


using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_estimateview {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_estimateview : Meta_easydata {
        public Meta_estimateview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "meta_estimateview") {
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
            Name = "Contratti attivi";
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idestimkind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".#Tipo Contratto");
                    continue;
                }
                if ((C.ColumnName == "yestim") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio");
                    continue;
                }
                if ((C.ColumnName == "nestim") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Numero");
                    continue;
                }
                if ((C.ColumnName == "estimkind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo Contratto");
                    continue;
                }
                if ((C.ColumnName == "idreg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice Anagrafica");
                    continue;
                }
                if ((C.ColumnName == "registry") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Anagr. Fornitore");
                    continue;
                }
                if ((C.ColumnName == "registryreference") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Rif Cliente");
                    continue;
                }
                if ((C.ColumnName == "description") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Descrizione");
                    continue;
                }
                if ((C.ColumnName == "manager") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Responsabile");
                    continue;
                }
                if ((C.ColumnName == "deliveryexpiration") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Term. Consegna");
                    continue;
                }
                if ((C.ColumnName == "deliveryaddress") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Ind. Consegna");
                    continue;
                }
                if ((C.ColumnName == "paymentexpiring") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Scad. Pagamento");
                    continue;
                }
                if ((C.ColumnName == "codecurrency") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Valuta");
                    continue;
                }
                if ((C.ColumnName == "currency") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Valuta");
                    continue;
                }

                if ((C.ColumnName == "exchangerate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tasso di Cambio");
                    continue;
                }
                if ((C.ColumnName == "doc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Doc Collegato");
                    continue;
                }
                if ((C.ColumnName == "docdate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Doc. Collegato");
                    continue;
                }
                if ((C.ColumnName == "adate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Contabile");
                    continue;
                }
                if ((C.ColumnName == "officiallyprinted") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Stampa Ufficiale");
                    continue;
                }
                if ((C.ColumnName == "txt") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Appunti");
                    continue;
                }
                if ((C.ColumnName == "taxable_euro") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Imponibile EUR");
                    continue;
                }
                if ((C.ColumnName == "iva_euro") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Iva EUR");
                    continue;
                }
                if ((C.ColumnName == "total") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Totale");
                    continue;
                }
                if ((C.ColumnName == "active") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Uilizzabile");
                    continue;
                }
                if ((C.ColumnName == "flagintracom") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo Contratto Intracom");
                    continue;
                }
                if ((C.ColumnName == "codemotivecredit") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Causale Credito");
                    continue;
                }
                if ((C.ColumnName == "codemotivecredit_crg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Causale Credito Aggiornata");
                    continue;
                }
                if ((C.ColumnName == "idaccmotivecredit_datacrg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Correz. Causale Credito");
                    continue;
                }
                if ((C.ColumnName == "applierannotations") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Note del Richiedente");
                    continue;
                }
                if ((C.ColumnName == "underwriting") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Finanziamento");
                    continue;
                }
                if ((C.ColumnName == "cigcode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod CIG");
                    continue;
                }
            }
        }
        private string[] mykey = new string[] { "idestimkind", "yestim", "nestim" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "estimkind", "Tipo Contratto attivo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "registry", "Cliente", nPos++);
                DescribeAColumn(T, "registryreference", "Rif. Cliente.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "taxable_euro", "Tot. Imponibile", nPos++);
                DescribeAColumn(T, "iva_euro", "Tot. IVA", nPos++);
                DescribeAColumn(T, "total", "Totale", nPos++);
                DescribeAColumn(T, "deliveryexpiration", "Term. cons.", nPos++);
                DescribeAColumn(T, "deliveryaddress", "Ind. cons.", nPos++);
                DescribeAColumn(T, "expirationkind", "Tipo scadenza", nPos++);
                DescribeAColumn(T, "paymentexpiring", "giorni scad.", nPos++);
                //DescribeAColumn(T, "idexpirationkind", "Tipo scad.", nPos++);
                DescribeAColumn(T, "expiration", "Scadenza", nPos++);
                DescribeAColumn(T, "currency", "Valuta", nPos++);
                DescribeAColumn(T, "exchangerate", "Cambio", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "adate", "Data reg.", nPos++);
                DescribeAColumn(T, "officiallyprinted", "Flag stampa", nPos++);
                DescribeAColumn(T, "active", "Utilizzabile", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                CompletaCaption(T);
            }
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "estimkind", "Tipo Contratto Attivo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "registry", "Cliente", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Utilizzabile", nPos++);
                CompletaCaption(T);
            }
        }
    }
}
