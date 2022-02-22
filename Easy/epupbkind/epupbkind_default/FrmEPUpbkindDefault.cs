
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
using ep_functions;


namespace epupbkind_default {
    public partial class FrmEPUpbkindDefault : MetaDataForm {
        public FrmEPUpbkindDefault() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.account_cost, "account");
            DataAccess.SetTableForReading(DS.account_rateo, "account");
            DataAccess.SetTableForReading(DS.account_revenue, "account");
            DataAccess.SetTableForReading(DS.account_risconto, "account");
            DataAccess.SetTableForReading(DS.account_riserva, "account");

            DataAccess.SetTableForReading(DS.accmotive_cost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_accruals, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_revenue, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_deferredcost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_reserve, "accmotive");
        }
        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            GetData.SetStaticFilter(DS.epupbkindyear, filteresercizio);
 
            GetData.SetStaticFilter(DS.epupbkindview, filteresercizio);
            GetData.SetStaticFilter(DS.account_cost, filteresercizio);
            GetData.SetStaticFilter(DS.account_rateo, filteresercizio);
            GetData.SetStaticFilter(DS.account_riserva, filteresercizio);
            GetData.SetStaticFilter(DS.account_revenue, filteresercizio);
            GetData.SetStaticFilter(DS.account_risconto, filteresercizio);
            HelpForm.SetDenyNull(DS.epupbkind.Columns["isresource"], true);


        }

        public void MetaData_AfterFill() {
            Meta.MarkTableAsNotEntityChild(DS.epupbkindyear);
            EnableDisableSelezioneConti();
        }


        private void EnableDisableSelezioneConti() {
            if (Meta.IsEmpty) {
                return;
            }
               
            DataRow curr = DS.epupbkindyear.Rows[0];
            gboxContoCosti.Enabled = (curr["idaccmotive_cost"] == DBNull.Value);
            gboxContoRicavi.Enabled = (curr["idaccmotive_revenue"] == DBNull.Value);
            gboxContoRateo.Enabled = (curr["idaccmotive_accruals"] == DBNull.Value);
            gboxContoRisconto.Enabled = (curr["idaccmotive_deferredcost"] == DBNull.Value);
            gboxContoRiserva.Enabled = (curr["idaccmotive_reserve"] == DBNull.Value); 
        }

        public void MetaData_AfterClear() {
            Meta.UnMarkTableAsNotEntityChild(DS.epupbkindyear);
            gboxContoCosti.Enabled = true;
            gboxContoRicavi.Enabled = true;
            gboxContoRateo.Enabled = true;
            gboxContoRisconto.Enabled = true;
            gboxContoRiserva.Enabled = true;
        }

        public void MetaData_BeforeFill() {
            CreateEpUpbKindYearRow();
        }



        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string table = T.TableName.ToLower();
            DataRow curr = DS.epupbkindyear.Rows[0];

            if (table == "accmotive_cost" || table == "accmotive_revenue" ||
               table == "accmotive_accruals" || table == "accmotive_deferredcost" ||
               table == "accmotive_reserve") {
                if (R == null) return;
                object idacc = getIdAccFromMotive(R["idaccmotive"]);

                switch (table) {
                case "accmotive_cost": {
                        curr["idacc_cost"] = idacc;
                        break;
                    }

                case "accmotive_revenue": {
                        curr["idacc_revenue"] = idacc;
                        break;
                    }

                case "accmotive_accruals": {
                        curr["idacc_accruals"] = idacc;
                        break;
                    }

                case "accmotive_deferredcost": {
                        curr["idacc_deferredcost"] = idacc;
                        break;
                    }

                case "accmotive_reserve": {
                        curr["idacc_reserve"] = idacc;
                        break;
                    }
                }

            }
            
            Meta.FreshForm();

        }
       
        object getIdAccFromMotive(object idAccMotive) {
            EP_functions ep = new EP_functions(Meta.Dispatcher);
            if (idAccMotive == DBNull.Value || idAccMotive == null) return null;
            var rEntries = ep.GetAccMotiveDetails(idAccMotive);
            if (rEntries == null || rEntries.Length == 0) return null;
            return rEntries[0]["idacc"];
        }

        public void CreateEpUpbKindYearRow() {
            if (Meta.IsEmpty) return;
            DataRow drEpUpbKind = HelpForm.GetLastSelected(DS.epupbkind);
            if (DS.Tables["epupbkindyear"].Rows.Count == 0) {
                MetaData metaepby = MetaData.GetMetaData(this, "epupbkindyear");
                metaepby.SetDefaults(DS.epupbkindyear);
                DataRow DR = metaepby.Get_New_Row(drEpUpbKind, DS.epupbkindyear);
            }
        }
    }
}
