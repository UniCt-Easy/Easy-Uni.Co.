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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace finview_treealle {
    public partial class Frm_finview_treealle : Form {
        public Frm_finview_treealle() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            DataAccess Conn = MetaData.GetConnection(this);
            string param = Meta.ExtraParameter as string;

            string filter = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            string staticfilter = param;
            GetData.SetStaticFilter(DS.finview, param);

            string oldfilter = GetData.MergeFilters(null, DS.finlevel);
            if (oldfilter != null) GetData.SetStaticFilter(DS.finlevel, filter);
            GetData.CacheTable(DS.finlevel);
            GetData.SetSorting(DS.finview, "printingorder");

            int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
            if (finkind==3) {
                dataGrid1.Tag = "TreeNavigator.tree2";
            }

        }

    }
}