/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using auditcheck_child;//businessrulecontrols
using System.Data;


namespace audit_regola {//businessrule//
	/// <summary>
	/// Summary description for FrmBusinessRule.
	/// </summary>
	public class Frm_audit_regola : System.Windows.Forms.Form {
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		public vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnControlli;
		private System.ComponentModel.IContainer components;
		//DataTable TabList;
		MetaData Meta;

		//ArrayList TableList;
		private System.Windows.Forms.GroupBox grpGravita;
		private System.Windows.Forms.CheckBox chkSistema;
		private System.Windows.Forms.TextBox txtConseguenza;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rdoDisabled;
		private System.Windows.Forms.RadioButton rdoWarning;
		private System.Windows.Forms.RadioButton rdoError;
		private System.Windows.Forms.TextBox txtDescrizione;
		//ArrayList OpList;
		//private DataAccess Conn;
		private bool IsAdmin=true;

		public Frm_audit_regola() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.audit.Columns["flagsystem"], true);
			//			DS.businessrule.descriptionColumn.ExtendedProperties["sqltype"]="text";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_audit_regola));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.chkSistema = new System.Windows.Forms.CheckBox();
            this.grpGravita = new System.Windows.Forms.GroupBox();
            this.rdoDisabled = new System.Windows.Forms.RadioButton();
            this.rdoWarning = new System.Windows.Forms.RadioButton();
            this.rdoError = new System.Windows.Forms.RadioButton();
            this.btnControlli = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConseguenza = new System.Windows.Forms.TextBox();
            this.DS = new audit_regola.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.grpGravita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS.audit)).BeginInit();
            this.SuspendLayout();
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
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.chkSistema);
            this.MetaDataDetail.Controls.Add(this.grpGravita);
            this.MetaDataDetail.Controls.Add(this.btnControlli);
            this.MetaDataDetail.Controls.Add(this.txtDescrizione);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Controls.Add(this.label4);
            this.MetaDataDetail.Controls.Add(this.txtConseguenza);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 8);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(571, 264);
            this.MetaDataDetail.TabIndex = 1;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio";
            // 
            // chkSistema
            // 
            this.chkSistema.Location = new System.Drawing.Point(16, 56);
            this.chkSistema.Name = "chkSistema";
            this.chkSistema.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSistema.Size = new System.Drawing.Size(120, 32);
            this.chkSistema.TabIndex = 2;
            this.chkSistema.Tag = "audit.flagsystem:S:N";
            this.chkSistema.Text = "Regola di sistema";
            this.chkSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSistema.CheckedChanged += new System.EventHandler(this.chkSistema_CheckedChanged);
            // 
            // grpGravita
            // 
            this.grpGravita.Controls.Add(this.rdoDisabled);
            this.grpGravita.Controls.Add(this.rdoWarning);
            this.grpGravita.Controls.Add(this.rdoError);
            this.grpGravita.Location = new System.Drawing.Point(144, 48);
            this.grpGravita.Name = "grpGravita";
            this.grpGravita.Size = new System.Drawing.Size(192, 88);
            this.grpGravita.TabIndex = 3;
            this.grpGravita.TabStop = false;
            this.grpGravita.Text = "Gravit‡";
            // 
            // rdoDisabled
            // 
            this.rdoDisabled.Location = new System.Drawing.Point(8, 56);
            this.rdoDisabled.Name = "rdoDisabled";
            this.rdoDisabled.Size = new System.Drawing.Size(176, 24);
            this.rdoDisabled.TabIndex = 3;
            this.rdoDisabled.Tag = "audit.severity:I";
            this.rdoDisabled.Text = "Disabilitata";
            // 
            // rdoWarning
            // 
            this.rdoWarning.Location = new System.Drawing.Point(8, 32);
            this.rdoWarning.Name = "rdoWarning";
            this.rdoWarning.Size = new System.Drawing.Size(152, 24);
            this.rdoWarning.TabIndex = 2;
            this.rdoWarning.Tag = "audit.severity:W";
            this.rdoWarning.Text = "Avvertimento";
            // 
            // rdoError
            // 
            this.rdoError.Location = new System.Drawing.Point(8, 16);
            this.rdoError.Name = "rdoError";
            this.rdoError.Size = new System.Drawing.Size(136, 16);
            this.rdoError.TabIndex = 1;
            this.rdoError.Tag = "audit.severity:E";
            this.rdoError.Text = "Errore bloccante";
            // 
            // btnControlli
            // 
            this.btnControlli.Location = new System.Drawing.Point(440, 104);
            this.btnControlli.Name = "btnControlli";
            this.btnControlli.Size = new System.Drawing.Size(75, 23);
            this.btnControlli.TabIndex = 6;
            this.btnControlli.Tag = "";
            this.btnControlli.Text = "Dettagli...";
            this.btnControlli.Click += new System.EventHandler(this.btnControlli_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(144, 144);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(408, 56);
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.Tag = "audit.title";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrizione breve:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(72, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(480, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "audit.idaudit";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Conseguenza:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConseguenza
            // 
            this.txtConseguenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConseguenza.Location = new System.Drawing.Point(144, 208);
            this.txtConseguenza.Multiline = true;
            this.txtConseguenza.Name = "txtConseguenza";
            this.txtConseguenza.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConseguenza.Size = new System.Drawing.Size(408, 48);
            this.txtConseguenza.TabIndex = 5;
            this.txtConseguenza.Tag = "audit.consequence";
          
            // 
            // Frm_audit_regola
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(595, 324);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "Frm_audit_regola";
            this.Text = "FrmBusinessRule";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.grpGravita.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS.audit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			//Conn=Meta.Conn;
			if (Meta.GetSys("FlagMenuAdmin")!=null) 
				IsAdmin=(Meta.GetSys("FlagMenuAdmin").ToString()=="S");

			//			HelpForm.SetDenyNull(DS.businessrule.Columns["flagsystem"],true);
			Meta.CanCancel = IsAdmin;
			Meta.CanInsert = IsAdmin;
			Meta.CanInsertCopy = IsAdmin;
		}

		public void MetaData_AfterClear() {
			txtConseguenza.ReadOnly = false;
			txtDescrizione.ReadOnly = false;
			chkSistema.Enabled = true;
			rdoError.Enabled = true;
			rdoWarning.Enabled = true;
			rdoDisabled.Enabled = true;
		}
			
		public void MetaData_AfterFill() {
			txtConseguenza.ReadOnly = !IsAdmin;
			txtDescrizione.ReadOnly = !IsAdmin;
		    if (!Meta.IsEmpty) {
                DataRow R = DS.audit.Rows[0];
                bool flagsystem = (R["flagsystem"].ToString().ToUpper() == "S");
                chkSistema.Enabled = IsAdmin;
                AbilitaGravita(!flagsystem);
            }

        }

		public void MetaData_AfterActivation(){
			//			TableList = new ArrayList();
			//			OpList = new ArrayList();
			//
			//			TabList = Meta.Conn.SQLRunner("SELECT objectname from customobject where isreal='S' order by objectname");
			//			string prec=null;
			//			foreach(DataRow R in TabList.Rows){
			//				string curr = R["objectname"].ToString();
			//				if (prec!=curr) {
			//					TableList.Add(curr);
			//					prec=curr;
			//				}
			//			}
			//
			//			OpList.Add("I");
			//			OpList.Add("U");
			//			OpList.Add("D");
		}

		private void btnControlli_Click(object sender, System.EventArgs e) {
			DataRow CurrBusiness = HelpForm.GetLastSelected(DS.audit);
			if (CurrBusiness==null) return;
			MetaData MetaRule = MetaData.GetMetaData(this, "auditcheck");
			MetaRule.StartFilter= "(idaudit="+
				QueryCreator.quotedstrvalue(CurrBusiness["idaudit"],true)+")";
			MetaRule.ExtraParameter=CurrBusiness["idaudit"];
			MetaRule.Edit(this.ParentForm,"child",false);
		    MetaRule.DoMainCommand("maindosearch.default");
		}

		DataTable ExBusinessRule;
		public void MetaData_BeforePost(){

			ExBusinessRule=null;
			DataRow Curr = HelpForm.GetLastSelected(DS.audit);
			if (Curr==null) return;
			string filter= "(idaudit="+QueryCreator.quotedstrvalue(
				Curr["idaudit"],true)+")";
			ExBusinessRule= Meta.Conn.SQLRunner("SELECT DISTINCT tablename,opkind FROM auditcheck WHERE "+ filter);
		}

		public void MetaData_AfterPost(){
			
			if (ExBusinessRule==null) return;
            string filterrule = Meta.GetSys("filterrule").ToString();
			FrmRecalc RC = new FrmRecalc(Meta.Conn, ExBusinessRule,filterrule);
			RC.Show();
			RC.Run();
		}

		

		private void chkSistema_CheckedChanged(object sender, System.EventArgs e) {
			AbilitaGravita(!chkSistema.Checked);
		}
		
		/// <summary>
		/// Abilitato se il flagsystem Ë "N" oppure 
		/// </summary>
		/// <param name="enable"></param>
		private void AbilitaGravita(bool enable) {
			rdoError.Enabled=enable;
			rdoWarning.Enabled=enable;
			rdoDisabled.Enabled=enable;
		}



	}
}