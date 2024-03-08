
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
//Pino: using dettagliorecuperi; diventato inutile

namespace meta_expenseclawback//meta_dettagliorecuperi//
{
	/// <summary>
	/// MetaData for spesa
	/// </summary>
	public class Meta_expenseclawback : Meta_easydata 
	{
		public Meta_expenseclawback(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expenseclawback") 
		{		
			Name = "Dettaglio Recuperi";
			EditTypes.Add("default");
			ListingTypes.Add("lista");
            ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") return MetaData.GetFormByDllName("expenseclawback_default");//PinoRana
			return null;
		}			

		public override void DescribeColumns(DataTable T, string ListingType) 
		{			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") 
			{
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idclawback", ".#", nPos++);
                DescribeAColumn(T, "!clawbackref", "Codice", "clawback.clawbackref", nPos++);
                DescribeAColumn(T, "!descrizione", "Descrizione", "clawback.description", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!desctiporiga", "Sezione", "lookup_tiporigaf24ep.description", nPos++);
                DescribeAColumn(T, "fiscaltaxcode", "Codice Tributo", nPos++);
                DescribeAColumn(T, "code", "Codice Sede", nPos++);
                DescribeAColumn(T, "identifying_marks", "Estremi", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!rifa_monthname", "Mese inizio", "monthname1.title",nPos++);
                DescribeAColumn(T, "!rifb_monthname", "Mese fine", "monthname2.title", nPos++);
                
			}
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idclawback", ".#", nPos++);
                DescribeAColumn(T, "!clawbackref", "Codice", "clawback.clawbackref", nPos++);
                DescribeAColumn(T, "!descrizione", "Descrizione", "clawback.description", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
            }
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
			if (R["amount"]==DBNull.Value){
				errmess= "E' necessario specificare l'importo della variazione";
				errfield="amount";
				return false;
			}
            //if ((R["code"].ToString() != "") && (R["code"].ToString().Length != 5)) {
            //    errmess = "Il Codice (Sede INPS, Sede INAIL, ecc..) deve avere lunghezza 5.";
            //    errfield = "code";
            //    return false;
            //}
			return true;
		}

		

	}
    

}
