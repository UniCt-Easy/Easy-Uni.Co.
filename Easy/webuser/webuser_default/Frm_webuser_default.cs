/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.IO;
using System.Xml;

namespace webuser_default
{
    public partial class Frm_webuser_default : Form
    {
        public MetaData meta;
        DataAccess conn ;
        QueryHelper q ;
        public Frm_webuser_default()
        {
            InitializeComponent();
        }


        helpDeskService.doHelpDesk hds;
        public void MetaData_AfterLink()
        {
            meta = MetaData.GetMetaData(this);
            conn = meta.Conn;
            q = conn.GetQueryHelper();
            CanGoEdit = true;
            hds = new helpDeskService.doHelpDesk();
            hds.Url = "https://ticket.temposrl.it/helpdeskservice/doHelpDesk.asmx";
            string filteruser = "(username=" +
            QueryCreator.quotedstrvalue(meta.GetSys("user"), true) + ")";
            DataTable TBUsers = meta.Conn.RUN_SELECT("webuser", "*", null, filteruser, null, false);

            int numrighe = TBUsers.Rows.Count;

            if (numrighe == 1)
            {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else
            {
                CanGoInsert = true;
                CanGoEdit = false;
            }

            GetData.SetStaticFilter(DS.webuser, filteruser);
            MetaData.SetDefault(DS.webuser, "username", meta.GetSys("user"));
            txtUserName.Text = meta.GetSys("user").ToString();
            //txtUserName.Enabled = false;
            txtUserName.ReadOnly = true;

            meta.SearchEnabled = false;
            meta.CanInsertCopy = false;
            meta.CanInsert = false;
            meta.CanCancel = false;
        }

        public void MetaData_AfterClear()
        {
            if (CanGoInsert)
            {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit)
            {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); //edyttype associato
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Salva()) {
                Close();
                return;
            }
            DialogResult = DialogResult.None;
        }

        bool Salva() {
            if (!meta.GetFormData(false)) {
                return false;
            }
            meta.SaveFormData();
            if (DS.HasChanges())
                return false;

            
            DataRow r = DS.webuser.Rows[0];

            if (r["nome"].ToString() == "") {
                MessageBox.Show("E' necessario indicare il nome", "Errore");
                return false;
            }

            if (r["cognome"].ToString() == "") {
                MessageBox.Show("E' necessario indicare il cognome", "Errore");
                return false;
            }
            if (r["email"].ToString() == "") {
                MessageBox.Show("E' necessario indicare l'email", "Errore");
                return false;
            }
            //Ottiene l'idcliente dal w.s.
            DataAccess conn = meta.Conn;
            QueryHelper q = conn.GetQueryHelper();

            //Prima ottiene l'idente
            object idente = conn.DO_READ_VALUE("uniconfig", null, "idente");

            if (r["idcliente"] != DBNull.Value && idente!=DBNull.Value) {
                return aggiornaCliente(r["idcliente"].ToString(),idente.ToString());
            }

             

         
         


            if (idente == DBNull.Value) {
                idente = ottieniIdEnte();
                if (idente == DBNull.Value)
                    return false;
                conn.DO_UPDATE("uniconfig", null,
                        new string[] { "idente" }, new string[] { q.quote(idente) }, 1);
            }

            //Poi ottiene l'idstruttura
            object idstruttura =DBNull.Value;
            DataTable treasurer = conn.RUN_SELECT("treasurer", "*", null, 
                    q.AppAnd(q.CmpEq("active", "S"),q.IsNotNull("idstruttura")),null, false);
            conn.DeleteAllUnselectable(treasurer);
            if (treasurer.Rows.Count > 0) {
                idstruttura = treasurer.Rows[0]["idstruttura"];
            }
            else {
                treasurer = conn.RUN_SELECT("treasurer", "*", null,
                   q.AppAnd(q.CmpEq("active", "S"), q.IsNull("idstruttura")), null, false);
                conn.DeleteAllUnselectable(treasurer);
                if (treasurer.Rows.Count > 0) {
                    idstruttura = ottieniIdStruttura(idente.ToString());
                    if (idstruttura == DBNull.Value) {
                        return false;
                    }
                    conn.DO_UPDATE("treasurer", q.CmpEq("idtreasurer", treasurer.Rows[0]["idtreasurer"]),
                         new string[] { "idstruttura" }, new string[] { q.quote(idstruttura) }, 1);

                }
                else {
                    MessageBox.Show("Nessun cassiere trovato attivo", "Errore");
                    return false;
                }
                
            }

            object idCliente = ottieniIdCliente(idente.ToString(), idstruttura.ToString());
            if (idCliente == DBNull.Value)
                return false;
            r["idcliente"] = idCliente;

            meta.SaveFormData();
            if (DS.HasChanges())
                return false;

            return true;
        }


