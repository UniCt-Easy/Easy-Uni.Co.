
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_trasf_paydisposition {
    public partial class FrmTrasfPaydisposition : MetaDataForm {
        MetaData Meta;
        public FrmTrasfPaydisposition () {
            InitializeComponent(); 
        }

        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioInizio.Text = Meta.GetSys("esercizio").ToString();
            int stopayear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1;
            int maxyear = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("accountingyear", null, "max(ayear)"));
            if (maxyear < stopayear) btnTrasferisciDisposizioni.Enabled = false;
                else btnTrasferisciDisposizioni.Enabled = true;
        }
        private void btnTrasferisciDisposizioni_Click (object sender, EventArgs e) {
            string errMsg;
            object startayear = HelpForm.GetObjectFromString(typeof(int), txtEsercizioInizio.Text.ToString(), "x.y.year");
            DataSet ds1 = Meta.Conn.CallSP("closeyear_transf_paydisposition", new object[] { startayear }, 600, out errMsg);
            if (ds1 == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Si è verificato il seguente errore nel trasferimento delle disposizioni di pagamento al nuovo esercizio:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }
            DataTable paydisposition = ds1.Tables[0];
            dataGrid.DataSource = paydisposition;
            HelpForm.SetDataGrid(dataGrid, paydisposition);
            HelpForm.SetGridStyle(dataGrid, paydisposition);
 
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Operazione eseguita", "");
        }

        private void txtEsercizio_Leave (object sender, EventArgs e) {
            TextBox TSender = (TextBox)sender;
            HelpForm.FormatLikeYear(TSender);
        }

	}
}
