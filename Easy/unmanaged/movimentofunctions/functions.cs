/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;
using System.Diagnostics;
using gestioneclassificazioni;
using manage_automatismi;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using q = metadatalibrary.MetaExpression;

namespace movimentofunctions {
	


	public class GestioneAutomatismi {
		//MetaData Meta;
		int fasemax;
		int fasefine;
		Form ParentForm;
        //DataTable PersSpesa;
        //DataTable PersEntrata;
        DataTable Config;
        DataTable Movimento;
		DataRow Pers;  //ExpenseSetupRow o IncomeSetupRow
		DataSet sourceDataSet;
		DataAccess Conn;
		MetaDataDispatcher Disp;
		bool viewMainMov;
		AutomatismiGenerati dsAuto = new AutomatismiGenerati();
        CQueryHelper QHC;
        QueryHelper QHS;

		public DataSet DSP{
			get {
				return dsAuto;
			}
		}

		string idmovimento;
        public bool GestioneFondoEconomale = false;
        
        public AutoTablesCache Cache;

        Dictionary<int, DataRow> ModPagam = new Dictionary<int, DataRow>();

        DataRow GetModPagamDefault(object codicecreddeb) {
            int idreg = CfgFn.GetNoNullInt32(codicecreddeb);

            if (ModPagam.ContainsKey(idreg)) return ModPagam[idreg];

            DataRow r = CfgFn.ModalitaPagamentoDefault(Conn, codicecreddeb);
            if (r == null) return null;
            ModPagam[idreg] = r;
            return r;
        }

        DataTable TrattamentoBollo;
        DataTable Cassiere;
		/// <summary>
		/// Costruttore della Classe GestioneAutomatismi
		/// </summary>
		/// <param name="ParentForm">Form Chiamante</param>
		/// <param name="Conn">Connessione Corrente</param>
		/// <param name="Disp">Dispatcher Corrente</param>
		/// <param name="sourceDS">DataSet Principale</param>
		/// <param name="fasefine">Cod. Fase massima tra i movimenti finanziari correnti</param>
		/// <param name="fasemax">Cod. Fase massima assoluta dei movimenti finanziari</param>
		/// <param name="tableMain">Tabella Principale</param>
		/// <param name="viewMainMov">Flag che visualizza i movimenti principali nel form di gestione degli automatismi
		/// (TRUE: Visualizza; FALSE: Non Visualizza)</param>
		public GestioneAutomatismi(Form ParentForm, 
			DataAccess Conn, MetaDataDispatcher Disp, DataSet sourceDS, int fasefine, int fasemax,
			string tableMain, bool viewMainMov) {
		    this.dsAuto.EnforceConstraints = false;
			this.ParentForm= ParentForm;
			this.fasefine= fasefine;
			this.fasemax= fasemax;
			this.Conn = Conn;
			this.Disp = Disp;
			this.sourceDataSet = sourceDS;
			this.viewMainMov = viewMainMov;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Cache = new AutoTablesCache(Conn);
            string filterCass = Conn.SelectCondition("treasurer", true);
		    filterCass = QHS.AppAnd(filterCass, QHS.NullOrEq("active", "S"));
            Cassiere = Conn.RUN_SELECT("treasurer", "*", null, filterCass, null, true);
            TrattamentoBollo = Conn.RUN_SELECT("stamphandling", "*", null, QHS.CmpEq("flagdefault", "S"), null, true);

			ClearDataSet.RemoveConstraints(dsAuto);
//			SetExpressions();

			copiaDatiDaDatasetPrincipaleASecondario(sourceDS);

			if (tableMain=="expense"){
				Movimento = dsAuto.Tables["expense"];
				idmovimento="idexp";
			}
			if (tableMain=="income") {
				Movimento = dsAuto.Tables["income"];
				idmovimento="idinc";
			}
            Pers = dsAuto.Tables["config"].Rows[0];

            maxfasebil = Conn.DO_READ_VALUE("finlevel",              
                    QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                    "max(nlevel)");
		}

        object maxfasebil;


		public DataRow GetLastPhaseRow() {
            string filterlast = QHC.CmpEq("nphase", fasemax);
			DataRow []Found = Movimento.Select(filterlast);
			if (Found.Length==0) return null;
			return Found[0];
		}

		public DataRow GetLastImpPhaseRow(DataRow rMov) {
			if (rMov == null) return null;
			string tImp = (rMov.Table.TableName == "expense") ? "expenseyear" : "incomeyear";
			string filterlast  = QueryCreator.WHERE_KEY_CLAUSE(rMov, DataRowVersion.Current, false);

			DataRow []Found = dsAuto.Tables[tImp].Select(filterlast);
			if (Found.Length == 0) return null;
			return Found[0];
		}

        public DataRow GetLastMovPhaseRow(DataRow rMov) {
            if (rMov == null) return null;
            string tImp = (rMov.Table.TableName == "expense") ? "expenselast" : "incomelast";
            string filterlast = QueryCreator.WHERE_KEY_CLAUSE(rMov, DataRowVersion.Current, false);

            DataRow[] Found = dsAuto.Tables[tImp].Select(filterlast);
            if (Found.Length == 0) return null;
            return Found[0];
        }

		/// <summary>
		/// Unisce ToMerge alla tabella Automatismi, per tutte le colonne comuni. 
		/// </summary>
		/// <param name="Automatismi"></param>
		/// <param name="ToMerge"></param>
		/// <param name="tipoautomatismo"></param>
		void MergeAutomatismi(DataTable Automatismi, 
			DataTable ToMerge, 
			byte tipoautomatismo){
			foreach(DataRow R in ToMerge.Rows){
				DataRow newR = Automatismi.NewRow();
				foreach(DataColumn C in ToMerge.Columns){
					if (!Automatismi.Columns.Contains(C.ColumnName))continue;
					newR[C.ColumnName]= R[C.ColumnName];
				}
				if (ToMerge.Columns["autokind"]==null)
					newR["autokind"]= tipoautomatismo;
				else 
					newR["autokind"]= R["autokind"];
//				newR["autokind"]= tipoautomatismo;
				Automatismi.Rows.Add(newR);
			}
		}

        public const int FLAG_FULLFILLED = 1;
        public const int TIPOAUTOMATISMO_RITENUTA = 2;
        public const int TIPOAUTOMATISMO_RECUPERO = 4;
        public const int IDAUTOKIND_RITENUTA = 4;
        public const int IDAUTOKIND_RECUPERO = 6;
        public const int IDAUTOKIND_CHIUSURA = 7;
        public const int IDAUTOKIND_CONTRIBUTO = 8;

        private int calcolaAdminTaxKind() {
            int automanagekind = CfgFn.GetNoNullInt32(Pers["automanagekind"]);
            int atk = automanagekind & 0x0F;
            switch (atk) {
                case 1: {
                        return 0;
                    }
                case 2: {
                        return 1;
                    }
                case 4: {
                        return 2;
                    }
                case 8: {
                        return 3;
                    }
            }
            return 0;
        }

        private int calcolaClawBackKind() {
            int automanagekind = CfgFn.GetNoNullInt32(Pers["automanagekind"]);
            int cbk = automanagekind & 0xF0;

            if (cbk != 0) return 1;
            return 0;
        }

        private int calcolaEmployTaxKind() {
            int automanagekind = CfgFn.GetNoNullInt32(Pers["automanagekind"]);
            int atk = automanagekind & 0xF00;
            switch (atk) {
                case 256: {
                        return 0;
                    }
                case 512: {
                        return  1;
                    }
                case 1024: {
                        return 2;
                    }
            }
            return 0;
        }

        struct UnderwritingPartition {
            public object idunderwriting;
            public decimal amount;
            public UnderwritingPartition(object idunderwriting, decimal amount) {
                this.idunderwriting = idunderwriting;
                this.amount = amount;
            }
        }

        /// <summary>
        /// Di un contributo determina il finanziamento crediti o cassa corrispondenti nel movimento principale
        /// </summary>
        /// <param name="rExp"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        UnderwritingPartition[] GetPartition(DataAccess Conn, DataRow rExp,  decimal amount) {
            int nphaseappropriation = getIntSys("expensefinphase");
            int nphasepayment = getIntSys("maxexpensephase");
            int nphase = CfgFn.GetNoNullInt32(rExp["nphase"]);
            if (nphase != nphaseappropriation && nphase != nphasepayment) return new UnderwritingPartition[] { };

            object idpayment = rExp["idpayment"];
            DataSet Auto = rExp.Table.DataSet;
            DataTable Expense = rExp.Table;

            DataRow MainMov = getRowPhase(Auto.Tables["expense"],idpayment,nphase,Conn);
            string filterc = QHC.CmpEq("idexp",MainMov["idexp"]);
            string filtersql = QHS.CmpEq("idexp", MainMov["idexp"]);
            string tabletoconsider = (nphase == nphaseappropriation) ? "underwritingappropriation" : "underwritingpayment";
            DataRow[] found = new DataRow[]{};
            if (Expense.Select(filterc).Length == 0) {
                DataTable T = Conn.RUN_SELECT(tabletoconsider, "*", null, filtersql, null, false);
                if (T.Rows.Count != 0) found = T.Select();
            }
            else {
                found = Auto.Tables[tabletoconsider].Select(filterc);
            }
            int N = found.Length;
            if (N==0) return new UnderwritingPartition[] { };
            UnderwritingPartition[] result = new UnderwritingPartition[N];

            decimal amount_to_assign = amount;
            int i = 0;
            while (i < N) {
                decimal curramount = CfgFn.GetNoNullDecimal(found[i]["amount"]);
                decimal sum_from_i = curramount;
                for (int j = i+1; j < N; j++) sum_from_i += CfgFn.GetNoNullDecimal(found[j]["amount"]);

                decimal evaluated = CfgFn.RoundValuta( (amount_to_assign * curramount) / sum_from_i );

                result[i] = new UnderwritingPartition(found[i]["idunderwriting"], evaluated);
                amount_to_assign -= evaluated;
            }

            return result;
        }


	


        /// <summary>
        /// Agisce sul DataSet di posting (DSP), pone il risultato in Auto
        /// Visualizza il form per collegare gli automatismi solo se visualizzaForm and OneMainRow.
        /// Le righe sono aggiunte a tAuto, corredate di codefin,codeupb,registry,manager (ove colonne presenti in tAuto)
        /// </summary>
        /// <param name="tAuto"></param>
        /// <param name="CurrMov"></param>
        /// <param name="visualizzaForm"></param>
        /// <param name="OneMainRow"></param>
        /// <returns></returns>
		bool RicalcolaAutomatismi(DataTable tAuto, DataRow CurrMov, DataRow CurrImpMov, DataRow CurrLastMov,
                bool visualizzaForm, bool OneMainRow){

//			DataRow CurrMov = GetLastPhaseRow();
			//DataRow CurrImpMov = GetLastImpPhaseRow(CurrMov);
   //         DataRow CurrLastMov = GetLastMovPhaseRow(CurrMov);

			if (CurrMov==null) return true;
			if (Movimento == null) return true;
            if (CurrLastMov == null) return true;
			if (Movimento.TableName=="expense"){

                int admintaxkind = calcolaAdminTaxKind();
                int employtaxkind = calcolaEmployTaxKind();
                int clawbackkind = calcolaClawBackKind();

                //string filter = "(nphase = '" + Conn.GetSys("maxexpensephase")    + "') and (autokind IS NULL)";
				if ((dsAuto.Tables["expensetax"].Select(
                    "(isnull(admintax,0)<>0 or isnull(employtax,0)<>0)").Length>0)&&
					((admintaxkind!=0)||(employtaxkind!=0))
					){
                    int flag = CfgFn.GetNoNullInt32(CurrLastMov["flag"]);
                    if ((flag & TIPOAUTOMATISMO_RITENUTA) == 0) {
						GestioneMovimentiAutomatici ga = new GestioneMovimentiAutomatici(Conn, dsAuto,Cache);
                        DataTable Out = ga.calcolaAutomatismi(CurrMov, CurrImpMov, CurrLastMov); //Out contiene già codefin,codeupb,registry,manager
						if ((Out!=null)&&(Out.Rows.Count>0)) {
                            flag += TIPOAUTOMATISMO_RITENUTA;
                            CurrLastMov["flag"] = flag;
							if (!Out.Columns.Contains("livsupid")) {
								Out.Columns.Add("livsupid", typeof(int));
							}

                            //Aggiunge i finanziamenti (senza riempire underwriting.title o simili)
                            GeneraAppropriationProceedsUnderwriting(Conn, dsAuto);
        

							//int nMov = dsAuto.Tables["expense"].Select(filter).Length;
							if ((visualizzaForm) && OneMainRow) {
								Form Frm = ShowAutomatismi.Show(Disp,
									Out.Select(), 
									CurrMov, "Automatismi Ritenute");
                                if(Frm.ShowDialog(ParentForm) == DialogResult.OK)
                                    MergeAutomatismi(tAuto, Out, IDAUTOKIND_RITENUTA);
                                else {
                                    return false;
                                }
							}
							else {
                                MergeAutomatismi(tAuto, Out, IDAUTOKIND_RITENUTA);
							}
						}
					}
				}

				if ((dsAuto.Tables["expenseclawback"].Select("amount<>0").Length>0) &&
					(clawbackkind!=0)
					){
                    int flag = CfgFn.GetNoNullInt32(CurrLastMov["flag"]);
                    if ((flag & TIPOAUTOMATISMO_RECUPERO) == 0) {
						GestioneMovimentiAutomatici ga = new GestioneMovimentiAutomatici(Conn, dsAuto,Cache);
						DataTable Out = ga.calcolaAutoRecuperi(CurrMov, CurrImpMov);
						if ((Out!=null)&&(Out.Rows.Count>0)) {
                            flag+= TIPOAUTOMATISMO_RECUPERO;
                            CurrLastMov["flag"] = flag;
							if (!Out.Columns.Contains("livsupid")) {
								Out.Columns.Add("livsupid", typeof(int));
							}

							//int nMov = dsAuto.Tables["expense"].Select(filter).Length;
							if ((visualizzaForm) && OneMainRow) {
								Form Frm = ShowAutomatismi.Show(
									Disp, Out.Select(), 
									CurrMov, "Automatismi Recuperi");
                                if(Frm.ShowDialog(ParentForm) == DialogResult.OK)
                                    MergeAutomatismi(tAuto, Out, IDAUTOKIND_RECUPERO);
                                else {
                                    return false;
                                }
							}
							else {
								MergeAutomatismi(tAuto, Out, IDAUTOKIND_RECUPERO);
							}
						}
					}
				}

			}
			else {  //Movimento = "Entrata"

			}
            return true;
		}


