/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;


namespace funzioni_configurazione {
    public class CalcoliFinanziario {
        MetaData Meta;
        MetaDataDispatcher Disp;
        Form F;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataAccess Conn;
        DataSet DS;
        Form ParentForm;
        public CalcoliFinanziario(MetaData Meta, Form F) {
            this.Meta = Meta;
            this.Disp = Meta.Dispatcher;
            this.DS = Meta.DS;
            this.F = F;
            this.ParentForm = F.ParentForm;
            this.Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            minlevelop = CfgFn.GetNoNullInt32(Conn.GetSys("finusablelevel"));
            ChooseComparators();

        }
        object idfin;
        object idupb;
        object idunderwriting;
        bool idupbwithchilds=false;
        int minlevelop;

        public bool Enabled = true;

        bool voceBilancioOperativa = false;
        bool voceBilancioFoglia = false;
         
        public void SetMask(object idfin, object idupb, object idunderwriting) {
            if (idupb==null)idupb=DBNull.Value;
            if (idfin==null)idfin=DBNull.Value;
            this.idfin = idfin;
            this.idupb = idupb;
            this.idunderwriting = idunderwriting;
            voceBilancioOperativa = false;
            voceBilancioFoglia = false;
            if (idfin != DBNull.Value) {
               
                int finlevel = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfin), "nlevel"));
                if (finlevel >= minlevelop) voceBilancioOperativa = true;
                int N = Conn.RUN_SELECT_COUNT("finlast", QHS.CmpEq("idfin", idfin), false);
                if (N > 0) voceBilancioFoglia = true;
            }
            if (idupb == DBNull.Value) {
                idupbwithchilds = false;
            }
            ChooseComparators();
            
        }
        delegate string myUPBComparator(string field, object value);
        
        string UpbCompareEqual(string field, object value) {
            return QHS.CmpEq(field, value);
        }
        string UpbCompareLike(string field, object value) {
            if (value == null) return QHS.Like(field, "%");
            return QHS.Like(field, value.ToString()+"%");
        }
        
        public void SetUpbWithChilds(bool withChilds) {
            idupbwithchilds = withChilds;
            ChooseComparators();
        }

        delegate string myFinComparator(string field, object value);
        string FinCompareEqual(string field, object value) {
            return QHS.CmpEq(field, value);
        }
        string FinGetAllChilds(string field, object value) {
            if (voceBilancioFoglia) {
                return QHS.CmpEq(field, value);
            }
            else {
                return "(" + field + " in (select idchild from finlink FFL where FFL.idparent=" + QHS.quote(value) + "))";
            }
        }
        string FinGetChildsLivOperativo(string field, object value) {
            int minlevelop = CfgFn.GetNoNullInt32(Conn.GetSys("finusablelevel"));
            return "(" + field + " in (select idchild from finlink FqL where FqL.idparent=" + QHS.quote(value)
                        + ")) AND ( (select nlevel from fin fq5 where fq5.idfin="+field+")="+QHS.quote(minlevelop)+")";
        }

        void ChooseComparators() {
            if (idupbwithchilds)
                upbComp = UpbCompareLike;
            else
                upbComp = UpbCompareEqual;

            finComp = FinGetAllChilds;
            if (voceBilancioOperativa) {
                finCompPrevision = FinCompareEqual;
            }
            else {
                finCompPrevision = FinGetChildsLivOperativo;
            }

        }

        myUPBComparator upbComp;
        myFinComparator finComp;
        myFinComparator finCompPrevision;


        #region Piccole Spese
        public void ElencaPiccoleSpese() {
            if (!Enabled) return;
            string Filter = FilterPiccoleSpesePag();
            string VistaScelta = (idunderwriting == DBNull.Value) ? "pettycashoperationview" : "pettycashopunderwritingview";

            MetaData Mpettycash = Disp.Get(VistaScelta);
            Mpettycash.FilterLocked = true;
            Mpettycash.DS = DS;
            DataRow MyDR = Mpettycash.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                MetaData newPettycashop = Meta.Dispatcher.Get("pettycashoperation");
                newPettycashop.Edit(F.ParentForm, "default", false);
                DataRow R2 = newPettycashop.SelectOne(newPettycashop.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yoperation", MyDR["yoperation"]), QHS.CmpEq("noperation", MyDR["noperation"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"])), "pettycashoperation", null);
                if (R2 != null) newPettycashop.SelectRow(R2, newPettycashop.DefaultListType);
            }
        }

        private string FilterPiccoleSpesePag() {
            string Filter = "";
            Filter = QHS.CmpEq("yoperation", Meta.GetSys("esercizio"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("yrestore"), QHS.CmpGt("adaterestore", Meta.GetSys("datacontabile")))));
            if (idupb==DBNull.Value) Filter = QHS.AppAnd(Filter,GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());

            return Filter;           
        }

        public decimal CK(Object O) {
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }


        public decimal TotPiccoleSpesePag() {
            if (!Enabled) return 0;
            // Vanno considerate le p.spese non reintegrate, senza considerare l'associazione ad un impegno
            decimal valore;

            string Filter = FilterPiccoleSpesePag();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("pettycashoperationview", true));
            string strExpr = "SUM(amount)";
            string VistaScelta = (idunderwriting == DBNull.Value) ? "pettycashoperationview" : "pettycashopunderwritingview";
            valore = CK(Conn.DO_READ_VALUE(VistaScelta, Filter, strExpr));
            return valore;
        }

        public void ElencaPiccoleSpesePag() {
            if (!Enabled) return;
            string Filter = FilterPiccoleSpesePag();
            string VistaScelta = (idunderwriting == DBNull.Value) ? "pettycashoperationview" : "pettycashopunderwritingview";

            MetaData Mpettycash = Disp.Get(VistaScelta);
            Mpettycash.FilterLocked = true;
            Mpettycash.DS = DS;
            DataRow MyDR = Mpettycash.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                MetaData newPettycashop = Meta.Dispatcher.Get("pettycashoperation");
                newPettycashop.Edit(F.ParentForm, "default", false);
                DataRow R2 = newPettycashop.SelectOne(newPettycashop.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yoperation", MyDR["yoperation"]), QHS.CmpEq("noperation", MyDR["noperation"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"])), "pettycashoperation", null);
                if (R2 != null) newPettycashop.SelectRow(R2, newPettycashop.DefaultListType);
            }

            /*
             * 
            if (MyDR != null) {
                MetaData newPettycashop = Meta.Dispatcher.Get("pettycashoperation");
                newPettycashop.Edit(this.ParentForm, "default", false);
                DataRow R2 = newPettycashop.SelectOne(newPettycashop.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yrestore", MyDR["yrestore"]), QHS.CmpEq("nrestore", MyDR["nrestore"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"]), upbComp("idupb", MyDR["idupb"])), "pettycashoperation", null);
                if (R2 != null) newPettycashop.SelectRow(R2, newPettycashop.DefaultListType);
            }
             */


        }

        public void ElencaPiccoleSpeseImp() {
            if (!Enabled) return;
            string Filter = FilterPiccoleSpeseImp();
            string VistaScelta = (idunderwriting == DBNull.Value) ? "pettycashoperationview" : "pettycashopunderwritingview";

            MetaData Mpettycash = Disp.Get(VistaScelta);
            Mpettycash.FilterLocked = true;
            Mpettycash.DS = DS;
            DataRow MyDR = Mpettycash.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                MetaData newPettycashop = Meta.Dispatcher.Get("pettycashoperation");
                newPettycashop.Edit(F.ParentForm, "default", false);
                DataRow R2 = newPettycashop.SelectOne(newPettycashop.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("yoperation", MyDR["yoperation"]), QHS.CmpEq("noperation", MyDR["noperation"]),
                    QHS.CmpEq("idpettycash", MyDR["idpettycash"])), "pettycashoperation", null);

                if (R2 != null) newPettycashop.SelectRow(R2, newPettycashop.DefaultListType);
            }
        }

        public string FilterPiccoleSpeseImp() {
            string Filter = "";
            Filter = QHS.CmpEq("yoperation", Meta.GetSys("esercizio"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("yrestore"), QHS.CmpGt("adaterestore", Meta.GetSys("datacontabile")))));
            Filter = QHS.AppAnd(Filter, QHS.IsNull("idexp"));
            //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());

            return Filter;
        }

        public decimal TotPiccoleSpeseImp() {
            // Vanno considerate le p.spese non reintegrate e NON associate ad un impegno
            decimal valore;
            if (!Enabled) return 0;

            string Filter = FilterPiccoleSpeseImp();
            string VistaScelta = (idunderwriting == DBNull.Value) ? "pettycashoperationview" : "pettycashopunderwritingview";
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("pettycashoperationview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Conn.DO_READ_VALUE(VistaScelta, Filter, strExpr));
            return valore;
        }
        #endregion

        #region previsione Iniziale cassa (da finyear)
        
        public void ElencaPrevInizialeCassa(string finpart) {
            if (!Enabled) return;

            //Previsione corrente (cassa)
            string VistaScelta = (idunderwriting == DBNull.Value) ? "finyearview" : "upbunderwritingyearview";
            string Filter = FilterPrevInizialeCassa(VistaScelta,finpart);
            MetaData MFinyearView = Disp.Get(VistaScelta);
            MFinyearView.FilterLocked = true;
            MFinyearView.DS = DS;
            DataRow MyDR = MFinyearView.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                SelezionaPrevisione(MyDR);
            }
        }

        private string FilterPrevInizialeCassa(string vistascelta,string finpart) {
            string secprev = "";
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                //Se è un bilancio di sola cassa, la prev. di cassa viene scritta in previsione.
                secprev = (vistascelta == "finyearview") ? "prevision" : "initialprevision";
            }
            else {
                secprev = (vistascelta == "finyearview") ? "secondaryprev" : "initialsecondaryprev";
            }
            string filter = "";
            filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (idfin != DBNull.Value) filter = QHS.AppAnd(filter, finCompPrevision(vistascelta+".idfin", idfin));
            if (idfin == DBNull.Value && vistascelta == "finyearview") {
                int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("finusablelevel"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", levelop));
            }
            if (idunderwriting != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) filter = QHS.AppAnd(filter, upbComp("idupb", idupb));
            if (finpart != "") filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", finpart));

            if (idupb == DBNull.Value) filter = QHS.AppAnd(filter, GetCondUpb());
            if (idfin == DBNull.Value) filter = QHS.AppAnd(filter, GetCondFin());
            if (idupb == DBNull.Value) filter = QHS.AppAnd(filter, GetCondSor());


            filter = QHS.AppAnd(filter, QHS.CmpNe(secprev, 0));
            return filter;
        }

        private void SelezionaPrevisione(DataRow MyDR) {

            if (!MyDR.Table.Columns.Contains("idunderwriting")) {
                MetaData newFinyearView = Meta.Dispatcher.Get("finyearview");
                newFinyearView.ExtraParameter = MyDR["idfin"];
                newFinyearView.Edit(this.ParentForm, "default", false);
                DataRow R2 = newFinyearView.SelectOne(newFinyearView.DefaultListType,
                     QHS.AppAnd(finCompPrevision("finyearview.idfin", MyDR["idfin"]),
                                   upbComp("idupb", MyDR["idupb"])), "finyearview", null);
                if (R2 != null) newFinyearView.SelectRow(R2, newFinyearView.DefaultListType);
            }
        }

        public decimal TotPrevInizialeCassa(string finpart) {
            if (!Enabled) return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            // Previsione corrente Entrata (principale)
            string VistaScelta = (idunderwriting == DBNull.Value) ? "finyearview" : "upbunderwritingyearview";
            string secprev = "";
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                //Se è un bilancio di sola cassa, la prev. di cassa viene scritta in previsione.
                secprev = (VistaScelta == "finyearview") ? "prevision" : "initialprevision";
            }
            else {
                secprev = (VistaScelta == "finyearview") ? "secondaryprev" : "initialsecondaryprev";
            }


            string Filter = FilterPrevInizialeCassa(VistaScelta,finpart);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finyearview", true));
            string strExpr = "SUM(" + secprev + ")";
            decimal valore = CK(Conn.DO_READ_VALUE(VistaScelta, Filter, strExpr));
            return valore;
        }


        #endregion

        #region Variazioni NORMALI Dotazione Cassa

        /// <summary>
        /// Variazioni NORMALI E STORNI Dotazione Cassa
        /// </summary>
        public void ElencaVarNormaleCassa() {
            string filter = filterVarNormaleCassa(); ;
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }

        }
        private string filterVarNormaleCassa() {
            string Filter = "";
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));  //A scanso di equivoci

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());

            return Filter;
        }


        private void SelezionaVariazione(DataRow MyDR) {
            MetaData newFinVarDetail = Meta.Dispatcher.Get("finvardetail");

            newFinVarDetail.Edit(this.ParentForm, "default", false);
            DataRow R2 = newFinVarDetail.SelectOne("lista",
                QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
                QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
                "finvardetail", null);
            if (R2 != null) newFinVarDetail.SelectRow(R2, "lista");
        }

        /// <summary>
        /// Variazioni NORMALI E STORNI Dotazione Cassa
        /// </summary>
        /// <returns></returns>
        public decimal TotVarNormaleCassa() {
            // variazioni e storni di cassa
            if (!Enabled) return 0;

            string Filter = filterVarNormaleCassa();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }


        #endregion

        #region Variazioni NORMALI Dotazione crediti
        /// <summary>
        ///  Variazioni NORMALI E STORNI Dotazione crediti
        /// </summary>
        public void ElencaVarNormaleCrediti() {
            string Filter = FilterVarNormaleCrediti();
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", Filter, null, null);
            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }

        private string FilterVarNormaleCrediti() {
            string Filter = "";
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "1"), QHS.CmpEq("variationkind", "4"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S"));  //A scanso di equivoci

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());


            return Filter;
        }

        /// <summary>
        /// Variazioni NORMALI E STORNI Dotazione crediti
        /// </summary>
        /// <returns></returns>
        public decimal TotVarNormaleCrediti() {
            //variazioni e storni di crediti
            if (!Enabled) return 0;

            string Filter = FilterVarNormaleCrediti();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }
        
        #endregion

        #region Variazioni RIPARTIZIONE Dotazione Cassa
        /// <summary>
        /// Variazioni di Ripartizione e Assestamento Dotazione Cassa
        /// </summary>
        public void ElencaVarRipartizioneCassa() {
            if (!Enabled) return;
            string filter = FilterVarRipartizioneCassa();
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }


        private string FilterVarRipartizioneCassa() {
            string Filter = "";
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagproceeds", "S"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S")); //A SCANSO DI EQUIVOCI....

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());


            return Filter;
        }

        /// <summary>
        ///  Variazioni di Ripartizione e Assestamento Dotazione Cassa
        /// </summary>
        /// <returns></returns>
        public decimal TotVarRipartizioneCassa() {
            // dotazione iniziale cassa
            if (!Enabled) return 0;

            string Filter = FilterVarRipartizioneCassa();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }



        #endregion

        #region Variazione RIPARTIZIONE Dotazione Crediti
        /// <summary>
        /// Variazioni di Ripartizione e Assestamento Dotazione Crediti
        /// </summary>
        public void ElencaVarRipartizioneCrediti() {
            string filter = FilterVarRipartizioneCrediti();
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }

        }

        private string FilterVarRipartizioneCrediti() {
            string Filter = "";
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("variationkind", "2"), QHS.CmpEq("variationkind", "3"))));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagcredit", "S"));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            //if (finpart != "") filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", finpart));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", "S")); //A SCANSO DI EQUIVOCI....

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());


            return Filter;
        }

        public decimal TotVarRipartizioneCrediti() {
            if (!Enabled) return 0;

            string Filter = FilterVarRipartizioneCrediti();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));
            return valore;
        }



        #endregion

        #region Variazione NON INIZIALE Previsione Cassa

        /// <summary>
        /// Variazioni NON INIZIALI di cassa  (da finvardetail)
        /// </summary>
        ///
        public void ElencaVarPrevisioneCassa(string finpart) {
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            string Filter = FilterVarPrevCassa(finpart);
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", Filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }



        private string FilterVarPrevCassa(string finpart) {
            string Filter = "";
            Filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfinvarstatus", "5"));
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagprevision", "S"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagsecondaryprev", "S"));
            }

            Filter = QHS.AppAnd(Filter, QHS.CmpNe("variationkind", "5"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            if (finpart != "") Filter = QHS.AppAnd(Filter, QHS.CmpEq("finpart", finpart));

            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());


            return Filter;
        }

        public decimal TotVarPrevCassa(string finpart) {
            if (!Enabled) return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            // Previsione corrente (principale)
            string Filter = FilterVarPrevCassa(finpart);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", Filter, strExpr));

            return valore;
        }

        #endregion

        #region Variazione NON INIZIALE Previsione Competenza
        /// <summary>
        /// Variazione NON INIZIALE Previsione Competenza
        /// </summary>
        public void ElencaVariazionePrevCompetenza(string finpart) {
            if (!Enabled) return;
            string filter = filtraVarPrevCompetenza(finpart);
            string VistaScelta = "finvardetailview";
            MetaData MFinVarDetail = Disp.Get(VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }


        private string filtraVarPrevCompetenza(string finpart) {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = "";
            filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idfinvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("flagprevision", "S"));
            filter = QHS.AppAnd(filter, QHS.CmpNe("variationkind", "5"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            if (idfin != DBNull.Value) filter = QHS.AppAnd(filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) filter = QHS.AppAnd(filter, upbComp("idupb", idupb));
            if (finpart != "") filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", finpart));


            if (idupb == DBNull.Value) filter = QHS.AppAnd(filter, GetCondUpb());
            if (idfin == DBNull.Value) filter = QHS.AppAnd(filter, GetCondFin());
            if (idupb == DBNull.Value) filter = QHS.AppAnd(filter, GetCondSor());

            return filter;
        }

        public decimal TotVarPrevCompetenza(string finpart) {
            if (!Enabled) return 0;
            string filter = filtraVarPrevCompetenza(finpart);
            filter = QHS.AppAnd(filter, Conn.SelectCondition("finvardetailview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("finvardetailview", filter, strExpr));

            return valore;
        }
        

        #endregion



        #region Movimenti

        /// <summary>
        /// Seleziona un movimento per idinc/idexp
        /// </summary>
        /// <param name="MyDR"></param>
        /// <param name="entrata_spesa"></param>
        private void SelezionaMovimento(DataRow MyDR, string entrata_spesa) {

            if (entrata_spesa == "E") {
                MetaData newEntrata = Disp.Get("income");
                newEntrata.Edit(this.ParentForm, "default", false);
                DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
                    QHS.CmpEq("idinc", MyDR["idinc"]), "income", null);
                if (R2 != null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
            }
            if (entrata_spesa == "S") {
                MetaData newSpesa = Disp.Get("expense");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idexp", MyDR["idexp"]), "expense", null);
                if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }
        /// <summary>
        /// Considera tutti gli impegni presenti a prescindere dall'esercizio di creazione. 
        /// Sono gli impegni di cassa. L'importo verrà visualizzato per il bilancio di sola Cassa
        /// </summary>
        /// <returns></returns>
        public decimal TotImpegniAll() {
            if (!Enabled) return 0;

            if (idunderwriting == DBNull.Value) {

                string Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

                Filter = QHS.AppAnd(Filter, Conn.SelectCondition("expenseview", true));

                // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
                string sql = "SELECT SUM(ayearstartamount) as amount from expenseview " +
                             " WHERE " + Filter;
                DataTable t = Conn.SQLRunner(sql, false,30);
                decimal valore = t != null ? CK(t.Rows[0]["amount"]) : 0;

                // Aggiungiamo le var. dei suddetti impegni.
                Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

                if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
                if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
                if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());

                sql = "SELECT SUM(amount) as amount from expensevarview  " +
                            " WHERE " + Filter;
                t = Conn.SQLRunner(sql, false,30);
                if (t != null) valore = valore + CK(t.Rows[0]["amount"]);
                return valore;
            }
            //altrimenti prendi da underwritingappropriationview
            return 0;
        }

        public decimal TotImpegniCompetenza() {
            if (!Enabled) return 0;

            if (idunderwriting == DBNull.Value) {

                string Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                
                Filter = QHS.AppAnd(Filter, Conn.SelectCondition("expenseview", true));

                // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
                string sql = "SELECT SUM(ayearstartamount) as amount from expenseview " +
                             " WHERE " + Filter;
                DataTable t = Conn.SQLRunner(sql, false,30);
                decimal valore = t!=null? CK(t.Rows[0]["amount"]):0;

                // Aggiungiamo le var. dei suddetti impegni.
                Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));

                if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
                if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
                if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());



                sql = "SELECT SUM(amount) as amount from expensevarview  " +
                            " WHERE " + Filter;
                t = Conn.SQLRunner(sql, false,30);
                if (t!=null) valore = valore + CK(t.Rows[0]["amount"]);
                return valore;
            }
            //altrimenti prendi da underwritingappropriationview
            return 0;
        }

        #endregion

        #region Assegnazioni di Incassi

        public void ElencaAssegnazioniIncassi() {
            if (!Enabled) return;
            string Filter = FilterAssegnazioniIncassi();
            string VistaScelta = "proceedspartview";
            MetaData MAssCassa = Disp.Get(VistaScelta);
            MAssCassa.FilterLocked = true;
            MAssCassa.DS = DS;
            DataRow MyDR = MAssCassa.SelectOne("lista", Filter, null, null);

            if (MyDR != null) {
                SelezionaAssegnazione(MyDR, "P");
            }
        }


        private string FilterAssegnazioniIncassi() {
            string Filter = "";
            Filter = QHS.CmpEq("yproceedspart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));


            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());

            return Filter;
        }

        
        public decimal TotAssegnazioniIncassi() {
            if (!Enabled) return 0;
            string Filter = FilterAssegnazioniIncassi();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("proceedspartview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("proceedspartview", Filter, strExpr));
            return valore;
        }



        private void SelezionaAssegnazione(DataRow MyDR, string credit_proceeds) {

            if (credit_proceeds == "C") {
                MetaData newCreditPart = Disp.Get("creditpart");
                newCreditPart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newCreditPart.SelectOne("lista",
                    QHS.AppAnd(QHS.CmpEq("ycreditpart", MyDR["ycreditpart"]),
                               QHS.CmpEq("ncreditpart", MyDR["ncreditpart"])), "creditpart", null);
                if (R2 != null) newCreditPart.SelectRow(R2, "lista");
            }
            if (credit_proceeds == "P") {
                MetaData newProceedsPart = Disp.Get("proceedspart");
                newProceedsPart.Edit(this.ParentForm, "default", false);
                DataRow R2 = newProceedsPart.SelectOne("lista",
                             QHS.AppAnd(QHS.CmpEq("yproceedspart", MyDR["yproceedspart"]),
                               QHS.CmpEq("nproceedspart", MyDR["nproceedspart"])), "proceedspart", null);
                if (R2 != null) newProceedsPart.SelectRow(R2, "lista");
            }
        }
        #endregion


        #region Assegnazioni di Crediti
        public void ElencaAssegnazioniCrediti() {
            if (!Enabled) return;
            string Filter = FilterAssegnazioniCrediti();
            string VistaScelta = "creditpartview";
            MetaData MAssCrediti = Disp.Get(VistaScelta);
            MAssCrediti.FilterLocked = true;
            MAssCrediti.DS = DS;
            DataRow MyDR = MAssCrediti.SelectOne("lista", Filter, null, null);

            if (MyDR != null) {
                SelezionaAssegnazione(MyDR, "C");
            }
        }

        private string FilterAssegnazioniCrediti() {
            string Filter = "";
            Filter = QHS.CmpEq("ycreditpart", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));


            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondUpb());
            if (idfin == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondFin());
            if (idupb == DBNull.Value) Filter = QHS.AppAnd(Filter, GetCondSor());


            return Filter;
        }

        public decimal TotAssegnazioniCrediti() {
            if (!Enabled) return 0;

            string Filter = FilterAssegnazioniCrediti();
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("creditpartview", true));
            string strExpr = "SUM(amount)";
            decimal valore = CK(Conn.DO_READ_VALUE("creditpartview", Filter, strExpr));
            return valore;
        }
        #endregion

        #region Incassi

        public void ElencaIncassi() {
            if (!Enabled) return;
            string Filter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            string VistaScelta = "incomeview";
            MetaData MIncassi = Disp.Get(VistaScelta);
            MIncassi.FilterLocked = true;
            MIncassi.DS = DS;
            DataRow MyDR = MIncassi.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "E");
            }
        }

        public decimal TotIncassi() {
            if (!Enabled) return 0;
            string Filter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));


            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomeview", true));

            // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
            string sql = "SELECT SUM(ayearstartamount) as amount from incomeview " +
                         " WHERE " + Filter;
            decimal valore = CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);

            // Aggiungiamo le var. dei suddetti incassi.
            Filter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));

            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomevarview", true));

            sql = "SELECT SUM(amount) as amount from incomevarview " +
                       " WHERE " + Filter;

            valore = valore + CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);
            return valore;
        }

        #endregion

        string myCondSor = null;
        string GetCondSor() {
            if (myCondSor != null) return myCondSor;
            if (Conn.GetUsr("cond_sor01") == null) {
                myCondSor = "";
                return "";
            }
            string S = "";
            for (int i = 1; i <= 5; i++) {
                object f = Conn.GetUsr("cond_sor0"+i.ToString());
                if (f==null) continue;
                if (f.ToString()=="") continue;
                if (f.ToString()=="AND(1=1)") continue;
                if (f.ToString().StartsWith("AND")) f = f.ToString().Substring(3);
                if (S != "") S += " AND ";
                S += f;
            }
            myCondSor = S;
            return S;
        }

        string myCondUpb = null;
        string GetCondUpb() {
            if (myCondUpb != null) return myCondUpb;
            if (Conn.GetUsr("cond_upb") == null) {
                myCondUpb = "";
                return "";
            }
            myCondUpb = Conn.GetUsr("cond_upb").ToString();
            if (myCondUpb.ToString() == "") return "";
            if (myCondUpb.ToString() == "AND(1=1)") {
                myCondUpb="";
                return "";
            }
            if (myCondUpb.ToString().StartsWith("AND")) myCondUpb = myCondUpb.ToString().Substring(3);
            return myCondUpb;          
        }

        string myCondFin = null;
        string GetCondFin() {
            if (myCondFin != null) return myCondFin;
            if (Conn.GetUsr("cond_fin") == null) {
                myCondFin = "";
                return "";
            }
            myCondFin = Conn.GetUsr("cond_fin").ToString();
            if (myCondFin.ToString() == "") return "";
            if (myCondFin.ToString() == "AND(1=1)") {
                myCondFin = "";
                return "";
            }
            if (myCondFin.ToString().StartsWith("AND")) myCondFin = myCondFin.ToString().Substring(3);
            return myCondFin;
        }

        public void ElencaAccertamentiAll() {
            if (!Enabled) return;

            string Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));
            
            string VistaScelta = "incomeview";
            MetaData MAccertamenti = Disp.Get(VistaScelta);
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "E");
            }
        }
        #region Accertamenti

        public void ElencaAccertamentiCompetenza() {
            if (!Enabled) return;

            string Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear", "C"));

            string VistaScelta = "incomeview";
            MetaData MAccertamenti = Disp.Get( VistaScelta);
            MAccertamenti.FilterLocked = true;
            MAccertamenti.DS = DS;
            DataRow MyDR = MAccertamenti.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                SelezionaMovimento(MyDR, "E");
            }
        }

        /// <summary>
        /// Considera tutti gli accertamenti presenti a prescindere dall'esercizio di creazione. Sono gli accertamenti di cassa.
        /// L'importo verrà visualizzato per il bilancio di sola Cassa
        /// </summary>
        /// <returns></returns>
        public decimal TotAccertamentiAll() {
            if (!Enabled) return 0;
            string Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomeview", true));

            string sql = "SELECT SUM(ayearstartamount) as amount from incomeview " +
                              " WHERE " + Filter;
            decimal valore = CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);

            // Aggiungiamo le var. dei suddetti accertamenti.
            Filter = QHS.CmpEq("nphase", Meta.GetSys("assessmentphase"));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomevarview", true));

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));
            sql = "SELECT SUM(amount) as amount from incomevarview " +
                        " WHERE " + Filter;
            valore = valore + CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);
            return valore;
        }
        public decimal TotAccertamentiCompetenza() {      
            if (!Enabled) return 0;
            string Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomeview", true));

            string sql = "SELECT SUM(ayearstartamount) as amount from incomeview " +
                              " WHERE " + Filter;
            decimal valore = CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);

            // Aggiungiamo le var. dei suddetti accertamenti.
            Filter = QHS.CmpEq("nphase", Meta.GetSys("assessmentphase"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));

            if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
            if (idunderwriting != DBNull.Value) Filter = QHS.AppAnd(Filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("incomevarview", true));

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));
            sql = "SELECT SUM(amount) as amount from incomevarview " +
                        " WHERE " + Filter;
            valore = valore + CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);
            return valore;
        }


        #endregion
        public void ElencaImpegniAll() {
            if (!Enabled) return;

            if (idunderwriting == DBNull.Value) {
                string Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

                string VistaScelta = "expenseview";
                MetaData MImpegni = Disp.Get(VistaScelta);
                MImpegni.FilterLocked = true;
                MImpegni.DS = DS;
                DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
                if (MyDR != null) {
                    SelezionaMovimento(MyDR, "S");
                }
                return;
            }
        }

        #region Impegni di competenza

        public void ElencaImpegniCompetenza() {
            if (!Enabled) return;

            if (idunderwriting == DBNull.Value) {
                string Filter = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

                Filter = QHS.AppAnd(Filter, QHS.CmpEq("flagarrear", "C"));

                string VistaScelta = "expenseview";
                MetaData MImpegni = Disp.Get(VistaScelta);
                MImpegni.FilterLocked = true;
                MImpegni.DS = DS;
                DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
                if (MyDR != null) {
                    SelezionaMovimento(MyDR, "S");
                }
                return;
            }
        }

        #endregion

        #region previsione iniziale competenza
        public void ElencaPrevisioneInizialeCompetenza(string finpart) {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
           
            string VistaScelta = (idunderwriting == DBNull.Value) ? "finyearview" : "upbunderwritingyearview";
            string Filter = FilterPrevInizialeCompetenza(VistaScelta,finpart);
            MetaData MFinyearView = Disp.Get( VistaScelta);
            MFinyearView.FilterLocked = true;
            MFinyearView.DS = DS;

            DataRow MyDR = MFinyearView.SelectOne("default", Filter, null, null);

            if (MyDR != null) {
                SelezionaPrevisione(MyDR);
            }
        }

        private string FilterPrevInizialeCompetenza(string VistaScelta,string finpart) {
            string filter = "";
            filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (idfin != DBNull.Value) filter = QHS.AppAnd(filter, finCompPrevision(VistaScelta + ".idfin", idfin));
            if (idfin == DBNull.Value && VistaScelta=="finyearview") {
                int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("finusablelevel"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", levelop));
            }
            if (idunderwriting != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idunderwriting", idunderwriting));
            if (idupb != DBNull.Value) filter = QHS.AppAnd(filter, upbComp("idupb", idupb));
            if (finpart != "") filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", finpart));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            return filter;
        }

        public decimal TotPrevInizialeCompetenza(string finpart) {            
            if (!Enabled) return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string vistascelta = (idunderwriting == DBNull.Value) ? "finyearview" : "upbunderwritingyearview";

            // Previsione corrente (principale)
            string Filter = FilterPrevInizialeCompetenza(vistascelta,finpart);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("finyearview", true));
            string strExpr = "SUM(prevision)";
            decimal valore = CK(Conn.DO_READ_VALUE(vistascelta, Filter, strExpr));
            return valore;
        }
       


        #endregion

        #region Pagamenti

        public void ElencoPagamenti() {
            if (!Enabled) return;
            if (idunderwriting == DBNull.Value) {
                string Filter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

                string VistaScelta = "expenseview";

                MetaData MImpegni = Disp.Get(VistaScelta);
                MImpegni.FilterLocked = true;
                MImpegni.DS = DS;
                DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
                if (MyDR != null) {
                    SelezionaMovimento(MyDR, "S");
                }
                return;
            }

        }


        public decimal TotPagamenti() {
            if (!Enabled) return 0;

            if (idunderwriting == DBNull.Value) {
                string Filter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

                Filter = QHS.AppAnd(Filter, Conn.SelectCondition("expenseview", true));

                // quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
                string sql = "SELECT SUM(ayearstartamount) as amount from expenseview  " +
                             " WHERE " + Filter;

                decimal valore = CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);

                // Aggiungiamo le var. dei suddetti pagamenti 
                Filter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));

                if (idfin != DBNull.Value) Filter = QHS.AppAnd(Filter, finComp("idfin", idfin));
                if (idupb != DBNull.Value) Filter = QHS.AppAnd(Filter, upbComp("idupb", idupb));

                Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
                //Filter = QHS.AppAnd(Filter, Conn.SelectCondition("upb", true));
                sql = "SELECT SUM(amount) as amount from expensevarview " +
                           " WHERE " + Filter;

                valore = valore + CK(Conn.SQLRunner(sql, false,30).Rows[0]["amount"]);
                return valore;
            }
            //else prende i dati da altrove
            return 0;
        }

        #endregion
    }
}
