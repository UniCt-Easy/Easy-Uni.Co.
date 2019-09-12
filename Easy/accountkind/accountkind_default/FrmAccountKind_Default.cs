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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace accountkind_default
{
	/// <summary>
	/// Summary description for FrmAccountKind_Default.
	/// </summary>
	public class FrmAccountKind_Default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		public accountkind_default.vistaForm DS;
		private System.Windows.Forms.CheckBox checkBox1;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton avere1;
		private System.Windows.Forms.RadioButton dare1;
		private System.Windows.Forms.RadioButton avere2;
		private System.Windows.Forms.RadioButton dare2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListBox listBoxB;
		private System.Windows.Forms.ListBox listBoxA;
		MetaData Meta;

		public FrmAccountKind_Default()
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

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			HelpForm.SetDenyNull(DS.accountkind.Columns["active"],true);
			GetData.CacheTable(DS.epcontext);
		}

		bool clearing=false;
		public void MetaData_AfterClear(){
			clearing=true;
			dare1.Checked=false;
			dare2.Checked=false;
			avere1.Checked=false;
			avere2.Checked=false;
			clearing=false;
		}

		public void MetaData_AfterActivation(){
			DataRow []Op = DS.epcontext.Select(null,"title asc");
			listBoxA.Items.Clear();
			listBoxB.Items.Clear();
			foreach(DataRow R in Op){
				if (R["kind"].ToString().ToUpper()=="A"){
					listBoxA.Items.Add(R["title"]);
			}
			else {
					listBoxB.Items.Add(R["title"]);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmAccountKind_Default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.seleziona = new System.Windows.Forms.ToolBarButton();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.modifica = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBoxB = new System.Windows.Forms.ListBox();
			this.avere2 = new System.Windows.Forms.RadioButton();
			this.dare2 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBoxA = new System.Windows.Forms.ListBox();
			this.avere1 = new System.Windows.Forms.RadioButton();
			this.dare1 = new System.Windows.Forms.RadioButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new accountkind_default.vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(32, 32);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
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
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(32, 32);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(664, 110);
			this.MetaDataToolBar.TabIndex = 2;
			this.MetaDataToolBar.Tag = "";
			// 
			// seleziona
			// 
			this.seleziona.ImageIndex = 0;
			this.seleziona.Tag = "mainselect";
			this.seleziona.Text = "Seleziona";
			this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageIndex = 5;
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta Ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageIndex = 6;
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua Ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// modifica
			// 
			this.modifica.ImageIndex = 3;
			this.modifica.Tag = "mainedit";
			this.modifica.Text = "Modifica";
			this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
			// 
			// inserisci
			// 
			this.inserisci.ImageIndex = 11;
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageIndex = 4;
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
			// 
			// elimina
			// 
			this.elimina.ImageIndex = 2;
			this.elimina.Tag = "maindelete";
			this.elimina.Text = "Elimina";
			this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
			// 
			// Salva
			// 
			this.Salva.ImageIndex = 1;
			this.Salva.Tag = "mainsave";
			this.Salva.Text = "Salva";
			this.Salva.ToolTipText = "Salva le modifiche effettuate";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 56);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(400, 472);
			this.dataGrid1.TabIndex = 3;
			this.dataGrid1.Tag = "accountkind.default";
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail.Controls.Add(this.groupBox1);
			this.MetaDataDetail.Controls.Add(this.checkBox1);
			this.MetaDataDetail.Controls.Add(this.groupBox2);
			this.MetaDataDetail.Controls.Add(this.textBox2);
			this.MetaDataDetail.Controls.Add(this.label2);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.label1);
			this.MetaDataDetail.Location = new System.Drawing.Point(416, 56);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(240, 472);
			this.MetaDataDetail.TabIndex = 4;
			this.MetaDataDetail.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.listBoxB);
			this.groupBox1.Controls.Add(this.avere2);
			this.groupBox1.Controls.Add(this.dare2);
			this.groupBox1.Location = new System.Drawing.Point(8, 296);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 168);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Segno per le seguenti operazioni:";
			// 
			// listBoxB
			// 
			this.listBoxB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxB.Items.AddRange(new object[] {
														  "Fattura di acquisto",
														  "Nota di credito su vendita",
														  "Liquidazione iva debito",
														  "Incasso",
														  "Ammortamento",
														  "Liquidazione ritenute"});
			this.listBoxB.Location = new System.Drawing.Point(8, 16);
			this.listBoxB.Name = "listBoxB";
			this.listBoxB.Size = new System.Drawing.Size(208, 121);
			this.listBoxB.TabIndex = 6;
			// 
			// avere2
			// 
			this.avere2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.avere2.Checked = true;
			this.avere2.Location = new System.Drawing.Point(136, 144);
			this.avere2.Name = "avere2";
			this.avere2.Size = new System.Drawing.Size(72, 16);
			this.avere2.TabIndex = 5;
			this.avere2.TabStop = true;
			this.avere2.Tag = "";
			this.avere2.Text = "Avere";
			this.avere2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// dare2
			// 
			this.dare2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dare2.Location = new System.Drawing.Point(24, 144);
			this.dare2.Name = "dare2";
			this.dare2.Size = new System.Drawing.Size(64, 16);
			this.dare2.TabIndex = 4;
			this.dare2.Tag = "";
			this.dare2.Text = "Dare";
			this.dare2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 104);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(224, 16);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Tag = "accountkind.active:S:N";
			this.checkBox1.Text = "Attivo";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBoxA);
			this.groupBox2.Controls.Add(this.avere1);
			this.groupBox2.Controls.Add(this.dare1);
			this.groupBox2.Location = new System.Drawing.Point(8, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 176);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Segno per le seguenti operazioni:";
			// 
			// listBoxA
			// 
			this.listBoxA.Items.AddRange(new object[] {
														  "Fattura di vendita",
														  "Nota di credito su acquisto",
														  "Liquidazione iva credito",
														  "Pagamento",
														  "Applicazione ritenute"});
			this.listBoxA.Location = new System.Drawing.Point(8, 16);
			this.listBoxA.Name = "listBoxA";
			this.listBoxA.Size = new System.Drawing.Size(208, 134);
			this.listBoxA.TabIndex = 6;
			// 
			// avere1
			// 
			this.avere1.Location = new System.Drawing.Point(128, 152);
			this.avere1.Name = "avere1";
			this.avere1.Size = new System.Drawing.Size(72, 16);
			this.avere1.TabIndex = 5;
			this.avere1.Tag = "accountkind.flagda:A";
			this.avere1.Text = "Avere";
			this.avere1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// dare1
			// 
			this.dare1.Checked = true;
			this.dare1.Location = new System.Drawing.Point(16, 152);
			this.dare1.Name = "dare1";
			this.dare1.Size = new System.Drawing.Size(64, 16);
			this.dare1.TabIndex = 4;
			this.dare1.TabStop = true;
			this.dare1.Tag = "accountkind.flagda:D";
			this.dare1.Text = "Dare";
			this.dare1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 72);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(224, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "accountkind.description";
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descrizione";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "accountkind.idaccountkind";
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Codice";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmAccountKind_Default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 533);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.MetaDataToolBar);
			this.Name = "FrmAccountKind_Default";
			this.Text = "FrmAccountKind_Default";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		bool GiveSign(RadioButton C){
			if (C==dare1) return true;
			if (C==dare2) return false;
			if (C==avere2) return true;
			if (C==avere1) return false;
			return true;
		}
		private void CheckBox_CheckedChanged(object sender, System.EventArgs e) {
			if (clearing) return;
			RadioButton Me= sender as RadioButton;
			clearing=true;
			foreach(RadioButton C in new RadioButton[]{
													dare1,dare2,avere1,avere2}){
				if (C==Me) continue;
				bool sign= GiveSign(Me) ^ GiveSign(C);
				C.Checked= Me.Checked^sign;
			}
			clearing=false;
		}
	}
}
