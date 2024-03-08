
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
using q=metadatalibrary.MetaExpression;
using metaeasylibrary;
using funzioni_configurazione;

namespace incomelastestimatedetail_detail {
	public partial class frmeincomelastestimatedetail_detail :MetaDataForm {
		MetaData Meta;
		DataAccess Conn;
		public frmeincomelastestimatedetail_detail() {
			InitializeComponent();
		}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			var dsSource = Meta.sourceRow.Table.DataSet;
			var tEstDet = dsSource.Tables["incomelastestimatedetail"];
			var tIncome = dsSource.Tables["income"];
			var existingRowNums = tEstDet._Filter(q.ne("rownum",0))._Pick("rownum").ToArray();

			object idincToConsider = Meta.sourceRow["idinc"];
			if (tIncome.Rows[0].RowState == DataRowState.Added) {
				idincToConsider = tIncome.Rows[0]["parentidinc"];
			}
			var notExist = (existingRowNums.Length>0) ? q.fieldNotIn( "rownum", existingRowNums): q.constant(true);
			//deve filtrare i dettagli appartenenti all'accertamento parent di questo incasso
			q accertate = q.constant(true);
			if (dsSource.Tables["estimatedetail_taxable"].Select().Length == 0) {
				//deve prendere in base a incomelink
				var righe = readTable($@"select ed.rownum from estimatedetail ed 
											join incomelink il on ed.idinc_taxable=il.idparent
											where {toString(q.eq("il.idchild",idincToConsider) & q.isNull("stop") & q.mCmp(Meta.sourceRow, "idestimkind", "yestim", "nestim"))} "); //mCmp non serve ma per sicurezza lo metto
				if (righe != null) {
					accertate = q.fieldIn( "rownum", righe.Select()._Pick("rownum").ToArray());
				}
			}
			else {
				//deve prendere le righe di estimatedetails
				accertate = q.fieldIn( "rownum", dsSource.Tables["estimatedetail_taxable"].Select()._Pick("rownum").ToArray());
			}
			

			q filterDetail = q.mCmp(Meta.sourceRow, "idestimkind", "yestim", "nestim")& notExist & q.isNull("stop") & accertate;
			btnSelRiga.Tag = "choose.estimatedetail.dettaglio." + toString(filterDetail);
			cmbTipoContratto.DataSource = DS.estimatekind;
			cmbTipoContratto.ValueMember = "idestimkind";
			cmbTipoContratto.DisplayMember="description";

			if (CfgFn.GetNoNullInt32(Meta.sourceRow["rownum"]) != 0) {
				var amount =  Conn.readValue("estimatedetailtocashin",
					q.mCmp(Meta.sourceRow, "idestimkind", "yestim", "nestim", "rownum"), "taxabletotal");
				txtImponibileEUR.Text =CfgFn.GetNoNullDecimal(amount).ToString("c");
			}
		}

	

		//public void MetaData_AfterActivation() { }
		//public void MetaData_AfterClear() {}
		//public void MetaData_BeforeFill() {}
		//public void MetaData_AfterFill() {}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "estimatedetail") {
				if (R == null) {
					txtImponibileEUR.Text = "";
				}
				else {
					var amount = conn.readValue("estimatedetail_extview", q.keyCmp(R), "taxable_euro");
					txtImponibileEUR.Text =CfgFn.GetNoNullDecimal(amount).ToString("c");
					txtIncassato.Text =  txtImponibileEUR.Text;
				}
			}
		}
		//public void MetaData_BeforePost() { }
		//public void MetaData_AfterPost() { }

	}
}
