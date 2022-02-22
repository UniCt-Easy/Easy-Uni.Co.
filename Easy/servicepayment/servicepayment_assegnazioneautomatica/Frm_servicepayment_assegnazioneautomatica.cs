
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
using System.Linq;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;
using System.Collections;
using ap_functions;

namespace servicepayment_assegnazioneautomatica
{
    public partial class Frm_servicepayment_assegnazioneautomatica : MetaDataForm
    {
        public Frm_servicepayment_assegnazioneautomatica()
        {
            InitializeComponent();
        }
        MetaData Meta;
        DataAccess Conn;
        int esercizio;
        DataTable prestazioni1 = new DataTable("prestazioni1");
        DataTable prestazioni2 = new DataTable("prestazioni2");

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        public void MetaData_AfterClear() { 
           this.Text = "Assegnazione Automatica del Pagamento";
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        Dictionary<string, string> tipiIncaricato = new Dictionary<string, string> { { "D", "Dipendente" }, { "C", "Consulente" }, { "A", "Dipendente altri enti" } };
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            
            prestazioni1.Columns.Add("ncon");
            prestazioni1.Columns.Add("ycon");
            prestazioni1.Columns.Add("amount",typeof(decimal));
            prestazioni1.Columns.Add("amount_servicepayment", typeof(decimal));
            prestazioni1.Columns.Add("semesterpay",typeof(Int32));
            prestazioni1.Columns.Add("yservreg");
            prestazioni1.Columns.Add("nservreg");
            prestazioni1.Columns.Add("expectedamount", typeof(decimal));
            prestazioni1.Columns.Add("employkind");
            prestazioni1.Columns.Add("ypay", typeof(Int32));
            prestazioni1.Columns.Add("total_servicepayment", typeof(decimal));
            DS.Tables.Add(prestazioni1);
            foreach (DataColumn C in prestazioni1.Columns){
                C.Caption = "";
            }
            prestazioni1.Columns["ncon"].Caption = "Num. Contratto";
            prestazioni1.Columns["ycon"].Caption = "Eserc. Contratto";
            prestazioni1.Columns["amount"].Caption = "Importo pagato";
            prestazioni1.Columns["amount_servicepayment"].Caption = "Importo in anagrafe";
            prestazioni1.Columns["semesterpay"].Caption = "Semestre";
            prestazioni1.Columns["yservreg"].Caption = "Eserc. Incarico";
            prestazioni1.Columns["nservreg"].Caption = "Num. Incarico";
            prestazioni1.Columns["expectedamount"].Caption = "Importo Incarico";
            prestazioni1.Columns["employkind"].Caption = "Tipo";
            prestazioni1.Columns["total_servicepayment"].Caption = "Totale in anagrafe";

            prestazioni2.Columns.Add("ncon");
            prestazioni2.Columns.Add("ycon");
            prestazioni2.Columns.Add("amount", typeof(decimal));
            prestazioni2.Columns.Add("amount_servicepayment", typeof(decimal));
            prestazioni2.Columns.Add("semesterpay", typeof(Int32));
            prestazioni2.Columns.Add("yservreg");
            prestazioni2.Columns.Add("nservreg");
            prestazioni2.Columns.Add("expectedamount", typeof(decimal));
            prestazioni2.Columns.Add("employkind");
            prestazioni2.Columns.Add("ypay", typeof(Int32));
            prestazioni2.Columns.Add("total_servicepayment", typeof(decimal));
            DS.Tables.Add(prestazioni2);
            foreach (DataColumn C in prestazioni2.Columns){
                C.Caption = "";
            }
            prestazioni2.Columns["ncon"].Caption = "Num. Contratto";
            prestazioni2.Columns["ycon"].Caption = "Eserc. Contratto";
            prestazioni2.Columns["amount"].Caption = "Importo pagato";
            prestazioni2.Columns["amount_servicepayment"].Caption = "Importo in anagrafe";
            prestazioni2.Columns["semesterpay"].Caption = "Semestre";
            prestazioni2.Columns["yservreg"].Caption = "Eserc. Incarico";
            prestazioni2.Columns["nservreg"].Caption = "Num. Incarico";
            prestazioni2.Columns["expectedamount"].Caption = "Importo Incarico";
            prestazioni2.Columns["employkind"].Caption = "Tipo";
            prestazioni2.Columns["total_servicepayment"].Caption = "Totale in anagrafe";

            prestazioni1.setTemporaryTable(false);
            prestazioni2.setTemporaryTable(false);
        }

        static string ComposeObjects(object[] o)
        {
            if (o == null) return null;
            if (o.Length == 0) return null;
            string res = "";
            foreach (object oo in o)
            {
                if (res != "") res += "§";
                res += oo.ToString();
            }
            return res;
        }
        public static string GetIdForDocument(DataRow R,string table)
        {
            if (R == null) return null;
            DataRowVersion toConsider = DataRowVersion.Current;
            if (R.RowState == DataRowState.Deleted) toConsider = DataRowVersion.Original;
            //string table = R.Table.TableName.ToLower();
            switch (table)
            {
                case "profservice":
                    return ComposeObjects(
                    new object[]{	"profservice",
										R["ycon", toConsider],
										R["ncon", toConsider]
									});
                case "casualcontract":
                    return ComposeObjects(
                        new object[]{	"cascon",
										R["ycon", toConsider],
										R["ncon", toConsider]
									});
                case "wageaddition":
                    return ComposeObjects(
                        new object[] { "wageadd",
										 R["ycon", toConsider],
										 R["ncon", toConsider]
									 });
                case "itineration":
                    return ComposeObjects(
                        new object[] { "itineration",
										 R["ycon", toConsider],
										 R["ncon", toConsider]
									 });
                case "parasubcontract":
                    	return ComposeObjects(
                new object[] { "parasubcontract",
								 R["idcon", toConsider]
							 });
            }
            return null;
        }

