
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
using metaeasylibrary;
using funzioni_configurazione;

namespace ct_config_default {
    public partial class Frm_ct_config_default : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        bool CanGoEdit= true;
        bool CanGoInsert;
        public Frm_ct_config_default() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            int numrighe = Meta.Conn.RUN_SELECT_COUNT("ct_config", null, true);
            if (numrighe == 1) {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else {
                CanGoInsert = true;
                CanGoEdit = false;
            }
            ImpostaLabelTipoClassificazione();
        }
        public void ImpostaLabelTipoClassificazione() {
            //SICUR_UPB_2016
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string Tipoclass = "SICUR_UPB_" + esercizio.ToString();
            string filterkind = QHS.CmpEq("codesorkind", Tipoclass);
            DataTable tSortingkind = Conn.RUN_SELECT("sortingkind", "*", null, filterkind, null, null, true);
            if (tSortingkind.Rows.Count > 0) {
                DataRow rSortingkind = tSortingkind.Rows[0];
                lblSottosezionale.Text = "Livello della Classificazione '" + rSortingkind["description"].ToString() + "' che identifica il livello “sottosezionale”";
            }
        }

        public void MetaData_AfterClear() {
            if (CanGoInsert) {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit) {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); 
            }

        }
    }
}