        void GeneraAppropriationProceedsUnderwriting(DataAccess Conn, DataSet Auto) {
            MetaData MetaUnderwritingAppropriation = Disp.Get("underwritingappropriation");
            DataTable UAppropriation = Auto.Tables["underwritingappropriation"];
            MetaUnderwritingAppropriation.SetDefaults(UAppropriation);

            MetaData MetaUnderwritingPayment = Disp.Get("underwritingpayment");
            DataTable UPayment = Auto.Tables["underwritingpayment"];
            MetaUnderwritingPayment.SetDefaults(UPayment);

            int nphaseappropriation = getIntSys("expensefinphase");
            int nphasepayment = getIntSys("maxexpensephase");


            string filter_T = QHC.AppAnd(QHC.CmpEq("autokind", IDAUTOKIND_CONTRIBUTO),
                                        QHC.CmpEq("nphase", nphasepayment));

            if (Auto.Tables["expense"] != null) {
                DataTable T = Auto.Tables["expense"];
                foreach (DataRow R in T.Select(filter_T)) {
                    //R è l'ultima fase di spesa dell'automatismo 
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_CONTRIBUTO) continue;                    

                    DataRow Rexpenseyear = Auto.Tables["expenseyear"].Select(QHC.CmpEq("idexp", R["idexp"]))[0];
                    decimal amount = CfgFn.GetNoNullDecimal( Rexpenseyear["amount"]);


                    //Prende la fase di impegno dell'automatismo
                    DataRow RAppropriation = getRowPhase(T, R["idexp"], nphaseappropriation, Conn);
                    UnderwritingPartition[] PApp = GetPartition(Conn, RAppropriation, amount);
                    foreach (UnderwritingPartition UPapp in PApp) {
                        DataRow NewUA = MetaUnderwritingAppropriation.Get_New_Row(R, UAppropriation);
                        NewUA["idunderwriting"] = UPapp.idunderwriting;
                        NewUA["amount"] = UPapp.amount;
                    }


                    //Prende la fase di pagamento dell'automatismo
                    DataRow RPayment = R;
                    UnderwritingPartition[] PPay = GetPartition(Conn, RPayment, amount);
                    foreach (UnderwritingPartition UPpay in PPay) {
                        DataRow NewUP = MetaUnderwritingPayment.Get_New_Row(R, UPayment);
                        NewUP["idunderwriting"] = UPpay.idunderwriting;
                        NewUP["amount"] = UPpay.amount;
                    }

                
                }
            }
        }

		/// <summary>
		/// Riempie i dati di una riga di entata o spesa prendendoli dall'automatismo e dall'
		///  IDmovimento in ingresso
		/// </summary>
		/// <param name="E_S"></param>
		/// <param name="Auto"></param>
		/// <param name="CurrSpesa"></param>
		void FillMovimento(DataRow E_S, DataRow Auto){ //, string idmovimento)
			int esercizio= Convert.ToInt32(Conn.GetSys("esercizio"));
			DateTime DataCont= Convert.ToDateTime(Conn.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"]= esercizio;
			//E_S["ycreation"]= esercizio;
			//E_S["adate"]= DataCont;
			string [] fields_to_copy=new string[] { 
													  "idman","idreg","description","autokind","autocode","doc","docdate"};
			foreach(string field in fields_to_copy) {
				if (E_S.Table.Columns.Contains(field))E_S[field]= Auto[field];
			}
			
			E_S.EndEdit();
		}


		void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto){
			string [] fields_to_copy=new string[] { 
													  "idfin","idupb","codefin","codeupb"};
			foreach(string field in fields_to_copy) {
				if (ImpMov.Table.Columns.Contains(field)) {
					ImpMov[field]= Auto[field];
				}
			}
			ImpMov["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
		}


		bool GeneraRigheVarMovimento(DataTable MainMov, DataTable VarMovimento, DataRow []Auto, 
			string idfieldname, int currIDmov){
			MetaData MetaVM = Disp.Get(VarMovimento.TableName);
			MetaVM.SetDefaults(VarMovimento);

            DateTime Adate = (DateTime)Conn.GetSys("datacontabile");
            DataRow[] Main = MainMov.Select(QHC.CmpEq("idexp", currIDmov));
            if (Main.Length == 1) {
                if (Main[0]["adate"] != DBNull.Value) Adate = (DateTime)Main[0]["adate"];
            }
            MetaData.SetDefault(VarMovimento, "adate", Adate);


			foreach(DataRow R in Auto){
                object currid = currIDmov;
				while (currid!=DBNull.Value){

                    //Vede se è una riga in DS
                    DataTable T = Movimento;
				    string filter = QHC.CmpEq( idfieldname, currid); //idfieldname + "=" + QueryCreator.quotedstrvalue(currid, false);
                    if (Movimento.Select(filter).Length == 0) {
                        T = Conn.RUN_SELECT(Movimento.TableName,"*", null, QHC.CmpEq( "parent" + idfieldname, currid), null, true);
                    }
                    DataRow[] MainRows = T.Select(filter);
                    if (MainRows.Length == 0) {
                        MessageBox.Show("Errore, riga non trovata in GeneraRigheVarMovimento");
                        return false;
                    }
                    DataRow MainRow = MainRows[0];
                    
					VarMovimento.Columns[idfieldname].DefaultValue= currid;

					DataRow newVarMovimento= MetaVM.Get_New_Row(null, VarMovimento);
					//newVarMovimento[idfieldname]= 
					newVarMovimento["yvar"]= Conn.GetSys("esercizio");
					//newVarMovimento["adate"]= Conn.GetSys("datacontabile");
					newVarMovimento["description"]= R["description"];
					newVarMovimento["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
					if (VarMovimento.Columns.Contains("autokind")){
						newVarMovimento["autokind"]= R["autokind"];			
					}
					if (VarMovimento.Columns.Contains("autocode")){
						newVarMovimento["autocode"]= R["autocode"];
					}
					if (VarMovimento.Columns.Contains("idpayment")){
                        newVarMovimento["idpayment"] = currIDmov;
					}
                    currid = MainRow["parent" + idfieldname];
				}

			}
			return true;
		}

        /// <summary>
        /// In base al contenuto di Auto.automatismitable genera movimenti di spesa e di entrata nel dataset  Auto
        /// NON mostra interfacce visuali
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="CurrIDMov"></param>
        /// <returns></returns>
		bool GeneraNuoveRighe(AutomatismiGenerati Auto, int CurrIDMov){
			string filtroMov = "(movkind = 'Spesa')";
			DataRow [] AutoSpesa = Auto.automatismitable.Select(filtroMov);
			if (!GeneraRigheMovimento(Auto.expense, Auto.expense, Auto.expenseyear, Auto.expenselast, AutoSpesa, "idexp", CurrIDMov))return false;

			filtroMov = "(movkind = 'Entrata')";
			DataRow [] AutoEntrata = Auto.automatismitable.Select(filtroMov);
            if (!GeneraRigheMovimento(Auto.expense, Auto.income, Auto.incomeyear, Auto.incomelast, AutoEntrata, "idinc", CurrIDMov)) return false;

			DataRow [] AutoVarSpesa = Auto.automatismitable.Select("(movkind='Variazione spesa')");
            if (!GeneraRigheVarMovimento(Auto.expense, Auto.expensevar, AutoVarSpesa, "idexp", CurrIDMov)) return false;
			
			DataRow [] AutoVarEntrata = Auto.automatismitable.Select("(movkind='Variazione entrata')");
            if (!GeneraRigheVarMovimento(Auto.expense,  Auto.incomevar, AutoVarEntrata, "idinc", CurrIDMov)) return false;
			
			return true;
		}

		//public bool GeneraNuoveRigheBulk(AutomatismiGenerati Auto, string CurrIDMov){
		public bool GeneraNuoveRigheBulk(DataSet ds, DataTable Auto, int CurrIDMov){
			ClearDataSet.RemoveConstraints(ds);
			string filtroMov = "(movkind = 'Spesa')";
			DataRow [] AutoSpesa = Auto.Select(filtroMov);
            if (!GeneraRigheMovimento(ds.Tables["expense"], ds.Tables["expense"], ds.Tables["expenseyear"], ds.Tables["expenselast"], AutoSpesa, "idexp", CurrIDMov)) return false;

			filtroMov = "(movkind = 'Entrata')";
			DataRow [] AutoEntrata = Auto.Select(filtroMov);
			if (!GeneraRigheMovimento(ds.Tables["expense"],ds.Tables["income"], ds.Tables["incomeyear"], ds.Tables["incomelast"], AutoEntrata,"idinc",CurrIDMov))return false;

			DataRow [] AutoVarSpesa = Auto.Select("(movkind='Variazione spesa')");
			if (!GeneraRigheVarMovimento(ds.Tables["expense"],ds.Tables["expensevar"], AutoVarSpesa, "idexp", CurrIDMov))return false;
			
			DataRow [] AutoVarEntrata = Auto.Select("(movkind='Variazione entrata')");
			if (!GeneraRigheVarMovimento(ds.Tables["expense"],ds.Tables["incomevar"], AutoVarEntrata, "idinc", CurrIDMov))return false;
			
			return true;
		}
		/// <summary>
		/// Imposta alcune colonne di dsAuto expense,income,etc. come "calcolate", per evitare che
		///  postdata cerchi di salvarle, ed al contempo indicare a postdata come compilare
		///  i messaggi business con i loro valori.
		/// </summary>
		/// <param name="Auto"></param>
//		void SetExpressions(){
//			QueryCreator.SetExpression(dsAuto.income.Columns["phase"],"incomephase.description");
//			QueryCreator.SetExpression(dsAuto.expense.Columns["phase"],"expensephase.description");
//			QueryCreator.SetExpression(dsAuto.incomeyear.Columns["codefin"],"fin.codefin");
//			QueryCreator.SetExpression(dsAuto.incomeyear.Columns["codeupb"],"upb.codeupb");
//			QueryCreator.SetExpression(dsAuto.expenseyear.Columns["codefin"],"fin.codefin");
//			QueryCreator.SetExpression(dsAuto.expenseyear.Columns["codeupb"],"upb.codeupb");
//		}

        private int getIntSys(string nome) {
            object O = Conn.GetSys(nome);
            if (O == null) return 99;
            return Convert.ToInt32(O);
        }
		
		/// <summary>
		/// Genera righe di spesa/imputazione spesa oppure di entrata/imputazione entrata a
		///  partire da una lista di automatismi. Le righe sono create in modo da rispettare
		///  la struttura parent/child tra i diversi livelli di uno stesso movimento e tra i
		///  movimenti e l'imputazione dei movimenti (es. spesa / imputazionespesa)
		/// </summary>
		/// <param name="Mov">Tabella in cui generare i movimenti: Entrata o Spesa</param>
		/// <param name="ImpMov">Tabella ImputazioneEntrata o ImputazioneSpesa</param>
		/// <param name="Auto">Lista Automatismi da considerare</param>
		/// <param name="idfield_name">campo chiave per Movimento e ImpMovimento (idspesa o identrata)</param>
		/// <param name="currIDmov">ID del movimento corrente (ossia del form principale)</param>
		/// </param>
		bool GeneraRigheMovimento(DataTable MainMov, DataTable Mov, DataTable ImpMov, DataTable LastMov,
			DataRow []Auto, string idfield_name, int currIDmov){
			MetaData MetaM  = Disp.Get(Mov.TableName); 
			MetaM.SetDefaults(Mov);
			MetaData MetaIM = Disp.Get(ImpMov.TableName);
			MetaIM.SetDefaults(ImpMov);
            MetaData MetaL = Disp.Get(LastMov.TableName);
            MetaL.SetDefaults(LastMov);
			int esercizio= CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
			int fasespesamax = getIntSys("maxexpensephase");
			int faseCreditoreDebitoreSpesa = getIntSys("expenseregphase");
			int faseBilancioSpesa = getIntSys("expensefinphase");
			int faseentratamax = getIntSys("maxincomephase");
			int faseCreditoreDebitoreEntrata = getIntSys("incomeregphase");
			int faseBilancioEntrata = getIntSys("incomefinphase");

            DateTime Adate = (DateTime) Conn.GetSys("datacontabile");
            DataRow[] Main = MainMov.Select(QHC.CmpEq("idexp", currIDmov));
            if (Main.Length == 1) {
                if (Main[0]["adate"] != DBNull.Value) Adate = (DateTime)Main[0]["adate"];
            }
            MetaData.SetDefault(Mov, "adate", Adate);
            

			foreach(DataRow R in Auto) {
				//DataRow ParentR= FindParentRow(Mov, R, idfield_name);
				DataRow ParentR = null;
				
				if (Mov.TableName == "expense") {

					for(int faseCorrente = 1; faseCorrente <= fasespesamax; faseCorrente++) {
						Mov.Columns["nphase"].DefaultValue= faseCorrente;

						DataRow NewSpesaRow = MetaM.Get_New_Row(ParentR, Mov);
						ParentR = NewSpesaRow;

						string linkfield;
						if (Movimento.TableName=="income")
							linkfield="idproceeds";
						else
							linkfield="idpayment";

						FillMovimento(NewSpesaRow,R);
						NewSpesaRow[linkfield]= currIDmov;
						R["idmovimento"]= NewSpesaRow[idfield_name];

						NewSpesaRow["nphase"] = faseCorrente;

						if (faseCorrente < faseCreditoreDebitoreSpesa) {
							NewSpesaRow["idreg"] = DBNull.Value;
						}
	

						if (faseCorrente==fasespesamax) {
                            R["idmovimento"] = NewSpesaRow["idexp"];

                            DataRow NewLastMov = MetaL.Get_New_Row(NewSpesaRow, LastMov);
							object codicecreddeb = R["idreg"];
                            DataRow ModPagam = GetModPagamDefault(codicecreddeb);
							if (ModPagam==null) {
								MessageBox.Show(
									"E' necessario che sia definita almeno una modalità di pagamento per il percipiente "+
									"\""+R["registry"].ToString()+"\"\n\n"+
									"Dati non salvati", "Errore", MessageBoxButtons.OK);
								return false;
							}
							//aggiungere le informazioni della modalità di pagamento
                            NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                            NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                            NewLastMov["iban"] = ModPagam["iban"];
                            NewLastMov["cin"] = ModPagam["cin"];
                            NewLastMov["idbank"] = ModPagam["idbank"];
                            NewLastMov["idcab"] = ModPagam["idcab"];
                            NewLastMov["cc"] = ModPagam["cc"];
                            NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                            NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                            NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                            NewLastMov["flag"] = 0;
                            if ((NewLastMov.Table.Columns.Contains("biccode")) &&
                                (ModPagam.Table.Columns.Contains("biccode")))
                            NewLastMov["biccode"] = ModPagam["biccode"];
                            if ((NewLastMov.Table.Columns.Contains("extracode")) &&
                              (ModPagam.Table.Columns.Contains("extracode")))
                                NewLastMov["extracode"] = ModPagam["extracode"];
                            if ((NewLastMov.Table.Columns.Contains("idchargehandling")) &&
                            (ModPagam.Table.Columns.Contains("idchargehandling")) && (ModPagam["idchargehandling"] != DBNull.Value)) {
                                NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                            }
                            object idpaymethod =  ModPagam["idpaymethod"];
                            IDictionary<string, object> rPaymethod = Cache.paymethod.ReadValuesFor(idpaymethod);
                            if (Cache.paymethod.HasValueFor(idpaymethod)) {
                                object paymethod_allowdeputy = rPaymethod["allowdeputy"];
                                object paymethod_flag = rPaymethod["flag"];
                                    if (NewLastMov.Table.Columns.Contains("paymethod_allowdeputy")) {
                                        NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                                    }
                                    if (NewLastMov.Table.Columns.Contains("paymethod_flag")) {
                                        NewLastMov["paymethod_flag"] = paymethod_flag;
                                    }

                            }
						}
						DataRow NewImpMov = ImpMov.NewRow();

						FillImputazioneMovimento(NewImpMov, R);
						//NewImpMov["nphase"] = faseCorrente;
						NewImpMov["idexp"]= NewSpesaRow["idexp"];
						NewImpMov["ayear"]= esercizio;

						if (faseCorrente < faseBilancioSpesa) {
							NewImpMov["idfin"] = DBNull.Value;
							NewImpMov["idupb"] = DBNull.Value;
						}

						ImpMov.Rows.Add(NewImpMov);
					
					}
				}

				if (Mov.TableName == "income") {

					for(int faseCorrente = 1; faseCorrente <= faseentratamax; faseCorrente++) {
						DataRow NewEntrataRow = MetaM.Get_New_Row(ParentR, Mov);
						ParentR = NewEntrataRow;

						string linkfield;
						if (Movimento.TableName=="income")
							linkfield="idproceeds";
						else
							linkfield="idpayment";

						FillMovimento(NewEntrataRow,R);
						NewEntrataRow[linkfield]= currIDmov;
						R["idmovimento"]= NewEntrataRow[idfield_name];

						NewEntrataRow["nphase"] = faseCorrente;

						if (faseCorrente < faseCreditoreDebitoreEntrata) {
							NewEntrataRow["idreg"] = DBNull.Value;
						}

                        if (faseCorrente == faseentratamax) {
                            R["idmovimento"] = NewEntrataRow["idinc"];

                            DataRow NewLastMov = MetaL.Get_New_Row(NewEntrataRow, LastMov);
                            NewLastMov["flag"] = 0;
                        }
	
						//NewEntrataRow["descrizione"]="Automatismo";
						
						DataRow NewImpMov = ImpMov.NewRow();

						FillImputazioneMovimento(NewImpMov, R);
						//NewImpMov["nphase"] = faseCorrente;
						NewImpMov["idinc"]= NewEntrataRow["idinc"];
						NewImpMov["ayear"]= esercizio;

						if (faseCorrente < faseBilancioEntrata) {
							NewImpMov["idfin"] = DBNull.Value;
							NewImpMov["idupb"]=DBNull.Value;
						}

						ImpMov.Rows.Add(NewImpMov);
					}
				}

			}
            //Imposta il livsupid di tutte le righe per cui è necessario
            

            string tName = Mov.TableName;
            string paridfield = (tName == "expense") ? "parentidexp" : "parentidinc";

            DataTable MovParent = Conn.RUN_SELECT(tName, idfield_name + ",nphase", null,
                        QHS.FieldInList(idfield_name, getIdListFromArray(Auto, "livsupid", 999900000)), null, false);

            foreach (DataRow R in Auto) {
                if (R["livsupid"] == DBNull.Value) continue;
                object idtolink = R["livsupid"];

                object idmov = R["idmovimento"];

                int nfasetolink = CfgFn.GetNoNullInt32(MovParent.Select(QHC.CmpEq(idfield_name, idtolink))[0]["nphase"]);
                        //CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE(tName, QHS.CmpEq(idfield_name, idtolink), "nphase"));
                DataRow MovSel = Mov.Select(QHC.CmpEq(idfield_name, idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel[paridfield];
                    MovSel = Mov.Select(QHC.CmpEq(idfield_name, idmov))[0];
                    currfase--;
                }
                MovSel[paridfield] = idtolink;

            }

            //Cancella tutto ciò che non ha figli e non è di ultima fase sino a che non trova + nulla
            bool keep = true;
            int fasemax = Mov.TableName == "expense" ? fasespesamax : faseentratamax;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", fasemax);
                foreach (DataRow Parent in Mov.Select(filternolastphase)) {
                    object idpar = Parent[idfield_name];
                    string filterchild = QHC.CmpEq("parent" + idfield_name, idpar);
                    if (Mov.Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq(idfield_name, Parent[idfield_name]);
                        DataRow Imp = ImpMov.Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }

			return true;
		}

        private bool LeggiFlagEsenteBancaPredefinita()
        {
            DataTable tTreasurer = Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        /*
expenseflagcommseparatemanager 1
expenseflagfinance   2
expenseflagregistry  4
expenseflagseparatearrears 8
expenseflagseparatemanager 16
         */

		void GeneraAutoReversali(DataSet Auto){
			int faseentratamax = getIntSys("maxincomephase");
            int fasespesamax = getIntSys("maxexpensephase");
            string filterIncome = QHC.AppAnd(QHC.CmpEq("nphase", faseentratamax), QHC.IsNotNull("autokind"));
            DataRow[] AutoEntrata = Auto.Tables["income"].Select(filterIncome);
            if (AutoEntrata.Length == 0) return;

            string filterMainSpesa = QHC.AppAnd(QHC.CmpEq("nphase", fasespesamax), QHC.IsNull("autokind"));
            DataRow[] AutoMainSpesa = Auto.Tables["expense"].Select(filterMainSpesa);
            /*
             * 2	Liquidazione ritenute
			 * 6	Recupero (Split Payment ecc.)
             * 7	Chiusura fondo economale
             * 12	Liquidazione IVA
             * 13	Acconto IVA
             * 15	Liquidazione IVA consolidata interna
             * 16	Liquidazione IVA consolidata esterna
             * 17	Liquidazione IVA intrastat istituzionale
             * 18	Liquidazione IVA intrastat consolidata interna
             * 19	Liquidazione IVA intrastat consolidata esterna
             */
            string listaAutokind = QHC.List(2, 6, 7, 12, 13, 15, 16, 17, 18, 19);
            string filterAutoMov = QHC.AppAnd(QHC.CmpEq("nphase", faseentratamax), QHC.FieldInList("autokind", listaAutokind));
            int Nspecial = Auto.Tables["income"].Select(filterAutoMov).Length;

            if ((AutoMainSpesa.Length == 0) && (Nspecial == 0)) return;

            string idList = QueryCreator.ColumnValues(AutoEntrata, "idinc", false);
            string filterlast = QHC.AppAnd(QHC.IsNull("kpro"), "(idinc in (" + idList + "))");
			DataRow []LastEntrata = Auto.Tables["incomelast"].Select(filterlast);
			if ((LastEntrata==null)||(LastEntrata.Length==0)) return;


            //Legge la configurazione del tratt.bollo           
            DataRow[] bollo = TrattamentoBollo.Select();
            if (bollo.Length == 1) MetaData.SetDefault(Auto.Tables["proceeds"],
                                       "idstamphandling",
                                       bollo[0]["idstamphandling"]);

            //Legge la configurazione dell'ist. cass.
			
			DataRow[] cassiere = Cassiere.Select(QHC.CmpEq("flagdefault","S"));
            if (cassiere == null || cassiere.Length == 0) cassiere = Cassiere.Select();
			if ((cassiere==null)||(cassiere.Length!=1)){
                MessageBox.Show(
                    "Non è stato possibile generare le reversali poiché non c'è un istituto cassiere predefinito.");
                return;
			}
			if (cassiere.Length==1) MetaData.SetDefault(Auto.Tables["proceeds"], 
										"idtreasurer", 
										cassiere[0]["idtreasurer"]);

			DataRow PersEntrataRow= Config.Rows[0];
            int flag = CfgFn.GetNoNullInt32(PersEntrataRow["proceeds_flag"]);

            bool flagrespons = ((flag & 16) == 16);
                //PersEntrataRow["proceeds_flagseparatemanager"].ToString().ToUpper();
            bool flagbilancio = ((flag & 2) == 2);
                //PersEntrataRow["proceeds_flagfinance"].ToString().ToUpper();
            bool flagcreddeb = ((flag & 4) == 4);
                //PersEntrataRow["proceeds_flagregistry"].ToString().ToUpper();
            bool flagresidui = ((flag & 8) == 8);
                //PersEntrataRow["proceeds_flagseparatearrears"].ToString().ToUpper();

          

			bool distinguiresidui = flagresidui;

			MetaData MetaDocInc = Disp.Get("proceeds");
			MetaDocInc.SetDefaults(Auto.Tables["proceeds"]);
			foreach(DataRow E in LastEntrata){
                if (E.RowState != DataRowState.Added) continue;   
                string fIdMov = QHC.CmpEq("idinc", E["idinc"]);
				DataRow ImpuE = Auto.Tables["incomeyear"].Select(fIdMov)[0];
                DataRow MOV = Auto.Tables["income"].Select(fIdMov)[0];
				int idbilancioreversale= CfgFn.GetNoNullInt32( ImpuE["idfin"]);
                object proceeds_finlevel = PersEntrataRow["proceeds_finlevel"];
                if (flagbilancio &&
					(proceeds_finlevel != DBNull.Value) &&
                    (!proceeds_finlevel.Equals(maxfasebil))
					){
					int liv=CfgFn.GetNoNullInt32(proceeds_finlevel);
					if (liv!=0){
                        object O = Conn.DO_READ_VALUE(
                            "finlink", QHS.AppAnd( QHS.CmpEq("idchild",idbilancioreversale),
                                                     QHS.CmpEq("nlevel",liv)),
                            "idparent");
                        if (O != DBNull.Value) idbilancioreversale = CfgFn.GetNoNullInt32(O);
						//idbilancioreversale= idbilancioreversale.Substring(0,3+liv*4);
					}
				}

                int flag_pro = CfgFn.GetNoNullInt32(Auto.Tables["proceeds"].Columns["flag"].DefaultValue);
                flag_pro &= 0xF8;
				if (distinguiresidui){
					object X = ImpuE["flagarrear"];
					if (X==DBNull.Value) X="M";
                    string Y = X.ToString().ToUpper();
                    switch (Y) {
                        case "C": {
                                flag_pro |= 0x01;
                                break;
                            }
                        case "R": {
                                flag_pro |= 0x02;
                                break;
                            }
                        case "M": {
                                flag_pro |= 0x04;
                                break;
                            }
                    }
                    
					MetaData.SetDefault(Auto.Tables["proceeds"], "flag", flag_pro);
				}
				else {
                    flag_pro |= 0x04;
					MetaData.SetDefault(Auto.Tables["proceeds"], "flag", flag_pro);
                }
				DataRow DocIncasRow = MetaDocInc.Get_New_Row(null,Auto.Tables["proceeds"]);
				E.BeginEdit();
				E["kpro"]=DocIncasRow["kpro"];
				E.EndEdit();
                if (flagcreddeb) DocIncasRow["idreg"] = MOV["idreg"];
				if (flagbilancio)DocIncasRow["idfin"]=idbilancioreversale;
                if (flagrespons) DocIncasRow["idman"] = MOV["idman"];
                DocIncasRow["adate"] = MOV["adate"];
                object flagautostampa = PersEntrataRow["proceeds_flagautoprintdate"];
                if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                    DocIncasRow["printdate"] = DocIncasRow["adate"];
                }
			}
		}

        Dictionary<int, int> paymentLevelForFin = new Dictionary<int, int>();

        int GetPaymentLevelForFin(int idfin, int level) {
            if (level == 0) return idfin;
            if (paymentLevelForFin.ContainsKey(idfin)) return paymentLevelForFin[idfin];
            int newidfin= idfin;
            object O = Conn.DO_READ_VALUE(
                "finlink", QHS.AppAnd(
                        QHS.CmpEq("idchild", idfin),
                        QHS.CmpEq("nlevel", level)),
                "idparent");
            if (O != DBNull.Value) newidfin = CfgFn.GetNoNullInt32(O);
            //idbilancioreversale= idbilancioreversale.Substring(0,3+liv*4);
            paymentLevelForFin[idfin] = newidfin;
            return newidfin;

        }

		void GeneraAutoMandati(DataSet Auto){
			int fasespesamax = getIntSys("maxexpensephase");
            string filterExpense = QHC.AppAnd(QHS.CmpEq("nphase", fasespesamax), QHS.IsNotNull("autokind"));
            DataRow[] AutoSpesa = Auto.Tables["expense"].Select(filterExpense);
            if (AutoSpesa.Length == 0) return;

            string filterMainExpense = QHC.AppAnd(QHS.CmpEq("nphase", fasespesamax), QHS.IsNull("autokind"));
            DataRow[] AutoMainSpesa = Auto.Tables["expense"].Select(filterMainExpense);
            /*
             * 1	APFPS	    Apertura fondo economale
             * 2	LIQRT	    Liquidazione ritenute
             * 3	REFPS	    Reintegro fondo economale
             * 12	LPIVA	    Liquidazione IVA
             * 13	ACIVA	    Acconto IVA
             * 15	IVAINT	    Liquidazione IVA consolidata interna
             * 16	IVAEXT	    Liquidazione IVA consolidata esterna
             * 17	LPIVA12	    Liquidazione IVA intrastat istituzionale
             * 18	IVAINT12	Liquidazione IVA intrastat consolidata interna
             * 19	IVAEXT12	Liquidazione IVA intrastat consolidata esterna
            
             */
            string listaAutokind = QHC.List(1, 2, 3, 12, 13, 15, 16, 17, 18, 19);
            string filterAutoMov = QHC.AppAnd(QHC.CmpEq("nphase", fasespesamax), QHC.FieldInList("autokind", listaAutokind));
            int Nspecial = Auto.Tables["expense"].Select(filterAutoMov).Length;

            if ((AutoMainSpesa.Length == 0) && (Nspecial == 0)) return;

            string idList = QueryCreator.ColumnValues(AutoSpesa, "idexp", false);
            string filterlast = QHC.AppAnd(QHC.IsNull("kpay"), "(idexp in (" + idList + "))");
			DataRow []LastSpesa = Auto.Tables["expenselast"].Select(filterlast);
			if ((LastSpesa==null)||(LastSpesa.Length==0)) return;

			//Legge la configurazione dell'ist. cass. e tratt.bollo			
			DataRow[] bollo = TrattamentoBollo.Select();
			if (bollo.Length==1) MetaData.SetDefault(Auto.Tables["payment"],
									 "idstamphandling",
									 bollo[0]["idstamphandling"]);

            DataRow[] cassiere = Cassiere.Select(QHC.CmpEq("flagdefault", "S"));
            if (cassiere == null || cassiere.Length == 0) cassiere = Cassiere.Select();
			if (cassiere.Length!=1){
				MessageBox.Show(
					"Non è stato possibile generare i mandati poiché non c'è un tesoriere predefinito.");
				return;
			}
			if (cassiere.Length==1) MetaData.SetDefault(Auto.Tables["payment"], 
										"idtreasurer", 
										cassiere[0]["idtreasurer"]);

            DataRow PersSpesaRow = Config.Rows[0];
            int flag = CfgFn.GetNoNullInt32(PersSpesaRow["payment_flag"]);
            bool flagrespons = ((flag & 16) == 16);
            bool flagbilancio = ((flag & 2) == 2);
            bool flagcreddeb = ((flag & 4) == 4);
            bool flagresidui = ((flag & 8) == 8);

            bool distinguiresidui = flagresidui;

			MetaData MetaDocPag = Disp.Get("payment");
			MetaDocPag.SetDefaults(Auto.Tables["payment"]);
			foreach(DataRow S in LastSpesa){
                if (S.RowState != DataRowState.Added) continue; 
                string fIdMov = QHC.CmpEq("idexp", S["idexp"]);
				DataRow ImpuS = Auto.Tables["expenseyear"].Select(fIdMov)[0];
                DataRow MOV = Auto.Tables["expense"].Select(fIdMov)[0];
				int idbilanciomandato=CfgFn.GetNoNullInt32( ImpuS["idfin"] );
                object payment_finlevel = PersSpesaRow["payment_finlevel"];
                if (flagbilancio &&
                    (payment_finlevel != DBNull.Value) &&
                    (!payment_finlevel.Equals(maxfasebil))
					){
					int liv=CfgFn.GetNoNullInt32(payment_finlevel);
                    idbilanciomandato = GetPaymentLevelForFin(idbilanciomandato, liv);               
				}

                int flag_pay = CfgFn.GetNoNullInt32(Auto.Tables["payment"].Columns["flag"].DefaultValue);
                flag_pay &= 0xF8;

				if (distinguiresidui){
					object X = ImpuS["flagarrear"];
					if (X==DBNull.Value) X="M";

                    string Y = X.ToString().ToUpper();
                    switch (Y) {
                        case "C": {
                                flag_pay |= 0x01;
                                break;
                            }
                        case "R": {
                                flag_pay |= 0x02;
                                break;
                            }
                        case "M": {
                                flag_pay |= 0x04;
                                break;
                            }
                    }
					MetaData.SetDefault(Auto.Tables["payment"], "flag", flag_pay);
				}
				else {
                    flag_pay |= 0x04;
					MetaData.SetDefault(Auto.Tables["payment"], "flag", flag_pay);
				}
				DataRow DocPagamRow = MetaDocPag.Get_New_Row(null,Auto.Tables["payment"]);
				S.BeginEdit();
				S["kpay"]=DocPagamRow["kpay"];
                if (flagcreddeb) DocPagamRow["idreg"] = MOV["idreg"];
				if (flagbilancio)DocPagamRow["idfin"]=idbilanciomandato;
                if (flagrespons) DocPagamRow["idman"] = MOV["idman"];
                DocPagamRow["adate"] = MOV["adate"];
                object flagautostampa = PersSpesaRow["payment_flagautoprintdate"];
                if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                    DocPagamRow["printdate"] = DocPagamRow["adate"];
                }
				S.EndEdit();
			}
		}

        public static DataRow getRowPhase(DataTable Mov, object idMov, int nphase,DataAccess Conn) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            if (Mov == null) return null;
            string filter = "";
            string field = "";

            if (Mov.TableName == "expense") {
                field = "idexp";
            }
            else {
                field = "idinc";
            }
            string parentField = "parent" + field;
            filter = QHC.CmpEq(field, idMov);
            DataRow[] R = Mov.Select(filter);
            if (R.Length == 0) {
                filter = QHS.CmpEq(field, idMov);
                DataTable T = Conn.RUN_SELECT(Mov.TableName, "*", null, filter, null, true);
                if (T == null) return null;
                R = T.Select();
                if (R.Length == 0) return null;
            }
            if (CfgFn.GetNoNullInt32(R[0]["nphase"]) == nphase) return R[0];
            if (R[0][parentField] == DBNull.Value) return null;
            return getRowPhase(Mov, R[0][parentField], nphase,Conn);
        }

	    public static DataRow getRowPhaseCached(DataTable Mov, Dictionary<int,DataRow> rowById,object idMov, int nphase,DataAccess Conn) {
	        CQueryHelper QHC = new CQueryHelper();
	        QueryHelper QHS = Conn.GetQueryHelper();
	        if (Mov == null) return null;
	        string filter = "";
	        string field = "";

	        if (Mov.TableName == "expense") {
	            field = "idexp";
	        }
	        else {
	            field = "idinc";
	        }
	        string parentField = "parent" + field;
	        filter = QHC.CmpEq(field, idMov);
	        DataRow R;
	        if (!rowById.TryGetValue((int) idMov, out R)) {
	            filter = QHS.CmpEq(field, idMov);
	            DataTable T = Conn.RUN_SELECT(Mov.TableName, "*", null, filter, null, true);
	            if (T == null) return null;
	            var RR = T.Select();
	            if (RR.Length == 0) return null;
	            R = RR[0];
	            rowById[(int) idMov] = R;
	        }
	        if (CfgFn.GetNoNullInt32(R["nphase"]) == nphase) return R;
	        if (R[parentField] == DBNull.Value) return null;
	        return getRowPhaseCached(Mov,rowById, R[parentField],  nphase,Conn);
	    }

        public static int GetPhase(DataAccess Conn, DataSet Auto, int idexp) {
            QueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataRow[] found = Auto.Tables["expense"].Select(QHC.CmpEq("idexp", idexp));
            if (found.Length == 0) {
                //Non è in memoria---> deve essere sul db
                //Può fare la select direttamente.
                string filtermain = QHS.CmpEq("idexp", idexp);
                //DataTable MainImp = Conn.RUN_SELECT("expensesorted", "*", null, filtermain, null, true);
                object nphase = Conn.DO_READ_VALUE("expense", filtermain, "nphase");
                return CfgFn.GetNoNullInt32(nphase);
            }
            else {
                return CfgFn.GetNoNullInt32(found[0]["nphase"]);
            }
        }


      

        int getEsercComp(DataTable Mov,Dictionary<int,DataRow> rowById, int idMov, int bilphase) {
            DataRow R = getRowPhaseCached(Mov,rowById, idMov, bilphase, Conn);
            if (R == null) return CfgFn.GetNoNullInt32( Conn.GetSys("esercizio") );
            return CfgFn.GetNoNullInt32( R["ymov"] );			
		}

		void CalcolaFlagCompetenza(DataSet Auto){
			int eserc=CfgFn.GetNoNullInt32( Conn.GetSys("esercizio"));
			string filtersercizio="(ayear='"+eserc+"')";
			int fasebilanciospesa= 0 ; //DOVEVA DIVENTARE: 
			/* MODIFICA ABORTITA
			if (String.CompareOrdinal(eserc,"2004")>0) fasebilanciospesa=
					CfgFn.GetNoNullInt32(
									Meta.Conn.DO_READ_VALUE("persbilancio",filtersercizio,"codfaseimpegno"));
			*/
			if (fasebilanciospesa==0) fasebilanciospesa=CfgFn.GetNoNullInt32(Conn.GetSys("expensefinphase"));
            Dictionary<int,DataRow> movById= new Dictionary<int, DataRow>();
		    foreach (DataRow r in Auto.Tables["expense"].Rows) {
		        movById[(int) r["idexp"]] = r;
		    }
			foreach (DataRow IS in Auto.Tables["expenseyear"].Rows){
                ///TODO: creare versione di getEsercComp che accetta un dictionary con l'associazione idexp >> Riga di expense
                int eserccomp = getEsercComp(Auto.Tables["expense"],movById, CfgFn.GetNoNullInt32(IS["idexp"]), fasebilanciospesa);
				//string idspesa=IS["idexp"].ToString();
				if (eserccomp==eserc){
					IS["flagarrear"]="C";
				}
				else {
					IS["flagarrear"]="R";
				}
			}

			int fasebilancioentrata= 0;

			if (fasebilancioentrata==0) fasebilancioentrata=CfgFn.GetNoNullInt32(Conn.GetSys("incomefinphase"));
            movById.Clear();
		    foreach (DataRow r in Auto.Tables["income"].Rows) {
		        movById[(int) r["idinc"]] = r;
		    }

			foreach (DataRow IS in Auto.Tables["incomeyear"].Rows){
                int eserccomp = getEsercComp(Auto.Tables["income"],movById, CfgFn.GetNoNullInt32(IS["idinc"]), fasebilancioentrata);
                //string idspesa=IS["idexp"].ToString();
                if (eserccomp == eserc) {
                    IS["flagarrear"] = "C";
                }
                else {
                    IS["flagarrear"] = "R";
                }
            }

		}


		void GeneraAutoMandatiReversali(DataSet Auto){
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            Dictionary<string,object> rconfig = Cache.config.ReadValuesFor(esercizio);

            string filtersercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            Config = Conn.RUN_SELECT("config", "*", null, filtersercizio, null, true);
            Auto.Tables["expenseyear"].Columns.Add("flagarrear", typeof(string));
            Auto.Tables["incomeyear"].Columns.Add("flagarrear", typeof(string));
            CalcolaFlagCompetenza(Auto);
            string fieldconfig= "flagautopayment";
            if (GestioneFondoEconomale) fieldconfig = "flagpcashautopayment"; 
			//Verifica se ci sono eventuali mandati da generare
            object automandati = rconfig[fieldconfig];
			if ((automandati!=null)&&(automandati.ToString().ToUpper()=="S")) GeneraAutoMandati(Auto);


			//Verifica se ci sono eventuali reversali da generare
            fieldconfig = "flagautoproceeds";
            if (GestioneFondoEconomale) fieldconfig = "flagpcashautoproceeds";
            object autoreversali = rconfig[fieldconfig];
			if ((autoreversali!=null)&&(autoreversali.ToString().ToUpper()=="S")) GeneraAutoReversali(Auto);
            Auto.Tables["expenseyear"].Columns.Remove("flagarrear");
            Auto.Tables["incomeyear"].Columns.Remove("flagarrear");

		}

		/// <summary>
		/// Metodo che ricopia nella riga principale di expense o income del DataSet sorgente i dati presenti
		/// nella riga del DataSet di posting
		/// </summary>
		/// <param name="IoE">I = Income; E = Expense</param>
		/// <param name="saveDone">TRUE: Salvataggio riuscito; FALSE: Salvataggio Non Riuscito</param>
        public void updateSource(DataSet source, bool saveDone) {
            string tName = "expense";
            string filter = QHC.IsNull("autokind");
            DataRow postedRow;
            if(source.Tables[tName].Rows.Count != 1) return;
            DataRow MainSourceRow = source.Tables["expense"].Rows[0];
            object savedflag = 0;
            if (source.Tables["expenselast"].Rows.Count > 0) {
                DataRow MainLastRow = source.Tables["expenselast"].Rows[0];
                savedflag = MainLastRow["flag"];
            }
            object idexpSource = MainSourceRow["idexp"];

            if (dsAuto.Tables[tName].Rows.Count == 1){
                postedRow = dsAuto.Tables[tName].Select()[0];
            }
            else{
                //Ottiene la riga principale o come l'unica con autokind null o come l'unica con idexp pari a MainSourceRow
                if (dsAuto.Tables[tName].Select(filter).Length == 1)
                {
                    postedRow = dsAuto.Tables[tName].Select(filter)[0];
                }
                else
                {
                    string myfilter = QHC.CmpEq("idexp", idexpSource);
                    DataRow[] mustbe = dsAuto.Tables[tName].Select(myfilter);
                    if (mustbe.Length != 1) return;
                    postedRow = mustbe[0];
                }
            }

            // Aggiornamento delle tabelle figlie

            foreach(DataRelation dRel in dsAuto.Tables[tName].ChildRelations) {
                if(dRel.ChildTable.TableName == tName) continue;
                if(source.Tables[dRel.ChildTable.TableName] == null) continue;

                string field = "idexp";
                int indice = -1;
                for(int i = 0;i < dRel.ParentColumns.Length;i++) {
                    if(dRel.ParentColumns[i].ColumnName != "idexp") continue;
                    indice = i;
                }
                if(indice == -1) continue;
                field = dRel.ChildColumns[indice].ColumnName;
                riassegnaPiuCampi(source, field, postedRow["idexp"].ToString(), idexpSource,
                            dRel.ChildTable.TableName, saveDone);
            }

            DataRow sourceRow = source.Tables[tName].Rows[0];
            bool allequalbuttwo = true;
            foreach(DataColumn C in dsAuto.Tables[tName].Columns) {
                if(!source.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                if((!saveDone) && (postedRow.RowState != DataRowState.Unchanged)) continue;
                if(C.ColumnName != "flag" &&
                    !sourceRow[C.ColumnName].Equals(postedRow[C])) allequalbuttwo = false;
                sourceRow[C.ColumnName] = postedRow[C];
            }
            if((!saveDone) && postedRow.RowState == DataRowState.Unchanged) sourceRow.AcceptChanges();
            if(!saveDone && allequalbuttwo) {
                if (source.Tables["expenselast"].Rows.Count > 0) {
                    DataRow MainLastRow = source.Tables["expenselast"].Rows[0];
                    MainLastRow["flag"] = savedflag;
                }
                PostData.RemoveFalseUpdates(source);
            }
        }

		/// <summary>
		/// Metodo che riassegna i campi nelle tabelle del DataSet di orgine
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="tName"></param>
		/// <param name="listaCampi"></param>
		private void riassegnaCampo(DataSet source, string filter, string tName, string field) {
			if (!dsAuto.Tables.Contains(tName)) return;
			foreach(DataRow rAuto in dsAuto.Tables[tName].Select(filter)) {
				foreach(DataRow rSource in source.Tables[tName].Rows) {
					rSource[field] = rAuto[field];
					if ((rSource["ct"] != null) && (rAuto["ct"] != null)) {
						rSource["ct"] = rAuto["ct"];
					}
					if ((rSource["cu"] != null) && (rAuto["cu"] != null)) {
						rSource["cu"] = rAuto["cu"];
					}
					if ((rSource["lt"] != null) && (rAuto["lt"] != null)) {
						rSource["lt"] = rAuto["lt"];
					}
					if ((rSource["lu"] != null) && (rAuto["lu"] != null)) {
						rSource["lu"] = rAuto["lu"];
					}
				}
			}
		}

		/// <summary>
		/// Metodo che copia i valori dei campi del DataSet di Posting nel DataSet di origine
		/// </summary>
		/// <param name="source">DataSet di Origine</param>
		/// <param name="filter">Filtro sul Movimento di spesa</param>
		/// <param name="tName">Nome della Tabella di cui ricopiare i dati</param>
		/// <param name="saveDone">TRUE: Il DataSet di Posting è stato salvato; FALSE: Il DataSet di Posting non è stato salvato</param>
        private void riassegnaPiuCampi(DataSet source, string field, object idexpMain, object idexpSourceMain,
			string tName, bool saveDone) {
            string filter = QHC.CmpEq(field, idexpMain);
		    if (!dsAuto.Tables.Contains(tName)) return;
		    DataTable tAuto = dsAuto.Tables[tName];

            DataRow[] rAuto = tAuto.Select(filter);

		    if (!source.Tables.Contains(tName)) return;

		    DataTable tSource = source.Tables[tName];
            // Gestione delle righe cancellate poi risorte
            // Controlla le righe che in precedenza sono state cancellate ed ora sono ritornate in vita
            // Se ci sono tali righe devono essere riabilitate e ricopiate
            if (!saveDone) {
				foreach(DataRow r in tSource.Rows) {
					// Se la riga non era cancellata passa al prossimo DataRow
					if (r.RowState != DataRowState.Deleted) continue;
					// Se la riga non è figlia del movimento principale passa al prossimo DataRow
					// Confronto l'idexp del dataset di origine con quello di posting in quanto se la riga
					// è in stato di deleted allora vuol dire che l'idexp era già calcolato in modo definitivo
					if (!r[field, DataRowVersion.Original].Equals(idexpMain)) continue;
					string fDeath = QueryCreator.WHERE_KEY_CLAUSE(r, DataRowVersion.Original, false);
					// Cerca la riga cancellata nel dataset di posting
					DataRow [] rowKeepAlive = tAuto.Select(fDeath);
					// Se non ce ne sono passa al prossimo DataRow
					if (rowKeepAlive.Length == 0) continue;
					// Annulla le modifiche alla riga corrente (nel dataset sorgente)
					r.RejectChanges();
					// Ricopia tutti i campi dalla riga presente nel dataset di posting
					foreach(DataColumn C in tSource.Columns) {
					    if (C.ReadOnly) continue;
                        if(!tAuto.Columns.Contains(C.ColumnName)) continue;
						r[C] = rowKeepAlive[0][C.ColumnName];
					}
					// Fissa le modifiche
					r.AcceptChanges();
				}
			}
			else {
                ArrayList A = new ArrayList(10);
				foreach(DataRow r in tSource.Rows) {
					if (r.RowState != DataRowState.Deleted) continue;
                    A.Add(r);
					//r.AcceptChanges();
				}
                foreach(DataRow R in A) R.AcceptChanges();
			}

			// Righe non cancellate nel dataset di origine
			// Queste righe vengono aggiornate solo se sono state interessate da qualche modifica
			if (rAuto.Length == 0) return; //righe prese da dsAuto con filtro QHC.CmpEq(field, idexpMain)
            string filterSrc = QHC.CmpEq(field, idexpSourceMain);
			DataRow [] RowSource = tSource.Select(filterSrc);
			for (int i = 0; i < RowSource.Length; i++) {
				if (RowSource[i].RowState == DataRowState.Unchanged) continue;
			    if (rAuto.Length <= i) continue;
                if ((!saveDone) && (rAuto[i].RowState!=DataRowState.Unchanged)) continue;
				RowSource[i].BeginEdit();
				foreach(DataColumn c in tAuto.Columns) {
                    if(!tSource.Columns.Contains(c.ColumnName)) continue;
					if (RowSource[i][c.ColumnName].ToString()==rAuto[i][c.ColumnName].ToString())continue;
					if (!string.IsNullOrEmpty(tSource.Columns[c.ColumnName].Expression)) continue;
                    bool rO= tSource.Columns[c.ColumnName].ReadOnly;
					if (rO) tSource.Columns[c.ColumnName].ReadOnly=false;
					RowSource[i][c.ColumnName] = rAuto[i][c.ColumnName];
					if (rO) tSource.Columns[c.ColumnName].ReadOnly=true;
				}
				RowSource[i].EndEdit();
                if((!saveDone) && rAuto[i].RowState == DataRowState.Unchanged) RowSource[i].AcceptChanges();
			}

            if(saveDone) {
                // Se in rAuto ci sono più righe che in RowSource (caso in cui viene aggiunta qualche classificazione
                // automatica) allora viene eseguito questo ciclo che aggiunge le righe nella tabella di origine
                for(int j = RowSource.Length;j < rAuto.Length;j++) {
                    DataRow rSource = tSource.NewRow();
                    foreach(DataColumn C in tAuto.Columns) {
                        if(!tSource.Columns.Contains(C.ColumnName)) continue;
                        if(rSource[C.ColumnName].ToString() == rAuto[j][C.ColumnName].ToString()) continue;
                        if(!string.IsNullOrEmpty(tSource.Columns[C.ColumnName].Expression)) continue;
                        bool r_o = tSource.Columns[C.ColumnName].ReadOnly;
                        if(r_o == true) tSource.Columns[C.ColumnName].ReadOnly = false;
                        rSource[C.ColumnName] = rAuto[j][C.ColumnName];
                        if(r_o) tSource.Columns[C.ColumnName].ReadOnly = r_o;
                    }
                    tSource.Rows.Add(rSource);
                    //if((!saveDone) && rAuto[j].RowState == DataRowState.Unchanged) rSource.AcceptChanges();
                }
            }
		}

        DataTable auto_single_I=null;
        DataTable auto_single_E=null;
        DataTable get_TableAutoSingle(string IoE) {
            if (IoE == "I") {
                if (auto_single_I != null) return auto_single_I;
                auto_single_I = Conn.SQLRunner( //parte entrate
                    "SELECT 	A.idautosort, K.idparent,K.nlevel, K.idchild, A.idupb, A.idsorkindreg, A.idsorreg, A.idman," +
                    "	A.idsorkind, A.idsor, 1 as idinc,	A.numerator, A.denominator, A.flagnodate," +
                    "	A.defaultn1, A.defaultn2, A.defaultn3, A.defaultn4, A.defaultn5," +
                    "	A.defaults1 as values1, A.defaults2 as values2, A.defaults3 as values3, A.defaults4 as values4, A.defaults5 as values5," +
                    "	A.defaultv1, A.defaultv2, A.defaultv3, A.defaultv4, A.defaultv5," +
                    "	'A' as cu, GETDATE() as ct, 'A' as lu, GETDATE() as lt, " +
                    "   T.nphaseincome " +
                    " FROM autoincomesorting A " +
                    " JOIN sortingkind T	ON A.idsorkind = T.idsorkind  " +
                    " LEFT OUTER JOIN finlink K 	ON K.idparent = A.idfin " +
                    " WHERE " + QHS.CmpEq("A.ayear", Conn.GetSys("esercizio")) +
                    " and A.idsor is not null " +
                    " and  (T.start is null or " + QHS.CmpLe("T.start", Conn.GetSys("esercizio")) + ") " +
                    " and (T.stop is null or  " + QHS.CmpGe("T.stop", Conn.GetSys("esercizio")) + ") ", true);
                return auto_single_I;
                //auto_single_E è da filtrare  a valle,contiene tutte le righe di fin al di sotto di A.idfin= K.idparent
            }
            if (auto_single_E != null) return auto_single_E;
            auto_single_E = Conn.SQLRunner( //parte entrate
                "SELECT 	A.idautosort, K.idparent,K.nlevel, K.idchild, A.idupb, A.idsorkindreg, A.idsorreg, A.idman," +
                "	A.idsorkind, A.idsor, 1 as idexp,	A.numerator, A.denominator, A.flagnodate," +
                "	A.defaultn1, A.defaultn2, A.defaultn3, A.defaultn4, A.defaultn5," +
                    "	A.defaults1 as values1, A.defaults2 as values2, A.defaults3 as values3, A.defaults4 as values4, A.defaults5 as values5," +
                "	A.defaultv1, A.defaultv2, A.defaultv3, A.defaultv4, A.defaultv5," +
                "	'A' as cu, GETDATE() as ct, 'A' as lu, GETDATE() as lt, " +
                "   T.nphaseexpense " +
                " FROM autoexpensesorting A " +
                " JOIN sortingkind T	ON A.idsorkind = T.idsorkind  " +
                " LEFT OUTER JOIN finlink K 	ON K.idparent = A.idfin " +
                " WHERE " + QHS.CmpEq("A.ayear", Conn.GetSys("esercizio")) +
                " and A.idsor is not null " +
                " and  (T.start is null or " + QHS.CmpLe("T.start", Conn.GetSys("esercizio")) + ") "+
                " and (T.stop is null or  " + QHS.CmpGe("T.stop", Conn.GetSys("esercizio")) + ") ", true);
            return auto_single_E;            
        }
        
        DataTable autoSingleResultTableI=null;
        DataTable autoSingleResultTableE = null;
        DataTable getAutoSingleResultTable(string IoE) {
            if (IoE == "I") {
                if (autoSingleResultTableI != null) return autoSingleResultTableI;
                DataTable T = new DataTable();
                T.Columns.Add("idsorkind", typeof(System.String));
                T.Columns.Add("idsor", typeof(System.Int32));
                T.Columns.Add("idinc", typeof(System.Int32));
                T.Columns.Add("idsubclass", typeof(System.Int32));
                T.Columns.Add("amount", typeof(decimal));
                T.Columns.Add("description", typeof(System.String));
                T.Columns.Add("noupdate", typeof(System.Int32));
                T.Columns.Add("nodelete", typeof(System.Int32));
                T.Columns.Add("txt", typeof(System.String));
                T.Columns.Add("rtf", typeof(System.Byte[]));
                T.Columns.Add("cu", typeof(System.String));
                T.Columns.Add("ct", typeof(DateTime));
                T.Columns.Add("lu", typeof(System.String));
                T.Columns.Add("lt", typeof(DateTime));
                T.Columns.Add("flagnodate", typeof(System.String));
                T.Columns.Add("tobecontinued", typeof(System.String));
                T.Columns.Add("start", typeof(DateTime));
                T.Columns.Add("stop", typeof(DateTime));
                T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
                T.Columns.Add("paridsorkind", typeof(System.String));
                T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
                autoSingleResultTableI = T;
                return T;
            }
            else {
                if (autoSingleResultTableE != null) return autoSingleResultTableE;
                DataTable T = new DataTable();
                T.Columns.Add("idsorkind", typeof(System.String));
                T.Columns.Add("idsor", typeof(System.Int32));
                T.Columns.Add("idexp", typeof(System.Int32));
                T.Columns.Add("idsubclass", typeof(System.Int32));
                T.Columns.Add("amount", typeof(decimal));
                T.Columns.Add("description", typeof(System.String));
                T.Columns.Add("noupdate", typeof(System.Int32));
                T.Columns.Add("nodelete", typeof(System.Int32));
                T.Columns.Add("txt", typeof(System.String));
                T.Columns.Add("rtf", typeof(System.Byte[]));
                T.Columns.Add("cu", typeof(System.String));
                T.Columns.Add("ct", typeof(DateTime));
                T.Columns.Add("lu", typeof(System.String));
                T.Columns.Add("lt", typeof(DateTime));
                T.Columns.Add("flagnodate", typeof(System.String));
                T.Columns.Add("tobecontinued", typeof(System.String));
                T.Columns.Add("start", typeof(DateTime));
                T.Columns.Add("stop", typeof(DateTime));
                T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
                T.Columns.Add("paridsorkind", typeof(System.String));
                T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
                autoSingleResultTableE = T;
                return T;
            }
        }

        List<DataRow> FiltraIdSorReg(DataRow[] rows, object idreg) {
            List<DataRow> L = new List<DataRow>();
            foreach (DataRow r in rows) {
                if (r["idsorkindreg"] == DBNull.Value) {
                    L.Add(r);
                    continue;
                }
                DataTable ListaClassRegistry= getListaClassRegistry(r["idsorkindreg"],r["idsorreg"],idreg);
                if (ListaClassRegistry.Rows.Count > 0) {
                    L.Add(r);
                    continue;
                }                
            }
            return L;
        }

        Dictionary<string, DataTable> allListaClassRegistry = new Dictionary<string, DataTable>();
        DataTable getListaClassRegistry(object idsorkindreg, object idsorreg, object idreg) {
            string key = idsorkindreg.ToString()+"#"+idsorreg.ToString()+"#"+idreg.ToString();
            if (allListaClassRegistry.ContainsKey(key)) return allListaClassRegistry[key];
            string filterSorReg= QHS.AppAnd(QHS.CmpEq("C.idreg",idreg),
                            QHS.CmpEq("sc.idsorkind",idsorkindreg));
            if (idsorreg!=DBNull.Value) filterSorReg=QHS.AppAnd(filterSorReg,
                        QHS.CmpEq("sortinglink.idparent",idsorreg));          
            DataTable t =Conn.SQLRunner(
                "SELECT sortinglink.idparent, sortinglink.nlevel "+
                "	FROM registrysorting C "+
                "	JOIN sorting sc		ON sc.idsor = C.idsor "+
                "	JOIN sortinglink 	ON sortinglink.idchild = C.idsor "+
                "	WHERE "+filterSorReg,true);
            if (t == null) t = new DataTable();
            allListaClassRegistry[key] = t;
            return t;
        }

        List<DataRow> FiltraUpbNullOrLike(List<DataRow> rows, object idupb) {
            List<DataRow> L = new List<DataRow>();
            foreach (DataRow r in rows) {
                if (r["idupb"] == DBNull.Value) {
                    L.Add(r);
                    continue;
                }
                if (idupb == DBNull.Value) continue;
                if (idupb.ToString().StartsWith(r["idupb"].ToString())) {
                    L.Add(r);
                    continue;
                }

            }
            return L;
        }
        List<DataRow> ScegliPiuSpecifici(List<DataRow> L, string phasename) {
            List<DataRow> newL = new List<DataRow>();
            foreach (DataRow r in L) {
                //Aggiunge r a newL se non trova altre righe più specifiche di r in L
                bool found=false;
                foreach (DataRow t in L) {
                    if (r["idsorkind"].ToString() != t["idsorkind"].ToString()) continue;
                    if (r[phasename].ToString() != t[phasename].ToString()) continue;

                    if (r["idparent"] != DBNull.Value && t["idparent"] == DBNull.Value) continue;
                    if (r["idparent"] == DBNull.Value && t["idparent"] != DBNull.Value) {
                        found = true; //t più specifico di r
                        break;
                    }
                    //sono entrambi not null, ne confronta il livello
                    if (CfgFn.GetNoNullInt32(r["nlevel"])>CfgFn.GetNoNullInt32(r["nlevel"])) continue;
                    if (CfgFn.GetNoNullInt32(r["nlevel"])<CfgFn.GetNoNullInt32(r["nlevel"])) {
                        found = true; //t più specifico di r
                        break;
                    }

                    //Ora vede l'upb
                    if (r["idupb"] != DBNull.Value && t["idupb"] == DBNull.Value) continue;
                    if (r["idupb"] == DBNull.Value && t["idupb"] != DBNull.Value) {
                        found = true; //t più specifico di r
                        break;
                    }
                    //entrambi not null, vede se ce n'è uno più specifico tra i due
                    string r_upb = r["idupb"].ToString();
                    string t_upb = t["idupb"].ToString();
                    if (r_upb.StartsWith(t_upb) && t_upb != r_upb) continue; //r piu specifico di t
                    if (t_upb.StartsWith(r_upb) && t_upb != r_upb) {
                        found = true;
                        break; //t più specifico di r
                    }

                    //vede idsorkindreg
                    if (r["idsorkindreg"] != DBNull.Value && t["idsorkindreg"] == DBNull.Value) continue;
                    if (r["idsorkindreg"] == DBNull.Value && t["idsorkindreg"] != DBNull.Value) {
                        found = true; //t più specifico di r
                        break;
                    }

                    //entrambi idsorkindreg not null
                    if (r["idsorreg"] != DBNull.Value && t["idsorreg"] == DBNull.Value) continue;
                    if (r["idsorreg"] == DBNull.Value && t["idsorreg"] != DBNull.Value) {
                        found = true; //t più specifico di r
                        break;
                    }

                    if (r["idsorkindreg"].ToString() != t["idsorkindreg"].ToString()) continue; //class.diverse, non sono confrontabili
                    if (r["idsorreg"].ToString() == t["idsorreg"].ToString()) continue;  //sono uguali, sarà lo stesso...
                    
                    //A questo punto potrebbe vedere se una delle due class. è parent dell'altra!
                    //tuttavia per ora lasciamo perdere, nessuno sta usando questo meccanismo

                }
                if (!found) {
                    newL.Add(r);
                }
            }
            return newL;

         /*   ((#tmp.idfin IS NULL) or (K.idparent = #tmp.idfin )) AND 
		((#tmp.idupb IS NULL)or(T2.idupb LIKE #tmp.idupb+'%') ) AND
		((#tmp.idman IS NULL)or(T2.idman = #tmp.idman) ) AND
		(   ((#tmp.idsorkindreg IS NULL)or
		      ( 
			 (T2.idsorkindreg = #tmp.idsorkindreg)
			AND (SLK.idparent = #tmp.idsorreg)
		      )		
		   )	
		)
          * */
        }

        DataSet simulateSort_auto_single(string IoE, int esercizio, object idmov, object idreg, object idupb,
                    object start_nphase, object stop_nphase, object idfin, object idman, object expenseamount, object parentid) {
            DataTable auto_single = get_TableAutoSingle(IoE);
            DataTable resT = getAutoSingleResultTable(IoE).Clone();

            DataSet D = new DataSet();
            string phaseFieldName = IoE == "I" ? "nphaseincome" : "nphaseexpense";
            string idFieldName = IoE == "I" ? "idinc" : "idexp";

            D.Tables.Add(resT);
            string filter = QHC.AppAnd(QHC.NullOrEq("idchild", idfin),
                                  QHC.NullOrEq("idman", idman),
                                  QHC.Between(phaseFieldName, start_nphase, stop_nphase)
                                  );
            DataRow[] found_noreg = auto_single.Select(filter);
            List<DataRow> found_noupb = FiltraIdSorReg(found_noreg, idreg);
            List<DataRow> found = FiltraUpbNullOrLike(found_noupb, idupb);
            List<DataRow> refined = ScegliPiuSpecifici(found,phaseFieldName);

            foreach (DataRow r in refined) {
                //Aggiunge la riga trovata al risultato
                int idsubclass = resT.Select(QHC.CmpEq("idsor", r["idsor"])).Length + 1;
                DataRow n = resT.NewRow();
                n["idsorkind"] = r["idsorkind"];
                n["idsor"] = r["idsor"];
                n[idFieldName] = idmov;
                n["idsubclass"] = idsubclass;
                decimal numerator = CfgFn.GetNoNullDecimal(r["numerator"]);
                decimal denominator = CfgFn.GetNoNullDecimal(r["denominator"]);
                if (numerator == 0 && denominator == 0) {
                    numerator = 1;
                    denominator = 1;
                }
                if (denominator == 0) denominator = numerator;
                n["amount"] = CfgFn.GetNoNullDecimal(expenseamount) * numerator / denominator;

                foreach (string f_tocopy in new string[] { "cu", "ct", "lu", "lt", "flagnodate" }) {
                    n[f_tocopy] = r[f_tocopy];
                }

                for (int i = 1; i <= 5; i++) {
                    if (r["defaultN" + i.ToString()].ToString() == "@") n["valueN" + i.ToString()] = n["amount"];
                    if (r["defaultV" + i.ToString()].ToString() == "@") n["valueV" + i.ToString()] = n["amount"];
                    n["valueS" + i.ToString()] = r["valueS" + i.ToString()];
                }
                n["ayear"] = esercizio;
                resT.Rows.Add(n);
                n.AcceptChanges();
            }


            //Ora aggiunge le righe in base alla class. sui movimenti parent
            DataTable tClassMovParent = IoE == "I" ? tClassMovI : tClassMovE;

            DataRow[] rclassParent = new DataRow[0];
            
            if (tClassMovParent.Rows.Count>0){
                rclassParent= tClassMovParent.Select(
                QHC.AppAnd(QHC.CmpEq("idchild", parentid),
                            QHC.Between(phaseFieldName, start_nphase, stop_nphase)));
            }
            foreach (DataRow rp in rclassParent) {
                decimal curramount= CfgFn.GetNoNullDecimal(rp["curramount"]);
                decimal expamount = CfgFn.GetNoNullDecimal(expenseamount);
                decimal sortamount =  CfgFn.GetNoNullDecimal(rp["amount"]) ;

                //cancella le classificazioni multiple se associati a pagamenti parziali (come da SP, si potrebbe anche rimuovere volendo)
                //if (sortamount > expamount) {
                //    int nfound_same_idsorkind = 0;
                //    foreach (DataRow g in rclassParent) {
                //        if (g["idsorkind"].ToString() == rp["idsorkind"].ToString()) nfound_same_idsorkind++;
                //    }
                //    if (nfound_same_idsorkind > 1) continue;
                //}
                int idsubclass = resT.Select(QHC.CmpEq("idsor", rp["idsor"])).Length + 1;
                DataRow n = resT.NewRow();
                foreach (string f in new string[]{"idsorkind","idsor","paridsorkind","paridsor","paridsubclass"}) {
                    n[f] = rp[f];
                }
                n["ct"] = DateTime.Now;
                n["lt"] = DateTime.Now;
                n["cu"] = "autosort";
                n["lu"] = "autosort";
                n["idsubclass"] = idsubclass;
                n["ayear"] = esercizio;
                n["amount"] = expamount * sortamount / curramount;
                resT.Rows.Add(n);
            }            	

            return D;
        }

        DataTable AllTipoClassMov;
        void GeneraClassificazioniAutomatichePerAutomatismi(DataSet Auto, string movtable) {
            GeneraClassificazioniAutomatichePerAutomatismi(Auto, movtable, false);
        }
        DataTable tClassMovI=null;
        DataTable tClassMovE=null;

        string getIdListFromArray(DataRow[] rr, string field, int threeshold) {
            Dictionary<int, bool> sl = new Dictionary<int, bool>();
            foreach (DataRow r in rr) {
                if (r.RowState == DataRowState.Deleted) continue;
                int n = CfgFn.GetNoNullInt32(r[field]);
                if (n == 0 || n >= threeshold) continue;
                if (sl.ContainsKey(n)) continue;
                sl.Add(n, true);
            }
            string res = "";
            foreach (int k in sl.Keys) {
                if (res.Length > 0) res += ",";
                res += k.ToString();
            }
            return res;
        }
        string getIdList(DataTable T,string field, int threeshold){
            Dictionary <int,bool> sl = new Dictionary <int,bool>();
            foreach(DataRow r in T.Rows){
                if (r.RowState==DataRowState.Deleted) continue;
                int n= CfgFn.GetNoNullInt32(r[field]);
                if (n==0 || n>=threeshold) continue;
                if (sl.ContainsKey(n)) continue;
                sl.Add(n,true);
            }
            string res = "";            
            foreach(int k in sl.Keys){
                if (res.Length>0) res+=",";
                res+= k.ToString();
            }
            return res;
        }

        void PrefillClassParentMov(string IoE, DataTable tMov) {
            if (IoE=="I" && tClassMovI==null){
                string list = getIdList(tMov,"parentidinc",900000000);
                if (list=="") {
                    tClassMovI= new DataTable("a");
                    return;
                }
                string sql = "select  EL.idchild, SK.idsorkind,	S2.idsor,"+
                            "S.idsorkind as paridsorkind, S.idsor as paridsor, ES.idsubclass as paridsubclass,"+
                            "ET.curramount,	ES.amount,SK.nphaseincome "+
                            " from incomesorted ES "+
                            "join incomelink EL on " +QHS.FieldInList("EL.idchild",list)+
		                    " and EL.idparent=ES.idinc and "+QHS.CmpEq("ES.ayear",Conn.GetSys("esercizio"))+
                            " join incometotal ET on ES.idinc=ET.idinc and "+QHS.CmpEq("ET.ayear",Conn.GetSys("esercizio"))+
                            " join sorting S  on ES.idsor=S.idsor	"+
                            " join sortingkind SK on SK.idparentkind= S.idsorkind	"+
                            " join sorting S2 on S2.idsorkind=SK.idsorkind and "+
                            "		S2.sortcode=S.sortcode AND ISNULL(S2.movkind,'')=ISNULL(S.movkind,'') "+
                            " where (SK.start is null or SK.start<="+Conn.GetSys("esercizio").ToString()+") "+
                            "    and (SK.stop is null or SK.stop>="+Conn.GetSys("esercizio").ToString()+") "+
                            "	and (isnull(SK.active,'S')='S') ";
                // nphaseincome andrà poi filtrato a valle, così come idchild
                tClassMovI = Conn.SQLRunner(sql,true,0);
            }
            if (IoE == "E" && tClassMovE == null) {
                string list = getIdList(tMov, "parentidexp", 900000000);
                if (list == "") {
                    tClassMovE = new DataTable("a");
                    return;
                }
                string sql = "select EL.idchild, SK.idsorkind,	S2.idsor," +
                            "S.idsorkind as paridsorkind, S.idsor as paridsor, ES.idsubclass as paridsubclass," +
                            "ET.curramount,	ES.amount,SK.nphaseexpense " +
                            " from expensesorted ES " +
                            "join expenselink EL on " + QHS.FieldInList("EL.idchild", list) +
                            " and EL.idparent=ES.idexp and " + QHS.CmpEq("ES.ayear", Conn.GetSys("esercizio")) +
                            " join expensetotal ET on ES.idexp=ET.idexp and " + QHS.CmpEq("ET.ayear", Conn.GetSys("esercizio")) +
                            " join sorting S  on ES.idsor=S.idsor	" +
                            " join sortingkind SK on SK.idparentkind= S.idsorkind	" +
                            " join sorting S2 on S2.idsorkind=SK.idsorkind and " +
                            "		S2.sortcode=S.sortcode AND ISNULL(S2.movkind,'')=ISNULL(S.movkind,'') " +
                            " where (SK.start is null or SK.start<=" + Conn.GetSys("esercizio").ToString() + ") " +
                            "    and (SK.stop is null or SK.stop>=" + Conn.GetSys("esercizio").ToString() + ") " +
                            "	and (isnull(SK.active,'S')='S') ";
                // nphaseexpense andrà poi filtrato a valle
                tClassMovE = Conn.SQLRunner(sql, true,0);
            }

        }

        public void GeneraClassificazioniSiope2018(DataSet Auto, string movtable) {

            if (Auto.Tables[movtable] == null) return;
            DataTable ImpClass = Auto.Tables[movtable + "sorted"];

            string idmovimento = movtable == "expense" ? "idexp" : "idinc";
            string fAutomatismi = QHC.IsNotNull("autokind");
            string IoE = movtable == "expense" ? "E" : "I";

            Cache.sorting.ReadValuesRelatedTo(ImpClass, "idsor");
            PrefillClassParentMov(IoE, Auto.Tables[movtable]);
            int fasespesamax = CfgFn.GetNoNullInt32(Conn.GetSys("maxexpensephase"));
            int faseentratamax = CfgFn.GetNoNullInt32(Conn.GetSys("maxincomephase"));
            foreach (DataRow CurrMov in Auto.Tables[movtable].Select(fAutomatismi)) {
                string filterid = QHC.CmpEq(idmovimento, CurrMov[idmovimento]);
                var rows = Auto.Tables[movtable + "year"].Select(filterid);
                if (rows.Length == 0) continue;
                DataRow CurrImputazioneMov = rows[0];
                if (CurrImputazioneMov.RowState != DataRowState.Added) continue;
                int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
                if ((IoE == "E") && (currfase != fasespesamax)) continue;
                object IDForSP = DBNull.Value;
                if (CurrMov.RowState != DataRowState.Added) IDForSP = CurrMov[idmovimento];

                int parentid = CfgFn.GetNoNullInt32(CurrMov["parent" + idmovimento]);
                object parid_for_SP = DBNull.Value;
                if (parentid != 0 && parentid < 900000000) parid_for_SP = parentid;
                object idsor = DBNull.Value;               
                if(IoE == "E"){
                    //12  LPIVA Liquidazione IVA
                    //17  LPIVA12 Liquidazione IVA intrastat istituzionale
                    //23  LPIVASPLIT Liquidazione IVA istituzionale split
                    if ( CurrMov["autokind"].ToString() == "12") {
                        object idsor_siopeivaexp = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idsor_siopeivaexp");
                        if ((idsor_siopeivaexp != DBNull.Value) && (idsor_siopeivaexp != null)) {
                            idsor = idsor_siopeivaexp;
                        }
                    }
                    if (CurrMov["autokind"].ToString() == "17") {
                        object idsor_siopeiva12exp = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idsor_siopeiva12exp");
                        if ((idsor_siopeiva12exp != DBNull.Value) && (idsor_siopeiva12exp != null)) {
                            idsor = idsor_siopeiva12exp;
                        }
                    }
                    if (CurrMov["autokind"].ToString() == "23") {
                        object idsor_siopeivasplitexp = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idsor_siopeivasplitexp");
                        if ((idsor_siopeivasplitexp != DBNull.Value) && (idsor_siopeivasplitexp != null)) {
                            idsor = idsor_siopeivasplitexp;
                        }
                    }
                }
                else {
                    if (CurrMov["autokind"].ToString() == "12") {
                        object idsor_siopeivainc = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idsor_siopeivainc");
                        if ((idsor_siopeivainc != DBNull.Value) && (idsor_siopeivainc != null)) {
                            idsor = idsor_siopeivainc;
                        }
                    }
                    if (CurrMov["autokind"].ToString() == "17") {
                        object idsor_siopeiva12inc = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idsor_siopeiva12inc");
                        if ((idsor_siopeiva12inc != DBNull.Value) && (idsor_siopeiva12inc != null)) {
                            idsor = idsor_siopeiva12inc;
                        }
                    }
                }
                if (idsor == null || idsor==DBNull.Value) continue;
               //DataRow[] existent_sorting = ImpClass.Select(filterid);

                RowChange.MarkAsAutoincrement(
                    ImpClass.Columns["idsubclass"],
                    null,
                    null,
                    7,
                    false);
                RowChange.SetSelector(ImpClass, idmovimento);
                RowChange.SetSelector(ImpClass, "idsor");

                // - add row to impclassspesa
                // - evaluates temporary AutoIncrement fields
                    DataRow MyDR = ImpClass.NewRow();
                    MyDR["amount"] = CurrImputazioneMov["amount"];
                    MyDR["idsor"] = idsor;
                    MyDR["ayear"] = Conn.GetSys("esercizio");
                    MyDR["tobecontinued"] = "N";
                    MyDR["flagnodate"] = "S";
                ///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni

                if (MyDR[idmovimento] == DBNull.Value) {
                    MyDR[idmovimento] = CurrMov[idmovimento];
                }

                    RowChange.CalcTemporaryID(MyDR);
                    ImpClass.Rows.Add(MyDR);

                    //object currcodtipoclass = AutoClass["idsorkind"];

                    //GestioneClassificazioni.CalcFlag(Conn, MyDR, currcodtipoclass);

                
            }
        }


        /// <summary>
        /// Chiama la sp sort_auto_single, che tiene conto della tabella autoexpensesorting, 
        ///     ossia "Configurazione classificazione automatica spese" per classificare gli automatismi 
        ///    in base a  creditore, upb, bilancio, responsabile
        /// La stessa sp restituisce anche le classificazioni "dipendenti" ossia quelle per cui è stata definita
        ///   una classificazione come "principale"
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="movtable"></param>
        /// <param name="allmov">se true applica le class. anche ai mov.principali (quelli che hanno autokind null)</param>
        void GeneraClassificazioniAutomatichePerAutomatismi(DataSet Auto, string movtable, bool allmov) {
	        QueryCreator.MarkEvent($"GeneraClassificazioniAutomatichePerAutomatismi(Auto,{movtable},{allmov})");
			if (Auto.Tables[movtable]==null) return;
			if (AllTipoClassMov==null) AllTipoClassMov = Conn.RUN_SELECT("sortingkind",
											"idsorkind, nphaseincome, nphaseexpense",null,null,null,true);
			DataTable ImpClass=Auto.Tables[movtable+"sorted"];

			string idmovimento= movtable=="expense" ? "idexp" : "idinc";
            string fAutomatismi = QHC.IsNotNull("autokind");
            if(allmov) fAutomatismi = null;
            string IoE= movtable == "expense" ? "E" : "I";

            Cache.sorting.ReadValuesRelatedTo(ImpClass, "idsor");
            PrefillClassParentMov(IoE, Auto.Tables[movtable]);
            Dictionary<int,DataRow> movyearById = new Dictionary<int, DataRow>();
            Dictionary<int,List<DataRow>> classById = new Dictionary<int, List<DataRow>>();
            foreach (DataRow ry in Auto.Tables[movtable + "year"].Rows) {
                if (ry.RowState == DataRowState.Deleted) continue;
                movyearById[(int) ry[idmovimento]] = ry;
                classById[(int) ry[idmovimento]] = new List<DataRow>();
            }
            
            foreach (DataRow rMov in Auto.Tables[movtable].Select(fAutomatismi)) {
                if (!classById.ContainsKey((int) rMov[idmovimento])) {
                    classById[(int) rMov[idmovimento]] = new List<DataRow>();
                }                
            }

            foreach (DataRow classRow in ImpClass.Rows) {
                if (classRow.RowState == DataRowState.Deleted) continue;

                //evita eccezioni in alcuni casi (task 13270)
                if (!classById.ContainsKey((int) classRow[idmovimento])) continue;

                classById[(int) classRow[idmovimento]].Add(classRow);
            }


            foreach(DataRow CurrMov in Auto.Tables[movtable].Select(fAutomatismi)) {
                DataRow CurrImputazioneMov = null;
                if (!movyearById.TryGetValue((int) CurrMov[idmovimento], out CurrImputazioneMov)) continue;
                //string filterid = QHC.CmpEq(idmovimento, CurrMov[idmovimento]);
                //if (Auto.Tables[movtable + "year"].Select(filterid).Length == 0) continue;

                //DataRow CurrImputazioneMov = Auto.Tables[movtable+"year"].Select(filterid)[0];
                if(CurrImputazioneMov.RowState != DataRowState.Added) continue;
				
				int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
			
				object IDForSP = DBNull.Value;
				//if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];
				if (CurrMov.RowState != DataRowState.Added) IDForSP = CurrMov[idmovimento];
                
                int parentid   = CfgFn.GetNoNullInt32(CurrMov["parent" + idmovimento]);
                object parid_for_SP = DBNull.Value;
                if (parentid!=0 && parentid<900000000) parid_for_SP= parentid;
				DataSet OutDS;
				try {
                    OutDS = simulateSort_auto_single(IoE,
										CfgFn.GetNoNullInt32( Conn.GetSys("esercizio")),
										IDForSP,
										CurrMov["idreg"],
										CurrImputazioneMov["idupb"],
										currfase,
										currfase,
										CurrImputazioneMov["idfin"],
										CurrMov["idman"],
										CurrImputazioneMov["amount"],
                                        parid_for_SP
									);
				}
				catch (Exception E) {
					MessageBox.Show(E.Message);
					return;
				}
				if ((OutDS==null) ||(OutDS.Tables.Count==0)) return; //no autoclass

                DataTable AutoClasses = OutDS.Tables[0];


                DataRow[] existent_sorting = classById[(int) CurrMov[idmovimento]].ToArray();// ImpClass.Select(filterid);


                //Cancella le classificazioni il cui TIPO è GIA' PRESENTE NEL MOVIMENTO
                foreach (DataRow AutoClass in AutoClasses.Select()) {
                    object idsorkind = AutoClass["idsorkind"];

                    //Cerca una riga in existent_sorting avente pari idsorkind
                    foreach (DataRow exClass in existent_sorting) {
                        object idsor = exClass["idsor"];
                        if (!Cache.sorting.HasValueFor(idsor)) continue;
                        object myidsorkind = Cache.sorting.getField(idsor,"idsorkind");
                        if (myidsorkind.ToString() == idsorkind.ToString()) {
                            AutoClass.Delete();
                            break;
                        }
                    }
                   
                }
                AutoClasses.AcceptChanges();


				RowChange.MarkAsAutoincrement(
					ImpClass.Columns["idsubclass"], 
					null,
					null,
					7,
					false);
                RowChange.setMinimumTempValue(ImpClass.Columns["idsubclass"],1);
				//RowChange.SetSelector(ImpClass, "idsorkind");
				RowChange.SetSelector(ImpClass, idmovimento);
				RowChange.SetSelector(ImpClass, "idsor");
		

				//for every row in OutDS.Tables[0]:
				// - add row to impclassspesa
				// - evaluates temporary AutoIncrement fields
				foreach (DataRow AutoClass in AutoClasses.Rows) {
					DataRow MyDR =  ImpClass.NewRow();
					foreach(DataColumn DC in ImpClass.Columns) {
						if (DC.ColumnName.StartsWith("!")) continue;
						if (DC.ColumnName=="originalamount") continue;
						MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
					}
					///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
					
                    if (MyDR[idmovimento]==DBNull.Value) 
						MyDR[idmovimento]= CurrMov[idmovimento];

					RowChange.CalcTemporaryID(MyDR);
					ImpClass.Rows.Add(MyDR);

                    object currcodtipoclass = AutoClass["idsorkind"];

					GestioneClassificazioni.CalcFlag(Conn, MyDR, currcodtipoclass);

					//object currcodtipoclass= MyDR["idsorkind"];
                    
                    //Applica la traduzione classificazioni ove presente
					DataRow []ArrCurrTipo = AllTipoClassMov.Select(QHC.CmpEq("idsorkind",currcodtipoclass));
					if ((ArrCurrTipo!=null) && (ArrCurrTipo.Length>0)){
						DataRow CurrTipo = ArrCurrTipo[0];
						CalcAutoClasses(MyDR,CurrTipo, CurrMov, CurrImputazioneMov, ImpClass);
					}
				}
			}
	
		}
        
        /// <summary>
        /// Al dizionario mySortTranslation si accede tramite l'idsor del master ossia idsortingmaster di sortingtranslation
        /// </summary>
        Dictionary<int, List<DataRow>> mySortTranslation = null;
        void ReadmySortTranslation() {
            if (mySortTranslation != null) return;
            mySortTranslation = new Dictionary<int, List<DataRow>>();
            DataTable T = Conn.SQLRunner(
                "select S.idsorkind,ST.idsortingchild,ST.idsortingmaster,ST.denominator,ST.numerator,ST.flagnodate," +
                "ST.defaultn1,ST.defaultn2,ST.defaultn3,ST.defaultn4,ST.defaultn5," +
                "ST.defaultv1,ST.defaultv2,ST.defaultv3,ST.defaultv4,ST.defaultv5," +
                "ST.defaults1,ST.defaults2,ST.defaults3,ST.defaults4,ST.defaults5, " +
                "SK.idparentkind,SK.nphaseincome,SK.nphaseexpense " +
                " from  sortingtranslation ST " +
                " join sorting S on  S.idsor = ST.idsortingchild " +
                " join sortingkind SK on SK.idsorkind=S.idsorkind " +
                " where  ISNULL(SK.active,'S')='S'" + 
                " and  (SK.start is null or " + QHS.CmpLe("SK.start", Conn.GetSys("esercizio")) + ") " +
                " and (SK.stop is null or  " + QHS.CmpGe("SK.stop", Conn.GetSys("esercizio")) + ") ", true);
            if (T == null || T.Rows.Count == 0) return;
            foreach (DataRow R in T.Rows) {
                int idsor = CfgFn.GetNoNullInt32(R["idsortingmaster"]);
                if (idsor != 0){
                    List<DataRow> l=null;
                    if (mySortTranslation.ContainsKey(idsor)){
                        l= mySortTranslation[idsor];
                    }
                    else {
                        l= new List<DataRow>();
                        mySortTranslation[idsor]=l;
                    }
                    l.Add(R);
                }
            }
        }
        DataSet SimulateCalcAutoClassesDataSet_E = null;
        DataSet SimulateCalcAutoClassesDataSet_S = null;
        void CreateSimulateCalcAutoClassesDataSet(string IoE) {
            if (SimulateCalcAutoClassesDataSet_E == null && IoE == "I") {
                DataSet D = new DataSet();

                DataTable T = new DataTable("I");
                T.Columns.Add("idsor", typeof(System.Int32));
                T.Columns.Add("idinc", typeof(System.Int32));
                T.Columns.Add("idsubclass", typeof(System.Int16));

                T.Columns.Add(new DataColumn("idsorkind", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsorkind", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
                T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
                DataColumn C = new DataColumn("cu", typeof(System.String), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("ct", typeof(System.DateTime), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("lu", typeof(System.String), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("lt", typeof(System.DateTime), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
                T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
                T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));

                T.Columns.Add(new DataColumn("noupdate", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("nodelete", typeof(System.Int32), ""));
                D.Tables.Add(T);

                SimulateCalcAutoClassesDataSet_E = D;
            }
            if (SimulateCalcAutoClassesDataSet_S == null && IoE == "E") {
                DataSet D = new DataSet();

                DataTable T = new DataTable("I");
                T.Columns.Add("idsor", typeof(System.Int32));
                
                T.Columns.Add("idexp", typeof(System.Int32));
                T.Columns.Add("idsubclass", typeof(System.Int16));


                T.Columns.Add(new DataColumn("idsorkind", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsorkind", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("amount", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuen5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("values1", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values2", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values3", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values4", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("values5", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("valuev1", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev2", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev3", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev4", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("valuev5", typeof(System.Decimal), ""));
                T.Columns.Add(new DataColumn("ayear", typeof(System.Int16), ""));
                T.Columns.Add(new DataColumn("description", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("txt", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("rtf", typeof(System.Byte[]), ""));
                DataColumn C = new DataColumn("cu", typeof(System.String), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("ct", typeof(System.DateTime), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("lu", typeof(System.String), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                C = new DataColumn("lt", typeof(System.DateTime), "");
                C.AllowDBNull = false;
                T.Columns.Add(C);

                T.Columns.Add(new DataColumn("flagnodate", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("tobecontinued", typeof(System.String), ""));
                T.Columns.Add(new DataColumn("start", typeof(System.DateTime), ""));
                T.Columns.Add(new DataColumn("stop", typeof(System.DateTime), ""));
                T.Columns.Add(new DataColumn("paridsor", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("paridsubclass", typeof(System.Int16), ""));
                T.Columns.Add(new DataColumn("noupdate", typeof(System.Int32), ""));
                T.Columns.Add(new DataColumn("nodelete", typeof(System.Int32), ""));
                D.Tables.Add(T);

                SimulateCalcAutoClassesDataSet_S = D;
            }

        }

        DataSet SimulateCalcAutoClasses(string IoE, object esercizio, object idmov, object idreg, object idupb, object nphase, object idfin,
                object idman, object amount, object idsor, object idsubclass, object classifamount, object description,
                object flagnodate, object @flagnocompleted, object start, object stop,
            object valueN1, object valueN2, object valueN3, object valueN4, object valueN5,
            object valueS1, object valueS2, object valueS3, object valueS4, object valueS5,
            object valueV1, object valueV2, object valueV3, object valueV4, object valueV5) {
            ReadmySortTranslation();
            int I_idsor = CfgFn.GetNoNullInt32(idsor);
            if (I_idsor == 0) return null;
            //Devo prendere le righe di mySortTranslation dove idsortingmaster=idsor
            // e che abbiano nphaseincome/expense not null a seconda dei casi,
            // e che abbiano idparentkind <> (idsorkind collegato ad idsor)
            // di queste l'idsor che devo considerare è l'idsortingchild
            if (!mySortTranslation.ContainsKey(I_idsor)) return null;
            object idkind_related = Cache.sorting.ReadValuesFor(idsor)["idsorkind"];

            string idmovname = (IoE == "I" ? "idinc" : "idexp");
            CreateSimulateCalcAutoClassesDataSet(IoE);
            createMasterChildSorting(IoE);
            DataSet D = IoE == "I" ? SimulateCalcAutoClassesDataSet_E.Clone() : SimulateCalcAutoClassesDataSet_S.Clone();
            DataTable T= D.Tables[0];            
            foreach (DataRow R in mySortTranslation[I_idsor]) {
                if (IoE == "I" && R["nphaseincome"] == DBNull.Value) continue;
                if (IoE == "E" && R["nphaseexpense"] == DBNull.Value) continue;
                if (R["idparentkind"].ToString() == idkind_related.ToString()) continue;

                DataRow n = T.NewRow();
                n[idmovname] = idmov;
                n["idsorkind"] = R["idsorkind"];
                n["idsor"] = R["idsortingchild"];
                n["idsubclass"] = 1;
                if (R["numerator"] == DBNull.Value && R["denominator"] == DBNull.Value) {
	                n["amount"] = CfgFn.GetNoNullDouble(classifamount);
                }
                else {
	                n["amount"] = CfgFn.GetNoNullDouble(classifamount) * CfgFn.GetNoNullDouble(R["numerator"]) /
	                              CfgFn.GetNoNullDouble(R["denominator"]);
                }

                n["description"] = "classificato automaticamente";
                n["txt"] = DBNull.Value;
                n["rtf"] = DBNull.Value;
                n["cu"] = "ASSISTENZA";
                n["lu"] = "ASSISTENZA";
                n["ct"] = DateTime.Now;
                n["lt"] = DateTime.Now;
                n["flagnodate"] = R["flagnodate"];
                n["tobecontinued"] ="N";
                n["start"] = start;
                n["stop"] = stop;
                for (int i = 1; i <= 5; i++) {
                    if (R["defaultn" + i.ToString()].ToString() == "@") {
                        n["valuen" + i.ToString()] = n["amount"];
                    }
                    else {
                        n["valuen" + i.ToString()] = 0;
                    }
                    n["values" + i.ToString()] = R["defaults" + i.ToString()];
                    if (R["defaultv" + i.ToString()].ToString() == "@") {
                        n["valuev" + i.ToString()] = n["amount"];
                    }
                    else {
                        n["valuev" + i.ToString()] = 0;
                    }
                }
                n["ayear"] = esercizio;
                n["paridsorkind"] = DBNull.Value;
                n["paridsor"] = idsor;
                n["paridsubclass"] = idsubclass;
                T.Rows.Add(n);
            }
            Dictionary<int, int> masterChild = IoE == "I" ? masterChildSorting_E : masterChildSorting_S;
            if (masterChild.ContainsKey(I_idsor)) {
                int idsorchild = masterChild[I_idsor];
                DataRow n = T.NewRow();
                n["idsorkind"] = Cache.sorting.ReadValuesFor(idsorchild)["idsorkind"];
                n["idsor"]=  idsorchild;
                n[idmovname]= idmov;
		        n["idsubclass"]=1;
                n["amount"]= classifamount;
                n["description"] = "classificato automaticamente";
                n["txt"] = DBNull.Value;
                n["rtf"] = DBNull.Value;
                n["cu"] = "ASSISTENZA";
                n["lu"] = "ASSISTENZA";
                n["ct"] = DateTime.Now;
                n["lt"] = DateTime.Now;
                n["flagnodate"] = "S";
                n["tobecontinued"] ="N";
                n["start"] = start;
                n["stop"] = stop;
                for (int i = 1; i <= 5; i++) {
                    n["valuen" + i.ToString()] = 0;
                    n["values" + i.ToString()] = DBNull.Value;
                    n["valuev" + i.ToString()] = 0;
                    
                }
                n["ayear"] = esercizio;
                n["paridsorkind"] = idkind_related;
                n["paridsor"] = idsor;
                n["paridsubclass"] = idsubclass;
                T.Rows.Add(n);
            }
            return D;
        }

        Dictionary<int, int> masterChildSorting_E = null;
        Dictionary<int, int> masterChildSorting_S = null;
        void createMasterChildSorting(string IoE) {
            if (masterChildSorting_E == null && IoE == "I") {
                masterChildSorting_E = new Dictionary<int, int>();
                DataTable T = Conn.SQLRunner(
                    "SELECT S1.idsor as idsormaster, S2.idsor as idsorchild " +
                    " from sorting S1 " +
                    " JOIN sortingkind SKmaster	ON SKmaster.idsorkind = S1.idsorkind " +
                    " join sortingkind SKchild 	on SKchild.idparentkind= SKmaster.idsorkind " +
                    " join sorting S2 on S2.idsorkind=SKchild.idsorkind and S1.sortcode=S2.sortcode and S1.movkind=S2.movkind " +
                    " WHERE ISNULL(SKchild.active,'S')='S' 	AND SKmaster.nphaseincome is not null ", true);
                foreach (DataRow r in T.Rows) {
                    masterChildSorting_E.Add(CfgFn.GetNoNullInt32(r["idsormaster"]),CfgFn.GetNoNullInt32(r["idsorchild"]));
                }
            }
            if (masterChildSorting_S == null && IoE == "E") {
                masterChildSorting_S = new Dictionary<int, int>();
                DataTable T = Conn.SQLRunner(
                    "SELECT S1.idsor as idsormaster, S2.idsor as idsorchild " +
                    " from sorting S1 " +
                    " JOIN sortingkind SKmaster	ON SKmaster.idsorkind = S1.idsorkind " +
                    " join sortingkind SKchild 	on SKchild.idparentkind= SKmaster.idsorkind " +
                    " join sorting S2 on S2.idsorkind=SKchild.idsorkind and S1.sortcode=S2.sortcode and S1.movkind=S2.movkind " +
                    " WHERE ISNULL(SKchild.active,'S')='S' 	AND SKmaster.nphaseexpense is not null ", true);
                foreach (DataRow r in T.Rows) {
                    masterChildSorting_S.Add(CfgFn.GetNoNullInt32(r["idsormaster"]), CfgFn.GetNoNullInt32(r["idsorchild"]));
                }
            }

        }



		/// <summary>
		/// Calcola le classificazioni automatiche sulla base della traduzione classificazioni (dello stesso movimento)
		/// </summary>
		/// <param name="CurrImpClass"></param>
		void CalcAutoClasses(DataRow CurrImpClass, DataRow CurrTipoClass,
			DataRow CurrMov, DataRow CurrImputazioneMov, DataTable ImpClass) {

			int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
			string movtable = CurrMov.Table.TableName;
			string idmovimento = movtable == "expense" ? "idexp" : "idinc";

			object IDForSP = DBNull.Value;
			//if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];
			if (CurrMov.RowState != DataRowState.Added) IDForSP = CurrMov[idmovimento];

			DataSet OutDS;
			try {
				OutDS=	SimulateCalcAutoClasses(movtable=="expense"?"E":"I",	  
									Conn.GetSys("esercizio"),
									IDForSP,
									CurrMov["idreg"],
									CurrImputazioneMov["idupb"],
									currfase,
									CurrImputazioneMov["idfin"],
									CurrMov["idman"],
									CurrImputazioneMov["amount"],
                                    //CurrImpClass["idsorkind"],
									CurrImpClass["idsor"],
									CurrImpClass["idsubclass"],
									CurrImpClass["amount"],
									CurrImpClass["description"],
									CurrImpClass["flagnodate"],
									CurrImpClass["tobecontinued"],
									CurrImpClass["start"],
									CurrImpClass["stop"],
									CurrImpClass["valueN1"],
									CurrImpClass["valueN2"],
									CurrImpClass["valueN3"],
									CurrImpClass["valueN4"],
									CurrImpClass["valueN5"],
									CurrImpClass["valueS1"],
									CurrImpClass["valueS2"],
									CurrImpClass["valueS3"],
									CurrImpClass["valueS4"],
									CurrImpClass["valueS5"],
									CurrImpClass["valueV1"],
									CurrImpClass["valueV2"],
									CurrImpClass["valueV3"],
									CurrImpClass["valueV4"],
									CurrImpClass["valueV5"]
								);
			}
			catch (Exception E) {
				MessageBox.Show(E.Message);
				return;
			}
			if ((OutDS==null)||(OutDS.Tables.Count==0)) return; //no autoclass
         	RowChange.MarkAsAutoincrement(
				ImpClass.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(ImpClass, "idsorkind");
			RowChange.SetSelector(ImpClass, idmovimento);
			RowChange.SetSelector(ImpClass, "idsor");

			DataTable AutoClasses = OutDS.Tables[0];
			//for every row in OutDS.Tables[0]:
			// - add row to impclassspesa
			// - evaluates temporary AutoIncrement fields
			foreach (DataRow AutoClass in AutoClasses.Rows) {
				DataRow MyDR =  ImpClass.NewRow();
				foreach(DataColumn DC in ImpClass.Columns) {
					if (DC.ColumnName.StartsWith("!")) continue;
				    if (!AutoClasses.Columns.Contains(DC.ColumnName)) continue;
					MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
				}
            
				if (MyDR[idmovimento]==DBNull.Value) 
					MyDR[idmovimento]= CurrMov[idmovimento];

				RowChange.CalcTemporaryID(MyDR);
				ImpClass.Rows.Add(MyDR);	
				GestioneClassificazioni.CalcFlag(Conn, MyDR, AutoClass["idsorkind"]);
			}
		}
		private Dictionary<int, bool> siopeClassUsed = new Dictionary<int, bool>();

		public void markIdsorAsSiope(object idsor) {
			if (idsor == null) return;
			if (idsor == DBNull.Value) return;
			siopeClassUsed[CfgFn.GetNoNullInt32(idsor)] = true;
		}

		private bool prefilledIncome = false;
		private bool prefilledExpense = false;

		public void prefillSiopeSorting(bool entrate) {
			if (prefilledIncome && entrate) return;
			if (prefilledExpense && (entrate == false)) return;
			if (entrate) {
				prefilledIncome = true;
			} else {
				prefilledExpense = true;
			}

			object codesorkind = entrate
				? Conn.Security.GetSys("codesorkind_siopeentrate")
				: Conn.Security.GetSys("codesorkind_siopespese");
			object idsorkind = Conn.readValue("sortingkind", q.eq("codesorkind", codesorkind), "idsorkind");
			if (idsorkind == null || idsorkind == DBNull.Value) return;
			var tSorting =  Conn.readFromTable("sorting", q.eq("idsorkind", idsorkind));
			foreach (DataRow r in tSorting.Rows) {
				siopeClassUsed[CfgFn.GetNoNullInt32(r["idsor"])] = true;
			}
		}


		static DataTable callSp(DataAccess Conn, List<string> idUpbList) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista AS string_list;");
			int currblockLen = 0;
			foreach (string id in idUpbList) {
				if (currblockLen == 0) {
					sb.Append($"insert into @lista values ('{id}')");
				} else {
					sb.Append($",('{id}')");
				}

				currblockLen++;
				if (currblockLen == 20) {
					sb.AppendLine(";");
					currblockLen = 0;
				}
			}
			if (currblockLen > 0) sb.AppendLine(";");
			sb.AppendLine($"exec  get_upb_info @lista");
			return Conn.SQLRunner(sb.ToString());
		}

		

		private Dictionary<string, DataRow> UpbUsed = new Dictionary<string, DataRow>();

		/// <summary>
		/// Rifinisce le righe della tabella ImpClass per adeguare gli importi in base all'upb
		/// </summary>
		/// <param name="DS_toclassify"></param>
		/// <remarks>siopeClassUsed deve essere pre-riempita con le class.siope usate</remarks>
		public void completaClassificazioniSiope(DataTable impClass, DataSet DS_toclassify) {
			//Prendiamo le righe che stanno in ImpClass il cui "idsor" è incluso in siopeClassUsed, dictionary degli idsor Siope 
			string tableName = impClass.TableName;
			if (tableName == "incomesorted") return; // Disabilitiamo la gestione DATI ARCONET per la SIOPE Entrate

			string idMovField = (tableName == "incomesorted") ? "idinc" : "idexp";

			string ImpMovYear = (tableName == "incomesorted") ? "incomeyear" : "expenseyear";
			if (!DS_toclassify.Tables.Contains(ImpMovYear)) return; //Il ds non contiene l'imputazione del movimento, non è possibile integrare

            // siopeClassUsed non è mai null
            // UpbUsed non è mai null

			var IdMov_IdUpb = new Dictionary<int, string>();

			if (impClass.Rows.Count == 0) return;
			foreach (DataRow impRow in impClass.Rows) {
				//Nel dictionary mettiamo solo gli idmov associati a classificazioni siope 
				if (impRow.RowState == DataRowState.Deleted) continue;
				if (impRow.RowState != DataRowState.Added) continue;
				int idsor = CfgFn.GetNoNullInt32(impRow["idsor"]);
				int idmov = CfgFn.GetNoNullInt32(impRow[idMovField]);
				if ((siopeClassUsed.ContainsKey(idsor)) && (!IdMov_IdUpb.ContainsKey(idmov))) IdMov_IdUpb.Add(idmov, "");

			}

			var listaUpbMancanti = new List<string>();

			foreach (DataRow row in DS_toclassify.Tables[ImpMovYear].Rows) {
				//cerca le righe mancanti nel dictionary rispetto a quelle usate col siope
				string idupb = row["idupb"].ToString();
				int idmov = CfgFn.GetNoNullInt32(row[idMovField]);
				if (IdMov_IdUpb.ContainsKey(idmov)) IdMov_IdUpb[idmov] = idupb;
				if (!UpbUsed.ContainsKey(idupb)) {
					UpbUsed[idupb] = null;
					listaUpbMancanti.Add(idupb);
				}
			}

			if (listaUpbMancanti.Count > 0) {
				DataTable T = callSp(Conn, listaUpbMancanti);
				if (T != null && T.Columns.Contains("codeupb")) {
					foreach (DataRow row in T.Rows) {
						string idupb = row["idupb"].ToString();
						UpbUsed[idupb] = row;
					}
				}
			}

			//Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati
			foreach (DataRow impClassRow in impClass.Rows) {
				if (impClassRow.RowState == DataRowState.Deleted) continue;
				int idsor = CfgFn.GetNoNullInt32(impClassRow["idsor"]);
				int idmov = CfgFn.GetNoNullInt32(impClassRow[idMovField]);
				if ((siopeClassUsed.ContainsKey(idsor)) &&
				    ((tableName == "expensesorted") || (tableName == "incomesorted") ||
				     (tableName == "pettycashsorted"))) {

					if (IdMov_IdUpb.ContainsKey(idmov)) {
						string idupb = IdMov_IdUpb[idmov];
						if (UpbUsed.ContainsKey(idupb)) {
							DataRow rUpb = UpbUsed[idupb];
							if (rUpb == null) continue;
							if (rUpb["uesiopecode"] != DBNull.Value) {
								impClassRow["values1"] = rUpb["uesiopecode"];
							}

							if (rUpb["cofogmpcode"] != DBNull.Value) {
								impClassRow["values2"] = rUpb["cofogmpcode"];
							}
						}
					}
				}
			}

			//caso ExpenseSorted/IncomeSorted
			//Per ognuna di queste righe aggiungiamo il relativo idexp/idinc ad un dictionary int-string (che sarebbe l'idupb) con valore stringa vuota come "value" (dic1)

			//per ogni riga di expenseyear/incomeyear vediamo : se l'idexp/inc è incluso nel dictionary di sopra (dic1), valorizziamo il "value" da stringa vuota a quello giusto

			//Ci costruiamo un dictionary<string,bool> di upb "utilizzati" partendo da un dict. vuoto e poi aggiungendo tutti quelli usati come value in dic1

			//A questo punto abbiamo tutti gli idupb distinti usati e questi li diamo in pasto ad una sp che ci dia i valori desiderati - > otteniamo una tabella con chiave idupb
			//ci costruiamo con questa tabella un dictionari string-datarow  dove string è l'idupb e datarow è la riga della tabella  (dic2)

			//Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati

		}

		/// <summary>
		/// Classifica in base a "Configurazione classificazione automatica spese" e "classificazioni dipendenti"
		///  i movimenti che non siano già classificati secondo quei tipi class.
		/// </summary>
		/// <param name="Auto"></param>
		/// <param name="allmov"></param>
		public void GeneraClassificazioniAutomatiche(DataSet Auto,bool allmov) {
			QueryCreator.MarkEvent("GeneraClassificazioniAutomatiche");
			GeneraClassificazioniAutomatichePerAutomatismi(Auto, "income",allmov);
			GeneraClassificazioniAutomatichePerAutomatismi(Auto, "expense",allmov);
			 // Disabilitiamo la gestione DATI ARCONET per la SIOPE Entrate

			//if (Auto.Tables.Contains("incomesorted")) {
			//	prefillSiopeSorting(true);
			//	completaClassificazioniSiope(Auto.Tables["incomesorted"], Auto);
			//}
			siopeClassUsed.Clear();
			if (Auto.Tables.Contains("expensesorted")) {
				prefillSiopeSorting(false);
				completaClassificazioniSiope(Auto.Tables["expensesorted"], Auto);
			}
			SmistaClassificazioni(Auto, "income");
            SmistaClassificazioni(Auto, "expense");
			
		}

        void SmistaClassificazioni (DataSet Auto,string movkind) {
			QueryCreator.MarkEvent($"SmistaClassificazioni(Auto,{movkind})");
            if (Auto.Tables[movkind] == null) return;
            if (Auto.Tables[movkind + "sorted"] == null) return;
            DataTable T = Auto.Tables[movkind];
            DataTable TSorted = Auto.Tables[movkind + "sorted"];
            string idmovimento = movkind == "expense" ? "idexp" : "idinc";

            Cache.sorting.ReadValuesRelatedTo(TSorted.Select(), "idsor");
            Dictionary<int, DataRow> rowById = new Dictionary<int, DataRow>();
            foreach (DataRow RSorted in T.Select()) {
                rowById[(int) RSorted[idmovimento]] = RSorted;
            }

            foreach (DataRow RSorted in TSorted.Select()) {
                object idsorkind = Cache.sorting.ReadValuesFor(RSorted["idsor"])["idsorkind"];

                string filter= QHC.CmpEq("idsorkind", idsorkind);
                if (AllTipoClassMov.Select(filter).Length == 0) {
                    //MessageBox.Show($"Tipo classificazione {idsorkind} non trovato o non utilizzabile", "Errore");
                    continue;                    
                }
                DataRow TipoR = AllTipoClassMov.Select(filter)[0];
                int nphase_sorting;

                DataRow rFound = null;
                if (!rowById.TryGetValue((int)RSorted[idmovimento],out rFound))continue;
                int nphase_mov = CfgFn.GetNoNullInt32(rFound["nphase"]);
                if (movkind == "expense") {
                    nphase_sorting = CfgFn.GetNoNullInt32(TipoR["nphaseexpense"]);
                    if (nphase_mov!=nphase_sorting)
                        AssegnaRigaAClassSpesa(Auto, RSorted, rFound, nphase_sorting);
                }
                else {
                    nphase_sorting = CfgFn.GetNoNullInt32(TipoR["nphaseincome"]);
                    if (nphase_mov != nphase_sorting)
                        AssegnaRigaAClassEntrata(Auto, RSorted, rFound, nphase_sorting);
                }
                
            }
        }

        void AssegnaRigaAClassEntrata (DataSet Auto, DataRow RSorted, DataRow R, int nphase) {
            if (Auto.Tables["income"] == null) return;
            object idinc = R["idinc"];
            DataTable T = Auto.Tables["income"];
            string childfilter = QHC.CmpEq("parentidinc", idinc);
            DataRow[] childs = T.Select(childfilter);
            if (childs.Length == 0) {
                RSorted.Delete();
                return;
            }
            if (CfgFn.GetNoNullInt32(childs[0]["nphase"]) != nphase)
                AssegnaRigaAClassEntrata(Auto, RSorted, childs[0], nphase);
            else 
                RSorted["idinc"] = childs[0]["idinc"];
        }


        void AssegnaRigaAClassSpesa (DataSet Auto, DataRow RSorted, DataRow R, int nphase) {
            if (Auto.Tables["expense"] == null) return;
            object idexp = R["idexp"];
            DataTable T = Auto.Tables["expense"];
            string childfilter = QHC.CmpEq("parentidexp", idexp);
            DataRow[] childs = T.Select(childfilter);
            if (childs.Length == 0) {
                RSorted.Delete();
                return;
            }
            if (CfgFn.GetNoNullInt32(childs[0]["nphase"]) != nphase)
                AssegnaRigaAClassSpesa(Auto, RSorted, childs[0], nphase);
            else
                RSorted["idexp"] = childs[0]["idexp"];
        }

		void GeneraClassificazioniRit(DataSet Auto, DataRow CurrMov, int codiceprestazione){
			DataTable AutoRit= Conn.RUN_SELECT("taxsortingsetup","*",null,	
                QHS.CmpEq("ayear",Conn.GetSys("esercizio")),null,true);

            //Se manca la configurazione delle ritenute, opera come se fossero movimenti normali, ossia valgono le class.automatiche
            // per i mov. di spesa e (modifica recente) le class. dipendenti
			if (AutoRit.Rows.Count == 0) {
                //GeneraClassificazioniAutomatiche(Auto,false);
				return;
			}


			//Genera le class.automatiche per ogni automatismo di entrata/spesa
			MetaData MetaImpClassEntrata= Disp.Get("incomesorted");
			DataTable ImpClassEntrata= Auto.Tables["incomesorted"];
			MetaImpClassEntrata.SetDefaults(ImpClassEntrata);
			MetaData MetaImpClassSpesa= Disp.Get("expensesorted");
			DataTable ImpClassSpesa= Auto.Tables["expensesorted"];
			MetaImpClassSpesa.SetDefaults(ImpClassSpesa);
			if (AllTipoClassMov==null) AllTipoClassMov = Conn.RUN_SELECT("sortingkind",
										   "idsorkind, nphaseincome, nphaseexpense",null,null,null,true);

            string filter_T = QHC.CmpEq("idpayment", CurrMov["idexp"]);
			
			//Esaminiamo le REVERSALI per le RITENUTE
			if (Auto.Tables["income"]!=null){
				DataTable T= Auto.Tables["income"];
				foreach(DataRow R in T.Select(filter_T)){
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
					if (idautokind!=IDAUTOKIND_RITENUTA)continue;
					int codicerit= CfgFn.GetNoNullInt32( R["autocode"]);
                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    string filtercoderit = QHC.AppAnd(filterrit,  QHC.CmpEq("idser", codiceprestazione));
					DataRow []Found= AutoRit.Select(filtercoderit);
					if ((Found==null)||(Found.Length==0)){
						Found= AutoRit.Select(QHC.AppAnd(filterrit,QHC.IsNull("idser")));
					}
					if (Found==null) continue;

                    DataRow Rincomeyear = Auto.Tables["incomeyear"].Select(QHC.CmpEq("idinc", R["idinc"]))[0];
                    object amount = Rincomeyear["amount"];

                    foreach(DataRow AR in Found){
						//Genera una class. automatica
						object tipoclass=AR["idsorkind"];
						if (tipoclass==DBNull.Value)continue;

						object idclass= AR["idsor_employproc"];
						if (idclass==DBNull.Value)continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
						DataRow TipoR= AllTipoClassMov.Select(filtertipoclass)[0];
						if (!TipoR["nphaseincome"].Equals(R["nphase"]))continue;

						//MetaData.SetDefault(ImpClassEntrata,"idsorkind",tipoclass);
						MetaData.SetDefault(ImpClassEntrata,"idsor",idclass);
						DataRow RImp=MetaImpClassEntrata.Get_New_Row(R,ImpClassEntrata);

                        RImp["amount"] = amount; 

                        //Meta_impclassentrata.CalcFlag(R);
						GestioneClassificazioni.CalcFlag(Conn,RImp, tipoclass);
					}
				}
			}

			//Esaminiamo le REVERSALI per i CONTRIBUTI
			if (Auto.Tables["income"]!=null){
				DataTable T= Auto.Tables["income"];
				foreach(DataRow R in T.Select(filter_T)){
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_CONTRIBUTO) continue;
					object codicerit= R["autocode"];
                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    string filtercoderit = QHC.AppAnd(filterrit,  QHC.CmpEq("idser", codiceprestazione));
					DataRow []Found= AutoRit.Select(filtercoderit);
					if ((Found==null)||(Found.Length==0)){
                        Found = AutoRit.Select(QHC.AppAnd(filterrit, QHC.IsNull("idser")));
                    }
					if (Found==null)continue;
                    
                    DataRow Rincomeyear = Auto.Tables["incomeyear"].Select(QHC.CmpEq("idinc", R["idinc"]))[0];
                    object amount = Rincomeyear["amount"];

					foreach(DataRow AR in Found){
						//Genera una class. automatica
                        object tipoclass = AR["idsorkind"];
                        if (tipoclass == DBNull.Value) continue;

                        object idclass = AR["idsor_adminproc"];
                        if (idclass == DBNull.Value) continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                        DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
                        if (!TipoR["nphaseincome"].Equals(R["nphase"])) continue;

                        //MetaData.SetDefault(ImpClassEntrata,"idsorkind",tipoclass);
						MetaData.SetDefault(ImpClassEntrata,"idsor",idclass);
						DataRow RImp=MetaImpClassEntrata.Get_New_Row(R,ImpClassEntrata);
						//Meta_impclassentrata.CalcFlag(R);
						GestioneClassificazioni.CalcFlag(Conn,RImp, tipoclass);
                        RImp["amount"] = amount; 
					}
				}
			}


			//Esaminiamo i PAGAMENTI  per i CONTRIBUTI
			if (Auto.Tables["expense"]!=null){
				DataTable T= Auto.Tables["expense"];
				foreach(DataRow R in T.Select(filter_T)){
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_CONTRIBUTO) continue;
                    object codicerit = R["autocode"];

                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    string filtercoderit = QHC.AppAnd(filterrit, QHC.CmpEq("idser", codiceprestazione));
                    DataRow[] Found = AutoRit.Select(filtercoderit);
					if ((Found==null)||(Found.Length==0)){
                        Found = AutoRit.Select(QHC.AppAnd(filterrit, QHC.IsNull("idser")));
                    }
					if (Found==null)continue;

                    DataRow Rexpenseyear = Auto.Tables["expenseyear"].Select(QHC.CmpEq("idexp", R["idexp"]))[0];
                    object amount = Rexpenseyear["amount"];

                    foreach(DataRow AR in Found){
						//Genera una class. automatica 
                        object tipoclass = AR["idsorkind"];
                        if (tipoclass == DBNull.Value) continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                        DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
						if (!TipoR["nphaseexpense"].Equals(R["nphase"]))continue;

                        object[] idclass = new object[] { AR["idsor_adminpay"] };
                        object idexp_toconsider = R["idpayment"];
                        if (idexp_toconsider == DBNull.Value) idexp_toconsider = R["parentidexp"];
                        if ((AR["flaginherit"].ToString().ToUpper() == "S") && (idexp_toconsider != DBNull.Value)) {
                            DataRow[] ImpMain = GetRowPhase(Conn, Auto,
                                CfgFn.GetNoNullInt32(R["nphase"]), idexp_toconsider, tipoclass,"expense");

                            if (ImpMain.Length > 0) {
                                idclass = ImpMain;
                            }
                            else {
                                idclass[0] = DBNull.Value;
                            }
							
						}
                        if (idclass[0] == DBNull.Value) continue;
                        if (!idclass[0].GetType().IsAssignableFrom(typeof(DataRow))) {
                            //MetaData.SetDefault(ImpClassSpesa,"idsorkind",tipoclass);
                            MetaData.SetDefault(ImpClassSpesa, "idsor", idclass[0]);
                            DataRow RImp = MetaImpClassSpesa.Get_New_Row(R, ImpClassSpesa);

                            RImp["amount"] = amount;

                            RImp["description"] = "classificato automaticamente ";
                            //Meta_impclassspesa.CalcFlag(R);
                            GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                        }
                        else {
                            decimal totmov_parent = 0;
                            decimal tot_currclass = 0;
                            foreach (DataRow Rpar in idclass) {
                                totmov_parent += CfgFn.GetNoNullDecimal(Rpar["amount"]);
                            }
                            DataRow LastClass = null;
                            decimal curramount = CfgFn.GetNoNullDecimal(amount);
                            foreach (DataRow idclass_curr in idclass) {
                                object myid = idclass_curr["idsor"];
                                decimal originalclass_amount = CfgFn.GetNoNullDecimal(idclass_curr["amount"]);
                                decimal amount_toclass = 0;
                                if (totmov_parent > 0)
                                    amount_toclass = (curramount * originalclass_amount) / totmov_parent;
                                tot_currclass += amount_toclass;
                                MetaData.SetDefault(ImpClassSpesa, "idsor", myid);
                                DataRow RImp = MetaImpClassSpesa.Get_New_Row(R, ImpClassSpesa);

                                RImp["amount"] = amount_toclass;
                                if (idclass.Length>1)
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento multiclassificato)";
                                else
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento )";
                                //Meta_impclassspesa.CalcFlag(R);
                                GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                                LastClass = RImp;
                            }
                            if (LastClass != null && tot_currclass != curramount) {
                                LastClass["amount"] = CfgFn.GetNoNullDecimal(LastClass["amount"]) +
                                                        (curramount - tot_currclass);
                            }
                        }
                        
					}
					
				}
			}



            //Esaminiamo i PAGAMENTI  per RITENUTE NEGATIVE (ED ESEMPIO BONUS FISCALE ecc.)
            if (Auto.Tables["expense"] != null) {
                DataTable T = Auto.Tables["expense"];
                foreach (DataRow R in T.Select(filter_T)) {
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_RITENUTA) continue;
                    object codicerit = R["autocode"];

                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    string filtercoderit = QHC.AppAnd(filterrit, QHC.CmpEq("idser", codiceprestazione));
                    DataRow[] Found = AutoRit.Select(filtercoderit);
                    if ((Found == null) || (Found.Length == 0)) {
                        Found = AutoRit.Select(QHC.AppAnd(filterrit, QHC.IsNull("idser")));
                    }
                    if (Found == null) continue;

                    DataRow Rexpenseyear = Auto.Tables["expenseyear"].Select(QHC.CmpEq("idexp", R["idexp"]))[0];
                    object amount = Rexpenseyear["amount"];

                    foreach (DataRow AR in Found) {
                        //Genera una class. automatica 
                        object tipoclass = AR["idsorkind"];
                        if (tipoclass == DBNull.Value) continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                        DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
                        if (!TipoR["nphaseexpense"].Equals(R["nphase"])) continue;

                        object[] idclass = new object[] { AR["idsor_employpay"] };
                        
                        if (idclass[0] == DBNull.Value) continue;
                        if (!idclass[0].GetType().IsAssignableFrom(typeof(DataRow))) {
                            //MetaData.SetDefault(ImpClassSpesa,"idsorkind",tipoclass);
                            MetaData.SetDefault(ImpClassSpesa, "idsor", idclass[0]);
                            DataRow RImp = MetaImpClassSpesa.Get_New_Row(R, ImpClassSpesa);

                            RImp["amount"] = amount;

                            RImp["description"] = "classificato automaticamente ";
                            //Meta_impclassspesa.CalcFlag(R);
                            GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                        }
                        else {
                            decimal totmov_parent = 0;
                            decimal tot_currclass = 0;
                            foreach (DataRow Rpar in idclass) {
                                totmov_parent += CfgFn.GetNoNullDecimal(Rpar["amount"]);
                            }
                            DataRow LastClass = null;
                            decimal curramount = CfgFn.GetNoNullDecimal(amount);
                            foreach (DataRow idclass_curr in idclass) {
                                object myid = idclass_curr["idsor"];
                                decimal originalclass_amount = CfgFn.GetNoNullDecimal(idclass_curr["amount"]);
                                decimal amount_toclass = 0;
                                if (totmov_parent > 0)
                                    amount_toclass = (curramount * originalclass_amount) / totmov_parent;
                                tot_currclass += amount_toclass;
                                MetaData.SetDefault(ImpClassSpesa, "idsor", myid);
                                DataRow RImp = MetaImpClassSpesa.Get_New_Row(R, ImpClassSpesa);

                                RImp["amount"] = amount_toclass;
                                if (idclass.Length > 1)
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento multiclassificato)";
                                else
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento )";
                                //Meta_impclassspesa.CalcFlag(R);
                                GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                                LastClass = RImp;
                            }
                            if (LastClass != null && tot_currclass != curramount) {
                                LastClass["amount"] = CfgFn.GetNoNullDecimal(LastClass["amount"]) +
                                                        (curramount - tot_currclass);
                            }
                        }

                    }

                }
            }


            //Esaminiamo le var. di AUMENTO per i CONTRIBUTI
            if (Auto.Tables["expensevar"]!=null){
				DataTable T= Auto.Tables["expensevar"];


				foreach(DataRow R in T.Select(filter_T)){
					int idspesa=CfgFn.GetNoNullInt32( R["idexp"]);
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_CONTRIBUTO) continue;
                    object codicerit = R["autocode"];

                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    string filtercoderit = QHC.AppAnd(filterrit, QHC.CmpEq("idser", codiceprestazione));
                    DataRow[] Found = AutoRit.Select(filtercoderit);
					if ((Found==null)||(Found.Length==0)){
                        Found = AutoRit.Select(QHC.AppAnd(filterrit, QHC.IsNull("idser")));
                    }
					if (Found==null)continue;

                    foreach (DataRow AR in Found) {
                        //Genera una class. automatica
                        object tipoclass = AR["idsorkind"];
                        if (tipoclass == DBNull.Value) continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                        DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
                        int rPhase = Cache.GetCachedExpensePhase(Conn, Auto.Tables["expense"], CfgFn.GetNoNullInt32(R["idexp"]));
                        if (CfgFn.GetNoNullInt32(TipoR["nphaseexpense"]) != rPhase) continue;
                        object[] idclass = new object[] { AR["idsor_adminpay"] };
                        if (AR["flaginherit"].ToString().ToUpper() == "S" && R["idpayment"] != DBNull.Value) {
                            DataRow[] ImpMain = GetRowPhase(Conn, Auto, rPhase, R["idpayment"], tipoclass,"expense");
                            if (ImpMain.Length > 0) {
                                idclass = ImpMain;
                            }
                            else {
                                idclass[0] = DBNull.Value;
                            }

                        }

                        if (idclass[0] == DBNull.Value) continue;
                        if (!idclass[0].GetType().IsAssignableFrom(typeof(DataRow))) {
                            //MetaData.SetDefault(ImpClassSpesa,"idsorkind",tipoclass);
                            MetaData.SetDefault(ImpClassSpesa, "idsor", idclass[0]);
                            MetaData.SetDefault(ImpClassSpesa, "idexp", idspesa);
                            DataRow RImp = MetaImpClassSpesa.Get_New_Row(null, ImpClassSpesa);

                            RImp["amount"] = R["amount"];

                            RImp["description"] = "classificato automaticamente";
                            //Meta_impclassspesa.CalcFlag(R);
                            GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                        }
                        else {
                            decimal totmov_parent = 0;
                            decimal tot_currclass = 0;
                            foreach (DataRow Rpar in idclass) {
                                totmov_parent += CfgFn.GetNoNullDecimal(Rpar["amount"]);
                            }
                            DataRow LastClass = null;
                            decimal curramount = CfgFn.GetNoNullDecimal(R["amount"]);
                            foreach (DataRow idclass_curr in idclass) {
                                object myid = idclass_curr["idsor"];
                                decimal originalclass_amount = CfgFn.GetNoNullDecimal( idclass_curr["amount"]);
                                decimal amount_toclass = 0;
                                if (totmov_parent > 0)
                                    amount_toclass = (curramount * originalclass_amount) / totmov_parent;
                                tot_currclass += amount_toclass;
                                MetaData.SetDefault(ImpClassSpesa, "idsor", myid);
                                MetaData.SetDefault(ImpClassSpesa, "idexp", idspesa);
                                DataRow RImp = MetaImpClassSpesa.Get_New_Row(null, ImpClassSpesa);

                                RImp["amount"] = amount_toclass;

                                if (idclass.Length > 1)
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento multiclassificato)";
                                else
                                    RImp["description"] = "classificato automaticamente (ereditato da movimento )";
                                //Meta_impclassspesa.CalcFlag(R);
                                GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                                LastClass = RImp;
                            }
                            if (LastClass != null && tot_currclass != curramount) {
                                LastClass["amount"] = CfgFn.GetNoNullDecimal(LastClass["amount"]) + 
                                                        (curramount - tot_currclass);
                            }
                        }
                    }
				}
			}

		}
        DataTable AutoRec = null;
        void GeneraClassificazioniRecuperi(DataSet Auto, DataRow CurrMov, object idser) {
            if (AutoRec==null) AutoRec = Conn.RUN_SELECT("autoclawbacksorting", "*", null,
                QHS.CmpEq("ayear", Conn.GetSys("esercizio")), null, true);

            if (AutoRec == null || AutoRec.Rows.Count == 0) {
                //if (idser==DBNull.Value) GeneraClassificazioniAutomatiche(Auto, false);
                return;
            }
            //Genera le class.automatiche per ogni automatismo di entrata/spesa
            MetaData MetaImpClassEntrata = Disp.Get("incomesorted");
            DataTable ImpClassEntrata = Auto.Tables["incomesorted"];
            MetaImpClassEntrata.SetDefaults(ImpClassEntrata);
            MetaData MetaImpClassSpesa = Disp.Get("expensesorted");
            DataTable ImpClassSpesa = Auto.Tables["expensesorted"];
            MetaImpClassSpesa.SetDefaults(ImpClassSpesa);
            if (AllTipoClassMov == null) AllTipoClassMov = Conn.RUN_SELECT("sortingkind",
                                             "idsorkind, nphaseincome, nphaseexpense", null, null, null, true);

            string filter_T = QHC.CmpEq("idpayment", CurrMov["idexp"]);

            //Esaminiamo le REVERSALI per i RECUPERI
            if (Auto.Tables["income"] != null) {
                DataTable T = Auto.Tables["income"];
                foreach (DataRow R in T.Select(filter_T)) {
                    int idautokind = CfgFn.GetNoNullInt32(R["autokind"]);
                    if (idautokind != IDAUTOKIND_RECUPERO) continue;
                    object codicerec = CfgFn.GetNoNullInt32(R["autocode"]);
                    string filterrec = QHC.CmpEq("idclawback", codicerec);
                    DataRow[] Found = AutoRec.Select(filterrec);
                    if (Found == null) continue;

                    DataRow Rincomeyear = Auto.Tables["incomeyear"].Select(QHC.CmpEq("idinc", R["idinc"]))[0];
                    object amount = Rincomeyear["amount"];

                    foreach (DataRow AR in Found) {
                        //Genera una class. automatica
                        object tipoclass = AR["idsorkind"];
                        if (tipoclass == DBNull.Value) continue;

                        object idclass = AR["idsor"];
                        if (idclass == DBNull.Value) continue;
                        string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                        DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
                        if (!TipoR["nphaseincome"].Equals(R["nphase"])) continue;

                        //MetaData.SetDefault(ImpClassEntrata,"idsorkind",tipoclass);
                        MetaData.SetDefault(ImpClassEntrata, "idsor", idclass);
                        DataRow RImp = MetaImpClassEntrata.Get_New_Row(R, ImpClassEntrata);

                        RImp["amount"] = amount;

                        //Meta_impclassentrata.CalcFlag(R);
                        GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                    }
                }
            }

        }



        public static DataRow[] GetRowPhase(DataAccess Conn, DataSet Auto, int nphase, object idmov, object idsorkind) {
            return GetRowPhase(Conn, Auto, nphase, idmov, idsorkind, "expense");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="Auto"></param>
        /// <param name="nphase">fase del mov. che deve essere preso</param>
        /// <param name="idexp">idexp del mov. principale</param>
        /// <param name="idsorkind"></param>
        /// <returns></returns>
        /// 
        public static DataRow []GetRowPhase(DataAccess Conn, DataSet Auto, int nphase, object idmov, object idsorkind,string tablename) {
            QueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            string idfield= (tablename=="expense") ?"idexp":"idinc";
            //Inizialmente cerca la riga in Auto
            DataRow[] found = Auto.Tables[tablename].Select(QHC.CmpEq(idfield, idmov));
            if(found.Length == 0) {
                DataRow Main = getRowPhase(Auto.Tables[tablename], idmov, nphase, Conn);
                //Non è in memoria---> deve essere sul db
                //Può fare la select direttamente.
                string filtermain = QHS.AppAnd(QHS.CmpEq(idfield, idmov), QHS.CmpEq("idsorkind", idsorkind));
                //DataTable MainImp = Conn.RUN_SELECT("expensesorted", "*", null, filtermain, null, true);
                DataTable MainImp = Conn.RUN_SELECT(tablename+"sortedview", "idsor,amount", null, filtermain, null, true);
                DataRow[] ImpMain = MainImp.Select();
                return ImpMain;
            }
            else {
                //E' in memoria. 
                //Vede se è della fase cercata
                if(CfgFn.GetNoNullInt32(found[0]["nphase"]) == nphase) {
                    //SI: allora può fare la query in memoria
                    
                    DataTable tSorting = DataAccess.RUN_SELECT(Conn, "sortingusable", "idsor", "idsor", QHS.CmpEq("idsorkind", idsorkind),
                        null, null, true);
                    if (tSorting == null) {
                        return new DataRow[0];
                    }
                    DataRow []MemFound= Auto.Tables[tablename+"sorted"].Select(
                        QHC.AppAnd(QHC.CmpEq(idfield, idmov), QHC.FieldIn("idsor", tSorting.Select())));
                    return MemFound;
                }
                //No: itera il procedimento ricorsivamente
                if (found[0]["parent" + idfield] == DBNull.Value) return new DataRow[] { }; //Condiz. di errore
                return GetRowPhase(Conn, Auto, nphase, CfgFn.GetNoNullInt32(found[0]["parent" + idfield]), idsorkind, tablename);
            }
        }

        

        void GeneraClassificazioniIndiretteMov(DataSet Auto, string movtable) {
            GeneraClassificazioniIndiretteMov(Auto, movtable, false);

        }


        Dictionary<DataRow, bool> autoclassified = new Dictionary<DataRow, bool>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="movtable"></param>
        /// <param name="classifyallmov">se false non opera sulle class. dei movimenti principali</param>
		void GeneraClassificazioniIndiretteMov(DataSet Auto,string movtable,bool classifyallmov){
			if (Auto.Tables[movtable]==null) return;
			if (AllTipoClassMov==null) AllTipoClassMov = Conn.RUN_SELECT("sortingkind",
										   "idsorkind, nphaseincome, nphaseexpense",null,null,null,true);

			DataTable ImpClass=Auto.Tables[movtable+"sorted"];
			string idmovimento= movtable=="expense" ? "idexp" : "idinc";
			DataRow []ImpClassR= ImpClass.Select();
            Dictionary<int, DataRow> movByID = new Dictionary<int, DataRow>();
            Dictionary<int, DataRow> movYearByID = new Dictionary<int, DataRow>();
            foreach (DataRow r in Auto.Tables[movtable].Rows) {
                movByID[(int) r[idmovimento]] = r;
            }
            foreach (DataRow r in Auto.Tables[movtable+"year"].Rows) {
                movYearByID[(int) r[idmovimento]] = r;
            }

			foreach (DataRow CurrImpClass in ImpClassR){
                if(CurrImpClass.RowState != DataRowState.Added) continue;
			    if (autoclassified.ContainsKey(CurrImpClass))
                    continue;
                autoclassified.Add(CurrImpClass, true);
			    if ((classifyallmov==false) && (Auto.Tables[movtable].Rows.Count==1)) continue;

			    DataRow CurrMov;
                if (!movByID.TryGetValue((int)CurrImpClass[idmovimento],out CurrMov))continue;
                
                if((classifyallmov==false)  && CurrMov["autokind"]==DBNull.Value) continue; //NON OPERA SULLE CLASS. DEI MOV.PRINCIPALI

			    DataRow CurrImputazioneMov;
			    if (!movYearByID.TryGetValue((int)CurrImpClass[idmovimento],out CurrImputazioneMov))continue;

			    
				int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);

				object IDForSP = DBNull.Value;
				if (CurrMov.RowState!=DataRowState.Added) IDForSP= CurrMov[idmovimento];

				DataSet OutDS;
				try {
					OutDS=	SimulateCalcAutoClasses(movtable=="expense"?"E":"I",                        
										Conn.GetSys("esercizio"),
										IDForSP,
										CurrMov["idreg"],
										CurrImputazioneMov["idupb"],
										currfase,
										CurrImputazioneMov["idfin"],
										CurrMov["idman"],
										CurrImputazioneMov["amount"],
                                        //CurrImpClass["idsorkind"],
										CurrImpClass["idsor"],
										CurrImpClass["idsubclass"],
										CurrImpClass["amount"],
										CurrImpClass["description"],
										CurrImpClass["flagnodate"],
										CurrImpClass["tobecontinued"],
										CurrImpClass["start"],
										CurrImpClass["stop"],
										CurrImpClass["valueN1"],
										CurrImpClass["valueN2"],
										CurrImpClass["valueN3"],
										CurrImpClass["valueN4"],
										CurrImpClass["valueN5"],
										CurrImpClass["valueS1"],
										CurrImpClass["valueS2"],
										CurrImpClass["valueS3"],
										CurrImpClass["valueS4"],
										CurrImpClass["valueS5"],
										CurrImpClass["valueV1"],
										CurrImpClass["valueV2"],
										CurrImpClass["valueV3"],
										CurrImpClass["valueV4"],
										CurrImpClass["valueV5"]
									);
				}
				catch (Exception E) {
					MessageBox.Show(E.Message);
					continue;
				}
				if ((OutDS==null)||(OutDS.Tables.Count==0)) continue; //no autoclass

				RowChange.MarkAsAutoincrement(
					ImpClass.Columns["idsubclass"], 
					null,
					null,
					7,
					false);
                //RowChange.SetSelector(ImpClass, "idsorkind");
				RowChange.SetSelector(ImpClass, idmovimento);
				RowChange.SetSelector(ImpClass, "idsor");

				DataTable AutoClasses = OutDS.Tables[0];
				//for every row in OutDS.Tables[0]:
				// - add row to impclassspesa
				// - evaluates temporary AutoIncrement fields
				foreach (DataRow AutoClass in AutoClasses.Rows) {
					object codicetipoclass= AutoClass["idsorkind"];
					if (codicetipoclass == DBNull.Value) continue;
                    string filtertipoclass = QHS.CmpEq("idsorkind", codicetipoclass);
					DataRow TipoR= AllTipoClassMov.Select(filtertipoclass)[0];
					int codicefase= CfgFn.GetNoNullInt32(TipoR["nphase" + movtable]);
					int id_to_consider= CalcRealIDMovimento(
						Auto.Tables[movtable],
						CfgFn.GetNoNullInt32( CurrMov[idmovimento] ), 
						codicefase);
					if (id_to_consider==0) continue; //Non genera la classificazione (manca la fase)!

					DataRow MyDR =  ImpClass.NewRow();
					foreach(DataColumn DC in ImpClass.Columns) {
						if (DC.ColumnName.StartsWith("!")) continue;
					    if (!AutoClasses.Columns.Contains(DC.ColumnName)) continue;
						MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
					}
					///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
					MyDR[idmovimento]= id_to_consider;
					RowChange.CalcTemporaryID(MyDR);
					ImpClass.Rows.Add(MyDR);		
//					if (movtable=="expense")
//						GestioneClassificazioni.CalcFlag(MyDR);
//					else
//						GestioneClassificazioni.CalcFlag(MyDR);
                    GestioneClassificazioni.CalcFlag(Conn, MyDR, codicetipoclass);
				}


			}

		}

        int CalcRealIDMovimento(DataTable Mov, int idmovimento, int fase) {
            DataRow RealR = getRowPhase(Mov, idmovimento,fase, Conn);
            if (RealR == null) return 0;
            string idfield = "id" + Mov.TableName.ToLower().Substring(0, 3);
            return CfgFn.GetNoNullInt32( RealR[idfield]);
 
            //int mylen = fase * 8;
            //string idfield = "id" + Mov.TableName.ToLower().Substring(0, 3);
            //DataRow[] Found = Mov.Select("(" + idfield + " LIKE " +
            //    QueryCreator.quotedstrvalue(idmovimento + "%", false) + ")AND" +
            //    "(len(" + idfield + ")=" + mylen.ToString() + ")");
            //if (Found == null) return null;
            //if (Found.Length != 1) return null;
            //return Found[0][idfield].ToString();
        }


      

        public void GeneraClassificazioniIndirette(DataSet Auto) {
            GeneraClassificazioniIndirette(Auto, false);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="ClassifyAll">se false non opera sulle class. dei movimenti principali</param>
		public void GeneraClassificazioniIndirette(DataSet Auto,bool ClassifyAll){
			GeneraClassificazioniIndiretteMov(Auto,"income",ClassifyAll);
			GeneraClassificazioniIndiretteMov(Auto,"expense",ClassifyAll);
		}

		public void ResetTipoAutomatismo(DataSet Auto){
			foreach (string tabname in new string []{"expense","income","expensevar","incomevar"}){
				DataTable T = Auto.Tables[tabname];
				if (T==null) continue;
				if (T.Columns["autokind"]==null)continue;
				foreach(DataRow R in T.Select()){
					if (R["autokind"].ToString()==IDAUTOKIND_CONTRIBUTO.ToString())
						R["autokind"]=IDAUTOKIND_RITENUTA;
				}
			}
		}
        public void integraCopiaDatiDaDatasetPrincipaleASecondario() {
	        QueryCreator.MarkEvent("integraCopiaDatiDaDatasetPrincipaleASecondario");
            foreach(DataTable t in sourceDataSet.Tables) {
                if (dsAuto.Tables[t.TableName] != null ) continue; //& !t.HasChanges()
                if (!t.HasChanges()) continue;
				//QueryCreator.MarkEvent($"dsAuto.Merge({t.TableName},false,add)");
                dsAuto.Merge(t, false, MissingSchemaAction.Add);
            }
        }

		/// <summary>
		/// Metodo che copia tutti i dati presenti nel DataSet Principale nel DataSet Secondario
		/// </summary>
		/// <param name="dest"></param>
		private void copiaDatiDaDatasetPrincipaleASecondario(DataSet dsSource) {
			QueryCreator.MarkEvent("copiaDatiDaDatasetPrincipaleASecondario");
			foreach(DataTable t in dsSource.Tables) {
				if (dsAuto.Tables[t.TableName] == null ) continue; //& !t.HasChanges()
				//QueryCreator.MarkEvent($"dsAuto.Merge({t.TableName},false,add)");
				dsAuto.Merge(t, false, MissingSchemaAction.Add);
			}
		}

        public static bool hasChanges(DataTable t) {
            if (t == null) return false;
            foreach (DataRow R in t.Rows) {
                if (R.RowState == DataRowState.Unchanged) continue;
                if (R.RowState != DataRowState.Modified) return true;
                if (PostData.CheckForFalseUpdate(R)) {
                    //R.AcceptChanges();
                    continue;
                }
                return true;
            }
            return false;
        }
        private bool aggiungiTabelle(DataSet dsSource) {
			foreach(DataTable t in dsSource.Tables) {
                // Controllo se la tabella è stata modificata
                if (!hasChanges(t)) {
                    continue;
                }
                    // Controllo sull'esistenza della tabella nel dataset di destinazione
                if (dsAuto.Tables[t.TableName] != null) continue;

				string tName = t.TableName;
				dsAuto.Merge(t, false, MissingSchemaAction.AddWithKey);

				aggiungiRelazioni(dsSource, t);
			}
			return true;
		}

		private void addRel(DataRelation r, string tParent, string tChild) {
			string rName = r.RelationName;

			DataColumn [] cParent = new DataColumn [r.ParentColumns.Length];
			for(int i = 0; i < r.ParentColumns.Length; i++) {
				cParent[i] = dsAuto.Tables[tParent].Columns[r.ParentColumns[i].ColumnName];
			}

			DataColumn [] cChild = new DataColumn [r.ChildColumns.Length];
			for(int j = 0; j < r.ChildColumns.Length; j++) {
				cChild[j] = dsAuto.Tables[tChild].Columns[r.ChildColumns[j].ColumnName];
			}
				
			DataRelation newRel = new DataRelation(rName, cParent, cChild, false);
			dsAuto.Relations.Add(newRel);
		}

		private void aggiungiRelazioni(DataSet dsSource, DataTable tSource) {
			// Ciclo su tutte le relazioni padre rispetto alla tabella tSource -> tSource è figlia nella relazione

			foreach(DataRelation r in tSource.ParentRelations) {
				
				string tParent = r.ParentTable.TableName;
				if (!dsAuto.Tables.Contains(tParent)) continue;
				
				string tChild = r.ChildTable.TableName;
				if (!dsAuto.Tables.Contains(tChild)) continue;
				addRel(r, tParent, tChild);
			}

			// Ciclo su tutte le relazioni figlie rispetto alla tabella tSource -> tSource è padre nella relazione
			foreach(DataRelation r in tSource.ChildRelations) {
				string tParent = r.ParentTable.TableName;
				if (!dsAuto.Tables.Contains(tParent)) continue;
				string rName = r.RelationName;
				string tChild = r.ChildTable.TableName;
				if (!dsAuto.Tables.Contains(tChild)) continue;
				if (tChild == tParent) continue;
				addRel(r, tParent, tChild);
			}
		}

        public bool GeneraAutomatismiAfterPost(bool visualizzaForm) {
            return GeneraAutomatismiAfterPost(visualizzaForm, false);
        }
        /// <summary>
		/// Legge i dati da DSP (DataSet per il Post)
		/// </summary>
		/// <param name="visualizzaForm">FALSE: Non visualizza i form intermedi; TRUE: Può visualizzare i form intermedi</param>
        /// <param name="ClassifyAll">se false non opera sulle class. dei movimenti principali</param>
		/// <returns></returns>
		public bool GeneraAutomatismiAfterPost(bool visualizzaForm, bool ClassifyAll){
			QueryCreator.MarkEvent($"GeneraAutomatismiAfterPost({visualizzaForm},{ClassifyAll})");
			if (!dsAuto.automatismitable.Columns.Contains("livsupid")) {
				dsAuto.automatismitable.Columns.Add("livsupid", typeof(int));
			}
			//Aggiunge una colonna alla tabella automatismi, per mettervi l'idmovimento
			if (!dsAuto.automatismitable.Columns.Contains("idmovimento")) {
				dsAuto.automatismitable.Columns.Add("idmovimento", typeof(int));
			}

            string filter = QHC.CmpEq("nphase", Conn.GetSys("maxexpensephase"));
            DataRow []AllMain=dsAuto.Tables["expense"].Select(filter);
            Dictionary<int,DataRow> impById = new Dictionary<int, DataRow>();
            Dictionary<int,DataRow> lastById = new Dictionary<int, DataRow>();
            foreach (DataRow r in dsAuto.Tables["expenseyear"].Select()) {
                impById[(int) r["idexp"]] = r;
            }
            foreach (DataRow r in dsAuto.Tables["expenselast"].Select()) {
                lastById[(int) r["idexp"]] = r;
            }
            bool OneMainRow = true;
            if(AllMain.Length != 1) OneMainRow = false;
			foreach(DataRow CurrMov in AllMain) {
				dsAuto.automatismitable.Clear();
			    DataRow imp;
			    DataRow last;
                if (impById.TryGetValue((int)CurrMov["idexp"],out imp) &
                        lastById.TryGetValue((int)CurrMov["idexp"],out last)) {
                    if(!RicalcolaAutomatismi(dsAuto.automatismitable, CurrMov,imp,last, visualizzaForm,OneMainRow)) {
                        return false;
                    };                    
                }
			    
				if (dsAuto.automatismitable.Rows.Count==0) continue;
                
				if (!GeneraNuoveRighe(dsAuto, CfgFn.GetNoNullInt32( CurrMov[idmovimento])))return false;
                if (Movimento.TableName == "expense") {
                    if (last != null) {
                        if (last["idser"] != DBNull.Value) {
                            int codiceprestazione = CfgFn.GetNoNullInt32(last["idser"]);
                            GeneraClassificazioniRit(dsAuto, CurrMov, codiceprestazione);
                        }

                        GeneraClassificazioniRecuperi(dsAuto, CurrMov, last["idser"]);
                        GeneraClassificazioniAutomatiche(dsAuto, false);
                    }
                }
			}
			
			GeneraAutoMandatiReversali(dsAuto);
			GeneraClassificazioniIndirette(dsAuto,ClassifyAll);

			ResetTipoAutomatismo(dsAuto);

            //A questo punto svuotando la tabella automatismi getta a mare tutti i dati su codefin,codeupb,registry,manager letti!
			dsAuto.automatismitable.Clear();
			dsAuto.automatismitable.AcceptChanges(); //automatismi è una tab. temporanea
	
			fillSatelliteTable();
			int nAuto = contaAutomatismi();
            int nMainMov = contaMovPrincipali();
            int nvarauto = contaVarAutomatismi();
            bool displaymainmov = viewMainMov || (nvarauto > 0);

            if ((visualizzaForm && (nAuto > 0) && (nMainMov > 0)) || viewMainMov){
                FrmManage_Automatismi ma = new FrmManage_Automatismi(dsAuto, Conn, Disp, displaymainmov, Cache);
				DialogResult dr = ma.ShowDialog();
				if (dr != DialogResult.OK) return false;
			}
			if (dsAuto.Tables.Contains("incomesorted")) {
				prefillSiopeSorting(true);
				completaClassificazioniSiope(dsAuto.Tables["incomesorted"], dsAuto);
			}
			siopeClassUsed.Clear();
			if (dsAuto.Tables.Contains("expensesorted")) {
				prefillSiopeSorting(false);
				completaClassificazioniSiope(dsAuto.Tables["expensesorted"], dsAuto);
			}
			return aggiungiTabelle(sourceDataSet);
		}

        private int contaMovPrincipali(){
            int nmovprincipale = 0;
            string autokindnull = QHC.IsNull("autokind");
            if (dsAuto.Tables.Contains("expense")){
                nmovprincipale += dsAuto.Tables["expense"].Select(autokindnull, null, DataViewRowState.Added).Length;
                nmovprincipale += dsAuto.Tables["expense"].Select(autokindnull, null, DataViewRowState.ModifiedCurrent).Length;
            }

            if (dsAuto.Tables.Contains("income")){
                nmovprincipale += dsAuto.Tables["income"].Select(autokindnull, null, DataViewRowState.Added).Length;
                nmovprincipale += dsAuto.Tables["income"].Select(autokindnull, null, DataViewRowState.ModifiedCurrent).Length;
            }
            return nmovprincipale;
        }

		private int contaAutomatismi() {
			int nAuto = 0;
            string autokindnotnull = QHC.IsNotNull("autokind");
			if (dsAuto.Tables.Contains("expense")) {
                nAuto += dsAuto.Tables["expense"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
			}

			if (dsAuto.Tables.Contains("income")) {
                nAuto += dsAuto.Tables["income"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
			}

			if (dsAuto.Tables.Contains("expensevar")) {
                nAuto += dsAuto.Tables["expensevar"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
			}

			if (dsAuto.Tables.Contains("incomevar")) {
                nAuto += dsAuto.Tables["incomevar"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
			}
			return nAuto;
		}
        private int contaVarAutomatismi() {
            int nAuto = 0;
            string autokindnotnull = QHC.IsNotNull("autokind");

            if(dsAuto.Tables.Contains("expensevar")) {
                nAuto += dsAuto.Tables["expensevar"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
            }

            if(dsAuto.Tables.Contains("incomevar")) {
                nAuto += dsAuto.Tables["incomevar"].Select(autokindnotnull, null, DataViewRowState.Added).Length;
            }
            return nAuto;
        }

        DataRow AddRowToFin(object idfin,object codefin) {
            DataRow rf = dsAuto.Tables["fin"].NewRow();
            rf["idfin"] = idfin;
            rf["codefin"] = codefin;
            dsAuto.Tables["fin"].Rows.Add(rf);
            rf.AcceptChanges();
            return rf;
        }
	    DataRow AddRowToUpb(object idupb, object codeupb) {
            DataRow rf = dsAuto.Tables["upb"].NewRow();
            rf["idupb"] = idupb;
            rf["codeupb"] = codeupb;
            dsAuto.Tables["upb"].Rows.Add(rf);
            rf.AcceptChanges();
	        return rf;
        }
        DataRow AddRowToTax(object taxcode, object description) {
            DataRow rf = dsAuto.Tables["tax"].NewRow();
            rf["taxcode"] = taxcode;
            rf["description"] = description;
            dsAuto.Tables["tax"].Rows.Add(rf);
            rf.AcceptChanges();
            return rf;
        }
	  

        /// <summary>
        /// Legge le tabelle di dsAuto tax,upb,fin per tutte le righe correlate a dsAuto.Tables["expenseyear"], incomeyear,expensetax
        /// </summary>
		private void fillSatelliteTable() {
            Dictionary<int, DataRow > finById = new Dictionary<int, DataRow>();
            Dictionary<string, DataRow > UpbById = new Dictionary<string, DataRow>();
            foreach (DataRow r in dsAuto.Tables["fin"].Select()) {
                //QueryCreator.MarkEvent("Adding to table "+r.Table.TableName);
                if (r["idfin"]==DBNull.Value)continue;                
                finById[(int) r["idfin"]] = r;
            }
            foreach (DataRow r in dsAuto.Tables["upb"].Select()) {
                //QueryCreator.MarkEvent("Adding to table "+r.Table.TableName);
                if (r["idupb"]==DBNull.Value)continue;                
                UpbById[(string) r["idupb"]] = r;
            }

			if (dsAuto.Tables.Contains("expenseyear")) {
                Cache.fin.ReadValuesRelatedTo(dsAuto.Tables["expenseyear"], "idfin");
                Cache.upb.ReadValuesRelatedTo(dsAuto.Tables["expenseyear"], "idupb");

                foreach(DataRow r in dsAuto.Tables["expenseyear"].Rows) {
                    DataRowVersion toConsider = (r.RowState == DataRowState.Deleted)
                        ? DataRowVersion.Original : DataRowVersion.Current;
                    if (r["idfin"]!=DBNull.Value && !finById.ContainsKey((int) r["idfin"])) {
                        object idfin=r["idfin", toConsider];
                        object codefin = Cache.fin.ReadValuesFor(idfin)["codefin"];
                        finById[(int) r["idfin"]] = AddRowToFin(idfin, codefin);
                    }

                    if (r["idupb"]!=DBNull.Value &&  !UpbById.ContainsKey((string) r["idupb"])) {
                        object idupb = r["idupb", toConsider];
                        object codeupb = Cache.upb.ReadValuesFor(idupb)["codeupb"];                       
                        UpbById[(string) r["idupb"]] =  AddRowToUpb(idupb, codeupb);
                    }
				}
			}

			if (dsAuto.Tables.Contains("incomeyear")) {
                Cache.fin.ReadValuesRelatedTo(dsAuto.Tables["incomeyear"], "idfin");
                Cache.upb.ReadValuesRelatedTo(dsAuto.Tables["incomeyear"], "idupb");

				foreach(DataRow r in dsAuto.Tables["incomeyear"].Rows) {
                    DataRowVersion toConsider = (r.RowState == DataRowState.Deleted)
                        ? DataRowVersion.Original : DataRowVersion.Current;
				    if (r["idfin"]!=DBNull.Value && !finById.ContainsKey((int) r["idfin"])) {
				        object idfin=r["idfin", toConsider];
				        object codefin = Cache.fin.ReadValuesFor(idfin)["codefin"];
				        finById[(int) r["idfin"]] = AddRowToFin(idfin, codefin);
				    }

				    if (r["idupb"]!=DBNull.Value &&!UpbById.ContainsKey((string) r["idupb"])) {
				        object idupb = r["idupb", toConsider];
				        object codeupb = Cache.upb.ReadValuesFor(idupb)["codeupb"];                       
				        UpbById[(string) r["idupb"]] =  AddRowToUpb(idupb, codeupb);
				    }
				}
			}

			if (dsAuto.Tables.Contains("expensetax")) {
                Cache.tax.ReadValuesRelatedTo(dsAuto.Tables["expensetax"], "taxcode");

				foreach(DataRow r in dsAuto.Tables["expensetax"].Rows) {
                    DataRowVersion toConsider = (r.RowState == DataRowState.Deleted)
                        ? DataRowVersion.Original : DataRowVersion.Current;
                    object taxcode=r["taxcode", toConsider];
                    string f1 = QHC.CmpEq("taxcode", taxcode);
					DataRow [] Tax = dsAuto.Tables["tax"].Select(f1);
					if (Tax.Length == 0) {
                        object description = Cache.tax.ReadValuesFor(taxcode)["description"];
                        AddRowToTax(taxcode, description);
                        //DataAccess.RUN_SELECT_INTO_TABLE(Conn, dsAuto.Tables["tax"], null, f1, null, true);
					}
				}
			}
		}


		public bool doPost(MetaDataDispatcher Disp) {
			MetaData metaSpesa = Disp.Get("expense");
			metaSpesa.ComputeRowsAs(dsAuto.Tables["expense"], "posting");

			MetaData metaEntrata = Disp.Get("income");
			metaEntrata.ComputeRowsAs(dsAuto.Tables["income"], "posting");

			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(dsAuto, Conn);

			if (MyPostData.DO_POST()) {
				creaMovBank("payment");
				creaMovBank("proceeds");
			}
			else {
				dsAuto.Clear();
				dsAuto.AcceptChanges();
				return false;
			}

			return true;
		}

		private void creaMovBank(string movTab) {
			if (dsAuto.Tables[movTab].Rows.Count == 0) return;
			string kfield = (movTab == "payment") ? "kpay" : "kpro";
			foreach(DataRow R in dsAuto.Tables[movTab].Rows) {
				int k = CfgFn.GetNoNullInt32(R[kfield]);
				Conn.CallSP("compute_"+movTab+"_bank", new object [] {k});
			}
		}

		public bool GeneraAzzeraDisponibilitaFasiPrec(){

			//vede se la prima riga generata ha una riga precedente
			if (fasefine==1) return false;

            string searchfirst = QHC.CmpEq("nphase", fasefine);
			DataRow []Found = Movimento.Select(searchfirst);
			if (Found.Length==0) return false;
			DataRow CurrMov = Found[0];

			//Chiama la sp_calcazzeradispspesa (idspesa, esercizio)
			int idmov= CfgFn.GetNoNullInt32( CurrMov[idmovimento] );
			int esercizio= Convert.ToInt32(Conn.GetSys("esercizio"));
			DataSet Out =  Conn.CallSP("compute_reset"+Movimento.TableName+"availability", 
				new object[]{esercizio, idmov});
			if ((Out==null)||(Out.Tables.Count==0)||(Out.Tables[0].Rows.Count==0)) return false;
			DataTable AutoVar = Out.Tables[0];
            foreach (DataRow Var in AutoVar.Select()) {
                if (CfgFn.GetNoNullDecimal(Var["amount"]) == 0) {
                    Var.Delete();
                }
            }
            AutoVar.AcceptChanges();
            if (AutoVar.Rows.Count == 0) return false;
			Form Frm = ShowAutomatismi.ShowAzzeramento(AutoVar);
			DialogResult Res= Frm.ShowDialog();
			if (Res!= DialogResult.OK) return false;

			DataSet NewDS= new DataSet();
			DataTable NewT= Conn.CreateTableByName(Movimento.TableName+"var",null);
			MetaData MetaVar= Disp.Get(Movimento.TableName+"var");
			MetaVar.SetDefaults(NewT);
			NewDS.Tables.Add(NewT);
            DateTime Adate = (DateTime)Conn.GetSys("datacontabile");
            if (CurrMov["adate"] != DBNull.Value) Adate = (DateTime)CurrMov["adate"];
           


			foreach(DataRow Var in AutoVar.Rows){
                MetaData.SetDefault(NewT, idmovimento, Var[idmovimento]);
                MetaData.SetDefault(NewT, "yvar", esercizio);
                DataRow newVar = MetaVar.Get_New_Row(null, NewT);
				    newVar["description"]= Var["description"];
				    newVar["amount"]= Var["amount"];
                    newVar["adate"] = Conn.GetSys("datacontabile");	//Adate; task 3235
                    if (AutoVar.Columns.Contains("idunderwriting") &&
                           NewT.Columns.Contains("idunderwriting"))
                        newVar["idunderwriting"] = Var["idunderwriting"];
			}

			PostData post = new Easy_PostData();
			post.InitClass(NewDS, Conn);
			bool res = post.DO_POST();
			return res;
		}
	}
}