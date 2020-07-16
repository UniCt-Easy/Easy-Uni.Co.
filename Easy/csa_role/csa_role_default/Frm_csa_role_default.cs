/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using funzioni_configurazione;

namespace csa_role_default {
	/// <summary>
	/// </summary>
    public class Frm_csa_role_default : System.Windows.Forms.Form
    {
        public vistaForm DS;
        MetaData Meta;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private GroupBox groupBox5;
        private TextBox textBox4;
        private TextBox txtCodiceCausaleCredit;
        private Button button10;
        private GroupBox groupBox10;
        private TextBox textBox5;
        private TextBox txtCodiceCausaleDeb;
        private Button button9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_csa_role_default() {
			InitializeComponent();
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
            this.DS = new csa_role_default.vistaForm();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleCredit = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(415, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "csa_role.ruolocsa";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(257, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruolo CSA:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(12, 57);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(415, 56);
            this.groupCredDeb.TabIndex = 6;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(399, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?csa_roleview.registry";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.txtCodiceCausaleCredit);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Location = new System.Drawing.Point(12, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 80);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoManage.txtCodiceCausaleCredit.tree.(in_use = \'S\')";
            this.groupBox5.Text = "Causale di credito";
            this.groupBox5.UseCompatibleTextRendering = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(120, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(200, 56);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "accmotiveapplied_credit.motive";
            // 
            // txtCodiceCausaleCredit
            // 
            this.txtCodiceCausaleCredit.Location = new System.Drawing.Point(10, 48);
            this.txtCodiceCausaleCredit.Name = "txtCodiceCausaleCredit";
            this.txtCodiceCausaleCredit.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausaleCredit.TabIndex = 1;
            this.txtCodiceCausaleCredit.Tag = "accmotiveapplied_credit.codemotive?csa_roleview.codemotivecredit";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(8, 16);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(104, 23);
            this.button10.TabIndex = 0;
            this.button10.Tag = "manage.accmotiveapplied_credit.tree";
            this.button10.Text = "Causale";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox5);
            this.groupBox10.Controls.Add(this.txtCodiceCausaleDeb);
            this.groupBox10.Controls.Add(this.button9);
            this.groupBox10.Location = new System.Drawing.Point(12, 119);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(328, 80);
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
            this.groupBox10.Text = "Causale di debito";
            this.groupBox10.UseCompatibleTextRendering = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(120, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(200, 56);
            this.textBox5.TabIndex = 2;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "accmotiveapplied_debit.motive";
            // 
            // txtCodiceCausaleDeb
            // 
            this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(10, 48);
            this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
            this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausaleDeb.TabIndex = 1;
            this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?csa_roleview.codemotivedebit";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(104, 23);
            this.button9.TabIndex = 0;
            this.button9.Tag = "manage.accmotiveapplied_debit.tree";
            this.button9.Text = "Causale";
            // 
            // Frm_csa_role_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(439, 298);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_csa_role_default";
            this.Text = "frmContractKindRules";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "registry_cred");
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);
            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");
            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "registry_deb");
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
         }
       
    }
}