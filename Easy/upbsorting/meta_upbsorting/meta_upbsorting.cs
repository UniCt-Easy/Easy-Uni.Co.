
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
using funzioni_configurazione;

namespace meta_upbsorting {
	/// <summary>
	/// Summary description for Meta_upbsorting.
	/// </summary>
	public class Meta_upbsorting : Meta_easydata {
		public Meta_upbsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "upbsorting") {
			EditTypes.Add("single");
			ListingTypes.Add("default");
            EditTypes.Add("imputazione");
		}

		protected override Form GetForm(string FormName) {
			
			if (FormName=="single") {
				Name = "Classificazione U.P.B.";
				DefaultListType = "default";
				return GetFormByDllName("upbsorting_single");
			}
            if (FormName == "imputazione") {
                Name = "Classificazione U.P.B.";
                DefaultListType = "lista";
                return MetaData.GetFormByDllName("upbsorting_imputazione");
            }
			return null;
        }

    override public bool IsValid(DataRow R, out string errmess, out string errfield) {
        if (!base.IsValid(R, out errmess, out errfield)) return false;
        if (CfgFn.GetNoNullDecimal(R["quota"]) == 0) {
            errmess = "L'importo della quota deve sempre essere specificato";
            errfield = "quota";
            return false;
        }
        return true;
    }

    public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType.StartsWith("lista."))
                return base.SelectOne(ListingType, filter, "upbsortingview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "upbsorting", Exclude);
        }		

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                //DescribeAColumn(T, "idsorkind", "Tipo", 1);
                DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind");
                DescribeAColumn(T, "idsor", "");
                DescribeAColumn(T, "idupb", "");
                DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode", 2);
                DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description", 3);
                DescribeAColumn(T, "quota", "Quota", 4);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
            }
		}
	}
}
