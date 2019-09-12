/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

namespace dbuser_alert {
    public partial class FrmDbuserAlert : Form {
        public FrmDbuserAlert() {
            InitializeComponent();
        }
        bool primo = true;
        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.alert, null, "description", false);
            GetData.SetStaticFilter(DS.dbuser, QHS.CmpEq("login", Meta.GetSys("user")));
            //GetData.SetStaticFilter(DS.useralert, QHS.CmpEq("login", Meta.GetSys("user")));
        }
        public void MetaData_AfterClear() {
            if (primo) {
                primo = false;
                MetaData.DoMainCommand(this, "maindosearch");
            }
        }
    }
}