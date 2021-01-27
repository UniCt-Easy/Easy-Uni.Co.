
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

namespace authpayment_default {
    public partial class FrmAuthPayment_Default : Form {
        public FrmAuthPayment_Default() {
            InitializeComponent();
        }

        object lastSentDate;

        bool inChiusura = false;
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filter = QHS.CmpEq("yauthpayment", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.authpayment, filter);

            string filterExp = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")));
            GetData.SetStaticFilter(DS.expenseview, filterExp);

            GetData.SetSorting(DS.authstatus, "idauthstatus");
        }

        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                DataRow Curr = DS.authpayment.Rows[0];
                DS.authpaymentexpense.ExtendedProperties[MetaData.ExtraParams] = Curr["idreg"];

                lastSentDate = Curr["sent_date"];

                DataRow [] AuthStatus = DS.authstatus.Select(QHC.CmpEq("idauthstatus",Curr["idauthstatus"]));
                if (AuthStatus.Length > 0) {
                    DataRow rAuthStatus = AuthStatus[0];
                    txtNoteStato.Text = rAuthStatus["explanation"].ToString();
                }

            }

            if ((Meta.InsertMode) || (Meta.EditMode)) {
                aggiungiAltriMovimenti();
                GetData GD = new GetData();
                GD.InitClass(DS, Meta.Conn, "authpaymentexpense");
                GD.GetTemporaryValues(DS.authpaymentexpense);
            }

            CalcolaImporto();
        }

        private void CalcolaImporto() {
            DataSet MyDS = (DataSet)dgDetail.DataSource;
            DataTable MyTable = MyDS.Tables[dgDetail.DataMember.ToString()];
            decimal importo = 0;
            importo = MetaData.SumColumn(MyTable, "!curramount");
            txtTotale.Text = importo.ToString("C");
        }

        private void aggiungiAltriMovimenti() {
            if (DS.authpayment.Rows.Count == 0) return;
            DataTable tInfo = DataAccess.CreateTableByName(Meta.Conn, "expenseview", "*");
            DataRow Curr = DS.authpayment.Rows[0];
            MetaData MetaAuthExp = MetaData.GetMetaData(this, "authpaymentexpense");
            MetaAuthExp.SetDefaults(DS.authpaymentexpense);
            foreach (DataRow r in DS.authpaymentexpense.Select()) {
                if (r.RowState != DataRowState.Added) continue;
                string filterExpense = QHS.CmpEq("idexp", r["idexp"]);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInfo, null, filterExpense, null, true);
                
                DataRow[] Main = tInfo.Select(QHC.CmpEq("idexp", r["idexp"]));
                if (Main.Length == 0) {
                    Meta.LogError($"FrmAuthPayment_Default.aggiungiAltriMovimenti(): Movimento di ID {r["idexp"]} non trovato", null);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show($"Movimento di ID {r["idexp"]} non trovato, probabilmente è stato cancellato", "Errore");
                    continue;
                }

                DataRow rExp = Main[0];
                string query = "SELECT * FROM expenselast " +
                    " JOIN expense ON expense.idexp = expenselast.idexp " +
                    " WHERE " + QHS.AppAnd(QHS.CmpEq("expenselast.kpay", rExp["kpay"]),
                    QHS.IsNotNull("expenselast.kpay"),
                    QHS.CmpEq("expense.idreg", rExp["idreg"]),
                    $"(NOT EXISTS (SELECT * FROM authpaymentexpense  WHERE idexp = expenselast.idexp))",
                    QHS.CmpNe("expenselast.idexp", rExp["idexp"]));

                DataTable tOther = Meta.Conn.SQLRunner(query);
                if (tOther != null) {
                    foreach (DataRow rOther in tOther.Rows) {
                        if (DS.authpaymentexpense.Select(QHC.CmpEq("idexp", rOther["idexp"])).Length > 0) continue;
                        DataRow rAuthExpense = MetaAuthExp.Get_New_Row(Curr, DS.authpaymentexpense);
                        rAuthExpense["idexp"] = rOther["idexp"];
                        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview,null, QHS.CmpEq("idexp", rOther["idexp"]), null, true);
                    }
                }

                tInfo.Clear();
            }
            
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T == null) return;
            if (T.TableName == "registrymainview") {
                if (Meta.DrawStateIsDone) {
                    DS.authpaymentexpense.ExtendedProperties[MetaData.ExtraParams] = (R == null) ? null : R["idreg"];
                }
            }

            if (T.TableName == "authstatus") {
                if (Meta.DrawStateIsDone) {
                    txtNoteStato.Text = (R == null) ? "" : R["explanation"].ToString();
                }
            }

        }

        public void MetaData_AfterActivation() {
            txtEsercMovimento.Text = Meta.GetSys("esercizio").ToString();
        }

        public void MetaData_AfterClear() {
            txtEsercMovimento.Text = Meta.GetSys("esercizio").ToString();
            txtTotale.Text = "";
            txtNoteStato.Text = "";
            lastSentDate = null;
        }

        private void txtInvio_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (DS.authpayment.Rows.Count == 0) return;
            
            object dataObj = HelpForm.GetObjectFromString(typeof(DateTime), txtInvio.Text, "authpayment.sent_date");
            if ((dataObj == null) || (dataObj == DBNull.Value)) return;

            if (lastSentDate.Equals(dataObj)) return;

            DateTime data = (DateTime)dataObj;
            DateTime authdata = data;
            int ggOffSet = 5;
            while(ggOffSet >= 0) {
                authdata = authdata.AddDays(1);

                if ((authdata.DayOfWeek == DayOfWeek.Saturday)
                    || (authdata.DayOfWeek == DayOfWeek.Sunday)) continue;
                ggOffSet--;
            }

            txtAutorizzazione.Text = HelpForm.StringValue(authdata, "authpayment.authorize_date");
            lastSentDate = data;//lastSentDate = authdata;
        }
    }
}
