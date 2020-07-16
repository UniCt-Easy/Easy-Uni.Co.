/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using System.Text;
using LiveUpdate;
using funzioni_configurazione;
using System.Collections;

namespace Install
{
	/// <summary>
	/// Summary description for Anagrafica.
	/// </summary>
	public class Anagrafica
	{
        public static void Reset() {
            lookupidcurrency = new Hashtable();
            migraValuta_eseguito = false;
            lookupidexpiration = new Hashtable();
            lookupidregistrykind = new Hashtable();
            migraClassCreddebi_eseguito = false;
            lookupidaddress = new Hashtable();
            MigraTipoIndirizzo_eseguito = false;
            migraQualifica_eseguita = false;
            lookupidpaymethod = new Hashtable();
            migraModalitaPagamento_eseguito = false;
            migraCreditoreDebitore_eseguito = false;
            migraContatto_eseguito = false;
            migrasportello_eseguito = false;
            migrabanca_eseguito = true;
            lookupidposition = new Hashtable();
        }

        public static bool EffettuaControlli (Form form, DataAccess SourceConn, bool question) {
            if (!controllaPosGiuridicaSenzaQualifica(form, SourceConn, question)) return false;
            if (!controllaCredDebiSenzaValuta(form, SourceConn, question)) return false;
            if (!controllaOrdineGenericoSenzaValuta(form, SourceConn, question)) return false;
            if (!controllaDocIvaSenzaValuta(form, SourceConn, question)) return false;
            if (!controllaIndTrasfertaSenzaValuta(form, SourceConn, question)) return false;
            if (!controllaMissioneTappaSenzaValuta(form, SourceConn, question)) return false;
            if (!controllaMissioneSpesaSenzaValuta(form, SourceConn, question)) return false;
            return true;
        }

