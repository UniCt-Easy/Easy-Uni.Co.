
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
using funzioni_configurazione;

namespace no_table_trasf_prevision_in_budget {
    public partial class FrmTrasfPrevisionInBudget : Form {
        MetaData Meta;
        int ayear;
        int idsorkind;
        public FrmTrasfPrevisionInBudget () {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.MainRefreshEnabled = false;
            Meta.searchEnabled = false;
            ayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            idsorkind = CfgFn.GetNoNullInt32(Meta.ExtraParameter);
        }

        public void MetaData_AfterActivation()
        {
            if ((idsorkind == 0)||(idsorkind == null)) return;
            DataTable CurrTipo = Meta.Conn.RUN_SELECT("sortingkind","*",null, QHS.CmpEq("idsorkind", idsorkind),null, false);
            if (CurrTipo.Rows.Count == 0) return; 
            Meta.Name = "Trasferimento Budget per  \"" + CurrTipo.Rows[0]["description"].ToString() + "\"";
        }
        private void btnTrasferisciPrevisioni_Click (object sender, EventArgs e) {
            string errMsg;
            Meta.Conn.CallSP("compute_transf_prevision_in_budget", new object[] {ayear,
            idsorkind}, 600, out errMsg);
            if (errMsg!=null)
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore", errMsg);
            else
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Operazione eseguita");
        }

        private void btnTrasferisciVariazioni_Click(object sender, EventArgs e)
        {
            bool Sovrascrivi = chkSovrascrivi.Checked;
            string errMsg;
            if (Sovrascrivi)
                Meta.Conn.CallSP("compute_transf_finvar_in_budgetvar", new object[] {ayear,
                idsorkind, "S"}, 600, out errMsg);
                else
                Meta.Conn.CallSP("compute_transf_finvar_in_budgetvar", new object[] {ayear,
                idsorkind, "N"}, 600, out errMsg);

            if (errMsg != null)
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore", errMsg);
            else
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Operazione eseguita");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
