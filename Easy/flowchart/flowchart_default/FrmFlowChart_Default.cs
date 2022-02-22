
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
using System.Collections;

namespace flowchart_default {
    public partial class FrmFlowChart_Default : MetaDataForm {
        MetaData Meta;
        string filteresercizio;
        public FrmFlowChart_Default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            filteresercizio = "(ayear='" + Meta.GetSys("esercizio") + "')";
            GetData.SetStaticFilter(DS.flowchart, filteresercizio);
            GetData.SetSorting(DS.flowchart, "printingorder");
            GetData.SetStaticFilter(DS.fin, filteresercizio);
            GetData.SetStaticFilter(DS.sortingview, filteresercizio);
            GetData.CacheTable(DS.manager, null, "title", false);
            GetData.CacheTable(DS.mandatekind, null, "description", false);
            GetData.CacheTable(DS.estimatekind, null, "description", false);
            GetData.CacheTable(DS.authagency, null, "title", false);
            GetData.CacheTable(DS.authmodel, null, "title", false);
            GetData.CacheTable(DS.invoicekind, null, "description", false);
            GetData.CacheTable(DS.pettycash, null, "description", false);
            GetData.CacheTable(DS.customuser, null, "username", false);
            GetData.CacheTable(DS.restrictedfunction, null, "description", false);
            PostData.MarkAsTemporaryTable(DS.no_table, false);
            GetData.DenyClear(DS.no_table);
            GetData.LockRead(DS.no_table);
            DataTable My = Meta.Conn.SQLRunner("select distinct modulename,groupname from report", true);
            foreach (DataRow R in My.Rows) {
                DataRow newR = DS.no_table.NewRow();
                newR["modulename"] = R["modulename"];
                newR["groupname"] = R["groupname"];
                DS.no_table.Rows.Add(newR);
            }
            DS.no_table.AcceptChanges();

            DataAccess.SetTableForReading(DS.no_table1, "no_table");
            PostData.MarkAsTemporaryTable(DS.no_table1, false);
            GetData.DenyClear(DS.no_table1);
            GetData.LockRead(DS.no_table1);
            DataTable My1 = Meta.Conn.SQLRunner("select distinct modulename from exportfunction", true);
            foreach (DataRow R1 in My1.Rows) {
                DataRow newR1 = DS.no_table1.NewRow();
                newR1["modulename"] = R1["modulename"];
                DS.no_table1.Rows.Add(newR1);
            }

