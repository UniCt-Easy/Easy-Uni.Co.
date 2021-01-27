
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace EasyWebReport{
    public partial class CambioRuolo : System.Web.UI.Page
    {
        QueryHelper QHS;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess Conn = GetVars.GetUserConn(Page);
            
            if (Conn==null) return;

            QHS = Conn.GetQueryHelper();
            string idcustomuser = Conn.GetSys("user").ToString();
            object currdate = Conn.GetSys("datacontabile");
            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            if (idcustomuser == "") return;
            string def_val= "";

            string f1 = QHS.AppAnd(QHS.CmpEq("U.idcustomuser", idcustomuser),
                QHS.NullOrLe("U.start", currdate), QHS.NullOrGe("U.stop", currdate));

            f1 = QHS.AppAnd(f1, QHS.CmpEq("F.ayear", Conn.GetSys("esercizio")));
            bool err=false;

            DataTable T = Conn.SQLRunner("select U.idflowchart, isnull(U.title,F.title) as title, " +
                   "U.ndetail from flowchartuser U join " +
                    " flowchart F on U.idflowchart=F.idflowchart where " + f1, true, -1);
            if (T == null) {
                err = true;                

                T = Conn.SQLRunner("select U.idflowchart, F.title, " +
                                   "U.ndetail from flowchartuser U join " +
                                    " flowchart F on U.idflowchart=F.idflowchart where " + f1, true, -1);
                
                T.PrimaryKey = new DataColumn[] { T.Columns["idflowchart"] };

                T.Columns.Add(new DataColumn("k",typeof(String)));
                foreach (DataRow R in T.Rows) {
                    R["k"] = R["idflowchart"].ToString() + "§" +
                                R["ndetail"].ToString() ;
                }                
            }
            else {
                err=false;
                T.Columns.Add(new DataColumn("k",typeof(String)));
                foreach (DataRow R in T.Rows) {
                    R["k"] = R["idflowchart"].ToString() + "§" +                                
                                R["ndetail"].ToString() ;
                }                
            }

            def_val = idflowchart.ToString() + "§" + ndetail.ToString();

            T.PrimaryKey = new DataColumn[] {T.Columns["k"]};
            if (T.Rows.Count == 0) return;

            if (!IsPostBack) {
                cmbruolo.DataSource = T;
                cmbruolo.DataTextField = "title";


                cmbruolo.DataValueField = "k";
            }
            cmbruolo.DataBind();

            if (!IsPostBack) {
                if (err) {

                    try {
                        if (T.Rows.Count > 0) cmbruolo.SelectedValue = def_val;
                    }
                    catch { }
                }
                else {

                    try {
                        if (T.Rows.Count > 0 && ndetail != null && ndetail != DBNull.Value) cmbruolo.SelectedValue = def_val;
                    }
                    catch { }
                }


            }

            

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndiceReport.aspx");
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            Easy_DataAccess Conn = GetVars.GetUserConn(Page);
            bool err = false;
            string idcustomuser = Conn.GetSys("idcustomuser") as string;
            object idflowchart = cmbruolo.SelectedValue;
            object ndetail = Conn.GetSys("ndetail");
            object currdate = Conn.GetSys("datacontabile");

            string sel = cmbruolo.SelectedValue;
            if (sel == "" || sel == null) return;

            if (sel.IndexOf("§") < 0) return;
            string []ss = sel.Split('§');
            ndetail = CfgFn.GetNoNullInt32(ss[1]);
            idflowchart = ss[0];
            string filter = QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                    QHS.CmpEq("idflowchart", idflowchart),
                                    QHS.CmpEq("ndetail", ndetail));
            object title= Conn.DO_READ_VALUE("flowchartuser",filter,"title");
            if (title == DBNull.Value)
                title = Conn.DO_READ_VALUE("flowchart", QHS.CmpEq("idflowchart", idflowchart), "title");
                       
            Conn.RecalcUserEnvironment(idflowchart, ndetail);
            Conn.ReadAllGroupOperations();

            Session["SavedFlowChart"] = null;
            if (title!=null) {
                 Session["SavedFlowChart"] = title;
            }

            Response.Redirect("IndiceReport.aspx");
        }
        

       
}
}
