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
//using classtreesezionesingle;
using metaeasylibrary;
using metadatalibrary;

namespace meta_sectionsorting//meta_classtreesezione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_sectionsorting : Meta_easydata {
		public Meta_sectionsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sectionsorting") {
			EditTypes.Add("default");
//			EditTypes.Add("single");
			ListingTypes.Add("default");
			Name = "Classificazione Sezione";
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				return GetFormByDllName("sectionsorting_default");
				//return new frmclasstreesezionesingle();
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			DescribeAColumn(T, "idsorkind", "Tipo");
			DescribeAColumn(T, "idsor", "");
			DescribeAColumn(T, "iddivision", "");
			DescribeAColumn(T, "!codiceclass", "Codice", "classmovimenti.codiceclass");
			DescribeAColumn(T, "!descrizione", "Descrizione", "classmovimenti.descrizione");
			DescribeAColumn(T, "quota", "Quota");
			HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
		}   
	}
}
