
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_csa_contractregistry {
	/// <summary>
	/// </summary>
	public class Meta_csa_contractregistry: Meta_easydata {
		public Meta_csa_contractregistry(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csa_contractregistry") {
			Name= "Matricole Regola specifica CSA";
			EditTypes.Add("default");
            EditTypes.Add("elenco");
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
        }
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
				return GetFormByDllName("csa_contractregistry_default");
            if (FormName == "elenco")
                return GetFormByDllName("csa_contractregistry_elenco");

            return null;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_contractregistryview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_contract");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_registry"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", Conn.GetSys("esercizio"));
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="lista") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T,"idcsa_registry","#", nPos++);
                DescribeAColumn(T,"ayear","Esercizio", nPos++);
                DescribeAColumn(T,"!title","Anagrafica", "registry.title", nPos++);
                DescribeAColumn(T, "!cf", "Codice fiscale", "registry.cf", nPos++);
                DescribeAColumn(T, "extmatricula", "Matricola", nPos++);
            }
		}

	}
}
