/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
namespace sisest_causale_default {
    public partial class Frm_sisest_causale_default :Form {
        MetaData Meta;
        public Frm_sisest_causale_default() {
            InitializeComponent();
        }
        QueryHelper QHS;

       public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_bollo, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_bollo_credit, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_regionale, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_regionale_credit, "accmotiveapplied");

            string filterEpOperationFatVen = QHS.CmpEq("idepoperation", "fatven");
            string filterEpOperationFatVen_cred= QHS.CmpEq("idepoperation", "fatven_cred");

            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen;
            DS.accmotiveapplied_bollo.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen;
            DS.accmotiveapplied_regionale.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen;

            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen_cred;
            DS.accmotiveapplied_bollo_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen_cred;
            DS.accmotiveapplied_regionale_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationFatVen_cred;


            DataAccess.SetTableForReading(DS.finmotive_bollo, "finmotive");
            DataAccess.SetTableForReading(DS.finmotive_regionale, "finmotive");
            int anno = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            int annosucc = anno + 1;
            rdbA.Text = "Anno accademico 01/11/" + anno.ToString() + " - 31/10/" + annosucc.ToString();
            rdbB.Text = "Anno corrente 01/01/"   + anno.ToString() + " - 31/12/" + anno.ToString();
        }
        public void MetaData_AfterClear() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
        }
        private void txtEsercizio_TextChanged(object sender, EventArgs e) {

        }
    }
}
