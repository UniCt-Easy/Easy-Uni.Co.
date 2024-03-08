
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
using generaSQL;
using System.IO;
using System.Collections;

namespace sortingkind_creascriptclass {
    public partial class FrmSortingKind_CreaScriptClass : MetaDataForm {
        string Header = "--JTR";
        MetaData Meta;

        ISaveFileDialog saveFileDialog1;

        public FrmSortingKind_CreaScriptClass() {
            InitializeComponent();
            saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
        }

        string codesorkind = "";
        string description = "";

        private void btnInstall_Click(object sender, EventArgs e) {
            lblFile.Text = "";
            if (txtTipoClass.Text == "") {
                show(this, "Specificare il codice del tipo di classificazione", "Errore");
                return;
            }
            if (txtDescrizione.Text == "") {
                show(this, "Specificare la descrizione del tipo di classificazione", "Errore");
                return;
            }

            codesorkind = txtTipoClass.Text;
            description = txtDescrizione.Text;
            if (!generaScript()) {
                show(this, "Errore! Procedura interrotta");
            }
        }

        private bool generaScript() {
            DataTable tSortingKind = DataAccess.CreateTableByName(Meta.Conn, "sortingkind", "*");
            DataTable tSortingApplicability = DataAccess.CreateTableByName(Meta.Conn, "sortingapplicability", "*");
            DataTable tSortingLevel = DataAccess.CreateTableByName(Meta.Conn, "sortinglevel", "*");
            DataTable tSorting = DataAccess.CreateTableByName(Meta.Conn, "sorting", "*");

            if (!fillSortingKind(tSortingKind)) {
                show(this, "Errore nel riempimento di SORTINGKIND");
                return false;
            }

            if (!fillSortingApplicability(tSortingApplicability)){
                show(this, "Errore nel riempimento di SORTINGAPPLICABILITY");
                return false;
            }

            if (!fillSortingLevel(tSortingLevel)) {
                show(this, "Errore nel riempimento di SORTINGLEVEL");
                return false;
            }

            if (!fillSorting(tSorting)) {
                show(this, "Errore nel riempimento di SORTING");
                return false;
            }

            DataSet dsScript = new DataSet();
            dsScript.Tables.Add(tSortingKind);
            dsScript.Tables.Add(tSortingApplicability);
            dsScript.Tables.Add(tSortingLevel);
            dsScript.Tables.Add(tSorting);


            if (!creaScriptClass(dsScript)) {
                show(this,"Errore nella generazione del file");
                return false;
            }
            show(this, "Generazione dello script effettuata");
            return true;
        }
        
        private bool fillSortingKind(DataTable tSortingKind) {
            DataRow rSortingKind = tSortingKind.NewRow();
            rSortingKind["idsorkind"] = 1;
            rSortingKind["codesorkind"] = codesorkind;
            rSortingKind["description"] = description;
            rSortingKind["active"] = "S";
            rSortingKind["flag"] = 0;
            rSortingKind["ct"] = DateTime.Now;
            rSortingKind["cu"] = "Software and More";
            rSortingKind["lt"] = DateTime.Now;
            rSortingKind["lu"] = "Software and More";

            tSortingKind.Rows.Add(rSortingKind);
            return true;
        }

        private bool fillSortingApplicability(DataTable tSortingApplicability) {
            DataRow rSortingApplicability = tSortingApplicability.NewRow();
            rSortingApplicability["idsorkind"] = 1;
            rSortingApplicability["tablename"] = "inventorytree";
            rSortingApplicability["ct"] = DateTime.Now;
            rSortingApplicability["cu"] = "Software and More";
            rSortingApplicability["lt"] = DateTime.Now;
            rSortingApplicability["lu"] = "Software and More";

            tSortingApplicability.Rows.Add(rSortingApplicability);
            return true;
        }

        private bool fillSortingLevel(DataTable tSortingLevel) {
            DataTable tInventorySortingLevel = DataAccess.CreateTableByName(Meta.Conn, "inventorysortinglevel", "*");
            if (tInventorySortingLevel == null) {
                show(this, "Errore nella creazione della tabella dei livelli");
                return false;
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventorySortingLevel, "nlevel", null, null, true);
            if (tInventorySortingLevel.Rows.Count == 0) {
                show(this, "La tabella dei livelli non ha righe");
                return false;
            }

            foreach (DataRow rISL in tInventorySortingLevel.Rows) {
                DataRow rSortingLevel = tSortingLevel.NewRow();
                rSortingLevel["idsorkind"] = 1;
                foreach(DataColumn c in tInventorySortingLevel.Columns) {
                    if (!tSortingLevel.Columns.Contains(c.ColumnName)) continue;
                    rSortingLevel[c.ColumnName] = rISL[c.ColumnName];
                }
                rSortingLevel["flag"] = (Convert.ToInt32(rSortingLevel["flag"])&0xFF) |
                            (Convert.ToInt32(rISL["codelen"]) << 8);
                //flag = flag & 0xff | (codelen << 8);
                tSortingLevel.Rows.Add(rSortingLevel);
            }

            return true;
        }

