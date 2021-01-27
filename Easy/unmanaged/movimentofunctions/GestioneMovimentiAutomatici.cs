
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;


namespace movimentofunctions {

  
	/// <summary>
	/// Summary description for GestioneMovimentiAutomatici.
	/// </summary>
	public class GestioneMovimentiAutomatici {
		DataSet ds;
		DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public AutoTablesCache Cache;

        public const int IDAUTOKIND_RITENUTA = 4;
        public const int IDAUTOKIND_RECUPERO = 6;
        public const int IDAUTOKIND_CONTRIBUTO = 8;
        int esercizio;
        object mainidman_obj;

        public GestioneMovimentiAutomatici(DataAccess Conn, DataSet ds) {
            Init(Conn, ds);
            Cache = new AutoTablesCache(Conn);
        }
        
		public GestioneMovimentiAutomatici(DataAccess Conn, DataSet ds,AutoTablesCache Cache) {
            Init(Conn, ds);
            this.Cache = Cache;
		}

        void Init(DataAccess Conn, DataSet ds) {
            this.ds = ds;
            this.Conn = Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            mainidman_obj = Conn.DO_READ_VALUE("upb",
                QHS.CmpEq("idupb", "0001"), "idman");
        }


        private int calcolaAdminTaxKind(IDictionary<string, object> Pers) {
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

        private int calcolaClawBackKind(IDictionary<string, object> Pers) {
            int automanagekind = CfgFn.GetNoNullInt32(Pers["automanagekind"]);
            int cbk = automanagekind & 0xF0;

            if (cbk != 0) return 1;
            return 0;
        }

        private int calcolaEmployTaxKind(IDictionary<string,object> Pers) {
            int automanagekind = CfgFn.GetNoNullInt32(Pers["automanagekind"]);
            int atk = automanagekind & 0xF00;
            switch (atk) {
                case 256: {
                        return 0;
                    }
                case 512: {
                        return 1;
                    }
                case 1024: {
                        return 2;
                    }
            }
            return 0;
        }



      

		/// <summary>
        /// Metodo che sostituisce la funzione della SP computed_linked_tax. 
		/// </summary>
		/// <param name="rSpesa">Data Row di expense</param>
		/// <param name="rImpSpesa">DataRow di expenseyear</param>
        /// <param name="rExpenseLast">DataRow di expenselast</param>
		/// <returns></returns>
        public DataTable calcolaAutomatismi(DataRow rSpesa, DataRow rImpSpesa, DataRow rExpenseLast) {
			if (rSpesa == null) return null;
			object idexp = rSpesa["idexp"];
			int ayear = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            
			// Inizio Sezione di dichiarazione delle variabili
			object ymov;
			object nmov;
			object idreg;
			object idman;
			object idfin;
			object idupb;
			int employtaxkind;
			int admintaxkind;
			object idfinadmintax;
            object idupbadmintax;
            decimal admintax;
			decimal employtax;
			decimal totadmintax;
			decimal totemploytax;
			object tmpidreg;
			object tmpidfin;
			object tmpidupb;
			int codente = 0;
			object mainidupb;
			// Fine Sezione Dichiarazione Variabili
            string fEsercizio = QHS.CmpEq("ayear", ayear);
            string fIdExp = QHS.CmpEq("idexp", idexp);
			mainidupb = "0001";
			
			DataTable tTax = new DataTable();
			tTax.Columns.Add("taxcode", typeof(int));
			tTax.Columns.Add("description", typeof(string));
			tTax.Columns.Add("idfinincomecontra", typeof(int));
			tTax.Columns.Add("idupbincomecontra", typeof(string));
            tTax.Columns.Add("idfinincomeemploy", typeof(string));
            tTax.Columns.Add("idfinadmintax", typeof(int));
			tTax.Columns.Add("idupbadmintax", typeof(string));
			tTax.Columns.Add("idfinexpensecontra", typeof(int));
			tTax.Columns.Add("employtax", typeof(decimal));
			tTax.Columns.Add("admintax", typeof(decimal));
			tTax.Columns.Add("idexp", typeof(int));

			
			bool esisteParIdExp = false;
			if (ds.Tables["expensetax"].Columns.Contains("!parentidexp")) {
				tTax.Columns.Add("livsupid", typeof(int));
				esisteParIdExp = true;
			}

			DataTable tAutomov = new DataTable();
			tAutomov.Columns.Add("movkind", typeof(string));
			tAutomov.Columns.Add("idman", typeof(int));
			tAutomov.Columns.Add("idreg", typeof(int));
			tAutomov.Columns.Add("idfin", typeof(int));
			tAutomov.Columns.Add("idupb", typeof(string));
			tAutomov.Columns.Add("description", typeof(string));
			tAutomov.Columns.Add("amount", typeof(decimal));
			tAutomov.Columns.Add("autocode", typeof(int));
			tAutomov.Columns.Add("autokind", typeof(byte));
			tAutomov.Columns.Add("idmovimento", typeof(int));
		    tAutomov.Columns.Add("doc", typeof(string));
		    tAutomov.Columns.Add("docdate", typeof(DateTime));

            if (ds.Tables["expensetax"].Columns.Contains("!parentidexp")) {
				tAutomov.Columns.Add("livsupid", typeof(int));
			}


            if (!Cache.config.HasValueFor(esercizio)) return null;

            Dictionary<string, object> rExpenseSetup = Cache.config.ReadValuesFor(esercizio);

            employtaxkind = calcolaEmployTaxKind(rExpenseSetup);
            admintaxkind = calcolaAdminTaxKind(rExpenseSetup);

			codente = CfgFn.GetNoNullInt32(rExpenseSetup["idregauto"]);

            //Cache.taxsetup.ReadValuesRelatedTo(ds.Tables["expensetax"], "taxcode");
            Cache.tax.ReadValuesRelatedTo(ds.Tables["expensetax"], "taxcode");

			if ((employtaxkind != 0) || (admintaxkind != 0)) {
			
				ymov = CfgFn.GetNoNullInt32(rSpesa["ymov"]);
				nmov = CfgFn.GetNoNullInt32(rSpesa["nmov"]);
				idreg = CfgFn.GetNoNullInt32(rSpesa["idreg"]);
				idman = rSpesa["idman"];
				idfin = rImpSpesa["idfin"];
				idupb = rImpSpesa["idupb"];
				//flagarrear = rImpSpesa["flagarrear"].ToString().ToUpper();

				foreach(DataRow rExpenseTax in ds.Tables["expensetax"].Select(fIdExp)) {
                    object taxcode = rExpenseTax["taxcode"];
                    if (!Cache.tax.HasValueFor(taxcode)) continue;
                    if (!Cache.hasValueForTaxConfig(rExpenseLast["idser"], taxcode))
                        continue;
                    Dictionary<string, object> rTaxSetup = Cache.getTaxConfig(rExpenseLast["idser"], taxcode);
                    Dictionary<string, object> rTaxKind = Cache.tax.GetRow(taxcode);

                    string fTaxCode = QHS.CmpEq("taxcode", rExpenseTax["taxcode"]);
					DataRow []Found = tTax.Select(fTaxCode);

					DataRow rTax;
					if (Found.Length == 0) {
						rTax = tTax.NewRow();
						rTax["taxcode"] = rExpenseTax["taxcode"];
						rTax["idexp"] = rExpenseTax["idexp"];
						rTax["description"] = rTaxKind["description"];
						rTax["admintax"] = rExpenseTax["admintax"];
						rTax["employtax"] = rExpenseTax["employtax"];
						rTax["idfinincomecontra"] = rTaxSetup["idfinincomecontra"];
                        rTax["idfinincomeemploy"] = rTaxSetup["idfinincomeemploy"];
                        rTax["idupbincomecontra"] = mainidupb;
						rTax["idfinadmintax"] = rTaxSetup["idfinadmintax"];
						rTax["idupbadmintax"] = idupb;
						rTax["idfinexpensecontra"] = rTaxSetup["idfinexpensecontra"];

						if (esisteParIdExp) {
							rTax["livsupid"] = rExpenseTax["!parentidexp"];
						}
						tTax.Rows.Add(rTax);
					}
					else {
						rTax = Found[0];
						if (rTax["admintax"] != DBNull.Value) {
							rTax["admintax"] = CfgFn.GetNoNullDecimal(rTax["admintax"])
								+ CfgFn.GetNoNullDecimal(rExpenseTax["admintax"]);
						}
						if (rTax["employtax"] != DBNull.Value) {
							rTax["employtax"] = CfgFn.GetNoNullDecimal(rTax["employtax"])
								+ CfgFn.GetNoNullDecimal(rExpenseTax["employtax"]);
						}
					}
				}
				if (tTax.Rows.Count == 0) return null;
                totadmintax = MetaData.SumColumn(tTax, "admintax");
                totemploytax = MetaData.SumColumn(tTax, "employtax");

                // GENERAZIONE DEI MOVIMENTI RELATIVI AI CONTRIBUTI
				if (totadmintax > 0 ) {
					/* CONTRIBUTI -- IMPOSTAZIONE 1 */
					if (admintaxkind == 1) {
						foreach(DataRow rTax in tTax.Select(QHS.IsNotNull("admintax"),"taxcode")) {

							admintax = CfgFn.GetNoNullDecimal(rTax["admintax"]);

							if (admintax == 0) continue;

                          
							tmpidreg = codente;

							idfinadmintax = rTax["idfinadmintax"];
                            tmpidfin = (idfinadmintax == DBNull.Value) ? idfin : idfinadmintax;
						
							idupbadmintax = rTax["idupbadmintax"];
                            tmpidupb = (idupbadmintax == DBNull.Value) ? idupb : idupbadmintax;
						
							DataRow rAutomovS = tAutomov.NewRow();
							if (esisteParIdExp) {
								rAutomovS["livsupid"] = rTax["livsupid"];
							}
							rAutomovS["movkind"] = "Spesa";
							rAutomovS["idman"] = idman;
							rAutomovS["idreg"] = tmpidreg;
							rAutomovS["idfin"] = tmpidfin;
							rAutomovS["idupb"] = tmpidupb;
							// Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
							// in quanto nmov è un campo ad autoincremento
							rAutomovS["description"] = rTax["description"] + " su pagamento eserc. " + ymov + " n. " + nmov;
							rAutomovS["amount"] = admintax;
							rAutomovS["autocode"] = rTax["taxcode"];
                            rAutomovS["autokind"] = IDAUTOKIND_CONTRIBUTO;
						    rAutomovS["doc"] = rSpesa["doc"];
						    rAutomovS["docdate"] = rSpesa["docdate"];
                            tAutomov.Rows.Add(rAutomovS);

							tmpidfin = rTax["idfinincomecontra"];
							tmpidupb = rTax["idupbincomecontra"];
						
							DataRow rAutomovE = tAutomov.NewRow();
							rAutomovE["movkind"] = "Entrata";
							rAutomovE["idman"] = idman;
							rAutomovE["idreg"] = tmpidreg;
							rAutomovE["idfin"] = tmpidfin;
							rAutomovE["idupb"] = tmpidupb;
							// Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
							// in quanto nmov è un campo ad autoincremento
							rAutomovE["description"] = rTax["description"] + " su pagamento eserc. " + ymov + " n. " + nmov;
							rAutomovE["amount"] = admintax;
							rAutomovE["autocode"] = rTax["taxcode"];
                            rAutomovE["autokind"] = IDAUTOKIND_CONTRIBUTO;
						    rAutomovE["doc"] = rSpesa["doc"];
						    rAutomovE["docdate"] = rSpesa["docdate"];
                            tAutomov.Rows.Add(rAutomovE);
						}
					} // if (@admintaxkind == "1")

					/* CONTRIBUTI -- IMPOSTAZIONE 2 */
					if (admintaxkind == 2) {

						foreach(DataRow rTax in tTax.Select(QHS.IsNotNull("admintax"),"taxcode")) {
							admintax = CfgFn.GetNoNullDecimal(rTax["admintax"]);
							if (admintax == 0) continue;

                            string searchcontrib= QHC.AppAnd( QHC.CmpEq("autocode", rTax["taxcode"]),
                                        QHC.CmpEq("autokind",IDAUTOKIND_CONTRIBUTO),
                                        QHC.CmpEq("movkind","Variazione Spesa"));
                            DataRow[] contrfound = tAutomov.Select(searchcontrib);
                            DataRow rAutomovS;
                            if (contrfound.Length == 0) {
                                rAutomovS = tAutomov.NewRow();
                                rAutomovS["movkind"] = "Variazione Spesa";
                                rAutomovS["idman"] = DBNull.Value;
                                rAutomovS["idreg"] = DBNull.Value;
                                rAutomovS["idfin"] = DBNull.Value;
                                rAutomovS["idupb"] = DBNull.Value;
                                rAutomovS["description"] = rTax["description"].ToString() +
                                    " su pagamento eserc. " + ymov + " n. " + nmov;
                                rAutomovS["autocode"] = rTax["taxcode"];
                                rAutomovS["autokind"] = IDAUTOKIND_CONTRIBUTO;
                                rAutomovS["amount"] =   admintax; // totadmintax;
                                tAutomov.Rows.Add(rAutomovS);
                                rAutomovS["doc"] = rSpesa["doc"];
                                rAutomovS["docdate"] = rSpesa["docdate"];
                            }
                            else {
                                rAutomovS = contrfound[0];
                                rAutomovS["amount"] = CfgFn.GetNoNullDecimal(rAutomovS["amount"]) + admintax; // totadmintax;
                            }

                            // Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
                            // in quanto nmov è un campo ad autoincremento
                            
                            tmpidreg = idreg;
							tmpidfin = rTax["idfinincomecontra"];
							tmpidupb = rTax["idupbincomecontra"];
						
							DataRow rAutomovE = tAutomov.NewRow();
							rAutomovE["movkind"] = "Entrata";
							rAutomovE["idman"] = idman;
							rAutomovE["idreg"] = tmpidreg;
							rAutomovE["idfin"] = tmpidfin;
							rAutomovE["idupb"] = tmpidupb;
							// Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
							// in quanto nmov è un campo ad autoincremento
							rAutomovE["description"] = rTax["description"] + " su pagamento eserc. " + ymov + " n. " + nmov;
							rAutomovE["amount"] = admintax;
							rAutomovE["autocode"] = rTax["taxcode"];
                            rAutomovE["autokind"] = IDAUTOKIND_CONTRIBUTO;
						    rAutomovE["doc"] = rSpesa["doc"];
						    rAutomovE["docdate"] = rSpesa["docdate"];
                            tAutomov.Rows.Add(rAutomovE);
						}
					} // if (@admintaxkind == "2")
				} // if (totadmintax > 0 && (flagarrearsadmintax == "N" || flagarrear == "C"))

				// GENERAZIONE DEI MOVIMENTI RELATIVI ALLE RITENUTE
				/* RITENUTE -- IMPOSTAZIONE 1 */
				if (employtaxkind == 1) {
					foreach(DataRow rTax in tTax.Select(QHS.IsNotNull("employtax"),"taxcode")) {
						employtax = CfgFn.GetNoNullDecimal(rTax["employtax"]);

						if (employtax == 0) continue;

						decimal amount = 0;
						string m_kind = "";
						tmpidreg = 0;
						tmpidfin = "";
						tmpidupb = "";

						if (employtax > 0) {
							tmpidreg = idreg;
                            tmpidfin = rTax["idfinincomeemploy"];
							tmpidupb = rTax["idupbincomecontra"];
							amount = employtax;
							m_kind = "Entrata";
						}
						// Caso in cui vi è una ritenuta c/dip. negativa
						if (employtax < 0) {
							tmpidreg = idreg;

							object idupbexpensecontra;
							idupbexpensecontra = rTax["idupbincomecontra"];
                            object idfinexpensecontra;
							idfinexpensecontra = rTax["idfinexpensecontra"];
							tmpidfin = idfinexpensecontra;
							tmpidupb = idupbexpensecontra;
							amount = -employtax;
							m_kind = "Spesa";
						}

						DataRow rAutomov = tAutomov.NewRow();
						rAutomov["movkind"] = m_kind;
						rAutomov["idman"] = idman;
						rAutomov["idreg"] = tmpidreg;
						rAutomov["idfin"] = tmpidfin;
						rAutomov["idupb"] = tmpidupb;
						// Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
						// in quanto nmov è un campo ad autoincremento
						rAutomov["description"] = rTax["description"] + " su pagamento eserc. " + ymov + " n. " + nmov;
						rAutomov["amount"] = amount;
						rAutomov["autocode"] = rTax["taxcode"];
                        rAutomov["autokind"] = IDAUTOKIND_RITENUTA;
					    rAutomov["doc"] = rSpesa["doc"];
					    rAutomov["docdate"] = rSpesa["docdate"];
                        tAutomov.Rows.Add(rAutomov);
					}
				} // if (@employtaxkind == "1")
				/* RITENUTE -- IMPOSTAZIONE 2 */
				if (employtaxkind == 2) {
					if (totemploytax > 0) {
						DataRow rAutomovS = tAutomov.NewRow();
						rAutomovS["movkind"] = "Variazione Spesa";
						rAutomovS["idman"] = DBNull.Value;
						rAutomovS["idreg"] = DBNull.Value;
						rAutomovS["idfin"] = DBNull.Value;
						rAutomovS["idupb"] = DBNull.Value;
						// Eventualmente questa riga deve essere riempita + tardi o la descrizione deve essere diversa
						// in quanto nmov è un campo ad autoincremento
						rAutomovS["description"] = "Ritenute "
							+ " su pagamento eserc. " + ymov + " n. " + nmov;
						rAutomovS["amount"] = - totemploytax;
                        rAutomovS["autocode"] = DBNull.Value;
                        rAutomovS["autokind"] = IDAUTOKIND_RITENUTA;
					    rAutomovS["doc"] = rSpesa["doc"];
					    rAutomovS["docdate"] = rSpesa["docdate"];
                        tAutomov.Rows.Add(rAutomovS);
					}



				} // if (@employtaxkind == "2")




			
				tAutomov.Columns.Add("codefin", typeof(string));
				tAutomov.Columns.Add("codeupb", typeof(string));
				tAutomov.Columns.Add("manager", typeof(string));
				tAutomov.Columns.Add("registry", typeof(string));
				if (tAutomov.Rows.Count > 0) {
                    Cache.fin.EvaluateFieldFromKey(tAutomov, "idfin", "codefin", "codefin");
                    Cache.upb.EvaluateFieldFromKey(tAutomov, "idupb", "codeupb", "codeupb");
                    Cache.manager.EvaluateFieldFromKey(tAutomov, "idman", "manager", "title");
                    Cache.registry.EvaluateFieldFromKey(tAutomov, "idreg", "registry", "title");
				}
			}	// IF (@employtaxkind != '0' AND @employtaxkind IS NOT NULL) OR 
				// @admintaxkind != '0' AND @admintaxkind IS NOT NULL)
            return tAutomov; // Ordina(tAutomov, "movkind ASC ,registry ASC ,codeupb ASC ,codefin ASC"); 
		}

       
		/// <summary>
        /// Metodo che sostituisce la funzione della SP computed_linked_clawback. Nota: Metodo che sostituisce la funzione della SP computed_linked_tax. 
        /// Nota: richiama calcInfo per completare codefin,codeupb,registry,manager
		/// </summary>
		/// <param name="rSpesa">Data Row di expense</param>
		/// <param name="rImpSpesa">DataRow di expenseyear</param>
		/// <returns></returns>
		public DataTable calcolaAutoRecuperi(DataRow rSpesa, DataRow rImpSpesa) {
			if (rSpesa == null) return null;
			object idexp = rSpesa["idexp"];
			int ayear = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

			// Inizio Sezione di dichiarazione delle variabili
			int ymov;
			int nmov;
			object idman;
			object idreg;
			int clawbackkind;		
			object idupb;
			object mainidupb;
			// Fine Sezione Dichiarazione Variabili

			DataTable tClawBack = new DataTable();
			tClawBack.Columns.Add("idclawback", typeof(int));
			tClawBack.Columns.Add("description", typeof(string));
			tClawBack.Columns.Add("idfin", typeof(int));
			tClawBack.Columns.Add("idupb", typeof(string));
			tClawBack.Columns.Add("amount", typeof(decimal));

			DataTable tAutomov = new DataTable();
			tAutomov.Columns.Add("movkind", typeof(string));
			tAutomov.Columns.Add("idman", typeof(int));
			tAutomov.Columns.Add("idreg", typeof(int));
			tAutomov.Columns.Add("idfin", typeof(int));
			tAutomov.Columns.Add("idupb", typeof(string));
			tAutomov.Columns.Add("description", typeof(string));
			tAutomov.Columns.Add("amount", typeof(decimal));
			tAutomov.Columns.Add("autocode", typeof(int));

            string fEsercizio = QHS.CmpEq("ayear", ayear);
            string fIdExp = QHS.CmpEq("idexp", idexp);
            string fAmount1 = QHS.CmpGt("amount", 0);
			string fExpenseAmount = GetData.MergeFilters(fIdExp,fAmount1);

			mainidupb = "0001";

            if (!Cache.config.HasValueFor(esercizio)) return null;

            Dictionary<string, object> rExpenseSetup = Cache.config.ReadValuesFor(esercizio);
			clawbackkind = calcolaClawBackKind(rExpenseSetup);

            Cache.clawbacksetup.ReadValuesRelatedTo(ds.Tables["expenseclawback"], "idclawback");
            Cache.clawback.ReadValuesRelatedTo(ds.Tables["expenseclawback"], "idclawback");

            if (clawbackkind != 0) {
				ymov = CfgFn.GetNoNullInt32(rSpesa["ymov"]);
				nmov = CfgFn.GetNoNullInt32(rSpesa["nmov"]);
				idreg = rSpesa["idreg"];
				idman = rSpesa["idman"];
				idupb = rImpSpesa["idupb"];

				foreach(DataRow rExpenseClawback in ds.Tables["expenseclawback"].Select(fExpenseAmount)) {
                    object idclawback=rExpenseClawback["idclawback"];
                    if (!Cache.clawbacksetup.HasValueFor(idclawback)) continue;
                    Dictionary<string, object> rClawbackSetup = Cache.clawbacksetup.ReadValuesFor(idclawback);

                    if (!Cache.clawback.HasValueFor(idclawback)) continue;
                    Dictionary<string, object> rClawbackKind = Cache.clawback.ReadValuesFor(idclawback);

					DataRow rClawBack = tClawBack.NewRow();
					rClawBack["idclawback"] = rExpenseClawback["idclawback"];
					rClawBack["description"] = rClawbackKind["description"] + " su pagamento eserc. " + ymov + " n. " + nmov;
					rClawBack["idfin"] = rClawbackSetup["clawbackfinance"];
					rClawBack["idupb"] = mainidupb;
					rClawBack["amount"] = rExpenseClawback["amount"];
					tClawBack.Rows.Add(rClawBack);
				}
				if (tClawBack.Rows.Count == 0) return null;
				DataRow []Found = tClawBack.Select(QHC.IsNotNull("idfin"));
				if (Found.Length == 0) return null;
				
				//Generazione automatismi recuperi
				if ( clawbackkind ==  1) {
					DataRow []Found1 = tClawBack.Select(QHC.IsNotNull("amount"),"idclawback ASC");
					if (Found1.Length == 0) return null;
					foreach (DataRow R in Found1)  {
						DataRow rAutomovE = tAutomov.NewRow();
						rAutomovE["movkind"] = "Entrata";
						rAutomovE["idman"] = idman;
						rAutomovE["idreg"] = idreg;
						rAutomovE["idfin"] = R["idfin"];
						rAutomovE["idupb"] = R["idupb"];
                        rAutomovE["description"] = R["description"];// +" su pagamento eserc. " + ymov + " n. " + nmov;
						rAutomovE["amount"] = R["amount"];
						rAutomovE["autocode"] = R["idclawback"];
						tAutomov.Rows.Add(rAutomovE);
					}
				}
			
				tAutomov.Columns.Add("codefin", typeof(string));
				tAutomov.Columns.Add("codeupb", typeof(string));
				tAutomov.Columns.Add("manager", typeof(string));
				tAutomov.Columns.Add("registry", typeof(string));
				if (tAutomov.Rows.Count > 0) {
                    Cache.fin.EvaluateFieldFromKey(tAutomov, "idfin", "codefin", "codefin");
                    Cache.upb.EvaluateFieldFromKey(tAutomov, "idupb", "codeupb", "codeupb");
                    Cache.manager.EvaluateFieldFromKey(tAutomov, "idman", "manager", "title");
                    Cache.registry.EvaluateFieldFromKey(tAutomov, "idreg", "registry", "title");
				}
			} // if ((clawbackkind != "0") && (clawbackkind != "")) 
			//implementare ORDER BY #automov.movkind, registry,  upb.codeupb,fin.codefin
            return tAutomov; // Ordina(tAutomov, "movkind ASC,registry ASC,codeupb ASC,codefin ASC"); 
		}
		
		/// <summary>


		public DataTable calcInfo (DataTable Dest, string KeyName, string parentName, string []ParentFieldName, string []DestFieldName){
			if (Dest==null) return Dest;
			if (ParentFieldName.Length != DestFieldName.Length) return Dest;
			
			//Costruisco un filtro per la ricerca nella tabella parentName
            if (Dest.Select().Length == 0) return Dest;
            string filter  = QHS.FieldIn(KeyName, Dest.Select(), KeyName);
			DataTable parentTable = Conn.RUN_SELECT(parentName,"*",null,filter,null,true);
			if (parentTable.Rows.Count==0) return Dest;
			foreach (DataRow ParentRow in parentTable.Rows){
				foreach(DataRow  Row in Dest.Rows){
					// Inserimento valori in Dest
					if (ParentRow[KeyName].ToString().ToUpper() == Row[KeyName].ToString().ToUpper()) {
						for (int i=0; i<DestFieldName.Length; i++){
                            Row[DestFieldName[i]] = ParentRow[ParentFieldName[i]]; 
						}
					}
				}
			 }
			return Dest;
		 }

		
		 public DataTable Ordina(DataTable T, string Sorting){
			if (T==null) return T;
			if (Sorting==""||Sorting==null) return T;
			DataRow []Found = T.Select(null,Sorting);
			DataTable Ordered = T.Clone();
			Ordered.Clear();
			foreach (DataRow Row in Found){
				DataRow rOrd = Ordered.NewRow();
				foreach(DataColumn C in T.Columns) {
					rOrd[C.ColumnName] = Row[C];
				}
				Ordered.Rows.Add(rOrd);
			}
			return Ordered;
		 }
		
	}

}
