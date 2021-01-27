
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


using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_incomesortedview {//meta_impclassentrataview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_incomesortedview : Meta_easydata {
		public Meta_incomesortedview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomesortedview") {		
			Name= "Imputazioni mov. entrata";
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType.StartsWith("lista.")) {
				string [] splittedlistingtype = ListingType.Split(".".ToCharArray());
				string codicetipoclass = splittedlistingtype[1];
				DataTable TipoClassMov = Conn.RUN_SELECT("sortingkind","*",null,"(idsorkind="+
					QueryCreator.quotedstrvalue(codicetipoclass, true)+")",
					null, true);
				if (TipoClassMov.Rows.Count!=1) return;
				DataRow CaptionsRow=TipoClassMov.Rows[0];
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;

                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "sortcode", "Cod. class.", nPos++);
                DescribeAColumn(T, "sorting", "Descr. class.", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "npro", "N.Reversale", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "codefin", "Codice bilancio", nPos++);
                DescribeAColumn(T, "finance", "Bilancio", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                DescribeAColumn(T, "registry", "Versante", nPos++);
                DescribeAColumn(T, "flagarrear", "Comp./Res.", nPos++);
                DescribeAColumn(T, "incomedescr", "Movimento", nPos++);
                DescribeAColumn(T, "yproceedstransmission", "Eserc. Elenco. Trasmissione", nPos++);
                DescribeAColumn(T, "nproceedstransmission", "Num. Elenco. Trasmissione", nPos++);
                DescribeAColumn(T, "valuen1", CaptionsRow["labeln1"].ToString(), nPos++);
                DescribeAColumn(T, "valuen2", CaptionsRow["labeln2"].ToString(), nPos++);
				DescribeAColumn(T, "valuen3", CaptionsRow["labeln3"].ToString(), nPos++);
                DescribeAColumn(T, "valuen4", CaptionsRow["labeln4"].ToString(), nPos++);
                DescribeAColumn(T, "valuen5", CaptionsRow["labeln5"].ToString(), nPos++);
                DescribeAColumn(T, "values1", CaptionsRow["labels1"].ToString(), nPos++);
                DescribeAColumn(T, "values2", CaptionsRow["labels2"].ToString(), nPos++);
                DescribeAColumn(T, "values3", CaptionsRow["labels3"].ToString(), nPos++);
                DescribeAColumn(T, "values4", CaptionsRow["labels4"].ToString(), nPos++);
                DescribeAColumn(T, "values5", CaptionsRow["labels5"].ToString(), nPos++);
			}
		}
	}
}
