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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_autoexpensesorting//meta_autoclassspese//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_autoexpensesorting : Meta_easydata 
	{
		public Meta_autoexpensesorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "autoexpensesorting") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
            EditTypes.Add("single");
            ListingTypes.Add("upb");
            ListingTypes.Add("fin");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Configurazione classificazioni automatiche movimenti di spesa";
				Form F = GetFormByDllName("autoexpensesorting_default");
				return F;
			}
            if (FormName == "single")
            {
                Name = "Configurazione classificazioni automatiche movimenti di spese - U.P.B.";
                DefaultListType = "upb";
                return GetFormByDllName("autoexpensesorting_single");
            }
			return null;
		}		
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"ayear");
			RowChange.MarkAsAutoincrement(T.Columns["idautosort"],null,
				null,9);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}
		public override void SetDefaults(DataTable PrimaryTable) {
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
			base.SetDefaults (PrimaryTable);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "autoexpensesortingview", Exclude);
			return base.SelectOne(ListingType, filter, "autoexpensesorting", Exclude);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idsorkind"]) == 0) {
                errmess = "Bisogna specificare il tipo di classificazione principale";
                errfield = "idsorkind";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idsor"]) == 0) {
                errmess = "Bisogna specificare la voce di classificazione principale";
                errfield = "idsor";
                return false;
            }

            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "upb") || (ListingType == "fin")){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "!sortingkind", "Tipo Class. Movimenti","sortingkind.description",nPos++);
                DescribeAColumn(T, "!sortingcode", "Codice Class. Movimenti", "sorting.sortcode", nPos++);
                DescribeAColumn(T, "!sorting", "Class. Movimenti",  "sorting.description",nPos++);
                DescribeAColumn(T, "!frazione", "Frazione", "", nPos++);
				ComputeRowsAs(T, ListingType);
            }
        }

		public override void CalculateFields(System.Data.DataRow R, string listtype) 
		{
			R["!frazione"]= R["numerator"]+"/"+R["denominator"];
		}


	}
}
