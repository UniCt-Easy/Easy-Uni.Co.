
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
using funzioni_configurazione;

namespace meta_f24epdetail
{
	/// <summary>
	/// Summary description for Meta_casualrefund.
	/// </summary>
    public class Meta_f24epdetail : Meta_easydata
	{
		public Meta_f24epdetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "f24epdetail") 
		{
			EditTypes.Add("single");
			ListingTypes.Add("default");
            ListingTypes.Add("dettagliocollegato");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="single")
			{
				Name = "Dettaglio F24 EP";
		        return GetFormByDllName("f24epdetail_single");
			}
			return null;
		}

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                int nPos = 1;
                DescribeAColumn(T, "!desctiporiga", "Sezione", "lookup_tiporigaf24ep.description", nPos++);
                DescribeAColumn(T, "fiscaltaxcode", "Codice Tributo",nPos++);
                DescribeAColumn(T, "code", "Codice Sede", nPos++);
                DescribeAColumn(T, "identifying_marks", "Estremi", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
            }
            if (ListingType == "dettagliocollegato")
            {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                int nPos = 1;
                DescribeAColumn(T, "ycon", "Eserc. Contratto",   nPos++);
                DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
                DescribeAColumn(T, "!desctiporiga", "Sezione", "lookup_tiporigaf24ep.description", nPos++);
                DescribeAColumn(T, "fiscaltaxcode", "Codice Tributo", nPos++);
                DescribeAColumn(T, "!rifa_monthname", "Mese inizio comp.", "monthname1.title", nPos++);
                DescribeAColumn(T, "rifa_year", "Anno inizio comp.", nPos++);
                DescribeAColumn(T, "!rifb_monthname", "Mese fine comp.", "monthname2.title", nPos++);
                DescribeAColumn(T, "rifb_year", "Anno fine comp.", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                FilterRows(T);
            }
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "ycon");
            RowChange.SetSelector(T, "ncon");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
         
            return base.Get_New_Row(ParentRow, T);
        }


        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "dettagliocollegato")
            {
                if (R["idf24ep"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

        public override bool IsValid (DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["amount"]) <= 0) {
                errmess = "Inserire un importo valido";
                errfield = "amount";
                return false;
            }
            
            string fiscaltaxcode =   R["fiscaltaxcode"].ToString();
            if (fiscaltaxcode == "") {

                errmess = "Inserire un codice tributo";
                errfield = "fiscaltaxcode";
                return false;
            }
            string tiporiga = R["tiporiga"].ToString();
            if (tiporiga == "")
            {

                errmess = "Scegliere la sezione";
                errfield = "tiporiga";
                return false;
            }
            return true;
        }
	}
}
