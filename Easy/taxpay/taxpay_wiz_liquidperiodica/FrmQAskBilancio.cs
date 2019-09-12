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

namespace taxpay_wiz_liquidperiodica{//liquidazioneritenuta//
	/// <summary>
	/// Summary description for FrmAskBilancio.
	/// </summary>
	public class FrmAskBilancio : System.Windows.Forms.Form {
		MetaDataDispatcher Disp;
		DataAccess Conn;
		private DataRow SelectedUpb;
		public DataRow Selected;
		bool InChiusura = false;
		object upbParent;
		object finParent;
		MetaData MetaUpb;
		MetaData Meta;
		DataTable upb;
		decimal importo;
		DataTable finview;
		DataTable responsabile;

		private System.Windows.Forms.Button BtnAnnulla;
		private System.Windows.Forms.Button btnOk;
		public System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkListManager;
		private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.Button btnBilancio;
		public System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox groupBox4;
		public System.Windows.Forms.ComboBox cmbResponsabile;
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

		public FrmAskBilancio(object upbParent, object finParent, decimal importoLiquidazione,
			MetaDataDispatcher Disp, DataAccess Conn) {
			InitializeComponent();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			this.upbParent = upbParent;
			this.finParent = finParent;
			this.Disp = Disp;
			this.Conn = Conn;
			this.importo = importoLiquidazione;

			MetaUpb = Disp.Get("upb");
			Meta = Disp.Get("finview");

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

			responsabile = DataAccess.CreateTableByName(Meta.Conn, "manager", "*");
			GetData.MarkToAddBlankRow(responsabile);
			GetData.Add_Blank_Row(responsabile);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, responsabile, null, null, null, true);

			cmbResponsabile.DataSource = responsabile;
			cmbResponsabile.ValueMember = "idman";
			cmbResponsabile.DisplayMember = "title";

