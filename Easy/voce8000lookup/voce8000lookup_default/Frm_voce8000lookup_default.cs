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

namespace voce8000lookup_default {
    public partial class Frm_voce8000lookup_default : Form {
        public Frm_voce8000lookup_default() {
            InitializeComponent();
        }

        private MetaData Meta;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            QueryHelper QHC = new CQueryHelper();
            bool IsAdmin = false;


            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;

            DataAccess.SetTableForReading(DS.voce8000_impon, "voce8000");
            DataAccess.SetTableForReading(DS.voce8000_quotaesente, "voce8000");
            GetData.SetStaticFilter(DS.voce8000lookup, QHC.IsNotNull("conto"));
            string filter_voce8000 = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("kind", "I"));
            GetData.SetStaticFilter(DS.voce8000_impon, filter_voce8000);
            GetData.SetStaticFilter(DS.voce8000_quotaesente, QHS.CmpEq("active", "S"));
            HelpForm.SetDenyNull(DS.voce8000lookup.Columns["flagcsausability"], true);
            VisualizzaCheckBox();
        }


        private void VisualizzaCheckBox()
        {
            int n_chk = 8;
            for (int i = 1; i <= (n_chk - 1); i++)
            {
                CheckBox chk = GetCtrlByName("chkCsaUsability" + n_chk.ToString()) as CheckBox;
                if (chk == null) return;
                chk.Visible = false;
            }

            string num = ""; int bitposition = 0;
            DataTable tservicecsausability = Meta.Conn.RUN_SELECT("servicecsausability", "*", null, null, null, null, true);
            foreach (DataRow r in tservicecsausability.Rows)
            {
                num = r["idlabel"].ToString();
                bitposition = CfgFn.GetNoNullInt32(r["bitposition"]);
                string dicitura = r["description"].ToString();

                CheckBox CB = GetCtrlByName("chkCsaUsability" + num) as CheckBox;
                if (CB == null)
                    continue;
                CB.Text = dicitura;
                CB.Tag = "voce8000lookup.flagcsausability:" + bitposition.ToString();
                CB.Visible = true;
            }

        }

        private object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }
    }
}