        public static bool controllaPosGiuridicaSenzaQualifica (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicequalifica,codicecreddeb " +
                           " FROM posgiuridica WHERE "+
                           " codicequalifica  NOT IN (SELECT codicequalifica FROM qualifica)" +
                           " AND codicequalifica IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
            if (t.Rows.Count > 0) {
                messaggio = "Esistono le seguenti posizioni giuridiche che non hanno la corrispondente qualifica:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicequalifica"].Caption = "Codice Qualifica";
                t.Columns["codicecreddeb"].Caption = "Cred./Deb";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
               
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaOrdineGenericoSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicevaluta,esercordine,numordine " +
                           " FROM ordinegenerico WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
            if (t.Rows.Count > 0) {
                messaggio = "Esistono i seguenti ordini con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["esercordine"].Caption = "Eserc. Ordine";
                t.Columns["numordine"].Caption = "Num. Ordine";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaDocIvaSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicetipodoc,esercdocumento,numdocumento " + 
                           " FROM documentoiva WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
            if (t.Rows.Count > 0) {
                messaggio = "Esistono i seguenti documenti IVA con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["codicetipodoc"].Caption = "Tipo Documento IVA";
                t.Columns["esercdocumento"].Caption = "Esercizio";
                t.Columns["numdocumento"].Caption = "Numero";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaCredDebiSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicecreddeb FROM creditoredebitore WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
            if (t.Rows.Count > 0) {
                messaggio = "Esistono i seguenti creditori con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["codicecreddeb"].Caption = "Cod. Cred./Deb";
                t.Columns["denominazione"].Caption = "Cred./Deb";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaIndTrasfertaSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicevaluta,codicelocalita,datainizio,gruppo " +
                           " FROM indtrasfertaestero WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
            if (t.Rows.Count > 0) {
                messaggio = "Esistono le seguenti indennit‡ di trasferta con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["codicelocalita"].Caption = "Localit‡";
                t.Columns["datainizio"].Caption = "Data inzio";
                t.Columns["gruppo"].Caption = "Gruppo";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaMissioneTappaSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicevaluta,esercmissione,nummissione,numtappa,descrizione " + 
                           " FROM missionetappa WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
           
            if (t.Rows.Count > 0) {
                messaggio = "Esistono le seguenti tappe di Missione con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["esercmissione"].Caption = "Esercizio";
                t.Columns["nummissione"].Caption = "Numero Missione";
                t.Columns["numtappa"].Caption = "Numero Tappa";
                t.Columns["descrizione"].Caption = "Descrizione";
                DialogResult dr  = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        public static bool controllaMissioneSpesaSenzaValuta (Form form, DataAccess SourceConn, bool question) {
            string query = " SELECT codicevaluta,esercmissione,nummissione, " +
                           " numtappa,numspesa,descrizione " +
                           " FROM missionespesa WHERE " +
                           " codicevaluta  NOT IN (SELECT codicevaluta FROM valuta)" +
                           " AND codicevaluta IS NOT NULL ";
            string messaggio;
            DataTable t = SourceConn.SQLRunner(query, 0, out messaggio);
            if (messaggio != null) {
                MessageBox.Show(form, messaggio);
                return false;
            }
          
            if (t.Rows.Count > 0) {
                messaggio = "Esistono le seguenti tappe di Missione con valuta non riconosciuta:";
                string domanda = null;
                if (question) domanda = "Si intende procedere nella migrazione?";
                t.Columns["codicevaluta"].Caption = "Codice Valuta";
                t.Columns["esercmissione"].Caption = "Esercizio";
                t.Columns["nummissione"].Caption = "Numero Missione";
                t.Columns["numtappa"].Caption = "Numero Tappa";
                t.Columns["numspesa"].Caption = "Numero Spesa";
                t.Columns["descrizione"].Caption = "Descrizione";
                DialogResult dr = new FrmErrore(t, messaggio, domanda).ShowDialog(form);
                if (dr == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        static string CAMBIA_TIPORESIDENZA = "residence=case when "
            + "C.tiporesidenza in ('E','U','R','T', 'A') then 1 " //I
            + "when C.tiporesidenza ='C' then 2 "  //J
            + "when C.tiporesidenza ='F' then 3 " //X
            + "else 1 end";  //I
        //static string CAMBIA_TIPORESIDENZA = "residence=tiporesidenza";

        public static bool migraCreditoreDebitore_eseguito = false;
        //codiceclass ---> classcreddebi --> registrykind
        //tiporesidenza --> residence chiave esterna per residence.idresidence
        //static Hashtable lookup_idreg = new Hashtable();
		public  static bool migraCreditoreDebitore( Form form,  DataAccess sourceConn, DataAccess destConn) 
		{
            if (migraCreditoreDebitore_eseguito) return true;
            migraCreditoreDebitore_eseguito = true;
            migraValuta(form, sourceConn, destConn);
            migraClassCreddebi(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT foreigncf=C.codfiscaleestero, C.codicecreddeb, title= C.denominazione, " +
                "cf=C.codicefiscale, C.personafisica, C.tiporesidenza," + CAMBIA_TIPORESIDENZA + "," +
                "surname=C.cognome770, cu=C.createuser, ct=C.createtimestamp, birthdate=C.datanascita," +
                " C.codicepaese,p_iva=C.partitaiva, active=C.flagutilizzabile,annotation=C.descrizione, " +
                " lt=C.lastmodtimestamp, lu=C.lastmoduser, forename=C.nome770, txt=C.notes, rtf=C.olenotes, " +
                " gender=C.sesso, C.luogonascita, C.provnascita, C.statonascita, C.codiceclass, "+
                " extmatricula= (SELECT matricola FROM posgiuridica p0 WHERE p0.codicecreddeb=C.codicecreddeb AND " +
                        " NOT EXISTS "+
           	            "(SELECT * FROM posgiuridica p1 WHERE (p0.codicecreddeb = p1.codicecreddeb) " +
	                                                " AND (p0.datainizio < p1.datainizio))" +
                                        " AND p0.matricola IS NOT NULL) "+
                " FROM CREDITOREDEBITORE C");

            DataTable Registry = destConn.CreateTableByName("registry", "*");
            int maxidreg = 0;
            All.Columns.Add("idnation", typeof(int));
            All.Columns.Add("location", typeof(string));
            All.Columns.Add("idcity", typeof(int));
            All.Columns.Add("idregistryclass", typeof(string));
            All.Columns.Add("idtitle", typeof(string));
            All.Columns.Add("idregistrykind", typeof(int));
           



        


            foreach (DataRow Curr in All.Rows) {
                ElaboraRegistryTitle(Curr);
                ImpostaDataDaCF(Curr);
                ImpostaLuogoNascitaDaCF(Curr, destConn);
                ElaboraIDRegistryClass(Curr);
                ElaboraTitle(Curr);
                RaffinaIdRegistryClass(Curr);
                RaffinaSesso(Curr);
                DataRow R = Registry.NewRow();
                maxidreg++;
                R["idreg"] = maxidreg;
                R["idregistrykind"] = gethash(lookupidregistrykind, Curr["codiceclass"].ToString());
                //lookup_idreg[Curr["codicecreddeb"]] = maxidreg;
                foreach (string S in new string[] {"foreigncf","title","cf","surname","cu","ct","residence",
                            "birthdate","p_iva","active","annotation","lt","lu","forename","txt","rtf","gender",
                            "idcity","idnation","location","idregistryclass","idtitle","extmatricula"
                })
                    R[S] = Curr[S];

                Registry.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Registry);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Registry");
		}
        static bool Like(string S, params string []mask){
            S = S.ToUpper();
            foreach (string mm in mask) {
                string m = mm.ToUpper();
                bool first=false;
                if (m.StartsWith("%")){
                    m=m.Substring(1);
                    first=true;
                }
                bool last=false;
                if (m.EndsWith("%")){
                    m=m.Substring(0,m.Length-1);
                    last=true;
                }
                if (first&& last) {
                    if (S.IndexOf(m) >= 0) return true;
                    continue;
                }
                if (first) {
                    if (S.EndsWith(m)) return true;
                    continue;
                }
                else {
                    if (S.StartsWith(m)) return true;
                    continue;
                }
            }
            return false;
        }
    
        static void ElaboraIDRegistryClass(DataRow A) {
            if (A["personafisica"].ToString() == "") A["personafisica"] = "N";
            bool personafisica = (A["personafisica"].ToString().ToUpper() == "S");
            if (A["cf"].ToString().Length == 16) personafisica = true;
            string title = A["title"].ToString();
            if (Like(title, "%Dipartiment%", "%Universit%", "Univ.%", "Dip.%", "Centro interdip%", "REGIONE%",
                "Tesoreria%", "%INAIL%", "%I.N.A.I.L.%", "%INPS%", "COMUNE %", "%I.N.P.S%", "Associazione%", "%IRAP%",
                "%NON LUCRATIVA%", "%SENZA FINI DI LUCRO%", "%ONLUS%", "MINISTERO%", "%INPDAP%", "%I.N.P.D.A.P%",
                "%I.N.P.D.A.P%", "%ISTAT%", "AMM.NE%", "%A.S.L%", "Ospedale%", "%FACOLTA%", "SCUOLA %", "%ISTITUTO%",
                "IST.%", "%U.S.L%", "ASL %", "FONDAZIONE %", "COMITATO %", "ACCADEMIA %", "SOPRINTENDENZA %",
                "% SANITARIA LOCALE %", "%PROVINCIA DI %", "PROVINCIA %", "%AZIENDA OSPEDALIERA%", "POLICLINICO%")) {
                A["personafisica"] = "N";
                A["idregistryclass"] = "23";
                return;
            }
            if (Like(title, "%srl%","%s.r.l%","%snc%","%s.n.c%","% sas %","%s.a.s%","% sas %","%s.a.s%","%-sas-%",
                    "%-sas","%.sas %","%s.a.s%","%-sas-%","%-sas","%.sas %","%-sas %","%-sas","%.sas",
                    "% spa %","%s.p.a%","% spa.%","%-spa-%","%-spa","%S P A%","% sapa %","%s.a.p.a%","% s.s.%",
                    "% spa","% sas","% sapa","BANCA %","% BANK","% A R.L.","%A.R.L.%","HOTEL %","RISTORANTE %",
                    "DITTA %","STUDIO %"
                )) {
                A["personafisica"] = "N";
                A["idregistryclass"] = "21";
                return;
            }
            if (Like(title, "%INDIVID%","%INDIV.%","%DITTA IND%","%IMPRESA IND%","%IMP.IND%","%IMP. IND","%IMP.IND%",
                    "%IMP. IND","%IMP. IND."
               )) {
                A["personafisica"] = "S";
                A["idregistryclass"] = "21";
                return;
            }
            if (Like(title, "DITTA%") && Like(title.Substring(5), "% DI %")) {
                A["personafisica"] = "S";
                A["idregistryclass"] = "21";
                return;
            }
            if (personafisica && Like(title.Substring(4),"% DI %","%.DI %","%-DI %")) {
                A["personafisica"] = "S";
                A["idregistryclass"] = "21";
                return;
            }
        }

        static void ElaboraTitle(DataRow A) {
            if (A["personafisica"].ToString().ToUpper() != "S") return;
            string title = A["title"].ToString().ToUpper();
            if (Like(title,"%Avv.ssa%")){
                A["idtitle"]="12";
                return;
            }
            if (Like(title, "%Avv.%")) {
                A["idtitle"]="1";
                return;
            }
            if (Like(title, "%Ing.%")) {
                A["idtitle"] = "2";
                return;
            }
            if (Like(title, "%Dott.%","%DR.%")) {
                A["idtitle"] = "3";
                return;
            }
            if (Like(title, "%Dott.ssa%", "%D.ssa%","%DR.ssa%")) {
                A["idtitle"] = "4";
                return;
            }
            if (Like(title, "%Prof.%")) {
                A["idtitle"] = "5";
                return;
            }
            if (Like(title, "%Dir.%")) {
                A["idtitle"] = "6";
                return;
            }
            if (Like(title, "%Sig.%")) {
                A["idtitle"] = "7";
                return;
            }
            if (Like(title, "%Sig.ra%")) {
                A["idtitle"] = "8";
                return;
            }
            if (Like(title, "%Prof.ssa%")) {
                A["idtitle"] = "9";
                return;
            }
            if (Like(title, "%Rag.%")) {
                A["idtitle"] = "10";
                return;
            }
            if (Like(title, "%Geom.%")) {
                A["idtitle"] = "11";
                return;
            }
        }

        static void RaffinaIdRegistryClass(DataRow A) {
            if (A["idregistryclass"] != DBNull.Value) return;
            if ((A["personafisica"].ToString().ToUpper() == "S") && (A["foreigncf"].ToString().Trim() != "")) {
                A["idregistryclass"] = "22";//6
                return;
            }
            if ((A["personafisica"].ToString().ToUpper() == "S") && (A["p_iva"].ToString().Trim() != "")) {
                A["idregistryclass"] = "22";//7
                return;
            }
            if (A["personafisica"].ToString().ToUpper() == "S") {
                A["idregistryclass"] = "22";//5
                return;
            }
            if ((A["personafisica"].ToString().ToUpper() == "N") && (A["tiporesidenza"].ToString().ToUpper()=="C")&&
                (A["p_iva"].ToString().Trim() == "")) {
                A["idregistryclass"] = "23";//4
                return;
            }
            if ((A["personafisica"].ToString().ToUpper() == "N") && (A["tiporesidenza"].ToString().ToUpper() == "C") &&
                (A["p_iva"].ToString().Trim() != "")) {
                A["idregistryclass"] = "21";//2
                return;
            }
        }

        static void RaffinaSesso(DataRow A){
            if (A["personafisica"].ToString().ToUpper() == "N") {
                A["gender"] = DBNull.Value;
                return;
            }
            if (A["cf"].ToString().Length != 16) return;
            char C = A["cf"].ToString()[9];
            if (C <= '3') {
                A["gender"] = "M";
            }
            else {
                A["gender"] = "F";
            }

        }
        
        static void ElaboraRegistryTitle(DataRow A) {
            if (A["personafisica"].ToString().ToUpper() != "S") return;
            if (A["surname"].ToString() != "") return;
            if (A["forename"].ToString() != "") return;
            string title = A["title"].ToString().Trim().ToUpper();
            string personafisica = A["personafisica"].ToString().ToUpper();
            int di_position = -1;
            //bool flagindividuale = false;
            //ATTENZIONE ADESSO : SE @denominazione contiene ' DI '  allora Ë una ditta individuale!!!!!
            if (title.Length >= 5) {
                di_position = title.IndexOf(" DI ");
                if (di_position < 0) di_position = title.IndexOf("-DI ");
                if (di_position < 0) di_position = title.IndexOf(".DI ");
                if (di_position > 4) title = title.Substring(di_position + 4).Trim();
            }

            di_position = -1;
            //ATTENZIONE ADESSO : SE @denominazione contiene '% C/O %'  allora la parte dopo C/O Ë rimossa
            if (title.Length >= 5) {
                di_position = title.IndexOf(" C/O ");
                if (di_position < 0) di_position = title.IndexOf("-C/O ");
                if (di_position > 4) title = title.Substring(0,di_position).Trim();
            }

            di_position = -1;
            //ATTENZIONE ADESSO : SE @denominazione contiene '%-%'  allora ciÚ che segue il - 
            //          non Ë considerato ai fine di nome/cogn./titolo
            if (title.Length >= 5) {
                di_position = title.IndexOf("-");
                if (di_position > 5) {
                    title = title.Substring(0, di_position).Trim();
                    //flagindividuale = true;
                }
            }

            title= title.Replace("DITTA INDIVIDUALE","");
            title= title.Replace("DITTA IND.","");
            title= title.Replace("DITTA INDIV.","");
            title= title.Replace("IMPRESA INDIVIDUALE","");
            title= title.Replace("IMPRESA IND.","");
            title= title.Replace("IMP.IND.","");
            title= title.Replace("IMP. IND.","");
            title= title.Replace(" DITTA","");
            
            
            title= title.Replace("AVV.SSA","");
            title= title.Replace("AVV.","");
            title= title.Replace("ING.","");
            title= title.Replace("DOTT.SSA","");
            title= title.Replace("D.SSA","");
            title= title.Replace("DR.SSA","");
            title= title.Replace("DOTT.","");
            title= title.Replace("DR.","");

            title= title.Replace("PROF.SSA","");
            title= title.Replace("PROF.","");
            title= title.Replace("DIR.","");
            title= title.Replace("SIG.RA","");
            title= title.Replace("SIG.","");
            title= title.Replace("RAG.","");
            title= title.Replace("GEOM.","");
            title = title.Trim();

            string cognome = "";
            string nome = "";
            //prende il nuovocognome come prima parola di @_denominazione
            int mypos = title.IndexOf(" ");
            if (mypos > 0) {
                cognome = title.Substring(0, mypos);
                title = title.Substring(mypos).Trim();
                //'DI','DE','LA','LE','DEL','VON','DELLE','LO','DELLO'
                if ((cognome == "DI") || (cognome == "DE") || (cognome == "LA") || (cognome == "LE") || (cognome == "DEL")
                            || (cognome == "VON") || (cognome == "DELLE") || (cognome == "LO") || (cognome == "DELLO") ) {
                    mypos = title.IndexOf(" ");
                    if (mypos > 0) {
                        cognome = cognome + " " + title.Substring(0, mypos);
                        title = title.Substring(mypos).Trim();
                    }
                }
                if (title.Length > 30) {
                    nome = "";
                    cognome = "";
                    personafisica = "N";
                }
                else {
                    nome = title;
                }
            }
            else {
                nome = "";
                cognome = title;
            }
            if (nome!="") A["forename"] = nome;
            if (cognome != "") A["surname"] = cognome;
            A["personafisica"] = personafisica;
        }

        static void ImpostaDataDaCF(DataRow A) {
            string cf = A["cf"].ToString().Trim().ToUpper();
            if (cf.Length != 16) return;
            if (A["birthdate"] != DBNull.Value) return;

            try {
                if (!CodiceFiscaleValido(cf)) return;
                int anno = Convert.ToInt32(cf.Substring(6, 2));
                string M = cf.Substring(8, 1);
                int mese = 0;
                if (M == "A") mese = 1;
                if (M == "B") mese = 2;
                if (M == "C") mese = 3;
                if (M == "D") mese = 4;
                if (M == "E") mese = 5;
                if (M == "H") mese = 6;
                if (M == "L") mese = 7;
                if (M == "M") mese = 8;
                if (M == "P") mese = 9;
                if (M == "R") mese = 10;
                if (M == "S") mese = 11;
                if (M == "T") mese = 12;
                int gg = Convert.ToInt32(cf.Substring(9, 2));
                if (gg >= 40) gg -= 40;
                int anno_oggi = DateTime.Now.Year;
                anno += 1900;
                while (anno + 100 <= anno_oggi) anno += 100;
                A["birthdate"] = new DateTime(anno, mese, gg);

            }
            catch {
            }

        }

        static void ImpostaLuogoNascitaDaCF(DataRow A, DataAccess Dest) {
            QueryHelper QHS= Dest.GetQueryHelper();
            string cf = A["cf"].ToString().Trim().ToUpper();
            if (cf.Length==16 && CodiceFiscaleValido(cf)) {
                string codicenaz = cf.Substring(11, 4);
                if (codicenaz.StartsWith("Z")) {
                    DataTable T = Dest.SQLRunner(
                        "SELECT n.title,n.idnation from geo_nation_agency ne" +
                            " join geo_nation n on n.idnation=ne.idnation " +
                            " WHERE ne.idcode =1 AND ne.idagency=1 " +
                            " and isnull(ne.stop, {d '2079-06-06'}) " +
                            " = (select max(isnull(stop, {d '2079-06-06'}))     from geo_nation_agency g2 " +
                            "     WHERE g2.idcode=1 AND g2.idagency=1 AND g2.value=" + QHS.quote(codicenaz) +
                            " ) and ne.value=" + QHS.quote(codicenaz));
                    if (T.Rows.Count > 0) {
                        string statonasc = A["statonascita"].ToString().Trim().ToUpper();
                        string nazione = T.Rows[0]["title"].ToString().Trim().ToUpper();
                        string res = A["luogonascita"].ToString().Trim();
                        if (A["provnascita"].ToString().Trim() != "")
                            res += "(" + A["provnascita"].ToString().Trim() + ")";
                        if (statonasc != nazione) {
                            if (A["statonascita"].ToString().Trim() != "") {
                                res += "-" + A["statonascita"].ToString().Trim();
                            }
                        }
                        if (res == "")
                            A["location"] = DBNull.Value;
                        else
                            A["location"] = res;
                        A["idnation"] = T.Rows[0]["idnation"];
                        A["idcity"] = DBNull.Value;
                        return;
                    }
                }
                else {
                    DataTable T = Dest.SQLRunner(
                    "SELECT c.idcity,C.title from geo_cf cf "+
                        " join geo_city c on c.idcity=cf.idcity" +
                        " where cf.citycode =" + QHS.quote(codicenaz) );
                    if (T.Rows.Count > 0) {
                        A["idnation"] =DBNull.Value;
                        A["idcity"] = T.Rows[0]["idcity"];
                        string luogonasc = A["luogonascita"].ToString().Trim().ToUpper();
                        string city = T.Rows[0]["title"].ToString().Trim().ToUpper();
                        string res = "";
                        if (luogonasc != city) {
                            res = luogonasc;
                            if (A["provnascita"].ToString().Trim() != "")
                                res += "(" + A["provnascita"].ToString().Trim() + ")";
                            if (A["statonascita"].ToString().Trim() != "") {
                                    res += "-" + A["statonascita"].ToString().Trim();
                            }
                        }
                        if (res != "")
                            A["location"] = res;
                        else
                            A["location"] = DBNull.Value;
                        return;
                    }

                }

            }

            //Codice fiscale non valido oppure citt‡ non trovata dal CF
            string statonasc2= A["statonascita"].ToString().Trim();
            string luogonasc2= A["luogonascita"].ToString().Trim();
            string provnasc2= A["provnascita"].ToString().Trim();

            // Stati esteri riconosciuti dalla denominazione
            DataTable T2 = Dest.SQLRunner(
                "SELECT n.idnation from geo_nation n "+
                " where n.title=" + QHS.quote(statonasc2) +
                " and isnull(n.stop,{d '2079-06-06'})=(select max(isnull(n2.stop,{d '2079-06-06'})) "+
                " FROM geo_nation n2 where n2.title=" + QHS.quote(statonasc2) + ")" +
                " and n.title!='italia'"
                );

            if (T2.Rows.Count > 0) {
                A["idnation"] = T2.Rows[0]["idnation"];
                A["location"] = DBNull.Value;
                A["idcity"] = DBNull.Value;
                return;
            }
            //Denominazione unica tra i comuni operativi:
            T2 = Dest.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C WHERE C.title=" + QHS.quote(luogonasc2) +
                 " AND (select count(*) from geo_cityusable c2 where c2.title=" + QHS.quote(luogonasc2) + ")=1 ");
            if (T2.Rows.Count > 0) {
                A["idnation"] = DBNull.Value;
                A["location"] = DBNull.Value;
                A["idcity"] = T2.Rows[0]["idcity"];
                return;
            }
            //Denominazione unica tra tutti i comuni
            T2 = Dest.SQLRunner(
                 "SELECT C.idcity FROM geo_city C WHERE C.title=" + QHS.quote(luogonasc2) +
                 " AND (select count(*) from geo_city c2 where c2.title=" + QHS.quote(luogonasc2) + ")=1 ");
            if (T2.Rows.Count > 0) {
                A["idnation"] = DBNull.Value;
                A["location"] = DBNull.Value;
                A["idcity"] = T2.Rows[0]["idcity"];
                return;
            }
            //Denominazione unica tra tutti i comuni operativi della provincia
            T2 = Dest.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C JOIN geo_country CT ON CT.idcountry=C.idcountry "+
                 " WHERE C.title=" + QHS.quote(luogonasc2) + " AND CT.province=" + QHS.quote(provnasc2) +
                 " AND (select count(*) from geo_cityusable c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(luogonasc2) + " AND CT2.province=" + QHS.quote(provnasc2) + ")=1 ");
            if (T2.Rows.Count > 0) {
                A["idnation"] = DBNull.Value;
                A["location"] = DBNull.Value;
                A["idcity"] = T2.Rows[0]["idcity"];
                return;
            }

            //Denominazione unica tra tutti i comuni  della provincia
            T2 = Dest.SQLRunner(
                 "SELECT C.idcity FROM geo_city C JOIN geo_country CT ON CT.idcountry=C.idcountry " +
                 " WHERE C.title=" + QHS.quote(luogonasc2) + " AND CT.province=" + QHS.quote(provnasc2) +
                 " AND (select count(*) from geo_city c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(luogonasc2) + " AND CT2.province=" + QHS.quote(provnasc2) + ")=1 ");
            if (T2.Rows.Count > 0) {
                A["idnation"] = DBNull.Value;
                A["location"] = DBNull.Value;
                A["idcity"] = T2.Rows[0]["idcity"];
                return;
            }
            if (cf.Length == 16 && !CodiceFiscaleValido(cf)) {
                string codicenaz = cf.Substring(11, 4);
                if (codicenaz.StartsWith("Z")) {
                     T2 = Dest.SQLRunner(
                        "SELECT n.title,n.idnation from geo_nation_agency  ne "+
                            " join geo_nation n on n.idnation=ne.idnation " +
                            " WHERE ne.idcode =1 AND ne.idagency=1 " +
                            " and isnull(ne.stop, {d '2079-06-06'}) " +
                            " = (select max(isnull(stop, {d '2079-06-06'}))     from geo_nation_agency g2 " +
                            "     WHERE idcodice=1 AND idente=1 AND valore=" + QHS.quote(codicenaz) +
                            " ) and ne.value=" + QHS.quote(codicenaz));
                    if (T2.Rows.Count > 0) {
                        string statonasc = A["statonascita"].ToString().Trim().ToUpper();
                        string nazione = T2.Rows[0]["title"].ToString().Trim().ToUpper();
                        string res = A["luogonascita"].ToString().Trim();
                        if (A["provnascita"].ToString().Trim() != "")
                            res += "(" + A["provnascita"].ToString().Trim() + ")";
                        if (statonasc != nazione) {
                            if (A["statonascita"].ToString().Trim() != "") {
                                res += "-" + A["statonascita"].ToString().Trim();
                            }
                        }
                        if (res == "")
                            A["location"] = DBNull.Value;
                        else
                            A["location"] = res;
                        A["idnation"] = T2.Rows[0]["idnation"];
                        A["idcity"] = DBNull.Value;
                        return;
                    }
                }
                else {
                    DataTable T = Dest.SQLRunner(
                    "SELECT c.idcity,C.title from geo_cf cf " +
                        " join geo_city c on c.idcity=cf.idcity and cf.citycode =" + QHS.quote(codicenaz));
                    if (T.Rows.Count > 0) {
                        A["idnation"] = DBNull.Value;
                        A["idcity"] = T.Rows[0]["idcity"];
                        string luogonasc = A["luogonascita"].ToString().Trim().ToUpper();
                        string city = T.Rows[0]["title"].ToString().Trim().ToUpper();
                        string res = "";
                        if (luogonasc != city) {
                            res = luogonasc;
                            if (A["provnascita"].ToString().Trim() != "")
                                res += "(" + A["provnascita"].ToString().Trim() + ")";
                            if (A["statonascita"].ToString().Trim() != "") {
                                res += "-" + A["statonascita"].ToString().Trim();
                            }
                        }
                        if (res != "")
                            A["location"] = res;
                        else
                            A["location"] = DBNull.Value;
                        return;
                    }

                }

            }

            string res2 = luogonasc2;
            if (provnasc2 != "") res2 += "(" + provnasc2 + ")";
            if (statonasc2 != "") res2 += "-" + statonasc2;
            A["location"] = res2;
            A["idcity"] = DBNull.Value;
            A["idnation"] = DBNull.Value;
    
        }


        static bool CodiceFiscaleValido(string cf) {
            string errori = "";
            string codicefiscale =cf.Trim().ToUpper();
            if (codicefiscale == "") return false;

            //per entit‡ che hanno codice fiscale numerico da 11
            if (codicefiscale.Length == 11) {
                foreach (char c in codicefiscale.ToCharArray()) {
                    if (!char.IsDigit(c)) return false;
                }
                return true;
            }
            errori = "(deve essere composto da 16 caratteri e non " + codicefiscale.Length + ")";
            //ASSOLUTAMENTE NON VALIDO
            if (codicefiscale.Length != 16) return false;            
            bool isValid;
            char carControllo = funzioni_configurazione.CalcolaCodiceFiscale.GetLastChar(codicefiscale.Substring(0, 15), out isValid);
            if (!isValid) return false;
            if (carControllo != codicefiscale[15]) return false;
            return true;
        }

        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }

        public static bool migraContatto_eseguito = false;

        private static bool migraContatto(DataAccess sourceConn, DataAccess destConn,Form form) {
            if (migraContatto_eseguito) return true;
            migraContatto_eseguito = true;
            string query = "select ct=C.createtimestamp, cu=C.createuser, lt=C.lastmodtimestamp, lu=C.lastmoduser,"
                + " REG.idreg, referencename = C.nomecontatto, registryreferencerole = C.funzionecontatto,"
                + " phonenumber = ISNULL(C.telefonoprefisso,'') + ISNULL(C.telefononumero,''),"
                + " faxnumber = ISNULL(C.telefaxprefisso,'') + ISNULL(C.telefaxnumero,''),"
                + " email = C.indirizzoemail, userweb = C.loginweb, passwordweb = C.passwordweb, txt = C.notes, "
                + " rtf = C.olenotes "
                + " from contatto C "
                + " join creditoredebitore CR ON C.codicecreddeb=CR.codicecreddeb "
                + " join " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=CR.denominazione "
                + " order by REG.idreg ";

            string errMsg;
            DataTable All = sourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }
            DataTable RegistryReference = destConn.CreateTableByName("registryreference", "*");
            int nProg = 1;
            int lastIdReg = 0;
            foreach (DataRow r in All.Rows) {
                DataRow R= RegistryReference.NewRow();
                int currIdReg = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currIdReg != lastIdReg) {
                    nProg = 1;
                    lastIdReg = currIdReg;
                }
                else {
                    nProg++;
                }
                R["idregistryreference"] = nProg;
                R["flagdefault"] = "N";
                foreach (string S in new string[] {"ct","cu","lt","lu","idreg","referencename","registryreferencerole",
                          "phonenumber","faxnumber","email","userweb","passwordweb","txt","rtf"  
                }) {
                    R[S] = r[S];
                }
                RegistryReference.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(RegistryReference);

            return Migrazione.lanciaScript(form, destConn, ds, "Contatto -> registryreference");

        }


        public static Hashtable lookupidcurrency = new Hashtable();
        static bool migraValuta_eseguito=false;
        public static bool migraValuta(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraValuta_eseguito) return true;
            migraValuta_eseguito = true;
            CQueryHelper QHC = new CQueryHelper();
            DataTable Existent = destConn.SQLRunner("SELECT * from currency");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codecurrency"].ToString().ToUpper();
                lookupidcurrency[code] = RC["idcurrency"];
            }
            Existent.CaseSensitive = false;
            string query =
                "select ct = m.createtimestamp, cu = m.createuser, lt = m.lastmodtimestamp, lu = m.lastmoduser, "
             + " codecurrency=m.codicevaluta, description=m.descrizione "
             + " from valuta m ";
            string errMsg;
            DataTable All = sourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }
            All.Columns.Add("idcurrency", typeof(int));
            DataTable Currency = destConn.CreateTableByName("currency", "*");
            int maxidcurrency = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("currency",null,"max(idcurrency)"));
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codecurrency"].ToString().ToUpper();
                if (lookupidcurrency[code] != null) continue;
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidcurrency[code] = found[0]["idcurrency"];
                    continue;
                }
                DataRow R = Currency.NewRow();
                maxidcurrency++;
                R["idcurrency"] = maxidcurrency;
                foreach (string S in new string[] {"ct","lt","cu","lu","codecurrency","description" }) {
                    R[S] = Curr[S];
                }
                lookupidcurrency[code] = maxidcurrency;
                Currency.Rows.Add(R);
            }
            if (Currency.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Currency);

