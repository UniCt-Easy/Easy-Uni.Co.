
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;
using System.Collections;


namespace no_table_entry_rateo {
    public partial class FrmNoTable_entry_rateo : Form {
        MetaData Meta;
        DataTable tPlAccount;
        DataTable tAccount;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        DataTable _tax;
        private DataTable _taxmotive;
        private DataRow _rConfig;
        public FrmNoTable_entry_rateo() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            tPlAccount = DataAccess.CreateTableByName(Meta.Conn, "placcount", "idplaccount, placcpart");
            tAccount = DataAccess.CreateTableByName(Meta.Conn, "account", "idacc, idplaccount");
            _tax = Conn.RUN_SELECT("tax", "*", null, null, null, false);
            _taxmotive = Conn.RUN_SELECT("taxmotive", "*", null, null, null, false);
            DataTable config = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Conn.GetEsercizio()), null, null, false);
            DataRow currInvSetup = config.Rows[0];
            _rConfig = currInvSetup;
            string flagEpExp = currInvSetup["flagepexp"].ToString().ToUpper();
            UsaImpegniDiBudget = (flagEpExp == "S");

        }

        object idacc_accruedcost = DBNull.Value;
        object idacc_accruedrevenue = DBNull.Value;
        object idacc_invoicetoreceive = DBNull.Value;
        object idacc_invoicetoemit = DBNull.Value;

        public void MetaData_AfterActivation() {
            this.Text = Meta.Name;
            DataTable config = Conn.RUN_SELECT("config", "ayear,idacc_accruedcost,idacc_accruedrevenue,idacc_invoicetoreceive,idacc_invoicetoemit",
                                                null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            if (config.Rows.Count > 0) {
                DataRow R = config.Rows[0];
                idacc_accruedcost = R["idacc_accruedcost"];
                idacc_accruedrevenue = R["idacc_accruedrevenue"];
                idacc_invoicetoreceive = R["idacc_invoicetoreceive"];
                idacc_invoicetoemit = R["idacc_invoicetoemit"];
            }
        }

        public void MetaData_AfterClear() {
            this.Text = Meta.Name;            
        }

        bool AnnoCommerciale = false;
        private List<DataRow> currDetails = new List<DataRow>();
        DataRow getExistentEntry(string idrelatedMain, object identrykind, DataTable tEntry, DataTable tEntryDetail) {
            currDetails = new List<DataRow>();
            Conn.RUN_SELECT_INTO_TABLE(tEntry, null, QHS.AppAnd(
                                        QHS.CmpEq("identrykind", identrykind),
                                        QHS.CmpEq("yentry", Conn.GetEsercizio()),
                                        QHS.CmpEq("idrelated", idrelatedMain)
                                        ), null, false);
            DataRow  []currEntries = tEntry.Select(QHC.AppAnd(
                QHC.CmpEq("identrykind", identrykind),
                QHC.CmpEq("yentry", Conn.GetEsercizio()),
                QHC.CmpEq("idrelated", idrelatedMain)
                ));
            if (currEntries.Length == 0) return null;
            DataRow currEntry = currEntries[0];
            Conn.RUN_SELECT_INTO_TABLE(tEntryDetail, null, QHS.AppAnd(
                    QHS.CmpEq("nentry", currEntry["nentry"]),
                    QHS.CmpEq("yentry", Conn.GetEsercizio())
                    ), null, false);
            foreach (DataRow r in tEntryDetail.Select(QHC.CmpEq("nentry", currEntry["nentry"]))) {
                r["amount"] = 0;
                currDetails.Add(r);
            }
            return currEntry;
        }

        void cacheDetail(DataRow r) {
            currDetails.Add(r);
        }

        DataRow getCachedDetail(object idacc, DataRow template, string []fields) {
            foreach (DataRow r in currDetails) {
                if (r["idacc"].ToString() != idacc.ToString())continue;
                bool equal = true;
                foreach (string f in fields) {
                    if (r[f].ToString() != template[f].ToString()) {
                        equal = false;
                        break;
                    }
                }
                if (!equal) continue;
                return r;
            }           
            return null;
        }

        private void btnGenera_Click(object sender, EventArgs e) {
            if (!doVerify()) return;

            // Caricamento delle tabelle entry e entrydetail che devono essere integrate            
            int currAyear = (int) Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);
            DateTime jan01 = new DateTime(1 + currAyear, 1, 1);
            DataSet DD = new DataSet();
            DD.EnforceConstraints = false;

            // Su questi dettagli va applicata la quota parte relativa all'anno in corso
            // scrittura: tipo rateo (identrykind=2),  costo a rateo per la quota parte dell'anno
            // idacc a idacc_accruedcost
            DataTable tParcellaRateo = ottieniParcellaRateo();
            if (tParcellaRateo == null) return;
            tParcellaRateo.Columns.Add("!valoreoriginale", typeof(decimal));
            tParcellaRateo.Columns.Add("!totgiorni", typeof(int));
            tParcellaRateo.Columns.Add("!giorni", typeof(int));
            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tParcellaRateo);


            // Su questi dettagli va applicata la quota parte relativa all'anno in corso
            // scrittura: tipo rateo (identrykind=2),  costo a rateo per la quota parte dell'anno
            // idacc a idacc_accruedcost
            DataTable tDettOrdineRateo = ottieniDettagliOrdineRateo();
            if (tDettOrdineRateo == null) return;
            tDettOrdineRateo.Columns.Add("!valoreoriginale", typeof (decimal));
            tDettOrdineRateo.Columns.Add("!totgiorni", typeof (int));
            tDettOrdineRateo.Columns.Add("!giorni", typeof (int));
            tDettOrdineRateo.Columns.Add("idrelated", typeof(string));
            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tDettOrdineRateo);

            //Questi dettagli vanno presi ad importo pieno, senza fare la quota parte dell'anno.
            // Tuttavia va considerata solo la parte non inserita in fattura (di questo si occupa il metodo chiamato)
            // scrittura: tipo normale (identrykind=1) costo a fatt. da ricevere  (idacc a idacc_invoicetoreceive)
            DataTable tDettOrdineFattRicevere = ottieniDettagliOrdineFattureARicevere();
            if (tDettOrdineFattRicevere == null) return;
            tDettOrdineFattRicevere.Columns.Add("idrelated", typeof(string));
            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tDettOrdineFattRicevere);

            // Su questi dettagli va applicata la quota parte relativa all'anno in corso
            // scrittura: tipo rateo (identrykind=2),  costo a rateo per la quota parte dell'anno
            // idacc a idacc_accruedcost
            DataTable tParcellaRicevere = ottieniParcellaARicevere();
            if (tParcellaRicevere == null) return;
            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tParcellaRicevere);


            DataTable tDettCAttivoRateo = ottieniDettagliContrattoAttivoRateo();
            if (tDettCAttivoRateo == null) return;
            tDettCAttivoRateo.Columns.Add("!valoreoriginale", typeof (decimal));
            tDettCAttivoRateo.Columns.Add("!totgiorni", typeof (int));
            tDettCAttivoRateo.Columns.Add("!giorni", typeof (int));
            tDettCAttivoRateo.Columns.Add("idrelated", typeof(string));

            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tDettCAttivoRateo);

            DataTable tDettCattivoFattEmettere = ottieniDettagliCattivoFattureDaEmettere();
            if (tDettCattivoFattEmettere == null) return;
            tDettCattivoFattEmettere.Columns.Add("idrelated", typeof(string));
            DD = new DataSet();
            DD.EnforceConstraints = false;
            DD.Tables.Add(tDettCattivoFattEmettere);


            AnnoCommerciale = chkCommerciale.Checked;

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");

            int ngiorni;
            int ngiornitot;
            int currYear = (int)Meta.GetSys("esercizio");

            string fAyear = QHS.CmpEq("ayear", currYear);
            double proRataPerc = CfgFn.GetNoNullDouble(Conn.DO_READ_VALUE("iva_prorata", fAyear, "prorata"));
            double promiscuoPerc = CfgFn.GetNoNullDouble(Conn.DO_READ_VALUE("iva_mixed", fAyear, "mixed"));

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            RowChange.SetOptimized(ds.Tables["entry"], true);
            RowChange.ClearMaxCache(ds.Tables["entry"]);
            RowChange.SetOptimized(ds.Tables["entrydetail"], true);
            RowChange.ClearMaxCache(ds.Tables["entrydetail"]);

            ds.Relations.Add("entryentrydetail",
                new DataColumn[] {tEntry.Columns["yentry"], tEntry.Columns["nentry"]},
                new DataColumn[] {tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"]}, false);

       
            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);

            string descr = "Rateo passivo";


            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);

            Hashtable H = new Hashtable();

            //Genera le scritture relative ai ratei passivi
            string last_mankey = "";
            DataRow CurrEntry = null;
         
            object identrykind = 2; // ratei
            var relevantFieldsPassivo = new[] {
                "idreg", "idupb", "idsor1", "idsor2", "idsor3", "idaccmotive",
                "idepexp", "competencystart", "competencystop","idrelated"
			};
            var relevantFieldsParcella = new[] {
                "idreg", "idupb", "idsor1", "idsor2", "idsor3", "idaccmotive",
                "idepexp", "competencystart", "competencystop","idrelated"
			};
            var relevantFieldsAttivo = new[] {
                "idreg", "idupb", "idsor1", "idsor2", "idsor3", "idaccmotive", "competencystart", "competencystop","idrelated","idepacc" 
			};

            if (idacc_accruedcost != DBNull.Value) {
                tDettOrdineRateo.Columns.Add("amount", typeof(decimal));

                #region ratei su ordine
                foreach (DataRow R in tDettOrdineRateo.Select(null, "idmankind asc, yman asc, nman asc,rownum asc")) {
					string descrDett = RifAOrdine(R) + " dett ." + R["rownum"];
					double abatablerate = proRataPerc;
                    if (R["flagmixed"].ToString().ToUpper() == "S") abatablerate *= promiscuoPerc;
                    double scontoPerc = CfgFn.GetNoNullDouble(R["discount"]);

                    double tassocambio = CfgFn.GetNoNullDouble(R["exchangerate"]);

                    var rImponibile = CfgFn.GetNoNullDouble(R["taxable"]);
                    var residuo = CfgFn.GetNoNullDouble(R["residual"]);
                    var quantitaOrdine = CfgFn.GetNoNullDouble(R["ordered"]);

                    var iva = CfgFn.RoundValuta((CfgFn.GetNoNullDouble(R["tax"]) * residuo) / quantitaOrdine);

                    var imponibile = CfgFn.RoundValuta(rImponibile * residuo * tassocambio * (1 - scontoPerc));

                    var ivaindetraibile = CfgFn.RoundValuta(CfgFn.GetNoNullDouble(R["unabatable"]) * residuo / quantitaOrdine);
                    var ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile)); //iva già in EURO
                    var ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda * abatablerate);

                    var importoDettaglio = CfgFn.RoundValuta((decimal)(imponibile + iva - ivadetraibile));
                    R["amount"] = importoDettaglio;

                    string idrelated = EP_functions.GetIdForDocument(R);
                    R["idrelated"] = idrelated + "§" + R["rownum"];
                    string currkey = QHS.MCmp(R, new string[] {"idmankind", "yman", "nman"});


                    DateTime inizioCompetenza = (DateTime) R["competencystart"];
                    DateTime fineCompetenza = (DateTime) R["competencystop"];
                    // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                    decimal importoRateo = calcolaQuota(AnnoCommerciale, currAyear,
                        importoDettaglio, inizioCompetenza, fineCompetenza, out ngiorni, out ngiornitot);

                    if (importoRateo == 0) continue;
                    if (currkey != last_mankey) {
                        //Crea una nuova scrittura se non è già presente nella hashtable
                        last_mankey = currkey;

                        if (H[idrelated] == null) {
                            CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                            if (CurrEntry == null) {
                                CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                CurrEntry["identrykind"] = identrykind;
                                CurrEntry["adate"] = dec31;
                                CurrEntry["description"] = descr + " " + RifAOrdine(R);
                                CurrEntry["idrelated"] = idrelated;
                            }

                            H[idrelated] = CurrEntry;
                        }
                        else {
                            CurrEntry = (DataRow) H[idrelated];
                        }
                    }


                    R["!valoreoriginale"] = importoDettaglio;
                    R["!totgiorni"] = ngiornitot;
                    R["!giorni"] = ngiorni;
                    R.AcceptChanges();


                    DataRow rDet = getCachedDetail(idacc_accruedcost, R, relevantFieldsPassivo);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idacc_accruedcost;
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
                    rDet["idrelated"] = idrelated + "§" + R["rownum"];
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoRateo;
					//è da vedere se il segno sia giusto o meno
					rDet["description"] = descrDett;
					R["competencystart"] = DataInizioRateoDaConsiderare(inizioCompetenza, currAyear);
                    R["competencystop"] = DataFineRateoDaConsiderare(fineCompetenza, currAyear);
                    rDet = getCachedDetail(R["idacc"], R, relevantFieldsPassivo);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = R["idacc"];
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
                    R.RejectChanges();
                    rDet["idrelated"] = idrelated + "§" + R["rownum"];
					rDet["description"] = descrDett;
					rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoRateo;
                        //è da vedere se il segno sia giusto o meno
                }
                #endregion


                #region ratei su Parcelle
                foreach (DataRow R in tParcellaRateo.Select(null, "ycon asc, ncon asc")) {

                    decimal importoDettaglio = CfgFn.GetNoNullDecimal(R["amount"]);

                    string idrelated = EP_functions.GetIdForDocument(R);//idrelated del contratto professionale complessivo

                    string currkey = QHS.MCmp(R, new string[] { "ycon", "ncon"  });


                    DateTime inizioCompetenza = (DateTime)R["competencystart"];
                    DateTime fineCompetenza = (DateTime)R["competencystop"];
                    // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                    decimal importoRateo = calcolaQuota(AnnoCommerciale, currAyear,
                        importoDettaglio, inizioCompetenza, fineCompetenza, out ngiorni, out ngiornitot);

                    if (importoRateo == 0) continue;
                    if (currkey != last_mankey) {
                        //Crea una nuova scrittura se non è già presente nella hashtable
                        last_mankey = currkey;

                        if (H[idrelated] == null) {
                            CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                            if (CurrEntry == null) {
                                CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                CurrEntry["identrykind"] = identrykind;
                                CurrEntry["adate"] = dec31;
                                CurrEntry["description"] = descr + " " + RifAParcella(R);
                                CurrEntry["idrelated"] = idrelated;
                            }

                            H[idrelated] = CurrEntry;
                        }
                        else {
                            CurrEntry = (DataRow)H[idrelated];
                        }
                    }


                    R["!valoreoriginale"] = importoDettaglio;
                    R["!totgiorni"] = ngiornitot;
                    R["!giorni"] = ngiorni;
                    R.AcceptChanges();


                    DataRow rDet = getCachedDetail(idacc_accruedcost, R, relevantFieldsParcella);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idacc_accruedcost;
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
					rDet["idrelated"] = idrelated;
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoRateo;
                    //è da vedere se il segno sia giusto o meno

                    R["competencystart"] = DataInizioRateoDaConsiderare(inizioCompetenza, currAyear);
                    R["competencystop"] = DataFineRateoDaConsiderare(fineCompetenza, currAyear);
                    rDet = getCachedDetail(R["idacc"], R, relevantFieldsParcella);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = R["idacc"];
                        foreach (var field in relevantFieldsParcella) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
                    R.RejectChanges();
                    rDet["idrelated"] = idrelated;
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoRateo;
                    //è da vedere se il segno sia giusto o meno
                }

                #endregion
            }
            else {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Conto ratei passivi non valorizzato", "Avviso");
            }
            H = new Hashtable();
            descr = "Fatture da ricevere";

         

            //Genera le scritture relative alle fatture a ricevere
            last_mankey = "";
            CurrEntry = null;
            identrykind = 1; // scrittura NORMALE per le fatt.  a ricevere
            if (idacc_invoicetoreceive == DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Conto fatture da ricevere non valorizzato", "Avviso");
            }
            else {
                tDettOrdineFattRicevere.Columns.Add("amount", typeof(decimal));
                #region fatture da ricevere - contratti passivi
                foreach (DataRow r in tDettOrdineFattRicevere.Select(null, "idmankind asc, yman asc, nman asc, rownum asc")) {
                    string descrDett =   RifAOrdine(r)+ " dett ." + r["rownum"];
					//"ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable,2)- ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable*isnull(d.discount,0),2) + " +
					//"  ROUND(isnull(d.unabatable*d.residual/d.ordered,0),2) as amount " +
					double abatablerate = proRataPerc;
                    if (r["flagmixed"].ToString().ToUpper() == "S") abatablerate *= promiscuoPerc;
                    double scontoPerc = CfgFn.GetNoNullDouble(r["discount"]);

                    double tassocambio = CfgFn.GetNoNullDouble(r["exchangerate"]);

                    var rImponibile = CfgFn.GetNoNullDouble(r["taxable"]);
                    var residuo = CfgFn.GetNoNullDouble(r["residual"]);
                    var quantitaOrdine = CfgFn.GetNoNullDouble(r["ordered"]);
                    
                    var iva = CfgFn.RoundValuta((CfgFn.GetNoNullDouble(r["tax"])* residuo)/quantitaOrdine);
                                       
                    var imponibile = CfgFn.RoundValuta(rImponibile * residuo * tassocambio * (1 - scontoPerc));

                    var ivaindetraibile = CfgFn.RoundValuta(CfgFn.GetNoNullDouble(r["unabatable"])*residuo/quantitaOrdine);
                    var ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile)); //iva già in EURO
                    var ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda * abatablerate);

                    var importoDettaglio = CfgFn.RoundValuta((decimal)(imponibile + iva - ivadetraibile));
                    r["amount"] = importoDettaglio;
                    string idrelated = EP_functions.GetIdForDocument(r);
                    r["idrelated"] = idrelated + "§" + r["rownum"];
                    string currkey = QHS.MCmp(r, "idmankind", "yman", "nman");
                    object idAcc = r["idacc"];

                    // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                    decimal importoFattRic = importoDettaglio;

                    if (currkey != last_mankey) {
                        //Crea una nuova scrittura se non è già presente nella hashtable
                        last_mankey = currkey;

                        if (H[idrelated] == null) {
                            CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                            if (CurrEntry == null) {
                                CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                CurrEntry["identrykind"] = identrykind;
                                CurrEntry["adate"] = dec31;
                                CurrEntry["description"] = descr + " " + RifAOrdine(r);
                                CurrEntry["idrelated"] = idrelated;
                            }
                            H[idrelated] = CurrEntry;
                        }
                        else {
                            CurrEntry = (DataRow) H[idrelated];
                        }
                    }

                    DataRow rDet = getCachedDetail(idacc_invoicetoreceive, r, relevantFieldsPassivo);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idacc_invoicetoreceive;
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = r[field];
                        }
                        cacheDetail(rDet);
                    }
                    rDet["idrelated"] = idrelated + "§" + r["rownum"]; 
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoFattRic;
                    rDet["idepexp"] = r["idepexp"];
					rDet["description"] = descrDett;
					rDet = getCachedDetail(idAcc, r, relevantFieldsPassivo);
					if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idAcc;
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = r[field];
                        }
                        cacheDetail(rDet);
                    }
					rDet["description"] = descrDett;
					rDet["idepexp"] = r["idepexp"];
                    rDet["idrelated"] = idrelated + "§" + r["rownum"];
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoFattRic;
                }
                #endregion


                #region fatture da ricevere - parcelle
                foreach (DataRow r in tParcellaRicevere.Select(null, "ycon asc, ncon asc")) {
                    decimal importoDettaglio = CfgFn.GetNoNullDecimal(r["amount"]);
                    string idrelated = EP_functions.GetIdForDocument(r);
                    string currkey = QHS.MCmp(r, "ycon", "ncon");
                    object idAcc = r["idacc"];

                    // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                    decimal importoFattRic = importoDettaglio;

                    if (currkey != last_mankey) {
                        //Crea una nuova scrittura se non è già presente nella hashtable
                        last_mankey = currkey;

                        if (H[idrelated] == null) {
                            CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                            if (CurrEntry == null) {
                                CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                CurrEntry["identrykind"] = identrykind;
                                CurrEntry["adate"] = dec31;
                                CurrEntry["description"] = descr + " " + RifAParcella(r);
                                CurrEntry["idrelated"] = idrelated;
                            }
                            H[idrelated] = CurrEntry;
                        }
                        else {
                            CurrEntry = (DataRow)H[idrelated];
                        }
                    }

                    DataRow rDet = getCachedDetail(idacc_invoicetoreceive, r, relevantFieldsParcella);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idacc_invoicetoreceive;
                        foreach (var field in relevantFieldsPassivo) {
                            rDet[field] = r[field];
                        }
                        cacheDetail(rDet);
                    }
                    rDet["idrelated"] = idrelated;
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoFattRic;

                    rDet = getCachedDetail(idAcc, r, relevantFieldsParcella);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idAcc;
                        foreach (var field in relevantFieldsParcella) {
                            rDet[field] = r[field];
                        }
                        cacheDetail(rDet);
                    }
                    rDet["idrelated"] = idrelated;
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoFattRic;
                }
                #endregion



                #region Ratei attivi - contratti attivi
                H = new Hashtable();

                //Dettagli ratei c.attivi
                last_mankey = "";
                CurrEntry = null;
                identrykind = 2; // ratei
                descr = "Rateo attivo";
                if (idacc_accruedrevenue == DBNull.Value) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Conto ratei attivi non valorizzato", "Avviso");
                }
                else {

                    foreach (DataRow R in tDettCAttivoRateo.Select(null, "idestimkind asc, yestim asc, nestim asc, rownum asc")) {
                        decimal importoDettaglio = CfgFn.GetNoNullDecimal(R["amount"]);
						string descrDett = rifAContrattoAttivo(R) + " dett." + R["rownum"];
						if (importoDettaglio == 0) continue;
                        string idrelated = EP_functions.GetIdForDocument(R);
                        R["idrelated"] = idrelated + "§" + R["rownum"];

                        string currkey = QHS.MCmp(R, new string[] {"idestimkind", "yestim", "nestim"});


                        DateTime inizioCompetenza = (DateTime) R["competencystart"];
                        DateTime fineCompetenza = (DateTime) R["competencystop"];
                        // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                        decimal importoRateo = calcolaQuota(AnnoCommerciale, currAyear,
                            importoDettaglio, inizioCompetenza, fineCompetenza, out ngiorni, out ngiornitot);


                        if (currkey != last_mankey) {
                            //Crea una nuova scrittura se non è già presente nella hashtable
                            last_mankey = currkey;


                            if (H[idrelated] == null) {
                                CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                                if (CurrEntry == null) {
                                    CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                    CurrEntry["identrykind"] = identrykind;
                                    CurrEntry["adate"] = dec31;
                                    CurrEntry["description"] = descr + " " + rifAContrattoAttivo(R);
                                    CurrEntry["idrelated"] = idrelated;
                                }
                                H[idrelated] = CurrEntry;
                            }
                            else {
                                CurrEntry = (DataRow) H[idrelated];
                            }
                        }

                        R["!valoreoriginale"] = importoDettaglio;
                        R["!totgiorni"] = ngiornitot;
                        R["!giorni"] = ngiorni;
                        R.AcceptChanges();

                        DataRow rDet = getCachedDetail(idacc_accruedrevenue, R, relevantFieldsAttivo);
                        if (rDet == null) {
                            rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                            rDet["idacc"] = idacc_accruedrevenue;
                            foreach (var field in relevantFieldsAttivo) {
                                rDet[field] = R[field];
                            }
                            cacheDetail(rDet);
                        }
                        rDet["idrelated"] = idrelated + "§" + R["rownum"];
                        rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoRateo;
						rDet["description"] = descrDett;
						R["competencystart"] = DataInizioRateoDaConsiderare(inizioCompetenza, currAyear);
                        R["competencystop"] = DataFineRateoDaConsiderare(fineCompetenza, currAyear);

                        rDet = getCachedDetail(R["idacc"], R, relevantFieldsAttivo);
                        if (rDet == null) {
                            rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                            rDet["idacc"] = R["idacc"];
                            foreach (var field in relevantFieldsAttivo) {
                                rDet[field] = R[field];
                            }
                            cacheDetail(rDet);
                        }
                        R.RejectChanges(); //ripristina competencystart e competencystop

                        rDet["idrelated"] = idrelated + "§" + R["rownum"];
                        rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoRateo;
						rDet["description"] = descrDett;


					}
                }
            }

            #endregion

            #region fatture da emettere - contratti attivi

            H = new Hashtable();

            //Genera le scritture relative alle fatture da emettere
            last_mankey = "";
            CurrEntry = null;
            descr = "Fatture da emettere";
            identrykind = 1; // scrittura NORMALE per le fatt.   da emettere
            if (idacc_invoicetoemit == DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Conto fatture da emettere non valorizzato", "Avviso");
            }
            else {

                foreach (DataRow R in tDettCattivoFattEmettere.Select(null, "idestimkind asc, yestim asc, nestim asc")) {
					string descrDett = rifAContrattoAttivo(R)+ " dett." + R["rownum"];
					decimal importoDettaglio = CfgFn.GetNoNullDecimal(R["amount"]);
                    if (importoDettaglio == 0) continue;

                    string idrelated = EP_functions.GetIdForDocument(R);
                    R["idrelated"] = idrelated + "§" + R["rownum"];
                    string currkey = QHS.MCmp(R, new string[] {"idestimkind", "yestim", "nestim"});
                    object idAcc = R["idacc"];

                    // dell'importo considerato, trattandosi di rateo, deve prendere la quota relativa all'anno corrente
                    decimal importoFattRic = importoDettaglio;


                    if (currkey != last_mankey) {
                        //Crea una nuova scrittura se non è già presente nella hashtable
                        last_mankey = currkey;


                        if (H[idrelated] == null) {
                            CurrEntry = getExistentEntry(idrelated, identrykind, tEntry, tEntryDetail);
                            if (CurrEntry == null) {
                                CurrEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);
                                CurrEntry["identrykind"] = identrykind;
                                CurrEntry["adate"] = dec31;
                                CurrEntry["description"] = descr + " " + rifAContrattoAttivo(R);
                                CurrEntry["idrelated"] = idrelated;
                            }
                            H[idrelated] = CurrEntry;
                        }
                        else {
                            CurrEntry = (DataRow) H[idrelated];
                        }
                    }
                    DataRow rDet = getCachedDetail(idacc_invoicetoemit, R, relevantFieldsAttivo);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idacc_invoicetoemit;
                        foreach (var field in relevantFieldsAttivo) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
                    rDet["idepacc"] = R["idepacc"];
                    rDet["idrelated"] = idrelated + "§" + R["rownum"];
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) - importoFattRic;
					rDet["description"] = descrDett;


					rDet = getCachedDetail(idAcc, R, relevantFieldsAttivo);
                    if (rDet == null) {
                        rDet = MEntryDetail.Get_New_Row(CurrEntry, tEntryDetail);
                        rDet["idacc"] = idAcc;
                        foreach (var field in relevantFieldsAttivo) {
                            rDet[field] = R[field];
                        }
                        cacheDetail(rDet);
                    }
					rDet["description"] = descrDett;
					rDet["idrelated"] = idrelated + "§" + R["rownum"];
                    rDet["idepacc"] = R["idepacc"];
                    rDet["amount"] = CfgFn.GetNoNullDecimal(rDet["amount"]) + importoFattRic;


                }
            }

            #endregion

            //Cancella tutti i dettagli scrittura a zero
            foreach (DataRow rDet in tEntryDetail.Select()) {
                if (CfgFn.GetNoNullDecimal(rDet["amount"]) == 0) {
                    rDet.Delete();
                }
            }

            //Cancella tutte le scritture senza dettagli
            foreach (DataRow rMain in tEntry.Select()) {
                if (tEntryDetail.Select(QHC.CmpKey(rMain)).Length == 0) {
                    rMain.Delete();
                }
            }

            doGenera(tDettOrdineRateo, tDettCAttivoRateo, tDettOrdineFattRicevere, tDettCattivoFattEmettere,
                            tParcellaRateo,tParcellaRicevere, ds);

        }

        //DataTable TipoCPassivo = null;
        string RifAOrdine(DataRow mandate) {
            //if (TipoCPassivo == null) TipoCPassivo = Conn.RUN_SELECT("mandatekind", null, null, null, null, false);
            string kind="";
            //if (TipoCPassivo.Select(filterkind).Length > 0) {
            //    kind = TipoCPassivo.Select(filterkind)[0]["description"].ToString();
            //}
            kind = mandate["idmankind"].ToString();
            return "Contratto passivo " + kind + " n." + mandate["nman"].ToString() + " del " + mandate["yman"].ToString();

        }

        string RifAParcella(DataRow parcella) {
            return "Parcella  n." + parcella["ncon"].ToString() + " del " + parcella["ycon"].ToString();

        }


        //DataTable TipoCPassivo = null;
        string rifAContrattoAttivo(DataRow estimate) {
            //if (TipoCPassivo == null) TipoCPassivo = Conn.RUN_SELECT("mandatekind", null, null, null, null, false);
            string filterkind = QHC.MCmp(estimate, new string[] { "idestimkind", "yestim", "nestim" });
            string kind = "";
            //if (TipoCPassivo.Select(filterkind).Length > 0) {
            //    kind = TipoCPassivo.Select(filterkind)[0]["description"].ToString();
            //}
            kind = estimate["idestimkind"].ToString();
            return "Contratto attivo " + kind + " n." + estimate["nestim"].ToString() + " del " + estimate["yestim"].ToString();

        }

        /// <summary>
        /// Su questi contratti professionali va applicata la quota parte relativa all'anno in corso
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniParcellaRateo() {
            int currAyear = (int) Meta.GetSys("esercizio");
            string queryED = "SELECT d.idser,d.ycon,d.ncon,d.totalcost,d.ivaamount,d.flagmixed,d.idivakind," +
                             " AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"
                             +
                             " d.start as competencystart , d.stop as competencystop, d.idaccmotive FROM profservice d "
                             + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
                             + " WHERE " + QHS.AppAnd(
                                 QHS.CmpLe("d.ycon", currAyear),
                                 QHS.CmpEq("d.epkind", "R"),
                                 QHS.NullOrGt("d.yinv", currAyear), //era QHS.isnull("d.idinvkind") , task 10466
                                 QHS.CmpLe("year(d.start)", currAyear), QHS.CmpGe("year(d.stop)", currAyear),
                                 QHS.CmpEq("AC.ayear", currAyear));

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }
            tEntryDetail.Columns.Add(new DataColumn("amount", typeof(decimal)));
            tEntryDetail.Columns.Add(new DataColumn("idepexp", typeof(int)));
            tEntryDetail.Columns.Add(new DataColumn("idrelated", typeof(string)));
            return calcolaScrittureProfService(tEntryDetail);
        }

        /// <summary>
        /// Questi dettagli vanno presi ad importo pieno, senza fare la quota parte dell'anno.
        /// Tuttavia va considerata solo la parte non inserita in fattura
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniParcellaARicevere() {
            int currAyear = (int)Meta.GetSys("esercizio");

            string queryED = "SELECT d.idser,d.ycon,d.ncon,d.totalcost,d.ivaamount,d.flagmixed,d.idivakind," +                       
                "AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"
            + " d.start as competencystart , d.stop as competencystop  FROM profservice d "
            + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
            + " WHERE " + QHS.AppAnd(
                                    QHS.CmpEq("d.ycon", currAyear),
                                    QHS.CmpEq("d.epkind", "F"),
                                    QHS.NullOrGt("d.yinv", currAyear), //era QHS.isnull("d.idinvkind") , task 10466
                                    QHS.CmpEq("AC.ayear", currAyear));

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }
            tEntryDetail.Columns.Add(new DataColumn("amount", typeof(decimal)));
            tEntryDetail.Columns.Add(new DataColumn("idepexp", typeof(int)));
            tEntryDetail.Columns.Add(new DataColumn("idrelated", typeof(string)));
            return calcolaScrittureProfService(tEntryDetail);            
        }

        private DataTable calcolaScrittureProfService(DataTable tEntryDetail) {
            tEntryDetail.TableName = "profservice";
            DataTable tipiSpesa = Conn.RUN_SELECT("profrefund", "*", null, null, null, false);
            EP_functions ep = new EP_functions(Meta.Dispatcher);

            double proRataPerc = CfgFn.GetNoNullDouble(
              Conn.DO_READ_VALUE("iva_prorata", "(ayear = '" + Conn.GetSys("esercizio") + "')", "prorata"));

            double promiscuoPerc = CfgFn.GetNoNullDouble(
                Conn.DO_READ_VALUE("iva_mixed", "(ayear = '" + Conn.GetSys("esercizio") + "')", "mixed"));


            //Esamina tutti i contratti
            foreach (DataRow contract in tEntryDetail.Select()) {
                double percIndetraibile = 0;
                if (contract["idivakind"] != DBNull.Value) {
                    percIndetraibile = CfgFn.GetNoNullDouble(Conn.DO_READ_VALUE("ivakind",
                            QHS.CmpEq("idivakind", contract["idivakind"]), "unabatabilitypercentage"));
                }
                string filterContract = QHS.MCmp(contract,"ycon","ncon");
                DataTable profservicerefund = Conn.RUN_SELECT("profservicerefund", "*", null, filterContract, null, false);
                object idaccmotive = contract["idaccmotive"];
                decimal amount = CfgFn.GetNoNullDecimal(contract["totalcost"]);

                decimal sommaspese = 0;
                //Esamina tutte le spese
                foreach(DataRow rSpesa in profservicerefund.Rows) {
                    DataRow tipoSpesa = tipiSpesa.Select(QHC.CmpEq("idlinkedrefund", rSpesa["idlinkedrefund"]))[0];

                    if (tipoSpesa == null)
                        continue;
                    if (tipoSpesa["idaccmotive"] == DBNull.Value)
                        continue;
                    if (tipoSpesa["idaccmotive"].ToString() == idaccmotive.ToString())
                        continue;

                    decimal importospesa = CfgFn.GetNoNullDecimal(rSpesa["amount"]);
                    sommaspese += importospesa;

                    DataRow[] contiSpesa = ep.GetAccMotiveDetails(tipoSpesa["idaccmotive"]);
                    if (contiSpesa.Length == 0) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Il tipo spesa " + tipoSpesa["description"] + 
                            " della prestazione professionale "+ contract["ncon"]+" del "+ contract["ycon"] +
                            " non è ben configurato", "Errore");
                        break;
                    }

                    object idaccSpesa = contiSpesa[0]["idacc"];

                    string idrel = BudgetFunction.GetIdForDocument(rSpesa);
                    object idepexp = Conn.DO_READ_VALUE("epexp",
                        QHS.AppAnd(QHS.CmpEq("idrelated", idrel), QHS.CmpEq("nphase", 2)), "idepexp");
                    if (idepexp == null) {
                        idepexp = DBNull.Value;
                    }
                    DataRow rNew = tEntryDetail.NewRow();
                    foreach (DataColumn c in tEntryDetail.Columns) {
                        rNew[c.ColumnName] = contract[c.ColumnName];
                    }
                    rNew["idrelated"] = idrel;
                    rNew["idacc"] = idaccSpesa;
                    rNew["idepexp"] = idepexp;
                    rNew["idaccmotive"] = tipoSpesa["idaccmotive"];
                    rNew["amount"] = importospesa;
                    tEntryDetail.Rows.Add(rNew);

                }
                amount -= sommaspese;

                decimal sommaRitNonConfig = 0;
                DataTable profservicetax = Conn.RUN_SELECT("profservicetax", "*", null, filterContract, null, false);

                foreach (DataRow rRitenuta in profservicetax.Select()) {
                    decimal importoritenuta = CfgFn.GetNoNullDecimal(rRitenuta["admintax"]);
                    if (importoritenuta <= 0) continue;

                    DataRow tipoRit = _tax.Select(QHC.CmpEq("taxcode", rRitenuta["taxcode"]))[0];

                   
                    object idaccmotiveCost = getIdaccmotiveCostForTax(contract["idser"], rRitenuta["taxcode"]);

                    if ((idaccmotiveCost == DBNull.Value || idaccmotiveCost == idaccmotive)) {
                        sommaRitNonConfig += importoritenuta; //accorpa il preimpegno dei contributi a quello principale
                        continue;
                    }

                    if (idaccmotiveCost == DBNull.Value) {
                        idaccmotiveCost = idaccmotive;
                    }

                    var contiCostoContributo = ep.GetAccMotiveDetails(idaccmotiveCost);
                    if (contiCostoContributo.Length == 0) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Contributo " + tipoRit["taxref"] + " mal configurato.", "Errore");
                        break;
                    }
                    object idAccCostoContributo = contiCostoContributo[0]["idacc"];

                    string idrel = BudgetFunction.GetIdForDocument(rRitenuta);

                    var lista = getInfoImpegniForContributo(ep, rRitenuta["taxcode"], importoritenuta, idrel, idrel, 2);
                    if (lista == null) {
                        break;
                    }
                    DataRow rNew = tEntryDetail.NewRow();
                    foreach (DataColumn c in tEntryDetail.Columns) {
                        rNew[c.ColumnName] = contract[c.ColumnName];
                    }
                    foreach (InfoContributi i in lista) {
                        rNew["idrelated"] = idrel;
                        rNew["idacc"] = idAccCostoContributo;
                        rNew["idepexp"] = i.idepexp;
                        rNew["idaccmotive"] = idaccmotiveCost;
                        rNew["amount"] = i.importo;
                        tEntryDetail.Rows.Add(rNew);
                    }


                }
                amount += sommaRitNonConfig;
             

                double ivaLorda = CfgFn.GetNoNullDouble(contract["ivaamount"]);
                double ivaIndetraibile = ivaLorda * percIndetraibile;
                double ivaDetraibileLorda = ivaLorda - ivaIndetraibile;

              

                double ivaDetraibile = ivaDetraibileLorda * proRataPerc;
                if (contract["flagmixed"].ToString().ToUpper() == "S") ivaDetraibile *= promiscuoPerc;

                amount -= (decimal)ivaDetraibile;
                contract["amount"] = amount;

                DataRow[] account = ep.GetAccMotiveDetails(idaccmotive);
                if (account.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("La causale  della prestazione professionale " + contract["ncon"] + " del " + contract["ycon"] +
                            " non è ben configurata", "Errore");
                    continue;
                }

                string idrelMain = BudgetFunction.GetIdForDocument(contract);
                contract["idepexp"] = getIdEpExpByIdRelated(idrelMain, 2);
                contract["idrelated"] = idrelMain;
            }

            return tEntryDetail;
        }

        object getIdaccmotiveCostForTax(object idser, object taxcode) {
            object idaccmotiveCost = DBNull.Value;
            DataRow[] tipoRitMotive = _taxmotive.Select(QHC.AppAnd(QHC.CmpEq("idser", idser), QHC.CmpEq("taxcode", taxcode)));
            if (tipoRitMotive.Length > 0) {
                if (tipoRitMotive[0]["idaccmotive"] != DBNull.Value) {
                    idaccmotiveCost = tipoRitMotive[0]["idaccmotive"];
                    return idaccmotiveCost;
                }
            }

            DataRow tipoRit = _tax.Select(QHC.CmpEq("taxcode", taxcode))[0];
            if (tipoRit["idaccmotive_cost"] != DBNull.Value) {
                idaccmotiveCost = tipoRit["idaccmotive_cost"];
                return idaccmotiveCost;
            }

            return idaccmotiveCost;
        }

        class InfoContributi {
            public object idacc;
            public decimal importo;
            public object idreg;
            public string idrelated;
            public string idaccmotive;
            public object idepexp;

            public InfoContributi(object idacc, decimal importo, object idreg, string idrelated, string idaccmotive,
                object idepexp) {
                this.idacc = idacc;
                this.importo = importo;
                this.idreg = idreg;
                this.idrelated = idrelated;
                this.idaccmotive = idaccmotive;
                this.idepexp = idepexp;

            }
        }
        TaxEntryHelper _teh;

        bool UsaImpegniDiBudget;

        object getIdEpExpByIdRelated(string idrelated, int nphase) {
            if (nphase == 0) return DBNull.Value;
            return Conn.DO_READ_VALUE("epexp",
                QHS.AppAnd(QHS.CmpEq("idrelated", idrelated), QHS.CmpEq("nphase", nphase)), "idepexp") ?? DBNull.Value;
        }

        List<InfoContributi> getInfoImpegniForContributo(EP_functions ep, object taxcode, decimal importo, string idrelated,
            string idrelMain, int nphase) {
            if (_teh == null) {
                _teh = new TaxEntryHelper(Conn);
            }
            if (_tax == null) {
                _tax = Conn.RUN_SELECT("tax", "*", null, null, null, false);
            }

            var tipoRits = _tax.Select(QHC.CmpEq("taxcode", taxcode));
            if (tipoRits.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(
                    "Non esiste nel db la ritenuta avente codice " + taxcode,
                    "Errore");
                return null;
            }
            var tipoRit = tipoRits[0];


            var result = new List<InfoContributi>();

            if (nphase == 1) {
                result.Add(new InfoContributi(DBNull.Value, importo, DBNull.Value, idrelated, null, DBNull.Value));
                return result;
            }

            object idepexpPreimpegno = getIdEpExpByIdRelated(idrelated, 1);
            if (idepexpPreimpegno == null || idepexpPreimpegno == DBNull.Value) {
                idepexpPreimpegno = getIdEpExpByIdRelated(idrelMain, 1);
            }
            int esercizio = Conn.GetEsercizio();
            if ((idepexpPreimpegno == null || idepexpPreimpegno == DBNull.Value) && UsaImpegniDiBudget &&
                esercizio > 2015) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(
                    "Non è stato trovato alcun preimpegno di budget per il contributo " + tipoRit["taxref"], "Errore");
                return null;
            }
            if (idepexpPreimpegno == null) {
                idepexpPreimpegno = DBNull.Value;
            }
            object idaccmotiveTouse;
            var idregauto = _rConfig["idregauto"];
            if (tipoRit["idaccmotive_debit"] != DBNull.Value) {
                idaccmotiveTouse = tipoRit["idaccmotive_debit"];
                var contiContribFinanz = ep.GetAccMotiveDetails(idaccmotiveTouse);
                if (contiContribFinanz.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        "Non è stata ben configurata la causale del debito del contributo " + tipoRit["taxref"],
                        "Errore");
                    return null;
                }
                result.Add(new InfoContributi(DBNull.Value, importo, idregauto, idrelated, null, idepexpPreimpegno));
            }
            else {
                idaccmotiveTouse = tipoRit["idaccmotive_pay"];
                var contiContribFinanz = ep.GetAccMotiveDetails(idaccmotiveTouse);
                if (contiContribFinanz.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        "Non è stata ben configurata la causale del debito del contributo " + tipoRit["taxref"],
                        "Errore");
                    return null;
                }

                var regs = _teh.GetIdRegFor(taxcode, DBNull.Value, DBNull.Value);
                if (regs == null || regs.Rows.Count == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Anagrafica per il versamento non trovata per la ritenuta di tipo " +
                                    tipoRit["taxref"], "Errore");
                    return null;
                }

                foreach (DataRow registry in regs.Rows) {
                    var amountToConsider = CfgFn.RoundValuta(importo * CfgFn.GetNoNullDecimal(registry["quota"]));
                    var idreg = CfgFn.GetNoNullInt32(registry["idreg"]);
                    var idrel = idrelated + "§" + idreg;
                    result.Add(new InfoContributi(DBNull.Value, amountToConsider, idreg, idrel, null, idepexpPreimpegno));
                }
            }
            return result;
        }

        

        /// <summary>
        /// Su questi dettagli va applicata la quota parte relativa all'anno in corso
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniDettagliOrdineRateo() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);
            //--------------------- Verifica presenza di dettagli senza causale di Costo ----------------
            string queryED_check = "SELECT d.idmankind as CodiceContrattoPassivo, d.yman as EsercContrattoPassivo, d.nman as NumContrattoPassivo, d.rownum as NumRiga, d.mandatekind as TipoContrattoPassivo"
            + "  FROM mandatedetailtoinvoiceyear d "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear),
                                    QHS.CmpLe("d.yman", currAyear),
                                    QHS.CmpEq("d.epkind", "R"),
                                    QHS.IsNull("D.idaccmotive"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpLe("year(d.competencystart)", currAyear), QHS.CmpGe("year(competencystop)", currAyear));
            DataTable t = Conn.SQLRunner(queryED_check, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, "Dettagli Contratti Passivi Rateo senza Casuale di costo", t);
                f.Show(this);
                return null;
            }

            string queryED = "SELECT d.idmankind,d.yman,d.nman," +
                             "d.exchangerate,d.residual,d.ordered,d.discount,d.tax,d.taxable,d.unabatable,d.flagactivity,d.flagmixed" +
                //"ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable,2)-  ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable*isnull(d.discount,0),2) + " +
                //"  ROUND(isnull(d.unabatable*d.residual/d.ordered,0),2) as amount " +
                ", AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,d.idepexp,"
            + " d.competencystart, d.competencystop, d.idaccmotive,d.mandatekind,d.rownum FROM mandatedetailtoinvoiceyear d "
            + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
            + " WHERE "+QHS.AppAnd( QHS.CmpEq("d.ayear",currAyear),
                                    QHS.CmpLe("d.yman",currAyear),
                                    QHS.CmpEq("d.epkind","R"),
                                    QHS.CmpGt("d.residual",0),
                                    QHS.CmpLe("year(d.competencystart)",currAyear), QHS.CmpGe("year(competencystop)",currAyear),
                                    QHS.CmpEq("AC.ayear",currAyear));

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "mandate";

            return tEntryDetail;
        }

        /// <summary>
        /// Questi dettagli vanno presi ad importo pieno, senza fare la quota parte dell'anno.
        /// Tuttavia va considerata solo la parte non inserita in fattura
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniDettagliOrdineFattureARicevere() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);
            //--------------------- Verifica presenza di dettagli senza causale di Costo ---------------- 
            string queryED_check = "SELECT d.idmankind as CodiceContrattoPassivo, d.yman as EsercContrattoPassivo, d.nman as NumContrattoPassivo, d.rownum as NumRiga, d.mandatekind as TipoContrattoPassivo"
            + "  FROM mandatedetailtoinvoiceyear d "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear),
                                    QHS.CmpEq("d.epkind", "F"),
                                    QHS.IsNull("d.idaccmotive"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpLe("isnull(year(d.start),d.yman)", currAyear), QHS.NullOrGe("year(d.stop)", currAyear),
                                    QHS.CmpGt("isnull(year(d.start),d.yman)", 2015)) +
                          "AND NOT EXISTS (SELECT * from entrydetail where idrelated = 'man§' + d.idmankind + " +
                             $"'§' + CONVERT(varchar(30), d.yman) + '§' + CONVERT(varchar(4), d.nman) + '§' + CONVERT(varchar(5), d.rownum) AND yentry < {currAyear} )";
            DataTable t = Conn.SQLRunner(queryED_check, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, "Dettagli Ordine Fatture a Ricevere senza Casuale di costo", t);
                f.Show(this);
                return null;
            }

            string queryED = "SELECT d.idmankind,d.yman,d.nman," +
                        "d.exchangerate,d.residual,d.ordered,d.discount,d.tax,d.taxable,d.unabatable,d.flagactivity,d.flagmixed" +
                             //"ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable,2)- ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable*isnull(d.discount,0),2) + " +
                             //"  ROUND(isnull(d.unabatable*d.residual/d.ordered,0),2) as amount " +
            ", AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,d.idepexp,"
            + " d.competencystart, d.competencystop, d.idaccmotive,d.mandatekind,d.rownum "+
                             "FROM mandatedetailtoinvoiceyear d "
            + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear),
                                    //QHS.CmpLe("d.yman", currAyear),
                                    QHS.CmpEq("d.epkind", "F"),
                                    QHS.CmpGt("d.residual", 0),
                                 QHS.CmpLe("isnull(year(d.start),d.yman)", currAyear), QHS.NullOrGe("year(d.stop)", currAyear),
                                    QHS.CmpEq("AC.ayear",currAyear),
                                 QHS.CmpGt("isnull(year(d.start),d.yman)", 2015)) +
                          "AND NOT EXISTS (SELECT * from entrydetail where idrelated = 'man§' + d.idmankind + " +
                             $"'§' + CONVERT(varchar(30), d.yman) + '§' + CONVERT(varchar(4), d.nman) + '§' + CONVERT(varchar(5), d.rownum) AND yentry < {currAyear} )";

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "mandate";

            return tEntryDetail;
        }

     

        /// <summary>
        /// Su questi dettagli va applicata la quota parte relativa all'anno in corso
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniDettagliContrattoAttivoRateo() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);

            //--------------------- Verifica presenza di dettagli senza causale di Ricavo ---------------- 
            string queryED_check = "SELECT d.idestimkind as CodiceContrattoAttivo, d.yestim as EsercContrattoAttivo, d.nestim as NumContrattoAttivo, d.rownum as NumRiga, d.estimatekind as TipoContrattoAttivo"
            + "  FROM estimatedetailtoinvoiceyear d "
            +" WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear),
                                    QHS.CmpLe("d.yestim", currAyear),
                                    QHS.IsNull("d.idaccmotive"),
                                    QHS.CmpEq("d.epkind", "R"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpLe("year(d.competencystart)", currAyear), QHS.CmpGe("year(competencystop)", currAyear)
                                    ) +
              "AND NOT EXISTS (SELECT * from entrydetail where idrelated like 'estim§' + d.idestimkind + " +
                "'§' + CONVERT(varchar(30), d.yestim) + '§' + CONVERT(varchar(4), d.nestim) + '§' + CONVERT(varchar(5), d.rownum) )";
            DataTable t = Conn.SQLRunner(queryED_check, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, "Dettagli Contratti Attivi Rateo senza Casuale di Ricavo", t);
                f.Show(this);
                return null;
            }

            string queryED = "SELECT d.idestimkind,d.yestim,d.nestim, ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable,2)-" +
                        " ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable*isnull(d.discount,0),2) as amount " +
                ", AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"
            + " d.competencystart, d.competencystop, d.idaccmotive,d.estimatekind,d.rownum,d.idepacc FROM estimatedetailtoinvoiceyear d "
            + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear), 
                                    QHS.CmpLe("d.yestim", currAyear),
                                    QHS.CmpEq("d.epkind", "R"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpLe("year(d.competencystart)", currAyear), QHS.CmpGe("year(competencystop)", currAyear),
                                    QHS.CmpEq("AC.ayear",currAyear))+
              "AND NOT EXISTS (SELECT * from entrydetail where idrelated like 'estim§' + d.idestimkind + " +
                "'§' + CONVERT(varchar(30), d.yestim) + '§' + CONVERT(varchar(4), d.nestim) + '§' + CONVERT(varchar(5), d.rownum) )";

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "estimate";

            return tEntryDetail;
        }

        /// <summary>
        /// Questi dettagli vanno presi ad importo pieno, senza fare la quota parte dell'anno.
        /// Tuttavia va considerata solo la parte non inserita in fattura
        /// </summary>
        /// <returns></returns>
        private DataTable ottieniDettagliCattivoFattureDaEmettere() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);
            //--------------------- Verifica presenza di dettagli senza causale di Ricavo ---------------- 
            string queryED_check = "SELECT d.idestimkind as CodiceContrattoAttivo, d.yestim as EsercContrattoAttivo, d.nestim as NumContrattoAttivo, d.rownum as NumRiga, d.estimatekind as TipoContrattoAttivo"
            + "  FROM estimatedetailtoinvoiceyear d "
            +" WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear),
                                    QHS.IsNull("d.idaccmotive"),
                                    QHS.CmpLe("isnull(year(d.start),d.yestim)", currAyear),
                                    QHS.CmpEq("d.epkind", "F"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpGt("isnull(year(d.start),d.yestim)", 2015)) +
                          "AND NOT EXISTS (SELECT * from entrydetail where idrelated = 'estim§' + d.idestimkind + " +
                             $"'§' + CONVERT(varchar(30), d.yestim) + '§' + CONVERT(varchar(4), d.nestim) + '§' + CONVERT(varchar(5), d.rownum) AND yentry < {currAyear} )";

            DataTable t = Conn.SQLRunner(queryED_check, false, 0);
            if (t.Rows.Count > 0) {
                DataSet d = new DataSet();
                d.Tables.Add(t);
                frmErrorView f = new frmErrorView(Meta.myHelpForm, "Dettagli Contratti Attivi Fatture da Emettere senza Casuale di Ricavo", t);
                f.Show(this);
                return null;
            }
            string queryED = "SELECT d.idestimkind,d.yestim,d.nestim,ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable,2)- " +
                        " ROUND(d.residual*isnull(d.exchangerate,1)*d.taxable*isnull(d.discount,0),2) as amount " +
                ", AC.idacc, D.idaccmotive, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"
            + " d.competencystart, d.competencystop, d.idaccmotive,d.estimatekind,d.rownum,d.idepacc FROM estimatedetailtoinvoiceyear d "
            + " join accmotivedetail AC on AC.idaccmotive=D.idaccmotive "
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("d.ayear", currAyear), 
                                    QHS.CmpLe("isnull(year(d.start),d.yestim)", currAyear),
                                    QHS.CmpEq("d.epkind", "F"),
                                    QHS.CmpGt("d.residual", 0),
                                    QHS.CmpEq("AC.ayear", currAyear),
                                    QHS.CmpGt("isnull(year(d.start),d.yestim)",2015)) +
						  "AND NOT EXISTS (SELECT * from entrydetail where idrelated = 'estim§' + d.idestimkind + " +
							 $"'§' + CONVERT(varchar(30), d.yestim) + '§' + CONVERT(varchar(4), d.nestim) + '§' + CONVERT(varchar(5), d.rownum) AND yentry < {currAyear} )";


            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "estimate";

            return tEntryDetail;
        }


        private bool doGenera(DataTable rateipassivi, DataTable rateiattivi,DataTable FattRicevere,DataTable FattEmettere,
            DataTable RateiParcelle, DataTable ParcelleRicevere,
            DataSet ds) {
            if (ds.Tables["entry"].Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna scrittura generata", "Avviso");
                return true;
            }
            if (ds.Tables["entrydetail"].Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna scrittura da generare", "Avviso");
                return true;
            }

            FrmEntryPreSave frm = new FrmEntryPreSave(rateiattivi,rateipassivi,
                FattRicevere,FattEmettere, RateiParcelle, ParcelleRicevere, Meta.Conn, AnnoCommerciale);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Operazione Annullata!");
                return true;
            }

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MEntry.Get_PostData();
            Post.InitClass(ds, Meta.Conn);

            if (Post.DO_POST()) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Generazione delle scritture automatiche di ratei e fatture da ricevere/emettere completata con successo!");
            }
            else {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nel salvataggio della scrittura di integrazione!", "Errore");
            }

            return true;
        }

        public static int ngiorniCommerciali(DateTime inizio, DateTime fine) {
            int giorni_primomese = inizio.Day > 30 ? 0 : 31 - inizio.Day;
            int giorni_ultimomese = fine.Day == 31 ? 30 : fine.Day;
            int n_anni_inmezzo = 0;
            if (fine.Year - inizio.Year > 1) n_anni_inmezzo = (fine.Year - inizio.Year) - 1;
            int n_mesi_inmezzo = 0;
            if (fine.Year > inizio.Year) {
                n_mesi_inmezzo = (12 - inizio.Month) + (fine.Month - 1);
            }
            else {
                if (fine.Month - inizio.Month > 1) {
                    n_mesi_inmezzo = fine.Month - inizio.Month - 1;
                }
            }
            return giorni_primomese + n_anni_inmezzo * 360 + n_mesi_inmezzo * 30 + giorni_ultimomese;
        }

        public static int NgiorniTotali(DateTime inizio, DateTime Fine, bool commerciale) {
            if (commerciale) {
                return ngiorniCommerciali(inizio, Fine);
            }
            else {
                return 1 + (Fine - inizio).Days;
            }

        }
        public static int NGiorniDaTrascorrere(DateTime Fine, int currAyear, bool commerciale) {
            if (commerciale) {
                DateTime gen1 = new DateTime(currAyear + 1, 1, 1);
                return ngiorniCommerciali(gen1, Fine);
            }
            else {
                DateTime dec31 = new DateTime(currAyear, 12, 31);
                return (Fine - dec31).Days;
            }
        }
        public static decimal SommaQuoteAnniPrecedenti(bool ConsideraAnnoCommerciale, int anno_attuale,
            decimal importo, DateTime inizioCompetenza, DateTime fineCompetenza) {
            decimal somma = 0;
            DateTime DataFine = fineCompetenza;
            int tot_giorni = NgiorniTotali(inizioCompetenza, fineCompetenza, ConsideraAnnoCommerciale);

            for (int i = inizioCompetenza.Year; i < anno_attuale; i++) {
                DateTime Inizio = DataInizioRateoDaConsiderare(inizioCompetenza, i);
                DateTime Fine = DataFineRateoDaConsiderare(DataFine, i);
                int tot_da_considerare = NgiorniTotali(Inizio, Fine, ConsideraAnnoCommerciale);
                decimal importoRateo = CfgFn.Round((importo / tot_giorni) * tot_da_considerare, 2);
                somma += importoRateo;
            }
            return somma;

        }
        public static DateTime DataInizioRateoDaConsiderare(DateTime inizioCompetenza, int currAyear){
            if (inizioCompetenza.Year < currAyear) {
                //Se la data inizio precede l'anno corrente, considera il primo dell'anno
                return  new DateTime(currAyear, 1, 1);
            }
            else
                return inizioCompetenza;
        }
        public static DateTime DataFineRateoDaConsiderare(DateTime fineCompetenza, int currAyear) {
            if (fineCompetenza.Year > currAyear) {
                return new DateTime(currAyear, 12, 31);
            }
            else
                return fineCompetenza;
        }

        public static decimal calcolaQuota(bool ConsideraAnnoCommerciale, int currAyear,
                    decimal importo, DateTime inizioCompetenza, DateTime fineCompetenza, out int ngiorni, out int ngiornitot) {
            DateTime Inizio = DataInizioRateoDaConsiderare(inizioCompetenza, currAyear);
            DateTime Fine = DataFineRateoDaConsiderare(fineCompetenza,currAyear);
            
            ngiornitot = NgiorniTotali(inizioCompetenza, fineCompetenza, ConsideraAnnoCommerciale);
            ngiorni = NgiorniTotali(Inizio, Fine, ConsideraAnnoCommerciale);
            
            if (fineCompetenza.Year == currAyear) {
                //Lavora per differenza come totale - importo anni precedenti
                return importo - SommaQuoteAnniPrecedenti(ConsideraAnnoCommerciale, currAyear, importo, inizioCompetenza, fineCompetenza);
            }



            decimal importoRateo = CfgFn.Round((importo / ngiornitot) * ngiorni, 2);
            return CfgFn.RoundValuta(importoRateo);
        }

        private bool doVerify() {
            string filter = QHS.AppAnd(QHS.CmpEq("identrykind", 2), //Rateo
                                QHS.CmpEq("Year(adate)", Meta.GetSys("esercizio")));

            string sqlCmd = " SELECT *" +
                     " FROM entry " +
                     " WHERE  " + filter;

            DataTable T = Meta.Conn.SQLRunner(sqlCmd);
            if ((T != null) && (T.Rows.Count > 0)) {
                if (MetaFactory.factory.getSingleton<IMessageShower>().Show("Esistono già delle scritture di rateo relative all''esercizio corrente. Si desidera proseguire comunque?", "Avviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
            }
            return true;
        }

        private string valutaIdAcc(object idAcc) {
            string filterC = QHC.CmpEq("idacc", idAcc);
            string filterSQL = QHC.CmpEq("idacc", idAcc);
            string filterPLC = "";
            string filterPLSQL = "";

            if (tAccount.Select(filterC).Length > 0) {
                DataRow rAcc = tAccount.Select(filterC)[0];
                filterPLC = QHC.CmpEq("idplaccount", rAcc["idplaccount"]);
                filterPLSQL = QHS.CmpEq("idplaccount", rAcc["idplaccount"]);
            }
            else {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAccount, null, filterSQL, null, true);
                if (tAccount.Select(filterC).Length > 0) {
                    DataRow rAcc = tAccount.Select(filterC)[0];
                    filterPLC = QHC.CmpEq("idplaccount", rAcc["idplaccount"]);
                    filterPLSQL = QHS.CmpEq("idplaccount", rAcc["idplaccount"]);
                }
            }

            if (filterPLC == "") return "";

            if (tPlAccount.Select(filterPLC).Length > 0) {
                return tPlAccount.Select(filterPLC)[0]["placcpart"].ToString().ToUpper();
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tPlAccount, null, filterPLSQL, null, true);

            if (tPlAccount.Select(filterPLC).Length > 0) {
                return tPlAccount.Select(filterPLC)[0]["placcpart"].ToString().ToUpper();
            }

            return "";

        }

        /// <summary>
        /// Metodo che costruisce un filtro per C#
        /// </summary>
        /// <param name="risconto"></param>
        /// <param name="rEntryDetail"></param>
        /// <returns></returns>
        private string costruisciFiltro(object risconto, DataRow rEntryDetail) {
            string filter = QHC.CmpEq("idacc", risconto);
            string f2 = QHC.MCmp(rEntryDetail, new string[] {"idreg", "idupb", "idsor1", "idsor2",
                "idsor3", "competencystop", "idaccmotive"});

            filter = QHC.AppAnd(filter, f2);
            return filter;
        }

        public void EditRelatedEntryByKey(DataRow rEntry) {
            if (rEntry == null) return;
            if ((rEntry["yentry"] == DBNull.Value) || (rEntry["nentry"] == DBNull.Value)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string checkfilter = QHS.MCmp(rEntry, new string[] { "yentry", "nentry" });
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }
    }
}
