
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
using AskInfo;

namespace invoice_default {
	/// <summary>
	/// Summary description for FrmAskInfo.
	/// </summary>
    public class FrmAskInfo : MetaDataForm {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.Button btnCausale;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		DataAccess Conn;
        MetaData Meta;
		private System.Windows.Forms.TextBox txtDescrCausale;
		string filtroEP = "";
		private System.Windows.Forms.GroupBox gboxMotive;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        MetaData MetaUPB;
        MetaData MetaAccmotive;

        private GroupBox gboxUPB;
        private Button btnUPB;
        private TextBox txtUPB;
        private TextBox txtDescrUPB;

        CQueryHelper QHC;
        QueryHelper QHS;

        public UPB_SelectionManager selUPB;
        public Accmotiveapplied_SelectionManager selAccmotive;

        public FrmAskInfo EnableUPBSelection(bool enable) {
            txtUPB.ReadOnly = !enable;
            txtUPB.TabStop = enable;
            btnUPB.Enabled = enable;
            return this;
        }

        public FrmAskInfo EnableAccmotiveSelection(bool enable) {
            txtCodiceCausale.ReadOnly = !enable;
            txtCodiceCausale.TabStop = enable;
            btnCausale.Enabled = enable;
            return this;
        }


		public FrmAskInfo(MetaData Meta,object idacc, object idupb, string filtroEP, bool usaScritture) {
			InitializeComponent();

            this.Meta = Meta;
            this.Conn = Meta.Conn;
            this.MetaUPB = Meta.Dispatcher.Get("upb");
            this.MetaAccmotive = Meta.Dispatcher.Get("accmotiveapplied");

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			this.filtroEP = filtroEP;

            selUPB = new UPB_SelectionManager(Meta, txtUPB, txtDescrUPB);
            if (idupb != DBNull.Value) {
                selUPB.SetValue(idupb);
                EnableUPBSelection(false);
            }
            else {
                EnableUPBSelection(true);
                btnUPB.Click += new EventHandler(btnUPB_Click);

            }

            string filter2 = QHS.AppAnd(filtroEP, QHS.CmpEq("active","S"),QHS.CmpEq("in_use", 'S'));
            selAccmotive = new Accmotiveapplied_SelectionManager(Meta, txtCodiceCausale, txtDescrCausale);
            selAccmotive.SetFilter(filter2);
            if (idacc != DBNull.Value) {
                selAccmotive.SetValue(idacc);
                EnableAccmotiveSelection(false);
            }
            else {                
                EnableAccmotiveSelection(usaScritture);
                btnCausale.Click +=new EventHandler(btnCausale_Click);
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
            this.label1 = new System.Windows.Forms.Label();
            this.gboxMotive = new System.Windows.Forms.GroupBox();
            this.txtDescrCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.btnCausale = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxMotive.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Informazioni necessarie";
            // 
            // gboxMotive
            // 
            this.gboxMotive.Controls.Add(this.txtDescrCausale);
            this.gboxMotive.Controls.Add(this.txtCodiceCausale);
            this.gboxMotive.Controls.Add(this.btnCausale);
            this.gboxMotive.Location = new System.Drawing.Point(12, 163);
            this.gboxMotive.Name = "gboxMotive";
            this.gboxMotive.Size = new System.Drawing.Size(485, 110);
            this.gboxMotive.TabIndex = 10;
            this.gboxMotive.TabStop = false;
            this.gboxMotive.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.gboxMotive.Text = "Causale";
            // 
            // txtDescrCausale
            // 
            this.txtDescrCausale.Location = new System.Drawing.Point(136, 16);
            this.txtDescrCausale.Multiline = true;
            this.txtDescrCausale.Name = "txtDescrCausale";
            this.txtDescrCausale.ReadOnly = true;
            this.txtDescrCausale.Size = new System.Drawing.Size(327, 56);
            this.txtDescrCausale.TabIndex = 2;
            this.txtDescrCausale.TabStop = false;
            this.txtDescrCausale.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(12, 74);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(451, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
            // 
            // btnCausale
            // 
            this.btnCausale.Location = new System.Drawing.Point(12, 45);
            this.btnCausale.Name = "btnCausale";
            this.btnCausale.Size = new System.Drawing.Size(104, 23);
            this.btnCausale.TabIndex = 0;
            this.btnCausale.Tag = "manage.accmotiveapplied.tree";
            this.btnCausale.Text = "Causale";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(186, 279);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(282, 279);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(12, 27);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(485, 111);
            this.gboxUPB.TabIndex = 13;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(8, 56);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(75, 23);
            this.btnUPB.TabIndex = 14;
            this.btnUPB.Text = "UPB";
            this.btnUPB.UseVisualStyleBackColor = true;
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 85);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(469, 20);
            this.txtUPB.TabIndex = 13;
            this.txtUPB.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 16);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(341, 63);
            this.txtDescrUPB.TabIndex = 12;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "";
            // 
            // FrmAskInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(509, 314);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gboxMotive);
            this.Controls.Add(this.label1);
            this.Name = "FrmAskInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selezione UPB e Causale";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAskInfo_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskInfo_FormClosing);
            this.gboxMotive.ResumeLayout(false);
            this.gboxMotive.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnUPB_Click(object sender, System.EventArgs e) {
            chiamaFormUPB("(active='S')");
        }

        private void chiamaFormUPB(string filtro) {
            MetaData mUPB = MetaUPB.Dispatcher.Get("upb");

            mUPB.FilterLocked = true;
            mUPB.SearchEnabled = false;
            mUPB.MainSelectionEnabled = true;
            mUPB.StartFilter = filtro;
            mUPB.ExtraParameter = filtro;
            string edittype = "tree";
            bool res = mUPB.Edit(this, edittype, true);
            if (!res) {
                mUPB.Destroy();
                return;
            }
            DataRow Selected = mUPB.LastSelectedRow;
            selUPB.SelectRow(Selected);
            mUPB.Destroy();
        }


		private void btnCausale_Click(object sender, System.EventArgs e) {
            MetaData mAccMot = MetaAccmotive.Dispatcher.Get("accmotiveapplied");

            mAccMot.FilterLocked = true;
            mAccMot.SearchEnabled = false;
            mAccMot.MainSelectionEnabled = true;
            mAccMot.StartFilter = null;
            mAccMot.ExtraParameter = filtroEP;
			string edittype="tree";
            bool res = mAccMot.Edit(this, edittype, true);
            if (!res) {
                mAccMot.Destroy();
                return;
            }
            DataRow Selected = mAccMot.LastSelectedRow;
			selAccmotive.SelectRow(Selected);
            mAccMot.Destroy();
        }




		private void FrmAskInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (e.Cancel==true) return;
			if (DialogResult == DialogResult.Cancel) return;
            if (selAccmotive.GetValue()==DBNull.Value){
                DialogResult dr = show(this, "Non è stata inserita la causale; si vuole proseguire ugualmente?", "Avviso", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) {
                    txtCodiceCausale.Focus();
                    e.Cancel = true;
                    return;
                }
            }
		}

        private void FrmAskInfo_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
