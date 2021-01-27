
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
using metadatalibrary;
using funzioni_configurazione;
using SituazioneViewer;

namespace treasurerstart_default//saldoinizialecassiere//
{
	/// <summary>
	/// Summary description for frmsaldoinizialecassiere.
	/// </summary>
	public class Frm_treasurerstart_default : System.Windows.Forms.Form
	{
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		public vistaForm DS;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.ImageList imageList1;
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
		private System.Windows.Forms.PictureBox pictureBox1;
        private Button btnSituazione;
		private System.ComponentModel.IContainer components;
        private Button btnValorizzaSaldo;
        MetaData Meta;
        //private DataAccess Conn;
		public Frm_treasurerstart_default(){
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_treasurerstart_default));
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.btnValorizzaSaldo = new System.Windows.Forms.Button();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.DS = new treasurerstart_default.vistaForm();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.btnValorizzaSaldo);
            this.MetaDataDetail.Controls.Add(this.btnSituazione);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Controls.Add(this.cmbCodiceIstituto);
            this.MetaDataDetail.Controls.Add(this.textBox2);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Location = new System.Drawing.Point(350, 56);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(312, 179);
            this.MetaDataDetail.TabIndex = 40;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio";
            // 
            // btnValorizzaSaldo
            // 
            this.btnValorizzaSaldo.Location = new System.Drawing.Point(131, 87);
            this.btnValorizzaSaldo.Name = "btnValorizzaSaldo";
            this.btnValorizzaSaldo.Size = new System.Drawing.Size(175, 36);
            this.btnValorizzaSaldo.TabIndex = 44;
            this.btnValorizzaSaldo.Text = "Copia saldo iniziale dall\'esercizio precedente";
            this.btnValorizzaSaldo.UseVisualStyleBackColor = true;
            this.btnValorizzaSaldo.Click += new System.EventHandler(this.btnValorizzaSaldo_Click);
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(190, 151);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(100, 22);
            this.btnSituazione.TabIndex = 43;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.UseVisualStyleBackColor = true;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Saldo iniziale:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(8, 40);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(280, 21);
            this.cmbCodiceIstituto.TabIndex = 24;
            this.cmbCodiceIstituto.Tag = "treasurerstart.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 23;
            this.textBox2.Tag = "treasurerstart.amount";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Istituto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid1.Size = new System.Drawing.Size(336, 261);
            this.dataGrid1.TabIndex = 33;
            this.dataGrid1.Tag = "treasurerstart.default";
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
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
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
            this.MetaDataToolBar.ImageList = this.imageList1;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(664, 106);
            this.MetaDataToolBar.TabIndex = 41;
            this.MetaDataToolBar.Tag = "";
            // 
            // seleziona
            // 
            this.seleziona.ImageIndex = 1;
            this.seleziona.Name = "seleziona";
            this.seleziona.Tag = "mainselect";
            this.seleziona.Text = "Seleziona";
            this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
            // 
            // impostaricerca
            // 
            this.impostaricerca.ImageIndex = 10;
            this.impostaricerca.Name = "impostaricerca";
            this.impostaricerca.Tag = "mainsetsearch";
            this.impostaricerca.Text = "Imposta Ricerca";
            this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
            // 
            // effettuaricerca
            // 
            this.effettuaricerca.ImageIndex = 12;
            this.effettuaricerca.Name = "effettuaricerca";
            this.effettuaricerca.Tag = "maindosearch";
            this.effettuaricerca.Text = "Effettua Ricerca";
            this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
            // 
            // modifica
            // 
            this.modifica.ImageIndex = 6;
            this.modifica.Name = "modifica";
            this.modifica.Tag = "mainedit";
            this.modifica.Text = "Modifica";
            this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.ImageIndex = 9;
            this.inseriscicopia.Name = "inseriscicopia";
            this.inseriscicopia.Tag = "maininsertcopy";
            this.inseriscicopia.Text = "Inserisci copia";
            this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 13;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(558, 249);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 64);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_treasurerstart_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 325);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_treasurerstart_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			GetData.SetStaticFilter(DS.treasurerstart, "(ayear='"+Meta.GetSys("esercizio").ToString()+"')");
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //this.Conn = Meta.Conn;
		}

        public void MetaData_AfterClear(){
            btnSituazione.Enabled = true;
            btnValorizzaSaldo.Enabled = true; ;
        }


        public void MetaData_AfterFill(){
            if (Meta.InsertMode){
                btnSituazione.Enabled = false;
                btnValorizzaSaldo.Enabled = false;
            }
            else{
                btnSituazione.Enabled = true;
                btnValorizzaSaldo.Enabled = true;
            }
        }

        private void btnSituazione_Click(object sender, EventArgs e){
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

        private void btnValorizzaSaldo_Click(object sender, EventArgs e){
            object idtreasurer;
            int ayearPrec = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
            int ayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            DataRow MyRow = HelpForm.GetLastSelected(DS.treasurer);
            if (MyRow == null) return;
            idtreasurer = MyRow["idtreasurer"];
            string filter = QHS.AppAnd(QHS.CmpEq("idtreasurer", idtreasurer), QHS.CmpEq("ayear", ayearPrec));
            decimal currentfloatfund = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("treasurercashtotal", filter, "currentfloatfund"));

            string script =
            " IF exists(SELECT * FROM [treasurerstart] WHERE ayear = " + QueryCreator.quotedstrvalue(ayear, true) + " AND idtreasurer =" + QueryCreator.quotedstrvalue(idtreasurer,true) + ")"+
            " BEGIN "+
            " UPDATE [treasurerstart] SET amount = "+ QueryCreator.quotedstrvalue(currentfloatfund,true)+" ,ct = getdate(),cu = 'TreasurerstarCopy',lt = getdate(),lu = 'TreasurerstarCopy' "+
            " WHERE ayear = "+ QueryCreator.quotedstrvalue(ayear, true) + " AND idtreasurer =" + QueryCreator.quotedstrvalue(idtreasurer,true) +
            " END " +
            " ELSE " +
            " BEGIN " + 
            " INSERT INTO [treasurerstart] (ayear,idtreasurer,amount,ct,cu,lt,lu) "+
            " VALUES (" + QueryCreator.quotedstrvalue(ayear, true) + "," + QueryCreator.quotedstrvalue(idtreasurer, true) + "," + QueryCreator.quotedstrvalue(currentfloatfund,true) + ","+
            " getdate(),'TreasurerstarCopy',getdate(),'TreasurerstarCopy')"+
            " END ";

           Meta.Conn.DO_SYS_CMD(script , false);
           MessageBox.Show("Copia eseguita.");
        }


	}
}
