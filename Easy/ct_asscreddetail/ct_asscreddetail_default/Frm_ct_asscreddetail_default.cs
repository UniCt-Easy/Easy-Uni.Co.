
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
using metaeasylibrary;
using funzioni_configurazione;

namespace ct_asscreddetail_default {
    public partial class Frm_ct_asscreddetail_default : Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_ct_asscreddetail_default() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.finspesa, "fin");
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filteresercizio, QHS.BitClear("flag", 0)));
            GetData.SetStaticFilter(DS.finspesa, QHS.AppAnd(filteresercizio, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.ct_asscreddetailview, QHS.CmpEq("yfinincome", Meta.GetSys("esercizio")));
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            AbilitaTutto(true);
            ImpostaTipoClassificazione();
           }

        public void ImpostaTipoClassificazione() {
            //SICUR_UPB_2016
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string Tipoclass = "SICUR_UPB_" + esercizio.ToString();
            string filterkind = QHS.CmpEq("codesorkind", Tipoclass);
            DataTable tSortingkind = Conn.RUN_SELECT("sortingkind", "*", null, filterkind, null, null, true);
            if (tSortingkind.Rows.Count > 0) {
                DataRow rSortingkind = tSortingkind.Rows[0];
                gboxclass.Text = rSortingkind["description"].ToString();
                string filter_idsortingkind = QHC.CmpEq("idsorkind", rSortingkind["idsorkind"]);
                GetData.SetStaticFilter(DS.sorting, filter_idsortingkind);
            }
        }

        public void MetaData_AfterFill() {
            AbilitaTutto(false);
        }
        public void MetaData_AfterClear() {
            AbilitaTutto(true);
        }
        private void AbilitaTutto(bool enable) {
            btnBilancioEntrata.Enabled = enable;
            btnBilancioSpesa.Enabled = enable;
            btnCodice.Enabled = enable;
            txtBilancioEntrata.ReadOnly = !enable;
            txtBilancioSpesa.ReadOnly = !enable;
            txtCodice.ReadOnly = !enable;
            txtPercentuale.ReadOnly = !enable;
        }
    }
}
