
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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;
namespace csa_agency_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_agency_default : MetaDataForm {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        MetaData Meta;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private Label label3;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private GroupBox grpModalita;
        private DataGrid dgrPagamento;
        private Button btnPagElimina;
        private Button btnPagModifica;
        private Button btnPagInserisci;
        private CheckBox chkAnnualPayment;
        private CheckBox chk;
        private System.ComponentModel.IContainer components;

		public Frm_csa_agency_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.csa_agency.Columns["isinternal"], true);
            HelpForm.SetDenyNull(DS.csa_agency.Columns["flag"], true);
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
        CQueryHelper QHC;
        QueryHelper QHS;
		
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterFill () {
            if (Meta.IsEmpty) return;
            if (CfgFn.GetNoNullInt32(DS.csa_agency.Rows[0]["idreg"]) != 0) {
                MetaData.SetDefault(DS.csa_agencypaymethod, "idreg", "S");
            }
            else {
                grpModalita.Enabled = false;
            }
            if (DS.csa_agencypaymethod.Select().Length > 0) {
                txtCredDeb.ReadOnly = true;
                grpModalita.Enabled = true;
            }
            else {
                txtCredDeb.ReadOnly = false;
            }
        }

        public void MetaData_AfterClear () {
            txtCredDeb.ReadOnly = false;
            grpModalita.Enabled = true;
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
            if (T.TableName == "registry") {
                if (R != null) {
                    grpModalita.Enabled = true;
                    MetaData.SetDefault(DS.csa_agencypaymethod, "idreg",R["idreg"]);
                }
                else {
                    grpModalita.Enabled = false;
                }
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_agency_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grpModalita = new System.Windows.Forms.GroupBox();
			this.dgrPagamento = new System.Windows.Forms.DataGrid();
			this.btnPagElimina = new System.Windows.Forms.Button();
			this.btnPagModifica = new System.Windows.Forms.Button();
			this.btnPagInserisci = new System.Windows.Forms.Button();
			this.DS = new csa_agency_default.vistaForm();
			this.chkAnnualPayment = new System.Windows.Forms.CheckBox();
			this.chk = new System.Windows.Forms.CheckBox();
			this.groupCredDeb.SuspendLayout();
			this.grpModalita.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPagamento)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
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
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(21, 189);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(436, 56);
			this.groupCredDeb.TabIndex = 5;
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
			this.txtCredDeb.Size = new System.Drawing.Size(420, 20);
			this.txtCredDeb.TabIndex = 0;
			this.txtCredDeb.Tag = "registry.title?csa_agencyview.registry";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Ente CSA:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(106, 163);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(351, 20);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "csa_agency.ente";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.Location = new System.Drawing.Point(218, 12);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox1.Size = new System.Drawing.Size(239, 22);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Tag = "csa_agency.isinternal:S:N";
			this.checkBox1.Text = "Ente Interno per Recuperi";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(106, 17);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "csa_agency.idcsa_agency";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(105, 108);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(351, 49);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "csa_agency.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpModalita
			// 
			this.grpModalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpModalita.Controls.Add(this.dgrPagamento);
			this.grpModalita.Controls.Add(this.btnPagElimina);
			this.grpModalita.Controls.Add(this.btnPagModifica);
			this.grpModalita.Controls.Add(this.btnPagInserisci);
			this.grpModalita.Location = new System.Drawing.Point(20, 251);
			this.grpModalita.Name = "grpModalita";
			this.grpModalita.Size = new System.Drawing.Size(437, 243);
			this.grpModalita.TabIndex = 10;
			this.grpModalita.TabStop = false;
			this.grpModalita.Text = "Modalità di Pagamento Anagrafica";
			// 
			// dgrPagamento
			// 
			this.dgrPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPagamento.CaptionVisible = false;
			this.dgrPagamento.DataMember = "";
			this.dgrPagamento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPagamento.Location = new System.Drawing.Point(84, 22);
			this.dgrPagamento.Name = "dgrPagamento";
			this.dgrPagamento.ReadOnly = true;
			this.dgrPagamento.Size = new System.Drawing.Size(344, 215);
			this.dgrPagamento.TabIndex = 11;
			this.dgrPagamento.Tag = "csa_agencypaymethod.anagrafica.anagrafica";
			// 
			// btnPagElimina
			// 
			this.btnPagElimina.Location = new System.Drawing.Point(8, 78);
			this.btnPagElimina.Name = "btnPagElimina";
			this.btnPagElimina.Size = new System.Drawing.Size(68, 22);
			this.btnPagElimina.TabIndex = 13;
			this.btnPagElimina.Tag = "Delete";
			this.btnPagElimina.Text = "Elimina";
			// 
			// btnPagModifica
			// 
			this.btnPagModifica.Location = new System.Drawing.Point(8, 50);
			this.btnPagModifica.Name = "btnPagModifica";
			this.btnPagModifica.Size = new System.Drawing.Size(69, 22);
			this.btnPagModifica.TabIndex = 12;
			this.btnPagModifica.Tag = "edit.anagrafica";
			this.btnPagModifica.Text = "Modifica...";
			// 
			// btnPagInserisci
			// 
			this.btnPagInserisci.Location = new System.Drawing.Point(10, 22);
			this.btnPagInserisci.Name = "btnPagInserisci";
			this.btnPagInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnPagInserisci.TabIndex = 10;
			this.btnPagInserisci.Tag = "Insert.anagrafica";
			this.btnPagInserisci.Text = "Inserisci...";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// chkAnnualPayment
			// 
			this.chkAnnualPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkAnnualPayment.Location = new System.Drawing.Point(212, 37);
			this.chkAnnualPayment.Name = "chkAnnualPayment";
			this.chkAnnualPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkAnnualPayment.Size = new System.Drawing.Size(244, 22);
			this.chkAnnualPayment.TabIndex = 11;
			this.chkAnnualPayment.Tag = "csa_agency.flag:0";
			this.chkAnnualPayment.Text = "Versamenti posticipati rispetto all\'importazione";
			// 
			// chk
			// 
			this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chk.Location = new System.Drawing.Point(164, 65);
			this.chk.Name = "chk";
			this.chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chk.Size = new System.Drawing.Size(292, 22);
			this.chk.TabIndex = 12;
			this.chk.Tag = "csa_agency.flag:1";
			this.chk.Text = "Non associare a sospeso in Elaborazione Versamenti";
			// 
			// Frm_csa_agency_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(477, 502);
			this.Controls.Add(this.chk);
			this.Controls.Add(this.chkAnnualPayment);
			this.Controls.Add(this.grpModalita);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_csa_agency_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmEnte";
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.grpModalita.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrPagamento)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
