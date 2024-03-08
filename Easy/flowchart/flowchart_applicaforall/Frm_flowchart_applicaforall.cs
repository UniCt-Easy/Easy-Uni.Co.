
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace flowchart_applicaforall{
    public partial class Frm_flowchart_applicaforall : MetaDataForm {
        MetaData Meta;
        Easy_DataAccess MyDataAccess;
        public Frm_flowchart_applicaforall() {
            InitializeComponent();
            txtpassword.PasswordChar = '*';
        }

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
        }

        public void MetaData_AfterActivation(){
            if (this.Text.EndsWith("(Ricerca)"))
            {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        public void MetaData_AfterClear(){
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        private void btnApplica_Click(object sender, EventArgs e) {
            string error="";
            string dettaglio="";
            DataTable Tdbdepartment = Meta.Conn.RUN_SELECT("dbdepartment", "iddbdepartment,description", null, null, null, true);
            foreach (DataRow dip in Tdbdepartment.Rows) {
                MyDataAccess = Easy_DataAccess.getEasyDataAccess("DSN", Meta.GetSys("server").ToString(), Meta.GetSys("database").ToString(),
                     Meta.GetSys("user").ToString(), txtpassword.Text.Trim(), null,dip["iddbdepartment"].ToString(), (int)Meta.GetSys("esercizio"), 
                     (DateTime)Meta.GetSys("datacontabile"),out error,out dettaglio);
                if (MyDataAccess == null){
                    show(error + "\n"+ dettaglio, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
                if (!MyDataAccess.Open()){
                    error = "Non è stato possibile effettuare il collegamento al dipartimento" + dip["iddbdepartment"].ToString();
                    dettaglio = MyDataAccess.LastError;
                    show(error + "\n" + dettaglio, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                string currDip = "\nid: "+dip["iddbdepartment"].ToString() + " \nNome:"+dip["description"].ToString();
                doApplica(MyDataAccess, currDip);
                MyDataAccess.Destroy();
            }

            show(this, "Fine operazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private bool doApplica(Easy_DataAccess CurrDataAccess, string CurrDip)  {
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            object idcustomgroup="ORGANIGRAMMA";
            string filterallexistent = QHS.CmpEq("idgroup", idcustomgroup);
            string deletecustomgroupoperation = "delete from customgroupoperation where " + filterallexistent;
            CurrDataAccess.SQLRunner(deletecustomgroupoperation,false);
            string insertcustomgroupoperation =
                "insert into customgroupoperation (idgroup,operation,tablename,allowcondition,denycondition," +
                        "defaultisdeny,ct,cu,lt,lu) " +
                "select idcustomgroup,operation,tablename,allowcondition,denycondition,defaultisdeny," +
                        "getdate(),'Software and More',getdate(),'Software and More' from securitycondition ";
            CurrDataAccess.SQLRunner(insertcustomgroupoperation, false,300);

            string deleteuserenvironment =
                "delete from userenvironment where " +
                " idcustomuser in (select idcustomuser from customusergroup where " + QHS.CmpEq("idcustomgroup", idcustomgroup) + ") " +
                " AND variablename in (select variablename from securityvar)";
            CurrDataAccess.SQLRunner(deleteuserenvironment, false,300);
            string insertuserenvironment =
                "insert into userenvironment (idcustomuser,variablename,value,flagadmin,kind,lt,lu) " +
                " select U.idcustomuser,S.variablename,S.value,'N',S.kind,getdate(),'Software and More' from securityvar S " +
                       " cross join customusergroup U where " + QHS.CmpEq("U.idcustomgroup", idcustomgroup);
            CurrDataAccess.SQLRunner(insertuserenvironment, false,300);
            
            //show(this, "Sicurezza applicata con successo!");

            //show(this, "Errore nel salvataggio della sicurezza!", "Errore");


            return true;
        }
    }
}
