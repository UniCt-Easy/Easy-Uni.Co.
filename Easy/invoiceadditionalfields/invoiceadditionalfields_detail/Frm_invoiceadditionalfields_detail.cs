
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace invoiceadditionalfields_detail {
	public partial class Frm_invoiceadditionalfields_detail : MetaDataForm {
		MetaData Meta;
		private IFormController controller;
		IDataAccess Conn;
		public Frm_invoiceadditionalfields_detail() {
			InitializeComponent();
		}
		QueryHelper QHS;
		CQueryHelper QHC;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = this.getInstance<IDataAccess>();
			controller = this.getInstance<IFormController>();
			QHC = new CQueryHelper();
			GetData.CacheTable(DS.invoicemultifieldkind);
		}
		//Valorizza le label che in realtà sono Text con il "fieldcode" di invoicemultifieldkind
		//Se il valore è già presente in "invoiceadditionalfields", lo scrive direttamente nel text, diversamente lo legge dalla 
		// tabella di configurazione per consentirne la valorizzazione
		public void ValorizzaLabel() {
			DataRow Curr = DS.invoiceadditionalfields.Rows[0];
			string filterDoc = qhc.AppAnd(QHC.CmpEq("tabname", "DatiOrdineAcquisto"));
			DataRow[] RR = DS.invoicemultifieldkind.Select(filterDoc, "ordernumber asc");
			if (RR.Length > 0) {
				grpBox1.Text = RR[0]["tabname"].ToString();
				//Curr["documentkind"] = RR[0]["documentkind"].ToString();
				//grpBox1.Text = RR[0]["documentkind"].ToString() + ": " + RR[0]["tabname"].ToString();
				if (controller.InsertMode) {
					Curr["documentkind"] = RR[0]["documentkind"].ToString();
				}
			}
			//Può capitare che un campo non sia stato scritto o che sia stato cancellato
			string filterInt = qhc.AppAnd(QHC.CmpEq("tabname", "DatiOrdineAcquisto"), QHC.CmpEq("systype", "int"), QHC.CmpEq("active", "S"));
			DataRow[] Rint = DS.invoicemultifieldkind.Select(filterInt, "ordernumber asc");
			if (Rint.Length > 0) {
				grpInt1.Text = Rint[0]["fieldname"].ToString();
				txtLabelforInt1.Text = (Curr["labelfield1int"] != DBNull.Value) ? Curr["labelfield1int"].ToString() : Rint[0]["fieldcode"].ToString();

			}
			string filterStr = qhc.AppAnd(QHC.CmpEq("tabname", "DatiOrdineAcquisto"), QHC.CmpEq("systype", "string"), QHC.CmpEq("active", "S"));
			DataRow[] Rstr = DS.invoicemultifieldkind.Select(filterStr, "ordernumber asc");
			if (Rstr.Length == 3) {
				grpString1.Text = Rstr[0]["fieldname"].ToString();
				grpString2.Text = Rstr[1]["fieldname"].ToString();
				grpString3.Text = Rstr[2]["fieldname"].ToString();
				txtLabelforString1.Text = (Curr["labelfield1str"] != DBNull.Value) ? Curr["labelfield1str"].ToString() : Rstr[0]["fieldcode"].ToString();
				txtLabelforString2.Text = (Curr["labelfield2str"] != DBNull.Value) ? Curr["labelfield2str"].ToString() : Rstr[1]["fieldcode"].ToString();
				txtLabelforString3.Text = (Curr["labelfield3str"] != DBNull.Value) ? Curr["labelfield3str"].ToString() : Rstr[2]["fieldcode"].ToString();
			}

			string filterDate = qhc.AppAnd(QHC.CmpEq("tabname", "DatiOrdineAcquisto"), QHC.CmpEq("systype", "date"), QHC.CmpEq("active", "S"));
			DataRow[] Rdate = DS.invoicemultifieldkind.Select(filterDate, "ordernumber asc");
			if (Rdate.Length > 0) {
				grpDate1.Text = Rdate[0]["fieldname"].ToString();
				txtLabelforDate1.Text = (Curr["labelfield1date"] != DBNull.Value) ? Curr["labelfield1date"].ToString() : Rdate[0]["fieldcode"].ToString();
			}

			//Insert
			if (controller.InsertMode) {
			}
			// Edit
			else {
				textFieldInt1.Text = HelpForm.StringValue(Curr["valuefield1int"], textFieldInt1.Tag.ToString());
				textFieldDate1.Text = HelpForm.StringValue(Curr["valuefield1date"], "x.y");
			}
		}
		public void MetaData_AfterFill() {
			ValorizzaLabel();
		}

		public void MetaData_AfterGetFormData() {
			if (DS.invoiceadditionalfields.Rows.Count == 0) return;
			DataRow Curr = DS.invoiceadditionalfields.Rows[0];
			if (Curr["valuefield1int"] == DBNull.Value) {
				Curr["labelfield1int"] = DBNull.Value;
			}
			if (Curr["valuefield1str"] == DBNull.Value) {
				Curr["labelfield1str"] = DBNull.Value;
			}
			if (Curr["valuefield2str"] == DBNull.Value) {
				Curr["labelfield2str"] = DBNull.Value;
			}

			if (Curr["valuefield3str"] == DBNull.Value) {
				Curr["labelfield3str"] = DBNull.Value;
			}
			if (Curr["valuefield1date"] == DBNull.Value) {
				Curr["labelfield1date"] = DBNull.Value;
			}
		}

		public void MetaData_BeforePost() {
		}

		private void textBox6_TextChanged(object sender, EventArgs e) {

		}

		private void textFieldString3_TextChanged(object sender, EventArgs e) {

		}

		private void txtLabelforString3_TextChanged(object sender, EventArgs e) {

		}

		private void textFieldString2_TextChanged(object sender, EventArgs e) {

		}

		private void grpBox1_Enter(object sender, EventArgs e) {

		}
	}
}
