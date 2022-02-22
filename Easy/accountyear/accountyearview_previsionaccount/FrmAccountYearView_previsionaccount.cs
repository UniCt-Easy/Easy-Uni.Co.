
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace accountyearview_previsionaccount {
    public partial class FrmAccountYearView_previsionaccount : MetaDataForm {
        public FrmAccountYearView_previsionaccount() {
            InitializeComponent();
        }
        bool inChiusura = false;
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.fin, null,"codefin", true);

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.account, filteresercizio);

            cambiaEtichetteEsercizi();          

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "accountminusable") {
                if (R != null) {
                    DataRow Curr = DS.accountyearview.Rows[0];
                    Curr["codeacc"] = R["codeacc"];
                    Curr["account"] = R["title"];
                    Curr["paridacc"] = R["paridacc"];
                    Curr["nlevel"] = R["nlevel"];

                    string filteraccountlevel = QHS.AppAnd(QHS.CmpEq("ayear", 
                                Meta.Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", R["nlevel"]));
                    object leveldescr = Meta.Conn.DO_READ_VALUE("accountlevel", filteraccountlevel, "description");
                    Curr["leveldescr"] = leveldescr;
                }
            }
        }


        private void cambiaEtichetteEsercizi() {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            grpImporto1.Text = (esercizioCurr).ToString();
            grpImporto2.Text = (++esercizioCurr).ToString();
            grpImporto3.Text = (++esercizioCurr).ToString();
            grpImporto4.Text = (++esercizioCurr).ToString();
            grpImporto5.Text = (++esercizioCurr).ToString();
        }

        private void btnConto_Click(object sender, EventArgs e) {
            string filter = "";
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string filteroperativo = "(idacc in (SELECT idacc from accountminusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
            }
            filter = GetData.MergeFilters(filter, filteroperativo);
            MetaData.DoMainCommand(this, "choose.accountminusable.default." + filter);
        }

        private string lastCodiceConto;
        private void textBox2_Enter(object sender, EventArgs e) {
            lastCodiceConto = txtCodiceConto.Text;
        }
        private void svuotaOggetti() {
            txtDenominazioneConto.Text = "";
        }
        private void txtCodiceConto_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtCodiceConto.Text == "") {
                svuotaOggetti();
                return;
            }
            if (lastCodiceConto == txtCodiceConto.Text) return;

            if (DS.accountyearview.Rows.Count == 0) return;
            Meta.GetFormData(true);

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string Codeacc = txtCodiceConto.Text;
            if (!Codeacc.EndsWith("%")) Codeacc += "%";
            filter = QHC.AppAnd(filter, QHS.Like("codeacc", Codeacc));

            MetaData MetaAccountminusable = MetaData.GetMetaData(this, "accountminusable");
            MetaAccountminusable.FilterLocked = true;
            MetaAccountminusable.DS = DS.Clone();

            DataRow Choosen = MetaAccountminusable.SelectOne("default", filter, "accountminusable", null);
            if (Choosen == null) {
                txtCodiceConto.Focus();
                lastCodiceConto = null;
                return;
            }

            DataRow Curr = DS.accountyearview.Rows[0];
            Curr["idacc"] = Choosen["idacc"];
            Curr["codeacc"] = Choosen["codeacc"];
            Curr["account"] = Choosen["title"];
            Curr["paridacc"] = Choosen["paridacc"];
            Curr["nlevel"] = Choosen["nlevel"];

            string filteraccountlevel = QHS.AppAnd(QHS.CmpEq("ayear",
                        Meta.Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", Choosen["nlevel"]));
            object leveldescr = Meta.Conn.DO_READ_VALUE("accountlevel", filteraccountlevel, "description");
            Curr["leveldescr"] = leveldescr;
            txtCodiceConto.Text = (Choosen != null) ? Choosen["codeacc"].ToString() : "";
            txtDenominazioneConto.Text = (Choosen != null) ? Choosen["title"].ToString() : "";
        }
    }
}
