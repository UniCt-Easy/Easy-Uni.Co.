
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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using funzioni_configurazione;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using SituazioneViewer;

namespace accountprevisionview_prevision
{
	/// <summary>
	/// Summary description for Frm_accountprevisionview_prevision.
	/// </summary>
	public class Frm_accountprevisionview_prevision : System.Windows.Forms.Form
	{
		MetaData Meta;
		decimal lastPrevCorr = 0;
        decimal lastPrevCorr2 = 0;
        decimal lastPrevCorr3 = 0;
        decimal lastPrevCorr4 = 0;
        decimal lastPrevCorr5 = 0;
        public accountprevisionview_prevision.vistaForm DS;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.GroupBox grpPrevisione;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        public GroupBox MetaDataDetail2;
        private TextBox txtCodiceUpb;
        private Label label1;
        private TextBox txtDenominazioneUpb;
        private Label label2;
        private GroupBox grpImporto5;
        private TextBox txtImporto5;
        private GroupBox grpImporto4;
        private TextBox txtImporto4;
        private GroupBox grpImporto3;
        private TextBox txtImporto3;
        private GroupBox grpImporto2;
        private TextBox txtImporto2;
        private GroupBox grpImporto1;
        private TextBox txtImporto1;
        private Button btnHideUnused;
        private TabPage tabPage1;
        private Button btnCalcolaTotali;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private CheckBox chkUpbChilds;
        private Label label11;
        private Button btnImpegniBudget;
        private TextBox txtBudgetIniziale;
        private Label label6;
        private Button btnBudgetIniziale;
        private TextBox txtImpegniBudget;
        private TextBox txtPreimpegniBudget;
        private Label label7;
        private Label label10;
        private Button btnVarBudget;
        private Button btnPreimpegniBudget;
        private Label label8;
        private TextBox txtBudgetDisponibile;
        private TextBox txtVariazioniBudget;
        private Label label9;
        private TextBox txtVarPreimpegni;
        private Label label3;
        private Button btnVarPreimpegni;
        private Button btnVarImpegni;
        private Label label4;
        private TextBox txtVarImpegni;
        private Button btnVarAccertamenti;
        private Label label15;
        private TextBox txtVarAccertamenti;
        private TextBox txtVarPreaccertamenti;
        private Label label16;
        private Button btnVarPreaccertamenti;
        private Button btnAccertamentiBudget;
        private Label label17;
        private TextBox txtAccertamentiBudget;
        private TextBox txtPreaccertamentiBudget;
        private Label label19;
        private Button btnPreaccertamentiBudget;
        private TextBox txtScrittureAvere;
        private Label label14;
        private TextBox txtScrittureDare;
        private Label label13;
        private Label label12;
        private Label label5;
        private TextBox txtBudgetAttuale;
        private Button btnScrittureDare;
        private Button btnScrittureAvere;
        private System.ComponentModel.IContainer components;

		public Frm_accountprevisionview_prevision()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

	    private object idUpbMain;
	    private DataAccess Conn;

        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            Meta.CanInsert = false;
            Meta.CanCancel = false;
            object idUpb = DBNull.Value;
            Conn = Meta.Conn; 

            int esercizio = (int)Meta.GetSys("esercizio");

            if (Meta.edit_type != "relation") {
                idUpb = Meta.ExtraParameter.ToString();
            }

            if (Meta.edit_type == "relation") {	//Extract parameter from context filter 
                string fieldname = "idupb";
                string ContextFilter = Meta.GetSys("Parent2Filter") as string;
                if (ContextFilter== null) ContextFilter = Meta.ContextFilter;
                int posizione = ContextFilter.IndexOf(fieldname); // Meta.ContextFilter.IndexOf(fieldname);
                int start = posizione + fieldname.Length + 2;//skips fieldname='
                int stop = ContextFilter.IndexOf("'", start);
                if (posizione != -1) {
                    idUpb = ContextFilter.Substring(start, stop - start);
                }
            }

