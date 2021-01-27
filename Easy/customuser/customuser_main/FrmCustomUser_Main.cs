
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

namespace customuser_main {
    public partial class FrmCustomUser_Main : Form {
        MetaData Meta;
        public FrmCustomUser_Main() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            string filter = "(iddbdepartment = " + QueryCreator.quotedstrvalue(Meta.GetSys("userdb"), true) + ")";
            GetData.CacheTable(DS.dbaccess, filter, "login", true);
        }

        public void MetaData_AfterClear() {
            btnApplica.Enabled = false;
        }

        public void MetaData_AfterFill() {
            btnApplica.Enabled = (!Meta.InsertMode);
        }

        private void btnApplica_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.InsertMode) return;
            if (DS.customuser.Rows.Count == 0) return;
            QueryHelper QHS= Meta.Conn.GetQueryHelper();
            DataRow Curr = DS.customuser.Rows[0];

            DataTable tCustomGroup = DataAccess.CreateTableByName(Meta.Conn, "customgroup", "*");
            DataTable tSecurityVar = DataAccess.CreateTableByName(Meta.Conn, "securityvar", "*");

            DataTable tCustomUserGroup = DataAccess.CreateTableByName(Meta.Conn, "customusergroup", "*");
            DataTable tUserEnvironment = DataAccess.CreateTableByName(Meta.Conn, "userenvironment", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCustomGroup, null, 
                QHS.CmpEq("idcustomgroup","ORGANIGRAMMA"), null, true);
            fillUserInGroup(Curr["idcustomuser"], tCustomGroup, tCustomUserGroup);

            // Fill della tabella securityvar
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tSecurityVar, null, null, null, true);
            fillUserEnvironment(Curr["idcustomuser"], tSecurityVar, tUserEnvironment);

            DataSet dsPost = new DataSet();
            dsPost.Tables.Add(tCustomUserGroup);
            dsPost.Tables.Add(tUserEnvironment);

            Easy_PostData pd = new Easy_PostData();
            pd.InitClass(dsPost, Meta.Conn);
            if (!pd.DO_POST()) {
                MessageBox.Show(this, "Errore nel salvataggio dei dati", "Errore");
            }
            else {
                MessageBox.Show(this, "Procedura di Applicazione dell'utente effettuata", "Ok");
            }
        }

        private void fillUserInGroup(object idcustomuser, DataTable tCustomGroup, DataTable tCustomUserGroup) {
            if (idcustomuser == null) return;
            if (tCustomGroup == null) return;
            if (tCustomUserGroup == null) return;
            string fuser = "(idcustomuser = " + QueryCreator.quotedstrvalue(idcustomuser, true) + ")";
            foreach (DataRow rGroup in tCustomGroup.Rows) {
                string fgruppo = "(idcustomgroup = " + QueryCreator.quotedstrvalue(rGroup["idcustomgroup"], false) + ")";
                string filter = GetData.MergeFilters(fuser, fgruppo);

                if (tCustomUserGroup.Select(filter).Length > 0) return;
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCustomUserGroup, null, filter, null, true);
                if (tCustomUserGroup.Select(filter).Length > 0) return;

                DataRow rCustomUserGroup = tCustomUserGroup.NewRow();
                rCustomUserGroup["idcustomuser"] = idcustomuser;
                rCustomUserGroup["idcustomgroup"] = rGroup["idcustomgroup"];
                rCustomUserGroup["lastmodtimestamp"] = DateTime.Now;
                rCustomUserGroup["lastmoduser"] = "Software and More";
                rCustomUserGroup["ct"] = DateTime.Now;
                rCustomUserGroup["cu"] = "Software and More";
                rCustomUserGroup["lt"] = DateTime.Now;
                rCustomUserGroup["lu"] = "Software and More";

                tCustomUserGroup.Rows.Add(rCustomUserGroup);
            }
        }

        private void fillUserEnvironment(object idcustomuser, DataTable tSecurityVar, DataTable tUserEnvironment) {
            if (idcustomuser == null) return;
            if (tSecurityVar == null) return;
            if (tUserEnvironment == null) return;

            foreach (DataRow rSecurityVar in tSecurityVar.Rows) {
                string f = "(idcustomuser = " + QueryCreator.quotedstrvalue(idcustomuser, true)
                + ") and (variablename = " + QueryCreator.quotedstrvalue(rSecurityVar["variablename"], true) + ")";
                if (tUserEnvironment.Select(f).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tUserEnvironment, null, f, null, true);
                }
                DataRow rUserEnvironment = null;
                if (tUserEnvironment.Select(f).Length > 0)
                    rUserEnvironment = tUserEnvironment.Select(f)[0];
                else
                    rUserEnvironment = tUserEnvironment.NewRow();

                rUserEnvironment["idcustomuser"] = idcustomuser;
                rUserEnvironment["variablename"] = rSecurityVar["variablename"];
                rUserEnvironment["value"] = rSecurityVar["value"];
                rUserEnvironment["flagadmin"] = "N";
                rUserEnvironment["kind"] = rSecurityVar["kind"];
                rUserEnvironment["lt"] = DateTime.Now;
                rUserEnvironment["lu"] = "Software and More";

                if (tUserEnvironment.Select(f).Length ==0)
                    tUserEnvironment.Rows.Add(rUserEnvironment);
            }
        }
    }
}
