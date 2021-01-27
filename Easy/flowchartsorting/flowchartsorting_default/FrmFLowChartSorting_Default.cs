
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace flowchartsorting_default {
    public partial class FrmFLowChartSorting_Default : Form {
        public FrmFLowChartSorting_Default() {
            InitializeComponent();
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T != DS.sortingapplicabilityview) return;

            if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done) {
                if ((!MetaData.Empty(this))) {
                    DS.flowchartsorting.Rows[0]["idsor"] = 0;
                }
                txtCodice.Text = "";
                txtDescrizione.Text = "";
                DS.sorting.Clear();
            }
            SetCodice();
        }



        void SetCodice() {
            if (Meta.EditMode) return;
            btnCodice.Enabled = (cmbTipo.SelectedIndex > 0);
            txtCodice.ReadOnly = (cmbTipo.SelectedIndex <= 0);
            if (cmbTipo.SelectedIndex <= 0) {
                txtCodice.Text = "";
                txtDescrizione.Text = "";
            }
            else {
                string filter = "(idsorkind=" + QueryCreator.quotedstrvalue(cmbTipo.SelectedValue, true) + ")";
                btnCodice.Tag = "manage.sorting.tree." + filter;
                //label per il form di selezione della voce di classificazione +"."+ filtro
                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = filter;
                //AutoManage.txtCodiceClass.tree
                gboxclass.Tag = "AutoManage.txtCodice.tree." + filter;
                MetaData.GetMetaData(this).SetAutoMode(gboxclass);
            }
        }

        public void MetaData_AfterFill() {
            SetCodice();
        }

        MetaData Meta;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

            string filterCT = QHS.CmpEq("tablename", "flowchart");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
        }
    }
}
