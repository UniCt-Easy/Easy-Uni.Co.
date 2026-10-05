/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace itinerationauthview_default
{
    public partial class Frm_itinerationauthview_default : MetaDataForm
    {
        public Frm_itinerationauthview_default()
        {
            InitializeComponent();
        }

        public void DoCancel()
        {
            // Imposta lo stato globale su "Annullata" (iditinerationstatus=7),
            // lo stato dell'approvazione su "N"
            // Aggiornare anche il campo "cancelreason" su itineration con il motivo della cancellazione
            ////rejectreason.Style.Remove("display");
            ////rejectreason.Style.Add("display", "none");
            ////rejectreason.Style.Remove("z-index");
            ////rejectreason.Style.Add("z-index", "11000");
            //GetImpersonatedAuthAgency();
            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
            DS.AcceptChanges();

            QHS = Conn.GetQueryHelper();

            string filter = "";
            filter = QHS.AppAnd(QHS.CmpEq("idauthagency", idauthagency), QHS.CmpEq("iditineration", iditineration));
            DataTable DTItinerationAuthAgency = Conn.RUN_SELECT("itinerationauthagency", "*", null, filter, null, false);
            if (DTItinerationAuthAgency == null || DTItinerationAuthAgency.Rows.Count == 0)
                return;
            DTItinerationAuthAgency.Rows[0]["flagstatus"] = "N";
            DTItinerationAuthAgency.setSkipSecurity();


            filter = QHS.CmpEq("iditineration", iditineration);
            DataTable DTItineration = Conn.CreateTableByName("itineration", "*");
            DTItineration.setSkipSecurity();
            Conn.RUN_SELECT_INTO_TABLE(DTItineration, null, filter, null, false);

            if (DTItineration == null || DTItineration.Rows.Count == 0)
                return;
            DTItineration.Rows[0]["iditinerationstatus"] = 7;
            if (txtrejectreason.Text != "")
                DTItineration.Rows[0]["webwarn"] = txtrejectreason.Text;
            if (txtAnnotazioniRifiutoApprovazione.Text != "")
                DTItineration.Rows[0]["cancelreason"] = txtAnnotazioniRifiutoApprovazione.Text;
            DataSet DSNew = new DataSet();

            DSNew.Tables.Add(DTItinerationAuthAgency);
            DSNew.Tables.Add(DTItineration);

            Easy_PostData PD = new Easy_PostData();
            PD.initClass(DSNew, Conn);
            ProcedureMessageCollection PMC = PD.DO_POST_SERVICE();
            if (!PMC.CanIgnore)
            {
                string longMessage = "";
                foreach (ProcedureMessage pm in PMC)
                {
                    longMessage += pm.GetKey() + " " + pm.LongMess + (pm.CanIgnore ? " warning " : " error") + "\n\r";
                }
                ShowClientMessage("Regole di sicurezza hanno impedito l'aggiornamento del DataBase", "Errore", longMessage);
            }
            else
            {
                PD.DO_POST_SERVICE();
            }
            string errormsg = "";
            if (PMC.Count == 0)
            {
                try
                {
                    errormsg = MissFun.WebSendMails(Conn as DataAccess, DTItineration.Rows[0]);
                    if (errormsg != "")
                        ShowClientMessage(errormsg, "Errore");
                }
                catch
                {
                    ShowClientMessage("Errore di invio mail", "Errore");
                }

            }

            CommFun.FreshPage(false, true);
            CommFun.DoMainCommand("mainsetsearch");
            CommFun.DoMainCommand("maindosearch");


        }
    }
}