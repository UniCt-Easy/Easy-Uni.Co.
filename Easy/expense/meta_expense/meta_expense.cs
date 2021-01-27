
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;
using movimentofunctions;


namespace meta_expense//meta_spesa//
{
	/// <summary>
	/// MetaData for spesa
	/// Updated by Leo 15 Dec 2002
	/// Revised By Nino: redirected "default" to "spesaview"
	/// Revised By Nino: added autoincrement field "nummovimento"
	/// </summary>
    public class Meta_expense : Meta_easydata {
        public Meta_expense(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "expense") {		
            Name= "Movimento di spesa";
            EditTypes.Add("default");
			EditTypes.Add("levels");
			EditTypes.Add("modpaga");
			EditTypes.Add("automatismi");
			EditTypes.Add("procmissione");
			EditTypes.Add("gerarchico");
			EditTypes.Add("wizarddelete");
			EditTypes.Add("wizarddecontabilizza");
			EditTypes.Add("wizardcontabilizza");
			EditTypes.Add("wizardazzerariporti");
			EditTypes.Add("wizardcreamovcompetenza");
			EditTypes.Add("wizardmandatedetail");
			EditTypes.Add("wizardinvoicedetail");
            EditTypes.Add("wizardinvoicedetailnomandate");
			EditTypes.Add("fromsalary");
			EditTypes.Add("importsalary");
            EditTypes.Add("wizardlinkexptoinc");
            EditTypes.Add("wizardunlinkexpfrominc");
            EditTypes.Add("wizardexpensefinvardetail");
            EditTypes.Add("ct_stornoresidui");
            EditTypes.Add("ct_stornocompetenzaclass"); 

            ListingTypes.Add("movimentiaperti");
			ListingTypes.Add("movbancario");
			ListingTypes.Add("movbancariocollegato");
			ListingTypes.Add("documentocollegato");
			ListingTypes.Add("default");
			ListingTypes.Add("ordinegenerico");
			ListingTypes.Add("posting");
			ListingTypes.Add("ep");
        }

        protected override Form GetForm(string FormName){

			if (FormName=="default") {
				DefaultListType = "default";	
				return MetaData.GetFormByDllName("expense_levels"); // new frmSpeseMovimenti();		
			}
			if (FormName=="levels") {
				DefaultListType = "default";	
				return MetaData.GetFormByDllName("expense_levels"); // new frmSpeseMovimenti();		
				//return new frmSpeseMovimenti();		
			}

			if (FormName=="gerarchico") {
				Name= "Spese";
				DefaultListType = "default";	
				return MetaData.GetFormByDllName("expense_gerarchico"); // new frmSpeseMovimenti();		
				//return new frmSpesaGerarchico();		
			}

			if (FormName=="procmissione") {
				Name= "Spese";
				DefaultListType = "default";	
				return MetaData.GetFormByDllName("expense_procmissione"); // new frmSpeseMovimenti();		
				//return new frmSpesaProceduraMissione();		
			}

			if (FormName=="modpaga") {
				Name="Modalità di pagamento del movimento finanziario";
				return MetaData.GetFormByDllName("expense_modpaga"); // new frmSpeseMovimenti();		
				//return new frmSpesaModCredDebi();
			}
			if (FormName=="automatismi"){
				Name="Elenco movimenti automatici";
				//return new frmSpesaAutomatismi();
				return MetaData.GetFormByDllName("expense_automatismi"); // new frmSpeseMovimenti();		
			}
			if (FormName=="wizarddelete"){
				Name="Wizard eliminazione movimento di spesa";
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				return MetaData.GetFormByDllName("expense_wizarddelete");
			}
			if (FormName=="wizarddecontabilizza"){
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Wizard rimozione contabilizzazioni";
				return MetaData.GetFormByDllName("expense_wizarddecontabilizza");
			}

			if (FormName=="wizardmandatedetail"){
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Wizard contabilizzazione dettagli Contratto Passivo";
				return MetaData.GetFormByDllName("expense_wizardmandatedetail");
			}

			if (FormName=="wizardinvoicedetail"){
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Wizard Pagamento Fatture di Acquisto";
				return MetaData.GetFormByDllName("expense_wizardinvoicedetail");
			}

            if (FormName == "wizardinvoicedetailnomandate") {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Wizard Pagamento Fatture di Acquisto non collegate a contratti passivi";
                return MetaData.GetFormByDllName("expense_wizardinvoicedetailnomandate");
            }

			if (FormName=="wizardcontabilizza"){
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Wizard aggiunta contabilizzazioni";
				return MetaData.GetFormByDllName("expense_wizardcontabilizza");
			}

			if (FormName == "wizardazzerariporti")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name = "Wizard di Azzeramento dei Riporti";
				return MetaData.GetFormByDllName("expense_wizardazzerariporti");
			}

			
			if (FormName == "wizardcreamovcompetenza")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name = "Wizard di Creazione dei Movimenti di Competenza";
				return MetaData.GetFormByDllName("expense_wizardcreamovcompetenza");
			}

