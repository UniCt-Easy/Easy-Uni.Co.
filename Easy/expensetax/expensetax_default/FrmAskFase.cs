
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace expensetax_default {
    public partial class FrmAskFase : MetaDataForm {
        MetaDataDispatcher Disp;
        DataAccess Conn;
        private DataRow SelectedUpb;
        public DataRow Selected;
        bool InChiusura = false;
       
        DataTable upb;
        decimal importo;
        DataTable finview;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAskFase(decimal importoIncasso, DataTable upbTable, DataTable finviewTable,
            MetaDataDispatcher Disp, DataAccess Conn) {
            InitializeComponent();
            this.Disp = Disp;
            this.Conn = Conn;
            this.upb = upbTable;
            this.finview = finviewTable;
            this.importo = importoIncasso;

            cmbUpb.DataSource = upb;
            cmbUpb.ValueMember = "idupb";
            cmbUpb.DisplayMember = "codeupb";
            Selected = null;
           
            
            QHC = new CQueryHelper();
            QHS = this.Conn.GetQueryHelper();

            HelpForm.SetComboBoxValue(cmbUpb, "0001");
            DataRow[] RUPB = upb.Select(QHC.CmpEq("idupb", "0001"));
            if (RUPB.Length > 0) {
            txtDescrizioneUpb.Text = RUPB[0]["title"].ToString();
            }
        }

        private void btnBilancio_Click(object sender, EventArgs e) {
            string filter;
            MetaData Meta = Disp.Get("finview");

            int esercizio = (int)Meta.GetSys("esercizio");
            string filterPart = QHS.BitClear("flag", 0);
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), filterPart);

            //Il filtro sull'UPB c'è sempre
            if (cmbUpb.SelectedIndex > 0) {
                filter = QHS.CmpEq("idupb", cmbUpb.SelectedValue);
            }
            else {
                filter = QHS.CmpEq("idupb", "0001");
            }
            filter = QHS.AppAnd(filteridfin, filter);

            //Aggiunge eventualmente il filtro sul disponibile
            if (chkFilterAvailable.Checked) {
                decimal currval = importo;
                filter = GetData.MergeFilters(filter, QHS.CmpGe("availableprevision", currval));
            }
            string filteroperativo = "(idfin in (SELECT idfin from finusable where " +
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")) + "))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter, QHS.Like("title", "%" + FR.txtDescrizione.Text + "%"));
                Meta.FilterLocked = true;
                filter = GetData.MergeFilters(filter, filteroperativo);
                Selected = Meta.SelectOne("default", filter, "finview", null);
                riempiTextBox(Selected);
                return;
            }

            chiamaFormBilancio(filter);
        }

        private void chiamaFormBilancio(string filtro) {
            MetaData Meta = Disp.Get("finview");

            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.ExtraParameter = filtro;
            string edittype = "treeeupb";
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
            txtDescrizioneUpb.Text = (upbRow != null) ? upbRow["title"].ToString() : "";
            cmbUpb.SelectedValue = (upbRow != null) ? upbRow["idupb"].ToString() : "";
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
            
            string filter = QHC.CmpEq("idupb", cmbUpb.SelectedValue);
            DataRow[] rUpb = upb.Select(filter);
            SelectedUpb = (rUpb.Length > 0) ? rUpb[0] : null;
            riempiInfoUpb(SelectedUpb);
        }

        private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;

            if (txtCodiceBilancio.Text.Trim() == "") {
                Selected = null;
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
            MetaData Meta = Disp.Get("finview");


            string filterPart = QHS.BitClear("flag", 0);
            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                filterPart, filterUpb);

            Meta.FilterLocked = true;
            Meta.SearchEnabled = false;
            Meta.MainSelectionEnabled = true;
            Meta.StartFilter = filtro;
            Meta.ExtraParameter = filtro;
            Meta.startFieldWanted = "codefin";
            Meta.startValueWanted = null;

            Meta.startValueWanted = txtCodiceBilancio.Text.Trim();
            string startfield = Meta.startFieldWanted;
            string startvalue = Meta.startValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                //Meta.myGetData= myGetData;
                Selected = Meta.SelectByCondition(filter2, "finview");
            }

            if (Selected == null) {
                string edittype = "treeeupb";
                bool res = Meta.Edit(this, edittype, true);
                if (!res) {
                    return;
                }
                Selected = Meta.LastSelectedRow;
            }

            riempiTextBox(Selected);
        }
    }
}
