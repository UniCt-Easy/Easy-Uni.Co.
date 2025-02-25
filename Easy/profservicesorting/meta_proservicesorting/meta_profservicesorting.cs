
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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

namespace meta_profservicesorting//meta_classtreecontrattoprof//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_profservicesorting : Meta_easydata
	{
		public Meta_profservicesorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "profservicesorting")
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName == "default")
			{
				Name = "Classificazione contratto professionale";
				DefaultListType="default";
				return GetFormByDllName("profservicesorting_default");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) 
		{
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			decimal quota = CfgFn.GetNoNullDecimal(R["quota"]);
			if (quota <=0 || quota>1)
			{
				errmess="Quota non valida";
				errfield="quota";
				return false;
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "", -1);
			int nPos = 0;

			DescribeAColumn(T, "idsorkind", "Tipo", nPos++);
			DescribeAColumn(T, "idsor", "", nPos++);
			DescribeAColumn(T, "ycon", "", nPos++);
			DescribeAColumn(T, "ncon", "", nPos++);
			DescribeAColumn(T, "!codiceclass", "Codice", "sorting.sortcode", nPos++);
			DescribeAColumn(T, "!descrizione", "Descrizione", "sorting.description", nPos++);
			DescribeAColumn(T, "quota", "Quota", nPos++);
			HelpForm.SetFormatForColumn(T.Columns["quota"],"p");

			for (int i = 1; i <= 5; i++) {
				DescribeAColumn(T, "valued" + i.ToString(), "Data " + i.ToString(), nPos++);
			}
		}   
	}
}
