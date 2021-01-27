
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace finyearview_previsionupb
{
    public partial class Frm_finyearview_previsionupb : Form
    {
        MetaData Meta;
        

        public Frm_finyearview_previsionupb()
        {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.upb, null, "codeupb", true);

            cambiaEtichetteEsercizi();
            impostaCampiReadonly(false);

        }
        public void MetaData_AfterFill() {
            if (Meta.InsertMode) {
                if (MetaDataDetail.TabPages.Contains(tabConsolidato))
                    MetaDataDetail.TabPages.Remove(tabConsolidato);
            }

        }

        private void impostaCampiReadonly(bool abilita)
        {
            DS.finyearview.Columns["finpart"].ReadOnly = abilita;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (T.TableName == "upb")
            {
                if (R != null)
                {
                    DataRow Curr = DS.finyearview.Rows[0];
                    Curr["codeupb"] = R["codeupb"];
                    Curr["upb"] = R["title"];
                    Curr["paridupb"] = R["paridupb"];

                }

            }
        }

        private void cambiaEtichetteEsercizi()
        {
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

        public void MetaData_AfterActivation()
        {
            gestisciGruppoPrevisioneSecondaria();
            calcolaConsolidato();

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataTable tConfig = DataAccess.RUN_SELECT(Meta.Conn, "config", null, null, filteresercizio, null, null, true);
            if (tConfig != null)
            {
                if (tConfig.Rows.Count != 0)
                {
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

        private object isNull(object a, object b)
        {
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void calcolaConsolidato()
        {
            DataRow Curr = DS.finyearview.Rows[0];
            object idBilancio = Curr["idfin"];
            string idupb = Curr["idupb"].ToString();

            string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupb), "(paridupb LIKE '" + idupb + "%')"));
            filtro = QHS.AppAnd(filtro, QHS.CmpEq("idfin", idBilancio));
            string expr = "";
            foreach (string field in new string[]{"prevision","secondaryprev","previousprevision","previoussecondaryprev",
                            "currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5"}) {
                if (expr != "") expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable Tfinyearview = Meta.Conn.SQLRunner("SELECT " + expr + " FROM finyearview WHERE " + filtro, false);


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

            foreach (DataRow rFinYear in Tfinyearview.Select())
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

        private void gestisciGruppoPrevisioneSecondaria()
        {
            int finkind = CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind"));

            grpPrevSec.Visible = (finkind == 3);
            grpPrevSecCons.Visible = (finkind == 3);
            
        }

        private void ImpostaLabelRipartizione(DataRow R)
        {
            string RipGroupBox = R["boxpartitiontitle"].ToString();
            string RipCorrente = R["currpartitiontitle"].ToString();
            string RipPrecedente = R["prevpartitiontitle"].ToString();
            if (RipGroupBox != "") gboxRipartizione.Text = RipGroupBox;
            if (RipCorrente != "") lblRipCorrente.Text = RipCorrente;
            if (RipPrecedente != "") lblRipPrecedente.Text = RipPrecedente;
        }

        
    }
}