        object ottieniIdEnte() {            
            object p_iva = conn.DO_READ_VALUE("generalreportparameter", q.CmpEq("idparam", "License_P_Iva"), "paramvalue");
            if (p_iva==null || p_iva.ToString() == "") {
                MessageBox.Show("Inserire la partita iva nei parametri di tutte le stampe", "Errore");
            }
            object denominazioneEnte = conn.DO_READ_VALUE("generalreportparameter", q.CmpEq("idparam", "DenominazioneUniversita"), "paramvalue");
            if (denominazioneEnte == null || denominazioneEnte.ToString() == "") {
                MessageBox.Show("Inserire la denominazione università nei parametri di tutte le stampe", "Errore");
            }
            string iDEnte = hds.registerEnte(denominazioneEnte.ToString(), p_iva.ToString());
            if (iDEnte.StartsWith("Errori")) {
                MessageBox.Show(iDEnte, "Errore");
                return DBNull.Value;
            }
            return iDEnte;
        }

        object ottieniIdStruttura(string idEnte) {
            string filterTreasurer = conn.SelectCondition("treasurer", true);
            DataTable treasurer = conn.RUN_SELECT("treasurer", "*", null, q.AppAnd(filterTreasurer, 
                q.CmpEq("active", "S"),q.IsNotNull("header")), null, false);

            if (treasurer.Rows.Count == 0) {
                treasurer = conn.RUN_SELECT("treasurer", "*", null, q.AppAnd(filterTreasurer,
                q.CmpEq("active", "S")), null, false);
            }
            if (treasurer.Rows.Count == 0) {
                MessageBox.Show("Non ho trovato un tesoriere attivo", "Errore");
                return DBNull.Value;
            }
            DataRow first = treasurer.Rows[0];
            string header = first["header"].ToString();
            if (header == "") {
                MessageBox.Show("Il cassiere "+first["description"].ToString()+"  ha il campo Intestazione Stampe vuoto.", "Errore");
                return DBNull.Value;
            }

            string iDStruttura = hds.registerStruttura(header, idEnte);
            if (iDStruttura.StartsWith("Errori")) {
                MessageBox.Show(iDStruttura, "Errore");
                return DBNull.Value;
            }
            return iDStruttura;
        }

        object ottieniIdCliente(string idEnte, string idStruttura) {
            DataRow r = DS.webuser.Rows[0];
            string idCliente = hds.registerCliente(idEnte, idStruttura,
                r["email"].ToString(),
                r["telefono1"].ToString(),
                r["telefono2"].ToString(),
                r["cellulare"].ToString(),
                r["nome"].ToString(),
                r["cognome"].ToString(),
                r["sesso_mf"].ToString(),
                r["titolo"].ToString(),
                r["username"].ToString());
            if (idCliente.StartsWith("Errori")) {
                MessageBox.Show(idCliente, "Errore");
                return DBNull.Value;
            }
            return idCliente;

        }

        bool aggiornaCliente(string idCliente,string idente) {
            DataRow r = DS.webuser.Rows[0];
            string res = hds.aggiornaCliente(idCliente,idente,
                r["email"].ToString(),
                r["telefono1"].ToString(),
                r["telefono2"].ToString(),
                r["cellulare"].ToString(),
                r["nome"].ToString(),
                r["cognome"].ToString(),
                r["sesso_mf"].ToString(),
                r["titolo"].ToString(),
                r["username"].ToString());
            if (res.StartsWith("Errori")) {
                MessageBox.Show(res, "Errore");
                return false;
            }
            return true;
        }
    }
}

