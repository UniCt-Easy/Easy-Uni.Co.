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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using funzioni_configurazione;
using System.Data;
using System.Windows.Forms;

namespace calcolooccasionale {
    public class calcOccasionale {
        DataAccess Conn;
        DataRow RCasualContract;
        DataRow RCasualContractYear=null;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataTable SpeseOccasionale=null;
        public decimal quotaesente; //Quota esente per la data considerata, attualmente (2009) è 5000 euro
        DataTable TipoSpesa=null;
        public decimal A; //tot altri enti
        public decimal B1; //già pagato FISCALE stesso dip.
        public decimal B2; //già pagato PREVIDENZIALE stesso dip.
        public decimal C1;//spese già dedotte di altri contratti nell'anno
        public decimal C2;//spese già dedotte  di questo contratto nell'anno
        public decimal D; // impon.fiscale iniziale =  A+B- (C1+C2)
        public decimal F1;//spese già dedotte altri contratti
        public decimal F2;//spese già dedotte  questo contratto
        public decimal G;//imp.netto previdenziale al lordo della quota esente = D- (F1+F2)
        public decimal H1;//Quota esente già applicata
        public decimal H2;//Quota esente residua
        public decimal I;// Imponibile previdenziale netto già pagato = G-H1
        public decimal delta;// Quota imponibile non eccedente il massimale della ritenuta previdenziale INPS
        

        /// <summary>
        /// Importo lordo residuo del contratto
        /// </summary>
        //public decimal E; // impon. lordo residuo per questo contratto
        /// <summary>
        /// Spese fiscali residue
        /// </summary>
        public decimal C3;//spese da dedurre questo contratto
        //public decimal ImponibileFiscaleNetto; //=E-C3

        /// <summary>
        /// Spese previdenziali residue
        /// </summary>
        public decimal F3;//spese da dedurre questo contratto
        //public decimal ImponibilePrevidenzialeNetto; //= E-(H2+C3+F3) oppure 0 se minore di 0

        public decimal CompensoLordoPagato;
        public decimal CompensoLordoPagatoAnniPrecedenti;
        public decimal QuotaEsenteApplicataQuestoContrattoNellAnno;

        public int esercizio;
        bool _usaTabelleDataSet = false;

        public calcOccasionale(DataAccess Conn,DataRow RCasualContract) {
            this.Conn = Conn;
            this.RCasualContract = RCasualContract;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            quotaesente = calcolaQuotaEsente();
            SpeseOccasionale = Conn.RUN_SELECT("casualcontractrefund", "*", null,
                    QHS.CmpKey(RCasualContract), null, true);
            var casContractYear = Conn.RUN_SELECT("casualcontractyear", "*", null,
                    QHS.AppAnd(QHS.CmpKey(RCasualContract),QHS.CmpEq("ayear",esercizio)), null, true);
            if (casContractYear.Rows.Count > 0) {
                RCasualContractYear = casContractYear.Rows[0];
            }
            else {
                MessageBox.Show("Il contratto occasionale " + RCasualContract["ycon"] +
                                " del " + RCasualContract["ycon"] +
                                " non è stato ancora trasferito nell'anno corrente.", "Errore");

            }
            TipoSpesa = Conn.RUN_SELECT("casualrefund", "*", null, null, null, false);
        }

        public calcOccasionale(DataAccess conn, DataRow rCasualContract, DataRow rCasualContractYear,
            
                        DataTable spese,DataTable tipoSpese) {
            this.Conn = conn;
            this.RCasualContract = rCasualContract;
            this.RCasualContractYear = rCasualContractYear;
            QHC = new CQueryHelper();
            QHS = conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(conn.GetSys("esercizio"));
            quotaesente = calcolaQuotaEsente();
            SpeseOccasionale = spese;
            this.TipoSpesa = tipoSpese;
            _usaTabelleDataSet = true;
        }


        public int lastNConnCalled = -1;
        public int lastYConnCalled = -1;
        public int lastIDRegCalled = -1;

        DataSet LastDS1=null;
        DataSet LastDSAll=null;

