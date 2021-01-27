
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace meta_csa_importriep
{
	/// <summary>
	/// </summary>
	public class Meta_csa_importriep : Meta_easydata {
		public Meta_csa_importriep(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_importriep") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Importazione Riepiloghi CSA";
                CanInsert = false;
				return MetaData.GetFormByDllName("csa_importriep_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
            SetDefault(T, "ayear", GetSys("esercizio"));
            SetDefault(T, "flagcr", "C");
		}		

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_importriepview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_import");
            RowChange.MarkAsAutoincrement(T.Columns["idriep"], null, null, 0);

            RowChange.setMinimumTempValue(T.Columns["idriep"],  9999000);
            DataRow R = base.Get_New_Row(ParentRow, T);
                     return R;
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idriep", "Codice", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "flagcr", "Comp./Residui", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                DescribeAColumn(T, "!registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "!fin", "Bilancio", nPos++);
                DescribeAColumn(T, "!upb", "UPB", nPos++);
                DescribeAColumn(T, "!account", "Account", nPos++);
               
            }
        }
        public override bool CanSelect (DataRow R) {
            return DataAccess.CanSelect(Conn, R);
        }
	}

}

