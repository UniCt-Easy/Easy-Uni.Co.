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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace lcardmail{
    public class lcardSendMail{
        public lcardSendMail(){
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Manda una mail alla segreteria amministrativa della richiesta di ricarica
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="lcardvar"></param>
        /// 

        public static void SendMails(DataAccess Conn, DataRow lcardvar){
            DataRow ConfigMail = GetSegreteriaMail(Conn);
            string emailSegreteria = "";
            if (ConfigMail != null){
                if (ConfigMail["email"].ToString() != ""){
                    if (emailSegreteria != "") emailSegreteria += ",";
                    emailSegreteria += ConfigMail["email"].ToString();
                }
            }
            if (emailSegreteria != "") SendMailSegreteria(Conn, lcardvar, emailSegreteria, false);

        }

        public static string WebSendMails(DataAccess Conn, DataRow lcardvar){
            string errormsg = "";
            DataRow ConfigMail = GetSegreteriaMail(Conn);
            string emailSegreteria = "";

            if (ConfigMail != null){
                if (ConfigMail["finvar_warnmail"].ToString() != ""){
                    emailSegreteria = ConfigMail["finvar_warnmail"].ToString();
                }
            }
            if (emailSegreteria != "") errormsg = SendMailSegreteria(Conn, lcardvar, emailSegreteria, true);

            return errormsg;
        }

        static string GetNomeResponsabile(DataAccess Conn, object idlcard){
            return Conn.DO_READ_VALUE("lcardvarview", Conn.GetQueryHelper().CmpEq("idlcard", idlcard), "manager").ToString();
        }

        public static string GetDipartimento(DataAccess Conn){
            QueryHelper QHS = Conn.GetQueryHelper();
            object X = Conn.DO_READ_VALUE("generalreportparameter",
                                QHS.CmpEq("idparam", "DenominazioneDipartimento"), "paramvalue");
            return X.ToString();
        }

        public static string SendMailSegreteria(DataAccess Conn, DataRow lcardvar, string emailaddress, bool web_message){
            
            string errormsg = "";
            string msg = "Per la Card n∞ " + lcardvar["idlcard"] + " intestata a " + GetNomeResponsabile(Conn, lcardvar["idlcard"])+ ", ";
            msg += "Ë stata effettuata una richiesta di importo pari a " + CfgFn.GetNoNullDecimal(lcardvar["amount"]).ToString("c") + ".\r\n";

            msg = "Da: " + GetDipartimento(Conn) + "\r\n" + msg;
            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.To = emailaddress;
            SM.Subject = "Richiesta ricarica Card";
            SM.MessageBody = msg;
            SM.Conn = Conn;

            if ((!SM.Send()) && (SM.ErrorMessage.Trim() != "")){
                if (!web_message)
                    QueryCreator.ShowError(null, SM.ErrorMessage, null);
                else errormsg = SM.ErrorMessage.Trim();
            }
            return errormsg;
        }

        public static DataRow GetSegreteriaMail(DataAccess Conn){
            QueryHelper QHS = Conn.GetQueryHelper();
            int esercizio = Convert.ToInt32(Conn.GetSys("esercizio"));
            string filtereserc= QHS.CmpEq("ayear",esercizio);
            string sql = "";
            sql = "select * from config " 
                + " where " + filtereserc ;


            DataTable ConfigMail = Conn.SQLRunner(sql, false);
            if (ConfigMail.Rows.Count == 0) return null;
            return ConfigMail.Rows[0];
        }


    }
}
