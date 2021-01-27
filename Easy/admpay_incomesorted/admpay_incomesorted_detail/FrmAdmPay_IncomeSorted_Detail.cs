
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
using System.Globalization;

namespace admpay_incomesorted_detail {
    public partial class FrmAdmPay_IncomeSorted_Detail : Form {

        MetaData Meta;
        decimal importomovimento;
        decimal importoresiduo;
        decimal importototale;
        decimal importooriginale;
        bool inChiusura = false;

        public FrmAdmPay_IncomeSorted_Detail() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Meta.ExtraParameter;
        }

        public void MetaData_AfterActivation() {
            if (DS.admpay_incomesorted.Rows.Count == 0) return;

            DataRow CurrRow = DS.admpay_incomesorted.Rows[0];

            importomovimento = CfgFn.GetNoNullDecimal(CurrRow["amount"]);
            importoresiduo = CfgFn.GetNoNullDecimal(DS.admpay_incomesorted.ExtendedProperties["importoresiduo"]);
            importototale = CfgFn.GetNoNullDecimal(DS.admpay_incomesorted.ExtendedProperties["importototale"]);
            importooriginale = importomovimento;

            txtImporto.ReadOnly = false; //read_only;
            txtPercentuale.ReadOnly = false; //read_only;

            object filterObj = DS.admpay_incomesorted.ExtendedProperties["CustomParentRelation"];
            string filter = "";
            if (filterObj != null) {
                filter = filterObj.ToString();
                filter = filter.Replace("!", "");
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.sortingkind, null, filter, null, true);
            }

            if (DS.sortingkind.Rows.Count == 0) return;
            DataRow Rtipo = DS.sortingkind.Rows[0];
            if (Rtipo["totalexpression"].ToString() == "") {
                importoresiduo = importototale - importooriginale;
            }

            decimal percentuale = 100;
            if (importototale != 0) percentuale = importomovimento / importototale * 100;
            decimal rounded = Math.Round(percentuale, 4);
            txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");

            GetData.SetStaticFilter(DS.sorting, filter);
        }

        private void txtPercentuale_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            // ripristina l'importo originale
            if (!txtPercentuale.Modified) return;
            if (!checkpercentuale()) {
                decimal percentuale = 100;
                if (importototale != 0) percentuale = importomovimento / importototale * 100;
                decimal rounded = Math.Round(percentuale, 4);
                // calcola la percentuale in base all'importo
                txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            }
            else {
                // calcola l'importo in base alla percentuale
                decimal perc = Decimal.Parse(txtPercentuale.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                importomovimento = perc * importototale / 100;
                txtImporto.Text = importomovimento.ToString("c");
            }
        }

        private bool checkpercentuale() {
            bool OK = false;
            if (txtPercentuale.Text == "") return false;
            decimal percentmax = 0;

            if (importototale != 0) percentmax = (importoresiduo + importooriginale) / importototale * 100;
            string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
                "tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
            try {
                decimal percent = Decimal.Parse(txtPercentuale.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                if ((percent < 0) || (percent > percentmax)) {
                    OK = (MessageBox.Show(errmsg, "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
                }
                else {
                    OK = true;
                }

            }
            catch {
                MessageBox.Show("E' necessario digitare un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }
            return OK;
        }

        private void txtImporto_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (!txtImporto.Modified) return;
            if (!checkimporto()) {
                // ripristina l'importo originale
                txtImporto.Text = importomovimento.ToString("c");
            }
            else {
                importomovimento = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));
                decimal percentuale = 100;
                if (importototale != 0) percentuale = importomovimento / importototale * 100;

                decimal rounded = Math.Round(percentuale, 4);
                // calcola la percentuale in base all'importo
                txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            }
        }

        private bool checkimporto() {
            bool OK = false;

            if (txtImporto.Text == "") return false;
            string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
                "tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
            try {
                decimal importo = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));
                if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
                    OK = true;
                }
                else {
                    OK = (MessageBox.Show(errmsg, "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
                }

            }
            catch {
                MessageBox.Show("E' necessario inserire un numero", "Avviso",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }
            return OK;
        }
    }
}
