/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace no_table_iban {
    public partial class FrmNotableIban : Form {
        MetaData Meta;
        QueryHelper QHS;

        public FrmNotableIban() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
        }

        //public static string normalizzaStringa(string s, int lunghezza) {
        //    const string alfanum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    StringBuilder sb = new StringBuilder();
        //    foreach (char c in s.ToUpper()) {
        //        if (alfanum.IndexOf(c) != -1)
        //            sb.Append(c);
        //    }
        //    if (sb.Length > lunghezza) return null;
        //    return sb.ToString().PadLeft(lunghezza, '0');
        //}

        //public static string normalizzaNumero(string s, int lunghezza) {
        //    const string num = "0123456789";
        //    StringBuilder sb = new StringBuilder();
        //    foreach (char c in s) {
        //        if (num.IndexOf(c) != -1)
        //            sb.Append(c);
        //    }
        //    if (sb.Length > lunghezza) return null;
        //    return sb.ToString().PadLeft(lunghezza, '0');
        //}

        private void btnOK_Click(object sender, EventArgs e) {
            string filtro = QHS.AppAnd(
                QHS.IsNull("iban"),
                QHS.IsNotNull("cin"),
                QHS.IsNotNull("idbank"),
                QHS.IsNotNull("idcab"),
                QHS.IsNotNull("cc"));
            DS.registrypaymethod.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.registrypaymethod, null, filtro, null, true);
            foreach (DataRow r in DS.registrypaymethod.Rows) {
                //string cin = normalizzaStringa(r["cin"].ToString(), 1);
                //string abi = normalizzaNumero(r["idbank"].ToString(), 5);
                //string cab = normalizzaNumero(r["idcab"].ToString(), 5);
                //string cc = normalizzaNumero(r["cc"].ToString(), 12);
                string cin = r["cin"].ToString();
                string abi = r["idbank"].ToString();
                string cab = r["idcab"].ToString();
                string cc = r["cc"].ToString();
                if (cc.Length < 12) {
                    cc = cc.PadLeft(12, '0');
                }
                if (CfgFn.CheckCIN(cin, cab, abi, cc)) {
                    string bban = cin + abi + cab + cc;
                    r["cc"] = cc;
                    r["iban"] = CfgFn.calcolaIBAN("IT", bban);
                }
            }
            int n = DS.registrypaymethod.Select(QHS.IsNotNull("iban")).Length;
            PostData pd = Meta.Get_PostData();
            string mess = pd.InitClass(DS, Meta.Conn);
            bool ok = pd.DO_POST();
            if (ok) {
                MessageBox.Show(this, "Sono stati calcolati " + n + " codici IBAN\n"+mess);
            }
            else {
                MessageBox.Show(this, "Salvataggio dei dati fallito!\n"+mess, "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MetaData_AfterClear() {
            Text = "Calcolo IBAN";
        }
        private void btnAnnulla_Click(object sender, EventArgs e) {
            Dispose(); 
        }
    }
}