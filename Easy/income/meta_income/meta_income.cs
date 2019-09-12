/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metaeasylibrary;
using metadatalibrary;
//using entratamovimenti;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
//using entrata_automatismi;
//using EntrataGerarchico;
using funzioni_configurazione;//funzioni_configurazione
//using entrataprocedura;



namespace meta_income//meta_entrata//
{
	/// <summary>
	/// Summary description for Class1.
	/// Updated by Leo 15 Dec 2002
	/// Revised by Nino on 19/1/2003 (added get_new_row and set_defaults)
	/// </summary>
	public class Meta_income : Meta_easydata {
		public Meta_income(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "income") {		
			Name= "Movimento di entrata";
			EditTypes.Add("default");
			EditTypes.Add("levels");
			EditTypes.Add("procedura");
			EditTypes.Add("gerarchico");
			EditTypes.Add("automatismi");
			EditTypes.Add("wizarddelete");
			EditTypes.Add("wizarddecontabilizza");
			EditTypes.Add("wizardmandatedetail");
            EditTypes.Add("wizardinvoicedetail");
            EditTypes.Add("wizardinvoicedetailnoestimate");
            EditTypes.Add("wizardchangeunderwriting");
			//ListingTypes.Add("movbancario");
			//ListingTypes.Add("movbancariocollegato");
			ListingTypes.Add("documentocollegato");
			ListingTypes.Add("assegnazionecredito");
			ListingTypes.Add("iva");
			ListingTypes.Add("estimate");
			ListingTypes.Add("posting");
		}

		public override bool CanSelect(DataRow R) {
			if (R.Table.Columns["ayear"]!=null){
				if (R["ayear"].ToString()!=GetSys("esercizio").ToString()){
					MessageBox.Show("L'entrata selezionata non è presente in questo esercizio quindi non è selezionabile.");
					return false;
				}
			}
			return base.CanSelect (R);
		}

		public override bool IsValid(DataRow R, 
			out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if ((edit_type=="default")||
				(edit_type=="gerarchico")||
				(edit_type=="procedura")||
				(edit_type=="levels")
				) {
				
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
					(R["parentidinc"]==DBNull.Value)){
					errmess="Per immettere un movimento di una fase intermedia o finale è "+
						"necessario identificare la fase precedente";
					errfield=null;
					return false;
				}

				return true;
			}
			return true;
		}


		protected override Form GetForm(string FormName)
		{
			object MDVer = Conn.GetSys("MetaDataVersion");
		    if (MDVer.ToString().CompareTo("2.1.160.0")<0){
				MessageBox.Show("Per poter eseguire il form richiesto è necessario attendere "+
					"il completamento del live-update del software, poi CHIUDERE e RIAPRIRE il programma.");
				return null;
			};

			if (FormName=="wizarddecontabilizza")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Cancellazione";
				return GetFormByDllName("income_wizarddecontabilizza");
			}

            if (FormName == "wizardchangeunderwriting")
            {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Associa Finanziamento ad Accertamento";
                return GetFormByDllName("income_wizardchangeunderwriting");
            }

			if (FormName=="default")
			{
				DefaultListType = "default";	
				return GetFormByDllName("income_levels");
				//return new frmentratamovimenti();
			}

			if (FormName=="levels")
			{
				DefaultListType = "default";	
//				return new frmentratamovimenti();
				return GetFormByDllName("income_levels");
			}

			if (FormName=="automatismi")
			{
				Name="Elenco movimenti automatici";
				return GetFormByDllName("income_automatismi");
				//return new FrmEntrata_Automatismi();
			}

			if (FormName=="gerarchico")
			{
				Name="Entrate";
				DefaultListType = "default";	
				return GetFormByDllName("income_gerarchico");
//				return new FrmEntrataGerarchico();		
			}

