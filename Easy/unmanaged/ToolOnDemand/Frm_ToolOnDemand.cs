
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
using System.IO;
using System.Data;
using metadatalibrary;
using System.Globalization;
using utility;//utility

namespace ToolOnDemand//ToolOnDemand//
{
	/// <summary>
	/// Summary description for frmToolOnDemand.
	/// </summary>
	public class Frm_ToolOnDemand : MetaDataForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private const string C_FILEINDEX="remoteondemandindex.xml";
		private /*Rana:ToolOnDemand.*/vistaForm DS;
		private System.Windows.Forms.TextBox txtDataRilascio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid gridMaster;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnInsertMaster;
		private System.Windows.Forms.Button btnDeleteMaster;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.DataGrid gridDetail;
		private string m_IndexFileName="";
		private string m_IndexFileZip="";
		private string m_IndexFileDir="";
		private System.Windows.Forms.CheckBox chkAnnullato;
		private DataTable TcmbTipoUpdate=null;
		private DataTable TcmbTipoFile=null;
		private DataRow m_CurrentMasterRow=null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbTipoUpdate;
		private System.Windows.Forms.TextBox txtNomeFile;
		private System.Windows.Forms.TextBox txtProgressivo;
		private System.Windows.Forms.ComboBox cmbTipoFile;
		private System.Windows.Forms.GroupBox grpDetail;
		private DataRow m_CurrentDetailRow=null;
		private System.Windows.Forms.Button btnUpdateMaster;
		private System.Windows.Forms.Button btnUpdateDetail;
		private System.Windows.Forms.Button btnDeleteDetail;
		private System.Windows.Forms.Button btnInsertDetail;
		private System.Windows.Forms.Button btnCancelMaster;
		private System.Windows.Forms.Button btnCancelDetail;
		private bool modified=false;
		private bool IsDetailOperation=false;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Button btnFile;
		private System.Windows.Forms.GroupBox grpMaster;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDescrizioneBreve;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtVersioneMinima;
	
		private enum eStato {
			READ,
			INSERT
		}
		private eStato Stato=eStato.READ;

