
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_csa_agencypaymethodview {
	/// <summary>
	/// Revised by Nino on 11/1/2003
	/// </summary>
	public class Meta_csa_agencypaymethodview : Meta_easydata {
		public Meta_csa_agencypaymethodview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_agencypaymethodview") {
			Name= "Modalità pagamento Ente CSA";
			ListingTypes.Add("default");
		}
		

     

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T, "idcsa_agencypaymethod", "#", nPos++);
				DescribeAColumn(T, "vocecsa","Voce CSA",nPos++);
                DescribeAColumn(T, "ente", "Ente", nPos++);
                DescribeAColumn(T, "agency", "Descrizione Ente", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "regmodcode", "Tipo", nPos++);
                DescribeAColumn(T, "paymentdescr", "Descr. Mod. Pagamento", nPos++);
                 }
		}
	}
}