            string filter = "(ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")";
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
               filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);

                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    grpAnalitico.Visible = false;
                }
 
            }

            DS.no_table1.AcceptChanges();

        }

      


        void SetGBoxClass(int num, object sortingkind) {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + nums);
                G.Visible = false;
            }
            else {
                string filter = Meta.QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + nums);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }


        object GetCtrlByName (string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        public void MetaData_BeforeFill() {
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
                ereditaInfoNodoPadre();
            }
        }

        private void ereditaInfoNodoPadre() {
            DataRow rFlowChart = HelpForm.GetLastSelected(DS.flowchart);
            if (rFlowChart == null) return;
            object paridFlowChart = rFlowChart["paridflowchart"];
            string filter = "(idflowchart = " + QueryCreator.quotedstrvalue(paridFlowChart, true) + ")";
            DataTable tFin = DataAccess.CreateTableByName(Meta.Conn, "flowchartfin", "*");
            tFin.Columns.Add("!codicefin");
            tFin.Columns.Add("!fin");
            
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tFin, null, filter, null, true);
            valorizzaCampiTemporanei(tFin, "fin");

            fillTable(tFin);

            DataTable tUpb = DataAccess.CreateTableByName(Meta.Conn, "flowchartupb", "*");
            tUpb.Columns.Add("!codiceupb");
            tUpb.Columns.Add("!upb");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tUpb, null, filter, null, true);
            valorizzaCampiTemporanei(tUpb, "upb");
            fillTable(tUpb);

            DataTable tManager = DataAccess.CreateTableByName(Meta.Conn, "flowchartmanager", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tManager, null, filter, null, true);
            fillTable(tManager);

            DataTable tAuthAgency = DataAccess.CreateTableByName(Meta.Conn, "flowchartauthagency", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAuthAgency, null, filter, null, true);
            fillTable(tAuthAgency);

            DataTable tAuthModel = DataAccess.CreateTableByName(Meta.Conn, "flowchartauthmodel", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAuthModel, null, filter, null, true);
            fillTable(tAuthModel);

            DataTable tEstimatekind = DataAccess.CreateTableByName(Meta.Conn, "flowchartestimatekind", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tEstimatekind, null, filter, null, true);
            fillTable(tEstimatekind);

            DataTable tMandatekind = DataAccess.CreateTableByName(Meta.Conn, "flowchartmandatekind", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tMandatekind, null, filter, null, true);
            fillTable(tMandatekind);

            DataTable tInvoicekind = DataAccess.CreateTableByName(Meta.Conn, "flowchartinvoicekind", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInvoicekind, null, filter, null, true);
            fillTable(tInvoicekind);

            DataTable tPettycash = DataAccess.CreateTableByName(Meta.Conn, "flowchartpettycash", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tPettycash, null, filter, null, true);
            fillTable(tPettycash);


            DataTable tResFun = DataAccess.CreateTableByName(Meta.Conn, "flowchartrestrictedfunction", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tResFun, null, filter, null, true);
            fillTable(tResFun);

            DataTable tModGroup = DataAccess.CreateTableByName(Meta.Conn, "flowchartmodulegroup", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tModGroup, null, filter, null, true);
            fillTable(tModGroup);

            DataTable tExpMod = DataAccess.CreateTableByName(Meta.Conn, "flowchartexportmodule", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tExpMod, null, filter, null, true);
            fillTable(tExpMod);


        }

        private void fillTable(DataTable t) {
            DataRow [] RowsFC = DS.flowchart.Select(null, null, DataViewRowState.Added);
            if (RowsFC.Length == 0) return;
            DataRow Curr = RowsFC[0];

            string tName = t.TableName;
            MetaData MetaTable = MetaData.GetMetaData(this, tName);
            MetaTable.SetDefaults(DS.Tables[tName]);
            foreach (DataRow r in t.Rows) {
                DataRow rTable = MetaTable.Get_New_Row(Curr, DS.Tables[tName]);
                foreach (DataColumn C in t.Columns) {
                    if ((C.ColumnName == "idflowchart") ||
                    (C.ColumnName == "ct") || (C.ColumnName == "cu") || (C.ColumnName == "lt") || (C.ColumnName == "lu"))
                        continue;
                    rTable[C.ColumnName] = r[C.ColumnName];
                }
            }
        }

        private void valorizzaCampiTemporanei(DataTable t, string tName) {
            string field = "";
            Hashtable eCampi = new Hashtable();
            switch(tName) {
                case "fin": {
                    field = "idfin";
                    eCampi["!codicefin"] = "codefin";
                    eCampi["!fin"] = "title";
                    break;
                }
                case "upb": {
                    field = "idupb";
                    eCampi["!codiceupb"] = "codeupb";
                    eCampi["!upb"] = "title";
                    break;
                }
            }
            DataTable tTemp = DataAccess.CreateTableByName(Meta.Conn, tName, "*");
            foreach (DataRow r in t.Rows) {
                string filter = "(" + field + " = " + QueryCreator.quotedstrvalue(r[field], false) + ")";
                if (tTemp.Select(filter).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tTemp, null, filter, null, true);
                }
                DataRow[] RIGHE = tTemp.Select(filter);
                if (RIGHE.Length == 0) continue;
                DataRow riga = RIGHE[0];
                foreach (DictionaryEntry campo in eCampi) {
                    r[campo.Key.ToString()] = riga[campo.Value.ToString()];
                }
            }
        }

        public void MetaData_BeforePost() {
            if (DS.flowchart.Rows.Count == 0) {
                return; 
            }
            DataRow R = DS.flowchart.Rows[0];
            if (R.RowState == DataRowState.Deleted) {
                foreach (DataRow A in DS.flowchartusersorting.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
            }
        }

        public void MetaData_AfterFill() {
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
            //abilita/disabilita i controlli

            bool ModoInsert = Meta.InsertMode;
            cmbLivello.Enabled = false;

            if (ModoInsert) {
                DataRow R = HelpForm.GetLastSelected(DS.flowchart);
                if (R == null) return;
                txtCodice.ReadOnly = false;
                txtOrdineStampa.ReadOnly = false;
                if (Operativo(R)) {
                    EnableControls(true);
                }
                else {
                    EnableControls(false);
                }
            }
            Meta.MarkTableAsNotEntityChild(DS.flowchartuser);
            Meta.MarkTableAsNotEntityChild(DS.flowchartusersorting);

        }

        public void MetaData_AfterClear() {
            EnableControls(true);
            cmbLivello.Enabled = true;
            txtCodice.ReadOnly = false;
            txtOrdineStampa.ReadOnly = false;
            Meta.CanInsert = false;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (R == null) return;

            if (T.TableName == "geo_cityview") {
                if (R != null) {
                    aggiornaCap(R["idcity"]);
                }
            }
            if (T.TableName != "flowchart") return;
            bool ModoInsert = Meta.InsertMode;
            cmbLivello.Enabled = false;
            txtOrdineStampa.ReadOnly = false;
            if (Operativo(R)) {
                EnableControls(true);
                txtCodice.ReadOnly = (!ModoInsert);
            }
            else {
                EnableControls(false);
                txtCodice.ReadOnly = true;
            }

        }

        private void aggiornaCap(object idComune) {
            if (Meta.Conn.RUN_SELECT_COUNT("geo_city_agency", "(idagency=3) and (idcity=" + idComune + ")", true) == 1) {
                object capPrincipale = Meta.Conn.DO_READ_VALUE("geo_city_agency",
                    "(idagency=3) and (idcode=1) and (idcity=" + idComune + ")", "value");
                if (capPrincipale != null) {
                    string cap = textBoxCap.Text;
                    if (cap == "") {
                        textBoxCap.Text = capPrincipale.ToString();
                    }
                }
            }
        }

        private void EnableControls(bool enable) {
            grpUPB.Enabled = enable;
            grpBilancio.Enabled = enable;
            listManager.Visible = enable;
            listAuthAgency.Visible = enable;
            listAuthModel.Visible = enable;
            listResFun.Visible = enable;
            grpContatto.Enabled = enable;
            gboxUser.Enabled = enable;
            listReport.Visible = enable;
            listViewExpo.Visible = enable;
            grpAnalitico.Enabled = enable;
        }

        private bool Operativo(DataRow R) {
            if (R == null) return false;
            string livellorow = R["nlevel"].ToString();
            DataRow[] Res = DS.flowchartlevel.Select("(nlevel='" + livellorow + "')AND" +
                filteresercizio);
            if (Res.Length != 1) return false;
            string operativo = Res[0]["flagusable"].ToString().ToUpper();
            if (operativo == "N") return false;
            return true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }
    }
}
