
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
using System.Globalization;
using funzioni_configurazione;
using ep_functions;

namespace assetunload_generauto {
    public partial class FrmAssetUnload_generauto : MetaDataForm {
        private object CodiceTipoBuono = null;
        private object idreg = null;
        private object idmot = null;
        private bool flag_bene = true;
        private bool flag_parte = true;
        private MetaData Meta;
        private DataAccess Conn;
        private DataTable TempTable;
        private bool flagcreddeb;
        private bool flagcausale;
        bool Warning = false;
        private MetaData Mentrataview;
        private int codicefase;
        private object m_DataRatifica = DBNull.Value;
        private EP_Manager EPM;

        public FrmAssetUnload_generauto() {
            InitializeComponent();
            GetData.SetSorting(DS.incomeview, "ymov DESC,nmov DESC");
            QueryCreator.SetTableForPosting(DS.assetpieceview, "asset");
            TempTable = new DataTable("temptable");
            cboTipo.DataSource = DS.assetunloadkind;
            cboTipo.DisplayMember = "description";
            cboTipo.ValueMember = "idassetunloadkind";

        }
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            HelpForm.SetAllowMultiSelection(DS.assetpieceview, true);
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filter, null, false);
            GetData.CacheTable(DS.incomephase, null, "nphase", true);
            Mentrataview = MetaData.GetMetaData(this, "incomeview");

