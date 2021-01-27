
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using metadatalibrary;

namespace manage_automatismi
{
	/// <summary>
	/// Summary description for AskDescription.
	/// </summary>
	public class AskDescription : System.Windows.Forms.Form
	{
		DataRow riga;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
        bool askFinanziamento;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        private GroupBox gboxFinanziamento;
        private TextBox txtUnderwriting;
        private Button btnFinanziamento;
        public object UnderWritingSelected;
        public object BillSelected;
        MetaDataDispatcher Disp;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable FinanziamentiDisponibili;
        private GroupBox gboxBolletta;
        private TextBox txtNumBolletta;
        private Button btnBolletta;
        DataRow row;
        public AskDescription(DataRow r, int dummy, bool askFinanziamento, MetaDataDispatcher Disp, DataAccess Conn)
		{
			this.riga = r;
			InitializeComponent();
			string descrizione = riga["description"].ToString();
			txtDescrizione.Text = descrizione;
            this.askFinanziamento = askFinanziamento;
            this.Disp = Disp;
            this.row = r;
            this.Conn = Conn;
            this.QHS = Conn.GetQueryHelper();
            this.QHC = new CQueryHelper();
            UnderWritingSelected = DBNull.Value;
            gboxFinanziamento.Visible = askFinanziamento;
            if (askFinanziamento) {
                if (r["idunderwriting"] != DBNull.Value)
                {
                    DataTable T = Conn.CreateTableByName("underwriting", "*");
                    Conn.RUN_SELECT_INTO_TABLE(T, "title asc", QHS.AppAnd(QHS.CmpEq("active", "S"),
                                                                          QHS.CmpEq("idunderwriting", r["idunderwriting"])),null, false);
                    DataRow Selected = null;
                    if (T.Rows.Count > 0)
                        Selected = T.Rows[0];
                    riempiTextBox(Selected);
                    UnderWritingSelected = r["idunderwriting"];
                }
               
                if (r.Table.TableName == "expensevarview")
                {
                    FinanziamentiDisponibili = GetFinanziamentiDisponibili(r["idexp"],
                                    CfgFn.GetNoNullInt32(r["nphase"]));
                    if ((FinanziamentiDisponibili == null) || (FinanziamentiDisponibili.Rows.Count == 0))
                        gboxFinanziamento.Enabled = false;
                }
            }
            else {
                if (!gboxFinanziamento.Visible)
                    MakeSpaceFrom(gboxFinanziamento);
            }
            gboxBolletta.Visible = false;
            MakeSpaceFrom(gboxBolletta);
		}
        string billkind = "";

        public AskDescription(DataRow r, int dummy, bool askFinanziamento, bool askBolletta,
                    MetaDataDispatcher Disp, DataAccess Conn) {
            this.riga = r;
            InitializeComponent();
            string descrizione = riga["description"].ToString();
            txtDescrizione.Text = descrizione;
            this.askFinanziamento = askFinanziamento;
            this.Disp = Disp;
            this.row = r;
            this.Conn = Conn;
            this.QHS = Conn.GetQueryHelper();
            this.QHC = new CQueryHelper();
            UnderWritingSelected = DBNull.Value;
            gboxFinanziamento.Visible = askFinanziamento;
            if (askFinanziamento) {
                if (r["idunderwriting"] != DBNull.Value) {
                    DataTable T = Conn.CreateTableByName("underwriting", "*");
                    Conn.RUN_SELECT_INTO_TABLE(T, "title asc", QHS.AppAnd(QHS.CmpEq("active", "S"),
                                                                          QHS.CmpEq("idunderwriting", r["idunderwriting"])), null, false);
                    DataRow Selected = null;
                    if (T.Rows.Count > 0)
                        Selected = T.Rows[0];
                    riempiTextBox(Selected);
                    UnderWritingSelected = r["idunderwriting"];
                }

                if (r.Table.TableName == "expensevarview") {
                    FinanziamentiDisponibili = GetFinanziamentiDisponibili(r["idexp"],
                                    CfgFn.GetNoNullInt32(r["nphase"]));
                    if ((FinanziamentiDisponibili == null) || (FinanziamentiDisponibili.Rows.Count == 0))
                        gboxFinanziamento.Enabled = false;
                }
            }
            else {
                if (!gboxFinanziamento.Visible)
                    MakeSpaceFrom(gboxFinanziamento);
            }

            if (askBolletta && r.Table.Columns.Contains("nbill")) {                
                if (r.Table.TableName.StartsWith("expense")) {
                    billkind = "D";
                }
                else {
                    billkind = "C";
                }

                if (r["nbill"] != DBNull.Value) {
                    DataTable T = Conn.CreateTableByName("bill", "*");
                    Conn.RUN_SELECT_INTO_TABLE(T, null, QHS.AppAnd(QHS.CmpEq("nbill", r["nbill"]),
                                    QHS.CmpEq("billkind", billkind),QHS.CmpEq("ybill",Conn.GetSys("esercizio"))
                                    ), null, false);
                    DataRow Selected = null;
                    if (T.Rows.Count > 0)
                        Selected = T.Rows[0];
                    riempiTextBoxBill(Selected);
                    DataRow MyDR = Selected;
                    BillSelected = MyDR["nbill"];
                }
            }
            else {
                gboxBolletta.Visible = false;
                MakeSpaceFrom(gboxBolletta);
            }

        }


