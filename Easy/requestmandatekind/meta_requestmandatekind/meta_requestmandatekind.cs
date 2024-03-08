
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
using metadatalibrary;
using metaeasylibrary;
using System.Text.RegularExpressions;
using funzioni_configurazione;

namespace meta_requestmandatekind {
	/// <summary>
	/// Summary description for meta_requestmandatekind.
	/// </summary>
	public class Meta_requestmandatekind: Meta_easydata {
		public Meta_requestmandatekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "requestmandatekind"){		
		
			ListingTypes.Add("default");
            ListingTypes.Add("elenco");
            Name = "Tipo contratto passivo";
		}
		
		protected override Form GetForm(string FormName) {
			if (FormName=="associa") {
				DefaultListType="elenco";
				Name="Tipo di Contratto Passivo";
				return GetFormByDllName("requestmandatekind_default");
			
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="elenco"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T,"idmankind_original", "Codice Tipo Richiesta Ordine", nPos++);
				DescribeAColumn(T,"idmankind", "Codice Tipo Contratto Passivo", nPos++);
			}
 

		}
 

		
	}
}
