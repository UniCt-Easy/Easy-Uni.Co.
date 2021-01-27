
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
using AskInfo;

namespace finvar_default {
    public partial class FrmStornoTraUpb : Form {
        bool inChiusura = false;
        DataRow finRow;
        DataRow underwritingRow;
        DataSet dsMain;
        MetaData MetaFinVar, metaFin, metaUnderwriting, metaUpbSource, metaUpbDest;
        CQueryHelper QHC;
        QueryHelper QHS;
        UPB_SelectionManager SelUPBSource = null;
        UPB_SelectionManager SelUPBDest = null;
        DataAccess Conn;

        private MetaData CreateNewMeta(MetaDataDispatcher Disp, string table) {
            MetaData M = Disp.Get(table);
            DataSet D = new DataSet("a");
            D.EnforceConstraints = false;
            DataTable T = Conn.CreateTableByName(table, "*");
            D.Tables.Add(T);
            return M;
        }


        public FrmStornoTraUpb(MetaData meta, DataSet ds) {
            InitializeComponent();
            this.dsMain = ds;
            this.MetaFinVar = meta;
            this.Conn = meta.Conn;
            metaFin = MetaFinVar.Dispatcher.Get("finview");
            metaUpbSource = CreateNewMeta(meta.Dispatcher, "upb");
            metaUpbDest = CreateNewMeta(meta.Dispatcher, "upb");
            metaUnderwriting = MetaFinVar.Dispatcher.Get("underwriting");
            QHC = new CQueryHelper();
            QHS = MetaFinVar.Conn.GetQueryHelper();

            MetaFinVar.Conn.RUN_SELECT_INTO_TABLE(DS.underwriting, "title", QHS.CmpEq("active", "S"), null, true);
            meta.Conn.DeleteAllUnselectable(DS.underwriting);

            SelUPBSource = new UPB_SelectionManager(metaUpbSource, txtUPBSource, txtDescrUPBSource);
            SelUPBDest = new UPB_SelectionManager(metaUpbDest, txtUPBDest, txtDescrUPBDest);

            EnableUPBSelectionSource(true);
            EnableUPBSelectionDest(true);
            btnUPBSource.Click += new EventHandler(btnUPBSource_Click);
            btnUPBDest.Click += new EventHandler(btnUPBDest_Click);

        }

        public void  EnableUPBSelectionSource(bool enable) {
            txtUPBSource.ReadOnly = !enable;
            txtUPBSource.TabStop = enable;
            btnUPBSource.Enabled = enable;
        }

        public void EnableUPBSelectionDest(bool enable) {
            txtUPBDest.ReadOnly = !enable;
            txtUPBDest.TabStop = enable;
            btnUPBDest.Enabled = enable;
        }

        public void SetUPBSource(object idupb) {
            SelUPBSource.SetValue(idupb);
            EnableUPBSelectionSource(idupb == DBNull.Value);
        }

        public object GetUPBSource() {
            return SelUPBSource.GetValue();
        }

        public void SetUPBDest(object idupb) {
            SelUPBDest.SetValue(idupb);
            EnableUPBSelectionDest(idupb == DBNull.Value);
        }

        public object GetUPBDest() {
            return SelUPBDest.GetValue();
        }


        private void btnUPBSource_Click(object sender, System.EventArgs e) {
            chiamaFormUPBSource("(active='S')");
        }
        private void btnUPBDest_Click(object sender, System.EventArgs e) {
            chiamaFormUPBDest("(active='S')");
        }

        private void chiamaFormUPBSource(string filtro) {
            MetaData mUPB = metaUpbSource.Dispatcher.Get("upb");

            mUPB.FilterLocked = true;
            mUPB.SearchEnabled = false;
            mUPB.MainSelectionEnabled = true;
            mUPB.StartFilter = filtro;
            mUPB.ExtraParameter = filtro;
            string edittype = "tree";
            bool res = mUPB.Edit(this, edittype, true);
            if (!res) {
                mUPB.Destroy();
                return;
            }

            DataRow Selected = mUPB.LastSelectedRow;
            SelUPBSource.SelectRow(Selected);
            mUPB.Destroy();
        }

        private void chiamaFormUPBDest(string filtro) {
            MetaData mUPB = metaUpbDest.Dispatcher.Get("upb");

            mUPB.FilterLocked = true;
            mUPB.SearchEnabled = false;
            mUPB.MainSelectionEnabled = true;
            mUPB.StartFilter = filtro;
            mUPB.ExtraParameter = filtro;
            string edittype = "tree";
            bool res = mUPB.Edit(this, edittype, true);
            if (!res) {
                mUPB.Destroy();
                return;
            }
            DataRow Selected = mUPB.LastSelectedRow;
            SelUPBDest.SelectRow(Selected);
            mUPB.Destroy();
        }



