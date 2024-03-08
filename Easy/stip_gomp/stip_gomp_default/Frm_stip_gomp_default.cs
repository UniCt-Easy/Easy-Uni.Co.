
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
using ep_functions;

namespace stip_gomp_default {
    public partial class Frm_stip_gomp_default : MetaDataForm {
        public Frm_stip_gomp_default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        MetaData Meta;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
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

			string filterfatacq = QHS.CmpEq("idepoperation", "fatacq");
			filterfatacq = AddAccMotiveFilter.AddAmmDepFilter(filterfatacq, Meta.Conn);
			GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterfatacq);
			DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterfatacq;
			DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");


			string filterfatacq_deb = QHS.CmpEq("idepoperation", "fatacq_deb");
			filterfatacq_deb = AddAccMotiveFilter.AddAmmDepFilter(filterfatacq_deb, Meta.Conn);
			GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterfatacq_deb);
			DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterfatacq_deb;
			DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");


			string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn);
            DS.accmotiveapplied_revenue.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotax.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotaxpost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;


			GetData.SetStaticFilter(DS.accmotiveapplied_revenue, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotax, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotaxpost, filterEpOperation);

            cmbTipoContratto.DataSource = DS.estimatekind;
        }
        public void MetaData_AfterFill() {
            if ((Meta.FirstFillForThisRow)&&(Meta.InsertMode)){
                txtAnnoregolamento.Text = Conn.GetEsercizio().ToString();
            }
        }
    }
}
