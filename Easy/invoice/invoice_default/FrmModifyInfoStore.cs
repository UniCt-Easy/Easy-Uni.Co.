
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using System.Data;

namespace invoice_default {
	/// <summary>
    /// Summary description for FrmModifyInfoStore
    ///
  public class FrmModifyInfoStore : MetaDataForm {
  private System.Windows.Forms.Button btnOk;
  private System.Windows.Forms.Button btnAnnulla;
  DataAccess Conn;
  MetaDataDispatcher Disp;
  MetaData MetaStore;
  DataTable store;
  

  /// <summary>
		/// Required designer variable.
		/// </summary>
private System.ComponentModel.Container components = null;


      QueryHelper QHS;
      private GroupBox groupBox1;
      private Label label3;
      private ComboBox cmbMagazzino;
      CQueryHelper QHC;
      private GroupBox grpDettaglio;
      private PictureBox pbox;
      private Label label2;
      private TextBox txtListino;
      private TextBox txtDescrizioneListino;
      private GroupBox groupBox2;
      private Label label4;
      private TextBox txtExpiry;
      public object idstore;
      public object expiry;
      private GroupBox grpUbicazione;
      private TextBox txtDescUbicazione;
      private TextBox txtIdUbicazione;
      private Button btnUbicazione;
      public object idstocklocation;
      public DataRow Selected;

