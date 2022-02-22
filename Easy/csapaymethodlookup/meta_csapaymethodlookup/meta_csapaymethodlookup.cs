
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
using metadatalibrary;

namespace meta_csapaymethodlookup
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_csapaymethodlookup : Meta_easydata {
		public Meta_csapaymethodlookup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csapaymethodlookup") {
            EditTypes.Add("lista");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
            Name= "Look-up modalità di pagamento";
		}

        protected override Form GetForm(string FormName)
        {
            if (FormName == "lista") {
                return MetaData.GetFormByDllName("csapaymethodlookup_lista");
            }
            return null;
        }	

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "lista")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idcsapaymethod", "#", nPos++);
                DescribeAColumn(T, "csa_description", "Descr.CSA", nPos++);
                DescribeAColumn(T, "csa_kind", "Tipo CSA", nPos++);
                DescribeAColumn(T, "!description", "Desc.Easy", "paymethod.description", nPos++);
            }
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
                DescribeAColumn(T, "idcsapaymethod", "#", nPos++);
                DescribeAColumn(T, "csa_kind", "Tipo CSA", nPos++);
                DescribeAColumn(T, "csa_description", "Descrizione CSA", nPos++);
                DescribeAColumn(T, "idpaymethod", "Tipo Easy", nPos++);
                DescribeAColumn(T, "!description", "Descrizione Easy", "paymethod.description", nPos++);
			}
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            if (PrimaryTable.Columns.Contains("flag")) {
        
                SetDefault(PrimaryTable, "flag", 0);
            }
        }


        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcsapaymethod"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idcsapaymethod");
            if (N < 9999000)
                R["idcsapaymethod"] = 9999001;
            else
                R["idcsapaymethod"] = N + 1;

            return R;
        }
    }		
}