			Selected = null;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			InChiusura = true;
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
			this.chkListTitle = new System.Windows.Forms.CheckBox();
			this.chkListManager = new System.Windows.Forms.CheckBox();
			this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
			this.btnBilancio = new System.Windows.Forms.Button();
			this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
			this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cmbResponsabile = new System.Windows.Forms.ComboBox();
			this.grpUpb = new System.Windows.Forms.GroupBox();
			this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
			this.btnUpb = new System.Windows.Forms.Button();
			this.cmbUpb = new System.Windows.Forms.ComboBox();
			this.grpBilancio.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.grpUpb.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnAnnulla
			// 
			this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnAnnulla.Location = new System.Drawing.Point(344, 248);
			this.BtnAnnulla.Name = "BtnAnnulla";
			this.BtnAnnulla.TabIndex = 9;
			this.BtnAnnulla.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(56, 248);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "Ok";
			// 
			// grpBilancio
			// 
			this.grpBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBilancio.Controls.Add(this.chkListTitle);
			this.grpBilancio.Controls.Add(this.chkListManager);
			this.grpBilancio.Controls.Add(this.chkFilterAvailable);
			this.grpBilancio.Controls.Add(this.btnBilancio);
			this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
			this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
			this.grpBilancio.Location = new System.Drawing.Point(32, 120);
			this.grpBilancio.Name = "grpBilancio";
			this.grpBilancio.Size = new System.Drawing.Size(416, 120);
			this.grpBilancio.TabIndex = 26;
			this.grpBilancio.TabStop = false;
			this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
			// 
			// chkListTitle
			// 
			this.chkListTitle.Location = new System.Drawing.Point(8, 48);
			this.chkListTitle.Name = "chkListTitle";
			this.chkListTitle.Size = new System.Drawing.Size(296, 16);
			this.chkListTitle.TabIndex = 15;
			this.chkListTitle.TabStop = false;
			this.chkListTitle.Text = "Cerca per denominazione";
			// 
			// chkListManager
			// 
			this.chkListManager.Location = new System.Drawing.Point(8, 32);
			this.chkListManager.Name = "chkListManager";
			this.chkListManager.Size = new System.Drawing.Size(288, 16);
			this.chkListManager.TabIndex = 14;
			this.chkListManager.TabStop = false;
			this.chkListManager.Text = "Elenca per responsabile";
			// 
			// chkFilterAvailable
			// 
			this.chkFilterAvailable.Checked = true;
			this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFilterAvailable.Location = new System.Drawing.Point(8, 16);
			this.chkFilterAvailable.Name = "chkFilterAvailable";
			this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
			this.chkFilterAvailable.TabIndex = 13;
			this.chkFilterAvailable.TabStop = false;
			this.chkFilterAvailable.Text = "Filtra per disponibilità sufficiente";
			// 
			// btnBilancio
			// 
			this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
			this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancio.ImageIndex = 0;
			this.btnBilancio.Location = new System.Drawing.Point(8, 64);
			this.btnBilancio.Name = "btnBilancio";
			this.btnBilancio.Size = new System.Drawing.Size(120, 23);
			this.btnBilancio.TabIndex = 1;
			this.btnBilancio.TabStop = false;
			this.btnBilancio.Tag = "";
			this.btnBilancio.Text = "Bilancio:";
			this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
			// 
			// txtCodiceBilancio
			// 
			this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 88);
			this.txtCodiceBilancio.Name = "txtCodiceBilancio";
			this.txtCodiceBilancio.Size = new System.Drawing.Size(120, 20);
			this.txtCodiceBilancio.TabIndex = 0;
			this.txtCodiceBilancio.Tag = "";
			this.txtCodiceBilancio.Text = "";
			this.txtCodiceBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
			// 
			// txtDenominazioneBilancio
			// 
			this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneBilancio.Location = new System.Drawing.Point(144, 64);
			this.txtDenominazioneBilancio.Multiline = true;
			this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
			this.txtDenominazioneBilancio.ReadOnly = true;
			this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneBilancio.Size = new System.Drawing.Size(264, 48);
			this.txtDenominazioneBilancio.TabIndex = 2;
			this.txtDenominazioneBilancio.TabStop = false;
			this.txtDenominazioneBilancio.Tag = "";
			this.txtDenominazioneBilancio.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cmbResponsabile);
			this.groupBox4.Location = new System.Drawing.Point(32, 80);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(416, 40);
			this.groupBox4.TabIndex = 25;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Responsabile";
			// 
			// cmbResponsabile
			// 
			this.cmbResponsabile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbResponsabile.Location = new System.Drawing.Point(8, 16);
			this.cmbResponsabile.Name = "cmbResponsabile";
			this.cmbResponsabile.Size = new System.Drawing.Size(400, 21);
			this.cmbResponsabile.TabIndex = 0;
			this.cmbResponsabile.Tag = "";
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
			this.txtDescrizioneUpb.Text = "";
			// 
			// btnUpb
			// 
			this.btnUpb.BackColor = System.Drawing.SystemColors.Control;
			this.btnUpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUpb.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUpb.Location = new System.Drawing.Point(8, 16);
			this.btnUpb.Name = "btnUpb";
			this.btnUpb.Size = new System.Drawing.Size(120, 23);
			this.btnUpb.TabIndex = 4;
			this.btnUpb.TabStop = false;
			this.btnUpb.Tag = "";
			this.btnUpb.Text = "UPB:";
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
			// FrmAskBilancio
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 278);
			this.Controls.Add(this.grpBilancio);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.grpUpb);
			this.Controls.Add(this.BtnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Name = "FrmAskBilancio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seleziona Voce Bilancio";
			this.grpBilancio.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.grpUpb.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;

			int esercizio = (int)Meta.GetSys("esercizio");
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
						
			//Il filtro sull'UPB c'è sempre
			if (cmbUpb.SelectedIndex>0){
                filter = QHS.CmpEq("idupb", cmbUpb.SelectedValue);
			}
			else {
                filter = QHS.CmpEq("idupb", "0001");
			}
			filter= QHS.AppAnd(filteridfin,filter);
			
			//Aggiunge eventualmente il filtro sul disponibile
			if (chkFilterAvailable.Checked){
				decimal currval = importo;
				filter=QHS.AppAnd(filter,QHS.CmpGe("availableprevision",currval));
			}
            string filteroperativo = QHS.FieldInList("idfin",
                        "SELECT idfin from finusable where " + QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			if (chkListManager.Checked){
				if (cmbResponsabile.SelectedIndex>0){
                    filter = QHS.AppAnd(filter, QHS.CmpGe("idman", cmbResponsabile.SelectedValue));
				}
				else {
                    filter = QHS.AppAnd(filter, QHS.IsNull("idman"));
				}
				Meta.FilterLocked = true;
				Meta.StartFilter = null;
				Meta.ExtraParameter = null;
				Meta.DS=null;
				filter = QHS.AppAnd(filter,filteroperativo);
				Selected = Meta.SelectOne("default",filter,"finview",null);
				riempiTextBox(Selected);
				return;
			}

			if (chkListTitle.Checked){
				FrmAskDescr FR= new FrmAskDescr(0);
				DialogResult D = FR.ShowDialog(this);
				if (D!= DialogResult.OK) return;
                filter = QHS.AppAnd(filter,QHS.Like("title", "%" + FR.txtDescrizione.Text + "%"));
				Meta.FilterLocked = true;
				Meta.StartFilter = null;
				Meta.ExtraParameter = null;
				Meta.DS=null;
				filter= GetData.MergeFilters(filter,filteroperativo);
				Selected = Meta.SelectOne("default",filter,"finview",null);
				riempiTextBox(Selected);
				return;
			}

			chiamaFormBilancio(filter);

//			MetaData Meta = Disp.Get("finview");
//			string filtro = "(ayear = " + Meta.GetSys("esercizio") + ") AND (finpart = 'S')";
//			Meta.FilterLocked = true;
//			Meta.SearchEnabled = false;
//			Meta.MainSelectionEnabled = true;
//
//			filtro = GetData.MergeFilters(filtro,"(idupb="+QueryCreator.quotedstrvalue(filter_upb,true)+")");
//			Meta.StartFilter = filtro;	
//
//			bool res = Meta.Edit(this,  "treesupb", true); 
//			if (!res) return;
//			Selected = Meta.LastSelectedRow;
//			riempiTextBox(Selected);
		}

		private void chiamaFormBilancio(string filtro) {
			Meta.FilterLocked = true;
			Meta.SearchEnabled = false;
			Meta.MainSelectionEnabled = true;
			Meta.StartFilter = filtro;
			Meta.ExtraParameter = filtro;
			string edittype = "treesupb";
			bool res = Meta.Edit(this, edittype, true);
			if (!res) return;
			Selected = Meta.LastSelectedRow;
			riempiTextBox(Selected);
		}
		
		private void riempiTextBox(DataRow finRow) {
			txtCodiceBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
			txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
		}

		private void riempiInfoUpb(DataRow upbRow) {
			if (cmbUpb.ValueMember == "") return;
			txtDescrizioneUpb.Text = (upbRow != null) ? upbRow["title"].ToString() : "";
			cmbUpb.SelectedValue = (upbRow != null) ? upbRow["idupb"] :DBNull.Value;
			if ((upbRow != null) && (upbRow["idman"] != DBNull.Value)) {
				cmbResponsabile.SelectedValue = upbRow["idman"];
			}
		}

		private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;

			if (txtCodiceBilancio.Text.Trim()=="") {
				Selected=null;
				riempiTextBox(Selected);
				return;
			}
            string filterUpb = "";
			if (cmbUpb.SelectedIndex > 0) {
                filterUpb = QHS.CmpEq("idupb", cmbUpb.SelectedValue);
			}
			else {
				filterUpb = QHS.CmpEq("idupb", "0001");
			}

            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                        QHS.BitSet("flag", 0), filterUpb);

			Meta.FilterLocked = true;
			Meta.SearchEnabled = false;
			Meta.MainSelectionEnabled = true;
			Meta.StartFilter = filtro;
			Meta.ExtraParameter = filtro;
			Meta.StartFieldWanted = "codefin";
			Meta.StartValueWanted = null;

			Meta.StartValueWanted = txtCodiceBilancio.Text.Trim();
			string startfield = Meta.StartFieldWanted;
			string startvalue = Meta.StartValueWanted;

			if (startvalue != null) {
				//try to load a row directly, without opening a new form		
				string stripped=startvalue;
				if (stripped.EndsWith("%")) stripped=stripped.TrimEnd(new Char[] {'%'});
                string filter2 = QHS.AppAnd(filtro, QHS.CmpEq(startfield, stripped));                    
				//Meta.myGetData= myGetData;
				Selected= Meta.SelectByCondition(filter2, "finview");
			}

			if (Selected==null) {
				string edittype = "treesupb";
				bool res = Meta.Edit(this, edittype, true);
				if (!res) {
					return;
				}
				Selected = Meta.LastSelectedRow;
			}

			riempiTextBox(Selected);
