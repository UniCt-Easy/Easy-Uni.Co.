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
using funzioni_configurazione;
using metadatalibrary;

namespace mandate_default {
    public partial class frmLottiPartecipati : Form {
        DataTable Lotti;
        DataTable Associazioni;
        DataRow Partecipante;

        CQueryHelper QHC = new CQueryHelper();
        DataTable CopiaAssociazioni;

        object idavcp = DBNull.Value;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lotti">Tabella mandatecig</param>
        /// <param name="Associazioni">Tabella mandateavcpdetail</param>
        /// <param name="Partecipante">DataRow mandateavcp del partecipante</param>
        public frmLottiPartecipati(DataTable Lotti, DataTable Associazioni,DataRow Partecipante) {
            InitializeComponent();

            this.Lotti = Lotti;
            this.Associazioni = Associazioni;
            this.Partecipante = Partecipante;
            idavcp = Partecipante["idavcp"];
            txtPartecipante.Text = Partecipante["title"].ToString();

            if (Partecipante["idmain_avcp"] != DBNull.Value) {
                idavcp = Partecipante["idmain_avcp"];
                txtPartecipante.Text = Partecipante.Table.Select(QHC.CmpEq("idavcp", idavcp))[0]["title"].ToString();
            }

            CopiaAssociazioni = CreaCopiaAssociazioni(Associazioni);


            ContextMenu CMenu = new ContextMenu();
            CMenu.MenuItems.Add("Seleziona tutto", new EventHandler(SelectAll));
            CMenu.MenuItems.Add("Deseleziona tutto", new EventHandler(DeselectAll));

            VisualizzaAssociazioni();
        }

        void SelectAll(object menusender, EventArgs e) {
            foreach (ListViewItem I in chkListaLotti.Items) I.Checked = true;
        }

        void DeselectAll(object menusender, EventArgs e) {
            foreach (ListViewItem I in chkListaLotti.Items) I.Checked = false;
        }

        DataTable CreaCopiaAssociazioni(DataTable Associazioni) {
            DataTable T = new DataTable("A");
            T.Columns.Add(new DataColumn("cigcode", typeof(string)));
            foreach (DataRow rA in Associazioni.Select(QHC.CmpEq("idavcp", idavcp))) {
                DataRow r = T.NewRow();
                r["cigcode"] = rA["cigcode"];
                T.Rows.Add(r);
            }
            T.AcceptChanges();
            return T;
        }




        string GetDescrLotto(object cigcode) {
            DataRow[] p = Lotti.Select(QHC.CmpEq("cigcode", cigcode));
            if (p.Length == 0) return "Errore: lotto non trovato";
            return p[0]["description"].ToString();
        }

        ListViewItem createItem(object cigcode, bool ischecked) {
            ListViewItem I = new ListViewItem(cigcode.ToString());
            I.SubItems.Add(GetDescrLotto(cigcode));  
            I.SubItems.Add(GetDescrLotto(cigcode));
            I.Checked = ischecked;
            DataRow[] p = Lotti.Select(QHC.CmpEq("cigcode", cigcode));
            if (p.Length == 0) return I;
            I.Tag = p[0];
            return I;
        }

        /// <summary>
        /// Visualizza i dati presenti in CopiaAssociazioni
        /// </summary>
        void VisualizzaAssociazioni() {
            chkListaLotti.BeginUpdate();
            chkListaLotti.Items.Clear();

            if (chkVediTuttiLotti.Checked) {
                foreach (DataRow rLotto in Lotti.Select(null, "description asc")) {
                    chkListaLotti.Items.Add(createItem(rLotto["cigcode"], isChecked(rLotto["cigcode"])));
                }
            }
            else {
                foreach (DataRow rLotto in CopiaAssociazioni.Select()) {
                    chkListaLotti.Items.Add(createItem(rLotto["cigcode"], true));
                }
            }
            chkListaLotti.EndUpdate();
            chkListaLotti.Refresh();

        }

        /// <summary>
        /// Legge le associazioni presenti nella lista e le applica a CopiaAssociazioni
        /// </summary>
        void LeggiAssociazioni() {
            CopiaAssociazioni.Clear();
            foreach (ListViewItem I in chkListaLotti.Items) {
                if (!I.Checked) continue;
                DataRow rA = I.Tag as DataRow;
                DataRow r = CopiaAssociazioni.NewRow();
                r["cigcode"] = rA["cigcode"];
                CopiaAssociazioni.Rows.Add(r);
            }
        }


        /// <summary>
        /// Allinea la tabella associazioni alla tabella CopiaAssociazioni
        /// </summary>
        void AccettaAssociazioni() {
            //Per tutte le righe Deleted in Associazioni, le riattiva se sono state riselezionate
            foreach (DataRow r in Associazioni.Rows) {
                if (r.RowState != DataRowState.Deleted) continue;
                if (r["idavcp", DataRowVersion.Original].ToString() != idavcp.ToString()) continue; //non è lo stesso partecipante
                if (isChecked(r["cigcode", DataRowVersion.Original])) r.RejectChanges();
            }

            //Per tutte le righe attive in Associazioni, le cancella se la corrispondente riga non è più selezionata
            foreach (DataRow r in Associazioni.Select(QHC.CmpEq("idavcp", idavcp))) {
                if (isChecked(r["cigcode"])) continue;
                r.Delete();
            }

            //Per tutte le righe selezionate, le aggiunge ad Associazioni se  non sono già presenti in essa
            foreach (DataRow p in Lotti.Select()) {
                if (!isChecked(p["cigcode"])) continue;
                if (Associazioni.Select(QHC.AppAnd(
                    QHC.CmpEq("cigcode", p["cigcode"]), QHC.CmpEq("idavcp", idavcp))).Length > 0) continue;
                DataRow rA = Associazioni.NewRow();
                rA["idmankind"] = Partecipante["idmankind"];
                rA["yman"] = Partecipante["yman"];
                rA["nman"] = Partecipante["nman"];
                rA["cigcode"] = p["cigcode"];
                rA["idavcp"] = idavcp;
                rA["lt"] = DateTime.Now;
                rA["lu"] = "curr_user";
                Associazioni.Rows.Add(rA);
            }

        }

        bool isChecked(object cigcode) {
            string filter = QHC.CmpEq("cigcode", cigcode);
            return CopiaAssociazioni.Select(filter).Length > 0;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            LeggiAssociazioni();
            AccettaAssociazioni();
        }

        private void chkVediTuttiLotti_CheckedChanged(object sender, EventArgs e) {
            LeggiAssociazioni();
            VisualizzaAssociazioni();
        }
    }
}
