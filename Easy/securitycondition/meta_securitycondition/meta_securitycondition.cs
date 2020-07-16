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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_securitycondition {
    class Meta_securitycondition : Meta_easydata{
        public Meta_securitycondition(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "securitycondition") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Condizioni di Sicurezza";
				DefaultListType="default";
				return MetaData.GetFormByDllName("securitycondition_default");
			}
			return null;
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                DescribeAColumn(T, "idrestrictedfunction", "Cod. Funzione");
                DescribeAColumn(T, "idsecuritycondition", "ID. Condizione");
                DescribeAColumn(T, "idcustomgroup", "Gruppo");
                DescribeAColumn(T, "tablename", "Nome tabella");
                DescribeAColumn(T, "operation", "Operazione");
                DescribeAColumn(T, "defaultisdeny", "Default");
                DescribeAColumn(T, "allowcondition", "Condizione di consenti");
                DescribeAColumn(T, "denycondition", "Condizione di divieto");
			}
			return;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "securityconditionview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idsecuritycondition"], null, null, 7);
            RowChange.SetSelector(T, "idrestrictedfunction");
            return base.Get_New_Row(ParentRow, T);
        }
	}
}

