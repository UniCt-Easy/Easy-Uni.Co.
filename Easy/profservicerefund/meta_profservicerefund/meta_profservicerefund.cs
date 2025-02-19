
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione

namespace meta_profservicerefund//meta_contrattoprofspesa//
{
	/// <summary>
	/// Summary description for Meta_contrattoprofspesa.
	/// </summary>
	public class Meta_profservicerefund : Meta_easydata
	{
		public Meta_profservicerefund(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "profservicerefund") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name = "Spese Documentate";
				return GetFormByDllName("profservicerefund_default");
			}
			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T, "ycon");
			RowChange.SetSelector(T, "ncon");
			RowChange.MarkAsAutoincrement(T.Columns["nrefund"],null,
				null,0);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (CfgFn.GetNoNullDecimal(R["amount"]) <= 0)
			{
				errmess = "Inserire un importo maggiore di zero";
				errfield = "amount";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns)
				{
					C.Caption = "";
				}
				DescribeAColumn(T,"nrefund","Numero Spesa");
				DescribeAColumn(T,"!descrizione","Descrizione","profrefund.description");
				DescribeAColumn(T,"amount","Importo");
			}
		}
	}
}
