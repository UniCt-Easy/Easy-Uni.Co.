
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
using metadatalibrary;

namespace registryclass_anagrafica//cdtipologiaclassificazione_Anagrafica//
{
	/// <summary>
	/// Summary description for frmcdtipologiaclassificazione_Anagrafica.
	/// </summary>
	public class Frm_registryclass_anagrafica : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnChiudi;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.CheckBox chkFlagPersonaFisica;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.CheckBox obbl_flagmatricolaext;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.CheckBox flagCognomeAcq;
		private System.Windows.Forms.CheckBox obbl_flagCognomeAcq;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.CheckBox flagtitolo;
		private System.Windows.Forms.CheckBox obbl_flagtitolo;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox flagPI;
		private System.Windows.Forms.CheckBox obbl_flagPI;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox flagCFEstero;
		private System.Windows.Forms.CheckBox obbl_flagCFEstero;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox flagCF;
		private System.Windows.Forms.CheckBox obbl_flagCF;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox17;
		private System.Windows.Forms.CheckBox obbl_flagstatocivile;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.CheckBox flagcodicebadge;
		private System.Windows.Forms.CheckBox obbl_flagcodicebadge;
		private System.Windows.Forms.GroupBox grpDenominazione;
		private System.Windows.Forms.CheckBox flagdenominazione;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.ComponentModel.IContainer components;

