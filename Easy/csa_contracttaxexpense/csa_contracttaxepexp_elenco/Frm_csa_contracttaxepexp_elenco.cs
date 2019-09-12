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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace csa_contracttaxepexp_elenco {
    public partial class Frm_csa_contracttaxepexp_elenco :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_contracttaxepexp_elenco() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
 
            HelpForm.SetDenyNull(DS.csa_contracttaxepexp.Columns["idepexp"], true);
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.csa_contracttaxepexp, filter);
            GetData.SetStaticFilter(DS.csa_contracttaxepexpview, filter);
            GetData.SetStaticFilter(DS.epexpview, filter);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.CanCancel = false;

        }
        public void MetaData_AfterFill() {
            enableControls(false);
            VisualizzaFaseImpegno();
        }

        private void VisualizzaFaseImpegno() {
            if (MetaData.Empty(this)) return;
            

            if (DS.epexp.Rows.Count > 0) {
                object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
                HelpForm.SetComboBoxValue(cmbFaseSpesa, currtipo);
            }
        }


        public void MetaData_AfterClear() {
            enableControls(true);
            cmbFaseSpesa.SelectedIndex = -1;
        }

 

        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;
            gboxSpesa.Enabled = abilita;
            grpContrattoCSA.Enabled = abilita;
            txtQuota.ReadOnly = readOnly;
            txtEsercizio.ReadOnly = readOnly;
        }

    }
}
