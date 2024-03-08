
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

namespace account_minusable {
    public partial class Frm_account_minusable :Form {
        MetaData Meta;
        public Frm_account_minusable() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            string param = Meta.ExtraParameter as string;
            string filterEsercizio = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = GetData.MergeFilters(filterEsercizio, param);
            string oldfilter = GetData.MergeFilters(null, DS.accountlevel);
            if (oldfilter != null) GetData.SetStaticFilter(DS.accountlevel, filter);
            GetData.CacheTable(DS.accountlevel);
            GetData.SetSorting(DS.accountminusable, "printingorder");
        }
        public void MetaData_AfterActivation() {
            if (tree.Nodes.Count > 0) {
                if (!tree.Nodes[0].IsExpanded) {
                    tree.Nodes[0].Expand();
                }
            }
        }

    }
}
