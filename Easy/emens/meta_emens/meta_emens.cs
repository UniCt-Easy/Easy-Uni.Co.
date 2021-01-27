
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

namespace meta_emens {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_emens : Meta_easydata {
		public Meta_emens(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "emens") {		
			EditTypes.Add("consolidamento");
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "default": {
					DefaultListType = "default";
					Name = "Denunce Retributive Mensili";
					return MetaData.GetFormByDllName("emens_default");
				}
                case "unified": {
                    DefaultListType = "default";
                    Name = "Denunce Retributive Mensili";
                    return MetaData.GetFormByDllName("emens_default");
                }

				case "consolidamento": {
					Name = "Consolidamento Denunce Retributive Mensili";
					DefaultListType = "default";
					return MetaData.GetFormByDllName("emens_consolida");
				}
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"adate",GetSys("datacontabile"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idemens"],null,null,0);
			return base.Get_New_Row (ParentRow, T);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (R["rtf"] == DBNull.Value) {
				errmess = "Bisogna generare l'E-Mens prima di salvare - Clicca sul Bottone Genera E-Mens";
				errfield = "rtf";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idemens","Numero Denuncia");
				DescribeAColumn(T,"yearnumber","Anno Denuncia");
				DescribeAColumn(T,"startmonth","Mese Inizio Denuncia");
				DescribeAColumn(T,"stopmonth","Mese Fine Denuncia");
				DescribeAColumn(T,"adate","Data Contabile");
				DescribeAColumn(T,"cfhumansender","CF Pers. Mittente");
				DescribeAColumn(T,"sendercompanyname","Ragione Sociale");
				DescribeAColumn(T,"cfsender","CF Mittente");
				DescribeAColumn(T,"inpscenter","Codice Sede INPS");
			}
		}



	}
}
