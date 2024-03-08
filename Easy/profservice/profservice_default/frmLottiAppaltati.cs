
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
using funzioni_configurazione;
using metadatalibrary;

namespace profservice_default {
    public partial class frmLottiAppaltati : MetaDataForm {

        DataTable Lotti;
        DataRow Partecipante;

        CQueryHelper QHC = new CQueryHelper();
        DataTable CopiaLotti;
        object idavcp = DBNull.Value;

        /// <summary>
        /// Lotti è la tabella mandatedetail del chiamante, Partecipante è la riga (mandateavcp) del partecipante 
        /// </summary>
        /// <param name="Lotti"></param>
        /// <param name="Partecipante"></param>
        public frmLottiAppaltati(DataTable Lotti, DataRow Partecipante) {
            InitializeComponent();
            this.Lotti = Lotti;
            this.Partecipante = Partecipante;

            idavcp = Partecipante["idavcp"];
            txtPartecipante.Text = Partecipante["title"].ToString();

            if (Partecipante["idmain_avcp"] != DBNull.Value) {
                idavcp = Partecipante["idmain_avcp"];
                txtPartecipante.Text = Partecipante.Table.Select(QHC.CmpEq("idavcp", idavcp))[0]["title"].ToString();
            }


            CopiaLotti = CreaCopiaLotti(Lotti);

          

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

        DataTable CreaCopiaLotti(DataTable Lotti) {
            DataTable T = new DataTable("A");
            T.Columns.Add(new DataColumn("cigcode", typeof(string)));
            foreach (DataRow rA in Lotti.Select(QHC.CmpEq("idavcp", idavcp))) {
                DataRow r = T.NewRow();
                r["cigcode"] = rA["cigcode"];
                T.Rows.Add(r);
            }
            T.AcceptChanges();
            return T;
        }

        string GetDescrLotto(object rownum) {
            DataRow[] p = Lotti.Select(QHC.CmpEq("cigcode", rownum));
            if (p.Length == 0) return "Errore: lotto non trovato";
            return p[0]["description"].ToString();
        }

        ListViewItem createItem(object cigcode, bool ischecked) {
            ListViewItem I = new ListViewItem(cigcode.ToString());
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
                foreach (DataRow rLotto in Lotti.Select(
                     QHC.NullOrEq("idavcp", idavcp),
                        "description asc")) {
                            chkListaLotti.Items.Add(createItem(rLotto["cigcode"], isChecked(rLotto["cigcode"])));
                }
            }
            else {
                foreach (DataRow rLotto in CopiaLotti.Select()) {
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
            CopiaLotti.Clear();
            foreach (ListViewItem I in chkListaLotti.Items) {
                if (!I.Checked) continue;
                DataRow rA = I.Tag as DataRow;
                DataRow r = CopiaLotti.NewRow();
                r["cigcode"] = rA["cigcode"];
                CopiaLotti.Rows.Add(r);
            }
        }


        /// <summary>
        /// Allinea la tabella Lotti alla tabella CopiaLotti
        /// </summary>
        void AccettaAssociazioni() {

            //Per tutte le righe attive in Associazioni, le scollega se la corrispondente riga non è più selezionata
            foreach (DataRow r in Lotti.Select(QHC.CmpEq("idavcp", idavcp))) {
                if (isChecked(r["cigcode"])) continue;
                r["idavcp"] = DBNull.Value;
            }

            //Per tutte le righe selezionate, le aggiunge ad Associazioni se  non sono già presenti in essa
            foreach (DataRow p in Lotti.Select()) {
                if (!isChecked(p["cigcode"])) continue;
                p["idavcp"] = idavcp;
            }

        }




        bool isChecked(object cigcode) {
            string filter = QHC.CmpEq("cigcode", cigcode);
            return CopiaLotti.Select(filter).Length > 0;
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
