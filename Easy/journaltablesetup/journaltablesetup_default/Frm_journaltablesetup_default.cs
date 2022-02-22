
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
using q=metadatalibrary.MetaExpression;
using metaeasylibrary;
using System.Data;


namespace journaltablesetup_default //transactionrule//
{
	/// <summary>
	/// Summary description for frmtransactionrule.
	/// </summary>
	public class Frm_journaltablesetup_default : MetaDataForm {
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.GroupBox gboxCampi;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView listViewLog;
		MetaData Meta;
		DataAccess Conn;
		public System.Windows.Forms.GroupBox gboxOperazioni;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbtabella;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdBModifica;
		private System.Windows.Forms.RadioButton rdBInserimento;
		public vistaForm DS;
		private System.Windows.Forms.RadioButton rdBCancellazione;


		public Frm_journaltablesetup_default() {
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
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Frm_journaltablesetup_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.gboxCampi = new System.Windows.Forms.GroupBox();
			this.listViewLog = new System.Windows.Forms.ListView();
			this.gboxOperazioni = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdBCancellazione = new System.Windows.Forms.RadioButton();
			this.rdBModifica = new System.Windows.Forms.RadioButton();
			this.rdBInserimento = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbtabella = new System.Windows.Forms.ComboBox();
			this.DS = new journaltablesetup_default.vistaForm();
			this.gboxCampi.SuspendLayout();
			this.gboxOperazioni.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// images
			// 
			this.images.ImageStream =
				((System.Windows.Forms.ImageListStreamer) (resources.GetObject("images.ImageStream")));
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
			// gboxCampi
			// 
			this.gboxCampi.Anchor =
				((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
				                                         System.Windows.Forms.AnchorStyles.Bottom)
				                                        | System.Windows.Forms.AnchorStyles.Left)
				                                       | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxCampi.Controls.Add(this.listViewLog);
			this.gboxCampi.Location = new System.Drawing.Point(11, 139);
			this.gboxCampi.Name = "gboxCampi";
			this.gboxCampi.Size = new System.Drawing.Size(729, 395);
			this.gboxCampi.TabIndex = 3;
			this.gboxCampi.TabStop = false;
			this.gboxCampi.Text = "Campi da inserire nel log:";
			// 
			// listViewLog
			// 
			this.listViewLog.Anchor =
				((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
				                                         System.Windows.Forms.AnchorStyles.Bottom)
				                                        | System.Windows.Forms.AnchorStyles.Left)
				                                       | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewLog.HideSelection = false;
			this.listViewLog.Location = new System.Drawing.Point(8, 19);
			this.listViewLog.Name = "listViewLog";
			this.listViewLog.Size = new System.Drawing.Size(708, 369);
			this.listViewLog.TabIndex = 0;
			this.listViewLog.Tag = "";
			this.listViewLog.UseCompatibleStateImageBehavior = false;
			// 
			// gboxOperazioni
			// 
			this.gboxOperazioni.Anchor =
				((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
				                                        System.Windows.Forms.AnchorStyles.Left)
				                                       | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxOperazioni.Controls.Add(this.groupBox3);
			this.gboxOperazioni.Controls.Add(this.groupBox1);
			this.gboxOperazioni.Location = new System.Drawing.Point(11, 12);
			this.gboxOperazioni.Name = "gboxOperazioni";
			this.gboxOperazioni.Size = new System.Drawing.Size(729, 112);
			this.gboxOperazioni.TabIndex = 35;
			this.gboxOperazioni.TabStop = false;
			this.gboxOperazioni.Text = "Dettaglio";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor =
				((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
				                                        System.Windows.Forms.AnchorStyles.Bottom)
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
			this.groupBox1.Anchor =
				((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
				                                        System.Windows.Forms.AnchorStyles.Left)
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
			this.cmbtabella.Anchor =
				((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left |
				                                       System.Windows.Forms.AnchorStyles.Right)));
			this.cmbtabella.DisplayMember = "objectname";
			this.cmbtabella.Location = new System.Drawing.Point(16, 32);
			this.cmbtabella.Name = "cmbtabella";
			this.cmbtabella.Size = new System.Drawing.Size(493, 21);
			this.cmbtabella.TabIndex = 0;
			this.cmbtabella.Tag = "journaltablesetup.tablename";
			this.cmbtabella.ValueMember = "objectname";
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
			this.Controls.Add(this.gboxOperazioni);
			this.Controls.Add(this.gboxCampi);
			this.Name = "Frm_journaltablesetup_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmtransactionrule";
			this.gboxCampi.ResumeLayout(false);
			this.gboxOperazioni.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion


		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			this.Conn = Meta.Conn;
			GetData.SetStaticFilter(DS.customobject, "(isreal='S')");
		}

		private bool isSetted = false;

		public void MetaData_AfterClear() {
			gboxOperazioni.Enabled = true;
			gboxCampi.Enabled = false;
			listViewLog.Clear();
			isSetted = false;
		}

		public void MetaData_AfterFill() {
			gboxOperazioni.Enabled = Meta.InsertMode;
			gboxCampi.Enabled = Meta.EditMode;
			if (!isSetted) {
				resetListView(DS.journaltablesetup.Rows[0]["tablename"].ToString());
				if (Meta.EditMode) fillListBox();
			}
		}

		void fillListBox() {
			foreach (object LVIO in listViewLog.Items) {
				var LVI = (ListViewItem) LVIO;
				LVI.Checked = false;
			}


			if (Meta.IsEmpty) {
				listViewLog.Refresh();
				return;
			}


			foreach (var RT in DS.journalfieldsetup.Select()) {
				foreach (object LVIO in listViewLog.Items) {
					var LVI = (ListViewItem) LVIO;
					var P2Col = (DataColumn) LVI.Tag;
					if (P2Col.ColumnName == RT["dbfield"].ToString())
						LVI.Checked = true;
				}
			}

			listViewLog.Refresh();
		
		}




		public void resetListView(string tableName) {
			isSetted = false;
			listViewLog.Clear();
			if (Meta.InsertMode || Meta.IsEmpty) return;

			listViewLog.BeginUpdate();

			DataTable TabellaDescrClass = Conn.CreateTableByName(tableName, "*");


			foreach (DataColumn c in TabellaDescrClass.Columns) {
				var listViewOD = new ListViewItem(c.ColumnName);
				listViewOD.Tag = c;
				listViewLog.Items.Add(listViewOD);
			}

			listViewLog.Columns.Add("Campo", 300, HorizontalAlignment.Left);
			listViewLog.CheckBoxes = true;
			listViewLog.View = View.Details;
			listViewLog.EndUpdate();
			listViewLog.Refresh();
			isSetted = true;
		}


		public void MetaData_AfterGetFormData() {
			DataRow P1Row = DS.journaltablesetup.Rows[0];
			DataRow[] CurrChilds = DS.journalfieldsetup.Select();
			foreach (DataRow r in CurrChilds) r.Delete(); //rimuove tutto

			foreach (object LVIO in listViewLog.Items) {
				ListViewItem LVI = (ListViewItem) LVIO;
				DataColumn P2Col = (DataColumn) LVI.Tag;


				string filtro1 = "(tablename=" + QueryCreator.quotedstrvalue(P1Row["tablename"].ToString(), false) +
				                 ")" +
				                 " AND (opkind=" + QueryCreator.quotedstrvalue(P1Row["opkind"].ToString(), false) +
				                 ")" +
				                 " AND (dbfield=" + QueryCreator.quotedstrvalue(P2Col.ColumnName, false) + ")";


				DataRow[] DelChilds = DS.journalfieldsetup.Select(filtro1, null, DataViewRowState.Deleted);
				if (LVI.Checked) {
					if (DelChilds.Length > 0) {
						DelChilds[0].RejectChanges();
					}
					else {
						var newMid = DS.journalfieldsetup.NewRow();
						newMid["tablename"] = P1Row["tablename"];
						newMid["opkind"] = P1Row["opkind"];
						newMid["dbfield"] = P2Col.ColumnName;
						DS.journalfieldsetup.Rows.Add(newMid);
					}
				}

			}

		}


	}
}
