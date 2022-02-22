
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importver
{
	/// <summary>
	/// </summary>
	public class Meta_csa_importver : Meta_easydata {
		public Meta_csa_importver(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_importver") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
            ListingTypes.Add("ritenuta");
            ListingTypes.Add("contributo");
            ListingTypes.Add("recupero");
            ListingTypes.Add("vocecsa");
        }
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType= "default";
				Name= "Importazione Versamenti CSA";
                CanInsert = false;
				return MetaData.GetFormByDllName("csa_importver_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
            SetDefault(T, "ayear", GetSys("esercizio"));
            SetDefault(T, "flagcr", "C");
		}		

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default"|| ListingType == "recupero" || ListingType == "ritenuta"||ListingType == "contributo"||ListingType == "voce csa") {
                return base.SelectOne(ListingType, filter, "csa_importverview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_import");
            RowChange.MarkAsAutoincrement(T.Columns["idver"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idver"], 9999000);
         
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idver", "Codice", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "flagcr", "Comp./Residui", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "ente", "Ente", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                DescribeAColumn(T, "!registry1", "Anagrafica", nPos++);
               
            }
        }

        public override bool CanSelect (DataRow R) {
            return DataAccess.CanSelect(Conn, R);
        }
	}

}

