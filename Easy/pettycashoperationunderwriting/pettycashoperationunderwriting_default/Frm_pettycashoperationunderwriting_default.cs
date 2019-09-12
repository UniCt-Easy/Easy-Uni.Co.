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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace pettycashoperationunderwriting_default{
    public partial class Frm_pettycashoperationunderwriting_default : Form{
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_pettycashoperationunderwriting_default(){
            InitializeComponent();
        }
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.CacheTable(DS.manager, null, "title", true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;

            txtEsercOp.Text = Meta.GetSys("esercizio").ToString();
        }

        void ClearExpense(){
            DS.pettycashoperation.Clear();
            txtNumOp.Text = "";
        }

        public void MetaData_AfterFill(){
            enableControls(false);
        }

        public void MetaData_AfterClear()
        {
            enableControls(true);
            txtEsercOp.Text = Meta.GetSys("esercizio").ToString();
        }

        private void enableControls(bool abilita){
            bool readOnly = !abilita;

            txtEsercOp.ReadOnly = readOnly;
            txtNumOp.ReadOnly = readOnly;
            btnFinanziamento.Enabled = abilita;
            txtUnderwriting.ReadOnly = readOnly;
            txtAdateExpense.ReadOnly = readOnly;
            txtAmount.ReadOnly = readOnly;
            txtDescrExpense.ReadOnly = readOnly;
            txtCredDeb.ReadOnly = readOnly;
            txtDocumento.ReadOnly = readOnly;
            txtDataDocumento.ReadOnly = readOnly;
        }

        private void txtEsercOp_Leave(object sender, EventArgs e)
        {
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercOp);	
        }

        private void FormattaDataDelTexBox(TextBox TB)
        {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }
    }
}