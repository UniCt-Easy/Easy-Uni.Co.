
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

namespace meta_entry {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_entry : Meta_easydata {
		int esercizio;
		public Meta_entry(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "entry") {		
			Name="Scrittura in partita doppia";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			esercizio= Convert.ToInt32(Conn.GetEsercizio());
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yentry", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "identrykind", 1);
			if (PrimaryTable.Columns.Contains("official")) {
				SetDefault(PrimaryTable, "official", "S");
			}
			

			SetDefault(PrimaryTable, "locked", "N");
		}

		public override string GetStaticFilter(string ListingType)
        {
            if (ListingType == "default")
            {
                return QHS.CmpEq("yentry", GetSys("esercizio"));
            }
            return base.GetStaticFilter(ListingType);
        }


		protected override Form GetForm(string FormName){
			if (FormName=="default"){
				Name="Scrittura in partita doppia";
				DefaultListType="default";
				return MetaData.GetFormByDllName("entry_default");
			}

			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"yentry");
            RowChange.setMinimumTempValue(T.Columns["nentry"], 99990000);
            RowChange.MarkAsAutoincrement(T.Columns["nentry"],null,null,9);
			return base.Get_New_Row (ParentRow, T);
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") return base.SelectOne(ListingType, filter, "entryview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"nentry","Num.",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
				DescribeAColumn(T,"adate","Data Cont.",nPos++);
				DescribeAColumn(T,"doc","Documento",nPos++);
				DescribeAColumn(T,"docdate","Data Documento",nPos++);
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
            int identrykind = CfgFn.GetNoNullInt32(R["identrykind"]);
            if (identrykind == 0) {
                errmess = "Occorre selezionare il tipo di scrittura";
                errfield = "entry.identrykind";
                return false;
            }
			DataRow [] rDettagli = R.GetChildRows("entryentrydetail");
			decimal saldo = 0;
			foreach(DataRow rDettaglio in rDettagli) {
				saldo += CfgFn.GetNoNullDecimal(rDettaglio["amount"]);
			}
			if (saldo != 0) {
				errmess = "Attenzione! Le scritture in partita doppia devono sempre essere bilanciate,"
					+" ed il loro saldo deve essere uguale a zero!";
				errfield = null;
				return false;
			}

            DateTime DataContabile = (DateTime)R["adate"];
            
            if (DataContabile.Year!= CfgFn.GetNoNullInt32 ( R["yentry"]) ) {
                errmess = "Attenzione!La Data Contabile deve essere compresa nell'anno della scrittura.";
 
                 errfield = "entry.adate"; 
                return false;
            }
			return true;
		}
	}
}