        public void ResetHash() {
            lastNConnCalled = -1;
            lastYConnCalled = -1;
            lastIDRegCalled = -1;
        }
        public bool GetInfoContratto() {
            var insertMode = (RCasualContract.RowState == DataRowState.Added);
            var  ncontoconsider = CfgFn.GetNoNullInt32( RCasualContract["ncon"]);
            var ycontoconsider = CfgFn.GetNoNullInt32(RCasualContract["ycon"]);
            var idregtoconsider = CfgFn.GetNoNullInt32(RCasualContract["idreg"]);
            if (RCasualContract.RowState == DataRowState.Added) {
                ncontoconsider = 9999999;
            }

           
            DataRow R1=null;
            DataSet D1 = null; 

            if (!insertMode) {               
                if (lastNConnCalled == ncontoconsider && lastYConnCalled == ycontoconsider) {
                    D1 = LastDS1;
                }
                else {
                    D1 = DataAccess.CallSP(Conn, "compute_casualcontract",
                        new object[] { Conn.GetSys("esercizio"), ycontoconsider,
                                RCasualContract["ncon"]}, false, 30000);
                }
                if (D1 == null || D1.Tables.Count == 0) {
                    MessageBox.Show("Errore nella chiamata alla SP che calcola le informazioni sul contratto");
                    return false;
                }
                R1 = D1.Tables[0].Rows[0];

            }

            DataSet dall=null;
            if (lastIDRegCalled == idregtoconsider) {
                dall = LastDSAll;
            }
            else {
                dall = DataAccess.CallSP(Conn, "compute_casualcontract_all",
                        new object[] { Conn.GetSys("esercizio"), idregtoconsider }, false, 30000);              
            }
            if (dall==null || dall.Tables.Count==0) {
                MessageBox.Show("Errore nella chiamata alla SP che calcola le informazioni sul contratto");
                return  false;
            }
          

            DataRow rall= dall.Tables[0].Rows[0];

            //Imponibile netto altri enti
            A = 0;
            if (RCasualContractYear!=null) A= CfgFn.GetNoNullDecimal(RCasualContractYear["taxableotheragency"]); //tot altri enti

            //tot.pagato nell'anno FISCALE
            B1= CfgFn.GetNoNullDecimal( rall["payed_lastyear_F"]);

            if (!insertMode) {
                //spese fiscali dedotte altri contratti nell'anno
                C1 = CfgFn.GetNoNullDecimal(rall["F_refund_lastyear"]) - CfgFn.GetNoNullDecimal(R1["F_refund_lastyear"]);
                //spese fiscali già dedotte da questo contratto nell'anno
                C2 = CfgFn.GetNoNullDecimal(R1["F_refund_lastyear"]);
            }
            else {
                //spese fiscali dedotte altri contratti nell'anno
                C1 = CfgFn.GetNoNullDecimal(rall["F_refund_lastyear"]) ;
                //spese fiscali già dedotte da questo contratto nell'anno
                C2 = 0;
            }

            //impon.fiscale iniziale =  A+B1- (C1+C2)
            this.D = A+B1 - (C1+C2);

            if (!insertMode) {
                //spese previdenziali dedotte altri contratti nell'anno
                F1 = CfgFn.GetNoNullDecimal(rall["P_refund_lastyear"]) - CfgFn.GetNoNullDecimal(R1["P_refund_lastyear"]);
                //spese previdenziali già dedotte da questo contratto nell'anno
                F2 = CfgFn.GetNoNullDecimal(R1["P_refund_lastyear"]);
            }
            else {
                //spese previdenziali dedotte altri contratti nell'anno
                F1 = CfgFn.GetNoNullDecimal(rall["P_refund_lastyear"]) ;
                //spese previdenziali già dedotte da questo contratto nell'anno
                F2 = 0;
            }
            this.B2 = CfgFn.GetNoNullDecimal(rall["payed_lastyear_P"]);

            G = A + B2 - (F1 + F2 + C1 + C2);
                        //this.D - (F1+F2);//imp.netto previdenziale al lordo della quota esente = D- (F1+F2)
            if (G<0) G=0;

            quotaesente = calcolaQuotaEsente();
            //Quota esente applicata su tutti i contratti
            H1 = CfgFn.GetNoNullDecimal(rall["exemptionquota_applied"]);//quota esente applicata

            H1 = H1 + A;
            if (H1 > quotaesente) H1 = quotaesente;

            H2 = quotaesente - H1;
            //if (G >= quotaesente) {
            //    H1 = quotaesente;
            //    H2 = 0;
            //}
            //else {
            //    H1 = G;
            //    H2 = quotaesente - G;
            //}

            I = G - H1; //impon. netto già pagato

            if (_usaTabelleDataSet) {
                if (insertMode) {
                    C3 = totSpese("F");
                    F3 = totSpese("P");
                }
                else {
                    //spese ancora  da dedurre questo contratto
                    C3 = totSpese("F") - CfgFn.GetNoNullDecimal(R1["F_refund_total"]);
                    //spese previdenziali ancora  da dedurre questo contratto
                    F3 = totSpese("P") - CfgFn.GetNoNullDecimal(R1["P_refund_total"]);
                }

            }
            else {
                //spese ancora  da dedurre questo contratto
                C3 = CfgFn.GetNoNullDecimal(R1["F_refund_residual"]);
                //spese previdenziali ancora  da dedurre questo contratto
                F3 = CfgFn.GetNoNullDecimal(R1["P_refund_residual"]);
            }
           

            if (!insertMode) {
                CompensoLordoPagato = CfgFn.GetNoNullDecimal(R1["payed_total_F"]);
                CompensoLordoPagatoAnniPrecedenti = CfgFn.GetNoNullDecimal(R1["payed_prevyears"]);
                QuotaEsenteApplicataQuestoContrattoNellAnno = CfgFn.GetNoNullDecimal(R1["exemptionquota_applied"]);
            }
            else {
                CompensoLordoPagato = 0;
                CompensoLordoPagatoAnniPrecedenti = 0;
                QuotaEsenteApplicataQuestoContrattoNellAnno = 0;
            }

            //calcolo della quota eccedente il massimale della ritenuta previdenziale,
            //sulla base dell'imponibile complessivo del percipiente, al lordo della quota esente
            var E = GetLordoResiduo();
            var mInps = GetMassimaleRitenuta();
            delta = (G + E - F3) - mInps;
            if (delta < 0) delta = 0;

            LastDS1 = D1;
            LastDSAll = dall;
            lastNConnCalled = ncontoconsider;
            lastYConnCalled = ycontoconsider;
            return true;
        }

