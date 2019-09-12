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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
//Pino: using descrtipoindirizzo; diventato inutile
//using cdtipoindirizzoanagrafica;

namespace meta_address//meta_descrtipoindirizzo//
{
	/// <summary>
	/// Summary description for cdtipoindirizzo.
	/// </summary>
	public class Meta_address : Meta_easydata {
		public Meta_address(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "address") {		
			EditTypes.Add("lista");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
			Name= "Tipo Indirizzo";
			//----------------------INSTM---------------------------begin
			EditTypes.Add("instmuser");
			ListingTypes.Add("instmuser");
			//$EditTypes$
			//----------------------INSTM---------------------------end
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="lista") {
				DefaultListType="lista";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("address_lista");//PinoRana
			}
			return null;
		}

		
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"active",'S');
		}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idaddress"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			if ( ListingType=="lista") {
                //foreach (DataColumn C in T.Columns)
                //    DescribeAColumn(T, C.ColumnName, "", -1);

                //int nPos = 1;
                DescribeAColumn(T, "codeaddress", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
            if (ListingType == "checkimport")
            {
                //foreach (DataColumn C in T.Columns)
                //    DescribeAColumn(T, C.ColumnName, "", -1);
                //int nPos = 1;
                DescribeAColumn(T, "codeaddress", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
			//----------------------INSTM---------------------------begin
			switch (ListingType) {
				case "instmuser": {
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						break;
					}
				case "default": {
						DescribeAColumn(T, "codeaddress", "Codice", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
			//----------------------INSTM---------------------------end
		}

		//----------------------INSTM---------------------------begin
		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "instmuser": {
						return "description asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "instmuser": {
						return "active = 'S'";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}

		//----------------------INSTM---------------------------end


	}
}
