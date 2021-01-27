
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


namespace meta_upbview {
	/// <summary>
	/// Summary description for Meta_upbview.
	/// </summary>
	public class Meta_upbview : Meta_easydata {
		public Meta_upbview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "upbview"){
			ListingTypes.Add("default");
		}


//		public override void DescribeColumns(DataTable T, string ListingType) {
//			base.DescribeColumns(T, ListingType);
//      Questo listing type si riferisce alla vecchia struttura della vista upbview
//			if (ListingType=="default")	{
//				foreach (DataColumn C in T.Columns)
//					DescribeAColumn(T, C.ColumnName, "",-1);
//				int nPos = 1;
//				DescribeAColumn(T,"codeupb","Codice",nPos++);
//				DescribeAColumn(T,"title","Denominazione",nPos++);
//				DescribeAColumn(T,"manager","Responsabile",nPos++);
//				DescribeAColumn(T,"requested","Fin.Richiesto",nPos++);
//				DescribeAColumn(T,"granted","Fin.Concesso",nPos++);
//				DescribeAColumn(T,"previousappropriation","Tot. impegnato Pregresso",nPos++);
//				DescribeAColumn(T,"previousassessment","Tot. accertato Pregresso",nPos++);
//				DescribeAColumn(T,"codefin","Codice Bilancio",nPos++);
//				DescribeAColumn(T,"fin","Denominazione Bilancio",nPos++);
//				DescribeAColumn(T,"finpart","Parte Bilancio",nPos++);
//				DescribeAColumn(T,"expiration","Scadenza",nPos++);
//				DescribeAColumn(T,"active","Attivo",nPos++);
//			}
//		}
        public override string GetSorting(string ListingType) {
            if (ListingType == "default") return "printingorder asc";
            return base.GetSorting(ListingType);
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")	{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T,"codeupb","Codice",nPos++);
				DescribeAColumn(T,"title","Denominazione",nPos++);
				DescribeAColumn(T,"manager","Responsabile",nPos++);
				DescribeAColumn(T,"underwriter","Ente Finanziatore",nPos++);
				DescribeAColumn(T,"expiration","Scadenza",nPos++);
				DescribeAColumn(T,"cupcode", "Codice Unico di Progetto", nPos++);
                DescribeAColumn(T,"active", "U.P.B. Attivo", nPos++);
                DescribeAColumn(T, "codetreasurer", "Codice Cassiere", nPos++);
                DescribeAColumn(T, "cofogmpcode", "Codice Cofog", nPos++);
				DescribeAColumn(T, "uesiopecode", "Codice UE", nPos++);
				DescribeAColumn(T, "codeupb_capofila", "Codice UPB capogruppo", nPos++);
				DescribeAColumn(T, "upb_capofila", "UPB capogruppo", nPos++);
			}
		}
        string[] mykey = new string[] { "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }

    }
}
