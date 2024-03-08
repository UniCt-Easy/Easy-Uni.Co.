
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
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;

namespace AskInfo {
    public partial class FrmAskInfo : MetaDataForm {
        QueryHelper QHS;
        QueryHelper QHC;
        DataAccess Conn;
        Manager_SelectionManager SelManager = null;
        UPB_SelectionManager SelUPB=null;
        Fin_SelectionManager SelFin = null;
        
        //string fintable;
        MetaData M;
        bool busy = false;

        MetaData MetaFin;
        string E_S;
        MetaData MetaUPB;
        bool SelectUPB;
        bool SelectManager;
        private bool allowNoFinSelection = false;
        private bool allowNoUpbSelection = false;
        private bool allowNoManagerSelection = false;
        bool destroyed = false;

        public void Destroy() {
            if (destroyed) return;
            destroyed = true;
            MetaData.UnregisterAllEvents(this);

            if (this.SelManager != null) {
                this.SelManager.Destroy();
                this.SelManager = null;
            }
            if (this.SelFin != null) {
                this.SelFin.Destroy();
                this.SelFin = null;
            }
            if (this.SelUPB != null) {
                this.SelUPB.Destroy();
                this.SelUPB = null;
            }
            if (this.MetaUPB != null) {
                this.MetaUPB.Destroy();
                this.MetaUPB = null;
            }
            if (this.MetaFin != null) {
                this.MetaFin.Destroy();
                this.MetaFin = null;
            }
            this.Conn = null;
            this.QHS = null;
            this.QHC = null;
            this.M = null;

            btnBilancio.Click -= btnBilancio_Click;
            if (SelectUPB) {
                btnUPB.Click -= btnUPB_Click;
            }
         

        }

        public FrmAskInfo askUpbAs(string title) {
            gboxUPB.Text = title;
            return this;
        }
        public FrmAskInfo AllowNoFinSelection(bool allow) {
            allowNoFinSelection = allow;
            return this;
        }
        public FrmAskInfo AllowNoUpbSelection(bool allow) {
            allowNoUpbSelection = allow;
            return this;
        }
        public FrmAskInfo AllowNoManagerSelection(bool allow) {
            allowNoManagerSelection = allow;
            return this;
        }
        public FrmAskInfo allowSelectPhase(string caption) {
            var tableFasiName = E_S == "S" ? "expensephase" : "incomephase";
            var fasi = Conn.readTable(tableFasiName);
            cmbFasi.DataSource= fasi;
            cmbFasi.ValueMember="nphase";
            cmbFasi.DisplayMember="description";

            gboxFasi.Text = caption;
            gboxFasi.Visible = true;
            return this;
        }

        private string fintable;

        public FrmAskInfo(MetaData M, string E_S, bool SelectUPB) {
            InitializeComponent();
            this.Conn = M.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            this.M = M;
            this.E_S = E_S;
            this.SelectUPB = SelectUPB;
            fintable =  "finview" ;
            gboxFasi.Visible = false;
                        
            MetaFin = CreateNewMeta(M.Dispatcher, fintable);
            MetaUPB = CreateNewMeta(M.Dispatcher, "upb");

            SelManager = new Manager_SelectionManager(M, txtResponsabile).FilterFinance();
            SelFin = new Fin_SelectionManager(M,  txtBilancio, txtDenominazioneBilancio,  fintable);
            SelFin.GetFilter = GetFinFilterOperativo;
            SelFin.SetListType("lista");
            btnBilancio.Click += btnBilancio_Click;

            SelUPB = new UPB_SelectionManager(M, txtUPB, txtDescrUPB);
            if (SelectUPB) {
                EnableUPBSelection(true);
                btnUPB.Click += btnUPB_Click;
            }
            else {
                EnableUPBSelection(false);
            }


            chkFilterAvailable.Visible = false;
            chkFilterAvailable.Checked = false;
            

            EnableFinSelection(true);
            EnableManagerSelection(true);
            
        }

        private MetaData CreateNewMeta(MetaDataDispatcher Disp, string table){
            MetaData M = Disp.Get(table);
            DataSet D = new DataSet("a");
            D.EnforceConstraints = false;
            DataTable T = Conn.CreateTableByName(table, "*");
            D.Tables.Add(T);
            return M;
        }

