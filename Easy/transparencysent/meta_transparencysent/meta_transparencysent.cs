/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_transparencysent {
	/// <summary>
	/// </summary>
	public class Meta_transparencysent : Meta_easydata {
		public Meta_transparencysent(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "transparencysent") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				DefaultListType = "default";
				Name = "Incarichi trasmessi";
				return MetaData.GetFormByDllName("transparencysent_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "ayear", Conn.GetEsercizio());
			SetDefault(T, "flagtransmissionstatus", "I");
			SetDefault(T, "active", "S");
		}

		//public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
		//    if (ListingType == "default") {
		//        return base.SelectOne(ListingType, filter, "transparencysentview", ToMerge);
		//    }
		//    return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		//}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "ayear");
			RowChange.MarkAsAutoincrement(T.Columns["idsent"], null, null, 7);
			DataRow R = base.Get_New_Row(ParentRow, T);

			int N = MetaData.MaxFromColumn(T, "idsent");
			if (N < 9999000)
				R["idsent"] = 9999001;
			else
				R["idsent"] = N + 1;

			return R;
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
				int nPos = 1;
				DescribeAColumn(T, "dipartimento", "Dipartimento", nPos++);
				DescribeAColumn(T, "ayear", "Esercizio", nPos++);
				DescribeAColumn(T, "idsent", "Numero trasmissione", nPos++);
				DescribeAColumn(T, "idexp", "id.# movimento", nPos++);
				DescribeAColumn(T, "description", "Descrizione movimento", nPos++);
				DescribeAColumn(T, "idsor_siope", "id.# SIOPE", nPos++);
				DescribeAColumn(T, "sortcode_siope", "Cod. SIOPE", nPos++);
				DescribeAColumn(T, "description_siope", "Descrizione SIOPE", nPos++);
				DescribeAColumn(T, "idreg", "id.# anagrafica ", nPos++);
				DescribeAColumn(T, "ragione_sociale", "Ragione Sociale", nPos++);
				DescribeAColumn(T, "p_iva", "Partita Iva", nPos++);
				DescribeAColumn(T, "cf_foreigncf", "Codice Fiscale", nPos++);
				DescribeAColumn(T, "data_transazione", "Data Transazione", nPos++);
				DescribeAColumn(T, "importo_pagato", "Importo Pagato", nPos++);
				DescribeAColumn(T, "identificativo_servizio", "Id. servizio", nPos++);
				DescribeAColumn(T, "flagtransmissionstatus", "Stato Trasmissione", nPos++);
				DescribeAColumn(T, "ambito_temporale", "Ambito Temporale", nPos++);
				DescribeAColumn(T, "tipologia_spesa", "Tipologia Spesa", nPos++);
				DescribeAColumn(T, "active", "Attivo", nPos++);
			}
		}

	}



}
