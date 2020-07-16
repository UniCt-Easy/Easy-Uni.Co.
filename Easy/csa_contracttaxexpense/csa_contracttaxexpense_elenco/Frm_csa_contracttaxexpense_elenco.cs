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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace csa_contracttaxexpense_elenco {
    public partial class Frm_csa_contracttaxexpense_elenco :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_contracttaxexpense_elenco() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_contracttaxexpense.Columns["idexp"], true);
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.csa_contracttaxexpense, filter);
            GetData.SetStaticFilter(DS.csa_contracttaxexpenseview, filter);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.CanCancel = false;
        }
        public void MetaData_AfterFill() {
            enableControls(false);
        }
        public void MetaData_AfterClear() {
            enableControls(true);
        }
       
        private void enableControls(bool abilita) {
            bool readOnly = !abilita;
            gboxSpesa.Enabled = abilita;
            grpContrattoCSA.Enabled = abilita;
            txtQuota.ReadOnly = readOnly;
            txtEsercizio.ReadOnly = readOnly;
            txtVoceCsa.ReadOnly = readOnly;
        }

    }
}
