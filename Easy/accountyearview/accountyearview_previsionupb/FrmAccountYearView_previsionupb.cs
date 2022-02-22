
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


namespace accountyearview_previsionupb {

    public partial class FrmAccountYearView_previsionupb : MetaDataForm {
        MetaData Meta;

        public FrmAccountYearView_previsionupb() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();            

            cambiaEtichetteEsercizi();
            

        }
        private void cambiaEtichetteEsercizi() {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            grpImporto1.Text = (esercizioCurr).ToString();
            grpImportoC1.Text = (esercizioCurr).ToString();
            grpImporto2.Text = (++esercizioCurr).ToString();
            grpImportoC2.Text = (esercizioCurr).ToString();
            grpImporto3.Text = (++esercizioCurr).ToString();
            grpImportoC3.Text = (esercizioCurr).ToString();
            grpImporto4.Text = (++esercizioCurr).ToString();
            grpImportoC4.Text = (esercizioCurr).ToString();
            grpImporto5.Text = (++esercizioCurr).ToString();
            grpImportoC5.Text = (esercizioCurr).ToString();
        }

        public void MetaData_AfterFill() {
            if (Meta.InsertMode) {
                if (MetaDataDetail.TabPages.Contains(tabConsolidato))
                    MetaDataDetail.TabPages.Remove(tabConsolidato);
            }

        }

       

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "upb") {
                if (R != null) {
                    DataRow Curr = DS.accountyearview.Rows[0];
                    Curr["codeupb"] = R["codeupb"];
                    Curr["upb"] = R["title"];
                    Curr["paridupb"] = R["paridupb"];

                }

            }
        }

        public void MetaData_AfterActivation() {

            calcolaConsolidato();

        }

        private object isNull(object a, object b) {
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void calcolaConsolidato() {
            DataRow Curr = DS.accountyearview.Rows[0];
            object idacc = Curr["idacc"];
            string idupb = Curr["idupb"].ToString();

            string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupb), "(paridupb LIKE '" + idupb + "%')"));
            filtro = QHS.AppAnd(filtro, QHS.CmpEq("idacc", idacc));
            string expr = "";
            foreach (string field in new string[]{"prevision","prevision2","prevision3","prevision4",
                            "prevision5"}) {
                if (expr != "")
                    expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable TAccyearview = Meta.Conn.SQLRunner("SELECT " + expr + " FROM accountyearview WHERE " + filtro, false);


            decimal previsioneCorr = 0;
            decimal previsioneAnno2 = 0;
            decimal previsioneAnno3 = 0;
            decimal previsioneAnno4 = 0;
            decimal previsioneAnno5 = 0;

            foreach (DataRow rAccYear in TAccyearview.Select()) {
                previsioneCorr += (decimal)isNull(rAccYear["prevision"], 0m);
                previsioneAnno2 += (decimal)isNull(rAccYear["prevision2"], 0m);
                previsioneAnno3 += (decimal)isNull(rAccYear["prevision3"], 0m);
                previsioneAnno4 += (decimal)isNull(rAccYear["prevision4"], 0m);
                previsioneAnno5 += (decimal)isNull(rAccYear["prevision5"], 0m);
            }
            txtCons1.Text = previsioneCorr.ToString("c");
            txtCons2.Text = previsioneAnno2.ToString("c");
            txtCons3.Text = previsioneAnno3.ToString("c");
            txtCons4.Text = previsioneAnno4.ToString("c");
            txtCons5.Text = previsioneAnno5.ToString("c");
           
        }
    }
}
