
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace sisest_corsolaurea_default {
    public partial class frmsisest_corsolaurea_default : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        public frmsisest_corsolaurea_default() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Dispatcher = Meta.Dispatcher as EntityDispatcher;
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
            QHS = Conn.GetQueryHelper();

            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");

            DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

            if (tConfig == null || tConfig.Rows.Count == 0) {
                show("Configurazione annuale non trovata.", "Errore");
                Meta.ErroreIrrecuperabile = true;
                return;
            }


            DataRow R = tConfig.Rows[0];

            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            CfgFn.SetGBoxClass(this, 1, idsorkind1);
            CfgFn.SetGBoxClass(this, 2, idsorkind2);
            CfgFn.SetGBoxClass(this, 3, idsorkind3);
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                tabControl1.TabPages.Remove(tabAnalitico);
            }


        }

        //public void MetaData_AfterActivation() { }
        //public void MetaData_AfterClear() {}
        //public void MetaData_BeforeFill() {}
        //public void MetaData_AfterFill() {}
        //public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
        //public void MetaData_BeforePost() { }
        //public void MetaData_AfterPost() { }

    }
}
