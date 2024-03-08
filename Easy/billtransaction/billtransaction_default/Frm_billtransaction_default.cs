
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
using funzioni_configurazione;

namespace billtransaction_default {
    public partial class Frm_billtransaction_default : MetaDataForm {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;
        public Frm_billtransaction_default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            string filterPay = QHS.CmpEq("ypay", esercizio);
            string filterPro = QHS.CmpGe("ypro", esercizio);
            string filtroSpesa = QHS.AppAnd(QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), QHS.IsNotNull("idpay"));
            filtroSpesa = GetData.MergeFilters(filterEsercizio, filtroSpesa);
            HelpForm.SetDenyNull(DS.billtransaction.Columns["nbill"], true);
        }

        public void MetaData_AfterActivation() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
        }

        public void MetaData_AfterClear() {
        }

        public void MetaData_AfterFill() {
           
            if (Meta.InsertMode && Meta.FirstFillForThisRow)
                txtNumBolletta.Text = "";
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
        }



    }
}
