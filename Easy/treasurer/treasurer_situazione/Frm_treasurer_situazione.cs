
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;

namespace treasurer_situazione//istitutocassiere_situazione//
{
	/// <summary>
	/// Summary description for frmistitutocassiere_situazione.
	/// </summary>
	public class Frm_treasurer_situazione : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodiceIstituto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label2;
		public /*Rana:istitutocassiere_situazione.*/vistaForm DS;
		private System.Windows.Forms.Button btnSituazioneCassiere;
		private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ImageList images;
        private Button btnValorizzaSaldo;
        private Label label3;
        private TextBox SubEntity_txtSaldo;
        private PictureBox pictureBox1;
		public MetaData Meta;

		public Frm_treasurer_situazione()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_treasurer_situazione));
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodiceIstituto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSituazioneCassiere = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnValorizzaSaldo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SubEntity_txtSaldo = new System.Windows.Forms.TextBox();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new treasurer_situazione.vistaForm();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 104);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(382, 37);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Tag = "treasurer.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodiceIstituto
            // 
            this.txtCodiceIstituto.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceIstituto.Name = "txtCodiceIstituto";
            this.txtCodiceIstituto.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceIstituto.TabIndex = 1;
            this.txtCodiceIstituto.Tag = "treasurer.codetreasurer";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice del Tesoriere:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSituazioneCassiere
            // 
            this.btnSituazioneCassiere.Location = new System.Drawing.Point(184, 48);
            this.btnSituazioneCassiere.Name = "btnSituazioneCassiere";
            this.btnSituazioneCassiere.Size = new System.Drawing.Size(72, 23);
            this.btnSituazioneCassiere.TabIndex = 20;
            this.btnSituazioneCassiere.TabStop = false;
            this.btnSituazioneCassiere.Text = "Situazione";
            this.btnSituazioneCassiere.Click += new System.EventHandler(this.btnSituazioneCassiere_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnValorizzaSaldo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SubEntity_txtSaldo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodiceIstituto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.btnSituazioneCassiere);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 216);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Tesoriere";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(294, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 64);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // btnValorizzaSaldo
            // 
            this.btnValorizzaSaldo.Location = new System.Drawing.Point(215, 158);
            this.btnValorizzaSaldo.Name = "btnValorizzaSaldo";
            this.btnValorizzaSaldo.Size = new System.Drawing.Size(175, 36);
            this.btnValorizzaSaldo.TabIndex = 47;
            this.btnValorizzaSaldo.Text = "Copia saldo iniziale dall\'esercizio precedente";
            this.btnValorizzaSaldo.UseVisualStyleBackColor = true;
            this.btnValorizzaSaldo.Click += new System.EventHandler(this.btnValorizzaSaldo_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Saldo iniziale:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubEntity_txtSaldo
            // 
            this.SubEntity_txtSaldo.Location = new System.Drawing.Point(8, 174);
            this.SubEntity_txtSaldo.Name = "SubEntity_txtSaldo";
            this.SubEntity_txtSaldo.Size = new System.Drawing.Size(122, 20);
            this.SubEntity_txtSaldo.TabIndex = 45;
            this.SubEntity_txtSaldo.Tag = "treasurerstart.amount";
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
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_treasurer_situazione
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(426, 240);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_treasurer_situazione";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() 
		{
			Meta = MetaData.GetMetaData(this);
			Meta.CanCancel=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy = false;

            GetData.SetStaticFilter(DS.treasurerstart, Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			
		}


		public void MetaData_AfterFill(){
			btnSituazioneCassiere.Enabled=true;
            SubEntity_txtSaldo.ReadOnly = (DS.treasurerstart.Rows.Count == 0);
            btnValorizzaSaldo.Enabled = true;// (DS.treasurerstart.Rows.Count > 0);
			//Text="Situazione istituto cassiere";
		}

		public void MetaData_AfterClear(){
			btnSituazioneCassiere.Enabled=false;
            SubEntity_txtSaldo.ReadOnly = true;
            btnValorizzaSaldo.Enabled = false;
		}


		private void btnSituazioneCassiere_Click(object sender, System.EventArgs e) {
            object idtreasurer;

            DataRow MyRow = HelpForm.GetLastSelected(DS.treasurer);
            if (MyRow == null) return;
            idtreasurer = MyRow["idtreasurer"];


            DataSet Out = Meta.Conn.CallSP("show_treasurer",
                new Object[3] { Meta.GetSys("esercizio"), Meta.GetSys("datacontabile"), idtreasurer });
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione Istituto Cassiere";
            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show(); 
            
		}

        private void btnValorizzaSaldo_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(false)) return;
            Meta.SaveFormData();
            if (DS.HasChanges()) return;

            object idtreasurer;
            QueryHelper QHS = Meta.Conn.GetQueryHelper();

            int ayearPrec = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
            int ayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            DataRow CurrRow = DS.treasurer.Rows[0];
            idtreasurer = CurrRow["idtreasurer"];
            string filter = QHS.AppAnd(QHS.CmpEq("idtreasurer", idtreasurer), QHS.CmpEq("ayear", ayearPrec));
            decimal currentfloatfund = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("treasurercashtotal", filter, "currentfloatfund"));

            DataRow TStart;
            if (DS.treasurerstart.Rows.Count == 0) {
                MetaData MStart = Meta.Dispatcher.Get("treasurerstart");
                MStart.SetDefaults(DS.treasurerstart);
                TStart = MStart.Get_New_Row(CurrRow, DS.treasurerstart);
            }
            else {
                TStart = DS.treasurerstart.Rows[0];
            }
            TStart["amount"] = currentfloatfund;
            Meta.SaveFormData();
            SubEntity_txtSaldo.ReadOnly = false;
        }


	}
}
