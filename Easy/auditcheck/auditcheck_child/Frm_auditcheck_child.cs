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
using System.IO;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using SqlEditor;//SqlEditor
using metaeasylibrary;
using generaSQL;

namespace auditcheck_child//businessrulecontrols//
{
	/// <summary>
	/// Summary description for FrmBusinessRuleControls.
	/// </summary>
	public class Frm_auditcheck_child : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnControlli;
		MetaData Meta;
		DataAccess Conn;
		private System.Windows.Forms.TreeView Tree;
		private System.Windows.Forms.ComboBox cmbTabella;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.ComboBox cmbRuleID;
		private System.Windows.Forms.CheckBox chkPost;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox gboxApplicazione;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private Label label3;
        public vistaForm DS;
        private RichTextBox txtSql;
        private GroupBox gboxSql;
        private GroupBox groupBox2;
        private RadioButton radToday;
        private RadioButton radRule;
        private RadioButton radThis;
        private Button btnAddScriptAuditCheck;
        private RadioButton radTable;
        private RadioButton radSingleAppend;
        private TextBox txtFolder;
        private Button btnSelezionaFolder;
        private FolderBrowserDialog folderDlg;
        bool IsAdmin =false;

		public Frm_auditcheck_child()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//Inited=false;
//			DS.ruleenforcement.statementColumn.ExtendedProperties["sqltype"]="text";
//			DS.ruleenforcement.messageColumn.ExtendedProperties["sqltype"]="text";
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_auditcheck_child));
            this.cmbRuleID = new System.Windows.Forms.ComboBox();
            this.DS = new auditcheck_child.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.gboxSql = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSingleAppend = new System.Windows.Forms.RadioButton();
            this.radTable = new System.Windows.Forms.RadioButton();
            this.radToday = new System.Windows.Forms.RadioButton();
            this.radRule = new System.Windows.Forms.RadioButton();
            this.radThis = new System.Windows.Forms.RadioButton();
            this.btnAddScriptAuditCheck = new System.Windows.Forms.Button();
            this.gboxApplicazione = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkPost = new System.Windows.Forms.CheckBox();
            this.btnControlli = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.Tree = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTabella = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.btnSelezionaFolder = new System.Windows.Forms.Button();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolder = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.gboxSql.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxApplicazione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRuleID
            // 
            this.cmbRuleID.DataSource = this.DS.audit;
            this.cmbRuleID.DisplayMember = "title";
            this.cmbRuleID.Location = new System.Drawing.Point(8, 32);
            this.cmbRuleID.Name = "cmbRuleID";
            this.cmbRuleID.Size = new System.Drawing.Size(439, 21);
            this.cmbRuleID.TabIndex = 1;
            this.cmbRuleID.Tag = "auditcheck.idaudit";
            this.cmbRuleID.ValueMember = "idaudit";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Regola";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.gboxSql);
            this.MetaDataDetail.Controls.Add(this.gboxApplicazione);
            this.MetaDataDetail.Controls.Add(this.chkPost);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Controls.Add(this.Tree);
            this.MetaDataDetail.Controls.Add(this.label5);
            this.MetaDataDetail.Controls.Add(this.txtMessage);
            this.MetaDataDetail.Controls.Add(this.label4);
            this.MetaDataDetail.Controls.Add(this.cmbTabella);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.cmbRuleID);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 12);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(1030, 232);
            this.MetaDataDetail.TabIndex = 1;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Controllo";
            // 
            // gboxSql
            // 
            this.gboxSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSql.Controls.Add(this.txtFolder);
            this.gboxSql.Controls.Add(this.btnSelezionaFolder);
            this.gboxSql.Controls.Add(this.groupBox2);
            this.gboxSql.Controls.Add(this.btnAddScriptAuditCheck);
            this.gboxSql.Location = new System.Drawing.Point(609, 16);
            this.gboxSql.Name = "gboxSql";
            this.gboxSql.Size = new System.Drawing.Size(408, 208);
            this.gboxSql.TabIndex = 13;
            this.gboxSql.TabStop = false;
            this.gboxSql.Text = "GeneraScript";
            this.gboxSql.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSingleAppend);
            this.groupBox2.Controls.Add(this.radTable);
            this.groupBox2.Controls.Add(this.radToday);
            this.groupBox2.Controls.Add(this.radRule);
            this.groupBox2.Controls.Add(this.radThis);
            this.groupBox2.Location = new System.Drawing.Point(6, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 129);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operazione";
            // 
            // radSingleAppend
            // 
            this.radSingleAppend.Checked = true;
            this.radSingleAppend.Location = new System.Drawing.Point(8, 92);
            this.radSingleAppend.Name = "radSingleAppend";
            this.radSingleAppend.Size = new System.Drawing.Size(222, 20);
            this.radSingleAppend.TabIndex = 4;
            this.radSingleAppend.TabStop = true;
            this.radSingleAppend.Tag = "";
            this.radSingleAppend.Text = "solo questo controllo (modalità append)";
            // 
            // radTable
            // 
            this.radTable.Location = new System.Drawing.Point(8, 52);
            this.radTable.Name = "radTable";
            this.radTable.Size = new System.Drawing.Size(246, 20);
            this.radTable.TabIndex = 3;
            this.radTable.Tag = "";
            this.radTable.Text = "controlli di tabella della regola (cleanup)";
            // 
            // radToday
            // 
            this.radToday.Location = new System.Drawing.Point(8, 36);
            this.radToday.Name = "radToday";
            this.radToday.Size = new System.Drawing.Size(222, 20);
            this.radToday.TabIndex = 1;
            this.radToday.Tag = "";
            this.radToday.Text = "controlli modificati oggi";
            // 
            // radRule
            // 
            this.radRule.Location = new System.Drawing.Point(8, 16);
            this.radRule.Name = "radRule";
            this.radRule.Size = new System.Drawing.Size(146, 25);
            this.radRule.TabIndex = 0;
            this.radRule.Tag = "";
            this.radRule.Text = "intera regola (e cleanup)";
            // 
            // radThis
            // 
            this.radThis.Location = new System.Drawing.Point(8, 72);
            this.radThis.Name = "radThis";
            this.radThis.Size = new System.Drawing.Size(146, 16);
            this.radThis.TabIndex = 2;
            this.radThis.Tag = "";
            this.radThis.Text = "solo questo controllo";
            // 
            // btnAddScriptAuditCheck
            // 
            this.btnAddScriptAuditCheck.Location = new System.Drawing.Point(272, 19);
            this.btnAddScriptAuditCheck.Name = "btnAddScriptAuditCheck";
            this.btnAddScriptAuditCheck.Size = new System.Drawing.Size(75, 23);
            this.btnAddScriptAuditCheck.TabIndex = 12;
            this.btnAddScriptAuditCheck.Text = "Genera";
            this.btnAddScriptAuditCheck.UseVisualStyleBackColor = true;
            this.btnAddScriptAuditCheck.Click += new System.EventHandler(this.btnAddScriptAuditCheck_Click);
            // 
            // gboxApplicazione
            // 
            this.gboxApplicazione.Controls.Add(this.checkBox5);
            this.gboxApplicazione.Controls.Add(this.checkBox4);
            this.gboxApplicazione.Controls.Add(this.checkBox3);
            this.gboxApplicazione.Controls.Add(this.checkBox2);
            this.gboxApplicazione.Controls.Add(this.checkBox1);
            this.gboxApplicazione.Location = new System.Drawing.Point(349, 56);
            this.gboxApplicazione.Name = "gboxApplicazione";
            this.gboxApplicazione.Size = new System.Drawing.Size(245, 72);
            this.gboxApplicazione.TabIndex = 4;
            this.gboxApplicazione.TabStop = false;
            this.gboxApplicazione.Text = "Applicazione";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(117, 32);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(122, 16);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Tag = "auditcheck.flag_proceeds:S:N";
            this.checkBox5.Text = "Ass. e Dot. Cassa";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(117, 16);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(122, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "auditcheck.flag_credit:S:N";
            this.checkBox4.Text = "Ass. e Dot. Crediti";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(8, 48);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "auditcheck.flag_both:S:N";
            this.checkBox3.Text = "Competenza e cassa";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(8, 32);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "auditcheck.flag_comp:S:N";
            this.checkBox2.Text = "Competenza";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "auditcheck.flag_cash:S:N";
            this.checkBox1.Text = "Cassa";
            // 
            // chkPost
            // 
            this.chkPost.Location = new System.Drawing.Point(466, 32);
            this.chkPost.Name = "chkPost";
            this.chkPost.Size = new System.Drawing.Size(104, 24);
            this.chkPost.TabIndex = 5;
            this.chkPost.Tag = "auditcheck.precheck:N:S";
            this.chkPost.Text = "Regola POST";
            // 
            // btnControlli
            // 
            this.btnControlli.Location = new System.Drawing.Point(946, 249);
            this.btnControlli.Name = "btnControlli";
            this.btnControlli.Size = new System.Drawing.Size(96, 23);
            this.btnControlli.TabIndex = 11;
            this.btnControlli.TabStop = false;
            this.btnControlli.Tag = "";
            this.btnControlli.Text = "SQL...";
            this.btnControlli.Click += new System.EventHandler(this.btnControlli_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(263, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operazione";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "auditcheck.opkind:U";
            this.radioButton2.Text = "Update";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RicalcolaEnforcementID);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "auditcheck.opkind:I";
            this.radioButton1.Text = "Insert";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RicalcolaEnforcementID);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 48);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "auditcheck.opkind:D";
            this.radioButton3.Text = "Delete";
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RicalcolaEnforcementID);
            // 
            // Tree
            // 
            this.Tree.Location = new System.Drawing.Point(8, 144);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(304, 80);
            this.Tree.TabIndex = 6;
            this.Tree.TabStop = false;
            this.Tree.DoubleClick += new System.EventHandler(this.Tree_DoubleClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Campi della tabella che possono essere inseriti nel messaggio:";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(328, 144);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(266, 80);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.Tag = "auditcheck.message";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(328, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Messaggio per l\'utente:";
            // 
            // cmbTabella
            // 
            this.cmbTabella.DataSource = this.DS.customobject;
            this.cmbTabella.DisplayMember = "objectname";
            this.cmbTabella.Location = new System.Drawing.Point(8, 72);
            this.cmbTabella.Name = "cmbTabella";
            this.cmbTabella.Size = new System.Drawing.Size(248, 21);
            this.cmbTabella.TabIndex = 2;
            this.cmbTabella.Tag = "auditcheck.tablename";
            this.cmbTabella.ValueMember = "objectname";
            this.cmbTabella.SelectedIndexChanged += new System.EventHandler(this.RicalcolaEnforcementID);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tabella";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sql (formato testo)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSql
            // 
            this.txtSql.AcceptsTab = true;
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(12, 275);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(1030, 274);
            this.txtSql.TabIndex = 10;
            this.txtSql.Tag = "auditcheck.sqlcmd";
            this.txtSql.Text = "";
            // 
            // btnSelezionaFolder
            // 
            this.btnSelezionaFolder.Location = new System.Drawing.Point(6, 151);
            this.btnSelezionaFolder.Name = "btnSelezionaFolder";
            this.btnSelezionaFolder.Size = new System.Drawing.Size(134, 23);
            this.btnSelezionaFolder.TabIndex = 14;
            this.btnSelezionaFolder.Text = "Seleziona cartella";
            this.btnSelezionaFolder.UseVisualStyleBackColor = true;
            this.btnSelezionaFolder.Click += new System.EventHandler(this.btnSelezionaFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(6, 180);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(396, 20);
            this.txtFolder.TabIndex = 15;
            // 
            // Frm_auditcheck_child
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1054, 561);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.btnControlli);
            this.Name = "Frm_auditcheck_child";
            this.Text = "FrmBusinessRuleControls";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.gboxSql.ResumeLayout(false);
            this.gboxSql.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gboxApplicazione.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn= Meta.Conn;
			GetData.CacheTable(DS.customobject,"(isreal='S')","objectname",true);
			if ((Meta.ExtraParameter!=null)&&(Meta.ExtraParameter.ToString()!="")) {
				cmbRuleID.Enabled=false;
				DS.auditcheck.Columns["idaudit"].DefaultValue= Meta.ExtraParameter;
			}
		    if (Meta.GetSys("FlagMenuAdmin") != null) {
		        IsAdmin = (Meta.GetSys("FlagMenuAdmin").ToString() == "S");
		    }
            gboxSql.Visible = IsAdmin;


		    HelpForm.SetDenyNull(DS.auditcheck.Columns["precheck"],true);
			HelpForm.SetDenyNull(DS.auditcheck.Columns["flag_comp"],true);
			HelpForm.SetDenyNull(DS.auditcheck.Columns["flag_cash"],true);
			HelpForm.SetDenyNull(DS.auditcheck.Columns["flag_both"],true);
            HelpForm.SetDenyNull(DS.auditcheck.Columns["flag_credit"], true);
            HelpForm.SetDenyNull(DS.auditcheck.Columns["flag_proceeds"], true);

			Meta.CanCancel = IsAdmin;
			Meta.CanInsert = IsAdmin;
			Meta.CanInsertCopy = IsAdmin;
			Meta.CanSave = IsAdmin;
			abilitaODisabilita(IsAdmin);            
		}

		void abilitaODisabilita(bool enabled) {
			cmbRuleID.Enabled = enabled;
			cmbTabella.Enabled = enabled;
			gboxApplicazione.Enabled = enabled;
			groupBox1.Enabled = enabled;
			chkPost.Enabled = enabled;
			txtMessage.ReadOnly = !enabled;
		}

		void ClearTree(){
			Tree.Nodes.Clear();
		}

	    public void MetaData_AfterGetFormData() {
            DataRow curr = DS.auditcheck.Rows[0];
            curr["sqlcmd"]= txtSql.Text;
        }

		public void MetaData_AfterFill(){
			abilitaODisabilita(IsAdmin);
			//RecalcCheck();
			//Inited=true;
		    DataRow curr = DS.auditcheck.Rows[0];
		    txtSql.Text = curr["sqlcmd"].ToString();
            string tablename= cmbTabella.Text;
			if (tablename.ToString()==""){
				ClearTree();
			}
			else 
				FillTree(tablename);
		}
		public void MetaData_AfterClear(){
			abilitaODisabilita(true);
			ClearTree();
		    txtSql.Text = "";
		    //chkPost.Checked=false;
		}

		void FillTree(string tablename){
			ClearTree();
			Tree.Nodes.Add(tablename);
			Tree.Nodes[0].Expand();

			DataTable RefTables = Conn.SQLRunner(
				"	SELECT object_name(rkeyid) FROM sysreferences "+
				" WHERE fkeyid = object_id("+QueryCreator.quotedstrvalue(tablename,true)+")"+
				" AND object_name(rkeyid) != "+QueryCreator.quotedstrvalue(tablename,true));
			foreach (DataRow Rtable in RefTables.Rows){
				Tree.Nodes.Add(Rtable[0].ToString());
			}

			foreach (TreeNode N in Tree.Nodes){
				string currtable= N.Text;
				dbstructure DBS = Conn.GetStructure(currtable);
				foreach(DataRow ColDesc in DBS.columntypes.Rows){
					N.Nodes.Add(ColDesc["field"].ToString());
				}
			}

		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (Meta.IsEmpty) return;
			if ((T.TableName == "customobject")&&(Meta.DrawStateIsDone)){
				if (R==null) 
					ClearTree();
				else
					FillTree(R["objectname"].ToString());
			}
//			if (T.TableName == "auditcheck"){
//				RecalcCheck();
//			}
		}

		void RicalcolaEnforcementID(object sender, System.EventArgs e){
			if (Meta == null) return;
			if (!Meta.DrawStateIsDone) return;
			if (!Meta.InsertMode) return;
			Meta.GetFormData(true);
			DataRow Curr = HelpForm.GetLastSelected(DS.auditcheck);
			if (Curr==null) return;
			if (Curr.RowState!=DataRowState.Added){
				MessageBox.Show("ERRORE!");
				return;
			}
			int maxexistent = MetaData.MaxFromColumn(DS.auditcheck,"idcheck");
			Curr["idcheck"]= maxexistent+1;
		}

		private void Tree_DoubleClick(object sender, System.EventArgs e) {
			if (Meta.IsEmpty)return;
			TreeNode curr = Tree.SelectedNode;
            if (curr == null) return;
			if (curr.Nodes.Count>0) return;
			if (curr.Parent==null) return;
			string tablename = curr.Parent.Text;
			string colname=curr.Text;
			string fieldref = "%<"+tablename+"."+colname+">%";
			string currmsg= txtMessage.Text;
			int currpos = txtMessage.SelectionStart;
			if ((currpos<0)||(currpos>currmsg.Length)) currpos= currmsg.Length;
			currmsg = currmsg.Insert(currpos,fieldref);
			txtMessage.Text= currmsg;
			
		}

		private void btnControlli_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = HelpForm.GetLastSelected(DS.auditcheck);
			if (Curr==null) return;
		    if (!Meta.GetFormData(true))return;
			frmSqlEditor F = new frmSqlEditor(Conn,Curr["sqlcmd"].ToString(), Curr["tablename"].ToString());
		    if (F.ShowDialog() == DialogResult.OK) {
		        Curr["sqlcmd"]= F.SQLstatement;
                txtSql.Text = F.SQLstatement;
		    }
			//RecalcCheck();
		}


		string lastdbtable;
		string lastdboperation;
		public void MetaData_BeforePost(){
			if (Meta.IsEmpty) return;
			lastdbtable=null;
			lastdboperation = null;
			DataRow CurrEnforcement= HelpForm.GetLastSelected(DS.auditcheck);
			if (CurrEnforcement==null) return;
			lastdbtable = CurrEnforcement["tablename"].ToString();
			lastdboperation = CurrEnforcement["opkind"].ToString();
		}

		public void MetaData_AfterPost(){
			if (lastdbtable==null)return;
			if (lastdboperation==null) return;
            string filterrule = Meta.GetSys("filterrule").ToString();
//			RecalcRule(Meta.Conn, lastdbtable, lastdboperation);
			string err= EasyAudits.RecalcAudit(Meta.Conn, lastdbtable, lastdboperation,filterrule);
			if (err!=null) {
				QueryCreator.ShowError(this,"Errore nella compilazione della s.p. "+
					lastdbtable + "(" + lastdboperation +")"+ ".",
					err);
			}
		}
        
        private void btnAddScriptAuditCheck_Click(object sender, EventArgs e) {
            if (DS.auditcheck.Rows.Count == 0) return;
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable t = Conn.CreateTableByName("auditcheck", "*", true);
            DataRow r = DS.auditcheck.Rows[0];
            string filter = null;
            bool clear = false;
            UpdateType updateType = UpdateType.insertAndUpdate;
            string filename = "auditcheck.sql";
            bool append = false;
            if (radRule.Checked) {
                filter = QHS.CmpEq("idaudit", r["idaudit"]);
                clear = true;
                updateType = UpdateType.bulkinsert;
                filename = r["idaudit"].ToString().ToLower()+".sql";
            }
            if (radToday.Checked) {
                filter = QHS.AppAnd(QHS.CmpEq("idaudit", r["idaudit"]), "( (convert(date,getdate()) = convert(date, lt)) )");
                filename = r["idaudit"].ToString().ToLower() + ".sql";
            }
            if (radTable.Checked) {
                filter = QHS.MCmp(r, "idaudit", "tablename");
                clear = true;
                updateType = UpdateType.bulkinsert;
                filename = r["idaudit"].ToString().ToLower()+"_"+r["tablename"].ToString().ToLower() + ".sql";
            }
            if (radThis.Checked) {
                filter = QHS.CmpKey(r);
                filename = r["idaudit"].ToString().ToLower() + "_" +
                           r["tablename"].ToString().ToLower() + "_" +
                           r["opkind"].ToString().ToLower() + 
                           r["idcheck"].ToString().ToLower() +
                           ".sql";
            }
            if (radSingleAppend.Checked) {
                filter = QHS.CmpKey(r);
                filename = r["idaudit"].ToString().ToLower() + ".sql";
                append = true;
            }


            DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filter, null, true);
            if (t.Rows.Count == 0) {
                MessageBox.Show("Nessuna riga trovata. Filtro:" + filter +
                    " Ultimo errore:" + Conn.LastError);
                return;
            }
            DataAccess.AddExtendedProperty(Conn, t);

            DataSet DS2 = new DataSet();
            DS2.Tables.Add(t);


            if (txtFolder.Text != "") {
                filename = Path.Combine(txtFolder.Text, filename);
            }
            
            
            StreamWriter writer = new StreamWriter(filename, append, System.Text.Encoding.Default);

            if (radRule.Checked) {
                //Eventuale riga di audit
                writer.WriteLine("-- AUDITCHECK " + r["idaudit"]);
                DataSet D3 = new DataSet();
                DataTable t2 = Conn.RUN_SELECT("audit", "*", null, QHS.CmpEq("idaudit", r["idaudit"]), null, false);
                D3.Tables.Add(t2);
                GeneraSQL.DO_GENERATE(Conn, D3, writer, UpdateType.onlyInsert, DataGenerationType.onlyData, true);
            }

            //eventuale cleanup
            if (clear) {
                writer.WriteLine("delete from auditcheck where " + filter);
                writer.WriteLine("GO");
                writer.Flush();
            }

            //Inserimento dati
            GeneraSQL.DO_GENERATE(Conn, DS2, writer, updateType, DataGenerationType.onlyData, true);

            writer.Flush();
            writer.Close();

            MessageBox.Show("Script " + filename + (append ? " aggiornato " : " generato ") + " con successo", "Avviso");

        }

        private void btnSelezionaFolder_Click(object sender, EventArgs e) {
            if (folderDlg.ShowDialog(this) == DialogResult.OK) {
                txtFolder.Text = folderDlg.SelectedPath;
            }
        }
    }
}
