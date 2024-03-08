
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace no_table_travasa_varinizialibudget {
    public partial class Frm_travasa_varinizialibudget : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        private int esercizio;
        public Frm_travasa_varinizialibudget() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
        }

        private void btnOK_Click(object sender, EventArgs e) {
            object datadiriferimento = HelpForm.GetObjectFromString(typeof(DateTime), txtData.Text, "x.y");
            if ((datadiriferimento == null) || (datadiriferimento == DBNull.Value)) {
                show(this, "La data immessa non è valida, procedura interrotta", "Errore");
                return;
            }

            string errMess =Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            if (errMess != null) {
                show("C'è già una transazione attiva, attendere il completamento dell'altra operazione in corso", "Errore");
                return;
            }

            DataSet ds = Conn.CallSP("compute_copy_budgetvariationinitial",
                new object[] { Meta.GetSys("esercizio"), datadiriferimento },
                600, out errMess);
            if (errMess != null) {
                Conn.RollBack();
                show(this, "Errore nella chiamata della procedura che trasferisce le variazioni iniziali di Budget nel Budget del Conto." +
                     "La transazione è stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
               
                return;
            }
            string msg =Conn.Commit();
            if (msg == null) {
                show(this, "Variazioni iniziali trasferite nel Budget del Conto.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                show(this, "Errore nel salvataggio dei dati.\r\n" + msg, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtData_TextChanged(object sender, EventArgs e) {

        }

        private void txtData_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtData, null);
        }
    }
}
