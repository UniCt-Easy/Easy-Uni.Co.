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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace profservice_default {
    public partial class FrmPartecipantiLotto : Form {
        DataTable Associazioni;
        DataRow Lotto;
        DataTable Partecipanti;
        CQueryHelper QHC = new CQueryHelper();
        DataTable CopiaAssociazioni;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Lotto">DataRow del mandatecig corrispondente al lotto</param>
        /// <param name="Partecipanti">Tabella mandateavcp del chiamante</param>
        /// <param name="Associazioni">Tabella mandateavcpdetail del chiamante</param>
        public FrmPartecipantiLotto(DataRow Lotto, DataTable Partecipanti, DataTable Associazioni) {
            InitializeComponent();
            this.Lotto = Lotto;
            this.Associazioni = Associazioni;
            this.Partecipanti = Partecipanti;

            CopiaAssociazioni = CreaCopiaAssociazioni(Associazioni);

            txtLotto.Text = Lotto["description"].ToString();
            txtCIG.Text = Lotto["cigcode"].ToString();

            ContextMenu CMenu = new ContextMenu();
            CMenu.MenuItems.Add("Seleziona tutto", new EventHandler(SelectAll));
            CMenu.MenuItems.Add("Deseleziona tutto", new EventHandler(DeselectAll));

            VisualizzaAssociazioni();
        }

        void SelectAll(object menusender, EventArgs e) {
            foreach (ListViewItem I in chkListPartecipanti.Items) I.Checked = true;
        }

        void DeselectAll(object menusender, EventArgs e) {
            foreach (ListViewItem I in chkListPartecipanti.Items) I.Checked = false;
        }
        DataTable CreaCopiaAssociazioni(DataTable Associazioni) {
            DataTable T = new DataTable("A");
            T.Columns.Add(new DataColumn("idavcp", typeof(int)));
            foreach (DataRow rA in Associazioni.Select(QHC.CmpEq("cigcode", Lotto["cigcode"]))) {
                DataRow r = T.NewRow();
                r["idavcp"] = rA["idavcp"];
                T.Rows.Add(r);
            }
            T.AcceptChanges();
            return T;
        }


        string GetDescrPartecipante(object idavcp) {
            DataRow[] p = Partecipanti.Select(QHC.CmpEq("idavcp", idavcp));
            if (p.Length == 0) return "Errore: partecipante non trovato";
            return p[0]["title"].ToString();
        }

        ListViewItem createItem(object idavcp,bool ischecked) {
            ListViewItem I = new ListViewItem(GetDescrPartecipante(idavcp));
            I.SubItems.Add(I.Text);
            I.Checked = ischecked;
            DataRow[] p = Partecipanti.Select(QHC.CmpEq("idavcp", idavcp));
            if (p.Length == 0) return I;
            I.Tag = p[0];
            return I;
        }

        /// <summary>
        /// Visualizza i dati presenti in CopiaAssociazioni
        /// </summary>
        void VisualizzaAssociazioni() {
            chkListPartecipanti.BeginUpdate();
            chkListPartecipanti.Items.Clear();

            if (chkVediTuttiPartecipanti.Checked) {
                foreach (DataRow rPart in Partecipanti.Select(QHC.IsNull("idmain_avcp"),"title asc")) {
                    chkListPartecipanti.Items.Add(createItem(rPart["idavcp"],isChecked(rPart["idavcp"])));
                }
            }
            else {
                foreach (DataRow rPart in CopiaAssociazioni.Select()) {
                    chkListPartecipanti.Items.Add(createItem(rPart["idavcp"], true));
                }
            }
            chkListPartecipanti.EndUpdate();
            chkListPartecipanti.Refresh();
        }

        /// <summary>
        /// Legge le associazioni presenti nella lista e le applica a CopiaAssociazioni
        /// </summary>
        void LeggiAssociazioni() {
            CopiaAssociazioni.Clear();
            foreach (ListViewItem I in chkListPartecipanti.Items) {
                if (!I.Checked) continue;
                DataRow rA = I.Tag as DataRow;
                DataRow r = CopiaAssociazioni.NewRow();
                r["idavcp"] = rA["idavcp"];
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
                if (r["cigcode", DataRowVersion.Original].ToString() != Lotto["cigcode"].ToString()) continue; //non è lo stesso lotto
                if (isChecked(r["idavcp",DataRowVersion.Original])) r.RejectChanges(); 
            }

            //Per tutte le righe attive in Associazioni, le cancella se la corrispondente riga non è più selezionata
            foreach (DataRow r in Associazioni.Select(QHC.CmpEq("cigcode", Lotto["cigcode"]))) {                
                if (isChecked(r["idavcp"])) continue;
                 r.Delete();
            }

            //Per tutte le righe selezionate, le aggiunge ad Associazioni se  non sono già presenti in essa
            foreach(DataRow p in Partecipanti.Select()){
                if(!isChecked(p["idavcp"])) continue;
                if (Associazioni.Select(QHC.AppAnd(
                    QHC.CmpEq("cigcode", Lotto["cigcode"]), QHC.CmpEq("idavcp", p["idavcp"]))).Length > 0) continue;
                DataRow rA = Associazioni.NewRow();
                rA["ycon"] = Lotto["ycon"];
                rA["ncon"] = Lotto["ncon"];
                rA["cigcode"] = Lotto["cigcode"];
                rA["idavcp"] = p["idavcp"];
                rA["lt"] = DateTime.Now;
                rA["lu"] = "curr_user";
                Associazioni.Rows.Add(rA);
            }

        }

        bool isChecked(object idavcp) {
            string filter = QHC.CmpEq("idavcp", idavcp);
            return CopiaAssociazioni.Select(filter).Length>0;
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
