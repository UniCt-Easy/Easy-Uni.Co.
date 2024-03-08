
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_registrypaymethod {//meta_modpagamentocreddebi//
	/// <summary>
	/// Revised by Nino on 11/1/2003
	/// </summary>
	public class Meta_registrypaymethod : Meta_easydata {
		public Meta_registrypaymethod(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registrypaymethod") {
			Name= "Modalità pagamento";
			//EditTypes.Add("default");
			ListingTypes.Add("default");
			//EditTypes.Add("modalitacredeb");
			//ListingTypes.Add("modalitacredeb");
			//Nuova Anagrafica
			EditTypes.Add("modpaganagrafica");
			ListingTypes.Add("modpaganagrafica");
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
            ListingTypes.Add("unione");
		}
		protected override Form GetForm(string FormName){

			if (FormName=="modpaganagrafica") {
				DefaultListType="modpaganagrafica";
				Name="Modalità di pagamento (di Anagrafica)";
				return GetFormByDllName("registrypaymethod_modpaganagrafica");
			}
			if (FormName=="anagrafica") 
				return GetFormByDllName("registrypaymethod_anagrafica");

			return null;
		}	
		

		public override DataRow SelectOne(string ListingType, 
			string filter, string searchtable, DataTable ToMerge) {
			
			if(ListingType=="modpaganagrafica")
				return base.SelectOne(ListingType, filter, 
					"registrypaymethodview", ToMerge);

			return base.SelectOne(ListingType, filter, 
				searchtable, ToMerge);
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrypaymethod"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idregistrypaymethod"], 9999);
            return base.Get_New_Row(ParentRow, T);
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                AddColumn(T, "descrmodalita", typeof(string), "paymethod.description", "Modalità");
                //if (T.DataSet!=null && T.DataSet.Tables["registry"] != null) DescribeAColumn(T, "idreg", "", 1);
                int nPos = 1;
                DescribeAColumn(T, "idregistrypaymethod", "#", nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "cin", "CIN", nPos++);
                DescribeAColumn(T, "regmodcode", "Nome", nPos++);
                DescribeAColumn(T, "idpaymethod", "", nPos++);
                DescribeAColumn(T, "idbank", "Cod. ABI", nPos++);
                DescribeAColumn(T, "idcab", "Cod. CAB", nPos++);
                DescribeAColumn(T, "flagstandard", "Predef.", nPos++);
                DescribeAColumn(T, "cc", "C/C", nPos++);
                DescribeAColumn(T, "paymentdescr", "Descrizione", nPos++);
                DescribeAColumn(T, "paymentexpiring", "", nPos++);
                DescribeAColumn(T, "idexpirationkind", "", nPos++);
                DescribeAColumn(T, "active", "attivo", nPos++);
            }
            if (ListingType == "unione") {
                //AddColumn(T, "descrmodalita", typeof(string), "paymethod.description", "Modalità");
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "idregistrypaymethod", "##", nPos++);
                DescribeAColumn(T, "!tipomodalita", "Tipo", nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "cin", "CIN", nPos++);
                DescribeAColumn(T, "regmodcode", "Nome", nPos++);
                DescribeAColumn(T, "idpaymethod", "", nPos++);
                DescribeAColumn(T, "idbank", "Cod. ABI", nPos++);
                DescribeAColumn(T, "idcab", "Cod. CAB", nPos++);
                DescribeAColumn(T, "flagstandard", "Predef.", nPos++);
                DescribeAColumn(T, "cc", "C/C", nPos++);
                DescribeAColumn(T, "paymentdescr", "Descrizione", nPos++);
                DescribeAColumn(T, "paymentexpiring", "", nPos++);
                DescribeAColumn(T, "idexpirationkind", "", nPos++);
                DescribeAColumn(T, "active", "attivo", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }

			if (ListingType=="modpaganagrafica"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T, "idregistrypaymethod", "#", nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "cin", "CIN", nPos++);
				DescribeAColumn(T,"regmodcode","Nome",nPos++);
				DescribeAColumn(T,"idbank","Cod. ABI",nPos++);
				DescribeAColumn(T,"idcab","Cod. CAB",nPos++);
				DescribeAColumn(T,"flagstandard","Predef.",nPos++);
				DescribeAColumn(T,"cc","C/C",nPos++);
				DescribeAColumn(T,"paymentdescr","Descrizione",nPos++);
			}
			if (ListingType=="anagrafica") {
				DescribeAColumn(T,"active","Flag attivo");
				DescribeAColumn(T, "idreg", "");
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T, "idregistrypaymethod", "#", nPos++);
				DescribeAColumn(T,"regmodcode","Nome",nPos++);
				DescribeAColumn(T,"paymentdescr","Descrizione",nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "cin", "CIN", nPos++);
				DescribeAColumn(T,"idbank","Cod. ABI",nPos++);
				DescribeAColumn(T,"idcab","Cod. CAB",nPos++);
				DescribeAColumn(T,"cc","C/C",nPos++);
				DescribeAColumn(T,"flagstandard","Predef.",nPos++);
                DescribeAColumn(T, "active", "attivo", nPos++);
            }
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
            if (PrimaryTable.Columns.Contains("active")){
				SetDefault(PrimaryTable, "active", "S");
                SetDefault(PrimaryTable, "flag", 0);
			}
		}


		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
			if (codicecreddeb <= 0) {
				errmess="Inserire il codice anagrafica";
				errfield="idreg";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["idpaymethod"])==0) {
				errmess="Non è stato selezionato nessun tipo di modalità pagamento";
				errfield="idpaymethod";
				return false;
			}
            
            //Lunghezza del BBAN = 1 (CIN) + 5 (ABI) + 5(CAB) + 12 (C/C) = 23
            bool cinCorretto = CfgFn.CheckCIN(R["cin"].ToString(),
                R["idcab"].ToString(),
                R["idbank"].ToString(),
                R["cc"].ToString());

            //Se il CIN non è corretto non è ammesso l'IBAN italiano
            if (!cinCorretto && (R["iban"].ToString().Length >= 2) && R["iban"].ToString().StartsWith("IT")) {
                errmess = "Poichè il CIN non è corretto, il codice IBAN deve essere vuoto";
                errfield = "iban";
                return false;
            }

            //Se l'iban c'è ed è italiano, deve essere di 27 caratteri
            if (cinCorretto && ((R["iban"].ToString()!="") && R["iban"].ToString().ToUpper().StartsWith("IT") 
                    && R["iban"].ToString().Length != 27)) {
                errmess = "Il codice IBAN deve essere composto da 27 caratteri";
                errfield = "iban";
                return false;
            }

            //Se il cin è corretto e c'è l'iban italiano, l'iban deve essere coerente con cin/cc/abi/cab
            if (cinCorretto && R["iban"].ToString().ToUpper().StartsWith("IT")) {
                string bban2 = R["cin"].ToString().ToUpper()
                    + R["idbank"]
                    + R["idcab"]
                    + R["cc"];
                string iban2 = CfgFn.calcolaIBAN("IT", bban2);
                if (R["iban"].ToString() != iban2) {
                    errmess = "Il codice IBAN non è coerente con i campi CIN, CAB, ABI, CC";
                    errfield = "iban";
                    return false;
                }
            }

            //Se l'iban c'è ed è straniero deve avere il codice di controllo corretto
            if (R["iban"].ToString().StartsWith("IT")==false && 
                R["iban"].ToString()!="" && 
                CfgFn.verificaIban(R["iban"].ToString()) == false) {
                errmess = "Il codice IBAN non è valido (codice di controllo errato)";
                errfield = "iban";
                return false;
            }

            //Controllo su unicità mod. pagamento predefinita
			if (edit_type=="default" || edit_type=="anagrafica") {
				if (!isSubentity) {
					errmess="Non è possibile modificare l'entità registrypaymethod senza un form padre";
					errfield=null;
					return false;
				}

				if (R["flagstandard"].ToString().ToLower()=="s") {
					DataTable ParentTable = SourceRow.Table;
					DataRow[] standard = ParentTable.Select("flagstandard='S'");
					if (standard.Length>0) {
						if (standard.Length>1) {
							errmess="Più di una modalità di pagamento predefinita (GIA' PRESENTI) per l'anagrafica considerata";
							errfield=null;
							return false;
						}
						DataRow found = standard[0];
						//if (found["tipomodalita"].ToString()==R["regmodcode"].ToString()) return true;
						if (SourceRow["flagstandard"].ToString().ToUpper()!="S"){
							errmess="Esiste già una modalità pagamento predefinita. Eliminarla prima di impostare quella corrente";
							errfield="flagstandard";
							R["flagstandard"]="N";
							return false;
						}
					}
				}
			}

			//Check CIN - scatta solo se sto cambiando qualcosa tra cin/abi/cab/cc
			if (
                //(R["flagstandard",DataRowVersion.Current].ToString()=="S")
                //&&
                (R.RowState==DataRowState.Added ||
				(
				(R["cin",DataRowVersion.Current].ToString()!= R["cin",DataRowVersion.Original].ToString()	)
				||
				(R["idcab",DataRowVersion.Current].ToString()!= R["idcab",DataRowVersion.Original].ToString()	)
				||
				(R["cc",DataRowVersion.Current].ToString()!= R["cc",DataRowVersion.Original].ToString()	)
				||
				(R["idbank",DataRowVersion.Current].ToString()!= R["idbank",DataRowVersion.Original].ToString()	)
				)
				)
                ){

                //Se il cin c'è deve essere giusto.
                if (R["cin"].ToString().Trim() != "") {
                    if (!CfgFn.CheckCIN(R["cin"].ToString(),
                        R["idcab"].ToString(),
                        R["idbank"].ToString(),
                        R["cc"].ToString())) {
                        errmess = "Il CIN inserito non corrisponde ai dati immessi. Se il CIN non è noto, è meglio non inserirlo.";
                        errfield = "cin";
                        return false;
                    }
                }
                else {
                    //Se il cin non c'è fa dei controlli generici sul resto

                    //ABI/CAB in descrizione
                    string descr = R["paymentdescr"].ToString().Trim().ToUpper();
                    if (descr.IndexOf("ABI") >= 0 && descr.IndexOf("CAB") >= 0) {
                        errmess = "Ci sono dei campi appositi per ABI/CAB, dunque non vanno messi nella descrizione.";
                        errfield = "paymentdescr";
                        return false;
                    }

                    //CC  in descrizione
                    if (descr.IndexOf("C/C") >= 0 && R["cc"].ToString().Trim() == "") {
                        errmess = "C'è un campo apposito per il C/C, che dunque non va messo nella descrizione.";
                        errfield = "paymentdescr";
                        return false;
                    }

                    //Se non c'è nulla va bene
                    if (R["idcab"].ToString().Trim() == "" &&
                        R["idbank"].ToString().Trim() == "" &&
                        R["cc"].ToString().Trim() == ""
                        ) {
                        return true;
                    }

                    //Se ci sono abi/cab, il cc deve essere di 12 caratteri
                    if (R["idcab"].ToString().Trim() != "" &&
                        R["idbank"].ToString().Trim() != "" &&
                        R["cc"].ToString() != "" &&
                        R["cc"].ToString().Length != 12) {
	                    if (!showClientMsg("Il CC risulta ERRATO in quanto dovrebbe essere completato con degli zeri iniziali. Procedo comunque?", "Dati incoerenti", MessageBoxButtons.OKCancel)) {
                            errfield = "cc";
                            return false;
                        }
                    }


                    if (R["idcab"].ToString().Trim() != "" ||
                        R["idbank"].ToString().Trim() != "" 
                         // ||R["cc"].ToString() != ""   omesso poiché per i cc postali si mette il cc ma non il cin
                        ) {
                        if (!showClientMsg("Non è stato inserito il CIN. E' normalmente necessario inserire ABI,CAB,CC,CIN per non incorrere in sanzioni bancarie. Procedo comunque?", "Dati incoerenti", MessageBoxButtons.OKCancel)) {
                            errfield = "cin";
                            return false;
                        }
                    }
                }
			}
			return true;
		}
	}
}
