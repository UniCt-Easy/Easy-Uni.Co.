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
using metaeasylibrary;
using System.Data;


namespace journaltablesetup_default//transactionrule//
{
	/// <summary>
	/// Summary description for frmtransactionrule.
	/// </summary>
	public class Frm_journaltablesetup_default : System.Windows.Forms.Form
	{
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
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView listViewLog;
		MetaData Meta;
		DataAccess Conn;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbtabella;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdBModifica;
		private System.Windows.Forms.RadioButton rdBInserimento;
        public vistaForm DS;
        private System.Windows.Forms.RadioButton rdBCancellazione;
		

		public Frm_journaltablesetup_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            cmbtabella.DataSource = DS.customobject;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_journaltablesetup_default));
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
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdBCancellazione = new System.Windows.Forms.RadioButton();
            this.rdBModifica = new System.Windows.Forms.RadioButton();
            this.rdBInserimento = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbtabella = new System.Windows.Forms.ComboBox();
            this.DS = new journaltablesetup_default.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.MetaDataToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(769, 56);
            this.MetaDataToolBar.TabIndex = 34;
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
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(24, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(729, 156);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "journaltablesetup.default";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewLog);
            this.groupBox2.Location = new System.Drawing.Point(24, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 205);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campi da inserire nel log:";
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.Location = new System.Drawing.Point(8, 19);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(708, 179);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.Tag = "";
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.groupBox3);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Location = new System.Drawing.Point(24, 218);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(729, 112);
            this.MetaDataDetail.TabIndex = 35;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdBCancellazione);
            this.groupBox3.Controls.Add(this.rdBModifica);
            this.groupBox3.Controls.Add(this.rdBInserimento);
            this.groupBox3.Location = new System.Drawing.Point(541, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 88);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operazione:";
            // 
            // rdBCancellazione
            // 
            this.rdBCancellazione.Location = new System.Drawing.Point(36, 64);
            this.rdBCancellazione.Name = "rdBCancellazione";
            this.rdBCancellazione.Size = new System.Drawing.Size(104, 16);
            this.rdBCancellazione.TabIndex = 2;
            this.rdBCancellazione.Tag = "journaltablesetup.opkind:D";
            this.rdBCancellazione.Text = "Cancellazione";
            // 
            // rdBModifica
            // 
            this.rdBModifica.Location = new System.Drawing.Point(36, 40);
            this.rdBModifica.Name = "rdBModifica";
            this.rdBModifica.Size = new System.Drawing.Size(88, 16);
            this.rdBModifica.TabIndex = 1;
            this.rdBModifica.Tag = "journaltablesetup.opkind:U";
            this.rdBModifica.Text = "Modifica";
            // 
            // rdBInserimento
            // 
            this.rdBInserimento.Location = new System.Drawing.Point(36, 16);
            this.rdBInserimento.Name = "rdBInserimento";
            this.rdBInserimento.Size = new System.Drawing.Size(96, 16);
            this.rdBInserimento.TabIndex = 0;
            this.rdBInserimento.Tag = "journaltablesetup.opkind:I";
            this.rdBInserimento.Text = "Inserimento";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbtabella);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabella:";
            // 
            // cmbtabella
            // 
            this.cmbtabella.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtabella.DisplayMember = "objectname";
            this.cmbtabella.Location = new System.Drawing.Point(16, 32);
            this.cmbtabella.Name = "cmbtabella";
            this.cmbtabella.Size = new System.Drawing.Size(493, 21);
            this.cmbtabella.TabIndex = 0;
            this.cmbtabella.Tag = "journaltablesetup.tablename";
            this.cmbtabella.ValueMember = "objectname";
            this.cmbtabella.SelectedIndexChanged += new System.EventHandler(this.cmbtabella_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_journaltablesetup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(769, 546);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_journaltablesetup_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtransactionrule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.MetaDataDetail.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			this.Conn=Meta.Conn;			
			GetData.SetStaticFilter(DS.customobject,"(isreal='S')");
		}
		
		


		public void MetaData_AfterRowSelect(DataTable T, DataRow R) 
		{
			
			if (T.TableName == "customobject")
			{
				if (R==null) return;
				string filtro="(tablename=" + QueryCreator.quotedstrvalue(R["objectname"].ToString(),true) + ")";
				SetListview(filtro);
			}

			if (T.TableName == "journaltablesetup")
			{
				if (R==null) return;
				string filtro="(tablename=" + QueryCreator.quotedstrvalue(R["tablename"].ToString(),true) + ")";
				SetListview(filtro);
			
				foreach(object LVIO in listViewLog.Items)
				{	
					ListViewItem  LVI = (ListViewItem) LVIO;
					LVI.Checked = false;
				}
				listViewLog.Refresh();

				if (!Meta.IsEmpty)
				{
                    string filter = "(tablename=" + QueryCreator.quotedstrvalue(R["tablename"].ToString()
                        , true) + " AND opkind=" + QueryCreator.quotedstrvalue(R["opkind"].ToString(), true) + ")";
						foreach(DataRow RT in DS.journalfieldsetup.Select(filter))
						{
							foreach(object LVIO in listViewLog.Items)
							{
				
								ListViewItem  LVI = (ListViewItem) LVIO;
								DataRow P2Row = (DataRow) LVI.Tag;
                                if(P2Row["field"].ToString() == RT["dbfield"].ToString())
									LVI.Checked = true;
							}
							listViewLog.Refresh();
						}
					}
				}
			
		}

		
		public void SetListview(string filtro)
		{
			listViewLog.Clear();
			listViewLog.BeginUpdate();

			DataTable TabellaDescrClass=Conn.RUN_SELECT("columntypes","*",null,filtro, null, null, true);
		
			foreach(DataRow R1 in TabellaDescrClass.Select(null,"field"))
			{
				ListViewItem listViewOD = new ListViewItem(R1["field"].ToString());
				listViewOD.Tag=R1;
				listViewLog.Items.Add(listViewOD);
			}
			listViewLog.Columns.Add("Descrizione",300,HorizontalAlignment.Left);
			listViewLog.CheckBoxes=true;
			listViewLog.View=View.Details;
			listViewLog.EndUpdate();
			listViewLog.Refresh();
		}		
	

		public void MetaData_AfterGetFormData()
		{
			string filtro1="";
		
			foreach(object LVIO in listViewLog.Items)
			{
				ListViewItem  LVI = (ListViewItem) LVIO;
				DataRow P2Row = (DataRow) LVI.Tag;
				DataRow P1Row= HelpForm.GetLastSelected(DS.journaltablesetup);
				
				if (P1Row==null) return;

                filtro1 = "(tablename=" + QueryCreator.quotedstrvalue(P1Row["tablename"].ToString(), false) + ")" +
                    " AND (opkind=" + QueryCreator.quotedstrvalue(P1Row["opkind"].ToString(), false) + ")" + 
					" AND (dbfield=" + QueryCreator.quotedstrvalue(P2Row["field"].ToString(),false) + ")";

				DataRow []CurrChilds=DS.journalfieldsetup.Select(filtro1,null,DataViewRowState.CurrentRows);
				DataRow []DelChilds=DS.journalfieldsetup.Select(filtro1,null,DataViewRowState.Deleted);
				
				if ((LVI.Checked) && (CurrChilds.Length==0))
				{
					DataRow newMid;
					if (DelChilds.Length>0)
					{
						DelChilds[0].RejectChanges();
						newMid=DelChilds[0];
					}
					else
					{
						newMid= DS.journalfieldsetup.NewRow();
					}


                    newMid["tablename"] = P1Row["tablename"];
                    newMid["opkind"] = P1Row["opkind"];
					newMid["dbfield"]=P2Row["field"];
					
					if (DelChilds.Length==0)
						DS.journalfieldsetup.Rows.Add(newMid);
				}
				if ((!LVI.Checked) && (CurrChilds.Length>0))
				{
					CurrChilds[0].Delete();
				}

			}
		
		}

        private void cmbtabella_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
