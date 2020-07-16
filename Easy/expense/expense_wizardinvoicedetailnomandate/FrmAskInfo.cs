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

namespace expense_wizardinvoicedetailnomandate {
    public partial class FrmAskInfo : Form {
        MetaDataDispatcher Disp;
        MetaData Meta;
        DataAccess Conn;
        public DataRow Selected;
        public object IDManagerSelected = null;
        public string IDUPBSelected = null;
        string E_S;
        string filter_upb;
        bool upbToSelect;
        string currfilter_upb;
        bool InChiusura = false;
        decimal importo;
        object idmanager;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAskInfo(string E_S, string filter_upb, MetaDataDispatcher Disp,
            object idmanager,
            decimal importo,
            bool upbToSelect) {
            InitializeComponent();

            this.E_S = E_S;
            this.filter_upb = filter_upb;
            this.currfilter_upb = filter_upb;
            this.Disp = Disp;
            this.Conn = Disp.Conn;
            this.importo = importo;
            this.idmanager = idmanager;
            this.upbToSelect = upbToSelect;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            SubEntity_txtImportoMovimento.Text = importo.ToString("c");
            Selected = null;

            DataTable responsabile = Conn.CreateTableByName("manager", "*", false);
            DataSet D = new DataSet();
            D.Tables.Add(responsabile);
            GetData.MarkToAddBlankRow(responsabile);
            GetData.Add_Blank_Row(responsabile);
            if (idmanager != null && idmanager.ToString() != "") {
                Conn.RUN_SELECT_INTO_TABLE(responsabile, "title",
                    QHS.CmpEq("idman", idmanager), null, true);
                cmbResponsabile.Enabled = false;
            }
            else {
                if (idmanager != null) {
                    Conn.RUN_SELECT_INTO_TABLE(responsabile, "title", QHS.CmpEq("active", "S"), null, true);
                }
                else {
                    cmbResponsabile.Enabled = false;
                }
            }
            Conn.DeleteAllUnselectable(responsabile);

            DataTable upb = Conn.CreateTableByName("upb", "*", false);
            D.Tables.Add(upb);
            GetData.MarkToAddBlankRow(upb);
            GetData.Add_Blank_Row(upb);
            if (filter_upb != null && filter_upb != "") {
                Conn.RUN_SELECT_INTO_TABLE(upb, "codeupb", filter_upb, null, true);
                cmbUPB.Enabled = false;
                if (upb.Select(filter_upb).Length > 0)
                    txtUPB.Text = upb.Select(filter_upb)[0]["title"].ToString();
            }
            else {
                if (upbToSelect) {
                    Conn.RUN_SELECT_INTO_TABLE(upb, "codeupb", QHS.CmpEq("active", "S"), null, true);
                }
                else {
                    cmbUPB.Enabled = false;
                }
            }
            Conn.DeleteAllUnselectable(upb);

            if (filter_upb == null) {
                chkFilterAvailable.Checked = false;
                chkFilterAvailable.Enabled = false;
            }
            cmbResponsabile.DataSource = responsabile;
            cmbResponsabile.ValueMember = "idman";
            cmbResponsabile.DisplayMember = "title";
            if (idmanager != null && idmanager.ToString() != "" && responsabile.Rows.Count>0)
            {
                cmbResponsabile.SelectedIndex = 1;
            }
            else
            {
                cmbResponsabile.SelectedIndex = 0;
            }

            cmbUPB.DataSource = upb;
            cmbUPB.ValueMember = "idupb";
            cmbUPB.DisplayMember = "codeupb";
            if (filter_upb != null && upb.Rows.Count>0) cmbUPB.SelectedIndex = 1;
            Meta = Disp.Get("finview");
            //if (filter_upb != null)
            //    Meta = Disp.Get("finview");
            //else 
            //    Meta = Disp.Get("fin");
            if (filter_upb == null) {
                txtBilancio.Enabled = false;
            }

        }
        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;

