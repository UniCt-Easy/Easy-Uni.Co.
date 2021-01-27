
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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

namespace securityvar_default {
    public partial class FrmSecurityVar_Default : Form {
        MetaData Meta;
        public FrmSecurityVar_Default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

        public void MetaData_AfterFill() {
            DataAccess Conn = Meta.Conn;
            if (((bool)Meta.GetSys("IsSystemAdmin")) == false) {
                if (!Meta.InsertMode) {
                    grpTipo.Enabled = false;
                    txtValore.ReadOnly = true;
                }
            }
            if (Meta.EditMode) {
                string varname = txtVarName.Text;
                txtActualValue.Text = "";
                if (Meta.GetUsr(varname) != null) txtActualValue.Text = Meta.GetUsr(varname).ToString();
            }
        }
    }
}
