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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace flowchartfin_single {
    public partial class FrmFlowChartFin_Single : Form {
        MetaData Meta;
        bool inChiusura = false;
        CQueryHelper QHC;
        QueryHelper QHS;
        string filteresercizio;
        public FrmFlowChartFin_Single() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.Conn.GetEsercizio());
            SetFilterFinView();
        }

        public void MetaData_AfterClear() {
            SetFilterFinView();
        }

        public void MetaData_AfterFill() {
            if (!Meta.InsertMode) {
                // Come nel vecchio codice le info relative al bilancio sono editabili solo in fase di inserimento
                rdbEntrata.Enabled = false;
                rdbSpesa.Enabled = false;
                chkListTitle.Enabled = false;
                btnBilancio.Enabled = false;
                txtCodiceBilancio.ReadOnly = true;
            }
            SetFilterFinView();
        }

        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;
            int esercizio = (int) Meta.GetSys("esercizio");
            string filteridfin = "";
            if (rdbSpesa.Checked)
                filteridfin = "((fin.flag & 1)<>0)";
            if (rdbEntrata.Checked)
                filteridfin = "((fin.flag & 1)=0)";

            filter = filteridfin;

            //JTR - 28.06.2007
            //string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
            //    Meta.GetSys("esercizio").ToString() + "'))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter, QHS.Like("title", FR.txtDescrizione.Text + "%"));
                //JTR - 28.06.2007
                //filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.fin.default." + filter);
                return;
            }

            DS.fin.ExtendedProperties[MetaData.ExtraParams] = filter;
            string filtro = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (rdbSpesa.Checked)
                // Invece di trees sto mettendo treealls
                MetaData.DoMainCommand(this, "manage.fin.treealls."+filtro);
            if (rdbEntrata.Checked)
                // Invece di treee sto mettendo treealle
                MetaData.DoMainCommand(this, "manage.fin.treealle."+filtro);
        }

        private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            DataRow Curr = DS.flowchartfin.Rows[0];
            if (txtCodiceBilancio.Text.Trim() == "") {
                SvuotaFinView();
                Curr["idfin"] = DBNull.Value;
                return;
            }

            string finpart = "";
            string edit_type = "";
            if (rdbSpesa.Checked) {
                finpart = "1";
                edit_type = "treealls";
            }
            if (rdbEntrata.Checked) {
                finpart = "0";
                edit_type = "treealle";
            }
            if (finpart == "") return;

            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.DoPar(QHS.CmpEq("(fin.flag & 1)",finpart)));
            MetaData MetaBilancio = MetaData.GetMetaData(this, "fin");
            MetaBilancio.FilterLocked = true;
            MetaBilancio.SearchEnabled = false;
            MetaBilancio.MainSelectionEnabled = true;
            MetaBilancio.StartFilter = filtro;
            MetaBilancio.ExtraParameter = filtro;
            MetaBilancio.startFieldWanted = "codefin";
            MetaBilancio.startValueWanted = null;
            MetaBilancio.edit_type = edit_type;

            MetaBilancio.startValueWanted = txtCodiceBilancio.Text.Trim();
            string startfield = MetaBilancio.startFieldWanted;
            string startvalue = MetaBilancio.startValueWanted;
            DataRow rFin = null;
            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                rFin = MetaBilancio.SelectByCondition(filter2, "fin");
            }

            string eos = (finpart == "0") ? "e" : "s";
            if (rFin == null) {
                string edittype = "tree" + eos;
                bool res = MetaBilancio.Edit(this, edittype, true);
                if (!res) {
                    SvuotaFinView();
                    Curr["idfin"] = DBNull.Value;
                    return;
                }
                rFin = MetaBilancio.LastSelectedRow;
            }
            Curr["idfin"] = rFin["idfin"];
            if (rFin != null) {
                SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("ayear", rFin["ayear"]));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.fin, null, filter, null, false);
            }
            Meta.FreshForm(gboxBilAnnuale.Controls, true, "fin");
        }

        private void SvuotaFinView() {
            txtDenominazioneBilancio.Text = "";
            txtCodiceBilancio.Text = "";
            DS.fin.Clear();
        }

        private void SetFilterFinView() {
            GetData.SetStaticFilter(DS.fin, filteresercizio);
        }

    }
}