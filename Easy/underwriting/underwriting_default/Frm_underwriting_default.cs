
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

namespace underwriting_default
{
    public partial class Frm_underwriting_default : MetaDataForm
    {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_underwriting_default(){
            InitializeComponent();
            DataAccess.SetTableForReading(DS.finvardetailcomp,"finvardetailview");
            DataAccess.SetTableForReading(DS.finvardetailcassa,"finvardetailview");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing){
            if (disposing){
                if (components != null){
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void MetaData_AfterClear(){
            PulisceText();
            AbilitaButtons(false);
        }
        private void PulisceText(){
            txtAccertatoAnniPrec.Text = "";
            txtAssegnazioniCreditiAnniPrec.Text = "";
            txtDotInizialeCreditiTeorica.Text = "";
            //txtDotInizialeCreditiPrec.Text = "";
            txtDotCreditiIniziale.Text = "";
            txtAccertamenti.Text = "";
            txtVarCrediti.Text = "";
            txtVarCreditiAnniPrec.Text = "";
            txtAssegnazioniCrediti.Text = "";
            txtAccertamentiNonAttribuiti.Text = "";
            txtImpegni.Text = "";
            txtVarImpegni.Text = "";
            txtImpegnatoPrec.Text = "";
            txtVarImpegniPrec.Text = "";
            txtCreditiNonUtilizzati.Text = "";
            txtCreditiCorrenti.Text = "";
            
            TxtIncassatoAnniPrec.Text = "";
            txtDotInizialeCassa.Text = "";
            txtIncassi.Text = "";
            txtVariazioniIncassi.Text = "";
            txtVarIncassiPrec.Text = "";
            txtAssegnazioniIncassiPrec.Text = "";
            txtAssegnazioniIncassi.Text = "";
            TxtIncassiNonAttribuiti.Text = "";
            TxtPagamenti.Text = "";
            txtPagatoPrec.Text = "";
            txtDotInizialeIncassiTeorica.Text = "";
            //txtDotInizialeIncassiPrec.Text = "";
            txtIncassiNonUtilizzati.Text = "";
            txtIncassiCorrenti.Text = "";

            txtAccertamentiE.Text = "";
            txtImpegniS.Text = "";
            txtIncassiE.Text = "";
            txtPagamentiS.Text = "";

            txtPrevisioneCorrCassaE.Text = "";
            txtPrevisioneCorrCassaS.Text = "";
            txtPrevisioneCorrCompE.Text = "";
            txtPrevisioneCorrCompS.Text = "";
            txtPrevisioneInizialeCassaE.Text = "";
            txtPrevisioneInizialeCassaS.Text = "";
            txtPrevisioneInizialeCompE.Text = "";
            txtPrevisioneInizialeCompS.Text = "";

            txtVarAccertamentiResidui.Text = "";
            txtVarPagamentiPrec.Text = "";
            txtVarPagamenti.Text = "";
        }
        public void MetaData_AfterFill(){
            SubEntity_txtpreveserciziocorr.ReadOnly = false;
            SubEntity_txtprevision2.ReadOnly = false;
            SubEntity_txtprevision3.ReadOnly = false;
            SubEntity_txtprevision4.ReadOnly = false;
            SubEntity_txtprevision5.ReadOnly = false;
            if (Meta.InsertMode){
                AbilitaButtons(false);
            }
            else{
                AbilitaButtons(true);
            }
        }


        private void CalcolaValoriPrevisionePrincipale(){
            //I valori delle var. saranno così calcoli:
            //Previsione iniziale = somma della var.di ripartizione 
            //Previsione corrente = previsione iniziale + var (tutte) 
            string filterInizialeS = "";
            decimal valore;
            string strExpr = "";
            DataRow Curr = DS.underwriting.Rows[0];

            txtAccertamentiE.Text = TotAccertamenti().ToString("C");
            decimal ImpegniS = TotImpegni() + TotVarImpegni();
            txtImpegniS.Text = ImpegniS.ToString("C");

            //PREVISIONE PRINCIPALE

            // Previsione iniziale Spesa (principale)
            filterInizialeS = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("variationkind", "5"));// Var. di Tipo Iniziale
            filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("idfinvarstatus", "5"));
            filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("flagprevision", "S"));// Flagprevision = S
            filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("finpart", "S"));
            filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterInizialeS, strExpr));
            txtPrevisioneInizialeCompS.Text = valore.ToString("C");

            // Previsione corrente Spesa (principale)
            string filterCurrS = "";
            filterCurrS = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("idfinvarstatus", "5"));
            filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("flagprevision", "S"));
            filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("finpart", "S"));
            filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterCurrS, strExpr));
            txtPrevisioneCorrCompS.Text = valore.ToString("C");

            // Previsione iniziale Entrata (principale)
            string filterInizialeE = "";
            filterInizialeE = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("variationkind", "5"));
            filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("idfinvarstatus", "5"));
            filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("flagprevision", "S"));
            filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("finpart", "E"));
            filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterInizialeE, strExpr));
            txtPrevisioneInizialeCompE.Text = valore.ToString("C");

            // Previsione corrente Entrata (principale)
            string filterCurrE = "";
            filterCurrE = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("idfinvarstatus", "5"));
            filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("flagprevision", "S"));
            filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("finpart", "E"));
            filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterCurrE, strExpr));
            txtPrevisioneCorrCompE.Text = valore.ToString("C");
        }

        private void CalcolaValoriPrevisioneSecondaria() {
            //I valori delle var. saranno così calcoli:
            //Previsione iniziale = somma della var.di ripartizione 
            //Previsione corrente = previsione iniziale + var (tutte) 
            string filterInizialeS = "";
            decimal valore;
            string strExpr = "";
            DataRow Curr = DS.underwriting.Rows[0];

            txtIncassiE.Text = TotIncassi().ToString("C");
            decimal PagamentiS = TotPagamenti() + TotVarPagamenti();
            txtPagamentiS.Text = PagamentiS.ToString("C");

            //PREVISIONE SECONDARIA
            string filterCurrS = "";
            string filterInizialeE = "";
            string filterCurrE = "";
            string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
            if (nomeprevsecondaria != null) {
                //PREVISIONE PRINCIPALE

                // Previsione iniziale Spesa (secondaria)
                filterInizialeS = "";
                filterInizialeS = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
                filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("variationkind", "5"));// Var. di Tipo Iniziale
                filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("idfinvarstatus", "5"));
                filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("flagsecondaryprev", "S"));// flagsecondaryprev = S
                filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("finpart", "S"));
                filterInizialeS = QHS.AppAnd(filterInizialeS, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

                strExpr = "SUM(ISNULL(amount,0))";
                valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterInizialeS, strExpr));
                txtPrevisioneInizialeCassaS.Text = valore.ToString("C");

                // Previsione corrente Spesa (secondaria)
                filterCurrS = "";
                filterCurrS = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
                filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("idfinvarstatus", "5"));
                filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("flagsecondaryprev", "S"));
                filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("finpart", "S"));
                filterCurrS = QHS.AppAnd(filterCurrS, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

                strExpr = "SUM(ISNULL(amount,0))";
                valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterCurrS, strExpr));
                txtPrevisioneCorrCassaS.Text = valore.ToString("C");

                // Previsione iniziale Entrata (secondaria)
                filterInizialeE = "";
                filterInizialeE = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
                filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("variationkind", "5"));
                filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("idfinvarstatus", "5"));
                filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("flagsecondaryprev", "S"));
                filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("finpart", "E"));
                filterInizialeE = QHS.AppAnd(filterInizialeE, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

                strExpr = "SUM(ISNULL(amount,0))";
                valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterInizialeE, strExpr));
                txtPrevisioneInizialeCassaE.Text = valore.ToString("C");

                // Previsione corrente Entrata (secondaria)
                filterCurrE = "";
                filterCurrE = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
                filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("idfinvarstatus", "5"));
                filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("flagsecondaryprev", "S"));
                filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("finpart", "E"));
                filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                filterCurrE = QHS.AppAnd(filterCurrE, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

                strExpr = "SUM(ISNULL(amount,0))";
                valore = CK(Conn.DO_READ_VALUE("finvardetailview", filterCurrE, strExpr));
                txtPrevisioneCorrCassaE.Text = valore.ToString("C");
            }
        }



        private decimal TotAccertatoAnniPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLt("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            // quindi sommiamo gli amount degli accertamenti
            string sql = "SELECT SUM(EY.amount) as amount from income E " +
                         "JOIN incomeyear EY on EY.idinc=E.idinc and EY.ayear=E.ymov" +
                         " WHERE " + Filter;

            // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);


            // Aggiungiamo le var. dei suddetti pagamenti.
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLt("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLt("EV.yvar", Meta.GetSys("esercizio")));


            sql = "SELECT SUM(EV.amount) as amount from income E " +
                        "JOIN incomevar EV on EV.idinc=E.idinc " +
                        " WHERE " + Filter;

            valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        private string FilterPiccoleSpeseImp(DataRow Curr) {
            string Filter = "";
            Filter = QHS.CmpEq("yoperation", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("yrestore"), QHS.CmpGt("adaterestore", Meta.GetSys("datacontabile")))));
            Filter = QHS.AppAnd(Filter, QHS.IsNull("idexp"));
            return Filter;
        }
        private decimal TotPiccolespeseImp(){
            // Vanno considerate le p.spese non reintegrate e NON associate ad un impegno
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];

            string Filter = FilterPiccoleSpeseImp(Curr);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("pettycashopunderwritingview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Conn.DO_READ_VALUE("pettycashopunderwritingview", Filter, strExpr));

            return valore;
           }

        private string FilterPiccoleSpesePag(DataRow Curr) {
            string Filter = "";
            Filter = QHS.CmpEq("yoperation", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("yrestore"), QHS.CmpGt("adaterestore", Meta.GetSys("datacontabile")))));
            return Filter;
        }
        private decimal TotPiccolespesePag(){
            // Vanno considerate le p.spese non reintegrate, senza considerare l'associazione ad un impegno
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];

            string Filter = FilterPiccoleSpesePag(Curr);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("pettycashopunderwritingview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Conn.DO_READ_VALUE("pettycashopunderwritingview", Filter, strExpr));
            return valore;
        }

        private decimal TotIncassatoAnniPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLt("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            string sql = "SELECT SUM(ET.curramount) as amount from income E " +
                         "JOIN incomeyear EY on EY.idinc=E.idinc and EY.ayear=E.ymov " +
                         "JOIN incometotal ET on ET.idinc=E.idinc and ET.ayear=EY.ayear" +
                         " WHERE " + Filter;

            // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        private decimal TotDotInizialeCreditiPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            
            Filter = QHS.CmpLe("yvar", esercizioPrec);
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }

        private decimal TotDotCreditiIniziale(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            Filter = QHS.CmpEq("yvar", esercizioCurr);
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }

        private decimal TotDotInizialeCassa(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }

        private decimal TotDotInizialeIncassiPrec(){
            decimal valore;
            string Filter = "";
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpLe("yvar", esercizioPrec);
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;

        }

        private decimal TotDotInizialeCreditiTeorica(){
            decimal valore;
            valore = TotAssegnazioniCreditiAnniPrec() + TotVarCreditiAnniPrec() - TotImpegnatoPrec()-TotVarImpegniPrec();
            return valore;
        }
        private decimal TotDorInizialeIncassiTeorica(){
            decimal valore;
            valore = TotAssegnazioniIncassiPrec() + TotVarIncassiPrec() - TotPagatoPrec();
            return valore;

        }

        private decimal TotAccertamenti() {
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            
            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            string sql = "SELECT SUM(EY.amount) as amount from income E " +
                         "JOIN incomeyear EY on EY.idinc=E.idinc and EY.ayear=E.ymov" +
                         " WHERE " + Filter;

            // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);


            // Aggiungiamo le var. dei suddetti pagamenti.
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));


            sql = "SELECT SUM(EV.amount) as amount from income E " +
                        "JOIN incomevar EV on EV.idinc=E.idinc " +
                        " WHERE " + Filter;

            valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;

        }


        private decimal TotVarAccertamentiResidui(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];

            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLt("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));


            string sql = "SELECT SUM(EV.amount) as amount from income E " +
                        "JOIN incomevar EV on EV.idinc=E.idinc " +
                        " WHERE " + Filter;

            valore =  CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        private decimal TotIncassi(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));


            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            string sql = "SELECT SUM(EY.amount) as amount from income E " +
                         "JOIN incomeyear EY on EY.idinc=E.idinc and EY.ayear=E.ymov" +
                         " WHERE " + Filter;

            // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);


            // Aggiungiamo le var. dei suddetti pagamenti.
            Filter = QHS.CmpEq("E.nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));


            sql = "SELECT SUM(EV.amount) as amount from income E " +
                        "JOIN incomevar EV on EV.idinc=E.idinc " +
                        " WHERE " + Filter;

            valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;

        }

        private decimal TotVarCrediti(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            // Prendiamo quelle normali  [1] e gli storni [4], perchè quelle di ripartizione e assestamento le abbiamo conteggiate nella dotazione iniziale
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }

        private decimal TotVarCreditiAnniPrec()
        {
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            Filter = QHS.CmpLe("yvar", esercizioPrec);
            // Prendiamo quelle normali  [1] e gli storni [4], perchè quelle di ripartizione e assestamento le abbiamo conteggiate nella dotazione iniziale
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;

        }

        private decimal TotVariazioniIncassi(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("variationkind", "4"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }

        private decimal TotVarIncassiPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;

            Filter = QHS.CmpLe("yvar", esercizioPrec);
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("variationkind", "4"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            string strExpr = "SUM(ISNULL(amount,0))";
            valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }


        private decimal TotAssegnazioniCrediti(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("P.ycreditpart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("P.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            string sql = "SELECT SUM(P.amount) as amount from income E " +
                           "JOIN creditpart P on E.idinc= P.idinc " +
                           "WHERE " + Filter;

            //Devo prendere le assegnazioni crediti degli accertamenti associati al finanziameto corrente.
            valore =  CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal TotAssegnazioniCreditiAnniPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpLt("P.ycreditpart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("P.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            string sql = "SELECT SUM(P.amount) as amount from income E " +
                           "JOIN creditpart P on E.idinc= P.idinc " +
                           "WHERE " + Filter;

            //Devo prendere le assegnazioni crediti degli accertamenti associati al finanziameto corrente.
            valore =  CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;

        }

        private decimal TotAssegnazioniIncassiPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpLt("P.yproceedspart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("P.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            string sql = "SELECT SUM(P.amount) as amount from income E " +
                           "JOIN proceedspart P on E.idinc= P.idinc " +
                           "WHERE " + Filter;

            //Devo prendere le assegnazioni crediti degli accertamenti associati al finanziameto corrente.
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal TotAssegnazioniIncassi(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];
            Filter = QHS.CmpEq("P.yproceedspart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("P.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.idunderwriting", Curr["idunderwriting"]));


            string sql = "SELECT SUM(P.amount) as amount from income E " +
                           "JOIN proceedspart P on E.idinc= P.idinc " +
                           "WHERE " + Filter;

            //Devo prendere le assegnazioni crediti degli accertamenti associati al finanziameto corrente.
            valore =  CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;

        }

        private decimal TotAccertamentiNonAttribuiti(){
            decimal valore;
            valore = TotAccertamenti() - TotAssegnazioniCrediti();
            return valore;
           }

        private decimal TotIncassiNonAttribuiti(){
            // incassi - Ass. incassi
            decimal valore;
            valore = TotIncassi() - TotAssegnazioniIncassi();
            return valore;
        }

        private decimal TotImpegni(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];

            Filter = QHS.CmpEq("E.ymov", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("U.idunderwriting", Curr["idunderwriting"]));

            string sql = "select sum(U.amount) as amount from underwritingappropriation U " +
                        " join  expense E on U.idexp=E.idexp " +
                        " WHERE " + Filter;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);


            // Aggiungiamo le var. relative ai finanziamenti=> E' stato aggiunto un button solo per le var
            //string FilterVar = QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile"));
            //FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            //FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            //FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("appropriationphase")));

            // sql = "select sum(EV.amount) as amount from expensevar EV " +
            //" join  expense E on EV.idexp=E.idexp " +
            //" WHERE " + FilterVar;


            //valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal TotVarImpegni() {
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];
           
            string FilterVar = QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("appropriationphase")));

            string sql = "select sum(EV.amount) as amount from expensevar EV " +
           " join  expense E on EV.idexp=E.idexp " +
           " WHERE " + FilterVar;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        private decimal TotImpegnatoPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];

            Filter = QHS.CmpLt("E.ymov", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("U.idunderwriting", Curr["idunderwriting"]));

            string sql = "select sum(U.amount) as amount from underwritingappropriation U " +
                        " join  expense E on U.idexp=E.idexp " +
                        " WHERE " + Filter;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);


            // Aggiungiamo le var. relative ai finanziamenti=E' stato creato un button per le var
            //string FilterVar = QHS.CmpLt("EV.yvar", Meta.GetSys("esercizio"));
            //FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            //FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("appropriationphase")));

            // sql = "select sum(EV.amount) as amount from expensevar EV " +
            //" join  expense E on EV.idexp=E.idexp " +
            //" WHERE " + FilterVar;

            //valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;        
       }
        private decimal TotVarImpegniPrec() {
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];

            string FilterVar = QHS.CmpLt("EV.yvar", Meta.GetSys("esercizio"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("appropriationphase")));

            string sql = "select sum(EV.amount) as amount from expensevar EV " +
                    " join  expense E on EV.idexp=E.idexp " +
                    " WHERE " + FilterVar;
            
            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;

        }

        private decimal TotPagamenti(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];

            Filter = QHS.CmpEq("E.ymov", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("U.idunderwriting", Curr["idunderwriting"]));

            string sql = "select sum(U.amount) as amount from underwritingpayment U " +
                        " join  expense E on U.idexp=E.idexp " +
                        " WHERE " + Filter;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            // Aggiungiamo le var. relative ai finanziamenti
            string FilterVar = QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("maxexpensephase")));

            sql = "select sum(EV.amount) as amount from expensevar EV " +
            " join  expense E on EV.idexp=E.idexp " +
            " WHERE " + FilterVar;


            valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;

        }

        private decimal TotVarPagamenti() {
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];

            string FilterVar = QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("maxexpensephase")));

            string  sql = "select sum(EV.amount) as amount from expensevar EV " +
            " join  expense E on EV.idexp=E.idexp " +
            " WHERE " + FilterVar;


            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;

        }
        private decimal TotPagatoPrec(){
            decimal valore;
            string Filter = "";
            DataRow Curr = DS.underwriting.Rows[0];

            Filter = QHS.CmpLt("E.ymov", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("U.idunderwriting", Curr["idunderwriting"]));

            string sql = "select sum(U.amount) as amount from underwritingpayment U " +
                        " join  expense E on U.idexp=E.idexp " +
                        " WHERE " + Filter;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            // Aggiungiamo le var. relative ai finanziamenti
            string FilterVar = QHS.CmpLt("EV.yvar", Meta.GetSys("esercizio"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("maxexpensephase")));

             sql = "select sum(EV.amount) as amount from expensevar EV " +
            " join  expense E on EV.idexp=E.idexp " +
            " WHERE " + FilterVar;


            valore = valore + CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal TotVarPagatoPrec() {
            decimal valore;
            DataRow Curr = DS.underwriting.Rows[0];

            string FilterVar = QHS.CmpLt("EV.yvar", Meta.GetSys("esercizio"));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("EV.idunderwriting", Curr["idunderwriting"]));
            FilterVar = QHS.AppAnd(FilterVar, QHS.CmpEq("E.nphase", Meta.GetSys("maxexpensephase")));

            string  sql = "select sum(EV.amount) as amount from expensevar EV " +
            " join  expense E on EV.idexp=E.idexp " +
            " WHERE " + FilterVar;

            valore = CK(Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }
        private decimal IncassiNonUtilizzati(){
            //Sono gli incassi non utilizzati in pagamenti: Assegnazione incassi - Pagamenti
            decimal valore;
//            valore = TotAssegnazioniIncassi() - TotPagamenti();
            valore = TotIncassiCorrenti() - TotPagamenti() - TotVarPagamenti()- TotPiccolespesePag();
            return valore;
        }
        
        private decimal TotCreditiNonUtilizzati(){
            // Sono i crediti non impegnati: Assegnazioni crediti -Impegni
            decimal valore;
            //valore = TotAssegnazioniCrediti() - TotImpegni();
            valore = TotCreditiCorrenti() - TotImpegni() - TotVarImpegni() - TotPiccolespeseImp();
            return valore;
        }


        private decimal TotCreditiCorrenti(){
            decimal valore;
            valore = TotDotCreditiIniziale() + TotVarCrediti() + TotAssegnazioniCrediti();
            return valore;
        }
        private decimal TotIncassiCorrenti(){
            decimal valore;
            valore = TotDotInizialeCassa() + TotVariazioniIncassi() + TotAssegnazioniIncassi();
            return valore;
        }

        private Decimal CK(Object O) {
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }


        private void AbilitaButtons(bool abilita){
            btnAccertamenti.Enabled = abilita;
            btnAccertatoAnniPrec.Enabled = abilita;
            btnAssegnazioniCreditianniprec.Enabled = abilita;
            btnAssegnazioniCrediti.Enabled = abilita;
            btnVarCreditiAnniPrec.Enabled = abilita;
            btnVarCrediti.Enabled = abilita;
            btnImpegni.Enabled = abilita;
            btnImpegnatoPrec.Enabled = abilita;
            btnDotCreditiIniziale.Enabled = abilita;
            btnIncassi.Enabled = abilita;
            btnIncassatoAnniPrec.Enabled = abilita;
            btnAssegnazioniIncassi.Enabled = abilita;
            btnDotazioneInizialeCassa.Enabled = abilita;
            btnVariazioniIncassi.Enabled = abilita;
            btnPagamenti.Enabled = abilita;
            btnPagatoPrec.Enabled = abilita;
            btnAssegnazioniIncassiPrec.Enabled = abilita;
            btnVarIncassiPrec.Enabled = abilita;
            btnDotazioneInizialeCassa.Enabled = abilita;
            btnVarAccertamentiResidui.Enabled = abilita;
            btnVarImpegni.Enabled = abilita;
            btnVarPagamenti.Enabled = abilita;
            btnVarPagamentiPrec.Enabled = abilita;
            btnVarImpegniPrec.Enabled = abilita;
            btnPiccolespeseImp.Enabled = abilita;
            BtnPiccolespesePag.Enabled = abilita;
            btnCalcolaTotaliCrediti.Enabled = abilita;
            btnCalcolaTotaliIncassi.Enabled = abilita;
            btnPrevSecondaria.Enabled = abilita;
            btnPrevPrincipale.Enabled = abilita;
        }
        private void SetTextReadOnly(){
            txtAccertatoAnniPrec.ReadOnly = true;
            txtAssegnazioniCreditiAnniPrec.ReadOnly = true;
            txtDotInizialeCreditiTeorica.ReadOnly = true;
            txtDotCreditiIniziale.ReadOnly = true;
            txtAccertamenti.ReadOnly = true;
            txtVarCrediti.ReadOnly = true;
            txtVarCreditiAnniPrec.ReadOnly = true;
            txtAssegnazioniCrediti.ReadOnly = true;
            txtAccertamentiNonAttribuiti.ReadOnly = true;
            txtImpegni.ReadOnly = true;
            txtVarImpegni.ReadOnly = true;
            txtImpegnatoPrec.ReadOnly = true;
            txtVarImpegniPrec.ReadOnly = true;
            txtCreditiNonUtilizzati.ReadOnly = true;
            txtCreditiCorrenti.ReadOnly = true;

            TxtIncassatoAnniPrec.ReadOnly = true;
            txtDotInizialeCassa.ReadOnly = true;
            txtIncassi.ReadOnly = true;
            txtVariazioniIncassi.ReadOnly = true;
            txtVarIncassiPrec.ReadOnly = true;
            txtAssegnazioniIncassiPrec.ReadOnly = true;
            txtAssegnazioniIncassi.ReadOnly = true;
            TxtIncassiNonAttribuiti.ReadOnly = true;
            TxtPagamenti.ReadOnly = true;
            txtPagatoPrec.ReadOnly = true;
            txtDotInizialeIncassiTeorica.ReadOnly = true;
            txtIncassiNonUtilizzati.ReadOnly = true;
            txtIncassiCorrenti.ReadOnly = true;

            txtAccertamentiE.ReadOnly = true;
            txtImpegniS.ReadOnly = true;
            txtIncassiE.ReadOnly = true;
            txtPagamentiS.ReadOnly = true;

            txtPrevisioneCorrCassaE.ReadOnly = true;
            txtPrevisioneCorrCassaS.ReadOnly = true;
            txtPrevisioneCorrCompE.ReadOnly = true;
            txtPrevisioneCorrCompS.ReadOnly = true;
            txtPrevisioneInizialeCassaE.ReadOnly = true;
            txtPrevisioneInizialeCassaS.ReadOnly = true;
            txtPrevisioneInizialeCompE.ReadOnly = true;
            txtPrevisioneInizialeCompS.ReadOnly = true;

            txtVarAccertamentiResidui.ReadOnly = true;
            txtPiccolespeseImp.ReadOnly = true;
            txtPiccolespesePag.ReadOnly = true;
            txtVarPagamentiPrec.ReadOnly = true;
            txtVarPagamenti.ReadOnly = true;
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

           
            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)){
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this,1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value)
                {
                    MetaDataDetail.TabPages.Remove(tabAttributi);
                }
            }

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.underwritingyear, filteresercizio);
            string filterComp = QHS.AppAnd(QHS.CmpEq("yvar", Meta.GetSys("esercizio")), QHS.CmpEq("flagprevision", "S"));
            GetData.SetStaticFilter(DS.finvardetailcomp, filterComp);
            string filterCassa = QHS.AppAnd(QHS.CmpEq("yvar", Meta.GetSys("esercizio")), QHS.CmpEq("flagsecondaryprev", "S"));
            GetData.SetStaticFilter(DS.finvardetailcassa, filterCassa);
            cambiaEtichetteEsercizi();

            AbilitaButtons(false);
            SetTextReadOnly();
        }


        public void MetaData_AfterActivation(){
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
            if (nomeprevsecondaria == null){
                MetaDataDetail.TabPages.Remove(tabPrevSecondaria);
            }
            else{
                tabPrevSecondaria.Text=CfgFn.NomePrevisioneSecondaria(Meta.Conn);
            }

            TabPrevPrincipale.Text= CfgFn.NomePrevisionePrincipale(Meta.Conn);

            string flagcredit = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizioCurr), "flagcredit").ToString();
            if (flagcredit == "N"){
                MetaDataDetail.TabPages.Remove(tabCrediti);
            }

            string flagproceeds = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizioCurr), "flagproceeds").ToString();
            if (flagproceeds == "N"){
                MetaDataDetail.TabPages.Remove(tabIncassi);
            }


        }

        public void MetaData_BeforeFill(){
            CreateFinLastRow();
        }

        public void CreateFinLastRow(){
            if (Meta.IsEmpty) return;
            DataRow drUnderwriting = HelpForm.GetLastSelected(DS.underwriting);
            if (DS.Tables["underwritingyear"].Rows.Count == 0){
                MetaData metaUnderwritingyear = MetaData.GetMetaData(this, "underwritingyear");
                metaUnderwritingyear.SetDefaults(DS.underwritingyear);
                DataRow DR = metaUnderwritingyear.Get_New_Row(drUnderwriting, DS.underwritingyear);
            }
        }

       

        private void cambiaEtichetteEsercizi(){
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            lblEsCorrentePrima.Text = esercizioCurr.ToString();

            lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrevisione5.Text = (++esercizioCurr).ToString();
        }

        private void btnAccertatoAnniPrec_Click(object sender, EventArgs e){
            string MyFilter;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("incomefinphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLt("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            MetaData MAccertamenti = MetaData.GetMetaData(this, "incomeview");
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("default", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
           }
       }
        private void SelezionaMovimento(DataRow MyDR, string entrata_spesa){

            if (entrata_spesa == "E"){
                MetaData newEntrata = Meta.Dispatcher.Get("income");
                newEntrata.Edit(this.ParentForm, "default", false);
                DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
                    QHS.CmpEq("idinc", MyDR["idinc"]), "income", null);
                if (R2 != null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
            }
            if (entrata_spesa == "S"){
                MetaData newSpesa = Meta.Dispatcher.Get("expense");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idexp", MyDR["idexp"]), "expense", null);
                if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
            if (entrata_spesa == "VS") {
                MetaData newSpesa = Meta.Dispatcher.Get("expensevar");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                     QHS.AppAnd(QHS.CmpEq("idunderwriting", MyDR["idunderwriting"]), QHS.CmpEq("idexp", MyDR["idexp"])), "expense", null);
                if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
            if (entrata_spesa == "UA") {
                MetaData newUA = Meta.Dispatcher.Get("underwritingappropriation");
                newUA.Edit(this.ParentForm, "default", false);
                DataRow R2 = newUA.SelectOne(newUA.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idunderwriting", MyDR["idunderwriting"]), QHS.CmpEq("idexp", MyDR["idexp"])), "underwritingappropriation", null);
                if (R2 != null) newUA.SelectRow(R2, newUA.DefaultListType);
            }
            if (entrata_spesa == "UP") {
                MetaData newUA = Meta.Dispatcher.Get("underwritingpayment");
                newUA.Edit(this.ParentForm, "default", false);
                DataRow R2 = newUA.SelectOne(newUA.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idunderwriting", MyDR["idunderwriting"]), QHS.CmpEq("idexp", MyDR["idexp"])), "underwritingpayment", null);
                if (R2 != null) newUA.SelectRow(R2, newUA.DefaultListType);
            }

        }

        //private string ScegliVista(string nomeVista){
        //    int esercizioCurr = (int)Meta.GetSys("esercizio");

        //    string flagvaliditadoc = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizioCurr), "cashvaliditykind").ToString();
        //        switch (flagvaliditadoc){
        //            case "1":
        //                nomeVista += "emitted";
        //                break;
        //            case "2":
        //                nomeVista += "printed";
        //                break;
        //            case "3":
        //                nomeVista += "communicated";
        //                break;
        //            case "4":
        //                nomeVista += "performed";
        //                break;
        //        }

        //    return nomeVista;
        //}

        private void btnIncassatoAnniPrec_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
           
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLt("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            MetaData MIncassi = MetaData.GetMetaData(this, "incomeview");
            MIncassi.FilterLocked = true;
            MIncassi.DS = DS;
            DataRow MyDR = MIncassi.SelectOne("default", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
            }
       }

        private void btnAccertamenti_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("incomefinphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "incomeview";

            MetaData MAccertamenti = MetaData.GetMetaData(this, VistaScelta);
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("default", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
            }
        }

        private void btnImpegni_Click(object sender, EventArgs e){
            // Impegni suddivisi per progetto/voce in uscita  (da underwritingexpense sugli impegni) 
            // In spesa ci possono essere più finanziamenti collegati allo stesso movimento.
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;

            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("ymov", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "underwritingappropriation";

            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "UA");
            }

        }

        private void btnDotInizialeCrediti_Click(object sender, EventArgs e){
            //Sono tutte le var di tipo Ripartizione[kind = 2] e assestamento [kind=3] associate al finanziamento corrente

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLe("yvar", esercizioPrec);
            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagcredit", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null){
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]), 
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])), 
                    "finvardetail", null);
                if (R2 != null)
                      newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }

        }

        private void btnStorniCrediti_Click(object sender, EventArgs e){
            //Sono tutte le var di Crediti [flagcredit = S] associate al finanziamento corrente
            // mettiamo quelle normali  [1] e gli storni [4], perchè quelle di ripartizione e assestamento le abbiamo conteggiate nella dotazione iniziale

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagcredit", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";
            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null){
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }
        }

        private void btnAssegnazioniCrediti_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            string MyFilter;
            string VistaScelta;

            MyFilter = QHS.CmpEq("ycreditpart", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));         

            VistaScelta = "creditpartview";

            MetaData MAssegnazioneCrediti = MetaData.GetMetaData(this, VistaScelta);
            MAssegnazioneCrediti.FilterLocked = true;
            MAssegnazioneCrediti.DS = DS;
            DataRow MyDR = MAssegnazioneCrediti.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null){
                MetaData newCreditpart = Meta.Dispatcher.Get("creditpart");
                newCreditpart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newCreditpart.SelectOne(newCreditpart.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("ycreditpart", MyDR["ycreditpart"]), QHS.CmpEq("ncreditpart", MyDR["ncreditpart"]),
                    QHS.CmpEq("idinc", MyDR["idinc"])),
                    "creditpart", null);
                if (R2 != null)
                    newCreditpart.SelectRow(R2, newCreditpart.DefaultListType);
            }
        }

        private void btnAccertamentiNonAttribuiti_Click(object sender, EventArgs e){
            //accertamenti a cui non ho fatto l'attribuzione crediti
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("incomefinphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpGt("unpartitioned", 0));


            MetaData MAccertamenti = MetaData.GetMetaData(this, "incomeview");
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("assegnazionecredito", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
            }

        }

        private void btnDotazioneInizialeCassa_Click(object sender, EventArgs e){
            //Sono tutte le var di tipo Ripartizione[kind = 2] e assestamento [kind=3] associate al finanziamento corrente

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));

            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagproceeds", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null)
            {
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }
        }

        private void btnIncassi_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            MetaData MAccertamenti = MetaData.GetMetaData(this, "incomeview");
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("default", MyFilter, null, null);

            if (MyDR != null)
            {
                SelezionaMovimento(MyDR, "E");
            }

        }

        private void btnStorniIncassi_Click(object sender, EventArgs e){
            //Sono tutte le var di tipo Storno[kind = 4] e Incassi [flagproceeds = S] associate al finanziamento corrente

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));

            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("variationkind", "4"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagproceeds", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null)
            {
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }

        }

        private void btnAssegnazioniIncassi_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            string MyFilter;
            string VistaScelta;

            MyFilter = QHS.CmpEq("yproceedspart", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "proceedspartview";

            MetaData MAssegnazioneIncassi = MetaData.GetMetaData(this, VistaScelta);
            MAssegnazioneIncassi.FilterLocked = true;
            MAssegnazioneIncassi.DS = DS;
            DataRow MyDR = MAssegnazioneIncassi.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                MetaData newProceedspart = Meta.Dispatcher.Get("proceedspart");
                newProceedspart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newProceedspart.SelectOne(newProceedspart.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yproceedspart", MyDR["yproceedspart"]), QHS.CmpEq("nproceedspart", MyDR["nproceedspart"]),
                    QHS.CmpEq("idinc", MyDR["idinc"])),
                    "proceedspart", null);
                if (R2 != null)
                    newProceedspart.SelectRow(R2, newProceedspart.DefaultListType);
            }
            
        }

        private void btnIncassiNonAttribuiti_Click(object sender, EventArgs e){
            //accertamenti a cui non ho fatto l'attribuzione crediti
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpGt("unpartitioned", 0));


            MetaData MIncassi = MetaData.GetMetaData(this, "incomeview");
            MIncassi.FilterLocked = true;
            MIncassi.DS = DS;
            DataRow MyDR = MIncassi.SelectOne("assegnazionecredito", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
            }

        }

        private void btnPagamenti_Click(object sender, EventArgs e){
            // Impegni suddivisi per progetto/voce in uscita  (da underwritingexpense sugli impegni) 
            // In spesa ci possono essere più finanziamenti collegati allo stesso movimento.
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;

            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("ymov", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "underwritingpayment";

            MetaData MPagamenti = MetaData.GetMetaData(this, VistaScelta);
            MPagamenti.FilterLocked = true;
            MPagamenti.DS = DS;
            DataRow MyDR = MPagamenti.SelectOne("default", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "UP");
            }

        }

        private void btnAssegnazioniCreditianniprec_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            string MyFilter;
            string VistaScelta;

            MyFilter = QHS.CmpLt("ycreditpart", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "creditpartview";

            MetaData MAssegnazioneCrediti = MetaData.GetMetaData(this, VistaScelta);
            MAssegnazioneCrediti.FilterLocked = true;
            MAssegnazioneCrediti.DS = DS;
            DataRow MyDR = MAssegnazioneCrediti.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                MetaData newCreditpart = Meta.Dispatcher.Get("creditpart");
                newCreditpart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newCreditpart.SelectOne(newCreditpart.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("ycreditpart", MyDR["ycreditpart"]), QHS.CmpEq("ncreditpart", MyDR["ncreditpart"]),
                    QHS.CmpEq("idinc", MyDR["idinc"])),
                    "creditpart", null);
                if (R2 != null)
                    newCreditpart.SelectRow(R2, newCreditpart.DefaultListType);
            }

        }

        private void btnVarCreditiAnniPrec_Click(object sender, EventArgs e){
            //Sono tutte le var Crediti [flagcredit = S] associate al finanziamento corrente
            // mettiamo quelle normali  [1] e gli storni [4], perchè quelle di ripartizione e assestamento le abbiamo conteggiate nella dotazione iniziale
            DataAccess Conn = MetaData.GetConnection(this);
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLe("yvar", esercizioPrec);
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagcredit", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null)
            {
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }
        }

        private void btnImpegnatoPrec_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;

            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLt("ymov", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "underwritingappropriation";

            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "UA");
            }

        }

        private void txtDotCreditiInizialeddd_Click(object sender, EventArgs e){
            //Sono tutte le var di tipo Ripartizione[kind = 2] e assestamento [kind=3] associate al finanziamento corrente

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("yvar", esercizioCurr);

            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagcredit", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null)
            {
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }
        }

        private void btnAssegnazioniIncassiPrec_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            string MyFilter;
            string VistaScelta;

            MyFilter = QHS.CmpLt("yproceedspart", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "proceedspartview";

            MetaData MAssegnazioneIncassi = MetaData.GetMetaData(this, VistaScelta);
            MAssegnazioneIncassi.FilterLocked = true;
            MAssegnazioneIncassi.DS = DS;
            DataRow MyDR = MAssegnazioneIncassi.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                MetaData newProceedspart = Meta.Dispatcher.Get("proceedspart");
                newProceedspart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newProceedspart.SelectOne(newProceedspart.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yproceedspart", MyDR["yproceedspart"]), QHS.CmpEq("nproceedspart", MyDR["nproceedspart"]),
                    QHS.CmpEq("idinc", MyDR["idinc"])),
                    "proceedspart", null);
                if (R2 != null)
                    newProceedspart.SelectRow(R2, newProceedspart.DefaultListType);
            }

        }

        private void btnVarIncassiPrec_Click(object sender, EventArgs e){
            //Sono tutte le var Incassi [flagproceeds = S] associate al finanziamento corrente
            // mettiamo quelle normali  [1] e gli storni [4], perchè quelle di ripartizione e assestamento le abbiamo conteggiate nella dotazione iniziale
            DataAccess Conn = MetaData.GetConnection(this);
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLe("yvar", esercizioPrec);
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagproceeds", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null){
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }

        }

        private void btnPagatoPrec_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;

            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLt("ymov", Meta.GetSys("esercizio"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "underwritingpayment";

            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "UP");
            }

        }

        private void btnDotazioneInizialeIncassiPrec_Click(object sender, EventArgs e){
            //Sono tutte le var di tipo Ripartizione[kind = 2] e assestamento [kind=3] associate al finanziamento corrente

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;

            MyFilter = QHS.CmpLe("yvar", esercizioPrec);

            MyFilter = QHS.AppAnd(MyFilter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idfinvarstatus", "5"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("flagproceeds", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("finpart", "S"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "finvardetailview";

            MetaData MDettVariazioni = MetaData.GetMetaData(this, VistaScelta);
            MDettVariazioni.FilterLocked = true;
            MDettVariazioni.DS = DS;
            DataRow MyDR = MDettVariazioni.SelectOne("listaestesa", MyFilter, null, null);

            if (MyDR != null)
            {
                MetaData newFinvardetail = Meta.Dispatcher.Get("finvardetail");
                newFinvardetail.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinvardetail.SelectOne(newFinvardetail.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"]),
                    QHS.CmpEq("idupb", MyDR["idupb"]), QHS.CmpEq("idfin", MyDR["idfin"])),
                    "finvardetail", null);
                if (R2 != null)
                    newFinvardetail.SelectRow(R2, newFinvardetail.DefaultListType);
            }
        }

        private void btnVarAccertamentiResidui_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            MyFilter =  QHS.AppAnd(MyFilter,QHS.CmpEq("nphase", Meta.GetSys("incomefinphase")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLt("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "incomevarview";

            MetaData MAccertamenti = MetaData.GetMetaData(this, VistaScelta);
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null){
                SelezionaMovimento(MyDR, "E");
            }
        }
        private void btnPiccolespeseImp_Click(object sender, EventArgs e){
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];
            string Filter = FilterPiccoleSpeseImp(Curr);
            string VistaScelta = "pettycashopunderwritingview";

            MetaData Mpettycash = MetaData.GetMetaData(this, VistaScelta);
            Mpettycash.FilterLocked = true;
            Mpettycash.DS = DS;
            DataRow MyDR = Mpettycash.SelectOne("default", Filter, null, null);

            if (MyDR != null){
                MetaData newPettycashunderwriting = Meta.Dispatcher.Get("pettycashoperationunderwriting");
                newPettycashunderwriting.Edit(this.ParentForm, "default", false);
                DataRow R2 = newPettycashunderwriting.SelectOne(newPettycashunderwriting.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yrestore", MyDR["yrestore"]), QHS.CmpEq("nrestore", MyDR["nrestore"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"]), QHS.CmpEq("idunderwriting", MyDR["idunderwriting"])), "pettycashoperationunderwriting", null);
                if (R2 != null) newPettycashunderwriting.SelectRow(R2, newPettycashunderwriting.DefaultListType);
            }
        }

        private void BtnPiccolespesePag_Click(object sender, EventArgs e){
            DataAccess Conn = MetaData.GetConnection(this);
            string VistaScelta;

            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string Filter = "";
            Filter = QHS.CmpEq("yoperation", esercizioCurr);
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.IsNull("yrestore"));

            VistaScelta = "pettycashopunderwritingview";

            MetaData Mpettycash = MetaData.GetMetaData(this, VistaScelta);
            Mpettycash.FilterLocked = true;
            Mpettycash.DS = DS;
            DataRow MyDR = Mpettycash.SelectOne("default", Filter, null, null);

            if (MyDR != null){
                MetaData newPettycashunderwriting = Meta.Dispatcher.Get("pettycashoperationunderwriting");
                newPettycashunderwriting.Edit(this.ParentForm, "default", false);
                DataRow R2 = newPettycashunderwriting.SelectOne(newPettycashunderwriting.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yrestore", MyDR["yrestore"]), QHS.CmpEq("nrestore", MyDR["nrestore"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"]), QHS.CmpEq("idunderwriting", MyDR["idunderwriting"])), "pettycashoperationunderwriting", null);
                if (R2 != null) newPettycashunderwriting.SelectRow(R2, newPettycashunderwriting.DefaultListType);
            }

        }

        private void btnVarImpegni_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "expensevarview";

            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "VS");
            }
        }

        private void btnVarImpegniPrec_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLt("ymov", Meta.GetSys("esercizio")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "expensevarview";

            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "VS");
            }

        }

        private void btnVarPagamentiPrec_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpLt("ymov", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "expensevarview";

            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "VS");
            }
        }

        private void btnVarPagamenti_Click(object sender, EventArgs e) {
                        DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;
            string VistaScelta;
            if (DS.underwriting.Rows.Count == 0) return;
            DataRow Curr = DS.underwriting.Rows[0];

            MyFilter = QHS.CmpEq("ymov", Meta.GetSys("esercizio"));
            MyFilter =  QHS.AppAnd(MyFilter,QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idunderwriting", Curr["idunderwriting"]));

            VistaScelta = "expensevarview";

            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("lista", MyFilter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "VS");
            }
        }

        private void btnCalcolaTotaliCrediti_Click(object sender, EventArgs e) {
            txtAccertatoAnniPrec.Text = TotAccertatoAnniPrec().ToString("C");
            txtAssegnazioniCreditiAnniPrec.Text = TotAssegnazioniCreditiAnniPrec().ToString("C");
            txtVarCreditiAnniPrec.Text = TotVarCreditiAnniPrec().ToString("C");
            txtImpegnatoPrec.Text = TotImpegnatoPrec().ToString("C");
            txtVarImpegniPrec.Text = TotVarImpegniPrec().ToString("C");
            txtDotInizialeCreditiTeorica.Text = TotDotInizialeCreditiTeorica().ToString("C");
            txtDotCreditiIniziale.Text = TotDotCreditiIniziale().ToString("C");
            txtAccertamenti.Text = TotAccertamenti().ToString("C");
            txtVarAccertamentiResidui.Text = TotVarAccertamentiResidui().ToString("C");
            txtAssegnazioniCrediti.Text = TotAssegnazioniCrediti().ToString("C");
            txtAccertamentiNonAttribuiti.Text = TotAccertamentiNonAttribuiti().ToString("C");
            txtVarCrediti.Text = TotVarCrediti().ToString("C");
            txtCreditiCorrenti.Text = TotCreditiCorrenti().ToString("C");
            txtImpegni.Text = TotImpegni().ToString("C");
            txtVarImpegni.Text = TotVarImpegni().ToString("C");
            txtPiccolespeseImp.Text = TotPiccolespeseImp().ToString("C");
            txtCreditiNonUtilizzati.Text = TotCreditiNonUtilizzati().ToString("C");

        }

        private void btnCalcolaTotaliIncassi_Click(object sender, EventArgs e) {
            TxtIncassatoAnniPrec.Text = TotIncassatoAnniPrec().ToString("C");
            txtAssegnazioniIncassiPrec.Text = TotAssegnazioniIncassiPrec().ToString("C");
            txtVarIncassiPrec.Text = TotVarIncassiPrec().ToString("C");
            txtPagatoPrec.Text = TotPagatoPrec().ToString("C");
            txtVarPagamentiPrec.Text = TotVarPagatoPrec().ToString("C");
            txtDotInizialeIncassiTeorica.Text = TotDorInizialeIncassiTeorica().ToString("C");
            txtDotInizialeCassa.Text = TotDotInizialeCassa().ToString("C");
            txtIncassi.Text = TotIncassi().ToString("C");
            txtAssegnazioniIncassi.Text = TotAssegnazioniIncassi().ToString("C");
            TxtIncassiNonAttribuiti.Text = TotIncassiNonAttribuiti().ToString("C");
            txtVariazioniIncassi.Text = TotVariazioniIncassi().ToString("C");
            txtIncassiCorrenti.Text = TotIncassiCorrenti().ToString("C");
            TxtPagamenti.Text = TotPagamenti().ToString("C");
            txtVarPagamenti.Text = TotVarPagamenti().ToString("C");
            txtPiccolespesePag.Text = TotPiccolespesePag().ToString("C"); 
             txtIncassiNonUtilizzati.Text = IncassiNonUtilizzati().ToString("C");
        }

        private void btnPrevPrincipale_Click(object sender, EventArgs e) {
            CalcolaValoriPrevisionePrincipale();
        }

        private void btnPrevSecondaria_Click(object sender, EventArgs e) {
            CalcolaValoriPrevisioneSecondaria();
        }
        

    }
}
