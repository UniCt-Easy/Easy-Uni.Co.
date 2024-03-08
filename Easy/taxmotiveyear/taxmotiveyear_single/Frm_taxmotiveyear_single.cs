
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace taxmotiveyear_single {
    public partial class Frm_taxmotiveyear_single : MetaDataForm {
        public Frm_taxmotiveyear_single() {
            InitializeComponent();
        }

        QueryHelper QHS;

        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            
        QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");
            string filterEpOperation = QHS.CmpEq("idepoperation", "appcontrib");
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperation);

            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");
            string filterEpOperationApprit = QHS.CmpEq("idepoperation", "apprit");
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationApprit;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationApprit);

            DataAccess.SetTableForReading(DS.accmotiveapplied_pay, "accmotiveapplied");
            string filterEpOperationPay = QHS.CmpEq("idepoperation", "liqrit");
            DS.accmotiveapplied_pay.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationPay;
            GetData.SetStaticFilter(DS.accmotiveapplied_pay, filterEpOperationPay);
        }
    }
}
