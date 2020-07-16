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
using funzioni_configurazione;

namespace meta_casualcontracttax
{
	/// <summary>
	/// Summary description for Meta_casualcontracttax.
	/// </summary>
	public class Meta_casualcontracttax : Meta_easydata
	{
		public Meta_casualcontracttax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "casualcontracttax") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name = "Ritenute";
				return GetFormByDllName("casualcontracttax_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns)
				{
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T,"!taxref","Codice Ritenuta", "tax.taxref", nPos++);
				DescribeAColumn(T,"!descrizione","Descrizione","tax.description", nPos++);
				//DescribeAColumn(T,"!imponibilenetto", "Imponibile Netto", nPos++);
				DescribeAColumn(T,"taxablenet","Imponibile Netto", nPos++);
				DescribeAColumn(T, "!aliquotadip", "Aliquota c/dip", nPos++);
				//DescribeAColumn(T,"employrate","Aliquota c/Dip.", nPos++);
				DescribeAColumn(T,"employtax","Rit. c/Dip.", nPos++);
				//DescribeAColumn(T,"adminrate","Aliquota c/Ammin.", nPos++);
				DescribeAColumn(T, "!aliquotaamm", "Aliquota c/amm", nPos++);
				DescribeAColumn(T,"admintax","Rit. c/Ammin.", nPos++);
				DescribeAColumn(T,"!tiporitenuta",".Tipo Ritenuta","tax.taxkind", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!imponibilenetto"], "c");
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["!aliquotadip"],"p");
				HelpForm.SetFormatForColumn(T.Columns["!aliquotaamm"],"p");
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
				decimal imponibile = CfgFn.GetNoNullDecimal(R["taxablenet"]);
				object quotaNumImponibile = R["taxablenumerator"];
				object quotaDenImponibile = R["taxabledenominator"];
				decimal frazione = rapporto(quotaNumImponibile, quotaDenImponibile);
				decimal imponibileNetto = CfgFn.GetNoNullDecimal(R["taxablenet"]);
                //decimal aliquotaAmmMedia = (imponibileNetto != 0)
                //    ? CfgFn.GetNoNullDecimal(R["admintax"]) / imponibileNetto : 0;
                //R["!aliquotaamm"] = aliquotaAmmMedia;
                //decimal aliquotaDipMedia = (imponibileNetto != 0)
                //    ? CfgFn.GetNoNullDecimal(R["employtax"]) / imponibileNetto : 0;
                //R["!aliquotadip"] = aliquotaDipMedia;
                R["!aliquotaamm"] = R["adminrate"];
                R["!aliquotadip"] = R["employrate"];
			}
		}
	}
}
