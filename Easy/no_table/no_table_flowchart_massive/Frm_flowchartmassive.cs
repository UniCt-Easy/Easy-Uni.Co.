
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using notable_importazione;
using System.Collections;

namespace no_table_flowchart_massive {
    public partial class Frm_flowchartmassive : MetaDataForm {

        MetaData Meta;
        Easy_DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public IOpenFileDialog myOpenFile;

        string department;
        
        

        public Frm_flowchartmassive() {
            InitializeComponent();
            myOpenFile = createOpenFileDialog(_myOpenFile);
        }


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;

            Conn = Meta.Conn as Easy_DataAccess;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            department = Conn.GetSys("userdb").ToString();
        }

        #region AggiungiUtente
        bool AggiungiLogin(string login,string password) {
            //DataTable T1 = Conn.SQLRunner(
            //    "select DISTINCT loginname = (case when (o.sid = 0x00) then NULL else l.loginname end) " +
            //    " from dbo.sysusers o " +
            //    "left join master.dbo.syslogins l on l.sid = o.sid " +
            //    "where ((o.issqlrole != 1 and o.isapprole != 1 ) or (o.sid = 0x00) " +
            //    "and o.hasdbaccess = 1)and o.isaliased != 1 ");

            DataTable T1 = Conn.SQLRunner(
                "select DISTINCT loginname from master.dbo.syslogins " +
                   "where hasaccess = 1 and isntgroup=0");




            //esce se la login è già presente 
            if (T1 != null) {
                foreach (DataRow R1 in T1.Rows) {
                    if (R1["loginname"].ToString().ToUpper() == login.ToUpper()) return true;
                }
            }
            
            string err;
            string dbname = Conn.GetSys("database").ToString();
            Conn.DO_SYS_CMD(//"EXEC sp_addlogin " + QHS.quote(login)+","+QHS.quote(password)
                "CREATE LOGIN ["+login+"] WITH PASSWORD="+QHS.quote(password)+","+
                        "DEFAULT_DATABASE = "+dbname+","+
                        "CHECK_EXPIRATION = OFF,"+
                        "CHECK_POLICY = OFF"                
                ,out err);
            if (err != null) {
                show("Errore creando la login "+login+": " + err);
                return false;
            }
            return true;
        }

        bool CollegaUtenteADipartimento(string login, string iddbdepartment) {
            DataTable Utenti = Conn.RUN_SELECT("dbaccess", "*", null, 
                            QHS.AppAnd(QHS.CmpEq("iddbdepartment",iddbdepartment),
                                        QHS.CmpEq("login",login)),null, false);
            if (Utenti != null && Utenti.Rows.Count > 0) return true; //già presente

            Conn.SQLRunner("exec sp_grantdbaccess " +
                    QueryCreator.quotedstrvalue(login, false) + ", " +
                    QueryCreator.quotedstrvalue(login, false));
            Conn.SQLRunner("exec sp_addrolemember  N'db_denydatawriter'," +QHS.quote(login));
            Conn.SQLRunner("GRANT  SELECT  ON [dbo].[dbaccess] TO [" + login + "]");
            Conn.SQLRunner("GRANT  SELECT  ON [" + iddbdepartment + "].[customobject] TO [" + login + "]");
            Conn.SQLRunner("GRANT  SELECT  ON [" + iddbdepartment + "].[columntypes] TO [" + login + "]");

            string err;
            Conn.linkUserToDepartment(login,out err);

            if (err != null && err != "") {
                show("Errore associando l'utente " + login + ":" + err + "\r\n");
                return false;
            }

            return true;
        }


