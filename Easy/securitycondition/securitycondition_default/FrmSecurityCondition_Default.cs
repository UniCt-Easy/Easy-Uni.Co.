
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace securitycondition_default {
    public partial class FrmSecurityCondition_Default : MetaDataForm {
        MetaData meta;
        public FrmSecurityCondition_Default() {
            InitializeComponent();
            DS.securitycondition.Columns["allowcondition"].ExtendedProperties["sqltype"] = "text";
            DS.securitycondition.Columns["denycondition"].ExtendedProperties["sqltype"] = "text";
        }

        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            bool IsAdmin = false;
            if (meta.GetSys("IsSystemAdmin") != null) {
                IsAdmin = (bool)meta.GetSys("IsSystemAdmin");
            }

            if (!IsAdmin) {
                meta.CanSave = false;
                meta.CanInsert = false;
                meta.CanCancel = false;
                meta.CanInsertCopy = false;
            }
            GetData.SetStaticFilter(DS.securitycondition, "(operation<>'P')");
        }

        public void MetaData_AfterFill() {
            ControlloVC();
        }

        public void ControlloVC() {
            txtBoxConsenti.Enabled = true;
            txtBoxDivieto.Enabled = true;
            if (meta.IsEmpty) {
                return;
            }
            if ((rdbConsenti.Checked == true) && (txtBoxDivieto.Text == "")) {
                txtBoxConsenti.Enabled = false;
                txtBoxDivieto.Enabled = true;
            }
            if ((rdbVieta.Checked == true) && (txtBoxConsenti.Text == "")) {
                txtBoxDivieto.Enabled = false;
                txtBoxConsenti.Enabled = true;
            }
        }


        public void MetaData_AfterClear() {
            txtBoxDivieto.Enabled = true;
            txtBoxConsenti.Enabled = true;
        }

        private void rdbVieta_CheckedChanged(object sender, EventArgs e) {
            ControlloVC();
        }

        private void rdbConsenti_CheckedChanged(object sender, EventArgs e) {
            ControlloVC();
        }
    }
}
