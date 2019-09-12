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
using funzioni_configurazione;
using System.Collections;
namespace no_table_wiz_cfpiva_duplicata {
    public partial class frmUnisciInformazioni : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        object[] idregs;
        int mainidreg;
        DataAccess Conn;
        MetaDataDispatcher Dispatcher;
        public vistaSubWizard DS;

        public frmUnisciInformazioni(int mainidreg, object[] idregs, DataAccess Conn, MetaDataDispatcher Dispatcher) {
            InitializeComponent();
            this.idregs = idregs;
            this.mainidreg = mainidreg;
            this.Conn = Conn;
            this.Dispatcher = Dispatcher;
            
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DS = new vistaSubWizard();

            PreFill();
            Start();
        }

        void PreFill() {
            Conn.RUN_SELECT_INTO_TABLE(DS.position, null, null, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.address, null, null, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.paymethod, null, null, null, false);
        }

        void Start() {
            FillTables();
            PreCalc();
            SetDataGrids();
            HideTabs();

        }

        void SetDataGrid(DataGrid G, string table, string listtype) {
            MetaData M = Dispatcher.Get(table);
            if (listtype == null) listtype = M.DefaultListType;
            if (listtype == null) listtype = "default";
            M.DescribeColumns(DS.Tables[table], listtype);
            HelpForm.SetAllowMultiSelection(DS.Tables[table], true);
            HelpForm.SetDataGrid(G, DS.Tables[table]);
        }
        void SetDataGrids() {
            SetDataGrid(gridmodpag, "registrypaymethod", "unione");
            SetDataGrid(gridposgiur, "registrylegalstatus", "unione");
            SetDataGrid(gridindirizzi, "registryaddress", "unione");
            SetDataGrid(gridcfstorico, "registrycf", "unione");
            SetDataGrid(gridivastorico, "registrypiva", "unione");
            SetDataGrid(gridreference, "registryreference", "unione");
            SetDataGrid(gridimponibile, "registrytaxablestatus", "unione");

        }
        void HideTabs() {
            if (DS.registryaddress.Rows.Count == 0) tabs.TabPages.Remove(TabIndirizzi);
            if (DS.registrypaymethod.Rows.Count == 0) tabs.TabPages.Remove(tabModPag);
            if (DS.registrylegalstatus.Rows.Count == 0) tabs.TabPages.Remove(tabMissioni);
            if (DS.registrycf.Rows.Count == 0) tabs.TabPages.Remove(tabCF);
            if (DS.registrypiva.Rows.Count == 0) tabs.TabPages.Remove(tabIva);
            if (DS.registryreference.Rows.Count == 0) tabs.TabPages.Remove(tabReference);
            if (DS.registrytaxablestatus.Rows.Count == 0) tabs.TabPages.Remove(tabImponibile);
        }
        void FillTables() {
            foreach (DataTable T in DS.Tables) {
                if (T.TableName == "registry") {
                    T.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(T, null, QHS.CmpEq("idreg",mainidreg), null, false);
                }
                else {
                    if (!T.Columns.Contains("!kk")) {
                        T.Columns.Add("!kk", typeof(int));
                    }
                    if (T.Columns.Contains("idreg")) {
                        T.Clear();
                        Conn.RUN_SELECT_INTO_TABLE(T, null, QHS.FieldIn("idreg", idregs), null, false);
                        for (int i = 0; i < T.Rows.Count; i++) T.Rows[i]["!kk"] = i;
                    }
                }
            }
            if (!DS.registrylegalstatus.Columns.Contains("!qualifica"))
                DS.registrylegalstatus.Columns.Add("!qualifica", typeof(string));
            if (!DS.registryaddress.Columns.Contains("!descrtipoindirizzo"))
                DS.registryaddress.Columns.Add("!descrtipoindirizzo", typeof(string));
            if (!DS.registryaddress.Columns.Contains("!comune"))
                DS.registryaddress.Columns.Add("!comune", typeof(string));
            if (!DS.registryaddress.Columns.Contains("!nazione"))
                DS.registryaddress.Columns.Add("!nazione", typeof(string));

            if (!DS.registrypaymethod.Columns.Contains("!tipomodalita"))
                DS.registrypaymethod.Columns.Add("!tipomodalita", typeof(string));


            //Campi Calcolati
            foreach (DataRow R in DS.registryaddress.Rows) {
                string f = QHC.CmpEq("idaddress", R["idaddresskind"]);
                if (DS.address.Select(f).Length > 0) {
                    R["!descrtipoindirizzo"] = DS.address.Select(f)[0]["description"];
                }
                object idnation = R["idnation"];
                if (idnation != DBNull.Value) R["!nazione"] =
                      Conn.DO_READ_VALUE("geo_nation", QHS.CmpEq("idnation", idnation),"title");
                object idcity = R["idcity"];
                if (idcity != DBNull.Value) R["!comune"] =
                        Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcity), "title");
            }

            foreach (DataRow R in DS.registrylegalstatus.Rows) {
                string f = QHC.CmpEq("idposition", R["idposition"]);
                if (DS.position.Select(f).Length > 0) {
                    R["!qualifica"] = DS.position.Select(f)[0]["description"];
                }
            }

            foreach (DataRow R in DS.registrypaymethod.Rows) {
                string f = QHC.CmpEq("idpaymethod", R["idpaymethod"]);
                if (DS.paymethod.Select(f).Length > 0) {
                    R["!tipomodalita"] = DS.paymethod.Select(f)[0]["description"];
                }


            }


        }
        void GridSelectRow(DataGrid G, int I,string tablename, string edittype,  string []key) {
            DataRow R = GetGridRow(G,I);
            if (R == null) return;
            MetaData MTable = Dispatcher.Get(tablename);
            string filter = "";
            foreach(string f in key) filter=QHS.AppAnd(filter,QHS.CmpEq(f,R[f]));
            MTable.ContextFilter = filter;
            MTable.Edit(this.ParentForm, edittype, false);
            string listtype = MTable.DefaultListType;
            DataRow RR = MTable.SelectOne(listtype, filter, null, null);
            if (RR != null) MTable.SelectRow(RR, listtype);
        }

        DataRow GetGridRow(DataGrid G,  int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("!kk", G[index, 0]);

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        string[] GetKey(DataTable T) {
            int N = T.PrimaryKey.Length;
            string[] k = new string[N];
            for (int i = 0; i < N; i++) k[i] = T.PrimaryKey[i].ColumnName;
            return k;
        }


        //se true, A è contenuto in B e A è da eliminare
        bool ModPag_AcontainsB(DataRow A, DataRow B) {
            //cin
            foreach (string field in new string[] { "idpaymethod","cin", "idbank", "idcab", "cc", "iban","iddeputy" }) {
                if (!AContainsB(A[field], B[field])) return false;
            }            
            return true;
        }

        bool ModPag_AequalsB(DataRow A, DataRow B) {
            foreach (string field in new string[] {"idpaymethod", "cin", "idbank", "idcab", "cc", "iban", "iddeputy" }) {
                if (B[field].ToString().ToLower() != A[field].ToString().ToLower()) return false;
            }
            return true;
        }

        void PrecalcModPag() {
            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();

            for (int i = 0; i < DS.registrypaymethod.Rows.Count; i++) {
                DataRow Ri = DS.registrypaymethod.Rows[i];
                //considera la mod. di pagamento I
                for (int j = 0; j < DS.registrypaymethod.Rows.Count; j++) {
                    //considera la mod. di pagamento J
                    if (i == j) continue;
                    DataRow Rj = DS.registrypaymethod.Rows[j];
                    if (ModPag_AequalsB(Rj, Ri) && (i < j)) continue;

                    if (ModPag_AcontainsB(Rj, Ri)) {
                        int idreg = CfgFn.GetNoNullInt32(Ri["idreg"]);
                        if (idreg == mainidreg) {
                            ToDel.Add(Ri);
                        }
                        else {
                            ToClear.Add(Ri);
                        }
                        break; //passa al prossimo Ri
                    }


                }
            }
            DelAndClear(ToDel, ToClear, DS.registrypaymethod);
        }

        bool AContainsB(object A, object B) {
            if (B.ToString() == "") return true;
            if (A.ToString() == "") return false;
            if (A.GetType() == typeof(string)) {
                return (A.ToString().Trim().ToLower().Contains(B.ToString().ToLower().Trim()));
            }
            else {
                return A.ToString() == B.ToString();
            }

        }

        //se true, A è contenuto in B e A è da eliminare
        bool Address_AcontainsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "address","cap","idcity","idnation"}) {
                if (!AContainsB(A[field],B[field]))return false;
            }            
            if ((A["location"].ToString()!="")&&((B["location"].ToString()=="")&&
                        (B["idcity"]==DBNull.Value)&&(A["idcity"]==DBNull.Value))) return false;
            if (((DateTime)B["start"]).CompareTo((DateTime)A["start"]) > 0) {
                B["start"] = A["start"];
            }
            return true;
        }
        bool Address_AequalsB(DataRow A, DataRow B) {
            foreach (string field in new string[] {"idaddresskind","location", "address", "cap", "idcity", "idnation" }) {
                if (B[field].ToString().ToLower() != A[field].ToString().ToLower()) return false;
            }
            return true;
        }

        void PrecalcAddress() {
            object id_default = DS.address.Select(QHC.CmpEq("codeaddress", "07_SW_DEF"))[0]["idaddress"];
            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();

            for (int i = 0; i < DS.registryaddress.Rows.Count; i++) {
                DataRow Ri = DS.registryaddress.Rows[i];
                //considera la mod. di pagamento I
                for (int j = 0; j < DS.registryaddress.Rows.Count; j++) {
                    //considera la mod. di pagamento J
                    if (i == j) continue;
                    DataRow Rj = DS.registryaddress.Rows[j];
                    //unifica solo verso quello predefinito
                    if (Rj["idaddresskind"].ToString()!=id_default.ToString()) continue;
                    if (Address_AequalsB(Rj, Ri) && (i < j)) continue;
                    
                    if (Address_AcontainsB(Rj, Ri)) {
                        int idreg = CfgFn.GetNoNullInt32(Ri["idreg"]);
                        if (idreg == mainidreg) {
                            ToDel.Add(Ri);
                        }
                        else {
                            ToClear.Add(Ri);
                        }
                        break; //passa al prossimo Ri
                    }


                }
            }
            DelAndClear(ToDel, ToClear, DS.registryaddress);
        }



        //se true, A è contenuto in B e A è da eliminare
        bool RTS_AcontainsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "supposedincome","start"}) {
                if (!AContainsB(A[field], B[field])) return false;
            }
            //if (((DateTime)B["start"]).CompareTo((DateTime)A["start"]) > 0) {
            //    B["start"] = A["start"];
            //}
            return true;
        }
        bool RTS_AequalsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "supposedincome","start" }) {
                if (B[field].ToString().ToLower() != A[field].ToString().ToLower()) return false;
            }
            return true;
        }

        void PrecalcRegistryTaxableStatus() {
            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();

            for (int i = 0; i < DS.registrytaxablestatus.Rows.Count; i++) {
                DataRow Ri = DS.registrytaxablestatus.Rows[i];
                //considera la mod. di pagamento I
                for (int j = 0; j < DS.registrytaxablestatus.Rows.Count; j++) {
                    //considera la mod. di pagamento J
                    if (i == j) continue;
                    DataRow Rj = DS.registrytaxablestatus.Rows[j];
                    //unifica solo verso quello predefinito
                    if (RTS_AequalsB(Rj, Ri) && (i < j)) continue;

                    if (RTS_AcontainsB(Rj, Ri)) {
                        int idreg = CfgFn.GetNoNullInt32(Ri["idreg"]);
                        if (idreg == mainidreg) {
                            ToDel.Add(Ri);
                        }
                        else {
                            ToClear.Add(Ri);
                        }
                        break; //passa al prossimo Ri
                    }


                }
            }
            DelAndClear(ToDel, ToClear, DS.registrytaxablestatus);
        }



        bool RLS_AcontainsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "start","incomeclass","incomeclassvalidity","idposition","stop" }) {
                if (!AContainsB(A[field], B[field])) return false;
            }
            //if (((DateTime)B["start"]).CompareTo((DateTime)A["start"]) > 0) {
            //    B["start"] = A["start"];
            //}
            return true;
        }
        bool RLS_AequalsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "start","incomeclass", "incomeclassvalidity", "idposition", "stop" }) {
                if (B[field].ToString().ToLower() != A[field].ToString().ToLower()) return false;
            }
            return true;
        }

        void PrecalcRegistryLegalStatus() {
            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();

            for (int i = 0; i < DS.registrylegalstatus.Rows.Count; i++) {
                DataRow Ri = DS.registrylegalstatus.Rows[i];
                //considera la mod. di pagamento I
                for (int j = 0; j < DS.registrylegalstatus.Rows.Count; j++) {
                    //considera la mod. di pagamento J
                    if (i == j) continue;
                    DataRow Rj = DS.registrylegalstatus.Rows[j];
                    //unifica solo verso quello predefinito
                    if (RLS_AequalsB(Rj, Ri) && (i < j)) continue;

                    if (RLS_AcontainsB(Rj, Ri)) {
                        int idreg = CfgFn.GetNoNullInt32(Ri["idreg"]);
                        if (idreg == mainidreg) {
                            ToDel.Add(Ri);
                        }
                        else {
                            ToClear.Add(Ri);
                        }
                        break; //passa al prossimo Ri
                    }


                }
            }
            DelAndClear(ToDel, ToClear, DS.registrylegalstatus);
        }

        bool Reference_AcontainsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "referencename", "email", "faxnumber", "mobilenumber", "phonenumber" }) {
                if (!AContainsB(A[field], B[field])) return false;
            }
            //if (((DateTime)B["start"]).CompareTo((DateTime)A["start"]) > 0) {
            //    B["start"] = A["start"];
            //}
            return true;
        }
        bool Reference_AequalsB(DataRow A, DataRow B) {
            foreach (string field in new string[] { "referencename", "email", "faxnumber", "mobilenumber", "phonenumber" }) {
                if (B[field].ToString().ToLower() != A[field].ToString().ToLower()) return false;
            }
            return true;
        }

        void PrecalcRegistryReference() {
            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();

            for (int i = 0; i < DS.registryreference.Rows.Count; i++) {
                DataRow Ri = DS.registryreference.Rows[i];
                //considera la mod. di pagamento I
                for (int j = 0; j < DS.registryreference.Rows.Count; j++) {
                    //considera la mod. di pagamento J
                    if (i == j) continue;
                    DataRow Rj = DS.registryreference.Rows[j];
                    //unifica solo verso quello predefinito
                    if (Reference_AequalsB(Rj, Ri) && (i < j)) continue;

                    if (Reference_AcontainsB(Rj, Ri)) {
                        int idreg = CfgFn.GetNoNullInt32(Ri["idreg"]);
                        if (idreg == mainidreg) {
                            ToDel.Add(Ri);
                        }
                        else {
                            ToClear.Add(Ri);
                        }
                        break; //passa al prossimo Ri
                    }


                }
            }
            DelAndClear(ToDel, ToClear, DS.registryreference);
        }




        void DelAndClear(ArrayList ToDel, ArrayList ToClear, DataTable T) {
            foreach (object O in ToClear) {
                DataRow R = O as DataRow;
                if (R == null) continue;
                if (R.RowState == DataRowState.Deleted) continue;
                if (R.RowState == DataRowState.Detached) continue;
                R.Delete();
                R.AcceptChanges();
            }
            
            foreach (object O in ToDel) {
                DataRow R = O as DataRow;
                if (R == null) continue;
                if (R.RowState == DataRowState.Deleted) continue;
                if (R.RowState == DataRowState.Detached) continue;
                R.Delete();
            }

        }

        void PreCalc() {
            PrecalcModPag();
            PrecalcAddress();
            PrecalcRegistryTaxableStatus();
            PrecalcRegistryLegalStatus();
            PrecalcRegistryReference();
        }
        
        void ClearGridUnselected(DataGrid G,string tablename) {
            string dataMember = G.DataMember;
            CurrencyManager cm = G.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view.Count == 0) return;

            DataTable T = DS.Tables[tablename];
            string[] k = GetKey(T);

            int nselected=0;
            for (int ii = 0; ii < view.Count; ii++) {
                if (G.IsSelected(ii)) nselected++;
            }
            if (nselected == 0) {
                MessageBox.Show("Nessuna riga selezionata");
                return;
            }


            ArrayList ToDel= new ArrayList();
            ArrayList ToClear  = new ArrayList();
            for (int i = 0; i < view.Count; i++) {
                if (G.IsSelected(i)) continue;
                
                DataRow R = GetGridRow(G, i);
                if (R == null) continue;
                int idreg = CfgFn.GetNoNullInt32( R["idreg"]);
                if (idreg == mainidreg) {
                    ToDel.Add(R);
                }
                else {
                    ToClear.Add(R);
                }                

            }

            DelAndClear(ToDel, ToClear, T);



        }

        void ClearAllUnselected() {
            ClearGridUnselected(gridmodpag, "registrypaymethod");
            ClearGridUnselected(gridposgiur, "registrylegalstatus");
            ClearGridUnselected(gridindirizzi, "registryaddress");
            ClearGridUnselected(gridcfstorico, "registrycf");
            ClearGridUnselected(gridivastorico, "registrypiva");
            ClearGridUnselected(gridreference, "registryreference");
            ClearGridUnselected(gridimponibile, "registrytaxablestatus");

        }
        void CorreggiFlag(DataTable T, string fieldSN) {
            if (T.Select().Length==0) return;
            string filter = QHC.CmpEq(fieldSN, "S");
            if (T.Select(filter).Length == 0) {
                if (T.Select().Length == 1) T.Select()[0][fieldSN] = "S";
                return;
            }
            if (T.Select(filter).Length == 1) return;

            string filtermain = QHC.AppAnd(filter, QHC.CmpEq("idreg", mainidreg));
            string filterother = QHC.AppAnd(filter, QHC.CmpNe("idreg", mainidreg));
            if (T.Select(filtermain).Length > 0) {
                DataRow[] foundmain = T.Select(filtermain);
                for (int i = 1; i < foundmain.Length; i++) foundmain[i][fieldSN] = "N";
                foreach (DataRow R in T.Select(filterother)) R[fieldSN] = "N";
            }
            else {
                DataRow[] foundother = T.Select(filterother);
                for (int i = 1; i < foundother.Length; i++) foundother[i][fieldSN] = "N";
            }

        }
        void PulisciRigheSpurie(DataTable T) {
            foreach (DataRow R in T.Select(QHC.CmpNe("idreg", mainidreg))) {
                R.Delete();
                R.AcceptChanges();
            }
        }

       

        void AllineaTabella(string table, string campoflag) {
            DataRow Main = DS.registry.Rows[0];
            DataTable T = DS.Tables[table];
            MetaData M = Dispatcher.Get(T.TableName);
            M.SetDefaults(T);
            foreach (DataRow R in T.Select()) {
                int curridreg = CfgFn.GetNoNullInt32(R["idreg"]);
                if (mainidreg == curridreg) continue;
                DataRow New = M.Get_New_Row(Main, T);
                foreach (DataColumn C in T.Columns) {
                    if (RowChange.IsAutoIncrement(C)) continue;
                    //non copiare idreg 
                    if (C.ColumnName == "idreg") continue;
                    New[C.ColumnName] = R[C.ColumnName];
                }

            }
            if (campoflag!=null) CorreggiFlag(T, campoflag);
            PulisciRigheSpurie(T);
        }
        void CorreggiRegistryAddress() {
            //Sistema prima quelli gli Start per i doppioni
                DataRow[] RRfound = DS.registryaddress.Select();
                foreach (DataRow R in RRfound) {
                    string fk = QHC.AppAnd(QHC.CmpEq("idaddresskind", R["idaddresskind"]),
                                    QHC.CmpEq("start", R["start"]));
                    DataRow[] copies = DS.registryaddress.Select(fk,"lt DESC");
                    for (int i = 1; i < copies.Length; i++) {
                        DateTime TryDate= (DateTime) R["start"] ;
                        TryDate= TryDate.Subtract(new TimeSpan(1,0,0,0));
                        string fk2 = QHC.AppAnd(QHC.CmpEq("idaddresskind", R["idaddresskind"]),
                                    QHC.CmpEq("start", TryDate));
                        while (DS.registryaddress.Select(fk2).Length > 0) {
                            TryDate = TryDate.Subtract(new TimeSpan(1, 0, 0, 0));
                            fk2 = QHC.AppAnd(QHC.CmpEq("idaddresskind", R["idaddresskind"]),
                                        QHC.CmpEq("start", TryDate));
                        }
                        copies[i]["start"] = TryDate;
                    }

                }



            foreach (DataRow AddressKind in DS.address.Rows) {
                DataRow[] Rfound = DS.registryaddress.Select(QHC.CmpEq("idaddresskind", AddressKind["idaddress"]),
                                            "start ASC");
                if (Rfound == null || Rfound.Length <= 1) continue;
                for (int i = 0; i < Rfound.Length; i++) {
                    //Rfound[i]["active"] = "S";
                    if (i == Rfound.Length-1) {
                        if (Rfound[i]["stop"]!=DBNull.Value)
                            MessageBox.Show("Attenzione, l'anagrafica rimane senza indirizzi di tipo "+
                                AddressKind["codeaddress"].ToString()+ " validi.");
                        continue;
                    }
                    Rfound[i]["active"] = "N";
                    DateTime succ =  (DateTime) Rfound[i+1]["start"] ;
                    succ = succ.Subtract(new TimeSpan(1,0,0,0));
                    Rfound[i]["stop"] = succ;                    
                }
            }
        }


        private void btnOk_Click(object sender, EventArgs e) {
            //ClearAllUnselected();
            AllineaTabella("registrypaymethod", "flagstandard");
            AllineaTabella("registryaddress",null);
            CorreggiRegistryAddress();
            AllineaTabella("registrylegalstatus", null);
            AllineaTabella("registrycf", null);
            AllineaTabella("registrypiva", null);
            AllineaTabella("registryreference", "flagdefault");
            AllineaTabella("registrytaxablestatus", null);
            MetaData M = Dispatcher.Get("registry");
            PostData P = M.Get_PostData();
            P.InitClass(DS, Conn);
            if (P.DO_POST()) return;
            DialogResult = DialogResult.None;
            Start();
        }

        private void btnImpostaModPagamento_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridmodpag, "registrypaymethod");

        }

        private void btnImpostaPosGiur_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridposgiur, "registrylegalstatus");

        }

        private void btnImpostaIndirizzi_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridindirizzi, "registryaddress");
        }

        private void btnContatti_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridreference, "registryreference");

        }

        private void btnCF_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridcfstorico, "registrycf");
        }

        private void btnPIva_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridivastorico, "registrypiva");

        }

        private void btnImponibile_Click(object sender, EventArgs e) {
            ClearGridUnselected(gridimponibile, "registrytaxablestatus");

        }

        private void btnChangeRegModeCode_Click(object sender, EventArgs e) {
            DataGrid G = gridmodpag;
            string dataMember = G.DataMember;
            CurrencyManager cm = G.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view.Count == 0) return;
            FrmAskCodice FF = new FrmAskCodice("n");
            DialogResult D = FF.ShowDialog();
            if (D == DialogResult.Cancel) return;
            string newcodice = FF.txtCodice.Text.Trim();

            DataTable T = DS.Tables["registrypaymethod"];
            string[] k = GetKey(T);

            ArrayList ToDel = new ArrayList();
            ArrayList ToClear = new ArrayList();
            for (int i = 0; i < view.Count; i++) {
                if (!G.IsSelected(i)) continue;

                DataRow R = GetGridRow(G, i);
                if (R == null) continue;
                R["regmodcode"] = newcodice;
                return;

            }

        }

        private void btnRead_Click(object sender, EventArgs e) {
            FillTables();
            //PreCalc();
            SetDataGrids();
            //HideTabs();
        }

        //DateTime LastGridClick;
        //private void GRID_MouseDown(object sender, MouseEventArgs e) {
        //    if (sender == null) return;
        //    if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
        //    LastGridClick = DateTime.Now;

        //}

        //private void GRID_MouseUp(object sender, MouseEventArgs e) {
        //    if (sender == null) return;
        //    if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
        //    DataGrid = sender as DataGrid;

        //    DataSet D = DetailGrid.DataSource as DataSet;
        //    if (D == null) return;
        //    DataTable T = D.Tables[DetailGrid.DataMember];
        //    if (T == null) return;

        //    System.Windows.Forms.DataGrid.HitTestInfo myHitTest = DetailGrid.HitTest(e.X, e.Y);
        //    if (myHitTest.Type == System.Windows.Forms.DataGrid.HitTestType.Cell) {
        //        int Row = myHitTest.Row;
        //        if (!DetailGrid.IsSelected(Row)) {
        //            SimpleSelect(Row);
        //        }
        //        else {
        //            DetailGrid.UnSelect(Row);
        //        }
        //    }
        //    else {
        //        int Row = myHitTest.Row;
        //    }
        //}

        //void SimpleSelect(int R) {
        //    try {
        //        DetailGrid.Select(R);
        //    }
        //    catch {
        //    }
        //}

    }
}