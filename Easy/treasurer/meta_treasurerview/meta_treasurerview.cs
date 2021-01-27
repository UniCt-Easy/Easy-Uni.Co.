
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_treasurerview {//meta_istitutocassiereview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_treasurerview : Meta_easydata {
		public Meta_treasurerview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "treasurerview") {		
			Name= "Tesoriere";
			ListingTypes.Add("lista");
		}
        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "lista") {
                string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        private string[] mykey = new string[] { "idtreasurer", "ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "idtreasurer",".#Cod. Tesoriere",nPos++);
                DescribeAColumn(T, "codetreasurer", "Cod. Tesoriere", nPos++);
                DescribeAColumn(T, "description", "Tesoriere", nPos++);
                DescribeAColumn(T, "treasurerstart", "Saldo iniziale", nPos++);
                DescribeAColumn(T, "currentfloatfund", "Saldo corrente", nPos++);
				DescribeAColumn(T, "banktitle" , "Banca",nPos++);
				DescribeAColumn(T, "cin", "",nPos++);
				DescribeAColumn(T, "idbank", "Cod. ABI",nPos++);
				DescribeAColumn(T, "idcab", "CAB",nPos++);
				DescribeAColumn(T, "cabtitle", "Sportello",nPos++);
				DescribeAColumn(T, "cc", "Conto",nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "bic", "BIC", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
				DescribeAColumn(T, "flagdefault",".Default", nPos++);
				DescribeAColumn(T, "address", ".Indirizzo", nPos++);
				DescribeAColumn(T, "cap", ".Cap", nPos++);
				DescribeAColumn(T, "city", ".Citta", nPos++);
				DescribeAColumn(T, "country", ".Paese", nPos++);
				DescribeAColumn(T, "phoneprefix", ".Prefisso tel.", nPos++);
				DescribeAColumn(T, "phonenumber", ".Numero tel.", nPos++);
				DescribeAColumn(T, "faxprefix", ".Prefisso fax", nPos++);
				DescribeAColumn(T, "faxnumber", ".Numero fax", nPos++);
                DescribeAColumn(T, "departmentname_fe", ".Denominazione F.E.", nPos++);
			}
		}
	}
}