			if (FormName=="wizarddelete")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				DefaultListType = "default";	
				Name="Rimuovi contabilizzazione";
				return GetFormByDllName("income_wizarddelete");
				//				return new FrmEntrataGerarchico();		
			}

			if (FormName=="wizardcontabilizza")
			{
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				DefaultListType = "default";	
				Name="Aggiungi contabilizzazione";
				return GetFormByDllName("income_wizardcontabilizza");
				//				return new FrmEntrataGerarchico();		
			}

			if (FormName=="procedura")
			{
				Name="Entrate";
				DefaultListType = "default";	//unused
				SearchEnabled=false;
				return GetFormByDllName("income_procedura");
				//return new FrmEntrataProcedura();
			}

			if (FormName=="wizardestimatedetail"){
				CanInsert=false;
				SearchEnabled=false;
				MainRefreshEnabled=false;
				Name="Wizard contabilizzazione dettagli CONTRATTO";
				return MetaData.GetFormByDllName("income_wizardestimatedetail");
			}
            if (FormName == "wizardinvoicedetail")
            {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Wizard contabilizzazione fattura di Vendita";
                return MetaData.GetFormByDllName("income_wizardinvoicedetail");
            }
            if (FormName == "wizardinvoicedetailnoestimate") {
                CanInsert = false;
                SearchEnabled = false;
                MainRefreshEnabled = false;
                Name = "Wizard contabilizzazione fattura di Vendita senza Contratto";
                return MetaData.GetFormByDllName("income_wizardinvoicedetailnoestimate");
            }
			return null;
		}

        protected override void InsertCopyColumn (DataColumn C, DataRow Source, DataRow Dest) {
            if (C.ColumnName == "idpayment") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

		 void SetAutoIncrementProperties(DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idinc"], null, null, 0);
            //RowChange.MarkAsCustomAutoincrement(T.Columns["idinc"], new RowChange.CustomCalcAutoID(CalcIDInc));
			//Imposto i campi selettori utilizzati nel WHERE durante il calcolo dell'idinc
            RowChange.SetMySelector(T.Columns["nmov"], "nphase",0);
            RowChange.SetMySelector(T.Columns["nmov"], "ymov",0);
		
			RowChange.MarkAsAutoincrement(T.Columns["nmov"],null,null,0);
		}

        private static object CalcIDInc(DataRow R, DataColumn C, DataAccess Conn) {
            object oidinc = Conn.DO_READ_VALUE("income", null, "max(idinc)");
            int idinc = CfgFn.GetNoNullInt32(oidinc);
            return idinc + 1;
        }

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			SetAutoIncrementProperties(T);
            RowChange.setMinimumTempValue(T.Columns["nmov"], 900000000);
            RowChange.setMinimumTempValue(T.Columns["idinc"], 900000000);
            DataRow R = base.Get_New_Row(ParentRow, T);			
			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);

			if (PrimaryTable.ExtendedProperties["app_default"]!=null){
				Hashtable H = (Hashtable)PrimaryTable.ExtendedProperties["app_default"];
				foreach (string field in new string[]{"idinc","idreg",
														 "description", "doc", "docdate",
														 "idman", "nphase","autocode","autokind","idpayment","idunderwriting" })
                {
					if (H[field]!=null)	SetDefault(PrimaryTable, field, H[field]);
				}
				SetDefault(PrimaryTable, "ymov", GetSys("esercizio").ToString());
				SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));	
				return;
			}
			
			SetDefault(PrimaryTable, "ymov", GetSys("esercizio").ToString());
			if (CfgFn.GetNoNullInt32(PrimaryTable.Columns["nphase"].DefaultValue)==0)
				SetDefault(PrimaryTable, "nphase",1);
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="iva")
				return base.SelectOne("default",filter, "incomeinvoiceview", Exclude);
			if (ListingType=="estimate")
				return base.SelectOne("default",filter, "incomeestimateview", Exclude);
			return base.SelectOne(ListingType, filter, "incomeview", Exclude);
		}

		public override PostData Get_PostData() {
			if (edit_type!="procedura") return base.Get_PostData ();
			return new EntrataPostData();
		}

		public override void CalculateFields(DataRow R, string list_type) {
			base.CalculateFields (R, list_type);
			if (list_type == "posting") {
				impostaCampi(R, list_type);
			}
		}

	    private string lastEvaluatedDSGuid = null;
        Dictionary<int,DataRow> expenseById = new Dictionary<int, DataRow>();

	    Dictionary<int, DataRow> recalcExpenseById(DataSet d) {
	        var expenseById = new Dictionary<int, DataRow>();
	        if (!d.Tables.Contains("expense")) {
	            return expenseById;
	        }

	        foreach (DataRow r in d.Tables["expense"].Rows) {
	            expenseById[(int) r["idexp"]] = r;
	        }

	        return expenseById;
	    }

	    Dictionary<int,DataRow> evaluateExpenseById(DataSet d) {
	        object dsGuid = d.ExtendedProperties["postingGuid"];
	        if (dsGuid == null) return null;
	        if (dsGuid.ToString() == lastEvaluatedDSGuid) return expenseById;

	        expenseById = recalcExpenseById(d);
	        lastEvaluatedDSGuid = dsGuid.ToString();
	        return expenseById;
	    }

	    string getNMovBySelect(DataTable t, object idmov) {
	        DataRow[] Exp = t.Select(QHC.CmpEq("idexp", idmov));
	        if (Exp.Length == 0) return null;
	        string nMov = Exp[0]["nmov"].ToString();
	        while ((nMov.StartsWith("0")) && (nMov.Length > 0)) {
	            nMov = nMov.Substring(1,nMov.Length - 1);
	        }

	        return nMov;
	    }
		private void impostaCampi(DataRow R, string listingtype) {
			if (listingtype != "posting") return;
			if (R["autokind"] == DBNull.Value) return;
			if ((R["idpayment"] == DBNull.Value)) return;
		    string nMov;
		    Dictionary<int,DataRow> dict = evaluateExpenseById(R.Table.DataSet);
		    if (dict == null) {
		        object idmov = R["idpayment"];
		        nMov = getNMovBySelect(R.Table.DataSet.Tables["expense"], idmov);
		    }
		    else {
		        DataRow rExp;
		        if (!dict.TryGetValue((int) R["idpayment"], out rExp)) {
		            //è cambiato il ds
		            dict = recalcExpenseById(R.Table.DataSet);
		            if (!dict.TryGetValue((int) R["idpayment"], out rExp)) {
		                nMov = getNMovBySelect(R.Table.DataSet.Tables["expense"], R["idpayment"]);
		            }
		        }

		        nMov = rExp["nmov"].ToString();
		    }

		    //string nMov = idmov.Substring(idmov.Length - 6,6);
             

			

			//string suCosa = (R["idpayment"] != DBNull.Value) ? "su pagamento" : "su incasso";
            string suCosa = "su pagamento";

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

	public class EntrataPostData: Easy_PostData {
		int faseiva;
		int faseestimate;
		DataSet dsSource;

		public EntrataPostData(){		
		}
		
		public override bool DO_POST() {
			bool res = base.DO_POST();
			if (res) {
				if (dsSource!=null) {
					if (dsSource.Tables["income"].Rows.Count>0){
						DataRow SourceExpense=dsSource.Tables["income"].Rows[0];
						int fasefine = Convert.ToInt32( DS.Tables["income"].ExtendedProperties["faseentratafine"]);
						DataRow Last= DS.Tables["income"].Select("nphase="+fasefine)[0];
                        int idlastphase = CfgFn.GetNoNullInt32(Last["idinc"]);
                        SourceExpense["idinc"] = idlastphase;
						SourceExpense["nphase"]= fasefine;

                        if (dsSource.Tables["incomelast"].Rows.Count > 0) {
                            DataRow SourceIncomeLast = dsSource.Tables["incomelast"].Rows[0];
                            SourceIncomeLast["idinc"] = idlastphase;
                        }


                        if (dsSource.Tables["incomeyear"].Rows.Count > 0) {
                            DataRow SourceIncomeYear = dsSource.Tables["incomeyear"].Rows[0];
                            SourceIncomeYear["idinc"] = idlastphase;
                        }

					}

                    if (DS.Tables.Contains("proceeds")) {
                        foreach (DataRow rProceeds in DS.Tables["proceeds"].Rows) {
                            int kpro = CfgFn.GetNoNullInt32(rProceeds["kpro"]);
                            if (kpro == 0) continue;
                            Conn.CallSP("compute_proceeds_bank", new object[] { kpro });
                        }
                    }
				}
			}
			return res;
		}

		public override string InitClass(DataSet DS, DataAccess Conn) {
			
			if (DS.Tables["income"].Rows.Count==0) {
				return base.InitClass(DS,Conn);

			}
			DataSet DSP = DS.Copy();
			dsSource= DS;

			DS.ExtendedProperties["DSPData"]=DSP;
			
			foreach (DataTable T in DS.Tables){
				RowChange.CopyAutoIncrementProperties(T, DSP.Tables[T.TableName]);
			}

            faseestimate=-1;
			if ((DS.Tables["incomeestimate"]!=null)&&
				(DS.Tables["incomeestimate"].ExtendedProperties["faseattivazione"]!=null)){
				faseestimate= CfgFn.GetNoNullInt32(DS.Tables["incomeestimate"].ExtendedProperties["faseattivazione"]);
			}

            //faseestimate = CfgFn.GetNoNullInt32(Conn.GetSys("estimatephase"));
            faseiva = CfgFn.GetNoNullInt32(Conn.GetSys("invoiceincomephase"));

			DSP.EnforceConstraints=false;
			//Aggiunge la relazione padre/figlio per la tabella spesa
			DSP.Relations.Add("incomeincome", 
				DSP.Tables["income"].Columns["idinc"],
				DSP.Tables["income"].Columns["parentidinc"],false);
			SplitRowInPhases(DSP,Conn);
			return base.InitClass (DSP, Conn);
		}

      
		/// <summary>
		/// Dalla riga presente in DSP.spesa ne crea n (da faseinizio a fasefine)
		/// </summary>
		/// <param name="DSP"></param>
		void SplitRowInPhases(DataSet DSP, DataAccess Conn){
            CQueryHelper QHC = new CQueryHelper();
			try {
				int faseinizio = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["faseinizio"]);
				int fasefine = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["fasefine"]);
				int faseentratafine = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["faseentratafine"]);
				int faseentratamax = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["faseentratamax"]);
			
				int minfasecreditore = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["minfasecreditore"]);
				int minfasebilannuale = Convert.ToInt32( DSP.Tables["income"].ExtendedProperties["minfasebilannuale"]);
				int esercizio= (int)Conn.GetSys("esercizio");

		
				DataRow ExEntrata = DSP.Tables["income"].Rows[0];
				DataRow ExImpEntrata = DSP.Tables["incomeyear"].Rows[0];
                object previd = DBNull.Value;
				for (int fase = faseinizio; fase<=faseentratafine; fase++){
					DataRow NewRow= DSP.Tables["income"].NewRow();
					NewRow["idinc"] = MetaData.MaxFromColumn(DSP.Tables["income"],"idinc")+1;
					NewRow["nphase"] = fase;
					
					//Assegna l'ID fase precedente
					if (fase>1){
						if (fase==faseinizio)
							NewRow["parentidinc"]= ExEntrata["parentidinc"];
						else
							NewRow["parentidinc"]= previd;
                        //NewRow["idinc"]= 
                        //    NewRow["parentidinc"].ToString()+
                        //    esercizio.ToString().Substring(2)+
                        //    "980000";
						NewRow["ymov"] = esercizio;		
					}
					else {
						NewRow["parentidinc"]= DBNull.Value;
                        //NewRow["idinc"]= 
                        //    esercizio.ToString().Substring(2)+
                        //    "980000";
						//Per la prima fase soltanto prendo l'esercmovimento del form
						NewRow["ymov"] = ExEntrata["ymov"];		
					}
					//RowChange.CalcTemporaryID(NewRow); da problemi poiché gli ID esistono già
                    //NewRow["ycreation"]=esercizio;


					previd= NewRow["idinc"];  //da usare nella iterazione successiva

					//Copia tutti gli altri dati del movimento (rispettando l'ordine delle fasi)
					foreach (DataColumn C in DSP.Tables["income"].Columns){
						if (C.ColumnName == "idinc") continue;
						if (C.ColumnName == "nphase") continue;
						if (C.ColumnName == "parentidinc") continue;
						if (C.ColumnName == "ymov")continue;


						if ((C.ColumnName == "idreg")
								&& (fase < minfasecreditore))continue;

                        if ((C.ColumnName == "cupcode") && (fase != minfasecreditore)) continue;


						//Salta dati non appartenenti ad ultima fase
                        //if ((																			
                        //    (C.ColumnName == "ypro")||(C.ColumnName == "npro")||(C.ColumnName == "nbill")
                        //    )&& (fase != faseentratamax))continue;

						NewRow[C.ColumnName] = ExEntrata[C.ColumnName];
					}
					DSP.Tables["income"].Rows.Add(NewRow);

					//Aggiunge la riga di imputazione spesa
					DataRow NewImp = DSP.Tables["incomeyear"].NewRow();
					NewImp["idinc"]= NewRow["idinc"];
                    NewImp["ayear"]= esercizio;
                    //NewImp["nphase"] = fase;
					foreach (DataColumn C in DSP.Tables["incomeyear"].Columns){
						if (C.ColumnName == "idinc") continue;
						if (C.ColumnName == "ayear") continue;
						if ((C.ColumnName == "idfin") && (fase < minfasebilannuale))continue;
						if ((C.ColumnName == "idupb") && (fase < minfasebilannuale))continue;
						NewImp[C.ColumnName] = ExImpEntrata[C.ColumnName];
					}
					DSP.Tables["incomeyear"].Rows.Add(NewImp);

					if ((fase== faseiva)&&
						(DSP.Tables["incomeinvoice"]!=null)) {
						foreach(DataRow ChildR in DSP.Tables["incomeinvoice"].Rows){
							ChildR["idinc"]= NewRow["idinc"];
						}
					}

					if (fase == faseentratamax){
						//Sposta le righe figlie dalla riga originale a questa
						foreach (DataTable ChildT in new DataTable[] {
                                    DSP.Tables["incomelast"],
									DSP.Tables["proceedspart"],
                                    DSP.Tables["incomebill"]
						}){
							foreach(DataRow ChildR in ChildT.Rows){
								ChildR["idinc"]= NewRow["idinc"];
							}
						}


						if (fasefine>faseentratamax){
							//Collega l'ultima fase al documento di pagamento
                            DSP.Tables["incomelast"].Rows[0]["kpro"] = DSP.Tables["proceeds"].Rows[0]["kpro"];
                            //NewRow["ypro"]= DSP.Tables["proceeds"].Rows[0]["ypro"];
                            //NewRow["npro"]= DSP.Tables["proceeds"].Rows[0]["npro"];
						}
						else {
                            //NewRow["ypro"]= DBNull.Value;
                            DSP.Tables["incomelast"].Rows[0]["kpro"] = DBNull.Value;
						}

					}

					if (fase == minfasebilannuale) {
						//Sposta le righe in assegnazionecrediti dalla riga originale a questa
						foreach(DataRow ChildR in DSP.Tables["creditpart"].Rows){
							ChildR["idinc"]= NewRow["idinc"];
						}
					}
//					if ((fase== faseestimate)&&
//						(DSP.Tables["incomeestimate"]!=null)) {
//						foreach(DataRow ChildR in DSP.Tables["incomeestimate"].Rows){
//							ChildR["idinc"]= NewRow["idinc"];
//						}
//					}
					//
					if ((fase== faseestimate)&&
						(DSP.Tables["incomeestimate"]!=null)) 
					{
						int movkind=0;
						foreach(DataRow ChildR in DSP.Tables["incomeestimate"].Rows)
						{
							ChildR["idinc"]= NewRow["idinc"];
							movkind=CfgFn.GetNoNullInt32(ChildR["movkind"]);
						}
						if (DSP.Tables["estimatedetail_taxable"]!=null)
						{
							foreach(DataRow ChildRR in DSP.Tables["estimatedetail_taxable"].Rows)
							{
								switch(movkind)
								{
									case 1:
                                        if (ChildRR["idinc_taxable"] != DBNull.Value) 
                                        {
                                                ChildRR["idinc_taxable"] = NewRow["idinc"]; 
                                        }
                                        if (ChildRR["idinc_iva"] != DBNull.Value) 
                                        { 
                                            ChildRR["idinc_iva"] = NewRow["idinc"]; 
                                        }
										break;
									case 3:
                                        if (ChildRR["idinc_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_taxable"] = NewRow["idinc"];
                                        }
										break;
								}

							}
						}
						if (DSP.Tables["estimatedetail_iva"]!=null)
						{
							foreach(DataRow ChildRR in DSP.Tables["estimatedetail_iva"].Rows)
							{
								switch(movkind)
								{
									case 2:
                                        if (ChildRR["idinc_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_iva"] = NewRow["idinc"];
                                        }
										break;
								}

							}
						}

					}
					if ((fase== faseiva)&&
						(DSP.Tables["incomeinvoice"]!=null)) {
						int movkind=0;
						foreach(DataRow ChildR in DSP.Tables["incomeinvoice"].Rows)	{
							ChildR["idinc"]= NewRow["idinc"];
							movkind=CfgFn.GetNoNullInt32(ChildR["movkind"]);
						}
						if (DSP.Tables["invoicedetail_taxable"]!=null)
						{
							foreach(DataRow ChildRR in DSP.Tables["invoicedetail_taxable"].Rows)
							{
								switch(movkind)
								{
									case  1:
                                        if (ChildRR["idinc_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_taxable"] = NewRow["idinc"];
                                        }
                                        
                                        if (ChildRR["idinc_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_iva"] = NewRow["idinc"];
                                        }
										break;
									case 3:
                                        if (ChildRR["idinc_taxable"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_taxable"] = NewRow["idinc"];
                                        }
										break;
								}

							}
						}
						if (DSP.Tables["invoicedetail_iva"]!=null)
						{
							foreach(DataRow ChildRR in DSP.Tables["invoicedetail_iva"].Rows)
							{
								switch(movkind)
								{
									case 2:
                                        if (ChildRR["idinc_iva"] != DBNull.Value)
                                        {
                                            ChildRR["idinc_iva"] = NewRow["idinc"];
                                        }
										break;
								}

							}
						}

					}
					//

					//Sposta le classificazioni di quella fase 
					foreach(DataRow ClassR in DSP.Tables["incomesorted"].Rows){
                        DataRow ClassMov = ClassR.GetParentRow("sortingincomesorted");
                        if (ClassMov == null) continue;
                        string searchparent = QHC.CmpEq("idsorkind", ClassMov["idsorkind"]);
                        DataTable SorKind = ClassMov.Table.DataSet.Tables["sortingkind"];
                        DataRow[] TipoClassRs = SorKind.Select(searchparent);
                        if (TipoClassRs.Length == 0) continue;
                        DataRow TipoClassR = TipoClassRs[0];
                        if (TipoClassR == null) continue;
						if (Convert.ToInt32(TipoClassR["nphaseincome"])!=fase) continue;
						ClassR["idinc"]= NewRow["idinc"];
					}
				
				}  //Fine del for relativo alle fasi

				if (DSP.Tables["proceeds"].Rows.Count>0){
					DataRow Incasso= DSP.Tables["proceeds"].Rows[0];
					Incasso["txt"]=ExEntrata["txt"];
					Incasso["rtf"]=ExEntrata["rtf"];
				}

				ExImpEntrata.Delete();
				ExEntrata.Delete();

				if (fasefine<=faseentratamax){
					DSP.Tables["proceeds"].Clear();
				}

                if (fasefine < faseentratamax && DSP.Tables["incomelast"] != null) {
                    DSP.Tables["incomelast"].Clear();
                }
                if (fasefine < faseentratamax && DSP.Tables["incomebill"] != null) {
                    DSP.Tables["incomebill"].Clear();
                }
			}
			catch (Exception e){
				MessageBox.Show(e.Message);
			}
		}

	}
}