            return Migrazione.lanciaScript(form, destConn, ds, "valuta -> currency");
        }

        public static Hashtable lookupidexpiration = new Hashtable();
        public static void RiempiLookupIdexpiration(){
            lookupidexpiration["1"] = 1;
            lookupidexpiration["2"] = 2;
            lookupidexpiration["3"] = 4;
            lookupidexpiration["4"] = 3;
        }
        static object gethash(Hashtable A, string code) {
            if (code == "") return DBNull.Value;
            code = code.ToUpper();
            if (A[code] == null) {
                MessageBox.Show("Code " + code + " was not found in " + A.GetType().Name);
                return DBNull.Value;
            }
            return A[code];
        }
        private static bool migraModPag(DataAccess sourceConn, DataAccess destConn, Form form) {
            migraModalitaPagamento(form, sourceConn, destConn);
            migraValuta(form, sourceConn, destConn);
            RiempiLookupIdexpiration();

            string query = "select ct = m.createtimestamp, cu = m.createuser, lt = m.lastmodtimestamp, lu = m.lastmoduser,"
                + " idreg = REG.idreg, regmodcode = m.tipomodalita, CR.codicevaluta, m.codicemodalita,"
                + " cin = m.cin, idbank = m.codicebanca, idcab = m.codicesportello, cc = m.numeroconto, "
                + " paymentdescr = m.descpagamento, paymentexpiring = m.scadpagamento, m.tiposcadenza, "
                + " flagstandard = ISNULL(m.flagmodalitastandard,'N'), active = 'S', "
                + " txt = m.notes, rtf = m.olenotes "
                + "from modpagamentocreddebi m join creditoredebitore c on m.codicecreddeb = c.codicecreddeb "
                + " join creditoredebitore CR ON M.codicecreddeb=CR.codicecreddeb "
                + " join " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=CR.denominazione "
                + "order by REG.idreg";

            string errMsg;
            DataTable All = sourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }
            int nProg = 1;
            int lastIdReg = 0;
            All.Columns.Add("idpaymethod", typeof(int));
            All.Columns.Add("idregistrypaymethod", typeof(int));
            All.Columns.Add("idexpirationkind", typeof(int));
            All.Columns.Add("idcurrency", typeof(int));
            foreach (DataRow r in All.Rows) {
                int currIdReg = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currIdReg != lastIdReg) {
                    nProg = 1;
                    lastIdReg = currIdReg;
                }
                else {
                    nProg++;
                }
                r["idregistrypaymethod"] = nProg;
                
