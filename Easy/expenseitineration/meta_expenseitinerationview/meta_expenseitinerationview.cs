/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;


namespace meta_expenseitinerationview {//meta_missionemovspesaview//
	/// <summary>
	/// Summary description for missionemovspesaview.
	/// </summary>
	public class Meta_expenseitinerationview : Meta_easydata {
		public Meta_expenseitinerationview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expenseitinerationview") {
			ListingTypes.Add("default");
            Name = "Missione - Mov. Spesa";
		}
        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "default") {
                filteresercizio = "(ayear='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        private string[] mykey = new string[] { "ayear", "iditineration", "idexp" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
                DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. movimento.", nPos++);
                DescribeAColumn(T, "nmov", "Num. movimento", nPos++);
                DescribeAColumn(T, "movkind", "Tipo movimento", nPos++);
                DescribeAColumn(T, "codefin", "Cod. Bil.", nPos++);
                DescribeAColumn(T, "finance", "Denom. Bil.", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "Denom. U.P.B.", nPos++);
                DescribeAColumn(T, "idexp", ".idexp", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "ypay", "Eserc.Mand.", nPos++);
                DescribeAColumn(T, "npay", "Num.Mand.", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo Originale", nPos++);
                DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", nPos++);
                DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
                DescribeAColumn(T, "available", "Disponibile", nPos++);
                DescribeAColumn(T, "idpaymethod", ".Codice Mod.Pag.", nPos++);
                DescribeAColumn(T, "cin", ".Cin", nPos++);
                DescribeAColumn(T, "idbank", ".Cod.ABI", nPos++);
                DescribeAColumn(T, "idcab", ".CAB", nPos++);
                DescribeAColumn(T, "cc", ".Conto", nPos++);
                DescribeAColumn(T, "paymentdescr", ".Desc.Pag.", nPos++);
                DescribeAColumn(T, "codser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", ".Prestazione", nPos++);
                DescribeAColumn(T, "servicestart", ".Data Inizio Prest.", nPos++);
                DescribeAColumn(T, "servicestop", ".Data Fine Prest.", nPos++);
                DescribeAColumn(T, "ivaamount", ".Iva", nPos++);
                DescribeAColumn(T, "autokind", ".Tipo Auto", nPos++);
                DescribeAColumn(T, "flagarrear", ".Competenza", nPos++);
                DescribeAColumn(T, "expiration", ".Data Scadenza", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);
			}
		}   
	}
}