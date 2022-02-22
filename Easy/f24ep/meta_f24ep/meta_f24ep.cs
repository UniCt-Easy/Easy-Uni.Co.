
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
using funzioni_configurazione;

namespace meta_f24ep {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_f24ep : Meta_easydata {
		public Meta_f24ep(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "f24ep") {		
			EditTypes.Add("consolidamento");
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "default": {
					DefaultListType = "default";
					Name = "Modello F24 EP da Liquidazioni ritenute";
					return MetaData.GetFormByDllName("f24ep_default");
				}
               
			}
			return null;
		}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
            SetDefault(PrimaryTable, "paymentdate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "nmonth", ((DateTime)GetSys("datacontabile")).Month );
        }

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idf24ep"],null,null,0);
			return base.Get_New_Row (ParentRow, T);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
          
            if (CfgFn.GetNoNullInt32(R["nmonth"]) == 0) {
                errmess = "Valorizzare il mese";
                errfield = "nmonth";
                return false;
            }
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["paymentdate"] is DateTime) {
                DateTime paymentDate = (DateTime)R["paymentdate"];
                DateTime dataContabile = (DateTime)GetSys("datacontabile");
                if (paymentDate < dataContabile.Date) {
                    errmess = "La data di versamento non può essere inferiore alla data contabile";
                    errfield = "paymentdate";
                    return false;
                }
            }
            return true;
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idf24ep", "Numero F24");
				DescribeAColumn(T,"ayear", "Esercizio");
                DescribeAColumn(T,"nmonth", "Mese");
				DescribeAColumn(T,"paymentdate", "Data Addebito");
				DescribeAColumn(T,"taxpay_start", "Data Prima Liquidazione");
				DescribeAColumn(T,"taxpay_stop", "Data Ultima Liquidazione");
				//DescribeAColumn(T,"totalpayed", "Totale addebito");
			}
		}
	}
}
