
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace customindirectrelcol_single {
    public partial class frmcustomindirectrelcol_single :Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        public frmcustomindirectrelcol_single() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.columntypes_middle, "columntypes");
            DataAccess.SetTableForReading(DS.columntypes_parent, "columntypes");
            this.padre1.CheckedChanged += new System.EventHandler(this.padre_CheckedChanged);
            this.padre2.CheckedChanged += new System.EventHandler(this.padre_CheckedChanged);

        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Dispatcher = Meta.Dispatcher as EntityDispatcher;
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
            QHS = Conn.GetQueryHelper();
            //bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
            string table1 = null;
            string table2 = null;
            System.Data.DataRow rCustomindirectrelcol = Meta.SourceRow;
            System.Data.DataRow rCustomindirectrel = rCustomindirectrelcol.GetParentRow("customindirectrel_customindirectrelcol");
            table1 = rCustomindirectrel["middletable"].ToString();
            if (padre1.Checked) table2 = rCustomindirectrel["parenttable1"].ToString();
            if (padre2.Checked) table2 = rCustomindirectrel["parenttable2"].ToString();
            this.MiddleTable.Tag = "AutoChoose.txtFromTable.default.(tablename='" + table1 + "')";
            this.MiddleTable.Text = "Tabella centrare ("+table1+")";
            this.ParentTable.Tag = "AutoChoose.txtToTable.default.(tablename='" + table2 + "')";
            this.ParentTable.Text = "Tabella padre (" + table2 + ")";
        }

        private void padre_CheckedChanged(object sender, System.EventArgs e) {

            string table2 = null;
            System.Data.DataRow rCustomindirectrelcol = Meta.SourceRow;
            System.Data.DataRow rCustomindirectrel = rCustomindirectrelcol.GetParentRow("customindirectrel_customindirectrelcol");

            if (padre1.Checked) table2 = rCustomindirectrel["parenttable1"].ToString();
            if (padre2.Checked) table2 = rCustomindirectrel["parenttable2"].ToString();

            this.ParentTable.Tag = "AutoChoose.txtToTable.default.(tablename='" + table2 + "')";
            this.ParentTable.Text = "Tabella padre (" + table2 + ")";

            Meta.SetAutoMode(ParentTable);

        }

        public void MetaData_AfterActivation() {}
        public void MetaData_AfterClear() {}
        public void MetaData_BeforeFill() { }
        public void MetaData_AfterFill() {
                txtFromTable.ReadOnly = false;
                txtToTable.ReadOnly = false;
                padre1.Enabled = true;
                padre2.Enabled = true;
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {}
        public void MetaData_BeforePost() {}
        public void MetaData_AfterPost() {}

    }
}
