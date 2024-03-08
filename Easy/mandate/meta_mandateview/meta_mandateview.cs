
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

namespace meta_mandateview {//meta_ordinegenericoview//
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_mandateview : Meta_easydata {
        public Meta_mandateview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "mandateview") {
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
            ListingTypes.Add("webdefault");
            ListingTypes.Add("webdefaultstatuses");
            Name = "ordini";
        }
        private string[] mykey = new string[] { "idmankind", "yman", "nman","idmankind_dest","yman_dest","nman_dest" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "webdefault") {
                sorting = "idmankind asc, yman desc, nman asc";
                return sorting;
            }
            if (ListingType == "webdefaultstatuses") {
                sorting = "listingorder asc,idmankind asc,yman desc, nman asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idmankind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".#Tipo Contratto");
                    continue;
                }
                if ((C.ColumnName == "yman") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio");
                    continue;
                }
                if ((C.ColumnName == "mankind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo Contratto");
                    continue;
                }
                if ((C.ColumnName == "idreg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".esercizio mov");
                    continue;
                }
                if ((C.ColumnName == "registry") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Anagr. Fornitore");
                    continue;
                }
                if ((C.ColumnName == "registryreference") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Rif Fornitore");
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
                if ((C.ColumnName == "codemotivedebit") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Causale Debito");
                    continue;
                }
                if ((C.ColumnName == "codemotivedebit_crg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Causale Debito Aggiornata");
                    continue;
                }
                if ((C.ColumnName == "idaccmotivedebit_datacrg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Correz. Causale Debito");
                    continue;
                }
                if ((C.ColumnName == "applierannotations") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Note del Richiedente");
                    continue;
                }
                if ((C.ColumnName == "mandatestatus") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Stato Ordine");
                    continue;
                }
                if ((C.ColumnName == "store") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Magazzino");
                    continue;
                }

                if ((C.ColumnName == "linkedtotal") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tot. contabilizzato");
                    continue;
                }
                if ((C.ColumnName == "isrequest") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Richiesta");
                    continue;
                }
                if ((C.ColumnName == "cigcode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod CIG");
                    continue;
                }

                if ((C.ColumnName == "flagdanger") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Materiale Pericoloso o Radioattivo");
                    continue;
                }
                if ((C.ColumnName == "mankind_dest") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo contratto approvato");
                    continue;
                }
                if ((C.ColumnName == "mankind_origin") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo richiesta");
                    continue;
                }
                if ((C.ColumnName == "yman_dest") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Anno contr.approvato");
                    continue;
                }
                if ((C.ColumnName == "yman_origin") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Anno richiesta");
                    continue;
                }
                if ((C.ColumnName == "nman_dest") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N. contr. approvato");
                    continue;
                }
                if ((C.ColumnName == "nman_origin") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N. richiesta");
                    continue;
                }
            }
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type == "lista") {
                impostaCampi(R, list_type);
                }
            }

        private void impostaCampi(DataRow R, string listingtype) {
            if (listingtype != "lista") return;
            if (R["flagtenderresult"] == DBNull.Value) return;
 
            string flagtenderresult = R["flagtenderresult"].ToString();
          
            if (flagtenderresult == "A") R["!tenderresult"] = "Aggiudicata";
            if (flagtenderresult == "D") R["!tenderresult"] = "Andata deserta"; ;
            if (flagtenderresult == "N") R["!tenderresult"] = "Senza esito per offerte non congrue";
  
            }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idmankind", "Tipo Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                DescribeAColumn(T, "mandatestatus", "Stato", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "registryreference", "Rif. fornit.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "taxable_euro", "Tot. Imponibile", nPos++);
                DescribeAColumn(T, "iva_euro", "Tot. IVA", nPos++);
                DescribeAColumn(T, "total", "Totale", nPos++);
                DescribeAColumn(T, "deliveryexpiration", "Term. cons.", nPos++);
                DescribeAColumn(T, "deliveryaddress", "Ind. cons.", nPos++);
                DescribeAColumn(T, "expirationkind", "Tipo scad.", nPos++);
                DescribeAColumn(T, "paymentexpiring", "giorni scad.", nPos++);
                DescribeAColumn(T, "expiration", "Scadenza", nPos++);
                DescribeAColumn(T, "expensekinddescription", "Natura spesa", nPos++);                

                DescribeAColumn(T, "currency", "Valuta", nPos++);
                DescribeAColumn(T, "exchangerate", "Cambio", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "adate", "Data reg.", nPos++);
                DescribeAColumn(T, "officiallyprinted", "Flag stampa", nPos++);
                DescribeAColumn(T, "active", "utilizzabile", nPos++);
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
                DescribeAColumn(T, "flagdanger", "Materiale pericoloso", nPos++);
                DescribeAColumn(T, "subappropriation", "Prenotazione", nPos++);
                DescribeAColumn(T, "adatesubappropriation", "Data Imputazione", nPos++);
                DescribeAColumn(T, "finsubappropriation", "Imputazione", nPos++);
                DescribeAColumn(T, "mankind_origin", "Tipo Richiesta", nPos++);
                DescribeAColumn(T, "yman_origin", "Anno richiesta", nPos++);
                DescribeAColumn(T, "nman_origin", "Numero richiesta", nPos++);
                DescribeAColumn(T, "iduniqueregister", "Prog.Registro Unico", nPos++);
                DescribeAColumn(T, "mepanumber", "Num.Ordine MEPA", nPos++);
                DescribeAColumn(T, "consipkind", "Opzione CONSIP", nPos++);
                DescribeAColumn(T, "consipkind_ext", "Opzione Adesione MEPA", nPos++);
                DescribeAColumn(T, "tenderresult", "Esito Gara", nPos++);
                DescribeAColumn(T, "motiveassignment", "Motivazione Affidamento", nPos++);
                DescribeAColumn(T, "anacreduced", "% Ribasso", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["anacreduced"], "p");
                DescribeAColumn(T, "rupanac", "Resp. Unico di Progetto ANAC", nPos++);
   
 
            }
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "mankind", "Tipo Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);

                DescribeAColumn(T, "mankind_origin", "Tipo Richiesta", nPos++);
                DescribeAColumn(T, "yman_origin", "Anno richiesta", nPos++);
                DescribeAColumn(T, "nman_origin", "Numero richiesta", nPos++); 
                DescribeAColumn(T, "active", "utilizzabile", nPos++);

                CompletaCaption(T);
            }

            if (listtype == "webdefault") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "statusimage", "Stato", nPos++);
                DescribeAColumn(T, "mankind", "Tipo Richiesta", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                //DescribeAColumn(T, "linkedtotal", "Totale Contabilizzato", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "utilizzabile", nPos++);
                DescribeAColumn(T, "mankind_dest", "Tipo Contratto", nPos++);
                DescribeAColumn(T, "yman_dest", "Esercizio", nPos++);
                DescribeAColumn(T, "nman_dest", "Numero", nPos++);

                CompletaCaption(T);
            }

            if (listtype == "webdefaultstatuses") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "statusimage", "Stato", nPos++);
                DescribeAColumn(T, "mankind", "Tipo Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                //DescribeAColumn(T, "linkedtotal", "Totale Contabilizzato", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "mankind_dest", "Tipo Contratto", nPos++);
                DescribeAColumn(T, "yman_dest", "Esercizio", nPos++);
                DescribeAColumn(T, "nman_dest", "Numero", nPos++);
                DescribeAColumn(T, "active", "utilizzabile", nPos++);
                CompletaCaption(T);
            }

        }
    }
}
