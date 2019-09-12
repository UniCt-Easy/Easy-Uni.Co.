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
using metadatalibrary;
using metaeasylibrary;
//using audit_regola;//businessrule

namespace meta_audit//meta_businessrule//
{
	public class Meta_audit : Meta_easydata
	{
		public Meta_audit(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "audit") {		
			//EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("regola");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="regola" ){
				Name= "Regola ";
				Form F = GetFormByDllName("audit_regola");
				return F;
			}
			return null;
		}		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach (DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idaudit","Codice");
				DescribeAColumn(T,"severity","Gravità");
				DescribeAColumn(T,"flagsystem","Regola di Sistema");
				DescribeAColumn(T,"title","Descrizione sintetica");
				DescribeAColumn(T,"consequence","Conseguenza");
			}
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);

			SetDefault(PrimaryTable,"flagsystem","N");
		}

	}
}
