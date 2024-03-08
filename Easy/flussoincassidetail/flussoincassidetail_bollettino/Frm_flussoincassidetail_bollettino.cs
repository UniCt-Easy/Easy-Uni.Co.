
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

namespace flussoincassidetail_bollettino {
	public partial class Frm_flussoincassidetail_bollettino : MetaDataForm {
		MetaData Meta;
		public Frm_flussoincassidetail_bollettino() {
			InitializeComponent();
		}
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            //QHC = new CQueryHelper();
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            GetData.SetStaticFilter(DS.flussoincassidetailview, filter);
        }
        public void MetaData_AfterFill() {
            //object modificabollettino = Conn.GetUsr("modificabollettino");
            //if (modificabollettino != null && modificabollettino.ToString().ToUpper() == "'S'") {
            //    txtUniqueFCode.ReadOnly = false;
            //}
            //else {
            //    txtUniqueFCode.ReadOnly = true;
            //}
            enableControls(false);
            txtUniqueFCode.ReadOnly = false;
        }
        public void MetaData_AfterClear() {
            enableControls(true);
            txtUniqueFCode.ReadOnly = false;
        }
        private void enableControls(bool abilita) {
            bool ReadOnly = !abilita;

            gboxBill.Enabled = abilita;
            gBoxRicevutaTelematica.Enabled = abilita;
            //GboxDettagli
            txtIUV.ReadOnly = ReadOnly;
            txtCodiceFiscale.ReadOnly = ReadOnly;
            txtImporto.ReadOnly = ReadOnly;
            txtPiva.ReadOnly = ReadOnly;
            //
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
