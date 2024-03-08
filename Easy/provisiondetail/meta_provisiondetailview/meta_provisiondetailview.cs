
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_provisiondetailview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_provisiondetailview : Meta_easydata {
		public Meta_provisiondetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "provisiondetailview") {		
			Name= "Dettaglio fondo di accantonamento";
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "idprovision", "rownum" };
        public override string[] primaryKey() {
            return mykey;
        }


        public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType== "default") {
				foreach(DataColumn C in T.Columns){
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "idprovision", "Num. Fondo", nPos++);
                DescribeAColumn(T, "provisiontitle", "Denominazione Fondo", nPos++);
                DescribeAColumn(T, "ydetail", "Esercizio", nPos++);
                DescribeAColumn(T, "rownum", "Num. Dettaglio", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione Dettaglio", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data Cont. Dettaglio", nPos++);  
                DescribeAColumn(T, "description", "Descrizione Fondo", nPos++);
                DescribeAColumn(T, "registry", "Denom. anagr.", nPos++);
                DescribeAColumn(T, "codemotive", "Cod. Causale di Costo", nPos++);
                DescribeAColumn(T, "accmotive", "Causale di Costo", nPos++);
                DescribeAColumn(T, "codemotive_patrim", "Cod. Causale Stato Patrimoniale", nPos++);
                DescribeAColumn(T, "accmotive_patrim", "Causale Stato Patrimoniale", nPos++);
            }
 
        }

    }
}
