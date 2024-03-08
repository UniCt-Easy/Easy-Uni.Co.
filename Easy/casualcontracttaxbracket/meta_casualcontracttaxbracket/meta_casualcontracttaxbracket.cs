
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_casualcontracttaxbracket
{
	/// <summary>
	/// Summary description for Meta_casualcontracttaxbracket.
	/// </summary>
	public class Meta_casualcontracttaxbracket : Meta_easydata
	{
		public Meta_casualcontracttaxbracket(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "casualcontracttaxbracket") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T,"ycon");
			RowChange.SetSelector(T,"ncon");
			RowChange.SetSelector(T,"taxcode");
			RowChange.MarkAsAutoincrement(T.Columns["nbracket"],null,null,0);
			return base.Get_New_Row(ParentRow, T);
		}
		
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.Caption,"",-1);
				}
				int nPos = 1;
				//DescribeAColumn(T,"taxable","Imponibile", nPos++);
				DescribeAColumn(T,"!taxref","Codice Ritenuta","tax.taxref", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
				DescribeAColumn(T,"employrate","Aliquota Dip.", nPos++);
				DescribeAColumn(T,"employtax","Ritenuta Dip.", nPos++);
				DescribeAColumn(T,"adminrate","Aliquota Ammin.", nPos++);
				DescribeAColumn(T,"admintax","Ritenuta Ammin.", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!imponibile"],"c");
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
				ComputeRowsAs(T, ListingType);
			}
		}

		/// <summary>
		/// Metodo che calcola il rapporto tra numeratore e denominatore
		/// </summary>
		/// <param name="quotanum">Numeratore</param>
		/// <param name="quotaden">Denominatore</param>
		/// <returns>Rapporto tra numeratore e denominatore</returns>
		private decimal rapporto(object quotanum, object quotaden) {
			if (CfgFn.GetNoNullDecimal(quotaden)==0) {
				return (quotanum is DBNull) ? 1 : CfgFn.GetNoNullDecimal(quotanum);
			}
			if (quotanum is DBNull) {
				return 1;
			}
			return CfgFn.GetNoNullDecimal(quotanum) / CfgFn.GetNoNullDecimal(quotaden);
		}

		public override void CalculateFields(DataRow R, string list_type) {
			if (list_type=="default") {
				DataRow rParent = R.GetParentRow("casualcontracttaxcasualcontracttaxbracket");
				if (rParent == null) return;
				decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				object quotaNumImponibile = rParent["taxablenumerator"];
				object quotaDenImponibile = rParent["taxabledenominator"];
				decimal frazione = rapporto(quotaNumImponibile, quotaDenImponibile);
				decimal imponibileNetto = CfgFn.RoundValuta(imponibile * frazione);
				R["!imponibile"] = imponibileNetto;

			}
		}
	}
}