                r["idpaymethod"] = gethash( lookupidpaymethod, r["codicemodalita"].ToString());
                string tiposcad = r["tiposcadenza"].ToString().ToUpper();
                 r["idexpirationkind"] = gethash( lookupidexpiration,tiposcad);

                 r["idcurrency"] = gethash(lookupidcurrency,r["codicevaluta"].ToString());
            }
            All.Columns.Remove("codicemodalita");
            All.Columns.Remove("tiposcadenza");
            All.Columns.Remove("codicevaluta");
            All.TableName = "registrypaymethod";

            DataSet ds = new DataSet();
            ds.Tables.Add(All);

            return Migrazione.lanciaScript(form, destConn, ds, "Mod. Pagamento dell'Anagrafica -> registrypaymethod");

        }




        static Hashtable lookupidregistrykind = new Hashtable();
        static bool migraClassCreddebi_eseguito = false;
        private static bool migraClassCreddebi(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraClassCreddebi_eseguito) return true;
            migraClassCreddebi_eseguito = true;
            CQueryHelper QHC= new CQueryHelper();

            DataTable Existent = destConn.SQLRunner("SELECT * from registrykind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["sortcode"].ToString().ToUpper();
                lookupidregistrykind[code] = RC["idregistrykind"];
            }
            Existent.CaseSensitive = false;
            DataTable RegistryKind = destConn.CreateTableByName("registrykind", "*");
            DataTable All = sourceConn.SQLRunner("SELECT * from classcreddebi");

            int maxregkind = CfgFn.GetNoNullInt32( destConn.DO_READ_VALUE("registrykind",null,"max(idregistrykind)")) ;
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codiceclass"].ToString().ToUpper();
                if (lookupidregistrykind[code] != null) continue;
                string find = QHC.CmpEq("description", Curr["descrizione"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidregistrykind[code] = found[0]["idregistrykind"];
                    continue;
                }
                DataRow R = RegistryKind.NewRow();
                maxregkind++;
                R["idregistrykind"] = maxregkind;
                lookupidregistrykind[code] = maxregkind;
                R["sortcode"] = Curr["codiceclass"] ;
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                RegistryKind.Rows.Add(R);
            }
            if (RegistryKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(RegistryKind);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento RegistryKind");
        }


        static Hashtable lookupidaddress = new Hashtable();
        static bool MigraTipoIndirizzo_eseguito = false;
        static bool MigraTipoIndirizzo(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (MigraTipoIndirizzo_eseguito) return true;
            MigraTipoIndirizzo_eseguito = true;
            CQueryHelper QHC = new CQueryHelper();

            DataTable Existent = destConn.SQLRunner("SELECT * from address");
            foreach (DataRow RC in Existent.Rows) {
                lookupidaddress[RC["codeaddress"].ToString().ToUpper()] = RC["idaddress"];
            }
            Existent.CaseSensitive = false;
            lookupidaddress["AVPAG"] = lookupidaddress["07_SW_AVV"];
            lookupidaddress["CERRA"] = lookupidaddress["07_SW_CER"];
            lookupidaddress["CERT"] = lookupidaddress["07_SW_CER"];
            lookupidaddress["CERT?"] = lookupidaddress["07_SW_CER"];
            lookupidaddress["DOMFI"] = lookupidaddress["07_SW_DOM"];
            lookupidaddress["FISC"] = lookupidaddress["07_SW_DOM"];
            lookupidaddress["FISC?"] = lookupidaddress["07_SW_DOM"];
            lookupidaddress["FATVE"] = lookupidaddress["07_SW_FAT"];
            lookupidaddress["ORDIN"] = lookupidaddress["07_SW_ORD"];
            lookupidaddress["STAND"] = lookupidaddress["07_SW_DEF"];

            DataTable Address = destConn.CreateTableByName("address", "*");
            int naddress = CfgFn.GetNoNullInt32( destConn.DO_READ_VALUE("address",null,"max(idaddress)"));

            Address.Columns["lu"].DefaultValue = "SWMORE";
            Address.Columns["lt"].DefaultValue = DateTime.Now;
            Address.Columns["active"].DefaultValue = "S";
            

            DataTable All = sourceConn.SQLRunner(
                    "SELECT DISTINCT tipoindirizzo from indirizzo where tipoindirizzo is not null ");
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["tipoindirizzo"].ToString().ToUpper();
                if (lookupidaddress[code] != null) continue;
                string find = QHC.CmpEq("description", Curr["codeaddress"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidaddress[code] = found[0]["idaddress"];
                    continue;
                }
                naddress++;
                DataRow R = Address.NewRow();
                R["idaddress"] = naddress;
                R["codeaddress"] = code;
                R["description"] = R["codeaddress"];
                R["active"] = "N";
                Address.Rows.Add(R);
                lookupidaddress[code] = naddress;
            }
            if (Address.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Address);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Address");
                        
        }

        static object compose(object localita, object provincia, object stato) {
            string res = localita.ToString();
            if (provincia.ToString() != "") res += "(" + provincia.ToString() + ")";
            if (stato.ToString() != "") res += "-" + stato.ToString();
            if (res == "") return DBNull.Value;
            return res;
        }
        static void ElaboraIndirizzo(DataRow Source, DataRow Dest, DataAccess destConn) {
            QueryHelper QHS = destConn.GetQueryHelper();

            string stato = Source["stato"].ToString().ToUpper();
            string localita = Source["localita"].ToString().Trim();
            string provincia = Source["provincia"].ToString().Trim();
            // Stati esteri riconosciuti dalla denominazione
            DataTable T2 = destConn.SQLRunner(
                "SELECT n.idnation from geo_nation n " +
                " where isnull(n.stop,{d '2079-06-06'})=(select max(isnull(n2.stop,{d '2079-06-06'})) " +
                " FROM geo_nation n2 where n2.title=" + QHS.quote(stato) + ")" +
                " and n.title!='italia' and n.title=" + QHS.quote(stato) 
                );
            if (T2.Rows.Count > 0) {
                Dest["idnation"] = T2.Rows[0]["idnation"];
                Dest["location"] = compose(Source["localita"],Source["provincia"],Source["stato"]);
                Dest["idcity"] = DBNull.Value;
                Dest["flagforeign"] = "S";
                return;
            }
            //Denominazione unica tra i comuni operativi:
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C WHERE C.title=" + QHS.quote(localita) +
                 " AND (select count(*) from geo_cityusable c2 where c2.title=" + QHS.quote(localita) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["idnation"] = DBNull.Value;
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                Dest["flagforeign"] = "N";
                return;
            }
            //Denominazione unica tra tutti i comuni
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_city C WHERE C.title=" + QHS.quote(localita) +
                 " AND (select count(*) from geo_city c2 where c2.title=" + QHS.quote(localita) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["idnation"] = DBNull.Value;
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                Dest["flagforeign"] = "N";
                return;
            }
            //Denominazione unica tra tutti i comuni operativi della provincia
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C JOIN geo_country CT ON CT.idcountry=C.idcountry " +
                 " WHERE C.title=" + QHS.quote(localita) + " AND CT.province=" + QHS.quote(provincia) +
                 " AND (select count(*) from geo_cityusable c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(localita) + " AND CT2.province=" + QHS.quote(provincia) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["idnation"] = DBNull.Value;
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                Dest["flagforeign"] = "N";
                return;
            }

            //Denominazione unica tra tutti i comuni  della provincia
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_city C JOIN geo_country CT ON CT.idcountry=C.idcountry " +
                 " WHERE C.title=" + QHS.quote(localita) + " AND CT.province=" + QHS.quote(provincia) +
                 " AND (select count(*) from geo_city c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(localita) + " AND CT2.province=" + QHS.quote(provincia) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["idnation"] = DBNull.Value;
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                Dest["flagforeign"] = "N";
                return;
            }

            string cap = Source["codicepostale"].ToString().Trim();
            if (cap != "") {
                //CAP
                T2 = destConn.SQLRunner(
                     "SELECT C.idcity FROM geo_cap C " +
                     " WHERE C.cap=" + QHS.quote(cap));
                if (T2.Rows.Count > 0) {
                    Dest["idnation"] = DBNull.Value;
                    Dest["location"] = compose(Source["localita"], Source["provincia"], Source["stato"]);
                    Dest["idcity"] = T2.Rows[0]["idcity"];
                    Dest["flagforeign"] = "N";
                    return;
                }
            }
            //Altri stati
            if ((stato != "") && (stato != "I") && (!stato.StartsWith("IT"))) {
                Dest["idnation"] = DBNull.Value;
                Dest["location"] = compose(Source["localita"], Source["provincia"], Source["stato"]);
                Dest["idcity"] = DBNull.Value;
                Dest["flagforeign"] = "S";
                return;
            }

            //tutti gli altri
            Dest["idnation"] = DBNull.Value;
            Dest["location"] = compose(Source["localita"], Source["provincia"], Source["stato"]);
            Dest["idcity"] = DBNull.Value;
            Dest["flagforeign"] = "N";

            
        }

        static bool MigraIndirizzo(Form form, DataAccess sourceConn, DataAccess destConn) {
            MigraTipoIndirizzo(form, sourceConn, destConn);
            DataTable All = sourceConn.SQLRunner(
                    "SELECT REG.idreg, I.* from indirizzo I "+
                    " join creditoredebitore C ON C.codicecreddeb=I.codicecreddeb "+
                    " join "+getExtAccess(destConn,"registry",true)+" REG ON REG.title=C.denominazione "
                    );
            DataTable RegistryAddress = destConn.CreateTableByName("registryaddress", "*");

            foreach (DataRow Curr in All.Rows) {
                DataRow R = RegistryAddress.NewRow();
                R["idreg"] = Curr["idreg"];
                R["start"] = new DateTime(1900, 1, 1);
                object II = gethash(lookupidaddress,Curr["tipoindirizzo"].ToString());
                if (II == DBNull.Value) {
                    MessageBox.Show(II.ToString());
                    continue;
                }
                R["idaddresskind"] = II;
                R["officename"] = Curr["nomeufficio"];
                R["address"] = Curr["indirizzo"];
                R["cap"] = Curr["codicepostale"];
                R["active"] = "S";
                ElaboraIndirizzo(Curr, R, destConn); //Calcola idcity,idnation,location e flagforeign

                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                RegistryAddress.Rows.Add(R);

            }

            DataSet ds = new DataSet();
            ds.Tables.Add(RegistryAddress);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento RegistryAddress");


        }
        public static Hashtable lookupidposition = new Hashtable();
        static bool migraQualifica_eseguita = false;
        private static bool migraQualifica(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraQualifica_eseguita) return true;
            migraQualifica_eseguita = true;
            DataTable Existent = destConn.SQLRunner("SELECT * from position");
            Existent.CaseSensitive=false;
            CQueryHelper QHC = new CQueryHelper();

            DataTable Position = destConn.CreateTableByName("position", "*");
            DataTable All = sourceConn.SQLRunner("SELECT * from qualifica");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codeposition"].ToString().ToUpper();
                lookupidposition[code] = RC["idposition"];
            }
            int maxposition = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("position",null,"max(idposition)"));
            foreach (DataRow Curr in All.Rows) {
                string codice = Curr["codicequalifica"].ToString().ToUpper();
                string descrizione = Curr["descrizione"].ToString().ToUpper();
                if (lookupidposition[codice] != null) continue;
                string find = QHC.CmpEq("description", descrizione);
                DataRow[] found = Existent.Select(descrizione);
                if (found.Length > 0) {
                    lookupidposition[codice] = found[0]["idposition"];
                    continue;
                }
                DataRow R = Position.NewRow();
                maxposition++;
                R["idposition"] = maxposition;
                R["codeposition"] = codice ;
                R["description"] = Curr["descrizione"];
                R["maxincomeclass"] = Curr["maxclassestip"];
                R["active"] = "S";
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Position.Rows.Add(R);
            }
            if (Position.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Position);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Position");
        }

        private static bool migraPosGiuridica(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("registrylegalstatus", null, false) > 0) return true;
            migraQualifica(form,sourceConn,destConn);

            DataTable RegLegal = destConn.CreateTableByName("registrylegalstatus", "*");
            string query = "SELECT P.*, REG.idreg, P.codicequalifica from posgiuridica P " +
                        " JOIN creditoredebitore C ON P.codicecreddeb=C.codicecreddeb " +
                        " JOIN " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=C.denominazione "; 
                        //" LEFT OUTER JOIN "+getExtAccess(destConn,"position",true)+ 
                        //" PO ON PO.codeposition=P.codicequalifica"
                        
            DataTable All = sourceConn.SQLRunner(query);

            foreach (DataRow Curr in All.Rows) {
                DataRow R = RegLegal.NewRow();
                R["idreg"] = Curr["idreg"];
                R["start"] = Curr["datainizio"];
                R["idposition"] =  gethash(Anagrafica.lookupidposition,Curr["codicequalifica"].ToString());
                R["incomeclass"] = Curr["classe"];
                R["incomeclassvalidity"] = Curr["dataclasse"];

                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["active"] = "S";
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                RegLegal.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(RegLegal);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento registrylegalstatus");
        }

        private static bool migraPosRetributiva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("registrytaxablestatus", null, false) > 0) return true;
            migraQualifica(form, sourceConn, destConn);

            DataTable RegTaxable = destConn.CreateTableByName("registrytaxablestatus", "*");
            DataTable All = sourceConn.SQLRunner(
                        "SELECT P.*, REG.idreg  from posretributiva P " +
                        " JOIN creditoredebitore C ON P.codicecreddeb=C.codicecreddeb " +
                        " JOIN " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=C.denominazione " 
                        );

            foreach (DataRow Curr in All.Rows) {
                DataRow R = RegTaxable.NewRow();
                R["idreg"] = Curr["idreg"];
                R["start"] = Curr["datainizio"];
                R["supposedincome"] = Curr["retribfiscale"];
              

                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["active"] = "S";
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                RegTaxable.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(RegTaxable);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento registrytaxablestatus");
        }

        static bool migrabanca_eseguito = false;
        private static bool migrabanca(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migrabanca_eseguito) return true;
            migrabanca_eseguito = true;
            string query = "SELECT * from banca " +
                           "WHERE NOT EXISTS (SELECT idbank FROM " +
                           getExtAccess(destConn, "bank", true) +
                           " B WHERE B.idbank = banca.codicebanca) ";

            DataTable Bank = destConn.CreateTableByName("bank", "*");
            DataTable All = sourceConn.SQLRunner(query);
          
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Bank.NewRow();
                R["idbank"] = Curr["codicebanca"];
                R["description"] = Curr["descrizione"];
                R["flagusable"] = "S";
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Bank.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Bank);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Bank");
        }

        static void ElaboraSportello(DataRow Source, DataRow Dest, DataAccess destConn) {
            QueryHelper QHS = destConn.GetQueryHelper();

            string localita = Source["localita"].ToString().Trim();
            string provincia = Source["provincia"].ToString().Trim();
            
            //Denominazione unica tra i comuni operativi:
            DataTable T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C WHERE C.title=" + QHS.quote(localita) +
                 " and (select count(*) from geo_cityusable c2 where c2.title=" + QHS.quote(localita) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                return;
            }
            //Denominazione unica tra tutti i comuni
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_city C WHERE C.title=" + QHS.quote(localita) +
                 " and (select count(*) from geo_city c2 where c2.title=" + QHS.quote(localita) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                return;
            }
            //Denominazione unica tra tutti i comuni operativi della provincia
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_cityusable C JOIN geo_country CT ON CT.idcountry=C.idcountry " +
                 " WHERE C.title=" + QHS.quote(localita) + " AND CT.province=" + QHS.quote(provincia) +
                 " and (select count(*) from geo_cityusable c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(localita) + " AND CT2.province=" + QHS.quote(provincia) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                return;
            }

            //Denominazione unica tra tutti i comuni  della provincia
            T2 = destConn.SQLRunner(
                 "SELECT C.idcity FROM geo_city C JOIN geo_country CT ON CT.idcountry=C.idcountry " +
                 " WHERE C.title=" + QHS.quote(localita) + " AND CT.province=" + QHS.quote(provincia) +
                 " and (select count(*) from geo_city c2 JOIN geo_country CT2 ON CT2.idcountry=C2.idcountry " +
                 "  where c2.title=" + QHS.quote(localita) + " AND CT2.province=" + QHS.quote(provincia) + ")=1 ");
            if (T2.Rows.Count > 0) {
                Dest["location"] = DBNull.Value;
                Dest["idcity"] = T2.Rows[0]["idcity"];
                return;
            }

            string cap = Source["cap"].ToString().Trim();
            if (cap != "") {
                //CAP
                T2 = destConn.SQLRunner(
                     "SELECT C.idcity FROM geo_cap C " +
                     " WHERE C.cap=" + QHS.quote(cap));
                if (T2.Rows.Count > 0) {
                    Dest["location"] = compose(Source["localita"], Source["provincia"], DBNull.Value);
                    Dest["idcity"] = T2.Rows[0]["idcity"];
                    return;
                }
            }

            

            //tutti gli altri
            Dest["location"] = compose(Source["localita"], Source["provincia"], DBNull.Value);
            Dest["idcity"] = DBNull.Value;


        }

        static bool migrasportello_eseguito = false;
        private static bool migrasportello(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migrasportello_eseguito) return true;
            migrasportello_eseguito = true;
            string query = "SELECT * from sportellobanca " +
                       "WHERE NOT EXISTS (SELECT idcab FROM " +
                       getExtAccess(destConn, "cab", true) +
                       " C WHERE C.idcab = sportellobanca.codicesportello AND " +
                       " C.idbank = sportellobanca.codicebanca) ";
            DataTable Bank = destConn.CreateTableByName("cab", "*");
            DataTable All = sourceConn.SQLRunner(query);
           

            foreach (DataRow Curr in All.Rows) {
                DataRow R = Bank.NewRow();
                R["idbank"] = Curr["codicebanca"];
                R["idcab"] = Curr["codicesportello"];
                R["description"] = Curr["descrizione"];
                R["address"] = Curr["indirizzo"];
                R["cap"] = Curr["cap"];
                ElaboraSportello(Curr, R, destConn);

                R["flagusable"] = "S";
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Bank.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Bank);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento cab");
        }


        public static Hashtable lookupidpaymethod = new Hashtable();
        static bool migraModalitaPagamento_eseguito = false;
        public static bool migraModalitaPagamento(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraModalitaPagamento_eseguito) return true;
            migraModalitaPagamento_eseguito = true;
            DataTable Existent = destConn.SQLRunner("SELECT * from paymethod");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["methodbankcode"].ToString().ToUpper();
                lookupidpaymethod[code] = RC["idpaymethod"];
            }

            DataTable All = sourceConn.SQLRunner("SELECT * from modalitapagamento");
            int nmaxpaymethod = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("paymethod",null,"max(idpaymethod)")) ;

            DataTable Paymethod=destConn.CreateTableByName("paymethod","*");
            CQueryHelper QHC = new CQueryHelper();

            foreach (DataRow Curr in All.Rows) {
                string code=Curr["codicemodalita"].ToString().ToUpper();
                if (lookupidpaymethod[code] != null) continue;
                //lo cerca nelle descrizioni (chiave alternativa)
                string finddescr = QHC.CmpEq("description", Curr["descrizione"]);
                if (Existent.Select(finddescr).Length > 0) {
                    DataRow found = Existent.Select(finddescr)[0];
                    lookupidpaymethod[code] = found["idpaymethod"];
                    continue;
                }
                nmaxpaymethod++;
                DataRow R = Paymethod.NewRow();
                R["idpaymethod"] = nmaxpaymethod;
                lookupidpaymethod[code] = nmaxpaymethod;
                R["active"] = "S";
                R["methodbankcode"] = Curr["codicemodalita"];
                R["description"] = Curr["descrizione"];
                int flag = 0;
                if (Curr["flagavvisopag"].ToString().ToUpper() == "S") flag += 1;
                R["allowdeputy"] = "N";
                R["flag"] = flag;
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Paymethod.Rows.Add(R);
            }
            if (Paymethod.Rows.Count == 0) return true;

            DataSet ds = new DataSet();
            ds.Tables.Add(Paymethod);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Paymethod");
        }



  
  
        /// <summary>
		/// Migra le tabelle speciali dell'Anagrafica.
		/// Questo metodo sar‡ chiamato da copiatutto
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tColName"></param>
		/// <returns></returns>
        public static bool migraAnagrafica(Form form, DataAccess sourceConn, DataAccess destConn) {
            //if (!migraValuta(form, sourceConn, destConn)) return false;
            //if (!migraClassCreddebi(form, sourceConn, destConn)) return false;
            
            //"creditoredebitore -> registry"
			if (!migraCreditoreDebitore(form,sourceConn, destConn)) return false;

            //"contatto -> registryreference"
            if (!migraContatto(sourceConn, destConn, form)) return false;

            //"modpagamentocreddebi -> registrypaymethod"
            if (!migraModalitaPagamento(form, sourceConn, destConn)) return false;
            if (!migraModPag(sourceConn, destConn, form)) return false;


            if (!MigraTipoIndirizzo(form,sourceConn, destConn)) return false;
            if (!MigraIndirizzo(form, sourceConn, destConn)) return false;

            
            if (!migraQualifica(form, sourceConn, destConn)) return false;
            if (!migraPosGiuridica(form, sourceConn, destConn)) return false;

            if (!migraPosRetributiva(form, sourceConn, destConn)) return false;

            if (!migrabanca(form, sourceConn, destConn)) return false;
            if (!migrasportello(form, sourceConn, destConn)) return false;

            //"cdruolo -> role"
			return true;
		}

		
	}
}
