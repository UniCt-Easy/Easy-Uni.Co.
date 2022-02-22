
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using System.IO;
using System.Text;

namespace CopyTables {
    /// <summary>
    /// Summary description for Frm_CopyTables.
    /// </summary>
    public class FrmCopyTables : System.Windows.Forms.Form {
        private GroupBox groupBox1;
        private TextBox txtSourceUserPwd;
        private TextBox txtSourceUserName;
        private TextBox txtSourceDBName;
        private TextBox txtSourceServer;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private GroupBox groupBox2;
        private TextBox txtDestUserPwd;
        private TextBox txtDestUserName;
        private TextBox txtDestDBName;
        private TextBox txtDestServer;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCopyDBO;
        private Button btnCopyNonDBO;
        private Label labCurrTable;
        private ProgressBar pBarCurrTab;
        private Label label15;
        private ProgressBar pbarAll;
        private Button btnSourceCheck;
        private Button btnDestCheck;
        private Label label5;
        private TextBox txtTabellaStart;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmCopyTables() {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSourceUserPwd = new System.Windows.Forms.TextBox();
            this.txtSourceUserName = new System.Windows.Forms.TextBox();
            this.txtSourceDBName = new System.Windows.Forms.TextBox();
            this.txtSourceServer = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDestUserPwd = new System.Windows.Forms.TextBox();
            this.txtDestUserName = new System.Windows.Forms.TextBox();
            this.txtDestDBName = new System.Windows.Forms.TextBox();
            this.txtDestServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyDBO = new System.Windows.Forms.Button();
            this.btnCopyNonDBO = new System.Windows.Forms.Button();
            this.labCurrTable = new System.Windows.Forms.Label();
            this.pBarCurrTab = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.pbarAll = new System.Windows.Forms.ProgressBar();
            this.btnSourceCheck = new System.Windows.Forms.Button();
            this.btnDestCheck = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTabellaStart = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSourceUserPwd);
            this.groupBox1.Controls.Add(this.txtSourceUserName);
            this.groupBox1.Controls.Add(this.txtSourceDBName);
            this.groupBox1.Controls.Add(this.txtSourceServer);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database di ORIGINE";
            // 
            // txtSourceUserPwd
            // 
            this.txtSourceUserPwd.Location = new System.Drawing.Point(191, 97);
            this.txtSourceUserPwd.Name = "txtSourceUserPwd";
            this.txtSourceUserPwd.PasswordChar = '*';
            this.txtSourceUserPwd.Size = new System.Drawing.Size(200, 20);
            this.txtSourceUserPwd.TabIndex = 4;
            // 
            // txtSourceUserName
            // 
            this.txtSourceUserName.Location = new System.Drawing.Point(191, 73);
            this.txtSourceUserName.Name = "txtSourceUserName";
            this.txtSourceUserName.Size = new System.Drawing.Size(200, 20);
            this.txtSourceUserName.TabIndex = 3;
            // 
            // txtSourceDBName
            // 
            this.txtSourceDBName.Location = new System.Drawing.Point(191, 49);
            this.txtSourceDBName.Name = "txtSourceDBName";
            this.txtSourceDBName.Size = new System.Drawing.Size(200, 20);
            this.txtSourceDBName.TabIndex = 2;
            // 
            // txtSourceServer
            // 
            this.txtSourceServer.Location = new System.Drawing.Point(191, 25);
            this.txtSourceServer.Name = "txtSourceServer";
            this.txtSourceServer.Size = new System.Drawing.Size(200, 20);
            this.txtSourceServer.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(79, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 23);
            this.label24.TabIndex = 14;
            this.label24.Text = "Password dipartimento";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(15, 73);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(176, 23);
            this.label23.TabIndex = 13;
            this.label23.Text = "Nome dipartimento";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(23, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(168, 23);
            this.label22.TabIndex = 12;
            this.label22.Text = "Nome del database";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(87, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 11;
            this.label21.Text = "Nome server";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDestUserPwd);
            this.groupBox2.Controls.Add(this.txtDestUserName);
            this.groupBox2.Controls.Add(this.txtDestDBName);
            this.groupBox2.Controls.Add(this.txtDestServer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database di Destinazione";
            // 
            // txtDestUserPwd
            // 
            this.txtDestUserPwd.Location = new System.Drawing.Point(191, 97);
            this.txtDestUserPwd.Name = "txtDestUserPwd";
            this.txtDestUserPwd.PasswordChar = '*';
            this.txtDestUserPwd.Size = new System.Drawing.Size(200, 20);
            this.txtDestUserPwd.TabIndex = 4;
            // 
            // txtDestUserName
            // 
            this.txtDestUserName.Location = new System.Drawing.Point(191, 73);
            this.txtDestUserName.Name = "txtDestUserName";
            this.txtDestUserName.Size = new System.Drawing.Size(200, 20);
            this.txtDestUserName.TabIndex = 3;
            // 
            // txtDestDBName
            // 
            this.txtDestDBName.Location = new System.Drawing.Point(191, 49);
            this.txtDestDBName.Name = "txtDestDBName";
            this.txtDestDBName.Size = new System.Drawing.Size(200, 20);
            this.txtDestDBName.TabIndex = 2;
            // 
            // txtDestServer
            // 
            this.txtDestServer.Location = new System.Drawing.Point(191, 25);
            this.txtDestServer.Name = "txtDestServer";
            this.txtDestServer.Size = new System.Drawing.Size(200, 20);
            this.txtDestServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(79, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Password dipartimento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nome dipartimento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nome del database";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(87, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nome server";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCopyDBO
            // 
            this.btnCopyDBO.ForeColor = System.Drawing.Color.Red;
            this.btnCopyDBO.Location = new System.Drawing.Point(94, 327);
            this.btnCopyDBO.Name = "btnCopyDBO";
            this.btnCopyDBO.Size = new System.Drawing.Size(285, 23);
            this.btnCopyDBO.TabIndex = 4;
            this.btnCopyDBO.Text = "Copia Tabelle DBO (svuotando le esistenti)";
            this.btnCopyDBO.UseVisualStyleBackColor = true;
            this.btnCopyDBO.Click += new System.EventHandler(this.btnCopyDBO_Click);
            // 
            // btnCopyNonDBO
            // 
            this.btnCopyNonDBO.Location = new System.Drawing.Point(435, 327);
            this.btnCopyNonDBO.Name = "btnCopyNonDBO";
            this.btnCopyNonDBO.Size = new System.Drawing.Size(296, 23);
            this.btnCopyNonDBO.TabIndex = 5;
            this.btnCopyNonDBO.Text = "Copia le tabelle NON DBO (svuotando i dati esistenti)";
            this.btnCopyNonDBO.UseVisualStyleBackColor = true;
            this.btnCopyNonDBO.Click += new System.EventHandler(this.btnCopyNonDBO_Click);
            // 
            // labCurrTable
            // 
            this.labCurrTable.AutoSize = true;
            this.labCurrTable.Location = new System.Drawing.Point(9, 475);
            this.labCurrTable.Name = "labCurrTable";
            this.labCurrTable.Size = new System.Drawing.Size(211, 13);
            this.labCurrTable.TabIndex = 12;
            this.labCurrTable.Text = "Stato di avanzamento della tabella corrente";
            // 
            // pBarCurrTab
            // 
            this.pBarCurrTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarCurrTab.Location = new System.Drawing.Point(12, 491);
            this.pBarCurrTab.Name = "pBarCurrTab";
            this.pBarCurrTab.Size = new System.Drawing.Size(771, 26);
            this.pBarCurrTab.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 411);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(167, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Stato di avanzamento della copia ";
            // 
            // pbarAll
            // 
            this.pbarAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbarAll.Location = new System.Drawing.Point(12, 427);
            this.pbarAll.Name = "pbarAll";
            this.pbarAll.Size = new System.Drawing.Size(771, 26);
            this.pbarAll.TabIndex = 9;
            // 
            // btnSourceCheck
            // 
            this.btnSourceCheck.Location = new System.Drawing.Point(508, 94);
            this.btnSourceCheck.Name = "btnSourceCheck";
            this.btnSourceCheck.Size = new System.Drawing.Size(139, 23);
            this.btnSourceCheck.TabIndex = 13;
            this.btnSourceCheck.Text = "Verifica connettività";
            this.btnSourceCheck.UseVisualStyleBackColor = true;
            this.btnSourceCheck.Click += new System.EventHandler(this.btnSourceCheck_Click);
            // 
            // btnDestCheck
            // 
            this.btnDestCheck.Location = new System.Drawing.Point(508, 211);
            this.btnDestCheck.Name = "btnDestCheck";
            this.btnDestCheck.Size = new System.Drawing.Size(139, 23);
            this.btnDestCheck.TabIndex = 14;
            this.btnDestCheck.Text = "Verifica connettività";
            this.btnDestCheck.UseVisualStyleBackColor = true;
            this.btnDestCheck.Click += new System.EventHandler(this.btnDestCheck_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inizia a copiare dalla tabella:";
            // 
            // txtTabellaStart
            // 
            this.txtTabellaStart.Location = new System.Drawing.Point(158, 368);
            this.txtTabellaStart.Name = "txtTabellaStart";
            this.txtTabellaStart.PasswordChar = '*';
            this.txtTabellaStart.Size = new System.Drawing.Size(200, 20);
            this.txtTabellaStart.TabIndex = 16;
            // 
            // FrmCopyTables
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(797, 545);
            this.Controls.Add(this.txtTabellaStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDestCheck);
            this.Controls.Add(this.btnSourceCheck);
            this.Controls.Add(this.labCurrTable);
            this.Controls.Add(this.pBarCurrTab);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pbarAll);
            this.Controls.Add(this.btnCopyNonDBO);
            this.Controls.Add(this.btnCopyDBO);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCopyTables";
            this.Text = "FrmCopyTables";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnSourceCheck_Click(object sender, EventArgs e) {
            DataAccess Conn = new DataAccess("x",
                txtSourceServer.Text.Trim(),
                txtSourceDBName.Text.Trim(),
                txtSourceUserName.Text.Trim(),
                txtSourceUserPwd.Text.Trim(),
                DateTime.Today.Year, DateTime.Today);
            try {
                if (Conn.Open()) {
                    DataTable TNonDBO = Conn.SQLRunner(
                        "select name from sysobjects where  xtype='U' and uid=user_id() order by name", false);
                    DataTable TDBO = Conn.SQLRunner(
                        "select name from sysobjects where  xtype='U' and uid=user_id('dbo') order by name", false);
                    int NNondbo = TNonDBO.Rows.Count;
                    int NDBO = TDBO.Rows.Count;
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Trovate " + NDBO.ToString() + " tabelle DBO e " + NNondbo.ToString() +
                            " tabelle NON DBO");
                    Conn.Close();
                }
                else {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stato possibile connettersi al db." + Conn.LastError);
                }
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                Conn.Close();
            }

        }

        private void btnDestCheck_Click(object sender, EventArgs e) {
            DataAccess Conn = new DataAccess("x",
               txtDestServer.Text.Trim(),
               txtDestDBName.Text.Trim(),
               txtDestUserName.Text.Trim(),
               txtDestUserPwd.Text.Trim(),
               DateTime.Today.Year, DateTime.Today);
            try {
                if (Conn.Open()) {
                    DataTable TNonDBO = Conn.SQLRunner(
                        "select name from sysobjects where  xtype='U' and uid=user_id() order by name", false);
                    DataTable TDBO = Conn.SQLRunner(
                        "select name from sysobjects where  xtype='U' and uid=user_id('dbo') order by name", false);
                    int NNondbo = TNonDBO.Rows.Count;
                    int NDBO = TDBO.Rows.Count;
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Trovate " + NDBO.ToString() + " tabelle DBO e " + NNondbo.ToString() +
                            " tabelle NON DBO");
                    Conn.Close();
                }
                else {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stato possibile connettersi al db." + Conn.LastError);
                }
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                Conn.Close();
            }
        }

        private void btnCopyDBO_Click(object sender, EventArgs e) {
            copytable(true);
        }
        private void btnCopyNonDBO_Click(object sender, EventArgs e) {
            copytable(false);
        }


        void copytable(bool DBO) {
            DataAccess SourceDip = new AllLocal_DataAccess("x",
           txtSourceServer.Text.Trim(),
           txtSourceDBName.Text.Trim(),
           txtSourceUserName.Text.Trim(),
           txtSourceUserPwd.Text.Trim(),
           DateTime.Today.Year, DateTime.Today);

            DataAccess DestDip = new AllLocal_DataAccess("x",
               txtDestServer.Text.Trim(),
               txtDestDBName.Text.Trim(),
               txtDestUserName.Text.Trim(),
               txtDestUserPwd.Text.Trim(),
               DateTime.Today.Year, DateTime.Today);

            btnCopyNonDBO.Enabled = false;
            btnCopyDBO.Enabled = false;
            Cursor = Cursors.WaitCursor;
            //DestDip.SQLRunner("exec sp_MSforeachtable 'ALTER TABLE ? DISABLE TRIGGER ALL'", false, -1);

            DestDip.CallSP("enable_disable_triggers",
                                       new object[2]{txtDestUserName.Text.Trim(),
			                          'D'},
                                       false,
                                       500);
            string tabellastart = txtTabellaStart.Text.Trim().ToLower();

            DataTable TName;
            if (DBO) {
                TName = SourceDip.SQLRunner(
                "select name from sysobjects where  xtype='U' and uid=user_id('dbo') order by name", false);
            }
            else {
                TName = SourceDip.SQLRunner(
                    "select name from sysobjects where  xtype='U' and uid=user_id() order by name", false);

            }

            string dest_owner = txtDestUserName.Text.Trim();
            if (DBO) dest_owner = "DBO";



            pbarAll.Maximum = TName.Rows.Count;
            pbarAll.Value = 0;
            Application.DoEvents();
            bool skipping = false;
            if (tabellastart != "") skipping = true;

            foreach (DataRow RT in TName.Rows) {
                string tablename = RT["name"].ToString().ToLower();
                pbarAll.Increment(1);
                pBarCurrTab.Value = 0;
                Application.DoEvents();
                if (skipping && (tablename != tabellastart)) continue;
                if (skipping && (tablename == tabellastart)) {
                    skipping = false;
                }

                bool res = CopyTable(SourceDip, DestDip, dest_owner, tablename, true, DBO);
                if (!res) {
                    Cursor = Cursors.Default;
                    DestDip.CallSP("enable_disable_triggers",
                                              new object[2]{txtDestUserName.Text.Trim(),
			                          'E'},
                                      false,
                                      500);
                    btnCopyNonDBO.Enabled = true;
                    btnCopyDBO.Enabled = true;
                    DestDip.Destroy();
                    SourceDip.Destroy();
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Copia non completata","Errore");
                    return;
                }
            }

            DestDip.CallSP("enable_disable_triggers",
                               new object[2]{txtDestUserName.Text.Trim(),
			                          'E'},
                       false,
                       500);
            Cursor = Cursors.Default;
            btnCopyNonDBO.Enabled = true;
            btnCopyDBO.Enabled = true;
            DestDip.Destroy();
            SourceDip.Destroy();
            pbarAll.Value = 0;
            pBarCurrTab.Value = 0;

            MetaFactory.factory.getSingleton<IMessageShower>().Show("Copia completata con successo");

        }
        string[] toskip = new string[] {
                "abatement","abatementcode","acquirekind","adminoperation","advice","affinity","allowancerule",
                "allowanceruledetail","apactivitykind","apcontractkind","apmanager","apregistrykind","authstatus",
                "buildcf","casualcontractexemption","casualdeduction","cbimotive","certificationmodel","checkup",
                "connector","consultingkind","contractlength","customdirectrel","customdirectrelcol",
                "customindirectrel","customindirectrelcol","customoperator","customselection","deduction",
                "deductioncode","durckind","emenscontractkind","epcontext","epoperation","expirationkind",
                "f24epsanctionkind","financialactivity","fiscaltaxregion","foreignallowancerule",
                "foreignallowanceruledetail","foreigncountry","foreigngroup","foreigngrouprule",
                "foreigngroupruledetail","geo_agency","geo_cap","geo_cf","geo_city","geo_city_agency","geo_code",
                "geo_country","geo_country_agency","geo_nation","geo_nation_agency","geo_region","geo_region_agency",
                "inpsactivity","inpscenter","intrastatcode","intrastatkind","intrastatmeasure","intrastatnation",
                "intrastatpaymethod","intrastatservice","intrastatsupplymethod","itinerationparameter",
                "itinerationrefundkindgroup","itinerationrefundkindgroupreduction","itinerationrefundrule"
                ,"itinerationrefundruledetail","mod770_details","monthname","motive770","motive770service",
                "otherinsurance","position","positionworkcontract","reduction","reductionrule",
                "reductionruledetail","registryclass","residence","restrictedfunction","securitycondition",
                "securityvar","sortabletable","taxablekind","taxableminmax","variationkind","workingtime"
            };

        bool CopyTable(DataAccess Source, DataAccess Dest, string dest_owner,
                    string tablename,bool clear, bool dbo) {

            if (tablename == "dtproperties") return true;
            foreach (string skip in toskip) {
                if (tablename == skip) return true;
            }
            

            DataTable T = Source.RUN_SELECT(tablename, "*", null, null, null, false);
            if (T.Rows.Count == 0) return true;


            DataTable Exists = Dest.SQLRunner("SELECT * FROM SYSOBJECTS WHERE NAME = "
                                + QueryCreator.quotedstrvalue(tablename, true) + " and xtype='U' and uid=user_id( "
                                + QueryCreator.quotedstrvalue(dest_owner, true) + ")", false);
            if (Exists.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Tabella " + tablename +
                                        " non trovata nel nuovo dipartimento. Questa tabella sarà saltata. ",
                                        "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            
            if (clear) {
                Dest.SQLRunner("DELETE FROM " + tablename, false);
            }
            else {
                int Num = Dest.RUN_SELECT_COUNT(tablename, null, false);
                if (Num > 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("La tabella " + tablename + " sarà saltata perché contiene già " +
                        Num.ToString() + " righe nel db di destinazione.", "Avviso");
                    return true;
                }
            }
            bool res = CopyTable(T, Dest,dest_owner);
            if (!res) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore nella copia della tabella " + tablename);
                return false;
            }

            return true;
        }



        bool CopyTable(DataTable TT, DataAccess Dest,string dest_owner) {
            int NN = 0;
            try {
                DataTable Cols = Dest.SQLRunner("sp_columns " + TT.TableName + ",'" + dest_owner + "'");


                if (TT.Rows.Count == 0) return true;
                string insert = "INSERT INTO " + TT.TableName + " VALUES(";//(
                //				foreach (DataColumn C in TT.Columns) {
                //					insert += C.ColumnName + ",";
                //				}
                //				insert = insert.Remove(insert.Length - 1, 1);
                //				insert += ") VALUES (";
                int count = 0;
                StringBuilder s = new StringBuilder();
                string err;

                labCurrTable.Text = "Stato di avanzamento della tabella " + TT.TableName;
                pBarCurrTab.Maximum = TT.Rows.Count;
                Application.DoEvents();

                foreach (DataRow row in TT.Rows) {
                    pBarCurrTab.Increment(1);
                    count++;
                    StringBuilder values = GetSQLDataValues(row, Cols);
                    s.Append( insert);
                    s.Append( values.ToString());
                    if (count == 10) {
                        Dest.SQLRunner(s.ToString(), 0, out err);
                        NN++;
                        if (NN == 800) {
                            Application.DoEvents();
                            GC.Collect();
                            NN = 0;
                        }
                        if (err != null) {
                            QueryCreator.ShowError(this, "Errore", err);
                            StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                            fsw.Write(s.ToString());
                            fsw.Close();
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore durante la copia della tabella " + TT.TableName + "\r\nLo script lanciato si trova nel file 'temp.sql'");

                            return false;
                        }
                        s = new StringBuilder();
                        Application.DoEvents();
                        count = 0;
                    }
                }
                if (count >0) {
                    Dest.SQLRunner(s.ToString(), 0, out err);
                    if (err != null) {
                        QueryCreator.ShowError(this, "Errore", err);
                        StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                        fsw.Write(s.ToString());
                        fsw.Close();
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore durante la copia di " + TT.TableName + "\r\nLo script lanciato si trova nel file 'temp.sql'");

                        return false;
                    }
                    count = 0;
                    s = new StringBuilder();
                }
                Application.DoEvents();
                GC.Collect();
                return true;
            }
            catch {
                return false;
            }

        }


        private StringBuilder GetSQLDataValues(DataRow row, DataTable Cols) {
            StringBuilder s = new StringBuilder();
            int colcount = Cols.Rows.Count;
            for (int i = 0; i < colcount; i++) {
                string valore = "";
                string colname = Cols.Rows[i]["COLUMN_NAME"].ToString();
                if (row.Table.Columns.Contains(colname))
                    valore = QueryCreator.quotedstrvalue(row[colname], true);
                else
                    valore = "NULL";
                s.Append(valore);
                if (i<colcount-1) s.Append(",");
            }
            //s = s.Remove(s.Length - 1, 1);
            s.Append(")\r\n");
            return s;
        }


    }
}
