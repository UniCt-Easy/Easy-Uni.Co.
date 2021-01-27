
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace accmotivesortingview_default {
    public partial class Frm_accmotivesortingview_default :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_accmotivesortingview_default() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filtersorkindApplicability = getFilterSorkindApplicability();
            GetData.SetStaticFilter(DS.sortingkind, filtersorkindApplicability);
            GetData.SetStaticFilter(DS.accmotivesortingview, filtersorkindApplicability);
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
        }

        public string getFilterSorkindActive() {
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("start"), QHS.CmpLe("start", Meta.GetSys("esercizio"))));
            filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("stop"), QHS.CmpGe("stop", Meta.GetSys("esercizio")))));
            return filter;
        }

        public string getFilterSorkindApplicability() {
            string filterKindActive = getFilterSorkindActive();
            string filteridsorkind= "";
            DataTable tSortingkind = Conn.RUN_SELECT("sortingkind", "idsorkind", null, filterKindActive, null, false);
            DataRow[] rClassKind = tSortingkind.Select();
            if (rClassKind != null && rClassKind.Length > 0) {
                string listaIdsorkind = QHS.DistinctVal(rClassKind, "idsorkind");
                filteridsorkind = QHS.FieldInList("idsorkind", listaIdsorkind);
            }
            DataTable tSortingapplicability = Conn.RUN_SELECT("sortingapplicability", "idsorkind", null, QHS.CmpEq("tablename", "accmotive"), null, false);
            DataRow[] rSortingapplicability = tSortingapplicability.Select();
            if (rSortingapplicability != null && rSortingapplicability.Length > 0) {
                string listaIdsorkind_formotive = QHS.DistinctVal(rSortingapplicability, "idsorkind");
                string filteridsorkind_formotive = QHS.FieldInList("idsorkind", listaIdsorkind_formotive);
                filteridsorkind = QHS.AppAnd(filteridsorkind, filteridsorkind_formotive);
            }
            return filteridsorkind;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {

            if (T.TableName == "sortingkind") {
                if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done) {
                    if ((!MetaData.Empty(this))) {
                        DS.accmotivesortingview.Rows[0]["idsor"] = 0;
                        DS.accmotivesortingview.Rows[0]["idsorkind"] = 0;
                    }
                    txtCodiceMov.Text = "";
                    txtDescrizioneMov.Text = "";
                    DS.sorting.Clear();
                }
                SetCodiceMovim();
            }
        }

        void SetCodiceMovim() {
            btnCodiceMov.Enabled = (cmbTipoMov.SelectedIndex > 0);
            txtCodiceMov.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
            if (cmbTipoMov.SelectedIndex <= 0) {
                txtCodiceMov.Text = "";
                txtDescrizioneMov.Text = "";
            }
            else {
                string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
                DataTable Available = Conn.RUN_SELECT("sorting", "*", null, filter, null, null, true);
                btnCodiceMov.Tag = "manage.sorting.tree." + filter;
                gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree." + filter;

                MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceMov.Name);
                if (AI != null) AI.startfilter = filter;

                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Available;
            }
        }
        public void MetaData_AfterClear() {
            grpClassificazione.Enabled = true;
        }
        public void MetaData_AfterFill() {
            SetCodiceMovim();
            grpClassificazione.Enabled = false;
        }
    }
}
