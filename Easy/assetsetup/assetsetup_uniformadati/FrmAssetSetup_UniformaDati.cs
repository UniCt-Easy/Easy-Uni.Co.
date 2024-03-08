
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
using System.Collections;
using System.IO;
using metadatalibrary;
using LiveUpdate;
using generaSQL;

namespace assetsetup_uniformadati {
    public partial class FrmAssetSetup_UniformaDati : MetaDataForm {
        MetaData Meta;

        // DataSet dove vengono riversati i dati prensenti nel file .xml di input
        DataSet dsFile = new DataSet();
        // DataSet di look up
        DataSet dsLookUp = new DataSet();
        // DataSet sottoinsieme di dsFile, è il DataSet che viene adoperato per il lookup
        DataSet dsPruned = new DataSet();

        CQueryHelper QHC;
        QueryHelper QHS;

        object iddep = null;
        object codedep = null;
        public IOpenFileDialog openFileDialog1;

        public FrmAssetSetup_UniformaDati() {
            InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        private void btnFile_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "File non selezionato", "Avvertimento");
                return;
            }
            txtFile.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// Metodo che calcola un filtro in base alla tabella tName per interrogare il dataset di input
        /// (quello presente nel file .xml importato)
        /// </summary>
        /// <param name="tName">Nome della Tabella su cui costruire il filtro</param>
        /// <returns></returns>
        private string calcolaFiltro(string tName) {
            string filter = "";
            switch (tName) {
                case "inventoryagency": {
                        filter = QHC.CmpEq("idinventoryagency", iddep);
                        break;
                    }

                case "inventory": {
                        filter = QHC.CmpEq("idinventoryagency", iddep);
                        break;
                    }

                case "assetloadkind": {
                        string f = QHC.CmpEq("idinventoryagency", iddep);
                        DataRow[] ROWINV = dsFile.Tables["inventory"].Select(f);
                        filter = QHC.FieldIn("idinventory", ROWINV);
                        //string listOfIdInventory = QueryCreator.ColumnValues(ROWINV, "idinventory", false);
                        //if (listOfIdInventory == "") break;
                        //filter = "(idinventory in (" + listOfIdInventory + "))";
                        break;
                    }

                case "assetunloadkind": {
                        string f = QHC.CmpEq("idinventoryagency", iddep);
                        DataRow[] ROWINV = dsFile.Tables["inventory"].Select(f);
                        filter = QHC.FieldIn("idinventory", ROWINV);
                        //string listOfIdInventory = QueryCreator.ColumnValues(ROWINV, "idinventory", false);
                        //if (listOfIdInventory == "") break;
                        //filter = "(idinventory in (" + listOfIdInventory + "))";
                        break;
                    }
            }
            return filter;
        }

        private void azzeraDataSet() {
            azzeraDataSet(dsFile);
            azzeraDataSet(dsLookUp);
            azzeraDataSet(dsPruned);
        }

        private void azzeraDataSet(DataSet ds) {
            ds.Clear();

            ArrayList A = new ArrayList(10);
            foreach (DataTable t in ds.Tables) {
                A.Add(t);
            }
            foreach (DataTable t in A) {
                ds.Tables.Remove(t);
            }
            ds.AcceptChanges();
        }

        private void btnUniforma_Click(object sender, EventArgs e) {
            if (openFileDialog1.FileName == "") {
                show(this, "File non selezionato, processo interrotto", "Errore");
                return;
            }

            if (!fillDsDaFile()) return;
            AskInventoryAgency aia = new AskInventoryAgency(dsFile.Tables["inventoryagency"]);
            createForm(aia, null);
            DialogResult dr = aia.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Ente inventariale non selezionato, processo interrotto", "Errore");
                return;
            }

            iddep = aia.cmbEnte.SelectedValue;
            if ((iddep == null) || (iddep == DBNull.Value)) {
                show(this, "L'ente inventariale selezionato non è valido", "Errore");
                azzeraDataSet();
                return;
            }

            codedep = dsFile.Tables["inventoryagency"].Select(QHC.CmpEq("idinventoryagency", iddep))[0]["codeinventoryagency"];

