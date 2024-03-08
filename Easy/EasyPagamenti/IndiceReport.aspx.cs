
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using HelpWeb;
//using funzioni_configurazione;

namespace EasyPagamenti {
    //menu - menulink - sub e le foglie: topline (primo figlio) , niente le altre
    public class MyMenuClass {
        string text = null;
        string classfun = null;
        List<MyMenuClass> submenu = new List<MyMenuClass>();
        string tag = null;
        bool canskip = false;
        public MyMenuClass(string text, string classfun, string tag, bool canskip) {
            this.text = text;
            this.classfun = classfun;
            this.tag = tag;
            this.canskip = canskip;
        }
        public MyMenuClass(string text, bool canskip) {
            this.text = text;
            this.canskip = canskip;
        }
        public MyMenuClass(string text) {
            this.text = text;
        }

        public MyMenuClass(string text, string classfun, string tag) {
            this.text = text;
            this.classfun = classfun;
            this.tag = tag;
        }

        public static void RegisterScript(Page P, Button B) {
            string ScriptString = "";
            ScriptString += "function dMF(classfun,tag){";
            ScriptString += "__doPostBack('_ctl0:CHP_PC:HwMenuButton',classfun+':'+tag);\r\n";
            ScriptString += "return true;\r\n";

            ScriptString += "}\r\n";

            string ScriptID = "dMF()";

            if (!P.ClientScript.IsClientScriptBlockRegistered(typeof(Page), ScriptID))
                P.ClientScript.RegisterClientScriptBlock(typeof(Page), ScriptID, ScriptString, true);
        }

        public void AddChild(MyMenuClass MenuItem) {
            submenu.Add(MenuItem);
        }
        public HtmlGenericControl GetControl() {
            return GetControl(0, true);
        }

        public void Optimize() {
            foreach (MyMenuClass C in submenu) C.Optimize();

            if (submenu.Count != 1) return;
            if (!((MyMenuClass)submenu[0]).canskip) return;

            submenu = ((MyMenuClass)submenu[0]).submenu;

        }

        HtmlGenericControl GetControl(int level, bool first) {
            HtmlGenericControl curr = GetCurr(level, first);
            HtmlGenericControl childs = GetChildren(level);
            if (curr == null) return childs;
            if (childs == null) return curr;
            curr.Controls.Add(childs);
            return curr;
        }


        HtmlGenericControl GetChildren(int level) {
            if (submenu.Count == 0) return null;
            HtmlGenericControl container = new HtmlGenericControl("ul");
            if (level == 0) {
                container.Attributes["class"] = "sm sm-blue";
                container.ID = "main-menu";
            }
            bool first = true;
            HtmlGenericControl last = null;
            foreach (MyMenuClass child in submenu) {
                HtmlGenericControl c = child.GetControl(level + 1, first);
                first = false;
                container.Controls.Add(c);
                last = c;
            }
            //if (last!=null) last.Attributes["class"] = "last";

            if (level == 0) {
                //HtmlGenericControl maindiv = new HtmlGenericControl("div");
                //maindiv.ID = "main-menu";
                //maindiv.Attributes["class"] = "sm sm-blue"; //
                //maindiv.Controls.Add(container);
                //return maindiv;
            }
            return container;
        }

        //menu - menulink - sub e le foglie: topline (primo figlio) , niente le altre
        HtmlGenericControl GetCurr(int level, bool first) {
            if (text == null) return null;
            HtmlGenericControl c = new HtmlGenericControl("li");

            HtmlGenericControl a = new HtmlGenericControl("a");
            c.Controls.Add(a);
            a.Attributes["href"] = "#";
            a.InnerText = text;
            if (classfun != null && tag != null)
                a.Attributes["onclick"] = "return dMF(\"" + classfun + "\",\"" + tag + "\");";


            if (submenu.Count > 0) {
                return c;
            }
            return c;
        }
    }

    /// <summary>
    /// Summary description for IndiceReport.
    /// </summary>
    public partial class IndiceReport :System.Web.UI.Page {


