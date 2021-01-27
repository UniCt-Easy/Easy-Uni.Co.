
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_csapositionlookup
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_csapositionlookup : Meta_easydata {
		public Meta_csapositionlookup(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csapositionlookup") {
            EditTypes.Add("lista");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
            Name= "Look-Up Qualifiche";
		}

        protected override Form GetForm(string FormName){
            if (FormName == "lista") {
                DefaultListType = "lista";
                ActAsList();
                return MetaData.GetFormByDllName("csapositionlookup_lista");
            }
            return null;
        }	

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "csa_compartment", "Comparto CSA", nPos++);
                DescribeAColumn(T, "csa_role", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "csa_class", "Inquadr.CSA", nPos++);
                DescribeAColumn(T, "csa_description", "Desr.CSA", nPos++);
                DescribeAColumn(T, "!codeposition", "cod. Easy", "position.codeposition", nPos++);
                DescribeAColumn(T, "!description", "Desc. Easy", "position.description", nPos++);
                DescribeAColumn(T, "supposedtaxable", "Imponibile presunto", nPos++);
            }
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "csa_compartment", "Comparto CSA", nPos++);
                DescribeAColumn(T, "csa_role", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "csa_class", "Inquadr.CSA", nPos++);
                DescribeAColumn(T, "csa_description", "Desr.CSA", nPos++);
                DescribeAColumn(T, "!codeposition", "cod. Easy", "position.codeposition", nPos++);
                DescribeAColumn(T, "!description", "Desc. Easy", "position.description", nPos++);
                DescribeAColumn(T, "supposedtaxable", "Imponibile presunto", nPos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcsaposition"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idcsaposition");
            if (N < 9999000)
                R["idcsaposition"] = 9999001;
            else
                R["idcsaposition"] = N + 1;

            return R;
        }
    }		
}