            string[] table = {"assetloadmotive", "assetunloadmotive", "assetloadkind", "assetunloadkind",
                "inventory", "inventorykind", "assetusagekind", "inventoryamortization"};
            foreach (string t in table) {
                string filter = calcolaFiltro(t);
                
                if (!verificaEUniformaTabelle(t, filter)) {
                    show(this, "Errore nella verifica e uniformazione della tabella " + t, "Errore");
                    azzeraDataSet();
                    return;
                }
            }
            bool res = verificaSeChiamareFormRiepilogo();
            if (res) {
                FrmRiepilogo fr = new FrmRiepilogo(Meta, dsLookUp);
                createForm(fr, null);
                DialogResult drRiep = fr.ShowDialog();
                if (drRiep != DialogResult.OK) {
                    show(this, "Il processo sarà interrotto", "Errore");
                    azzeraDataSet();
                    return;
                }
            }

            
            foreach (string t in table) {
                if (!aggiornaDB(t)) {
                    show("Errore nel cambio delle chiavi esterne riferite alla tabella " + t, "Errore");
                    azzeraDataSet();
                    return;
                }
            }
            if (!aggiornaDB("config")) {
                show("Errore nel cambio delle chiavi esterne riferite alla tabella CONFIG", "Errore");
                azzeraDataSet();
                return;
            }