            int esercizio = (int)Meta.GetSys("esercizio");
            string filterpart = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), filterpart);

            //filter= filter_upb;
            filter = currfilter_upb;

            filter = GetData.MergeFilters(filteridfin, filter);

            //Aggiunge eventualmente il filtro sul disponibile
            if (chkFilterAvailable.Checked) {
                decimal currval = importo;
                filter = GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
            }

            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear = '"
                + esercizio + "'))";
            if (chkListManager.Checked) {
                if (cmbResponsabile.SelectedIndex > 0) {
                    filter = GetData.MergeFilters(filter, QHS.CmpEq("idman", cmbResponsabile.SelectedValue));
                }
                else {
                    filter = GetData.MergeFilters(filter, QHS.IsNull("idman"));
                }
                Meta.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                Selected = Meta.SelectOne("default", filter, "finview", null);
                riempiTextBox(Selected);
                return;
            }

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                Meta.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                Selected = Meta.SelectOne("default", filter, "finview", null);
                riempiTextBox(Selected);
                return;
            }

            chiamaFormBilancio(filter);
        }


        private void chiamaFormBilancio(string filtro) {
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.ExtraParameter = filtro;
            string edittype;
            if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            edittype = "tree" + E_S.ToLower() + "upb";
            //if (filter_upb!=null)
            //    edittype= "tree" + E_S.ToLower() + "upb";
            //else 
            //    edittype= "tree" + E_S.ToLower();
            bool res = Meta.Edit(this, edittype, true);
            if (!res) return;
            Selected = Meta.LastSelectedRow;
            riempiTextBox(Selected);
        }

        private void riempiTextBox(DataRow finRow) {
            txtBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
            txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
        }




        private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;

            if (txtBilancio.Text.Trim() == "") {
                Selected = null;
                riempiTextBox(Selected);
                return;
            }

            if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            string filterPart = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filterPart,
                currfilter_upb);

            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.StartFieldWanted = "codefin";
            Meta.StartValueWanted = null;

            Meta.StartValueWanted = txtBilancio.Text.Trim();
            string startfield = Meta.StartFieldWanted;
            string startvalue = Meta.StartValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                //Meta.myGetData= myGetData;
                Selected = Meta.SelectByCondition(filter2, "finview");
            }

            if (Selected == null) {
                string edittype = "tree" + E_S.ToLower() + "upb";
                bool res = Meta.Edit(this, edittype, true);
                if (!res) {
                    return;
                }
                Selected = Meta.LastSelectedRow;
            }

            riempiTextBox(Selected);
        }

        private void btnOk_Click(object sender, System.EventArgs e) {
            if (cmbResponsabile.SelectedIndex <= 0 && idmanager != null && idmanager != DBNull.Value){
                MessageBox.Show("Selezionare un responsabile");
                DialogResult = DialogResult.None;
                return;
            }
            if (cmbUPB.SelectedIndex <= 0 && filter_upb == null && upbToSelect) {
                MessageBox.Show("Selezionare un UPB");
                DialogResult = DialogResult.None;
                return;
            }
            if (cmbResponsabile.SelectedValue != null && cmbResponsabile.SelectedIndex>0)
                IDManagerSelected = cmbResponsabile.SelectedValue;
            else
                IDManagerSelected = null;
            if (cmbUPB.SelectedValue != null && cmbUPB.SelectedIndex>0)
                IDUPBSelected = cmbUPB.SelectedValue.ToString();
            else
                IDUPBSelected = null;
            if (Selected == null) {
                MessageBox.Show("Selezionare una voce di bilancio");
                DialogResult = DialogResult.None;
            }
        }

        private void cmbUPB_SelectedIndexChanged(object sender, EventArgs e) {
            if (filter_upb != null) return;

            if ((cmbUPB.SelectedValue == null) || (cmbUPB.SelectedValue.ToString() == "")) {
                txtBilancio.Enabled = false;
                chkFilterAvailable.Checked = false;
                chkFilterAvailable.Enabled = false;
            }
            else {
                currfilter_upb = "(idupb=" + QueryCreator.quotedstrvalue(cmbUPB.SelectedValue, false) + ")";
                object upb = Conn.DO_READ_VALUE("upb", currfilter_upb, "title");
                txtUPB.Text = upb.ToString();
                txtBilancio.Enabled = true;
                chkFilterAvailable.Checked = true;
                chkFilterAvailable.Enabled = true;
            }

        }

        private void cmb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Se Ë stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if ((e.KeyChar == 27) || (e.KeyChar == 13))
            {
                return;
            }

            ComboBox acComboBox = (ComboBox)sender;

            int selectionStart = acComboBox.SelectionStart;
            if (selectionStart > acComboBox.Text.Length) selectionStart = acComboBox.Text.Length;

            //Se il tasto premuto Ë BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8)
            {
                if (selectionStart > 0)
                {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else
                {
                    acComboBox.SelectAll();
                }
            }
            else
            {
                //Se Ë un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                string ricerca = acComboBox.Text.Substring(0, selectionStart) + e.KeyChar;

                int index = acComboBox.FindString(ricerca);

                if (index != -1)
                {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index)
                    {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < acComboBox.Text.Length)
                    {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                }
                else
                {
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
        private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ComboBox acComboBox = (ComboBox)sender;
            int selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode)
            {
                //Se Ë stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                    if (selectionStart > 0)
                    {
                        acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                    }
                    else
                    {
                        acComboBox.SelectAll();
                    }
                    break;

                //Se Ë stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                    int index = acComboBox.FindString("");
                    if (index != -1)
                    {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                        acComboBox.DroppedDown = true;
                    }
                    acComboBox.SelectAll();
                    break;

                //Se Ë stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                    if (acComboBox.Text.Length > selectionStart)
                    {
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                    break;

                //Se Ë stato premuto il tasto "HOME" seleziono tutta la riga attuale.
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