
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

namespace registryspecialcategory770_detail {
    public partial class Frm_registryspecialcategory770_detail : MetaDataForm {
        private MetaData Meta;
        QueryHelper QHS;
        public Frm_registryspecialcategory770_detail() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            GetData.SetStaticFilter(DS.specialcategory770, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
        }
        private void txtAppunti_TextChanged(object sender, EventArgs e) {

        }

        private void cmbTipoIndirizzo_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void txtAppunti_TextChanged_1(object sender, EventArgs e) {

        }
    }
}
