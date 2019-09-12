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

namespace EasyInstall {
    public partial class FrmMatchAnagrafica : Form {
        DataAccess Source;
        DataAccess Dest;
        //bool err = false;
        public FrmMatchAnagrafica(DataAccess SourceConn, DataAccess DestConn) {
            InitializeComponent();
            this.Source = SourceConn;
            this.Dest = DestConn;
            Conta = new int[15];
            for (int i = 0; i < 15; i++) Conta[i] = 0;
        }
        int[] Conta;
        void Init() {
            string sql =
                "select count(*) as totale, idregistryclass from registry  " +
                " where idregistryclass in ('21','22','23','24') " +
                " group by idregistryclass ";
            DataTable Tot = Source.SQLRunner(sql, false, 0);
            foreach (DataRow R in Tot.Rows) {
                if (R["idregistryclass"].ToString() == "21") Conta[0] = Convert.ToInt32(R["totale"]);
                if (R["idregistryclass"].ToString() == "22") Conta[1] = Convert.ToInt32(R["totale"]);
                if (R["idregistryclass"].ToString() == "23") Conta[2] = Convert.ToInt32(R["totale"]);
                if (R["idregistryclass"].ToString() == "24") Conta[3] = Convert.ToInt32(R["totale"]);
            }
            int totclass = Conta[0] + Conta[1] + Conta[2] + Conta[3];
            int totdb = Source.RUN_SELECT_COUNT("registry", null, false);
            if (totdb != totclass) {
                MessageBox.Show("Nel db di origine ci sono anagrafiche con tipologie non standard. Impossibile proseguire.");
                return;
            }
            pBar.Minimum = 0;
            pBar.Maximum = totclass;
            pBar.Step = 1;

            CalcTotal();

        }
        void CalcTotal() {
            for (int i = 0; i < 15;i += 5 ) {
                Conta[i + 4] = Conta[i] + Conta[i + 1] + Conta[i + 2] + Conta[i + 3];
            }
            txtTotSource.Text = Conta[4].ToString();
            txtEsaminateTotali.Text = Conta[9].ToString();
            txtPresentiTotali.Text = Conta[14].ToString();
            pBar.Value = Conta[4];
            pBar.Update();
            Application.DoEvents();
        }
        void Migra() {

        }
        private void btnStop_Click(object sender, EventArgs e) {
            if (MessageBox.Show(this, "Si intende annullare la migrazione?", "Conferma", MessageBoxButtons.OKCancel)
                == DialogResult.OK) {
                //err = true;
                Close();
            }
        }
    }
}