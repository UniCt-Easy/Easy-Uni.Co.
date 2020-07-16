/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace expense_wizardmandatedetail
{
	/// <summary>
	/// Summary description for FrmAskInfo.
	/// </summary>
	public class FrmAskInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button BtnAnnulla;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaDataDispatcher Disp;
		MetaData Meta;
		DataAccess Conn;
		//DataSet myDS = new DataSet();
		//GetData myGetData = new GetData();
		public DataRow Selected ;
		public string  IDManagerSelected=null;
        public string  IDUPBSelected = null;
		string E_S;
		string filter_upb;
        bool upbToSelect;
        //string currfilter_upb;
		private System.Windows.Forms.ComboBox cmbResponsabile;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkListManager;
		private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		bool InChiusura = false;
		private System.Windows.Forms.GroupBox gboxManager;
		decimal importo;
        private GroupBox gboxUPB;
        private ComboBox cmbUPB;
		object idmanager;

        CQueryHelper QHC;
        private TextBox txtUPB;
        QueryHelper QHS;
		public FrmAskInfo(string E_S,string filter_upb,MetaDataDispatcher Disp,
			object idmanager,
			decimal importo,
            bool    upbToSelect) {
			InitializeComponent();

			this.E_S = E_S;
			this.filter_upb = filter_upb;
            //this.currfilter_upb = filter_upb;
			this.Disp = Disp;
			this.Conn = Disp.Conn;
			this.importo= importo;
			this.idmanager=idmanager;
            this.upbToSelect = upbToSelect;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			SubEntity_txtImportoMovimento.Text=importo.ToString("c");
			Selected = null;

			DataTable responsabile= Conn.CreateTableByName("manager","*",false);
			DataSet D= new DataSet();
			D.Tables.Add(responsabile);
			GetData.MarkToAddBlankRow(responsabile);
			GetData.Add_Blank_Row(responsabile);
			if (idmanager!=null && idmanager!=DBNull.Value){
                Conn.RUN_SELECT_INTO_TABLE(responsabile, "title",
                    QHS.CmpEq("idman", idmanager), null, true);
				cmbResponsabile.Enabled=false;
			}
			else {
				if (idmanager==DBNull.Value){
					Conn.RUN_SELECT_INTO_TABLE(responsabile,"title",QHS.CmpEq("active", "S"),null,true);
				}
				else {
					cmbResponsabile.Enabled=false;
				}
			}
            Conn.DeleteAllUnselectable(responsabile);

            DataTable upb = Conn.CreateTableByName("upb", "*", false);
            D.Tables.Add(upb);
            GetData.MarkToAddBlankRow(upb);
            GetData.Add_Blank_Row(upb);
            if (filter_upb != null && filter_upb != "")
            {
                Conn.RUN_SELECT_INTO_TABLE(upb, "codeupb", filter_upb,null, true);
                cmbUPB.Enabled = false;
                if (upb.Select(filter_upb).Length > 0)
                    txtUPB.Text = upb.Select(filter_upb)[0]["title"].ToString();
            }
            else
            {
                if (upbToSelect)
                {
                    Conn.RUN_SELECT_INTO_TABLE(upb, "codeupb", QHS.CmpEq("active", "S"), null, true);
                }
                else
                {
                    cmbUPB.Enabled = false;
                }
            }

			if (filter_upb==null){
				chkFilterAvailable.Checked=false;
				chkFilterAvailable.Enabled=false;
			}
			cmbResponsabile.DataSource = responsabile;
			cmbResponsabile.ValueMember = "idman";
			cmbResponsabile.DisplayMember = "title";
            if (idmanager != null && idmanager != DBNull.Value && responsabile.Rows.Count>1) cmbResponsabile.SelectedIndex = 1;
            else cmbResponsabile.SelectedIndex = -1;
            cmbUPB.DataSource = upb;
            cmbUPB.ValueMember = "idupb";
            cmbUPB.DisplayMember = "codeupb";
            if (filter_upb != null) cmbUPB.SelectedIndex = 1;
            //Meta = Disp.Get("finview");
            if (filter_upb != null)
                Meta = Disp.Get("finview");
            else 
                Meta = Disp.Get("fin");
            //if (filter_upb == null) {
            //    txtBilancio.Enabled = false;
            //}
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			InChiusura = true;
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
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gboxManager = new System.Windows.Forms.GroupBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkListManager = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.cmbUPB = new System.Windows.Forms.ComboBox();
            this.gboxManager.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(331, 284);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 9;
            this.BtnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(250, 284);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gboxManager
            // 
            this.gboxManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxManager.Controls.Add(this.cmbResponsabile);
            this.gboxManager.Location = new System.Drawing.Point(8, 40);
            this.gboxManager.Name = "gboxManager";
            this.gboxManager.Size = new System.Drawing.Size(399, 40);
            this.gboxManager.TabIndex = 11;
            this.gboxManager.TabStop = false;
            this.gboxManager.Text = "Responsabile";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.ItemHeight = 13;
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 14);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(383, 21);
            this.cmbResponsabile.TabIndex = 1;
            this.cmbResponsabile.Tag = "expense.idman";
            this.cmbResponsabile.ValueMember = "idman";
            this.cmbResponsabile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            this.cmbResponsabile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Location = new System.Drawing.Point(8, 0);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(399, 40);
            this.groupBox18.TabIndex = 12;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo del movimento che sar‡ generato";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(8, 16);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "expenseyear.amount?expenseview.ayearstartamount";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
            this.gboxBilAnnuale.Controls.Add(this.chkListManager);
            this.gboxBilAnnuale.Controls.Add(this.chkFilterAvailable);
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 158);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(399, 104);
            this.gboxBilAnnuale.TabIndex = 13;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 40);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(296, 16);
            this.chkListTitle.TabIndex = 12;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(8, 24);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(288, 16);
            this.chkListManager.TabIndex = 11;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 8);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 16);
            this.chkFilterAvailable.TabIndex = 10;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilit‡ sufficiente";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(8, 56);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(8, 80);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(112, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "finview.codefin?expenseview.codefin";
            this.txtBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 56);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(263, 42);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.cmbUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 83);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(399, 71);
            this.gboxUPB.TabIndex = 14;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            this.gboxUPB.Text = "UPB da associare ai dettagli ai quali non Ë stato attribuito";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(188, 17);
            this.txtUPB.Multiline = true;
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(202, 51);
            this.txtUPB.TabIndex = 13;
            this.txtUPB.TabStop = false;
            this.txtUPB.Tag = "";
            // 
            // cmbUPB
            // 
            this.cmbUPB.DisplayMember = "codeupb";
            this.cmbUPB.Location = new System.Drawing.Point(8, 30);
            this.cmbUPB.Name = "cmbUPB";
            this.cmbUPB.Size = new System.Drawing.Size(174, 21);
            this.cmbUPB.TabIndex = 10;
            this.cmbUPB.Tag = "mandatedetail.idupb";
            this.cmbUPB.ValueMember = "idupb";
            this.cmbUPB.SelectedIndexChanged += new System.EventHandler(this.cmbUPB_SelectedIndexChanged);
            this.cmbUPB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
            this.cmbUPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
            // 
            // FrmAskInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(415, 322);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.gboxManager);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Richiesta informazioni";
            this.gboxManager.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;

			int esercizio = (int)Meta.GetSys("esercizio");
            string filterpart = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), filterpart);

			filter= filter_upb;
            //filter = currfilter_upb;
			
			filter= GetData.MergeFilters( filteridfin,filter);
			
			//Aggiunge eventualmente il filtro sul disponibile
			if (chkFilterAvailable.Checked){
				decimal currval = importo;
				filter=GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
			}
			string filteroperativo= "(idfin in (SELECT idfin from finusable where ayear = '"
				+ Meta.GetSys("esercizio") + "'))";
			if (chkListManager.Checked){
				if (cmbResponsabile.SelectedIndex>0){
					filter= GetData.MergeFilters(filter, QHS.CmpEq("idman", cmbResponsabile.SelectedValue));
				}
				else {
					filter= GetData.MergeFilters(filter,QHS.IsNull("idman"));
				}
				Meta.FilterLocked = true;
				filter = GetData.MergeFilters(filter,filteroperativo);
				Selected = Meta.SelectOne("default",filter,"finview",null);
				riempiTextBox(Selected);
				return;
			}

			if (chkListTitle.Checked){
				FrmAskDescr FR= new FrmAskDescr(0);
				DialogResult D = FR.ShowDialog(this);
				if (D!= DialogResult.OK) return;
				/*filter = GetData.MergeFilters(filter,
					"(title like "+QueryCreator.quotedstrvalue(
					"%"+FR.txtDescrizione.Text+"%",true))+")";*/
                filter = QHC.Like("title", '%' + FR.txtDescrizione.Text + '%');
				Meta.FilterLocked = true;
				filter= GetData.MergeFilters(filter,filteroperativo);
				Selected = Meta.SelectOne("default",filter,"finview",null);
				riempiTextBox(Selected);
				return;
			}

			chiamaFormBilancio(filter);
		}


		private void chiamaFormBilancio(string filtro) {
			Meta.FilterLocked = true;
			Meta.SearchEnabled = false;
			Meta.MainSelectionEnabled = true;
			Meta.StartFilter = filtro;
			Meta.ExtraParameter = filtro;
			string edittype;
            //if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            //edittype= "tree" + E_S.ToLower() + "upb";
            if (filter_upb!=null)
                edittype= "tree" + E_S.ToLower() + "upb";
            else 
               edittype= "tree" + E_S.ToLower();
			bool res = Meta.Edit(this, edittype, true);
			if (!res) return;
			Selected = Meta.LastSelectedRow;
			riempiTextBox(Selected);
		}
		
		private void riempiTextBox(DataRow finRow) {
			txtBilancio.Text = (finRow != null) ? finRow["codefin"].ToString() : "";
			txtDenominazioneBilancio.Text = (finRow != null) ? finRow["title"].ToString() : "";
		}




		private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;

			if (txtBilancio.Text.Trim()=="") {
				Selected=null;
				riempiTextBox(Selected);
				return;
			}

            //if ((currfilter_upb == null) || (currfilter_upb == "")) return;
            string filterPart = (E_S == "E") ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0);
            string filtro = QHS.AppAnd(
                QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filterPart),
                filter_upb);
            
			Meta.FilterLocked = true;
			Meta.SearchEnabled = false;
			Meta.MainSelectionEnabled = true;
			Meta.StartFilter = filtro;
			Meta.StartFieldWanted = "codefin";
			Meta.StartValueWanted = null;

			Meta.StartValueWanted = txtBilancio.Text.Trim();
			string startfield = Meta.StartFieldWanted;
			string startvalue = Meta.StartValueWanted;

			if (startvalue != null) {
				//try to load a row directly, without opening a new form		
				string stripped=startvalue;
				if (stripped.EndsWith("%")) stripped=stripped.TrimEnd(new Char[] {'%'});
				string filter2 = GetData.MergeFilters(filtro,"("+startfield+"='"+stripped+"')");			
				//Meta.myGetData= myGetData;
				Selected= Meta.SelectByCondition(filter2, "finview");
			}

			if (Selected==null) {
				string edittype = "tree" + E_S.ToLower() + "upb";
				bool res = Meta.Edit(this, edittype, true);
				if (!res) {
					return;
				}
				Selected = Meta.LastSelectedRow;
			}

			riempiTextBox(Selected);
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
            /*
			if (cmbResponsabile.SelectedIndex<=0 && idmanager!=null) {
				MessageBox.Show("Selezionare un responsabile");
				DialogResult= DialogResult.None;
				return;
			}*/
            if (cmbUPB.SelectedIndex <= 0 && filter_upb == null && upbToSelect)
            {
                MessageBox.Show("Selezionare un UPB");
                DialogResult = DialogResult.None;
                return;
            }
			if (cmbResponsabile.SelectedValue!=null && cmbResponsabile.SelectedIndex>0)
				IDManagerSelected=cmbResponsabile.SelectedValue.ToString();
			else  
				IDManagerSelected=null;
            if (cmbUPB.SelectedValue != null && cmbUPB.SelectedIndex>0)
                IDUPBSelected = cmbUPB.SelectedValue.ToString();
            else
                IDUPBSelected = null;
			if (Selected==null) {
				MessageBox.Show("Selezionare una voce di bilancio");
				DialogResult= DialogResult.None;
			}
		}

        private void cmbUPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_upb != null) return;

            if (!((cmbUPB.SelectedValue == null) || (cmbUPB.SelectedValue.ToString() == "")))
            {
                string currfilter_upb = "(idupb=" + QueryCreator.quotedstrvalue(cmbUPB.SelectedValue, false) + ")";
                object upb = Conn.DO_READ_VALUE("upb", currfilter_upb, "title");
                txtUPB.Text = upb.ToString();
            }
            
        }

        private void cmb_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e) {
            //Se Ë stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if ((e.KeyChar == 27) || (e.KeyChar == 13)) {
                return;
            }

            ComboBox acComboBox = (ComboBox)sender;

            int selectionStart = acComboBox.SelectionStart;
            if (selectionStart > acComboBox.Text.Length) selectionStart = acComboBox.Text.Length;

            //Se il tasto premuto Ë BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8) {
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
            }
            else {
                //Se Ë un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                string ricerca = acComboBox.Text.Substring(0, selectionStart) + e.KeyChar;

                int index = acComboBox.FindString(ricerca);

                if (index != -1) {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < acComboBox.Text.Length) {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                }
                else {
                    //Se invece tale riga non esiste, allora seleziono la riga attuale
                    //dal carattere in posizione selectionStart fino alla fine
                    acComboBox.DroppedDown = true;
                    acComboBox.Select(selectionStart, acComboBox.Text.Length - selectionStart);
                }
            }
            //Forzo l'apertura della tendina per facilitare l'utente nella scelta
            e.Handled = true;
        }

        /// <summary>
        /// Evento generato prima di KeyPress. Lo uso per gestire la pressione dei tasti 
        /// "SINISTRA", "DESTRA", "HOME" e "CANC"
        /// che altrimenti non riuscirei ad intercettare con KeyPress.
        /// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
        /// </summary>
        /// <param name="sender">il ComboBox da gestire</param>
        /// <param name="e">l'evento</param>
        private void cmb_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e) {
            ComboBox acComboBox = (ComboBox)sender;
            int selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode) {
                //Se Ë stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
                break;

                //Se Ë stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                int index = acComboBox.FindString("");
                if (index != -1) {
                    acComboBox.DroppedDown = false;
                    acComboBox.SelectedIndex = index;
                    acComboBox.DroppedDown = true;
                }
                acComboBox.SelectAll();
                break;

                //Se Ë stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                if (acComboBox.Text.Length > selectionStart) {
                    acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                }
                break;

                //Se Ë stato premuto il tasto "HOME" seleziono tutta la riga attuale.
                case Keys.Home:
                acComboBox.SelectAll();
                break;

                default:
                //Altrimenti lascio la gestione di questo evento a .NET
                return;
            }
            e.Handled = true;
        }
	}
}