        public decimal GetLordoResiduo() {
            return CfgFn.GetNoNullDecimal(RCasualContract["feegross"]) - CompensoLordoPagato;  
        }

        public bool RitenuteFiscaliApplicabili() {
            var lordo = CfgFn.GetNoNullDecimal(RCasualContract["feegross"]);
            var spese = totSpese("F") + totSpese("P");
            return spese != lordo;
        }
        public decimal GetNettoResiduo() {
            decimal lordoresiduo= GetLordoResiduo();
            DataTable Riten = calcolaRitenute(lordoresiduo);
            decimal totrit = 0;
            if (Riten != null) {
                foreach (DataRow R in Riten.Select()) {
                    totrit += CfgFn.GetNoNullDecimal(R["employtax"]);
                }
            }
            return lordoresiduo - totrit;


        }
        public decimal GetImponibileFiscaleNetto(decimal lordo) {
            decimal x = lordo - C3;
            if (x < 0) x = 0;
            return x;
        }
        public decimal GetImponibilePrevidenzialeNetto(decimal lordo) {
            decimal x = lordo - (H2 + C3 + F3);
            if (x < 0) x = 0;
            return x;
        }

        decimal totSpese(string deduction) {
            deduction = deduction.ToUpper();
            decimal totSpeseFiscali = 0;
            var filter = QHC.NullOrLe("ayear", esercizio);
            if (SpeseOccasionale == null) return 0;
            // Calcola le spese deducibili previdenzialemente di QUESTO Contratto 
            if (SpeseOccasionale.Select(filter).Length == 0) return totSpeseFiscali;
            foreach (var r in SpeseOccasionale.Select(filter)) {
                var filterk = QHC.CmpEq("idlinkedrefund", r["idlinkedrefund"]);
                var rts = TipoSpesa.Select(filterk);
                if (rts.Length==0) continue;
                var isFiscale = rts[0]["deduction"] == DBNull.Value || rts[0]["deduction"].ToString().ToUpper() == deduction;
                if (isFiscale) {
                    totSpeseFiscali += CfgFn.GetNoNullDecimal(r["amount"]);
                }
            }
            return totSpeseFiscali;
        }