      public FrmModifyInfoStore(MetaDataDispatcher Disp, DataRow RstockView){
          InitializeComponent();

          this.Disp = Disp;
          this.Conn = Disp.Conn;

          QHC = new CQueryHelper();
          QHS = Conn.GetQueryHelper();

          MetaStore = Disp.Get("store");

          store = Conn.CreateTableByName("store", "*", false);
          DataSet D = new DataSet();
          D.Tables.Add(store);
          GetData.MarkToAddBlankRow(store);
          GetData.Add_Blank_Row(store);
          Conn.RUN_SELECT_INTO_TABLE(store, "description", QHS.CmpEq("active", "S"), null, true);
          cmbMagazzino.DataSource = store;
          cmbMagazzino.ValueMember = "idstore";
          cmbMagazzino.DisplayMember = "description";

          RiempiControlli(RstockView);
      }

/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.grpDettaglio = new System.Windows.Forms.GroupBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtIdUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpDettaglio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpUbicazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(449, 357);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(545, 357);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMagazzino);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 60);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleziona";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Magazzino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.Location = new System.Drawing.Point(79, 25);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(275, 21);
            this.cmbMagazzino.TabIndex = 16;
            this.cmbMagazzino.Tag = "";
            // 
            // grpDettaglio
            // 
            this.grpDettaglio.Controls.Add(this.pbox);
            this.grpDettaglio.Controls.Add(this.label2);
            this.grpDettaglio.Controls.Add(this.txtListino);
            this.grpDettaglio.Controls.Add(this.txtDescrizioneListino);
            this.grpDettaglio.Location = new System.Drawing.Point(7, 78);
            this.grpDettaglio.Name = "grpDettaglio";
            this.grpDettaglio.Size = new System.Drawing.Size(614, 178);
            this.grpDettaglio.TabIndex = 17;
            this.grpDettaglio.TabStop = false;
            this.grpDettaglio.Text = "Listino";
            // 
            // pbox
            // 
            this.pbox.Location = new System.Drawing.Point(399, 18);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(199, 152);
            this.pbox.TabIndex = 53;
            this.pbox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Codice";
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(17, 58);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(112, 20);
            this.txtListino.TabIndex = 44;
            this.txtListino.Tag = "listview.intcode?invoicedetailview.intcode";
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(135, 18);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(253, 60);
            this.txtDescrizioneListino.TabIndex = 45;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtExpiry);
            this.groupBox2.Location = new System.Drawing.Point(375, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 59);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleziona";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Scadenza:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(99, 21);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(133, 20);
            this.txtExpiry.TabIndex = 2;
            this.txtExpiry.Tag = "";
            this.txtExpiry.Leave += new System.EventHandler(this.txtExpiry_Leave);
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtIdUbicazione);
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(12, 262);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(362, 71);
            this.grpUbicazione.TabIndex = 117;
            this.grpUbicazione.TabStop = false;
            this.grpUbicazione.Tag = "";
            this.grpUbicazione.Text = "Ubicazione";
            // 
            // txtDescUbicazione
            // 
            this.txtDescUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazione.Location = new System.Drawing.Point(128, 16);
            this.txtDescUbicazione.Multiline = true;
            this.txtDescUbicazione.Name = "txtDescUbicazione";
            this.txtDescUbicazione.ReadOnly = true;
            this.txtDescUbicazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescUbicazione.Size = new System.Drawing.Size(226, 49);
            this.txtDescUbicazione.TabIndex = 3;
            this.txtDescUbicazione.TabStop = false;
            this.txtDescUbicazione.Tag = "stocklocationview.description";
            // 
            // txtIdUbicazione
            // 
            this.txtIdUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdUbicazione.Location = new System.Drawing.Point(6, 45);
            this.txtIdUbicazione.Name = "txtIdUbicazione";
            this.txtIdUbicazione.Size = new System.Drawing.Size(112, 20);
            this.txtIdUbicazione.TabIndex = 1;
            this.txtIdUbicazione.Tag = "stockview.stocklocationcode?x";
            // 
            // btnUbicazione
            // 
            this.btnUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUbicazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUbicazione.Location = new System.Drawing.Point(6, 14);
            this.btnUbicazione.Name = "btnUbicazione";
            this.btnUbicazione.Size = new System.Drawing.Size(112, 23);
            this.btnUbicazione.TabIndex = 1;
            this.btnUbicazione.TabStop = false;
            this.btnUbicazione.Tag = "";
            this.btnUbicazione.Text = "Ubicazione";
            this.btnUbicazione.Click += new System.EventHandler(this.btnUbicazione_Click);
            // 
            // FrmModifyInfoStore
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(632, 392);
            this.Controls.Add(this.grpUbicazione);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpDettaglio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmModifyInfoStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica informazioni Magazzino";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAskInfoStore_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModifyInfoStore_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.grpDettaglio.ResumeLayout(false);
            this.grpDettaglio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


        bool has_expiry = false;

		private void FrmAskInfoStore_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (e.Cancel==true) return;
			if (DialogResult == DialogResult.Cancel) return;
            // Varifica il magazzino
            if (cmbMagazzino.SelectedValue == null) {
               show(this, "Non è stato inserito il magazzino", "Avviso");
               cmbMagazzino.Focus();
               e.Cancel = true;
               return; 
            }
            else 
                idstore = cmbMagazzino.SelectedValue;

            // Verifica la data se ammessa
            if (has_expiry && (txtExpiry.Text == "")){
                show(this, "Non è stato inserita la data scadenza", "Avviso");
                e.Cancel = true;
                return;
            }
            else 
                    expiry = HelpForm.GetObjectFromString(typeof(DateTime),txtExpiry.Text.ToString(), "x.y");

    	}

        private void RiempiControlli (DataRow RStockview) {
            grpDettaglio.Enabled = false;
            if (RStockview == null) return;
            txtDescrizioneListino.Text = RStockview["list"].ToString();
            txtListino.Text = RStockview["intcode"].ToString();
            DataRow Rlist = Conn.RUN_SELECT("list", "*", null, QHS.CmpEq("idlist",RStockview["idlist"]), null, true).Rows[0];
            FreshLogo(Rlist);

            HelpForm.SetComboBoxValue(cmbMagazzino, RStockview["idstore"]);
            cmbMagazzino.Enabled = (RStockview["idmankind"] == DBNull.Value);
            if (RStockview["expiry"] != DBNull.Value){
                DateTime Texpiry = (DateTime)RStockview["expiry"];
                txtExpiry.Text = Texpiry.ToShortDateString();
            }
            has_expiry = (Rlist["has_expiry"].ToString() != "S")? false : true;
            txtIdUbicazione.Text = RStockview["stocklocationcode"].ToString();
            txtDescUbicazione.Text = RStockview["stocklocation"].ToString();

            idstocklocation = RStockview["idstocklocation"];
           
        }

        void FreshLogo (DataRow RList) {
            if (RList == null) return;

            try {
                if (RList["pic"] != DBNull.Value) {
                    MemoryStream MS = new MemoryStream((byte[])RList["pic"]);
                    Image IM = new Bitmap(MS, false);
                    pbox.Image = IM;
                }
                else {
                    pbox.Image = null;
                }
            }
            catch {
                pbox.Image = null;
            }
        }

      private void txtExpiry_Leave(object sender, EventArgs e){
          HelpForm.ExtLeaveDateTimeTextBox(txtExpiry, null);
      }

      private void btnUbicazione_Click(object sender, EventArgs e){
          MetaData MetaLocation;
          MetaLocation = Disp.Get("stocklocationview");
          MetaLocation.FilterLocked = true;
          MetaLocation.SearchEnabled = false;
          MetaLocation.MainSelectionEnabled = true;
          string edittype;
          edittype = "tree";

          bool res = MetaLocation.Edit(this, edittype, true);
          if (!res) return;
          Selected = MetaLocation.LastSelectedRow;
          riempiTextBox(Selected);
          idstocklocation = Selected["idstocklocation"];
      }
      private void riempiTextBox(DataRow UbiRow){
          txtIdUbicazione.Text = (UbiRow != null) ? UbiRow["stocklocationcode"].ToString() : "";
          txtDescUbicazione.Text = (UbiRow != null) ? UbiRow["description"].ToString() : "";
      }

        private void FrmModifyInfoStore_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
