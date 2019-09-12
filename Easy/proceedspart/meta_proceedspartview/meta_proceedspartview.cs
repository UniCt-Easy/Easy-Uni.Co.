/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace meta_proceedspartview//meta_assegnazioneincassiview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_proceedspartview : Meta_easydata {
		public Meta_proceedspartview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedspartview") {		
			Name= "assegnazioni incasso al bilancio";
			ListingTypes.Add("lista");
		}
        private string[] mykey = new string[] { "yproceedspart", "nproceedspart" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetSorting (string ListingType) {
            string sorting;
            if (ListingType == "lista") {
                sorting = "yproceedspart desc, nproceedspart desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
				DescribeAColumn(T, "phase", "Fase",nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "yproceedspart", "Eserc. assegn.", nPos++);
                DescribeAColumn(T, "nproceedspart", "Num. assegn.", nPos++);
                DescribeAColumn(T, "codefin", "Bil. Spesa", nPos++);
                DescribeAColumn(T, "finance", "Denom. bil", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "treasurer", "Cassiere progetto finanziato", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "codeupbincome", "Cod. UPB Entrata", nPos++);
                DescribeAColumn(T, "upbincome", "UPB Entrata", nPos++);
                DescribeAColumn(T, "treasurerproceeds", "Cassiere Reversale", nPos++);
                DescribeAColumn(T, "financeincome", "Bil. Entrata", nPos++);
                DescribeAColumn(T, "allocatedamount", "Importo destinato", nPos++);
                DescribeAColumn(T, "moneytotransfer", "Importo da Girofondare", nPos++);
                DescribeAColumn(T, "moneytransfered", "Importo Girofondato", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
			}
		}
	}
}
