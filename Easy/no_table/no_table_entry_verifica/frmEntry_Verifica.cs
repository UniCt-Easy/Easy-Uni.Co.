
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
using ep_functions;
using metadatalibrary;
using export_default;
using funzioni_configurazione;
//ExportForm
using metaeasylibrary;
using meta_export;
using mainform;

namespace no_table_entry_verifica {
    public partial class frmEntry_Verifica : MetaDataForm {
        public frmEntry_Verifica() {
            InitializeComponent();
        }

        private MetaData Meta;
        DataAccess Conn;
        private QueryHelper QHS;
        private CQueryHelper QHC;
        private int esercizio;
        private bool UsaImpegniDiBudget;


        private object idaccFornitore = DBNull.Value;
        private object idaccCliente = DBNull.Value;
        private object codeaccFornitore = DBNull.Value;
        private object codeaccCliente = DBNull.Value;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            esercizio = Conn.GetEsercizio();
            DataTable config = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", esercizio), null, null, false);
            DataRow _rConfig = config.Rows[0];
            string flagEpExp = _rConfig["flagepexp"].ToString().ToUpper();

            UsaImpegniDiBudget = (flagEpExp == "S");

            EP_functions ep = new EP_functions(Meta.Dispatcher);
            idaccFornitore = ep.GetAccountForSupplier();
            idaccCliente = ep.GetAccountForCustomer();

