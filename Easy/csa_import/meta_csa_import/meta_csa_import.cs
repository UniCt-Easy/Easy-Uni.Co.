
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

namespace meta_csa_import
{
	/// <summary>
	/// </summary>
	public class Meta_csa_import : Meta_easydata {
		public Meta_csa_import(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_import") {		
			EditTypes.Add("default");
            EditTypes.Add("annualpayment");
            ListingTypes.Add("default");
			ListingTypes.Add("versamentiposticipati");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Importazione CSA";
                this.CanInsertCopy = false;
				return MetaData.GetFormByDllName("csa_import_default");
			}
            if (FormName == "annualpayment") {
                Name = "Versamenti Annuali Voci CSA";
                return MetaData.GetFormByDllName("csa_import_inail");
            }
			//csa_import_inail_maxphase
			if (FormName == "postponedpayment") {
				Name = "Versamenti posticipati";
				return MetaData.GetFormByDllName("csa_import_inail_maxphase");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
            SetDefault(T, "yimport", GetSys("esercizio"));
            SetDefault(T, "adate", GetSys("datacontabile"));
 		}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.ClearMySelector(T, "yimport");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_import"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["nimport"], null, null, 0);
            RowChange.SetMySelector(T.Columns["nimport"], "yimport", 0);

            DataRow R = base.Get_New_Row(ParentRow, T);
          

            int K = MetaData.MaxFromColumn(T, "idcsa_import");
            if (K < 9999000)
                R["idcsa_import"] = 9999001;
            else
                R["idcsa_import"] = K + 1;
            return R;
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idcsa_import", "Codice", nPos++);
                DescribeAColumn(T, "yimport", "Esercizio", nPos++);
                DescribeAColumn(T, "nimport", "Numero", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);
                DescribeAColumn(T, "ybill_netti", "Eserc. Sospeso Netti", nPos++);
                DescribeAColumn(T, "nbill_netti", "Num. Sospeso Netti", nPos++);
                DescribeAColumn(T, "ybill_versamenti", "Eserc. Sospeso Versamenti", nPos++);
                DescribeAColumn(T, "nbill_versamenti", "Num. Sospeso Versamenti", nPos++);
                DescribeAColumn(T, "refexternaldoc", "Riferimento doc. esterno", nPos++);
                DescribeAColumn(T, "referencedate", "Data Competenza Stipendi", nPos++);
            }
			if (ListingType == "versamentiposticipati") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "idcsa_import", ".#Codice", nPos++);
				DescribeAColumn(T, "yimport", "Esercizio", nPos++);
				DescribeAColumn(T, "nimport", "Numero", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "adate", "Data Contabile", nPos++);
                DescribeAColumn(T, "refexternaldoc", "Riferimento doc. esterno", nPos++);
			}
		}

	}

}