            if (FormName == "wizardexpensefinvardetail")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name = "Wizard di Creazione prenotazioni dalle richieste di previsione";
                return MetaData.GetFormByDllName("expense_wizardexpensefinvardetail");
			}

            if (FormName == "ct_stornoresidui")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
                Name = "Modifica UPB, Articolo e disponibile di un Impegno Residuo";
                return MetaData.GetFormByDllName("expense_ct_stornoresidui");
			}
            if (FormName == "ct_stornocompetenzaclass") {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Modifica UPB, Articolo e disponibile di un Impegno Competenza";
                return MetaData.GetFormByDllName("expense_ct_stornocompetenzaclass");
            }

            if (FormName == "fromsalary") {
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name = "Creazione dei Movimenti di Spesa per gli Stipendi ";
				return MetaData.GetFormByDllName("expense_fromsalary");
			}

			if (FormName == "importsalary") {
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name = "Importazione degli Stipendi";
				return MetaData.GetFormByDllName("expense_importsalary");
			}

            if (FormName == "wizardlinkexptoinc") {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Vincolo tra pagamento e incasso";
                return MetaData.GetFormByDllName("expense_wizardlinkexptoinc");
            }
            if (FormName == "wizardunlinkexpfrominc") {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Scollega incasso da pagamento ";
                return MetaData.GetFormByDllName("expense_wizardunlinkexpfrominc");
            }

			return null;
        }			
        

		public override bool CanSelect(DataRow R) {
			if (R.Table.Columns["ayear"]!=null){
				if (R["ayear"].ToString()!=GetSys("esercizio").ToString()){
					MetaFactory.factory.getSingleton<IMessageShower>().Show("La spesa selezionata non è presente in questo esercizio quindi non è selezionabile.");
					return false;
				}
			}
			return base.CanSelect (R);
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if (C.ColumnName == "idinc_linked") return;
			base.InsertCopyColumn (C, Source, Dest);
		}

        //private static object CalcIDExp(DataRow R, DataColumn C, DataAccess Conn) {
        //    object oidexp = Conn.DO_READ_VALUE("expense", null, "max(idexp)");
        //    int idexp = CfgFn.GetNoNullInt32(oidexp);
        //    return idexp + 1;
        //}


		public static void SetAutoIncrementProperties(DataTable T, DataAccess Conn) {
			RowChange.MarkAsAutoincrement(T.Columns["idexp"],null,null,0);
            //RowChange.MarkAsCustomAutoincrement(T.Columns["idexp"], new RowChange.CustomCalcAutoID(CalcIDExp));
            //Imposto i campi selettori utilizzati nel WHERE durante il calcolo di nmov
            RowChange.SetMySelector(T.Columns["nmov"], "nphase",0);
            RowChange.SetMySelector(T.Columns["nmov"], "ymov",0);		
			RowChange.MarkAsAutoincrement(T.Columns["nmov"],null,null,0);
		}


        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			SetAutoIncrementProperties(T,Conn);
            RowChange.setMinimumTempValue(T.Columns["nmov"],  900000000);
            RowChange.setMinimumTempValue(T.Columns["idexp"], 900000000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

		public override bool IsValid(DataRow R, 
				out string errmess, out string errfield){
			if (R.Table.Columns.Contains("idinc_linked") &&
			    R.Table.Columns["idinc_linked"].AllowDBNull == false) {
				if (R["idinc_linked"] == DBNull.Value) {
					errmess =
						"E' necessario accedere alla scheda Altro e collegare il movimento finanziario di entrata di partita di giro." +
						" Il movimento di entrata deve avere UPB e Importo uguali a quelle del movimento di spesa che si vuole salvare";
					errfield = "idinc_linked";
					return false;
				}
			}

			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if ((edit_type=="default")||
				(edit_type=="ordinegenerico")||
				(edit_type=="iva")||
				(edit_type=="gerarchico")||
				(edit_type=="levels")||
				(edit_type=="procedura")||
				(edit_type=="procmissione"))
			{
				

				if (R.Table.ExtendedProperties["faseinizio"]!=null){
					//Può accadere solo nel form procedura
					int faseinizio= Convert.ToInt32(R.Table.ExtendedProperties["faseinizio"]);

					if (faseinizio==0){
						errmess="E' necessario specificare almeno una fase.";
						errfield=null;
						return false;
					}
				}

				if ((Convert.ToInt32(R["nphase"])>1)&&
					(R["parentidexp"]==DBNull.Value)){
					errmess="Per immettere un movimento di una fase intermedia o finale è "+
						"necessario identificare la fase precedente";
					errfield=null;
					return false;
				}
	
				return true;
			}



			return true;
		}


		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			//SetDefault(PrimaryTable,"delete_flagcompeconomica","N");

			if (PrimaryTable.ExtendedProperties["app_default"]!=null){
				Hashtable H = (Hashtable)PrimaryTable.ExtendedProperties["app_default"];
				foreach (string field in new string[]{"idexp","idreg",
														 "description", "doc", "docdate",
														 "idman", 
														 "nphase","autocode","autokind","idpayment","idchargehandling" }){
					if (H[field]!=null)	SetDefault(PrimaryTable, field, H[field]);
				}
				SetDefault(PrimaryTable, "ymov", GetSys("esercizio").ToString());
				//SetDefault(PrimaryTable, "ycreation", GetSys("esercizio").ToString());
				SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));	
				return;
			}
			SetDefault(PrimaryTable, "ymov", GetSys("esercizio").ToString());
			//SetDefault(PrimaryTable, "ycreation", GetSys("esercizio").ToString());
			if (CfgFn.GetNoNullInt32( PrimaryTable.Columns["nphase"].DefaultValue)==0)
					SetDefault(PrimaryTable, "nphase",1);
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		}



		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType=="ordinegenerico")return base.SelectOne("default",filter, "expensemandateview", Exclude);
			if (ListingType=="iva")return base.SelectOne("default",filter, "expenseinvoiceview", Exclude);
			if (ListingType=="missione")return base.SelectOne("default", filter, "expenseitinerationview", Exclude);
			if (ListingType=="cedolino")return base.SelectOne("default",filter, "expensepayrollview", Exclude);
			if (ListingType=="occasionale")return base.SelectOne("default",filter, "expensecasualcontractview", Exclude);
			if (ListingType=="professionale")return base.SelectOne("default",filter, "expenseprofserviceview", Exclude);
			if (ListingType=="dipendente")return base.SelectOne("default",filter, "expensewageadditionview", Exclude);
			if (ListingType=="ep") return base.SelectOne("ep",filter, "expense_epview", Exclude);
			return base.SelectOne(ListingType, filter, "expenseview", Exclude);
		}

		public override PostData Get_PostData() {
            if (DS.Tables["expense"].Rows.Count == 0)  return base.Get_PostData ();
			if ((edit_type=="procedura")||
				(edit_type=="procmissione")) return new SpesaPostData(Dispatcher);
            if ((edit_type == "gerarchico") || (edit_type == "levels") || (edit_type == "default")) {
				if ((DS.Tables["expense"].Rows.Count == 0)
					|| (DS.Tables["expense"].Rows[0].RowState == DataRowState.Deleted)) {
					return base.Get_PostData();
				}
				else {
					return new SpesaLevGerPostData(DS, Dispatcher, edit_type, this);
				}
			}
			return base.Get_PostData ();
		}

		public override void CalculateFields(DataRow R, string list_type) {
			base.CalculateFields (R, list_type);
			if (list_type == "posting") {
				impostaCampi(R, list_type);
			}
		}

		private void impostaCampi(DataRow R, string listingtype) {
			if (listingtype != "posting") return;
			if (R["autokind"] == DBNull.Value) return;
			if (R["idpayment"] == DBNull.Value) return;

            object idmov = R["idpayment"];
            DataRow[] Exp = R.Table.Select("idexp=" + QueryCreator.quotedstrvalue(idmov, false));
            if (Exp.Length == 0) return;

			

			//string nMov = idmov.Substring(idmov.Length - 6,6);
            string nMov = Exp[0]["nmov"].ToString();

			while ((nMov.StartsWith("0")) && (nMov.Length > 0)) {
				nMov = nMov.Substring(1,nMov.Length - 1);
			}
			
			//string suCosa = (R["idpayment"] != DBNull.Value) ? "su pagamento" : "su incasso";
            string suCosa = "su pagamento" ;

			string descr = R["description"].ToString();

			int pos = descr.LastIndexOf(suCosa);
			// Non ho trovato il token "su pagamento" o "su incasso"
			if (pos == -1) return;
			pos += suCosa.Length;

			string temp_s = descr.Substring(pos);
			int pos_n = temp_s.IndexOf("n. ");
			// Non ho trovato il token "n. "
			if (pos_n == -1) return;

			string s1 = descr.Substring(0,pos) + temp_s.Substring(0, pos_n);
			
			string s2 = "n. ";
			string temp_s1 = temp_s.Substring(pos_n + 3);

			int nCharToPaste = 0;
			foreach(char c in temp_s1.ToCharArray()) {
				if ((c >= '0') && (c <= '9')) {
					s2 += c.ToString();
					nCharToPaste++;
				}
				else {
					break;
				}
			}
			s2 = "n. " + nMov;

			string s3 = temp_s1.Substring(nCharToPaste);

			R["description"] = s1 + s2 + s3;
		}
		

    }

	public class SpesaLevGerPostData: Easy_PostData {
		DataSet dsSource;
		string edit_type;
		MetaDataDispatcher Disp;
		GestioneAutomatismi ga;

		public SpesaLevGerPostData(DataSet DS, MetaDataDispatcher Disp, string edit_type, MetaData Meta) {
			this.dsSource = DS;
			this.edit_type = edit_type;
			this.Disp = Disp;
		}

		public override string InitClass(DataSet DS, DataAccess Conn) {
			int fasefine = CfgFn.GetNoNullInt32(DS.Tables["expense"].Rows[0]["nphase"]);
			int fasespesamax = CfgFn.GetNoNullInt32(Conn.GetSys("maxexpensephase"));
			
			ga = new GestioneAutomatismi(null, Conn, Disp, DS, fasefine, fasespesamax, "expense", false);
			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) return "NoSave";
			DataSet DSP = ga.DSP;

			MetaData metaSpesa = Disp.Get("expense");
			metaSpesa.ComputeRowsAs(DSP.Tables["expense"], "posting");

			MetaData metaEntrata = Disp.Get("income");
			metaEntrata.ComputeRowsAs(DSP.Tables["income"], "posting");

            MetaData metaVarSpesa = Disp.Get("expensevar");
            metaVarSpesa.ComputeRowsAs(DSP.Tables["expensevar"], "posting");

			return base.InitClass (DSP, Conn);
		}

		public override bool DO_POST() {
			bool res = base.DO_POST();
			ga.updateSource(dsSource, res);
			if (res) {
                if (ga.DSP.Tables.Contains("payment")) {
                    foreach (DataRow rPayment in ga.DSP.Tables["payment"].Rows) {
                        int kpay = CfgFn.GetNoNullInt32(rPayment["kpay"]);
                        if (kpay == 0) continue;
                        Conn.CallSP("compute_payment_bank", new object[] { kpay });
                    }
                }

                if (ga.DSP.Tables.Contains("proceeds")) {
                    foreach (DataRow rProceeds in ga.DSP.Tables["proceeds"].Rows) {
                        int kpro = CfgFn.GetNoNullInt32(rProceeds["kpro"]);
                        if (kpro == 0) continue;
                        Conn.CallSP("compute_proceeds_bank", new object[] { kpro });
                    }
                }
				dsSource.AcceptChanges();
			}
			return res;
		}

	}


	public class SpesaPostData: Easy_PostData {
		int fasemissione;
		int faseordine;
		int faseiva;
		int fasecedolino;
		int faseoccasionale;
		int faseprofessionale;
		int fasedipendente;
		MetaDataDispatcher Disp;
		DataSet dsSource;

		public override bool DO_POST() {
			bool res = base.DO_POST();
			if (res) {
				if (dsSource!=null){
					if (dsSource.Tables["expense"].Rows.Count>0){
						DataRow SourceExpense=dsSource.Tables["expense"].Rows[0];
						int fasespesafine = Convert.ToInt32( DS.Tables["expense"].ExtendedProperties["fasespesafine"]);
						DataRow Last= DS.Tables["expense"].Select("nphase="+fasespesafine)[0];
						int idlastphase= CfgFn.GetNoNullInt32( Last["idexp"]);
                        SourceExpense["idexp"] = idlastphase;
						SourceExpense["nphase"]= fasespesafine;

                        if (dsSource.Tables["expenselast"].Rows.Count > 0) {
                            DataRow SourceExpenseLast = dsSource.Tables["expenselast"].Rows[0];
                            SourceExpenseLast["idexp"] = idlastphase;
                        }


                        if (dsSource.Tables["expenseyear"].Rows.Count > 0) {
                            DataRow SourceExpenseYear = dsSource.Tables["expenseyear"].Rows[0];
                            SourceExpenseYear["idexp"] = idlastphase;
                        }

					}

                    if (DS.Tables.Contains("payment")) {
                        foreach (DataRow rPayment in DS.Tables["payment"].Rows) {
                            int kpay = CfgFn.GetNoNullInt32(rPayment["kpay"]);
                            if (kpay == 0) continue;
                            Conn.CallSP("compute_payment_bank", new object[] { kpay});
                        }
                    }

                    if (DS.Tables.Contains("proceeds")) {
                        foreach (DataRow rProceeds in DS.Tables["proceeds"].Rows) {
                            int kpro = CfgFn.GetNoNullInt32(rProceeds["kpro"]);
                            if (kpro == 0) continue;
                            Conn.CallSP("compute_proceeds_bank", new object[] { kpro});
                        }
                    }
				}
			}
			return res;
		}


		


		public SpesaPostData(MetaDataDispatcher Disp){		
			this.Disp = Disp;
		}

		public override string InitClass(DataSet DS, DataAccess Conn) {
			
			if (DS.Tables["expense"].Rows.Count==0) {
				return base.InitClass(DS,Conn);

			}
			DataSet PreDSP = DS.Copy();
			dsSource= DS;
			
			foreach (DataTable T in DS.Tables){
				RowChange.CopyAutoIncrementProperties(T, PreDSP.Tables[T.TableName]);
			}
			fasemissione= CfgFn.GetNoNullInt32(Conn.GetSys("itinerationphase"));
			fasecedolino= CfgFn.GetNoNullInt32(Conn.GetSys("itinerationphase"));
			faseoccasionale= CfgFn.GetNoNullInt32(Conn.GetSys("itinerationphase"));
			faseprofessionale= CfgFn.GetNoNullInt32(Conn.GetSys("itinerationphase"));
			fasedipendente= CfgFn.GetNoNullInt32(Conn.GetSys("itinerationphase"));
			faseordine= CfgFn.GetNoNullInt32(Conn.GetSys("mandatephase"));
			faseiva= CfgFn.GetNoNullInt32(Conn.GetSys("invoiceexpensephase"));

			PreDSP.EnforceConstraints=false;
						 //Aggiunge la relazione padre/figlio per la tabella spesa
			PreDSP.Relations.Add("expenseexpense", 
					PreDSP.Tables["expense"].Columns["idexp"],
					PreDSP.Tables["expense"].Columns["parentidexp"],false);
			SplitRowInPhases(PreDSP,Conn);
			DataSet DSP = aggiornaDSP(PreDSP,Conn);
			if (DSP == null) return "NoSave";

			MetaData metaSpesa = Disp.Get("expense");
			metaSpesa.ComputeRowsAs(DSP.Tables["expense"], "posting");

			MetaData metaEntrata = Disp.Get("income");
			metaEntrata.ComputeRowsAs(DSP.Tables["income"], "posting");

            MetaData metaVarSpesa = Disp.Get("expensevar");
            metaVarSpesa.ComputeRowsAs(DSP.Tables["expensevar"], "posting");

			DS.ExtendedProperties["DSPData"]=DSP;
			return base.InitClass (DSP, Conn);
		}

		private DataSet aggiornaDSP(DataSet DSP, DataAccess Conn) {
			
			int fasespesafine = Convert.ToInt32(DSP.Tables["expense"].ExtendedProperties["fasespesafine"]);
			int fasespesamax = CfgFn.GetNoNullInt32(Conn.GetSys("maxexpensephase"));

			GestioneAutomatismi ga = new GestioneAutomatismi(null, Conn, Disp,
				DSP, fasespesafine, fasespesamax, "expense", false);
			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) return null;
			return ga.DSP;
		}

		/// <summary>
		/// Dalla riga presente in DSP.spesa ne crea n (da faseinizio a fasefine)
		/// </summary>
		/// <param name="DSP"></param>
		void SplitRowInPhases(DataSet DSP, DataAccess Conn){
            CQueryHelper QHC = new CQueryHelper();
			try {
				int faseinizio = Convert.ToInt32( DSP.Tables["expense"].ExtendedProperties["faseinizio"]);
				int fasefine = Convert.ToInt32( DSP.Tables["expense"].ExtendedProperties["fasefine"]);
				int fasespesafine = Convert.ToInt32( DSP.Tables["expense"].ExtendedProperties["fasespesafine"]);
				int fasespesamax = CfgFn.GetNoNullInt32(Conn.GetSys("maxexpensephase"));
			
				int minfasecreditore = 	Convert.ToInt32(Conn.GetSys("expenseregphase"));
				int minfasebilannuale = Convert.ToInt32(Conn.GetSys("expensefinphase"));
				int esercizio = (int) Conn.GetSys("esercizio");

				DataRow ExSpesa = DSP.Tables["expense"].Rows[0];
				DataRow ExImpSpesa = DSP.Tables["expenseyear"].Rows[0];

				object previd=DBNull.Value;
				for (int fase = faseinizio; fase<=fasespesafine; fase++){
					DataRow NewRow= DSP.Tables["expense"].NewRow();
					NewRow["idexp"] = MetaData.MaxFromColumn(DSP.Tables["expense"],"idexp")+1;
					NewRow["nphase"] = fase;
					
					//Assegna l'ID fase precedente
					if (fase>1){
						if (fase == faseinizio) {
							NewRow["parentidexp"] = ExSpesa["parentidexp"];
						}
						else {
							NewRow["parentidexp"] = previd;
						}

						//NewRow["idexp"]= 
                        //        NewRow["parentidexp"].ToString()+
                        //        esercizio.ToString().Substring(2)+
                        //        "980000";
						NewRow["ymov"] = esercizio;		
					}
					else {
						NewRow["parentidexp"]= DBNull.Value;
                        //NewRow["idexp"]= 
                        //    esercizio.ToString().Substring(2)+
                        //    "980000";
						//Per la prima fase soltanto prendo l'esercmovimento del form
						NewRow["ymov"] = ExSpesa["ymov"];		
					}
					//NewRow["ycreation"]=esercizio;
					//RowChange.CalcTemporaryID(NewRow); da problemi poiché gli ID esistono già


					previd= NewRow["idexp"]; //.ToString();  //da usare nella iterazione successiva

					//Copia tutti gli altri dati del movimento (rispettando l'ordine delle fasi)
					foreach (DataColumn C in DSP.Tables["expense"].Columns){
						if (C.ColumnName == "idexp") continue;
						if (C.ColumnName == "idinc_linked" && fase!=1) continue;
						if (C.ColumnName == "nphase") continue;
						if (C.ColumnName == "parentidexp") continue;
						if (C.ColumnName == "ymov")continue;


						if ((C.ColumnName == "idreg") && (fase < minfasecreditore))continue;

                        if ((C.ColumnName == "cigcode") && (fase != minfasecreditore)) continue;
                        if ((C.ColumnName == "cupcode") && (fase != minfasecreditore)) continue;

                        ////Salta dati non appartenenti ad ultima fase
                        //if ((
                        //    (C.ColumnName == "idser")||
                        //    (C.ColumnName == "servicestart")||(C.ColumnName == "servicestop")||
                        //    (C.ColumnName.StartsWith("importoprestazione"))||
                        //    (C.ColumnName == "autotaxflag")|| (C.ColumnName == "autoclawbackflag")||
                        //    (C.ColumnName == "servicestop")||
                        //    (C.ColumnName == "ypay")||(C.ColumnName == "npay")||
                        //    (C.ColumnName == "fulfilled") || (C.ColumnName == "idclawback")||
                        //    (C.ColumnName == "nbill")
                        //    )

                        //    && (fase != fasespesamax))continue;

						
						NewRow[C.ColumnName] = ExSpesa[C.ColumnName];
					}
					DSP.Tables["expense"].Rows.Add(NewRow);

					//Aggiunge la riga di expenseyear
					DataRow NewImp = DSP.Tables["expenseyear"].NewRow();
					NewImp["idexp"]= NewRow["idexp"];
					NewImp["ayear"]= esercizio; // NewRow["eserccreazione"];
                    //NewImp["nphase"] = fase;
					foreach (DataColumn C in DSP.Tables["expenseyear"].Columns){
						if (C.ColumnName == "idexp") continue;
						if (C.ColumnName == "ayear") continue;
                        //if (C.ColumnName == "nphase") continue;
						if ((C.ColumnName == "idfin") && (fase < minfasebilannuale))continue;
						if ((C.ColumnName == "idupb") && (fase < minfasebilannuale))continue;
                        //if ((C.ColumnName == "flagarrear") && (fase < minfasebilannuale))continue;
						NewImp[C.ColumnName] = ExImpSpesa[C.ColumnName];
					}
					DSP.Tables["expenseyear"].Rows.Add(NewImp);

					if ((fase== fasemissione)&&(DSP.Tables["expenseitineration"]!=null)){
						foreach(DataRow ChildR in DSP.Tables["expenseitineration"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
						}
					}
					if ((fase== fasecedolino)&&(DSP.Tables["expensepayroll"]!=null)){
						foreach(DataRow ChildR in DSP.Tables["expensepayroll"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
						}
					}
					if ((fase== faseoccasionale)&&(DSP.Tables["expensecasualcontract"]!=null)){
						foreach(DataRow ChildR in DSP.Tables["expensecasualcontract"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
						}
					}
					if ((fase== faseprofessionale)&&(DSP.Tables["expenseprofservice"]!=null)){
						foreach(DataRow ChildR in DSP.Tables["expenseprofservice"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
						}
					}

					if ((fase== fasedipendente)&&(DSP.Tables["expensewageaddition"]!=null))
					{
						foreach(DataRow ChildR in DSP.Tables["expensewageaddition"].Rows)
						{
							ChildR["idexp"]= NewRow["idexp"];
						}
					}

					if ((fase== faseordine)&&
						(DSP.Tables["expensemandate"]!=null)) {
						int movkind=0;
						foreach(DataRow ChildR in DSP.Tables["expensemandate"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
							movkind=CfgFn.GetNoNullInt32( ChildR["movkind"]);
						}
						if (DSP.Tables["mandatedetail_taxable"]!=null){
							foreach(DataRow ChildRR in DSP.Tables["mandatedetail_taxable"].Rows){
								switch(movkind){
									case 1:
                                        if (ChildRR["idexp_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_taxable"] = NewRow["idexp"];
                                        }
                                        if (ChildRR["idexp_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_iva"] = NewRow["idexp"];
                                        }
										break;
									case 3:
                                        if (ChildRR["idexp_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_taxable"] = NewRow["idexp"];
                                        }
										break;
								}

							}
						}
						if (DSP.Tables["mandatedetail_iva"]!=null){
							foreach(DataRow ChildRR in DSP.Tables["mandatedetail_iva"].Rows){
								switch(movkind){
									case 2:
                                        if (ChildRR["idexp_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_iva"] = NewRow["idexp"];
                                        }
										break;
								}

							}
						}

					}

					if ((fase== faseiva)&&
						(DSP.Tables["expenseinvoice"]!=null)) {
						int movkind=0;
						foreach(DataRow ChildR in DSP.Tables["expenseinvoice"].Rows){
							ChildR["idexp"]= NewRow["idexp"];
							movkind=CfgFn.GetNoNullInt32( ChildR["movkind"]);
						}
						if (DSP.Tables["invoicedetail_taxable"]!=null){
							foreach(DataRow ChildRR in DSP.Tables["invoicedetail_taxable"].Rows){
								switch(movkind){
									case 1:
                                        if (ChildRR["idexp_taxable"]!= DBNull.Value)
                                        {
                                            ChildRR["idexp_taxable"] = NewRow["idexp"];
                                        }
                                        if (ChildRR["idexp_iva"]!=DBNull.Value)
                                        {
                                            ChildRR["idexp_iva"] = NewRow["idexp"];
                                        }
										break;
									case 3:
                                        if (ChildRR["idexp_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_taxable"] = NewRow["idexp"];
                                        }
										break;
								}

							}
						}
						if (DSP.Tables["invoicedetail_iva"]!=null){
							foreach(DataRow ChildRR in DSP.Tables["invoicedetail_iva"].Rows){
								switch(movkind){
									case 2:
                                        if (ChildRR["idexp_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idexp_iva"] = NewRow["idexp"];
                                        }
										break;
								}

							}
						}

					}

					if (fase == fasespesamax){
						//Sposta le righe figlie dalla riga originale a questa
                        foreach (DataTable ChildT in new DataTable[] {  DSP.Tables["expenselast"],
																		 DSP.Tables["expensetax"],
                                                                         DSP.Tables["expensetaxcorrige"],
                                                                         DSP.Tables["expensetaxofficial"],
																		 DSP.Tables["expenseclawback"],
                                                                         DSP.Tables["underwritingpayment"],
                                                                         DSP.Tables["expensebill"]
                                                                        }){
							if (ChildT==null) continue;
							foreach(DataRow ChildR in ChildT.Rows){
								ChildR["idexp"]= NewRow["idexp"];
							}
						}

						if (fasefine>fasespesamax){
							//Collega l'ultima fase al documento di pagamento
                            DSP.Tables["expenselast"].Rows[0]["kpay"] = DSP.Tables["payment"].Rows[0]["kpay"];
                            //NewRow["ypay"]= DSP.Tables["payment"].Rows[0]["ypay"];
                            //NewRow["npay"]= DSP.Tables["payment"].Rows[0]["npay"];
						}
						else {
							//NewRow["ypay"]= DBNull.Value;
                            DSP.Tables["expenselast"].Rows[0]["kpay"] = DBNull.Value;
						}

					}


                    if (fase == minfasebilannuale && DSP.Tables["underwritingappropriation"]!=null) {
                        //Sposta le righe in assegnazionecrediti dalla riga originale a questa
                        foreach (DataRow ChildR in DSP.Tables["underwritingappropriation"].Rows) {
                            ChildR["idexp"] = NewRow["idexp"];
                        }
                    }

					//Sposta le classificazioni di quella fase 
					if (DSP.Tables["expensesorted"]!=null){
						foreach(DataRow ClassR in DSP.Tables["expensesorted"].Rows){
                            DataRow ClassMov = ClassR.GetParentRow("sortingexpensesorted");
                            if (ClassMov == null) continue;
                            string searchparent = QHC.CmpEq("idsorkind", ClassMov["idsorkind"]);
                            DataTable SorKind = ClassMov.Table.DataSet.Tables["sortingkind"];
                            DataRow []TipoClassRs = SorKind.Select(searchparent);
                            if (TipoClassRs.Length == 0) continue;
                            DataRow TipoClassR = TipoClassRs[0];
							if (Convert.ToInt32(TipoClassR["nphaseexpense"])!=fase) continue;
							ClassR["idexp"]= NewRow["idexp"];
						}
					}
				
				}  //Fine del for relativo alle fasi
				if (DSP.Tables["payment"]!=null && DSP.Tables["payment"].Rows.Count>0){
					DataRow Pagamento= DSP.Tables["payment"].Rows[0];
					Pagamento["txt"]=ExSpesa["txt"];
					Pagamento["rtf"]=ExSpesa["rtf"];
				}

				ExImpSpesa.Delete();
				ExSpesa.Delete();

				if (fasefine<=fasespesamax && DSP.Tables["payment"]!=null){					
					DSP.Tables["payment"].Clear();
				}
                if (fasefine < fasespesamax && DSP.Tables["expenselast"] != null) {
                    DSP.Tables["expenselast"].Clear();
                }
                if (fasefine < fasespesamax && DSP.Tables["expensebill"] != null) {
                    DSP.Tables["expensebill"].Clear();
                }
            }
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
			}
		}

	}
	
}
