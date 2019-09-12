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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
namespace flussoincassidetail_default {
    public partial class Frm_flussoincassidetail_default :Form {
        MetaData Meta;
        public Frm_flussoincassidetail_default() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filter = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            GetData.SetStaticFilter(DS.flussoincassidetailview, filter);
        }
        public void MetaData_AfterFill() {
            enableControls(false);
        }
        public void MetaData_AfterClear() {
            enableControls(true);
        }
        private void enableControls(bool abilita) {
            bool ReadOnly = !abilita;

            gboxBill.Enabled = abilita;
            gboxDettagli.Enabled = abilita;
            txtEsercizio.ReadOnly = ReadOnly;
            txtDataIncasso.ReadOnly = ReadOnly;
            txtCodiceFiscale.ReadOnly = ReadOnly;
            txtCausale.ReadOnly = ReadOnly;
            txtTRN.ReadOnly = ReadOnly;
            txtImportoTotale.ReadOnly = ReadOnly;
            chbAttivo.Enabled = abilita;
            chbElaborato.Enabled = abilita;
        }
    }
}
