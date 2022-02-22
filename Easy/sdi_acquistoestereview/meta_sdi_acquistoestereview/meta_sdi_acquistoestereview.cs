
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


using System;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_sdi_acquistoestereview {
    public class Meta_sdi_acquistoestereview : Meta_easydata {
        public Meta_sdi_acquistoestereview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sdi_acquistoestereview") {
            ListingTypes.Add("default");
        }


        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "idsdi_acquistoestere DESC";
            }
            return base.GetSorting(ListingType);
        }
        private string[] mykey = new string[] { "idsdi_acquistoestere" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idsdi_acquistoestere", "Num.File", nPos++);
                DescribeAColumn(T, "filename", "Nome File", nPos++);
                DescribeAColumn(T, "zipfilename", "Nome File Compresso", nPos++);
                DescribeAColumn(T, "adate", "data contabile", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo Doc. Iva", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Doc. Iva", nPos++);
                DescribeAColumn(T, "ninv", "Num. Doc. Iva", nPos++);
                DescribeAColumn(T, "invoicedocdate", "Data emissione", nPos++);
                DescribeAColumn(T, "identificativo_sdi", "Identificativo SdI", nPos++);
                DescribeAColumn(T, "sdi_status", "Stato", nPos++);
                DescribeAColumn(T, "sdi_deliverystatus", "Stato trasmissione", nPos++);
                DescribeAColumn(T, "issigned", "Firmato", nPos++);
                DescribeAColumn(T, "exist_ns", "Notifica di scarto", nPos++);
                DescribeAColumn(T, "ns_prot", "N.Prot.Notifica di scarto", nPos++);
                DescribeAColumn(T, "exist_mc", "Notifica di mancata consegna", nPos++);
                DescribeAColumn(T, "mc_prot", "N.Prot.Notifica di mancata consegna", nPos++);
                DescribeAColumn(T, "exist_rc", "Ricevuta di consegna", nPos++);
                DescribeAColumn(T, "rc_prot", "N.Prot.Ricevuta di consegna", nPos++);
                DescribeAColumn(T, "exist_ne", "Notifica esito cedente", nPos++);
                DescribeAColumn(T, "ne_prot", "N.Prot.Notifica esito cedente", nPos++);
                DescribeAColumn(T, "exist_dt", "Notifica decorrenza termini", nPos++);
                DescribeAColumn(T, "dt_prot", "N.Prot.Notifica decorrenza termini", nPos++);
                DescribeAColumn(T, "exist_at", "Attestazione di avvenuta trasm.al SdI con impossibilità di recapito", nPos++);
                DescribeAColumn(T, "at_prot", "N.Prot.Attestazione di trasm.al SdI con impossibilità di recapito", nPos++);
            }

        }

    }
}

