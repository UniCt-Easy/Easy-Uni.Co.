
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
using funzioni_configurazione;

namespace upbaccountview_default {
    public partial class Frm_upbaccountview_default : Form {
        private MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_upbaccountview_default() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterusable = QHS.CmpEq("flagusable", "S");
            GetData.SetStaticFilter(DS.account,filtereserc);
            GetData.SetStaticFilter(DS.upbaccountview, QHS.AppAnd(filtereserc,filterusable));
            cambiaEtichetteEsercizi();
            Meta.SearchEnabled = false;
        }

        private void cambiaEtichetteEsercizi() {
        int esercizioCurr = (int)Meta.GetSys("esercizio");

            lblPrevCorr1.Text += esercizioCurr.ToString();
            lblPreimpegni1.Text += esercizioCurr.ToString();
            lblImpegni1.Text += esercizioCurr.ToString();
            lblPreAccertamenti1.Text += esercizioCurr.ToString();
            lblAccertamenti1.Text += esercizioCurr.ToString();

            lblPrevCorr2.Text += (++esercizioCurr).ToString();
            lblPreimpegni2.Text += (esercizioCurr).ToString();
            lblImpegni2.Text += (esercizioCurr).ToString();
            lblPreAccertamenti2.Text += esercizioCurr.ToString();
            lblAccertamenti2.Text += esercizioCurr.ToString();

            lblPrevCorr3.Text += (++esercizioCurr).ToString();
            lblPreimpegni3.Text += (esercizioCurr).ToString();
            lblImpegni3.Text += (esercizioCurr).ToString();
            lblPreAccertamenti3.Text += esercizioCurr.ToString();
            lblAccertamenti3.Text += esercizioCurr.ToString();

            lblPrevCorr4.Text += (++esercizioCurr).ToString();
            lblPreimpegni4.Text += (esercizioCurr).ToString();
            lblImpegni4.Text += (esercizioCurr).ToString();
            lblPreAccertamenti4.Text += esercizioCurr.ToString();
            lblAccertamenti4.Text += esercizioCurr.ToString();

            lblPrevCorr5.Text += (++esercizioCurr).ToString();
            lblPreimpegni5.Text += (esercizioCurr).ToString();
            lblImpegni5.Text += (esercizioCurr).ToString();
            lblPreAccertamenti5.Text += esercizioCurr.ToString();
            lblAccertamenti5.Text += esercizioCurr.ToString();

        }

        public void MetaData_AfterClear() {
            DisabilitaCampi(false);

        }

        public void MetaData_AfterFill() {
            DisabilitaCampi(true);
            btnCalcolaTotali.Enabled = true;
        }

        private void DisabilitaCampi(bool disable) {
            txtimpegni1.ReadOnly = disable;
            txtpreimpegni1.ReadOnly = disable;
            txtimpegni2.ReadOnly = disable;
            txtpreimpegni2.ReadOnly = disable;
            txtimpegni3.ReadOnly = disable;
            txtpreimpegni3.ReadOnly = disable;
            txtimpegni4.ReadOnly = disable;
            txtpreimpegni4.ReadOnly = disable;
            txtimpegni5.ReadOnly = disable;
            txtpreimpegni5.ReadOnly = disable;

            txtAccertamenti1.ReadOnly = disable;
            txtpreAccertamenti1.ReadOnly = disable;
            txtAccertamenti2.ReadOnly = disable;
            txtpreAccertamenti2.ReadOnly = disable;
            txtAccertamenti3.ReadOnly = disable;
            txtpreAccertamenti3.ReadOnly = disable;
            txtAccertamenti4.ReadOnly = disable;
            txtpreAccertamenti4.ReadOnly = disable;
            txtAccertamenti5.ReadOnly = disable;
            txtpreAccertamenti5.ReadOnly = disable;

            txtprevisione.ReadOnly = disable;
            txtprevisione2.ReadOnly = disable;
            txtprevisione3.ReadOnly = disable;
            txtprevisione4.ReadOnly = disable;
            txtprevisione5.ReadOnly = disable;


            txtepavere.ReadOnly = disable;
            txtepdare.ReadOnly = disable;
            txtCIG.ReadOnly = disable;
            txtCUP.ReadOnly = disable;

            cmbEPUPBKind.Enabled = !disable;

            //gboxConto.Enabled = !disable;
            txtCodiceConto.ReadOnly = disable;
            btnAccount.Enabled = !disable;
            //gboxUPB.Enabled = !disable;
            txtUPB.ReadOnly = disable;
            btnUPBCode.Enabled = !disable;
            gboxResponsabile.Enabled = !disable;
            grpAttivita.Enabled = !disable;
            grpProfitLoss .Enabled = !disable;
            grpboxUtilizzoConto.Enabled = !disable;
            grpFunzione.Enabled = !disable;
            chkCdOrdine.Enabled = !disable;
            chkCompetency.Enabled = !disable;
            chkBoxEnableBudget.Enabled = !disable;
        }
        bool valoricalcolati = false;
        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            if (txtCodiceConto.Text == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario indicare il Conto");
                return;
            }
            if (txtUPB.Text == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario indicare l'U.P.B.");
                return;
            }
            valoricalcolati = true;
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = QHC.AppAnd(QHC.CmpEq("codeacc", txtCodiceConto.Text.ToString()), QHC.CmpEq("codeupb", txtUPB.Text.ToString()), filtereserc);
            Meta.DoMainCommand("choose.upbaccountview.default." + filter);
            Meta.DoMainCommand("maindosearch");
        }

        private void btnRicerca_Click(object sender, EventArgs e) {
                Meta.DoMainCommand("mainsetsearch");
          
        }

        private void Frm_upbaccountview_default_Load(object sender, EventArgs e) {

        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }
    }
}

