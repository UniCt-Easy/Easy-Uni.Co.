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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace colbit_default {
    public partial class frmColBitDefault : Form {
        public frmColBitDefault() {
            InitializeComponent();
        }

        private MetaData meta;
        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            DS.colbit.Columns["nbit"].ExtendedProperties["allowZero"] = 1;
        }

        void calcolaMaschere(bool mustRead) {
            if (mustRead) meta.GetFormData(true);
            DataRow r = DS.colbit.Rows[0];
            int nBit = CfgFn.GetNoNullInt32(r["nbit"]);
            QueryHelper q = meta.Conn.GetQueryHelper();
            string sSet = "x = x | " + (1 << nBit);
            int x = 1 << nBit;
            int notX = ~x;
            string sClear = "x = x & ~("+x+")  oppure  x = x & " + notX.ToString("x");
            string sCheck = "(x & " + (1 << nBit) + ")<>0";
            txtCheck.Text = sCheck;
            txtClear.Text = sClear;
            txtSet.Text = sSet;
        }
        public void MetaData_AfterFill() {
            calcolaMaschere(false);
        }

        private void txtNBit_TextChanged(object sender, EventArgs e) {
            if (meta == null) return;
            if (!meta.DrawStateIsDone) return;
            calcolaMaschere(true);
        }
    }
}
