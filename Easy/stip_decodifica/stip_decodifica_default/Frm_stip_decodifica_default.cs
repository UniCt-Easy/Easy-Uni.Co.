
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
using ep_functions;

namespace stip_decodifica_default {
    public partial class Frm_stip_decodifica_default : Form {
        public Frm_stip_decodifica_default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        IDataAccess Conn;
        private IFormController controller;
        public void MetaData_AfterLink() {
            var Meta = MetaData.GetMetaData(this);
            Conn =  this.getInstance<IDataAccess>();
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            controller = this.getInstance<IFormController>();
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Conn as DataAccess);
            DS.accmotiveapplied_credit.setStaticFilter(filterEpOperationCred);
            DS.accmotiveapplied_credit.setTableForReading("accmotiveapplied");
            model.setExtraParams(DS.accmotiveapplied_credit,filterEpOperationCred);

            DS.finmotive_income.setTableForReading("finmotive");

            DS.accmotiveapplied_revenue.setTableForReading( "accmotiveapplied");
            DS.accmotiveapplied_undotax.setTableForReading( "accmotiveapplied");
            DS.accmotiveapplied_undotaxpost.setTableForReading("accmotiveapplied");
			string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn as DataAccess);

            model.setExtraParams(DS.accmotiveapplied_revenue,filterEpOperation);
            model.setExtraParams(DS.accmotiveapplied_undotax,filterEpOperation);
            model.setExtraParams(DS.accmotiveapplied_undotaxpost,filterEpOperation);

            DS.accmotiveapplied_revenue.setStaticFilter( filterEpOperation);
            DS.accmotiveapplied_undotax.setStaticFilter( filterEpOperation);
            DS.accmotiveapplied_undotaxpost.setStaticFilter(filterEpOperation);
            cmbTipoContratto.DataSource = DS.estimatekind;
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
