
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
using calcolocedolino;
using funzioni_configurazione;

namespace parasubcontract_default {
    public partial class FrmCalcAcconto : MetaDataForm {
        DataAccess Conn;
        int idreg;
        public decimal annualincome;
        public decimal citytax_account;
        object idcity;
        object idser;
        bool inChiusura = false;
        QueryHelper QHS;
        public FrmCalcAcconto(DataAccess Conn, int idreg, decimal annualincome, object idcity, object idser) {
            InitializeComponent();
            this.Conn = Conn;
            this.idreg = idreg;
            this.annualincome = annualincome;
            this.idcity = idcity;
            this.idser = idser;
            QHS = Conn.GetQueryHelper();
            fillForm();
        }

        private void fillForm() {
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")) - 1;
            decimal stimaRedditoCompl = CalcoliCococo.calcolaImpFiscalePerAccontoAddizCom(Conn, esercizio, idreg);
            string msg = "Abbiamo stimato che il reddito complessivo per l'esercizio " + esercizio + " sia pari a € " + 
                + stimaRedditoCompl + ".\r\nIl calcolo è stato fatto sommando gli imponibili fiscali lordi delle prestazioni pagate al percipiente.";
            lblRedditoComplessivo.Text = msg;
            if (annualincome != 0) {
                txtRedditoComplessivo.Text = annualincome.ToString("c");
            }
            if ((idcity != null) || (idcity != DBNull.Value)) {
                object nomeCitta = Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcity), "title");
                if (nomeCitta != null && nomeCitta != DBNull.Value) {
                    txtComuneResidenza.Text = nomeCitta.ToString().ToUpper();
                }
            }
            bool calcolaAcconto = ((annualincome != 0) && ((idcity != null) || (idcity != DBNull.Value)));
            if (calcolaAcconto) {
                string errMess;
                decimal acconto = CalcoliCococo.calcolaAccontoAddCom(Conn, (esercizio + 1), idcity, idser, annualincome, out errMess);
                if (errMess == null) {
                    txtAcconto.Text = acconto.ToString("c");
                }
                else {
                    show("Non è stato possibile calcolare l'acconto perché si è verificato il seguente errore\r\n" + errMess);
                }
                

            }
        }

        private void txtRedditoComplessivo_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDecTextBox(txtRedditoComplessivo, "x.y");
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            decimal rc = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtRedditoComplessivo.Text, "x.y"));
            string errMess;
            decimal acconto = CalcoliCococo.calcolaAccontoAddCom(Conn, esercizio, idcity, idser, rc, out errMess);
            if (errMess == null) {
                txtAcconto.Text = acconto.ToString("c");
            }
            else {
                show("Non è stato possibile calcolare l'acconto perché si è verificato il seguente errore\r\n" + errMess);
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            object acc = HelpForm.GetObjectFromString(typeof(decimal), txtAcconto.Text, "x.y");
            citytax_account = CfgFn.GetNoNullDecimal(acc);
            object rc = HelpForm.GetObjectFromString(typeof(decimal), txtRedditoComplessivo.Text, "x.y");
            annualincome = CfgFn.GetNoNullDecimal(rc);
        }

    }
}