        decimal importo=0;
        public FrmAskInfo EnableFilterAvailable(decimal importo) {
            //if (SelectUPB == false) return this;
            if (SelectUPB == false && SelUPB.GetValue() == DBNull.Value) return this;

            this.importo = importo;
            chkFilterAvailable.Visible = true;
            chkFilterAvailable.Checked = true;
            txtImporto.Text = importo.ToString("c");
            gboxImporto.Visible = true;
            SelUPB.OnChange = OnUPBChange;
            OnUPBChange(SelUPB.GetValue());
            return this;
            
        }

        string GetFinFilterAll(string fintableLocale) {
            string filter = "";

            //assume finview come vista
            object idupb = SelUPB.GetValue();
            if (idupb != DBNull.Value) {
                if (fintableLocale == "finview")  filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", idupb));
            }
            else {
                if (fintableLocale == "finview") filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", "0001"));
            }

            if (chkFilterAvailable.Checked && fintableLocale=="finview") {
                filter = QHS.AppAnd(filter, QHS.CmpGe("availableprevision",importo));
            }

            int esercizio = (int)M.GetSys("esercizio");
            filter = QHS.AppAnd(filter, QHS.CmpEq("ayear", esercizio));

            string filterpart = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            filter = QHS.AppAnd(filter, filterpart);

            if (idupb == DBNull.Value && chkListManager.Checked) {
                object idman = SelManager.GetValue();
                if (idman != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idman", idman));
                }
            }

            return filter;
        }

        string GetFinFilterOperativo(string fintableLocale) {
            if (MetaFin.destroyed) return null;
            string filter = GetFinFilterAll(fintableLocale);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear = '"
                + MetaFin.GetSys("esercizio") + "'))";
            return QHS.AppAnd(filter, filteroperativo);
        }



        void OnUPBChange(object idupb) {
            if (idupb == DBNull.Value) {
                gboxBilAnnuale.Visible = false;
                chkFilterAvailable.Checked = false;
                chkFilterAvailable.Enabled = false;
            }
            else {
                gboxBilAnnuale.Visible = true;
                chkFilterAvailable.Checked = true;
                chkFilterAvailable.Enabled = true;
                object idman = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "idman");
                if (idman != DBNull.Value && SelectManager) {
                    SelManager.SetValue(idman);
                    EnableManagerSelection(false);
                }
                
            }

            int count = 0;
            if (this.E_S == "S") {
                count = CfgFn.GetNoNullInt32(Conn.count("finusable", q.bitClear("flag", 1) & q.bitSet("flag", 0) & q.eq("ayear", M.GetSys("esercizio"))));
			}
            else {
                count = CfgFn.GetNoNullInt32(Conn.count("finusable", q.bitClear("flag", 1) & q.bitClear("flag", 0) & q.eq("ayear", M.GetSys("esercizio"))));
			}
            
            if (chkFilterAvailable.Checked && count != 1) {
                SelFin.SetValue(DBNull.Value);
                EnableFinSelection(true);
            }
            else {
                chkFilterAvailable.Checked = false;
                EnableFinSelection(true);
            }
        }


        #region Gestione Responsabile
        public FrmAskInfo EnableManagerSelection(bool enable) {
            SelectManager = enable;
            txtResponsabile.ReadOnly = !enable;
            txtResponsabile.TabStop = enable;
            return this;
        }
        public FrmAskInfo SetManager(object idman) {
            SelManager.SetValue(idman);
            EnableManagerSelection(idman == DBNull.Value);
            return this;
        }
        public object GetManager() {
            return SelManager.GetValue();
        }
        #endregion

        #region Gestione Bilancio

        public FrmAskInfo EnableFinSelection(bool enable) {
            txtBilancio.ReadOnly = !enable;
            btnBilancio.Enabled = enable;
            return this;
        }

        public object GetFin() {
            return SelFin.GetValue();
        }
        public object GetFinCode() {
            return SelFin.getCode();
        }
        public object GetFinTitle() {
            return SelFin.getTitle();
        }
        public object GetUpbCode() {
            return SelUPB.getCode();
        }
        public object GetUpbTitle() {
            return SelUPB.getTitle();
        }
        public object GetManagerTitle() {
            return SelManager.getCode();
        }
        public object GetFaseMovimento() {
            return cmbFasi.SelectedValue;
        }

