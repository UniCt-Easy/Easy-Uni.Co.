
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
using metadatalibrary;
using System.IO;
using System.Data;

namespace invoice_default {
	/// <summary>
    /// Summary description for FrmAskInfoExpiry.
    ///
  public class FrmAskInfoExpiry : MetaDataForm {
  private System.Windows.Forms.Button btnOk;
  private System.Windows.Forms.Button btnAnnulla;
  DataAccess Conn;
  MetaDataDispatcher Disp;

  /// <summary>
		/// Required designer variable.
		/// </summary>
private System.ComponentModel.Container components = null;
      QueryHelper QHS;
      private GroupBox grpDettaglio;
      private GroupBox groupBox1;
      CQueryHelper QHC;
      private Label label3;
      private TextBox txtExpiry;
      private TextBox txtDescrizione;
      private Label label1;
      private TextBox txtListino;
      private TextBox txtDescrizioneListino;
      private Label label2;
      private PictureBox pbox;
      public object expiry;
      public FrmAskInfoExpiry (MetaDataDispatcher Disp, DataRow RInvDet, DataRow RList) {
          InitializeComponent();

          this.Disp = Disp;
          this.Conn = Disp.Conn;

          QHC = new CQueryHelper();
          QHS = Conn.GetQueryHelper();

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
            this.grpDettaglio = new System.Windows.Forms.GroupBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.grpDettaglio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(450, 282);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(546, 282);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // grpDettaglio
            // 
            this.grpDettaglio.Controls.Add(this.pbox);
            this.grpDettaglio.Controls.Add(this.label2);
            this.grpDettaglio.Controls.Add(this.txtListino);
            this.grpDettaglio.Controls.Add(this.txtDescrizioneListino);
            this.grpDettaglio.Controls.Add(this.txtDescrizione);
            this.grpDettaglio.Controls.Add(this.label1);
            this.grpDettaglio.Location = new System.Drawing.Point(11, 86);
            this.grpDettaglio.Name = "grpDettaglio";
            this.grpDettaglio.Size = new System.Drawing.Size(610, 187);
            this.grpDettaglio.TabIndex = 13;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtExpiry);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 73);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleziona";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Scadenza:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(116, 22);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(133, 20);
            this.txtExpiry.TabIndex = 2;
            this.txtExpiry.Tag = "";
            this.txtExpiry.Leave += new System.EventHandler(this.txtExpiry_Leave);
            // 
            // FrmAskInfoExpiry
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(633, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDettaglio);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfoExpiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione Data Scadenza";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAskInfoExpiry_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskInfoExpiry_FormClosing);
            this.grpDettaglio.ResumeLayout(false);
            this.grpDettaglio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion



		private void FrmAskInfoExpiry_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (e.Cancel==true) return;
			if (DialogResult == DialogResult.Cancel) return;
            if (txtExpiry.Text == "") {
                show(this, "Non Ã¨ stato inserita la data scadenza", "Avviso");
                e.Cancel = true;
                return;
            }
            else expiry = HelpForm.GetObjectFromString(typeof(DateTime),
                 txtExpiry.Text.ToString(), "x.y");
		}


      private void RiempiControlli (DataRow RInvDet, DataRow RList) {
            if (RInvDet == null) return;
            txtDescrizione.Text = RInvDet["detaildescription"].ToString();
            txtDescrizioneListino.Text = RList["description"].ToString();
            txtListino.Text = RList["intcode"].ToString();
            grpDettaglio.Enabled = false;
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

      private void txtExpiry_Leave (object sender, EventArgs e) {
          HelpForm.ExtLeaveDateTimeTextBox(txtExpiry, null);
      }

      public bool DatiValidi () {
        
          try {
              DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                  txtExpiry.Text.ToString(), "x.y");
              return true;
          }
          catch {
              show("E' necessario inserire una data valida");
              txtExpiry.Focus();
              return false;
          }
      }

        private void FrmAskInfoExpiry_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