		public Frm_registryclass_anagrafica()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.registryclass.Columns["flagcfbutton"],true);
			HelpForm.SetDenyNull(DS.registryclass.Columns["flaginfofromcfbutton"],true);
			HelpForm.SetDenyNull(DS.registryclass.Columns["flaghuman"],true);
			HelpForm.SetDenyNull(DS.registryclass.Columns["active"],true);
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
		public void MetaData_AfterLink(){
			MetaData Meta = MetaData.GetMetaData(this);
			bool IsAdmin=false;

			if (Meta.GetSys("FlagMenuAdmin")!=null) 
				IsAdmin=(Meta.GetSys("FlagMenuAdmin").ToString()=="S");
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_registryclass_anagrafica));
			this.DS = new vistaForm();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.chkFlagPersonaFisica = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.obbl_flagmatricolaext = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.flagCognomeAcq = new System.Windows.Forms.CheckBox();
			this.obbl_flagCognomeAcq = new System.Windows.Forms.CheckBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.flagtitolo = new System.Windows.Forms.CheckBox();
			this.obbl_flagtitolo = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.flagPI = new System.Windows.Forms.CheckBox();
			this.obbl_flagPI = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.flagCFEstero = new System.Windows.Forms.CheckBox();
			this.obbl_flagCFEstero = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.flagCF = new System.Windows.Forms.CheckBox();
			this.obbl_flagCF = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox17 = new System.Windows.Forms.CheckBox();
			this.obbl_flagstatocivile = new System.Windows.Forms.CheckBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.flagcodicebadge = new System.Windows.Forms.CheckBox();
			this.obbl_flagcodicebadge = new System.Windows.Forms.CheckBox();
			this.grpDenominazione = new System.Windows.Forms.GroupBox();
			this.flagdenominazione = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.aggiorna = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.grpDenominazione.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 56);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(654, 208);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.Tag = "registryclass.default";
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(584, 595);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 77;
			this.btnChiudi.Text = "Chiudi";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.chkFlagPersonaFisica);
			this.MetaDataDetail.Controls.Add(this.groupBox9);
			this.MetaDataDetail.Controls.Add(this.groupBox12);
			this.MetaDataDetail.Controls.Add(this.groupBox11);
			this.MetaDataDetail.Controls.Add(this.groupBox10);
			this.MetaDataDetail.Controls.Add(this.groupBox8);
			this.MetaDataDetail.Controls.Add(this.groupBox7);
			this.MetaDataDetail.Controls.Add(this.groupBox6);
			this.MetaDataDetail.Controls.Add(this.groupBox5);
			this.MetaDataDetail.Controls.Add(this.groupBox4);
			this.MetaDataDetail.Controls.Add(this.groupBox3);
			this.MetaDataDetail.Controls.Add(this.groupBox2);
			this.MetaDataDetail.Controls.Add(this.groupBox13);
			this.MetaDataDetail.Controls.Add(this.grpDenominazione);
			this.MetaDataDetail.Controls.Add(this.checkBox1);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.label2);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 272);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(654, 312);
			this.MetaDataDetail.TabIndex = 2;
			this.MetaDataDetail.TabStop = false;
			// 
			// chkFlagPersonaFisica
			// 
			this.chkFlagPersonaFisica.Location = new System.Drawing.Point(452, 216);
			this.chkFlagPersonaFisica.Name = "chkFlagPersonaFisica";
			this.chkFlagPersonaFisica.TabIndex = 64;
			this.chkFlagPersonaFisica.Tag = "registryclass.flaghuman:S:N";
			this.chkFlagPersonaFisica.Text = "Persona fisica";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.checkBox6);
			this.groupBox9.Location = new System.Drawing.Point(444, 160);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(192, 40);
			this.groupBox9.TabIndex = 61;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Bottone \"Comune, Data da C.F.\"";
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(8, 16);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(72, 16);
			this.checkBox6.TabIndex = 73;
			this.checkBox6.Tag = "registryclass.flaginfofromcfbutton:S:N";
			this.checkBox6.Text = "Visibile";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.checkBox8);
			this.groupBox12.Location = new System.Drawing.Point(228, 160);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(192, 40);
			this.groupBox12.TabIndex = 60;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Bottone \"Calcola Codice Fiscale\"";
			// 
			// checkBox8
			// 
			this.checkBox8.Location = new System.Drawing.Point(8, 16);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(72, 16);
			this.checkBox8.TabIndex = 78;
			this.checkBox8.Tag = "registryclass.flagcfbutton:S:N";
			this.checkBox8.Text = "Visibile";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.checkBox4);
			this.groupBox11.Controls.Add(this.checkBox5);
			this.groupBox11.Location = new System.Drawing.Point(444, 112);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(192, 40);
			this.groupBox11.TabIndex = 58;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Campo \"Domicilio fiscale\"";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(8, 16);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(72, 16);
			this.checkBox4.TabIndex = 73;
			this.checkBox4.Tag = "registryclass.flagfiscalresidence:S:N";
			this.checkBox4.Text = "Visibile";
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(88, 16);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(88, 16);
			this.checkBox5.TabIndex = 87;
			this.checkBox5.Tag = "registryclass.flagfiscalresidence_forced:S:N";
			this.checkBox5.Text = "Obbligatorio";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.checkBox2);
			this.groupBox10.Controls.Add(this.checkBox3);
			this.groupBox10.Location = new System.Drawing.Point(444, 64);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(192, 40);
			this.groupBox10.TabIndex = 55;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Campo \"Residenza\"";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(8, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(72, 16);
			this.checkBox2.TabIndex = 73;
			this.checkBox2.Tag = "registryclass.flagresidence:S:N";
			this.checkBox2.Text = "Visibile";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(88, 16);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(88, 16);
			this.checkBox3.TabIndex = 87;
			this.checkBox3.Tag = "registryclass.flagresidence_forced:S:N";
			this.checkBox3.Text = "Obbligatorio";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.checkBox9);
			this.groupBox8.Controls.Add(this.obbl_flagmatricolaext);
			this.groupBox8.Location = new System.Drawing.Point(228, 256);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(192, 40);
			this.groupBox8.TabIndex = 66;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Campo \"Matricola ext.\"";
			// 
			// checkBox9
			// 
			this.checkBox9.Location = new System.Drawing.Point(8, 16);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(72, 16);
			this.checkBox9.TabIndex = 74;
			this.checkBox9.Tag = "registryclass.flagextmatricula:S:N";
			this.checkBox9.Text = "Visibile";
			// 
			// obbl_flagmatricolaext
			// 
			this.obbl_flagmatricolaext.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagmatricolaext.Name = "obbl_flagmatricolaext";
			this.obbl_flagmatricolaext.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagmatricolaext.TabIndex = 72;
			this.obbl_flagmatricolaext.Tag = "registryclass.flagextmatricula_forced:S:N";
			this.obbl_flagmatricolaext.Text = "Obbligatorio";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.flagCognomeAcq);
			this.groupBox7.Controls.Add(this.obbl_flagCognomeAcq);
			this.groupBox7.Location = new System.Drawing.Point(228, 112);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(192, 40);
			this.groupBox7.TabIndex = 57;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Campo \"Cognome acquisito\"";
			// 
			// flagCognomeAcq
			// 
			this.flagCognomeAcq.Location = new System.Drawing.Point(8, 16);
			this.flagCognomeAcq.Name = "flagCognomeAcq";
			this.flagCognomeAcq.Size = new System.Drawing.Size(72, 16);
			this.flagCognomeAcq.TabIndex = 78;
			this.flagCognomeAcq.Tag = "registryclass.flagmaritalsurname:S:N";
			this.flagCognomeAcq.Text = "Visibile";
			// 
			// obbl_flagCognomeAcq
			// 
			this.obbl_flagCognomeAcq.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagCognomeAcq.Name = "obbl_flagCognomeAcq";
			this.obbl_flagCognomeAcq.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagCognomeAcq.TabIndex = 68;
			this.obbl_flagCognomeAcq.Tag = "registryclass.flagmaritalsurname_forced:S:N";
			this.obbl_flagCognomeAcq.Text = "Obbligatorio";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.flagtitolo);
			this.groupBox6.Controls.Add(this.obbl_flagtitolo);
			this.groupBox6.Location = new System.Drawing.Point(12, 64);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(192, 40);
			this.groupBox6.TabIndex = 53;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Campo \"Titolo\"";
			// 
			// flagtitolo
			// 
			this.flagtitolo.Location = new System.Drawing.Point(8, 16);
			this.flagtitolo.Name = "flagtitolo";
			this.flagtitolo.Size = new System.Drawing.Size(72, 16);
			this.flagtitolo.TabIndex = 79;
			this.flagtitolo.Tag = "registryclass.flagqualification:S:N";
			this.flagtitolo.Text = "Visibile";
			// 
			// obbl_flagtitolo
			// 
			this.obbl_flagtitolo.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagtitolo.Name = "obbl_flagtitolo";
			this.obbl_flagtitolo.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagtitolo.TabIndex = 75;
			this.obbl_flagtitolo.Tag = "registryclass.flagqualification_forced:S:N";
			this.obbl_flagtitolo.Text = "Obbligatorio";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.flagPI);
			this.groupBox5.Controls.Add(this.obbl_flagPI);
			this.groupBox5.Location = new System.Drawing.Point(12, 208);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(192, 40);
			this.groupBox5.TabIndex = 62;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Campo \"Partita IVA\"";
			// 
			// flagPI
			// 
			this.flagPI.Location = new System.Drawing.Point(8, 16);
			this.flagPI.Name = "flagPI";
			this.flagPI.Size = new System.Drawing.Size(72, 16);
			this.flagPI.TabIndex = 84;
			this.flagPI.Tag = "registryclass.flagp_iva:S:N";
			this.flagPI.Text = "Visibile";
			// 
			// obbl_flagPI
			// 
			this.obbl_flagPI.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagPI.Name = "obbl_flagPI";
			this.obbl_flagPI.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagPI.TabIndex = 76;
			this.obbl_flagPI.Tag = "registryclass.flagp_iva_forced:S:N";
			this.obbl_flagPI.Text = "Obbligatorio";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.flagCFEstero);
			this.groupBox4.Controls.Add(this.obbl_flagCFEstero);
			this.groupBox4.Location = new System.Drawing.Point(228, 208);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(192, 40);
			this.groupBox4.TabIndex = 63;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Campo \"Codice fiscale estero\"";
			// 
			// flagCFEstero
			// 
			this.flagCFEstero.Location = new System.Drawing.Point(8, 16);
			this.flagCFEstero.Name = "flagCFEstero";
			this.flagCFEstero.Size = new System.Drawing.Size(72, 16);
			this.flagCFEstero.TabIndex = 80;
			this.flagCFEstero.Tag = "registryclass.flagforeigncf:S:N";
			this.flagCFEstero.Text = "Visibile";
			// 
			// obbl_flagCFEstero
			// 
			this.obbl_flagCFEstero.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagCFEstero.Name = "obbl_flagCFEstero";
			this.obbl_flagCFEstero.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagCFEstero.TabIndex = 69;
			this.obbl_flagCFEstero.Tag = "registryclass.flagforeigncf_forced:S:N";
			this.obbl_flagCFEstero.Text = "Obbligatorio";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.flagCF);
			this.groupBox3.Controls.Add(this.obbl_flagCF);
			this.groupBox3.Location = new System.Drawing.Point(12, 160);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 40);
			this.groupBox3.TabIndex = 59;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Campo \"Codice fiscale\"";
			// 
			// flagCF
			// 
			this.flagCF.Location = new System.Drawing.Point(8, 16);
			this.flagCF.Name = "flagCF";
			this.flagCF.Size = new System.Drawing.Size(72, 16);
			this.flagCF.TabIndex = 85;
			this.flagCF.Tag = "registryclass.flagcf:S:N";
			this.flagCF.Text = "Visibile";
			// 
			// obbl_flagCF
			// 
			this.obbl_flagCF.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagCF.Name = "obbl_flagCF";
			this.obbl_flagCF.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagCF.TabIndex = 77;
			this.obbl_flagCF.Tag = "registryclass.flagcf_forced:S:N";
			this.obbl_flagCF.Text = "Obbligatorio";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox17);
			this.groupBox2.Controls.Add(this.obbl_flagstatocivile);
			this.groupBox2.Location = new System.Drawing.Point(228, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 40);
			this.groupBox2.TabIndex = 54;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Campo \"Stato civile\"";
			// 
			// checkBox17
			// 
			this.checkBox17.Location = new System.Drawing.Point(8, 16);
			this.checkBox17.Name = "checkBox17";
			this.checkBox17.Size = new System.Drawing.Size(72, 16);
			this.checkBox17.TabIndex = 82;
			this.checkBox17.Tag = "registryclass.flagmaritalstatus:S:N";
			this.checkBox17.Text = "Visibile";
			// 
			// obbl_flagstatocivile
			// 
			this.obbl_flagstatocivile.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagstatocivile.Name = "obbl_flagstatocivile";
			this.obbl_flagstatocivile.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagstatocivile.TabIndex = 70;
			this.obbl_flagstatocivile.Tag = "registryclass.flagmaritalstatus_forced:S:N";
			this.obbl_flagstatocivile.Text = "Obbligatorio";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.flagcodicebadge);
			this.groupBox13.Controls.Add(this.obbl_flagcodicebadge);
			this.groupBox13.Location = new System.Drawing.Point(12, 256);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(192, 40);
			this.groupBox13.TabIndex = 65;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Campo \"Codice badge\"";
			// 
			// flagcodicebadge
			// 
			this.flagcodicebadge.Location = new System.Drawing.Point(8, 16);
			this.flagcodicebadge.Name = "flagcodicebadge";
			this.flagcodicebadge.Size = new System.Drawing.Size(72, 16);
			this.flagcodicebadge.TabIndex = 83;
			this.flagcodicebadge.Tag = "registryclass.flagbadgecode:S:N";
			this.flagcodicebadge.Text = "Visibile";
			// 
			// obbl_flagcodicebadge
			// 
			this.obbl_flagcodicebadge.Location = new System.Drawing.Point(88, 16);
			this.obbl_flagcodicebadge.Name = "obbl_flagcodicebadge";
			this.obbl_flagcodicebadge.Size = new System.Drawing.Size(88, 16);
			this.obbl_flagcodicebadge.TabIndex = 71;
			this.obbl_flagcodicebadge.Tag = "registryclass.flagbadgecode_forced:S:N";
			this.obbl_flagcodicebadge.Text = "Obbligatorio";
			// 
			// grpDenominazione
			// 
			this.grpDenominazione.Controls.Add(this.flagdenominazione);
			this.grpDenominazione.Location = new System.Drawing.Point(12, 112);
			this.grpDenominazione.Name = "grpDenominazione";
			this.grpDenominazione.Size = new System.Drawing.Size(192, 40);
			this.grpDenominazione.TabIndex = 56;
			this.grpDenominazione.TabStop = false;
			this.grpDenominazione.Text = "Campo \"Denominazione\"";
			// 
			// flagdenominazione
			// 
			this.flagdenominazione.Location = new System.Drawing.Point(8, 16);
			this.flagdenominazione.Name = "flagdenominazione";
			this.flagdenominazione.Size = new System.Drawing.Size(176, 16);
			this.flagdenominazione.TabIndex = 86;
			this.flagdenominazione.Tag = "registryclass.flagtitle:S:N";
			this.flagdenominazione.Text = "Diverso da \'cognome+nome\'";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(580, 32);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(56, 16);
			this.checkBox1.TabIndex = 52;
			this.checkBox1.Tag = "registryclass.active:S:N";
			this.checkBox1.Text = "Attivo";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 20);
			this.textBox1.TabIndex = 50;
			this.textBox1.Tag = "registryclass.idregistryclass";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(116, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 68;
			this.label2.Text = "Descrizione";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(116, 32);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(448, 20);
			this.textBox2.TabIndex = 51;
			this.textBox2.Tag = "registryclass.description";
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 67;
			this.label1.Text = "Codice";
			// 
			// MetaDataToolBar
			// 
			this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							   this.seleziona,
																							   this.impostaricerca,
																							   this.effettuaricerca,
																							   this.modifica,
																							   this.inserisci,
																							   this.inseriscicopia,
																							   this.elimina,
																							   this.Salva,
																							   this.aggiorna});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(672, 106);
			this.MetaDataToolBar.TabIndex = 78;
			this.MetaDataToolBar.Tag = "";
			// 
			// seleziona
			// 
			this.seleziona.ImageIndex = 1;
			this.seleziona.Tag = "mainselect";
			this.seleziona.Text = "Seleziona";
			this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageIndex = 10;
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta Ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageIndex = 12;
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua Ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// modifica
			// 
			this.modifica.ImageIndex = 6;
			this.modifica.Tag = "mainedit";
			this.modifica.Text = "Modifica";
			this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
			// 
			// inserisci
			// 
			this.inserisci.ImageIndex = 0;
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageIndex = 9;
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
			// 
			// elimina
			// 
			this.elimina.ImageIndex = 3;
			this.elimina.Tag = "maindelete";
			this.elimina.Text = "Elimina";
			this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
			// 
			// Salva
			// 
			this.Salva.ImageIndex = 2;
			this.Salva.Tag = "mainsave";
			this.Salva.Text = "Salva";
			this.Salva.ToolTipText = "Salva le modifiche effettuate";
			// 
			// aggiorna
			// 
			this.aggiorna.ImageIndex = 13;
			this.aggiorna.Tag = "mainrefresh";
			this.aggiorna.Text = "Aggiorna";
			// 
			// frmcdtipologiaclassificazione_Anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 632);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnChiudi);
			this.Name = "frmcdtipologiaclassificazione_Anagrafica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmcdtipologiaclassificazione_Anagrafica";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.grpDenominazione.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
