
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace no_table_entry_rateo {
    public partial class FrmEntryPreSave : Form {
        //DataTable tEntry;
        DataAccess Conn;
        DataTable tAccount;
        DataTable tAnagrafica;
        DataTable tUpb;
        DataTable tSorting;
        DataTable tAccMotive;
        DataTable tExpenseSetup;
        CQueryHelper QHC;
        QueryHelper QHS;
        ContextMenu ExcelMenu;
        DataTable tRateiAttivi;
        DataTable tRateiPassivi;
        DataTable tFattEmettere;
        DataTable tFattRicevere;
        DataTable tRateiParcelle;
        DataTable tParcelleRicevere;

        bool Commerciale = false;
        int esercizio;

        public FrmEntryPreSave(DataTable tRateiAttivi, DataTable tRateiPassivi, DataTable tFattRicevere, DataTable tFattEmettere,
                        DataTable tRateiParcelle, DataTable tParcelleRicevere,
                        DataAccess Conn, bool AnnoCommerciale) {
            InitializeComponent();
            this.tRateiAttivi = tRateiAttivi;
            this.tRateiPassivi = tRateiPassivi;
            this.tFattEmettere = tFattEmettere;
            this.tFattRicevere = tFattRicevere;
            this.tParcelleRicevere = tParcelleRicevere;
            this.tRateiParcelle = tRateiParcelle;

            this.Conn = Conn;
            QHS = this.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            this.Commerciale = AnnoCommerciale;
            esercizio = (int)Conn.GetSys("esercizio");

            tAccount = DataAccess.CreateTableByName(Conn, "account", "idacc, codeacc, title");
            tAnagrafica = DataAccess.CreateTableByName(Conn, "registry", "idreg, title");
            tUpb = DataAccess.CreateTableByName(Conn, "upb", "idupb, codeupb");
            tSorting = DataAccess.CreateTableByName(Conn, "sorting", "idsorkind, idsor,sortcode");
            tAccMotive = DataAccess.CreateTableByName(Conn, "accmotive", "idaccmotive, codemotive, title");
            tExpenseSetup = DataAccess.CreateTableByName(Conn, "config", "ayear, idsortingkind1, idsortingkind2, idsortingkind3");
            string f = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tExpenseSetup, null, f, null, true);

            fillTempField(tRateiAttivi,txtTotRAttivi);
            fillTempField(tRateiPassivi, txtTotRPassivi);
            fillTempField(tFattEmettere, txtTotFattEmettere);
            fillTempField(tFattRicevere, txtTotFattRic);
            fillTempField(tParcelleRicevere, txtTotParcelleRicevere);
            fillTempField(tRateiParcelle, txtTotRateiParcelle);

            assegnaCaption(tRateiPassivi);
            assegnaCaption(tRateiAttivi);
            assegnaCaption(tFattRicevere);
            assegnaCaption(tFattEmettere);
            assegnaCaption(tParcelleRicevere);
            assegnaCaption(tRateiParcelle);

            HelpForm.SetDataGrid(dgRatPassivi, tRateiPassivi);
            HelpForm.SetDataGrid(dgRatAttivi, tRateiAttivi);
            HelpForm.SetDataGrid(dgFattEmettere, tFattEmettere);
            HelpForm.SetDataGrid(dgFattRicevere, tFattRicevere);
            HelpForm.SetDataGrid(dgParcelleRicevere, tParcelleRicevere);
            HelpForm.SetDataGrid(dgRateiParcelle, tRateiParcelle);


            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));


            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            
            dgRatAttivi.ContextMenu = ExcelMenu;
            dgRatPassivi.ContextMenu = ExcelMenu;
            dgFattRicevere.ContextMenu = ExcelMenu;
            dgFattEmettere.ContextMenu = ExcelMenu;
            dgParcelleRicevere.ContextMenu = ExcelMenu;
            dgRateiParcelle.ContextMenu = ExcelMenu;

        }

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }


        private void fillTempField(DataTable T,TextBox Txt) {
            T.Columns.Add("!codiceconto");
            T.Columns.Add("!conto");
            T.Columns.Add("!anagrafica");
            T.Columns.Add("!upb");
            T.Columns.Add("!class1");
            T.Columns.Add("!class2");
            T.Columns.Add("!class3");
            T.Columns.Add("!codicecausale");
            T.Columns.Add("!causale");
            T.Columns.Add("!start", typeof(DateTime));
            T.Columns.Add("!stop", typeof(DateTime));

            decimal saldo = 0;
            foreach (DataRow r in T.Rows) {
                if (r["idacc"] != DBNull.Value) assegnaConto(r);
                if (r["idreg"] != DBNull.Value) assegnaAnagrafica(r);
                if (r["idupb"] != DBNull.Value) assegnaUpb(r);
                if (r["idaccmotive"] != DBNull.Value) assegnaCausale(r);
                if (r["idsor1"] != DBNull.Value) assegnaClass(r, 1);
                if (r["idsor2"] != DBNull.Value) assegnaClass(r, 2);
                if (r["idsor3"] != DBNull.Value) assegnaClass(r, 3);
                if (r["competencystart"] != DBNull.Value || r["competencystop"] != DBNull.Value) assegnaDate(r);

                saldo += CfgFn.GetNoNullDecimal(r["amount"]);
            }

            Txt.Text = saldo.ToString("c");
        }



        private void assegnaDate(DataRow r) {
            r["!start"] = r["competencystart"];
            r["!stop"] = r["competencystop"];
        }

        private void assegnaConto(DataRow r) {
            string filterC = QHC.CmpEq("idacc", r["idacc"]);
            string filterSQL = QHS.CmpEq("idacc", r["idacc"]);
            fill(r, filterC, filterSQL, tAccount, "!codiceconto", "codeacc");
            fill(r, filterC, filterSQL, tAccount, "!conto", "title");
        }

        private void assegnaCausale(DataRow r) {
            string filterC = QHC.CmpEq("idaccmotive", r["idaccmotive"]);
            string filterSQL = QHS.CmpEq("idaccmotive", r["idaccmotive"]);
            fill(r, filterC, filterSQL, tAccMotive, "!codicecausale", "codemotive");
            fill(r, filterC, filterSQL, tAccMotive, "!causale", "title");
        }

        private void assegnaAnagrafica(DataRow r) {
            string filterC = QHC.CmpEq("idreg", r["idreg"]);
            string filterSQL = QHS.CmpEq("idreg", r["idreg"]);
            fill(r, filterC, filterSQL, tAnagrafica, "!anagrafica", "title");
        }

        private void assegnaUpb(DataRow r) {
            string filterC = QHC.CmpEq("idupb", r["idupb"]);
            string filterSQL = QHS.CmpEq("idupb", r["idupb"]);
            fill(r, filterC, filterSQL, tUpb, "!upb", "codeupb");
        }

        private void assegnaClass(DataRow r, int nSor) {
            if ((tExpenseSetup == null) || (tExpenseSetup.Rows.Count == 0)) return;
            DataRow rExp = tExpenseSetup.Rows[0];
            string filterC = QHC.AppAnd(QHC.CmpEq("idsorkind", rExp["idsortingkind" + nSor]),
                QHC.CmpEq("idsor", r["idsor" + nSor]));
            string filterSQL = QHS.AppAnd(QHS.CmpEq("idsorkind", rExp["idsortingkind" + nSor]),
                QHS.CmpEq("idsor", r["idsor" + nSor]));
            fill(r, filterC, filterSQL, tSorting, "!class" + nSor, "sortcode");
        }

        /// <summary>
        /// Metodo che riempie il campo del datarow che abndrà in output
        /// </summary>
        /// <param name="r">DataRow da aggiornare</param>
        /// <param name="filter">Filtro sulla tabella a cui la chiave esterna fa riferimento</param>
        /// <param name="t">Tabella Padre</param>
        /// <param name="tempField">Nome del campo temporaneo (iniziante sempre con !)</param>
        /// <param name="field">Come del campo della tabella padre</param>
        private void fill(DataRow r, string filterC, string filterSQL, DataTable t, string tempField, string field) {
            if (t.Select(filterC).Length > 0) {
                DataRow rOfT = t.Select(filterC)[0];
                r[tempField] = rOfT[field];
                return;
            }
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filterSQL, null, true);
            if (t.Select(filterC).Length > 0) {
                DataRow rOfT = t.Select(filterC)[0];
                r[tempField] = rOfT[field];
            }
        }

        private void assegnaCaption(DataTable T) {
            foreach (DataColumn c in T.Columns) {
                MetaData.DescribeAColumn(T, c.ColumnName, "", -1);
            }
            int npos = 1;
            MetaData.DescribeAColumn(T, "!valoreoriginale", "Importo originale", npos++);
            MetaData.DescribeAColumn(T, "competencystart", "Data Inizio", npos++);
            MetaData.DescribeAColumn(T, "competencystop", "Data Fine", npos++);
            if (T.Columns.Contains("!giorni")) {
                MetaData.DescribeAColumn(T, "!totgiorni", "Totale giorni", npos++);
                MetaData.DescribeAColumn(T, "!giorni", "Giorni considerati", npos++);
                MetaData.DescribeAColumn(T, "!importo", "Importo Calcolato", npos++);
            }
            else {
                MetaData.DescribeAColumn(T, "amount", "Importo", npos++);
            }

            MetaData.DescribeAColumn(T, "!codiceconto", "Codice Conto", npos++);
            MetaData.DescribeAColumn(T, "!conto", "Conto", npos++);
            MetaData.DescribeAColumn(T, "!anagrafica", "Anagrafica", npos++);
            MetaData.DescribeAColumn(T, "!upb", "U.P.B.", npos++);
            MetaData.DescribeAColumn(T, "!class1", "Coord. Anal. 1", npos++);
            MetaData.DescribeAColumn(T, "!class2", "Coord. Anal. 2", npos++);
            MetaData.DescribeAColumn(T, "!class3", "Coord. Anal. 3", npos++);
            MetaData.DescribeAColumn(T, "!codicecausale", "Cod. Causale", npos++);
            MetaData.DescribeAColumn(T, "!causale", "Causale", npos++);
            if (T.Columns.Contains("mandatekind")) {
                MetaData.DescribeAColumn(T, "mandatekind", "Tipo Contratto Passivo", npos++);
                MetaData.DescribeAColumn(T, "yman", "Esercizio contratto", npos++);
                MetaData.DescribeAColumn(T, "nman", "Numero contratto", npos++);
                MetaData.DescribeAColumn(T, "rownum", "Numero dettaglio", npos++);
            }
            if (T.Columns.Contains("estimatekind")) {
                MetaData.DescribeAColumn(T, "estimatekind", "Tipo Contratto Attivo", npos++);
                MetaData.DescribeAColumn(T, "yestim", "Esercizio contratto", npos++);
                MetaData.DescribeAColumn(T, "nestim", "Numero contratto", npos++);
                MetaData.DescribeAColumn(T, "rownum", "Numero dettaglio", npos++);
            }
            if (T.Columns.Contains("ycon")) {
                MetaData.DescribeAColumn(T, "ycon", "Anno parcella", npos++);
                MetaData.DescribeAColumn(T, "ncon", "Num. parcella", npos++);
            }



        }
    }
}
