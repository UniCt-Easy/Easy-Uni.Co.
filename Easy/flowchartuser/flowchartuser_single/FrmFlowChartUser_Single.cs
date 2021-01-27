
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

namespace flowchartuser_single {
    public partial class FrmFlowChartUser_Single : Form {
        MetaData Meta;

        public FrmFlowChartUser_Single() {
            InitializeComponent();
        }

        DataAccess Conn;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            CQueryHelper QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterDepartment = QHS.CmpEq("iddbdepartment", Meta.GetSys("userdb"));
            DataTable tDBAccess = Meta.Conn.CreateTableByName("dbaccess", "*");
            Meta.Conn.RUN_SELECT_INTO_TABLE(tDBAccess, null, filterDepartment, null, false);
            string loginNameList = QueryCreator.ColumnValues(tDBAccess, null, "login", true);
            string filterCustomUser = QHS.FieldInList("username", loginNameList);

            string Autochoose = "AutoChoose.txtUtente.default.";
            string Choose = "choose.customuser.default.";
            grpUser.Tag = Autochoose + filterCustomUser;
            btnUser.Tag = Choose + filterCustomUser;
            Meta.SetAutoMode(grpUser);


            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");


            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
                null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
            }
        }

        public void MetaData_AfterFill() {
            Meta.MarkTableAsNotEntityChild(DS.flowchartusersorting);
        }
    }
}
