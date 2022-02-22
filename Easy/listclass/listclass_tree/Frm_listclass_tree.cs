
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace listclass_tree{
    public partial class Frm_listclass_tree : MetaDataForm{
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public Frm_listclass_tree() {
            InitializeComponent();
        }

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string CurrEditType = Meta.edit_type;
            string filter = Meta.GetFilterForSearch(DS.listclass); 
            switch (CurrEditType) {
                case "estimatetree":
                        filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 2), filter);
                        break;
                case "mandatetree":
                    filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 1), filter);
                        break;
                case "bookingtree":
                    filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 0), filter);
                     break;
                default:
                    break;
            }
            GetData.SetStaticFilter(DS.listclass, filter);
        }

        public void MetaData_AfterActivation(){
            if (tree.Nodes.Count > 0){
                if (!tree.Nodes[0].IsExpanded){
                    tree.Nodes[0].Expand();
                }
            }
        }
    }
}
