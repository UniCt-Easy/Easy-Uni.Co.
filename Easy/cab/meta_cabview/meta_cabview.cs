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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using System.Windows.Forms;
//using sportellobancalista_anagrafica;

namespace meta_cabview//meta_sportellobancaview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_cabview : Meta_easydata
	{
		public Meta_cabview(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "cabview") 
		{		
			//
			// TODO: Add constructor logic here
			//
			Name="Sportelli di una banca";
			EditTypes.Add("lista_anag");
			ListingTypes.Add("default_anag");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista_anag") 
			{
				Name="Sportelli di una Banca";
				//ActAsList();             
				StartEmpty = true;
                DefaultListType = "default_anag";
                return GetFormByDllName("cabview_lista_anag");
			}
			return null;
		}
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "flagusable", "S");
        }
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default_anag") 
			{
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idbank", "Cod. ABI", nPos++);
                DescribeAColumn(T, "idcab", "Cod. CAB", nPos++);
                DescribeAColumn(T, "description", "Nome Filiale", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "C.A.P.", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "country", "Provincia", nPos++);
			}
		}
	}
}
