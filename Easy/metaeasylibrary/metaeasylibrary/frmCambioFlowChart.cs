/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace metaeasylibrary {
    public partial class frmCambioFlowChart : Form {
       
        public object idflowchart = DBNull.Value;
        public object ndetail = DBNull.Value;

        DataTable T;
        bool err = false;
        public frmCambioFlowChart(DataAccess Conn) {
            InitializeComponent();
            MetaData.SetColor(this, true);
            object idcustomuser= Conn.GetSys("idcustomuser") ;
            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object currdate = Conn.GetSys("datacontabile");
            QueryHelper QHS = Conn.GetQueryHelper();
            string f1 = QHS.AppAnd(QHS.CmpEq("U.idcustomuser", idcustomuser),
                QHS.NullOrLe("U.start", currdate), QHS.NullOrGe("U.stop", currdate));
            f1 = QHS.AppAnd(f1,QHS.CmpEq("F.ayear",Conn.GetSys("esercizio")));
            T = Conn.SQLRunner("select U.idflowchart, isnull(U.title,F.title) as title, "+
                   "U.ndetail from flowchartuser U join " +
                    " flowchart F on U.idflowchart=F.idflowchart where " + f1+ " order by 2" , true, -1);
            if (T == null) {
                err = true;
                //string f2 = QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                //QHS.NullOrLe("start", currdate), QHS.NullOrGe("stop", currdate));
                //T = Conn.RUN_SELECT("flowchart", "*", "title asc",
                //    "idflowchart in (select idflowchart from flowchartuser where " + f2 +
                //           ")and ayear=" +
                //           QueryCreator.quotedstrvalue(Conn.GetSys("esercizio"), true), null, false);
                //if (T == null) {
                //    MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore nell'accesso al database", "Errore");
                //    err = true;
                //    btnOk.Visible = false;
                //    return;
                //}
                //T.PrimaryKey = new DataColumn[] { T.Columns["idflowchart"] };
                cmbFlowChart.Visible = false;
                btnOk.Visible = false;
                labErrore.Visible = true;
                return;
            }
            else {
                T.PrimaryKey = new DataColumn[] {T.Columns["idflowchart"],
                                                    //T.Columns["idcustomuser"],
                                                    T.Columns["ndetail"] };

            }
            cmbFlowChart.DataSource = T;
            cmbFlowChart.DisplayMember = "title";
            if (err) {
                cmbFlowChart.ValueMember = "idflowchart";

                try {
                    if (T.Rows.Count > 0) cmbFlowChart.SelectedValue = idflowchart;
                }
                catch { }
            }
            else {
                cmbFlowChart.ValueMember = "ndetail";

                try {
                    if (T.Rows.Count > 0 && ndetail!=null && ndetail!=DBNull.Value) cmbFlowChart.SelectedValue = ndetail;
                }
                catch { }
            }

            cmbFlowChart.KeyDown += new KeyEventHandler(this.cmb_KeyDown);
            cmbFlowChart.KeyPress += new KeyPressEventHandler(this.cmb_KeyPress);

        }

        public DataRow GetCurrentRowFromCombo(ComboBox C,DataTable T) {
            if (C.DataSource == null) return null;

            if (C.SelectedIndex < 0) { //index 0 is used for blank row
                return null;
            }
            DataRowView RV = ((DataRowView)((ComboBox)C).Items[C.SelectedIndex]);
            if (RV == null) return null;
            DataRow R = RV.Row;
            if (R.Table == T) return R;
            R = FindExternalRow(T, R);
            return R;
        }
        public  DataRow FindExternalRow(DataTable T, DataRow R) {
            string condition = QueryCreator.WHERE_REL_CLAUSE(R, T.PrimaryKey, T.PrimaryKey,
                DataRowVersion.Default, false);
            DataRow[] Found = T.Select(condition);
            if (Found.Length == 0) return null;
            return Found[0];
        }

        private void cmbFlowChart_SelectedIndexChanged(object sender, EventArgs e) {
            if (T == null) return;
            DataRow R = GetCurrentRowFromCombo(cmbFlowChart, T);
            if (R == null) {
                idflowchart = DBNull.Value;
                ndetail = DBNull.Value;
            }
            else {
                idflowchart = R["idflowchart"];
                ndetail = DBNull.Value;
                if (T.Columns.Contains("ndetail")) ndetail = R["ndetail"];
                
            }

        }
        private void cmb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            if (T == null) return;
            //Se è stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if ((e.KeyChar == 27) || (e.KeyChar == 13)) {
                return;
            }

            ComboBox acComboBox = (ComboBox)sender;

            int selectionStart = acComboBox.SelectionStart;
            if (selectionStart > acComboBox.Text.Length) selectionStart = acComboBox.Text.Length;

            //Se il tasto premuto è BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8) {
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
            }
            else {
                //Se è un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                string ricerca = acComboBox.Text.Substring(0, selectionStart) + e.KeyChar;

                int index = acComboBox.FindString(ricerca);

                if (index != -1) {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < acComboBox.Text.Length) {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                }
                else {
                    //Se invece tale riga non esiste, allora seleziono la riga attuale
                    //dal carattere in posizione selectionStart fino alla fine
                    acComboBox.DroppedDown = true;
                    acComboBox.Select(selectionStart, acComboBox.Text.Length - selectionStart);
                }
            }
            //Forzo l'apertura della tendina per facilitare l'utente nella scelta
            e.Handled = true;
        }

        /// <summary>
        /// Evento generato prima di KeyPress. Lo uso per gestire la pressione dei tasti 
        /// "SINISTRA", "DESTRA", "HOME" e "CANC"
        /// che altrimenti non riuscirei ad intercettare con KeyPress.
        /// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
        /// </summary>
        /// <param name="sender">il ComboBox da gestire</param>
        /// <param name="e">l'evento</param>
        private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            if (T == null) return;
            ComboBox acComboBox = (ComboBox)sender;
            int selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode) {
                //Se è stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                    if (selectionStart > 0) {
                        acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                    }
                    else {
                        acComboBox.SelectAll();
                    }
                    break;

                //Se è stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                    int index = acComboBox.FindString("");
                    if (index != -1) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                        acComboBox.DroppedDown = true;
                    }
                    acComboBox.SelectAll();
                    break;

                //Se è stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                    if (acComboBox.Text.Length > selectionStart) {
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                    break;

                //Se è stato premuto il tasto "HOME" seleziono tutta la riga attuale.
                case Keys.Home:
                    acComboBox.SelectAll();
                    break;

                default:
                    //Altrimenti lascio la gestione di questo evento a .NET
                    return;
            }
            e.Handled = true;
        }
	}
}