        private void chiamaFormBilancio(string filtro) {
            busy = true;
            MetaData mFin = MetaFin.Dispatcher.Get(fintable);

            mFin.FilterLocked = true;
            mFin.SearchEnabled = false;
            mFin.MainSelectionEnabled = true;
            mFin.StartFilter = filtro;
            mFin.ExtraParameter = filtro;
            string edittype;
            //if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            //edittype = "tree" + E_S.ToLower() + "upb";
            //if (SelUPB.GetValue() != DBNull.Value)
                edittype = "tree" + E_S.ToLower() + "upb";
            //else
            //    edittype = "tree" + E_S.ToLower();
            bool res = mFin.Edit(this, edittype, true);

            if (!res) {
                mFin.Destroy();
                busy = false;
                return;
            }
            DataRow Selected = mFin.LastSelectedRow;
            SelFin.SelectRow(Selected);
            mFin.Destroy();
            busy = false;
        }


        private void btnBilancio_Click(object sender, System.EventArgs e) {
            if (destroyed) return;
            busy = true;
            string filterAll = GetFinFilterAll(fintable);

            if (chkListManager.Checked) {                
                MetaFin.FilterLocked = true;
                DataRow Selected = MetaFin.SelectOne("default", GetFinFilterOperativo("finview"), "finview", null);
                if (Selected != null) SelFin.SelectRow(Selected);
                busy = false;
                return;
            }

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
				createForm(FR, this);
				DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                /*filter = GetData.MergeFilters(filter,
                    "(title like "+QueryCreator.quotedstrvalue(
                    "%"+FR.txtDescrizione.Text+"%",true))+")";*/
                string filter = QHS.Like("title", '%' + FR.txtDescrizione.Text + '%');
                MetaFin.FilterLocked = true;
                filter = GetData.MergeFilters(filter, GetFinFilterOperativo("finview"));
                DataRow Selected = MetaFin.SelectOne("default", filter, "finview", null);
                if (Selected != null) SelFin.SelectRow(Selected);
                busy = false;
                return;
            }