        string ButtonTag = null;
        protected void HwMenuButton_Click(object sender, EventArgs e) {
            if (ButtonTag == null) return;
            string tipo = ButtonTag.Substring(0, 1).ToLower();
            string tag = ButtonTag.Substring(2);
            if (tipo == "f") DoFunction(tag);
            //if (tipo == "e") DoExport(tag);
            //if (tipo == "r") DoReport(tag);
            if (tipo == "s") {
                if (tag == "disconnect") Disconnect();
                if (tag == "choosedepartment") ScegliDipartimentoMagazzino();
                if (tag == "changepwd") ChangePwd();
                //if (tag == "ingressomagazzino") StampaCheckIn();
            }

        }

        //attenzione
        void DoFunction(string tag) {
            string[] parts = tag.Split('.');
            if (parts.Length < 2) return;
            string meta = parts[0];
            string edittye = parts[1];
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            if (APS == null) {
                MetaPage.SessionTimeOut(this);
                return;
            }
            MetaData M = APS.Dispatcher.Get(meta);
            M.edit_type = edittye;
            if ((M.TableName == "showcase") && (M.edit_type == "defaultpagamenti")) {
                M.Name = "Cataloghi";
            }
            APS.CallPage(this, M, false);
        }

        protected void ChangePwd() {
            Response.Redirect("CambioPassword.aspx");
        }
        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument) {
            if (sourceControl == HwMenuButton) ButtonTag = eventArgument;
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }
    
        protected void Page_Load(object sender, System.EventArgs e) {
            //** attenzione manca la parte di autorizzazione
            //** 
            //** 
            MyMenuClass.RegisterScript(this, HwMenuButton);
            MyMenuClass myMenu = new MyMenuClass(null);
            //MyMenuClass menuTicket = new MyMenuClass("Ticket");
            //MyMenuClass menuSviluppo = new MyMenuClass("Sviluppo");
            //myMenu.AddChild(menuTicket);
            //myMenu.AddChild(menuSviluppo);

            //menuTicket.AddChild(new MyMenuClass("Ticket", "f", "ticket.default"));
            //menuSviluppo.AddChild(new MyMenuClass("Task", "f", "swprocess.default"));
            //menuSviluppo.AddChild(new MyMenuClass("Attività", "f", "swprocessdetail.default"));

            //btnRegistroRichiesteBuonoOrdine.Attributes.Add("onclick", "aprifin();");
            if ((Session["Cart"] != null)) {
                ApplicationState APS = ApplicationState.GetApplicationState(this);
                MetaData M = APS.Dispatcher.Get("webpayment");
                M.edit_type = "defaultpagamenti";
                APS.CallPage(this, M, false);
            }

            

            MyMenuClass mag = null;
            mag = new MyMenuClass("Accedi al portale dei pagamenti");
            //MyMenuClass m = new MyMenuClass("Cataloghi", "f", "showcase.defaultpagamenti");
            MyMenuClass m = new MyMenuClass("Cataloghi", "s", "choosedepartment");
            mag.AddChild(m);

            m = new MyMenuClass("Mie Prenotazioni", "f", "webpayment.defaultpagamenti");
            mag.AddChild(m);

            m = new MyMenuClass("Mie Prenotazioni(Bozze)", "f", "webpayment.defaultpagamentibozze");
            mag.AddChild(m);

            m = new MyMenuClass("Mie Prenotazioni(Pagate)", "f", "webpayment.defaultpagamentipagati");
            mag.AddChild(m);

			//MyMenuClass m = new MyMenuClass("Prodotti", "f", "showcase.defaultpagamenti");
			//myMenu.AddChild(m);
			myMenu.AddChild(mag);
            myMenu.AddChild(new MyMenuClass("Disconnetti", "s", "disconnect"));
            myMenu.AddChild(new MyMenuClass("Cambia Password", "s", "changepwd"));
            myMenu.Optimize();
            MenuPanel.Controls.Add(myMenu.GetControl());
            
        }

        protected void ScegliDipartimentoMagazzino() {
            Response.Redirect("sceglimagazzino.aspx");
        }

        private void RigaClick(object sender, EventArgs e) {
        }

        private void Disconnect() {
            ApplicationState Ap = ApplicationState.GetApplicationState(this);
            Ap.Conn.Close();
            Ap.Conn.Destroy();

            ApplicationState.ClearApplicationState(this);

            Response.Redirect(Session["SavedHomePage"].ToString());


        }

    }
}
