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
using metaeasylibrary;

namespace chooseBill {
   
    public partial class FrmChooseBill : Form {
        DataAccess Conn;
        MetaData Meta;
        DataTable TBill;
        DataSet DS;
        public FrmChooseBill(MetaData Meta,string basefilter) {
            InitializeComponent();
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            QueryHelper QHS = Conn.GetQueryHelper();            
            string filter = QHS.AppAnd(Conn.SelectCondition("billview", true),
                        QHS.CmpEq("active", "S"),
                        "(isnull(total,0)-isnull(reduction,0)>covered)", "(ISNULL(toregularize,0)>0)",
                        basefilter
                        );

            TBill = Conn.RUN_SELECT("billview", "*", "nbill desc", filter, null, false);
            DS = new DataSet("a");
            DS.Tables.Add(TBill);
            FormatDataGrid(TBill);
            HelpForm.SetDataGrid(gridBill, TBill);
        }
        public  DataRow [] GetGridSelectedRows() {
            DataGrid G = gridBill;
            string dataMember = G.DataMember;
            CurrencyManager cm = (CurrencyManager)G.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return new DataRow[]{};
            List<DataRow> lr = new List<DataRow>();
            for (int i = 0; i < view.Count; i++) {
                if (G.IsSelected(i)) {
                    lr.Add(view[i].Row);
                }
            }

            return lr.ToArray();
        }

        private void FormatDataGrid(DataTable tResult) {
            MetaData MBill = Meta.Dispatcher.Get("billview");
            MBill.DescribeColumns(TBill, "default");
            

            HelpForm.SetGridStyle(gridBill, tResult);
            metadatalibrary.formatgrids fg = new formatgrids(gridBill);
            fg.AutosizeColumnWidth();
        }
        
    }
}
