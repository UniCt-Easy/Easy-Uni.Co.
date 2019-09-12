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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using funzioni_configurazione;

namespace EasyWebReport
{
    public partial class WebUsersManagement : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["DBSysConn"] == null && Session["DBUserConn"] == null)
            {
                customuserdata.Style.Add("display", "none");
                btnadd.Visible = false;
                btnchoose.Visible = false;
                btnclear.Visible = false;
                btndel.Visible = false;
                btndisconnect.Visible = false;
                btnread.Visible = false;
                btnshow.Visible = false;
                return;
            }
            FillVirtualUserData();
            FillCustomUserData();
            FillRegistryData();
            FillManagerData();
        }

        public void FillRegistryData()
        {
            string idregistryreference = Request.Form["txtidregistryreference"];

            if (idregistryreference == null || idregistryreference == "")
            {
                lblError.Text = "";
                return;
            }
            string filter;
            string[] arr = idregistryreference.Split('|');
            
            string idreg = arr[0];
            string idregref = arr[1];

            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();

            filter = QHS.AppAnd(QHS.CmpEq("idregistryreference", idregref),QHS.CmpEq("idreg",idreg));

            DataTable DT = Conn.RUN_SELECT("registryreference", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
            {
                lblError.Text = "Problema sul DB di sistema.";
                return;
            
            }

            txtlogin.Text = DT.Rows[0]["userweb"].ToString();
            txtidregistryreference.Text = "";
            return;
        }



        public void FillManagerData()
        {
            string idman = Request.Form["txtidman"];
            if (idman == null || idman == "")
            {
                lblError.Text = "";
                return;
            }
            string filter;
            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();

            filter = QHS.CmpEq("idman", idman);

            DataTable DT = Conn.RUN_SELECT("manager", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
            {
                lblError.Text = "Problema sul DB di sistema.";
                return;

            }

            txtlogin.Text = DT.Rows[0]["userweb"].ToString();
            txtidman.Text = "";


            return;
        }

        public void FillVirtualUserData()
        {
            string idvirtualuser = Request.Form["txtidvirtualuser"];
            if (idvirtualuser == null || idvirtualuser == "")
            {
                lblError.Text = "";
                return;
            }
            string filter;
            DataAccess sys = GetSystemDB();
            QueryHelper QHS;
            QHS = sys.GetQueryHelper();

            filter = QHS.CmpEq("idvirtualuser", idvirtualuser);
            DataTable DT = sys.RUN_SELECT("virtualuser", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
            {
                lblError.Text = "Problema sul DB di sistema.";
                return;
            }
            FillForm(DT.Rows[0]);

            switch (userkind.SelectedValue)
            {
                case "1":
                    btnrespforn.Text = "Seleziona Responsabile";
                    btnrespforn.Visible = true;
                    break;
                case "2":
                    btnrespforn.Text = "Seleziona Fornitore";
                    btnrespforn.Visible = true;
                    break;
                case "3":
                    btnrespforn.Visible = false;
                    break;
                case "4":
                    btnrespforn.Visible = false;
                    break;
                case "5":
                    btnrespforn.Visible = false;
                    break;
            }

            txtidvirtualuser.Text = "";
            return;
        
        }
        void HideDataControls() {
            userkind.Visible = false;
            txtlogin.ReadOnly = true;
            //txtcoddip.ReadOnly = true;
            txtcustuser.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtCognome.ReadOnly = true;
            txtCf.ReadOnly = true;
            btnchoose.Visible = true;
            btndisconnect.Visible = false;
            btnshow.Visible = false;
            btnread.Visible = false;
            btndel.Visible = false;
            btnchoose.Visible = false;
            btnadd.Visible = false;

        }
        public void FillCustomUserData()
        {
            string idcustomuser = Request.Form["txtidcustomuser"];
            if (idcustomuser == null || idcustomuser == "")
            {
                lblError.Text = "";
                return;
            }
            string filter;
            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();

            filter = QHS.CmpEq("idcustomuser", idcustomuser);
            DataTable DT = Conn.RUN_SELECT("customuser", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
            {
                lblError.Text = "Problema sul DB di sistema.";
                return;
            }

            txtcustuser.Text = DT.Rows[0]["idcustomuser"].ToString();
            if (Request.Form["userkind"].ToString() == "3")
            {
                txtlogin.Text = DT.Rows[0]["username"].ToString();
            }


            txtidcustomuser.Text = "";



        }

        public bool CustomUserExists(string customuser)
        {
            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            QueryHelper QHC = Conn.GetQueryHelper();
            string filter = QHC.CmpEq("idcustomuser", customuser);

            DataTable DT = Conn.RUN_SELECT("customuser", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0) return false;
            if (DT.Rows.Count==1) return true;
            return false;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            
            lblError.Text = "";


            if (Request.Form["txtcognome"].ToString() == "")
            {
                lblError.Text = "Inserire il cognome<br/>";
                return; ;
            }

            if (Request.Form["txtnome"].ToString()== "")
            {
                lblError.Text = "Inserire il nome<br/>";
                return;
            }
            if (Request.Form["txtcustuser"] == "")
            {
                lblError.Text = "Inserire l'utente applicativo<br/>";
                return;
            }

            if (Request.Form["txtlogin"].ToString() == "")
            {
                lblError.Text = "Inserire la login<br/>";
                return;
            }

            if (Request.Form["txtEmail"].ToString() == "") {
                lblError.Text = "Inserire l'email<br/>";
                return;
            }

            DataAccess sys = GetSystemDB();

            DataSet DS=new vistaForm_virtualuser();
            string login = Request.Form["txtlogin"].ToString();
            string cognome = Request.Form["txtCognome"].ToString();
            string nome=Request.Form["txtNome"].ToString();
            string cf=Request.Form["txtCf"].ToString();
            string coddip = Request.Form["txtcoddip"].ToString();
            string custuser = Request.Form["txtcustuser"].ToString();
            string email = Request.Form["txtEmail"].ToString();
            string typeofuser=Request.Form["userkind"].ToString();
            QueryHelper QHS=sys.GetQueryHelper();
            if (custuser == "")
            {
                lblError.Text = "Utente Applicativo non specificato";
                return;
            }

            if (!CustomUserExists(custuser))
            {
                lblError.Text = "L'Utente Applicativo specificato è inesistente";
                return;
            }
            
            string filter=QHS.AppAnd(QHS.CmpEq("userkind",typeofuser),QHS.CmpEq("codicedipartimento",coddip),
                QHS.CmpEq("username",login));
            int numberofrecs = sys.RUN_SELECT_COUNT("virtualuser", filter, false);
            
            string query="SELECT MAX(idvirtualuser) as maxvalue from virtualuser";
            DataTable RES=sys.SQLRunner(query);
            int newkeynum=CfgFn.GetNoNullInt32(RES.Rows[0]["maxvalue"]) + 1 ;

            DataTable T=DS.Tables["virtualuser"];
            DataRow DR;
            if (numberofrecs == 0)
            {
                DR = T.NewRow();
                DR["idvirtualuser"] = newkeynum;
            }
            else
            {
                sys.RUN_SELECT_INTO_TABLE(T,null, filter, null, false);
                DR = T.Rows[0];
            }
            DR["username"]=login;
            DR["codicedipartimento"]=coddip;
            DR["userkind"]=typeofuser;
            DR["sys_user"]=custuser;
            DR["surname"]=cognome;
            DR["forename"]=nome;
            DR["cf"]=cf;
            DR["email"] = email;
            if(numberofrecs==0) T.Rows.Add(DR);

            PostData PD=new PostData();
            PD.InitClass(DS,sys);
			ProcedureMessageCollection MCOLL =  PD.DO_POST_SERVICE();

            if (!MCOLL.CanIgnore){
				lblError.Text="Delle regole di sicurezza impediscono l'update del db di sistema!!";
				return;
			}
            MCOLL = PD.DO_POST_SERVICE();
			if (!MCOLL.CanIgnore){
				lblError.Text="Delle regole di sicurezza hanno impedito l'update del db di sistema!!";
				return;
			}
			if(numberofrecs==0)
                lblError.Text="<p style=\"color: blue;text-align: center;\">Utente aggiunto.</p>";
            else
                lblError.Text = "<p style=\"color: blue;text-align: center;\">Utente aggiornato.</p>";

        }
        protected void btnread_Click(object sender, EventArgs e)
        {
            if ((Session["DBSysConn"] == null || Session["DBUserConn"] == null))
            {
                //lblError.Text = "Connessione non effettuata";
                return;
            }

            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            DataAccess sys = GetSystemDB();
            string filter = BuildFilter();

            if (filter == "")
            {
                lblError.Text = "Nessun criterio di ricerca inserito";
                return;
            }

            DataTable T = sys.RUN_SELECT("virtualuser", "*", null, filter, null, false);
            if (T == null || T.Rows.Count == 0)
            {
                lblError.Text = "Nessun utente soddisfa i criteri di ricerca";
                return;
            }

            if (T.Rows.Count == 1)
            {
                DataRow DR = T.Rows[0];
                FillForm(DR);
                lblError.Text = "";
                return;
            }

            if (T.Rows.Count > 1)
            {
                lblError.Text = "<p style=\"color: blue;\">Più di un utente soddisfa i criteri specificati. Selezionarne uno dall'elenco.";
                RenderAllUsersTable(T);
                return;
            }
        }

        public void FillForm(DataRow DR)
        {
            if (DR == null) return;
            if (DR["username"].ToString() != "")
                txtlogin.Text = DR["username"].ToString();
            if (DR["surname"].ToString() != "")
                txtCognome.Text = DR["surname"].ToString();
            if (DR["forename"].ToString() != "")
                txtNome.Text = DR["forename"].ToString();
            if (DR["cf"].ToString() != "")
                txtCf.Text = DR["cf"].ToString();
            if (DR["sys_user"].ToString() != "")
                txtcustuser.Text = DR["sys_user"].ToString();
            if (DR["codicedipartimento"].ToString() != "")
                txtcoddip.Text = DR["codicedipartimento"].ToString();
            if (DR["userkind"].ToString() != "")
                userkind.SelectedValue = DR["userkind"].ToString();
            if (DR["email"].ToString() != "")
                txtEmail.Text = DR["email"].ToString();
            return;
        }


        public string BuildFilter()
        {

            DataAccess sys = GetSystemDB();
            QueryHelper QHS = sys.GetQueryHelper();

            string filter="";
            string login = Request.Form["txtlogin"].ToString();
            string cognome = Request.Form["txtCognome"].ToString();
            string nome = Request.Form["txtNome"].ToString();
            string cf = Request.Form["txtCf"].ToString();
            string coddip = Request.Form["txtcoddip"].ToString();
            string custuser = Request.Form["txtcustuser"].ToString();
            string userkind = Request.Form["userkind"].ToString();
            string email = Request.Form["txtEmail"].ToString();

            if (login != "")
            {
                filter = QHS.Like("username", "%"+login+"%");
            }

            if (cognome != "")
            { 
                filter=QHS.AppAnd(filter,QHS.Like("surname", "%"+cognome+"%"));
            }

            if (nome != "")
            {
                filter = QHS.AppAnd(filter, QHS.Like("forename", "%" + nome + "%"));
            }

            if (email != "") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("email",  email));
            }

            if (cf != "")
            {
                filter = QHS.AppAnd(filter, QHS.Like("cf", "%" + cf + "%"));
            }

            if (coddip != "")
            {
                filter = QHS.AppAnd(filter, QHS.CmpEq("codicedipartimento", coddip));
            }

            if (custuser != "")
            {
                filter = QHS.AppAnd(filter, QHS.CmpEq("sys_user", custuser));
            }

            if (userkind != "")
            {
                filter = QHS.AppAnd(filter, QHS.CmpEq("userkind", userkind));
            }

            return filter;
        }



        protected void btndel_Click(object sender, EventArgs e)
        {
            if (((SystemDBIsConnected() == false) || Session["DBUserConn"] == null))
            {
                return;
            }

            DataAccess sys = GetSystemDB();
            QueryHelper QHS = sys.GetQueryHelper();
            DataSet DS=new vistaForm_virtualuser();
            DataTable T=DS.Tables["virtualuser"];
            string login = Request.Form["txtlogin"].ToString();
            string cognome = Request.Form["txtCognome"].ToString();
            string nome = Request.Form["txtNome"].ToString();
            string cf = Request.Form["txtCf"].ToString();
            string coddip = Request.Form["txtcoddip"].ToString();
            string custuser = Request.Form["txtcustuser"].ToString();
            string userkind = Request.Form["userkind"].ToString();



            string filter = QHS.AppAnd(QHS.CmpEq("userkind", userkind), QHS.CmpEq("codicedipartimento", coddip),
                QHS.CmpEq("username", login));

            sys.RUN_SELECT_INTO_TABLE(T, null, filter, null, false);

            if (T == null || T.Rows.Count == 0)
            {
                lblError.Text = "Record inesistente";
                return;
            }

            DataRow DR = T.Rows[0];
            DR.Delete();

            PostData PD = new PostData();
            PD.InitClass(DS, sys);
        
            ProcedureMessageCollection MCOLL = PD.DO_POST_SERVICE();
            if (!MCOLL.CanIgnore)
            {
                lblError.Text = "Delle regole di sicurezza hanno impedito l'update del db di sistema!!";
                return;
            }
            PD.DO_POST_SERVICE();
            lblError.Text = "<p style=\"color: blue;\">Utente '"+login+ "' Eliminato.</p>";
            EmptyForm(false);

        }

        void DisconnectSystemDB() {
            DataAccess D = GetSystemDB();
            D.Close();
            //D.Destroy();
            Session["DBSysConn"] = null;
        }
        bool SystemDBIsConnected() {
            return (Session["DBSysConn"] != null);
        }
        DataAccess GetSystemDB() {
            return Session["DBSysConn"] as DataAccess;
        }
        bool ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile)
        {
            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);

            
            if (codice.Trim().Length == 0)
            {
                lblError.Text = "Non è stato selezionato alcun dipartimento";
                return false;
            }
            
            if (user == "")
            {
                lblError.Text = "Nessun nome utente specificato";
                return false;
            }

            if (pwd == "")
            {
                lblError.Text = "Nessuna password specificata";
                return false;
            }


            Session["DBSysConn"] = Conn;
            //Attenzione: leggere da XML IP del server e NomeDB
            //Inserire da codice NomeUtente e Password
            
            
            string filterdip = "(codicedipartimento=" + QueryCreator.quotedstrvalue(codice, true) + ")";
            DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0))
            {
                //Dati non corretti
                lblError.Text = "Il codice inserito non è corretto.";
                return false;
            }
            if (CodDip.Rows.Count > 1)
            {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                lblError.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                return false;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            Session["Dipartimento"] = myDr["Dipartimento"].ToString();
            

            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, user, pwd, datacontabile, out err);
            if (UsrConn == null)
            {
                err = "Connessione per l'utente '" + user + "' rifiutata. Controllare Nome Utente e/o Password";
                string err2 = "Connessione al db del dipartimento " + codice +
                    " non riuscita. <br/>" + err;
                lblError.Text = err2;
                return false;
            }
            Session["DBUserConn"] = UsrConn;
            return true;
        }



        protected void btnshow_Click(object sender, EventArgs e)
        {
            if ((SystemDBIsConnected()==false) || Session["DBUserConn"] == null)
            {
                //lblError.Text = "Connessione non effettuata";
                return;
            }

            DataAccess sys = GetSystemDB();
            QueryHelper QHS=sys.GetQueryHelper();

            if(txtcoddip.Text.ToString()=="")
            {
                lblError.Text="E' necessario specificare il codice dipartimento";
                return;
            }

            string filter;
            filter=QHS.CmpEq("codicedipartimento",txtcoddip.Text.ToString());
            //DataTable DT = sys.SQLRunner(Query);
            DataTable DT = sys.RUN_SELECT("virtualuser", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
            {
                lblError.Text = "Nessun utente presente";
                return;
            
            }
            lblError.Text = "<p style=\"color: blue;\">Selezionare un utente dall'elenco</p>";
            RenderAllUsersTable(DT);
        }

        public void EmptyForm(bool all) {
            if (all) {
                txtdbusername.Text = "";
                txtdbpasswd.Text = "";
                txtcoddip.Text = "";
            }

            txtCf.Text = "";
            txtCognome.Text = "";
            txtcustuser.Text = "";
            txtlogin.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            //lblError.Text = "";

        }

        public void RenderAllUsersTable(DataTable DT)
        {
            list.Style.Add("left", "20%");
            list.Style.Add("top", "25%");
            

            Table T = new Table();
            T.Style.Add("width","100%");
            T.Style.Add("border","1px solid black");
            T.Style.Add("font-face", "Arial, helvetica");
            T.Style.Add("font-size", "13px");
            T.Style.Add("background-color", "white");
            TableRow TR;

            TR=new TableRow();
            TR.Style.Add("background-color", "#777777");
            TR.Style.Add("color", "#white");

            TableCell TC = new TableCell();
            TC.Text = "Codice Dipartimento";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Tipologia Utente";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Login";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Utente Applicativo";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Cognome";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Nome";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Codice Fiscale";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            T.Rows.Add(TR);

            int count = 0;
            foreach (DataRow DR in DT.Rows)
            {
                TableRow DTR = new TableRow();
                DTR.Style.Add("color","black");
                DTR.Style.Add("cursor", "hand");


                if (count % 2 == 0)
                    DTR.Style.Add("background-color", "#eaeaea");
                else
                    DTR.Style.Add("background-color", "white");
                DTR.Attributes.Add("onclick","submitclick('"+DR["idvirtualuser"]+"','virtualuser')");

                TableCell DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["codicedipartimento"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                switch (DR["userkind"].ToString())
                {
                    case "1":
                        DTC.Text = "Responsabile";
                        break;
                    case "2":
                        DTC.Text = "Fornitore";
                        break;
                    case "3":
                        DTC.Text = "Utente Applicativo";
                        break;
                    case "4":
                        DTC.Text = "Utente LDAP";
                        break;
                    case "5":
                        DTC.Text = "Utente SSO";
                        break;
                }
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["username"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["sys_user"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["surname"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["forename"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["cf"].ToString();
                DTR.Cells.Add(DTC);

                T.Rows.Add(DTR);
                count++;
            }

            TableRow TFR = new TableRow();
            TFR.Style.Add("background-color", "#aaaaaa");
            TableCell TFC = new TableCell();
            T.Rows.Add(TFR);
            TFC.ColumnSpan = 7;
            TFC.Text = "<center><input type=\"button\" onclick=\"submitclick();\" value=\"Chiudi\"></center>";
            TFR.Cells.Add(TFC);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Style.Add("background-color", "Blue");
            div.Style.Add("width", "100%");
            div.Style.Add("color", "white");
            div.Style.Add("font-weight", "bold");
            div.Style.Add("font-size", "12px");
            div.Style.Add("text-align", "center");
            div.InnerText = "Utenti";

            listplaceholder.Controls.Add(div);
            listplaceholder.Controls.Add(T);
        
        }


        public void RenderRegistryTable(DataTable DT)
        {
            list.Style.Add("left", "45%");
            list.Style.Add("top", "25%");


            Table T = new Table();
            T.Style.Add("width", "100%");
            T.Style.Add("border", "1px solid black");
            T.Style.Add("font-face", "Arial, helvetica");
            T.Style.Add("font-size", "13px");
            T.Style.Add("background-color", "white");
            TableRow TR;

            TR = new TableRow();
            TR.Style.Add("background-color", "#777777");
            TR.Style.Add("color", "#white");

            TableCell TC = new TableCell();
            TC.Text = "Anagrafica";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Riferimento";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Login";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            T.Rows.Add(TR);

            int count = 0;
            foreach (DataRow DR in DT.Rows)
            {
                TableRow DTR = new TableRow();
                DTR.Style.Add("color", "black");
                DTR.Style.Add("cursor", "hand");


                if (count % 2 == 0)
                    DTR.Style.Add("background-color", "#eaeaea");
                else
                    DTR.Style.Add("background-color", "white");
                DTR.Attributes.Add("onclick", "submitclick('" + DR["idreg"] + "|" + DR["idregistryreference"] + "','registryreference')");

                TableCell DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["Anagrafica"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["Riferimento"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["Login"].ToString();
                DTR.Cells.Add(DTC);

                T.Rows.Add(DTR);
                count++;
            }

            TableRow TFR = new TableRow();
            TFR.Style.Add("background-color", "#aaaaaa");
            TableCell TFC = new TableCell();
            T.Rows.Add(TFR);
            TFC.ColumnSpan = 3;
            TFC.Text = "<center><input type=\"button\" onclick=\"submitclick();\" value=\"Chiudi\"></center>";
            TFR.Cells.Add(TFC);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Style.Add("background-color", "Blue");
            div.Style.Add("width", "100%");
            div.Style.Add("color", "white");
            div.Style.Add("font-weight", "bold");
            div.Style.Add("font-size", "12px");
            div.Style.Add("text-align", "center");
            div.InnerText = "Fornitori";

            listplaceholder.Controls.Add(div);
            listplaceholder.Controls.Add(T);
 
        
        }

        public void RenderManagersTable(DataTable DT)
        {

            list.Style.Add("left", "45%");
            list.Style.Add("top", "25%");


            Table T = new Table();
            T.Style.Add("width", "100%");
            T.Style.Add("border", "1px solid black");
            T.Style.Add("font-face", "Arial, helvetica");
            T.Style.Add("font-size", "13px");
            T.Style.Add("background-color", "white");
            TableRow TR;

            TR = new TableRow();
            TR.Style.Add("background-color", "#777777");
            TR.Style.Add("color", "#white");

            TableCell TC = new TableCell();
            TC.Text = "Responsabile";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Login";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            T.Rows.Add(TR);

            int count = 0;
            foreach (DataRow DR in DT.Rows)
            {
                TableRow DTR = new TableRow();
                DTR.Style.Add("color", "black");
                DTR.Style.Add("cursor", "hand");


                if (count % 2 == 0)
                    DTR.Style.Add("background-color", "#eaeaea");
                else
                    DTR.Style.Add("background-color", "white");
                DTR.Attributes.Add("onclick", "submitclick('" + DR["idman"] + "','manager')");

                TableCell DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["title"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["userweb"].ToString();
                DTR.Cells.Add(DTC);

                T.Rows.Add(DTR);
                count++;
            }

            TableRow TFR = new TableRow();
            TFR.Style.Add("background-color", "#aaaaaa");
            TableCell TFC = new TableCell();
            T.Rows.Add(TFR);
            TFC.ColumnSpan = 2;
            TFC.Text = "<center><input type=\"button\" onclick=\"submitclick();\" value=\"Chiudi\"></center>";
            TFR.Cells.Add(TFC);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Style.Add("background-color", "Blue");
            div.Style.Add("width", "100%");
            div.Style.Add("color", "white");
            div.Style.Add("font-weight", "bold");
            div.Style.Add("font-size", "12px");
            div.Style.Add("text-align", "center");
            div.InnerText = "Responsabili";

            listplaceholder.Controls.Add(div);
            listplaceholder.Controls.Add(T);
        
        
        }

        public void RenderCustomUsersTable(DataTable DT)
        {
            Table T = new Table();
            T.Style.Add("width", "100%");
            T.Style.Add("border", "1px solid black");
            T.Style.Add("font-face", "Arial, helvetica");
            T.Style.Add("font-size", "13px");
            T.Style.Add("background-color", "white");
            TableRow TR;

            list.Style.Add("left", "45%");
            list.Style.Add("top", "25%");

            TR = new TableRow();
            TR.Style.Add("background-color", "#777777");
            TR.Style.Add("color", "#white");

            TableCell TC = new TableCell();
            TC.Text = "Utente Applicativo";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            TC = new TableCell();
            TC.Text = "Login";
            TC.Style.Add("text-align", "center");
            TC.Style.Add("font-weight", "bold");
            TR.Cells.Add(TC);

            T.Rows.Add(TR);

            int count = 0;
            foreach (DataRow DR in DT.Rows)
            {
                TableRow DTR = new TableRow();
                DTR.Style.Add("color", "black");
                DTR.Style.Add("cursor", "hand");


                if (count % 2 == 0)
                    DTR.Style.Add("background-color", "#eaeaea");
                else
                    DTR.Style.Add("background-color", "white");
                DTR.Attributes.Add("onclick", "submitclick('" + DR["idcustomuser"] + "','customuser')");

                TableCell DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["idcustomuser"].ToString();
                DTR.Cells.Add(DTC);

                DTC = new TableCell();
                DTC.Style.Add("text-align", "left");
                DTC.Text = DR["username"].ToString();
                DTR.Cells.Add(DTC);

                T.Rows.Add(DTR);
                count++;
            }

            TableRow TFR = new TableRow();
            TFR.Style.Add("background-color", "#aaaaaa");
            TableCell TFC = new TableCell();
            T.Rows.Add(TFR);
            TFC.ColumnSpan = 2;
            TFC.Text = "<center><input type=\"button\" onclick=\"submitclick();\" value=\"Chiudi\"></center>";
            TFR.Cells.Add(TFC);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Style.Add("background-color", "Blue");
            div.Style.Add("width", "100%");
            div.Style.Add("color", "white");
            div.Style.Add("font-weight", "bold");
            div.Style.Add("font-size", "12px");
            div.Style.Add("text-align", "center");
            div.InnerText = "Utenti Applicativi";

            listplaceholder.Controls.Add(div);

            listplaceholder.Controls.Add(T);
        
        
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            EmptyForm(false);
            lblError.Text = "";
        }
        protected void btndisconnect_Click(object sender, EventArgs e)
        {
            
            DisconnectSystemDB();
            DataAccess Conn = Session["DBUserConn"] as DataAccess;
            Conn.Close();
            Conn.Destroy();
            Session["DBUserConn"] = null;
            EmptyForm(true);
            lblError.Text = "Connessione non effettuata";
            lbldbstatus.Text = "";
            btnadd.Visible = false;
            btnchoose.Visible = false;
            btnclear.Visible = false;
            btndel.Visible = false;
            btndisconnect.Visible = false;
            btnread.Visible = false;
            btnshow.Visible = false;
            btnConnetti.Visible = true;
            connectiondata.Style.Add("display", "block");
            customuserdata.Style.Add("display", "none");

            return;
        }
        protected void btnchoose_Click(object sender, EventArgs e)
        {
            if ((SystemDBIsConnected()==false) || Session["DBUserConn"] == null)
            {
                //lblError.Text = "Connessione non effettuata";
                return;
            }


            DataAccess Conn = (DataAccess)Session["DBUserConn"];

            DataTable T = Conn.RUN_SELECT("customuser", "idcustomuser,username", "idcustomuser asc, username asc", null, null, false);

            if (T == null || T.Rows.Count == 0) return;

            RenderCustomUsersTable(T);

        }
  
        protected void btnConnetti_Click(object sender, EventArgs e) {
            if (ConnectToDepartment(txtcoddip.Text, txtdbusername.Text, txtdbpasswd.Text, DateTime.Now))
            {
                connectiondata.Style.Add("display", "none");
                customuserdata.Style.Add("display", "block");

                btnadd.Visible = true;
                btnchoose.Visible = true;
                btnclear.Visible = true;
                btndel.Visible = true;
                btndisconnect.Visible = true;
                btnread.Visible = true;
                btnshow.Visible = true;
                btnConnetti.Visible = false;

                lbldbstatus.Text = "Connesso al DB - Codice Dipartimento: " + txtcoddip.Text;
                lblError.Text = "";          
            }

        }

        protected void userkind_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (userkind.SelectedValue)
            { 
                case "1":
                    btnrespforn.Text = "Seleziona Responsabile";
                    btnrespforn.Visible = true;
                    break;
                case "2":
                    btnrespforn.Text = "Seleziona Fornitore";
                    btnrespforn.Visible = true;
                    break;
                case "3":
                    btnrespforn.Visible = false;
                    break;
                case "4":
                    btnrespforn.Visible = false;
                    break;
                case "5":
                    btnrespforn.Visible = false;
                    break;
            }

        }
        protected void btnrespforn_Click(object sender, EventArgs e)
        {
            DataAccess Conn = (DataAccess)Session["DBUserConn"];
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            string filter;

            if (userkind.SelectedValue == "1")
            {
                // Responsabili
                
                filter=QHS.AppAnd(QHS.CmpEq("active","S"),QHS.IsNotNull("userweb"),QHS.CmpNe("userweb",""));
                DataTable DT = Conn.RUN_SELECT("manager", "idman,title,userweb", "title asc", filter, null, false);
                if (DT == null || DT.Rows.Count == 0) return;
                RenderManagersTable(DT);
                

                
            
            }
            if (userkind.SelectedValue == "2")
            {
                // Fornitori


                string query = "select registryreference.idregistryreference as idregistryreference, registry.idreg as idreg,registry.title as Anagrafica, registryreference.referencename as Riferimento, registryreference.userweb as Login ";
                query+=" from registry join registryreference on (registry.idreg=registryreference.idreg) where registry.active='S' ";
                query+=" and userweb is not null and userweb <>''";

                DataTable DT = Conn.SQLRunner(query);
                if (DT == null || DT.Rows.Count == 0) return;

                RenderRegistryTable(DT);

            }
        }
}
}