
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

namespace finyearview_previsionfin
{
    public partial class Frm_finyearview_previsionfin : MetaDataForm
    {
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

        public Frm_finyearview_previsionfin(){
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        bool inChiusura = false;

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            //GetData.CacheTable(DS.fin, null,"codefin", true);

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter;
            filter = QHS.CmpEq("idupb", "0001");
            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, filter));

            cambiaEtichetteEsercizi();
            impostaCampiReadonly(false);

        }


        private void impostaCampiReadonly(bool abilita){
            DS.finyearview.Columns["finpart"].ReadOnly = abilita;
        }


        public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName == "fin"){
                if (R != null){
                    DataRow Curr = DS.finyearview.Rows[0];
                    Curr["codefin"] = R["codefin"];
                    Curr["finance"] = R["title"];
                    Curr["paridfin"] = R["paridfin"];
                    Curr["flag"] = R["flag"];
                    Curr["nlevel"] = R["nlevel"];
                    int flag = CfgFn.GetNoNullInt32(R["flag"]);
                    object finpart = DBNull.Value;
                    if ((flag & 1) == 1){
                        finpart = "S";
                    }
                    else{
                        finpart = "E";
                    }
                    Curr["finpart" ] = finpart;

                    string filterfinlevel = QHS.AppAnd(QHS.CmpEq("ayear", Meta.Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", R["nlevel"]));
                    object leveldescr = Meta.Conn.DO_READ_VALUE("finlevel", filterfinlevel, "description");
                    Curr["leveldescr"]= leveldescr;
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
            lblRipCorrente.Text = "Presunti del " + currstr;
            lblEsPrecPrima.Text = precstr;
            lblEsPrecSeconda.Text = precstr;
            lblRipPrecedente.Text = "Presunti del " + precstr;

            lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrevisione5.Text = (++esercizioCurr).ToString();
        }

        public void MetaData_AfterActivation()
        {
            gestisciGruppoPrevisioneSecondaria();
            riempiVarDiConfronto();

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

        public void MetaData_AfterFill(){
            if (!Meta.InsertMode){
                rdbEntrata.Enabled = false;
                rdbSpesa.Enabled = false;
                btnBilancio.Enabled = false;
                txtCodiceBilancio.ReadOnly = true;
            }
        }

        private object isNull(object a, object b)
        {
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void gestisciGruppoPrevisioneSecondaria()
        {
            int finkind = CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind"));
            grpPrevSec.Visible = (finkind == 3);
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

        private void riempiVarDiConfronto()
        {
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

        private void azzeraVarDiConfronto()
        {
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

        private void btnBilancio_Click(object sender, EventArgs e){
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "";

            if (rdbSpesa.Checked)
                filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
            if (rdbEntrata.Checked)
                filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0));

            //Il filtro sull'UPB c'è sempre
            filter = QHS.CmpEq("idupb", "0001");
            filter = QHS.AppAnd(filteridfin, filter);


            //string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
            //    esercizio + "'))";

            //if (chkListTitle.Checked)
            //{
            //    FrmAskDescr FR = new FrmAskDescr(0);
            //    DialogResult D = FR.ShowDialog(this);
            //    if (D != DialogResult.OK) return;
            //    filter = GetData.MergeFilters(filter,
            //        "(title like " + QueryCreator.quotedstrvalue(
            //        "%" + FR.txtDescrizione.Text + "%", true)) + ")";
            //    filter = GetData.MergeFilters(filter, filteroperativo);
            //    MetaData.DoMainCommand(this, "choose.finview.default." + filter);
            //    return;
            //}

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            if (rdbSpesa.Checked)
                MetaData.DoMainCommand(this, "manage.fin.treealls");//treesupb: sostituito per poter selezionare anche i capitoli articolati
            if (rdbEntrata.Checked)
                MetaData.DoMainCommand(this, "manage.fin.treealle");//treeeupb



        }

        private void SvuotaFinView()
        {
            txtDenominazioneBilancio.Text = "";
            txtCodiceBilancio.Text = "";
            DS.finview.Clear();
        }
        private void txtCodiceBilancio_Leave(object sender, EventArgs e){
            if (inChiusura) return; 
            DataRow Curr = DS.finyearview.Rows[0];
            if (txtCodiceBilancio.Text.Trim() == ""){
                SvuotaFinView();
                Curr["idfin"] = 0;
                return;
            }

            string finpart = "";
            if (rdbSpesa.Checked){
                finpart = "S";
            }
            if (rdbEntrata.Checked){
                finpart = "E";
            }
            if (finpart == "") return;

            string filterUpb = "";
            filterUpb = QHS.CmpEq("idupb", "0001");

            string edittype = "treeall" + finpart.ToLower();

            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("finpart", finpart), filterUpb);
            MetaData MetaBilancio = MetaData.GetMetaData(this, "finview");
            MetaBilancio.FilterLocked = true;
            MetaBilancio.SearchEnabled = false;
            MetaBilancio.MainSelectionEnabled = true;
            MetaBilancio.StartFilter = filtro;
            MetaBilancio.ExtraParameter = filtro;
            MetaBilancio.startFieldWanted = "codefin";
            MetaBilancio.startValueWanted = null;
            MetaBilancio.edit_type = edittype;

            MetaBilancio.startValueWanted = txtCodiceBilancio.Text.Trim();
            string startfield = MetaBilancio.startFieldWanted;
            string startvalue = MetaBilancio.startValueWanted;
            DataRow rFin = null;
            if (startvalue != null){
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                rFin = MetaBilancio.SelectByCondition(filter2, "finview");
            }
            if (rFin == null){
                bool res = MetaBilancio.Edit(this, edittype, true);
                if (!res){
                    SvuotaFinView();
                    Curr["idfin"] = 0;
                    return;
                }
                rFin = MetaBilancio.LastSelectedRow;
            }
            Curr["idfin"] = rFin["idfin"];
            Curr["codefin"] = rFin["codefin"];
            Curr["finance"] = rFin["title"];
            Curr["paridfin"] = rFin["paridfin"];
            Curr["flag"] = rFin["flag"];
            Curr["nlevel"] = rFin["nlevel"];
            int flag = CfgFn.GetNoNullInt32(rFin["flag"]);
            object ES = DBNull.Value;
            if ((flag & 1) == 1){
                ES = "S";
            }
            else{
                ES = "E";
            }
            Curr["finpart"] = ES;

            string filterfinlevel = QHS.AppAnd(QHS.CmpEq("ayear", Meta.Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", rFin["nlevel"]));
            object leveldescr = Meta.Conn.DO_READ_VALUE("finlevel", filterfinlevel, "description");
            Curr["leveldescr"] = leveldescr;

            if (rFin != null){
                SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("idupb", rFin["idupb"]), QHS.CmpEq("ayear", rFin["ayear"]));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.finview, null, filter, null, false);
            }
            Meta.FreshForm(gboxBilAnnuale.Controls, true, "finview");
        }


    }
}
