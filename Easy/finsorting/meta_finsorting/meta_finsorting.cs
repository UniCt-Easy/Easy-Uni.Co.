/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
//using classtreebilanciosingle;
using metadatalibrary;

namespace meta_finsorting//meta_classtreebilancio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finsorting : Meta_easydata {
		public Meta_finsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finsorting") {
//			EditTypes.Add("default");
			EditTypes.Add("single");
            EditTypes.Add("imputazione");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			
			if (FormName=="single")
			{
				Name = "Classificazione bilancio";
				DefaultListType = "default";
				return GetFormByDllName("finsorting_single");
				//return new frmclasstreebilanciosingle();
			}
            if (FormName == "imputazione") {
                Name = "Classificazione bilancio";
                DefaultListType = "lista";
                return MetaData.GetFormByDllName("finsorting_imputazione");
            }
			return null;
		}

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType.StartsWith("lista."))
                return base.SelectOne(ListingType, filter, "finsortingview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "finsorting", Exclude);
        }		 

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                DescribeAColumn(T, "idsorkind", "Tipo");
                DescribeAColumn(T, "idsor", "");
                DescribeAColumn(T, "idfin", "");
                DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode");
                DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description");
                DescribeAColumn(T, "!tipoclass", "Tipo", "sortingview.codesorkind");
                DescribeAColumn(T, "quota", "Quota");
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
            }
		}   
	}
}

