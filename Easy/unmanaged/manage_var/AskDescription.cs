
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace manage_var {
    public partial class AskDescription : MetaDataForm {
        DataRow riga;
        bool askFinanziamento;
        DataAccess Conn;
        public object UnderWritingSelected;
        MetaDataDispatcher Disp;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable FinanziamentiDisponibili; 
        public AskDescription(DataRow r, int dummy, bool askFinanziamento,  MetaDataDispatcher Disp,DataAccess Conn) {
            this.riga = r;
            InitializeComponent();
            string descrizione = riga["description"].ToString();
            txtDescrizione.Text = descrizione;
            this.askFinanziamento = askFinanziamento;
            this.Disp = Disp;
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
                                                                          QHS.CmpEq("idunderwriting", r["idunderwriting"])), null, false);
                    DataRow Selected = null;
                    if (T.Rows.Count > 0)
                        Selected = T.Rows[0];
                    riempiTextBox(Selected);
                }
               
                FinanziamentiDisponibili = GetFinanziamentiDisponibili(r["idexp"],
                                CfgFn.GetNoNullInt32(r["nphase"]));
                if ((FinanziamentiDisponibili == null) || (FinanziamentiDisponibili.Rows.Count == 0))
                    gboxFinanziamento.Enabled = false;
            }
            else {
                if (!gboxFinanziamento.Visible)
                    MakeSpaceFrom(gboxFinanziamento);
            }


        }


        void riempiTextBox(DataRow Selected)
        {
            txtUnderwriting.Text = (Selected != null) ? Selected["title"].ToString() : "";
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

        private void btnFinanziamento_Click(object sender, EventArgs e)
        {
            if ((FinanziamentiDisponibili == null) || (FinanziamentiDisponibili.Rows.Count == 0)) return;

            string Filter = "";

            Filter = QHS.CmpEq("active", "S");

            MetaData MFinanziamento = Disp.Get("underwriting");

            MFinanziamento.FilterLocked = true;
            MFinanziamento.SearchEnabled = false;
            MFinanziamento.MainSelectionEnabled = true;

            
            string Filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());
            Filter = QHS.AppAnd(Filter, Filteridunderwriting);
            DataRow MyDR = MFinanziamento.SelectOne("default", Filter, "underwritingview", null);

            if (MyDR != null)
            {
                riempiTextBox(MyDR);
                UnderWritingSelected = MyDR["idunderwriting"];
            }
        }

        private void txtUnderwriting_Leave(object sender, EventArgs e)
        {
            if ((FinanziamentiDisponibili == null) || (FinanziamentiDisponibili.Rows.Count == 0)) return;

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
            Meta.startFieldWanted = "codeunderwriting";
            Meta.startValueWanted = null;

            Meta.startValueWanted = txtUnderwriting.Text.Trim();
            string startfield = Meta.startFieldWanted;
            string startvalue = Meta.startValueWanted;

            if (startvalue != null)
            {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + " like '%" + stripped + "%')");
                string Filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());

                filter2 = QHS.AppAnd(filter2, Filteridunderwriting);

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
            if (T == null || T.Rows.Count == 0) return null;
            return T;

        }
     
    }
}