        void riempiTextBox(DataRow Selected)
        {
            txtUnderwriting.Text = (Selected != null) ? Selected["title"].ToString() : "";
        }
        void riempiTextBoxBill(DataRow Selected)
        {
            txtNumBolletta.Text = (Selected != null) ? Selected["nbill"].ToString() : "";
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


        void MakeSpaceFrom(GroupBox G) {
            Form F = G.FindForm();
            int disp = G.Height;
            int y0 = G.Location.Y;
            F.SuspendLayout();
            foreach (Control C in F.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            F.Size = new Size(F.Size.Width, F.Size.Height - disp);
            F.ResumeLayout();

        }


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.gboxBolletta = new System.Windows.Forms.GroupBox();
            this.txtNumBolletta = new System.Windows.Forms.TextBox();
            this.btnBolletta = new System.Windows.Forms.Button();
            this.gboxFinanziamento.SuspendLayout();
            this.gboxBolletta.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrizione:";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 24);
            this.txtDescrizione.MaxLength = 150;
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(400, 56);
            this.txtDescrizione.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(248, 234);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(336, 234);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtUnderwriting);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(8, 86);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(400, 61);
            this.gboxFinanziamento.TabIndex = 4;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Tag = "";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(116, 22);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(278, 20);
            this.txtUnderwriting.TabIndex = 3;
            this.txtUnderwriting.Tag = "";
            this.txtUnderwriting.Leave += new System.EventHandler(this.txtUnderwriting_Leave);
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 19);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 2;
            this.btnFinanziamento.Tag = "";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            this.btnFinanziamento.Click += new System.EventHandler(this.btnFinanziamento_Click);
            // 
            // gboxBolletta
            // 
            this.gboxBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxBolletta.Controls.Add(this.txtNumBolletta);
            this.gboxBolletta.Controls.Add(this.btnBolletta);
            this.gboxBolletta.Location = new System.Drawing.Point(8, 153);
            this.gboxBolletta.Name = "gboxBolletta";
            this.gboxBolletta.Size = new System.Drawing.Size(400, 61);
            this.gboxBolletta.TabIndex = 5;
            this.gboxBolletta.TabStop = false;
            this.gboxBolletta.Tag = "";
            // 
            // txtNumBolletta
            // 
            this.txtNumBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumBolletta.Location = new System.Drawing.Point(116, 22);
            this.txtNumBolletta.Name = "txtNumBolletta";
            this.txtNumBolletta.Size = new System.Drawing.Size(278, 20);
            this.txtNumBolletta.TabIndex = 3;
            this.txtNumBolletta.Tag = "";
            this.txtNumBolletta.Leave += new System.EventHandler(this.txtNumBolletta_Leave);
            // 
            // btnBolletta
            // 
            this.btnBolletta.Location = new System.Drawing.Point(6, 19);
            this.btnBolletta.Name = "btnBolletta";
            this.btnBolletta.Size = new System.Drawing.Size(104, 23);
            this.btnBolletta.TabIndex = 2;
            this.btnBolletta.Tag = "";
            this.btnBolletta.Text = "N.bolletta";
            this.btnBolletta.UseVisualStyleBackColor = true;
            this.btnBolletta.Click += new System.EventHandler(this.btnBolletta_Click);
            // 
            // AskDescription
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 269);
            this.Controls.Add(this.gboxBolletta);
            this.Controls.Add(this.gboxFinanziamento);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label1);
            this.Name = "AskDescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambia Descrizione";
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            this.gboxBolletta.ResumeLayout(false);
            this.gboxBolletta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void btnFinanziamento_Click(object sender, EventArgs e)
        {
            string Filter = "";
           
            Filter = QHS.CmpEq("active", "S");

            MetaData MFinanziamento = Disp.Get("underwriting");

            MFinanziamento.FilterLocked = true;
            MFinanziamento.SearchEnabled = false;
            MFinanziamento.MainSelectionEnabled = true;
            if (row.Table.TableName == "expensevarview")
            {
                string Filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());
                Filter = QHS.AppAnd(Filter, Filteridunderwriting);
            }
            DataRow MyDR = MFinanziamento.SelectOne("default", Filter, null, null);

            if (MyDR != null)
            {
                riempiTextBox(MyDR);
                UnderWritingSelected = MyDR["idunderwriting"];
            }
        }

        private void txtUnderwriting_Leave(object sender, EventArgs e)
        {
            //if (InChiusura) return;
           
            DataRow Selected = null;
            if (txtUnderwriting.Text.Trim() == "")
            {
                Selected = null;
                riempiTextBox(Selected);
                return;
            }

            MetaData Meta = Disp.Get("underwriting");
            string filtro = QHS.CmpEq("active", "S");
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            //Meta.StartFieldWanted = "codeunderwriting";
            //Meta.StartValueWanted = null;

            //Meta.StartValueWanted = txtUnderwriting.Text.Trim();
            string startfield =  "codeunderwriting";
            string startvalue = txtUnderwriting.Text.Trim();

            if (startvalue != null)
            {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + " like '%" + stripped + "%')");
                if (row.Table.TableName == "expensevarview")
                {
                    string Filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());

                    filter2 = QHS.AppAnd(filter2, Filteridunderwriting);
                }
                DataRow MyDR = Meta.SelectOne("default", filter2, "underwritingview", null);

                if (MyDR != null)
                {
                    riempiTextBox(MyDR);
                    UnderWritingSelected = MyDR["idunderwriting"];
                }
            }
       
        }

        DataTable GetFinanziamentiDisponibili(object idexp, int nphase)
        {
            int appropriationPhase = CfgFn.GetNoNullInt32(Conn.GetSys("appropriationphase"));
            int maxPhase = CfgFn.GetNoNullInt32(Conn.GetSys("maxexpensephase"));

            if (nphase != appropriationPhase && nphase != maxPhase) return null; //non si associano fin. a questa fase
            string table;
            if (nphase == appropriationPhase)
                table = "underwritingappropriation";
            else
                table = "underwritingpayment";
            DataTable T = Conn.RUN_SELECT(table, "*", null, QHS.CmpEq("idexp", idexp), null, false);
            //if (T == null || T.Rows.Count == 0)) 
            // ricerca nel dataset dei finanziamenti eventualmente associati
            // ai movimenti di spesa/entrata;
            if (T == null || T.Rows.Count == 0) return null;
            return T;

        }
        
        private void btnBolletta_Click(object sender, EventArgs e) {
            //choose.bill.spesa.
            string Filter = "";

            Filter = "((active='S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0))";
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("billkind", billkind), QHS.CmpEq("ybill", Conn.GetSys("esercizio")));
            MetaData MBill = Disp.Get("bill");

            MBill.FilterLocked = true;
            MBill.SearchEnabled = false;
            MBill.MainSelectionEnabled = true;
            DataRow MyDR = MBill.SelectOne("spesa", Filter, null, null);

            if (MyDR != null) {
                riempiTextBoxBill(MyDR);
                BillSelected = MyDR["nbill"];
            }
        }

        private void txtNumBolletta_Leave(object sender, EventArgs e) {

            DataRow Selected = null;
            if (txtNumBolletta.Text.Trim() == "") {
                BillSelected = null;
                riempiTextBoxBill(Selected);
                return;
            }

            MetaData Meta = Disp.Get("bill");
            string filtro = "((active='S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0))";
            filtro = QHS.AppAnd(filtro, QHS.CmpEq("billkind", billkind), QHS.CmpEq("ybill", Conn.GetSys("esercizio")));
            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            //Meta.StartFieldWanted = "nbill";
            //Meta.StartValueWanted = null;

            //Meta.StartValueWanted = txtUnderwriting.Text.Trim();
            string startfield = "nbill";
            string startvalue =  txtUnderwriting.Text.Trim();

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + " like '%" + stripped + "%')");
                DataRow MyDR = Meta.SelectOne("spesa", filter2, "billview", null);

                if (MyDR != null) {
                    riempiTextBoxBill(MyDR);
                    BillSelected =  MyDR["nbill"];
                }
            }
        }
	}
}
