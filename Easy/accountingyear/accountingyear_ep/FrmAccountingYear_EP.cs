
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
using funzioni_configurazione;

namespace accountingyear_ep {
    public partial class FrmAccountingYear_EP : MetaDataForm {
        int esercizio;
        MetaData Meta;

        public FrmAccountingYear_EP() {
            InitializeComponent();
        }

        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteresercizio = QHS.CmpEq("ayear", esercizio);
            Meta.StartFilter = filteresercizio;
            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
        }

        public void MetaData_AfterActivation() {
            bool opened = EsercizioAperto(esercizio);
            abilitaBottoni(opened);
        }

        private void btnFase1_Click(object sender, EventArgs e) {
            chiusuraEsercizio();
        }

        private void btnFase2_Click(object sender, EventArgs e) {
            riaperturaEsercizio();
        }

        private void chiusuraEsercizio() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataRow rAccountingYear = DS.accountingyear.Rows[0];
            int flag = CfgFn.GetNoNullInt32(rAccountingYear["flag"]);
            if ((flag & 32) == 0) {
                flag |= 0x20;
            }

            rAccountingYear["flag"] = flag;

            PostData Post = Meta.Get_PostData();

            Post.InitClass(DS, Meta.Conn);
            if (!Post.DO_POST()) {
                show(this, "Errore durante la chiusura dell'esercizio" + esercizio);
            }
            else {
                show(this, "Esercizio " + esercizio + " chiuso correttamente");
            }
            this.Close();
        }

        private void riaperturaEsercizio() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataSet dsOut = DataAccess.CallSP(Meta.Conn, "closeyear_reopenayear", new object[] { esercizio, "E" }, true, 60000);

            if (dsOut == null) {
                show(this, "Errore nella S.P. di riapertura dell'esercizio " + esercizio);
            }
            else {
                show(this, "Esercizio " + esercizio + " riaperto correttamente");
            }
            this.Close();
        }

        private void abilitaBottoni(bool enable) {
            btnFase1.Enabled = enable;
            btnFase2.Enabled = !enable;
        }

        private bool EsercizioAperto(int esercizio) {
            if (DS.accountingyear.Rows.Count == 0) return true;
            DataRow rAccountingYear = DS.accountingyear.Rows[0];
            return ((CfgFn.GetNoNullInt32(rAccountingYear["flag"]) & 32) == 0);
        }

        public void MetaData_AfterClear() {
            MetaData.DoMainCommand(this, "maindosearch.ep");
        }
    }
}
