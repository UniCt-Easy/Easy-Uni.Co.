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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using metadatalibrary;
using System.Data;

namespace invoice_default {
	/// <summary>
    /// Summary description for FrmAskInfoStore.
    ///
  public class FrmAskInfoStore : System.Windows.Forms.Form {
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
      private TextBox txtDescrizione;
      private Label label1;
public object idstore;
      public FrmAskInfoStore(MetaDataDispatcher Disp, DataRow RInvDet,DataRow RList) {
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
          if (RInvDet["idinvkind"] != DBNull.Value) {
              RiempiControlli(RInvDet,RList);
          }
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
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpDettaglio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(447, 276);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(543, 276);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMagazzino);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 60);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleziona";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Magazzino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.Location = new System.Drawing.Point(85, 25);
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
            this.grpDettaglio.Controls.Add(this.txtDescrizione);
            this.grpDettaglio.Controls.Add(this.label1);
            this.grpDettaglio.Location = new System.Drawing.Point(11, 70);
            this.grpDettaglio.Name = "grpDettaglio";
            this.grpDettaglio.Size = new System.Drawing.Size(610, 187);
            this.grpDettaglio.TabIndex = 17;
            this.grpDettaglio.TabStop = false;
            this.grpDettaglio.Text = "Dettaglio Fattura";
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
            this.label2.Location = new System.Drawing.Point(14, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Listino:";
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(17, 145);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(112, 20);
            this.txtListino.TabIndex = 44;
            this.txtListino.Tag = "listview.intcode?invoicedetailview.intcode";
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(135, 107);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(249, 60);
            this.txtDescrizioneListino.TabIndex = 45;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(17, 47);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(367, 54);
            this.txtDescrizione.TabIndex = 41;
            this.txtDescrizione.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Descrizione:";
            // 
            // FrmAskInfoStore
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(632, 309);
            this.Controls.Add(this.grpDettaglio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfoStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione Magazzino";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAskInfoStore_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskInfoStore_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.grpDettaglio.ResumeLayout(false);
            this.grpDettaglio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		private void FrmAskInfoStore_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (e.Cancel==true) return;
			if (DialogResult == DialogResult.Cancel) return;
            if (cmbMagazzino.SelectedValue == null) {
               MessageBox.Show(this, "Non è stato inserito il magazzino", "Avviso");
               cmbMagazzino.Focus();
               e.Cancel = true;
               return; 
            }
            else idstore = cmbMagazzino.SelectedValue;
		}


        private void RiempiControlli (DataRow RInvDet, DataRow RList) {
            if (RInvDet == null) return;
            txtDescrizione.Text = RInvDet["detaildescription"].ToString();
            grpDettaglio.Enabled = false;
            if (RList == null) return;
            txtDescrizioneListino.Text = RList["description"].ToString();
            txtListino.Text = RList["intcode"].ToString();
            FreshLogo(RList);
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

        private void FrmAskInfoStore_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}