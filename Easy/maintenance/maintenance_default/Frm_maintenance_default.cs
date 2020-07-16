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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione


namespace maintenance_default//eventotecnico//
{
	/// <summary>
	/// Summary description for frmeventotecnico.
	/// </summary>
	public class Frm_maintenance_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbInventario;
		private System.Windows.Forms.TextBox txtNumInv;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		public vistaForm DS;
		public MetaData Meta;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.TextBox txtImporto;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtidpiece;
		private System.Windows.Forms.TextBox txtDescrizioneCespite;
		private System.Windows.Forms.TextBox txtDescrizioneEvento;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label labDescrizione;
		private System.Windows.Forms.Button btnSelezBene;
		private object m_LastCodiceInventario=DBNull.Value;
		private System.Windows.Forms.Button btnTipo;
		MetaData.AutoInfo MyAutoInfo;

		public Frm_maintenance_default()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelezBene = new System.Windows.Forms.Button();
            this.labDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtidpiece = new System.Windows.Forms.TextBox();
            this.txtDescrizioneCespite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.DS = new maintenance_default.vistaForm();
            this.txtNumInv = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtDescrizioneEvento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTipo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelezBene);
            this.groupBox1.Controls.Add(this.labDescrizione);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.txtidpiece);
            this.groupBox1.Controls.Add(this.txtDescrizioneCespite);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbInventario);
            this.groupBox1.Controls.Add(this.txtNumInv);
            this.groupBox1.Location = new System.Drawing.Point(16, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtNumInv.default";
            this.groupBox1.Text = "Cespite";
            // 
            // btnSelezBene
            // 
            this.btnSelezBene.Location = new System.Drawing.Point(16, 48);
            this.btnSelezBene.Name = "btnSelezBene";
            this.btnSelezBene.Size = new System.Drawing.Size(80, 24);
            this.btnSelezBene.TabIndex = 26;
            this.btnSelezBene.Tag = "choose.assetpieceview.default";
            this.btnSelezBene.Text = "N.Inventario";
            // 
            // labDescrizione
            // 
            this.labDescrizione.Location = new System.Drawing.Point(24, 144);
            this.labDescrizione.Name = "labDescrizione";
            this.labDescrizione.Size = new System.Drawing.Size(184, 16);
            this.labDescrizione.TabIndex = 25;
            this.labDescrizione.Text = "Descrizione Cespite principale";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(24, 168);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(552, 48);
            this.txtDescrizione.TabIndex = 24;
            this.txtDescrizione.Tag = "assetpieceview.descriptionmain";
            // 
            // txtidpiece
            // 
            this.txtidpiece.Location = new System.Drawing.Point(8, 112);
            this.txtidpiece.Name = "txtidpiece";
            this.txtidpiece.ReadOnly = true;
            this.txtidpiece.Size = new System.Drawing.Size(64, 20);
            this.txtidpiece.TabIndex = 23;
            this.txtidpiece.Tag = "assetpieceview.idpiece?maintenanceview.idpiece";
            this.txtidpiece.Text = "idpiece Value";
            this.txtidpiece.Visible = false;
            // 
            // txtDescrizioneCespite
            // 
            this.txtDescrizioneCespite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneCespite.Location = new System.Drawing.Point(104, 80);
            this.txtDescrizioneCespite.Multiline = true;
            this.txtDescrizioneCespite.Name = "txtDescrizioneCespite";
            this.txtDescrizioneCespite.ReadOnly = true;
            this.txtDescrizioneCespite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneCespite.Size = new System.Drawing.Size(472, 56);
            this.txtDescrizioneCespite.TabIndex = 2;
            this.txtDescrizioneCespite.TabStop = false;
            this.txtDescrizioneCespite.Tag = "assetpieceview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(32, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Descrizione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Inventario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DataSource = this.DS.inventory;
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventario.Location = new System.Drawing.Point(104, 24);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(472, 21);
            this.cmbInventario.TabIndex = 4;
            this.cmbInventario.Tag = "assetpieceview.idinventory.(active=\'S\')?maintenanceview.idinventory";
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtNumInv
            // 
            this.txtNumInv.Location = new System.Drawing.Point(104, 48);
            this.txtNumInv.Name = "txtNumInv";
            this.txtNumInv.Size = new System.Drawing.Size(88, 20);
            this.txtNumInv.TabIndex = 5;
            this.txtNumInv.Tag = "assetpieceview.ninventory?maintenanceview.ninventory";
            this.txtNumInv.TextChanged += new System.EventHandler(this.txtNumInv_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "maintenance.nmaintenance";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.maintenancekind;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(136, 40);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(472, 21);
            this.cboTipo.TabIndex = 2;
            this.cboTipo.Tag = "maintenance.idmaintenancekind.(active=\'S\')";
            this.cboTipo.ValueMember = "idmaintenancekind";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(112, 376);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(93, 20);
            this.txtData.TabIndex = 7;
            this.txtData.Tag = "maintenance.adate";
            // 
            // txtDescrizioneEvento
            // 
            this.txtDescrizioneEvento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneEvento.Location = new System.Drawing.Point(16, 320);
            this.txtDescrizioneEvento.Multiline = true;
            this.txtDescrizioneEvento.Name = "txtDescrizioneEvento";
            this.txtDescrizioneEvento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneEvento.Size = new System.Drawing.Size(592, 48);
            this.txtDescrizioneEvento.TabIndex = 6;
            this.txtDescrizioneEvento.Tag = "maintenance.description";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Contabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(336, 376);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(112, 20);
            this.txtImporto.TabIndex = 8;
            this.txtImporto.Tag = "maintenance.amount";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(16, 40);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(112, 24);
            this.btnTipo.TabIndex = 2;
            this.btnTipo.TabStop = false;
            this.btnTipo.Tag = "manage.maintenancekind.default";
            this.btnTipo.Text = "Tipo Manutenzione";
            // 
            // Frm_maintenance_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 422);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtDescrizioneEvento);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_maintenance_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmeventotecnico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC= new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}
		
		private void abilitaSceltaBene(bool enabled) 
		{
			cmbInventario.Enabled = enabled;
			btnTipo.Enabled = enabled;
			cboTipo.Enabled = enabled;
			txtNumInv.ReadOnly = ! enabled;
			btnSelezBene.Enabled = enabled;
		}

		public void MetaData_AfterClear() {
			btnSelezBene.Tag = "choose.assetpieceview.default";
			m_LastCodiceInventario="";
			txtImporto.Text="";
			txtDescrizione.Visible=false; txtDescrizioneCespite.Height=120; // change Height
			labDescrizione.Visible=false;
			abilitaSceltaBene(true);
		}
		public void MetaData_AfterFill() 
		{
			if (MyAutoInfo == null) MyAutoInfo= Meta.GetAutoInfo(txtNumInv.Name);

			abilitaSceltaBene(Meta.InsertMode);
			if (Meta.IsEmpty) return;

			if (!Meta.IsEmpty) 
			{
				if (DS.assetpieceview.Rows.Count==0)
					ImpostaFiltrobtnSelezBene(null,false);
				else 
					ImpostaFiltrobtnSelezBene(DS.assetpieceview.Rows[0],true);
			}

			if (!Meta.InsertMode) 
			{				
				if (cmbInventario.SelectedIndex > 0) 
					m_LastCodiceInventario=cmbInventario.SelectedValue.ToString();
				else 
					m_LastCodiceInventario="";
			}
			int nidpiece= CfgFn.GetNoNullInt32(DS.maintenance.Rows[0]["idpiece"]);
			if (nidpiece==1)
			{
				txtDescrizione.Visible = false; txtDescrizioneCespite.Height=120; // change Height
				labDescrizione.Visible = false;
			}
			else 
			{
				txtDescrizione.Visible=true; txtDescrizioneCespite.Height=56; // change Height
				labDescrizione.Visible=true;
			}
		}
		

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) 
		{
			if (T.TableName == "inventory") {
				if (!Meta.DrawStateIsDone) return;
				ImpostaFiltrobtnSelezBene(R,false);
				ScollegaBene(R);
			}
		}

		void ImpostaFiltrobtnSelezBene(DataRow AssetPiece, bool filtraIdPiece)
		{
			string filtro = (AssetPiece== null) ? "" : "."+QHS.CmpMulti(AssetPiece,"idinventory");
			btnSelezBene.Tag = "choose.assetpieceview.default" + filtro;
			if (AssetPiece!=null && filtraIdPiece) 	
			{
                filtro= QHS.AppAnd(filtro,QHS.CmpMulti(AssetPiece,"idpiece"));
				btnSelezBene.Tag = "choose.assetpieceview.default" + filtro;
				if (MyAutoInfo!=null)
					MyAutoInfo.startfilter=QHS.AppAnd(QHS.IsNull("idassetunload"),QHS.CmpMulti(AssetPiece,"idpiece"));
			}
			else 
			{
				if (MyAutoInfo!=null)
					MyAutoInfo.startfilter=QHS.IsNull("idassetunload");
			}
		}

		private void ScollegaBene(DataRow R) {
			object codice=(R==null?DBNull.Value:R["idinventory"]);
			if (m_LastCodiceInventario.Equals(codice)) return;
			m_LastCodiceInventario=codice;
			txtNumInv.Text="";
			txtDescrizioneCespite.Text="";
			if (!Meta.IsEmpty) {
				DS.assetpieceview.Clear();
				DS.maintenance.Rows[0]["idasset"]=-1;
			}
		}

		private void txtNumInv_TextChanged(object sender, System.EventArgs e)
		{
			if (Meta==null) return;
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if (DS.assetpieceview.Rows.Count==0) 
			{
				ImpostaFiltrobtnSelezBene(null,false);
				return;
			}
			DataRow R=DS.assetpieceview.Rows[0];
			ImpostaFiltrobtnSelezBene(R,false); 
		}
	}
}
