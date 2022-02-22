
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
//Pino: using trattamentobollo; diventato inutile
using metadatalibrary;

namespace meta_stamphandling {//meta_trattamentobollo//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_stamphandling : Meta_easydata {
		public Meta_stamphandling(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "stamphandling") {		
			EditTypes.Add("lista");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="lista") {
				Name="Trattamento del bollo";
				ActAsList();                
				return MetaData.GetFormByDllName("stamphandling_lista");
			}
			return null;
		}			
    
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idstamphandling", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "handlingbankcode", "Cod. per Banca", nPos++);
                DescribeAColumn(T, "flagdefault", "", nPos++);
                DescribeAColumn(T, "active", "", nPos++);
            }
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "handlingbankcode", "Cod. per Banca", nPos++);
            }
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			//compatibilità mandati (Bit  2) e reversali (Bit 3)
			SetDefault(PrimaryTable, "flag", 6);
		}

		//aggiungere un IsValid su flagstandard
		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if (R["idstamphandling"].ToString()==""){
				errmess="Non è stata selezionata nessun tipo di trattamento bollo";
				errfield="idstamphandling";
				return false;
			}
            

			if (R["flagdefault"].ToString().ToLower()!="s") return true;
			DataTable ParentTable = R.Table;
			DataRow[] standard = ParentTable.Select("flagdefault='S'");
			if (standard.Length==0) return true;
			if (standard.Length>1) {
				errmess="Non può esistere più di un tipo trattamento bollo predefinito.";
				errfield=null;
				return false;
			}
			DataRow found = standard[0];
			if (found["idstamphandling"].ToString()==R["idstamphandling"].ToString()) return true;
			errmess="Non può esistere più di un tipo trattamento bollo predefinito.";
			errfield="flagdefault";
			return false;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idstamphandling"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idstamphandling");
            if (N < 9999000)
                R["idstamphandling"] = 9999001;
            else
                R["idstamphandling"] = N + 1;

            return R;
        }
    }
}
