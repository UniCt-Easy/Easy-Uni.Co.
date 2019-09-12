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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using ep_functions;

namespace stip_decodifica_default {
    public partial class Frm_stip_decodifica_default : Form {
        public Frm_stip_decodifica_default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Meta.Conn);
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);
            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");
            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;
            DataAccess.SetTableForReading(DS.finmotive_income, "finmotive");

            DataAccess.SetTableForReading(DS.accmotiveapplied_revenue, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_undotax, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_undotaxpost, "accmotiveapplied");
			string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn);
            DS.accmotiveapplied_revenue.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotax.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotaxpost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_revenue, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotax, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotaxpost, filterEpOperation);
        }


		//public void MetaData_AfterFill() {
		//	EnableDisableControls(false);
		//}

		//public void MetaData_AfterClear() {
		//	EnableDisableControls(true);
		//}


		//void EnableDisableControls(bool enable) {

		//	txtCorsoLaurea.ReadOnly = !enable;
		//	txtCodiceCorsoLaurea.ReadOnly = !enable;
		//	txtTassa.ReadOnly = !enable;
		//	txtVoce.ReadOnly = !enable;
		//}

	}
}
