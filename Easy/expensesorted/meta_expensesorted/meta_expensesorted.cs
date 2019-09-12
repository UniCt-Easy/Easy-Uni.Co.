/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
//using impclassspesasingle;
//using impclassspesa_main;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_expensesorted//meta_impclassspesa//
{
	
	public class Meta_expensesorted : Meta_easydata {
		public Meta_expensesorted(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensesorted") {
			EditTypes.Add("default");
			EditTypes.Add("main"); //by Leo
			EditTypes.Add("relation"); // Ros
			EditTypes.Add("all");
			ListingTypes.Add("default");
			//ListingTypes.Add("lista"); //by Leo
		}


		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name = "Classificazione Movimenti di spesa";
				//return new frmImpClassSpesa();
				return MetaData.GetFormByDllName("expensesorted_default");
			}

			//by Leo
			if (FormName=="main")
			{
				Name = "Classificazione Movimenti di spesa";
				//DefaultListType="lista";
				//return new frmimpclassspesa_main();
				return MetaData.GetFormByDllName("expensesorted_main");
			}

			if (FormName == "all") {
				Name = "Classificazione Movimenti di spesa";
				return MetaData.GetFormByDllName("expensesorted_all");
			}

			if (FormName=="relation")
			{
				Name = "Classificazione Movimenti di spesa";
				DefaultListType="lista";
				return MetaData.GetFormByDllName("expensesorted_main");
				//return new frmimpclassspesa_main();
			}
			return null;
		}			

		//by Leo
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType.StartsWith("lista."))
				return base.SelectOne(ListingType, filter, "expensesortedview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "expensesorted", Exclude);
		}		 

		public override void SetEntityDetail(DataRow SourceRow)
		{
			DS.Tables["expensesorted"].ExtendedProperties["importototale"]= 
				SourceRow.Table.ExtendedProperties["importototale"];
			DS.Tables["expensesorted"].ExtendedProperties["importoresiduo"]= 
				SourceRow.Table.ExtendedProperties["importoresiduo"];
            DS.Tables["expensesorted"].ExtendedProperties["CustomParentRelation"] =
                SourceRow.Table.ExtendedProperties["CustomParentRelation"];
			CopyCustomFilter(SourceRow);
		}   

		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			DataTable Unfiltered= (DataTable) R.Table.ExtendedProperties["UnfilteredTable"];
			if (Unfiltered==null) Unfiltered = R.Table;
			if (Unfiltered.ExtendedProperties["TotaleImporto"]==null) return;
			decimal tot = CfgFn.GetNoNullDecimal(Unfiltered.ExtendedProperties["TotaleImporto"]);
			if (tot==0) {
				R["!percentuale"]="-";
				return;
			}
			decimal perc= CfgFn.GetNoNullDecimal(R["amount"])/tot;
			R["!percentuale"]= perc.ToString("p");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                int nPos = 1;
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "description", "Commento", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "!idsorkind", "", "sorting.idsorkind", nPos++);
                DescribeAColumn(T, "idsubclass", "#", nPos++);
				DescribeAColumn(T,"flagnodate","");
				DescribeAColumn(T,"tobecontinued","");
				DescribeAColumn(T,"paridsor","");
				DescribeAColumn(T,"paridsubclass","");
				DescribeAColumn(T,"start","");
				DescribeAColumn(T,"stop","");
				DescribeAColumn(T,"idsor","");
				DescribeAColumn(T,"idexp","");
                DescribeAColumn(T, "!codice", "Cod.", "sorting.sortcode", nPos++);
                DescribeAColumn(T, "!percentuale", "%", "", nPos++);
                DescribeAColumn(T, "!descr", "Descrizione", "sorting.description", nPos++);
				for(int i=1;i<=5;i++){
					DescribeAColumn(T,"valuen"+i.ToString(),"");
					DescribeAColumn(T,"values"+i.ToString(),"");
					DescribeAColumn(T,"valuev"+i.ToString(),"");
				}
				ComputeRowsAs(T, "default");

			}
		}
		void CopyCustomFilter(DataRow SourceRow){
			if (SourceRow.Table.ExtendedProperties["ExtraParams"]==null) return;
            DataRow parent = SourceRow.GetParentRow("sortingexpensesorted");
            if (parent == null) return;
            string filter = QHC.CmpEq("!idsorkind", parent["idsorkind"]);
			DataTable OldTable = 
				(DataTable) SourceRow.Table.ExtendedProperties[MetaData.ExtraParams];
			DataTable newTable = OldTable.Clone();
			DataRow []selected = OldTable.Select(filter);
			foreach(DataRow R in selected){
				DataRow newR= newTable.NewRow();
				foreach(DataColumn C in newTable.Columns){
					newR[C]= R[C.ColumnName];
				}
				newTable.Rows.Add(newR);
				newR.AcceptChanges();
			}
			PrimaryDataTable.ExtendedProperties[MetaData.ExtraParams]= newTable;
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(
				T.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
		    RowChange.setMinimumTempValue(T.Columns["idsubclass"],1000);
			//RowChange.SetSelector(T, "idsorkind");
			RowChange.SetSelector(T, "idexp");
			RowChange.SetSelector(T, "idsor");
			return base.Get_New_Row (ParentRow, T);
		}


		override public bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;
			if (DS.Tables["sortingkind"]==null) return true;
            DataRow parent = R.GetParentRow("sortingexpensesorted");
            if (parent == null) {
                return true;
            }
			string filtercodice= QHC.CmpEq("idsorkind", parent["idsorkind"]);
			DataRow [] tipoclass= DS.Tables["sortingkind"].Select(filtercodice);
			if (tipoclass.Length==0) return true; //??

            if (R["amount"] == DBNull.Value) {
                errmess = "L'importo della classificazione deve sempre essere specificato";
                errfield = "amount";
                return false;
            }

			if (edit_type=="default")
			{
				if (DS.Tables["sorting"]==null) return true;

                string filteridcodice = QHC.CmpEq("idsor", R["idsor"]);
				DataRow [] classmov= DS.Tables["sorting"].Select(filteridcodice);
				if (classmov.Length==0) return true; //??

				DataRow CurrTipo= tipoclass[0];
				DataRow CurrClass= classmov[0];

				//Evaluates flagincompleto and checks forced columns to be not null
				bool flagincompleto=false;
				foreach (char C in new char[3] {'n','s','v'})
				{
					for (int i=1;i<=5;i++)
					{
						string suffix = C.ToString()+i.ToString();
						if ((CurrTipo["forced"+suffix].ToString().ToLower()=="s") &&
							(R["value"+C.ToString()+i.ToString()]==DBNull.Value))
						{
							if (MessageBox.Show(
								"Il campo "+CurrTipo["label"+suffix].ToString()+
								" non dovrebbe essere vuoto. Proseguo lo stesso?",
								"Avviso",
								MessageBoxButtons.YesNo)!= DialogResult.Yes)
							{
								errfield= "value"+suffix;
								errmess=null;
								return false;
							}
							flagincompleto=true;
						}
					}
				}
				if ((CurrClass["flagnodate"].ToString().ToLower()=="n") &&
					(R["flagnodate"].ToString().ToLower()=="n") )
				{				
					if (R["start"].ToString().Equals(""))
					{
						if (MessageBox.Show(
							"Il campo datainizio non dovrebbe essere vuoto. Proseguo lo stesso?",
							"Avviso",
							MessageBoxButtons.YesNo)!= DialogResult.Yes)
						{
							errfield= "start";
							errmess=null;
							return false;
						}
						else 
						{
							flagincompleto=true;
						}					
					}
					if (R["stop"].ToString().Equals(""))
					{
						if (MessageBox.Show(
							"Il campo datafine non dovrebbe essere vuoto. Proseguo lo stesso?",
							"Avviso",
							MessageBoxButtons.YesNo)!= DialogResult.Yes)
						{
							errfield= "stop";
							errmess=null;
							return false;
						}
					}
					else 
					{
						flagincompleto=true;
					}					
				}

				if ((flagincompleto)&&(R["tobecontinued"].ToString().ToLower()==""))
				{
					R["tobecontinued"]="S";
				}
			}
			if (edit_type=="main")
			{
				if (DS.Tables["sortingview"]==null) return true;

				string filteridcodice = QHC.CmpEq("idsor", R["idsor"]);
				DataRow [] classmov= DS.Tables["sortingview"].Select(filteridcodice);
				if (classmov.Length==0) return true; //??

				DataRow CurrTipo= tipoclass[0];
				DataRow CurrClass= classmov[0];

				//Evaluates flagincompleto and checks forced columns to be not null
				bool flagincompleto=false;
				foreach (char C in new char[3] {'n','s','v'})
				{
					for (int i=1;i<=5;i++)
					{
						string suffix = C.ToString()+i.ToString();
						if ((CurrTipo["forced"+suffix].ToString().ToLower()=="s") &&
							(R["value"+C.ToString()+i.ToString()]==DBNull.Value))
						{
							if (MessageBox.Show(
								"Il campo "+CurrTipo["label"+suffix].ToString()+
								" non dovrebbe essere vuoto. Proseguo lo stesso?",
								"Avviso",
								MessageBoxButtons.YesNo)!= DialogResult.Yes)
							{
								errfield= "valore"+suffix;
								errmess=null;
								return false;
							}
							flagincompleto=true;
						}
					}
				}
				if ((CurrClass["flagnodate"].ToString().ToLower()=="n") &&
					(R["flagnodate"].ToString().ToLower()=="n") ) {				
					if (R["start"].ToString().Equals("")) {
						if (MessageBox.Show(
							"Il campo datainizio non dovrebbe essere vuoto. Proseguo lo stesso?",
							"Avviso",
							MessageBoxButtons.YesNo)!= DialogResult.Yes) {
							errfield= "start";
							errmess=null;
							return false;
						}
						else {
							flagincompleto=true;
						}					
					}
					if (R["stop"].ToString().Equals("")) {
						if (MessageBox.Show(
							"Il campo datafine non dovrebbe essere vuoto. Proseguo lo stesso?",
							"Avviso",							
							MessageBoxButtons.YesNo)!= DialogResult.Yes) {
							errfield= "stop";
							errmess=null;
							return false;
						}
					}
					else {
						flagincompleto=true;
					}					
				}

				if ((flagincompleto)&&(R["tobecontinued"].ToString().ToLower()==""))
				{
					R["tobecontinued"]="S";
				}
			}
			return true;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			MetaData.SetDefault(PrimaryTable,"tobecontinued","N");
			MetaData.SetDefault(PrimaryTable,"flagnodate","S");
			MetaData.SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}


	}


}