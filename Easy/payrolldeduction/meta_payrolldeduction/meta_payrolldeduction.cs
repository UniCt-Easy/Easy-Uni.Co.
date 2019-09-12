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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_payrolldeduction {//meta_dettagliodeduzionecedolino//
	/// <summary>
	/// Summary description for Meta_dettagliodeduzionecedolino.
	/// </summary>
	public class Meta_payrolldeduction : Meta_easydata {
		public Meta_payrolldeduction(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrolldeduction") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string EditType) {
			switch (EditType) {
				case "default": 
					DefaultListType="default";
					Name = "Dettaglio Deduzioni Cedolino";
					return MetaData.GetFormByDllName("payrolldeduction_default");
				case "readonly":
					DefaultListType="default";
					Name = "Dettaglio Deduzioni Cedolino";
					return MetaData.GetFormByDllName("payrolldeduction_default");
				default: return null;
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (CfgFn.GetNoNullInt32(R["iddeduction"]) <= 0) {
				errmess = "Inserire la deduzione";
				errfield = "iddeduction";
				return false;
			}
			if (R["taxablecode"] == DBNull.Value) {
				errmess = "Inserire l'imponibile";
				errfield = "taxablecode";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idpayroll","");
				DescribeAColumn(T,"iddeduction","");
				DescribeAColumn(T,"!codicededuzione","Codice Ded.","deductioncode.code");
				DescribeAColumn(T,"!descrdeduzione","Descrizione Ded.","deductioncode.description");
				DescribeAColumn(T,"taxablecode","");
				DescribeAColumn(T,"!descrimponibile","Descrizione Imponibile","taxablecode.description");
				DescribeAColumn(T,"annualamount","Importo Annuo");
				DescribeAColumn(T,"curramount","Importo Corrente");
			}
		}
	}
}