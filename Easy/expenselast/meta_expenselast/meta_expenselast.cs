
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;
using movimentofunctions;


namespace meta_expenselast {
    public class Meta_expenselast : Meta_easydata {
        public Meta_expenselast(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "expenselast") {
            Name = "Movimento di spesa - Dettaglio";
            ListingTypes.Add("elenco");
            EditTypes.Add("modpaga");
            EditTypes.Add("elenco");
            EditTypes.Add("ct_reset");
        }
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if  (C.ColumnName == "kpay") return;
            base.InsertCopyColumn(C, Source, Dest);
        }
        override public bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            //byte flag = Convert.ToByte(R["flag"]);
            //bool fulfilled = (flag & 1) == 1;
            //if (fulfilled) {
            //    string messaggio = "Attenzione!, impostando il flag 'Regolarizza disposizione di pagamento già effettuata' " +
            //        " il movimento sarà nascosto nella stampa della distinta di trasmissione a meno che non venga impostato " +
            //        " il parametro MostraMovGiaTrasmessi a S, dal bottone Altri Parametri, in tal caso il movimento verrà visualizzato su sfondo grigio";
            //    DialogResult RES = MetaFactory.factory.getSingleton<IMessageShower>().Show(messaggio, "ATTENZIONE", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    if (RES == DialogResult.Cancel) {
            //        errmess = "";
            //        errfield = "flag";
            //        return false;
            //    }
            //}

            //Check CIN
            if (R.Table.Columns.Contains("pagopanoticenum")) {
	            if (R["pagopanoticenum"] != DBNull.Value && R["pagopanoticenum"].ToString().Length != 18) {
		            errmess = "Il codice avviso pagoPA deve essere di 18 caratteri";
		            errfield = "pagopanoticenum";
		            return false;
	            }
            }
            if (R.Table.DataSet.Tables["expense"] != null) {
                byte fasefine = CfgFn.GetNoNullByte(R.Table.DataSet.Tables["expense"].ExtendedProperties["fasefine"]);

                byte fasemax = CfgFn.GetNoNullByte(GetSys("maxexpensephase"));
                if (fasefine == fasemax || fasefine==0) {
                    //if (R["idpaymethod"] == DBNull.Value && R["nbill"]==DBNull.Value) {
                    //    errmess = "Non è stata selezionata nessun tipo di modalità pagamento";
                    //    errfield = "idpaymethod";
                    //    return false;
                    //}
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
                    if (cinCorretto && ((R["iban"].ToString() != "") && R["iban"].ToString().ToUpper().StartsWith("IT")
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
                    if (R["iban"].ToString().StartsWith("IT") == false &&
                        R["iban"].ToString() != "" &&
                        CfgFn.verificaIban(R["iban"].ToString()) == false) {
                        errmess = "Il codice IBAN non è valido (codice di controllo errato)";
                        errfield = "iban";
                        return false;
                    }



                    //Check CIN - scatta solo se sto cambiando qualcosa tra cin/abi/cab/cc
                    if (
                        //(R["flagstandard",DataRowVersion.Current].ToString()=="S")
                        //&&
                        (R.RowState == DataRowState.Added ||
                        (
                        (R["cin", DataRowVersion.Current].ToString() != R["cin", DataRowVersion.Original].ToString())
                        ||
                        (R["idcab", DataRowVersion.Current].ToString() != R["idcab", DataRowVersion.Original].ToString())
                        ||
                        (R["cc", DataRowVersion.Current].ToString() != R["cc", DataRowVersion.Original].ToString())
                        ||
                        (R["idbank", DataRowVersion.Current].ToString() != R["idbank", DataRowVersion.Original].ToString())
                        )
                        )
                        ) {

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
                                DialogResult RES = MetaFactory.factory.getSingleton<IMessageShower>().Show("Il CC risulta ERRATO in quanto dovrebbe essere completato con degli zeri iniziali. Procedo comunque?", "Dati incoerenti", MessageBoxButtons.OKCancel);
                                if (RES == DialogResult.Cancel) {
                                    errfield = "cc";
                                    return false;
                                }
                            }


                            if (R["idcab"].ToString().Trim() != "" ||
                                R["idbank"].ToString().Trim() != ""
                                // ||R["cc"].ToString() != ""   omesso poiché per i cc postali si mette il cc ma non il cin
                                ) {
                                DialogResult RES = MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stato inserito il CIN. E' normalmente necessario inserire ABI,CAB,CC,CIN per non incorrere in sanzioni bancarie. Procedo comunque?", "Dati incoerenti", MessageBoxButtons.OKCancel);
                                if (RES == DialogResult.Cancel) {
                                    errfield = "cin";
                                    return false;
                                }
                            }
                        }
                    }
                    return true;

                }
            }
            return true;
        }



        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flag", 0);
            //SetDefault(PrimaryTable, "fulfilled", "N");
            //SetDefault(PrimaryTable, "autotaxflag", "N");
            //SetDefault(PrimaryTable, "autoclawbackflag", "N");

            object idTrattamentoSpesePred = Conn.DO_READ_VALUE("chargehandling", QHS.BitSet("flag", 1), "idchargehandling");
            if ((idTrattamentoSpesePred != null) && (PrimaryTable.Columns.Contains("idchargehandling"))) {
                SetDefault(PrimaryTable, "idchargehandling", idTrattamentoSpesePred);
            }

            if (PrimaryTable.ExtendedProperties["app_default"] != null) {
                Hashtable H = (Hashtable)PrimaryTable.ExtendedProperties["app_default"];
                foreach (string field in new string[]{"idexp", "iban",														 
				             "iddeputy", "refexternaldoc",
							  "idregistrypaymethod", "idpaymethod",
                               "idbank", "idcab", "cin", "cc","paymentdescr","biccode","extracode",
                               "paymethod_allowdeputy", "paymethod_flag","flag", "idchargehandling"}) {
                                   if ((H[field] != null) && (H[field] != DBNull.Value) && (PrimaryTable.Columns.Contains(field))) {
                                         SetDefault(PrimaryTable, field, H[field]);
                                    }
                }
                return;
            }
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "modpaga": {
                        Name = "Modalità di pagamento del movimento finanziario";
                        return MetaData.GetFormByDllName("expenselast_modpaga"); // new frmSpeseMovimenti();		
                        //return new frmSpesaModCredDebi();
                    }
                case  "ct_reset": {
                        CanInsert = false;
                        SearchEnabled = false;
                        MainRefreshEnabled = false;
                        Name = "Azzeramento Fine anno";
                        return MetaData.GetFormByDllName("ct_expenselast_reset");
                    }
                case "elenco":
                    {
                        CanInsert = false;
                        CanSave = false;
                        DefaultListType = "elenco";
                        Name = "Elenco";
                        return MetaData.GetFormByDllName("expenselast_elenco");
                    }
            }
            return null;
        }

       public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) 
		{
			if (ListingType == "elenco") return base.SelectOne("elenco", filter, "expenselastview", ToMerge);
		    return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}
    }
}