            object upbname = Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idUpb), "title");//.ToString();
            if (upbname != null) {
                Meta.Name = "Budget dell'UPB \"" + upbname.ToString() + "\"";
            }
            Meta.DefaultListType = "prevision";//+idUpb;

            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            string filter = QHS.AppAnd(QHS.CmpEq("idupb", idUpb), filterEsercizio);
		    idUpbMain = idUpb;
            GetData.SetStaticFilter(DS.accountprevisionview, filter);
            GetData.SetStaticFilter(DS.accountyear, filter);
            GetData.CacheTable(DS.account, filterEsercizio, null, false);
            GetData.CacheTable(DS.upb, QHS.CmpEq("idupb", idUpb), null, false);
            GetData.CacheTable(DS.accountlevel, filterEsercizio, "nlevel", false);
            GetData.SetSorting(DS.accountprevisionview, "printingorder");
            cambiaEtichetteEsercizi();

		}

        private void cambiaEtichetteEsercizi() {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            grpImporto1.Text = esercizioCurr.ToString();
            grpImporto2.Text = (++esercizioCurr).ToString();
            grpImporto3.Text = (++esercizioCurr).ToString();
            grpImporto4.Text = (++esercizioCurr).ToString();
            grpImporto5.Text = (++esercizioCurr).ToString();
        }

		public void MetaData_AfterActivation() {
			riempiVarDiConfronto();
			enableControls(false);
		}

		public void MetaData_AfterFill() {
			PostData.MarkAsRealTable(DS.accountprevisionview);
			riempiVarDiConfronto();
            btnSituazione.Enabled = !(Meta.InsertMode);
			bool enable = !(Meta.InsertMode || Meta.EditMode);
			enableControls(enable);
            if (Meta.InsertMode) {
                AbilitaBottoni(false);
            }
            else {
                DataRow R = HelpForm.GetLastSelected(DS.accountprevisionview);
                if (R == null)
                    return;
                if (Operativo(R)) {
                    AbilitaBottoni(true);
                }
                else {
                    AbilitaBottoni(false);
                    pulisciTextRiepilogo();
                }
            }
		}

        private void AbilitaBottoni(bool Enable) {
            btnBudgetIniziale.Enabled = Enable;
            btnVarBudget.Enabled = Enable;
            btnPreimpegniBudget.Enabled = Enable;
            btnImpegniBudget.Enabled = Enable;
            btnCalcolaTotali.Enabled = Enable;
            btnVarImpegni.Enabled = Enable;
            btnVarPreimpegni.Enabled = Enable;

        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "accountprevisionview") {
				bool isOperativo = Operativo(R);
				gestisciTxtPrevisione(isOperativo);
				riempiVarDiConfronto();
                bool maggioreMinOp = MaggioreMinLivOperativo(R);
                if ((R != null) && (!maggioreMinOp)) {
                    btnCalcolaTotali.Enabled = true;
                    btnHideUnused.Enabled = false;
                }
                else {
                    btnCalcolaTotali.Enabled = false;
                    btnHideUnused.Enabled = true;
                }

                pulisciTextRiepilogo();
            }
		}

        private void pulisciTextRiepilogo() {
            txtBudgetIniziale.Text="";
            txtVariazioniBudget.Text="";
            txtPreimpegniBudget.Text="";
            txtImpegniBudget.Text="";
            txtBudgetDisponibile.Text = "";
            txtBudgetAttuale.Text = "";
            txtVarImpegni.Text = "";
            txtVarPreimpegni.Text = "";

            txtPreaccertamentiBudget.Text = "";
            txtAccertamentiBudget.Text = "";
            txtVarAccertamenti.Text = "";
            txtVarPreaccertamenti.Text = "";
            txtScrittureAvere.Text = "";
            txtScrittureDare.Text = "";
        }

        public void MetaData_AfterClear() {
			azzeraVarDiConfronto();
			gestisciTxtPrevisione(true);
			enableControls(true);
            btnSituazione.Enabled = false;

            string filterEsercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.CmpEq("idupb", idUpbMain), filterEsercizio);
            GetData.SetStaticFilter(DS.accountprevisionview, filter);
            GetData.SetStaticFilter(DS.accountyear, filter);
        }

		private void enableControls(bool enable) {
			txtCodiceConto.ReadOnly = !enable;
			txtDenominazioneConto.ReadOnly = !enable;
		}

		private void riempiVarDiConfronto() {
			DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
			if (Curr == null) return;
			azzeraVarDiConfronto();
			lastPrevCorr = (decimal)isNull(Curr["prevision"],0m);
            lastPrevCorr2 = (decimal)isNull(Curr["prevision2"], 0m);
            lastPrevCorr3 = (decimal)isNull(Curr["prevision3"], 0m);
            lastPrevCorr4 = (decimal)isNull(Curr["prevision4"], 0m);
            lastPrevCorr5 = (decimal)isNull(Curr["prevision5"], 0m);
			
		}

		private void azzeraVarDiConfronto() {
			lastPrevCorr = 0;
            lastPrevCorr2 = 0;
            lastPrevCorr3 = 0;
            lastPrevCorr4 = 0;
            lastPrevCorr5 = 0;
		}

		private object isNull(object a, object b) {
			return ((a == null) || (a == DBNull.Value))	? b : a;
		}

		private void gestisciTxtPrevisione(bool enable) {
			txtImporto1.ReadOnly = !enable;
            txtImporto2.ReadOnly = !enable;
            txtImporto3.ReadOnly = !enable;
            txtImporto4.ReadOnly = !enable;
            txtImporto5.ReadOnly = !enable;
		}

		private bool Operativo(DataRow R){
			// Controllo che la voce selezionata sia un nodo foglia
			if (R == null) return false;

			// Se la voce è un nodo foglia controllo se sono su di un livello operativo
			string filteresercizio = QHC.CmpEq("ayear",Meta.GetSys("esercizio"));
			object livellorow=R["nlevel"];
			DataRow[] Res = DS.accountlevel.Select(QHC.AppAnd(filteresercizio,QHC.CmpEq("nlevel",livellorow)));
			if (Res.Length!=1) return false;
			string operativo=Res[0]["flagusable"].ToString().ToUpper();
			if (operativo=="N") return false;
			return true;
		}

		public void MetaData_BeforePost() {
			if (!DS.HasChanges()) return;
			DataRow rAccPrevView = HelpForm.GetLastSelected(DS.accountprevisionview);
			if (rAccPrevView.RowState == DataRowState.Unchanged) return;
            string filter =    QHC.AppAnd(QHC.CmpEq("idacc", rAccPrevView["idacc"]),
                            QHC.CmpEq("idupb", rAccPrevView["idupb"]));
			DataRow [] rAccYear = DS.accountyear.Select(filter);
			if (rAccYear.Length > 0) {
				// Modifica la tabella accountyear
                foreach (string c in new string[] { "prevision", "prevision2", "prevision3", "prevision4", "prevision5" }) {
					if (!rAccYear[0][c].Equals(rAccPrevView[c])) {
						rAccYear[0][c] = rAccPrevView[c];
					}
				}
			}
			else {
				MetaData MetaAccYear = MetaData.GetMetaData(this,"accountyear");
				MetaAccYear.SetDefaults(DS.accountyear);
				DataRow rNewAccYear = MetaAccYear.Get_New_Row(rAccPrevView,DS.accountyear);
				foreach(DataColumn C in DS.accountyear.Columns) {
					if (!DS.accountprevisionview.Columns.Contains(C.ColumnName)) continue;
					rNewAccYear[C] = rAccPrevView[C.ColumnName];
				}
			}
			PostData.MarkAsTemporaryTable(DS.accountprevisionview,false);
		}

		public void MetaData_AfterPost() {
			DataRow rAccPrevView = HelpForm.GetLastSelected(DS.accountprevisionview);
			aggiornaLivelliSuperiori(rAccPrevView);
			PostData.MarkAsRealTable(DS.accountprevisionview);
			DS.accountprevisionview.AcceptChanges();
		}

		private void aggiornaLivelliSuperiori(DataRow rAccPrevView) {
			object minLivelloOperativoOBJ = DS.accountlevel.Compute("min(nlevel)",
                QHC.CmpEq("flagusable",'S'));
			int minLivelloOperativo = Convert.ToInt32(minLivelloOperativoOBJ);
			string idAcc = rAccPrevView["idacc"].ToString();
			int livelloIdAcc = (idAcc.Length - 2) / 4;
			if (livelloIdAcc > minLivelloOperativo) return;
			string root = rAccPrevView["idacc"].ToString().Substring(0,2);
			string currIdAcc = idAcc.Substring(0,idAcc.Length - 4);
			while(currIdAcc != root) {
                string filter = QHC.CmpEq("idacc", currIdAcc);
				DataRow rAccPrevViewParent = DS.accountprevisionview.Select(filter)[0];
                foreach (string c in new string[] { "prevision", "prevision2", "prevision3", "prevision4", "prevision5" }) {
                    rAccPrevViewParent[c] = (decimal)isNull(rAccPrevViewParent[c], 0m) +
                        (decimal)isNull(rAccPrevView[c], 0m) - lastPrevCorr;
                }
				currIdAcc = currIdAcc.Substring(0,currIdAcc.Length - 4);
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_accountprevisionview_prevision));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.MetaDataDetail2 = new System.Windows.Forms.GroupBox();
            this.btnHideUnused = new System.Windows.Forms.Button();
            this.txtCodiceUpb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazioneUpb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.grpPrevisione = new System.Windows.Forms.GroupBox();
            this.grpImporto5 = new System.Windows.Forms.GroupBox();
            this.txtImporto5 = new System.Windows.Forms.TextBox();
            this.grpImporto4 = new System.Windows.Forms.GroupBox();
            this.txtImporto4 = new System.Windows.Forms.TextBox();
            this.grpImporto3 = new System.Windows.Forms.GroupBox();
            this.txtImporto3 = new System.Windows.Forms.TextBox();
            this.grpImporto2 = new System.Windows.Forms.GroupBox();
            this.txtImporto2 = new System.Windows.Forms.TextBox();
            this.grpImporto1 = new System.Windows.Forms.GroupBox();
            this.txtImporto1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUpbChilds = new System.Windows.Forms.CheckBox();
            this.btnCalcolaTotali = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVarImpegni = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVarImpegni = new System.Windows.Forms.TextBox();
            this.txtVarPreimpegni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVarPreimpegni = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnImpegniBudget = new System.Windows.Forms.Button();
            this.txtBudgetIniziale = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBudgetIniziale = new System.Windows.Forms.Button();
            this.txtImpegniBudget = new System.Windows.Forms.TextBox();
            this.txtPreimpegniBudget = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnVarBudget = new System.Windows.Forms.Button();
            this.btnPreimpegniBudget = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBudgetDisponibile = new System.Windows.Forms.TextBox();
            this.txtVariazioniBudget = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DS = new accountprevisionview_prevision.vistaForm();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBudgetAttuale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtScrittureDare = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtScrittureAvere = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnVarAccertamenti = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVarAccertamenti = new System.Windows.Forms.TextBox();
            this.txtVarPreaccertamenti = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnVarPreaccertamenti = new System.Windows.Forms.Button();
            this.btnAccertamentiBudget = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAccertamentiBudget = new System.Windows.Forms.TextBox();
            this.txtPreaccertamentiBudget = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnPreaccertamentiBudget = new System.Windows.Forms.Button();
            this.btnScrittureDare = new System.Windows.Forms.Button();
            this.btnScrittureAvere = new System.Windows.Forms.Button();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.MetaDataDetail2.SuspendLayout();
            this.grpPrevisione.SuspendLayout();
            this.grpImporto5.SuspendLayout();
            this.grpImporto4.SuspendLayout();
            this.grpImporto3.SuspendLayout();
            this.grpImporto2.SuspendLayout();
            this.grpImporto1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(216, 508);
            this.treeView1.TabIndex = 18;
            this.treeView1.Tag = "accountprevisionview.tree";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 508);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(219, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(729, 508);
            this.MetaDataDetail.TabIndex = 21;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.MetaDataDetail2);
            this.tabPrincipale.Controls.Add(this.btnSituazione);
            this.tabPrincipale.Controls.Add(this.grpPrevisione);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(721, 425);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // MetaDataDetail2
            // 
            this.MetaDataDetail2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail2.Controls.Add(this.btnHideUnused);
            this.MetaDataDetail2.Controls.Add(this.txtCodiceUpb);
            this.MetaDataDetail2.Controls.Add(this.label1);
            this.MetaDataDetail2.Controls.Add(this.txtDenominazioneUpb);
            this.MetaDataDetail2.Controls.Add(this.label2);
            this.MetaDataDetail2.Location = new System.Drawing.Point(8, 3);
            this.MetaDataDetail2.Name = "MetaDataDetail2";
            this.MetaDataDetail2.Size = new System.Drawing.Size(705, 88);
            this.MetaDataDetail2.TabIndex = 17;
            this.MetaDataDetail2.TabStop = false;
            this.MetaDataDetail2.Text = "Informazioni sull\'U.P.B.";
            // 
            // btnHideUnused
            // 
            this.btnHideUnused.Location = new System.Drawing.Point(477, 19);
            this.btnHideUnused.Name = "btnHideUnused";
            this.btnHideUnused.Size = new System.Drawing.Size(224, 23);
            this.btnHideUnused.TabIndex = 20;
            this.btnHideUnused.Text = "Nascondi voci inutilizzate";
            this.btnHideUnused.Click += new System.EventHandler(this.btnHideUnused_Click);
            // 
            // txtCodiceUpb
            // 
            this.txtCodiceUpb.Location = new System.Drawing.Point(104, 24);
            this.txtCodiceUpb.Name = "txtCodiceUpb";
            this.txtCodiceUpb.ReadOnly = true;
            this.txtCodiceUpb.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceUpb.TabIndex = 2;
            this.txtCodiceUpb.TabStop = false;
            this.txtCodiceUpb.Tag = "accountprevisionview.codeupb";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazioneUpb
            // 
            this.txtDenominazioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneUpb.Location = new System.Drawing.Point(104, 48);
            this.txtDenominazioneUpb.Multiline = true;
            this.txtDenominazioneUpb.Name = "txtDenominazioneUpb";
            this.txtDenominazioneUpb.ReadOnly = true;
            this.txtDenominazioneUpb.Size = new System.Drawing.Size(593, 32);
            this.txtDenominazioneUpb.TabIndex = 3;
            this.txtDenominazioneUpb.TabStop = false;
            this.txtDenominazioneUpb.Tag = "accountprevisionview.upb";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denominazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(326, 285);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 16;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // grpPrevisione
            // 
            this.grpPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrevisione.Controls.Add(this.grpImporto5);
            this.grpPrevisione.Controls.Add(this.grpImporto4);
            this.grpPrevisione.Controls.Add(this.grpImporto3);
            this.grpPrevisione.Controls.Add(this.grpImporto2);
            this.grpPrevisione.Controls.Add(this.grpImporto1);
            this.grpPrevisione.Location = new System.Drawing.Point(8, 191);
            this.grpPrevisione.Name = "grpPrevisione";
            this.grpPrevisione.Size = new System.Drawing.Size(705, 77);
            this.grpPrevisione.TabIndex = 5;
            this.grpPrevisione.TabStop = false;
            this.grpPrevisione.Text = "Budget";
            // 
            // grpImporto5
            // 
            this.grpImporto5.Controls.Add(this.txtImporto5);
            this.grpImporto5.Location = new System.Drawing.Point(509, 19);
            this.grpImporto5.Name = "grpImporto5";
            this.grpImporto5.Size = new System.Drawing.Size(116, 48);
            this.grpImporto5.TabIndex = 40;
            this.grpImporto5.TabStop = false;
            this.grpImporto5.Tag = "";
            this.grpImporto5.Text = "Budget anno";
            // 
            // txtImporto5
            // 
            this.txtImporto5.Location = new System.Drawing.Point(6, 18);
            this.txtImporto5.Name = "txtImporto5";
            this.txtImporto5.Size = new System.Drawing.Size(104, 20);
            this.txtImporto5.TabIndex = 1;
            this.txtImporto5.Tag = "accountprevisionview.prevision5";
            // 
            // grpImporto4
            // 
            this.grpImporto4.Controls.Add(this.txtImporto4);
            this.grpImporto4.Location = new System.Drawing.Point(387, 19);
            this.grpImporto4.Name = "grpImporto4";
            this.grpImporto4.Size = new System.Drawing.Size(116, 48);
            this.grpImporto4.TabIndex = 39;
            this.grpImporto4.TabStop = false;
            this.grpImporto4.Tag = "";
            this.grpImporto4.Text = "Budget anno";
            // 
            // txtImporto4
            // 
            this.txtImporto4.Location = new System.Drawing.Point(6, 18);
            this.txtImporto4.Name = "txtImporto4";
            this.txtImporto4.Size = new System.Drawing.Size(104, 20);
            this.txtImporto4.TabIndex = 1;
            this.txtImporto4.Tag = "accountprevisionview.prevision4";
            // 
            // grpImporto3
            // 
            this.grpImporto3.Controls.Add(this.txtImporto3);
            this.grpImporto3.Location = new System.Drawing.Point(257, 19);
            this.grpImporto3.Name = "grpImporto3";
            this.grpImporto3.Size = new System.Drawing.Size(119, 48);
            this.grpImporto3.TabIndex = 38;
            this.grpImporto3.TabStop = false;
            this.grpImporto3.Tag = "";
            this.grpImporto3.Text = "Budget anno";
            // 
            // txtImporto3
            // 
            this.txtImporto3.Location = new System.Drawing.Point(6, 18);
            this.txtImporto3.Name = "txtImporto3";
            this.txtImporto3.Size = new System.Drawing.Size(104, 20);
            this.txtImporto3.TabIndex = 1;
            this.txtImporto3.Tag = "accountprevisionview.prevision3";
            // 
            // grpImporto2
            // 
            this.grpImporto2.Controls.Add(this.txtImporto2);
            this.grpImporto2.Location = new System.Drawing.Point(135, 19);
            this.grpImporto2.Name = "grpImporto2";
            this.grpImporto2.Size = new System.Drawing.Size(116, 48);
            this.grpImporto2.TabIndex = 37;
            this.grpImporto2.TabStop = false;
            this.grpImporto2.Tag = "";
            this.grpImporto2.Text = "Budget anno";
            // 
            // txtImporto2
            // 
            this.txtImporto2.Location = new System.Drawing.Point(6, 18);
            this.txtImporto2.Name = "txtImporto2";
            this.txtImporto2.Size = new System.Drawing.Size(104, 20);
            this.txtImporto2.TabIndex = 1;
            this.txtImporto2.Tag = "accountprevisionview.prevision2";
            // 
            // grpImporto1
            // 
            this.grpImporto1.Controls.Add(this.txtImporto1);
            this.grpImporto1.Location = new System.Drawing.Point(11, 19);
            this.grpImporto1.Name = "grpImporto1";
            this.grpImporto1.Size = new System.Drawing.Size(118, 48);
            this.grpImporto1.TabIndex = 36;
            this.grpImporto1.TabStop = false;
            this.grpImporto1.Tag = "";
            this.grpImporto1.Text = "Budget anno";
            // 
            // txtImporto1
            // 
            this.txtImporto1.Location = new System.Drawing.Point(6, 18);
            this.txtImporto1.Name = "txtImporto1";
            this.txtImporto1.Size = new System.Drawing.Size(104, 20);
            this.txtImporto1.TabIndex = 1;
            this.txtImporto1.Tag = "accountprevisionview.prevision";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtDenominazioneConto);
            this.groupBox1.Controls.Add(this.txtCodiceConto);
            this.groupBox1.Location = new System.Drawing.Point(8, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 88);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni sul Conto";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 23);
            this.label24.TabIndex = 3;
            this.label24.Text = "Denominazione";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 23);
            this.label23.TabIndex = 2;
            this.label23.Text = "Codice";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneConto.Location = new System.Drawing.Point(104, 48);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.Size = new System.Drawing.Size(593, 32);
            this.txtDenominazioneConto.TabIndex = 1;
            this.txtDenominazioneConto.Tag = "accountprevisionview.account";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(104, 24);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceConto.TabIndex = 0;
            this.txtCodiceConto.Tag = "accountprevisionview.codeacc";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUpbChilds);
            this.tabPage1.Controls.Add(this.btnCalcolaTotali);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(721, 482);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Riepilogo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUpbChilds
            // 
            this.chkUpbChilds.AutoSize = true;
            this.chkUpbChilds.Location = new System.Drawing.Point(17, 20);
            this.chkUpbChilds.Name = "chkUpbChilds";
            this.chkUpbChilds.Size = new System.Drawing.Size(285, 17);
            this.chkUpbChilds.TabIndex = 70;
            this.chkUpbChilds.Text = "Considera anche gli UPB sottostanti nei dati di riepilogo";
            this.chkUpbChilds.UseVisualStyleBackColor = true;
            this.chkUpbChilds.CheckedChanged += new System.EventHandler(this.chkUpbChilds_CheckedChanged);
            // 
            // btnCalcolaTotali
            // 
            this.btnCalcolaTotali.Location = new System.Drawing.Point(427, 20);
            this.btnCalcolaTotali.Name = "btnCalcolaTotali";
            this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
            this.btnCalcolaTotali.TabIndex = 4;
            this.btnCalcolaTotali.Text = "Calcola totali";
            this.btnCalcolaTotali.UseVisualStyleBackColor = true;
            this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(13, 61);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(693, 413);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnScrittureDare);
            this.tabPage2.Controls.Add(this.btnScrittureAvere);
            this.tabPage2.Controls.Add(this.btnVarAccertamenti);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.txtVarAccertamenti);
            this.tabPage2.Controls.Add(this.txtVarPreaccertamenti);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.btnVarPreaccertamenti);
            this.tabPage2.Controls.Add(this.btnAccertamentiBudget);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtAccertamentiBudget);
            this.tabPage2.Controls.Add(this.txtPreaccertamentiBudget);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.btnPreaccertamentiBudget);
            this.tabPage2.Controls.Add(this.txtScrittureAvere);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtScrittureDare);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtBudgetAttuale);
            this.tabPage2.Controls.Add(this.btnVarImpegni);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtVarImpegni);
            this.tabPage2.Controls.Add(this.txtVarPreimpegni);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnVarPreimpegni);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btnImpegniBudget);
            this.tabPage2.Controls.Add(this.txtBudgetIniziale);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnBudgetIniziale);
            this.tabPage2.Controls.Add(this.txtImpegniBudget);
            this.tabPage2.Controls.Add(this.txtPreimpegniBudget);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.btnVarBudget);
            this.tabPage2.Controls.Add(this.btnPreimpegniBudget);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtBudgetDisponibile);
            this.tabPage2.Controls.Add(this.txtVariazioniBudget);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 387);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Budget";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnVarImpegni
            // 
            this.btnVarImpegni.Location = new System.Drawing.Point(168, 208);
            this.btnVarImpegni.Name = "btnVarImpegni";
            this.btnVarImpegni.Size = new System.Drawing.Size(44, 20);
            this.btnVarImpegni.TabIndex = 60;
            this.btnVarImpegni.Text = "F";
            this.btnVarImpegni.UseVisualStyleBackColor = true;
            this.btnVarImpegni.Click += new System.EventHandler(this.btnVarImpegni_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 18);
            this.label4.TabIndex = 58;
            this.label4.Text = "Variazioni a impegni di Budget";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarImpegni
            // 
            this.txtVarImpegni.Location = new System.Drawing.Point(218, 209);
            this.txtVarImpegni.Name = "txtVarImpegni";
            this.txtVarImpegni.ReadOnly = true;
            this.txtVarImpegni.Size = new System.Drawing.Size(97, 20);
            this.txtVarImpegni.TabIndex = 59;
            this.txtVarImpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreimpegni
            // 
            this.txtVarPreimpegni.Location = new System.Drawing.Point(218, 157);
            this.txtVarPreimpegni.Name = "txtVarPreimpegni";
            this.txtVarPreimpegni.ReadOnly = true;
            this.txtVarPreimpegni.Size = new System.Drawing.Size(97, 20);
            this.txtVarPreimpegni.TabIndex = 56;
            this.txtVarPreimpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-13, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Variazioni a preimpegni di Budget";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarPreimpegni
            // 
            this.btnVarPreimpegni.Location = new System.Drawing.Point(168, 156);
            this.btnVarPreimpegni.Name = "btnVarPreimpegni";
            this.btnVarPreimpegni.Size = new System.Drawing.Size(44, 20);
            this.btnVarPreimpegni.TabIndex = 57;
            this.btnVarPreimpegni.Text = "D";
            this.btnVarPreimpegni.UseVisualStyleBackColor = true;
            this.btnVarPreimpegni.Click += new System.EventHandler(this.btnVarPreimpegni_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(147, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 18);
            this.label11.TabIndex = 44;
            this.label11.Text = "Budget iniziale";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImpegniBudget
            // 
            this.btnImpegniBudget.Location = new System.Drawing.Point(168, 182);
            this.btnImpegniBudget.Name = "btnImpegniBudget";
            this.btnImpegniBudget.Size = new System.Drawing.Size(44, 20);
            this.btnImpegniBudget.TabIndex = 52;
            this.btnImpegniBudget.Text = "E";
            this.btnImpegniBudget.UseVisualStyleBackColor = true;
            this.btnImpegniBudget.Click += new System.EventHandler(this.btnImpegniBudget_Click);
            // 
            // txtBudgetIniziale
            // 
            this.txtBudgetIniziale.Location = new System.Drawing.Point(269, 41);
            this.txtBudgetIniziale.Name = "txtBudgetIniziale";
            this.txtBudgetIniziale.ReadOnly = true;
            this.txtBudgetIniziale.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetIniziale.TabIndex = 45;
            this.txtBudgetIniziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(42, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 40;
            this.label6.Text = "Impegni di Budget";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBudgetIniziale
            // 
            this.btnBudgetIniziale.Location = new System.Drawing.Point(372, 39);
            this.btnBudgetIniziale.Name = "btnBudgetIniziale";
            this.btnBudgetIniziale.Size = new System.Drawing.Size(44, 20);
            this.btnBudgetIniziale.TabIndex = 46;
            this.btnBudgetIniziale.Text = "A";
            this.btnBudgetIniziale.UseVisualStyleBackColor = true;
            this.btnBudgetIniziale.Click += new System.EventHandler(this.btnBudgetIniziale_Click);
            // 
            // txtImpegniBudget
            // 
            this.txtImpegniBudget.Location = new System.Drawing.Point(218, 183);
            this.txtImpegniBudget.Name = "txtImpegniBudget";
            this.txtImpegniBudget.ReadOnly = true;
            this.txtImpegniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtImpegniBudget.TabIndex = 51;
            this.txtImpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPreimpegniBudget
            // 
            this.txtPreimpegniBudget.Location = new System.Drawing.Point(218, 131);
            this.txtPreimpegniBudget.Name = "txtPreimpegniBudget";
            this.txtPreimpegniBudget.ReadOnly = true;
            this.txtPreimpegniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtPreimpegniBudget.TabIndex = 49;
            this.txtPreimpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "G = A + B - C - D";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 18);
            this.label10.TabIndex = 43;
            this.label10.Text = "Preimpegni di Budget";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarBudget
            // 
            this.btnVarBudget.Location = new System.Drawing.Point(372, 69);
            this.btnVarBudget.Name = "btnVarBudget";
            this.btnVarBudget.Size = new System.Drawing.Size(44, 20);
            this.btnVarBudget.TabIndex = 48;
            this.btnVarBudget.Text = "B";
            this.btnVarBudget.UseVisualStyleBackColor = true;
            this.btnVarBudget.Click += new System.EventHandler(this.btnVarBudget_Click);
            // 
            // btnPreimpegniBudget
            // 
            this.btnPreimpegniBudget.Location = new System.Drawing.Point(168, 130);
            this.btnPreimpegniBudget.Name = "btnPreimpegniBudget";
            this.btnPreimpegniBudget.Size = new System.Drawing.Size(44, 20);
            this.btnPreimpegniBudget.TabIndex = 50;
            this.btnPreimpegniBudget.Text = "C";
            this.btnPreimpegniBudget.UseVisualStyleBackColor = true;
            this.btnPreimpegniBudget.Click += new System.EventHandler(this.btnPreimpegniBudget_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(147, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "Variazione Budget";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetDisponibile
            // 
            this.txtBudgetDisponibile.Location = new System.Drawing.Point(269, 250);
            this.txtBudgetDisponibile.Name = "txtBudgetDisponibile";
            this.txtBudgetDisponibile.ReadOnly = true;
            this.txtBudgetDisponibile.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetDisponibile.TabIndex = 53;
            this.txtBudgetDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVariazioniBudget
            // 
            this.txtVariazioniBudget.Location = new System.Drawing.Point(269, 70);
            this.txtVariazioniBudget.Name = "txtVariazioniBudget";
            this.txtVariazioniBudget.ReadOnly = true;
            this.txtVariazioniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtVariazioniBudget.TabIndex = 47;
            this.txtVariazioniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(147, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 42;
            this.label9.Text = "Budget disponibile";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(147, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 61;
            this.label5.Text = "Budget Attuale";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetAttuale
            // 
            this.txtBudgetAttuale.Location = new System.Drawing.Point(269, 98);
            this.txtBudgetAttuale.Name = "txtBudgetAttuale";
            this.txtBudgetAttuale.ReadOnly = true;
            this.txtBudgetAttuale.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetAttuale.TabIndex = 62;
            this.txtBudgetAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(372, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 63;
            this.label12.Text = "A + B";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScrittureDare
            // 
            this.txtScrittureDare.Location = new System.Drawing.Point(270, 276);
            this.txtScrittureDare.Name = "txtScrittureDare";
            this.txtScrittureDare.ReadOnly = true;
            this.txtScrittureDare.Size = new System.Drawing.Size(97, 20);
            this.txtScrittureDare.TabIndex = 65;
            this.txtScrittureDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(148, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 64;
            this.label13.Text = "Scritture EP Dare";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScrittureAvere
            // 
            this.txtScrittureAvere.Location = new System.Drawing.Point(270, 302);
            this.txtScrittureAvere.Name = "txtScrittureAvere";
            this.txtScrittureAvere.ReadOnly = true;
            this.txtScrittureAvere.Size = new System.Drawing.Size(97, 20);
            this.txtScrittureAvere.TabIndex = 67;
            this.txtScrittureAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(148, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 18);
            this.label14.TabIndex = 66;
            this.label14.Text = "Scritture EP Avere";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarAccertamenti
            // 
            this.btnVarAccertamenti.Location = new System.Drawing.Point(424, 208);
            this.btnVarAccertamenti.Name = "btnVarAccertamenti";
            this.btnVarAccertamenti.Size = new System.Drawing.Size(44, 20);
            this.btnVarAccertamenti.TabIndex = 82;
            this.btnVarAccertamenti.Text = "F";
            this.btnVarAccertamenti.UseVisualStyleBackColor = true;
            this.btnVarAccertamenti.Click += new System.EventHandler(this.btnVarAccertamenti_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(470, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 18);
            this.label15.TabIndex = 80;
            this.label15.Text = "Variazioni ad accertamenti di Budget";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVarAccertamenti
            // 
            this.txtVarAccertamenti.Location = new System.Drawing.Point(321, 208);
            this.txtVarAccertamenti.Name = "txtVarAccertamenti";
            this.txtVarAccertamenti.ReadOnly = true;
            this.txtVarAccertamenti.Size = new System.Drawing.Size(97, 20);
            this.txtVarAccertamenti.TabIndex = 81;
            this.txtVarAccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreaccertamenti
            // 
            this.txtVarPreaccertamenti.Location = new System.Drawing.Point(321, 156);
            this.txtVarPreaccertamenti.Name = "txtVarPreaccertamenti";
            this.txtVarPreaccertamenti.ReadOnly = true;
            this.txtVarPreaccertamenti.Size = new System.Drawing.Size(97, 20);
            this.txtVarPreaccertamenti.TabIndex = 78;
            this.txtVarPreaccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(470, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 18);
            this.label16.TabIndex = 77;
            this.label16.Text = "Variazioni a preaccertamenti di Budget";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVarPreaccertamenti
            // 
            this.btnVarPreaccertamenti.Location = new System.Drawing.Point(424, 156);
            this.btnVarPreaccertamenti.Name = "btnVarPreaccertamenti";
            this.btnVarPreaccertamenti.Size = new System.Drawing.Size(44, 20);
            this.btnVarPreaccertamenti.TabIndex = 79;
            this.btnVarPreaccertamenti.Text = "D";
            this.btnVarPreaccertamenti.UseVisualStyleBackColor = true;
            this.btnVarPreaccertamenti.Click += new System.EventHandler(this.btnVarPreaccertamenti_Click);
            // 
            // btnAccertamentiBudget
            // 
            this.btnAccertamentiBudget.Location = new System.Drawing.Point(425, 182);
            this.btnAccertamentiBudget.Name = "btnAccertamentiBudget";
            this.btnAccertamentiBudget.Size = new System.Drawing.Size(44, 20);
            this.btnAccertamentiBudget.TabIndex = 74;
            this.btnAccertamentiBudget.Text = "E";
            this.btnAccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnAccertamentiBudget.Click += new System.EventHandler(this.btnAccertamentiBudget_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(470, 183);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 18);
            this.label17.TabIndex = 68;
            this.label17.Text = "Accertamenti di Budget";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccertamentiBudget
            // 
            this.txtAccertamentiBudget.Location = new System.Drawing.Point(322, 182);
            this.txtAccertamentiBudget.Name = "txtAccertamentiBudget";
            this.txtAccertamentiBudget.ReadOnly = true;
            this.txtAccertamentiBudget.Size = new System.Drawing.Size(97, 20);
            this.txtAccertamentiBudget.TabIndex = 73;
            this.txtAccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPreaccertamentiBudget
            // 
            this.txtPreaccertamentiBudget.Location = new System.Drawing.Point(321, 130);
            this.txtPreaccertamentiBudget.Name = "txtPreaccertamentiBudget";
            this.txtPreaccertamentiBudget.ReadOnly = true;
            this.txtPreaccertamentiBudget.Size = new System.Drawing.Size(97, 20);
            this.txtPreaccertamentiBudget.TabIndex = 71;
            this.txtPreaccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(474, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(166, 18);
            this.label19.TabIndex = 70;
            this.label19.Text = "Preaccertamenti di Budget";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPreaccertamentiBudget
            // 
            this.btnPreaccertamentiBudget.Location = new System.Drawing.Point(424, 130);
            this.btnPreaccertamentiBudget.Name = "btnPreaccertamentiBudget";
            this.btnPreaccertamentiBudget.Size = new System.Drawing.Size(44, 20);
            this.btnPreaccertamentiBudget.TabIndex = 72;
            this.btnPreaccertamentiBudget.Text = "C";
            this.btnPreaccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnPreaccertamentiBudget.Click += new System.EventHandler(this.btnPreaccertamentiBudget_Click);
            // 
            // btnScrittureDare
            // 
            this.btnScrittureDare.Location = new System.Drawing.Point(374, 275);
            this.btnScrittureDare.Name = "btnScrittureDare";
            this.btnScrittureDare.Size = new System.Drawing.Size(44, 20);
            this.btnScrittureDare.TabIndex = 83;
            this.btnScrittureDare.Text = "H";
            this.btnScrittureDare.UseVisualStyleBackColor = true;
            this.btnScrittureDare.Click += new System.EventHandler(this.btnScrittureDare_Click);
            // 
            // btnScrittureAvere
            // 
            this.btnScrittureAvere.Location = new System.Drawing.Point(374, 303);
            this.btnScrittureAvere.Name = "btnScrittureAvere";
            this.btnScrittureAvere.Size = new System.Drawing.Size(44, 20);
            this.btnScrittureAvere.TabIndex = 84;
            this.btnScrittureAvere.Text = "I";
            this.btnScrittureAvere.UseVisualStyleBackColor = true;
            this.btnScrittureAvere.Click += new System.EventHandler(this.btnScrittureAvere_Click);
            // 
            // Frm_accountprevisionview_prevision
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(948, 508);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_accountprevisionview_prevision";
            this.Text = "Frm_accountprevisionview_prevision";
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.MetaDataDetail2.ResumeLayout(false);
            this.MetaDataDetail2.PerformLayout();
            this.grpPrevisione.ResumeLayout(false);
            this.grpImporto5.ResumeLayout(false);
            this.grpImporto5.PerformLayout();
            this.grpImporto4.ResumeLayout(false);
            this.grpImporto4.PerformLayout();
            this.grpImporto3.ResumeLayout(false);
            this.grpImporto3.PerformLayout();
            this.grpImporto2.ResumeLayout(false);
            this.grpImporto2.PerformLayout();
            this.grpImporto1.ResumeLayout(false);
            this.grpImporto1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnSituazione_Click(object sender, EventArgs e){
            object idConto;
            object idUpb;

            DataRow MyRow = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (MyRow == null) return;
            idConto = MyRow["idacc"];
            idUpb = MyRow["idupb"];

            DataSet Out = Meta.Conn.CallSP("show_budget",
                new Object[3] {Meta.GetSys("datacontabile"),
								  idUpb, idConto}
                );
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione di Budget Conto - UPB ";
            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();

        }

        private void txtCodiceTipoClass_TextChanged(object sender, EventArgs e) {

        }

        private void btnHideUnused_Click(object sender, EventArgs e) {
            btnHideUnused.Visible = false;
            object idUpb = idUpbMain;
            string commonFilter = QHS.AppAnd(QHS.CmpEq("U.idupb", idUpb), QHS.CmpEq("A.ayear", Conn.GetSys("esercizio")));
            string sql =
                "select distinct A.idacc from account A " +
                " join upbaccounttotal U on U.idacc like A.idacc+'%' " +
                " where " + commonFilter + " and (" +
                " isnull(U.previsionvariation, 0) <> 0  or isnull(U.currentprev,0)<>0 " +
                " or isnull(U.previsionvariation2, 0) <> 0  or isnull(U.currentprev2,0)<>0 " +
                " or isnull(U.previsionvariation3, 0) <> 0  or isnull(U.currentprev3,0)<>0 " +
                " or isnull(U.previsionvariation4, 0) <> 0  or isnull(U.currentprev4,0)<>0 " +
                " or isnull(U.previsionvariation5, 0) <> 0  or isnull(U.currentprev5,0)<>0 " +
                ")";
            sql += " UNION ";
            sql += " select distinct A.idacc from account A " +
                   " join upbepexptotal U on U.idacc like A.idacc+'%' " +
                  " where " + commonFilter + " and (" +
                   " (isnull(U.total, 0) <> 0 or isnull(U.total2, 0) <> 0 or isnull(U.total3, 0) <> 0 "+
                   " or isnull(U.total4, 0) <> 0  or isnull(U.total5, 0) <> 0) ) ";
            sql += " UNION ";
            sql += " select distinct A.idacc from account A " +
                   " join upbepacctotal U on U.idacc like A.idacc+'%' " +
                  " where " + commonFilter + " and (" +
                   " (isnull(U.total, 0) <> 0 or isnull(U.total2, 0) <> 0 or isnull(U.total3, 0) <> 0 " +
                   " or isnull(U.total4, 0) <> 0  or isnull(U.total5, 0) <> 0) ) ";

            DataTable tAll = Conn.SQLRunner(sql);
            if (tAll == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna voce di bilancio risulta utilizzata", "Avviso");
                return;
            }
            List<string> usedIdAcc = new List<string>();
            foreach (DataRow r in tAll.Rows) {
                usedIdAcc.Add(r["idacc"].ToString());
            }
            cascadeDeleteUnusedNodes(usedIdAcc, treeView1.Nodes);
            string filterAcc = QHS.FieldIn("idacc", tAll.Select(), "idacc");
            GetData.SetStaticFilter(DS.account, filterAcc);
            GetData.SetStaticFilter(DS.accountprevisionview, filterAcc);
            btnHideUnused.Visible = true;
        }

        void cascadeDeleteUnusedNodes(List<string> used, TreeNodeCollection coll) {
            List<TreeNode> toDelete = new List<TreeNode>();
            foreach (TreeNode tNode in coll) {
                tree_node tn = (tree_node)tNode.Tag;
                bool toKeep = true;
                if (tn!=null && tn.Row != null) {
                    string currId = tn.Row["idacc"].ToString();
                    toKeep = used.Contains(currId);
                }
                if (toKeep) {
                    cascadeDeleteUnusedNodes(used, tNode.Nodes);
                }
                else {
                    toDelete.Add(tNode);
                    object idacc = ((tree_node)tNode.Tag).Row["idacc"];
                    DataRow[] r3 = DS.accountyear.Select(QHC.CmpEq("idacc", idacc));
                    foreach (DataRow rr in r3) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }

                    DataRow[] r1 = DS.accountprevisionview.Select(QHC.CmpEq("idacc", idacc));
                    foreach (DataRow rr in r1) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }
                    DataRow[] r2 = DS.account.Select(QHC.CmpEq("idacc", idacc));
                    foreach (DataRow rr in r2) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }



                }
            }
            foreach (TreeNode n in toDelete) {
                coll.Remove(n);
            }
        }
        private decimal BudgetIniziale() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));

            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountyearview", true));
            string strExpr = "SUM(prevision)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountyearview", filter, strExpr));
            return valore;
        }
        private Decimal CK(Object O) {
            if (O == DBNull.Value)
                return 0;
            return CfgFn.GetNoNullDecimal(O);
        }
        private decimal VariazioniBudget() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            //1   Normale
            //2   Ripartizione
            //3   Assestamento
            //4   Storno
            //5   Iniziale
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,3,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountvardetailview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountvardetailview", filter, strExpr));
            return valore;
        }
        private decimal PreimpegniPreaccertamentiBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpEq("E.nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString()+"%"));
               }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END ) as amount from epexpyear EY " +
                        "JOIN epexp E on EY.idepexp = E.idepexp " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END ) as amount from epaccyear EY " +
                        "JOIN epacc E on EY.idepacc = E.idepacc " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            
            return valore;
        }

        private decimal VariazioniPreimpPreaccBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            
            // Le var. dei suddetti impegni.
            Filter = QHS.CmpEq("E.nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epexpyear EY " +
                    "JOIN epexp E on EY.idepexp = E.idepexp " +
                    "JOIN epexpvar EV on EV.idepexp = EY.idepexp " +
                    "JOIN upb U on EY.idupb = U.idupb " +
                    " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epaccyear EY " +
                        "JOIN epacc E on EY.idepacc = E.idepacc " +
                        "JOIN epaccvar EV on EV.idepacc = EY.idepacc " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal ImpegniAccertamentiBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpEq("E.nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END) as amount from epexpyear EY " +
                             "JOIN epexp E on EY.idepexp = E.idepexp " +
                             "JOIN upb U on EY.idupb = U.idupb " +
                             " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END) as amount from epaccyear EY " +
                         "JOIN epacc E on EY.idepacc = E.idepacc " +
                         "JOIN upb U on EY.idupb = U.idupb " +
                         " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }


        private decimal VariazioniImpAccBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
           

            // Aggiungiamo le var. dei suddetti impegni.
            Filter = QHS.CmpEq("E.nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epexpyear EY " +
                            "JOIN epexp E on EY.idepexp = E.idepexp " +
                            "JOIN epexpvar EV on EV.idepexp = EY.idepexp " +
                            "JOIN upb U on EY.idupb = U.idupb " +
                            " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epaccyear EY " +
                            "JOIN epacc E on EY.idepacc = E.idepacc " +
                            "JOIN epaccvar EV on EV.idepacc = EY.idepacc " +
                            "JOIN upb U on EY.idupb = U.idupb " +
                            " WHERE " + Filter;
            }
            valore =  CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private bool MaggioreMinLivOperativo(DataRow R) {
            // Controllo che la voce selezionata sia un nodo foglia
            if (R == null) return false;
            if (R.RowState == DataRowState.Detached) return false;

            // Se la voce è un nodo foglia controllo se sono su minimo livello operativo
            string filteresercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            int thislevel = CfgFn.GetNoNullInt32(R["nlevel"]);
            int minlivlevelop = CfgFn.GetNoNullInt32(Meta.GetSys("accountusablelevel"));
            if (thislevel <= minlivlevelop) return false;

            return true;
        }

        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            decimal budgetIni = BudgetIniziale();
            txtBudgetIniziale.Text = budgetIni.ToString("c");

            decimal varBudget = VariazioniBudget();
            txtVariazioniBudget.Text = varBudget.ToString("c");

            decimal BudgetAttuale = budgetIni + varBudget;
            txtBudgetAttuale.Text = BudgetAttuale.ToString("c");
            decimal preImp = PreimpegniPreaccertamentiBudget("I");
            txtPreimpegniBudget.Text = preImp.ToString("c");
            decimal preAcc = PreimpegniPreaccertamentiBudget("A");
            txtPreaccertamentiBudget.Text = preAcc.ToString("c");

            decimal varPreImp = VariazioniPreimpPreaccBudget("I");
            txtVarPreimpegni.Text = varPreImp.ToString("c");
            decimal varPreAcc = VariazioniPreimpPreaccBudget("A");
            txtVarPreaccertamenti.Text = varPreAcc.ToString("c");

            txtImpegniBudget.Text = ImpegniAccertamentiBudget("I").ToString("c");
            txtAccertamentiBudget.Text = ImpegniAccertamentiBudget("A").ToString("c");
            txtVarImpegni.Text = VariazioniImpAccBudget("I").ToString("c");
            txtVarAccertamenti.Text = VariazioniImpAccBudget("A").ToString("c");
            txtBudgetDisponibile.Text = (budgetIni + varBudget - preImp - preAcc  - varPreImp - varPreAcc).ToString("c");
            decimal ScrittureEPdare = ScrittureDare();
            txtScrittureDare.Text = ScrittureEPdare.ToString("c");

            decimal ScrittureEPavere = ScrittureAvere();
            txtScrittureAvere.Text = ScrittureEPavere.ToString("c");
                
        }
        // -(select sum(D.amount) from entrydetail D where D.idacc=A.idacc and D.idupb=U.idupb and D.amount<0) as dare, 

        private decimal ScrittureDare() {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpLt("D.amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.yentry", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("D.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("D.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "SELECT - SUM(D.amount) as amount from entrydetailview D " +
                             " WHERE " + Filter;
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }
        private decimal ScrittureAvere() {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpGt("D.amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.yentry", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("D.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("D.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "SELECT SUM(D.amount) as amount from entrydetailview D " +
                             " WHERE " + Filter;
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }
        private void btnBudgetIniziale_Click(object sender, EventArgs e) {
            string VistaScelta;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            //Previsione corrente (principale)
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
                
            VistaScelta = "accountyearview";
            MetaData MFinyearView = MetaData.GetMetaData(this, VistaScelta);
            MFinyearView.FilterLocked = true;
            MFinyearView.DS = DS;

            DataRow MyDR = MFinyearView.SelectOne("default", filter, null, null);

            if (MyDR != null) {
                SelezionaBudget(MyDR);
            }
        }

        private void SelezionaBudget(DataRow MyDR) {
            MetaData newAccyearView = Meta.Dispatcher.Get("accountyearview");
            newAccyearView.ExtraParameter = MyDR["idacc"];
            newAccyearView.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccyearView.SelectOne(newAccyearView.DefaultListType,
                 QHS.AppAnd(QHS.CmpEq("idacc", MyDR["idacc"]),
                               QHS.CmpEq("idupb", MyDR["idupb"])), "accountyearview", null);
            if (R2 != null)
                newAccyearView.SelectRow(R2, newAccyearView.DefaultListType);
        }
        private void btnVarBudget_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return;

            /*
             *  1	Normale
                2	Ripartizione
                3	Assestamento
                4	Storno
                5	Iniziale
             * */
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,3,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "accountvardetailview";
            MetaData MFinVarDetail = MetaData.GetMetaData(this, VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }

        private void SelezionaVariazione(DataRow MyDR) {
            MetaData newAccVarDetail = Meta.Dispatcher.Get("accountvardetail");

            newAccVarDetail.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccVarDetail.SelectOne("lista",
                QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
                QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
                "accountvardetail", null);
            if (R2 != null)
                newAccVarDetail.SelectRow(R2, "lista");
        }

        private void btnPreimpegniBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epexpview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epexp");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }
        private void btnVarPreimpegni_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)return;
            Filter = QHS.CmpEq("nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epexpvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd( QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), "epexpvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }


        private void btnImpegniBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return;
            Filter = QHS.CmpEq("nphase", "2");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epexpview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epexp");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void chkUpbChilds_CheckedChanged(object sender, EventArgs e) {
            pulisciTextRiepilogo();
        }

        private void btnVarImpegni_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epexpvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), "epexpvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnPreaccertamentiBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epaccview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epacc");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarPreaccertamenti_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epaccvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epaccvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), "epaccvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnAccertamentiBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null)
                return;
            Filter = QHS.CmpEq("nphase", "2");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epaccview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epacc");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarAccertamenti_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epaccvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epaccvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), "epaccvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnScrittureDare_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpLt("amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            //Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "entrydetailview";
            MetaData MDettScritture = MetaData.GetMetaData(this, VistaScelta);
            MDettScritture.FilterLocked = true;
            MDettScritture.DS = DS;
            DataRow MyDR = MDettScritture.SelectOne("listaestesa", Filter, null, null);
            if (MyDR != null) {
                MetaData newDettScrittura = Meta.Dispatcher.Get("entrydetail");
                newDettScrittura.Edit(this.ParentForm, "default", false);
                DataRow R2 = newDettScrittura.SelectOne(newDettScrittura.DefaultListType,
                        QHS.AppAnd(QHS.CmpEq("nentry", MyDR["nentry"]), QHS.CmpEq("yentry", MyDR["yentry"]),
                        QHS.CmpEq("ndetail", MyDR["ndetail"])), "entrydetail", null);
                if (R2 != null)
                    newDettScrittura.SelectRow(R2, newDettScrittura.DefaultListType);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e) {

        }

        private void btnScrittureAvere_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountprevisionview);
            if (Curr == null) return;
            Filter = QHS.CmpGt("amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            //Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "entrydetailview";
            MetaData MDettScritture = MetaData.GetMetaData(this, VistaScelta);
            MDettScritture.FilterLocked = true;
            MDettScritture.DS = DS;
            DataRow MyDR = MDettScritture.SelectOne("listaestesa", Filter, null, null);
            if (MyDR != null) {
                MetaData newDettScrittura = Meta.Dispatcher.Get("entrydetail");
                newDettScrittura.Edit(this.ParentForm, "default", false);
                DataRow R2 = newDettScrittura.SelectOne(newDettScrittura.DefaultListType,
                        QHS.AppAnd(QHS.CmpEq("nentry", MyDR["nentry"]), QHS.CmpEq("yentry", MyDR["yentry"]),
                        QHS.CmpEq("ndetail", MyDR["ndetail"])), "entrydetail", null);
                if (R2 != null)
                    newDettScrittura.SelectRow(R2, newDettScrittura.DefaultListType);
            }
        }
    }
}
