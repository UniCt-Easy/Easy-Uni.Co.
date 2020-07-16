/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace authpaymentexpense_single {
    public partial class FrmAuthPaymentExpense_Single : Form {
        public FrmAuthPaymentExpense_Single() {
            InitializeComponent();
        }

        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        object idReg;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            idReg = Meta.ExtraParameter;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            string excludeIdExp = "";

            DataRow rParent = Meta.SourceRow;
            DataRow rAuthPayment = rParent.GetParentRow("authpayment_authpaymentexpense");
            if (rAuthPayment != null) {
                DataRow[] Figli = rAuthPayment.GetChildRows("authpayment_authpaymentexpense");
                if (Figli != null) {
                    excludeIdExp = QHS.FieldNotIn("idexp", Figli);
                }
            }
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), QHS.CmpEq("idreg", idReg),
                excludeIdExp);
            GetData.SetStaticFilter(DS.expenseview, filter);
        }

        private void fillDetail() {
            DataRow r = Meta.SourceRow;
            string filter = QHS.CmpEq("idexp", r["idexp"]);
            DataTable t = DataAccess.CreateTableByName(Meta.Conn, "expenseview", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, t, null, filter, null, true);

            if ((t == null) || (t.Rows.Count == 0)) return;
            
            DataRow rCurr = t.Rows[0];
            txtEsercizioMovimento.Text = rCurr["ymov"].ToString();
            txtNumeroMovimento.Text = rCurr["nmov"].ToString();
            txtCredDeb.Text = rCurr["registry"].ToString();
            txtDescrizione.Text = rCurr["description"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(rCurr["amount"]).ToString("c");
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(rCurr["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(rCurr["available"]).ToString("c");

            
        }

        public void MetaData_AfterActivation() {
            if (Meta.SourceRow != null) {
                fillDetail();
                if (Meta.SourceRow.RowState != DataRowState.Added) {
                    gboxMovimento.Enabled = false;
                }
            }

            string filter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
            object phase = Meta.Conn.DO_READ_VALUE("expensephase", filter, "description");
            if (phase == null) return;
            txtFase.Text = phase.ToString();

            txtEsercizioMovimento.Text = Meta.GetSys("esercizio").ToString();
        }

        string GetFasePrecFilter(bool FiltraNumMovimento) {
            string ffase = "";
            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (txtEsercizioMovimento.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim()));
            if ((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroMovimento.Text.Trim()));

            MyFilter = QHS.AppAnd(MyFilter, "(NOT EXISTS(SELECT * FROM authpaymentexpense " +
                " WHERE authpaymentexpense.idexp = expenseview.idexp))");

            return MyFilter;
        }

        private void btnSelectMov_Click(object sender, EventArgs e) {
            if (DS.authpaymentexpense.Rows.Count == 0) return;
            DataRow CurrAuthExp = DS.authpaymentexpense.Rows[0];
            
            string MyFilter;

            if (((Control)sender).Name == "txtNumeroMovimento")
                MyFilter = GetFasePrecFilter(true);
            else
                MyFilter = GetFasePrecFilter(false);

            MetaData MFase = MetaData.GetMetaData(this, "expense");
            MFase.FilterLocked = true;
            MFase.DS = DS;

            DataRow MyDR = MFase.SelectOne("default", MyFilter, null, null);

            if (MyDR == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox)sender).Text.Trim() != "") ((TextBox)sender).Focus();
                    }
                }

                txtEsercizioMovimento.Text = "";
                txtNumeroMovimento.Text = "";
                txtCredDeb.Text = "";
                txtDescrizione.Text = "";
                SubEntity_txtImportoMovimento.Text = "";
                txtImportoCorrente.Text = "";
                txtImportoDisponibile.Text = "";

                return;
            }

            CurrAuthExp["idexp"] = MyDR["idexp"];
            txtEsercizioMovimento.Text = MyDR["ymov"].ToString();
            txtNumeroMovimento.Text = MyDR["nmov"].ToString();
            txtCredDeb.Text = MyDR["registry"].ToString();
            txtDescrizione.Text = MyDR["description"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
        }
    }
}