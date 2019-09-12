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

namespace meta_authmodel
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_authmodel : Meta_easydata 
	{
        public Meta_authmodel (DataAccess Conn, MetaDataDispatcher Dispatcher):
        base(Conn, Dispatcher, "authmodel") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

      
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Modello di Autorizzazione";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("authmodel_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "solodescrizione")
            {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idauthmodel", ".#", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "authfinrequired", "N");
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idauthmodel"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idauthmodel");
            if (N < 9999000)
                R["idauthmodel"] = 9999001;
            else
                R["idauthmodel"] = N + 1;

            return R;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }
	}
	
}
