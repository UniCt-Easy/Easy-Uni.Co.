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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace finyearview_prevision
{
    public partial class Frm_finyearview_prevision : Form{
        MetaData Meta;
        decimal lastPrevPrincCorr = 0;
        decimal lastPrevPrincPrec = 0;
        decimal lastPrevSecCorr = 0;
        decimal lastPrevSecPrec = 0;
        decimal lastResCorr = 0;
        decimal lastResPrec = 0;
        decimal lastPrev2 = 0;
        decimal lastPrev3 = 0;
        decimal lastPrev4 = 0;
        decimal lastPrev5 = 0;

        public Frm_finyearview_prevision(){
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.CacheTable(DS.upb, null, "codeupb", true);

            cambiaEtichetteEsercizi();
            impostaCampiReadonly(false);

        }


       private void impostaCampiReadonly(bool abilita){
           DS.finyearview.Columns["finpart"].ReadOnly = abilita;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName == "upb"){
                if (R != null){
                    DataRow Curr = DS.finyearview.Rows[0];
                    Curr["codeupb"] = R["codeupb"];
                    Curr["upb"] = R["title"];
                    Curr["paridupb"] = R["paridupb"];
                    
                }

            }
        }

        private void cambiaEtichetteEsercizi(){
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            string currstr = esercizioCurr.ToString();
            string precstr = esercizioPrec.ToString();
            lblEsCorrentePrima.Text = currstr;
            lblEsCorrSeconda.Text = currstr;
            lblEsCorrPrincCons.Text = currstr;
            lblEsCorrSecCons.Text = currstr;
            lblRipCorrente.Text = "Presunti del " + currstr;
            lblRipCorrCons.Text = "Presunti del " + currstr;
            lblEsPrecPrima.Text = precstr;
            lblEsPrecSeconda.Text = precstr;
            lblEsPrecPrincCons.Text = precstr;
            lblEsPrecSecCons.Text = precstr;
            lblRipPrecedente.Text = "Presunti del " + precstr;
            lblRipPrecCons.Text = "Presunti del " + precstr;

            lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrev2Cons.Text = esercizioCurr.ToString();
            lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrev3Cons.Text = esercizioCurr.ToString();
            lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrev4Cons.Text = esercizioCurr.ToString();
            lblPrevisione5.Text = (++esercizioCurr).ToString();
            lblPrev5Cons.Text = esercizioCurr.ToString();
        }

        public void MetaData_AfterActivation(){
            gestisciGruppoPrevisioneSecondaria();
            riempiVarDiConfronto();
            calcolaConsolidato();
 
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataTable tConfig = DataAccess.RUN_SELECT(Meta.Conn, "config", null, null, filteresercizio, null, null, true);
            if (tConfig != null){
                if (tConfig.Rows.Count != 0){
                    DataRow rConfig = tConfig.Rows[0];

                    //Imposta groupbox previsioni competenza 
                    string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
                    if (nomeprevsecondaria != null)
                        grpPrevSec.Text = nomeprevsecondaria;
                    gboxPrimaPrevisione.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);

                    ImpostaLabelRipartizione(rConfig);
                }
            }
        }

        private object isNull(object a, object b){
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void calcolaConsolidato(){
            DataRow Curr = DS.finyearview.Rows[0];
            object idBilancio = Curr["idfin"];
            int esercizio = (int)Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            string filter = QHS.AppAnd(QHS.CmpEq("idfin", idBilancio), filterEsercizio);
            DataTable Tfinyearview = DataAccess.RUN_SELECT(Meta.Conn, "finyearview", "*", "codeupb", filter, null, null, true);

            decimal previsioneCorr = 0;
            decimal previsioneSecCorr = 0;
            decimal previsionePrec = 0;
            decimal previsioneSecPrec = 0;
            decimal residuiCorr = 0;
            decimal residuiPrec = 0;
            decimal previsioneAnno2 = 0;
            decimal previsioneAnno3 = 0;
            decimal previsioneAnno4 = 0;
            decimal previsioneAnno5 = 0;
          
            string filtro = QHS.AppOr(QHS.CmpEq("idupb", Curr["idupb"]), "(paridupb LIKE '" + Curr["idupb"] + "%')");
            foreach (DataRow rFinYear in Tfinyearview.Select(filtro))
            {
                previsioneCorr += (decimal)isNull(rFinYear["prevision"], 0m);
                previsioneSecCorr += (decimal)isNull(rFinYear["secondaryprev"], 0m);
                previsionePrec += (decimal)isNull(rFinYear["previousprevision"], 0m);
                previsioneSecPrec += (decimal)isNull(rFinYear["previoussecondaryprev"], 0m);
                residuiCorr += (decimal)isNull(rFinYear["currentarrears"], 0m);
                residuiPrec += (decimal)isNull(rFinYear["previousarrears"], 0m);
                previsioneAnno2 += (decimal)isNull(rFinYear["prevision2"], 0m);
                previsioneAnno3 += (decimal)isNull(rFinYear["prevision3"], 0m);
                previsioneAnno4 += (decimal)isNull(rFinYear["prevision4"], 0m);
                previsioneAnno5 += (decimal)isNull(rFinYear["prevision5"], 0m);
            }
            txtPrevisionePrincipaleCorrConsolidato.Text = previsioneCorr.ToString("c");
            txtPrevisioneSecondariaCorrConsolidato.Text = previsioneSecCorr.ToString("c");
            txtPrevisionePrincipalePrecConsolidato.Text = previsionePrec.ToString("c");
            txtPrevisioneSecondariaPrecConsolidato.Text = previsioneSecPrec.ToString("c");
            txtResiduiCorrConsolidato.Text = residuiCorr.ToString("c");
            txtResiduiPrecConsolidato.Text = residuiPrec.ToString("c");
            txtPrevisione2Consolidato.Text = previsioneAnno2.ToString("c");
            txtPrevisione3Consolidato.Text = previsioneAnno3.ToString("c");
            txtPrevisione4Consolidato.Text = previsioneAnno4.ToString("c");
            txtPrevisione5Consolidato.Text = previsioneAnno5.ToString("c");
        }

        private void gestisciGruppoPrevisioneSecondaria(){
            int finkind = CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind"));

            if (finkind == 3){
                grpPrevSec.Visible = true;
                grpPrevSecCons.Visible = true;
                return;
            }
        }

        private void ImpostaLabelRipartizione(DataRow R){
            string RipGroupBox = R["boxpartitiontitle"].ToString();
            string RipCorrente = R["currpartitiontitle"].ToString();
            string RipPrecedente = R["prevpartitiontitle"].ToString();
            if (RipGroupBox != "") gboxRipartizione.Text = RipGroupBox;
            if (RipCorrente != "") lblRipCorrente.Text = RipCorrente;
            if (RipPrecedente != "") lblRipPrecedente.Text = RipPrecedente;
        }

        private void riempiVarDiConfronto(){
            //DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            //if (Curr == null) return;
            DataRow Curr = DS.finyearview.Rows[0];
            azzeraVarDiConfronto();
            lastPrevPrincCorr = (decimal)isNull(Curr["prevision"], 0m);
            lastPrevPrincPrec = (decimal)isNull(Curr["previousprevision"], 0m);
            lastPrevSecCorr = (decimal)isNull(Curr["secondaryprev"], 0m);
            lastPrevSecPrec = (decimal)isNull(Curr["previoussecondaryprev"], 0m);
            lastResCorr = (decimal)isNull(Curr["currentarrears"], 0m);
            lastResPrec = (decimal)isNull(Curr["previousarrears"], 0m);
            lastPrev2 = (decimal)isNull(Curr["prevision2"], 0m);
            lastPrev3 = (decimal)isNull(Curr["prevision3"], 0m);
            lastPrev4 = (decimal)isNull(Curr["prevision4"], 0m);
            lastPrev5 = (decimal)isNull(Curr["prevision5"], 0m);
        }

        private void azzeraVarDiConfronto(){
            lastPrevPrincCorr = 0;
            lastPrevPrincPrec = 0;
            lastPrevSecCorr = 0;
            lastPrevSecPrec = 0;
            lastResCorr = 0;
            lastResPrec = 0;
            lastPrev2 = 0;
            lastPrev3 = 0;
            lastPrev4 = 0;
            lastPrev5 = 0;
        }
    }
}