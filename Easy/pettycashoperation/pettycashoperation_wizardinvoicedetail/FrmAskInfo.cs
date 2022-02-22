
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

namespace pettycashoperation_wizardinvoicedetail{
    public partial class FrmAskInfo : MetaDataForm {
        MetaDataDispatcher Disp;
        
        DataAccess Conn;
        public DataRow Selected;
        public DataTable Dati;
        public object IDManagerSelected = DBNull.Value;
        public object IDUPBSelected = DBNull.Value;
        string filter_upb;
        bool upbToSelect;
        string currfilter_upb;
        bool InChiusura = false;
        decimal importo;
        object idmanager;
        object idfin;
        object idupb;
        decimal importoRimasto;
        object idpettycash;
        object idpettycashreg;
        string mode;
        public object idexp;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataSet D;
        DataTable responsabile;
        DataTable upb;
        DataTable fin;
        DataTable expensephase;
        public FrmAskInfo(string filter_upb, MetaDataDispatcher Disp,
            object idupb,
            object idmanager,
            object idfin,
            decimal importo,
            decimal importoRimasto,
            object idexp,
            object idpettycash,
            bool upbToSelect,
            string mode ) {
            InitializeComponent();

            this.filter_upb = filter_upb;
            this.currfilter_upb = filter_upb;
            this.Disp = Disp;
            this.Conn = Disp.Conn;
            this.importo = importo;
            this.idmanager = idmanager;
            this.idfin = idfin;
            this.idupb = idupb;
            this.importoRimasto = importoRimasto;
            this.idexp = idexp;
            this.idpettycash = idpettycash;
            this.upbToSelect = upbToSelect;
            this.mode = mode;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            txtImporto.Text = importo.ToString("c");
            Selected = null;

            responsabile = Conn.CreateTableByName("manager", "*", false);
            D = new DataSet();
            D.Tables.Add(responsabile);
            GetData.MarkToAddBlankRow(responsabile);
            GetData.Add_Blank_Row(responsabile);

            Conn.RUN_SELECT_INTO_TABLE(responsabile, "title", QHS.CmpEq("active", "S"), null, true);

            Conn.DeleteAllUnselectable(responsabile);
            cmbResponsabile.DataSource = responsabile;
            cmbResponsabile.ValueMember = "idman";
            cmbResponsabile.DisplayMember = "title";

            upb = Conn.CreateTableByName("upb", "*", false);
            D.Tables.Add(upb);
            GetData.MarkToAddBlankRow(upb);
            GetData.Add_Blank_Row(upb);
            Conn.RUN_SELECT_INTO_TABLE(upb, "codeupb", QHS.CmpEq("active", "S"), null, true);

            Conn.DeleteAllUnselectable(upb);
            if (filter_upb == null) {
                chkFilterAvailable.Checked = false;
                chkFilterAvailable.Enabled = false;
            }

            cmbUPB.DataSource = upb;
            cmbUPB.ValueMember = "idupb";
            cmbUPB.DisplayMember = "codeupb";

            fin = Conn.CreateTableByName("fin", "*", false);
            D.Tables.Add(fin);
            Conn.RUN_SELECT_INTO_TABLE(fin, null, QHS.CmpEq("idfin", idfin), null, true);

            Conn.DeleteAllUnselectable(fin);

            

            expensephase = Conn.CreateTableByName("expensephase", "*", false);
            D.Tables.Add(expensephase);
            GetData.MarkToAddBlankRow(expensephase);
            GetData.Add_Blank_Row(expensephase);
            string filterCmbPhase = QHS.AppAnd(QHS.CmpNe("nphase", Conn.GetSys("maxexpensephase")), QHS.CmpGe("nphase", Conn.GetSys("expensefinphase")));
            Conn.RUN_SELECT_INTO_TABLE(expensephase, "nphase", filterCmbPhase, null, true);
            cmbFaseSpesa.DataSource = expensephase;
            cmbFaseSpesa.ValueMember = "nphase";
            cmbFaseSpesa.DisplayMember = "description";

            string filterpcash = QHC.CmpEq("idpettycash", idpettycash);
            idpettycashreg = Conn.DO_READ_VALUE("pettycashsetup", filterpcash, "registrymanager");

            ImpostaOggetti();
        }

