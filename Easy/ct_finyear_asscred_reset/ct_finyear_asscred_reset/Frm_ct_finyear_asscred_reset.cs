
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
using metaeasylibrary;
using funzioni_configurazione;


namespace ct_finyear_asscred_reset
{
    public partial class Frm_ct_finyear_asscred_reset : MetaDataForm {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        ContextMenu ExcelMenu;
        DataAccess Conn;
        public Frm_ct_finyear_asscred_reset(){
            InitializeComponent();
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            gridDettagli.ContextMenu = ExcelMenu;
        }
        private void Excel_Click(object menusender, EventArgs e){
            if (menusender == null)
                return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))
                return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))
                return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null)
                return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))
                return;
            string DDT = G.DataMember;
            if (DDT == null)
                return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null)
                return;
            exportclass.DataTableToExcel(T, true);
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            btnAzzera.Enabled = false;
        }
        private object calcola_idsor0i(string idsor0i)
        {
            object defaultValue = DBNull.Value;

            string NtoS = idsor0i.Substring(5, 2);

            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value)
                as_filter = "N";
            object all_value = "S";

            if (as_filter.ToString().ToUpper() == "S")
            {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(all_sorkind" + NtoS + ",'S')");
                if (all_value == null || all_value == DBNull.Value)
                {
                    all_value = "S";
                }
            }

            if (all_value.ToString().ToUpper() == "S")
            {
                defaultValue = DBNull.Value;
                return defaultValue;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            defaultValue = idsor;
            return defaultValue;
        }

        DataTable Tdett_previsioni = null;
        private Dictionary<int, DataRow> lookupRows = new Dictionary<int, DataRow>();
        bool RiempiGrid(){
            object idsor01 = calcola_idsor0i("idsor01");
            object idsor02 = calcola_idsor0i("idsor02");
            object idsor03 = calcola_idsor0i("idsor03");
            object idsor04 = calcola_idsor0i("idsor04");
            object idsor05 = calcola_idsor0i("idsor05");
            object esercizio = Meta.GetSys("esercizio");


            object[] param = new object[] { esercizio, idsor01, idsor02, idsor03, idsor04, idsor05};
            DataSet DSprevisioni = Conn.CallSP("get_finyear_asscred", param, true, 300);
            if (DSprevisioni == null || DSprevisioni.Tables.Count == 0)
                return false;
            Tdett_previsioni = DSprevisioni.Tables[0];
            Tdett_previsioni.Columns["idrow"].Caption = "nRiga";
            Tdett_previsioni.Columns["codefin"].Caption = "Cod.Bilancio";
            Tdett_previsioni.Columns["fin"].Caption = "Bilancio";
            Tdett_previsioni.Columns["codeupb"].Caption = "Cod.UPB";
            Tdett_previsioni.Columns["upb"].Caption = "UPB";
            Tdett_previsioni.Columns["prevision"].Caption = "Previsione";
            Tdett_previsioni.Columns["part"].Caption = "E/S";
            Tdett_previsioni.Columns["idupb"].Caption = "InternalCodeUpb";
            Tdett_previsioni.Columns["idfin"].Caption = "InternalCodeBilancio";

            Tdett_previsioni.AcceptChanges();
            gridDettagli.DataSource = null;
            gridDettagli.TableStyles.Clear();
            //InsidePaint = true;
            HelpForm.SetDataGrid(gridDettagli, Tdett_previsioni);

            lookupRows = new Dictionary<int, DataRow>();
            foreach (DataRow r in Tdett_previsioni.Rows){
                lookupRows[CfgFn.GetNoNullInt32(r["idrow"])] = r;
            }
            DataTable Tdett_previsioniError = Tdett_previsioni.Copy();
            RimuoviDettASaldoDiversoDazero(Tdett_previsioni, Tdett_previsioniError);
            if (Tdett_previsioniError.Rows.Count > 0) {
                MostraRigheaSaldoDiversoDazero(Tdett_previsioniError);
            }
            SelezionaTutto();
            //InsidePaint = false;

            return true;
        }

        private void RimuoviDettASaldoDiversoDazero(DataTable Tdett_previsioni, DataTable Tdett_previsioniError) {
            object idupb = null;
            decimal prevision = 0;
            decimal amountVar = 0;
            DataTable T = new DataTable("t");
            T.Columns.Add("idupb", typeof(string));
            T.Columns.Add("prevision", typeof(decimal));

            foreach (DataRow R in Tdett_previsioni.Rows) {
                idupb = R["idupb"];
                prevision = CfgFn.GetNoNullDecimal(R["prevision"]);
                amountVar = 0;
                foreach (DataRow RR in Tdett_previsioniError.Select(QHC.AppAnd(QHC.CmpEq("idupb",idupb), QHC.CmpEq("prevision", prevision)))) {
                    if (RR["part"].ToString() == "S") {
                        amountVar = amountVar - CfgFn.GetNoNullDecimal(R["prevision"]);
                    }
                    else {
                        amountVar = amountVar + CfgFn.GetNoNullDecimal(R["prevision"]);
                    }
                }
                if (amountVar == 0) {
                    // Se il saldo è zero, cancella le righe dalla tabella Errore, che mostrerà dopo nel formettino
                    foreach (DataRow RR in Tdett_previsioniError.Select(QHC.AppAnd(QHC.CmpEq("idupb", idupb), QHC.CmpEq("prevision", prevision)))) {
                        RR.Delete();
                        Tdett_previsioniError.AcceptChanges();
                    }
                }
                if (amountVar != 0) {
                    //Salva le righe che danno saldo <> 0 in un DataTable
                    DataRow r = T.NewRow();
                    r["idupb"] = idupb;
                    r["prevision"] = prevision;
                    T.Rows.Add(r);
                }
            }

            foreach (DataRow R in T.Select()) {
                idupb = R["idupb"];
                prevision = CfgFn.GetNoNullDecimal(R["prevision"]);
                //Cancella dalla tabella principale, le righe con saldo <>0
                foreach (DataRow RR in Tdett_previsioni.Select(QHC.AppAnd(QHC.CmpEq("idupb", idupb), QHC.CmpEq("prevision", prevision)))) {
                    RR.Delete();
                    Tdett_previsioni.AcceptChanges();
                }
            }
        }

        private void MostraRigheaSaldoDiversoDazero(DataTable Tdett_previsioniError) {
            // Mostra le righe per le quali la variazione non sarebbe a saldo zero
            FrmError frm = new FrmError(Tdett_previsioniError);
            frm.ShowDialog();

        }
        void SelezionaTutto()
        {
            object dataSource = gridDettagli.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

            DataView view = cm.List as DataView;

            if (view != null)
            {
                for (int i = 0; i < view.Count; i++)
                {
                    gridDettagli.Select(i);
                }
            }
        }

        private DataRow[] GetGridSelectedRows(DataGrid G)
        {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++)
            {
                if (G.IsSelected(i))
                {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++)
            {
                if (G.IsSelected(i))
                {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        DataRow GetGridRow(DataGrid G, int index)
        {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            return lookupRows[CfgFn.GetNoNullInt32(G[index, 0])];

        }

        //bool InsidePaint = false;

        private void btnAzzera_Click(object sender, EventArgs e){
            SelezionaTutto();
            DataRow[] Mov_SelectedRows = GetGridSelectedRows(gridDettagli);
            if ((Mov_SelectedRows == null) || (Mov_SelectedRows.Length == 0))
            {
                show("Non è stato selezionato alcun movimento da annullare.");
                return;
            }
            Azzera(Mov_SelectedRows);
        }
        private void btnMostraPrevisioni_Click(object sender, EventArgs e){
            btnMostraPrevisioni.Visible = false;
            btnAzzera.Enabled = true;
            RiempiGrid();

        }
        private void ElaboraMovimento(DataRow R, DataRow rFinVar, MetaData FinVardetail, DataTable dtFinVardetail){
            MetaData.SetDefault(DS.finvardetail, "yvar", rFinVar["yvar"]);
            MetaData.SetDefault(DS.finvardetail, "nvar", rFinVar["nvar"]);
            //Aggiunge i dettagli variazione
            DataRow rVarDetail = FinVardetail.Get_New_Row(rFinVar, dtFinVardetail);
            rVarDetail["amount"] = -CfgFn.GetNoNullDecimal(R["prevision"]);
            rVarDetail["description"] = " Azzeramento previsione iniziale per le Entrate finalizzate ";
            rVarDetail["idfin"] = R["idfin"];
            rVarDetail["idupb"] = R["idupb"];
            rVarDetail["createexpense"] = "N";

        }
        private object Calc_nOfficial () {
            // I selettori del campo NOFFICIAL sono YVAR e OFFICIAL
            int yvar = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.CmpEq("yvar", yvar), QHS.CmpEq("official", 'S'));
            object nOff = Conn.DO_READ_VALUE("finvar", filter, "MAX(nofficial)");
            if (nOff == null) return 1;

            int nOfficial = 1 + CfgFn.GetNoNullInt32(nOff);

            return nOfficial;
        }
        private object Read_finvarkind() {
            string filter = QHS.CmpEq("codevarkind", 1);//Diminuzione della previsione iniziale
            object idfinvarkind = Conn.DO_READ_VALUE("finvarkind", filter, "idfinvarkind");
            if (idfinvarkind == null) return null;

            return idfinvarkind;
        }
        private void Azzera(DataRow[] MovimentiSelezionati){
            //Crea la variazione
            MetaData FinVar = MetaData.GetMetaData(this, "finvar");
            DataTable dtFinVar = DS.finvar;
            FinVar.SetDefaults(DS.finvar);
            // Nuova riga in finvar
            DataRow rFinVar = FinVar.Get_New_Row(null, dtFinVar);
            int nvar = CfgFn.GetNoNullInt32(rFinVar["nvar"]);
            rFinVar["yvar"] = Meta.GetSys("esercizio");
            rFinVar["description"] = "Azzeramento previsione iniziale per le Entrate finalizzate";
            rFinVar["adate"] = new DateTime(Convert.ToInt32(Meta.GetSys("esercizio")), 1, 1);
            rFinVar["idfinvarstatus"] = "5"; //Stato Approvata
            rFinVar["variationkind"] = "3";//Tipo Assestamento
            rFinVar["flagprevision"] = "S";
            rFinVar["flagsecondaryprev"] = "N";
            rFinVar["flagcredit"] = "N";
            rFinVar["flagproceeds"] = "N";
            rFinVar["official"] = "S";
            rFinVar["nofficial"] = Calc_nOfficial();
            rFinVar["enactment"] = "Azzeramento previsione iniziale per le Entrate finalizzate";
            rFinVar["enactmentdate"] = new DateTime(Convert.ToInt32(Meta.GetSys("esercizio")), 1, 1);
            rFinVar["moneytransfer"] = "N";
            rFinVar["varflag"] = 0;
            rFinVar["idfinvarkind"] = Read_finvarkind();//Diminuzione della previsione iniziale

            //Crea i dettagli variazione
            MetaData FinVardetail = MetaData.GetMetaData(this, "finvardetail");
            DataTable dtFinVardetail = DS.finvardetail;
            for (int i = 0; i < MovimentiSelezionati.Length; i++){
                DataRow Ri = MovimentiSelezionati[i];
                ElaboraMovimento(Ri, rFinVar, FinVardetail, dtFinVardetail);
            }
            //Effettua il post
            PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res){

                string mess = "Operazione Eseguita con successo.";
                show(mess);
                btnAzzera.Visible = false;
                btnAnnulla.Text = "Chiudi";
            }
            else{
                DS.finvar.Clear();
                DS.finvardetail.Clear();
                return;
            }
        }
    }
}
