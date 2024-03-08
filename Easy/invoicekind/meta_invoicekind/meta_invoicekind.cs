
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//using tipodocumentoiva;

namespace meta_invoicekind {//meta_tipodocumentoiva//
	/// <summary>
	/// Summary description for tipodocumentoiva.
	/// </summary>
	public class Meta_invoicekind : Meta_easydata {
		public Meta_invoicekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicekind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
            Name = "Tipo di documento";
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="elenco";
				Name="Tipo di documento";
				return GetFormByDllName("invoicekind_default");
				//return new frmtipodocumentoiva();
			}
			return null;
		}
        public override string GetFilterForSearch(DataTable T) {
            return null;
        }
 
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
				DescribeAColumn(T,"codeinvkind","Codice",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
                DescribeAColumn(T,"active", "Attivo", nPos++);
                DescribeAColumn(T,"ipa_fe","IPA", nPos++);
                DescribeAColumn(T, "riferimento_amministrazione", "Riferimento Amministrazione", nPos++);
                DescribeAColumn(T, "enable_fe", "Utilizzabile nella F.E.", nPos++);
				DescribeAColumn(T, "enable_fe_estera", "Fattura Elettronica Estera", nPos++);
                DescribeAColumn(T,"flag","");
				DescribeAColumn(T,"idacc_discount","");
			}
            if (ListingType == "lista"){
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "description", "Tipo documento IVA", nPos++);
            }

		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"flag",0);
            SetDefault(PrimaryTable,"formatstring", "{0:yy}/{1:d6}");
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "enable_fe", "N");
			SetDefault(PrimaryTable, "enable_fe_estera", "N");
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idinvkind"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["idinvkind"], 9999000);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "elenco")
				return base.SelectOne(ListingType, filter, "invoicekindview", Exclude);

			return base.SelectOne(ListingType, filter, "invoicekind", Exclude);
		}
    }
}