        private void btnBilancio_Click(object sender, System.EventArgs e) {
            int esercizio = (int)MetaFinVar.GetSys("esercizio");
            string filterpart = rdbEntrata.Checked ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), filterpart);
            string filterUpb = QHS.CmpEq("idupb", SelUPBSource.GetValue());
            string filter = GetData.MergeFilters(filterUpb, filteridfin);

            //Aggiunge eventualmente il filtro sul disponibile
            //if (chkFilterAvailable.Checked) {
            //    decimal currval = importo;
            //    filter = GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
            //}
            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear = '"
                + MetaFinVar.GetSys("esercizio") + "'))";
            //if (chkListManager.Checked) {
            //    if (cmbResponsabile.SelectedIndex > 0) {
            //        filter = GetData.MergeFilters(filter, QHS.CmpEq("idman", cmbResponsabile.SelectedValue));
            //    }
            //    else {
            //        filter = GetData.MergeFilters(filter, QHS.IsNull("idman"));
            //    }
            //    Meta.FilterLocked = true;
            //    filter = GetData.MergeFilters(filter, filteroperativo);
            //    Selected = Meta.SelectOne("default", filter, "finview", null);
            //    riempiTextBox(Selected);
            //    return;
            //}

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                /*filter = GetData.MergeFilters(filter,
                    "(title like "+QueryCreator.quotedstrvalue(
                    "%"+FR.txtDescrizione.Text+"%",true))+")";*/
                filter = QHC.Like("title", '%' + FR.txtDescrizione.Text + '%');
                metaFin.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                filter = GetData.MergeFilters(filter, filterpart);
                setFinRow(metaFin.SelectOne("default", filter, "finview", null));
                return;
            }

            chiamaFormBilancio(filter);
        }

        private void chiamaFormBilancio(string filtro) {
            MetaData mFin = metaFin.Dispatcher.Get("finview");

            mFin.FilterLocked = true;
            mFin.SearchEnabled = false;
            mFin.MainSelectionEnabled = true;
            mFin.StartFilter = filtro;
            mFin.ExtraParameter = filtro;
            string edittype = rdbEntrata.Checked ? "treeeupb" : "treesupb";
            bool res = mFin.Edit(this, edittype, true);
            if (!res) {
                mFin.Destroy();
                return;
            }
            setFinRow(mFin.LastSelectedRow);
            mFin.Destroy();
        }

     

        private void rdbSpesa_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            setFinRow(null);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (inChiusura) return;
            
        }


        public void setFinRow(DataRow selected) {
            finRow = selected;
            txtCodiceBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
            txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
        }

        public void setUnderwritingRow(DataRow selected)
        {
            finRow = selected;
            txtCodiceBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
            txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
        }

        private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (txtCodiceBilancio.Text.Trim() == "") {
                setFinRow(null);
                return;
            }

            string filterPart = rdbEntrata.Checked ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", metaFin.GetSys("esercizio")), filterPart,
                QHS.CmpEq("idupb", SelUPBSource.GetValue()));

            MetaData mFin = metaFin.Dispatcher.Get("finview");

            mFin.FilterLocked = true;
            mFin.SearchEnabled = false;
            mFin.MainSelectionEnabled = true;
            mFin.StartFilter = filtro;
            mFin.startFieldWanted = "codefin";
            mFin.startValueWanted = null;

            mFin.startValueWanted = txtCodiceBilancio.Text.Trim();
            string startfield = mFin.startFieldWanted;
            string startvalue = mFin.startValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                //Meta.myGetData= myGetData;
                DataRow Selected = mFin.SelectByCondition(filter2, "finview");
                if (Selected != null) {
                    setFinRow(Selected);
                    return;
                }
            }
            

            string edittype = rdbEntrata.Checked ? "treeeupb" : "treesupb";
            bool res = mFin.Edit(this, edittype, true);
            if (!res) {
                return;
            }
            setFinRow(mFin.LastSelectedRow);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.ActiveControl = null;
            if (finRow == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare la voce di bilancio");
                HelpForm.FocusControl(txtCodiceBilancio);
                DialogResult = DialogResult.None;
                return;
            }
            if (SelUPBSource.GetValue() == DBNull.Value || SelUPBSource.GetValue()==null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare l'upb da cui stornare");
                HelpForm.FocusControl(txtUPBSource);
                DialogResult = DialogResult.None;
                return;
            }
            if (SelUPBDest.GetValue() == DBNull.Value || SelUPBDest.GetValue() ==null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare l'upb in cui stornare");
                HelpForm.FocusControl(txtUPBDest);
                DialogResult = DialogResult.None;
                return;
            }
            if (SelUPBSource.GetValue().ToString()==SelUPBDest.GetValue().ToString()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare due upb diversi");
                HelpForm.FocusControl(txtUPBSource);
                DialogResult = DialogResult.None;
                return;
            }
            
            object o = HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text, "x.y");
            decimal importo = CfgFn.GetNoNullDecimal(o);
            if (importo <= 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Occorre specificare un importo maggiore di 0");
                HelpForm.FocusControl(txtImporto);
                DialogResult = DialogResult.None;
                return;
            }
            //string filtro1 = QHS.AppAnd(QHS.CmpEq("idupb", SelUPBSource.GetValue()), QHS.CmpEq("idfin", finRow["idfin"]));
            //DataRow[] rDett1 = dsMain.Tables["finvardetail"].Select(filtro1);
            //if (rDett1.Length > 0) {
            //    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non è possibile creare una ulteriore variazione con upb='" + txtUPBSource.Text
            //                                    + "' e bilancio='" + finRow["codefin"] + "'");
            //    DialogResult = DialogResult.None;
            //    return;
            //}
            //string filtro2 = QHS.AppAnd(QHS.CmpEq("idupb", SelUPBDest.GetValue()), QHS.CmpEq("idfin", finRow["idfin"]));
            //DataRow[] rDett2 = dsMain.Tables["finvardetail"].Select(filtro2);
            //if (rDett2.Length > 0) {
            //    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non è possibile creare una ulteriore variazione con upb='" + txtUPBDest.Text
            //                                    + "' e bilancio='" + finRow["codefin"] + "'");
            //    DialogResult = DialogResult.None;
            //    return;
            //}

            MetaData metaFinVarDetail = MetaFinVar.Dispatcher.Get("finvardetail");
            DataRow rFV = dsMain.Tables["finvar"].Rows[0];
            metaFinVarDetail.SetDefaults(dsMain.Tables["finvardetail"]);
            DataRow rFVD1 = metaFinVarDetail.Get_New_Row(rFV, dsMain.Tables["finvardetail"]);
            //DataRowView upb1 = (DataRowView)cmbUPB1.SelectedItem;
            //DataRowView upb2 = (DataRowView)cmbUPB2.SelectedItem;
            rFVD1["idupb"] = SelUPBSource.GetValue();
            if (underwritingRow != null){
                rFVD1["idunderwriting"] = underwritingRow["idunderwriting"];
            }
            rFVD1["nvar"] = rFV["nvar"];
            rFVD1["yvar"] = rFV["yvar"];
            rFVD1["amount"] = -importo;
            if (txtDescrizione.Text != "") {
                rFVD1["description"] = txtDescrizione.Text;
            }

            //rFVD1["description"] = "storno da " + upb1.Row["codeupb"]; ;
            rFVD1["idfin"] = finRow["idfin"];
            DataRow rFVD2 = metaFinVarDetail.Get_New_Row(rFV, dsMain.Tables["finvardetail"]);
            rFVD2["idupb"] = SelUPBDest.GetValue();
            if (underwritingRow != null){
                rFVD2["idunderwriting"] = underwritingRow["idunderwriting"];
            }
            rFVD2["nvar"] = rFV["nvar"];
            rFVD2["yvar"] = rFV["yvar"];
            rFVD2["amount"] = importo;
            //rFVD2["description"] = "storno a " + upb2.Row["codeupb"];
            rFVD2["idfin"] = finRow["idfin"];
            if (txtDescrizione.Text != "") {
                rFVD2["description"] = txtDescrizione.Text;
            }

        }
        
        private void FrmStornoTraUpb_FormClosing(object sender, FormClosingEventArgs e) {
            inChiusura = true;
            MetaData.UnregisterAllEvents(this);
            //this.ActiveControl = null;
        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            inChiusura = true;
            MetaData.UnregisterAllEvents(this);
        }

        private void txtImporto_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.LeaveDecTextBox(sender, e);
        }

    



        private void cmb_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e) {
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
        private void cmb_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e) {
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

        private void btnFinanziamento_Click(object sender, EventArgs e)
        {
            metaUnderwriting.FilterLocked = true;
            metaUnderwriting.DS = DS;
            DataRow MyDR = metaUnderwriting.SelectOne("default", null, null, null);

            if (MyDR != null)
            {
                TextBox T = txtUnderwriting;
                T.Text = MyDR["title"].ToString();
                underwritingRow = MyDR;
            }
            else
            {
                underwritingRow = null;
            }
        }
    }
}
