
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Linq;
using q = metadatalibrary.MetaExpression;

namespace assetload_default {
    public partial class FrmAskDescr : Form {
        MetaDataDispatcher Disp;
        DataAccess Conn;
        DataSet D;
        public DataRow Selected;
        public object CodInv;
        public DataTable Inv;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAskDescr(MetaDataDispatcher Disp, object CodiceInventario) {
            InitializeComponent();
            this.Disp = Disp;
            this.Conn = Disp.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            CodInv = CodiceInventario;
            D = new DataSet();
            FormInit();
        }
        void FormInit() {
            DataTable Invoicekind = Conn.CreateTableByName("invoicekind", "*");
            GetData.MarkToAddBlankRow(Invoicekind);
            GetData.Add_Blank_Row(Invoicekind);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, Invoicekind, "description asc", QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2)), null, true);
            cmbInv.DataSource = Invoicekind;
            cmbInv.DisplayMember = "description";
            cmbInv.ValueMember = "idinvkind";
        }
 
        private void riempiTextBox(DataRow Rinv) {
            if (Rinv == null) {
                txtNinv.Text = "";
                return;
            }
            if (Rinv["idinvkind"] != null && Rinv["idinvkind"] != DBNull.Value) {
                cmbInv.SelectedValue = Rinv["idinvkind"];
            }
            txtYinv.Text = Rinv["yinv"].ToString();
            txtNinv.Text = Rinv["ninv"].ToString();
            btnOk.Focus();
        }
        private void ScegliFattura() {
            string filter = GetFilter();

            MetaData E = Disp.Get("invoiceview");
            E.FilterLocked = true;
            E.DS = D.Clone();
            Selected = E.SelectOne("default", filter, "invoiceview", null);

            riempiTextBox(Selected);
        }
        private void FrmAskDescr_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
            if (DialogResult==DialogResult.OK && Selected == null) {
                MessageBox.Show("E' necessario scegliere la fattura", "Ok");
                e.Cancel = true;
            }
        }
        private void txtYinv_Leave(object sender, EventArgs e) {
            if (txtYinv.Text.Trim() == "") {
                txtYinv.Text = "";
            }
            if (txtYinv.Text.Trim() != "") {
                txtYinv.Text = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtYinv.Text, "x.y")).ToString();
            }
                txtNinv.Focus();
        }
        private void txtNinv_Leave(object sender, EventArgs e) {
            if (txtNinv.Text.Trim() == "") {
                txtNinv.Text = "";
            }
            if (txtNinv.Text.Trim() != "") {
                txtNinv.Text=CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtNinv.Text, "x.y")).ToString();
            }
            ScegliFattura();
        }
        private string GetFilter() {
            string filter = QHS.CmpEq("flagbuysell","A");
            if (cmbInv.SelectedIndex > 0) {
                filter =  QHS.CmpEq("idinvkind", cmbInv.SelectedValue);
            }
            if (txtYinv.Text.Trim() != "") {
                int Esercizio = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtYinv.Text, "x.y"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("yinv", Esercizio));
            }
            if (txtNinv.Text.Trim() != "") {
                int Numero = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtNinv.Text, "x.y"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", Numero));
            }
            
            return filter;

        }

        private void btnSeleziona_Click(object sender, EventArgs e) {
            ScegliFattura();
        }
    }
}
