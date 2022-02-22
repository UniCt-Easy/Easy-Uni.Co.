
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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;

namespace sorting_traduzione//ClassMovimenti_traduzione//
{
	/// <summary>
	/// Summary description for FrmClassMovimenti_traduzione.
	/// </summary>
	public class Frm_sorting_traduzione : MetaDataForm
	{
		MetaData Meta;
		public System.Windows.Forms.GroupBox gbox;
		public dsmeta DS;
		public System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelPorzioneClassificata;
        public GroupBox MetaDataDetail;
        private System.ComponentModel.IContainer components;

		public Frm_sorting_traduzione()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			DS.sortingtranslation.ExtendedProperties["gridmaster"]="tipoclassmovimenti_dest";
			DataAccess.SetTableForReading(DS.tipoclassmovimenti_dest, "sortingkind");
			DataAccess.SetTableForReading(DS.classmovimenti_dest, "sorting");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sorting_traduzione));
            this.gbox = new System.Windows.Forms.GroupBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.DS = new sorting_traduzione.dsmeta();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tree = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.labelPorzioneClassificata = new System.Windows.Forms.Label();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbox.Controls.Add(this.cmbLivello);
            this.gbox.Controls.Add(this.txtDescrizione);
            this.gbox.Controls.Add(this.label4);
            this.gbox.Controls.Add(this.txtCodice);
            this.gbox.Controls.Add(this.label3);
            this.gbox.Controls.Add(this.label2);
            this.gbox.Location = new System.Drawing.Point(6, 19);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(716, 48);
            this.gbox.TabIndex = 3;
            this.gbox.TabStop = false;
            this.gbox.Text = "Classificazione sorgente";
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.sortinglevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Enabled = false;
            this.cmbLivello.ItemHeight = 13;
            this.cmbLivello.Location = new System.Drawing.Point(48, 16);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(104, 21);
            this.cmbLivello.TabIndex = 8;
            this.cmbLivello.Tag = "sorting.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // DS
            // 
            this.DS.DataSetName = "dsmeta";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(344, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(364, 24);
            this.txtDescrizione.TabIndex = 13;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(280, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(192, 16);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(88, 20);
            this.txtCodice.TabIndex = 11;
            this.txtCodice.Tag = "sorting.sortcode";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(152, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Codice:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Livello:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(184, 566);
            this.tree.TabIndex = 4;
            this.tree.Tag = "sorting.tree";
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // DGridClassificazioni
            // 
            this.DGridClassificazioni.AllowNavigation = false;
            this.DGridClassificazioni.AllowSorting = false;
            this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridClassificazioni.DataMember = "";
            this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridClassificazioni.Location = new System.Drawing.Point(9, 85);
            this.DGridClassificazioni.Name = "DGridClassificazioni";
            this.DGridClassificazioni.ParentRowsVisible = false;
            this.DGridClassificazioni.ReadOnly = true;
            this.DGridClassificazioni.Size = new System.Drawing.Size(713, 200);
            this.DGridClassificazioni.TabIndex = 29;
            this.DGridClassificazioni.Tag = "tipoclassmovimenti_dest.listatipoclassi";
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.labelPorzioneClassificata);
            this.groupBox15.Controls.Add(this.btnDelClass);
            this.groupBox15.Controls.Add(this.btnEditClass);
            this.groupBox15.Controls.Add(this.btnInsertClass);
            this.groupBox15.Controls.Add(this.DGridDettagliClassificazioni);
            this.groupBox15.Location = new System.Drawing.Point(9, 291);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(713, 257);
            this.groupBox15.TabIndex = 31;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Traduzione classificazioni";
            // 
            // labelPorzioneClassificata
            // 
            this.labelPorzioneClassificata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPorzioneClassificata.Location = new System.Drawing.Point(272, 8);
            this.labelPorzioneClassificata.Name = "labelPorzioneClassificata";
            this.labelPorzioneClassificata.Size = new System.Drawing.Size(433, 40);
            this.labelPorzioneClassificata.TabIndex = 8;
            this.labelPorzioneClassificata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelClass
            // 
            this.btnDelClass.Location = new System.Drawing.Point(192, 16);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(75, 23);
            this.btnDelClass.TabIndex = 3;
            this.btnDelClass.Tag = "delete";
            this.btnDelClass.Text = "Elimina";
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(104, 16);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(75, 23);
            this.btnEditClass.TabIndex = 2;
            this.btnEditClass.Tag = "edit.dettaglio";
            this.btnEditClass.Text = "Modifica...";
            // 
            // btnInsertClass
            // 
            this.btnInsertClass.Location = new System.Drawing.Point(16, 16);
            this.btnInsertClass.Name = "btnInsertClass";
            this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClass.TabIndex = 1;
            this.btnInsertClass.Tag = "insert.dettaglio";
            this.btnInsertClass.Text = "Inserisci...";
            // 
            // DGridDettagliClassificazioni
            // 
            this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridDettagliClassificazioni.DataMember = "";
            this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 48);
            this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
            this.DGridDettagliClassificazioni.ReadOnly = true;
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(697, 201);
            this.DGridDettagliClassificazioni.TabIndex = 7;
            this.DGridDettagliClassificazioni.Tag = "sortingtranslation.destinazione.dettaglio";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tipo Classificazione destinazione";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.gbox);
            this.MetaDataDetail.Controls.Add(this.groupBox15);
            this.MetaDataDetail.Controls.Add(this.DGridClassificazioni);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Location = new System.Drawing.Point(190, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(728, 554);
            this.MetaDataDetail.TabIndex = 32;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "groupBox1";
            // 
            // Frm_sorting_traduzione
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(930, 566);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.tree);
            this.Name = "Frm_sorting_traduzione";
            this.Text = "FrmClassMovimenti_traduzione";
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() 
		{
			MetaData metaTipoClassMov = MetaData.GetMetaData(this, "sortingkind");
			metaTipoClassMov.DescribeColumns(DS.tipoclassmovimenti_dest, "listatipoclassi");
            MetaData metaSorTrasl = MetaData.GetMetaData(this, "sortingtranslation");
            metaSorTrasl.DescribeColumns(DS.sortingtranslation, "destinazione");

            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filter = (string)Meta.ExtraParameter;
			string filtercodice = QHS.CmpEq("idsorkind", filter);
			string filterdest = QHS.CmpNe("idsorkind", filter);
			GetData.SetStaticFilter(DS.sorting, filtercodice);
			GetData.CacheTable(DS.sortinglevel,filtercodice,null,true);
			GetData.CacheTable(DS.sortingkind,filtercodice,null,false);
			GetData.CacheTable(DS.tipoclassmovimenti_dest,filterdest,null,false);
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
		}
		public void MetaData_AfterActivation()
		{
			if (DS.sortingkind.Rows.Count==0) return;
			DataRow CurrTipo = DS.sortingkind.Rows[0];
			Meta.Name = "Traduzione classificazioni del tipo \""+CurrTipo["description"]+"\"";
		}

		private bool TipoNumerico(object codicelivello)
		{
			DataRow[] Res = DS.sortinglevel.Select(QHC.CmpEq("nlevel",codicelivello));
			if (Res.Length!=1) return false;
			int tipocodice = CfgFn.GetNoNullByte(Res[0]["flag"]) & 1;
			if (tipocodice==0)
				return true;
			else
				return false;
		}

		public void MetaData_AfterFill()
		{
            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.tipoclassmovimenti_dest);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!sortingkindchild", CurrSorKind["idsorkind"]);
                DS.sortingtranslation.ExtendedProperties["CustomParentRelation"] = f;
            }

			bool ModoInsert=Meta.InsertMode;
			txtCodice.ReadOnly=true;
			cmbLivello.Enabled=false;
			DataRow R = HelpForm.GetLastSelected(DS.sorting);
			if (R==null) return;
			object livello = R["nlevel"];
			if (ModoInsert)
			{
				txtCodice.ReadOnly=TipoNumerico(livello);
			}
		}

		public void MetaData_AfterClear()
		{
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
		}

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "tipoclassmovimenti_dest") {
                DataRow CurrSorKind = HelpForm.GetLastSelected(DS.tipoclassmovimenti_dest);
                if (CurrSorKind != null) {
                    string f = QHC.CmpEq("!sortingkindchild", CurrSorKind["idsorkind"]);
                    DS.sortingtranslation.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (T.TableName == "tipoclassmovimenti_dest")
			{
				if (R==null){
					btnDelClass.Enabled = false;
					btnEditClass.Enabled = false;
					btnInsertClass.Enabled = false;
					return;
				}
				//MetaData.SetDefault(DS.sortingtranslation, "sortingkindchild", R["idsorkind"]);
                DS.sortingtranslation.ExtendedProperties[MetaData.ExtraParams] = R;
				MetaData.SetDefault(DS.sortingtranslation, "idsortingchild", 0);

				if (R["flagdate"].ToString().ToLower()=="s"){
					MetaData.SetDefault(DS.sortingtranslation,"flagnodate","N");
				}
				else {
					MetaData.SetDefault(DS.sortingtranslation,"flagnodate",DBNull.Value);
				}

				foreach(string kind in new string[]{"N","S","v"}){
					for (int i=1; i<=5; i++) {
						string forcedname= "forced"+kind+i.ToString();
						string fieldname= "default"+kind+i.ToString();
						if (R[forcedname].ToString().ToUpper()=="S"){
							if (kind=="N") 
								MetaData.SetDefault(DS.sortingtranslation, fieldname, 0);
							if (kind=="S") 
								MetaData.SetDefault(DS.sortingtranslation, fieldname, "");
							if (kind=="v") 
								MetaData.SetDefault(DS.sortingtranslation, fieldname, 0);
						}
						else {
							MetaData.SetDefault(DS.sortingtranslation, fieldname, DBNull.Value);
						}

					}

				}

				object codiceTipoClassChild = R["idsorkind"];
				string filtro = QHC.CmpEq("!sortingkindchild", codiceTipoClassChild);
				bool esisteRigaTraduzione = (HelpForm.GetLastSelected(DS.sorting) != null)
					&& (DS.sortingtranslation.Select(filtro).Length > 0);
				bool GestioneResiduiAttiva= (R["totalexpression"].ToString()=="");
				btnDelClass.Enabled = esisteRigaTraduzione;
				btnEditClass.Enabled = esisteRigaTraduzione;

				if ((!esisteRigaTraduzione) || (!GestioneResiduiAttiva))
				{
					labelPorzioneClassificata.Text = null;
					btnInsertClass.Enabled = HelpForm.GetLastSelected(DS.sorting) != null;
				} 
				else 
				{
					long sommaNum, sommaDen;
					getPorzioneClassificata(out sommaNum, out sommaDen);

					if (sommaDen == 0) 
					{
						labelPorzioneClassificata.Text = "Errore nelle frazioni. Correggere i dati esistenti!";
					} 
					else 
					{
						if (sommaNum == 0) 
						{
							labelPorzioneClassificata.Text = "Traduzione completata delle classificazioni di tipo \""
								+ R["description"] +"\".";
						} 
						else 
						{
							string messaggio = "Già classificato: " + (sommaDen-sommaNum) + "/" + sommaDen 
								+ ";  Da classificare: " + sommaNum + "/" + sommaDen;
							if (sommaNum < 0) 
							{
								messaggio += "\r\nLa somma delle frazioni supera 1, correggere i dati esistenti!";
							}
							labelPorzioneClassificata.Text = messaggio;
						}
					}
					btnInsertClass.Enabled = (sommaNum > 0) && (sommaNum <= sommaDen) && (sommaDen != 0);
				}
			}

			if (T.TableName != "sorting") return;
			bool ModoInsert=Meta.InsertMode;
			txtCodice.ReadOnly=true;
			cmbLivello.Enabled=false;
			if (R==null) 
			{
				return;
			}
			object livello = R["nlevel"];
			if (ModoInsert)
			{
				txtCodice.ReadOnly=TipoNumerico(livello);
			}
		}

		public long massimoComuneDivisore(long x, long y) 
		{
			while (y != 0) 
			{
				long m = x % y;
				x = y;
				y = m;
			}
			return x;
		}

		public void getPorzioneClassificata(out long sommaNum, out long sommaDen) 
		{
			sommaDen = 1;
			sommaNum = 1;
			DataRow R = HelpForm.GetLastSelected(DS.tipoclassmovimenti_dest);
			object codiceTipoClassChild = R["idsorkind"];
			string filtro = QHC.CmpEq("!sortingkindchild", codiceTipoClassChild);

			foreach (DataRow r in DS.sortingtranslation.Select(filtro)) 
			{
				if ((r["numerator"] != DBNull.Value) && (r["denominator"] != DBNull.Value))
				{
					long numeratore = (int) r["numerator"];
					long denominatore = (int) r["denominator"];
					sommaNum = sommaNum * denominatore - sommaDen * numeratore;
					sommaDen *= denominatore;
					long mcd = massimoComuneDivisore(sommaNum, sommaDen);
					if (mcd == 0) return;
					sommaNum /= mcd;
					sommaDen /= mcd;
				}
			}
			if (sommaDen < 0) 
			{
				sommaNum = -sommaNum;
				sommaDen = -sommaDen;
			}
		}
	}
}
