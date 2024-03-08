
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;


namespace provisiondetail_single {//UnDettVarBilancio//
	/// <summary>
	/// Summary description for frmUnDettVarBilancio.
	/// </summary>
	public class Frm_provisiondetail_single : MetaDataForm {
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox grpImporto;
        private System.ComponentModel.IContainer components;
		MetaData Meta;
		private System.Windows.Forms.ImageList imageList1;
		
        CQueryHelper QHC;
        private Label label4;
        private TextBox txtDataDoc;
        private GroupBox grpCausale;
        private TextBox txtDescrizioneCausale;
        private TextBox txtCodiceCausale;
        private Button button2;
        private TextBox textBox17;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        QueryHelper QHS;
		public Frm_provisiondetail_single() {
			InitializeComponent();
		}
       
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			
			if( disposing ) {
			    components?.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_provisiondetail_single));
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DS = new provisiondetail_single.vistaForm();
            this.grpImporto.SuspendLayout();
            this.grpCausale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(585, 333);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 11;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(481, 333);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 10;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 18);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "provisiondetail.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(12, 198);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(670, 129);
            this.txtDescrizione.TabIndex = 6;
            this.txtDescrizione.Tag = "provisiondetail.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbAumento
            // 
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(140, 12);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(94, 16);
            this.rdbAumento.TabIndex = 1;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            this.rdbAumento.CheckedChanged += new System.EventHandler(this.rdbAumento_CheckedChanged);
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(140, 29);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(94, 16);
            this.rdbDiminuzione.TabIndex = 2;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            this.rdbDiminuzione.CheckedChanged += new System.EventHandler(this.rdbDiminuzione_CheckedChanged);
            // 
            // grpImporto
            // 
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(12, 37);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(240, 56);
            this.grpImporto.TabIndex = 3;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "provisiondetail.amount.valuesigned";
            this.grpImporto.Text = "Importo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(69, 112);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(128, 20);
            this.txtDataDoc.TabIndex = 4;
            this.txtDataDoc.Tag = "provisiondetail.adate";
            // 
            // grpCausale
            // 
            this.grpCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
            this.grpCausale.Controls.Add(this.txtCodiceCausale);
            this.grpCausale.Controls.Add(this.button2);
            this.grpCausale.Location = new System.Drawing.Point(268, 44);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(412, 144);
            this.grpCausale.TabIndex = 5;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.grpCausale.Text = "Causale di reddito (se immessa genera un accertamento di budget)";
            // 
            // txtDescrizioneCausale
            // 
            this.txtDescrizioneCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneCausale.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizioneCausale.Multiline = true;
            this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
            this.txtDescrizioneCausale.ReadOnly = true;
            this.txtDescrizioneCausale.Size = new System.Drawing.Size(281, 86);
            this.txtDescrizioneCausale.TabIndex = 2;
            this.txtDescrizioneCausale.TabStop = false;
            this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceCausale.Location = new System.Drawing.Point(6, 108);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(395, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.accmotiveapplied.tree";
            this.button2.Text = "Causale";
            // 
            // textBox17
            // 
            this.textBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox17.Location = new System.Drawing.Point(576, 9);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 20);
            this.textBox17.TabIndex = 58;
            this.textBox17.Tag = "provisiondetail.rownum";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Num.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 60;
            this.textBox1.Tag = "provisiondetail.ydetail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Esercizio";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_provisiondetail_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(688, 367);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpCausale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDataDoc);
            this.Controls.Add(this.grpImporto);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_provisiondetail_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();


            string filterEpOperationRicavo = QHS.CmpEq("idepoperation", "ric_accantonamento");
            //string filterEpOperationCosto = QHS.CmpEq("idepoperation", "costo_accantonamento");

            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationRicavo;

            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationRicavo);

        }

	    public void MetaData_AfterFill() {
	        var r = DS.provisiondetail.Rows[0];
            
	        gestisciSegno();
        }

        public void MetaData_AfterClear() {
            txtImporto.Text = "";
            rdbAumento.Checked = false;
            rdbDiminuzione.Checked = false;
        }

        private void rdbDiminuzione_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            gestisciSegno();
        }

	    void gestisciSegno() {
	        if (rdbAumento.Checked) {
	            grpCausale.Visible = false;
	            DataRow r = DS.provisiondetail.Rows[0];
	            r["idaccmotive"] = DBNull.Value;
	        }
	        else {
	            grpCausale.Visible = true;
	        }
	    }

        private void rdbAumento_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            gestisciSegno();
        }
    }
}
