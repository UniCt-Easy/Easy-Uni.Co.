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
using System.Linq;
using System.Text;
using meta_grantload;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using ep_functions;
using System.Collections;

namespace grantload_default {
    public partial class Frm_grantload_default :Form {
        
        public MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
        private EP_Manager EPM;

        public Frm_grantload_default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();            
            DataAccess.SetTableForReading(DS.assetview_grant,"assetview");
            DataAccess.SetTableForReading(DS.assetview_grantdetail,"assetview");
            DataAccess.SetTableForReading(DS.epacc_grant,"epacc");
            DataAccess.SetTableForReading(DS.epacc_grantdetail,"epacc");

            esercizio = (int) Meta.GetSys("esercizio");
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
            btnGeneraEP, btnVisualizzaEP, labEP, null, "grantload");
            //QH.AppAnd(QH.IsNull("idgrantload"), QH.CmpEq("ygrant", esercizio));
            btnCollega.Tag = "choose.assetgrant.default." +
                    QHS.AppAnd(QHS.CmpEq("ygrant", esercizio), QHS.IsNull("idgrantload"));
            btnCollegaRisconti.Tag = "choose.assetgrantdetail.default." +
                    QHS.AppAnd(QHS.CmpEq("ydetail", esercizio), QHS.IsNull("idgrantload"));
            chkDefinizione.Enabled = true;

        }

        public void MetaData_AfterClear() {
            enableControls(true);
            enableControls(true, true);
            chkDefinizione.Enabled = true;
            VisualizzaTabPageRisconti();
            EPM.mostraEtichette();
        }


        public void MetaData_BeforeFill() {
            DataRow Curr = DS.grantload.Rows[0];
            Meta.CanSave = (esercizio.ToString() == Curr["yload"].ToString());
        }

        public void MetaData_AfterFill() {
            enableControls(false);
            DataRow Curr = DS.grantload.Rows[0];

            enableControls(false, esercizio.ToString() != Curr["yload"].ToString());
         
            VisualizzaTabPageRisconti();
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                if ((DS.assetgrant.Rows.Count > 0) || (DS.assetgrantdetail.Rows.Count > 0))
                    chkDefinizione.Enabled = false;
                else
                    chkDefinizione.Enabled = true;
            }
            EPM.mostraEtichette();

        }


        public void MetaData_BeforePost() {
            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }


        void VisualizzaTabPageRisconti() {
            if (DS.grantload.Rows.Count == 0) {
                AddRemoveTab(tabPageRisconti, true, false);
                AddRemoveTab(tabPageContributi, true, false);
                return;
            }

            if (!chkDefinizione.Checked) // Risconti kind=U
            {
                AddRemoveTab(tabPageContributi, false, false);
                AddRemoveTab(tabPageRisconti, true, false);
            }
            else // Contributi kind=D
            {
                AddRemoveTab(tabPageContributi, true, false);
                AddRemoveTab(tabPageRisconti, false, false);
            }
        }

        void AddTab(TabPage Tab, bool redraw) {
            if (tabDefinizioneScarico.TabPages.Contains(Tab)) return;
            tabDefinizioneScarico.TabPages.Add(Tab);
            if (Meta.IsEmpty) {
                Meta.myHelpForm.ClearControls(Tab.Controls);
            }
            else {
                if (redraw) Meta.myHelpForm.FillControls(Tab.Controls);
            }
        }


        void AddRemoveTab(TabPage Tab, bool Add, bool redraw) {
            if (Add) {
                AddTab(Tab, redraw);
            }
            else {
                if (tabDefinizioneScarico.TabPages.Contains(Tab)) {
                    tabDefinizioneScarico.TabPages.Remove(Tab);
                }
            }
        }


        private void chkTransmissionKind_CheckedChanged(object sender, EventArgs e) {
            VisualizzaTabPageRisconti();
        }
        
      
        
        string CalculateFilterForLinking(bool SQL) {
            
            QueryHelper QH = SQL ? QHS : QHC;
            string MyFilter = QH.AppAnd(QH.IsNull("idgrantload"), QH.CmpEq("ygrant", esercizio));
                            
            return MyFilter;
        }

        
        string CalculateFilterForLinkingRisconti(bool SQL) {
            
            QueryHelper QH = SQL ? QHS : QHC;
            string MyFilter = QH.AppAnd(QH.IsNull("idgrantload"), QH.CmpEq("ydetail", esercizio));
            
            return MyFilter;
        }

        
        private void btnModifica_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = CalculateFilterForLinking(false);
            string MyFilterSQL = CalculateFilterForLinking(true);
            Meta.MultipleLinkUnlinkRows("Composizione Elenco Contributi",
                "Contributi inclusi nell' elenco selezionato",
                "Contributi non inclusi in alcun elenco",
                DS.assetgrant, MyFilter, MyFilterSQL, "single");
            
            Meta.FreshForm();
        }

        
        private void btnModificaRisconti_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);                   
            string MyFilter = CalculateFilterForLinkingRisconti(false);
            string MyFilterSQL = CalculateFilterForLinkingRisconti(true);
            Meta.MultipleLinkUnlinkRows("Composizione Elenco Risconti",
                "Risconti inclusi nell' elenco selezionato",
                "Risconti non inclusi in alcun elenco",
                DS.assetgrantdetail, MyFilter, MyFilterSQL, "detail");
           
            Meta.FreshForm();
        }

     

      


        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            txtAnno.Enabled = abilita;
        }


        private void enableControls(bool abilita, bool esanno) {
            bool readOnly = !abilita;

            if (esanno) {
                btnCollega.Enabled = abilita;
                btnScollega.Enabled = abilita;
                btnModifica.Enabled = abilita;


                btnCollegaRisconti.Enabled = abilita;
                btnModificaVar.Enabled = abilita;
                btnScollegaVar.Enabled = abilita;
            }
        }


        private void chkScarico_CheckedChanged(object sender, EventArgs e) {
            VisualizzaTabPageRisconti();
        }
    }
}
