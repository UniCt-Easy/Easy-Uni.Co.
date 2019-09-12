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

namespace sdi_acquisto_default {
    public partial class FrmAskAnagrafica : Form {
        MetaData Meta;
        MetaDataDispatcher Disp;
        MetaData MetaRegistry;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public object idreg;

        public FrmAskAnagrafica(MetaData Meta, MetaDataDispatcher Disp) {
            InitializeComponent();
            this.Meta = Meta;
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            this.Disp = Disp;
            MetaRegistry = Disp.Get("registrymainview");
        }

        private void txtAnagrafica_Leave(object sender, EventArgs e) {
            string reg = txtAnagrafica.Text;
            if (!reg.EndsWith("%"))
                reg += "%";

                string filter = QHS.AppAnd(QHS.Like("title", reg), QHS.CmpEq("active", 'S'));
                MetaRegistry.FilterLocked = true;
                DataRow R = MetaRegistry.SelectOne("default", filter, null, null);
                if (R == null)
                    return;

                idreg = R["idreg"];
                txtAnagrafica.Text = R["title"].ToString();
        }

        
    }
}


