
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_flussoincassidetail {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_flussoincassidetail : Meta_easydata {
		public Meta_flussoincassidetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "flussoincassidetail") {
			EditTypes.Add("single");
            EditTypes.Add("bollettino");
            ListingTypes.Add("default");
        }

		protected override Form GetForm(string FormName){
            if (FormName == "single") {
                Name = "Dettaglio Flusso Incassi";
                return MetaData.GetFormByDllName("flussoincassidetail_single");
                }
            if (FormName == "default") {
                Name = "Dettaglio Flusso Incassi";
                return MetaData.GetFormByDllName("flussoincassidetail_default");
            }
            if (FormName == "bollettino") {
                Name = "Dettaglio Flusso Incassi-Bollettino";
                return MetaData.GetFormByDllName("flussoincassidetail_bollettino");
            }
            return null;
		}

        

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			 
		}


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, "flussoincassidetailview", Exclude);
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idflusso");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

     

 
        public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
                DescribeAColumn(T, "!codiceflusso", "Codice Flusso", "flussoincassi.codiceflusso",pos++);
                DescribeAColumn(T, "iddetail", "#",  pos++);
                DescribeAColumn(T, "iuv", "Codice IUV",pos++);
                DescribeAColumn(T, "iduniqueformcode", "Codice Bollettino", pos++);
                DescribeAColumn(T, "cf", "Codice Fiscale", pos++);
                DescribeAColumn(T, "importo", "Importo",pos++);
				DescribeAColumn(T, "p_iva", "Partita Iva", pos++);
			}
		}   


	}
}
