
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


using metadatalibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace purchasesubmission_single {

    public partial class Frm_purchasesubmission_single : MetaDataForm {

        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        
        public Frm_purchasesubmission_single() {
            InitializeComponent();
            dialogSalvaAvviso.Title = "Salva avviso di pagamento";
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterClear() {
            txtIUV.ReadOnly = false;
            txtEsercizio.ReadOnly = false;
            btnAvviso.Enabled = false;
        }

        public void MetaData_AfterFill() {
            txtIUV.ReadOnly = !Meta.InsertMode;
            txtEsercizio.ReadOnly = !Meta.InsertMode;

            AbilitaAvviso();
        }

        private void AbilitaAvviso() {
            if (DS.purchasesubmission.Rows.Count == 0) {
                btnAvviso.Enabled = false;
            }
            else {
                var curr = DS.purchasesubmission.Rows[0];

                btnAvviso.Enabled = !curr.IsNull("idattachment");
            }
        }

        private void btnAvviso_Click(object sender, EventArgs e) {
            if (DS.purchasesubmission.Rows.Count == 0) return;
            var curr = DS.purchasesubmission.Rows[0];

            var idattachment = curr.Field<Guid>("idattachment");

            if (dialogSalvaAvviso.ShowDialog(this) == DialogResult.Cancel) return;

            // TODO: estrarre il file dal DB
        }

    }

}
