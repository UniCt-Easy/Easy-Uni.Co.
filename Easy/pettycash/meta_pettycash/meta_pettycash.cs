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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using fondopiccolespese_sit; diventato inutile
//using pettycash_default;//fondopiccolespese

namespace meta_pettycash//meta_fondopiccolespese//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_pettycash : Meta_easydata {
		public Meta_pettycash(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycash") {
			EditTypes.Add("situazione");
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName){
			
			if (FormName=="situazione")
			{
				Name = "Ricerca fondo";
				DefaultListType="default";
				return MetaData.GetFormByDllName("pettycash_situazione");//PinoRana
			}
			//Rosalba
			if (FormName=="default") 
			{
				Name = "Fondo economale";
				DefaultListType="default";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("pettycash_default");//PinoRana
			}

			return null;
		}			
//		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
//			//RowChange.MarkAsAutoincrement(T.Columns["codicefondo"],null,null,7);
//			return base.Get_New_Row(ParentRow, T);
//		}

//		public override void SetDefaults(DataTable PrimaryTable){
//			base.SetDefaults(PrimaryTable);
//			SetDefault(PrimaryTable, "flagutilizzabile", "S");
//		}

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idpettycash"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "pettycode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "description", "Fondo Economale", nPos++);
            }

		}
	}
}