        private bool fillSorting(DataTable tSorting) {
            DataTable tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "*");
            if (tInventoryTree == null) {
                show(this, "Errore nella creazione della tabella della class. inventario");
                return false;
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventoryTree, "idinv", null, null, true);
            if (tInventoryTree.Rows.Count == 0) {
                show(this, "La tabella della classificazione inventariale non ha righe");
                return false;
            }

            foreach (DataRow rIT in tInventoryTree.Rows) {
                DataRow rSorting = tSorting.NewRow();
                rSorting["idsorkind"] = 1;
                rSorting["idsor"] = rIT["idinv"];
                rSorting["sortcode"] = rIT["codeinv"];
                rSorting["description"] = rIT["description"];
                rSorting["nlevel"] = rIT["nlevel"];
                rSorting["paridsor"] = rIT["paridinv"];
                rSorting["ct"] = DateTime.Now;
                rSorting["cu"] = "Software and More";
                rSorting["lt"] = DateTime.Now;
                rSorting["lu"] = "Software and More";

                tSorting.Rows.Add(rSorting);
            }

            return true;
        }

        public bool creaScriptClass(DataSet ds) {
            StringWriter sw = new StringWriter();
            sw.WriteLine(Header);
            generaSortingKind(Meta.Conn, ds, sw);
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "File non scelto. Procedura interrotta");
                return false;
            }
            string filename = saveFileDialog1.FileName;
            StreamWriter fsw = new StreamWriter(filename, false, Encoding.Default);
            fsw.Write(sw.ToString());
            fsw.Close();
            lblFile.Text = "Script salvato in " + filename;
            return true;
        }

        private void btnDati_Click(object sender, EventArgs e) {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "File non scelto. Procedura interrotta");
                return;
            }
            string filename = saveFileDialog1.FileName;
            StreamWriter writer = new StreamWriter(filename, false, Encoding.Default);
            writer.WriteLine(Header);
            writer.WriteLine("delete from inventorytree");
            writer.WriteLine("GO");
            DataTable tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventoryTree, "idinv", null, null, true);
            if (tInventoryTree == null) {
                show(this, "Errore nel riempimento dell tabella INVENTORYTREE", "Errore");
                return;
            }
            if (tInventoryTree.Rows.Count == 0) {
                show(this, "La tabella INVENTORYTREE risulta vuota, non verrà generato alcuno script", "Avviso");
                return;
            }

            DataSet dsIT = new DataSet();
            dsIT.Tables.Add(tInventoryTree);

            GeneraSQL.GeneraStrutturaEDati(Meta.Conn, dsIT, writer, UpdateType.onlyInsert, DataGenerationType.onlyData, true);
            writer.Close();
            show("File generato correttamente");
            return;
        }


        public static bool generaSortingKind(DataAccess Conn, DataSet D, StringWriter writer) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable TSorKind = D.Tables["sortingkind"];
            DataTable TSorApp = D.Tables["sortingapplicability"];
            DataTable TSorLev = D.Tables["sortinglevel"];
            DataTable TSor = D.Tables["sorting"];

            DataRow SorKind = TSorKind.Rows[0];
            //Ciclo su sortingkind
            StringBuilder sql = new StringBuilder();
            string filterkind = QHS.CmpEq("idsorkind", SorKind["idsorkind"]);
            //
            //Mette la riga in sortingkind
            sql.Append("DECLARE @idsorkind int\r\n");
            sql.Append("SET @idsorkind = isnull((SELECT MAX(idsorkind) from sortingkind),0)+1 \r\n");

            string insert = "INSERT INTO  sortingkind (";
            bool first = true;
            foreach (DataColumn C in TSorKind.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += C.ColumnName;
            }
            insert += ") VALUES (";
            first = true;
            string values = "";

            foreach (DataColumn C in TSorKind.Columns) {
                string ccolName = C.ColumnName;
                if (!first) values += ",";
                first = false;
                if (ccolName == "idsorkind") {
                    values += "@idsorkind";
                }
                else {
                    values += QueryCreator.GetPrintable(QHS.quote(SorKind[ccolName]));
                }
            }
            values += ")\r\n";
            sql.Append(insert + values);

            //Mette le righe in sortingapplicability
            if (TSorApp.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER sortingapplicability");
            }
            insert = "INSERT INTO  sortingapplicability (";
            first = true;
            foreach (DataColumn CC in TSorApp.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += CC.ColumnName;
            }
            insert += ") VALUES (";
            foreach (DataRow RSA in TSorApp.Rows) {
                first = true;
                values = "";
                foreach (DataColumn C2 in TSorApp.Columns) {
                    string colName = C2.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    if (colName == "idsorkind") {
                        values += "@idsorkind";
                    }
                    else {
                        values += QueryCreator.GetPrintable(QHS.quote(RSA[colName]));
                    }
                }
                values += ")\r\n";
                sql.Append(insert + values);

            }

            //Mette le righe in sortinglevel
            if (TSorLev.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER sortinglevel");
            }
            insert = "INSERT INTO  sortinglevel (";
            first = true;
            foreach (DataColumn C3 in TSorLev.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += C3.ColumnName;
            }
            insert += ") VALUES (";

            foreach (DataRow RSL in TSorLev.Rows) {
                first = true;
                values = "";
                foreach (DataColumn C4 in TSorLev.Columns) {
                    string colName = C4.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    if (colName == "idsorkind") {
                        values += "@idsorkind";
                    }
                    else {
                        values += QueryCreator.GetPrintable(QHS.quote(RSL[colName]));
                    }
                }
                values += ")\r\n";
                sql.Append(insert + values);

            }
            writer.WriteLine(sql);
            writer.WriteLine("GO");
            writer.Flush();

            //Mette le righe in sorting
            if (TSor.Rows.Count > 0) {
                sql.AppendLine();
                sql.AppendLine("-- GENERAZIONE DATI PER sorting");
            }
            sql = new StringBuilder();
            sql.Append("DECLARE @idsorkind int\r\n");
            sql.Append("SELECT  @idsorkind = idsorkind from sortingkind where " +
                QHS.CmpEq("codesorkind", SorKind["codesorkind"])
                + " \r\n");


            sql.Append("DECLARE @idsor int\r\n");
            sql.Append("SET @idsor = isnull((SELECT MAX(idsor) from sorting),0) \r\n");
            Hashtable ParID = new Hashtable();
            insert = "INSERT INTO  sorting (";
            first = true;
            foreach (DataColumn C5 in TSor.Columns) {
                if (!first) insert += ",";
                first = false;
                insert += C5.ColumnName;
            }
            insert += ") VALUES (";
            int NUM = 0;
            foreach (DataRow Sor in TSor.Select(null, "nlevel asc")) {
                NUM++;
                int nlevel = Convert.ToInt32(Sor["nlevel"]);
                first = true;
                values = "";
                foreach (DataColumn C6 in TSor.Columns) {
                    string colName = C6.ColumnName;
                    if (!first) values += ",";
                    first = false;
                    if (colName == "idsorkind") {
                        values += "@idsorkind";
                        continue;
                    }
                    if (colName == "idsor") {
                        values += "@idsor+" + NUM.ToString();
                        ParID[Sor["idsor"].ToString()] = NUM;
                        continue;
                    }
                    if (colName == "paridsor") {
                        if (Sor["paridsor"] == DBNull.Value) {
                            values += "null";
                        }
                        else {
                            if (ParID[Sor["paridsor"].ToString()] == null) {
                                (new MetaDataForm()).show("Riga parent di " + Sor["idsor"].ToString() +
                                    " non trovata in sorting.");
                                writer.Close();
                                return false;
                            }
                            else {
                                values += "@idsor+" + ParID[Sor["paridsor"].ToString()].ToString();
                            }
                        }
                        continue;
                    }
                    values += QueryCreator.GetPrintable(QHS.quote(Sor[colName]));

                }
                values += ")\r\n";
                sql.Append(insert + values);

            }
            if (sql.Length != 0) {
                writer.WriteLine(sql);
                writer.WriteLine("GO");
                writer.Flush();
            }




            writer.Write("-- FINE GENERAZIONE SCRIPT --\r\n\r\n");
            writer.WriteLine("GO");
            writer.Close();

            return true;
        }

    }
}
