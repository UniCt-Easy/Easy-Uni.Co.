
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace budgetprevisionview_previsionupb
{
    public partial class Frm_budgetprevisionview_previsionupb : MetaDataForm
    {
        MetaData Meta;


        public Frm_budgetprevisionview_previsionupb()
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
            GetData.CacheTable(DS.upb, null, "codeupb", true);
            DataRow SourceRow = Meta.SourceRow;
            //string filter = QHS.CmpEq("idsor", SourceRow["idsor"]);
            //DataTable SortTable = Meta.Conn.RUN_SELECT("sortingview", "idsorkind, codesorkind,sortingkind,idsor,paridsor,sortcode,description,nlevel,leveldescr", null, filter, null, null, true);
          
            //if (SortTable.Rows.Count > 0)
            //{
            //    DataRow SortRow = SortTable.Rows[0];
            //    MetaData.SetDefault(DS.budgetprevisionview, "idsorkind", SortRow["idsorkind"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "codesorkind", SortRow["codesorkind"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "sortingkind", SortRow["sortingkind"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "idsor", SortRow["idsor"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "paridsor", SortRow["paridsor"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "sortcode", SortRow["sortcode"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "sorting", SortRow["description"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "nlevel", SortRow["nlevel"]);
            //    MetaData.SetDefault(DS.budgetprevisionview, "leveldescr", SortRow["leveldescr"]);
               
            //}
            cambiaEtichetteEsercizi();
        }
        public void MetaData_AfterFill() {
            if (Meta.InsertMode) {
                if (MetaDataDetail.TabPages.Contains(tabConsolidato))
                    MetaDataDetail.TabPages.Remove(tabConsolidato);
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (T.TableName == "upb")
            {
                if (R != null)
                {
                    DataRow Curr = DS.budgetprevisionview.Rows[0];
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
            lblEsCorrPrincCons.Text = currstr;
            lblEsPrecPrima.Text = precstr;
            lblEsPrecPrincCons.Text = precstr;
        
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

            calcolaConsolidato();
        }

        private object isNull(object a, object b)
        {
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void calcolaConsolidato()
        {
            DataRow Curr = DS.budgetprevisionview.Rows[0];
            object idSorting = Curr["idsor"];
            string idupb = Curr["idupb"].ToString();

            string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupb), "(paridupb LIKE '" + idupb + "%')"));
            filtro = QHS.AppAnd(filtro, QHS.CmpEq("idsor", idSorting));
            string expr = "";
            foreach (string field in new string[]{"prevision","previousprevision",
                                                  "prevision2","prevision3","prevision4","prevision5"}) {
                if (expr != "") expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable Tbudgetprevisionview = Meta.Conn.SQLRunner("SELECT " + expr + " FROM budgetprevisionview WHERE " + filtro, false);


            decimal previsioneCorr = 0;
           
            decimal previsionePrec = 0;
           
            decimal previsioneAnno2 = 0;
            decimal previsioneAnno3 = 0;
            decimal previsioneAnno4 = 0;
            decimal previsioneAnno5 = 0;

            foreach (DataRow rbudgetprevision in Tbudgetprevisionview.Select())
            {
                previsioneCorr += (decimal)isNull(rbudgetprevision["prevision"], 0m);
          
                previsionePrec += (decimal)isNull(rbudgetprevision["previousprevision"], 0m);
              
                previsioneAnno2 += (decimal)isNull(rbudgetprevision["prevision2"], 0m);
                previsioneAnno3 += (decimal)isNull(rbudgetprevision["prevision3"], 0m);
                previsioneAnno4 += (decimal)isNull(rbudgetprevision["prevision4"], 0m);
                previsioneAnno5 += (decimal)isNull(rbudgetprevision["prevision5"], 0m);
            }
            txtPrevisionePrincipaleCorrConsolidato.Text = previsioneCorr.ToString("c");
            txtPrevisionePrincipalePrecConsolidato.Text = previsionePrec.ToString("c");
            txtPrevisione2Consolidato.Text = previsioneAnno2.ToString("c");
            txtPrevisione3Consolidato.Text = previsioneAnno3.ToString("c");
            txtPrevisione4Consolidato.Text = previsioneAnno4.ToString("c");
            txtPrevisione5Consolidato.Text = previsioneAnno5.ToString("c");
        }
        
    }
}
