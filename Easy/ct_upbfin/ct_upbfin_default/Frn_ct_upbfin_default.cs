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
using funzioni_configurazione;

namespace ct_upbfin_default {
    public partial class Frn_ct_upbfin_default :Form {
        MetaData Meta;
        string filteresercizio;
        public Frn_ct_upbfin_default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.finview, filteresercizio);
            Meta.CanInsertCopy = false;
        }

        private void btnBilancio_Click(object sender, EventArgs e) {
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "";
            if (rdbSpesa.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'));
            if (rdbEntrata.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'E'));

            //Il filtro sull'UPB c'è sempre
            object idupb = Meta.GetAutoField(txtUPB);
            if (idupb != DBNull.Value){
                filter = QHS.CmpEq("idupb", idupb);
            }
            else{
                filter = QHS.CmpEq("idupb", "0001");
            }
            filter = QHS.AppAnd(filteridfin, filter);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked)
            {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            if (rdbSpesa.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treesupb");
            if (rdbEntrata.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treeeupb");
        }
    }
}
