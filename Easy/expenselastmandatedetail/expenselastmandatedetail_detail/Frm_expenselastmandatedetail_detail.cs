
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using q = metadatalibrary.MetaExpression;
using metaeasylibrary;
using funzioni_configurazione;

namespace expenselastmandatedetail_detail {
	public partial class Frm_expenselastmandatedetail_detail : MetaDataForm {
		MetaData Meta;
		DataAccess Conn;
		public Frm_expenselastmandatedetail_detail() {
			InitializeComponent();
			}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			var dsSource = Meta.sourceRow.Table.DataSet;
			var tEstDet = dsSource.Tables["expenselastmandatedetail"];
			var texpense = dsSource.Tables["expense"];
			var existingRowNums = tEstDet._Filter(q.ne("rownum", 0))._Pick("rownum").ToArray();

			object idexpToConsider = Meta.sourceRow["idexp"];
			if (texpense.Rows[0].RowState == DataRowState.Added) {
				idexpToConsider = texpense.Rows[0]["parentidexp"];
				}
			var notExist = (existingRowNums.Length > 0) ? q.fieldNotIn("rownum", existingRowNums) : q.constant(true);
			//deve filtrare i dettagli appartenenti all'impegno parent di questo pagamento
			q impegnate = q.constant(true);
			if (dsSource.Tables["mandatedetail_taxable"].Select().Length == 0) {
				//deve prendere in base a expenselink
				var righe = readTable($@"select ed.rownum from mandatedetail ed 
											join expenselink il on ed.idexp_taxable=il.idparent
											where {toString(q.eq("il.idchild", idexpToConsider) & q.isNull("stop") & q.mCmp(Meta.sourceRow, "idmankind", "yman", "nman"))} "); //mCmp non serve ma per sicurezza lo metto
				if (righe != null && righe.Rows.Count > 0) {
					impegnate = q.fieldIn("rownum", righe.Select()._Pick("rownum").ToArray());
					}
				}
			else {
				//deve prendere le righe di mandatedetails
				impegnate = q.fieldIn("rownum", dsSource.Tables["mandatedetail_taxable"].Select()._Pick("rownum").ToArray());
				}


			q filterDetail = q.mCmp(Meta.sourceRow, "idmankind", "yman", "nman") & notExist & q.isNull("stop") & impegnate;
			btnSelRiga.Tag = "choose.mandatedetail.dettaglio." + toString(filterDetail);
			cmbTipoContratto.DataSource = DS.mandatekind;
			cmbTipoContratto.ValueMember = "idmankind";
			cmbTipoContratto.DisplayMember = "description";

			if (CfgFn.GetNoNullInt32(Meta.sourceRow["rownum"]) != 0) {
				var amount = Conn.readValue("mandatedetailtocashout",
					q.mCmp(Meta.sourceRow, "idmankind", "yman", "nman", "rownum"), "taxabletotal");
				txtImponibileEUR.Text = CfgFn.GetNoNullDecimal(amount).ToString("c");
				}
			}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "mandatedetail") {
				if (R == null) {
					txtImponibileEUR.Text = "";
					}
				else {
					var amount = conn.readValue("mandatedetail_extview", q.keyCmp(R), "taxable_euro");
					txtImponibileEUR.Text = CfgFn.GetNoNullDecimal(amount).ToString("c");
					txtIncassato.Text = txtImponibileEUR.Text;
					}
				}
			}
		}
	}
