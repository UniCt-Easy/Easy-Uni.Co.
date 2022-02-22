
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


 namespace meta_servicetrasmission 
 {
	 /// <summary>
	 /// Summary description for Class1.
	 /// </summary>
	 public class Meta_servicetrasmission : Meta_easydata 
	 {
		 public Meta_servicetrasmission(DataAccess Conn, MetaDataDispatcher Dispatcher):
			 base(Conn, Dispatcher, "servicetrasmission") 
		 {		
			 EditTypes.Add("default");
			 ListingTypes.Add("default");
		 }
		 protected override Form GetForm(string FormName) 
		 {
			DefaultListType = "default";
			Name = "Trasmissione Anagrafe delle Prestazioni";
			return MetaData.GetFormByDllName("servicetrasmission_default");
		 }

		 public override void SetDefaults(DataTable PrimaryTable) 
		 {
			 base.SetDefaults (PrimaryTable);
			 SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		 }

		 public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) 
		 {
			 RowChange.MarkAsAutoincrement(T.Columns["idtrasmission"],null,null,0);
             return base.Get_New_Row (ParentRow, T);
		 }

		 public override bool IsValid(DataRow R, out string errmess, out string errfield) 
		 {
			 if (!base.IsValid (R, out errmess, out errfield)) return false;
//			 if (R["rtf"] == DBNull.Value) 
//			 {
//				 errmess = "Bisogna generare prima di salvare - Clicca sul Bottone Genera ";
//				 errfield = "rtf";
//				 return false;
//			 }
			 return true;
		 }


         public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
             if (ListingType == "default")
                 return base.SelectOne(ListingType, filter, "servicetrasmissionview", ToMerge);

             return base.SelectOne(ListingType, filter, "servicetrasmission", ToMerge);
         }

		 public override void DescribeColumns(DataTable T, string ListingType) 
		 {
			 base.DescribeColumns (T, ListingType);
			 if (ListingType=="default") 
			 {
				 foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				 DescribeAColumn(T,"idtrasmission","Numero Trasmissione");
				 DescribeAColumn(T,"adate","Data Contabile");
				 
			 }
		 }



	 }
 }
