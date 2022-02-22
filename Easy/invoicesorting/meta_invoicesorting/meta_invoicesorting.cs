
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_invoicesorting
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_invoicesorting : Meta_easydata {
		public Meta_invoicesorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicesorting") {
			EditTypes.Add("default");
			ListingTypes.Add("default"); 
		}

		protected override Form GetForm(string FormName) {
			// if (FormName=="default") return new frmClassGerarchica();
			if (FormName=="default") {
				Name = "Classificazione documento IVA";
				return MetaData.GetFormByDllName("invoicesorting_default");
			}
			return null;
		}			

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 0;
				DescribeAColumn(T,"idsorkind","Tipo",nPos++);
				DescribeAColumn(T, "quota", "Quota",nPos++);
				DescribeAColumn(T, "!codiceclass", "Codice","sorting.sortcode",nPos++);
				DescribeAColumn(T, "!descrizione", "Descrizione","sorting.description",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
			}
		}
		
		
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			decimal quota = CfgFn.GetNoNullDecimal(R["quota"]);
			if (quota <=0 || quota>1) {
				errmess="Quota non valida";
				errfield="quota";
				return false;
			}
			return true;
		}
	}
}
