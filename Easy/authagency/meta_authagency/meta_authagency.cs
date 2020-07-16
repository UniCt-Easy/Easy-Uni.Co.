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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_authagency
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_authagency : Meta_easydata 
	{
        public Meta_authagency (DataAccess Conn, MetaDataDispatcher Dispatcher):
        base(Conn, Dispatcher, "authagency") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

      
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Agenti Autorizzativi";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("authagency_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "solodescrizione") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idauthagency", ".#", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "priority", "Ordine aut.", nPos++);
			}
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "ismanager", "N");
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idauthagency"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idauthagency");
            if (N < 9999000)
                R["idauthagency"] = 9999001;
            else
                R["idauthagency"] = N + 1;

            return R;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }
	}
	
}