        /// <summary>
        /// Aggiunge un utente al db e lo collega al dipartimento selezionato, sempre che non vi faccia già parte
        ///  idcustomuser è posta uguale alla login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        bool AggiungiUtente(string login) {
            bool res = AggiungiLogin(login, "**********");
            if (res) res = CollegaUtenteADipartimento(login, department);
            return res;
        }

        #endregion


        #region AggiungiUtenteAdOrganigramma

        void CheckEsistenzaGruppoOrganigramma() {
            if (Conn.RUN_SELECT_COUNT("customgroup", QHS.CmpEq("idcustomgroup", "ORGANIGRAMMA"), false) > 0) return;
            string sql = "insert into customgroup (idcustomgroup,description,groupname) values " +
                            " ('ORGANIGRAMMA','Organigramma','organigramma')";
            Conn.SQLRunner(sql, false);
        }

        bool AggiungiUtenteAGruppoOrganigramma(string idcustomuser,string login) {

            //Aggiunge la riga in customuser ove necessario
            DataTable tCustomUser = Conn.RUN_SELECT("customuser", "*", null, QHS.CmpEq("idcustomuser", idcustomuser), null, false);
            if (tCustomUser.Rows.Count == 0) {
                Conn.SQLRunner("insert into customuser(idcustomuser,lt,lu,ct,cu,username) values " +
                            "(" + QHS.List(idcustomuser, DateTime.Now, "flowchartmassive", 
                                            DateTime.Now, "flowchartmassive", login) + ")", true);
            }
            else {
                Conn.SQLRunner("update customuser set username=" + QHS.quote(login) + " WHERE " + QHS.CmpEq("idcustomuser", idcustomuser), true);
            }

            CheckEsistenzaGruppoOrganigramma();

            DataTable tCustomGroup = DataAccess.CreateTableByName(Meta.Conn, "customgroup", "*");
            DataTable tSecurityVar = DataAccess.CreateTableByName(Meta.Conn, "securityvar", "*");

            DataTable tCustomUserGroup = DataAccess.CreateTableByName(Meta.Conn, "customusergroup", "*");
            DataTable tUserEnvironment = DataAccess.CreateTableByName(Meta.Conn, "userenvironment", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCustomGroup, null,
                QHS.CmpEq("idcustomgroup", "ORGANIGRAMMA"), null, true);
            fillUserInGroup(idcustomuser, tCustomGroup, tCustomUserGroup);

            // Fill della tabella securityvar
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tSecurityVar, null, null, null, true);
            fillUserEnvironment(idcustomuser, tSecurityVar, tUserEnvironment);

            DataSet dsPost = new DataSet();
            dsPost.Tables.Add(tCustomUserGroup);
            dsPost.Tables.Add(tUserEnvironment);

            Easy_PostData pd = new Easy_PostData();
            pd.InitClass(dsPost, Meta.Conn);
            if (!pd.DO_POST()) {
                show(this, "Errore nel salvataggio dei dati in AggiungiUtenteAGruppoOrganigramma", "Errore");
                return false;
            }
            else {
                return true;
            }
        }

        private void fillUserInGroup(object idcustomuser, DataTable tCustomGroup, DataTable tCustomUserGroup) {
            if (idcustomuser == null) return;
            if (tCustomGroup == null) return;
            if (tCustomUserGroup == null) return;
            string fuser = QHS.CmpEq("idcustomuser", idcustomuser);
            foreach (DataRow rGroup in tCustomGroup.Rows) {
                string fgruppo = QHS.CmpEq("idcustomgroup", rGroup["idcustomgroup"]);
                string filter = QHS.AppAnd(fuser, fgruppo);

                if (tCustomUserGroup.Select(QHC.AppAnd(QHC.CmpEq("idcustomuser", idcustomuser),
                                                    QHC.CmpEq("idcustomgroup", rGroup["idcustomgroup"]))).Length > 0) return;
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCustomUserGroup, null,
                                    QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                                    QHS.CmpEq("idcustomgroup", rGroup["idcustomgroup"])), null, true);
                if (tCustomUserGroup.Select(filter).Length > 0) return;

                DataRow rCustomUserGroup = tCustomUserGroup.NewRow();
                rCustomUserGroup["idcustomuser"] = idcustomuser;
                rCustomUserGroup["idcustomgroup"] = rGroup["idcustomgroup"];
                rCustomUserGroup["lastmodtimestamp"] = DateTime.Now;
                rCustomUserGroup["lastmoduser"] = "Software and More";
                rCustomUserGroup["ct"] = DateTime.Now;
                rCustomUserGroup["cu"] = "Software and More";
                rCustomUserGroup["lt"] = DateTime.Now;
                rCustomUserGroup["lu"] = "Software and More";

                tCustomUserGroup.Rows.Add(rCustomUserGroup);
            }
        }

        private void fillUserEnvironment(object idcustomuser, DataTable tSecurityVar, DataTable tUserEnvironment) {
            if (idcustomuser == null) return;
            if (tSecurityVar == null) return;
            if (tUserEnvironment == null) return;

            foreach (DataRow rSecurityVar in tSecurityVar.Rows) {
                string f_c = QHC.AppAnd(QHC.CmpEq("idcustomuser", idcustomuser), QHC.CmpEq("variablename", rSecurityVar["variablename"]));
                string f_sql = QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser), QHS.CmpEq("variablename", rSecurityVar["variablename"]));
                   
                if (tUserEnvironment.Select(f_c).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tUserEnvironment, null, f_sql, null, true);
                }
                DataRow rUserEnvironment = null;
                if (tUserEnvironment.Select(f_c).Length > 0)
                    rUserEnvironment = tUserEnvironment.Select(f_c)[0];
                else
                    rUserEnvironment = tUserEnvironment.NewRow();

                rUserEnvironment["idcustomuser"] = idcustomuser;
                rUserEnvironment["variablename"] = rSecurityVar["variablename"];
                rUserEnvironment["value"] = rSecurityVar["value"];
                rUserEnvironment["flagadmin"] = "N";
                rUserEnvironment["kind"] = rSecurityVar["kind"];
                rUserEnvironment["lt"] = DateTime.Now;
                rUserEnvironment["lu"] = "Software and More";

                if (tUserEnvironment.Select(f_c).Length == 0)
                    tUserEnvironment.Rows.Add(rUserEnvironment);
            }
        }

        public class FlowChartUser {
            public string idcustomuser;
            public object flowchartcode;

            public object idsor01;
            public object idsor02;
            public object idsor03;
            public object idsor04;
            public object idsor05;

            public object flagdefault;

            public object all_sorkind01;
            public object all_sorkind02;
            public object all_sorkind03;
            public object all_sorkind04;
            public object all_sorkind05;

            public object sorkind01_withchilds;
            public object sorkind02_withchilds;
            public object sorkind03_withchilds;
            public object sorkind04_withchilds;
            public object sorkind05_withchilds;

            public object title;
            public object start;
        }

        
        /// <summary>
        /// Aggiunge un utente al gruppo organigramma e poi lo collega ad uno specifico nodo dell'organigramma stesso
        /// </summary>
        /// <param name="FlowChartUserToAdd"></param>
        /// <returns></returns>
        bool AggiungiUtenteAdOrganigramma(FlowChartUser FlowChartUserToAdd) {
            MetaData meta_flowchartuser = Meta.Dispatcher.Get("flowchartuser");

            string idcustomuser = FlowChartUserToAdd.idcustomuser;
            string login = idcustomuser; // assunzione base

            bool res = AggiungiUtenteAGruppoOrganigramma(idcustomuser, login);
            if (!res) return false;

            object idflowchart = Conn.DO_READ_VALUE("flowchart", 
                    QHS.AppAnd(QHS.CmpEq("codeflowchart", FlowChartUserToAdd.flowchartcode),    
                        QHS.CmpEq("ayear",Conn.GetSys("esercizio")))
                        ,"idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) {
                show(this,
                    "Il codice " + FlowChartUserToAdd.flowchartcode + " non è presente nella tabella organigramma dell'anno "+
                        Conn.GetSys("esercizio").ToString()+".",
                    "Errore");
                return false;
            }

            string f = QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser), QHS.CmpEq("idflowchart", idflowchart),
                                QHS.CmpEq("title", FlowChartUserToAdd.title));
            if (Conn.RUN_SELECT_COUNT("flowchartuser", f, false) > 0) return true; //già presente 

            DataTable TFlowchartUser = Conn.CreateTableByName("flowchartuser", "*");
            DataSet D = new DataSet();
            D.Tables.Add(TFlowchartUser);

            MetaData.SetDefault(TFlowchartUser, "idflowchart", idflowchart);
            MetaData.SetDefault(TFlowchartUser, "idcustomuser", idcustomuser);

            meta_flowchartuser.SetDefaults(TFlowchartUser);
            DataRow fu = meta_flowchartuser.Get_New_Row(null, TFlowchartUser);

            fu["title"] = FlowChartUserToAdd.title;

            fu["idsor01"] = FlowChartUserToAdd.idsor01;
            fu["idsor02"] = FlowChartUserToAdd.idsor02;
            fu["idsor03"] = FlowChartUserToAdd.idsor03;
            fu["idsor04"] = FlowChartUserToAdd.idsor04;
            fu["idsor05"] = FlowChartUserToAdd.idsor05;

            fu["all_sorkind01"] = FlowChartUserToAdd.all_sorkind01;
            fu["all_sorkind02"] = FlowChartUserToAdd.all_sorkind02;
            fu["all_sorkind03"] = FlowChartUserToAdd.all_sorkind03;
            fu["all_sorkind04"] = FlowChartUserToAdd.all_sorkind04;
            fu["all_sorkind05"] = FlowChartUserToAdd.all_sorkind05;

            fu["sorkind01_withchilds"] = FlowChartUserToAdd.sorkind01_withchilds;
            fu["sorkind02_withchilds"] = FlowChartUserToAdd.sorkind02_withchilds;
            fu["sorkind03_withchilds"] = FlowChartUserToAdd.sorkind03_withchilds;
            fu["sorkind04_withchilds"] = FlowChartUserToAdd.sorkind04_withchilds;
            fu["sorkind05_withchilds"] = FlowChartUserToAdd.sorkind05_withchilds;

            fu["flagdefault"] = FlowChartUserToAdd.flagdefault;

            fu["start"] = FlowChartUserToAdd.start==DBNull.Value? new DateTime(1900, 1, 1): FlowChartUserToAdd.start;

            Easy_PostData pd = new Easy_PostData();
            pd.InitClass(D, Conn);
            if (!pd.DO_POST()) {
                show(this, "Errore nel salvataggio dei dati in AggiungiUtenteAdOrganigramma", "Errore");
                return false;
            }
            else {
                return true;
            }

        }
       
        #endregion

        public bool CustomUserExists(object idcustomuser) {
            string filter = QHS.CmpEq("idcustomuser", idcustomuser);

            DataTable DT = Conn.RUN_SELECT("customuser", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0) return false;
            if (DT.Rows.Count == 1) return true;
            return false;
        }

        public bool AddVirtualUser(DataAccess WebConn, WebUser WU) {
            if (!CustomUserExists(WU.idcustomuser)) {
                show(this, "L'utente " + WU.idcustomuser.ToString() +
                    " non esiste nel dipartimento, impossibile associarlo al profilo web " + WU.login + ".", "Errore");
                return false;
            }

            string filter = QHS.AppAnd(QHS.CmpEq("userkind", WU.tipoutente), QHS.CmpEq("codicedipartimento", department),
               QHS.CmpEq("username", WU.login));
            int numberofrecs = WebConn.RUN_SELECT_COUNT("virtualuser", filter, false);

            string query = "SELECT MAX(idvirtualuser) as maxvalue from virtualuser";
            DataTable RES = WebConn.SQLRunner(query);
            int newkeynum=1;
            if (RES!=null && RES.Rows.Count>0) newkeynum = CfgFn.GetNoNullInt32(RES.Rows[0]["maxvalue"]) + 1;

            string sql;
            if (numberofrecs > 0) {
                sql = "UPDATE virtualuser set sys_user=" + QHS.quote(WU.idcustomuser) +
                                    ", surname=" + QHS.quote(WU.cognome) +
                                    ", forename=" + QHS.quote(WU.nome) +
                                    ", cf=" + QHS.quote(WU.cf) +
                                    ", email=" + QHS.quote(WU.email) +
                                    " WHERE " + filter;
            }
            else {
                sql = "INSERT INTO virtualuser (idvirtualuser,username,codicedipartimento,userkind,sys_user,surname,forename,cf,email) " +
                        " VALUES (" + QHS.List(
                        new object[] { newkeynum, WU.login, department, WU.tipoutente, WU.idcustomuser, WU.cognome, WU.nome, WU.cf, WU.email }
                            ) + ")";
            }
            WebConn.SQLRunner(sql);
            int newnumberofrecs = WebConn.RUN_SELECT_COUNT("virtualuser", filter, false);
            if (newnumberofrecs == 1) return true;
            show(this, "Problemi nell'aggiornare virtualuser (" + WU.idcustomuser + ")", "Errore");
            return false;

        }

        public bool CollegaResponsabile(DataAccess WebConn, WebUser WU, FlowChartUser FCU) {
            if (!CollegaUtenteNormale(WebConn, WU, FCU)) return false;

            DataTable Man = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("email", WU.email), null, false);
            if (Man == null || Man.Rows.Count == 0) {
                show(this,"L'utente " + WU.login + " è associato ad una mail responsabile inesistente (" + WU.email + ")", "Errore");
                return false;
            }
            if (Man.Rows.Count > 1) {
                show(this, "L'utente " + WU.login + " è associato ad una mail responsabile presente in più responsabili (" + WU.email + ")", "Errore");
                return false;
            }
            string sql = "UPDATE manager set userweb=" + QHS.quote(WU.login) +
                                //    ", passwordweb=" + QHS.quote(WU.email)+ 
                        " WHERE " + QHS.CmpKey(Man.Rows[0]);
            Conn.SQLRunner(sql,false,100);

            return AddVirtualUser(WebConn, WU);
        }

        public bool CollegaUtenteNormale(DataAccess WebConn, WebUser WU, FlowChartUser FCU) {
            if (WU.login.ToString() == "") {
                show(this, "Impossibile aggiungere un utente senza login", "Errore");
                return false;
            }
            //Aggiunge l'utente al dipartimento e 
            if (!AggiungiUtente(WU.login.ToString())) return false; //per gli utenti normali login= idcustomuser 

            if (FCU.flowchartcode != DBNull.Value) {
                if (!AggiungiUtenteAdOrganigramma(FCU)) return false;
                return AddVirtualUser(WebConn, WU);
            }
            return true; //se non c'è una voce di organigramma lo aggiunge come utente normale punto e basta                      
        }

        public bool CollegaUtenteLDAP(DataAccess WebConn, WebUser WU, FlowChartUser FCU) {

            //if (!CollegaUtenteNormale(WebConn, WU, FCU)) return false;
            //se è ANCHE un responsabile lo segna comunque tra i responsabili impostando la userweb di quel resp.

            DataTable Man = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("email", WU.email), null, false);
            
            if (Man.Rows.Count > 1) {
                show(this, "L'utente " + WU.login + " è associato ad una mail responsabile presente in più responsabili (" + WU.email + ")", "Errore");
                return false;
            }
            if (Man.Rows.Count == 1) {
                string sql = "UPDATE manager set userweb=" + QHS.quote(WU.login) +
                    //    ", passwordweb=" + QHS.quote(WU.email)+ 
                            " WHERE " + QHS.CmpKey(Man.Rows[0]);
                Conn.SQLRunner(sql, false, 100);
            }


            return AddVirtualUser(WebConn, WU);
        }
       


        public class WebUser {
            public object tipoutente; //1 resp. 2 fornitore 3utenteapp 4 utenteldap >>userkind
            public object nome; //   >>forename
            public object cognome;  //>> surname
            public object cf;
            public object email; //se da collegare ad un responsabile, dovrebbe essere la stessa del responsabile nel db e la sua
                                 // userweb e posta uguale a "login"
            public object login; //ha un significato che dipende da tipoutente >>username
            public object idcustomuser; // va in sys_user , rappresenta l'utente impersonato
        }

        bool CollegaUtenteWeb(DataAccess WebConn, WebUser WU, FlowChartUser FCU) {
            int tipo = CfgFn.GetNoNullInt32(WU.tipoutente.ToString().Trim());
            switch (tipo) {
                case 1: return CollegaResponsabile(WebConn, WU, FCU);
                case 3: return CollegaUtenteNormale(WebConn, WU, FCU);
                case 4: return CollegaUtenteLDAP(WebConn, WU, FCU);
                case 5: return CollegaUtenteLDAP(WebConn, WU, FCU);
                default:
                    show(this,
                        "Il tipo utente " + WU.tipoutente.ToString() + " non è contemplato (login " + WU.login + ")", "Errore");
                    return false;
            }
            
        }
        DataAccess GetWebConnection() {
            string server = txtServerWeb.Text.Trim();
            string db = txtDatabaseWeb.Text.Trim();
            string user = txtUserWeb.Text.Trim();
            string password = txtPasswordWeb.Text.Trim();

            return new DataAccess("test", server, db, user, password, DateTime.Now.Year, DateTime.Now);
        }


        bool CheckConnection(DataAccess Test,bool quiet) {
            
            bool res = Test.Open();
            Test.Close();
            if (res) {
                if (!quiet) {
                    show(this, "Connessione al db di sistema web effettuata con successo", "Avviso");
                }
            }
            else {
                show(this, "Errore nella connessione al db di sistema web:\r\n" +
                            Test.LastError, "Errore");
            }

            return res;
        }
        string[] tracciato_importautenti = new string[]{
            //campi per WebUser
            "tipoutente;Tipo utente (1 resp. 3 utente normale 4 utente ldap 5 utente SSO);Codificato;1;1|3|4|5",
            "nome;Nome;Stringa;50",
            "cognome;Cognome;Stringa;50",
            "cf;Codice fiscale;Stringa;16",
            "email;EMail address;Stringa;40",
            "login;Login (significato varia in base a tipoutente);Stringa;40",
            "idcustomuser;IDCustomuser, login dell'utente impersonato ove diverso da login;Stringa;30",

            //Campi per FlowChartUser
            "flowchartcode;Codice oganigramma;Stringa;50",
            "codiceattr01;Codice attributo 1;Stringa;50",
            "codiceattr02;Codice attributo 2;Stringa;50",
            "codiceattr03;Codice attributo 3;Stringa;50",
            "codiceattr04;Codice attributo 4;Stringa;50",
            "codiceattr05;Codice attributo 5;Stringa;50",
            "flagdefault;Ruolo di default (S/N);Codificato;1;S|N",
            "all_attr01;Nessun filtro per attributo 1 (S/N);Codificato;1;S|N",
            "all_attr02;Nessun filtro per attributo 2 (S/N);Codificato;1;S|N",
            "all_attr03;Nessun filtro per attributo 3 (S/N);Codificato;1;S|N",
            "all_attr04;Nessun filtro per attributo 4 (S/N);Codificato;1;S|N",
            "all_attr05;Nessun filtro per attributo 5 (S/N);Codificato;1;S|N",
            "attr01_childs;Include i nodi figli per attributo 1 (S/N);Codificato;1;S|N",
            "attr02_childs;Include i nodi figli per attributo 2 (S/N);Codificato;1;S|N",
            "attr03_childs;Include i nodi figli per attributo 3 (S/N);Codificato;1;S|N",
            "attr04_childs;Include i nodi figli per attributo 4 (S/N);Codificato;1;S|N",
            "attr05_childs;Include i nodi figli per attributo 5 (S/N);Codificato;1;S|N",
            "ruolo;Nome del ruolo;Stringa;30",
            "datainizio;Data inizio ruolo;data;8"

        };
        private void btnTestServerWeb_Click(object sender, EventArgs e) {
            DataAccess Test = GetWebConnection();
            if (Test == null) {
                show(this, "Errore nella connessione al db di sistema web.", "Errore");
                return ;
            }
            CheckConnection(GetWebConnection(),false);
            Test.Destroy();
        }

        private void btnImportaUtenti_Click(object sender, EventArgs e) {
            DataAccess WebConn = GetWebConnection();
            if (WebConn == null) {
                show(this, "Errore nella connessione al db di sistema web.", "Errore");
                return ;
            }
            if (!CheckConnection(WebConn, true)) return;

            myOpenFile.RestoreDirectory = true;
            DialogResult DR = myOpenFile.ShowDialog(this);
            if (DR != DialogResult.OK) {
                WebConn.Destroy();
                return;
            }
            WebConn.Open();
            FrmNotable_Importazione.LeggiFile Reader = new FrmNotable_Importazione.LeggiFile();
            Reader.Init(tracciato_importautenti, myOpenFile.FileName);
            txtResult.Text = "";
            WebUser WU;
            FlowChartUser FCU;
            bool err = false;
            int nrighe_lette=0;
            while (GetDataFromReader(Reader, out WU, out FCU)) {
                nrighe_lette++;
                if (WU.login == null || WU.login == DBNull.Value || WU.login.ToString() == "") {
                    txtResult.Text += "Utente  privo di login trovato e ignorato.\r\n";
                    err = true;
                    Application.DoEvents();
                    continue;
                }
                string utente = WU.login + "(tipo " + WU.tipoutente + ")";

                if (WU.idcustomuser == null || WU.idcustomuser.ToString()=="") {
                    txtResult.Text += utente + " privo di idcustomuser quindi non creato.\r\n";
                    err = true;
                    Application.DoEvents();
                    continue;
                }

                if (CollegaUtenteWeb(WebConn, WU, FCU)) {
                    //txtResult.Text += utente + " creato con successo \r\n";
                }
                else {
                    txtResult.Text += utente + " non creato o creato con problemi.\r\n";
                    err = true;
                    Application.DoEvents();
                }
            }
            Reader.Close();
            if (!err) {
                txtResult.Text += "Nessun problema riscontrato.\r\n";
            }

            WebConn.Close();
            WebConn.Destroy();
            show(this, "Operazione completata. Dal file sono state lette:" + nrighe_lette+ " righe.", "Avviso");
        }

        public bool GetDataFromReader(FrmNotable_Importazione.LeggiFile Reader, out WebUser WU, out FlowChartUser FCU) {
            Reader.GetNext();
            WU = null;
            FCU = null;
            if (!Reader.DataPresent()) return false;
            WU = new WebUser();
            FCU = new FlowChartUser();

            WU.cf = Reader.getCurrField("cf");
            WU.cognome = Reader.getCurrField("cognome");
            WU.email = Reader.getCurrField("email");
            WU.idcustomuser = Reader.getCurrField("idcustomuser");
            WU.login = Reader.getCurrField("login");
            WU.nome = Reader.getCurrField("nome");
            WU.tipoutente = Reader.getCurrField("tipoutente");

            FCU.all_sorkind01 = Reader.getCurrField("all_attr01");
            FCU.all_sorkind02 = Reader.getCurrField("all_attr02");
            FCU.all_sorkind03 = Reader.getCurrField("all_attr03");
            FCU.all_sorkind04 = Reader.getCurrField("all_attr04");
            FCU.all_sorkind05 = Reader.getCurrField("all_attr05");

            FCU.flagdefault = Reader.getCurrField("flagdefault");
            FCU.flowchartcode = Reader.getCurrField("flowchartcode");
            FCU.idcustomuser = Reader.getCurrField("idcustomuser").ToString();

            FCU.sorkind01_withchilds = Reader.getCurrField("attr01_childs");
            FCU.sorkind02_withchilds = Reader.getCurrField("attr02_childs");
            FCU.sorkind03_withchilds = Reader.getCurrField("attr03_childs");
            FCU.sorkind04_withchilds = Reader.getCurrField("attr04_childs");
            FCU.sorkind05_withchilds = Reader.getCurrField("attr05_childs");

            FCU.title = Reader.getCurrField("ruolo");

            FCU.idsor01 = attr_id_fromcode(1, Reader.getCurrField("codiceattr01"));
            FCU.idsor02 = attr_id_fromcode(2, Reader.getCurrField("codiceattr02"));
            FCU.idsor03 = attr_id_fromcode(3, Reader.getCurrField("codiceattr03"));
            FCU.idsor04 = attr_id_fromcode(4, Reader.getCurrField("codiceattr04"));
            FCU.idsor05 = attr_id_fromcode(5, Reader.getCurrField("codiceattr05"));

            FCU.start = Reader.getCurrField("datainizio");
            return true;
        }

        Hashtable SorKind = null;
        object attr_id_fromcode(int num, object code) {
            if (code == null || code == DBNull.Value) return DBNull.Value;
            if (code.ToString() == "") return DBNull.Value;

            if (SorKind == null) {
                SorKind = new Hashtable();
                object idsorkind01 = Conn.DO_READ_VALUE("uniconfig", null, "idsorkind01", null);
                object idsorkind02 = Conn.DO_READ_VALUE("uniconfig", null, "idsorkind02", null);
                object idsorkind03 = Conn.DO_READ_VALUE("uniconfig", null, "idsorkind03", null);
                object idsorkind04 = Conn.DO_READ_VALUE("uniconfig", null, "idsorkind04", null);
                object idsorkind05 = Conn.DO_READ_VALUE("uniconfig", null, "idsorkind05", null);

                SorKind[1] = idsorkind01;
                SorKind[2] = idsorkind02;
                SorKind[3] = idsorkind03;
                SorKind[4] = idsorkind04;
                SorKind[5] = idsorkind05;

            }
            if (SorKind[num] == DBNull.Value || SorKind[num] == null) return DBNull.Value;
            object id = Conn.DO_READ_VALUE("sorting",
                            QHS.AppAnd(QHS.CmpEq("idsorkind", SorKind[num]),
                                        QHS.CmpEq("sortcode", code)), "idsor");
            if (id == null) id = DBNull.Value;

            if (id == DBNull.Value) {
                show("Il codice " + code.ToString() + " per l'attributo " + num.ToString() + " non esiste.", "Errore");
            }
            return id;

        }

    }
}