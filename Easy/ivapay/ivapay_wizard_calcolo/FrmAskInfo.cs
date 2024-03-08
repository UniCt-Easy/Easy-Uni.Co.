
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
using System.Data;

namespace ivapay_wizard_calcolo{ 
	/// <summary>
	/// Summary description for FrmAskBilancio.
	/// </summary>
	public class FrmAskInfo : MetaDataForm {
		MetaDataDispatcher Disp;
		DataAccess Conn;
		public DataRow SelectedUpb;
		
		object upbParent;
		object finParent;
		
		DataTable upb;
		
		DataTable finview;

		private System.Windows.Forms.Button BtnAnnulla;
		private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.Button btnBilancio;
		public System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		public System.Windows.Forms.GroupBox grpUpb;
		private System.Windows.Forms.TextBox txtDescrizioneUpb;
		private System.Windows.Forms.Button btnUpb;
		private System.Windows.Forms.ComboBox cmbUpb;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAskInfo( object upbParent, object finParent,
			MetaDataDispatcher Disp, DataAccess Conn) {
			InitializeComponent();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			this.upbParent = upbParent;
			this.finParent = finParent;
			this.Disp = Disp;
			this.Conn = Conn;


			finview = DataAccess.CreateTableByName(Conn, "finview", "*");
			upb = DataAccess.CreateTableByName(Conn, "upb", "*");
			GetData.MarkToAddBlankRow(upb);
			GetData.Add_Blank_Row(upb);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, upb, null, null, null, true);
			
			cmbUpb.DataSource = upb;
			cmbUpb.ValueMember = "idupb";
			cmbUpb.DisplayMember = "codeupb";

			if (upbParent != DBNull.Value){
                string filterUpb = QHC.CmpEq("idupb", upbParent);
				DataRow UPBRow = upb.Select(filterUpb)[0];
				txtDescrizioneUpb.Text= UPBRow["title"].ToString();
				HelpForm.SetComboBoxValue(cmbUpb, upbParent);

				if (finParent != DBNull.Value) {
                    string filterFinView = QHS.AppAnd(QHS.CmpEq("idfin", finParent), QHS.CmpEq("idupb", upbParent));
					DataAccess.RUN_SELECT_INTO_TABLE(Conn, finview, null, filterFinView, null, true);
		
					if (finview.Rows.Count>0){
						DataRow finRow = finview.Rows[0];
						txtCodiceBilancio.Text = finRow["codefin"].ToString();
						txtDenominazioneBilancio.Text=finRow["title"].ToString();
					}
				}
			}

            SelectedUpb = null;
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
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.grpUpb = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.btnUpb = new System.Windows.Forms.Button();
            this.cmbUpb = new System.Windows.Forms.ComboBox();
            this.grpBilancio.SuspendLayout();
            this.grpUpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(373, 189);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 9;
            this.BtnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(270, 189);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            // 
            // grpBilancio
            // 
            this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
            this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
            this.grpBilancio.Enabled = false;
            this.grpBilancio.Location = new System.Drawing.Point(32, 86);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(416, 78);
            this.grpBilancio.TabIndex = 26;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Enabled = false;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(10, 19);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(120, 23);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.UseVisualStyleBackColor = false;
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Enabled = false;
            this.txtCodiceBilancio.Location = new System.Drawing.Point(10, 43);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceBilancio.TabIndex = 0;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(146, 19);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(264, 48);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // grpUpb
            // 
            this.grpUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUpb.Controls.Add(this.txtDescrizioneUpb);
            this.grpUpb.Controls.Add(this.btnUpb);
            this.grpUpb.Controls.Add(this.cmbUpb);
            this.grpUpb.Location = new System.Drawing.Point(32, 8);
            this.grpUpb.Name = "grpUpb";
            this.grpUpb.Size = new System.Drawing.Size(416, 72);
            this.grpUpb.TabIndex = 24;
            this.grpUpb.TabStop = false;
            this.grpUpb.Tag = "";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(144, 16);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(264, 48);
            this.txtDescrizioneUpb.TabIndex = 5;
            this.txtDescrizioneUpb.TabStop = false;
            this.txtDescrizioneUpb.Tag = "";
            // 
            // btnUpb
            // 
            this.btnUpb.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb.Location = new System.Drawing.Point(8, 16);
            this.btnUpb.Name = "btnUpb";
            this.btnUpb.Size = new System.Drawing.Size(120, 23);
            this.btnUpb.TabIndex = 4;
            this.btnUpb.TabStop = false;
            this.btnUpb.Tag = "";
            this.btnUpb.Text = "UPB:";
            this.btnUpb.UseVisualStyleBackColor = false;
            this.btnUpb.Click += new System.EventHandler(this.btnUpb_Click);
            // 
            // cmbUpb
            // 
            this.cmbUpb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpb.Location = new System.Drawing.Point(8, 40);
            this.cmbUpb.Name = "cmbUpb";
            this.cmbUpb.Size = new System.Drawing.Size(121, 21);
            this.cmbUpb.TabIndex = 3;
            this.cmbUpb.Tag = "";
            this.cmbUpb.SelectedIndexChanged += new System.EventHandler(this.cmbUpb_SelectedIndexChanged);
            // 
            // FrmAskInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(488, 224);
            this.Controls.Add(this.grpBilancio);
            this.Controls.Add(this.grpUpb);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleziona UPB";
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.grpUpb.ResumeLayout(false);
            this.grpUpb.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		
		private void riempiTextBox(DataRow finRow) {
			txtCodiceBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
			txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
		}

		private void riempiInfoUpb(DataRow upbRow) {
			if (cmbUpb.ValueMember == "") return;
			txtDescrizioneUpb.Text = (upbRow != null) ? upbRow["title"].ToString() : "";
			cmbUpb.SelectedValue = (upbRow != null) ? upbRow["idupb"] :DBNull.Value;
		}

		private void btnUpb_Click(object sender, System.EventArgs e) {
            MetaData MetaUpb = Disp.Get("upb");

            MetaUpb.FilterLocked = true;
			MetaUpb.SearchEnabled = true;
			MetaUpb.StartFilter = null;

			string edittype = "tree";
			bool res = MetaUpb.Edit(this, edittype, true);
			if (!res) return;
			SelectedUpb = MetaUpb.LastSelectedRow;
			riempiInfoUpb(SelectedUpb);
		}

		private void cmbUpb_SelectedIndexChanged(object sender, System.EventArgs e) {
			
			if (cmbUpb.SelectedIndex <= 0) {
				riempiInfoUpb(null);
				return;
			}
            string filter = QHC.CmpEq("idupb", cmbUpb.SelectedValue);
			DataRow [] rUpb = upb.Select(filter);
			SelectedUpb = (rUpb.Length > 0) ? rUpb[0] : null;
			riempiInfoUpb(SelectedUpb);
		}
	}
}
