
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
//using classtreecreddebi;
//using classtreecreddebiview;
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_registrysorting {//meta_classtreecreddebi//
	/// <summary>
	/// MetaData for classtreecreddebi
	/// </summary>
	public class Meta_registrysorting : Meta_easydata {
		public Meta_registrysorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registrysorting") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("anagrafica");
            EditTypes.Add("imputazione");
			ListingTypes.Add("anagrafica");  
		}

		protected override Form GetForm(string FormName) {
			// if (FormName=="default") return new frmClassGerarchica();
			if (FormName=="default") {
				Name = "Classificazione anagrafica";
				return MetaData.GetFormByDllName("registrysorting_default");
			}

			if (FormName=="anagrafica") {
				Name = "Classificazione anagrafica";
				DefaultListType="anagrafica";
				return MetaData.GetFormByDllName("registrysorting_anagrafica");
			}

            if (FormName == "imputazione") {
                Name = "Classificazione anagrafica";
                DefaultListType = "lista";
                return MetaData.GetFormByDllName("registrysorting_imputazione");
            }
			return null;
		}			

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
//				DescribeAColumn(T,"idsorkind","Tipo", nPos++);
                DescribeAColumn(T, "codesorkind", "Tipo", nPos++);
                DescribeAColumn(T, "!descrtipoclass", "Tipo Class.", "sortingview.sortingkind", nPos++);
				DescribeAColumn(T, "!codiceclass", "Codice","sortingview.sortcode", nPos++);
				DescribeAColumn(T, "!descrizione", "Descrizione","sortingview.description", nPos++);
				DescribeAColumn(T, "quota", "Quota", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
			}
		}
		
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "anagrafica" || ListingType.StartsWith("lista."))
				return base.SelectOne(ListingType, filter, "registrysortingview", Exclude);
			return base.SelectOne(ListingType, filter, "registrysorting", Exclude);
		}	
		
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
			if (codicecreddeb <= 0) {
				errmess="Inserire l'anagrafica";
				errfield="idreg";
				return false;
			}

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
