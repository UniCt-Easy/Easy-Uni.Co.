
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace config_pagopa_default {
    public partial class frmconfig_pagopa_default :Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        bool CanGoEdit;
        bool CanGoInsert;

        public frmconfig_pagopa_default() {
            InitializeComponent();
            CanGoEdit = true;
        }
        public void MetaData_AfterLink() {

            Meta = MetaData.GetMetaData(this);
            int numrighe = Meta.Conn.RUN_SELECT_COUNT("config_pagopa", null, true);
            if (numrighe == 1) {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else {
                CanGoInsert = true;
                CanGoEdit = false;
            }



            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;

        }



        public void MetaData_AfterClear() {
            if (CanGoInsert) {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit) {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); 
            }


        }

        //public void MetaData_AfterActivation() { }
        //public void MetaData_BeforeFill() {}
        //public void MetaData_AfterFill() {}
        //public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
        //public void MetaData_BeforePost() { }
        //public void MetaData_AfterPost() { }

    }
}