        void AddRowToTable(DataRow R, DataTable T){
            DataRow NewR = T.NewRow();
            foreach (DataColumn C in R.Table.Columns)
            {
                if (T.Columns[C.ColumnName] != null)
                    NewR[C.ColumnName] = R[C.ColumnName];
            }
            T.Rows.Add(NewR);
        }

        string getPaymentsVar() {
            return getPayments() +
            "  JOIN expensevar V  ON V.idexp = EL.idexp ";
        }

        /// <summary>
        /// Join tra C.idexp sino a Payment P
        /// </summary>
        /// <returns></returns>
        string getPayments() {
            return
               "   JOIN expenselink ELK ON ELK.idparent = C.idexp " +
                "   JOIN expenselast EL       ON EL.idexp=ELK.idchild " +
                "   JOIN expense E            ON EL.idexp=E.idexp " +
                "   JOIN expenseyear EY       ON EL.idexp=EY.idexp " +
                "   JOIN payment P           ON P.kpay = EL.kpay ";

        }

        Dictionary<string, decimal> totalePagato = new Dictionary<string, decimal>();

        //Da chiamare dopo che si invoca un bottone di "esegui" o uno di calcola prestazioni
        void AbilitaDisabilitaBottoni() {
          
        }
        bool eseguitoPrimoSemestre = false;
        bool eseguitoSecondoSemestre = false;

        void azzeraDataSet() {
            DS.serviceregistry.Clear();
            DS.servicepayment.Clear();
            prestazioni1.Clear();
            prestazioni2.Clear();
            totalePagato.Clear();
            eseguitoPrimoSemestre = false;
            eseguitoSecondoSemestre = false;
        }
        string keyRegistryService(DataRow rPagamento) {
            return rPagamento["yservreg"] + "#" + rPagamento["nservreg"];
        }
        decimal totalePagatoPrestazione (object yservreg,object nservreg) {
            string k = yservreg + "#" + nservreg;
            if (totalePagato.ContainsKey(k)) return totalePagato[k];
            return 0;
        }

        void  impostaPagamento(object yservreg, object nservreg, decimal amount) {
            string k = yservreg + "#" + nservreg;
            if (totalePagato.ContainsKey(k)) {             
                totalePagato[k] = amount;
            }
            else {
                totalePagato.Add(k, amount);
            }
        }

        bool importoVariato(object yservreg, object nservreg) {
	        string k = yservreg + "#" + nservreg;
	        return totalePagato.ContainsKey(k);
        }

