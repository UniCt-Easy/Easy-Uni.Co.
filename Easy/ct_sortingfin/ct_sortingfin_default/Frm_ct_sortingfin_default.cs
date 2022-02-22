
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
using funzioni_configurazione;

namespace ct_sortingfin_default {
    public partial class Frm_ct_sortingfin_default : MetaDataForm {
        MetaData Meta;
        bool InChiusura;
        string filteresercizio;
        public Frm_ct_sortingfin_default() {
            InitializeComponent();
            InChiusura = false;
        }
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.finview, filteresercizio);
            Meta.CanInsertCopy = false;
            ImpostaTipoClassificazione();
        }
        public void MetaData_AfterClear() {
            btnBilancio.Enabled = true;
        }

        public void MetaData_AfterFill() {
            if (Meta.IsEmpty)
                return;
            if (Meta.InsertMode)
                btnBilancio.Enabled = true;
            else
                btnBilancio.Enabled = false;

        }
        public void ImpostaTipoClassificazione() {
            //SICUR_UPB_2016
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string Tipoclass = "SICUR_UPB_" + esercizio.ToString();
            string filterkind = QHS.CmpEq("codesorkind", Tipoclass);
            DataTable tSortingkind = Conn.RUN_SELECT("sortingkind", "*", null, filterkind, null, null, true);
            if (tSortingkind.Rows.Count > 0)
            {
                DataRow rSortingkind = tSortingkind.Rows[0];
                gboxclass.Text = rSortingkind["description"].ToString();
                string filter_idsortingkind = QHC.CmpEq("idsorkind", rSortingkind["idsorkind"]);
                GetData.SetStaticFilter(DS.sorting, filter_idsortingkind);
            }
        }
        private void btnBilancio_Click(object sender, EventArgs e) {
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "";
            if (rdbSpesa.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'));
            if (rdbEntrata.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'E'));

            //Il filtro sull'UPB c'è sempre
            filter = QHS.CmpEq("idupb", "0001");

            filter = QHS.AppAnd(filteridfin, filter);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked)
            {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            if (rdbSpesa.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treesupb");
            if (rdbEntrata.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treeeupb");
        }

        private void SvuotaFinView() {
            txtDescrBilancio.Text = "";
            txtBilancio.Text = "";
            DS.finview.Clear();
        }
        private void txtBilancio_Leave(object sender, EventArgs e) {
            if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = null;
            if (DS.ct_sortingfin.Rows.Count > 0) {
                Curr = DS.ct_sortingfin.Rows[0];
            }
            
            if (txtBilancio.Text.Trim() == "") {
                SvuotaFinView();
                if (Curr != null) Curr["idfin"] = 0;
                return;
            }

            string finpart = "";
            if (rdbSpesa.Checked) {
                finpart = "S";
            }
            if (rdbEntrata.Checked) {
                finpart = "E";
            }
            if (finpart == "") return;

            string filterUpb = "";
            filterUpb = QHS.CmpEq("idupb", "0001");

            string filtro = QHS.AppAnd(filterUpb, QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("finpart", finpart));
            MetaData MetaBilancio = MetaData.GetMetaData(this, "finview");
            MetaBilancio.FilterLocked = true;
            MetaBilancio.SearchEnabled = false;
            MetaBilancio.MainSelectionEnabled = true;
            MetaBilancio.StartFilter = filtro;
            MetaBilancio.ExtraParameter = filtro;
            MetaBilancio.startFieldWanted = "codefin";
            MetaBilancio.startValueWanted = null;

            MetaBilancio.startValueWanted = txtBilancio.Text.Trim();
            string startfield = MetaBilancio.startFieldWanted;
            string startvalue = MetaBilancio.startValueWanted;
            DataRow rFin = null;
            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                rFin = MetaBilancio.SelectByCondition(filter2, "finview");
            }

            if (rFin == null) {
                string edittype = "tree" + finpart.ToLower() + "upb";
                bool res = MetaBilancio.Edit(this, edittype, true);
                if (!res) {
                    SvuotaFinView();
                    if (Curr != null) Curr["idfin"] = "";
                    return;
                }
                rFin = MetaBilancio.LastSelectedRow;
            }
            if (Curr != null) Curr["idfin"] = rFin["idfin"];
            if (rFin != null) {
                SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("idupb", rFin["idupb"]), QHS.CmpEq("ayear", rFin["ayear"]));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.finview, null, filter, null, false);
            }
            Meta.FreshForm(gboxBilancio.Controls, true, "finview");
            if (!(Meta.InsertMode || Meta.EditMode)) {
                txtBilancio.Text = rFin["codefin"].ToString();
                txtDescrBilancio.Text = rFin["title"].ToString();
                if (rFin["finpart"].ToString() == "S") {
                    rdbSpesa.Checked = true;
                }
                else {
                    rdbEntrata.Checked = true;
                }
            }
        }
    }
}