            chiamaFormBilancio(filterAll);
            busy = false;
        }
        #endregion

        #region Gestione UPB

        public FrmAskInfo EnableUPBSelection(bool enable) {
            txtUPB.ReadOnly = !enable;
            txtUPB.TabStop = enable;
            btnUPB.Enabled = enable;
            return this;
        }

        public FrmAskInfo SetFin(object idfin) {
            SelFin.SetValue(idfin);
            EnableFinSelection(idfin == DBNull.Value);
            return this;
        }

        public FrmAskInfo SetUPB(object idupb) {
            SelUPB.SetValue(idupb);
            EnableUPBSelection(idupb == DBNull.Value);
            return this;
        }

        public object GetUPB() {
            return SelUPB.GetValue();
        }

        private void btnUPB_Click(object sender, System.EventArgs e) {
            chiamaFormUPB("(active='S')");
        }

        private void chiamaFormUPB(string filtro) {
            busy = true;
            MetaData mUPB = MetaUPB.Dispatcher.Get("upb");

            mUPB.FilterLocked = true;
            mUPB.SearchEnabled = false;
            mUPB.MainSelectionEnabled = true;
            mUPB.StartFilter = filtro;
            mUPB.ExtraParameter = filtro;
            string edittype = "tree";
            
            bool res = mUPB.Edit(this, edittype, true);

            if (!res) {
                mUPB.Destroy();
                busy = false;
                return;
            }
            DataRow Selected = mUPB.LastSelectedRow;
            SelUPB.SelectRow(Selected);
            mUPB.Destroy();
            busy = false;
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e) {
            if (destroyed) return;
            if (busy) {
                show("Attendere il completamento dell'operazione", "Avviso");
                DialogResult = DialogResult.None;
                return;
            }
            if (SelectManager && !allowNoManagerSelection) {
                if (SelManager.GetValue() == DBNull.Value) {
                    show("Selezionare un responsabile");
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            if (SelectUPB && !allowNoUpbSelection) {
                if (SelUPB.GetValue() == DBNull.Value) {
                    show("Selezionare un UPB");
                    DialogResult = DialogResult.None;
                    return;

                }
            }
            if (SelFin.GetValue() == DBNull.Value && ! allowNoFinSelection) {
                show("Selezionare una voce di bilancio");
                DialogResult = DialogResult.None;
                return;
            }

        }

        private void FrmAskInfo_FormClosed(object sender, FormClosedEventArgs e) {

        }

        private void FrmAskInfo_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
            if (busy) {
                show("Attendere il completamento dell'operazione", "Avviso");
                e.Cancel = true;
                return;
            }
        }

        private void BtnAnnulla_Click(object sender, EventArgs e) {
            if (busy) {
                show("Attendere il completamento dell'operazione", "Avviso");
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
    public class Generic_SelectionManager {
        protected TextBox T;
        protected object _keyValue;

        //bool disabled = false;
        Form F;
        protected DataAccess Conn;
        protected QueryHelper QHS;
        private string displayField;
        private string keyField;
        private string table;
        private string listtype = "default";
        private string _filter = null;

        MetaData Meta;
        public delegate void OnChangeDelegate(object newValue);
        public OnChangeDelegate OnChange;

        public delegate string GetFilterDelegate(string table);
        public  GetFilterDelegate GetFilter;

        public bool destroyed = false;
        public void Destroy() {
            if (destroyed) return;
            destroyed = true;
            this.Conn = null;
            T.LostFocus -= this.TextBoxLostFocus;
            T.GotFocus -= this.textBoxGotFocus;
            this.T = null;
            this.QHS = null;
            if (this.Meta != null) {
                this.Meta.Destroy();
                this.Meta = null;
            }
            
        }

        bool Disabled() {
            if (destroyed) return true;
            if (F == null) return true;
            if (F.IsDisposed) return true;
            if (F.Disposing) return true;
            if (!F.Visible) return true;
            return false;
        }

        private string MyGetFilter(string table) {
            return _filter;
        }

        public Generic_SelectionManager(MetaData M,  TextBox T,
            string displayField, string keyField, string table) {
            this.T = T;
            F = T.FindForm();
            this.Conn = M.Conn;
            QHS = Conn.GetQueryHelper();
            this.displayField = displayField;
            this.keyField = keyField;
            this.table = table;
            Meta = M.Dispatcher.Get(table);
            Meta.FilterLocked = true;
            Meta.linkedForm = F;
            DataSet DS = new DataSet();
            DS.EnforceConstraints = false;
            DataTable TT = Conn.CreateTableByName(table,"*");
            DS.Tables.Add(TT);
            Meta.DS = DS;
            Meta.myGetData = M.Get_GetData();            
            GetFilter = MyGetFilter;
            Meta.privateGetData = true;
            T.LostFocus += this.TextBoxLostFocus;
            T.GotFocus += this.textBoxGotFocus;

        }
        public Generic_SelectionManager SetListType(string listtype){
            this.listtype = listtype;
            return this;
        }
        public Generic_SelectionManager SetFilter(string filter) {
            this._filter = filter;
            return this;
        }


        protected virtual void refillControls(DataRow R) {
            T.Text = R[displayField].ToString();
        }

        protected virtual void clearControls() {
            T.Text = "";
        }

        private void mySetValue(object keyValue){
            this._keyValue = keyValue;
            if (OnChange != null) OnChange(keyValue);
        }

        public void SetValue(object keyValue) {
            if (keyValue == DBNull.Value) {                
                clearControls();
                mySetValue(DBNull.Value);
                return;
            }
            DataTable T = Conn.RUN_SELECT(table, "*", null, QHS.CmpEq(keyField, keyValue), null, false);
            if (T == null || T.Rows.Count == 0) return;
            SelectRow(T.Rows[0]);
        }

        public  void SelectRow(DataRow R) {
            if (R == null) return;
            refillControls(R);
            mySetValue( R[keyField]);
        }

        public object GetValue() {
            if (_keyValue == null) return DBNull.Value;
            return _keyValue;
        }

        string LastTextNoFound = "";
        bool busy = false;

        private void textBoxGotFocus(object s, EventArgs e) {
            if (destroyed) return;
            if (Disabled()) return;
            if (busy) return;
            if (T.Enabled == false) return;
            if (T.ReadOnly == true) return;

            LastTextNoFound = T.Text;
        }

        private void TextBoxLostFocus(object s, EventArgs e) {
            if (destroyed) return;
            if (busy) return;
            if (Disabled()) return;

            string SavedLastTextNoFound = LastTextNoFound;
            if (T == null) return;
            if (T.Enabled == false) return;
            if (T.ReadOnly == true) return;
            if (T.Text == LastTextNoFound) return;
            if (Meta.destroyed) return;

            Control OldFocused = F.ActiveControl;

            //QueryCreator.MarkEvent("Leaving T... ");

            //Control G = T.Parent;

            busy = true;

            //Get all conditions from "table" linked control in groupbox
            string oldval = T.Text;
            string searchval = oldval;
            if (!searchval.EndsWith("%")) searchval += "%";
            
            string myFilter = QHS.AppAnd(GetFilter(table), QHS.Like(displayField, searchval));



            //take startvalue
            string startv = T.Text.Trim();
            bool selected = false;

            if (startv == "") {
                SetValue(DBNull.Value);
                selected = true;
            }

            
            if ((searchval != LastTextNoFound)) { //||((Now-LastMsgTime)>200)){
                //if (NewStr==LastTextNoFound) QueryCreator.MarkEvent("Diff was "+diff.ToString());
                LastTextNoFound = searchval;

                //do a choose.table.listtype.filter
                if (!selected)  {
                    selected = Choose(myFilter);
                }
               if (selected)
                    LastTextNoFound = T.Text; //CAN BE DIFFERENT FROM THE PREVIOUS!!
                else
                    LastTextNoFound = SavedLastTextNoFound;


            }
            else {
                busy = false;
                return;
            }


            if (Disabled()) return;
            if (!selected) {

                F.Activate();
                RecursiveSelect(T);

            }
            busy = false;
        }

        void RecursiveSelect(Control C) {
            if (C.Parent != null) {
                if (C.GetType() != typeof(Form)) RecursiveSelect(C.Parent);
            }
            C.Focus();
            C.Select();
        }

        bool Choose(string filter) {
            if (destroyed) return false;
            Meta.DS.Tables[table].Clear();
            DataRow SelectedRow = null;

            SelectedRow = Meta.SelectOne(listtype, filter, table, null);

            if (SelectedRow == null) {
                return false;
            }
            SelectRow(SelectedRow);
            return true;
        }
        public virtual object getCode() {
            if (T.Text != "") return DBNull.Value;
            return T.Text;
        }
    }


    public class Manager_SelectionManager: Generic_SelectionManager{
       

        public Manager_SelectionManager(MetaData Meta,  TextBox T)
            :
                    base(Meta,  T, "title", "idman", "manager") {
            SetFilter(QHS.CmpEq("active", "S"));
        }

        public Manager_SelectionManager FilterFinance() {
            SetFilter(QHS.CmpEq("financeactive","S"));
            return this;
        }
       
        
    }

    public class UPB_SelectionManager : Generic_SelectionManager {
        TextBox TTitle;
        public UPB_SelectionManager(MetaData Meta, TextBox TxtCode, TextBox TxtTitle)
            :
                    base(Meta,  TxtCode, "codeupb", "idupb", "upb") {
            this.TTitle = TxtTitle;
        }
        protected override void refillControls(DataRow R) {
            if (destroyed) return;
            base.refillControls(R);
            if (TTitle!=null) TTitle.Text = R["title"].ToString();            
        }
        protected override void clearControls() {
            if (destroyed) return;
            base.clearControls();
            if (TTitle != null) TTitle.Text = "";
        }
       
        public object getTitle() {
            if (TTitle == null) return DBNull.Value;
            if (TTitle.Text != "") return DBNull.Value;
            return TTitle.Text;
        }
    }

    public class Fin_SelectionManager :Generic_SelectionManager{
        TextBox TTitle;
        public Fin_SelectionManager(MetaData M,  TextBox TxtCode, TextBox TxtTitle, string table)
            :base(M,  TxtCode, "codefin", "idfin", table) {
            this.TTitle = TxtTitle;
        }
        protected override void refillControls(DataRow R) {
            if (destroyed) return;
            base.refillControls(R);
            if (TTitle!=null) TTitle.Text = R["title"].ToString();            
        }
        protected override void clearControls() {
            if (destroyed) return;
            base.clearControls();
            if (TTitle != null) TTitle.Text = "";
        }

        
        public object getTitle() {
            if (TTitle == null) return DBNull.Value;
            if (TTitle.Text != "") return DBNull.Value;
            return TTitle.Text;
        }
    }

    public class Accmotiveapplied_SelectionManager : Generic_SelectionManager {
        TextBox TTitle;
        public Accmotiveapplied_SelectionManager(MetaData M, TextBox TxtCode, TextBox TxtTitle)
            : base(M, TxtCode, "codemotive", "idaccmotive", "accmotiveapplied") {
            this.TTitle = TxtTitle;
        }
        protected override void refillControls(DataRow R) {
            if (destroyed) return;
            base.refillControls(R);
            if (TTitle != null)
                TTitle.Text = R["motive"].ToString();
        }
        protected override void clearControls() {
            if (destroyed) return;
            base.clearControls();
            if (TTitle != null) TTitle.Text = "";
        }
    }
    

}
