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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace customdirectrelcol_single {
    public partial class frmcustomdirectrelcol_single :Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        public frmcustomdirectrelcol_single() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.columntypes1, "columntypes");

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
            DataRow rCustomdirectrelcol = Meta.SourceRow;
            DataRow rCustomdirectrel = rCustomdirectrelcol.GetParentRow("customdirectrel_customdirectrelcol");
            table1 = rCustomdirectrel["fromtable"].ToString();
            table2 = rCustomdirectrel["totableview"].ToString();
            if (table2=="") table2 = rCustomdirectrel["totable"].ToString();
            this.FromTable.Tag = "AutoChoose.txtFromTable.default.(tablename='" + table1 + "')";
            this.FromTable.Text = "Colonna di partenza ("+table1+")";
            this.ToTable.Tag = "AutoChoose.txtToTable.default.(tablename='" + table2 + "')";
            this.ToTable.Text = "Colonna di arrivo ("+table2+")";


        }

        public void MetaData_AfterActivation() { }
        public void MetaData_AfterClear() {}
        public void MetaData_BeforeFill() {}
        public void MetaData_AfterFill() {
            txtFromTable.ReadOnly = false;
            txtToTable.ReadOnly = false;
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {}
        public void MetaData_BeforePost() { }
        public void MetaData_AfterPost() { }

    }
}