        decimal aggiungiPagamento(object yservreg, object nservreg,decimal amount) {
            string k = yservreg + "#" + nservreg;
            if (totalePagato.ContainsKey(k)) {
                decimal oldPagato = totalePagato[k];
                decimal pagato = oldPagato+ amount;
                totalePagato[k] = pagato;
                return pagato;
            }
            else {
                totalePagato.Add(k, amount);
                return amount;
            }            
        }
        /// <summary>
        /// Legge il primo ed il secondo semestre dell'occasionale
        /// </summary>
        void FillPrestazioneOccasionale() {
            azzeraDataSet();

            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            String MyQuery1 =
            " SELECT casualcontract.ncon, casualcontract.ycon, " +
                    "casualcontract.idsor01,casualcontract.idsor02,casualcontract.idsor03," +
                    "casualcontract.idsor04,casualcontract.idsor05,casualcontract.idupb,casualcontract.idreg,casualcontract.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expensecasualcontract C  " +
                 getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '1' AND '6' ) AND ( year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= casualcontract.ncon AND C.ycon=casualcontract.ycon),0)  " +
                " + " +
                "ISNULL((SELECT SUM(V.amount)  " +
                "   FROM expensecasualcontract C  " +
                getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '1' AND '6' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = casualcontract.ycon and C.ncon= casualcontract.ncon ),0) " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationcasualcontract PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.ycon = casualcontract.ycon AND PC.ncon = casualcontract.ncon AND ( month(P.adate) BETWEEN '1' AND '6' )),0) " +
                " ) as amount," +
                " 1 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'cascon§' + convert(varchar(10), casualcontract.ycon) + '§' + convert(varchar(10), casualcontract.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount, serviceregistry.employkind, " +
                getPayments(esercizio, 1) +
                " FROM casualcontract " +
                " JOIN casualcontractyear" +
                " ON casualcontractyear.ycon = casualcontract.ycon   AND casualcontractyear.ncon = casualcontract.ncon " +
                " AND casualcontractyear.ayear = " + QHS.quote(esercizio) +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'cascon§' + convert(varchar(10), casualcontract.ycon) + '§' + convert(varchar(10), casualcontract.ncon) " +
                //" left outer join servicepayment  on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
                //considera le anag. prestazioni non bloccate   da trasferire (mi pare sia un errore)
                //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
                " WHERE  (serviceregistry.is_blocked= 'N') ";
            //Considera i pagamenti la cui somma non costituisce il saldo... altro errore
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount )  )" +
            //" group by casualcontract.ncon, casualcontract.ycon,   " +
            //" casualcontract.idsor01,casualcontract.idsor02,casualcontract.idsor03,casualcontract.idsor04,casualcontract.idsor05,   " +
            //" casualcontract.idupb,casualcontract.idreg,casualcontract.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount   ";


            String MyQuery2 =
            " SELECT casualcontract.ncon, casualcontract.ycon, " +
                    "casualcontract.idsor01,casualcontract.idsor02,casualcontract.idsor03," +
                  "casualcontract.idsor04,casualcontract.idsor05,casualcontract.idupb,casualcontract.idreg,casualcontract.idser," +

                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expensecasualcontract C  " +
                getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '7' AND '12' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= casualcontract.ncon AND C.ycon=casualcontract.ycon),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount) " +
                "   FROM expensecasualcontract C  " +
                getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '7' AND '12' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = casualcontract.ycon and C.ncon= casualcontract.ncon ),0) " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationcasualcontract PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.ycon = casualcontract.ycon AND PC.ncon = casualcontract.ncon AND ( month(P.adate) BETWEEN '7' AND '12' )),0) " +
                " ) as amount," +
                " 2 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'cascon§' + convert(varchar(10), casualcontract.ycon) + '§' + convert(varchar(10), casualcontract.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,   serviceregistry.employkind," +
                getPayments(esercizio, 2) +
                " FROM casualcontract " +
                " JOIN casualcontractyear  ON casualcontractyear.ycon = casualcontract.ycon  AND casualcontractyear.ncon = casualcontract.ncon " +
                " AND casualcontractyear.ayear = " + QHS.quote(esercizio) +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'cascon§' + convert(varchar(10), casualcontract.ycon) + '§' + convert(varchar(10), casualcontract.ncon) " +
                   //" left outer join servicepayment " +
                   //" on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
                   //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
                   " WHERE  (serviceregistry.is_blocked= 'N') ";
            // " AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //"    where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by casualcontract.ncon, casualcontract.ycon,   " +
            //" casualcontract.idsor01,casualcontract.idsor02,casualcontract.idsor03,casualcontract.idsor04,casualcontract.idsor05,   " +
            //" casualcontract.idupb,casualcontract.idreg,casualcontract.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount   ";

          

            DataTable casualcontract_1 = Meta.Conn.SQLRunner(MyQuery1);
            DataAccess.SetTableForReading(casualcontract_1, "casualcontractview");
            Conn.DeleteAllUnselectable(casualcontract_1);
            
            DataTable casualcontract_2 = Meta.Conn.SQLRunner(MyQuery2);
            DataAccess.SetTableForReading(casualcontract_2, "casualcontractview");
            Conn.DeleteAllUnselectable(casualcontract_2);

            acquisiciPagamenti(casualcontract_1, casualcontract_2);
            abilitaDisabilitaBottoni();
            setGrids();
             
        }

        void setGrids() {
            if (dgrprestazioni1.DataSource == null) {
                HelpForm.SetDataGrid(dgrprestazioni1, prestazioni1);
                new formatgrids(dgrprestazioni1).AutosizeColumnWidth();
            }
            if (dgrprestazioni2.DataSource == null) {
                HelpForm.SetDataGrid(dgrprestazioni2, prestazioni2);
                new formatgrids(dgrprestazioni2).AutosizeColumnWidth();
            }
        }

        void abilitaDisabilitaBottoni() {
            bool righePresenti = prestazioni1.Rows.Count > 0 || prestazioni2.Rows.Count > 0;      
            //Se non ci sono righe presenti, i bottoni delle prestazioni sono abilitati
            //Se si è eseguito qualcosa, i bottoni sono disabilitati
            //Tuttavia quando si esegue qualcosa, la corrispondente tabella prestazioni è azzerata per cui dopo che si esegue tutto
            // automaticamente nella prima condizione, e cliccando sulla prestazione si azzereranno anche i flag sull'esecuzione dei semestri
            btnMissione.Enabled = !(eseguitoPrimoSemestre || eseguitoSecondoSemestre || righePresenti);
            btnoccasionale.Enabled = !(eseguitoPrimoSemestre || eseguitoSecondoSemestre || righePresenti);
            btndipendente.Enabled = !(eseguitoPrimoSemestre || eseguitoSecondoSemestre || righePresenti);
            btnProfessionale.Enabled = !(eseguitoPrimoSemestre || eseguitoSecondoSemestre || righePresenti);
            btnparasubordinati.Enabled = !(eseguitoPrimoSemestre || eseguitoSecondoSemestre || righePresenti);
            btnEsegui1.Enabled = prestazioni1.Rows.Count > 0 && ! eseguitoPrimoSemestre;
            btnEsegui2.Enabled = prestazioni2.Rows.Count > 0 && ! eseguitoSecondoSemestre;           
        }

        void acquisiciPagamenti(DataTable semestre1, DataTable semestre2) {
            Dictionary<string, bool> prestazioniLette = new Dictionary<string, bool>();
            foreach (DataRow rPagamento in semestre1.Select(QHC.CmpGt("amount", 0))) {
                //amount è l'importo pagato nei movimenti finanziari, amount_servicepayment l'importo inserito come pagamento nelle anag. prestaz.
                //se sono uguali non inserisce nuovi pagamenti
                decimal pagatoInSemestre = CfgFn.GetNoNullDecimal(rPagamento["amount"]);
                decimal anagrafatoSemestre = CfgFn.GetNoNullDecimal(rPagamento["amount_servicepayment"]);
                decimal totaleAnagrafato = CfgFn.GetNoNullDecimal(rPagamento["total_servicepayment"]); 
                if (pagatoInSemestre == anagrafatoSemestre) continue;
                AddRowToTable(rPagamento, prestazioni1);
                //DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.serviceregistry, null,QHS.MCmp(Rcasualcontrat, "yservreg", "nservreg"), null, true);
                //DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.servicepayment, null,QHS.AppAnd(QHS.MCmp(Rcasualcontrat, "yservreg", "nservreg"),QHS.CmpEq("semesterpay","1")) , null, true);
                if (rPagamento["amount_servicepayment"] != DBNull.Value) {//è importante distinguere il null dallo zero, non usare la variabile
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.servicepayment, null, QHS.MCmp(rPagamento, "yservreg", "nservreg", "ypay"), null, true);
                    prestazioniLette[keyRegistryService(rPagamento)] = true;                    
                }
                impostaPagamento(rPagamento["yservreg"], rPagamento["nservreg"], totaleAnagrafato);//non include il pagamento da anagrafare ancora
            }


            foreach (DataRow rPagamento in semestre2.Select(QHC.CmpGt("amount", 0))) {
                decimal pagatoInSemestre = CfgFn.GetNoNullDecimal(rPagamento["amount"]);
                decimal anagrafatoSemestre = CfgFn.GetNoNullDecimal(rPagamento["amount_servicepayment"]);
                decimal totaleAnagrafato = CfgFn.GetNoNullDecimal(rPagamento["total_servicepayment"]);
                if (pagatoInSemestre == anagrafatoSemestre) continue;
                AddRowToTable(rPagamento, prestazioni2);                
                if (prestazioniLette.ContainsKey(keyRegistryService(rPagamento))) continue;
                //DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.serviceregistry, null, QHS.MCmp(Rcasualcontrat, "yservreg", "nservreg"), null, true);
                //DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.servicepayment, null, QHS.AppAnd(QHS.MCmp(Rcasualcontrat, "yservreg", "nservreg"), QHS.CmpEq("semesterpay", "2")), null, true);
                if (rPagamento["amount_servicepayment"] != DBNull.Value) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.servicepayment, null, QHS.MCmp(rPagamento, "yservreg", "nservreg", "ypay", "semesterpay"), null, true);                    
                }
                impostaPagamento(rPagamento["yservreg"], rPagamento["nservreg"], totaleAnagrafato);//non include il pagamento da anagrafare ancora
            }
            prestazioni1.AcceptChanges();
            prestazioni2.AcceptChanges();
        }

        /// <summary>
        /// Legge i pagamenti del semestre in amount_servicepayment e quelli complessivi pluriennali in total_servicepayment
        /// </summary>
        /// <param name="anno"></param>
        /// <param name="semestre"></param>
        /// <returns></returns>
        string getPayments(int anno, int semestre) {
            return " (select sum(P1.payedamount) from servicepayment P1  where P1.yservreg = serviceregistry.yservreg and P1.nservreg = serviceregistry.nservreg " +
                  " and P1.ypay=" + QHS.quote(anno) + " and P1.semesterpay=" + QHS.quote(semestre) + ")  as amount_servicepayment, " +
                   "(select sum(P1.payedamount) from servicepayment P1  where P1.yservreg = serviceregistry.yservreg and P1.nservreg = serviceregistry.nservreg) " +
                    " as total_servicepayment ";
        }

        /// <summary>
        /// Legge il primo ed il secondo semestre delle prest. dipendente
        /// </summary>
        void FillPrestazioneDipendente(){
            azzeraDataSet();


            String MyQuery1 =
                " SELECT wageaddition.ncon, wageaddition.ycon, " +
                        "wageaddition.idsor01, wageaddition.idsor02, wageaddition.idsor03," +
                    "wageaddition.idsor04, wageaddition.idsor05, wageaddition.idupb, wageaddition.idreg, wageaddition.idser," +
                " ( ISNULL( (SELECT SUM(EY.amount) " +
                "   FROM expensewageaddition C  " +
               getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '1' AND '6' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= wageaddition.ncon AND C.ycon=wageaddition.ycon) ,0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expensewageaddition C  " +
               getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '1' AND '6' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = wageaddition.ycon and C.ncon= wageaddition.ncon ),0) " +
                " ) as amount," +
               " 1 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'wageadd§' + convert(varchar(10), wageaddition.ycon) + '§' + convert(varchar(10), wageaddition.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,  serviceregistry.employkind, " +
                getPayments(esercizio,1) +
                " FROM wageaddition " +
                " JOIN wageadditionyear" +
                " ON wageadditionyear.ycon = wageaddition.ycon " +
                " AND wageadditionyear.ncon = wageaddition.ncon " +
                " AND  wageadditionyear.ayear = " + QHS.quote(esercizio) +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'wageadd§' + convert(varchar(10), wageaddition.ycon) + '§' + convert(varchar(10), wageaddition.ncon) " +
                " WHERE  (serviceregistry.is_blocked= 'N') ";
            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by wageaddition.ncon, wageaddition.ycon,   " +
            //" wageaddition.idsor01, wageaddition.idsor02, wageaddition.idsor03, wageaddition.idsor04, wageaddition.idsor05,   " +
            //" wageaddition.idupb, wageaddition.idreg, wageaddition.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg, serviceregistry.expectedamount   ";

            String MyQuery2 =
                " SELECT wageaddition.ncon, wageaddition.ycon, " +
                   "wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03," +
                    "wageaddition.idsor04,wageaddition.idsor05,wageaddition.idupb,wageaddition.idreg,wageaddition.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expensewageaddition C  " +
               getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '7' AND '12' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= wageaddition.ncon AND C.ycon=wageaddition.ycon),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expensewageaddition C  " +
                getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '7' AND '12' ) 	AND ( year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = wageaddition.ycon and C.ncon= wageaddition.ncon ) ,0)" +
                " ) as amount," +
               " 2 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'wageadd§' + convert(varchar(10), wageaddition.ycon) + '§' + convert(varchar(10), wageaddition.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,  serviceregistry.employkind, " +
                getPayments(esercizio, 2) +
                " FROM wageaddition " +
                " JOIN wageadditionyear" +
                " ON wageadditionyear.ycon = wageaddition.ycon " +
                " AND wageadditionyear.ncon = wageaddition.ncon " +
                " AND  wageadditionyear.ayear = " + QHS.quote(esercizio)+
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'wageadd§' + convert(varchar(10), wageaddition.ycon) + '§' + convert(varchar(10), wageaddition.ncon) " +
                " WHERE  (serviceregistry.is_blocked= 'N') ";
            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by wageaddition.ncon, wageaddition.ycon,   " +
            //" wageaddition.idsor01, wageaddition.idsor02, wageaddition.idsor03, wageaddition.idsor04, wageaddition.idsor05,   " +
            //" wageaddition.idupb, wageaddition.idreg, wageaddition.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg, serviceregistry.expectedamount   ";


            DataTable wageaddition_1 = Meta.Conn.SQLRunner(MyQuery1);
            DataAccess.SetTableForReading(wageaddition_1, "wageadditionview");
            Conn.DeleteAllUnselectable(wageaddition_1);            

            DataTable wageaddition_2 = Meta.Conn.SQLRunner(MyQuery2);
            DataAccess.SetTableForReading(wageaddition_2, "wageadditionview");
            Conn.DeleteAllUnselectable(wageaddition_2);

            acquisiciPagamenti(wageaddition_1, wageaddition_2);
            abilitaDisabilitaBottoni();
            setGrids();
        }


        /// <summary>
        /// Legge il primo ed il secondo semestre delle missioni
        /// </summary>
        void FillMissione() {
            azzeraDataSet();

            String MyQuery1 =
            " SELECT itineration.yitineration as ycon, itineration.nitineration as ncon, " +
                " itineration.idsor01,itineration.idsor02,itineration.idsor03," +
                " itineration.idsor04,itineration.idsor05,itineration.idupb,itineration.idreg,itineration.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expenseitineration C  " +
                  getPayments() +

                "   WHERE ( month(P.adate) BETWEEN '1' AND '6' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.iditineration= itineration.iditineration ),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expenseitineration C  " +
                getPaymentsVar() +

                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '1' AND '6' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.iditineration= itineration.iditineration ),0)  " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationitineration PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.iditineration = itineration.iditineration  AND ( month(P.adate) BETWEEN '1' AND '6' )),0) " +
                " ) as amount," +
               " 1 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'itineration§' + convert(varchar(10), itineration.yitineration) + '§' + convert(varchar(10), itineration.nitineration) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,  serviceregistry.employkind, " +
                getPayments(esercizio,1)+
                " FROM itineration " +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'itineration§' + convert(varchar(10), itineration.yitineration) + '§' + convert(varchar(10), itineration.nitineration) " +
                " left outer join servicepayment " +
                "   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
                     " WHERE  (serviceregistry.is_blocked= 'N') ";
                //" WHERE itineration.yitineration = " + QHS.quote(esercizio) +
            //" and ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by itineration.nitineration, itineration.yitineration,   " +
            //" itineration.idsor01,itineration.idsor02,itineration.idsor03,itineration.idsor04,itineration.idsor05,   " +
            //" itineration.idupb,itineration.idreg,itineration.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount, itineration.iditineration   ";

            String MyQuery2 =
            " SELECT itineration.yitineration as ycon, itineration.nitineration as ncon, " +
                " itineration.idsor01,itineration.idsor02,itineration.idsor03," +
                " itineration.idsor04,itineration.idsor05 ,itineration.idupb, itineration.idreg, itineration.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expenseitineration C  " +
                getPayments() +

                "   WHERE ( month(P.adate) BETWEEN '7' AND '12' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.iditineration= itineration.iditineration ),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expenseitineration C  " +
                getPaymentsVar() +

                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '7' AND '12' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.iditineration= itineration.iditineration ),0)  " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationitineration PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.iditineration = itineration.iditineration AND ( month(P.adate) BETWEEN '7' AND '12' )),0) " +
                " ) as amount," +
               " 2 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'itineration§' + convert(varchar(10), itineration.yitineration) + '§' + convert(varchar(10), itineration.nitineration) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,  serviceregistry.employkind, " +
                getPayments(esercizio,2) +
                " FROM itineration " +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'itineration§' + convert(varchar(10), itineration.yitineration) + '§' + convert(varchar(10), itineration.nitineration) " +
                //" left outer join servicepayment " +
                //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
                " WHERE (serviceregistry.is_blocked= 'N') ";
            //" WHERE itineration.yitineration = " + QHS.quote(esercizio) +
            //" and ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" GROUP BY itineration.nitineration, itineration.yitineration,   " +
            //" itineration.idsor01,itineration.idsor02,itineration.idsor03,itineration.idsor04,itineration.idsor05,   " +
            //" itineration.idupb,itineration.idreg,itineration.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount, itineration.iditineration   ";




            DataTable itineration_1 = Meta.Conn.SQLRunner(MyQuery1);
            DataAccess.SetTableForReading(itineration_1, "itineration");
            Conn.DeleteAllUnselectable(itineration_1);
           
            DataTable itineration_2 = Meta.Conn.SQLRunner(MyQuery2);
            DataAccess.SetTableForReading(itineration_2, "itineration");
            Conn.DeleteAllUnselectable(itineration_2);

            acquisiciPagamenti(itineration_1, itineration_2);
            abilitaDisabilitaBottoni();
            setGrids();
        }

        /// <summary>
        /// Legge il primo ed il secondo semestre delle parcelle
        /// </summary>
        void FillProfessionale() {
            azzeraDataSet();

            String MyQuery1 =
            " SELECT profservice.ncon, profservice.ycon, " +
             "profservice.idsor01,profservice.idsor02, profservice.idsor03," +
            "profservice.idsor04, profservice.idsor05, profservice.idupb, profservice.idreg, profservice.idser, profservice.idinvkind," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expenseprofservice C  " +
              getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '1' AND '6' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= profservice.ncon AND C.ycon=profservice.ycon),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expenseprofservice C  " +
               getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '1' AND '6' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = profservice.ycon and C.ncon= profservice.ncon ),0) " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationprofservice PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.ycon = profservice.ycon AND PC.ncon = profservice.ncon AND ( month(P.adate) BETWEEN '1' AND '6' )),0) " +
                " ) as amount," +
              " 1 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'profservice§' + convert(varchar(10), profservice.ycon) + '§' + convert(varchar(10), profservice.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount , serviceregistry.employkind, " +
                getPayments(esercizio,1)+                
                " FROM profservice " +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'profservice§' + convert(varchar(10), profservice.ycon) + '§' + convert(varchar(10), profservice.ncon) " +
                   " WHERE  (serviceregistry.is_blocked= 'N') ";
            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE profservice.ycon = " + QHS.quote(esercizio)  + 
            //" and ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by profservice.ncon, profservice.ycon,   " +
            //" profservice.idsor01, profservice.idsor02, profservice.idsor03, profservice.idsor04, profservice.idsor05,   " +
            //" profservice.idupb, profservice.idreg, profservice.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg, serviceregistry.expectedamount, profservice.idinvkind   ";


            String MyQuery2 =
            " SELECT profservice.ncon, profservice.ycon, " +
               "profservice.idsor01,profservice.idsor02,profservice.idsor03," +
            "profservice.idsor04,profservice.idsor05,profservice.idupb,profservice.idreg,profservice.idser,profservice.idinvkind," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expenseprofservice C  " +
                getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '7' AND '12' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ncon= profservice.ncon AND C.ycon=profservice.ycon),0)  " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount)  " +
                "   FROM expenseprofservice C  " +
                getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '7' AND '12' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND C.ycon = profservice.ycon and C.ncon= profservice.ncon ),0) " +
                " + " +
                "ISNULL((SELECT SUM(P.amount)" +
                "   FROM pettycashoperationprofservice PC" +
                "   JOIN pettycashoperation P " +
                "       ON PC.idpettycash = P.idpettycash " +
                "       AND PC.yoperation = P.yoperation " +
                "       AND PC.noperation = P.noperation " +
                "   WHERE PC.ycon = profservice.ycon AND PC.ncon = profservice.ncon AND ( month(P.adate) BETWEEN '7' AND '12' )),0) " +
                " ) as amount," +
                " 2 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'profservice§' + convert(varchar(10), profservice.ycon) + '§' + convert(varchar(10), profservice.ncon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount ,  serviceregistry.employkind," +
                getPayments(esercizio,2)+
                " FROM profservice " +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'profservice§' + convert(varchar(10), profservice.ycon) + '§' + convert(varchar(10), profservice.ncon) " +
                 " WHERE  (serviceregistry.is_blocked= 'N') ";

            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE profservice.ycon = " + QHS.quote(esercizio) +
            //" and ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by profservice.ncon, profservice.ycon,   " +
            //" profservice.idsor01, profservice.idsor02, profservice.idsor03, profservice.idsor04, profservice.idsor05,   " +
            //" profservice.idupb, profservice.idreg, profservice.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg, serviceregistry.expectedamount, profservice.idinvkind   ";

            DataTable profservice_1 = Meta.Conn.SQLRunner(MyQuery1);
            DataAccess.SetTableForReading(profservice_1, "profserviceview");
            Conn.DeleteAllUnselectable(profservice_1);

            DataTable profservice_2 = Meta.Conn.SQLRunner(MyQuery2);
            DataAccess.SetTableForReading(profservice_2, "profserviceview");
            Conn.DeleteAllUnselectable(profservice_2);

            acquisiciPagamenti(profservice_1, profservice_2);
            abilitaDisabilitaBottoni();
            setGrids();
        }

        void FillParasubordinati() {
            azzeraDataSet();


            prestazioni1.Columns.Add("idcon");
            prestazioni2.Columns.Add("idcon");
            String MyQuery1 =               
                " SELECT parasubcontract.ncon, parasubcontract.ycon, parasubcontract.idcon, "+
                 "parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03," +
                    "parasubcontract.idsor04,parasubcontract.idsor05,parasubcontract.idupb,parasubcontract.idreg,parasubcontract.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expensepayroll C "+ 
	            "   JOIN payroll Y  ON C.idpayroll = Y.idpayroll "+
                getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '1' AND '6' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND Y.idcon= parasubcontract.idcon),0)   "+ 
                " + "+                
                "ISNULL((SELECT  SUM(V.amount)   "+ 
                "   FROM expensepayroll C "+ 
                "   JOIN payroll Y "+
                "       ON C.idpayroll = Y.idpayroll " +
               getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '1' AND '6' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND Y.idcon = parasubcontract.idcon ),0)  " + 
                "       ) as amount, "+
               " 1 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'parasubcontract§' + convert(varchar(10), parasubcontract.idcon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,  serviceregistry.employkind, " +
                getPayments(esercizio,1)+
                "   FROM parasubcontract  " + 
                "   JOIN parasubcontractyear "+ 
                "       ON parasubcontractyear.idcon = parasubcontract.idcon  "+
                "       AND parasubcontractyear.ayear = " + QHS.quote(esercizio) +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'parasubcontract§' + convert(varchar(10), parasubcontract.idcon) " +
                   " WHERE  (serviceregistry.is_blocked= 'N') ";
            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by parasubcontract.ncon, parasubcontract.ycon, parasubcontract.idcon,  " +
            //" parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05,   " +
            //" parasubcontract.idupb, parasubcontract.idreg, parasubcontract.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount   ";

            String MyQuery2 =
                " SELECT parasubcontract.ncon, parasubcontract.ycon, parasubcontract.idcon, " +
                  "parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03," +
                    "parasubcontract.idsor04,parasubcontract.idsor05,parasubcontract.idupb,parasubcontract.idreg,parasubcontract.idser," +
                " (ISNULL((SELECT SUM(EY.amount) " +
                "   FROM expensepayroll C " +
                "   JOIN payroll Y " +
                "       ON C.idpayroll = Y.idpayroll " +
                getPayments() +
                "   WHERE ( month(P.adate) BETWEEN '7' AND '12' ) AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND Y.idcon= parasubcontract.idcon),0)   " +
                " + " +
                "ISNULL((SELECT  SUM(V.amount) " +
                "   FROM expensepayroll C " +
                "   JOIN payroll Y " +
                "       ON C.idpayroll = Y.idpayroll " +
                getPaymentsVar() +
                "   WHERE (ISNULL(v.autokind,0)<> 4)" +
                "       AND ( month(P.adate) BETWEEN '7' AND '12' ) 	AND (year(P.adate)= " + QHS.quote(esercizio) + ")" +
                "       AND Y.idcon = parasubcontract.idcon ),0)  " +
                "       ) as amount, " +
                " 2 as semesterpay, " + QHS.quote(esercizio) + " as ypay, " +
                " 'parasubcontract§' + convert(varchar(10), parasubcontract.idcon) as idrelated, " +
                " serviceregistry.yservreg,  " +
                " serviceregistry.nservreg,  " +
                " serviceregistry.expectedamount,   serviceregistry.employkind," +
                getPayments(esercizio,2)+
                "   FROM parasubcontract  " +
                "   JOIN parasubcontractyear " +
                "       ON parasubcontractyear.idcon = parasubcontract.idcon  " +
                "       AND parasubcontractyear.ayear = " + QHS.quote(esercizio) +
                " join serviceregistry " +
                "     on serviceregistry.idrelated = 'parasubcontract§' + convert(varchar(10), parasubcontract.idcon) " +
                 " WHERE  (serviceregistry.is_blocked= 'N') ";


            //" left outer join servicepayment " +
            //"   on servicepayment.yservreg = serviceregistry.yservreg and servicepayment.nservreg = serviceregistry.nservreg " +
            //" WHERE  ((serviceregistry.is_delivered='N' and serviceregistry.is_blocked= 'N') or (serviceregistry.is_delivered='S' and serviceregistry.is_blocked='N' and serviceregistry.is_changed='S')) " +
            //" AND (servicepayment.yservreg is null or((select sum(P2.payedamount) from servicepayment P2     " +
            //" where P2.yservreg = serviceregistry.yservreg and P2.nservreg = serviceregistry.nservreg) <> serviceregistry.expectedamount)  )" +
            //" group by parasubcontract.ncon, parasubcontract.ycon, parasubcontract.idcon,  " +
            //" parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05,   " +
            //" parasubcontract.idupb, parasubcontract.idreg, parasubcontract.idser, serviceregistry.yservreg,    " +
            //" serviceregistry.nservreg,serviceregistry.expectedamount   ";

            DataTable parasubcontract_1 = Meta.Conn.SQLRunner(MyQuery1);
            DataAccess.SetTableForReading(parasubcontract_1, "parasubcontractview");
            Conn.DeleteAllUnselectable(parasubcontract_1);
           

            DataTable parasubcontract_2 = Meta.Conn.SQLRunner(MyQuery2);
            DataAccess.SetTableForReading(parasubcontract_2, "parasubcontractview");
            Conn.DeleteAllUnselectable(parasubcontract_2);


            acquisiciPagamenti(parasubcontract_1, parasubcontract_2);
            abilitaDisabilitaBottoni();
           

            prestazioni1.Columns.Remove("idcon");
            prestazioni2.Columns.Remove("idcon");

            setGrids();
            
        }
        private void btnoccasionale_Click(object sender, EventArgs e){
            FillPrestazioneOccasionale();
            abilitaDisabilitaBottoni();
        }


        private void btndipendente_Click(object sender, EventArgs e) {
            FillPrestazioneDipendente();
            abilitaDisabilitaBottoni();
        }

        private void btnEsegui1_Click(object sender, EventArgs e){
            //Aggiorna pagamenti relativi al primo semestre
            eseguitoPrimoSemestre= AggiornaPagamenti(prestazioni1);
            abilitaDisabilitaBottoni();
        }

        private void btnEsegui2_Click(object sender, EventArgs e){
            //Aggiorna pagamenti relativi al secondo semestre
            eseguitoSecondoSemestre= AggiornaPagamenti(prestazioni2);
            abilitaDisabilitaBottoni();
        }

        ///// <summary>
        ///// Nel caso di dipendenti verifica che nessun semestre sia bloccato, non solo quello in corso. 
        ///// La verifica è fatta in base ai dati in memoria
        ///// </summary>
        ///// <param name="pagamentoPrestazione"></param>
        ///// <returns></returns>
        //bool verificaAggiornabilita(DataRow pagamentoPrestazione) { 
        //    if (pagamentoPrestazione["amount_servicepayment"] != DBNull.Value) return true;
        //    string filter;
        //    if (pagamentoPrestazione["employkind"].ToString().ToUpper() == "C") {
        //        //Consulente: il semestre non deve essere bloccato
        //        filter = QHC.MCmp(pagamentoPrestazione, "yservreg", "nservreg", "ypay","semesterpay");
        //    }
        //    else {
        //        //Dipendente: nulla deve essere bloccato
        //        filter = QHC.MCmp(pagamentoPrestazione, "yservreg", "nservreg", "ypay");
        //    }
        //    filter = QHC.AppAnd(filter, QHS.CmpEq("is_blocked", "S"));            
        //    if (DS.servicepayment.Select(filter).Length > 0) {
        //        string contratto = contratto = "n." + QueryCreator.quotedstrvalue(pagamentoPrestazione["nservreg"], true) + " / " 
        //                + QueryCreator.quotedstrvalue(pagamentoPrestazione["yservreg"], true) + " semestre "+pagamentoPrestazione["semesterpay"];
        //        show("Il pagamento del contratto " + contratto + " NON sarà aggiornato perchè il pagamento è bloccato ");
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// Crea o aggiorna le righe di servicepayment relative al semestre considerato
        /// aggiorna anche il totale anagrafato nel dictionary. Assume che i pagamenti sul db siano già stati letti
        /// </summary>
        /// <param name="pagamentiSemestre"></param>
        void aggiornaPagamento(DataRow pagamentiSemestre) {
            DataRow CurrPag;
            MetaData MetaDet = Meta.Dispatcher.Get("servicepayment");
            MetaDet.SetDefaults(DS.servicepayment);
            decimal payedamount = CfgFn.GetNoNullDecimal(pagamentiSemestre["amount"]);	//effettivo pagato
            if (pagamentiSemestre["amount_servicepayment"] == DBNull.Value) {
                foreach (string field in new string []{ "yservreg", "nservreg", "ypay","semesterpay" }) {
                    MetaData.SetDefault(DS.servicepayment, field, pagamentiSemestre[field]);
                }                                
                CurrPag = MetaDet.Get_New_Row(null, DS.servicepayment);
                CurrPag["payedamount"] = payedamount;
                //CurrPag["is_changed"] = "S";
                aggiungiPagamento(pagamentiSemestre["yservreg"], pagamentiSemestre["nservreg"], payedamount);
                pagamentiSemestre["amount_servicepayment"] = payedamount;
                pagamentiSemestre.AcceptChanges();
            }
            else {
                string filter = QHC.MCmp(pagamentiSemestre, "yservreg", "nservreg", "ypay", "semesterpay");
                CurrPag = DS.servicepayment.First(filter);
                if (CurrPag != null) {
	                decimal oldPagamento = CfgFn.GetNoNullDecimal(CurrPag["payedamount"]);
                    if (payedamount != oldPagamento) {
	                    CurrPag["payedamount"] = payedamount;
	                    //CurrPag["is_changed"] = "S";
	                    //if (payedamount != oldPagamento) {
		                    aggiungiPagamento(pagamentiSemestre["yservreg"], pagamentiSemestre["nservreg"], payedamount - oldPagamento);
		                    pagamentiSemestre["amount_servicepayment"] = payedamount;
		                    pagamentiSemestre.AcceptChanges();
	                    //}
                    }
                }                
            }

        }


        bool AggiornaPagamenti(DataTable pagamenti){
            MetaData MetaDet = Meta.Dispatcher.Get("servicepayment");
           
            foreach (DataRow R in pagamenti.Rows)   {
                decimal curr_amount = CfgFn.GetNoNullDecimal(R["amount"]);
                decimal anagrafato = CfgFn.GetNoNullDecimal(R["amount_servicepayment"]);
                //if (!verificaAggiornabilita(R)) continue;  il filtro sugli aggiornabili è effettuato a priori
                aggiornaPagamento(R);                            
            }            

            valorizzaCampiPrestazione(pagamenti);
                        
            PostData Post = MetaDet.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res) {
                show("Operazione eseguita con successo.","Avviso");
                pagamenti.Clear();
                //Il Dataset non è azzerato, è possibile ancora aggiungere i pagamenti di un altro semestre (in qualsiasi ordine)
            }
            else {
                show("Ci sono stati problemi nell'aggiornamento dei pagamenti.","Errore");
            }
            return res;   
        }
        /// <summary>
        /// Imposta il flag payment='S' ove la somma dei pagamenti sia pari al pagamento atteso
        /// </summary>
        void valorizzaCampiPrestazione(DataTable pagamenti) {          
            foreach (DataRow R in pagamenti.Select()) {
	            if (!importoVariato(R["yservreg"], R["nservreg"])) continue;
	            var sr = DS.serviceregistry.get(Conn, q.mCmp(R, "yservreg", "nservreg")).FirstOrDefault();
	            sr["is_changed"] = "S";

	            decimal nuovo_totale_anagrafato = totalePagatoPrestazione(R["yservreg"], R["nservreg"]);//aggiornato anche con i pagamenti in atto
                decimal importoatteso = CfgFn.GetNoNullDecimal(R["expectedamount"]);
                if (nuovo_totale_anagrafato != importoatteso) continue;
                sr["payment"] = "S";
                                                   
            }
        }
        //void ValorizzaIncaricoSaldato() {
        //    string keyfilter = "";
        //    decimal amount=0;
        //    foreach (DataRow R in DS.serviceregistry.Select()){
        //        keyfilter = QHS.AppOr(keyfilter, QHS.CmpKey(R));
        //        amount = CfgFn.GetNoNullDecimal(R["expectedamount"]);
        //        foreach (DataRow P in DS.servicepayment.Select(keyfilter)) {
        //            amount = amount - CfgFn.GetNoNullDecimal(P["payedamount"]);
        //        }
        //        if (amount == 0) {
        //            R["payment"] = "S";
        //        }
        //        keyfilter = "";
        //    }
        //}

     

        private void btnsalva_Click(object sender, EventArgs e) {
        }

        private void btnMissione_Click(object sender, EventArgs e){
            FillMissione();
            abilitaDisabilitaBottoni();

        }

        private void btnProfessionale_Click(object sender, EventArgs e){
            FillProfessionale();
            abilitaDisabilitaBottoni();
        }

        private void btnparasubordinati_Click(object sender, EventArgs e)
        {
            FillParasubordinati();
            abilitaDisabilitaBottoni();


        }
 
    }
}
