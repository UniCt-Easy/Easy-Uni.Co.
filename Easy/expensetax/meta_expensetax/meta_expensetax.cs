
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
//Pino: using dettaglioritenute; diventato inutile

namespace meta_expensetax {//meta_dettaglioritenute//
	/// <summary>
	/// MetaData for spesa
	/// </summary>
	public class Meta_expensetax : Meta_easydata {
		public Meta_expensetax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensetax") {		
			Name = "Dettaglio Ritenute";
			EditTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("default");
			ListingTypes.Add("liquidazione");
			
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") { 
				DefaultListType="default";
				return MetaData.GetFormByDllName("expensetax_default");//PinoRana
			}
			return null;
		}			

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "competencydate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "taxcode");
			RowChange.SetSelector(T, "idexp");
			RowChange.MarkAsAutoincrement(T.Columns["nbracket"],null,null,7);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {	
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, ".taxcode", "#",nPos++);
                DescribeAColumn(T, "!taxref", "Codice", "tax.taxref", nPos++);
				DescribeAColumn(T, "!descrizione", "Descrizione","tax.description",nPos++);
				DescribeAColumn(T, "taxablenet", "Imponibile Netto",nPos++);
				DescribeAColumn(T, "employrate", "Aliq. dip.",nPos++);
                DescribeAColumn(T, "taxablenumerator", "Num.imp.", nPos++);
                DescribeAColumn(T, "taxabledenominator", "Den.imp.", nPos++);
                DescribeAColumn(T, "employnumerator", "Num. dip.", nPos++);
				DescribeAColumn(T, "employdenominator", "Den. dip.",nPos++);
				DescribeAColumn(T, "employtax", "Rit. dip.",nPos++);
				DescribeAColumn(T, "adminrate", "Aliq. amm.",nPos++);
				DescribeAColumn(T, "adminnumerator", "Num. amm.",nPos++);
				DescribeAColumn(T, "admindenominator", "Den. amm.",nPos++);
                DescribeAColumn(T, "admintax", "Rit. amm.", nPos++);
                DescribeAColumn(T, "competencydate", "Data competenza", nPos++);
				DescribeAColumn(T,"ytaxpay","Eserc. Liquidazione",nPos++);
				DescribeAColumn(T,"ntaxpay","Num. Liquidazione",nPos++);

				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["employnumerator"],"n");
				HelpForm.SetFormatForColumn(T.Columns["employdenominator"],"n");
				HelpForm.SetFormatForColumn(T.Columns["adminnumerator"],"n");
				HelpForm.SetFormatForColumn(T.Columns["admindenominator"],"n");
                HelpForm.SetFormatForColumn(T.Columns["taxablenumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxabledenominator"], "n");

			}
	
			if (ListingType=="liquidazione") 
			{	
				foreach(DataColumn C in T.Columns) 
				{
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
                DescribeAColumn(T, ".taxcode", "#", nPos++);
                DescribeAColumn(T, "!taxref", "Codice", "tax.taxref", nPos++);
				DescribeAColumn(T, "!descrizione", "Descrizione","tax.description",nPos++);
				DescribeAColumn(T, "taxablenet", "Imponibile Netto",nPos++);
				DescribeAColumn(T, "employrate", "Aliq. dip.",nPos++);
				DescribeAColumn(T, "employnumerator", "Num. dip.",nPos++);
				DescribeAColumn(T, "employdenominator", "Den. dip.",nPos++);
				DescribeAColumn(T, "employtax", "Rit. dip.",nPos++);
				DescribeAColumn(T, "adminrate", "Aliq. amm.",nPos++);
				DescribeAColumn(T, "adminnumerator", "Num. amm.",nPos++);
				DescribeAColumn(T, "admindenominator", "Den. amm.",nPos++);
				DescribeAColumn(T, "admintax", "Rit. amm.",nPos++);
				DescribeAColumn(T,"competencydate","Data competenza",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
                HelpForm.SetFormatForColumn(T.Columns["employnumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["employdenominator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["adminnumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["admindenominator"], "n");
            }
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess, out errfield))return false;

            if (R["ayear"] == DBNull.Value) {
                errmess = "E' necessario specificare l' anno competenza";
                errfield = "ayear";
                return false;
            }//Aggiunto controllo su ayear per evitare il db error


            if (R["taxablegross"]==DBNull.Value){
				errmess= "E' necessario specificare l' imponibile lordo";
				errfield="taxablegross";
				return false;
			}

            object taxCode = R["taxcode"];
            DataRow Tax = R.GetParentRow("taxexpensetax");
            if ((Tax != null) && (Tax.Table.Columns.Contains("geoappliance"))){
                string geo = Tax["geoappliance"].ToString().ToUpper();
                switch(geo) {
                    case "C": {
                        if (R["idcity"] == DBNull.Value) {
                            errfield = "idcity";
                            errmess = "Specificare il comune per la ritenuta di carattere comunale";
                            return false;
                        }
                        break;
                    }
                    case "R":
                        if (R["idfiscaltaxregion"] == DBNull.Value) {
                            errfield = "idfiscaltaxregion";
                            errmess = "Specificare la regione fiscale per la ritenuta di carattere regionale";
                            return false;
                        }
                        break;
                    default: {
                        if (R["idcity"] != DBNull.Value) {
                            errfield = "idcity";
                            errmess = "Non deve essere specificato il comune per le ritenute a carattere nazionale";
                            return false;
                        }

                        if (R["idfiscaltaxregion"] != DBNull.Value) {
                            errfield = "idfiscaltaxregion";
                            errmess = "Non deve essere specificata la regione fiscale per le ritenute a carattere nazionale";
                            return false;
                        }
                        break;
                    }
                }
            }
			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "expensetaxview", Exclude);
			return base.SelectOne(ListingType,filter,searchtable,Exclude);
		}


        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest)
        {
            if ((C.ColumnName == "ytaxpay") || (C.ColumnName == "ntaxpay") || (C.ColumnName == "competencydate"))
                return;
            base.InsertCopyColumn(C, Source, Dest);
        }
	}
}