            codeaccFornitore = Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccFornitore), "codeacc");
            codeaccCliente = Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccCliente), "codeacc");

            bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
            if (!isAdmin) {
                tabMovBudget.TabPages.Remove(tabPageMovBudget);
                tabMovBudget.TabPages.Remove(tabMovBudget2);
                tabMovBudget.TabPages.Remove(tabScrittureErrate);
                tabMovBudget.TabPages.Remove(tabScrittureErrate2);
            }

            int mainCounter = 0;
            foreach (TabPage t in tabMovBudget.TabPages) {
                mainCounter++;
                int nButton = 0;
                SortedList<int,Button> btn = new SortedList<int, Button>();
                foreach (Control c in t.Controls) {
                    Button b  = c as Button;
                    if (b==null)continue;
                    if (b.Text.Trim().ToLower()!="verifica")continue;
                    btn.Add(b.Location.Y*1000+ b.Location.X,b);
                }

                foreach (Button bb in btn.Values) {
                    nButton++;
                    bb.Text = $@"{mainCounter}.{nButton} Verifica";
                }

            }
        }



        #region rigenerazione scritture

        private Dictionary<string, EP_Manager> allEpm = new Dictionary<string, EP_Manager>();
        private Dictionary<string, MetaData> allMeta = new Dictionary<string, MetaData>();

        void rigeneraScrittura(DataRow curr, string tableName, bool silent=false) {
            MetaData m;
            EP_Manager ep;
            try {
                if (allEpm.ContainsKey(tableName)) {
                    m = allMeta[tableName];
                    m.DS = curr.Table.DataSet;
                    ep = allEpm[tableName];
                    ep.update(curr.Table.DataSet);
                }
                else {
                    m = Meta.Dispatcher.Get(tableName);
                    m.DS = curr.Table.DataSet;
                    allMeta[tableName] = m;
                    ep = new EP_Manager(m, null, null, null, null, null, null, null, null, tableName);
                    allEpm[tableName] = ep;
                }
                ep.disableIntegratedPosting();
                ep.setForcedCurrentRow(curr);
                ep.etichetteAbilitate = false;
                ep.autoIgnore = true;
                ep.silent = silent;
                ep.beforePost();
                ep.afterPost(true);
            }
            catch (Exception e) {
                string msg =
                        $"Errore generando la scrittura per {txtCurrent.Text}, tabella {curr.Table.TableName} nella riga di chiave {QHC.CmpKey(curr)}";
                Meta.LogError(msg, e);
                QueryCreator.ShowException(msg, e);
            }
            Application.DoEvents();

        }

        void rigeneraScritturaCSA(DataRow curr, string kind) {


            EP_Manager epm = new EP_Manager(Meta, null, null, null, null,
                null, null,
                null, null, "csa_import");
            if (kind == "debito") epm.tipoScrittura = "debito";
            epm.disableIntegratedPosting();
            epm.setForcedCurrentRow(curr);
            epm.silent = true;
            epm.etichetteAbilitate = false;
            


            //if (epm.impegniAbilitati(curr))
            //    epm.generaImpegniAccertamenti(curr, 0, out scrittureGenerate, out impegniGenerati);
            //else
            epm.generaScritture(curr, null);

        }

        DataTable getTable(string tableName, string filter, string orderBy) {
            DataTable t = Conn.CreateTableByName(tableName, "*");
            if (t.Columns.Contains("txt")) {
                t.Columns.Remove("txt");
            }
            if (t.Columns.Contains("rtf")) {
                t.Columns.Remove("rtf");
            }

            //int i = 0;            
            //while (i < t.Columns.Count) {
            //    string field = t.Columns[i].ColumnName;
            //    bool isKey = false;
            //    foreach (DataColumn cc in t.PrimaryKey) {
            //        if (cc.ColumnName == field) {
            //            isKey = true;
            //            i += 1;
            //            break;
            //        }
            //    }
            //    if (isKey) continue;
            //    t.Columns.Remove(field);
            //}
            Conn.RUN_SELECT_INTO_TABLE(t, orderBy, filter, null, false);
            return t;
        }

        private void btnGeneraTrasmPagamento_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("ypaymenttransmission", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("paymenttransmission", "*", "npaymenttransmission", filter, null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("kpaymenttransmission"))) return;
                t.TableName = "paymenttransmission";
            }

            btnGeneraTrasmPagamento.Visible = false;

            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("paymenttransmDS");
                DataTable T = Conn.RUN_SELECT("paymenttransmission", "*", null, QHS.CmpEq("kpaymenttransmission",r["kpaymenttransmission"]), null, false);
                if (T.Rows.Count == 0) continue;
                D.Tables.Add(T);
                txtCurrent.Text = "Elenco di trasmissione n." + r["npaymenttransmission"];
                rigeneraScrittura(T.Rows[0], "paymenttransmission");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraTrasmPagamento.Visible = true;
        }

        private void btnGeneraTrasmIncasso_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yproceedstransmission", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("proceedstransmission", "*", "nproceedstransmission", filter, null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("kproceedstransmission"))) return;
                t.TableName = "proceedstransmission";
            }
            btnGeneraTrasmIncasso.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("proceedstransmissionDS");
                DataTable T = Conn.RUN_SELECT("proceedstransmission", "*", null, QHS.CmpEq("kproceedstransmission",r["kproceedstransmission"]), null, false);
                if (T.Rows.Count == 0) continue;
                D.Tables.Add(T);
                txtCurrent.Text = "Elenco di trasmissione n." + r["nproceedstransmission"];
                rigeneraScrittura(T.Rows[0], "proceedstransmission");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraTrasmIncasso.Visible = true;
        }

        private void generaCPassivi_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filterCurr = QHS.CmpEq("yman", esercizio);

            string filterPrev = QHS.CmpLt("yman", esercizio);

            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("mandate", "*", "adate", filterCurr, null, false);

                string filterCPCurr = QHS.AppAnd(filterCurr,
                QHS.AppAnd(QHS.AppOr(QHS.IsNull("start"),
                QHS.AppAnd(QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31")))));

                DataTable T1 = Conn.RUN_SELECT("mandatedetail", "*", null, filterCPCurr, null, false);

                string filterCPPrev = QHS.AppAnd(filterPrev,
                QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31"));
                DataTable T2 = Conn.RUN_SELECT("mandatedetail", "*", null, filterCPPrev, null, false);

                if ((T2 != null) && T2.Rows.Count > 0)
                    T1.Merge(T2);
                if (T1.Rows.Count == 0) return;

                DataTable tPrev = new DataTable();
                foreach (DataRow r in T2.Select()) {
                    string filterKey = QHS.MCmp(r, "idmankind", "yman", "nman");
                    DataRow[] MandateRow = t.Select(filterKey);
                    if (MandateRow.Length > 0) continue;
                    DataTable tMandate = Conn.RUN_SELECT("mandate", "*", null, filterKey, null, false);
                    if (tMandate != null && tMandate.Rows.Count > 0)
                        t.Merge(tMandate);
                }

            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idmankind")) || !(t.Columns.Contains("yman")) ||
                    !(t.Columns.Contains("nman"))) return;
                t.TableName = "mandate";
            }

            generaCPassivi.Visible = false;
            int n = t.Select(filterCurr).Length;
            progBar.Maximum = n;
            progBar.Value = 0;
            // Elaborazione riga per riga
            foreach (DataRow r in t.Select(filterCurr)) {
                txtCurrent.Text = "Contratto passivo tipo " + r["idmankind"] + " n°" + r["nman"] + '/' + r["yman"];
                progBar.Increment(1);
                progBar.Update();

                DataSet D = new DataSet("mandateDS");
                DataTable T = Conn.RUN_SELECT("mandate", "*", null, QHS.MCmp(r, "idmankind", "yman", "nman"), null, false);
                if (T.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }

                D.Tables.Add(T);
                DataRow rv = T.Rows[0];
                string adate = rv["adate"].ToString();
                DateTime.TryParse(adate, out DateTime result);
                // filtro per selezionare i dettagli contratti passivi dell'esercizio corrente
                // Se la data contabile del cp è dell'anno corrente prendo tutti i dettagli con start null o con start nell'anno corrente
                // Altrimenti prendo i dettagli con start valorizzato con l'anno corrente
                string filterCP = "";
                // select * from mandatedetail
                // where idmankind = r["idmankind"] and yman = r["yman"] and nman = r["yman"]
                // and (start is null or (start >= esercizio/01/01 and start <= esercizio/12/31))
                // and stop is null
                filterCP = QHS.AppAnd(QHS.MCmp(r, "idmankind", "yman", "nman"),
                QHS.AppAnd(QHS.AppOr(QHS.IsNull("start"),
                QHS.AppAnd(QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31")))));

                DataTable TDett = Conn.RUN_SELECT("mandatedetail", "*", null, filterCP, null, false);
                if (TDett.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }
                D.Tables.Add(TDett);

                rigeneraScrittura(T.Rows[0], "mandate");
            }


            int n1 = t.Select(filterPrev).Length;
            progBar.Maximum = n1;
            progBar.Value = 0;
            foreach (DataRow r in t.Select(filterPrev)) {

                txtCurrent.Text = "Contratto passivo anni prec. tipo " + r["idmankind"] + " n°" + r["nman"] + '/' + r["yman"];
                progBar.Increment(1);
                progBar.Update();

                DataSet D = new DataSet("mandateDS");
                DataTable T = Conn.RUN_SELECT("mandate", "*", null, QHS.MCmp(r, "idmankind", "yman", "nman"), null, false);
                if (T.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }

                D.Tables.Add(T);
                DataRow rv = T.Rows[0];
                string adate = rv["adate"].ToString();
                DateTime.TryParse(adate, out DateTime result);
                // filtro per selezionare i dettagli contratti passivi dell'esercizio corrente
                // Se la data contabile del cp è dell'anno corrente prendo tutti i dettagli con start null o con start nell'anno corrente
                // Altrimenti prendo i dettagli con start valorizzato con l'anno corrente
                string filterCP = "";

                // select * from mandatedetail
                // where idmankind = r["idmankind"] and yman = r["yman"] and nman = r["nman"]
                // and start >= esercizio/01/01 and start <= esercizio/12/31
                // and stop is null
                filterCP = QHS.MCmp(r, "idmankind", "yman", "nman") ;


                DataTable TDett = Conn.RUN_SELECT("mandatedetail", "*", null, filterCP, null, false);
                if (TDett.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }
                D.Tables.Add(TDett);

                rigeneraScrittura(T.Rows[0], "mandate");

            }

            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            generaCPassivi.Visible = true;
        }

        void rigeneraContrattoAttivo(DataRow r) {
            DataSet D = new DataSet("estimateDS");
            DataTable T = Conn.RUN_SELECT("estimate", "*", null, QHS.MCmp(r, "idestimkind", "yestim", "nestim"), null,
                false);
            if (T.Rows.Count == 0) return;
            DataRow rv = T.Rows[0];
            D.Tables.Add(T);
            DataTable T1 = Conn.RUN_SELECT("estimatedetail", "*", null, QHS.MCmp(r, "idestimkind", "yestim", "nestim"),
                null, false);
            if (T1.Rows.Count == 0) return;
            D.Tables.Add(T1);
            txtCurrent.Text = "Contratto attivo tipo " + r["idestimkind"] + ") n." + r["nestim"] + '/'+ r["estim"];
            rigeneraScrittura(T.Rows[0], "estimate");
            progBar.Increment(1);
            progBar.Update();
        }

        void rigeneraContrattoPassivo(DataRow r) {
            DataSet D = new DataSet("mandateDS");
            DataTable T = Conn.RUN_SELECT("mandate", "*", null, QHS.MCmp(r, "idmankind", "yman", "nman"), null,
                false);
            if (T.Rows.Count == 0) return;
            DataRow rv = T.Rows[0];
            D.Tables.Add(T);
            DataTable T1 = Conn.RUN_SELECT("mandatedetail", "*", null, QHS.MCmp(r, "idmankind", "yman", "nman"),
                null, false);
            if (T1.Rows.Count == 0) return;
            D.Tables.Add(T1);
            txtCurrent.Text = "Contratto passivo tipo " + r["idmankind"] + ") n." + r["nman"];
            rigeneraScrittura(T.Rows[0], "mandate");
            progBar.Increment(1);
            progBar.Update();
        }

        private void generaCAttivi_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
         
            DataTable t = new DataTable();
            generaCAttivi.Visible = false;
  


            string filterCurr = QHS.CmpEq("yestim", esercizio);

			//QHS.AppAnd(QHS.CmpEq("yestim", esercizio),
			//QHS.CmpEq("idestimkind", "CA_ESSE3_Competenza"),
			//QHS.CmpNe("nestim", 32));

			string filterPrev = QHS.CmpLt("yestim", esercizio);

            if (cmd.Trim() == "") {
           
                t = Conn.RUN_SELECT("estimate", "*", "adate", filterCurr, null, false);
               
                string filterCACurr = QHS.AppAnd(filterCurr,
                QHS.AppAnd(QHS.AppOr(QHS.IsNull("start"),
                QHS.AppAnd(QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31")))));

                DataTable T1 = Conn.RUN_SELECT("estimatedetail", "*", null, filterCACurr, null, false);

                string filterCAPrev = QHS.AppAnd(filterPrev,
                QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31"));
                DataTable T2 = Conn.RUN_SELECT("estimatedetail", "*", null, filterCAPrev, null, false);
                if ((T2 != null) && T2.Rows.Count > 0)  
                    T1.Merge(T2);
                    if (T1.Rows.Count == 0) return ;

                DataTable tPrev = new DataTable();
                foreach (DataRow r in T2.Select()) {
                    string filterKey = QHS.MCmp(r, "idestimkind", "yestim", "nestim");
                    DataRow[] EstimateRow = t.Select(filterKey);
                    if (EstimateRow.Length > 0) continue;
                    DataTable tEstimate = Conn.RUN_SELECT("estimate", "*", null, filterKey, null, false);
                    if (tEstimate != null && tEstimate.Rows.Count > 0)
                    t.Merge(tEstimate);
                }
            }

            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idestimkind")) || !(t.Columns.Contains("yestim")) ||
                    !(t.Columns.Contains("nestim"))) return;
                t.TableName = "estimate";
            }
            int n = t.Select(filterCurr).Length;
            progBar.Maximum = n;
            progBar.Value = 0;

            // Elaborazione riga per riga
            foreach (DataRow r in t.Select(filterCurr)) {
				txtCurrent.Text = "Contratto attivo tipo " + r["idestimkind"] + " n°" + r["nestim"] + '/' + r["yestim"];
				progBar.Increment(1);
				progBar.Update();

				DataSet D = new DataSet("estimateDS");
				DataTable T = Conn.RUN_SELECT("estimate", "*", null, QHS.MCmp(r, "idestimkind", "yestim", "nestim"), null, false);
				if (T.Rows.Count == 0) {
					txtCurrent.Text = "";
					continue;
				}

				D.Tables.Add(T);
				DataRow rv = T.Rows[0];
				string adate = rv["adate"].ToString();
				DateTime.TryParse(adate, out DateTime result);
				// filtro per selezionare i dettagli contratti passivi dell'esercizio corrente
				// Se la data contabile del cp è dell'anno corrente prendo tutti i dettagli con start null o con start nell'anno corrente
				// Altrimenti prendo i dettagli con start valorizzato con l'anno corrente
				string filterCA = "";
				// select * from estimatedetail
				// where idestimkind = r["idestimkind"] and yestim = r["yestim"] and nestim = r["nestim"]
				// and (start is null or (start >= esercizio/01/01 and start <= esercizio/12/31))
				// and stop is null
				filterCA = QHS.AppAnd(QHS.MCmp(r, "idestimkind", "yestim", "nestim"),
				QHS.AppAnd(QHS.AppOr(QHS.IsNull("start"),
				QHS.AppAnd(QHS.CmpGe("start", $"{esercizio}/01/01"), QHS.CmpLe("start", $"{esercizio}/12/31")))));

				DataTable TDett = Conn.RUN_SELECT("estimatedetail", "*", null, filterCA, null, false);
				if (TDett.Rows.Count == 0) {
					txtCurrent.Text = "";
					continue;
				}
				D.Tables.Add(TDett);

				rigeneraScrittura(T.Rows[0], "estimate");
			}

            int n1 = t.Select(filterPrev).Length;
            progBar.Maximum = n1;
            progBar.Value = 0;
            foreach (DataRow r in t.Select(filterPrev)) {
           
                txtCurrent.Text = "Contratto attivo anni prec. tipo " + r["idestimkind"] + " n°" + r["nestim"] + '/' + r["yestim"];
                progBar.Increment(1);
                progBar.Update();

                DataSet D = new DataSet("estimateDS");
                DataTable T = Conn.RUN_SELECT("estimate", "*", null, QHS.MCmp(r, "idestimkind", "yestim", "nestim"), null, false);
                if (T.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }

                D.Tables.Add(T);
                DataRow rv = T.Rows[0];
                string adate = rv["adate"].ToString();
                DateTime.TryParse(adate, out DateTime result);
                // filtro per selezionare i dettagli contratti passivi dell'esercizio corrente
                // Se la data contabile del cp è dell'anno corrente prendo tutti i dettagli con start null o con start nell'anno corrente
                // Altrimenti prendo i dettagli con start valorizzato con l'anno corrente
                string filterCA = "";
      
                // select * from estimatedetail
                // where idestimkind = r["idestimkind"] and yestim = r["yestim"] and nestim = r["nestim"]
                // and start >= esercizio/01/01 and start <= esercizio/12/31
                // and stop is null
                filterCA = QHS.MCmp(r, "idestimkind", "yestim", "nestim");
                 

                DataTable TDett = Conn.RUN_SELECT("estimatedetail", "*", null, filterCA, null, false);
                if (TDett.Rows.Count == 0) {
                    txtCurrent.Text = "";
                    continue;
                }
                D.Tables.Add(TDett);

                rigeneraScrittura(T.Rows[0], "estimate");

            }

            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            generaCAttivi.Visible = true;
        }

    void rigeneraFattura(DataRow r, DataTable invkind) {
            DataSet D = new DataSet("invoiceDS");
            DataTable T = getTable("invoice", QHS.MCmp(r, "idinvkind", "yinv", "ninv"), null);
            if (T.Rows.Count == 0) return;
            D.Tables.Add(invkind);
            D.Tables.Add(T);
            var t1 = getTable("invoicedetail", QHS.MCmp(r, "idinvkind", "yinv", "ninv"), null);
            D.Tables.Add(t1);
            string filterrelated = QHS.AppAnd(QHS.CmpEq("idrelated", EP_functions.GetIdForDocument(T.Rows[0])),
                QHS.CmpEq("yentry", esercizio), QHS.FieldIn("identrykind", new object[] {1, 2, 8}));
            DataTable TEntry = Conn.RUN_SELECT("entry", "*", null, filterrelated, null, true);
            bool avviso = false;
            foreach (DataRow rE in TEntry.Rows) {
                if (Conn.RUN_SELECT_COUNT("entrydetailaccrual", QHS.CmpKey(rE), false) > 0) {
                    avviso = true;
                    break;
                }
            }

            if (avviso) {
                var res= show("Ci sono ratei associati alle scritture che saranno scollegati. Sarà " +
                                "necessario ricollegarli a mano.", "Avviso", MessageBoxButtons.OKCancel);
                if (res == DialogResult.Cancel) {
                    D.Tables.Remove(invkind);
                    progBar.Increment(1);
                    progBar.Update();
                    return;
                }
            }
            txtCurrent.Text = $"Fattura tipo {r["codeinvkind"]}({r["invoicekind"]}) n.{r["ninv"]}";
            rigeneraScrittura(T.Rows[0], "invoice",true);
            D.Tables.Remove(invkind);
            progBar.Increment(1);
            progBar.Update();
        }

        private void generaFattAcquisto_Click(object sender, EventArgs e) {

            string cmd = txtComando.Text;
            string filter = QHS.AppAnd(QHS.CmpEq("yinv", esercizio), QHS.CmpEq("flagbuysell", "A"));
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("invoiceview", "idinvkind,yinv,ninv,codeinvkind,invoicekind,flagbuysell", "adate", filter, null,
                    false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idinvkind")) || !(t.Columns.Contains("yinv")) || !(t.Columns.Contains("ninv"))
                    || !(t.Columns.Contains("codeinvkind")) || !(t.Columns.Contains("invoicekind")) ||
                    !(t.Columns.Contains("flagbuysell"))) return;
                t.TableName = "invoiceview";
            }

            generaFattAcquisto.Visible = false;

            DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Select(filter)) {              
                rigeneraFattura(r, invkind);
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            generaFattAcquisto.Visible = true;
        }

        private void generaFVendita_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.AppAnd(QHS.CmpEq("yinv", esercizio), QHS.CmpEq("flagbuysell", "V"));
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("invoiceview", "idinvkind,yinv,ninv,codeinvkind,invoicekind,flagbuysell", "adate", filter, null,
                    false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idinvkind")) || !(t.Columns.Contains("yinv")) || !(t.Columns.Contains("ninv"))
                    || !(t.Columns.Contains("codeinvkind")) || !(t.Columns.Contains("invoicekind")) ||
                    !(t.Columns.Contains("flagbuysell"))) return;
                t.TableName = "invoiceview";
            }

            generaFVendita.Visible = false;
            DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Select(filter)) {
                rigeneraFattura(r, invkind);
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            generaFVendita.Visible = true;
        }

        private void btnGeneraOccasionale_Click(object sender, EventArgs e) {

            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("year(datecompleted)", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = getTable("casualcontract", filter, "datecompleted");
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("ycon")) || !(t.Columns.Contains("ncon")) ||
                    !(t.Columns.Contains("datecompleted"))) return;
                t.TableName = "casualcontract";
                t.PrimaryKey = new DataColumn[] { t.Columns["ycon"], t.Columns["ncon"] };
            }
            btnGeneraOccasionale.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Select()) {
                DataTable T = Conn.RUN_SELECT("casualcontract", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;
                DataSet D = new DataSet("casualcontractDS");
                D.Tables.Add(T);
                txtCurrent.Text = "Contratto occasionale n. " + T.Rows[0]["ncon"] + " del " + T.Rows[0]["ycon"];
                rigeneraScrittura(T.Rows[0], "casualcontract");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraOccasionale.Visible = true;
        }


        private void btnGeneraMissioni_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("year(datecompleted)", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = getTable("itineration", filter, "datecompleted");
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("yitineration")) || !(t.Columns.Contains("iditineration")) ||
                    !(t.Columns.Contains("nitineration")) || !(t.Columns.Contains("datecompleted"))) return;
                t.TableName = "itineration";
                t.PrimaryKey = new DataColumn[] { t.Columns["yitineration"], t.Columns["nitineration"] };
            }

            btnGeneraMissioni.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Select()) {
                DataTable T = Conn.RUN_SELECT("itineration", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;
                DataSet D = new DataSet("itinerationDS");
                D.Tables.Add(T);

                txtCurrent.Text = $@"Missione n. {T.Rows[0]["nitineration"]} del {T.Rows[0]["yitineration"]}";
                rigeneraScrittura(T.Rows[0], "itineration");

                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraMissioni.Visible = true;
        }

        private void btnGeneraDipendente_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("ycon", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("wageaddition", "*", "ncon", filter, null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("ycon")) || !(t.Columns.Contains("ncon"))) return;
                t.TableName = "wageaddition";
                t.PrimaryKey = new DataColumn[] { t.Columns["ycon"], t.Columns["ncon"] };
            }
            btnGeneraDipendente.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;

            foreach (DataRow r in t.Rows) {
                DataTable T = Conn.RUN_SELECT("wageaddition", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;
                DataSet D = new DataSet("wageadditionDS");
                D.Tables.Add(T);
                txtCurrent.Text = "Compenso dipendenti n. " + T.Rows[0]["ncon"] + " del " + T.Rows[0]["ycon"];
                rigeneraScrittura(T.Rows[0], "wageaddition");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraDipendente.Visible = true;
        }

        #endregion

        #region verifiche

        private void btnInvoice1_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as \'Tipo Doc.\', I.yinv as \'Eserc.doc\',I.ninv as \'n.doc.\', \r\n\t " +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto fatt.\', A2.codeacc as \'conto mov.\' \r\n\t " +
                    " from invoiceview I \r\n\t " +
                    //" left outer join account A4 on A4.idacc = CFG.idacc_supplier " +
                    " join invoicedetail ID on I.idinvkind=ID.idinvkind and I.yinv=ID.yinv and I.ninv=ID.ninv \r\n\t " +
                    " join expense e on e.idexp=ID.idexp_taxable \r\n\t " +
                    " left outer join accmotivedetail AD on AD.idaccmotive = isnull(I.idaccmotivedebit_crg,I.idaccmotivedebit) and AD.ayear=E.ymov \r\n\t " +
                    " left outer join account A1 on A1.idacc= AD.idacc \r\n\t " +
                    " join expenselast el on e.idexp=el.idexp \r\n\t " +
                    " join registry r on r.idreg= e.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                    " left outer join account A2 on A2.idacc= isnull(EL.idaccdebit,rAD.idacc) " +
                    " where e.ymov = " + esercizio + " and I.flagbuysell=\'A\' and isnull(A2.idacc," +
                    QHS.quote(idaccFornitore) + ") <> AD.idacc \r\n\t" +
                    " order by  I.idinvkind, I.yinv,I.ninv \r\n\t ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck1.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        private void btnInvoice2_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as \'Tipo Doc.\', I.yinv as \'Eserc.doc\',I.ninv as \'n.doc.\', \r\n\t\t" +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto fatt.\', A2.codeacc as \'conto mov.\'\r\n\t" +
                    " from invoiceview I \r\n\t" +
                    " join invoicedetail ID on I.idinvkind=ID.idinvkind and I.yinv=ID.yinv and I.ninv=ID.ninv\r\n\t" +
                    " join expense e on e.idexp=ID.idexp_iva\r\n\t" +
                    " left outer join accmotivedetail AD on AD.idaccmotive = isnull(I.idaccmotivedebit_crg,I.idaccmotivedebit) and AD.ayear=E.ymov\r\n\t" +
                    " left outer join account A1 on A1.idacc= AD.idacc\r\n\t" +
                    " join expenselast el on e.idexp=el.idexp\r\n\t" +
                    " join registry r on r.idreg= e.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                    " left outer join account A2 on A2.idacc= isnull(EL.idaccdebit,rAD.idacc) " +
                    " where e.ymov = " + esercizio + " and I.flagbuysell=\'A\' and isnull(A2.idacc," +
                    QHS.quote(idaccFornitore) + ") <> AD.idacc\r\n\t" +
                    " order by  I.idinvkind, I.yinv,I.ninv\r\n\t";

            DataTable t = Conn.SQLRunner(sql,false,0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck2.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }



        private void btnInvoice3_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as \'Tipo Doc.\', I.yinv as \'Eserc.doc\',I.ninv as \'n.doc.\', \r\n\t\t" +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto fatt.\', A2.codeacc as \'conto mov.\'\r\n\t" +
                    " from invoiceview I \r\n\t" +
                    " join invoicedetail ID on I.idinvkind=ID.idinvkind and I.yinv=ID.yinv and I.ninv=ID.ninv\r\n\t" +
                    " join income e on e.idinc=ID.idinc_taxable\r\n\t" +
                    " left outer join accmotivedetail AD on AD.idaccmotive = I.idaccmotivedebit and AD.ayear=E.ymov\r\n\t" +
                    " left outer join account A1 on A1.idacc= AD.idacc\r\n\t" +
                    " join incomelast el on e.idinc=el.idinc\r\n\t" +
                    " join registry r on r.idreg= e.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivecredit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                    " left outer join account A2 on A2.idacc= isnull(EL.idacccredit,rAD.idacc) " +
                    " where e.ymov = " + esercizio + " and I.flagbuysell='V\' and isnull(A2.idacc," +
                    QHS.quote(idaccCliente) + ") <> AD.idacc\r\n\t" +
                    " order by  I.idinvkind, I.yinv,I.ninv\r\n\t";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck3.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice4_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as \'Tipo Doc.\', I.yinv as \'Eserc.doc\',I.ninv as \'n.doc.\', \r\n\t\t" +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto fatt.\', A2.codeacc as \'conto mov.\'\r\n\t" +
                    " from invoiceview I \r\n\t" +
                    " join invoicedetail ID on I.idinvkind=ID.idinvkind and I.yinv=ID.yinv and I.ninv=ID.ninv\r\n\t" +
                    " join income e on e.idinc=ID.idinc_iva\r\n\t" +
                    " left outer join accmotivedetail AD on AD.idaccmotive = I.idaccmotivedebit and AD.ayear=E.ymov\r\n\t" +
                    " left outer join account A1 on A1.idacc= AD.idacc\r\n\t" +
                    " join incomelast el on e.idinc=el.idinc\r\n\t" +
                    " join registry r on r.idreg= e.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivecredit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                    " left outer join account A2 on A2.idacc= isnull(EL.idacccredit,rAD.idacc) " +
                    " where e.ymov = " + esercizio + " and I.flagbuysell=\'V\' and isnull(A2.idacc," +
                    QHS.quote(idaccCliente) + ") <> AD.idacc\r\n\t" +
                    " order by  I.idinvkind, I.yinv,I.ninv\r\n\t";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck4.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnGene1_Click(object sender, EventArgs e) {
            //Conti di Ricavo e Riserva con saldo DARE per singola UPB 
            CheckSaldoUPB(128 + 2048, true, txtGene1.Text);
        }

        private void btnGene2_Click(object sender, EventArgs e) {
            //Conti di Costo,Immobilizzazione con saldo AVERE per singola UPB
            CheckSaldoUPB(64 + 256, false, txtGene2.Text);
        }

        private void btnGene3_Click(object sender, EventArgs e) {
            //Conti di Rateo e Risconto attivo con saldo AVERE per singola UPB 
            CheckSaldoUPB(1 + 4, false, txtGene3.Text);
        }

        private void btnGene4_Click(object sender, EventArgs e) {
            //Conti di Rateo e Risconto passivo con saldo DARE per singola UPB 
            CheckSaldoUPB(2 + 8, true, txtGene4.Text);
        }

        public string MaskSet(string field, int mask) {
            return "((" + field + "&" + mask + ")<>0)";

        }

        void CheckSaldoUPB(int mask, bool dare, string message) {
            string filterDare = dare ? QHS.CmpLt("SUM(ED.amount)", 0) : QHS.CmpGt("SUM(ED.amount)", 0);
            string filterMask = MaskSet("A.flagaccountusage", mask);
            string sql = "select U.codeupb as 'codice upb', U.title as UPB, " +
                         "A.codeacc as 'codice conto', A.title as 'Conto'," +
                         "SUM(ED.amount) as saldo, " +
                         "SUM (case when ED.amount<0 then -ED.amount else 0 end) as dare, " +
                         "SUM (case when ED.amount>0 then ED.amount else 0 end) as avere " +
                         " from entrydetail ED " +
                         " left outer join UPB U on ED.idupb = U.idupb " +
                         " left outer join account A on ED.idacc = A.idacc " +
                         " WHERE " + QHS.CmpEq("ED.yentry", Conn.GetEsercizio()) +
                         " GROUP BY U.codeupb, U.title, A.codeacc, A.title, A.flagaccountusage " +
                         " HAVING " + QHS.AppAnd(filterDare, filterMask);

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, message, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }



        #endregion

        #region compensi

        private void btnCompensi1_Click(object sender, EventArgs e) {
            //Compensi occasionali (causale documento - conto scritture)
            string sql =
                    "select C.ycon as 'anno contratto', C.ncon as 'n.contratto', C.datecompleted as 'data scritture' , " +
                    "ED.idacc, A3.codeacc 'conto debito scrittura contratto', A2.codeacc as 'conto debito contratto',  " +
                    "A3.flagaccountusage ," + " U.codeupb as 'codice upb contratto' " +
                    " from casualcontract C " +
                    "join casualcontractview CV on C.ycon = CV.ycon and C.ncon = CV.ncon " +
                    " left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear = year(C.datecompleted) " +
                    " left outer join account A1 on A1.idacc = AD.idacc " +
                    " left outer join entry E on E.idrelated = CV.idrelated " +
                    " left outer join config CFG on CFG.ayear = year(C.datecompleted) " +
                    " left outer join account A4 on A4.idacc = CFG.idacc_supplier " +
                    " join registry r on r.idreg = c.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear = year(C.datecompleted) " +
                    " left outer join account A2 on A2.idacc = coalesce(AD.idacc, rAD.idacc, A4.idacc) " +
                    " left outer join entrydetail ED on E.yentry = ED.yentry and E.nentry = ED.nentry " +
                    " AND ED.idrelated = CV.idrelated " +
                    " left outer join account A3 on ED.idacc = A3.idacc " +
                    " left outer join upb U on C.idupb = U.idupb" +
                    " where isnull(A2.idacc, \'\') <> isnull(A3.idacc, \'\')  and " +
                    " (isnull(A3.flagaccountusage, 0) & 16 <> 0) and " +
                    QHS.CmpEq("year(C.datecompleted)", Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi1.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi2_Click(object sender, EventArgs e) {
            //Compensi occasionali (causale compenso - conto movimento)
            string sql = "select  C.ycon as 'anno contratto', C.ncon as 'n.contratto', " +
                         "E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto contratto.\', A2.codeacc as \'conto mov.\' ," +
                         "U.codeupb as 'codice upb contratto' " +
                         "from casualcontract C  " +
                         "join expensecasualcontract EC on EC.ycon=C.ycon and EC.ncon = C.ncon " +
                         "join expense e on e.idexp=EC.idexp " +
                         "left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear=E.ymov " +
                         "left outer join account A1 on A1.idacc= AD.idacc " +
                         " left outer join expenselink ELINK on ELINK.idparent = E.idexp " +
                         " join expenselast el on elink.idchild = el.idexp " +
                         "join registry r on r.idreg= e.idreg " +
                         "left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                         "left outer join account A2 on A2.idacc= isnull(EL.idaccdebit,rAD.idacc) " +
                         "left outer join upb U on C.idupb = U.idupb " +
                         "where isnull(A2.codeacc," + QHS.quote(codeaccFornitore) + ") <> A1.codeacc " +
                         " AND " + QHS.CmpEq("year(C.datecompleted)", Conn.GetEsercizio()) +
                         " order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi2.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        #endregion

        private void btnCompensi3_Click(object sender, EventArgs e) {
            //Missioni (causale missione - conto scritture)
            string sql =
                    "select C.yitineration as 'anno missione', C.nitineration as 'n.missione', C.datecompleted as 'data scritture' , " +
                    "ED.idacc, A3.codeacc 'conto debito scrittura missione', A2.codeacc as 'conto debito missione',  " +
                    "A3.flagaccountusage ," + " U.codeupb as 'codice upb missione' " +
                    " from itineration C " +
                    "join itinerationview CV on C.iditineration = CV.iditineration  " +
                    " left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear = year(C.datecompleted) " +
                    " left outer join account A1 on A1.idacc = AD.idacc " +
                    " left outer join entry E on E.idrelated = CV.idrelated " +
                    " left outer join config CFG on CFG.ayear = year(C.datecompleted) " +
                    " left outer join account A4 on A4.idacc = CFG.idacc_supplier " +
                    " join registry r on r.idreg = c.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear = year(C.datecompleted) " +
                    " left outer join account A2 on A2.idacc = coalesce(AD.idacc, rAD.idacc, A4.idacc) " +
                    " left outer join entrydetail ED on E.yentry = ED.yentry and E.nentry = ED.nentry AND ED.idrelated = CV.idrelated " +
                    " left outer join account A3 on ED.idacc = A3.idacc " +
                    " left outer join upb U on C.idupb = U.idupb " +
                    " where isnull(A2.idacc, \'\') <> isnull(A3.idacc, \'\')  and " +
                    " (isnull(A3.flagaccountusage, 0) & 16 <> 0) and " +
                    QHS.CmpEq("year(C.datecompleted)", Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi5.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi4_Click(object sender, EventArgs e) {
            //Missioni (causale missione - conto movimento)
            string sql = "select  C.yitineration as 'anno missione', C.nitineration as 'n.missione', " +
                         "E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto missione.\', A2.codeacc as \'conto mov.\' ," +
                         "U.codeupb as 'codice upb missione' " +
                         "from itineration C  " +
                         "join expenseitineration EC on EC.iditineration=C.iditineration  " +
                         "join expense e on e.idexp=EC.idexp " +
                         "left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear=E.ymov " +
                         "left outer join account A1 on A1.idacc= AD.idacc " +
                         " left outer join expenselink ELINK on ELINK.idparent = E.idexp " +
                         " join expenselast el on elink.idchild = el.idexp " +
                         "join registry r on r.idreg= e.idreg " +
                         "left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                         "left outer join account A2 on A2.idacc= isnull(EL.idaccdebit,rAD.idacc) " +
                         "left outer join upb U on C.idupb = U.idupb " +
                         "where isnull(A2.codeacc," + QHS.quote(codeaccFornitore) + ") <> A1.codeacc " +
                         " AND " + QHS.CmpEq("year(C.datecompleted)", Conn.GetEsercizio()) +
                         " order by  C.yitineration, C.nitineration ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi6.Text, t);
                createForm(f, this);
                f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi5_Click(object sender, EventArgs e) {
            //Compensi a dipendenti(causale compenso - conto scritture)
            string sql =
                    "select C.ycon as 'anno compenso', C.ncon as 'n.compenso', C.adate as 'data scritture' , " +
                    "ED.idacc, A3.codeacc 'conto debito scrittura compenso', A2.codeacc as 'conto debito compenso',  " +
                    "A3.flagaccountusage ," + "U.codeupb as 'codice upb contratto' " +
                    " from wageaddition C " +
                    "join wageadditionview CV on C.ycon = CV.ycon and C.ncon = CV.ncon  " +
                    " left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear = C.ycon " +
                    " left outer join account A1 on A1.idacc = AD.idacc " +
                    " left outer join entry E on E.idrelated = CV.idrelated " +
                    " left outer join config CFG on CFG.ayear = C.ycon " +
                    " left outer join account A4 on A4.idacc = CFG.idacc_supplier " +
                    " join registry r on r.idreg = c.idreg " +
                    " left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear = C.ycon " +
                    " left outer join account A2 on A2.idacc = coalesce(AD.idacc, rAD.idacc, A4.idacc) " +
                    " left outer join entrydetail ED on E.yentry = ED.yentry and E.nentry = ED.nentry and ED.idrelated = CV.idrelated " +
                    " left outer join account A3 on ED.idacc = A3.idacc " +
                    " left outer join upb U on C.idupb = U.idupb " +
                    " where isnull(A2.idacc, \'\') <> isnull(A3.idacc, \'\')  and " +
                    " (isnull(A3.flagaccountusage, 0) & 16 <> 0) and " +
                    QHS.CmpEq("C.ycon", Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi8.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi6_Click(object sender, EventArgs e) {
            // Compensi a dipendenti(causale compenso - conto movimento)
            string sql = "select  C.ycon as 'anno compenso', C.ncon as 'n.compenso', " +
                         "E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', A1.codeacc as \'conto compenso.\', A2.codeacc as \'conto mov.\' ," +
                         "U.codeupb as 'codice upb contratto' " +
                         "from wageaddition C  " +
                         "join expensewageaddition EC on EC.ycon=C.ycon and EC.ncon=C.ncon " +
                         "join expense e on e.idexp=EC.idexp " +
                         "left outer join accmotivedetail AD on AD.idaccmotive = C.idaccmotivedebit and AD.ayear=E.ymov " +
                         "left outer join account A1 on A1.idacc= AD.idacc " +
                         " left outer join expenselink ELINK on ELINK.idparent = E.idexp " +
                         " join expenselast el on elink.idchild = el.idexp " +
                         "join registry r on r.idreg= e.idreg " +
                         "left outer join accmotivedetail rAD on r.idaccmotivedebit = rAD.idaccmotive and rAD.ayear=E.ymov " +
                         "left outer join account A2 on A2.idacc= isnull(EL.idaccdebit,rAD.idacc) " +
                         "left outer join upb U on C.idupb = U.idupb " +
                         "where isnull(A2.codeacc," + QHS.quote(codeaccFornitore) + ") <> A1.codeacc " +
                         " AND " + QHS.CmpEq("C.ycon", Conn.GetEsercizio()) +
                         " order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi9.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi10_Click(object sender, EventArgs e) {
            //Compensi parasubordinati (Incoerenza tra voce di Bilancio e Causale in contabilizzazione)
            string sql = "select  P.ycon as 'anno contratto', P.ncon as 'n. contratto', P.duty as 'Mansione', " +
                         " PY.npayroll as 'n. cedolino',  " +
                         " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto' ," +
                         " U.codeupb as 'codice upb contratto' " +
                         " from payroll PY " +
                         " join parasubcontract P on PY.idcon = P.idcon " +
                         " join expensepayroll EP on EP.idpayroll = PY.idpayroll " +
                         " join expenseyear EY ON  " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                         " and EY.idexp = EP.idexp " +
                         " join fin F ON F.idfin = EY.idfin " +
                         " join expense E on E.idexp = EY.idexp " +
                         " join finsorting FS on  FS.idfin = EY.idfin " +
                         " join sorting ESS on  ESS.idsor = FS.idsor " +
                         " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                         QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                         " join accmotivedetail ACD on ACD.idaccmotive = P.idaccmotive " +
                         " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                         " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                         " join account A ON A.idacc = ACD.idacc " +
                         " left outer join upb U on P.idupb = U.idupb " +
                         " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                         " order by  P.ycon, P.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi10.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi7_Click(object sender, EventArgs e) {
            // Missioni a dipendenti (Incoerenza tra voce di Bilancio e Causale in contabilizzazione)
            string sql =
                    "select  I.yitineration as 'anno missione', I.nitineration as 'n.missione',I.description as 'Descrizione', " +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto' ," +
                    " U.codeupb as 'codice upb missione' " +
                    " from itineration I  " +
                    " join expenseitineration EI on EI.iditineration = I.iditineration  " +
                    " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                    " AND EY.idexp = EI.idexp " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join expense E on E.idexp = EY.idexp " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive =  I.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " left outer join upb U on I.idupb = U.idupb " +
                    " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                    " order by  I.yitineration, I.nitineration ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi7.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi4_Click_1(object sender, EventArgs e) {
            //Compensi professionali (Incoerenza tra voce di Bilancio e Causale in contabilizzazione)
            string sql =
                    "select  P.ycon as 'anno contratto', P.ncon as 'n.contratto', P.description as 'Descrizione',  " +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto' ," +
                    " U.codeupb as 'codice upb prestazione' " +
                    " from profservice P  " +
                    " join expenseprofservice EP on EP.ycon = P.ycon AND EP.ncon = P.ncon " +
                    " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                    " AND EY.idexp = EP.idexp " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join expense E on E.idexp = EY.idexp " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive =  P.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " left outer join upb U on P.idupb = U.idupb " +
                    " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                    " order by  P.ycon, P.ncon ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi4.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensi3_Click_1(object sender, EventArgs e) {
            //Compensi occasionali (Incoerenza tra voce di Bilancio e Causale in contabilizzazione)
            string sql =
                    "select  C.ycon as 'anno contratto', C.ncon as 'n.contratto', C.description as 'Descrizione', " +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto' ," +
                    " U.codeupb as 'codice upb contratto'" +
                    " from casualcontract C  " +
                    " join expensecasualcontract EC on EC.ycon = C.ycon AND EC.ncon = C.ncon " +
                    " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                    " AND EY.idexp = EC.idexp " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join expense E on E.idexp = EY.idexp " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive =  C.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " left outer join upb U on C.idupb = U.idupb " +
                    " where ACS.idsor<> ESS.idsor  AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                    " order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi3.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }



        private void btnGene6_Click(object sender, EventArgs e) {
            string sql = " select MK.description as 'tipo contratto', " +
                         " MD.yman as 'anno contratto', MD.nman as 'n.contratto', " +
                         " MD.rownum as 'Dett.', MD.detaildescription as 'Descr.'," +
                         " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto'" +
                         " from mandatedetail  MD " +
                         " join mandatekind MK ON  MD.idmankind = MK.idmankind " +
                         " join expensemandate EM on EM.idmankind = MD.idmankind " +
                         " AND EM.yman = MD.yman  AND EM.nman = MD.nman " +
                         " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                         " AND EY.idexp = MD.idexp_taxable  " +
                         " join fin F ON F.idfin = EY.idfin " +
                         " join expense E on E.idexp = EY.idexp " +
                         " join finsorting FS on  FS.idfin = EY.idfin " +
                         " join sorting ESS on  ESS.idsor = FS.idsor " +
                         " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                         QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                         " join accmotivedetail ACD on ACD.idaccmotive =  MD.idaccmotive " +
                         " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                         " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                         " join account A ON A.idacc = ACD.idacc " +
                         " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                         " order by MD.idmankind , MD.yman, MD.nman ";

            //+QHS.CmpEq("C.ycon", Conn.GetEsercizio()) +
            //" order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtGene6.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnGene5_Click(object sender, EventArgs e) {
            string sql = " select EK.description as 'tipo contratto', " +
                         " ED.yestim as 'anno contratto', ED.nestim as 'n.contratto', " +
                         " ED.rownum as 'Dett.', ED.detaildescription as 'Descr.'," +
                         " I.ymov as \'Eserc.mov\',I.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto'" +
                         " from estimatedetail  ED " +
                         " join estimatekind EK ON  ED.idestimkind = EK.idestimkind " +
                         " join incomeyear EY ON" + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                         " and EY.idinc =  ED.idinc_taxable " +
                         " join fin F ON F.idfin = EY.idfin " +
                         " join income I on I.idinc = EY.idinc " +
                         " join finsorting FS on  FS.idfin = EY.idfin " +
                         " join sorting ESS on  ESS.idsor = FS.idsor " +
                         " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                         QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                         " join accmotivedetail ACD on ACD.idaccmotive =  ED.idaccmotive " +
                         " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                         " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                         " join account A ON A.idacc = ACD.idacc " +
                         " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("I.ymov", Conn.GetEsercizio()) +
                         " order by ED.idestimkind , ED.yestim, ED.nestim ";

            //+QHS.CmpEq("C.ycon", Conn.GetEsercizio()) +
            //" order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtGene5.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice6_Click(object sender, EventArgs e) {
            string sql =
                    " select IK.description as 'tipo', ID.yinv as 'anno', ID.ninv as 'n', ID.rownum as 'Dett.', ID.detaildescription as 'Descr.'," +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto'" +
                    " from invoicedetail ID " +
                    " join invoicekind IK ON  ID.idinvkind = IK.idinvkind " +
                    " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio())
                    + " and EY.idexp = ID.idexp_taxable " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join expense E on E.idexp = EY.idexp " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive = ID.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                    " order by IK.description, ID.yinv, ID.ninv ";
            //+QHS.CmpEq("C.ycon", Conn.GetEsercizio()) +
            //" order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck6.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice5_Click(object sender, EventArgs e) {
            string sql =
                    " select IK.description as 'tipo', ID.yinv as 'anno', ID.ninv as 'n', ID.rownum as 'Dett.', ID.detaildescription as 'Descr.'," +
                    " I.ymov as \'Eserc.mov\',I.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto'" +
                    " from invoicedetail ID " +
                    " join invoicekind IK ON  ID.idinvkind = IK.idinvkind " +
                    " join incomeyear EY ON" + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                    " and EY.idinc = ID.idinc_taxable " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join income I on I.idinc = EY.idinc " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive = ID.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("I.ymov", Conn.GetEsercizio()) +
                    " order by IK.description  , ID.yinv, ID.ninv ";
            //+QHS.CmpEq("C.ycon", Conn.GetEsercizio()) +
            //" order by  C.ycon, C.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheck5.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice7_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as 'Tipo Doc.', I.yinv as 'Eserc.doc',I.ninv as 'n.doc.\', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from invoiceview I " +
                    " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                    " join income e on e.idinc = ID.idinc_taxable " +
                    " join incomeyear ey on e.idinc = ey.idinc " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = id.idupb " +
                    " where I.flagbuysell = 'V'  and u1.idupb<> u2.idupb and " +
                    QHS.CmpEq("I.yinv", Conn.GetEsercizio()) +
                    " order by I.idinvkind, I.yinv,I.ninv,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice7.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        private void btnCompensi11_Click(object sender, EventArgs e) {
            //Compensi dipendenti (Incoerenza tra voce di Bilancio e Causale in contabilizzazione)
            string sql =
                    "select  W.ycon as 'anno contratto', W.ncon as 'n.contratto', W.description as 'Descrizione', " +
                    " E.ymov as \'Eserc.mov\',E.nmov as \'N.mov\', F.codefin as 'Bilancio', A.codeacc as 'Conto' ," +
                    " U.codeupb as 'codice upb contratto' " +
                    " from wageaddition W  " +
                    " join expensewageaddition EW on EW.ycon = W.ycon AND EW.ncon = W.ncon " +
                    " join expenseyear EY ON " + QHS.CmpEq("EY.ayear", Conn.GetEsercizio()) +
                    " AND EY.idexp = EW.idexp " +
                    " join fin F ON F.idfin = EY.idfin " +
                    " join expense E on E.idexp = EY.idexp " +
                    " join finsorting FS on  FS.idfin = EY.idfin " +
                    " join sorting ESS on  ESS.idsor = FS.idsor " +
                    " join sortingkind ESK on ESK.idsorkind = ESS.idsorkind and(ESK.flag & 4 <> 0) AND " +
                    QHS.CmpEq("ESK.start", Conn.GetEsercizio()) +
                    " join accmotivedetail ACD on ACD.idaccmotive =  W.idaccmotive " +
                    " AND " + QHS.CmpEq(" ACD.ayear", Conn.GetEsercizio()) +
                    " join accountsorting ACS on ACD.idacc = ACS.idacc " +
                    " join account A ON A.idacc = ACD.idacc " +
                    " left outer join upb U on W.idupb = U.idupb " +
                    " where ACS.idsor<> ESS.idsor AND " + QHS.CmpEq("E.ymov", Conn.GetEsercizio()) +
                    " order by  W.ycon, W.ncon ";

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCompensi11.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnGeneraCedolino_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio), QHS.CmpEq("flagbalance", "N"));
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = getTable("payroll", filter, "npayroll");
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idpayroll"))) return;
                t.TableName = "payroll";
            }

            btnGeneraCedolino.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataTable T = Conn.RUN_SELECT("payroll", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;
                DataSet D = new DataSet("payrollDS");
                D.Tables.Add(T);
                txtCurrent.Text = "Cedolino parasubordinati - Contratto " + T.Rows[0]["idcon"].ToString() +
                                  " ced. n. " + T.Rows[0]["npayroll"] + " del " + T.Rows[0]["fiscalyear"];
                rigeneraScrittura(T.Rows[0], "payroll");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraCedolino.Visible = true;

        }

        private void btnEsiti_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("ayear", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = getTable("bankimport", filter, "idbankimport");
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idbankimport")) || !(t.Columns.Contains("adate"))) return;
                t.TableName = "bankimport";
            }
            btnEsiti.Visible = false;
            DataSet D = new DataSet("bankimportDS");
            D.Tables.Add(t);
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                txtCurrent.Text = "Importazione esiti -  " + r["idbankimport"] + " del " + r["adate"];
                rigeneraScrittura(r, "bankimport");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();

            btnEsiti.Visible = true;
        }


        private void btnInvoice8_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as 'Tipo Doc.', I.yinv as 'Eserc.doc',I.ninv as 'n.doc.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from invoiceview I " +
                    " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                    " join income e on e.idinc = ID.idinc_iva " +
                    " join incomeyear ey on e.idinc = ey.idinc " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb =  isnull(id.idupb_iva, id.idupb) " +
                    " where I.flagbuysell = 'V'  and u1.idupb<> u2.idupb and " +
                    QHS.CmpEq("I.yinv", Conn.GetEsercizio()) +
                    " order by I.idinvkind, I.yinv,I.ninv,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice8.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        /*
            select I.codeinvkind as 'Tipo Doc.', I.yinv as 'Eserc.doc',I.ninv as 'n.doc.\', ID.rownum as 'n.dett.',
			   ID.detaildescription as 'Descrizione dettaglio',
               E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb dettaglio', u2.codeupb as 'cod.upb movimento'
               from invoiceview I 
               join invoicedetail ID on I.idinvkind=ID.idinvkind and I.yinv=ID.yinv and I.ninv=ID.ninv
               join expense e on e.idexp=ID.idexp_taxable
			   join expenseyear ey on e.idexp=ey.idexp 
			   join upb u1 on u1.idupb =ey.idupb 
			   join upb u2 on u2.idupb =id.idupb 
               where I.flagbuysell='A'  and u1.idupb<>u2.idupb
               order by  I.idinvkind, I.yinv,I.ninv,ID.rownum

    */

        private void btnInvoice9_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as 'Tipo Doc.', I.yinv as 'Eserc.doc',I.ninv as 'n.doc.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from invoiceview I " +
                    " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                    " join expense e on e.idexp = ID.idexp_taxable " +
                    " join expenseyear ey on e.idexp = ey.idexp " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = id.idupb " +
                    " where I.flagbuysell = 'A'  and u1.idupb<> u2.idupb and " +
                    QHS.CmpEq("I.yinv", Conn.GetEsercizio()) +
                    " order by I.idinvkind, I.yinv,I.ninv,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice9.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }



        private void btnInvoice10_Click(object sender, EventArgs e) {
            string sql =
                    "select I.codeinvkind as 'Tipo Doc.', I.yinv as 'Eserc.doc',I.ninv as 'n.doc.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from invoiceview I " +
                    " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                    " join expense e on e.idexp = ID.idexp_iva " +
                    " join expenseyear ey on e.idexp = ey.idexp " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = isnull(id.idupb_iva,id.idupb) " +
                    " where I.flagbuysell = 'A'  and u1.idupb<> u2.idupb and " +
                    QHS.CmpEq("I.yinv", Conn.GetEsercizio()) +
                    " order by I.idinvkind, I.yinv,I.ninv,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice10.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        /*
        select I.idestimkind as 'Tipo ', I.yestim as 'Eserc.',I.nestim as 'n.', ID.rownum as 'n.dett.',
			   ID.detaildescription as 'Descrizione dettaglio',
               E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb dettaglio', u2.codeupb as 'cod.upb movimento'
               from estimateview I 
               join estimatedetail ID on I.idestimkind=ID.idestimkind and I.yestim=ID.yestim and I.nestim=ID.nestim
               join income e on e.idinc=ID.idinc_taxable
			   join incomeyear ey on e.idinc=ey.idinc 
			   join upb u1 on u1.idupb =ey.idupb 
			   join upb u2 on u2.idupb =id.idupb 
               where  u1.idupb<>u2.idupb and ey.ayear=2015
               order by  I.idestimkind, I.yestim,I.nestim,ID.rownum
               */
        private void btnUpbCAttivi1_Click(object sender, EventArgs e) {
            string sql =
                    "select I.idestimkind as 'Tipo', I.yestim as 'Eserc.',I.nestim as 'n.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from estimateview I " +
                    " join estimatedetail ID on I.idestimkind = ID.idestimkind and I.yestim = ID.yestim and I.nestim = ID.nestim " +
                    " join income e on e.idinc = ID.idinc_taxable " +
                    " join incomeyear ey on e.idinc = ey.idinc " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = id.idupb " +
                    " where  u1.idupb<> u2.idupb and " + QHS.CmpEq("ey.ayear", Conn.GetEsercizio()) +
                    " order by I.idestimkind, I.yestim,I.nestim,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnUpbCAttivi1.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnUpbCAttivi2_Click(object sender, EventArgs e) {
            string sql =
                    "select I.idestimkind as 'Tipo', I.yestim as 'Eserc.',I.nestim as 'n.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from estimateview I " +
                    " join estimatedetail ID on I.idestimkind = ID.idestimkind and I.yestim = ID.yestim and I.nestim = ID.nestim " +
                    " join income e on e.idinc = ID.idinc_iva " +
                    " join incomeyear ey on e.idinc = ey.idinc " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb  =isnull(id.idupb_iva,id.idupb) " +
                    " where  u1.idupb<> u2.idupb and " + QHS.CmpEq("ey.ayear", Conn.GetEsercizio()) +
                    " order by I.idestimkind, I.yestim,I.nestim,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnUpbCAttivi2.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnUpbCPassivi1_Click(object sender, EventArgs e) {
            string sql =
                    "select I.idmankind as 'Tipo', I.yman as 'Eserc.',I.nman as 'n.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from mandateview I " +
                    " join mandatedetail ID on I.idmankind = ID.idmankind and I.yman = ID.yman and I.nman = ID.nman " +
                    " join expense e on e.idexp = ID.idexp_taxable " +
                    " join expenseyear ey on e.idexp = ey.idexp " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = id.idupb " +
                    " where  u1.idupb<> u2.idupb and " + QHS.CmpEq("ey.ayear", Conn.GetEsercizio()) +
                    " order by I.idmankind, I.yman,I.nman,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnUpbCPassivi1.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnUpbCPassivi2_Click(object sender, EventArgs e) {
            string sql =
                    "select I.idmankind as 'Tipo', I.yman as 'Eserc.',I.nman as 'n.', ID.rownum as 'n.dett.', " +
                    " ID.detaildescription as 'Descrizione dettaglio', " +
                    " E.ymov as 'Eserc.mov',E.nmov as 'N.mov', u1.codeupb as 'codice upb movimento', u2.codeupb as 'cod.upb dettaglio' " +
                    " from mandateview I " +
                    " join mandatedetail ID on I.idmankind = ID.idmankind and I.yman = ID.yman and I.nman = ID.nman " +
                    " join expense e on e.idexp = ID.idexp_iva " +
                    " join expenseyear ey on e.idexp = ey.idexp " +
                    " join upb u1 on u1.idupb = ey.idupb " +
                    " join upb u2 on u2.idupb = id.idupb_iva " +
                    " where  u1.idupb<> u2.idupb and " + QHS.CmpEq("ey.ayear", Conn.GetEsercizio()) +
                    " order by I.idmankind, I.yman,I.nman,ID.rownum ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnUpbCPassivi2.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCreditoCAttivi_Click(object sender, EventArgs e) {
            string sql =
                    "select M.estimkind as 'tipo contratto', M.yestim as 'anno contratto', M.nestim as 'n.contratto', " +
                    " EE.ymov as 'anno incasso', EE.nmov as 'num. incasso',  " +
                    " Acontratto.codeacc as 'conto contratto', " +
                    " Acliente.codeacc as 'conto cliente', " +
                    " Aconfig.codeacc as 'conto configurazione', " +
                    " Amov.codeacc as 'conto movimento', " +
                    " Agood.ayear as 'anno conto corretto', " +
                    " Agood.codeacc as 'conto corretto'," +
                    " Aused.ayear as 'anno conto usato', " +
                    " Aused.codeacc as 'conto usato' " +
                    " from estimateview M " +
                    " join estimatekind MK on M.idestimkind = MK.idestimkind " +
                    " join incomeestimate EM on M.idestimkind = EM.idestimkind and M.yestim = EM.yestim and M.nestim = EM.nestim " +
                    " join incomelink ELINK on ELINK.idparent = EM.idinc " +
                    " join incomelast EL on ELINK.idchild = EL.idinc " +
                    " left outer join account Amov on Amov.idacc = EL.idacccredit " +
                    " join income EE on EE.idinc = EL.idinc " +
                    " left outer join accmotivedetail AD on AD.idaccmotive = isnull(M.idaccmotivecredit_crg, M.idaccmotivecredit) and AD.ayear = EE.ymov " +
                    " left outer join account Acontratto on Acontratto.idacc = AD.idacc " +
                    " join config C on C.ayear = EE.ymov " + //Config anno movimento
                    " left outer join account Aconfig on Aconfig.idacc = C.idacc_customer " +
                    " join registry R on EE.idreg = R.idreg " +
                    " left outer join accmotivedetail AR on R.idaccmotivecredit = AR.idaccmotive and AR.ayear = EE.ymov " + //causale credito, anno mov
                    " left outer join account Acliente on Acliente.idacc = AR.idacc " +
                    " left outer join account Agood on Agood.idacc = coalesce(AD.idacc, AR.idacc, C.idacc_customer) " +
                    " left outer join account Aused on Aused.idacc = coalesce(Amov.idacc, AR.idacc, Aconfig.idacc) " +
                    " where EE.ymov = " + QHS.quote(Conn.GetEsercizio()) + " and MK.linktoinvoice = 'N' " +
                    " and isnull(Aused.idacc, 'q')<> isnull(Agood.idacc, 'q')";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckCreditoContratti.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDebitoCPassivi_Click(object sender, EventArgs e) {
            string sql = "select M.mankind as 'tipo contratto', M.yman as 'anno contratto', M.nman as 'n.contratto'," +
                         "EE.ymov as 'anno pagamento', EE.nmov as 'num. pagamento', " +
                         " Acontratto.codeacc as 'conto contratto'," +
                         " Afornitore.codeacc as 'conto fornitore'," +
                         " Aconfig.codeacc as 'conto configurazione'," +
                         " Amov.codeacc as 'conto movimento'," +
                         " Agood.ayear as 'anno conto corretto', " +
                         " Agood.codeacc as 'conto corretto'," +
                         " Aused.ayear as 'anno conto usato', " +
                         " Aused.codeacc as 'conto usato' " +
                         " from mandateview M  " +
                         " join mandatekind MK on M.idmankind = MK.idmankind " +
                         " join expensemandate EM on M.idmankind = EM.idmankind and M.yman = EM.yman and M.nman = EM.nman " +
                         " join expenselink ELINK on ELINK.idparent = EM.idexp " +
                         " join expenselast EL on ELINK.idchild = EL.idexp " +
                         " left outer join account Amov on Amov.idacc = EL.idaccdebit " +
                         " join expense EE on EE.idexp = EL.idexp " +
                         "  left outer join accmotivedetail AD on AD.idaccmotive = isnull(M.idaccmotivedebit_crg, M.idaccmotivedebit) and AD.ayear = EE.ymov " +
                         " left outer join account Acontratto on Acontratto.idacc = AD.idacc " +
                         " join config C on C.ayear = EE.ymov " +
                         " left outer join account Aconfig on Aconfig.idacc = C.idacc_supplier " +
                         " join registry R on EE.idreg = R.idreg " +
                         " left outer join accmotivedetail AR on R.idaccmotivedebit = AR.idaccmotive and AR.ayear = EE.ymov " +
                         " left outer join account Afornitore on Afornitore.idacc = AR.idacc " +
                         " left outer join account Agood on Agood.idacc = coalesce(AD.idacc, AR.idacc, C.idacc_supplier) " +
                         " left outer join account Aused on Aused.idacc = coalesce(Amov.idacc, AR.idacc, Aconfig.idacc) " +
                         " where EE.ymov = " + QHS.quote(Conn.GetEsercizio()) + " and MK.linktoinvoice = 'N' " +
                         " and isnull(Aused.idacc, 'q')<> isnull(Agood.idacc, 'q')";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckDebitoContratti.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice11_Click(object sender, EventArgs e) {
            string sql = "select I.codeinvkind as 'tipo fattura', I.yinv as 'eserc.fattura',I.ninv as 'n.fattura'," +
                         " P.ycon as 'anno.parcella',P.ncon as 'n.parcella' from entry E " +
                         " join invoiceview I on E.idrelated = 'inv§' + convert(varchar(20), I.idinvkind) " +
                         " + '§' + convert(varchar(4), I.yinv) + '§' + convert(varchar(20), I.ninv) " +
                         " join profservice P on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv " +
                         " where E.idrelated like 'inv%' " +
                         " and P.epkind = 'R' " +
                         " and P.ycon < I.yinv " +
                         " and not exists(select * from entrydetailaccrual A where A.yentry = E.yentry and A.nentry = E.nentry) " +
                         " and E.yentry = " + QHS.quote(Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice11.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice12_Click(object sender, EventArgs e) {
            string sql = "select I.codeinvkind as 'tipo fattura', I.yinv as 'anno fattura',I.ninv as 'n.fattura'," +
                         " ID.rownum as 'n.riga fattura',MK.description as 'tipo contratto', MD.yman as 'anno contratto'," +
                         " MD.nman as 'n.contratto',MD.rownum as 'n.riga contratto'" +
                         " from entry E " +
                         " join invoiceview I on E.idrelated = 'inv§' + convert(varchar(20), I.idinvkind) + " +
                         " '§' + convert(varchar(4), I.yinv) + '§' + convert(varchar(20), I.ninv) " +
                         " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                         " join mandatedetail MD on ID.idmankind = MD.idmankind and ID.yman = MD.yman and ID.nman = MD.nman and ID.manrownum = MD.rownum " +
                         " join mandatekind MK on MD.idmankind = MK.idmankind " +
                         " where E.idrelated like 'inv%' " +
                         " and MD.epkind = 'R' " +
                         " and MD.yman < I.yinv " +
                         " and not exists(select * from entrydetailaccrual A where A.yentry = E.yentry and A.nentry = E.nentry) " +
                         "and E.yentry =  " + QHS.quote(Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice12.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnInvoice13_Click(object sender, EventArgs e) {
            string sql = "select I.codeinvkind as 'tipo fattura', I.yinv as 'anno fattura',I.ninv as 'n.fattura'," +
                         " ID.rownum as 'n.riga fattura',MK.description as 'tipo contratto', MD.yestim as 'anno contratto'," +
                         " MD.nestim as 'n.contratto',MD.rownum as 'n.riga contratto'" +
                         " from entry E " +
                         " join invoiceview I on E.idrelated = 'inv§' + convert(varchar(20), I.idinvkind) + " +
                         " '§' + convert(varchar(4), I.yinv) + '§' + convert(varchar(20), I.ninv) " +
                         " join invoicedetail ID on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv " +
                         " join estimatedetail MD on ID.idestimkind = MD.idestimkind and ID.yestim = MD.yestim and ID.nestim = MD.nestim " +
                         " and ID.estimrownum = MD.rownum " +
                         " join estimatekind MK on MD.idestimkind = MK.idestimkind " +
                         " where E.idrelated like 'inv%' " +
                         " and MD.epkind = 'R' " +
                         " and MD.yestim < I.yinv " +
                         " and not exists(select * from entrydetailaccrual A where A.yentry = E.yentry and A.nentry = E.nentry) " +
                         "and E.yentry =  " + QHS.quote(Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtInvoice12.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnGene7_Click(object sender, EventArgs e) {
            string sql =
                    "select B.codeacc as 'codice prec.', A.codeacc as 'codice', " +
                    " B.flag 'flag prec', A.flag," +
                    " B.accountkinddescr 'tipo conto prec', A.accountkinddescr 'tipo conto', " +
                    " B.patrimony_sign 'Segno nello stato patrimoniale prec', A.patrimony_sign 'Segno nello stato patrimoniale'," +
                    //" --B.flagprofit 'Utile prec', A.flagprofit 'Utile',"
                    " B.flagaccountusage 'Flag utilizzo prec', A.flagaccountusage 'Flag utilizzo', " +
                    " B.flagupb 'registra UPB prec', A.flagupb 'registra UPB', " +
                    " B.flagregistry 'registra anag prec', A.flagregistry 'rregistra anag', " +
                    " B.placcount_sign 'Segno nel Conto Economico prec', A.placcount_sign 'Segno nel Conto Economico', " +
                    " B.economicbudget_sign 'Segno nel budget economico prec', A.economicbudget_sign 'Segno nel budget economico'," +
                    " B.investmentbudget_sign 'Segno nel budget degli investimenti prec', A.investmentbudget_sign 'Segno nel budget degli investimenti', " +
                    " B.codepatrimony 'stato patrimoniale prec', A.codepatrimony 'stato patrimoniale'," +
                    " B.codeplaccount 'conto economico prec', A.codeplaccount 'conto economico' " +
                    " from accountview A " +
                    " join accountlookup AL on AL.newidacc = A.idacc " +
                    " join accountview B on AL.oldidacc = B.idacc " +
                    " where " +
                    " (isnull(A.flag, 0) <> isnull(B.flag, 0) " +
                    " or isnull(A.idaccountkind, 0)<> isnull(B.idaccountkind, 0) " +
                    " or isnull(A.patrimony_sign, 'q')<> isnull(B.patrimony_sign, 'q') " +
                    //" --or isnull(A.flagprofit, 'q')<> isnull(B.flagprofit, 'q')"
                    " or isnull(A.flagaccountusage, 0)<> isnull(B.flagaccountusage, 0) " +
                    " or isnull(A.flagupb, 'q')<> isnull(B.flagupb, 'q') " +
                    " or isnull(A.flagregistry, 'q')<> isnull(B.flagregistry, 'q') " +
                    " or isnull(A.placcount_sign, 'q')<> isnull(B.placcount_sign, 'q') " +
                    " or isnull(A.economicbudget_sign, 'q')<> isnull(B.economicbudget_sign, 'q') " +
                    " or isnull(A.investmentbudget_sign, 'q')<> isnull(B.investmentbudget_sign, 'q') " +
                    " or isnull(A.codepatrimony, 'q')<> isnull(B.codepatrimony, 'q') " +
                    " or isnull(A.codeplaccount, 'q')<> isnull(B.codeplaccount, 'q') " +
                    " ) " +
                    " and A.ayear = " + QHS.quote(Conn.GetEsercizio());
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtGene7.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnGene8_Click(object sender, EventArgs e) {
            string sql =
                    "select ayear as 'Esercizio', codeacc as 'Codice conto', printingorder as 'Ordine di stampa', " +
                    "title as 'Denominazione', accountkind as 'Tipo conto', flagaccountusage as 'Flag utilizzo conto'" +
                    "from accountusable where " + QHS.AppAnd(QHS.NullOrEq("flagaccountusage",0),
                        QHS.CmpEq("ayear", Conn.GetEsercizio()));
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtGene8.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        private void btnGene9_Click(object sender, EventArgs e) {
            string sql =
                    "select accountusable.ayear as 'Esercizio', accountusable.codeacc as 'Codice conto', accountusable.printingorder as 'Ordine di stampa', " +
                    "accountusable.title as 'Denominazione', accountusable.accountkind as 'Tipo conto', accountusable.idpatrimony as 'Stato patrimoniale', accountusable.idplaccount as 'Conto economico'" +
                    "from accountusable join account on accountusable.idacc = account.idacc " +
                    "where accountusable.ayear = " + QHS.quote(Conn.GetEsercizio()) +
                    "AND ((account.flag & 4) = 0) AND ((accountusable.idpatrimony is null and accountusable.idplaccount is null )" +
                    "OR (exists(select * from patrimony where paridpatrimony = accountusable.idpatrimony)) " +
                    "OR (exists(select * from placcount where paridplaccount = accountusable.idplaccount)))";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtGene13.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }


        private void btnGeneraCSA_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yimport", esercizio);
            DataTable All = new DataTable();
            if (cmd.Trim() == "") {
                All = Conn.RUN_SELECT("csa_import", "*", "nimport", filter, null, false);
            }
            else {
                All = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((All == null) || (All.Rows.Count == 0)) return;
                if (!(All.Columns.Contains("idcsa_import")) || !(All.Columns.Contains("yimport")) ||
                    !(All.Columns.Contains("nimport"))) return;
                All.TableName = "csa_import";
            }

            btnGeneraCSA.Visible = false;


            // aggiungere clear per scuotare il dataset
            //DataSet D = new DataSet("csaDS");

            //DataTable t = Conn.CreateTableByName("csa_import", "*");
            //if (t.Columns.Contains("txt")) {
            //    t.Columns.Remove("txt");
            //}
            //if (t.Columns.Contains("rtf")) {
            //    t.Columns.Remove("rtf");
            //}
            //DataTable tRiep = Conn.CreateTableByName("csa_importriep", "*");
            //if (tRiep.Columns.Contains("txt")) {
            //    tRiep.Columns.Remove("txt");
            //}
            //if (tRiep.Columns.Contains("rtf")) {
            //    tRiep.Columns.Remove("rtf");
            //}

            //DataTable tVer = Conn.CreateTableByName("csa_importver", "*");
            //if (tVer.Columns.Contains("txt")) {
            //    tVer.Columns.Remove("txt");
            //}
            //if (tVer.Columns.Contains("rtf")) {
            //    tVer.Columns.Remove("rtf");
            //}
            //D.Tables.Add(t);
            //D.Tables.Add(tRiep);
            //D.Tables.Add(tVer);


            progBar.Value = 0;
            progBar.Maximum = All.Rows.Count;
            progBar.Update();
            foreach (DataRow r in All.Rows) {
                //D.Clear();
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_import"],null,QHS.CmpKey(r),null,false);
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_importriep"], null, QHS.CmpKey(r), null, false);
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_importver"], null, QHS.CmpKey(r), null, false);
                txtCurrent.Text = "Importazione CSA Stipendi n° " + r["nimport"].ToString() + " del " + r["nimport"];
                rigeneraScritturaCSA(r, null);
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraCSA.Visible = true;
        }

        private void btnGeneraCSADebit_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yimport", esercizio);
            DataTable All = new DataTable();
            if (cmd.Trim() == "") {
                All = Conn.RUN_SELECT("csa_import", "*", "nimport", filter, null, false);
            }
            else {
                All = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((All == null) || (All.Rows.Count == 0)) return;
                if (!(All.Columns.Contains("idcsa_import")) || !(All.Columns.Contains("yimport")) ||
                    !(All.Columns.Contains("nimport"))) return;
            }

            btnGeneraCSADebit.Visible = false;

            //// aggiungere clear per scuotare il dataset
            //DataSet D = new DataSet("csaDS");

            //DataTable t = Conn.CreateTableByName("csa_import", "*");
            //if (t.Columns.Contains("txt")) {
            //    t.Columns.Remove("txt");
            //}
            //if (t.Columns.Contains("rtf")) {
            //    t.Columns.Remove("rtf");
            //}

            All.TableName = "csa_import.debit"; //Indispensabile per la generazione delle scritture

            //DataTable tRiep = Conn.CreateTableByName("csa_importriep", "*");
            //if (tRiep.Columns.Contains("txt")) {
            //    tRiep.Columns.Remove("txt");
            //}
            //if (tRiep.Columns.Contains("rtf")) {
            //    tRiep.Columns.Remove("rtf");
            //}

            //DataTable tVer = Conn.CreateTableByName("csa_importver", "*");
            //if (tVer.Columns.Contains("txt")) {
            //    tVer.Columns.Remove("txt");
            //}
            //if (tVer.Columns.Contains("rtf")) {
            //    tVer.Columns.Remove("rtf");
            //}
            //D.Tables.Add(t);
            //D.Tables.Add(tRiep);
            //D.Tables.Add(tVer);

            progBar.Value = 0;
            progBar.Maximum = All.Rows.Count;
            progBar.Update();
            foreach (DataRow r in All.Rows) {
                //D.Clear();
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_import"], null, QHS.CmpKey(r), null, false);
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_importriep"], null, QHS.CmpKey(r), null, false);
                //Conn.RUN_SELECT_INTO_TABLE(D.Tables["csa_importver"], null, QHS.CmpKey(r), null, false);
                txtCurrent.Text = "Importazione CSA Stipendi n° " + r["nimport"].ToString() + " del " + r["nimport"];
                rigeneraScritturaCSA(r, "debito");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnGeneraCSADebit.Visible = true;
        }

        //private void btnAssestamentoBudget_Click(object sender, EventArgs e) {
        //    string sql = " SELECT " +
        //                 " accountyear.ayear as 'Esercizio', " +
        //                 " CASE when ((account.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END as 'Ricavi', " +
        //                 " account.codeacc as 'Codice Conto', " +
        //                 " account.title as 'Denom. Conto', " +
        //                 " upb.codeupb 'Cod. UPB', " +
        //                 " upb.title 'Denom. UPB', " +
        //                 " account.nlevel as 'Num. Livello Conto'," +
        //                 " accountlevel.description as 'Livello Conto'," +
        //                 " accountyear.prevision as 'Previsione', " +
        //                 " isnull((select sum(curramount) from epaccview where epaccview.idacc = " +
        //                 " account.idacc and epaccview.idupb=upb.idupb and epaccview.nphase = 1), 0) as 'Totale Accertato', " +
        //                 " accountyear.prevision - isnull((select sum(curramount) from epaccview where epaccview.idacc = " +
        //                 " account.idacc and epaccview.idupb=upb.idupb and epaccview.nphase = 1),0) as 'Disponibile ad accertare' " +
        //                 " FROM accountyear " +
        //                 " JOIN account ON accountyear.idacc = account.idacc " +
        //                 " JOIN upb ON upb.idupb = accountyear.idupb " +
        //                 " JOIN accountlevel ON accountlevel.nlevel = account.nlevel AND accountlevel.ayear = account.ayear " +
        //                 " WHERE((account.flagaccountusage & 128) <> 0) " +
        //                 " AND (accountyear.prevision - isnull((select sum(curramount) from epaccview where epaccview.idacc = " +
        //                 " account.idacc  and epaccview.idupb=upb.idupb and epaccview.nphase = 1), 0) ) <> 0 AND " +
        //                 QHS.CmpEq("account.ayear", Conn.GetEsercizio());

        //    DataTable t = Conn.SQLRunner(sql, false, 0);
        //    if (t.Rows.Count > 0) {
        //        DataSet d = new DataSet();
        //        d.Tables.Add(t);
        //        frmErrorView f = new frmErrorView(Meta.myHelpForm, btnAssestamentoBudget.Text, t);
        //        createForm(f, this);
		//        f.Show(this);
        //    }
        //    else {
        //        show(this, "Nessun problema riscontrato", "Avviso");
        //    }
        //}

        private void btnContrattiNoMovBudget_Click(object sender, EventArgs e) {

            //Secondo controllo: Contratti senza movimenti di budget
            // Esportare tutte le righe di tutti i contratti attivi e passivi che hanno 
            // il flag ‘utilizzabile per la contabilizzazione’ 

            //          UNION
            //          SELECT 'Contratto Attivo' as 'Documento', estimateview.idestimkind as 'Tipo',  estimatedetailview.yestim as 'Esercizio', estimatedetailview.nestim as 'Numero',  
            //estimateview.description as 'Descrizione',  estimateview.adate as 'Data Contabile',  estimateview.registry as 'Anagrafica',  estimateview.manager as 'Responsabile',
            //estimatedetailview.rownum as 'N. riga',  estimatedetailview.idgroup as 'N. Gruppo' , estimatedetailview.rowtotal as 'Tot. Riga'
            //from estimatedetailview  join estimateview ON estimateview.idestimkind = estimatedetailview.idestimkind  AND estimateview.yestim = estimatedetailview.yestim
            // AND estimateview.nestim = estimatedetailview.nestim


            //join estimatekind ON estimateview.idestimkind = estimatekind.idestimkind
            //where estimatedetailview.idepacc is null
            //  AND isnull(estimatekind.linktoinvoice, 'N') = 'N'  AND isnull(estimateview.active, 'N') = 'S'  AND(estimatedetailview.yestim = '2017')
            //AND estimateview.active = 'S'

            string sql = " SELECT " +
                         " 'Contratto Passivo' as 'Documento',  mandateview.mankind as 'Tipo', " +
                         " mandatedetailview.yman as 'Esercizio', mandatedetailview.nman as 'Numero',  " +
                         " mandatedetailview.rownum as '#Riga', mandatedetailview.idgroup as '#Gruppo',  " +
                         " mandateview.description as 'Descrizione', " +
                         " mandateview.adate as 'Data Contabile',  mandateview.registry as 'Anagrafica', " +
                         " mandateview.manager as 'Responsabile',rowtotal as 'Totale Riga' " +
                         " from mandatedetailview join mandateview ON mandateview.idmankind = mandatedetailview.idmankind  " +
                         " AND mandateview.yman = mandatedetailview.yman   AND mandateview.nman = mandatedetailview.nman " +
                         " join mandatekind ON mandateview.idmankind = mandatekind.idmankind " +
                         " where mandatedetailview.idepexp is null " +
                         //" AND isnull(mandatekind.linktoinvoice, 'N') = 'N' " +
                         " AND isnull(mandateview.active, 'N') = 'S' " +
                         " AND " + QHS.CmpEq("isnull(year(mandatedetailview.start),mandatedetailview.yman)", Conn.GetEsercizio()) +
                         " AND isnull(mandatekind.isrequest, 'N') = 'N' " +
                         " UNION " +
                         " SELECT  'Contratto Attivo' as 'Documento', estimateview.estimkind as 'Tipo', " +
                         " estimatedetailview.yestim as 'Esercizio', estimatedetailview.nestim as 'Esercizio',  " +
                         " estimatedetailview.rownum as '#Riga', estimatedetailview.idgroup as '#Gruppo',  " +
                         " estimateview.description as 'Descrizione', " +
                         " estimateview.adate as 'Data Contabile', estimateview.registry as 'Anagrafica', " +
                         " estimateview.manager as 'Responsabile',rowtotal as 'Totale Riga' " +
                         " from estimatedetailview  join estimateview ON estimateview.idestimkind = estimatedetailview.idestimkind " +
                         " AND estimateview.yestim = estimatedetailview.yestim " +
                         " AND estimateview.nestim = estimatedetailview.nestim " +
                         " join estimatekind ON estimateview.idestimkind = estimatekind.idestimkind " +
                         " where estimatedetailview.idepacc is null " +
                         //" AND isnull(estimatekind.linktoinvoice, 'N') = 'N' " +
                         " AND isnull(estimateview.active, 'N') = 'S' " +
                         " AND " + QHS.CmpEq("isnull(year(estimatedetailview.start),estimatedetailview.yestim)", Conn.GetEsercizio()) ;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnContrattiNoMovBudget.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCompensiNoMovBudget_Click(object sender, EventArgs e) {
            var param = new[] {Meta.GetSys("esercizio")};
            var ds = Conn.CallSP("exp_compensi_no_epexp", param, true);
            if (ds == null || ds.Tables.Count == 0) {
                show(this, "Nessun problema riscontrato", "Avviso");
                return;
            }
            frmErrorView f = new frmErrorView(Meta.myHelpForm, btnCompensiNoMovBudget.Text, ds.Tables[0]);
            createForm(f, this);
			f.Show(this);
        }

        private void btnFattureNonCollegateOrdini_Click(object sender, EventArgs e) {
            // Fatture impegnate non collegate a ordini
            string sql = " SELECT " +
                         " 'Fattura' as 'Documento', invoicekind as 'Tipo' , " +
                         " yinv as 'Esercizio', ninv as 'Numero', " +
                         " detaildescription as 'Descrizione dettaglio', rownum as '#Numero riga', " +
                         " adate as 'Data Contabile', registry as 'Anagrafica' " +
                         " from invoicedetailview where exists " +
                         " (select * from epexp where idrelated = 'inv' + '§' + " +
                         " convert(varchar(4), idinvkind) + '§' + " +
                         " convert(varchar(4), yinv) + '§' + convert(varchar(14), ninv)) " +
                         " AND NOT EXISTS(select * from profservice   where " +
                         " idinvkind = invoicedetailview.idinvkind " +
                         " AND  yinv = invoicedetailview.yinv " +
                         " AND  ninv = invoicedetailview.ninv) " +
                         " AND (select flag from accmotive where " +
                         " idaccmotive = invoicedetailview.idaccmotive) & 1 = 0 " +
                         " AND " + QHS.CmpEq("yinv", Conn.GetEsercizio()) +
                         " AND yman is null " +
                         " AND ISNULL(rounding,'N') = 'N' " +
                         " ORDER BY invoicekind ,yinv, ninv, rownum ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnFattureNonCollegateOrdini.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnNoteDiCredito_Click(object sender, EventArgs e) {
            // Note di credito
            // Esportare tutte le note di credito senza upb / causale o senza il riferimento alla fattura.
            string sql = " SELECT " +
                         " 'Nota di credito' as 'Documento', invoicekind as 'Tipo' , " +
                         " yinv as 'Esercizio', ninv as 'Numero', " +
                         " detaildescription as 'Descrizione dettaglio', " +
                         " rownum as '#Numero riga', " +
                         " adate as 'Data Contabile', registry as 'Anagrafica' " +
                         " from invoicedetailview where exists " +
                         " (select * from epexp where idrelated = 'inv' + '§' +  " +
                         " convert(varchar(4), idinvkind) + '§' + " +
                         " convert(varchar(4), yinv) + '§' + convert(varchar(14), ninv)) " +
                         " AND NOT EXISTS(select * from profservice   " +
                         " where idinvkind = invoicedetailview.idinvkind " +
                         " AND  yinv = invoicedetailview.yinv " +
                         " AND  ninv = invoicedetailview.ninv) " +
                         " AND (select flag from accmotive where " +
                         " idaccmotive = invoicedetailview.idaccmotive) & 1 = 0 " +
                         " AND " + QHS.CmpEq("yinv", Conn.GetEsercizio()) +
                         " AND ISNULL(rounding,'N') = 'N' " +
                         " AND ISNULL(flagvariation, 'N') = 'S' " +
                         " AND(idinvkind_main IS NULL " +
                         " OR idupb IS NULL " +
                         " OR idaccmotive IS NULL )" +
                         " ORDER BY invoicekind ,yinv, ninv, rownum ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnNoteDiCredito.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnOpFondoEconomaleNoEntry_Click(object sender, EventArgs e) {
            // Note di credito
            // Esportare tutte le note di credito senza upb / causale o senza il riferimento alla fattura.
            string sql = " SELECT " +
                         " 'Operazione Fondo Economale' as 'Documento', " +
                         " pettycash as 'Tipo Fondo', " +
                         " yoperation as 'Esercizio', noperation as 'Numero', " +
                         " description as 'Descrizione', " +
                         " adate as 'Data contabile',manager as 'Responsabile', " +
                         " amount as 'Importo' " +
                         " from pettycashoperationview where  not exists " +
                         " (select * from entry where idrelated = 'pettycashoperation' " +
                         " + '§' + convert(varchar(4), idpettycash) + '§' + " +
                         " convert(varchar(4), yoperation) + '§' + " +
                         " convert(varchar(14), noperation)) " +
                         " and not exists " +
                         " (select * from epexp where idrelated = 'pettycashoperation' + " +
                         " '§' +  " +
                         " convert(varchar(4), idpettycash) + '§' + " +
                         " convert(varchar(4), yoperation) + '§' +  " +
                         " convert(varchar(14), noperation)) " +
                         " AND " + QHS.CmpEq("yoperation", Conn.GetEsercizio()) +
                         " AND pettycashoperationview.kind NOT IN('A', 'R', 'C') " +
                         " ORDER BY pettycash, yoperation, noperation ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnOpFondoEconomaleNoEntry.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnImpBudgetDoppiati_Click(object sender, EventArgs e) {
            /*
             * Ottavo controllo: Impegni di budget doppiati
               Esportare tutte le fatture di acquisto che non sono collegate a contratto passivo per errore o dimenticanza. 
               Questo controllo si potrebbe basare sui movimenti finanziari, ovvero mostrare le fatture non collegate 
               a contratto passivo ma che sono state pagate a partire da un impegno finanziario sul quale 
               è presente un contratto passivo (Come il pulsante presente nel dettaglio della fattura – 
               collega a dettaglio contratto passivo). L’esportazione deve mostrare oltre al numero di riga fattura, 
               fornitore ecc, anche la riga del pagamento al quale la riga è legata, l’impegno e il contratto passivo legato.
             * */
            string sql = @"


 SELECT  'Fattura' as 'Documento', IK.description as 'Tipo', I.yinv as 'Esercizio',  I.ninv as 'Numero', 
  I.detaildescription as 'Descr. Dettaglio', I.rownum as 'Num. riga',  II.adate as 'Data contabile',
	F.description as 'Fase', E.ymov as 'Anno mov.',E.nmov as 'N.mov.',
	
    R.title as 'Anagrafica' ,   EM.idmankind as 'Tipo contratto passivo', 
	  EM.yman as 'Eserc. Contratto Passivo',  EM.nman as 'Num. Contratto Passivo' 
	   from invoicedetail I 
		join expenselink EL on (EL.idchild in (I.idexp_taxable,I.idexp_iva))
		join expensemandate EM on EM.idexp=EL.idparent		
	JOIN invoicekind IK on i.idinvkind=IK.idinvkind
	join invoice II on II.idinvkind=I.idinvkind and II.yinv=I.yinv and II.ninv=I.ninv
	join registry R on II.idreg=R.idreg
	join expense E on E.idexp=EL.idparent
	join expensephase F on E.nphase=F.nphase
WHERE 
	(I.idexp_iva is not null or I.idexp_taxable is not null) and
	I.idmankind is null and
	exists (select * from  mandatedetail  MD 
			where EM.idmankind=MD.idmankind and EM.yman=MD.yman and EM.nman=MD.nman 
						and (EM.idexp in (MD.idexp_iva,MD.idexp_taxable))
						and MD.idepexp is not null
			) AND
	NOT EXISTS (select * from profservice   where idinvkind = I.idinvkind 
			  and  yinv = I.yinv and  ninv = I.ninv) 
  AND " + QHS.CmpEq("I.yinv", Conn.GetEsercizio()) + " AND ISNULL( I.rounding,'N') = 'N'  " +
                         "ORDER BY  IK.description , I.yinv,  I.ninv,  I.rownum ";



            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnImpBudgetDoppiati.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnPrevBudgetSforata_Click(object sender, EventArgs e) {
            string sql = " SELECT " +
                         " ayear as 'Esercizio', codeacc as 'Cod. Conto', account as 'Conto', " +
                         " codeupb as 'Cod. UPB', upb as 'UPB', manager as 'Responsabile', " +
                         " currentprev as 'Previsione corrente', " +
                         " epexp1 as 'Tot. Preimpegni', " +
                         " epexp2 as 'Tot. Impegni', " +
                         " available as 'Disponibile' " +
                         " from upbaccountview " +
                         " WHERE " + QHS.CmpEq("ayear", Conn.GetEsercizio()) +
                         " AND ISNULL(available,0) <  0 ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnPrevBudgetSforata.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnScrittureCostoSenzaImpBudget_Click(object sender, EventArgs e) {
            string sql = " SELECT " +
                         " yentry as 'Esercizio', nentry as 'Numero', ndetail as '#Riga', " +
                         " codeacc as 'Codice Conto', account as 'Conto', " +
                         " codeupb as 'Cod. UPB', upb as 'UPB', " +
                         " registry as 'Anagrafica', " +
                         " description as 'Descr, Scritura', " +
                         " detaildescription as 'Descr. Dettaglio', " +
                         " give as 'Dare', " +
                         " have as 'Avere', " +
                         " idrelated as '#IdRelated', entrydetailview.idepexp " +
                         " from entrydetailview " +
                         " WHERE " + QHS.CmpEq("yentry", Conn.GetEsercizio()) +
                         " AND idepexp is null " +
                         " AND ((flagaccountusage & 64) <> 0) ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epexp";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnScrittureCostoSenzaImpBudget.Text, t,
                    Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnImpBudgetDispNegativo_Click(object sender, EventArgs e) {

            string sql = " SELECT " +
                         " ayear as 'Esercizio', phase as 'Fase', " +
                         " yepexp as 'Eserc. Impegno', nepexp as 'Num. Impegno', " +
                         " codeacc as 'Cod. Conto', account as 'Conto', " +
                         " codeupb as 'Cod. UPB', upb as 'UPB', " +
                         " registry as 'Anagrafica', doc as 'Doc.', docdate as 'Data Doc.', " +
                         " available as 'Disponibile', epexpview.idepexp " +
                         " from epexpview " +
                         " WHERE " + QHS.CmpEq("ayear", Conn.GetEsercizio()) +
                         " AND isnull(available, 0) < 0 ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epexp";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnImpBudgetDispNegativo.Text, t, Meta.Dispatcher,
                    "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnIncoerenzeImportoContrPassivoFattura_Click(object sender, EventArgs e) {

            string sql = " SELECT " +
                         " invoicekind.codeinvkind as 'Cod. Tipo Fattura',	invoicekind.description as 'Descrizione', " +
                         " invoicedetail.yinv as 'Esercizio',invoicedetail.ninv as 'Numero', " +
                         " CASE " +
                         " WHEN((invoicekind.flag & 1) = 0) THEN 'A' " +
                         " WHEN((invoicekind.flag & 1) <> 0) THEN 'V' " +
                         " END as 'Acquisto/Vendita', " +
                         " CASE " +
                         " WHEN((invoicekind.flag & 4) = 0) THEN 'N' " +
                         " WHEN((invoicekind.flag & 4) <> 0) THEN 'S' " +
                         " END as 'Nota di Variazione', " +
                         " invoice.exchangerate as 'Tasso di Cambio',	" +
                         " invoicedetail.rownum as '#Riga', invoicedetail.idgroup as '#Gruppo', " +
                         " registry.title as 'Anagrafica', invoicedetail.detaildescription as 'Descr. Dettaglio', " +
                         " ivakind.description as 'Tipo Iva', ivakind.rate as 'Aliquota', " +
                         " CONVERT(decimal(19, 2), " +
                         " ROUND(invoicedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) , 2 )) as 'Importo Unitario Dettaglio Fattura', " +
                         " CONVERT(decimal(19, 2), " +
                         " ROUND(mandatedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) , 2  )) " +
                         " as 'Importo Unitario Dett. Contratto Passivo', " +
                         "CONVERT(decimal(19, 2),ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage, invoicedetail.number) * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) *" +
                         "(1 - CONVERT(DECIMAL(19, 6), ISNULL(invoicedetail.discount, 0.0))), 2)) as 'Imponibile Dettaglio Fattura'," +
                         "ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage, mandatedetail.number) *" +
                         "CONVERT(DECIMAL(19, 6), mandate.exchangerate) *" +
                         "(1 - CONVERT(DECIMAL(19, 6), ISNULL(mandatedetail.discount, 0.0))), 2) as 'Imponibile Dett. Contratto Passivo'" +
                         " FROM invoicedetail " +
                         " JOIN ivakind  ON ivakind.idivakind = invoicedetail.idivakind " +
                         " JOIN invoice  ON invoice.ninv = invoicedetail.ninv " +
                         " AND invoice.yinv = invoicedetail.yinv " +
                         " AND invoice.idinvkind = invoicedetail.idinvkind " +
                         " JOIN invoicekind  ON invoicekind.idinvkind = invoicedetail.idinvkind " +
                         " JOIN registry   ON registry.idreg = invoice.idreg " +
                         " LEFT OUTER JOIN mandatedetail  ON invoicedetail.idmankind = mandatedetail.idmankind " +
                         " AND invoicedetail.yman = mandatedetail.yman " +
                         " AND invoicedetail.nman = mandatedetail.nman " +
                         " AND invoicedetail.manrownum = mandatedetail.rownum " +
                         " LEFT OUTER JOIN mandate ON mandate.idmankind = mandatedetail.idmankind " +
                         " AND mandate.yman = mandatedetail.yman " +
                         " AND mandate.nman = mandatedetail.nman " +
                         " WHERE CONVERT(decimal(19, 2), " +
                         " ROUND(invoicedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) " +
                         "  , 2  )) <> " +
                         " CONVERT(decimal(19, 2), " +
                         " ROUND(mandatedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) " +
                         " , 2)) " +
                         " AND" + QHS.CmpEq("invoicedetail.yinv ", Conn.GetEsercizio()) +
                         " AND invoicedetail.idmankind IS NOT NULL ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnIncoerenzeImportoContrPassivoFattura.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnIncoerenzeAliquotaContrPassivoFattura_Click(object sender, EventArgs e) {
            string sql = " SELECT " +
                         " invoicekind.codeinvkind as 'Cod. Tipo Fattura',	invoicekind.description as 'Descrizione', " +
                         " invoicedetail.yinv as 'Esercizio',invoicedetail.ninv as 'Numero', " +
                         " CASE " +
                         " WHEN((invoicekind.flag & 1) = 0) THEN 'A' " +
                         " WHEN((invoicekind.flag & 1) <> 0) THEN 'V' " +
                         " END as 'Acquisto/Vendita', " +
                         " CASE " +
                         " WHEN((invoicekind.flag & 4) = 0) THEN 'N' " +
                         " WHEN((invoicekind.flag & 4) <> 0) THEN 'S' " +
                         " END as 'Nota di Variazione', " +
                         " invoice.exchangerate as 'Tasso di Cambio',	" +
                         " invoicedetail.rownum as '#Riga', invoicedetail.idgroup as '#Gruppo', " +
                         " registry.title as 'Anagrafica', invoicedetail.detaildescription as 'Descr. Dettaglio', " +
                         " CONVERT(decimal(19, 2), " +
                         " ROUND(invoicedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) , 2 )) as 'Imponibile Unitario', " +
                         " CONVERT(decimal(19, 2), " +
                         " ROUND(mandatedetail.taxable * " +
                         " CONVERT(DECIMAL(19, 10), invoice.exchangerate) , 2  )) " +
                         " as 'Imponibile Unitario Dett. Contratto Passivo', " +
                         " ivakind.description as 'Tipo Iva', ivakind.rate as 'Aliquota', " +
                         " ivakind2.description as 'Tipo Iva Dett. Contr. Passivo', ivakind2.rate as 'Aliquota Dett. Contr. Passivo'  " +

                         " FROM invoicedetail " +
                         " JOIN ivakind  ON ivakind.idivakind = invoicedetail.idivakind " +
                         " JOIN invoice  ON invoice.ninv = invoicedetail.ninv " +
                         " AND invoice.yinv = invoicedetail.yinv " +
                         " AND invoice.idinvkind = invoicedetail.idinvkind " +
                         " JOIN invoicekind ON invoicekind.idinvkind = invoicedetail.idinvkind " +
                         " JOIN registry   ON registry.idreg = invoice.idreg " +
                         " LEFT OUTER JOIN mandatedetail  ON invoicedetail.idmankind = mandatedetail.idmankind " +
                         " AND invoicedetail.yman = mandatedetail.yman " +
                         " AND invoicedetail.nman = mandatedetail.nman " +
                         " AND invoicedetail.manrownum = mandatedetail.rownum " +
                         " JOIN ivakind ivakind2 ON ivakind2.idivakind = mandatedetail.idivakind " +
                         " LEFT OUTER JOIN mandate ON mandate.idmankind = mandatedetail.idmankind " +
                         " AND mandate.yman = mandatedetail.yman " +
                         " AND mandate.nman = mandatedetail.nman " +
                         " WHERE  	ivakind.rate <> ivakind2.rate " +
                         " AND" + QHS.CmpEq("invoicedetail.yinv ", Conn.GetEsercizio()) +
                         " AND invoicedetail.idmankind IS NOT NULL ";


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnIncoerenzeAliquotaContrPassivoFattura.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDettContrPassiviIncoerentiImpBudget_Click(object sender, EventArgs e) {
            var param = new[] {Meta.GetSys("esercizio")};
            var ds = Conn.CallSP("exp_mandatedetail_epexp", param, true);
            if (ds == null || ds.Tables.Count == 0) {
                show(this, "Nessun problema riscontrato", "Avviso");
                return;
            }
            frmErrorView f = new frmErrorView(Meta.myHelpForm, btnDettContrPassiviIncoerentiImpBudget.Text,
                ds.Tables[0]);
            createForm(f, this);
			f.Show(this);
        }

        private void btnPagamentiNonCollegatiDoc_Click(object sender, EventArgs e) {
            var param = new[] {Meta.GetSys("esercizio")};
            var ds = Conn.CallSP("exp_expenselast_no_doc", param, true);
            if (ds == null || ds.Tables.Count == 0) {
                show(this, "Nessun problema riscontrato", "Avviso");
                return;
            }
            frmErrorView f = new frmErrorView(Meta.myHelpForm, btnPagamentiNonCollegatiDoc.Text, ds.Tables[0]);
            createForm(f, this);
			f.Show(this);
        }

        private void btnIncassiNonCollegatiDoc_Click(object sender, EventArgs e) {
            var param = new[] {Meta.GetSys("esercizio")};
            var ds = Conn.CallSP("exp_incomelast_no_doc", param, true);
            if (ds == null || ds.Tables.Count == 0) {
                show(this, "Nessun problema riscontrato", "Avviso");
                return;
            }
            frmErrorView f = new frmErrorView(Meta.myHelpForm, btnIncassiNonCollegatiDoc.Text, ds.Tables[0]);
            createForm(f, this);
			f.Show(this);
        }

        private void btnDettContrPassiviCompetenza_Click(object sender, EventArgs e) {
            string sql = " select mankind as 'Tipo Contr. Passivo', yman as 'Esercizio', nman as 'Numero', " +
                         " idgroup as '#Gruppo', rownum as '#Riga', registry as 'Anagrafica', detaildescription as 'Descr. Dettaglio', " +
                         " codemotive as 'Cod. Causale', competencystart as 'Inizio Compet.', competencystop as 'Fine Compet.'" +
                         " from mandatedetailview " +
                         " join accmotivedetail " +
                         " on accmotivedetail.idaccmotive = mandatedetailview.idaccmotive " +
                         " join account on account.idacc = accmotivedetail.idacc " +
                         " WHERE" + QHS.CmpEq("mandatedetailview.yman ", Conn.GetEsercizio()) +
                         " AND" + QHS.CmpEq("account.ayear ", Conn.GetEsercizio()) +
                         " AND account.flagcompetency = 'S' " +
                         " AND (competencystart is null or competencystop is null) ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnDettContrPassiviCompetenza.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDettFattureCompetenza_Click(object sender, EventArgs e) {
            string sql = " select invoicekind as 'Tipo Doc. Iva', yinv as 'Esercizio', ninv as 'Numero', " +
                         " flagbuysell as 'Acquisto/Vendita', flagvariation as 'Nota di credito', " +
                         " idgroup as '#Gruppo', rownum as '#Riga', registry as 'Anagrafica', detaildescription as 'Descr. Dettaglio', " +
                         " codemotive as 'Cod. Causale', competencystart as 'Inizio Compet.', competencystop as 'Fine Compet.'" +
                         " from invoicedetailview " +
                         " join accmotivedetail " +
                         " on accmotivedetail.idaccmotive = invoicedetailview.idaccmotive " +
                         " join account on account.idacc = accmotivedetail.idacc " +
                         " WHERE" + QHS.CmpEq("invoicedetailview.yinv ", Conn.GetEsercizio()) +
                         " AND" + QHS.CmpEq("account.ayear ", Conn.GetEsercizio()) +
                         " AND account.flagcompetency = 'S' " +
                         " AND (competencystart is null or competencystop is null) ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnDettFattureCompetenza.Text, t);
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnScrittureRicavoSenzaAccBudget_Click(object sender, EventArgs e) {
            string sql = " SELECT " +
                         " yentry as 'Esercizio', nentry as 'Numero', ndetail as '#Riga', " +
                         " codeacc as 'Codice Conto', account as 'Conto', " +
                         " codeupb as 'Cod. UPB', upb as 'UPB', " +
                         " registry as 'Anagrafica', " +
                         " description as 'Descr, Scritura', " +
                         " detaildescription as 'Descr. Dettaglio', " +
                         " give as 'Dare', " +
                         " have as 'Avere', " +
                         " idrelated as '#IdRelated' ,entrydetailview.idepacc" +
                         " from entrydetailview " +
                         " WHERE " + QHS.CmpEq("yentry", Conn.GetEsercizio()) +
                         " AND idepacc is null " +
                         " AND ((flagaccountusage & 128) <> 0) ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epacc";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnScrittureRicavoSenzaAccBudget.Text, t,
                    Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void exp1_Click(object sender, EventArgs e) {

            CallExportForm("exp_entry_onparentaccount");

        }

        private void exp2_Click(object sender, EventArgs e) {
            CallExportForm("exp_document_no_entry");
        }

        
        private void exp3_Click(object sender, EventArgs e) {
            CallExportForm("exp_document_multiple_entry");
        }




        /// <summary>
        /// Call meta_export with store procedre name in input 
        /// </summary>
        /// <param name="StoreProcedureName"></param>
        private void CallExportForm(string spname) {
            Meta.Dispatcher.Edit(this, "export", "default", false, spname);
        }

        private void btnBuoniCarico_Click(object sender, EventArgs e) {

            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yassetload", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("assetload", "idassetload,idassetloadkind, yassetload,nassetload", "adate", filter,
                    null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idassetload")) || !(t.Columns.Contains("idassetloadkind")) ||
                    !(t.Columns.Contains("adate"))
                    || !(t.Columns.Contains("yassetload")) || !(t.Columns.Contains("nassetload"))) return;
                t.TableName = "assetload";
            }


            btnBuoniCarico.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("assetloadDS");
                DataTable T = Conn.RUN_SELECT("assetload", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;

                DataRow rv = T.Rows[0];
                D.Tables.Add(T);
                DataTable T1 = Conn.RUN_SELECT("assetacquireview", "*", null, QHS.CmpKey(r), null, false);
                D.Tables.Add(T1);
                txtCurrent.Text = "Buono di carico tipo id " + r["idassetloadkind"] + " n." + r["nassetload"];
                rigeneraScrittura(T.Rows[0], "assetload");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnBuoniCarico.Visible = true;
        }

        private void btnBuoniScarico_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yassetunload", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("assetunload", "idassetunloadkind, idassetunload,yassetunload,nassetunload",
                    "adate", filter, null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idassetunload")) || !(t.Columns.Contains("idassetunloadkind")) ||
                    !(t.Columns.Contains("adate"))
                    || !(t.Columns.Contains("yassetunload")) || !(t.Columns.Contains("nassetunload"))) return;
                t.TableName = "assetunload";
            }

            btnBuoniScarico.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("assetunloadDS");
                DataTable T = Conn.RUN_SELECT("assetunload", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;

                DataRow rv = T.Rows[0];
                D.Tables.Add(T);
                DataTable T1 = Conn.RUN_SELECT("assetpieceview", "*", null, QHS.CmpKey(r), null, false);
                D.Tables.Add(T1);
                DataTable T2 = Conn.RUN_SELECT("assetamortizationunloadview", "*", null, QHS.CmpKey(r), null, false);
                D.Tables.Add(T2);

                txtCurrent.Text = "Buono di scarico tipo id " + r["idassetunloadkind"] + ") n." + r["nassetunload"];
                rigeneraScrittura(T.Rows[0], "assetunload");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnBuoniScarico.Visible = true;
        }

        private void btnReimpostaQuery_Click(object sender, EventArgs e) {
            txtComando.Text = "";
        }

        private void btnTrg_evaluatearrearsepacc_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("ayear", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("epaccview", "idepacc, ayear", "adate", filter, null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idepacc")) || !(t.Columns.Contains("ayear"))) return;
                t.TableName = "epaccview";
            }

            btnTrg_evaluatearrearsepacc.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Select(filter)) {
                txtCurrent.Text = "Ricalcolo Accertamento id " + r["idepacc"] + ") esercizio." + r["ayear"];
                var param = new[] {r["idepacc"], Meta.GetSys("esercizio")};
                Conn.CallSP("trg_evaluatearrearsepacc", param, true);
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnTrg_evaluatearrearsepacc.Visible = true;
        }

        /// <summary>
        /// Accertamenti di Budget con idrelated che non punta ad un contratto attivo esistente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamentiBudgetNoEstimate_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct EA.idrelated as 'Id Rel',EA.idepacc as 'Idepacc',EA.nepacc as 'Numero Accertamento'," +
                    " EA.yepacc as 'Eserc. creaz. Accertamento',EA.ayear as 'Esercizio', "+
                    " EA.description as 'descrizione',EA.amount as 'importo', EA.phase as 'fase' "+
                    " from epaccview EA " +
                    " join account A on EA.idacc = A.idacc " +
                    " where " + //"A.flagenablebudgetprev = 'N' and EA.curramount <> 0 and \r\n\t\t" +
                    " not exists(select * from estimatedetailview ESTD  where EA.idrelated = " +
                    " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' +  " +
                    " convert(varchar(30), ESTD.yestim) + '§' +  " +
                    " convert(varchar(30), ESTD.nestim) + '§' +  " +
                    " convert(varchar(30), ESTD.rownum) ) " +
                    " and EA.idrelated like 'estim§%'  " +
                    " and EA.totcurramount> 0" +
                    " and EA.yepacc= "+esercizio +
                    " and EA.ayear = " + esercizio;
            ;
            DataTable t = Conn.SQLRunner(sql,false,0);           
            if (t?.Rows.Count > 0) {
                t.TableName = "epacc";
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiBudgetNoEstimate.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Accertamenti di Budget con idrelated che non punta ad una fattura esistente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamentiBudgetNoInvoice_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct EA.idrelated as \'Id Rel\',EA.idepacc ,EA.nepacc as \'Numero Accertamento\'," +
                    " EA.yepacc as \'Eserc. creaz. Accertamento\',EA.ayear as \'Esercizio\', "+
                    " EA.description as 'descrizione',EA.amount as 'importo', EA.phase as 'fase' " +
                    " from epaccview EA \r\n\t\t" +
                    " join account A on EA.idacc = A.idacc " +
                    " where " + //"A.flagenablebudgetprev = 'N' and EA.curramount <> 0 \r\n\t\t" +
                    "  not exists(select * from invoicedetailview INVD  where EA.idrelated = " +
                    " 'inv§' + convert(varchar(30), INVD.idinvkind) + '§' + " +
                    " convert(varchar(30), INVD.yinv) + '§' + " +
                    " convert(varchar(30), INVD.ninv) + '§' + " +
                    " convert(varchar(30), INVD.rownum) ) " +
                    " and EA.idrelated like 'inv§%' " +
                    " and EA.totcurramount> 0" +
                    " and EA.yepacc= " + esercizio +
                    " and EA.ayear = " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
           
            if (t?.Rows.Count > 0) {
                t.TableName = "epacc";
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiBudgetNoInvoice.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Accertamenti di Budget su conti NON associati a previsione di Budget
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamentiBudgetEstimate_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct EA.idrelated as \'Id Rel\',EA.idepacc ,EA.nepacc as \'Numero Accertamento\'," +
                    " EA.yepacc as \'Eserc. creaz. Accertamento\',EA.ayear as \'Esercizio\', EA.codeupb as \'Cod UPB\', EA.upb  as \'UPB\', " +
                    " EA.codeacc as  \'Cod Conto EP\', EA.account  as \'Conto EP\' from epaccview EA  " +
                    " join account A on EA.idacc = A.idacc  " +
                    " join estimatedetailview ESTD  on  EA.idrelated =  " +
                    " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' +  " +
                    " convert(varchar(30), ESTD.yestim) + '§' +  " +
                    " convert(varchar(30), ESTD.nestim) + '§' +  " +
                    " convert(varchar(30), ESTD.rownum)  " +
                    " where A.flagenablebudgetprev = 'N' and EA.curramount <> 0 " +
                    " and EA.ayear = " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            
            if (t?.Rows.Count > 0) {
                t.TableName = "epacc"; DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiBudgetEstimate.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Scritture in pd di il cui accertamento collegato tramite chiave è diverso da quello dell'idrelated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamentiIncoerentiIdrelated_Click(object sender, EventArgs e) {
            //string sql =
            //        " select ED.yentry,ED.nentry,ED.idepacc, \r\n\t\t " +
            //        " ED.idepacc 'acc.scrittura',ESTD.idepacc 'acc.dettaglio contratto',ED.idrelated,\r\n\t\t " +
            //        " ED.description 'dettaglio scrittura',ESTD.detaildescription 'dettaglio contratto', \r\n\t\t" +
            //        " E1.description 'accert.scrittura',E2.description 'accertamento dett.contratto',\r\n\t\t " +
            //        " ED.amount 'dettaglio scrittura',EY1.amount 'accertamento scrittura',EY2.amount 'accertamento contratto', \r\n\t\t" +
            //        " ED.ndetail, ED.lt,ED.lu \r\n\t\t" +
            //        " from entrydetail ED \r\n\t\t" +
            //        " left outer join estimatedetail ESTD on ED.idrelated = \r\n\t\t" +
            //        " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + \r\n\t\t" +
            //        " convert(varchar(30), ESTD.yestim) + '§' + \r\n\t\t" +
            //        " convert(varchar(30), ESTD.nestim) + '§' + \r\n\t\t" +
            //        " convert(varchar(30), ESTD.rownum)\r\n\t\t " +
            //        " left outer join epacc E1 on  E1.idepacc = ED.idepacc \r\n\t\t" +
            //        " left outer join epaccyear EY1 on  EY1.idepacc = ED.idepacc and EY1.ayear = ED.yentry \r\n\t\t" +
            //        " left outer join epacc E2 on  E2.idepacc = ESTD.idepacc\r\n\t\t " +
            //        " left outer join epaccyear EY2 on  EY2.idepacc = ESTD.idepacc and EY2.ayear = ED.yentry\r\n\t\t " +
            //        " where ED.idrelated like 'estim%' and isnull(ED.idepacc, 0)<> isnull(ESTD.idepacc, 0)\r\n\t\t " +
            //        " and ED.yentry = " + esercizio +
            //        " order by ED.lt,ED.yentry,ED.nentry ";

            string sql = $@"
                    select e1.idepacc,e2.idepacc, /*a.idacc,*/ a.codeacc 'conto scrittura',
            /*a2.idacc,*/ a2.codeacc 'conto acc. idepacc',
            /*a3.idacc,*/ a3.codeacc 'conto acc. idrel',
            entrydetail.idrelated 'idrel scrittura',
            e1.idrelated 'idrel acc.scrittura',
            entrydetail.amount 'imp.scrittura', ey1.amount 'imp. conto idepacc', ey2.amount ' imp. conto idrel',
            entrydetail.description 'descr.scrittura', e1.description 'desc. acc. idepacc', e2.description 'descr. acc idrel',
            a.title,* from entrydetail
                    left outer
                    join epacc e1 on entrydetail.idepacc = e1.idepacc
 
            left outer join epaccyear ey1 on e1.idepacc = ey1.idepacc and ey1.ayear = {esercizio}
            left outer join epacc e2 on entrydetail.idrelated = e2.idrelated and e2.nphase = 2
            left outer join epaccyear ey2 on e2.idepacc = ey2.idepacc and ey2.ayear = {esercizio}
            left outer join account a on entrydetail.idacc = a.idacc
            left outer join account a2 on a2.idacc = ey1.idacc
            left outer join account a3 on a3.idacc = ey2.idacc
            left outer join accmotive aa on entrydetail.idaccmotive = aa.idaccmotive
            left outer join accmotive aa2 on aa2.idaccmotive = e1.idaccmotive
            left outer join accmotive aa3 on aa3.idaccmotive = e2.idaccmotive

            where e1.idepacc<> e2.idepacc and entrydetail.yentry = {esercizio} and(a.flagaccountusage & 128) <> 0  and e1.idrelated<> e2.idrelated
                 ";
                 DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiIncoerentiIdrelated.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Accertamenti di budget  collegati dall'inserisci copia a dettagli contratti attivi ma in realtà collegati ad altri dettagli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamentiBudget_1_Click(object sender, EventArgs e) {
            string sql = " select  " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) as 'ipotetico idrelated', " +
                         " E1.idrelated 'idrelated accertamento effettivo', * " +
                         " from estimatedetail ESTD " +
                         " join epaccview E1 on E1.idepacc = ESTD.idepacc and E1.ayear = isnull(year(ESTD.start), ESTD.yestim)" +
                         " left outer join accmotivedetail AMD on AMD.idaccmotive = ESTD.idaccmotive and " +
                         " AMD.ayear = isnull(year(ESTD.start), ESTD.yestim)" +
                         " left outer join account A on AMD.idacc = A.idacc" +
                         " left outer join epaccview E2 on E2.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) and E2.nphase=E1.nphase and E2.ayear=E1.ayear " +
                         " where isnull(E1.idrelated, '') <> 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum)" +
                         " and ESTD.stop is null and E1.nphase=2 " +
                         " and E1.ayear=" + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epacc";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiBudget_1.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

       


        /// <summary>
        /// Accertamenti di Budget con dati incoerenti rispetto ai contratti a cui sono collegati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccertamenti_3_Click(object sender, EventArgs e) {
            string sql = "select EA.yepacc,EA.nepacc,EA.nphase," +
                         " EA.idrelated, EA.ayear,EA.description,ESTD.detaildescription,"+
                         "EA.totcurramount, ESTD.taxable_euro, "+
                         "EA.idreg, ESTD.idreg,"+
                         " EA.idepacc, ESTD.idepacc, " +
                         " *" +
                         " from epaccview EA " +
                         " join estimatedetailview ESTD  on EA.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " where  ( "+
                            "(EA.description <> ESTD.detaildescription)  " +
                               "OR (EA.totcurramount <> ESTD.taxable_euro) "+
                               " or (isnull(EA.idreg,ESTD.idreg)<> isnull(ESTD.idreg,0))"+
                            ")  " +
                         " and EA.ayear = isnull(year(ESTD.start), ESTD.yestim) and EA.nphase = 2  " +                   
                         " and ESTD.stop is null " +
                         " and EA.ayear = " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epacc";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamenti_3.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

		private void btnImpegni_3_Click(object sender, EventArgs e) {
			string sql = "select EP.yepexp,EP.nepexp,EP.nphase," +
						 " EP.idrelated, EP.ayear,EP.description,MAND.detaildescription,"+
						 "EP.totcurramount, MAND.taxable_euro, "+
						 "EP.idreg, MAND.idreg,"+
						 " EP.idepexp, MAND.idepexp, " +
						 " *" +
						 " from epexpview EP " +
						 " join mandatedetailview MAND  on EP.idrelated = " +
						 " 'man§' + convert(varchar(30), MAND.idmankind) + '§' + " +
						 " convert(varchar(30), MAND.yman) + '§' + " +
						 " convert(varchar(30), MAND.nman) + '§' + " +
						 " convert(varchar(30), MAND.rownum) " +
						 " where  ( "+
							"(EP.description <> MAND.detaildescription)  " +
                               "OR ((EP.totcurramount <> MAND.taxable_euro) and flagactivity <>1) " +
                               "OR ((EP.totcurramount <> MAND.rowtotal) and flagactivity =1 ) " +
                               " or (isnull(EP.idreg,MAND.idreg)<> isnull(MAND.idreg,0))" +
							")  " +
						 " and EP.ayear = isnull(year(MAND.start), MAND.yman) and EP.nphase = 2  " +
						 " and MAND.stop is null " +
						 " and EP.ayear = " + esercizio;

			DataTable t = Conn.SQLRunner(sql, false, 0);
			if (t?.Rows.Count > 0) {
				DataSet d = new DataSet();
				d.Tables.Add(t);
				t.TableName = "epexp";
				frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamenti_3.Text, t, Meta.Dispatcher, "default");
				createForm(f, this);
				f.Show(this);
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}

		private void btnNoBudgetSuspect_Click(object sender, EventArgs e) {
            string sql = "  select* from account where flagenablebudgetprev = 'N' " +
                         "and(flagaccountusage & (64 + 128 + 256)) <> 0 " +
                         "and(not exists(select * from account A2 where A2.paridacc = account.idacc)) " +
                         "and account.ayear =" + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "account";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtNoBudgetSuspect.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnBudgetSuspect_Click(object sender, EventArgs e) {
            //esistenti sotto altre forme incoerenti con l'accertamento stesso
            string sql = "  select* from account where flagenablebudgetprev = 'S' " +
                         "and(flagaccountusage & (64 + 128 + 256)) = 0 " +
                         "and(not exists(select * from account A2 where A2.paridacc = account.idacc)) " +
                         "and account.ayear =" + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "account";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtBudgetSuspect.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Prova a correggere accertamenti di Budget con dati incoerenti rispetto ai contratti a cui sono collegati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCorreggiCAttiviIncoerenti_Click(object sender, EventArgs e) {
            string sql = "select EA.idepacc,ESTD.idestimkind,ESTD.yestim, ESTD.nestim " +
                         " from epaccview EA " +
                         " join estimatedetailview ESTD  on EA.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " where  ((EA.description <> ESTD.detaildescription)  " +
                         "OR (EA.totcurramount <> ESTD.taxable_euro) or (isnull(EA.idreg,ESTD.idreg)<> isnull(ESTD.idreg,0)))  " +
                         " and EA.ayear = isnull(year(ESTD.start), ESTD.yestim) and EA.nphase = 2   and ESTD.stop is null and ESTD.stop is null" +
                         " and EA.ayear = isnull(year(ESTD.start), ESTD.yestim) and EA.nphase = 2  " +
                         " and ESTD.stop is null " +
                         " and EA.ayear = " + esercizio;

            DataTable elencoAccertamentiBudget = Conn.SQLRunner(sql, false, 0);
            int maxEsercizioEP = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", null, "max(ayear)"));
            if (elencoAccertamentiBudget.Rows.Count > 0) {
                DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);

                progBar.Maximum = elencoAccertamentiBudget.Rows.Count;
                progBar.Value = 0;
                var cAttiviElaborati = new Dictionary<string, bool>();
                foreach (DataRow rAccBudget in elencoAccertamentiBudget.Rows) {
                    int lastVal = progBar.Value;
                    //Risalva il contratto attivo collegato
                    string keyCattivo = $"{rAccBudget["idestimkind"]}§{rAccBudget["yestim"]}§{rAccBudget["nestim"]}§";
                    bool checkFatture = false;
                    if (!cAttiviElaborati.ContainsKey(keyCattivo)) {
                        cAttiviElaborati.Add(keyCattivo, true);
                        //Risalva il c.attivo in questione
                        rigeneraContrattoAttivo(rAccBudget);
                        progBar.Value = lastVal;
                        checkFatture = true;

                    }
                    //Per ogni esercizio fino all'ultimo a partire dall'attuale:
                    for (int ayear = Conn.GetEsercizio(); ayear <= maxEsercizioEP; ayear++) {
                        //ricalcola  i totali dell'anno sull'accertamento in questione    
                        Conn.CallSP("rebuild_epacctotal_idmov", new[] { ayear, rAccBudget["idepacc"] });

                        //ricalcola i residui dell'accertamento ove vi sia un anno successivo
                        if (ayear < maxEsercizioEP) {
                            Conn.CallSP("trg_evaluatearrearsepacc", new[] {rAccBudget["idepacc"], ayear});
                        }
                    }

                    //Risalva eventuali fatture collegate  al c.attivo, nell'anno corrente
                    if (checkFatture) {
                        var tFatture = Conn.RUN_SELECT("invoiceestimateview", "*", null,
                            QHS.MCmp(rAccBudget, "idestimkind", "yestim", "nestim"), null, null, false);
                        if (tFatture?.Rows.Count > 0) {

                            foreach (DataRow rFatt in tFatture.Rows) {
                                DataTable inv = Conn.RUN_SELECT("invoiceview",
                                    "idinvkind, yinv, ninv, codeinvkind, invoicekind", null,
                                    QHS.MCmp(rFatt, "idinvkind", "yinv", "ninv"), null, false);

                                rigeneraFattura(inv.Rows[0], invkind);
                                progBar.Value = lastVal;
                            }
                        }
                    }





                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
                show(this, "Operazione terminata", "Avviso");
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }



		private void btnCorreggiCPassiviIncoerenti_Click(object sender, EventArgs e) {
			string sql = "select EP.idepexp,MAND.idmankind,MAND.yman, MAND.nman " +
						 " from epexpview EP " +
						 " join mandatedetailview MAND  on EP.idrelated = " +
						 " 'man§' + convert(varchar(30), MAND.idmankind) + '§' + " +
						 " convert(varchar(30), MAND.yman) + '§' + " +
						 " convert(varchar(30), MAND.nman) + '§' + " +
						 " convert(varchar(30), MAND.rownum) " +
						 " where  ((EP.description <> MAND.detaildescription)  " +
						 "OR (EP.totcurramount <> MAND.taxable_euro) or (isnull(EP.idreg,MAND.idreg)<> isnull(MAND.idreg,0)))  " +
						 " and EP.ayear = isnull(year(MAND.start), MAND.yman) and EP.nphase = 2   and MAND.stop is null and MAND.stop is null" +
						 " and EP.ayear = isnull(year(MAND.start), MAND.yman) and EP.nphase = 2  " +
						 " and MAND.stop is null " +
						 " and EP.ayear = " + esercizio;

			DataTable elencoImpegniBudget = Conn.SQLRunner(sql, false, 0);
			int maxEsercizioEP = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", null, "max(ayear)"));
			if (elencoImpegniBudget.Rows.Count > 0) {
				DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);

				progBar.Maximum = elencoImpegniBudget.Rows.Count;
				progBar.Value = 0;
				var cPassiviElaborati = new Dictionary<string, bool>();
				foreach (DataRow rImpBudget in elencoImpegniBudget.Rows) {
					int lastVal = progBar.Value;
					//Risalva il contratto attivo collegato
					string keyCPassivo = $"{rImpBudget["idmankind"]}§{rImpBudget["yman"]}§{rImpBudget["nman"]}§";
					bool checkFatture = false;
					if (!cPassiviElaborati.ContainsKey(keyCPassivo)) {
						cPassiviElaborati.Add(keyCPassivo, true);
						//Risalva il c.attivo in questione
						rigeneraContrattoAttivo(rImpBudget);
						progBar.Value = lastVal;
						checkFatture = true;

					}
					//Per ogni esercizio fino all'ultimo a partire dall'attuale:
					for (int ayear = Conn.GetEsercizio(); ayear <= maxEsercizioEP; ayear++) {
						//ricalcola  i totali dell'anno sull'impegno in questione    
						Conn.CallSP("rebuild_epexptotal_idmov", new[] { ayear, rImpBudget["idepexp"] });

						//ricalcola i residui dell'impegno ove vi sia un anno successivo
						if (ayear < maxEsercizioEP) {
							Conn.CallSP("trg_evaluatearrearsepexp", new[] { rImpBudget["idepexp"], ayear });
						}
					}

					//Risalva eventuali fatture collegate  al c.attivo, nell'anno corrente
					if (checkFatture) {
						var tFatture = Conn.RUN_SELECT("invoicemandateview", "*", null,
							QHS.MCmp(rImpBudget, "idmankind", "yman", "nman"), null, null, false);
						if (tFatture?.Rows.Count > 0) {

							foreach (DataRow rFatt in tFatture.Rows) {
								DataTable inv = Conn.RUN_SELECT("invoiceview",
									"idinvkind, yinv, ninv, codeinvkind, invoicekind", null,
									QHS.MCmp(rFatt, "idinvkind", "yinv", "ninv"), null, false);

								rigeneraFattura(inv.Rows[0], invkind);
								progBar.Value = lastVal;
							}
						}
					}





					progBar.Increment(1);
					progBar.Update();
					Application.DoEvents();
				}
				progBar.Value = 0;
				txtCurrent.Text = "";
				show(this, "Operazione terminata", "Avviso");
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}



		private void btnImpegniResiduiErrati_Click(object sender, EventArgs e) {
            string sql = "select epexp.yepexp as 'anno impegno', epexp.nepexp as 'n. impegno' , epexp.nphase as 'fase'," +
                            "AM.codemotive 'cod.causale', CurrA.codeacc as 'codice conto anno prec', CurrA.title as 'Conto anno prec.'," +
                          "actual.codeacc as 'codice conto anno curr.', actual.title as 'Conto anno curr.', " +
                         "NewA.codeacc as 'codice conto lookup', NewA.title as 'Conto anno lookup', " +
                          "epexp.* from epexp " +
                         " join epexpyear CurrEP  on epexp.idepexp = CurrEP.idepexp " +
                         " join epexpyear NewEP  on NewEP.idepexp = CurrEP.idepexp and NewEP.ayear = CurrEP.ayear + 1 " +
                         " join accountlookup lookup on CurrEP.idacc = lookup.oldidacc " +
                         " join account CurrA on CurrA.idacc = CurrEP.idacc " +
                         " join account NewA on NewA.idacc = lookup.newidacc " +
                         " join account actual on actual.idacc = NewEP.idacc " +
                         " left outer join accmotive AM on AM.idaccmotive  = epexp.idaccmotive " +
                         " where NewEP.idacc<> lookup.newidacc " +
                         " and NewEP.ayear= " + esercizio;

              


            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epexp";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtImpegniResiduiErrati.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnAccertamentiResiduiErrati_Click(object sender, EventArgs e) {
            string sql = "select  epacc.yepacc as 'anno accertamento', epacc.nepacc as 'n. accertamento' , epacc.nphase as 'fase', " +
                        "AM.codemotive 'cod.causale',CurrA.codeacc as 'codice conto anno prec', CurrA.title as 'Conto anno prec.'," +
                         "actual.codeacc as 'codice conto anno curr.', actual.title as 'Conto anno curr.', "+
                         "NewA.codeacc as 'codice conto lookup', NewA.title as 'Conto anno lookup', " +
                         "epacc.* from epacc " +
                         "join epaccyear CurrEP  on epacc.idepacc = CurrEP.idepacc " +
                         "join epaccyear NewEP on NewEP.idepacc = CurrEP.idepacc and NewEP.ayear = CurrEP.ayear + 1 " +
                         " join accountlookup lookup on CurrEP.idacc = lookup.oldidacc " +
                         " join account CurrA on CurrA.idacc = CurrEP.idacc " +
                         " join account NewA on NewA.idacc = lookup.newidacc " +
                         " join account actual on actual.idacc = NewEP.idacc "+
                         " left outer join accmotive AM on AM.idaccmotive  = epacc.idaccmotive " +
                         " where NewEP.idacc<> lookup.newidacc" +
                         " and NewEP.ayear= " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "epacc";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiResiduiErrati.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCostoContoDiverso_Click(object sender, EventArgs e) {
            string sql = "select "+
                         "Ik.description as 'tipo fattura',ID.yinv 'anno fatt.', ID.ninv 'n. fattura', ID.rownum 'riga fatt.'," +
                         " isnull(MD.idmankind,MD2.idmankind) 'tipo contratto', "+
                         "isnull(MD.yman,MD2.yman) 'anno c.', "+
                         "isnull(MD.nman,MD2.nman) 'n.c.', "+
                         "isnull(MD.rownum,MD2.rownum) 'riga c.'," +
                         " EE.yepexp as 'anno impegno', EE.nepexp as 'n.impegno', "  +
                         " A1.codeacc  'conto scritt.', A3.codeacc 'cc acc'," +
                         " AA1.codemotive  'cod. causale fatt.',AA2.codemotive 'cod. causale contr.',AA3.codemotive 'cod. causale imp'," +
                         " AA1.title  'cc. fatt.',AA2.title 'cc contr.',AA3.title 'cc impegno'," +
                        "* from entrydetail E    " +
                         " join account A on E.idacc = A.idacc " +
                         " join epexpyear EP on EP.idepexp = E.idepexp and E.yentry = EP.ayear " +
                         " join epexp EE on EE.idepexp = EP.idepexp  " +
                         " left outer join invoicedetail ID on E.idrelated = 'inv§'+" +
                          "convert(varchar(30),ID.idinvkind)+'§'+"+
                         "convert(varchar(30),ID.yinv)+'§'+" +
                         "convert(varchar(30),ID.ninv)+'§'+" +
                         "convert(varchar(30),ID.rownum) "+
                         " left outer join mandatedetail   MD on MD.idmankind=ID.idmankind and MD.yman=ID.yman and MD.nman=ID.nman and MD.rownum=ID.manrownum " +
                         " left outer join invoicekind ik on ik.idinvkind=ID.idinvkind "+
                         " left outer join mandatedetail MD2 on E.idrelated = 'man§'+" +
                         "convert(varchar(30),MD2.idmankind)+'§'+" +
                         "convert(varchar(30),MD2.yman)+'§'+" +
                         "convert(varchar(30),MD2.nman)+'§'+" +
                         "convert(varchar(30),MD2.rownum) " +
                         " join account A1 on A1.idacc=E.idacc " +
                         //join account A2 on A2.idacc=EP.idacc "+
                         " join account A3 on A3.idacc=EP.idacc " +
                         " left outer join accmotive AA1 on ID.idaccmotive = AA1.idaccmotive " +
                         " left outer join accmotive AA2 on isnull(MD.idaccmotive,MD2.idaccmotive) = AA2.idaccmotive " +
                         " left outer join accmotive AA3 on EE.idaccmotive = AA3.idaccmotive " +
                         " where(A.flagaccountusage & 320) <> 0 and isnull(A.flagenablebudgetprev, 'N') = 'S' " +
                         " and E.idacc<> EP.idacc " +
                         " and E.yentry= " + esercizio;


           




            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCostoContoDiverso.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnRicavoContoDiverso_Click(object sender, EventArgs e) {
            //string sql = "select * from entrydetail E    " +
            //             " join account A on E.idacc = A.idacc " +
            //             " join epaccyear EP on EP.idepacc = E.idepacc and E.yentry = EP.ayear " +
            //             " where(A.flagaccountusage & 128) <> 0 and isnull(A.flagenablebudgetprev, 'N') = 'S' " +
            //             " and E.idacc<> EP.idacc " +
            //             " and E.yentry= " + esercizio;

            string sql = "select " +
                         "Ik.description as 'tipo fattura',ID.yinv 'anno fatt.', ID.ninv 'n. fattura', ID.rownum 'riga fatt.'," +
                         " isnull(MD.idestimkind,MD2.idestimkind) 'tipo contratto', "+
                         "isnull(MD.yestim,MD2.yestim) 'anno c.', "+
                         "isnull(MD.nestim,MD2.nestim) 'n.c.',"+
                         "isnull(MD.rownum,MD2.rownum) 'riga c.'," +
                         " EE.yepacc as 'anno acc', EE.nepacc as 'n.acc', " +
                         " A1.codeacc  'conto scritt.', A3.codeacc 'conto acc'," +
                         " AA1.codemotive  'cod. causale fatt.',AA2.codemotive 'cod. causale contr.',AA3.codemotive 'cod. causale acc'," +
                         " AA1.title  'causale fatt.',AA2.title 'causale contr.',AA3.title 'causale acc.'," +
                         "* from entrydetail E    " +
                         " join account A on E.idacc = A.idacc " +
                         " join epaccyear EP on EP.idepacc = E.idepacc and E.yentry = EP.ayear " +
                         " join epacc EE on EE.idepacc = EP.idepacc  " +
                         " left outer join invoicedetail ID on E.idrelated = 'inv§'+" +
                         "convert(varchar(30),ID.idinvkind)+'§'+" +
                         "convert(varchar(30),ID.yinv)+'§'+" +
                         "convert(varchar(30),ID.ninv)+'§'+" +
                         "convert(varchar(30),ID.rownum) " +
                         " left outer join estimatedetail   MD on MD.idestimkind=ID.idestimkind and "+
                                "MD.yestim=ID.yestim and MD.nestim=ID.nestim and MD.rownum=ID.manrownum " +
                         " left outer join invoicekind ik on ik.idinvkind=ID.idinvkind " +
                           " left outer join estimatedetail MD2 on E.idrelated = 'estim§'+" +
                         "convert(varchar(30),MD2.idestimkind)+'§'+" +
                         "convert(varchar(30),MD2.yestim)+'§'+" +
                         "convert(varchar(30),MD2.nestim)+'§'+" +
                         "convert(varchar(30),MD2.rownum) " +
                         " join account A1 on A1.idacc=E.idacc " +
                         //join account A2 on A2.idacc=EP.idacc "+
                         " join account A3 on A3.idacc=EP.idacc " +
                         " left outer join accmotive AA1 on ID.idaccmotive = AA1.idaccmotive " +
                         " left outer join accmotive AA2 on isnull(MD.idaccmotive,MD2.idaccmotive) = AA2.idaccmotive " +
                         " left outer join accmotive AA3 on EE.idaccmotive = AA3.idaccmotive " +
                         " where(A.flagaccountusage & 128) <> 0 and isnull(A.flagenablebudgetprev, 'N') = 'S' " +
                         " and E.idacc<> EP.idacc " +
                         " and E.yentry= " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtRicavoContoDiverso.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCorreggiAccertamentiIncoerentiIdrelated_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct ESTD.idestimkind,ESTD.yestim,ESTD.nestim " +
                    " from entrydetail ED \r\n\t\t" +
                    " left outer join account a on ED.idacc = a.idacc" +
                    " left outer join estimatedetail ESTD on ED.idrelated = \r\n\t\t" +
                    " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.yestim) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.nestim) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.rownum)\r\n\t\t " +
                    " left outer join epacc E1 on  E1.idepacc = ED.idepacc \r\n\t\t" +
                    " left outer join epaccyear EY1 on  EY1.idepacc = ED.idepacc and EY1.ayear = ED.yentry \r\n\t\t" +
                    " left outer join epacc E2 on  E2.idepacc = ESTD.idepacc\r\n\t\t " +
                    " left outer join epaccyear EY2 on  EY2.idepacc = ESTD.idepacc and EY2.ayear = ED.yentry\r\n\t\t " +
                    " where ED.idrelated like 'estim%' and isnull(ED.idepacc, 0)<> isnull(ESTD.idepacc, 0)\r\n\t\t " +
                    " and(a.flagaccountusage & 128) <> 0  and e1.idrelated<> e2.idrelated   "+
                    " and ED.yentry = " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rAccBudget in t.Rows) {
                    int lastVal = progBar.Value;
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraContrattoAttivo(rAccBudget);
                   
                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";

            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        /// <summary>
        /// Scritture su accertamenti di Budget con idrelated che non punta ad un contratto attivo esistente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct EA.idrelated as 'Id Rel',EA.idepacc as 'Idepacc',EA.nepacc as 'Numero Accertamento'," +
                    " EA.yepacc as 'Eserc. creaz. Accertamento',EA.ayear as 'Esercizio', " +
                    " EA.description as 'descrizione',EA.amount as 'importo', EA.phase as 'fase', " +
                    " ED.yentry, ED.nentry, ED.ndetail "+
                    " from epaccview EA " +
                    " join account A on EA.idacc = A.idacc " +
                    " join entrydetail ED on ED.idepacc = EA.idepacc "+
                    " where " + //"A.flagenablebudgetprev = 'N' and EA.curramount <> 0 and \r\n\t\t" +
                    " not exists(select * from estimatedetailview ESTD  where EA.idrelated = " +
                    " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' +  " +
                    " convert(varchar(30), ESTD.yestim) + '§' +  " +
                    " convert(varchar(30), ESTD.nestim) + '§' +  " +
                    " convert(varchar(30), ESTD.rownum) ) " +
                    " and EA.idrelated like 'estim§%'  " +
                    " and ED.yentry = " + esercizio +
                    " and EA.ayear = " + esercizio;
          
            DataTable t = Conn.SQLRunner(sql,false,0);
            t.TableName = "entrydetail";
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEPAcc_conIdrelatedSenzaCA.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct EA.idrelated as \'Id Rel\',EA.idepacc ,EA.nepacc as \'Numero Accertamento\'," +
                    " EA.yepacc as \'Eserc. creaz. Accertamento\',EA.ayear as \'Esercizio\', " +
                    " EA.description as 'descrizione',EA.amount as 'importo', EA.phase as 'fase', " +
                    " ED.yentry, ED.nentry, ED.ndetail " +
                    " from epaccview EA \r\n\t\t" +
                    " join account A on EA.idacc = A.idacc " +
                    " join entrydetail ED on ED.idepacc = EA.idepacc " +
                    " where " + //"A.flagenablebudgetprev = 'N' and EA.curramount <> 0 \r\n\t\t" +
                    "  not exists(select * from invoicedetailview INVD  where EA.idrelated = " +
                    " 'inv§' + convert(varchar(30), INVD.idinvkind) + '§' + " +
                    " convert(varchar(30), INVD.yinv) + '§' + " +
                    " convert(varchar(30), INVD.ninv) + '§' + " +
                    " convert(varchar(30), INVD.rownum) ) " +
                    " and EA.idrelated like 'inv§%' " +
                    " and ED.yentry = " + esercizio +
                    " and EA.ayear = " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            t.TableName = "entrydetail";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEPAcc_conIdrelatedSenzaFatt.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEntryDataWrong_Click(object sender, EventArgs e) {
            string sql = " select ES.adate as 'data contratto', E.adate as 'data scrittura', ESTD.stop as 'data annullamento', * from entrydetail ED " +
                         " join entry E on ED.yentry = E.yentry and ED.nentry = E.nentry " +
                         " join estimatedetail ESTD on ED.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join estimate ES on ES.idestimkind = ESTD.idestimkind and ES.yestim = ESTD.yestim and ES.nestim = ESTD.nestim " +
                         " where ED.idrelated like 'estim§%' " +
                         " and ESTD.start is null " +
                         " and ES.adate<> E.adate and (ESTD.stop is null or ESTD.stop<>E.adate) " +
                         " and ED.yentry = " + esercizio;                   

            DataTable t = Conn.SQLRunner(sql, false, 0);
            t.TableName = "entrydetail";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEntryVarDataWrong.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEntryVarDataWrong_Click(object sender, EventArgs e) {
            string sql = " select ESTD.start as 'data dettaglio', E.adate as 'data scrittura', ESTD.stop as 'data annullamento', * from entrydetail ED " +
                         " join entry E on ED.yentry = E.yentry and ED.nentry = E.nentry " +
                         " join estimatedetail ESTD on ED.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join estimate ES on ES.idestimkind = ESTD.idestimkind and ES.yestim = ESTD.yestim and ES.nestim = ESTD.nestim " +
                         " where ED.idrelated like 'estim§%' " +
                         " and ESTD.start is not null " +
                         " and ESTD.start <> E.adate and (ESTD.stop is null or ESTD.stop<>E.adate)" +
                         " and (ESTD.stop is null or ESTD.yestim<> year(ESTD.stop)) " +
                         " and ED.yentry = " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            t.TableName = "entrydetail";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEntryDataWrong.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEntryWrongDatePassivi_Click(object sender, EventArgs e) {
            string sql = " select ES.adate as 'data contratto', E.adate as 'data scrittura',ESTD.stop as 'data annullamento', * from entrydetail ED " +
                         " join entry E on ED.yentry = E.yentry and ED.nentry = E.nentry " +
                         " join mandatedetail ESTD on ED.idrelated = " +
                         " 'mandate§' + convert(varchar(30), ESTD.idmankind) + '§' + " +
                         " convert(varchar(30), ESTD.yman) + '§' + " +
                         " convert(varchar(30), ESTD.nman) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join mandate ES on ES.idmankind = ESTD.idmankind and ES.yman = ESTD.yman and ES.nman = ESTD.nman " +
                         " where ED.idrelated like 'man§%' " +
                         " and ESTD.start is null " +
                         " and ES.adate<> E.adate and (ESTD.stop is null or ESTD.stop<>E.adate) " +
                         " and ED.yentry = " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            t.TableName = "entrydetail";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEntryWrongDatePassivi.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEntryWrongDatePassiviVar_Click(object sender, EventArgs e) {
            string sql = " select ES.adate as 'data contratto', E.adate as 'data scrittura',ESTD.stop as 'data annullamento', * from entrydetail ED " +
                         " join entry E on ED.yentry = E.yentry and ED.nentry = E.nentry " +
                         " join mandatedetail ESTD on ED.idrelated = " +
                         " 'mandate§' + convert(varchar(30), ESTD.idmankind) + '§' + " +
                         " convert(varchar(30), ESTD.yman) + '§' + " +
                         " convert(varchar(30), ESTD.nman) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join mandate ES on ES.idmankind = ESTD.idmankind and ES.yman = ESTD.yman and ES.nman = ESTD.nman " +
                         " where ED.idrelated like 'man§%' " +
                         " and ESTD.start is not null " +
                         " and ESTD.start<> E.adate and (ESTD.stop is null or ESTD.stop<>E.adate) " +
                         " and (ESTD.stop is null or ESTD.yman <> year(ESTD.stop)) " + 
                         " and ED.yentry = " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            t.TableName = "entrydetail";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEntryWrongDatePassiviVar.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDoublePreAcc_Click(object sender, EventArgs e) {
            string sql =
                    "select  e1.idrelated, e1.idepacc,e1.nepacc,e2.nepacc,e1.description,e2.description," +
                    " e1.totamount,e2.totamount from epaccview e1 " +
                    " join epaccview e2 on e1.idrelated = e2.idrelated and e1.nphase = e2.nphase and e1.ayear = e2.ayear " +
                    " where e1.idepacc<> e2.idepacc and e1.nphase = 1 " +
                    " and e1.ayear  = " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            t.TableName = "epacc";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtDoublePreAcc.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDoublePreimp_Click(object sender, EventArgs e) {
            string sql =
                    "select  e1.idrelated, e1.idepexp,e1.nepexp,e2.nepexp,e1.description,e2.description," +
                    " e1.totamount,e2.totamount from epexpview e1 " +
                    " join epexpview e2 on e1.idrelated = e2.idrelated and e1.nphase = e2.nphase and e1.ayear = e2.ayear " +
                    " where e1.idepexp<> e2.idepexp and e1.nphase = 1 and e1.totcurramount = 0 and e2.totcurramount>0" +
                    " and e1.ayear  = " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            t.TableName = "epexp";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtDoublePreimp.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgRicavoContoDiverso_Click(object sender, EventArgs e) {
            string sql = "select distinct ES.idestimkind,ES.yestim,ES.nestim from entrydetail ED    " +
                         " join account A on ED.idacc = A.idacc " +
                         " join epaccyear EP on EP.idepacc = ED.idepacc and ED.yentry = EP.ayear " +
                         " join estimatedetail ESTD on ED.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join estimate ES on ES.idestimkind = ESTD.idestimkind and ES.yestim = ESTD.yestim and ES.nestim = ESTD.nestim " +
                         " where ED.idrelated like 'estim§%' " +
                         " AND (A.flagaccountusage & 128) <> 0 and isnull(A.flagenablebudgetprev, 'N') = 'S' " +
                         " and ED.idacc<> EP.idacc " +
                         " and ED.yentry= " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rEstim in t.Rows) {
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraContrattoAttivo(rEstim);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgRicavoContoDiversoFatt_Click(object sender, EventArgs e) {
            string sql = "select distinct ES.idinvkind,ES.yinv,ES.ninv from entrydetail ED    " +
                         " join account A on ED.idacc = A.idacc " +
                         " join epaccyear EP on EP.idepacc = ED.idepacc and ED.yentry = EP.ayear " +
                         " join invoicedetail ESTD on ED.idrelated = " +
                         " 'inv§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yinv) + '§' + " +
                         " convert(varchar(30), ESTD.ninv) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) " +
                         " join invoice ES on ES.idinvkind = ESTD.idinvkind and ES.yinv = ESTD.yinv and ES.ninv = ESTD.ninv " +
                         " where ED.idrelated like 'inv§%' " +
                         " AND (A.flagaccountusage & 128) <> 0 and isnull(A.flagenablebudgetprev, 'N') = 'S' " +
                         " and ED.idacc<> EP.idacc " +
                         " and ED.yentry= " + esercizio;

            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rEstim in t.Rows) {
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraFattura(rEstim, invkind);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void BtncrgAccertamentiBudgetEstimate_Click(object sender, EventArgs e) {
            string sql = " select  " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) as 'idrelated', " +
                         //" E2.idrelated 'missing', E2.yepacc 'missing y' ,E2.nepacc 'missing n', " +
                         " E1.idrelated 'idrelated accertamento effettivo', " +
                         " ESTD.idestimkind,ESTD.yestim,ESTD.nestim, ESTD.rownum " +
                         " from estimatedetail ESTD " +
                         " join epaccview E1 on E1.idepacc = ESTD.idepacc and E1.ayear = isnull(year(ESTD.start), ESTD.yestim)" +
                         " left outer join accmotivedetail AMD on AMD.idaccmotive = ESTD.idaccmotive and " +
                         " AMD.ayear = isnull(year(ESTD.start), ESTD.yestim)" +
                         " left outer join account A on AMD.idacc = A.idacc" +
                         " left outer join epaccview E2 on E2.idrelated = " +
                         " 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum) and E2.nphase=E1.nphase and E2.ayear=E1.ayear " +
                         " where isnull(E1.idrelated, '') <> 'estim§' + convert(varchar(30), ESTD.idestimkind) + '§' + " +
                         " convert(varchar(30), ESTD.yestim) + '§' + " +
                         " convert(varchar(30), ESTD.nestim) + '§' + " +
                         " convert(varchar(30), ESTD.rownum)" +
                         " and ESTD.stop is null " +
                         " and AMD.ayear = E1.ayear " +
                         " and E1.ayear=" + esercizio +
                         " order by ESTD.idestimkind,ESTD.yestim,ESTD.nestim ";

            DataTable t = Conn.SQLRunner(sql, false, 0);

            if (t?.Rows.Count > 0) {
                t.TableName = "epacc"; DataSet d = new DataSet();
                d.Tables.Add(t);

                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;

                string prevContract = "";
                DataTable estimDetail = Conn.CreateTableByName("estimatedetail", "*");
                foreach (DataRow r in t.Rows) {
                    var currContract = $"{r["idestimkind"]}§{r["yestim"]}§{r["nestim"]}";
                    int oldval = progBar.Value;
                    if (currContract != prevContract) {
                        prevContract = currContract;
                        if (estimDetail.Rows.Count > 0) {
                            scollegaDettagliContrattoAttivo(estimDetail);
                            estimDetail.Clear();
                        }
                    }
                    progBar.Value = oldval;
                    //Set r.idepacc  to null
                    Conn.RUN_SELECT_INTO_TABLE(estimDetail, null,
                        QHS.MCmp(r, "idestimkind", "yestim", "nestim", "rownum"), null, false);
             
                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();
                }

              
                if (estimDetail.Rows.Count > 0) {
                    scollegaDettagliContrattoAttivo(estimDetail);
                    estimDetail.Clear();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";

            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        void scollegaDettagliContrattoAttivo(DataTable estimDet) {
            if (estimDet.Rows.Count == 0) return;
            DataSet d = new DataSet();
            estimDet.DataSet?.Tables.Remove(estimDet);
            d.Tables.Add(estimDet);

            DataTable entry = Conn.CreateTableByName("entrydetail", "*");
            d.Tables.Add(entry);

            DataRow cAttivoDett = estimDet.Rows[0];
            foreach (DataRow r in estimDet.Rows) {
                string result = Conn.DO_UPDATE("estimatedetail",
                    QHS.AppAnd(QHS.CmpEq("idestimkind", r["idestimkind"]),
                        QHS.CmpEq("yestim", r["yestim"]),
                        QHS.CmpEq("nestim", r["nestim"]),
                        QHS.CmpEq("rownum", r["rownum"])
                    ),
                    new [] { "idepacc"},
                    new [] { "null"} ,1                    
                    );
                if (result != null) {
                    show(result, "Errore");
                    continue;
                }
                //r["idepacc"] = DBNull.Value;
                string idrelated = EP_functions.GetIdForDocument(r);
                Conn.RUN_SELECT_INTO_TABLE(entry, null, QHS.AppAnd(
                    QHS.CmpEq("yentry", esercizio), QHS.CmpEq("idrelated", idrelated)),null,false);                                
            }
            foreach (DataRow r in entry.Rows) {
                r["idepacc"] = DBNull.Value;
            }

            
            DataTable estim = Conn.RUN_SELECT("estimate", "*", null, 
                QHS.MCmp(cAttivoDett, "idestimkind", "yestim", "nestim"), null,false);            
            DataRow cAttivo = estim.Rows[0];
            d.Tables.Add(estim);           


            
            txtCurrent.Text = "Contratto attivo tipo " + cAttivo["idestimkind"] + ") n." + cAttivo["nestim"];

            MetaData mCattivo = Meta.Dispatcher.Get("estimate");
            PostData post = mCattivo.Get_PostData();
            post.InitClass(d, Conn);
            if (post.DO_POST()) {
                rigeneraScrittura(cAttivo, "estimate");
            }
            
            progBar.Increment(1);
            progBar.Update();
        }

        private void btnResiduiPassErrati_Click(object sender, EventArgs e) {
            string sql = "select epexp.yepexp, epexp.idepexp " +
                         " from epexp " +
                         " join epexpyear CurrEP  on epexp.idepexp = CurrEP.idepexp " +
                         " join epexpyear NewEP  on NewEP.idepexp = CurrEP.idepexp and NewEP.ayear = CurrEP.ayear + 1 " +
                         " join accountlookup lookup on CurrEP.idacc = lookup.oldidacc " +
                         " join account CurrA on CurrA.idacc = CurrEP.idacc " +
                         " join account NewA on NewA.idacc = lookup.newidacc " +
                         " join account actual on actual.idacc = NewEP.idacc " +
                         " where NewEP.idacc<> lookup.newidacc " +
                         " and NewEP.ayear= " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
            
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;

                foreach (DataRow r in t.Rows) {
                    for (int es = CfgFn.GetNoNullInt32(r["yepexp"]); es <= Conn.GetEsercizio(); es++) {
                        Conn.CallSP("trg_evaluatearrearsepexp", new[] { r["idepexp"], es });
                    }
                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnResiduiAttErrati_Click(object sender, EventArgs e) {
            string sql = "select epacc.idepacc, epacc.yepacc " +
                         " from epacc " +
                         "join epaccyear CurrEP  on epacc.idepacc = CurrEP.idepacc " +
                         "join epaccyear NewEP on NewEP.idepacc = CurrEP.idepacc and NewEP.ayear = CurrEP.ayear + 1 " +
                         " join accountlookup lookup on CurrEP.idacc = lookup.oldidacc " +
                         " join account CurrA on CurrA.idacc = CurrEP.idacc " +
                         " join account NewA on NewA.idacc = lookup.newidacc " +
                         " join account actual on actual.idacc = NewEP.idacc " +
                         " where NewEP.idacc<> lookup.newidacc" +
                         " and NewEP.ayear= " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;

                foreach (DataRow r in t.Rows) {
                    for (int es = CfgFn.GetNoNullInt32(r["yepacc"]); es <= Conn.GetEsercizio(); es++) {
                        Conn.CallSP("trg_evaluatearrearsepacc", new[] { r["idepacc"], es });
                    }                     
                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();                   
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnFattureCPassiviContoIncoerente_Click(object sender, EventArgs e) {
            string sql = "select "+
                "A1.codemotive 'codice causale fatt.', A1.title 'causale fatt.',"+
                         "A2.codemotive 'codice causale contr.', A2.title 'causale contr.'," +
                         "A3.codemotive 'codice causale impegno', A3.title 'causale impegno'," +
                    "Ik.description as 'tipo fattura',ID.yinv 'anno fatt.', ID.ninv 'n. fattura', ID.rownum 'riga fatt.'," +
                            " MD.idmankind 'tipo contratto', MD.yman 'anno c.', MD.nman 'n.c.', MD.rownum 'riga c.',"+
                            " * from invoicedetail  ID    " +   
                            "join invoicekind ik on ik.idinvkind=ID.idinvkind "                         +
                         " join mandatedetail MD on MD.idmankind=ID.idmankind and MD.yman=ID.yman and MD.nman=ID.nman and MD.rownum=ID.manrownum "+    
                         " join epexp EP on EP.idepexp=MD.idepexp "+
                         " left outer join accmotive A1 on ID.idaccmotive = A1.idaccmotive "+
                         " left outer join accmotive A2 on MD.idaccmotive = A2.idaccmotive " +
                         " left outer join accmotive A3 on EP.idaccmotive = A3.idaccmotive " +
                         " where isnull(MD.idaccmotive,0) <> isnull(ID.idaccmotive,0) " +
                         " and ID.yinv= " + esercizio;

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "invoicedetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtFattureCPassiviContoIncoerente.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgFattureCPassiviContoIncoerente_Click(object sender, EventArgs e) {
            string sql = "select " +
                         " ID.idinvkind,ID.yinv,ID.ninv,ID.rownum, EP.idaccmotive,IK.codeinvkind,IK.description as invoicekind " +
                         "  from invoicedetail  ID    " +
                         "join invoicekind ik on ik.idinvkind=ID.idinvkind " +
                         " join mandatedetail MD on MD.idmankind=ID.idmankind and MD.yman=ID.yman and MD.nman=ID.nman and MD.rownum=ID.manrownum " +
                         " join epexp EP on EP.idepexp=MD.idepexp " +
                         " left outer join accmotive A1 on ID.idaccmotive = A1.idaccmotive " +
                         " left outer join accmotive A2 on MD.idaccmotive = A2.idaccmotive " +
                         " left outer join accmotive A3 on EP.idaccmotive = A3.idaccmotive " +
                         " where isnull(MD.idaccmotive,0) <> isnull(ID.idaccmotive,0) " +
                         "  and MD.idaccmotive=EP.idaccmotive " +
                         " and ID.yinv= " + esercizio;

            //Si correggono modificando la causale della fattura rendendola consona all'impegno di b.
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);

                foreach (DataRow r in t.Rows) {
                    Conn.DO_UPDATE("invoicedetail",
                        QHS.AppAnd(QHS.CmpEq("idinvkind", r["idinvkind"]),
                            QHS.CmpEq("yinv", r["yinv"]),
                            QHS.CmpEq("ninv", r["ninv"]),
                            QHS.CmpEq("rownum", r["rownum"])
                        ),
                        new[] {"idaccmotive"},
                        new[] {QHS.quote(r["idaccmotive"])}, 1);

                    rigeneraFattura(r, invkind);
                }
                progBar.Value = 0;
                txtCurrent.Text = "";

            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnImpegniIncoerentiIdrelated_Click(object sender, EventArgs e) {
            string sql = $@"
                    select e1.idepexp,e2.idepexp, /*a.idacc,*/ a.codeacc 'conto scrittura',
            /*a2.idacc,*/ a2.codeacc 'conto acc. idepexp',
            /*a3.idacc,*/ a3.codeacc 'conto acc. idrel',
            entrydetail.idrelated 'idrel scrittura',
            e1.idrelated 'idrel acc.scrittura',
            entrydetail.amount 'imp.scrittura', ey1.amount 'imp. conto idepexp', ey2.amount ' imp. conto idrel',
            entrydetail.description 'descr.scrittura', e1.description 'desc. acc. idepexp', e2.description 'descr. acc idrel',
            a.title,* from entrydetail
                    left outer
                    join epexp e1 on entrydetail.idepexp = e1.idepexp
 
            left outer join epexpyear ey1 on e1.idepexp = ey1.idepexp and ey1.ayear = {esercizio}
            left outer join epexp e2 on entrydetail.idrelated = e2.idrelated and e2.nphase = 2
            left outer join epexpyear ey2 on e2.idepexp = ey2.idepexp and ey2.ayear = {esercizio}
            left outer join account a on entrydetail.idacc = a.idacc
            left outer join account a2 on a2.idacc = ey1.idacc
            left outer join account a3 on a3.idacc = ey2.idacc
            left outer join accmotive aa on entrydetail.idaccmotive = aa.idaccmotive
            left outer join accmotive aa2 on aa2.idaccmotive = e1.idaccmotive
            left outer join accmotive aa3 on aa3.idaccmotive = e2.idaccmotive

            where e1.idepexp<> e2.idepexp and entrydetail.yentry = {esercizio} and(a.flagaccountusage & 320) <> 0  and e1.idrelated<> e2.idrelated
                 ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtImpegniIncoerentiIdrelated.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCrgIncoerentiIdrelated_Click(object sender, EventArgs e) {
            string sql =
                    " select distinct ESTD.idmankind,ESTD.yman,ESTD.nman " +
                    " from entrydetail ED \r\n\t\t" +
                    " left outer join account a on ED.idacc = a.idacc" +
                    " left outer join mandatedetail ESTD on ED.idrelated = \r\n\t\t" +
                    " 'man§' + convert(varchar(30), ESTD.idmankind) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.yman) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.nman) + '§' + \r\n\t\t" +
                    " convert(varchar(30), ESTD.rownum)\r\n\t\t " +
                    " left outer join epexp E1 on  E1.idepexp = ED.idepexp \r\n\t\t" +
                    " left outer join epexpyear EY1 on  EY1.idepexp = ED.idepexp and EY1.ayear = ED.yentry \r\n\t\t" +
                    " left outer join epexp E2 on  E2.idepexp = ESTD.idepexp\r\n\t\t " +
                    " left outer join epexpyear EY2 on  EY2.idepexp = ESTD.idepexp and EY2.ayear = ED.yentry\r\n\t\t " +
                    " where ED.idrelated like 'man%' and isnull(ED.idepexp, 0)<> isnull(ESTD.idepexp, 0)\r\n\t\t " +
                    " and(a.flagaccountusage & 320) <> 0  and e1.idrelated<> e2.idrelated and ED.yentry = " + esercizio;

                                                



            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rAccBudget in t.Rows) {
                    int lastVal = progBar.Value;
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraContrattoPassivo(rAccBudget);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";

            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
          
        }

        private void BtnchkMancaAnagrafica_Click(object sender, EventArgs e) {
            string sql = $@"
            select distinct yentry 'anno scrittura',nentry 'n.scrittura',ndetail 'n. dettaglio',
                idrelated,ed.description 'descrizione',m.idmankind 'id tipo contr.passivo'
                    ,m.yman 'anno c.passivo',m.nman 'n.c.passivo',ED.* from entrydetail ed 
	        join account A on ED.idacc=A.idacc 
	        left outer join mandate m on ed.idrelated like 'man§'+convert(varchar(30),m.idmankind)+'§'+
                convert(varchar(30),m.yman)+'§'+convert(varchar(30),m.nman)+'§%'
	        where ed.yentry={esercizio} and A.flagregistry='S' and ed.idreg is null
		        order by nentry";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtMancaAnagrafica.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnMancaAnagrCPassivi_Click(object sender, EventArgs e) {
            string sql = $@"
            select distinct m.idmankind ,m.yman ,m.nman  from entrydetail ed 
	            join account A on ED.idacc=A.idacc 
	            join mandate m on ed.idrelated like 'man§'+convert(varchar(30),m.idmankind)+'§'+
                        convert(varchar(30),m.yman)+'§'+convert(varchar(30),m.nman)+'§%'
	            where ed.yentry={esercizio} and A.flagregistry='S' and ed.idreg is null 
		       ";
            DataTable t = Conn.SQLRunner(sql,false,0);
            if (t.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rMan in t.Rows) {
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraContrattoPassivo(rMan);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCheckMancaUPB_Click(object sender, EventArgs e) {
            string sql = $@"
            select distinct yentry 'anno scrittura',nentry 'n.scrittura',ndetail 'n. dettaglio',
                idrelated,ed.description 'descrizione',m.idmankind 'id tipo contr.passivo'
                    ,m.yman 'anno c.passivo',m.nman 'n.c.passivo',ED.* from entrydetail ed 
	        join account A on ED.idacc=A.idacc 
	        left outer join mandate m on ed.idrelated like 'man§'+convert(varchar(30),m.idmankind)+'§'+
                convert(varchar(30),m.yman)+'§'+convert(varchar(30),m.nman)+'§%'
	        where ed.yentry={esercizio} and A.flagupb='S' and ed.idupb is null
		        order by nentry";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckMancaUPB.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCrgMancaUPBCPassivi_Click(object sender, EventArgs e) {
            string sql = $@"
            select distinct m.idmankind ,m.yman ,m.nman  from entrydetail ed 
	            join account A on ED.idacc=A.idacc 
	            join mandate m on ed.idrelated like 'man§'+convert(varchar(30),m.idmankind)+'§'+
                        convert(varchar(30),m.yman)+'§'+convert(varchar(30),m.nman)+'§%'
	            where ed.yentry={esercizio} and A.flagupb='S' and ed.idupb is null 
		       ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rMan in t.Rows) {
                    //Risalva il contratto attivo collegato
                    //Risalva il c.attivo in questione
                    rigeneraContrattoPassivo(rMan);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCreditiSuImpegni_Click(object sender, EventArgs e) {
            string sql = $@"
                select * from entrydetail  E
	                join account A on A.idacc=E.idacc
	                    where E.idepexp is not null and A.flagaccountusage&32<>0 --crediti
	                         and E.yentry={esercizio} 
		        order by nentry";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCreditiSuImpegni.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCrgCreditiSuImpegni_Click(object sender, EventArgs e) {
            string sql = $@"
                select distinct E.idepexp from entrydetail  E
	                join account A on A.idacc=E.idacc
	                    where E.idepexp is not null and A.flagaccountusage&32<>0 --crediti
	                            and E.yentry={esercizio} 
		            ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                int maxEsercizioEP = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", null, "max(ayear)"));
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;

                foreach (DataRow rEpExp in t.Rows) {
                    object parid = Conn.DO_READ_VALUE("epexp", QHS.CmpEq("idepexp", rEpExp["idepexp"]), "paridepexp");
                    //Per ogni esercizio fino all'ultimo a partire dall'attuale:
                    for (int ayear = Conn.GetEsercizio(); ayear <= maxEsercizioEP; ayear++) {
                        //ricalcola  i totali dell'anno sull'accertamento in questione    
                        Conn.CallSP("rebuild_epexptotal_idmov", new[] { ayear, rEpExp["idepexp"]});
                        Conn.CallSP("rebuild_epexptotal_idmov", new[] { ayear, parid });

                        //ricalcola i residui dell'accertamento ove vi sia un anno successivo
                        if (ayear < maxEsercizioEP) {
                            Conn.CallSP("trg_evaluatearrearsepexp", new[] { rEpExp["idepexp"], ayear});
                            Conn.CallSP("trg_evaluatearrearsepexp", new[] { parid, ayear });
                        }
                    

                    }
                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();
                }

                progBar.Value = 0;
                txtCurrent.Text = "";


            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnDebitiSuAccertamenti_Click(object sender, EventArgs e) {
            string sql = $@"
                select * from entrydetail  E
	                join account A on A.idacc=E.idacc
	                    where E.idepacc is not null and A.flagaccountusage&16<>0 --debiti
	                        and E.yentry={esercizio} 
		        order by nentry";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtDebitiSuAccertamenti.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCrgDebitiSuAccertamenti_Click(object sender, EventArgs e) {
            string sql = $@"
                select distinct E.idepacc from entrydetail  E
	                join account A on A.idacc=E.idacc
	                    where E.idepacc is not null and A.flagaccountusage&16<>0 --debiti
	                     and E.yentry={esercizio} 
		            ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                int maxEsercizioEP = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", null, "max(ayear)"));
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;

                foreach (DataRow rEpAcc in t.Rows) {
                    object parid = Conn.DO_READ_VALUE("epacc", QHS.CmpEq("idepacc", rEpAcc["idepacc"]), "paridepacc");
                    //Per ogni esercizio fino all'ultimo a partire dall'attuale:
                    for (int ayear = Conn.GetEsercizio(); ayear <= maxEsercizioEP; ayear++) {
                        //ricalcola  i totali dell'anno sull'accertamento in questione    
                        Conn.CallSP("rebuild_epacctotal_idmov", new[] { ayear, rEpAcc["idepacc"] });
                        Conn.CallSP("rebuild_epacctotal_idmov", new[] { ayear, parid });

                        //ricalcola i residui dell'accertamento ove vi sia un anno successivo
                        if (ayear < maxEsercizioEP) {
                            Conn.CallSP("trg_evaluatearrearsepacc", new[] { rEpAcc["idepacc"], ayear });
                            Conn.CallSP("trg_evaluatearrearsepacc", new[] { parid, ayear });
                        }
                       

                    }
                    progBar.Increment(1);
                    progBar.Update();
                    Application.DoEvents();
                }

                progBar.Value = 0;
                txtCurrent.Text = "";


            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgCheckMovBudgetCPassivi_Click(object sender, EventArgs e) {
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            string sql = $@"
            select  distinct pt.idmankind,pt.yman,pt.nman from  entrydetail ED1 
			join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				join account A on ED1.idacc=A.idacc         
                left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
			 join mandate pt on e1.idrelated= 'man§'+convert(varchar(30),pt.idmankind)+'§'+convert(varchar(30),pt.yman)+'§'+convert(varchar(30),pt.nman)
				where E1.identrykind= 1  and (A.flag & 16) =0 and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null 
                        and (A.flagaccountusage&48 <>0)      and(isnull(U.flag,0) & 4) =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                    and ( pt.yman >= {primoAnnoBudget})
				order by pt.idmankind,pt.yman,pt.nman
            ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rMan in t.Rows) {
                    //Risalva il c.passivo in questione
                    rigeneraContrattoPassivo(rMan);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCheckMovBudget_Click(object sender, EventArgs e) {
            DataTable config = Conn.RUN_SELECT("config", "*", null, $"ayear={esercizio}", null, false);
            DataRow rCfg = config.Rows[0];
            string noIva = "";
            foreach (string idacc in new[] {"idacc_ivapaymentsplit","idacc_unabatable_split","idacc_ivapayment","idacc_ivarefund"}) {
                if (rCfg[idacc] == DBNull.Value) continue;
                noIva = QHS.AppAnd(noIva, QHS.CmpNe("ED1.idacc", rCfg[idacc]));
            }
            if (noIva != "") noIva = " AND " + noIva;
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            object contabPhaseExp = Conn.GetSys("mandatephase");
            object contabPhaseInc = Conn.GetSys("incomephase");
            string sql = $@"
            select  ED1.yentry,ED1.nentry,ED1.ndetail,ED1.amount, E1.idrelated 'idrelated scrittura', ED1.idrelated 'idrelated dettaglio',
                ED1.description 'desc.dettaglio', E1.description 'descr.scrittura', 
                AMM.codemotive 'causale principale',
                A.codeacc 'codice conto', A.title 'conto',
                AA.codeacc 'codice conto principale', AA.title 'conto princ.',
                U.codeupb 'cod.upb' , U.title 'upb' 
                from  entrydetail ED1 
			        join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				    join account A on ED1.idacc=A.idacc
                    left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                        and (A.flag & 16) =0   and(isnull(U.flag,0) & 4) =0
                        and isnull(ed1.description,'') <> 'iva detraibile'
                        and isnull(ed1.description,'') <> 'iva detraibile split'
                        and isnull(ed1.description,'') <> 'iva detraibile intracom'
                        and not isnull(e1.idrelated,'') like 'ivapay§%'
                        and not isnull(ed1.description,'') like 'Ritenuta positiva su riga versamento %'
                        and not isnull(ed1.description,'') like 'Ritenuta negativa su riga versamento %'
                        and not ( isnull(ed1.description,'')  like 'Contributi positivi, Versamento,%'   and ed1.amount<0)
                        and not ( isnull(ed1.description,'') like 'Reversale su p.di giro su riga versamento%') 
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Debiti')
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Crediti')
                        and not ( isnull(ed1.description,'') like 'Lordi positivi, Riepilogo, riga%' and ed1.amount<0) 
                        and isnull(AA.flag,0)& 16  =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        {noIva}
                        and not e1.idrelated like 'paytrans%' and not e1.idrelated like 'protrans%'    
				order by E1.idrelated
        ";
            DataTable t = Conn.SQLRunner(sql, false, 0);
           
            
            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckMovBudget.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgCheckMovBudgetCAttivi_Click(object sender, EventArgs e) {
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            string sql = $@"
            select  distinct E1.idrelated,pt.idestimkind,pt.yestim,pt.nestim from  entrydetail ED1 
			join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				join account A on ED1.idacc=A.idacc
                left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
			 join estimate pt on e1.idrelated= 'estim§'+convert(varchar(30),pt.idestimkind)+'§'+convert(varchar(30),pt.yestim)+'§'+convert(varchar(30),pt.nestim)
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                        and (A.flag & 16) =0  and(isnull(U.flag,0) & 4) =0       and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and ( pt.yestim >= {primoAnnoBudget})
				order by pt.idestimkind,pt.yestim,pt.nestim
        ";
            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rEstim in t.Rows) {                    
                    //Risalva il c.attivo in questione
                    rigeneraContrattoAttivo(rEstim);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgCheckMovBudgetFatture_Click(object sender, EventArgs e) {
            string sql = $@"
            select  distinct pt.idinvkind,pt.codeinvkind,pt.invoicekind,pt.yinv,pt.ninv from  entrydetail ED1 
			join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				join account A on ED1.idacc=A.idacc
               left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
			 join invoiceview pt on e1.idrelated= 'inv§'+convert(varchar(30),pt.idinvkind)+'§'+convert(varchar(30),pt.yinv)+'§'+convert(varchar(30),pt.ninv)
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                            and (A.flag & 16) =0      and(isnull(U.flag,0) & 4) =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
				order by pt.idinvkind,pt.yinv,pt.ninv
            ";
            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                DataTable invkind = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
                progBar.Maximum = t.Rows.Count;
                progBar.Value = 0;
                foreach (DataRow rInv in t.Rows) {
                    //Risalva la fatt.
                    rigeneraFattura(rInv, invkind);

                    progBar.Update();
                    Application.DoEvents();
                }
                progBar.Value = 0;
                txtCurrent.Text = "";
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgCheckMovBudgetElePag_Click(object sender, EventArgs e) {
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            object contabPhaseExp = Conn.GetSys("mandatephase");
            string sql = $@"
            select  distinct pt.kpaymenttransmission,pt.npaymenttransmission from  entrydetail ED1 
			join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				join account A on ED1.idacc=A.idacc 
               left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
			 join paymenttransmission pt on e1.idrelated= 'paytrans§'+convert(varchar(30),pt.ypaymenttransmission)+'§'+convert(varchar(30),pt.npaymenttransmission) 
                    join expense pagamento on ED1.idrelated ='expense§'+convert(varchar(20),pagamento.idexp)+'§debit'
                    left outer join expenselink EL on EL.idchild=pagamento.idexp  and EL.nlevel = {contabPhaseExp}        
                    left outer join expense impegno on impegno.idexp = EL.idparent                    
                    left outer   join expensemandate on impegno.idexp=expensemandate.idexp                 
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                        and (A.flag & 16) =0      and(isnull(U.flag,0) & 4) =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and (impegno.ymov is null or impegno.ymov >= {primoAnnoBudget}   )
                        and (expensemandate.yman is null or expensemandate.yman >= {primoAnnoBudget})
				order by pt.kpaymenttransmission
            ";
            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                int n = t.Rows.Count;
                progBar.Maximum = n;
                progBar.Value = 0;
                foreach (DataRow r in t.Rows) {
                    DataSet D = new DataSet("paymenttransmDS");
                    DataTable T = Conn.RUN_SELECT("paymenttransmission", "*", null, QHS.CmpEq("kpaymenttransmission",r["kpaymenttransmission"]), null, false);
                    if (T.Rows.Count == 0) continue;
                    D.Tables.Add(T);
                    txtCurrent.Text = "Elenco di trasmissione n." + r["npaymenttransmission"];
                    rigeneraScrittura(T.Rows[0], "paymenttransmission");
                    progBar.Increment(1);
                    progBar.Update();
                }
                txtCurrent.Text = "";
                progBar.Value = 0;
                progBar.Update();
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void crgCheckMovBudgetEleInca_Click(object sender, EventArgs e) {
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            object contabPhaseInc = Conn.GetSys("incomephase");
            string sql = $@"
            select  distinct pt.kproceedstransmission,pt.nproceedstransmission from  entrydetail ED1 
			join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				join account A on ED1.idacc=A.idacc         
              left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
			 join proceedstransmission pt on e1.idrelated= 'protrans§'+convert(varchar(30),pt.yproceedstransmission)+'§'+convert(varchar(30),pt.nproceedstransmission) 
                     left outer join income incasso on ED1.idrelated ='income§'+convert(varchar(20),incasso.idinc)+'§credit'
                    left outer join incomelink EL2 on EL2.idchild=incasso.idinc  and EL2.nlevel = {contabPhaseInc}    
                    left outer join income accertamento on accertamento.idinc = EL2.idparent            
                    left outer   join incomeestimate on accertamento.idinc=incomeestimate.idinc
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                            and (A.flag & 16) =0     and(isnull(U.flag,0) & 4) =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and isnull(ed1.description,'') <> 'iva detraibile'
                        and isnull(ed1.description,'') <> 'iva detraibile split'
                        and isnull(ed1.description,'') <> 'iva detraibile intracom'
                        and not isnull(e1.idrelated,'') like 'ivapay§%'
                        and not isnull(ed1.description,'') like 'Ritenuta positiva su riga versamento %'
                        and not isnull(ed1.description,'') like 'Ritenuta negativa su riga versamento %'
                        and not ( isnull(ed1.description,'')  like 'Contributi positivi, Versamento,%'   and ed1.amount<0)
                        and not ( isnull(ed1.description,'') like 'Reversale su p.di giro su riga versamento%') 
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Debiti')
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Crediti')
                        and not ( isnull(ed1.description,'') like 'Lordi positivi, Riepilogo, riga%' and ed1.amount<0) 
                    and (accertamento.ymov is null or accertamento.ymov >= {primoAnnoBudget}   )
                    and (incomeestimate.yestim is null or incomeestimate.yestim >= {primoAnnoBudget})
				order by pt.kproceedstransmission
            ";
            DataTable t = Conn.SQLRunner(sql);
            if (t.Rows.Count > 0) {
                int n = t.Rows.Count;
                progBar.Maximum = n;
                progBar.Value = 0;
                foreach (DataRow r in t.Rows) {
                    DataSet D = new DataSet("proceedstransmDS");
                    DataTable T = Conn.RUN_SELECT("proceedstransmission", "*", null, QHS.CmpEq("kproceedstransmission", r["kproceedstransmission"]), null, false);
                    if (T.Rows.Count == 0) continue;
                    D.Tables.Add(T);
                    txtCurrent.Text = "Elenco di trasmissione n." + r["nproceedstransmission"];
                    rigeneraScrittura(T.Rows[0], "proceedstransmission");
                    progBar.Increment(1);
                    progBar.Update();
                }
                txtCurrent.Text = "";
                progBar.Value = 0;
                progBar.Update();
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnCheckMovimentiElencoTrasmNoImpegniBudget_Click(object sender, EventArgs e) {
            DataTable config = Conn.RUN_SELECT("config", "*", null, $"ayear={esercizio}", null, false);
            DataRow rCfg = config.Rows[0];
            string noIva = "";
            foreach (string idacc in new[] { "idacc_ivapaymentsplit", "idacc_unabatable_split", "idacc_ivapayment", "idacc_ivarefund" }) {
                if (rCfg[idacc] == DBNull.Value) continue;
                noIva = QHS.AppAnd(noIva, QHS.CmpNe("ED1.idacc", rCfg[idacc]));
            }
            if (noIva != "") noIva = " AND " + noIva;
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            object contabPhaseExp = Conn.GetSys("mandatephase");
            object contabPhaseInc = Conn.GetSys("incomephase");
            string sql = $@"
            select  ED1.yentry,ED1.nentry,ED1.ndetail,ED1.amount, E1.idrelated 'idrelated scrittura', ED1.idrelated 'idrelated dettaglio',
                ED1.description 'desc.dettaglio', E1.description 'descr.scrittura', 
                AMM.codemotive 'causale principale',
                A.codeacc 'codice conto', A.title 'conto',
                AA.codeacc 'codice conto principale', AA.title 'conto princ.',
                U.codeupb 'cod.upb' , U.title 'upb' ,impegno.idexp,   
                pagamento.nmov as 'n.pagamento', impegno.nmov as 'n. impegno', impegno.ymov as 'anno impegno',
                expensemandate.yman as 'anno c.passivo', expensemandate.idmankind as 'codice tipo contratto', expensemandate.nman as 'n. contratto' 
                from  entrydetail ED1 
			        join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				    join account A on ED1.idacc=A.idacc
                    left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
                    join expense pagamento on ED1.idrelated ='expense§'+convert(varchar(20),pagamento.idexp)+'§debit'
                    left outer join expenselink EL on EL.idchild=pagamento.idexp  and EL.nlevel = {contabPhaseExp}        
                    left outer join expense impegno on impegno.idexp = EL.idparent                    
                    left outer   join expensemandate on impegno.idexp=expensemandate.idexp
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                        and (A.flag & 16) =0   and(isnull(U.flag,0) & 4) =0
                        and isnull(ed1.description,'') <> 'iva detraibile'
                        and isnull(ed1.description,'') <> 'iva detraibile split'
                        and isnull(ed1.description,'') <> 'iva detraibile intracom'
                        and not isnull(e1.idrelated,'') like 'ivapay§%'
                        and not isnull(ed1.description,'') like 'Ritenuta positiva su riga versamento %'
                        and not isnull(ed1.description,'') like 'Ritenuta negativa su riga versamento %'
                        and not ( isnull(ed1.description,'')  like 'Contributi positivi, Versamento,%'   and ed1.amount<0)
                        and not ( isnull(ed1.description,'') like 'Reversale su p.di giro su riga versamento%') 
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Debiti')
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Crediti')
                        and not ( isnull(ed1.description,'') like 'Lordi positivi, Riepilogo, riga%' and ed1.amount<0) 
                        and isnull(AA.flag,0)& 16  =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and (impegno.ymov is null or impegno.ymov >= {primoAnnoBudget}   )
                        and (expensemandate.yman is null or expensemandate.yman >= {primoAnnoBudget})
                        {noIva}


				order by E1.idrelated
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "expense";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckMovBudget.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DataTable config = Conn.RUN_SELECT("config", "*", null, $"ayear={esercizio}", null, false);
            DataRow rCfg = config.Rows[0];
            string noIva = "";
            foreach (string idacc in new[] { "idacc_ivapaymentsplit", "idacc_unabatable_split", "idacc_ivapayment", "idacc_ivarefund" }) {
                if (rCfg[idacc] == DBNull.Value) continue;
                noIva = QHS.AppAnd(noIva, QHS.CmpNe("ED1.idacc", rCfg[idacc]));
            }
            if (noIva != "") noIva = " AND " + noIva;
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            if (txtPrimoAnnoBudget.Text != "") {
                primoAnnoBudget = CfgFn.GetNoNullInt32(txtPrimoAnnoBudget.Text);
            }
            object contabPhaseExp = Conn.GetSys("mandatephase");
            object contabPhaseInc = Conn.GetSys("incomephase");
            string sql = $@"
            select  ED1.yentry,ED1.nentry,ED1.ndetail,ED1.amount, E1.idrelated 'idrelated scrittura', ED1.idrelated 'idrelated dettaglio',
                ED1.description 'desc.dettaglio', E1.description 'descr.scrittura', 
                AMM.codemotive 'causale principale',
                A.codeacc 'codice conto', A.title 'conto',
                AA.codeacc 'codice conto principale', AA.title 'conto princ.',
                U.codeupb 'cod.upb' , U.title 'upb' ,   accertamento.idinc,
                incasso.nmov as 'n.incasso', accertamento.nmov as 'n. accertamento', accertamento.ymov as 'anno accertamento',
                incomeestimate.yestim as 'anno c.attivo', incomeestimate.idestimkind as 'codice tipo contratto', incomeestimate.nestim as 'n. contratto' 
                from  entrydetail ED1 
			        join entry E1 on ED1.yentry=E1.yentry and ED1.nentry=E1.nentry
				    join account A on ED1.idacc=A.idacc
                    left outer join upb U on ED1.idupb=U.idupb
                    left outer join accmotivedetail AM on ED1.idaccmotive=AM.idaccmotive and AM.ayear=ED1.yentry
                    left outer join accmotive AMM on ED1.idaccmotive=AMM.idaccmotive 
                    left outer join account AA on AA.idacc=AM.idacc 
                    join income incasso on ED1.idrelated ='income§'+convert(varchar(20),incasso.idinc)+'§credit'
                    left outer join incomelink EL2 on EL2.idchild=incasso.idinc  and EL2.nlevel = {contabPhaseInc}    
                    left outer join income accertamento on accertamento.idinc = EL2.idparent            
                    left outer   join incomeestimate on accertamento.idinc=incomeestimate.idinc
				where E1.identrykind= 1  and E1.yentry={esercizio} and ED1.idepexp is null and ED1.idepacc is null and (A.flagaccountusage&48 <>0)
                        and (A.flag & 16) =0   and(isnull(U.flag,0) & 4) =0    and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and isnull(ed1.description,'') <> 'iva detraibile'
                        and isnull(ed1.description,'') <> 'iva detraibile split'
                        and isnull(ed1.description,'') <> 'iva detraibile intracom'
                        and not isnull(e1.idrelated,'') like 'ivapay§%'
                        and not isnull(ed1.description,'') like 'Ritenuta positiva su riga versamento %'
                        and not isnull(ed1.description,'') like 'Ritenuta negativa su riga versamento %'
                        and not ( isnull(ed1.description,'')  like 'Contributi positivi, Versamento,%'   and ed1.amount<0)
                        and not ( isnull(ed1.description,'') like 'Reversale su p.di giro su riga versamento%') 
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Debiti')
                        and ( isnull(e1.description,'') <> 'Scrittura a correzione apertura - Crediti')
                        and not ( isnull(ed1.description,'') like 'Lordi positivi, Riepilogo, riga%' and ed1.amount<0) 
                        and isnull(AA.flag,0)& 16  =0  and isnull(AA.flagaccountusage,256)&(64+128+256)<>0
                        and (accertamento.ymov is null or accertamento.ymov >= {primoAnnoBudget}   )
                        and (incomeestimate.yestim is null or incomeestimate.yestim >= {primoAnnoBudget})
                        {noIva}


				order by E1.idrelated
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "income";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckMovBudget.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        

        private void btnCheckDebitiEpilogoDare_Click(object sender, EventArgs e) {
            string sql = $@"
   select EE.idrelated,ED.yentry,ED.nentry,ED.ndetail,EE.description,ED.amount,ED.codeacc,ED.account,ED.registry,ED.codeupb,ED.upb,EE.yepexp,EE.nepexp,
		md.idmankind,md.yman,md.nman,md.rownum
		 from entrydetailview ED
	join entry E on ED.yentry=E.yentry and ED.nentry=E.nentry
	join account A on A.idacc=ED.idacc and A.flagaccountusage & 16  <>0  --debito
	left outer join epexp EE on EE.idepexp=ED.idepexp
	left outer join mandatedetail  md on EE.idrelated = 'man§'+
                         convert(varchar(30),MD.idmankind)+'§'+ 
                         convert(varchar(30),MD.yman)+'§'+
                         convert(varchar(30),MD.nman)+'§'+
                         convert(varchar(30),MD.rownum) 
	where ED.amount>0 ---avere
		and (EE.idepexp is null or EE.flagvariation='N')
		and E.identrykind=12
		and E.yentry={Conn.GetEsercizio()}
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtCheckDebitiEpilogoDare.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEpilogoAvereNoteCredito_Click(object sender, EventArgs e) {
            string sql = $@"
   select EE.idrelated,ED.yentry,ED.nentry,ED.ndetail,EE.description,ED.amount,ED.codeacc,ED.account,ED.registry,ED.codeupb,ED.upb,EE.yepexp,EE.nepexp,
		md.idmankind,md.yman,md.nman,md.rownum
		 from entrydetailview ED
	join entry E on ED.yentry=E.yentry and ED.nentry=E.nentry
	join account A on A.idacc=ED.idacc and A.flagaccountusage & 16  <>0  --debito
	 join epexp EE on EE.idepexp=ED.idepexp
	left outer join mandatedetail  md on EE.idrelated = 'man§'+
                         convert(varchar(30),MD.idmankind)+'§'+ 
                         convert(varchar(30),MD.yman)+'§'+
                         convert(varchar(30),MD.nman)+'§'+
                         convert(varchar(30),MD.rownum) 
	where ED.amount<0 ---dare
		and (EE.flagvariation='S')
		and E.identrykind=12
		and E.yentry={Conn.GetEsercizio()}
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEpilogoAvereNoteCredito.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEpilogoAvereCrediti_Click(object sender, EventArgs e) {
            string sql = $@"
   select EE.idrelated,ED.yentry,ED.nentry,ED.ndetail,EE.description,ED.amount,ED.codeacc,ED.account,ED.registry,ED.codeupb,ED.upb,EE.yepacc,EE.nepacc,
		md.idestimkind,md.yestim,md.nestim,md.rownum
		 from entrydetailview ED
	join entry E on ED.yentry=E.yentry and ED.nentry=E.nentry
	join account A on A.idacc=ED.idacc and A.flagaccountusage & 32  <>0  --credito
	left outer join epacc EE on EE.idepacc=ED.idepacc
	left outer join estimatedetail  md on EE.idrelated = 'estim§'+
                         convert(varchar(30),MD.idestimkind)+'§'+ 
                         convert(varchar(30),MD.yestim)+'§'+
                         convert(varchar(30),MD.nestim)+'§'+
                         convert(varchar(30),MD.rownum) 
	where ED.amount<0 ---dare
		and (EE.idepacc is null or EE.flagvariation='N')
		and E.identrykind=12
		and E.yentry={Conn.GetEsercizio()}
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEpilogoAvereCrediti.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnEpilogoDareCreditiNoteDebito_Click(object sender, EventArgs e) {
            string sql = $@"
   select EE.idrelated,ED.yentry,ED.nentry,ED.ndetail,EE.description,ED.amount,ED.codeacc,ED.account,ED.registry,ED.codeupb,ED.upb,EE.yepacc,EE.nepacc,
		md.idestimkind,md.yestim,md.nestim,md.rownum
		 from entrydetailview ED
	join entry E on ED.yentry=E.yentry and ED.nentry=E.nentry
	join account A on A.idacc=ED.idacc and A.flagaccountusage & 32  <>0  --credito
	join epacc EE on EE.idepacc=ED.idepacc
	left outer join estimatedetail  md on EE.idrelated = 'estim§'+
                         convert(varchar(30),MD.idestimkind)+'§'+ 
                         convert(varchar(30),MD.yestim)+'§'+
                         convert(varchar(30),MD.nestim)+'§'+
                         convert(varchar(30),MD.rownum) 
	where ED.amount>0 ---avere
		and ( EE.flagvariation='S')
		and E.identrykind=12
		and E.yentry={Conn.GetEsercizio()}
        ";
            DataTable t = Conn.SQLRunner(sql);

            if (t?.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtEpilogoDareCreditiNoteDebito.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnRigeneraLiqIva_Click(object sender, EventArgs e) {
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yivapay", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("ivapay", "yivapay,nivapay, dateivapay", "nivapay", filter,
                    null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("dateivapay")) || !(t.Columns.Contains("yivapay")) ||
                    !(t.Columns.Contains("nivapay"))
                    ) return;
                t.TableName = "ivapay";
            }


            btnRigeneraLiqIva.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("ivaPayDS");
                DataTable T = Conn.RUN_SELECT("ivapay", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;

                DataRow rv = T.Rows[0];
                D.Tables.Add(T);               
                txtCurrent.Text = "Liquidazione iva n." + r["nivapay"];
                rigeneraScrittura(T.Rows[0], "ivapay");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnRigeneraLiqIva.Visible = true;
        }

        private void btnImpegniFattDuplicati_Click(object sender, EventArgs e) {
            int primoAnnoBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("epexp", null, "min(yepexp)"));
            string sql =
                "select  e1.phase as 'Fase',e1.yepexp as 'Anno imp.',e1.nepexp as 'N.',e1.description as 'descrizione'," +
                " e1.totamount 'importo totale',invd.invoicekind 'tipo fatt.',invd.yinv 'anno fatt.', invd.ninv 'n.fatt.' from epexpview e1 " +
                "  join invoicedetailview invd on E1.idrelated = 'inv§'+" +
                "convert(varchar(30),invd.idinvkind)+'§'+" +
                "convert(varchar(30),invd.yinv)+'§'+" +
                "convert(varchar(30),invd.ninv)+'§'+" +
                "convert(varchar(30),invd.rownum) " +
                " where e1.totcurramount <> 0 " +
                " and invd.idmankind  is not null and invd.yman>="+primoAnnoBudget+
                " and invd.idepexp<>e1.idepexp "+
                " and e1.ayear  = " + esercizio;
            

          DataTable t = Conn.SQLRunner(sql);
            t.TableName = "epexp";
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, txtDoublePreimp.Text, t, Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato", "Avviso");
            }
        }

        private void btnSpeseFondoEconomale_Click(object sender, EventArgs e) {

            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("yoperation", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("pettycashoperationview", "idpettycash,yoperation, noperation,adate,pettycode,pettycash", "adate", filter,
                    null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("idpettycash")) || !(t.Columns.Contains("yoperation")) ||
                    !(t.Columns.Contains("noperation"))
                    || !(t.Columns.Contains("adate")) ) return;
                t.TableName = "pettycashoperation";
            }


            btnSpeseFondoEconomale.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("pettycashoperationDS");
                DataTable T = Conn.RUN_SELECT("pettycashoperation", "*", null,
                        QHS.MCmp(r, "idpettycash", "yoperation", "noperation"), null, false);
                if (T.Rows.Count == 0) continue;
                D.Tables.Add(T);
                txtCurrent.Text = $@"Piccola spesa {r["pettycode"]} n.{r["noperation"]}, fondo {r["pettycash"]}";
                rigeneraScrittura(T.Rows[0], "pettycashoperation");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnSpeseFondoEconomale.Visible = true;
        }

		private void btnImpegniContoIncoerentePadre_Click(object sender, EventArgs e) {
			string sql = " select epexp.nphase as 'fase', epexp.yepexp as 'anno impegno', epexp.nepexp as 'n. impegno', " +
					  	 " CurrA.codeacc as 'codice conto impegno', CurrA.title as 'Conto impegno'," +
						 " ParEpExp.nphase as 'fase preimpegno', ParEpExp.yepexp as 'anno preimpegno', ParEpExp.nepexp as 'n. preimpegno', " +
						 " ParA.codeacc as 'codice conto preimp.', ParA.title as 'Conto preimp.' " +
						 " from epexp " +
						 " join epexp ParEpExp  on epexp.paridepexp = ParEpExp.idepexp " +
						 " join epexpyear CurrEP  on epexp.idepexp = CurrEP.idepexp " +
						 " join epexpyear ParEP  on ParEP.idepexp = ParEpExp.idepexp and ParEP.ayear = CurrEP.ayear " +
						 " join account CurrA on CurrA.idacc = CurrEP.idacc " +
						 " join account ParA on ParA.idacc = ParEP.idacc " +
						 " where CurrEP.idacc<> ParEP.idacc " +
						 " and CurrEP.ayear= " + esercizio;

			DataTable t = Conn.SQLRunner(sql, false, 0);
			if (t?.Rows.Count > 0) {
				DataSet d = new DataSet();
				d.Tables.Add(t);
				t.TableName = "epexp";
				frmErrorView f = new frmErrorView(Meta.myHelpForm, txtImpegniContoIncoerentePadre.Text, t, Meta.Dispatcher, "default");
				createForm(f, this);
				f.Show(this);
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}

		private void btnImpegniUpbIncoerentePadre_Click(object sender, EventArgs e) {
			string sql = " select epexp.nphase as 'fase', epexp.yepexp as 'anno impegno', epexp.nepexp as 'n. impegno', " +
					  	 " CurrA.codeupb as 'codice UPB impegno', CurrA.title as 'UPB impegno'," +
						 " ParEpExp.nphase as 'fase preimpegno', ParEpExp.yepexp as 'anno preimpegno', ParEpExp.nepexp as 'n. preimpegno', " +
						 " ParA.codeupb as 'codice UPB preimp.', ParA.title as 'UPB preimp.' " +
						 " from epexp " +
						 " join epexp ParEpExp  on epexp.paridepexp = ParEpExp.idepexp " +
						 " join epexpyear CurrEP  on epexp.idepexp = CurrEP.idepexp " +
						 " join epexpyear ParEP  on ParEP.idepexp = ParEpExp.idepexp and ParEP.ayear = CurrEP.ayear " +
						 " join upb CurrA on CurrA.idupb = CurrEP.idupb " +
						 " join upb ParA on ParA.idupb = ParEP.idupb " +
						 " where CurrEP.idupb<> ParEP.idupb " +
						 " and CurrEP.ayear= " + esercizio;

			DataTable t = Conn.SQLRunner(sql, false, 0);
			if (t?.Rows.Count > 0) {
				DataSet d = new DataSet();
				d.Tables.Add(t);
				t.TableName = "epexp";
				frmErrorView f = new frmErrorView(Meta.myHelpForm, txtImpegniUpbIncoerentePadre.Text, t, Meta.Dispatcher, "default");
				createForm(f, this);
				f.Show(this);
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}

		private void btnAccertamentiUpbIncoerentePadre_Click(object sender, EventArgs e) {
			string sql = " select epacc.nphase as 'fase', epacc.yepacc as 'anno accertamento', epacc.nepacc as 'n. accertamento', " +
					  	 " CurrA.codeupb as 'codice UPB accertamento', CurrA.title as 'UPB accertamento'," +
						 " ParEpAcc.nphase as 'fase preaccertamento', ParEpAcc.yepacc as 'anno preaccertamento', ParEpAcc.nepacc as 'n. preaccertamento', " +
						 " ParA.codeupb as 'codice UPB preacc.', ParA.title as 'UPB preacc.' " +
						 " from epacc " +
						 " join epacc ParEpAcc  on epacc.paridepacc= ParEpAcc.idepacc" +
						 " join epaccyear CurrEP  on epacc.idepacc = CurrEP.idepacc " +
						 " join epaccyear ParEP  on ParEP.idepacc = ParEpAcc.idepacc and ParEP.ayear = CurrEP.ayear " +
						 " join upb CurrA on CurrA.idupb = CurrEP.idupb " +
						 " join upb ParA on ParA.idupb = ParEP.idupb " +
						 " where CurrEP.idupb<> ParEP.idupb " +
						 " and CurrEP.ayear= " + esercizio;

			DataTable t = Conn.SQLRunner(sql, false, 0);
			if (t?.Rows.Count > 0) {
				DataSet d = new DataSet();
				d.Tables.Add(t);
				t.TableName = "epacc";
				frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiUpbIncoerentePadre.Text, t, Meta.Dispatcher, "default");
				createForm(f, this);
				f.Show(this);
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}

		private void btnAccertamentiContoIncoerentePadre_Click(object sender, EventArgs e) {
			string sql = " select epacc.nphase as 'fase', epacc.yepacc as 'anno accertamento', epacc.nepacc as 'n. accertamento', " +
					  	 " CurrA.codeacc as 'codice Conto accertamento', CurrA.title as 'Conto accertamento'," +
						 " ParEpAcc.nphase as 'fase preaccertamento', ParEpAcc.yepacc as 'anno preaccertamento', ParEpAcc.nepacc as 'n. preaccertamento', " +
						 " ParA.codeacc as 'codice Conto preacc.', ParA.title as 'Conto preacc.' " +
						 " from epacc " +
						 " join epacc ParEpAcc  on epacc.paridepacc= ParEpAcc.idepacc" +
						 " join epaccyear CurrEP  on epacc.idepacc = CurrEP.idepacc " +
						 " join epaccyear ParEP  on ParEP.idepacc = ParEpAcc.idepacc and ParEP.ayear = CurrEP.ayear " +
						 " join account CurrA on CurrA.idacc = CurrEP.idacc " +
						 " join account ParA on ParA.idacc = ParEP.idacc " +
						 " where CurrEP.idacc<> ParEP.idacc " +
						 " and CurrEP.ayear= " + esercizio;

			DataTable t = Conn.SQLRunner(sql, false, 0);
			if (t?.Rows.Count > 0) {
				DataSet d = new DataSet();
				d.Tables.Add(t);
				t.TableName = "epacc";
				frmErrorView f = new frmErrorView(Meta.myHelpForm, txtAccertamentiContoIncoerentePadre.Text, t, Meta.Dispatcher, "default");
				createForm(f, this);
				f.Show(this);
			} else {
				show(this, "Nessun problema riscontrato", "Avviso");
			}
		}

        private void btnRigeneraLiqImposte_Click(object sender, EventArgs e) {
            //taxcode, ytaxpay, ntaxpay
            string cmd = txtComando.Text;
            string filter = QHS.CmpEq("ytaxpay", esercizio);
            DataTable t = new DataTable();
            if (cmd.Trim() == "") {
                t = Conn.RUN_SELECT("taxpay", "ytaxpay, ntaxpay, taxcode", "ntaxpay", filter,
                    null, false);
            }
            else {
                t = Meta.Conn.SQLRunner(cmd, false, 300);
                if ((t == null) || (t.Rows.Count == 0)) return;
                if (!(t.Columns.Contains("taxcode")) || !(t.Columns.Contains("ytaxpay")) ||
                    !(t.Columns.Contains("ntaxpay"))
                    ) return;
                t.TableName = "taxpay";
            }


            btnRigeneraLiqImposte.Visible = false;
            int n = t.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            foreach (DataRow r in t.Rows) {
                DataSet D = new DataSet("taxPayDS");
                DataTable T = Conn.RUN_SELECT("taxpay", "*", null, QHS.CmpKey(r), null, false);
                if (T.Rows.Count == 0) continue;

                DataRow rv = T.Rows[0];
                D.Tables.Add(T);
                txtCurrent.Text = "Liquidazione imposte n." + r["ntaxpay"];
                rigeneraScrittura(T.Rows[0], "taxpay");
                progBar.Increment(1);
                progBar.Update();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            btnRigeneraLiqImposte.Visible = true;
        }

        private void btnGen13_Click(object sender, EventArgs e) {
            string sql = " select "+
             " yentry as 'Esercizio', nentry as 'Numero', ndetail as '#Riga', " +
             " codeacc as 'Codice Conto', account as 'Conto', " +
             " codeupb as 'Cod. UPB', upb as 'UPB', " +
             " registry as 'Anagrafica', " +
             " description as 'Descr, Scritura', " +
             " detaildescription as 'Descr. Dettaglio', " +
             " give as 'Dare', " +
             " have as 'Avere' " +
             " from entrydetailview " +
             " WHERE " + QHS.CmpEq("yentry", Conn.GetEsercizio()) +
             " AND substring(idacc, 1, 2) <> substring(convert(varchar(4), yentry), 3, 2) ";

            DataTable t = Conn.SQLRunner(sql, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                t.TableName = "entrydetail";
                frmErrorView f = new frmErrorView(Meta.myHelpForm, btnGen13.Text + " "+ txtBoxGen13.Text, t,
                    Meta.Dispatcher, "default");
                createForm(f, this);
				f.Show(this);
            }
            else {
                show(this, "Nessun problema riscontrato nell'esercizio corrente.", "Avviso");
            }
        }

		private void btnCopy_Click(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            string valore = txtCurrent.Text;
            Clipboard.SetDataObject(valore);
            toolTipBtnCopiaAppunti.Show(valore + " Copiato!",btnCopy,1000);
        }


		//paytrans§2016§100
	}

}
