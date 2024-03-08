
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
using funzioni_configurazione;
using System.Xml;

namespace ticket_default {
    public partial class frmTicket_default : MetaDataForm {
        public frmTicket_default() {
            InitializeComponent();
            
            
        }
        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            DataAccess Conn = Meta.Conn;
            QueryHelper q = Conn.GetQueryHelper();
            string filter = q.CmpEq("login", Meta.GetSys("user"));
            GetData.SetStaticFilter(DS.ticket, filter);
            Meta.CanCancel = false;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
        }
        public void MetaData_AfterFill() {
            DataRow Curr = DS.ticket.Rows[0];
            if (Curr["status"].ToString() == "Chiuso") {
                btnAggiorna.Visible = false;
            }
            else {
                btnAggiorna.Visible = true;
            }
        }
        public void MetaData_AfterClear() {
            btnAggiorna.Visible = false;
        }

        private void btnAggiorna_Click(object sender, EventArgs e) {
            
            btnAggiorna.Visible = false;
            try {
                 DataRow Curr = DS.ticket.Rows[0];
                int idticket = Convert.ToInt32(Curr["idticket"]);
                helpDeskService.doHelpDesk hds = new helpDeskService.doHelpDesk();
                hds.Url = "https://SERVER/helpdeskservice/doHelpDesk.asmx";
                string res = hds.getStatoTicket(idticket);
                if (res.StartsWith("Errori")) {
                    show(res, "Errore");
                }
                else {
                    //nel server:Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlDoc.OuterXml));
                    string xmlClear = Encoding.UTF8.GetString(Convert.FromBase64String(res));
                    XmlDocument x = new XmlDocument();
                    x.LoadXml(xmlClear);
                    XmlNode xn = x.DocumentElement;
                    foreach(XmlNode xx in xn.ChildNodes){
                        if (xx.Name == "stato") {
                            Curr["status"] = xx.InnerText;
                        }
                        if (xx.Name == "soluzione") {                            
                            Curr["soluzione"] = Encoding.UTF8.GetString(Convert.FromBase64String(xx.InnerText));
                        }
                        if (xx.Name == "operatore") {
                            Curr["operatore"] = xx.InnerText;
                        }
                        
                        if (xx.Name == "chiusura") {
                            Curr["chiusura"] = XmlConvert.ToDateTime(xx.InnerText, XmlDateTimeSerializationMode.Local);
                        }
                        MetaData.FreshForm(this, false);
                        
                        MetaData.SaveFormData(this);
                    }
                }

            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                btnAggiorna.Visible = true;
            }
           

        }
    }
}