//			if (InChiusura) return;
//
//			if (txtCodiceBilancio.Text.Trim()==""){
//				Selected=null;
//				riempiTextBox(null);
//				return;
//			}
//
//			MetaData Meta = Disp.Get("finview");
//			string filtro = "(ayear = " + Meta.GetSys("esercizio") + ") AND (finpart = 'S')";
//			
//			filtro = GetData.MergeFilters(filtro,"(idupb="+QueryCreator.quotedstrvalue(filter_upb,true)+")");
//
//			Meta.FilterLocked = true;
//			Meta.SearchEnabled = false;
//			Meta.MainSelectionEnabled = true;
//			Meta.StartFilter = filtro;
//			Meta.StartFieldWanted = "codefin";
//			Meta.StartValueWanted = null;
//
//			Meta.StartValueWanted = txtCodiceBilancio.Text.Trim();
//			string startfield = Meta.StartFieldWanted;
//			string startvalue = Meta.StartValueWanted;
//
//			if (startvalue != null) {
//				//try to load a row directly, without opening a new form		
//				string stripped=startvalue;
//				if (stripped.EndsWith("%")) stripped=stripped.TrimEnd(new Char[] {'%'});
//				string filter2 = GetData.MergeFilters(filtro,"("+startfield+"='"+stripped+"')");			
//				//Meta.myGetData= myGetData;
//				Selected= Meta.SelectByCondition(filter2, "finview");
//			}
//
//			if (Selected==null) {
//				bool res = Meta.Edit(this, "treesupb", true);
//				if (!res) {
//					return;
//				}
//				Selected = Meta.LastSelectedRow;
//			}
//
//			riempiTextBox(Selected);
		}

		private void btnUpb_Click(object sender, System.EventArgs e) {
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
			if (MetaUpb == null) return;
			if (cmbUpb.SelectedIndex <= 0) {
				riempiInfoUpb(null);
				finview.Clear();
				riempiTextBox(null);
				return;
			}
            string filter = QHC.CmpEq("idupb", cmbUpb.SelectedValue);
			DataRow [] rUpb = upb.Select(filter);
			SelectedUpb = (rUpb.Length > 0) ? rUpb[0] : null;
			riempiInfoUpb(SelectedUpb);
			// Ogni volta che cambio l'UPB devo azzerare il bilancio
			finview.Clear();
			riempiTextBox(null);
		}
	}
}