		public Frm_ToolOnDemand()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			btnFile_Click(null,null);
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
			this.DS = new /*Rana:ToolOnDemand.*/vistaForm();
			this.grpMaster = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnCancelMaster = new System.Windows.Forms.Button();
			this.btnUpdateMaster = new System.Windows.Forms.Button();
			this.btnDeleteMaster = new System.Windows.Forms.Button();
			this.btnInsertMaster = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbTipoUpdate = new System.Windows.Forms.ComboBox();
			this.txtDataRilascio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDescrizioneBreve = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gridMaster = new System.Windows.Forms.DataGrid();
			this.chkAnnullato = new System.Windows.Forms.CheckBox();
			this.grpDetail = new System.Windows.Forms.GroupBox();
			this.btnCancelDetail = new System.Windows.Forms.Button();
			this.btnUpdateDetail = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbTipoFile = new System.Windows.Forms.ComboBox();
			this.txtNomeFile = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtProgressivo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnDeleteDetail = new System.Windows.Forms.Button();
			this.btnInsertDetail = new System.Windows.Forms.Button();
			this.gridDetail = new System.Windows.Forms.DataGrid();
			this.btnSalva = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.btnFile = new System.Windows.Forms.Button();
			this.txtVersioneMinima = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpMaster.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
			this.grpDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// grpMaster
			// 
			this.grpMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpMaster.Controls.Add(this.txtVersioneMinima);
			this.grpMaster.Controls.Add(this.label10);
			this.grpMaster.Controls.Add(this.txtDescrizione);
			this.grpMaster.Controls.Add(this.label9);
			this.grpMaster.Controls.Add(this.btnCancelMaster);
			this.grpMaster.Controls.Add(this.btnUpdateMaster);
			this.grpMaster.Controls.Add(this.btnDeleteMaster);
			this.grpMaster.Controls.Add(this.btnInsertMaster);
			this.grpMaster.Controls.Add(this.label4);
			this.grpMaster.Controls.Add(this.cmbTipoUpdate);
			this.grpMaster.Controls.Add(this.txtDataRilascio);
			this.grpMaster.Controls.Add(this.label3);
			this.grpMaster.Controls.Add(this.txtDescrizioneBreve);
			this.grpMaster.Controls.Add(this.label2);
			this.grpMaster.Controls.Add(this.txtCodice);
			this.grpMaster.Controls.Add(this.label1);
			this.grpMaster.Controls.Add(this.gridMaster);
			this.grpMaster.Controls.Add(this.chkAnnullato);
			this.grpMaster.Location = new System.Drawing.Point(16, 48);
			this.grpMaster.Name = "grpMaster";
			this.grpMaster.Size = new System.Drawing.Size(648, 328);
			this.grpMaster.TabIndex = 1;
			this.grpMaster.TabStop = false;
			this.grpMaster.Text = "Aggiornamento";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(88, 280);
			this.txtDescrizione.MaxLength = 2000;
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(352, 40);
			this.txtDescrizione.TabIndex = 4;
			this.txtDescrizione.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 280);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 23;
			this.label9.Text = "Descrizione";
			// 
			// btnCancelMaster
			// 
			this.btnCancelMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelMaster.Location = new System.Drawing.Point(560, 296);
			this.btnCancelMaster.Name = "btnCancelMaster";
			this.btnCancelMaster.TabIndex = 10;
			this.btnCancelMaster.Text = "Annulla";
			this.btnCancelMaster.Click += new System.EventHandler(this.btnCancelMaster_Click);
			// 
			// btnUpdateMaster
			// 
			this.btnUpdateMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateMaster.Location = new System.Drawing.Point(560, 272);
			this.btnUpdateMaster.Name = "btnUpdateMaster";
			this.btnUpdateMaster.TabIndex = 8;
			this.btnUpdateMaster.Text = "Aggiorna";
			this.btnUpdateMaster.Click += new System.EventHandler(this.btnUpdateMaster_Click);
			// 
			// btnDeleteMaster
			// 
			this.btnDeleteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteMaster.Location = new System.Drawing.Point(464, 296);
			this.btnDeleteMaster.Name = "btnDeleteMaster";
			this.btnDeleteMaster.TabIndex = 9;
			this.btnDeleteMaster.Text = "Elimina";
			this.btnDeleteMaster.Click += new System.EventHandler(this.btnDeleteMaster_Click);
			// 
			// btnInsertMaster
			// 
			this.btnInsertMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInsertMaster.Location = new System.Drawing.Point(464, 272);
			this.btnInsertMaster.Name = "btnInsertMaster";
			this.btnInsertMaster.TabIndex = 7;
			this.btnInsertMaster.Text = "Inserisci";
			this.btnInsertMaster.Click += new System.EventHandler(this.btnInsertMaster_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 234);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 21;
			this.label4.Text = "Tipo";
			// 
			// cmbTipoUpdate
			// 
			this.cmbTipoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoUpdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoUpdate.Location = new System.Drawing.Point(88, 232);
			this.cmbTipoUpdate.Name = "cmbTipoUpdate";
			this.cmbTipoUpdate.Size = new System.Drawing.Size(224, 21);
			this.cmbTipoUpdate.TabIndex = 6;
			// 
			// txtDataRilascio
			// 
			this.txtDataRilascio.Location = new System.Drawing.Point(232, 208);
			this.txtDataRilascio.Name = "txtDataRilascio";
			this.txtDataRilascio.Size = new System.Drawing.Size(72, 20);
			this.txtDataRilascio.TabIndex = 2;
			this.txtDataRilascio.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 210);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Pubblicato";
			// 
			// txtDescrizioneBreve
			// 
			this.txtDescrizioneBreve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizioneBreve.Location = new System.Drawing.Point(88, 256);
			this.txtDescrizioneBreve.MaxLength = 500;
			this.txtDescrizioneBreve.Name = "txtDescrizioneBreve";
			this.txtDescrizioneBreve.Size = new System.Drawing.Size(352, 20);
			this.txtDescrizioneBreve.TabIndex = 3;
			this.txtDescrizioneBreve.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 16;
			this.label2.Text = "Breve desc.";
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(88, 208);
			this.txtCodice.MaxLength = 10;
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtCodice.Size = new System.Drawing.Size(72, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "";
			this.txtCodice.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 210);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Codice";
			// 
			// gridMaster
			// 
			this.gridMaster.AllowNavigation = false;
			this.gridMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridMaster.CaptionVisible = false;
			this.gridMaster.DataMember = "";
			this.gridMaster.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridMaster.Location = new System.Drawing.Point(16, 24);
			this.gridMaster.Name = "gridMaster";
			this.gridMaster.ReadOnly = true;
			this.gridMaster.Size = new System.Drawing.Size(616, 176);
			this.gridMaster.TabIndex = 0;
			this.gridMaster.Tag = "";
			this.gridMaster.Click += new System.EventHandler(this.gridMaster_Click);
			this.gridMaster.CurrentCellChanged += new System.EventHandler(this.gridMaster_Click);
			// 
			// chkAnnullato
			// 
			this.chkAnnullato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkAnnullato.Location = new System.Drawing.Point(336, 232);
			this.chkAnnullato.Name = "chkAnnullato";
			this.chkAnnullato.Size = new System.Drawing.Size(72, 16);
			this.chkAnnullato.TabIndex = 5;
			this.chkAnnullato.Text = "Annullato";
			// 
			// grpDetail
			// 
			this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpDetail.Controls.Add(this.btnCancelDetail);
			this.grpDetail.Controls.Add(this.btnUpdateDetail);
			this.grpDetail.Controls.Add(this.label5);
			this.grpDetail.Controls.Add(this.cmbTipoFile);
			this.grpDetail.Controls.Add(this.txtNomeFile);
			this.grpDetail.Controls.Add(this.label6);
			this.grpDetail.Controls.Add(this.txtProgressivo);
			this.grpDetail.Controls.Add(this.label7);
			this.grpDetail.Controls.Add(this.btnDeleteDetail);
			this.grpDetail.Controls.Add(this.btnInsertDetail);
			this.grpDetail.Controls.Add(this.gridDetail);
			this.grpDetail.Location = new System.Drawing.Point(16, 384);
			this.grpDetail.Name = "grpDetail";
			this.grpDetail.Size = new System.Drawing.Size(648, 160);
			this.grpDetail.TabIndex = 2;
			this.grpDetail.TabStop = false;
			this.grpDetail.Text = "Dettaglio aggiornamento";
			// 
			// btnCancelDetail
			// 
			this.btnCancelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelDetail.Location = new System.Drawing.Point(552, 128);
			this.btnCancelDetail.Name = "btnCancelDetail";
			this.btnCancelDetail.TabIndex = 6;
			this.btnCancelDetail.Text = "Annulla";
			this.btnCancelDetail.Click += new System.EventHandler(this.btnCancelDetail_Click);
			// 
			// btnUpdateDetail
			// 
			this.btnUpdateDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateDetail.Location = new System.Drawing.Point(552, 104);
			this.btnUpdateDetail.Name = "btnUpdateDetail";
			this.btnUpdateDetail.TabIndex = 4;
			this.btnUpdateDetail.Text = "Aggiorna";
			this.btnUpdateDetail.Click += new System.EventHandler(this.btnUpdateDetail_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(368, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 31;
			this.label5.Text = "Tipo file";
			// 
			// cmbTipoFile
			// 
			this.cmbTipoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoFile.Location = new System.Drawing.Point(448, 72);
			this.cmbTipoFile.Name = "cmbTipoFile";
			this.cmbTipoFile.Size = new System.Drawing.Size(192, 21);
			this.cmbTipoFile.TabIndex = 2;
			// 
			// txtNomeFile
			// 
			this.txtNomeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNomeFile.Location = new System.Drawing.Point(448, 48);
			this.txtNomeFile.Name = "txtNomeFile";
			this.txtNomeFile.Size = new System.Drawing.Size(192, 20);
			this.txtNomeFile.TabIndex = 1;
			this.txtNomeFile.Text = "";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(368, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 28;
			this.label6.Text = "Nome file";
			// 
			// txtProgressivo
			// 
			this.txtProgressivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProgressivo.Location = new System.Drawing.Point(448, 24);
			this.txtProgressivo.Name = "txtProgressivo";
			this.txtProgressivo.ReadOnly = true;
			this.txtProgressivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtProgressivo.Size = new System.Drawing.Size(80, 20);
			this.txtProgressivo.TabIndex = 0;
			this.txtProgressivo.Tag = "";
			this.txtProgressivo.Text = "";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(368, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 26;
			this.label7.Text = "Progressivo";
			// 
			// btnDeleteDetail
			// 
			this.btnDeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteDetail.Location = new System.Drawing.Point(448, 128);
			this.btnDeleteDetail.Name = "btnDeleteDetail";
			this.btnDeleteDetail.TabIndex = 5;
			this.btnDeleteDetail.Text = "Elimina";
			this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
			// 
			// btnInsertDetail
			// 
			this.btnInsertDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInsertDetail.Location = new System.Drawing.Point(448, 104);
			this.btnInsertDetail.Name = "btnInsertDetail";
			this.btnInsertDetail.TabIndex = 3;
			this.btnInsertDetail.Text = "Inserisci";
			this.btnInsertDetail.Click += new System.EventHandler(this.btnInsertDetail_Click);
			// 
			// gridDetail
			// 
			this.gridDetail.AllowNavigation = false;
			this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetail.CaptionVisible = false;
			this.gridDetail.DataMember = "";
			this.gridDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDetail.Location = new System.Drawing.Point(16, 24);
			this.gridDetail.Name = "gridDetail";
			this.gridDetail.ReadOnly = true;
			this.gridDetail.Size = new System.Drawing.Size(344, 128);
			this.gridDetail.TabIndex = 13;
			this.gridDetail.Tag = "fileupdate.default";
			this.gridDetail.Click += new System.EventHandler(this.gridDetail_Click);
			this.gridDetail.CurrentCellChanged += new System.EventHandler(this.gridDetail_Click);
			// 
			// btnSalva
			// 
			this.btnSalva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSalva.Location = new System.Drawing.Point(251, 552);
			this.btnSalva.Name = "btnSalva";
			this.btnSalva.TabIndex = 3;
			this.btnSalva.Text = "Salva";
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnChiudi.Location = new System.Drawing.Point(355, 552);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 4;
			this.btnChiudi.Text = "Chiudi";
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 5;
			this.label8.Text = "Locazione File XML";
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(128, 14);
			this.txtFile.Name = "txtFile";
			this.txtFile.ReadOnly = true;
			this.txtFile.Size = new System.Drawing.Size(504, 20);
			this.txtFile.TabIndex = 6;
			this.txtFile.Text = "";
			// 
			// btnFile
			// 
			this.btnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFile.Location = new System.Drawing.Point(632, 13);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(24, 23);
			this.btnFile.TabIndex = 7;
			this.btnFile.Text = "...";
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// txtVersioneMinima
			// 
			this.txtVersioneMinima.Location = new System.Drawing.Point(472, 208);
			this.txtVersioneMinima.Name = "txtVersioneMinima";
			this.txtVersioneMinima.Size = new System.Drawing.Size(72, 20);
			this.txtVersioneMinima.TabIndex = 24;
			this.txtVersioneMinima.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(336, 210);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 16);
			this.label10.TabIndex = 25;
			this.label10.Text = "Versione DB supportata";
			// 
			// frmToolOnDemand
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 582);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnSalva);
			this.Controls.Add(this.grpDetail);
			this.Controls.Add(this.grpMaster);
			this.Name = "frmToolOnDemand";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Live Update On Demand Tool";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmToolOnDemand_Closing);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpMaster.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
			this.grpDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Metodi Comuni

		private void btnFile_Click(object sender, System.EventArgs e) {
			grpMaster.Enabled=false;
			grpDetail.Enabled=false;
			FolderBrowserDialog dir=new FolderBrowserDialog();
			dir.Description="Specificare la cartella in cui esiste o verrà generato il file";
			if (m_IndexFileDir!="") dir.SelectedPath=m_IndexFileDir;
			if (dir.ShowDialog()!=DialogResult.OK) return;
			m_IndexFileDir=dir.SelectedPath;
			if (!m_IndexFileDir.EndsWith(@"\")) m_IndexFileDir+=@"\";
			m_IndexFileName=m_IndexFileDir+C_FILEINDEX;
			m_IndexFileZip=m_IndexFileName.Remove(m_IndexFileName.Length-3,3)+"zip";
			txtFile.Text=m_IndexFileName;
			Init();
		}

		private void Init() {
			grpMaster.Enabled=true;
			DS.Clear();
			if (!File.Exists(m_IndexFileName)) Archivia();
			DS.ReadXml(m_IndexFileName);
			FillCombo();
			//L'ordinamento ha effetto solo sui grid Detail
			GetData.SetSorting(DS.fileupdate,"progressivo ASC");
			DS.fileupdate.ExtendedProperties["gridmaster"]="update";
			ImpostaGridMaster();
			ImpostaControlliMaster();
			AggiungiEventi();
			AbilitaBottoniMaster();
		}

		private void AggiungiEventi() {
			txtDataRilascio.Leave+=new System.EventHandler(GeneralLeaveDateTextBox);
		}

		private void SetCheckBox(CheckBox C, string valore) {
			if (valore.ToUpper()=="S") {
				C.Checked=true;
				C.CheckState= CheckState.Checked;
			}
			else {
				C.Checked=false;
				C.CheckState= CheckState.Unchecked;
			}				
		}

		private void FillCombo() {
			if (TcmbTipoUpdate==null) {
				TcmbTipoUpdate=new DataTable();
				TcmbTipoUpdate.Columns.Add("codicetipo");
				TcmbTipoUpdate.Columns.Add("descrizione");
				TcmbTipoUpdate.Rows.Add(new object[]{"", ""});
				TcmbTipoUpdate.Rows.Add(new object[]{"S", "Server side"});
				TcmbTipoUpdate.Rows.Add(new object[]{"C", "Client side"});
				TcmbTipoUpdate.Rows.Add(new object[]{"M", "Misto"});
			}
			cmbTipoUpdate.DataSource=TcmbTipoUpdate;
			cmbTipoUpdate.DisplayMember="descrizione";
			cmbTipoUpdate.ValueMember="codicetipo";

			if (TcmbTipoFile==null) {
				TcmbTipoFile=new DataTable();
				TcmbTipoFile.Columns.Add("codicetipo");
				TcmbTipoFile.Columns.Add("descrizione");
				TcmbTipoFile.Rows.Add(new object[]{"", ""});
				TcmbTipoFile.Rows.Add(new object[]{"S", "Script SQL"});
				TcmbTipoFile.Rows.Add(new object[]{"R", "Report"});
				TcmbTipoFile.Rows.Add(new object[]{"X", "Xml"});
				TcmbTipoFile.Rows.Add(new object[]{"A", "Altro"});
			}
			cmbTipoFile.DataSource=TcmbTipoFile;
			cmbTipoFile.DisplayMember="descrizione";
			cmbTipoFile.ValueMember="codicetipo";
		}

		private DataRow GetCurrentGridRow(DataGrid G,string tablename){
			if (tablename==null) return null;
			DataTable T = DS.Tables[tablename];
			DataSet  DSV = (DataSet) G.DataSource;
			if (DSV==null) return null;
			DataTable TV=  DSV.Tables[G.DataMember];
			if (TV==null) return null;		
			if (TV.Rows.Count==0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
			}
			catch {
				DV=null;
			}
			if (DV==null) return null;
			DataRow R = DV.Row;
			HelpForm.SetLastSelected(T, R);
			return HelpForm.FindExternalRow(T, R);
		}

		private void GeneralLeaveDateTextBox(object sender, System.EventArgs e){
			TextBox T = (TextBox)sender;
			if (T.Text=="") return;
			string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			string S = T.Text+hhsep+"0"+ppsep+"0";
			int len = S.Length;
			object O = DBNull.Value;
			while (len>0){
				try {
					O = HelpForm.GetObjectFromString(typeof(DateTime), S, null);
					if ((O!=null)&&(O!=DBNull.Value)) break;
				}
				catch {
				}
				len=len-1;
				S=S.Substring(0, len);
			}
			T.Text= HelpForm.StringValue(O, null);
		}

		private void ShowMsg(string msg) {
			show(msg,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}

		private DialogResult ShowQuestion(string msg) {
			return show(msg,"Domanda",
				MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
		}

		private void Archivia() {
			DS.WriteXml(m_IndexFileName);
			XZip.AddFiles(m_IndexFileZip,m_IndexFileDir,C_FILEINDEX,true,true);
		}

		private void CheckDir(string dir) {
			string fullpath=m_IndexFileDir+dir;
			if (Directory.Exists(fullpath)) return;
			if (XDir.IsReadOnly(m_IndexFileDir)) {
				ShowMsg("Impossibile creare la cartella "+fullpath+". Privilegi mancanti");
				return;
			}
			Directory.CreateDirectory(fullpath);
		}

		#endregion

		#region Metodi Master

		private void ImpostaGridMaster() {
			foreach (DataColumn C in DS.update.Columns) {
				C.Caption="";
			}
			DS.update.Columns["code"].Caption="Codice";
			DS.update.Columns["shortdescritpion"].Caption="Breve descrizione";
			DS.update.Columns["publishingdate"].Caption="Pubblicato";
			DS.update.Columns["flagkind"].Caption="Tipo";
			DS.update.Columns["flagannullato"].Caption="Annullato";
			HelpForm.SetDataGrid(gridMaster, DS.update);
		}

		private void ImpostaValoriControlliMaster(DataRow R) {
			txtCodice.Text=(R==null?"":R["code"].ToString());
			txtDataRilascio.Text=(R==null?"":R["publishingdate"].ToString());
			GeneralLeaveDateTextBox(txtDataRilascio,null);
			txtDescrizioneBreve.Text=(R==null?"":R["shortdescription"].ToString());
			txtDescrizione.Text=(R==null?"":R["description"].ToString());
			HelpForm.SetComboBoxValue(cmbTipoUpdate, R==null ? "" : R["flagkind"]);
			SetCheckBox(chkAnnullato,(R==null?"":R["flagannullato"].ToString()));
			txtVersioneMinima.Text=(R==null?"":R["dbversion"].ToString());
		}

		private void ImpostaControlliMaster() {
			DataRow R=GetCurrentGridRow(gridMaster,"update");
			if (CurrentMasterRow==R) return;
			CurrentMasterRow=R;
			ImpostaValoriControlliMaster(R);
			ImpostaGridDetail();
			ImpostaControlliDetail();
			AbilitaBottoniMaster();
		}

		private void gridMaster_Click(object sender, System.EventArgs e) {
			ImpostaControlliMaster();
		}

		private DataRow CurrentMasterRow {
			get {
				return m_CurrentMasterRow;
			}
			set {
				m_CurrentMasterRow=value;
				HelpForm.SetLastSelected(DS.update,m_CurrentMasterRow);
			}
		}

		private void AbilitaBottoniMaster() {
			DataRow[] rows=DS.update.Select(null,null,DataViewRowState.CurrentRows);
			btnInsertMaster.Enabled=(Stato==eStato.READ);
			btnDeleteMaster.Enabled=((Stato==eStato.READ) && (rows.Length>0));
			btnUpdateMaster.Enabled=((Stato==eStato.INSERT) || (rows.Length>0));
			btnCancelMaster.Enabled=(Stato!=eStato.READ);
			grpDetail.Enabled=((Stato==eStato.READ) && (rows.Length>0));
			AbilitaBottoniDetail();
		}

		private bool IsValidMaster(DataRow R) {
			if (R["code"].ToString()=="") {
				ShowMsg("Il codice è obbligatorio");
				txtCodice.Focus();
				return false;
			}
			if (R["shortdescription"].ToString()=="") {
				ShowMsg("Specificare la descrizione breve");
				txtDescrizioneBreve.Focus();
				return false;
			}
			if (R["description"].ToString()=="") {
				ShowMsg("Specificare la descrizione");
				txtDescrizione.Focus();
				return false;
			}
			if (R["publishingdate"].ToString()=="") {
				ShowMsg("Specificare la data di pubblicazione");
				txtDataRilascio.Focus();
				return false;
			}
			if (R["flagkind"].ToString()=="") {
				ShowMsg("Specificare il tipo di aggiornamento");
				cmbTipoUpdate.Focus();
				return false;
			}
			if (Stato==eStato.INSERT) {
				string filter="code="+QueryCreator.quotedstrvalue(R["code"],false);
				if (DS.update.Select(filter,null,DataViewRowState.CurrentRows).Length>0) {
					ShowMsg("Esiste già una riga con il codice "+R["code"].ToString());
					txtCodice.Focus();
					return false;
				}
			}
			return true;
		}

		private bool CheckOperation() {
			if (IsDetailOperation) {
				ShowMsg("Devi annullare o aggiornare l'operazione sul dettaglio prima");
			}
			return IsDetailOperation;
		}

		private void btnInsertMaster_Click(object sender, System.EventArgs e) {
			if (CheckOperation()) return;
			ImpostaValoriControlliMaster(null);
			txtDataRilascio.Text=DateTime.Now.Date.ToShortDateString();
			Stato=eStato.INSERT;
			AbilitaBottoniMaster();
		}

		private void btnUpdateMaster_Click(object sender, System.EventArgs e) {
			if (CheckOperation()) return;
			DataRow R= null;
			if (Stato==eStato.INSERT) {
				R=DS.update.NewRow();
			}
			else {
				R=CurrentMasterRow;
			}
			R["code"]=txtCodice.Text.Trim();
			CheckDir(txtCodice.Text.Trim());
			R["shortdescription"]=txtDescrizioneBreve.Text;
			R["description"]=txtDescrizione.Text;
			R["publishingdate"]=HelpForm.GetObjectFromString(typeof(DateTime),txtDataRilascio.Text,null);
			R["flagkind"]=cmbTipoUpdate.SelectedValue.ToString();
			R["flagannullato"]=(chkAnnullato.Checked?"S":"N");
			R["dbversion"]=txtVersioneMinima.Text;
			if (!IsValidMaster(R)) return;
			if (Stato==eStato.INSERT) DS.update.Rows.Add(R);
			R.AcceptChanges();
			Stato=eStato.READ;
			modified=true;
			CurrentMasterRow=R;
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
		}

		private void btnDeleteMaster_Click(object sender, System.EventArgs e) {
			if (CheckOperation()) return;
			Stato=eStato.READ;
			if (CurrentMasterRow==null) {
				ShowMsg("Selezionare una riga");
				return;
			}
			DialogResult res=ShowQuestion("Sei sicuro di voler cancellare la riga?");
			if (res!=DialogResult.Yes) return;
			CurrentMasterRow.Delete();
			DS.update.AcceptChanges();
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
			modified=true;
		}

		private void btnCancelMaster_Click(object sender, System.EventArgs e) {
			if (CheckOperation()) return;
			CurrentMasterRow=null;
			Stato=eStato.READ;
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
		}


		#endregion

		#region Metodi Detail

		private void ImpostaGridDetail() {
			foreach (DataColumn C in DS.fileupdate.Columns) {
				C.Caption="";
			}
			DS.fileupdate.Columns["progressivo"].Caption="Progressivo";
			DS.fileupdate.Columns["filename"].Caption="Nome file";
			DS.fileupdate.Columns["filekind"].Caption="Tipo file";
			HelpForm.SetDataGrid(gridDetail, DS.fileupdate);
		}

		private void ImpostaValoriControlliDetail(DataRow R) {
			txtProgressivo.Text=(R==null?"":R["progressivo"].ToString());
			txtNomeFile.Text=(R==null?"":R["filename"].ToString());
			HelpForm.SetComboBoxValue(cmbTipoFile, R==null ? "" : R["filekind"]);
		}

		private void ImpostaControlliDetail() {
			DataRow R=GetCurrentGridRow(gridDetail,"fileupdate");
			if (CurrentDetailRow==R) return;
			CurrentDetailRow=R;
			ImpostaValoriControlliDetail(R);
		}

		private void gridDetail_Click(object sender, System.EventArgs e) {
			ImpostaControlliDetail();
		}

		private DataRow CurrentDetailRow {
			get {
				return m_CurrentDetailRow;
			}
			set {
				m_CurrentDetailRow=value;
				HelpForm.SetLastSelected(DS.fileupdate,m_CurrentDetailRow);
			}
		}

		private void AbilitaBottoniDetail() {
			if (grpDetail.Enabled) {
				DataTable TV=GetDetailTableMemory();
				int nRows=0;
				if (TV!=null) nRows=TV.Select(null,null,DataViewRowState.CurrentRows).Length;
				btnInsertDetail.Enabled=(Stato==eStato.READ);
				btnDeleteDetail.Enabled=((Stato==eStato.READ) && (nRows>0));
				btnUpdateDetail.Enabled=((Stato==eStato.INSERT) || (nRows>0));
				btnCancelDetail.Enabled=(Stato!=eStato.READ);
			}
		}

		private bool IsValidDetail(DataRow R) {
			if (R["filename"].ToString()=="") {
				ShowMsg("Il nome del file è obbligatorio");
				txtNomeFile.Focus();
				return false;
			}
			if (R["filekind"].ToString()=="") {
				ShowMsg("Specificare il tipo di file");
				cmbTipoFile.Focus();
				return false;
			}
			return true;
		}

		private void btnInsertDetail_Click(object sender, System.EventArgs e) {
			IsDetailOperation=true;
			ImpostaValoriControlliDetail(null);
			Stato=eStato.INSERT;
			AbilitaBottoniDetail();
		}

		private void btnUpdateDetail_Click(object sender, System.EventArgs e) {
			DataRow R=null;
			DataRow Rparent=CurrentMasterRow;
			if (Stato==eStato.INSERT) {
				R=DS.fileupdate.NewRow();
				DataTable TV=GetDetailTableMemory();
				int max=0;
				if (TV!=null) {
					DataRow[] rows=TV.Select(null,"progressivo DESC",DataViewRowState.CurrentRows);
					if (rows.Length>0) max=(int)rows[0]["progressivo"];
				}
				R["progressivo"]=max+1;
			}
			else {
				R=CurrentDetailRow;
				R["progressivo"]=Convert.ToInt32(txtProgressivo.Text);
			}
			R["code"]=Rparent["code"];
			R["filename"]=txtNomeFile.Text;
			R["filekind"]=cmbTipoFile.SelectedValue.ToString();
			if (!IsValidDetail(R)) return;
			if (Stato==eStato.INSERT) DS.fileupdate.Rows.Add(R);
			R.AcceptChanges();
			Stato=eStato.READ;
			modified=true;
			CurrentDetailRow=R;
			ImpostaGridDetail();
			ImpostaValoriControlliDetail(R);
			AbilitaBottoniDetail();
			IsDetailOperation=false;
		}

		private void btnDeleteDetail_Click(object sender, System.EventArgs e) {
			Stato=eStato.READ;
			if (CurrentDetailRow==null) {
				ShowMsg("Selezionare una riga");
				return;
			}
			DialogResult res=ShowQuestion("Sei sicuro di voler cancellare la riga?");
			if (res!=DialogResult.Yes) return;
			CurrentDetailRow.Delete();
			DS.fileupdate.AcceptChanges();
			ImpostaGridDetail();
			ImpostaControlliDetail();
			AbilitaBottoniDetail();
			modified=true;
			IsDetailOperation=false;
		}

		private void btnCancelDetail_Click(object sender, System.EventArgs e) {
			IsDetailOperation=false;
			CurrentDetailRow=null;
			Stato=eStato.READ;
			AbilitaBottoniDetail();
			ImpostaControlliDetail();
		}

		private DataTable GetDetailTableMemory() {
			DataSet DSV = (DataSet) gridDetail.DataSource;
			if (DSV==null) return null;
			return DSV.Tables[gridDetail.DataMember];
		}


		#endregion

		#region Metodi Form

		private void btnSalva_Click(object sender, System.EventArgs e) {
			if (modified) {
				DS.AcceptChanges();
				Archivia();
			}
			Stato=eStato.READ;
			modified=false;
		}

		private bool Chiudi() {
			if (modified) {
				DialogResult res=show("Ci sono modifche, vuoi salvare?","Attenzione",
					MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if (res==DialogResult.Cancel) return true;
				if (res==DialogResult.Yes) btnSalva_Click(null,null);
			}
			return false;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void frmToolOnDemand_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel=Chiudi();
		}


		#endregion

	}
}
