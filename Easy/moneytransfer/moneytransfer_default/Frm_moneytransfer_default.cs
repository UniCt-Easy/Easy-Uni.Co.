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
using funzioni_configurazione;//funzioni_configurazione

namespace moneytransfer_default {
    public partial class Frm_moneytransfer_default : Form {
        MetaData Meta;
        public Frm_moneytransfer_default() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.treasurersource, "treasurer");
            DataAccess.SetTableForReading(DS.treasurerdest, "treasurer");
        }

        public void MetaData_AfterClear() {
            txtEsercizioDocumento.Text = Meta.GetSys("esercizio").ToString();
            txtEsercizioDocumento.ReadOnly = false;
            txtNumeroDocumento.ReadOnly = false;

            EnableDisableCassieri(true);
        }
        ////public void MetaData_AfterRowSelect(DataTable T, DataRow R){
        ////    if (T.TableName == "proceedspartview"){
        ////        if (R != null) ManageAssegnazioneChange(R);
        ////    }
        ////}

        ////void ManageAssegnazioneChange(DataRow Assegnazione){
        ////    //if (Meta.IsEmpty) return;
        ////    //object idtreasurersource = Assegnazione["idtreasurerincome"];
        ////    //object idtreasurerdest = Assegnazione["idtreasurer"];
        ////    //HelpForm.SetComboBoxValue(cmbCassiereorigine, idtreasurersource);
        ////    //HelpForm.SetComboBoxValue(cmbCassieredest, idtreasurerdest);
        ////    //decimal importocorrente = CfgFn.GetNoNullDecimal(
        ////    //        HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text,
        ////    //                    "x.y.c"));
        ////    //if (importocorrente!=CfgFn.GetNoNullDecimal(Assegnazione["moneytotransfer"])){
        ////    //    if (MessageBox.Show("Aggiorno il campo Importo col valore da Girofondare?",
        ////    //        "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
        ////    //        txtImporto.Text = Assegnazione["moneytotransfer"].ToString();
        ////    //}


        ////   }

        public void MetaData_AfterFill() {
            txtEsercizioDocumento.ReadOnly = true;
            txtNumeroDocumento.ReadOnly = true;

            if (Meta.EditMode) EnableDisableCassieri(false);

            if (Meta.InsertMode) {
                DataRow Curr = DS.moneytransfer.Rows[0];
                if ((Curr["yvar"] != DBNull.Value) || (Curr["yproceedspart"] != DBNull.Value))
                    EnableDisableCassieri(false);
                else
                    EnableDisableCassieri(true);
            }
        }


        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.MarkSkipSecurity(DS.treasurerdest);
            Conn = Meta.Conn;
            HelpForm.SetDenyNull(DS.moneytransfer.Columns["transferkind"], true);
        }

        //private void btnAssegnazione_Click(object sender, EventArgs e){
        //    //if (Meta.DrawStateIsDone) Meta.GetFormData(true);
        //    //string filter = QHS.AppAnd(QHS.IsNotNull("idtreasurerproceeds"), 
        //    //        QHS.IsNotNull("idtreasurer"), " ( idtreasurerproceeds <> idtreasurer ) ");
        //    //if (Meta.IsEmpty ){
        //    //    Meta.DoMainCommand("choose.proceedspartview.lista." + filter);
        //    //    return;
        //    //}
        //    //ManageAssegnazioneChange(null);

        //}

        //private void txtNumAssegnazione_Leave(object sender, EventArgs e){
        //    //if (!Meta.DrawStateIsDone) return;
        //    //string filter = "";
        //    //if (txtNumAssegnazione.Text.Trim() != "") {
        //    //    int nass = CfgFn.GetNoNullInt32( HelpForm.GetObjectFromString(typeof(Int32),
        //    //                    txtNumAssegnazione.Text, txtNumAssegnazione.Tag.ToString()));
        //    //    if (nass!=0) filter= QHS.AppAnd(filter,QHS.CmpEq("nproceedspart",nass));
        //    //}
        //    //if (txtEsercAssegnazione.Text.Trim() != "") {
        //    //    int yass = CfgFn.GetNoNullInt32( HelpForm.GetObjectFromString(typeof(Int32),
        //    //                    txtEsercAssegnazione.Text, txtEsercAssegnazione.Tag.ToString()));
        //    //    if (yass != 0) filter = QHS.AppAnd(filter, QHS.CmpEq("yproceedspart", yass));
        //    //}

        //    //ManageAssegnazioneChange(filter);
        //}

        //private void ManageAssegnazioneChange(string filter){
        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    if (!Meta.DrawStateIsDone) return;
        //    Meta.GetFormData(true);
        //    filter = QHS.AppAnd(filter, QHS.IsNotNull("idtreasurerproceeds"), QHS.IsNotNull("idtreasurer"),
        //        QHS.CmpGt("moneytotransfer", 0), " ( idtreasurerproceeds <> idtreasurer ) ");

        //    string filterTreasurerSource = "";
        //    if (cmbCassiereorigine.SelectedIndex > 0){
        //        filterTreasurerSource = QHS.CmpEq("idtreasurerproceeds", cmbCassiereorigine.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerSource);
        //    }

        //    string filterTreasurerDest = "";
        //    if (cmbCassieredest.SelectedIndex > 0) {
        //        filterTreasurerDest = QHS.CmpEq("idtreasurer", cmbCassieredest.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerDest);
        //    }

        //    MetaData Mproceedspartview = MetaData.GetMetaData(this, "proceedspartview");
        //    Mproceedspartview.FilterLocked = true;
        //    Mproceedspartview.DS = DS.Clone();

        //    if (Meta.InsertMode) {
        //        filter = QHS.AppAnd(filter, QHS.CmpGt("moneytotransfer", 0));
        //    }

        //    DataRow Choosen = Mproceedspartview.SelectOne("lista", filter, "proceedspartview", null);
        //    if (Choosen == null)
        //    {
        //        return;
        //    }
        //    ValorizzaCampiAssegnazioneCassa(Choosen);
        //    return;

        //}


        //private void ManageStornoChange(string filter)
        //{
        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    if (!Meta.DrawStateIsDone) return;
        //    filter = QHS.AppAnd(filter, QHS.IsNotNull("idtreasurerincome"), QHS.IsNotNull("idtreasurer"),
        //        QHS.CmpGt("moneytotransfer", 0), " ( idtreasurerincome <> idtreasurer ) ",QHS.CmpEq("kind","storno") );

        //    string filterTreasurerSource = "";
        //    if (cmbCassiereorigine.SelectedIndex > 0)
        //    {
        //        filterTreasurerSource = QHS.CmpEq("idtreasurerincome", cmbCassiereorigine.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerSource);
        //    }

        //    string filterTreasurerDest = "";
        //    if (cmbCassieredest.SelectedIndex > 0)
        //    {
        //        filterTreasurerDest = QHS.CmpEq("idtreasurer", cmbCassieredest.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerDest);
        //    }

        //    MetaData Moneytotransfer_available_view = MetaData.GetMetaData(this, "moneytotransfer_available_view");
        //    Moneytotransfer_available_view.FilterLocked = true;
        //    Moneytotransfer_available_view.DS = DS.Clone();

        //    if (Meta.InsertMode)
        //    {
        //        filter = QHS.AppAnd(filter, QHS.CmpGt("moneytotransfer", 0));
        //    }

        //    DataRow Choosen = Moneytotransfer_available_view.SelectOne("lista", filter, "moneytotransfer_available_view", null);
        //    if (Choosen == null)
        //    {   
        //        return;
        //    }
        //    ValorizzaCampiRiga(Choosen);
        //    return;

        //}

        //void ValorizzaCampiAssegnazioneCassa(DataRow Choosen) {
        //    //spostare le valorizzazinei qui deve essere chiamato due volte
        //    //quando seleziono label1'assegnazione incassi devo scollegare la variazione di bilancio eventuale
        //    //else viceversa
        //    //metto i campo a null e  svuotare relative tabelle nel dataset
        //    if (Choosen == null) return;
        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    Meta.GetFormData(true);
        //    DataRow Curr = DS.moneytransfer.Rows[0];


        //    decimal importocorrente = CfgFn.GetNoNullDecimal(
        //            HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text,
        //                        "x.y.c"));
        //    if (importocorrente != CfgFn.GetNoNullDecimal(Choosen["moneytotransfer"]))
        //    {
        //        if (MessageBox.Show("Aggiorno il campo Importo col valore da trasferire?",
        //            "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //            Curr["amount"] = CfgFn.GetNoNullDecimal(Choosen["moneytotransfer"]);
        //    }

        //    Curr["yvar"] = DBNull.Value;
        //    Curr["nvar"] = DBNull.Value;
        //    Curr["rownum"] = DBNull.Value;

        //    DS.finvardetail.Clear();


        //    object yproceedspart = Choosen["yproceedspart"];

        //    Curr["yproceedspart"] = Choosen["yproceedspart"];
        //    object nproceedspart = Choosen["nproceedspart"];

        //    Curr["nproceedspart"] = Choosen["nproceedspart"];

        //    object idtreasurerOrigine = Choosen["idtreasurerproceeds"];
        //    HelpForm.SetComboBoxValue(cmbCassiereorigine, idtreasurerOrigine);
        //    Curr["idtreasurersource"] = idtreasurerOrigine;

        //    object idtreasurerDest = Choosen["idtreasurer"];
        //    HelpForm.SetComboBoxValue(cmbCassieredest, idtreasurerDest);
        //    Curr["idtreasurerdest"] = idtreasurerDest;
        //    Meta.FreshForm();
        //}

        //void ValorizzaCampiRiga(DataRow Choosen)
        //{
        //    if (Choosen == null) return;

        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    Meta.GetFormData(true);
        //    DataRow Curr = DS.moneytransfer.Rows[0];


        //    decimal importocorrente = CfgFn.GetNoNullDecimal(
        //            HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text,
        //                        "x.y.c"));
        //    if (importocorrente != CfgFn.GetNoNullDecimal(Choosen["moneytotransfer"]))
        //    {
        //        if (MessageBox.Show("Aggiorno il campo Importo col valore da trasferire?",
        //            "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //            Curr["amount"] = CfgFn.GetNoNullDecimal(Choosen["moneytotransfer"]);
        //    }

        //    object y = Choosen["y"];
        //    object n = Choosen["n"];
        //    object ndet = Choosen["ndet"];

        //    string filter = "";
        //    if (Choosen["kind"].ToString() == "storno")
        //    {
        //        Curr["yproceedspart"] = DBNull.Value;
        //        Curr["nproceedspart"] = DBNull.Value;
        //        DS.proceedspartview.Clear();
        //        DS.finvardetail.Clear();

        //        filter = QHS.AppAnd(QHS.CmpEq("yvar", y), QHS.CmpEq("nvar", n), QHS.CmpEq("rownum", ndet));
        //        DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.finvardetail, null, filter, null, true);

        //        Curr["yvar"] = y;
        //        Curr["nvar"] = n;
        //        Curr["rownum"] = ndet;
        //    }
        //    else
        //    {
        //        Curr["yvar"] = DBNull.Value;
        //        Curr["nvar"] = DBNull.Value;
        //        Curr["rownum"] = DBNull.Value;
        //        DS.proceedspartview.Clear();
        //        DS.finvardetail.Clear();
        //        filter = QHS.AppAnd(QHS.CmpEq("nproceedspart", n), QHS.CmpEq("idinc", ndet));
        //        DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.proceedspartview, null, filter, null, true);

        //        Curr["yproceedspart"] = y;
        //        Curr["nproceedspart"] = n;
        //    }
        //    object idtreasurerOrigine = Choosen["idtreasurerincome"];
        //    HelpForm.SetComboBoxValue(cmbCassiereorigine, idtreasurerOrigine);
        //    Curr["idtreasurersource"] = idtreasurerOrigine;

        //    object idtreasurerDest = Choosen["idtreasurer"];
        //    HelpForm.SetComboBoxValue(cmbCassieredest, idtreasurerDest);
        //    Curr["idtreasurerdest"] = idtreasurerDest;
        //    Meta.FreshForm();

        //}


        private void FormattaDataDelTexBox(TextBox TB) {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }

        //private void txtEsercAssegnazione_Leave(object sender, EventArgs e){
        //if (!Meta.DrawStateIsDone) return;
        //FormattaDataDelTexBox(txtEsercAssegnazione);		
        //object yAssegnazione = txtEsercAssegnazione.Text;
        //string filter = "";
        //if (yAssegnazione != DBNull.Value) {
        //    filter = QHS.CmpEq("yproceedspart", yAssegnazione);
        //}
        //ManageAssegnazioneChange(filter);
        //}



        //private void btnStornoCassa_Click(object sender, EventArgs e) {
        // if (Meta.DrawStateIsDone) Meta.GetFormData(true);
        // string filter = QHS.AppAnd(QHS.IsNotNull("idtreasurerincome"),
        //      QHS.IsNotNull("idtreasurer"), " ( idtreasurerincome <> idtreasurer ) ", QHS.CmpEq("kind","storno"));
        // if (Meta.IsEmpty)
        // {
        //     Meta.DoMainCommand("choose.moneytotransfer_available_view.lista." + filter);
        //     return;
        // }
        //ManageStornoChange(null);
        //}

        //private void btnSeleziona_Click(object sender, EventArgs e) {

        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    if (!Meta.DrawStateIsDone) return;
        //    Meta.GetFormData(true);
        //   string  filter = QHS.AppAnd(QHS.IsNotNull("idtreasurerincome"), QHS.IsNotNull("idtreasurer"),
        //        QHS.CmpGt("moneytotransfer", 0), " ( idtreasurerincome <> idtreasurer ) ");

        //    string filterTreasurerSource = "";
        //    if (cmbCassiereorigine.SelectedIndex > 0)
        //    {
        //        filterTreasurerSource = QHS.CmpEq("idtreasurerincome", cmbCassiereorigine.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerSource);
        //    }

        //    string filterTreasurerDest = "";
        //    if (cmbCassieredest.SelectedIndex > 0)
        //    {
        //        filterTreasurerDest = QHS.CmpEq("idtreasurer", cmbCassieredest.SelectedValue);
        //        filter = QHS.AppAnd(filter, filterTreasurerDest);
        //    }

        //    MetaData Moneytotransfer_available_view = MetaData.GetMetaData(this, "moneytotransfer_available_view");
        //    Moneytotransfer_available_view.FilterLocked = true;
        //    Moneytotransfer_available_view.DS = DS.Clone();

        //    if (Meta.InsertMode)
        //    {
        //        filter = QHS.AppAnd(filter, QHS.CmpGt("moneytotransfer", 0));
        //    }

        //    DataRow Choosen = Moneytotransfer_available_view.SelectOne("lista", filter, "moneytotransfer_available_view", null);
        //    if (Choosen == null)
        //    {
        //        return;
        //    }

        //    //ValorizzaCampiRiga(Choosen);

        //}


        private void EnableDisableCassieri(bool enable) {
            btnCassiereOrigine.Enabled = enable;
            cmbCassiereorigine.Enabled = enable;
            btnCassiereDestinazione.Enabled = enable;
            cmbCassieredest.Enabled = enable;
        }


        //private void btnScollega_Click(object sender, EventArgs e)
        //{
        //    if (DS.moneytransfer.Rows.Count == 0) return;
        //    if (!Meta.DrawStateIsDone) return;
        //    Meta.GetFormData(true);

        //    DS.proceedspartview.Clear();
        //    DS.finvardetail.Clear();

        //    DataRow Curr = DS.moneytransfer.Rows[0];
        //    Curr["yvar"] = DBNull.Value;
        //    Curr["nvar"] = DBNull.Value;
        //    Curr["rownum"] = DBNull.Value;

        //    Curr["yproceedspart"] = DBNull.Value;
        //    Curr["nproceedspart"] = DBNull.Value;

        //    Meta.FreshForm();
        //}

    }
}