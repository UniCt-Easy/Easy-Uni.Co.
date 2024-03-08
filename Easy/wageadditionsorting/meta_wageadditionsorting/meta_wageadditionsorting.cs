
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


using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_wageadditionsorting//meta_classtreecontrattodip//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_wageadditionsorting : Meta_easydata 
	{
		public Meta_wageadditionsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "wageadditionsorting") 
		{
			EditTypes.Add("default");
			//EditTypes.Add("single");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName == "default")
			{
				Name = "Classificazione contratto dipendenti";			
				DefaultListType="default";
				return GetFormByDllName("wageadditionsorting_default");
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
			DescribeAColumn(T, "idsorkind", "Tipo");
			DescribeAColumn(T, "idsor", "");
			DescribeAColumn(T, "ycon", "");
			DescribeAColumn(T, "ncon", "");
			DescribeAColumn(T, "!codiceclass", "Codice", "sorting.sortcode");
			DescribeAColumn(T, "!descrizione", "Descrizione", "sorting.description");
			DescribeAColumn(T, "quota", "Quota");
			HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
		}   
	}

}
