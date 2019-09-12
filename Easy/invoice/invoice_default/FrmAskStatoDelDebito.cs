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
using funzioni_configurazione;

namespace invoice_default {
    public partial class FrmAskStatoDelDebito : Form {
      
        MetaData MCausali;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable PccDebitStatus;
        public object idpccdebitmotive;
        public FrmAskStatoDelDebito(MetaData Meta, DataTable PccDebitStatus, object idpccdebitstatusDefault) {
            InitializeComponent();

            this.Conn = Meta.Conn; 
            cmbStatodeldebito.DataSource = PccDebitStatus;
            cmbStatodeldebito.ValueMember = "idpccdebitstatus";
            cmbStatodeldebito.DisplayMember = "description";

            if (idpccdebitstatusDefault != DBNull.Value)
                HelpForm.SetComboBoxValue(cmbStatodeldebito, idpccdebitstatusDefault);
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            this.PccDebitStatus = PccDebitStatus;
            MCausali =Meta.Dispatcher.Get("pccdebitmotive"); 
            MCausali.FilterLocked = true;
        }

        private void btnCasuale_Click(object sender, EventArgs e)
        {
            
            object idpccdebitstatus = DBNull.Value;
            string filter = "";
            if (cmbStatodeldebito.SelectedIndex > 0) idpccdebitstatus = cmbStatodeldebito.SelectedValue;

            if (idpccdebitstatus != DBNull.Value)
            {
                 
                int maskorder = CfgFn.GetNoNullInt32(PccDebitStatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);
                filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            }

      
            //MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;

            idpccdebitmotive = Choosen["idpccdebitmotive"];
            txtCausale.Text = Choosen["description"].ToString();
        }

        
    }
}


