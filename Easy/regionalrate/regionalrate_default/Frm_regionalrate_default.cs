
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
using funzioni_configurazione;
using metadatalibrary;

namespace regionalrate_default//aliquotaregionalelista//
{
	/// <summary>
	/// Summary description for frmaliquotaregionalelista.
	/// </summary>
	public class Frm_regionalrate_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox cmbDataInizioStruttura;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTipoRitenuta;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpRegione;
		private System.Windows.Forms.TextBox txtGeoRegione;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		DataTable TipoRitenutaTable;
		string filterritenuta;
		string filterdatainiziostruttura;
		int lastidregione;
		private System.Windows.Forms.ComboBox cmbScaglione;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox2;
		string lastnomeregione;

		public Frm_regionalrate_default()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_regionalrate_default));
			this.DS = new regionalrate_default.vistaForm();
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.cmbDataInizioStruttura = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
			this.grpRegione = new System.Windows.Forms.GroupBox();
			this.txtGeoRegione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbScaglione = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.MetaDataDetail = new System.Windows.Forms.Panel();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.grpRegione.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.MetaDataDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
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
																							   this.Salva});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
			this.MetaDataToolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(3, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(682, 56);
			this.MetaDataToolBar.TabIndex = 52;
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
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 192);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(672, 112);
			this.dataGrid1.TabIndex = 56;
			this.dataGrid1.Tag = "regionalrate.default";
			// 
			// cmbDataInizioStruttura
			// 
			this.cmbDataInizioStruttura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDataInizioStruttura.Location = new System.Drawing.Point(144, 160);
			this.cmbDataInizioStruttura.Name = "cmbDataInizioStruttura";
			this.cmbDataInizioStruttura.Size = new System.Drawing.Size(152, 21);
			this.cmbDataInizioStruttura.TabIndex = 55;
			this.cmbDataInizioStruttura.Tag = "";
			this.cmbDataInizioStruttura.SelectedIndexChanged += new System.EventHandler(this.cmbDataInizioStruttura_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 24);
			this.label1.TabIndex = 57;
			this.label1.Text = "Tipo ritenuta:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbTipoRitenuta
			// 
			this.cmbTipoRitenuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoRitenuta.Location = new System.Drawing.Point(144, 72);
			this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
			this.cmbTipoRitenuta.Size = new System.Drawing.Size(272, 21);
			this.cmbTipoRitenuta.TabIndex = 53;
			this.cmbTipoRitenuta.Tag = "";
			this.cmbTipoRitenuta.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRitenuta_SelectedIndexChanged);
			// 
			// grpRegione
			// 
			this.grpRegione.Controls.Add(this.txtGeoRegione);
			this.grpRegione.Location = new System.Drawing.Point(144, 104);
			this.grpRegione.Name = "grpRegione";
			this.grpRegione.Size = new System.Drawing.Size(344, 48);
			this.grpRegione.TabIndex = 54;
			this.grpRegione.TabStop = false;
			this.grpRegione.Tag = "AutoChoose.txtGeoRegione.default";
			// 
			// txtGeoRegione
			// 
			this.txtGeoRegione.Location = new System.Drawing.Point(8, 16);
			this.txtGeoRegione.Name = "txtGeoRegione";
			this.txtGeoRegione.Size = new System.Drawing.Size(328, 20);
			this.txtGeoRegione.TabIndex = 1;
			this.txtGeoRegione.Tag = "geo_region_view.title?regionalrateview.region";
			this.txtGeoRegione.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 58;
			this.label2.Text = "Regione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 23);
			this.label3.TabIndex = 59;
			this.label3.Text = "Data Inizio Struttura:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbScaglione
			// 
			this.cmbScaglione.DataSource = this.DS.regionalratebracket;
			this.cmbScaglione.DisplayMember = "!descrizione";
			this.cmbScaglione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbScaglione.ItemHeight = 13;
			this.cmbScaglione.Location = new System.Drawing.Point(176, 16);
			this.cmbScaglione.Name = "cmbScaglione";
			this.cmbScaglione.Size = new System.Drawing.Size(344, 21);
			this.cmbScaglione.TabIndex = 1;
			this.cmbScaglione.Tag = "";
			this.cmbScaglione.ValueMember = "numeroscaglione";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(104, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 22);
			this.label10.TabIndex = 29;
			this.label10.Text = "Scaglione:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(232, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 22);
			this.label6.TabIndex = 17;
			this.label6.Text = "Data inizio aliquota:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(336, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(96, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "regionalrate.ratestart";
			this.textBox1.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButton2);
			this.groupBox3.Controls.Add(this.radioButton1);
			this.groupBox3.Location = new System.Drawing.Point(544, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(120, 64);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tipo Applicazione";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Tag = "regionalrate.enforcement:F";
			this.radioButton2.Text = "Fascia Fissa";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Tag = "regionalrate.enforcement:P";
			this.radioButton1.Text = "Progressiva";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(504, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 22);
			this.label7.TabIndex = 28;
			this.label7.Text = "Aliquota:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(568, 80);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(96, 20);
			this.textBox7.TabIndex = 1;
			this.textBox7.Tag = "regionalrate.rate.fixed.4..%.100";
			this.textBox7.Text = "";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.cmbScaglione);
			this.MetaDataDetail.Controls.Add(this.label10);
			this.MetaDataDetail.Controls.Add(this.label6);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.groupBox3);
			this.MetaDataDetail.Controls.Add(this.label7);
			this.MetaDataDetail.Controls.Add(this.textBox7);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 312);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(672, 112);
			this.MetaDataDetail.TabIndex = 60;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(112, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 31;
			this.textBox2.Tag = "regionalrate.publishmentdate";
			this.textBox2.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 24);
			this.label4.TabIndex = 30;
			this.label4.Text = "Data Pubblicazione";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_regionalrate_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 430);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.cmbDataInizioStruttura);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbTipoRitenuta);
			this.Controls.Add(this.grpRegione);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "Frm_regionalrate_default";
			this.Text = "frmaliquotaregionalelista";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.grpRegione.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.MetaDataDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			GetData.SetSorting(DS.regionalrate,"ratestart, nbracket");
			GetData.LockRead(DS.regionalratebracket);
			string filtraRitenuteCombo = "(taxkind='F')AND(geoappliance='R')AND(active='S')";
			//riempie il combo tiporitenuta
			object O = "";
			cmbTipoRitenuta.Items.Add(O);
			TipoRitenutaTable=Meta.Conn.RUN_SELECT("tax","*","description",filtraRitenuteCombo, null, true);
			foreach (DataRow R in TipoRitenutaTable.Rows)
				cmbTipoRitenuta.Items.Add(R["description"]);

			bool IsAdmin = (Meta.GetSys("manage_prestazioni")!=null)
				? Meta.GetSys("manage_prestazioni").ToString()=="S"
				: false;
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;			
		}

		void DisableToolbar()
		{
			Meta.CanInsertCopy=false;
			Meta.FreshToolBar();
		}

		void EnableToolbar()
		{
			Meta.CanInsertCopy=true;
			Meta.FreshToolBar();
		}

		private void cmbTipoRitenuta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (!Meta.DrawStateIsDone) return;
			DS.regionalrate.Clear();
			DS.regionalratebracket.Clear();
			cmbDataInizioStruttura.Items.Clear();
			if (!Meta.IsEmpty) 
			{
				Meta.FreshForm();
				Meta.DoMainCommand("mainsetsearch");
			}
			if (txtGeoRegione.Text != "")
			{	
				if (cmbTipoRitenuta.SelectedItem.ToString()=="") return;
				DataRow [] CodRiten = TipoRitenutaTable.Select("description="+
					QueryCreator.quotedstrvalue(cmbTipoRitenuta.SelectedItem, false));
				if (CodRiten.Length != 1) return;
				filterritenuta = "(taxcode="+
					QueryCreator.quotedstrvalue(CodRiten[0]["taxcode"], true)+
					") AND (idregion=" + QueryCreator.quotedstrvalue(lastidregione,true) + ")";
				MetaData.SetDefault(DS.regionalrate, "taxcode", CodRiten[0]["taxcode"]);
				PopolaComboDataInizioStruttura(filterritenuta);
				if (!Meta.IsEmpty) DisableToolbar();
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (R==null) return;

			if (T.TableName == "regionalrate")
			{
				if (Meta.EditMode)
				{
					EnableToolbar();
					cmbScaglione.SelectedValue=R["nbracket"];
				}
			}

			if (T.TableName == "geo_region_view")
			{
				lastidregione = Convert.ToInt32(R["idregion"]);
				lastnomeregione = R["title"].ToString();
				DS.regionalrate.Clear();
				DS.regionalratebracket.Clear();
				cmbDataInizioStruttura.Items.Clear();
				if (!Meta.IsEmpty) Meta.FreshForm();
				if (cmbTipoRitenuta.SelectedItem != null)
				{
					if (cmbTipoRitenuta.SelectedItem.ToString()=="") return;
					DataRow [] CodRiten = TipoRitenutaTable.Select("description="+
						QueryCreator.quotedstrvalue(cmbTipoRitenuta.SelectedItem, false));
					if (CodRiten.Length != 1) return;
					filterritenuta = "(taxcode="+
						QueryCreator.quotedstrvalue(CodRiten[0]["taxcode"], true)+
						") AND (idregion=" + QueryCreator.quotedstrvalue(lastidregione,true) + ")";
					MetaData.SetDefault(DS.regionalrate, "taxcode", CodRiten[0]["taxcode"]);
					PopolaComboDataInizioStruttura(filterritenuta);
					if (!Meta.IsEmpty) DisableToolbar();
				}
			}
		}

		void CheckFormChanges()
		{
			Meta.GetFormData(true);
			if (!Meta.WarnUnsaved())
				MetaDataDetail.Focus();
		}

		void PopolaComboDataInizioStruttura(string filter)
		{
			//riempie il combo datainiziostruttura
			object O = "";
			cmbDataInizioStruttura.Items.Add(O);
			DataTable DataInizioStrutturaTable=Meta.Conn.RUN_SELECT("regionalratevalidity","validitystart",null,filter, null, true);
			foreach (DataRow R in DataInizioStrutturaTable.Rows)
				cmbDataInizioStruttura.Items.Add(Convert.ToDateTime(R["validitystart"]).ToShortDateString());
		}

		public void MetaData_AfterClear()
		{
			cmbScaglione.Enabled=false;	
			cmbTipoRitenuta.Enabled=true;
			txtGeoRegione.Enabled=true;
			cmbDataInizioStruttura.Enabled=true;
			if (!Meta.DrawStateIsDone) return;
			EnableToolbar();
		}

		public void MetaData_AfterFill()
		{
			if (Meta.InsertMode)
			{
				cmbScaglione.Enabled=true;
				cmbTipoRitenuta.Enabled=false;
				txtGeoRegione.Enabled=false;
				cmbDataInizioStruttura.Enabled=false;
			}
			if (Meta.EditMode)
			{
				cmbScaglione.Enabled=false;
				cmbTipoRitenuta.Enabled=true;
				txtGeoRegione.Enabled=true;
				cmbDataInizioStruttura.Enabled=true;
			}
		}

		public void MetaData_AfterGetFormData()
		{
			if (Meta.EditMode) return;
			DataRow CurrentRow = HelpForm.GetLastSelected(DS.regionalrate);
			int CurrentScaglione = Convert.ToInt16(cmbScaglione.SelectedValue);
			string filter = "(ratestart="+QueryCreator.quotedstrvalue(
				CurrentRow["ratestart"],false)+
				") AND (nbracket = "+QueryCreator.quotedstrvalue(
				CurrentScaglione,false)+")";			
			// verifica se lo scaglione è già stato inserito
			// sulla datainizioaliquota corrente
			DataRow [] res = DS.regionalrate.Select(filter);
			if (res.Length==0) {
				CurrentRow["nbracket"]=cmbScaglione.SelectedValue;
			}
			else {
				CurrentRow["nbracket"]=0;
			}
		}

		private void cmbDataInizioStruttura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Meta.DoMainCommand("mainsetsearch");
			if (!Meta.IsEmpty && DS.HasChanges())
			{
				MetaDataDetail.Focus();
				return;
			}
			if (cmbDataInizioStruttura.SelectedItem.ToString()=="") 
			{
				cmbDataInizioStruttura.Items.Clear();
				cmbTipoRitenuta.SelectedItem="";
				txtGeoRegione.Text = "";
				Meta.FreshForm();
				DisableToolbar();
				return;				
			}

			filterdatainiziostruttura = "(validitystart="+
				QueryCreator.quotedstrvalue(cmbDataInizioStruttura.SelectedItem,true)+
				")";
			MetaData.SetDefault(DS.regionalrate, "validitystart", Convert.ToDateTime(cmbDataInizioStruttura.SelectedItem));
			DS.regionalratebracket.Clear();
			string filter = GetData.MergeFilters(filterritenuta, filterdatainiziostruttura);
			Meta.DoMainCommand("maindosearch.default."+filter);
			MetaData.SetDefault(DS.regionalrate, "idregion", lastidregione);
			PopolaComboScaglione(filter);
			EnableToolbar();

		}

		void PopolaComboScaglione(string filter)
		{
			DS.regionalratebracket.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.regionalratebracket, "nbracket",
				filter, null, true);
			foreach (DataRow R in DS.regionalratebracket.Rows)
			{
				if (R["maxamount"] != DBNull.Value)
				{
					R["!descrizione"] = "Scaglione "+R["nbracket"].ToString()+
						": da "+CfgFn.GetNoNullDecimal(R["minamount"]).ToString("c")+
						" a "+CfgFn.GetNoNullDecimal(R["maxamount"]).ToString("c")+".";
				}
				else
				{
					R["!descrizione"] = "Scaglione "+R["nbracket"].ToString()+
						": da "+CfgFn.GetNoNullDecimal(R["minamount"]).ToString("c")+".";
				}
			}

			DS.regionalratebracket.AcceptChanges();
		}

		private void cmbTipoRitenuta_Enter(object sender, System.EventArgs e)
		{
			CheckFormChanges();
		}
	}
}
