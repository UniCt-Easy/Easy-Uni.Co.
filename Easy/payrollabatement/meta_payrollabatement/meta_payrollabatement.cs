
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

namespace meta_payrollabatement {//meta_dettagliodetrazionecedolino//
	/// <summary>
	/// Summary description for Meta_dettagliodetrazionecedolino.
	/// </summary>
	public class Meta_payrollabatement : Meta_easydata {
		public Meta_payrollabatement(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrollabatement") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string EditType) {
			switch (EditType) {
				case "default":
					DefaultListType="default";
					Name = "Dettaglio Detrazioni Cedolino";
					return MetaData.GetFormByDllName("payrollabatement_default");
				case "readonly":
					DefaultListType="default";
					Name = "Dettaglio Detrazioni Cedolino";
					return MetaData.GetFormByDllName("payrollabatement_default");
				default: return null;
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (CfgFn.GetNoNullInt32(R["idabatement"]) <= 0) {
				errmess = "Inserire la detrazione";
				errfield = "idabatement";
				return false;
			}
			if (R["taxcode"] == DBNull.Value) {
				errmess = "Inserire la ritenuta";
				errfield = "taxcode";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idpayroll","");
				DescribeAColumn(T,"idabatement","");
				DescribeAColumn(T,"!codicedetrazione","Codice Det.","abatementcode.code");
				DescribeAColumn(T,"!descrdetrazione","Descrizione Det.","abatementcode.description");
				DescribeAColumn(T,"taxcode","");
				DescribeAColumn(T,"!descrritenuta","Descrizione Ritenuta","tax.description");
				DescribeAColumn(T,"annualamount","Importo Annuo");
				DescribeAColumn(T,"curramount","Importo Corrente");
			}
		}
	}
}
