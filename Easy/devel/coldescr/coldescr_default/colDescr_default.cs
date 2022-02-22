
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace coldescr_default {
    public partial class colDescr_default : MetaDataForm {
        public colDescr_default() {
            InitializeComponent();
        }

        private MetaData meta;
        private DataAccess conn;
        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            conn = meta.Conn;
            DS.colbit.Columns["nbit"].ExtendedProperties["allowZero"] = 1;
          
        }
        public void MetaData_AfterClear() {
            rdbCodificato.Visible = true;
            rdbSemplice.Visible = true;
            rdbBit.Visible = true;
            btnCreaFlag.Visible = false;
            if (!this.Modal) {
                btnCancel.Visible = false;
                btnOk.Visible = false;
            }
        }

        public void MetaData_BeforeFill() {
            if (DS.colvalue.Rows.Count > 0 && !tabControl1.TabPages.Contains(tabPageValori)) {
                tabControl1.TabPages.Add(tabPageValori);
            }
            if (DS.colbit.Rows.Count > 0 && !tabControl1.TabPages.Contains(tabPageBit)) {
                tabControl1.TabPages.Add(tabPageBit);
            }

        }
        public void MetaData_AfterFill() {
            if (!this.Modal) {
                btnCancel.Visible = false;
                btnOk.Visible = false;
            }

            calcolaTab();
            if (DS.colvalue.Rows.Count>0) {
                rdbCodificato.Visible = true;
                rdbSemplice.Visible = false;
                rdbBit.Visible = false;
                btnCreaFlag.Visible = false;
            }
            if (DS.colbit.Rows.Count > 0) {
                rdbCodificato.Visible = false;
                rdbSemplice.Visible = false;
                rdbBit.Visible = true;
                btnCreaFlag.Visible = false;
            }
            if (DS.colvalue.Rows.Count == 0 && DS.colbit.Rows.Count == 0) {
                rdbCodificato.Visible = true;
                rdbSemplice.Visible = true;
                rdbBit.Visible = true;
                btnCreaFlag.Visible = true;
            }
        }

        void calcolaTab() {
            if (rdbSemplice.Checked) {
                tabControl1.Visible = false;
            }
            else {
                tabControl1.Visible = true;
                tabControl1.TabPages.Clear();
                if (rdbCodificato.Checked) tabControl1.TabPages.Add(tabPageValori);
                if (rdbBit.Checked) tabControl1.TabPages.Add(tabPageBit);
            }
        }

        private void btnImporta_Click(object sender, EventArgs e) {
            if (meta.IsEmpty) return;
            DataRow curr = DS.coldescr.Rows[0];
            selezionaCampi f = new selezionaCampi(1);
            if (f.ShowDialog() != DialogResult.OK) return;
            string table = f.txtTable.Text;
            string chiave = f.txtKey.Text;
            string valore = f.txtVal.Text;
            string descr = f.txtDescr.Text;
            string listFields = chiave;
            if (valore !=null && valore != "" && valore !=chiave) listFields += "," + valore;
            if (descr!=null && descr != "" && descr!= valore && descr!=chiave) listFields += "," + descr;
            DataTable t = conn.RUN_SELECT(table, listFields, null, null, null, false);
            if (t == null) return;
            MetaData colval = meta.Dispatcher.Get("colvalue");
            foreach (DataRow r in t.Rows) {
                DataRow cv = colval.Get_New_Row(curr, DS.colvalue);
                cv["value"] = r[chiave];
                if (valore != null && valore != "") {
                    cv["title"] = r[valore];
                }
                if (descr != null && descr != "") {
                    cv["description"] = r[descr];
                }
            }
        }

        private void rdbSemplice_CheckedChanged(object sender, EventArgs e) {
            if (meta == null) return;
            if (!meta.DrawStateIsDone) return;
            calcolaTab();
        }

        private void btnCreaFlag_Click(object sender, EventArgs e) {
            if (meta.IsEmpty) return;
            if (DS.colvalue.Rows.Count > 0) return;
            meta.GetFormData(true);
            DataRow r = DS.coldescr.Rows[0];
            MetaData valMeta = meta.Dispatcher.Get("coldescr");
            valMeta.SetDefaults(DS.coldescr);
            DataRow valS = valMeta.Get_New_Row(r, DS.colvalue);
            valS["value"] = "S";
            valS["title"] = r["description"];

            DataRow valN = valMeta.Get_New_Row(r, DS.colvalue);
            valN["value"] = "N";
            valN["title"] = "Non è vero che: \"" + r["description"] +"\"";

            r["kind"] = "C";
            meta.FreshForm();
        }
    }
}
