
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Windows.Forms;
using metadatalibrary;

namespace no_table_entry_verifica {
    public partial class frmErrorView : Form {
        
        private HelpForm helpForm;
        private DataSet d;
        private DataTable t;
        private DataAccess conn;
        private string editType;
        private MetaDataDispatcher dispatcher;

        public frmErrorView(HelpForm helpForm, string title, DataTable t) {
            InitializeComponent();
            labTitolo.Text = title;
            HelpForm.SetDataGrid(dgDettaglio, t);
            this.helpForm = helpForm;
            helpForm.AddEvents(dgDettaglio);
            this.t = t;
            if (t.DataSet == null) {
                d = new DataSet();
                d.Tables.Add(t);
            }
            else {
                d = t.DataSet;
            }
            labNRighe.Text = "N. righe:" + t.Rows.Count;
        }
        public frmErrorView(HelpForm helpForm, string title, DataTable t, MetaDataDispatcher dispatcher,string editType) {
            InitializeComponent();
            labTitolo.Text = title;
            HelpForm.SetDataGrid(dgDettaglio, t);
            this.helpForm = helpForm;
            helpForm.AddEvents(dgDettaglio);
            this.dispatcher = dispatcher;
          
           
            this.t = t;
            if (t.DataSet == null) {
                d = new DataSet();
                d.Tables.Add(t);
            }
            else {
                d = t.DataSet;
            }
            conn = dispatcher.Conn;
            this.editType = editType ?? "default";
            labNRighe.Text = "N. righe:" + t.Rows.Count;
        }

      
        private void dgDettaglio_DoubleClick(object sender, EventArgs e) {
            if (dispatcher == null) return;

            DataRowView dv;
            try {
                dv = (DataRowView)dgDettaglio.BindingContext[d, t.TableName].Current;
            }
            catch {
                dv = null;
            }
            if (dv == null) return ;

            DataRow currentRow = dv.Row;
            DataTable desTable = conn.CreateTableByName(t.TableName, "*");
            MetaData dest = dispatcher.Get(t.TableName);
            var cols = (from c in desTable.PrimaryKey select c.ColumnName).ToArray();
            if (cols.Length == 0) return;
            QueryHelper qhs = conn.GetQueryHelper();
            string filter = qhs.MCmp(currentRow, cols);

            dest.ContextFilter = filter;
            dest.Edit(getMain(this), editType, false);
            var listtype = dest.DefaultListType;
            if (listtype == "") listtype = dest.DefaultListType;
            var r = dest.SelectOne(listtype, filter, null, null);
            if (r != null) dest.SelectRow(r, listtype);
            

        }

        private Form getMain(Form f) {
            if (f.ParentForm != null) return getMain(f.ParentForm);
            if (f.MdiParent != null) return getMain(f.MdiParent);
            return f.Owner != null ? getMain(f.Owner) : f;
        }
    }
}
