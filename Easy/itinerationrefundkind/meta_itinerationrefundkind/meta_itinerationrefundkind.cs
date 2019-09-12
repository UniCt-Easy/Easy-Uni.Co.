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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_itinerationrefundkind
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationrefundkind : Meta_easydata 
	{
		public Meta_itinerationrefundkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "itinerationrefundkind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}

      
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Rimborso Spese";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("itinerationrefundkind_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
				DescribeAColumn(T, "codeitinerationrefundkind","Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!itinerationrefundkindgroup", "Tipo", "itinerationrefundkindgroup.description", nPos++);
                DescribeAColumn(T, "idaccmotive", "", nPos++);
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "codeitinerationrefundkind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
            if (ListingType == "solodescrizione") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "active", "S");
            SetDefault(T, "flagbalance", "S");
            SetDefault(T, "flagadvance", "S");

        }
        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iditinerationrefundkind"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullInt32(R["iditinerationrefundkindgroup"]) == 0) {
                errmess = "Bisogna specificare la classificazione della spesa";
                errfield = "iditinerationrefundkindgroup";
                return false;
            }
            return true;
        }
	}
	
}
