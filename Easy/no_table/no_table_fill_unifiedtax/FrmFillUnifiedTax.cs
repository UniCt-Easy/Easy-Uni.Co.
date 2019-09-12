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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_fill_unifiedtax {
    public partial class FrmFillUnifiedTax :Form {
        MetaData Meta;
        public FrmFillUnifiedTax() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            bool IsAmministrazione = false;
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            if (Meta.GetSys("userdb") != null) {
                IsAmministrazione = (Meta.GetSys("userdb").ToString().ToLower() == "amministrazione");
            }
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            DateTime dtPrimoDelMese = new DateTime(
            CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")),
            ((DateTime)Meta.GetSys("datacontabile")).Month,
            1);

            DateTime dtUltimoDelMesePrec = dtPrimoDelMese.AddDays(-1);
            //txtDataRiferimento.Text = ((DateTime)Meta.GetSys("datacontabile")).ToShortDateString();

            txtDataRiferimento.Text = dtUltimoDelMesePrec.ToShortDateString();
            HelpForm.ExtLeaveDateTimeTextBox(txtDataRiferimento, null);
            btnFillExpensetax.Enabled = IsAmministrazione;
            btnFillUnifiedClawback.Enabled = IsAmministrazione;

           
        }
        private void btnFillExpensetax_Click(object sender, EventArgs e) {
            if (!DatiValidi()) return;
            object esercizio = HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            object dataRiferimento = HelpForm.GetObjectFromString(typeof(DateTime),
                txtDataRiferimento.Text.ToString(), "x.y");
            Meta.Conn.CallSP("fill_unifiedtax", new object[] { esercizio,
            dataRiferimento}, false, 600);
            MessageBox.Show("Operazione eseguita.");
        }

        private void txtEsercizio_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizio);
        }

        private void txtDataRiferimento_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataRiferimento, null);
        }
        public bool DatiValidi() {
            int esercizio;
            try {
                esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizio.Text.ToString(), "x.y.year");
                if ((esercizio < 0)) {
                    MessageBox.Show("L'esercizio non può essere negativo");
                    txtEsercizio.Focus();
                    return false;
                }

            }
            catch {
                MessageBox.Show("E' necessario inserire un esercizio");
                txtEsercizio.Focus();
                return false;
            }

            try {
                DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataRiferimento.Text.ToString(), "x.y");
                return true;
            }
            catch {
                MessageBox.Show("E' necessario inserire una data valida");
                txtDataRiferimento.Focus();
                return false;
            }

        }

        private void btnFillUnifiedClawback_Click(object sender, EventArgs e) {
            if (!DatiValidi()) return;
            object esercizio = HelpForm.GetObjectFromString(typeof(int),
                txtEsercizio.Text.ToString(), "x.y.year");
            object dataRiferimento = HelpForm.GetObjectFromString(typeof(DateTime),
                txtDataRiferimento.Text.ToString(), "x.y");
            Meta.Conn.CallSP("fill_unifiedclawback", new object[] { esercizio,
            dataRiferimento}, false, 600);
            MessageBox.Show("Operazione eseguita.");
        }

      
    }
}