        bool applicaQuotaEsente(object idser) {
            var filtroPrestazione = QHS.CmpEq("idser", idser);
            // Flag che indica se deve essere applicata o meno la quota esente previdenziale a quella prestazione
            var flagnoexemptionquote = Conn.DO_READ_VALUE("service", filtroPrestazione, "ISNULL(flagnoexemptionquote,'N')");

            if (flagnoexemptionquote != null) {
                return flagnoexemptionquote.ToString() != "S";
            }

            return false;
        }
        
        bool nonConsideraAltriCompensi(object idser) {
            var filtroPrestazione = QHS.CmpEq("idser", idser);
            // Flag che indica se deve essere applicata o meno la quota esente previdenziale a quella prestazione
            var flagnoncumula = Conn.DO_READ_VALUE("service", filtroPrestazione, "ISNULL(flagnoncumula,'N')");

            if (flagnoncumula == null) return false;
            return flagnoncumula.ToString() == "S";
        }


        /// <summary>
        /// Metodo che calcola la quota esente in vigore rispetto alla data contabile della prestazione
        /// </summary>
        /// <returns>Importo della quota esente</returns>
        decimal calcolaQuotaEsente() {
            var curr = RCasualContract;
            if (!applicaQuotaEsente(curr["idser"])) return 0;
            var dateToConsider = (DateTime)Conn.GetSys("datacontabile");
            var filter = QHS.CmpLe("startvalidity", dateToConsider);
            var quotaes=Conn.RUN_SELECT("casualcontractexemption","*","startvalidity DESC",filter,"1",false);
            return quotaes.Rows.Count==0 ? 0 : CfgFn.GetNoNullDecimal( quotaes.Rows[0]["exemptionquota"]);
        }

        /// <summary>
        /// In base alla data contabile (del dataset), e codiceritenuta seleziona l'aliquota amm/dip
        /// </summary>
        /// <param name="codiceRitenuta"></param>
        /// <returns>Una riga da taxratebracketview, null se non trova aliquote</returns>
        private DataRow calcolaCampiQuota(object codiceRitenuta) {
            object datadaconsiderare = (DateTime) Conn.GetSys("datacontabile");
            var maxIdTaxRateStart = Conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpLe("start", datadaconsiderare),
                QHS.CmpEq("taxcode", codiceRitenuta)), "max(idtaxratestart)");

