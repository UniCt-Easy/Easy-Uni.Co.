/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace no_table_trasf_flowchart {
    public partial class FrmTrasfFlowchart : Form {
        MetaData Meta;
        public FrmTrasfFlowchart () {
            InitializeComponent();
        }

        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioInizio.Text = Meta.GetSys("esercizio").ToString();
            int stopayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1;
            txtEsercizioFine.Text = stopayear.ToString();
        }
        private void btnTrasferisciOrganigramma_Click (object sender, EventArgs e) {
           // if (!DatiValidi()) return;
            object startayear = HelpForm.GetObjectFromString(typeof(int),
                txtEsercizioInizio.Text.ToString(), "x.y.year");

            object stopayear = HelpForm.GetObjectFromString(typeof(int),
            txtEsercizioFine.Text.ToString(), "x.y.year");

            Meta.Conn.CallSP("closeyear_flowchartcopy", new object[] {startayear,
            stopayear}, false, 600);
			MessageBox.Show("Operazione eseguita");
        }

        private void txtEsercizio_Leave (object sender, EventArgs e) {
            TextBox TSender = (TextBox)sender;
            HelpForm.FormatLikeYear(TSender);
        }

        /*public bool DatiValidi () {
            int startayear;
            try {
                startayear = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizioInizio.Text.ToString(), "x.y.year");
                if ((startayear <= 0)) {
                    MessageBox.Show("L'esercizio iniziale non puÚ essere negativo o nullo");
                    txtEsercizioInizio.Focus();
                    return false;
                }
               
            }
            catch {
                MessageBox.Show("E' necessario inserire un esercizio iniziale");
                txtEsercizioInizio.Focus();
                return false;
            }

            int stopayear;
            try {
                stopayear = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtEsercizioFine.Text.ToString(), "x.y.year");
                if ((stopayear < 0)) {
                    MessageBox.Show("L'esercizio finale non puÚ essere negativo");
                    txtEsercizioFine.Focus();
                    return false;
                }

            }
            catch {
                MessageBox.Show("E' necessario inserire un esercizio finale");
                txtEsercizioFine.Focus();
                return false;
            }
            
            return true;
        }*/

    }
}