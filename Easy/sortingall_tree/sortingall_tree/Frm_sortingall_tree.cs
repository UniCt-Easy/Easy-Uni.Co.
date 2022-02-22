
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace sortingall_tree {
    public partial class Frm_sortingall_tree : MetaDataForm {
        public Frm_sortingall_tree() {
            InitializeComponent();
        }
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            DataTable FilterTable = MetaData.GetMetaData(this).ExtraParameter as DataTable;
            MetaData Meta = MetaData.GetMetaData(this);
            int esercizio = (int)Meta.GetSys("esercizio");
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
            if (FilterTable != null) {
                //DS.classmovimenti.ExtendedProperties[HelpForm.FilterTree] = FilterTable;
                if (FilterTable.Rows.Count == 0) {
                    HelpForm.SetFilterToTree(DS.sortingall, FilterTable);
                    return;
                }
                DataRow OneRow = FilterTable.Rows[0];
                string filtercodice = QHS.CmpEq("idsorkind", OneRow["idsorkind"]);
                GetData.CacheTable(DS.sortinglevel, filtercodice, null, false);
                FilterTable.ExtendedProperties["idsorkindFilter"] = filtercodice;
                HelpForm.SetFilterToTree(DS.sortingall, FilterTable);
            }
            else {
                object filter = MetaData.GetMetaData(this).ExtraParameter;
                string f = null;
                if (filter != null) f = filter.ToString();
                GetData.CacheTable(DS.sortinglevel, f, null, false);
                GetData.SetStaticFilter(DS.sortingall,
                    QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio"))));
            }
            if (Meta.edit_type == "tree5") {
                tree.Tag = "sortingall.tree5";
            }
        }

    }
}
