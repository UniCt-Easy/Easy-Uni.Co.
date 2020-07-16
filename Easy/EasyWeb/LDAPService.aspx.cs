/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace EasyWebReport {
    public partial class LDAPService : System.Web.UI.Page {
        DataAccess Conn;
        ldapauth ldpauth;
        protected void Page_Load(object sender, EventArgs e) {
            string S1 = this.Request.Params["x"]; //proviene da sp_exp_licenzauso
            this.Response.Clear();
            if (S1 == null || S1 == "") return;
            string error;
            Conn = GetVars.GetSystemDataAccess(this, out error);
            if (Conn == null) return;

            ldpauth = new ldapauth(Conn);
            if (!ldpauth.getconfig()) return;

            DoLDAP(S1);

        }


        void DoLDAP(string S1) {



            this.Response.Clear();
            //this.Response.Output.Write(S);
            Hashtable HH = DataAccess.GetHashFromString(S1);
            string E = "Errore";
            QueryHelper QHS = Conn.GetQueryHelper();

            


            try {
                //Elabora la Hashtable per la mail
                string user = HH["usr"] as string; 
                string pwd =  HH["pwd"] as string;
                string dep = HH["dep"] as string;


                ldapauth LA = new ldapauth(Conn);
                if (!LA.getconfig()) {
                    this.Response.Output.Write("Errore LA.getconfig: "+LA.ErrorMsg);
                    return;
                }
                if (!LA.Authenticate(user, pwd)) {
                    this.Response.Output.Write("Errore LA.Authenticate: "+LA.ErrorMsg+
                            "(servername="+LA.servername+"port="+LA.port.ToString()+"user="+user+",pwd="+pwd+")");
                    return ;
                }
                user = LA.user_decoded;

                string filter = QHS.AppAnd(QHS.CmpEq("username", user),
                    QHS.CmpEq("codicedipartimento", dep),
                    QHS.CmpEq("userkind", 4)
                    );
                // prelevare l'idflowchart e poi fare la connecttodepartment
                DataTable virtualuser = Conn.RUN_SELECT("virtualuser", "*", null, filter, null, false);
                if (virtualuser == null || virtualuser.Rows.Count == 0) {
                    this.Response.Output.Write("Errore: virtualuser not found (" + filter + ")");
                    Conn.Destroy();
                    return;
                }

                DataRow VU = virtualuser.Rows[0];




                string filterdip = QHS.CmpEq("codicedipartimento", dep);
                DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);
                if ((CodDip == null) || (CodDip.Rows.Count != 1)) {
                    Conn.Destroy();
                    return;
                }
                Hashtable Hresp = new Hashtable();
                Hresp["usr"] = GetVars.DecryptPassword(GetVars.ConvBytes(CodDip.Rows[0]["UserDB"]));
                Hresp["pwd"] = GetVars.DecryptPassword(GetVars.ConvBytes(CodDip.Rows[0]["PassDB"]));
                Hresp["vusr"] = VU["sys_user"].ToString();
                E = DataAccess.GetStringFromHashTable(Hresp);
            }
            catch (Exception EE){
                E = "Errore:"+QueryCreator.GetErrorString(EE);
            }
            Conn.Destroy();
            this.Response.Output.Write(E.ToString());
        }
    }
}