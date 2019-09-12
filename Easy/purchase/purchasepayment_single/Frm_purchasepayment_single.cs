/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using metadatalibrary;
using System;
using System.Windows.Forms;

namespace purchasepayment_single {

    public partial class Frm_purchasepayment_single : Form {

        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;

        public Frm_purchasepayment_single() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterCler() {
            txtIUV.ReadOnly = false;
            txtCCP.ReadOnly = false;
        }

        public void MetaData_AfterFill() {
            txtIUV.ReadOnly = !Meta.InsertMode;
            txtCCP.ReadOnly = !Meta.InsertMode;
        }

        private void cmbTipoPagamento_SelectedValueChanged(object sender, EventArgs e) {
            var value = cmbTipoPagamento.SelectedValue;

            if (Convert.ToByte(value).Equals(3)) {
                txtIBAN.ReadOnly = false;
            }
            else {
                txtIBAN.ReadOnly = true;
                txtIBAN.Text = string.Empty;
            }
        }
    }

}
