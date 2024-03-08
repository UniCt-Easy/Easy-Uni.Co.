
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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;


namespace meta_flussocreditidetailview {
    class Meta_flussocreditidetailview :Meta_easydata {
        public Meta_flussocreditidetailview(DataAccess Conn,
                MetaDataDispatcher Dispatcher):
                base(Conn, Dispatcher, "flussocreditidetailview") {
            ListingTypes.Add("default");

        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idflusso desc, iddetail asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }


        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idflusso", "N.Flusso", nPos++);
                DescribeAColumn(T, "iddetail", "N.Dettaglio", nPos++);
                DescribeAColumn(T, "istransmitted", "Trasmesso", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "registry", "Versante", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "codicetassonomia", "Tassonomia PagoPA", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "importoversamento", "importo versamento", nPos++);
                DescribeAColumn(T, "tax", "importo iva", nPos++);
                DescribeAColumn(T, "estimkind_det", "Tipo Contratto Attivo", nPos++);
                DescribeAColumn(T, "yestim", "Eserc.Contratto Attivo", nPos++);
                DescribeAColumn(T, "nestim", "Num.Contratto Attivo", nPos++);
                DescribeAColumn(T, "rownum", "Dett.Contratto Attivo", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo doc.Iva", nPos++);
                DescribeAColumn(T, "yinv", "Eserc.Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num.Fattura", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "upb_iva", "UPB iva", nPos++);
                DescribeAColumn(T, "iduniqueformcode", "Codice Bollettino Univoco", nPos++);
                DescribeAColumn(T, "nform", "Numero Bollettino", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "iuv", "IUV", nPos++);
                DescribeAColumn(T, "annulment", "Data annullamento", nPos++);
                DescribeAColumn(T, "stop", "Data fine validità", nPos++);
                DescribeAColumn(T, "datacreazioneflusso", "data creazione flusso", nPos++);
                DescribeAColumn(T, "causalecredito", "causale credito", nPos++);
                DescribeAColumn(T, "casualeentroanno", "casuale entro anno", nPos++);
                DescribeAColumn(T, "casualepostanno", "casuale post anno", nPos++);
                DescribeAColumn(T, "casualericavo", "casualericavo", nPos++);
                DescribeAColumn(T, "causalebilentrata", "causale bilancio entrata", nPos++);
                DescribeAColumn(T, "causalebilancioentrataiva", "Causale Bilancio di entrata iva", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio Comp.Economica", nPos++);
                DescribeAColumn(T, "competencystop", "Fine Comp.Economica", nPos++);
                DescribeAColumn(T, "codiceavviso", "Codice Avviso", nPos++);
                DescribeAColumn(T, "idunivoco", "Progr.generale tra tutti i dettagli credito", nPos++);
                DescribeAColumn(T, "expirationdate", "Scadenza", nPos++);
                DescribeAColumn(T, "p_iva", "Piva", nPos++);                
                DescribeAColumn(T, "docdate", "Data per elaborazione", nPos++);
                DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
            }
        }


    }
}

