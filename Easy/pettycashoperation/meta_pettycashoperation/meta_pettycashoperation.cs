/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace meta_pettycashoperation {//meta_opfondopiccolespese//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_pettycashoperation : Meta_easydata {
		public Meta_pettycashoperation(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashoperation") {
			EditTypes.Add("default");
			EditTypes.Add("wiz_apertura");
			EditTypes.Add("wiz_chiusura");
			EditTypes.Add("wiz_reintegro");
            EditTypes.Add("wizardinvoicedetail");
			ListingTypes.Add("lista");
		}
		
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (! base.IsValid (R, out errmess, out errfield)) return false;
			if (R.Table.Columns["idexp"]==null) return true;

            if (CfgFn.GetNoNullDecimal(R["idpettycash"]) == 0) 
            {
                errmess = "Non Ë stato selezionato il Fondo Economale";
                errfield = "idpettycash";
                return false;
            }

			if (((R["idfin"]!=DBNull.Value) ||
				(R["idupb"]!=DBNull.Value)) &&
				(R["idexp"]!=DBNull.Value)){
				errmess="Non Ë possibile specificare sia il movimento di spesa che un'attribuzione normale";
				return false;
			}
			
			if (R["amount"]==DBNull.Value) {
				errmess="Non Ë stato immesso l'importo originale";
				errfield="amount";
				return false;
			}
			if (CfgFn.GetNoNullDecimal(R["amount"])<0) {
				errmess="L'importo non puÚ essere negativo";
				errfield="amount";
				return false;
			}
            if (CfgFn.GetNoNullDecimal(R["nlist"]) < 0)
            {
                errmess = "Il numero Nota Spese puÚ essere negativo";
                errfield = "nlist";
                return false;
            }
			return true;
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="lista";
				Name = "Operazione";
				Form F = GetFormByDllName("pettycashoperation_default");
				//frmopfondopiccolespese F = new frmopfondopiccolespese();
				return F;
			}

			if (FormName=="wiz_apertura") {
				DefaultListType="lista";
				Name = "Apertura";
				Form F = GetFormByDllName("pettycashoperation_wiz_apertura");
				//frmwizard_aperturafondops F = new frmwizard_aperturafondops();
				return F;
			}

			if (FormName=="wiz_chiusura") {
				DefaultListType="lista";
				Name = "Chiusura";
				Form F= GetFormByDllName("pettycashoperation_wiz_chiusura");
				//frmwizardchiusurafondops F = new frmwizardchiusurafondops();
				return F;
			}

			if (FormName=="wiz_reintegro") {
				DefaultListType="lista";
				Name = "Reintegro";
				Form F = GetFormByDllName("pettycashoperation_wiz_reintegro");
				//frmwizard_reintegrofondops F = new frmwizard_reintegrofondops();
				return F;
			}

            if (FormName == "wizardinvoicedetail"){
                DefaultListType = "lista";
                Form F = GetFormByDllName("pettycashoperation_wizardinvoicedetail");
                return F;
            }


			return null;
		}		

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "idpettycash");
			RowChange.SetSelector(T, "yoperation");
			RowChange.MarkAsAutoincrement(T.Columns["noperation"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "noperation");
            if (N < 990000)
                R["noperation"] = 990000;
            else
                R["noperation"] = N + 1;

			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yoperation", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			//SetDefault(PrimaryTable, "kind", "S");
			//SetDefault(PrimaryTable, "flagdocumented", "D");
            int flag = CfgFn.GetNoNullInt32(PrimaryTable.Columns["flag"].DefaultValue);
            flag &= 0xF0;
            flag |= 0x18; 
            SetDefault(PrimaryTable, "flag", flag);
    		SetDefault(PrimaryTable, "yrestore", DBNull.Value);
			SetDefault(PrimaryTable, "nrestore", DBNull.Value);
		}
		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if ((C.ColumnName == "yrestore") || (C.ColumnName == "nrestore"))return;
			base.InsertCopyColumn (C, Source, Dest);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista")
				return base.SelectOne(ListingType, filter, "pettycashoperationview", Exclude);
			if (ListingType=="iva")
				return base.SelectOne("default",filter, "pettycashopinvoiceview", Exclude);
			if (ListingType=="missione")
				return base.SelectOne("default",filter, "pettycashopitinerationview", Exclude);
			if (ListingType=="occasionale")
				return base.SelectOne("default",filter, "pettycashopcasualcontractview", Exclude);
			if (ListingType=="professionale")
				return base.SelectOne("default",filter, "pettycashopprofserviceview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "pettycashoperation", Exclude);
		}		


		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos=1;
				DescribeAColumn(T, "yoperation", "Eserc. op.",nPos++);
				DescribeAColumn(T, "noperation", "Num. op.",nPos++);
				DescribeAColumn(T, "idpettycash", "Cod. fondo",nPos++);
				//DescribeAColumn(T, "kind", "Tipo op.",nPos++);
				//DescribeAColumn(T, "flagdocumented", "Tipo spesa",nPos++);
				DescribeAColumn(T, "yrestore", "Eserc. reintegro",nPos++);
				DescribeAColumn(T, "nrestore", "Num. reintegro",nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "doc", "Documento",nPos++);
				DescribeAColumn(T, "docdate", "Data doc.",nPos++);
				DescribeAColumn(T, "amount", "Importo",nPos++);
				DescribeAColumn(T, "adate", "Data contabile",nPos++);
			}
		}   
	}



}