            //Tooltip
            Tip.SetToolTip(btnInizia, "Cliccare qui per far partire la generazione automatica");
            Tip.SetToolTip(grpIncludi, "Selezionare una delle voci per filtrare la generazione completa");
            Tip.SetToolTip(rdoAll, "Selezionare questa voce se si vogliono tutti i tipi di scarico");
            Tip.SetToolTip(rdoBene, "Selezionare questa voce se si vuole scaricare solo i cespiti");
            Tip.SetToolTip(rdoParte, "Selezionare questa voce se si vuole scaricare solo gli aumenti di valore");
            Tip.SetToolTip(btnGeneraTutto, "Cliccare qui per avviare in qualsiasi momento la generazione automatica");
            //Tip.SetToolTip(btnAddAll,"Cliccare qui per collegare al buono sia gli scarichi cespiti che gli scarichi parti");
            Tip.SetToolTip(btnAddBene, "Cliccare qui per scaricare i cespiti e gli eumenti di valore selezionati");
            Tip.SetToolTip(btnSuccessivo, "Cliccare qui per passare al buono successivo");
            EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "assetunload");
        }

        public void MetaData_AfterClear() {
            if (Meta.GointToInsertMode) return;
            Text = "Generazione automatica buoni di scarico";
        }

        public void MetaData_BeforeFill() {
            GetData.DenyClear(DS.assetpieceview);
        }
        public void MetaData_AfterActivation() {
            codicefase = MetaData.MaxFromColumn(DS.incomephase, "nphase");
            if (DS.config.Rows.Count == 0) {
                show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente!", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Warning = true;
                return;
            }
            DataRow r = DS.Tables["config"].Rows[0];
            string flagnumerazione = r["asset_flagnumbering"].ToString().ToUpper();
            if (flagnumerazione == "" || flagnumerazione == "N") {
                show("Non è stato definito il tipo di numerazione per la configurazione " +
                    "del PATRIMONIO per l'esercizio corrente", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Warning = true;
                return;
            }
            byte assetload_flag = (byte)r["assetload_flag"];
            flagcreddeb = (assetload_flag & 1) == 1;
            flagcausale = (assetload_flag & 2) == 2;
            if (flagcausale == false && flagcreddeb == false) {
                show("Non è stata definita la configurazione dei buoni " +
                    "di carico / scarico per l'esercizio corrente.\rI buoni eventualmente " +
                    "generati verranno creati senza creditore e causale.\r\r",
                    "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(flagcreddeb) {
                txtCredDeb.ReadOnly = false;
            }
            else {
                txtCredDeb.ReadOnly = true;
            }
            if (flagcausale) {
                cboCausale.Enabled = true;
            }
            else {
                cboCausale.Enabled = false;
            }
            AbilitaBottoni(false);
            AbilitaBottoniOperazioni(false);
            Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
        }
        private void AbilitaBottoniBene(bool enable) {
            btnAddBene.Enabled = (enable && flag_bene);
            btnDeselBene.Enabled = (enable && flag_bene);
        }
        private void AbilitaBottoniOperazioni(bool enable) {
            btnSuccessivo.Enabled = enable;
        }

        private void AbilitaBottoni(bool enable) {
            AbilitaBottoniBene(enable);
            btnSi.Enabled = enable && (flag_bene || flag_parte);
            btnNo.Enabled = enable && (flag_bene || flag_parte);
            btnGeneraTutto.Enabled = enable && (flag_bene || flag_parte);
        }

        public void MetaData_BeforePost() {
            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "assetunloadkind") {
                CodiceTipoBuono = (R == null ? null : R["idassetunloadkind"]);
                flag_bene = (R != null && R["idassetunloadkind"].ToString() != "");
                flag_parte = (R != null && R["idassetunloadkind"].ToString() != "");
                rdoBene.Enabled = flag_bene;
                rdoParte.Enabled = flag_parte;
                //abilitato se è abilitata almeno una voce
                rdoAll.Enabled = (flag_bene || flag_parte);
            }
            if (T.TableName == "registry") {
                idreg = (R == null ? DBNull.Value : R["idreg"]);
                if (Meta.InsertMode && Meta.DrawStateIsDone) {
                    DataRow Curr = DS.assetunload.Rows[0];
                    Curr["idreg"] = R["idreg"];
                }
            }
            if (T.TableName == "assetunloadmotive") {
                idmot = (R == null ? DBNull.Value : R["idmot"]);
            }

        }

        void visualizzaMessaggio() {
            string messaggio = "Non ci sono scarichi ";
            if (rdoAll.Checked) {
                messaggio += "cespiti o aumenti di valore da elaborare";
            }
            else {
                if (rdoBene.Checked) {
                    messaggio += "cespiti da elaborare";
                }
                if (rdoParte.Checked) {
                    messaggio += "aumenti di valore da elaborare";
                }
            }
            show(messaggio);
        }

        private string GetInventoryFilter(QueryHelper QH, object codInventario) {
            string filter = "";
            string filterInv = QH.CmpEq("idinventory", codInventario);
            string SQLfilterInv = QHS.CmpEq("idinventory", codInventario);

            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "flag"));
            bool flagMixed = ((flag & 2) != 0);

            if (flagMixed) {

                // Se il flag vale S, non devo filtrare i carichi sull'inventario ma solo sull'ente Inventariale
                object inventoryAgency = Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "idinventoryagency");
                string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                if (ListInvEnte.Rows.Count > 0) {
                    if (ListInvEnte.Rows.Count != 0) {
                        filter = QH.FieldIn("idinventory", ListInvEnte.Select());
                    }
                    else {
                        filter = filterInv;
                    }
                }
                else {
                    filter = filterInv;
                }
            }
            else {

                filter = filterInv;
            }
            return filter;
        }
        private void CollegaRigheADocumento(bool quiet) {
            if ((TempTable == null) || (TempTable.Rows.Count == 0)) {
                if (!quiet) visualizzaMessaggio();
                //show("Non ci sono scarichi cespiti e/o parti da elaborare");
                AbilitaBottoniOperazioni(false);
                AbilitaBottoni(false);
                //cboTipo.Enabled=true;
                grpIncludi.Enabled = true;
                //btnInizia.Enabled=true;
                return;
            }

            string fCodTipoBuono = QHS.CmpEq("idassetunloadkind", cboTipo.SelectedValue);
            DataRow[] codiceinventarioRow = DS.assetunloadkind.Select(fCodTipoBuono);
            object codInventario = DBNull.Value;
            if ((codiceinventarioRow != null) && (codiceinventarioRow.Length > 0)) {
                codInventario = codiceinventarioRow[0]["idinventory"];
            }


            string condizioniaggiuntive = GetInventoryFilter(QHS, codInventario);
            // Considera o meno il filtro su Inventario in base a flagmixed di inventory
            //if (TempTable.Columns["xxx"] != null) {
            //    // Considera o meno il filtro su Inventario in base a flagmixed di inventory
            //    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,GetInventoryFilter(QHS,codInventario));
            //}

            if (TempTable.TableName != "dummy") {
                DataRow CurrRow = TempTable.Rows[0];
                if (flagcreddeb) {
                    object codicecreddeb = CurrRow["idreg"];
                    MetaData.SetDefault(DS.assetunload, "idreg", codicecreddeb);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idreg", codicecreddeb));
                }
                if (flagcausale) {
                    object codicecausale = CurrRow["idmot"];
                    MetaData.SetDefault(DS.assetunload, "idmot", codicecausale);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idmot", codicecausale));
                }
            }
            else {
                MetaData.SetDefault(DS.assetunload, "idreg", DBNull.Value);
                MetaData.SetDefault(DS.assetunload, "idmot", DBNull.Value);
            }


            DS.assetpieceview.Clear();
            MetaData.SetDefault(DS.assetunload, "idassetunloadkind", CodiceTipoBuono);
            MetaData.SetDefault(DS.assetunload, "idreg", idreg);
            MetaData.SetDefault(DS.assetunload, "idmot", idmot);
            MetaData.SetDefault(DS.assetunload, "dataratifica", m_DataRatifica);
            Meta.EditNew();
            string sort = "idassetunloadkind ASC, yassetunload ASC, nassetunload ASC";
            string filter = QHS.AppAnd(condizioniaggiuntive,
                QHS.BitSet("flag", 0), QHS.IsNull("idassetunloadkind"), QHS.IsNull("yassetunload"),
                QHS.IsNull("nassetunload"));

            //DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.scaricobeneinventarioview, sort,filter,null,false);
            //DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.scaricoparteinventarioview, sort,filter,null,false);

            if (rdoAll.Checked || rdoBene.Checked || rdoParte.Checked) {
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetpieceview, sort, filter, null , false);
            }

            MetaData.FreshForm(this, false);
            int max = DS.assetpieceview.Rows.Count;
            for (int i = 0; i < max; i++) {
                dgrCaricoBene.Select(i);
            }
            AbilitaBottoniOperazioni(false); //true
            CheckBottoniBene();
            CheckBottoneTutto();
            //ControlloRatifica();
            //			if (TempTable.TableName=="dummy") TempTable=null;
        }
        private void CheckBottoniBene() {
            DataSet DSbene = (DataSet)dgrCaricoBene.DataSource;
            DataTable T = (DataTable)DSbene.Tables[dgrCaricoBene.DataMember.ToString()];
            DataRow[] rows = T.Select(null, null, DataViewRowState.CurrentRows);
            AbilitaBottoniBene(rows.Length > 0);
        }
        private void CheckBottoneTutto() {
            //il controllo dei flag si trova già nell'enabled dei singoli button
            btnSi.Enabled = (btnAddBene.Enabled );
            btnNo.Enabled = (btnAddBene.Enabled );
            btnGeneraTutto.Enabled = (btnAddBene.Enabled );
        }
        private void btnChiudi_Click(object sender, System.EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnGeneraTutto_Click(object sender, System.EventArgs e) {
            Meta.GetFormData(true);
            foreach (string c in new string[] { "description", "docdate", 
                "enactmentdate", "doc", "enactment" }) {
                if (DS.assetunload.Rows[0][c] != DBNull.Value) {
                    MetaData.SetDefault(DS.assetunload, c, DS.assetunload.Rows[0][c]);
                }
            }

            while ((TempTable != null) && (TempTable.Rows.Count > 0)) {
                bool esito = AccettaDocumento(/*link*/);
                if (!esito) break;
                CollegaRigheADocumento(true);
            }
            AbilitaBottoni(false);
            AbilitaBottoniOperazioni(false);
            Meta.DontWarnOnInsertCancel = true;
        }
        private void AbilitaRatificaCampo(bool enable) {
            txtDataRatifica.ReadOnly = !enable;
        }
        private void AbilitaRatificaGrid(bool enable) {
            btnCollegaMov.Enabled = enable;
            btnScollegaMov.Enabled = enable;
            gridRatifica.Enabled = enable;
        }
        private void AbilitaRatifica(bool enable) {
            AbilitaRatificaCampo(enable);
            AbilitaRatificaGrid(enable);
        }
        private void ParseDate(TextBox T) {
            if (!T.Enabled) return;
            if (T.ReadOnly) return;
            if (T.Text == "") {
                m_DataRatifica = DBNull.Value;
                return;
            }
            string tag = HelpForm.GetStandardTag(T.Tag);
            tag = tag + ".d";
            string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
            string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string S = T.Text + hhsep + "0" + ppsep + "0";
            int len = S.Length;
            object valore = DBNull.Value;
            while (len > 0) {
                try {
                    valore = HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
                    if ((valore != null) && (valore != DBNull.Value)) break;
                }
                catch {
                }
                len = len - 1;
                S = S.Substring(0, len);
            }
            T.Text = HelpForm.StringValue(valore, tag);
            m_DataRatifica = valore;
        }
        private string GetTempQuery(string tipo) {
            string ParteSelect, ParteFrom, ParteWhere;
            string SelectClause, FromClause, WhereClause;
            string fCodTipoBuono = "(idassetunloadkind = " + QueryCreator.quotedstrvalue(cboTipo.SelectedValue, true) + ")";

            DataRow[] codiceinventarioRow = DS.assetunloadkind.Select(fCodTipoBuono);
            object codInventario = DBNull.Value;
            if ((codiceinventarioRow != null) && (codiceinventarioRow.Length > 0)) {
                codInventario = codiceinventarioRow[0]["idinventory"] ;
            }

            //ParteSelect = "'tipobuono' as xxx";
            ParteSelect = "idinventory";
            ParteWhere = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.IsNull("idassetunloadkind"),
                        QHS.IsNull("yassetunload"), QHS.IsNull("nassetunload"));

            //PARTE NUOVA, sul bit "pronto per lo scarico"
            //Per questo flag andrebbe messo un check come viene fatto nel wizard "Agiunta guidata" nel form Buono scarico
            //E solo se sta spuntato il check applica il filtro, altrimenti non lo deve applicare.
            //ParteWhere = QHS.AppAnd(ParteWhere, QHS.BitSet("flag", 1));

            if (codInventario != DBNull.Value) {
                // considero se devo filtrare per inventario 
                ParteWhere = QHS.AppAnd(ParteWhere, GetInventoryFilter(QHS, codInventario));
                string filterInv = QHS.CmpEq("idinventory", codInventario);
                int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", filterInv, "flag"));
                bool flagMixed = ((flag & 2) != 0);
                if (!flagMixed) {
                    ParteSelect += ", inventory";
                }
            }


            SelectClause = "SELECT ";
            FromClause = " FROM ";
            WhereClause = " WHERE ";
            ParteFrom = "assetpieceview";

            switch (tipo) {
                case "B": ParteWhere=QHS.AppAnd(ParteWhere,QHS.CmpEq("idpiece",1)) ; break;
                case "P": ParteWhere = QHS.AppAnd(ParteWhere, QHS.CmpGt("idpiece", 1)); break;
            }

            //if (flagcreddeb) {
            //    ParteSelect = MyAppend(ParteSelect, "idreg");
            //}
            //if (flagcausale) {
            //    ParteSelect = MyAppend(ParteSelect, "idmot");
            //}
            if ((flagcreddeb == false) && (flagcausale == false)) {
                //ParteSelect = MyAppend(ParteSelect, "idreg");
                //ParteSelect = MyAppend(ParteSelect, "idmot");
            }

            return SelectClause + ParteSelect + FromClause + ParteFrom +
                WhereClause + ParteWhere;
        }


        private void FillTempTable() {
            string query = "";

            if (rdoAll.Checked) {
                query = GetTempQuery("B") + " UNION " + GetTempQuery("P");
            }
            else {
                if (rdoBene.Checked || rdoParte.Checked) {
                    query = GetTempQuery("B");
                }
                if (rdoParte.Checked) {
                    query = GetTempQuery("P");
                }
            }

            //string query=GetTempQuery("B")+" UNION "+GetTempQuery("P");
            string GroupByClause = " GROUP BY ";
            string OrderByClause = " ORDER BY ";
            string ParteGroupBy = "idinventory, inventory";
            string ParteOrderBy = "";
            bool config = false;
            if (flagcreddeb ) {
                //ParteGroupBy = MyAppend(ParteGroupBy, "idreg");
                //ParteOrderBy = MyAppend(ParteOrderBy, "idreg ASC");
                //config = true;
            }
            if (flagcausale ) {
                //ParteGroupBy = MyAppend(ParteGroupBy, "idmot");
                //ParteOrderBy = MyAppend(ParteOrderBy, "idmot ASC");
                //config = true;
            }
            if (!config) {
                //GroupByClause="";
                OrderByClause = "";
            }
            if (config) {
                TempTable = Conn.SQLRunner(query + GroupByClause + ParteGroupBy + OrderByClause + ParteOrderBy, true);
            }
            else {
                DataTable Temp = Conn.SQLRunner(query + GroupByClause + ParteGroupBy + OrderByClause + ParteOrderBy, true);
                //				DataTable Temp = Conn.SQLRunner(query);
                if ((Temp != null) && (Temp.Rows.Count > 0)) {
                    TempTable = new DataTable("dummy");
                    DataRow R = TempTable.NewRow();
                    TempTable.Rows.Add(R);
                }
                else {
                    TempTable = null;
                }
            }


        }

        private string MyAppend(string source, string toappend) {
            if (source.Trim() == "") return toappend;
            return source + ", " + toappend + " ";
        }


        private DataRow GetDetailRow(DataGrid G, int index, string key) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            var keyidasset =key.Split(',')[0];
            var keyidpiece = key.Split(',')[1];
            //string filter = QHS.AppAnd(QHS.CmpEq("idasset", G[index, 2]),
            //                QHS.CmpEq("idpiece", G[index, 3]));
            string filter = QHC.AppAnd(QHC.CmpEq(keyidasset, G[index, 0].ToString()), QHC.CmpEq(keyidpiece, G[index, 1].ToString()));
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        private void CollegaTipoDoc(DataGrid G, int count, string key) {
            bool messaggiovisualizzato = false;

            DataRow R = DS.assetunload.Rows[0];
            object idbuono = R["idassetunload"];
            show("Insieme al cespiti selezionati saranno scaricati anche i relativi ACCESSORI",
            "Avviso");

            for (int i = 0; i < count; i++) {
                if (G.IsSelected(i)) {
                    DataRow CurrRow = GetDetailRow(G, i, key);
                    CurrRow["idassetunload"] = idbuono;

                    string filterpiece = QHC.AppAnd(QHC.CmpEq("idasset", CurrRow["idasset"]),
                                     QHC.CmpGt("idpiece", 1), QHC.IsNull("idassetunload"), QHC.BitSet("flag", 0));
                    DataTable DaCollegare = Meta.Conn.RUN_SELECT("assetpieceview",
                                            "*", null, filterpiece, null, true);

                    string keyfilter = QueryCreator.WHERE_COLNAME_CLAUSE(CurrRow,
                                         new string[] { "idasset", "idpiece" }, DataRowVersion.Default, false);
                    //verifico se presente nel dataSet del form 
                    DataRow[] Found = DS.assetpieceview.Select(keyfilter);
                    if (Found.Length > 0) {
                        //Se presente viene ricollegato
                        if (Found[0]["idassetunload"] == DBNull.Value) {
                            Found[0]["idassetunload"] = CurrRow["idassetunload"];
                            //messaggiovisualizzato = true;
                        }
                    }
                    else { //se non presente, viene aggiunto
                        DataRow NewR = DS.assetpieceview.NewRow();
                        foreach (DataColumn C in CurrRow.Table.Columns) {
                            NewR[C.ColumnName] = CurrRow[C.ColumnName];
                        }
                        DS.assetpieceview.Rows.Add(NewR);
                        //Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
                        NewR.AcceptChanges();
                        NewR["idassetunload"] = CurrRow["idassetunload"];
                        //messaggiovisualizzato = true;
                    }
                    foreach (DataRow Riga in DS.assetpieceview.Select(filterpiece)) {
                        Riga.BeginEdit();
                        //Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
                        Riga["idassetunload"] = CurrRow["idassetunload"];
                        Riga.EndEdit();
                        //messaggiovisualizzato = true;
                    }

                    //Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
                }
                //if (messaggiovisualizzato) {
                //    show("Insieme al cespiti selezionati saranno scaricati anche i relativi AUMENTI DI VALORE",
                //    "Avviso");
                //    messaggiovisualizzato = false;
                //}
            }
            Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
            Meta.FreshForm();
        }
        private bool AccettaDocumento(/*string link*/) {
            bool success = true;
            int rowsBene = DS.assetpieceview.Rows.Count;
            if (rowsBene == 0) {
                success = false;
                return success;
            }
            //			switch(link) {
            //				case "1":
            //					if (flag_bene) CollegaTipoDoc(dgrCaricoBene, rowsBene, "numscaricobene");
            //					break;
            //				case "2":
            //					if (flag_parte) CollegaTipoDoc(dgrCaricoParte, rowsParte, "numscaricoparte");
            //					break;
            //				default:
            if (flag_bene||flag_parte) CollegaTipoDoc(dgrCaricoBene, rowsBene, "idasset, idpiece");
            //					break;
            //			}

            MetaData.DoMainCommand(this, "mainsave");
            if (!DS.HasChanges() && (TempTable != null)) {
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
                success = true;
            }
            else {
                success = false;
                return success;
            }
            AbilitaBottoni(false);
            //btnGeneraTutto.Enabled=(TempTable!=null && TempTable.Rows.Count>0);
            return success;
        }
        private void btnInizia_Click(object sender, System.EventArgs e) {
            if (CodiceTipoBuono == null || CodiceTipoBuono.ToString() == "") {
                show("Selezionare il tipo buono di scarico", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Vengono chiesti se la config. lo prevede.
            //if (flagcreddeb && txtCredDeb.Text == "") {
            //    show("Selezionare il Cessionario", "Attenzione",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (flagcausale && cboCausale.SelectedIndex <= 0) {
                show("Selezionare la Causale", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Cursor = Cursors.WaitCursor;
            txtDataContabile.ReadOnly = false;
            txtDataRatifica.ReadOnly = false;
            grpIncludi.Enabled = false;
            //btnInizia.Enabled=false;
            if (Warning) {
                Cursor = null;
                return;
            }
            FillTempTable();
            CollegaRigheADocumento(false);
            Cursor = null;
        }
        private void btnSuccessivo_Click(object sender, System.EventArgs e) {
            abilitaDisabilitaGenerazione(true);
            VaiAvanti();

            CollegaRigheADocumento(false);
            if ((TempTable == null) || ((TempTable != null) && (TempTable.Rows.Count == 0))) 
                Meta.DontWarnOnInsertCancel = true;
        }
        private void abilitaDisabilitaGenerazione(bool enabled) {
            grpScaricoBene.Enabled = enabled;
            btnSi.Enabled = enabled;
            btnGeneraTutto.Enabled = enabled;
            btnNo.Enabled = enabled;
        }
        private void btnAddBene_Click(object sender, System.EventArgs e) {
            //AccettaDocumento("1");
            selezionaTutteLeRigheDiUnGrid(dgrCaricoBene);
            AbilitaBottoniCreaBuono(true);
        }
        private void selezionaTutteLeRigheDiUnGrid(DataGrid grid) {
            string dataMember = grid.DataMember;
            CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
            if ((cm == null) || !(cm.List is DataView)) return;
            for (int i = 0; i < cm.Count; i++) {
                grid.Select(i);
            }
        }
        private void VaiAvanti() {
            if ((TempTable != null) && (TempTable.Rows.Count > 0) && (DS.HasChanges())) {
                if (DS.assetpieceview.Rows.Count > 0) DS.assetpieceview.AcceptChanges();
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
            }
        }
        //private void ControlloRatifica() {
        //    if (Meta.IsEmpty) return;
        //    DataRow[] rows = DS.assetunloadincome.Select(null, null, DataViewRowState.CurrentRows);
        //    ParseDate(txtDataRatifica);
        //    string dataratifica = txtDataRatifica.Text;
        //    if (dataratifica == "" && rows.Length == 0) {
        //        AbilitaRatifica(true);
        //    }
        //    else {
        //        if (dataratifica != "") {
        //            AbilitaRatificaCampo(true);
        //            AbilitaRatificaGrid(false);
        //        }
        //        if (rows.Length > 0) {
        //            AbilitaRatificaCampo(false);
        //            AbilitaRatificaGrid(true);
        //        }
        //    }
        //}
        private string GetMovimentoFilter() {
            object codicecreddeb = DS.assetunload.Rows[0]["idreg"];
            object eserccorrente = Conn.GetSys("esercizio");

            string MyFilter = QHS.CmpEq("nphase", codicefase);
            if (txtEsercizio.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter,QHS.CmpEq( "ayear", eserccorrente));
                //MyFilter += "AND (esercizio=" + QueryCreator.quotedstrvalue(txtEsercizio.Text.Trim(), true) + ")";

            if (flagcreddeb ) {
                MyFilter= QHS.AppAnd(MyFilter,QHS.CmpEq("idreg",codicecreddeb));
            }

            if (DS.assetunloadincome.Rows.Count > 0) {
                foreach (DataRow R in DS.assetunloadincome.Rows) {
                    if (R.RowState == DataRowState.Deleted) continue;
                    MyFilter += " AND (idinc <> " + QueryCreator.quotedstrvalue(R["idinc"], true) + ")";
                }
            }
            return MyFilter;
        }
        private void ImpostaValoriDaEntrata(DataTable T, DataRow R) {
            MetaData.SetDefault(T, "idinc", R["idinc"]);
            MetaData.SetDefault(T, "!ymov", R["ymov"]);
            MetaData.SetDefault(T, "!nmov", R["nmov"]);
            MetaData.SetDefault(T, "!incomedescription", R["description"]);
            MetaData.SetDefault(T, "!incomedoc", R["doc"]);
            MetaData.SetDefault(T, "!amount", R["amount"]);
        }
        private void btnCollegaMov_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Mentrataview.FilterLocked = true;
            Mentrataview.DS = DS;
            DataRow R = Mentrataview.SelectOne("reversaleautomatica", GetMovimentoFilter(), null, null);
            if (R == null) return;
            MetaData M = MetaData.GetMetaData(this, "assetunloadincome");
            ImpostaValoriDaEntrata(DS.assetunloadincome, R);
            ImpostaDataRatifica(R);
            M.SetDefaults(DS.assetunloadincome);
            M.Get_New_Row(DS.assetunload.Rows[0], DS.assetunloadincome);
            //ControlloRatifica();
        }
        private void btnScollegaMov_Click(object sender, System.EventArgs e) {
            DataRow R;
            DataTable T;
            if (!Meta.myHelpForm.GetCurrentRow(gridRatifica, out T, out R)) return;
            if (R == null) return;
            R.Delete();
            //ControlloRatifica();
        }
        private void ImpostaDataRatifica(DataRow R) {
            Meta.GetFormData(true);
            // Calcola la data di competenza per l'incasso selezionato
            object compDate = R["competencydate"];
            if (compDate == DBNull.Value) return;
            string tag = HelpForm.GetStandardTag(txtDataRatifica.Tag);
            if (DS.assetunload.Rows[0]["ratificationdate"] == DBNull.Value) {
                DS.assetunload.Rows[0]["ratificationdate"] = compDate;
                txtDataRatifica.Text = HelpForm.StringValue(compDate, tag);
            }
            else {
                if (!(DS.assetunload.Rows[0]["ratificationdate"].Equals(compDate))) {
                    if (show("Sostituire la data ratifica con la data di competenza " + HelpForm.StringValue(compDate, tag) +
                                        " del movimento selezionato?",
                    "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        DS.assetunload.Rows[0]["ratificationdate"] = compDate;
                        txtDataRatifica.Text = HelpForm.StringValue(compDate, tag);
                    }
                }
            }
            MetaData.FreshForm(this, false);
        }
        private void btnSi_Click(object sender, System.EventArgs e) {
            bool res = AccettaDocumento(/*"3"*/);
            if (res) AbilitaBottoniOperazioni(true);
        }
        private void btnNo_Click(object sender, System.EventArgs e) {
            abilitaDisabilitaGenerazione(false);
            deselezionaTutteLeRigheDiUnGrid(dgrCaricoBene);
            AbilitaBottoniOperazioni(true);
        }
        private void deselezionaTutteLeRigheDiUnGrid(DataGrid grid) {
            string dataMember = grid.DataMember;
            CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
            if ((cm == null) || !(cm.List is DataView)) return;
            for (int i = 0; i < cm.Count; i++) {
                grid.UnSelect(i);
            }
        }
        private void btnDeselBene_Click(object sender, System.EventArgs e) {
            deselezionaTutteLeRigheDiUnGrid(dgrCaricoBene);
             AbilitaBottoniCreaBuono(false);
        }

        private void AbilitaBottoniCreaBuono(bool enable) {
            btnSi.Enabled = enable;
            btnGeneraTutto.Enabled = enable;
        }

        private int contaRigheSelezionate(DataGrid grid) {
            string dataMember = grid.DataMember;
            int contarighe = 0;
            CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
            if ((cm == null) || !(cm.List is DataView)) return contarighe;
            for (int i = 0; i < cm.Count; i++) {
                if (grid.IsSelected(i)) {
                    contarighe++;
                }
            }
            return contarighe;
        }
        private void dgrCaricoBene_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int i = contaRigheSelezionate(dgrCaricoBene);
			if (i > 0) AbilitaBottoniCreaBuono(true);
		}

        private void txtDataRatifica_Leave(object sender, EventArgs e) {
            ParseDate(txtDataRatifica);
            if (m_DataRatifica != DBNull.Value) {
                DS.assetunload.Rows[0]["ratificationdate"] = m_DataRatifica;
            }
        }
    }
    
}