            show(this, "Uniformazione dati completata", "Ok");
        }

        public bool verificaSeChiamareFormRiepilogo() {
            foreach (DataTable t in dsLookUp.Tables) {
                if (t.Select(QHC.IsNotNull("!linkedcode")).Length > 0) return true;
            }

            return false;
        }

        private bool aggiornaDB(string tName) {
            StringBuilder SB = new StringBuilder();
            if (tName == "config") {
                // A differenza delle altre tabelle CONFIG viene inserita o aggiornata.
                // L'aggiornamento vinee fatto solo sui campi relativi al patrimonio
                string assetsetup_fields = "assetload_flag, asset_flagnumbering, asset_flagrestart";
                string[] listaCampi = new string[] { "assetload_flag", "asset_flagnumbering", "asset_flagrestart" };
                foreach (DataRow rAssetSetup in dsFile.Tables["config"].Rows) {
                    string filtro = QHS.CmpEq("ayear", rAssetSetup["ayear"]);
                    int nRow = Meta.Conn.RUN_SELECT_COUNT("config", filtro, true);
                    if (nRow > 0) {
                        string queryAssetSetup = "UPDATE config SET ";
                        string u = "";
                        foreach (string fName in listaCampi) {
                            u += fName + " = " + QHS.quote(rAssetSetup[fName]) + ",";
                        }
                        u = u.Substring(0, u.Length - 2);
                        queryAssetSetup += u + " WHERE " + QHS.CmpEq("ayear", rAssetSetup["ayear"]);
                        SB.Append(queryAssetSetup);
                    }
                    else {
                        string fieldForInsert = "ayear," + assetsetup_fields;
                        string sqlInsert = "INSERT INTO config (" + fieldForInsert + ") VALUES (";
                        string values = GeneraSQL.GetSQLDataValues(rAssetSetup);
                        sqlInsert += values;
                        SB.Append(sqlInsert);
                    }
                }
            }
            else {
                string f_id;
                string f_code;
                string f_descr;
                ottieniCampiTabella(tName, out f_id, out f_code, out f_descr);
                if ((f_id == "") || (f_code == "") || (f_descr == "")) {
                    return false;
                }

                string[] tLinked = ottieniElencoTabelleCollegate(tName);
                // Parte UPDATE delle chiavi esterne e DELETE delle righe che non devono esserci nel DB del dipartimento
                foreach (DataRow r in dsLookUp.Tables[tName].Rows) {
                    if ((r["!linkedcode"] == DBNull.Value) || (r["!linkedcode"].ToString() == "")) continue;
                    foreach (string tabella in tLinked) {
                        if ((tabella == null) || (tabella == "")) continue;
                        string valore_codice_db = r[f_code].ToString();
                        string valore_codice_ds = r["!linkedcode"].ToString();
                        if (valore_codice_db != valore_codice_ds) {
                            string sqlUpdate =
                            "UPDATE " + tabella + " SET " + f_id + " = " + QueryCreator.quotedstrvalue(r["!linkedid"], true)
                            + " WHERE " + f_id + " = " + QueryCreator.quotedstrvalue(r[f_id], true) + "\n\r";
                            SB.Append(sqlUpdate);
                        }
                    }
                    string sqlDelete = "DELETE FROM " + tName + " WHERE " + f_id + " = " + QueryCreator.quotedstrvalue(r[f_id], true) + "\n\r";
                    SB.Append(sqlDelete);
                    if (SB.ToString() != "") {
                        SB.Append("GO\n\r");
                    }
                }

                // Parte delle INSERT delle righe assenti nel DB del dipartimento
                string fields = "";
                foreach (DataColumn c in dsPruned.Tables[tName].Columns) {
                    fields += c.ColumnName + ",";
                }

                fields = fields.Remove(fields.Length - 1, 1);

                foreach (DataRow rDS in dsPruned.Tables[tName].Rows) {
                    string filter = QueryCreator.WHERE_KEY_CLAUSE(rDS, DataRowVersion.Current, false);
                    if (dsLookUp.Tables[tName].Select(filter).Length > 0) continue;
                    string sqlInsert = "INSERT INTO " + tName + "(" + fields + ") VALUES (";
                    string values = GeneraSQL.GetSQLDataValues(rDS);
                    sqlInsert += values;

                    SB.Append(sqlInsert);
                }
            }
            if (SB.ToString() != "") {
                SB.Append("GO\n\r");

                string error;
                return Download.RUN_SCRIPT(Meta.Conn, SB, out error);
            }
            return true;
        }

        private bool verificaEUniformaTabelle(string tName, string filterOnDs) {
            DataTable tDB = DataAccess.CreateTableByName(Meta.Conn, tName, "*");
            tDB.Columns.Add("!linked");
            tDB.Columns.Add("!linkedid");
            tDB.Columns.Add("!linkedcode");
            tDB.Columns.Add("!linkeddescr");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tDB, null, null, null, true);

            string[] tLinked = ottieniElencoTabelleCollegate(tName);
            string id_field;
            string code_field;
            string descr_field;
            ottieniCampiTabella(tName, out id_field, out code_field, out descr_field);
            if ((id_field == "") || (code_field == "") || (descr_field == "")) {
                return false;
            }

            DataTable tDS = DataAccess.CreateTableByName(Meta.Conn, tName, "*");
            if (filterOnDs != "") {
                tDS.Clear();
                foreach (DataRow rDsFile in dsFile.Tables[tName].Select(filterOnDs)) {
                    DataRow rDS = tDS.NewRow();
                    foreach (DataColumn c in dsFile.Tables[tName].Columns) {
                        rDS[c.ColumnName] = rDsFile[c.ColumnName];
                    }
                    tDS.Rows.Add(rDS);
                }
            }
            else {
                foreach (DataRow rDsFile in dsFile.Tables[tName].Rows) {
                    DataRow rDS = tDS.NewRow();
                    foreach (DataColumn c in dsFile.Tables[tName].Columns) {
                        rDS[c.ColumnName] = rDsFile[c.ColumnName];
                    }
                    tDS.Rows.Add(rDS);
                }
            }

            tDS.AcceptChanges();
            dsPruned.Tables.Add(tDS);

            foreach (DataRow rDB in tDB.Rows) {
                string filter = QHC.CmpEq(code_field, rDB[code_field]);
                string filterKey = QHC.CmpEq(id_field, rDB[id_field]);
                DataRow[] RowInDS = tDS.Select(filter);
                if (RowInDS.Length > 0) continue;
                foreach (string tabella in tLinked) {
                    if ((tabella == null) || (tabella == "")) continue;
                    int nRow = Meta.Conn.RUN_SELECT_COUNT(tabella, filterKey, true);
                    if (((rDB["!linked"] == DBNull.Value) || (rDB["!linked"].ToString().ToUpper() == "N")) && (nRow > 0)) {
                        rDB["!linked"] = "S";
                        AskObject ao = new AskObject(rDB[code_field].ToString(), rDB[descr_field].ToString(), id_field, descr_field, tDS);
                        createForm(ao, null);
                        DialogResult dr = ao.ShowDialog();
                        if (dr != DialogResult.OK) {
                            show(this, "Look up non impostato");
                            return false;
                        }
                        object idSelected = ao.cmbObject.SelectedValue; 
                        rDB["!linkedid"] = idSelected;
                        rDB["!linkedcode"] = tDS.Select(QHC.CmpEq(id_field, idSelected))[0][code_field];
                        rDB["!linkeddescr"] = ao.cmbObject.Text;
                        break;
                    }
                }
            }
            dsLookUp.Tables.Add(tDB);
            return true;
        }

        private void ottieniCampiTabella(string tName, out string id, out string code, out string description) {
            id = "";
            code = "";
            description = "";
            switch (tName) {
                case "assetloadmotive": {
                        id = "idmot";
                        code = "codemot";
                        description = "description";
                        break;
                    }
                case "assetunloadmotive": {
                        id = "idmot";
                        code = "codemot";
                        description = "description";
                        break;
                    }
                case "assetloadkind": {
                        id = "idassetloadkind";
                        code = "codeassetloadkind";
                        description = "description";
                        break;
                    }
                case "assetunloadkind": {
                        id = "idassetunloadkind";
                        code = "codeassetunloadkind";
                        description = "description";
                        break;
                    }
                case "inventory": {
                        id = "idinventory";
                        code = "codeinventory";
                        description = "description";
                        break;
                    }
                case "inventorykind": {
                        id = "idinventorykind";
                        code = "codeinventorykind";
                        description = "description";
                        break;
                    }
                case "assetusagekind": {
                        id = "idassetusagekind";
                        code = "codeassetusagekind";
                        description = "description";
                        break;
                    }
                case "inventoryamortization": {
                        id = "idinventoryamortization";
                        code = "codeinventoryamortization";
                        description = "description";
                        break;
                    }
                case "inventoryagency": {
                        id = "idinventoryagency";
                        code = "codeinventoryagency";
                        description = "description";
                        break;
                    }
                default: {
                        show(this, "Tabella non esistente " + tName, "Errore");
                        break;
                    }
            }
        }

        private string[] ottieniElencoTabelleCollegate(string tName) {
            string[] tLinked = new string[10];
            int rank = 0;
            switch (tName) {
                case "assetloadmotive": {
                        tLinked.SetValue("assetload", rank++);
                        tLinked.SetValue("assetacquire", rank++);
                        break;
                    }
                case "assetunloadmotive": {
                        tLinked.SetValue("assetunload", rank++);
                        break;
                    }
                case "assetloadkind": {
                        tLinked.SetValue("assetload", rank++);
                        tLinked.SetValue("assetacquire", rank++);
                        tLinked.SetValue("assetloadexpense", rank++);
                        break;
                    }
                case "assetunloadkind": {
                        tLinked.SetValue("assetunload", rank++);
                        tLinked.SetValue("asset", rank++);
                        tLinked.SetValue("assetamortization", rank++);
                        break;
                    }
                case "inventory": {
                        tLinked.SetValue("assetloadkind", rank++);
                        tLinked.SetValue("assetunloadkind", rank++);
                        break;
                    }
                case "assetusagekind": {
                        tLinked.SetValue("assetusage", rank++);
                        break;
                    }
                case "inventorykind": {
                        tLinked.SetValue("inventory", rank++);
                        break;
                    }
                case "inventoryamortization": {
                        tLinked.SetValue("assetamortization", rank++);
                        break;
                    }
                case "inventoryagency": {
                        tLinked.SetValue("inventory", rank++);
                        tLinked.SetValue("assetconsignee", rank++);
                        tLinked.SetValue("assetvar", rank++);
                        break;
                    }
                default: {
                        show(this, "Tabella non esistente " + tName, "Errore");
                        break;
                    }
            }
            return tLinked;
        }

        private bool fillDsDaFile() {
            try {
                FileStream fs = (FileStream)openFileDialog1.OpenFile();
                dsFile.ReadXml(fs);
                fs.Close();
            }
            catch (Exception) {
                show(this, "Errore nell'apertura del file! Processo Terminato");
                return false;
            }
            return true;
        }

    }
}