            var query = "select top 1 adminrate, employrate, taxablenumerator, taxabledenominator,"
                + " adminnumerator, admindenominator,"
                + " employnumerator, employdenominator"
                + " from taxratebracketview where " +
                QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                QHS.CmpEq("taxcode", codiceRitenuta))
                + " order by nbracket asc";

            var quotanumdenDt = Conn.SQLRunner(query);
            if ((quotanumdenDt == null) || (quotanumdenDt.Rows.Count == 0)) return null;
            return quotanumdenDt.Rows[0];
        }


       public decimal GetMassimaleRitenuta() {
           
           DataRow Curr = RCasualContract;
           string filtroPrestazione = QHS.CmpEq("idser", Curr["idser"]);
           DataTable ritenuteDellaPrestazione = DataAccess.RUN_SELECT(Conn, "servicetaxview",
                                                "taxcode,taxkind", "taxcode", filtroPrestazione, null, null, true);

           DataRow[] rInps = ritenuteDellaPrestazione.Select(QHS.CmpEq("taxkind", 3));
           if ((rInps.Length) == 0) return 0;

           object taxcode = rInps[0]["taxcode"]; // codice della ritenuta previdenziale
           object datadaconsiderare = (DateTime)Conn.GetSys("datacontabile");
           // Determina la più recente struttura aliquote 
           object maxIdTaxRateStart = Conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpLe("start", datadaconsiderare),
                QHS.CmpEq("taxcode", taxcode)), "max(idtaxratestart)");

           // Determina il massimale della struttura  aliquote considerata
           object maxamount =     Conn.DO_READ_VALUE("taxratebracket",
                QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                QHS.CmpEq("taxcode", taxcode)), "max(maxamount)");

                return CfgFn.GetNoNullDecimal(maxamount);
        }


        public DataTable calcolaRitenute(decimal lordoAlBeneficiario) {
           
            bool res = GetInfoContratto();
            if (!res) return null;

            var curr = RCasualContract;
            var currYear = RCasualContractYear;

            string[] colonnedaEliminare = { "cu", "ct", "lu", "lt" };
            var ritenuteDaPagare = Conn.CreateTableByName("casualcontracttaxbracket", "*");
            ritenuteDaPagare.Columns.Add("taxablenet", typeof(decimal));
            ritenuteDaPagare.Columns.Add("taxablegross", typeof(decimal));
            ritenuteDaPagare.Columns.Add("taxablenumerator", typeof(decimal));
            ritenuteDaPagare.Columns.Add("taxabledenominator", typeof(decimal));
            ritenuteDaPagare.Columns.Add("employnumerator", typeof(decimal));
            ritenuteDaPagare.Columns.Add("employdenominator", typeof(decimal));
            ritenuteDaPagare.Columns.Add("adminnumerator", typeof(decimal));
            ritenuteDaPagare.Columns.Add("admindenominator", typeof(decimal));
            foreach (string C in colonnedaEliminare) {
                ritenuteDaPagare.Columns.Remove(C);
            }
            if (lordoAlBeneficiario == 0) return ritenuteDaPagare;

            var filtroPrestazione = QHS.CmpEq("idser", curr["idser"]);
            var ritenuteDellaPrestazione = DataAccess.RUN_SELECT(Conn, "servicetaxview",
                "taxcode,taxkind", "taxcode", filtroPrestazione, null, null, true);

            // Per ogni ritenuta legata alla prestazione calcolo l'importo da pagare suddiviso per scaglioni
            foreach (DataRow ritenutaPrestazioneRow in ritenuteDellaPrestazione.Rows) {

                decimal imponibileDaTassare = 0;
                //Imponibile di Partenza: questo imponibile è utile quando si effettua il calcolo delle ritenute
                //previdenziali, in quanto a differenza degli altri tipi di ritenuta, la determinazione dello scaglione
                //di pertinenza dell'aliquota viene calcolato in modo incrementale, in pratica si resta sullo stesso scaglione
                //fin quando nello stesso anno non si raggiunge l'importo massimo dello scaglione di riferimento.
                decimal imponibileDiPartenza = 0;

                var quota = calcolaCampiQuota(ritenutaPrestazioneRow["taxcode"]);
                var frazioneImponibile = (quota != null)
                    ? rapporto(quota["taxablenumerator"], quota["taxabledenominator"]) : 0;

                switch (ritenutaPrestazioneRow["taxkind"].ToString()) {
                    case "1": { //fiscale
                        if (RitenuteFiscaliApplicabili()) {
                            imponibileDaTassare =
                                CfgFn.RoundValuta(GetImponibileFiscaleNetto(lordoAlBeneficiario) * frazioneImponibile);
                            imponibileDiPartenza = 0; //potrebbe essere this.D
                        }
                        else {
                            imponibileDaTassare = 0;
                            imponibileDiPartenza = 0;
                        }

                        break;
                    }
                    case "2": { //assistenziale
                        //Contro ordine: L'IRAP si applica sempre come da task 5505
                        imponibileDaTassare =
                            CfgFn.RoundValuta(GetImponibileFiscaleNetto(lordoAlBeneficiario) * frazioneImponibile);
                        imponibileDiPartenza = 0; //potrebbe essere this.D


                        //Modifica effettuata in base a task 5446
                        //if (RitenuteFiscaliApplicabili()) {
                        //    imponibileDaTassare = CfgFn.RoundValuta(GetImponibileFiscaleNetto(lordoAlBeneficiario) * frazioneImponibile);
                        //    imponibileDiPartenza = 0; //potrebbe essere this.D
                        //}
                        //else {
                        //    imponibileDaTassare = 0;
                        //    imponibileDiPartenza = 0;
                        //}
                        break;
                    }

                    case "3": { //previdenziale
                        var lordoAlBeneficiarioRicalcolato = lordoAlBeneficiario;
                        if (applicaQuotaEsente(curr["idser"])) lordoAlBeneficiarioRicalcolato -= delta;
                        if (lordoAlBeneficiarioRicalcolato < 0) lordoAlBeneficiarioRicalcolato = 0;
                        imponibileDaTassare =
                            CfgFn.RoundValuta(GetImponibilePrevidenzialeNetto(lordoAlBeneficiarioRicalcolato) *
                                              frazioneImponibile);

                        imponibileDiPartenza = this.I;
                        if (nonConsideraAltriCompensi(curr["idser"])) imponibileDiPartenza = 0;
                        break;
                    }
                    default: {
                        imponibileDaTassare = CfgFn.RoundValuta(lordoAlBeneficiario * frazioneImponibile);
                        imponibileDiPartenza = 0;
                        break;
                    }
                }

                object datadaconsiderare = (DateTime)Conn.GetSys("datacontabile");

                var maxIdTaxRateStart = Conn.DO_READ_VALUE("taxratestart",
                    QHS.AppAnd(QHS.CmpLe("start", datadaconsiderare),
                    QHS.CmpEq("taxcode", ritenutaPrestazioneRow["taxcode"])), "max(idtaxratestart)");

                var imponibileTotale = (imponibileDiPartenza + imponibileDaTassare);

                var calcolaSuAliquotaMarginale = ((ritenutaPrestazioneRow["taxkind"].ToString() == "1")
                    && (currYear!=null) &&(currYear["flaghigherrate"].ToString().ToUpper() == "S"));

                // Se viene applicata l'aliquota marginale basta prendere solo il primo scaglione altrimenti 
                // si procede normalmente
                // L'aliquota marginale è applicata solo sulla ritenuta fiscale ed è solo a carico del dipendente
                if (calcolaSuAliquotaMarginale) {
                    var riten = ritenuteDaPagare.NewRow();
                    riten["taxablegross"] = lordoAlBeneficiario;
                    riten["taxablenet"] = imponibileDaTassare;
                    riten["taxablenumerator"] = quota==null? 1: quota["taxablenumerator"];
                    riten["taxabledenominator"] = quota == null ? 1 : quota["taxabledenominator"];
                    riten["ycon"] = RCasualContract["ycon"];
                    riten["ncon"] = RCasualContract["ncon"];
                    riten["taxcode"] = ritenutaPrestazioneRow["taxcode"];
                    riten["nbracket"] = 1;
                    riten["taxable"] = imponibileDaTassare;
                    riten["adminrate"] = DBNull.Value;
                    riten["employrate"] = currYear["higherrate"];
                    riten["employtax"] = CfgFn.RoundValuta(imponibileDaTassare * CfgFn.GetNoNullDecimal(riten["employrate"]));
                    riten["admintax"] = DBNull.Value;
                    riten["employnumerator"] = quota == null ? 1 : quota["employnumerator"];
                    riten["employdenominator"] = quota == null ? 1 : quota["employdenominator"];
                    riten["adminnumerator"] = quota == null ? 1 : quota["adminnumerator"];
                    riten["admindenominator"] = quota == null ? 1 : quota["admindenominator"];

                    ritenuteDaPagare.Rows.Add(riten);
                    continue;
                }

                var query = "SELECT CASE " +
                    " WHEN " + QHS.CmpLe("ISNULL(minamount,0)", imponibileDiPartenza) +
                    " THEN " + QHS.quote(imponibileDiPartenza) +
                    " ELSE minamount " +
                    " END AS minamount, " +
                    " CASE " +
                    " WHEN " + QHS.NullOrGt("maxamount", imponibileTotale) +
                    " THEN " + QHS.quote(imponibileTotale) +
                    " ELSE maxamount " +
                    " END AS maxamount, " +
                    " adminnumerator, admindenominator, adminrate, " +
                    " employnumerator, employdenominator, employrate, nbracket " +
                    " from taxratebracketview where " +
                    QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                    QHS.CmpEq("taxcode", ritenutaPrestazioneRow["taxcode"])) +
                    "and (" + QHS.DoPar(QHS.AppAnd(QHS.CmpLe("minamount", imponibileDiPartenza),
                    QHS.NullOrGe("maxamount", imponibileDiPartenza))) +
                    " or " + QHS.Between("minamount", imponibileDiPartenza, imponibileTotale) + ")" +
                    " order by nbracket";

                var scaglioniDellaRitenuta = Conn.SQLRunner(query);
                // Aggiungo uno scaglione vuoto nel caso in cui non vengono generati scaglioni dalla query
                // in quanto ho bisogno di almeno uno scaglione per compatibilità con il modulo di spesa
                if ((scaglioniDellaRitenuta == null) || (scaglioniDellaRitenuta.Rows.Count == 0)) {
                    var riten = ritenuteDaPagare.NewRow();
                    riten["ycon"] = RCasualContract["ycon"];
                    riten["ncon"] = RCasualContract["ncon"];
                    riten["taxcode"] = ritenutaPrestazioneRow["taxcode"];
                    riten["nbracket"] = 1;
                    riten["taxable"] = 0;
                    riten["adminrate"] = DBNull.Value;
                    riten["employrate"] = DBNull.Value;
                    riten["employtax"] = 0;
                    riten["admintax"] = 0;
                    riten["taxablegross"] = lordoAlBeneficiario;
                    riten["taxablenet"] = imponibileDaTassare;
                    riten["taxablenumerator"] = quota == null ? 1 : quota["taxablenumerator"];
                    riten["taxabledenominator"] = quota == null ? 1 : quota["taxabledenominator"];
                    riten["employnumerator"] = quota == null ? 1 : quota["employnumerator"];
                    riten["employdenominator"] = quota == null ? 1 : quota["employdenominator"];
                    riten["adminnumerator"] = quota == null ? 1 : quota["adminnumerator"];
                    riten["admindenominator"] = quota == null ? 1 : quota["admindenominator"];

                    ritenuteDaPagare.Rows.Add(riten);
                    continue;
                }

                // Riempimento della tabella di output ritenuteDaPagare
                var numeroScaglione = 1;
                foreach (DataRow scagl in scaglioniDellaRitenuta.Rows) {
                    var riten = ritenuteDaPagare.NewRow();
                    riten["ycon"] = RCasualContract["ycon"];
                    riten["ncon"] = RCasualContract["ncon"];
                    riten["taxcode"] = ritenutaPrestazioneRow["taxcode"];
                    riten["nbracket"] = numeroScaglione;
                    riten["taxable"] = CfgFn.GetNoNullDecimal(scagl["maxamount"]) - CfgFn.GetNoNullDecimal(scagl["minamount"]);
                    riten["adminrate"] = scagl["adminrate"];
                    riten["employrate"] = scagl["employrate"];
                    var frazioneDipendente = rapporto(scagl["employnumerator"], scagl["employdenominator"]);
                    var frazioneAmministrazione = rapporto(scagl["adminnumerator"], scagl["admindenominator"]);
                    riten["employtax"] = CfgFn.RoundValuta((decimal)riten["taxable"] * CfgFn.GetNoNullDecimal(riten["employrate"]) * frazioneDipendente);
                    riten["admintax"] = CfgFn.RoundValuta((decimal)riten["taxable"] * CfgFn.GetNoNullDecimal(riten["adminrate"]) * frazioneAmministrazione);
                    riten["taxablegross"] = lordoAlBeneficiario;
                    riten["taxablenet"] = riten["taxable"];
                    riten["employnumerator"] = scagl["employnumerator"];
                    riten["employdenominator"] = scagl["employdenominator"];
                    riten["adminnumerator"] = scagl["adminnumerator"];
                    riten["admindenominator"] = scagl["admindenominator"];

                    ritenuteDaPagare.Rows.Add(riten);
                    numeroScaglione++;
                }
            }
            return ritenuteDaPagare;
        }

        /// <summary>
        /// Metodo che calcola il rapporto tra numeratore e denominatore
        /// </summary>
        /// <param name="quotanum">Numeratore</param>
        /// <param name="quotaden">Denominatore</param>
        /// <returns>Rapporto tra numeratore e denominatore</returns>
        public decimal rapporto(object quotanum, object quotaden) {
            decimal num = CfgFn.GetNoNullDecimal(quotanum);
            decimal den = CfgFn.GetNoNullDecimal(quotaden);
            if (den == 0) {
                return 1;
            }
            return num / den;
        }
    }
}
