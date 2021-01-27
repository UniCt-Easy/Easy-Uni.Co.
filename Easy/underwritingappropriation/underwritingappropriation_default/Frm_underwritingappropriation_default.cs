
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace underwritingappropriation_default {
    public partial class Frm_underwritingappropriation_default : Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_underwritingappropriation_default() {
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

            txtYmovExpense.Text = Meta.GetSys("esercizio").ToString();
        }
        private void btnSelectMov_Click(object sender, EventArgs e)
        {
            string MyFilter;

            if (((Control)sender).Name == "txtNmovExpense")
                MyFilter = GetFilterExpense(true);
            else
                MyFilter = GetFilterExpense(false);

            MetaData MFase = MetaData.GetMetaData(this, "expense");
            MFase.FilterLocked = true;
            MFase.DS = DS;

            DataRow MyDR = MFase.SelectOne("default", MyFilter, null, null);

            if (MyDR == null)
            {
                if (Meta.InsertMode)
                {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType()))
                    {
                        if (((TextBox)sender).Text.Trim() != "") ((TextBox)sender).Focus();
                    }
                }
                return;
            }
            txtFaseSpesa.Text = MyDR["phase"].ToString();
            txtYmovExpense.Text = MyDR["ymov"].ToString();
            txtNmovExpense.Text = MyDR["nmov"].ToString();
        }

        string GetFilterExpense(bool IsNumMov)
        {
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
          
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov",  Meta.GetSys("esercizio")));

            if ((IsNumMov) && (txtNmovExpense.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNmovExpense.Text.Trim()));

            return MyFilter;
        }

        private void txtYmovExpense_Leave(object sender, EventArgs e)
        {
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtYmovExpense);		
        }

        private void FormattaDataDelTexBox(TextBox TB)
        {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }

        private void txtNmovExpense_Leave(object sender, System.EventArgs e)
        {
            if (txtNmovExpense.Text.Trim() == "")
            {
                ClearExpense();
                return;
            }
            btnSelectMov_Click(sender, e);
        }
        void ClearExpense()
        {
            DS.expense.Clear();
            txtFaseSpesa.Text = "";
           
            txtNmovExpense.Text = "";
        }

          public void MetaData_AfterFill() {
            enableControls(false);
        }

        public void MetaData_AfterClear() {
            enableControls(true);
            txtYmovExpense.Text = Meta.GetSys("esercizio").ToString();
        }

        private void enableControls(bool abilita)
        {
            bool readOnly = !abilita;

            //gboxMovimento.Enabled = abilita;
            btnSelectMov.Enabled = abilita;
            txtYmovExpense.ReadOnly = readOnly;
            txtNmovExpense.ReadOnly = readOnly;

            //txtYmovExpense.ReadOnly = readOnly;
            //txtNmovExpense.ReadOnly = readOnly;
            //gboxFinanziamento.Enabled = abilita;
            btnFinanziamento.Enabled = abilita;
            txtUnderwriting.ReadOnly = readOnly;
            gboxResponsabile.Enabled = abilita;
            txtAdateExpense.ReadOnly = readOnly;
            txtAmount.ReadOnly = readOnly;
            txtDescrExpense.ReadOnly = readOnly;
            //groupCredDeb.Enabled = abilita;
            txtCredDeb.ReadOnly = readOnly;
            txtDocumento.ReadOnly = readOnly;
            txtDataDocumento.ReadOnly = readOnly;
        }
    }
}
