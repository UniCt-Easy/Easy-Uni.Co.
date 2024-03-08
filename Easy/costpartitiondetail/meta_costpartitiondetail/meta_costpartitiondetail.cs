
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

namespace meta_costpartitiondetail {
	/// <summary>
	/// Summary description for Meta_costpartitiondetail.
	/// </summary>
	public class Meta_costpartitiondetail : Meta_easydata {
		public Meta_costpartitiondetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "costpartitiondetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="lista";
				Name = "Dettaglio Ripartizione";
				return MetaData.GetFormByDllName("costpartitiondetail_default");
			}
			if (FormName=="single") {
                Name = "Dettaglio Ripartizione";
				return MetaData.GetFormByDllName("costpartitiondetail_single");
			}
			return null;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcostpartition");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null,null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
		}


		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype == "default") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;
				object title1 = DBNull.Value;
				object title2 = DBNull.Value;
				object title3 = DBNull.Value;

				DescribeAColumn(T, "iddetail", "#", nPos);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "rate", "Percentuale", nPos++);
				string filter = QHS.CmpEq("ayear", GetSys("esercizio"));
				DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
					filter, null, null, true);

				if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
					DataRow r = tExpSetup.Rows[0];
					object idsorkind1 = r["idsortingkind1"];
					object idsorkind2 = r["idsortingkind2"];
					object idsorkind3 = r["idsortingkind3"];

					if (idsorkind1 != DBNull.Value) {
						string filter1 = QHS.CmpEq("idsorkind", idsorkind1);
						title1 = Conn.DO_READ_VALUE("sortingkind", filter1, "description");
					}

					if (idsorkind2 != DBNull.Value) {
						string filter2 = QHS.CmpEq("idsorkind", idsorkind2);
						title2 = Conn.DO_READ_VALUE("sortingkind", filter2, "description");
					}

					if (idsorkind3 != DBNull.Value) {
						string filter3 = QHS.CmpEq("idsorkind", idsorkind3);
						title3 = Conn.DO_READ_VALUE("sortingkind", filter3, "description");
					}

					if ((title1 != DBNull.Value) && (title1 != null))
						DescribeAColumn(T, "!codesor1", title1.ToString(), "sorting1.sortcode", nPos++);
					if ((title2 != DBNull.Value) && (title2 != null))
						DescribeAColumn(T, "!codesor2", title2.ToString(), "sorting2.sortcode", nPos++);
					if ((title3 != DBNull.Value) && (title3 != null))
						DescribeAColumn(T, "!codesor3", title3.ToString(), "sorting3.sortcode", nPos++);
				}

				ComputeRowsAs(T, listtype);
				HelpForm.SetFormatForColumn(T.Columns["rate"], "p6");
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield){

            DataRow rParent = R.GetParentRow("costpartition_costpartitiondetail");
            if (rParent != null)
            {
                if ((rParent["kind"].ToString().ToUpper() == "C") && (R["amount"] == DBNull.Value))
                {
                    errmess = "Attenzione! E' necessario valorizzare l'importo";
                    errfield = "amount";
                    return false;
                }
                if ((rParent["kind"].ToString().ToUpper() == "P") && (R["rate"] == DBNull.Value))
                {
                    errmess = "Attenzione! E' necessario valorizzare la percentuale";
                    errfield = "rate";
                    return false;
                }

            }

            return base.IsValid(R, out errmess, out errfield);    
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "lista")
                return base.SelectOne(ListingType, filter, "costpartitiondetailview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "costpartitiondetail", Exclude);
        }	

	}
}