        private void ImpostaOggetti() {
            if (idexp != DBNull.Value){
                chkSpesa.Checked = true;
                EnableDisable(false);

                DataRow rExpense = Conn.RUN_SELECT("expense", "*", null, QHS.CmpEq("idexp", idexp), null, true).Rows[0];
                txtNum.Text = rExpense["nmov"].ToString();
                txtEserc.Text = rExpense["ymov"].ToString();
                cmbFaseSpesa.SelectedValue = rExpense["nphase"];
            }
            else{
                chkSpesa.Checked = false;
                EnableDisable(true);
            }

            if (idmanager != DBNull.Value && idmanager.ToString() != "" && responsabile.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbResponsabile, idmanager);
            }
            else{
                cmbResponsabile.SelectedIndex = 0;
            }
            if (idupb != null && idupb.ToString() != "" && upb.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbUPB, idupb);
            }
            if (idfin != DBNull.Value){
                txtBilancio.Text = fin.Rows[0]["codefin"].ToString();
                txtDenominazioneBilancio.Text = fin.Rows[0]["title"].ToString();
            }


        }

        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;

            int esercizio = (int)Conn.GetSys("esercizio");
            string filterpart = QHS.BitSet("flag", 0);// Parte spesa
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
                MetaData Meta = Disp.Get("finview");
                Meta.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                Selected = Meta.SelectOne("default", filter, "finview", null);
                riempiTextBox(Selected);
                RichiestaCambioResponsabile(Selected["idman"]);
                return;
            }

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                MetaData Meta = Disp.Get("finview");
                Meta.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                Selected = Meta.SelectOne("default", filter, "finview", null);
                riempiTextBox(Selected);

                RichiestaCambioResponsabile(Selected["idman"]);

                return;
            }

            chiamaFormBilancio(filter);
        }

        private void RichiestaCambioResponsabile(object currIdman ) {
            if ((currIdman != DBNull.Value) &&
                    ((cmbResponsabile.SelectedValue == null) 
                        || ((cmbResponsabile.SelectedValue != null)
                            && (cmbResponsabile.SelectedValue.ToString() != currIdman.ToString()))
                    )
                )
            {
                if ((cmbResponsabile.SelectedIndex <= 0) ||
                    show("Cambio il responsabile in base alla voce di bilancio selezionata?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    HelpForm.SetComboBoxValue(cmbResponsabile, currIdman);
                }
            }	

        }

        private void chiamaFormBilancio(string filtro) {
            MetaData Meta = Disp.Get("finview");
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.ExtraParameter = filtro;
            string edittype;
            if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            edittype = "treesupb";
            //if (filter_upb!=null)
            //    edittype= "tree" + E_S.ToLower() + "upb";
            //else 
            //    edittype= "tree" + E_S.ToLower();
            bool res = Meta.Edit(this, edittype, true);
            if (!res) return;
            Selected = Meta.LastSelectedRow;
            riempiTextBox(Selected);
            RichiestaCambioResponsabile(Selected["idman"]);
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
            string filterPart = QHS.BitSet("flag", 0);
            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")), filterPart, currfilter_upb);

            MetaData Meta = Disp.Get("finview");
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.startFieldWanted = "codefin";
            Meta.startValueWanted = null;

            Meta.startValueWanted = txtBilancio.Text.Trim();
            string startfield = Meta.startFieldWanted;
            string startvalue = Meta.startValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                //Meta.myGetData= myGetData;
                Selected = Meta.SelectByCondition(filter2, "finview");
            }

            if (Selected == null) {
                string edittype = "treesupb";
                bool res = Meta.Edit(this, edittype, true);
                if (!res) {
                    return;
                }
                Selected = Meta.LastSelectedRow;
            }

            riempiTextBox(Selected);
        }

        private void btnOk_Click(object sender, System.EventArgs e) {
            if (chkSpesa.Checked) {
                if ((txtEserc.Text.Trim() == "") || (txtNum.Text.Trim() == "")){
                    show("Selezionare un Movimento");
                    DialogResult = DialogResult.None;
                }
            }
            else {
                if (cmbResponsabile.SelectedIndex <= 0 && idmanager != null && idmanager != DBNull.Value){
                    show("Selezionare un responsabile");
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbUPB.SelectedIndex <= 0 && filter_upb == null && upbToSelect){
                    show("Selezionare un UPB");
                    DialogResult = DialogResult.None;
                    return;
                }
                if (cmbResponsabile.SelectedValue != null && cmbResponsabile.SelectedIndex > 0)
                    IDManagerSelected = cmbResponsabile.SelectedValue;
                else
                    IDManagerSelected = DBNull.Value;

                if (cmbUPB.SelectedValue != null && cmbUPB.SelectedIndex > 0)
                    IDUPBSelected = cmbUPB.SelectedValue.ToString();
                else
                    IDUPBSelected = DBNull.Value;

                if ((Selected == null) && txtBilancio.Text.Trim() == ""){
                    show("Selezionare una voce di bilancio");
                    DialogResult = DialogResult.None;
                }
            }

            if (CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImporto.Text, "x.y.c")) == 0){
                show("L'importo non può essere pari a zero.");
                DialogResult = DialogResult.None;
            }

            if (CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImporto.Text, "x.y.c")) < 0){
                show("L'importo non può essere negativo.");
                DialogResult = DialogResult.None;
            }

            decimal delta = TotaleImportoAssegnato();
            if (delta <0){
                show("La somma dei dettagli supera l'importo della fattura! Correggere l'importo.");
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
                txtBilancio.Enabled = true;
                chkFilterAvailable.Checked = true;
                chkFilterAvailable.Enabled = true;
            }

        }
        private void FrmAskInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (e.Cancel == true) return;
            if (DialogResult == DialogResult.Cancel) return;

            Dati = new DataTable();
            Dati.TableName = "Info";
            Dati.Columns.Add("idupb", typeof(string));
            Dati.Columns.Add("codeupb", typeof(string));
            Dati.Columns.Add("idman", typeof(int));
            Dati.Columns.Add("manager", typeof(string));
            Dati.Columns.Add("idfin", typeof(int));
            Dati.Columns.Add("codefin", typeof(string));
            Dati.Columns.Add("amount", typeof(decimal));
            Dati.Columns.Add("idexp", typeof(int));

            DataRow rDati = Dati.NewRow();

            if (Selected == null){
                rDati["idfin"]  = idfin;
                rDati["codefin"] = Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfin), "codefin");
            }
            else
            {
                rDati["idfin"] = Selected["idfin"];
                rDati["codefin"] = Selected["codefin"];
            }
            rDati["idupb"] = IDUPBSelected;
            rDati["codeupb"] = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", IDUPBSelected), "codeupb");

            rDati["idman"] = IDManagerSelected;
            rDati["manager"] = Conn.DO_READ_VALUE("manager", QHS.CmpEq("idman", IDManagerSelected), "title");

            rDati["amount"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImporto.Text, "x.y.c"));
            rDati["idexp"] = idexp;
            Dati.Rows.Add(rDati);

        }

        private decimal TotaleImportoAssegnato(){
            decimal valorePrecendente = importo;
            decimal importoinserito = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImporto.Text, "x.y.c"));
            decimal delta=0;
            if(mode=="InsertMode"){
            delta = importoRimasto - importoinserito;
            }
            else{
                delta = importoRimasto + valorePrecendente - importoinserito;
            }
            return delta;
        }

        private void txtImporto_Leave(object sender, EventArgs e){
            decimal importoText = CfgFn.GetNoNullDecimal(txtImporto.Text);
            txtImporto.Text = importoText.ToString("c");
            decimal delta = TotaleImportoAssegnato();
            if (delta <0){
                show("La somma dei dettagli supera l'importo della fattura!");
            }
        }

        void EnableDisableParteSpesa(bool enable)
        {
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseSpesa.Enabled = enable;
            btnSpesa.Enabled = enable;

        }
        void EnableDisableParteNormale(bool enable){
            btnBilancio.Enabled = enable;
            cmbUPB.Enabled = enable;
            txtBilancio.ReadOnly = !enable;
            cmbResponsabile.Enabled = enable;
            chkFilterAvailable.Enabled = enable;
            chkListManager.Enabled = enable;
            chkListTitle.Enabled = enable;
        }

        void EnableDisable(bool parteNormale){
            EnableDisableParteNormale(parteNormale);
            EnableDisableParteSpesa(!parteNormale);
        }

        private void chkSpesa_CheckedChanged(object sender, EventArgs e){
            if (idexp != DBNull.Value)
                return;
            if (chkSpesa.Checked)
            {
                EnableDisable(false);
                //if (Meta.IsEmpty) return;
                //DataRow R = DS.pettycashoperation.Rows[0];
                if (txtBilancio.Text != "" ||
                    cmbUPB.SelectedIndex >0  ||
                    cmbResponsabile.SelectedIndex > 0)
                {
                    if (show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre " +
                        "attribuzioni su questa operazione. Proseguo?", "Conferma",
                        MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        chkSpesa.Checked = false;
                        return;
                    }

                    if (cmbResponsabile.SelectedIndex > 0) {
                        cmbResponsabile.SelectedIndex = -1;
                    }
                    if (cmbUPB.SelectedIndex > 0) {
                        cmbUPB.SelectedIndex = -1;
                    }
                    //DS.finview.Clear();
                    Selected = null;
                    txtBilancio.Text = "";
                    txtDenominazioneBilancio.Text = "";
                    idfin = DBNull.Value;
                    return;
                }
                return;
            }
            //if (Meta.IsEmpty) return;
            EnableDisable(true);

            // se si è deciso di rimuovere il movimento e selezionare le info manualmente
            if (idexp != DBNull.Value) {
                if (show("Per abilitare la selezione delle attribuzioni normali su questa operazione è necessario annullare il collegamento al movimento di spesa " +
                    ". Proseguo?", "Conferma",
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    chkSpesa.Checked = true;
                    return;
                }
                idexp = DBNull.Value;
                //DS.expenseview.Clear();
                cmbFaseSpesa.SelectedIndex = 0;
                txtEserc.Text = "";
                txtNum.Text = "";
            }

        }

        private void btnSpesa_Click(object sender, EventArgs e) {
            string filter = "";
            string filterreg = QHS.DoPar(QHS.AppOr(QHS.IsNull("idreg"), QHS.CmpEq("idreg", idpettycashreg)));
		
            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0)
            {
                filter = QHS.AppAnd(filter, filterreg, QHS.CmpEq("nphase", selectedfase));
            }
            else
            {
                filter = QHS.AppAnd(filter,QHS.AppAnd(filterreg,
                                    QHS.CmpNe("nphase", Conn.GetSys("maxexpensephase")),
                                    QHS.CmpGe("nphase", Conn.GetSys("expensefinphase"))));
            }
            int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            decimal importoForFilter = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImporto.Text, "x.y.c"));
            if (importoForFilter == 0)
            {
                importoForFilter = importoRimasto;
            }

            if (importoForFilter > 0)
                filter = QHS.AppAnd(filter, QHS.CmpGe("available", importoForFilter));
            if (ymov != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
            }

            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
            }

            MetaData E = Disp.Get("expense");
            E.FilterLocked = true;
            E.DS = D.Clone();
            DataRow Choosen = E.SelectOne("default", filter, "expense", null);
            if (Choosen == null) return;
            idexp = Choosen["idexp"];
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];

        }

        private void txtNum_Leave(object sender, EventArgs e){
            if ((idexp != DBNull.Value) && (txtNum.Text.Trim() == ""))
            {
                idexp = DBNull.Value;
            }
            btnSpesa_Click(sender, e);
        }

        private void txtEserc_Leave(object sender, EventArgs e){
            HelpForm.FormatLikeYear(txtEserc);
            if (idexp != DBNull.Value){
                if (txtEserc.Text.Trim() == "")
                {
                    txtNum.Text = "";
                    idexp= DBNull.Value;
                }
                else{
                    int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                    if (oldYmov != newYmov){
                        txtNum.Text = "";
                        idexp = DBNull.Value;
                    }
                }

            }
        }
        int oldYmov = 0 ;
        private void txtEserc_Enter(object sender, EventArgs e) {
            oldYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
        }

    }
}
