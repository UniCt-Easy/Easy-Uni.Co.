
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
using System.IO;
using metadatalibrary;
using System.Collections;
using funzioni_configurazione;

namespace assetacquire_import {
    public partial class FrmAssetAcquire_Import : Form {
        MetaData Meta;
        DataSet dsFile;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmAssetAcquire_Import() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            ClearDataSet.RemoveConstraints(dsImporta);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterActivation() {
            if (this.Text.EndsWith("(Ricerca)")){
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        public void MetaData_AfterClear() {
            if (this.Text.EndsWith("(Ricerca)")){
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        public object ottieniIdEnte(object codiceEnte) {
            if (codiceEnte == null) return null;

            return Meta.Conn.DO_READ_VALUE("inventoryagency", "", "idinventoryagency");
        }

        int nPassi = 14;

        private void btnImporta_Click(object sender, EventArgs e) {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = nPassi;

            if (txtFolder.Text == "") {
                MessageBox.Show(this, "Non è stata scelta la cartella dove verrà salvato il file di log", "Errore");
                return;
            }

            dsFile = new DataSet();
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) return;

            try {
                FileStream fs = (FileStream)openFileDialog1.OpenFile();
                dsFile.ReadXml(fs);
                fs.Close();
                string testo = "Apertura del File";
                aggiornaForm(testo);
            }
            catch (Exception) {
                MessageBox.Show(this, "Errore nell'apertura del file! Processo Terminato");
                return;
            }
            string codiceEnte = openFileDialog1.FileName;

            int ultimoBackSlash = codiceEnte.LastIndexOf("\\");
            codiceEnte = codiceEnte.Substring(ultimoBackSlash + 1);
            codiceEnte = codiceEnte.Substring(0, codiceEnte.Length - 4);

            object idEnte = ottieniIdEnte(codiceEnte);

            if ((idEnte == null) || (idEnte == DBNull.Value)) {
                MessageBox.Show(this, "Non esiste alcun ente inventariale con codice " + codiceEnte);
                return;
            }

            aggiungiCampiTemporanei();

            popolaTabelleLookup();

            // Metodi che aggiornano le tabelle importate con i valori che dovranno assumere
            // sul DB dell'amministrazione centrale
            if (!assegnaCodiceAnagrafica()) {
                MessageBox.Show(this, "Errore nell'assegnazione dei codici anagrafici");
                return;
            }

            // Attenzione! Essendo cambiata la chiave del buono di carico, devo calcolarlo subito
            // in quanto è chiave esterna x le altre tabelle
            if (!assegnaValoriBuonoCarico()) {
                MessageBox.Show(this, "Errore nell'assegnazione dei buoni di carico");
                return;
            }

            if (!assegnaValoriBuonoScarico()) {
                MessageBox.Show(this, "Errore nell'assegnazione dei buoni di scarico");
                return;
            }

            if (!assegnaValoriCaricoBene()) {
                MessageBox.Show(this, "Errore nell'assegnazione dei carichi cespiti");
                return;
            }
            if (!assegnaValoriBeniRimanenti()) {
                MessageBox.Show(this, "Errore nell'assegnazione dei cespiti rimanenti");
                return;
            }

            if (!assegnaValoriRivalutazioneBene()) {
                MessageBox.Show(this, "Errore nell'assegnazione delle rivalutazioni/svalutazioni dei cespiti");
                return;
            }

            // Processo di Travaso dei dati
            if (!travasaIDatiInAmminCentrale(codiceEnte)) return;
            saveData();
        }

        private void aggiungiCampiTemporanei() {
            string testo = "Aggiunta campi temporanei";
            aggiornaForm(testo);
            // 1. REGISTRY
            if (dsFile.Tables.Contains("registry")) {
                dsFile.Tables["registry"].Columns.Add("idreg_ac", typeof(int));
            }
            // 2. ASSETACQUIRE
            if (dsFile.Tables.Contains("assetacquire")) {
                dsFile.Tables["assetacquire"].Columns.Add("nassetacquire_ac", typeof(int));
                dsFile.Tables["assetacquire"].Columns.Add("idreg_ac", typeof(int));
                dsFile.Tables["assetacquire"].Columns.Add("idassetload_ac", typeof(int));
                dsFile.Tables["assetacquire"].Columns.Add("idinventory_ac", typeof(int));
                dsFile.Tables["assetacquire"].Columns.Add("idinv_ac", typeof(int));
                dsFile.Tables["assetacquire"].Columns.Add("idmot_ac", typeof(int));
            }
            // 3. ASSET
            if (dsFile.Tables.Contains("asset")) {
                dsFile.Tables["asset"].Columns.Add("idasset_ac", typeof(int));
                dsFile.Tables["asset"].Columns.Add("idpiece_ac", typeof(int));
                dsFile.Tables["asset"].Columns.Add("idinventory_ac", typeof(int));
                dsFile.Tables["asset"].Columns.Add("nassetacquire_ac", typeof(int));
                dsFile.Tables["asset"].Columns.Add("idassetunload_ac", typeof(int));
            }
            // 4.ASSETAMORTIZATION
            if (dsFile.Tables.Contains("assetamortization")) {
                dsFile.Tables["assetamortization"].Columns.Add("namortization_ac", typeof(int));
                dsFile.Tables["assetamortization"].Columns.Add("idasset_ac", typeof(int));
                dsFile.Tables["assetamortization"].Columns.Add("idpiece_ac", typeof(int));
                dsFile.Tables["assetamortization"].Columns.Add("idassetunload_ac", typeof(int));
                dsFile.Tables["assetamortization"].Columns.Add("idinventory_ac", typeof(int));
                dsFile.Tables["assetamortization"].Columns.Add("idinventoryamortization_ac", typeof(int));
            }
            // 5. ASSETLOAD
            if (dsFile.Tables.Contains("assetload")) {
                dsFile.Tables["assetload"].Columns.Add("idreg_ac", typeof(int));
                dsFile.Tables["assetload"].Columns.Add("idassetload_ac", typeof(int));
                dsFile.Tables["assetload"].Columns.Add("idassetloadkind_ac", typeof(int));
                dsFile.Tables["assetload"].Columns.Add("idmot_ac", typeof(int));
            }
            // 6. ASSETUNLOAD
            if (dsFile.Tables.Contains("assetunload")) {
                dsFile.Tables["assetunload"].Columns.Add("idreg_ac", typeof(int));
                dsFile.Tables["assetunload"].Columns.Add("idassetunload_ac", typeof(int));
                dsFile.Tables["assetunload"].Columns.Add("idassetunloadkind_ac", typeof(int));
                dsFile.Tables["assetunload"].Columns.Add("idmot_ac", typeof(int));
            }
        }

        DataTable tInventory;
        DataTable tAssetLoadKind;
        DataTable tAssetUnloadKind;
        DataTable tInventoryAmortization;
        DataTable tAssetLoadMotive;
        DataTable tAssetUnloadMotive;
        DataTable tInventoryTree;

        Hashtable hInventory = new Hashtable();
        Hashtable hAssetLoadKind = new Hashtable();
        Hashtable hAssetUnloadKind = new Hashtable();
        Hashtable hInventoryAmortization = new Hashtable();
        Hashtable hAssetLoadMotive = new Hashtable();
        Hashtable hAssetUnloadMotive = new Hashtable();
        Hashtable hInventoryTree = new Hashtable();

        private void popolaTabelleLookup() {
            tInventory = DataAccess.CreateTableByName(Meta.Conn, "inventory", "idinventory, codeinventory");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventory, null, null, null, true);

            tAssetLoadKind = DataAccess.CreateTableByName(Meta.Conn, "assetloadkind",
                "idassetloadkind, codeassetloadkind, startnumber");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAssetLoadKind, null, null, null, true);

            tAssetUnloadKind = DataAccess.CreateTableByName(Meta.Conn, "assetunloadkind",
                "idassetunloadkind, codeassetunloadkind");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAssetUnloadKind, null, null, null, true);

            tInventoryAmortization = DataAccess.CreateTableByName(Meta.Conn, "inventoryamortization",
                "idinventoryamortization, codeinventoryamortization");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventoryAmortization, null, null, null, true);

            tAssetLoadMotive = DataAccess.CreateTableByName(Meta.Conn, "assetloadmotive", "idmot, codemot");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAssetLoadMotive, null, null, null, true);

            tAssetUnloadMotive = DataAccess.CreateTableByName(Meta.Conn, "assetunloadmotive", "idmot, codemot");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAssetUnloadMotive, null, null, null, true);

            // Per via della dimensione della tabella verrà riempita volta x volta
            tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "idinv, codeinv");
        }

        private object isNull(object a, object b) {
            if ((a == null) || (a == DBNull.Value)) return b;
            return a;
        }

        #region ASSEGNAZIONE CODICI
        /// <summary>
        /// Metodo che assegna l'idreg dell'A.C. alla tabella dell'anagrafica
        /// </summary>
        private bool assegnaCodiceAnagrafica() {
            string testo = "Assegnazione codice anagrafica";
            aggiornaForm(testo);
            if (!dsFile.Tables.Contains("registry")) return true;
            object maxIdRegDB = Meta.Conn.DO_READ_VALUE("registry", null, "MAX(idreg)");
            object maxIdRegDS = dsFile.Tables["registry"].Compute("MAX(idreg_ac)", null);

            int primoCodiceLibero = 1 + getMaxValue(maxIdRegDB, maxIdRegDS);

            foreach (DataRow R in dsFile.Tables["registry"].Rows) {
                string filtro = "(title = "
                    + QueryCreator.quotedstrvalue(R["title"], false) + ")";

                if (dsImporta.Tables["registry"].Select(filtro).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["registry"], null, filtro, null, true);
                }

                DataRow[] CreditoreAmmCentr = dsImporta.Tables["registry"].Select(filtro);

                if (CreditoreAmmCentr.Length == 0) {
                    R["idreg_ac"] = primoCodiceLibero;
                    primoCodiceLibero++;
                }
                else {
                    R["idreg_ac"] = CreditoreAmmCentr[0]["idreg"];
                }
            }
            return true;
        }

        private object ottieniIdInventory(object codeInventory) {
            if (hInventory[codeInventory] != null) {
                return hInventory[codeInventory];
            }
            else {
                string f = QHC.CmpEq("codeinventory", codeInventory);
                if (tInventory.Select(f).Length > 0) {
                    DataRow rInventory = tInventory.Select(f)[0];
                    hInventory[codeInventory] = rInventory["idinventory"];
                    return hInventory[codeInventory];
                }
            }
            return null;
        }

        private object ottieniIdMotiveLoad(object codeMot) {
            if (hAssetLoadMotive[codeMot] != null) {
                return hAssetLoadMotive[codeMot];
            }
            else {
                string f = QHC.CmpEq("codemot", codeMot);
                if (tAssetLoadMotive.Select(f).Length > 0) {
                    DataRow rAssetLoadMotive = tAssetLoadMotive.Select(f)[0];
                    hAssetLoadMotive[codeMot] = rAssetLoadMotive["idmot"];
                    return hAssetLoadMotive[codeMot];
                }
            }
            return null;
        }

        private object ottieniIdMotiveUnload(object codeMot) {
            if (hAssetUnloadMotive[codeMot] != null) {
                return hAssetUnloadMotive[codeMot];
            }
            else {
                string f = QHC.CmpEq("codemot", codeMot);
                if (tAssetUnloadMotive.Select(f).Length > 0) {
                    DataRow rAssetUnloadMotive = tAssetUnloadMotive.Select(f)[0];
                    hAssetUnloadMotive[codeMot] = rAssetUnloadMotive["idmot"];
                    return hAssetUnloadMotive[codeMot];
                }
            }
            return null;
        }

        private object ottieniIdAssetLoad(object codeAssetLoadKind) {
            if (hAssetLoadKind[codeAssetLoadKind] != null) {
                return hAssetLoadKind[codeAssetLoadKind];
            }
            else {
                string f = QHC.CmpEq("codeassetloadkind", codeAssetLoadKind);
                if (tAssetLoadKind.Select(f).Length > 0) {
                    DataRow rAssetLoadKind = tAssetLoadKind.Select(f)[0];
                    hAssetLoadKind[codeAssetLoadKind] = rAssetLoadKind["idassetloadkind"];
                    return hAssetLoadKind[codeAssetLoadKind];
                }
            }
            return null;
        }

        private object ottieniIdAssetUnload(object codeAssetUnloadKind) {
            if (hAssetUnloadKind[codeAssetUnloadKind] != null) {
                return hAssetUnloadKind[codeAssetUnloadKind];
            }
            else {
                string f = QHC.CmpEq("codeassetunloadkind", codeAssetUnloadKind);
                if (tAssetUnloadKind.Select(f).Length > 0) {
                    DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                    hAssetUnloadKind[codeAssetUnloadKind] = rAssetUnloadKind["idassetunloadkind"];
                    return hAssetUnloadKind[codeAssetUnloadKind];
                }
            }
            return null;
        }

        private object ottieniIdInventoryAmortization(object codeInventoryAmortization) {
            if (hInventoryAmortization[codeInventoryAmortization] != null) {
                return hInventoryAmortization[codeInventoryAmortization];
            }
            string f = QHC.CmpEq("codeinventoryamortization", codeInventoryAmortization);
            if (tInventoryAmortization.Select(f).Length > 0) {
                DataRow rInventoryAmortization = tInventoryAmortization.Select(f)[0];
                hInventoryAmortization[codeInventoryAmortization] = rInventoryAmortization["idinventoryamortization"];
                return hInventoryAmortization[codeInventoryAmortization];
            }
            return null;
        }
        /// <summary>
        /// Metodo che assegna il numero carico bene dell'Amministrazione Centrale 
        /// ai carichi provenienti dal dipartimento
        /// </summary>
        private bool assegnaValoriCaricoBene() {
            string testo = "Assegnazione valori al carico cespite";
            aggiornaForm(testo);
            if (!dsFile.Tables.Contains("assetacquire")) return true;

            object maxNAssetAcquireDB = Meta.Conn.DO_READ_VALUE("assetacquire", null, "MAX(nassetacquire)");
            object maxNAssetAcquireDS = dsFile.Tables["assetacquire"].Compute("MAX(nassetacquire_ac)", null);
            int nCaricoLibero = 1 + getMaxValue(maxNAssetAcquireDB, maxNAssetAcquireDS);
            int nCiclo = 0;
            ArrayList elencoAccessori = new ArrayList();
            foreach (DataRow rCaricoDip in dsFile.Tables["assetacquire"].Rows) {
                nCiclo++;
                if ((nCiclo % 100) == 0) {
                    Application.DoEvents();
                }
                if (rCaricoDip["idinventory"] != DBNull.Value) {
                    object idInventory = ottieniIdInventory(rCaricoDip["!codeinventory"]);
                    if (idInventory != null) {
                        rCaricoDip["idinventory_ac"] = idInventory;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Carico Cespite\nCodifica dell'inventario assente");
                        return false;
                    }
                }

                if (rCaricoDip["idinv"] != DBNull.Value) {
                    object idInv = ricavaNodoInventoryTree(rCaricoDip["!codeinv"]);
                    if (idInv != null) {
                        rCaricoDip["idinv_ac"] = idInv;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Carico Cespite\nCodifica della class. inventariale assente");
                        return false;
                    }
                }

                if (rCaricoDip["idmot"] != DBNull.Value) {
                    object idMot = ottieniIdMotiveLoad(rCaricoDip["!codemot"]);
                    if (idMot != null) {
                        rCaricoDip["idmot_ac"] = idMot;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Carico Cespite\nCodifica della causale assente");
                        return false;
                    }
                }

                if (rCaricoDip["idassetload"] != DBNull.Value) {
                    object idassetloadkind = ottieniIdAssetLoad(rCaricoDip["!codeassetloadkind"]);
                    if (idassetloadkind != null) {
                        DataRow rBuono = leggiBuonoCarico(idassetloadkind,
                            rCaricoDip["!yassetload"], rCaricoDip["!nassetload"]);
                        if (rBuono != null) {
                            rCaricoDip["idassetload_ac"] = rBuono["idassetload"];
                        }
                        else {
                            MessageBox.Show(this, "Sezione Carico Cespite\nCodifica del buono di carico assente");
                            return false;
                        }
                    }
                    else {
                        MessageBox.Show(this, "Sezione Carico Cespite\nCodifica del buono di carico assente");
                        return false;
                    }
                }

                int flag = CfgFn.GetNoNullInt32(rCaricoDip["flag"]);

                if ((flag & 0x4) != 0) {
                    elencoAccessori.Add(rCaricoDip);
                    continue;
                }

                string filtro = QHC.AppAnd(QHC.CmpEq("idinventory", rCaricoDip["idinventory_ac"]),
                    QHC.MCmp(rCaricoDip, new string[] { "number", "startnumber" }));
                string filtroSQL = QHS.AppAnd(QHS.CmpEq("idinventory", rCaricoDip["idinventory_ac"]),
                    QHS.MCmp(rCaricoDip, new string[] { "number", "startnumber" }));

                if (dsImporta.Tables["assetacquire"].Select(filtro).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetacquire"],
                        null, filtroSQL, null, true);
                }

                DataRow[] rCaricoBeneAC = dsImporta.Tables["assetacquire"].Select(filtro);

                if (rCaricoBeneAC.Length == 0) {
                    rCaricoDip["nassetacquire_ac"] = nCaricoLibero;
                    nCaricoLibero++;

                    if (!assegnaValoriBeneDaCaricoNuovo(rCaricoDip)) {
                        MessageBox.Show(this, "Errore nell'assegnazione del carico cespite ai cespiti dipendenti",
                            "Errore");
                        return false;
                    }
                }
                else {
                    int nCaricoBeneAC = CfgFn.GetNoNullInt32(isNull(rCaricoBeneAC[0]["nassetacquire"], 0));
                    rCaricoDip["nassetacquire_ac"] = nCaricoBeneAC;

                    int nCaricoDip = CfgFn.GetNoNullInt32(isNull(rCaricoDip["nassetacquire"], 0));
                    if (!assegnaValoriBeneDaCarico(nCaricoBeneAC, nCaricoDip)) {
                        MessageBox.Show(this, "Errore nell'assegnazione del numero di carico al cespite associato",
                            "Errore");
                        return false;
                    }
                }

                if ((dsFile.Tables["assetacquire"].Columns.Contains("idreg"))
                    && (rCaricoDip["idreg"] != DBNull.Value)) {
                    string filtroCred = QHC.CmpEq("idreg", rCaricoDip["idreg"]);
                    DataRow[] Creditore = dsFile.Tables["registry"].Select(filtroCred);
                    if (Creditore.Length > 0) {
                        DataRow rCreditore = Creditore[0];
                        rCaricoDip["idreg_ac"] = rCreditore["idreg_ac"];
                    }
                }
            }

            nCiclo = 0;
            foreach (DataRow rCaricoInElenco in elencoAccessori) {
                nCiclo++;
                if ((nCiclo % 100) == 0) {
                    Application.DoEvents();
                }
                int nAssetAcquire = CfgFn.GetNoNullInt32(rCaricoInElenco["nassetacquire"]);

                string f1 = QHC.CmpEq("nassetacquire", nAssetAcquire);
                DataRow rCaricoDip = dsFile.Tables["assetacquire"].Select(f1)[0];
                if (!valorizzaNAssetAcquireAccessorio(rCaricoDip)) {
                    rCaricoDip["nassetacquire_ac"] = nCaricoLibero;
                    nCaricoLibero++;
                }

                if ((dsFile.Tables["assetacquire"].Columns.Contains("idreg")) && (rCaricoInElenco["idreg"] != DBNull.Value)) {
                    string filtroCred = QHC.CmpEq("idreg", rCaricoInElenco["idreg"]);
                    DataRow[] Creditore = dsFile.Tables["registry"].Select(filtroCred);
                    if (Creditore.Length > 0) {
                        DataRow rCreditore = Creditore[0];
                        rCaricoDip["idreg_ac"] = rCreditore["idreg_ac"];
                    }
                }
            }
            return true;
        }

        private object ricavaNodoInventoryTree(object tempCodeInv) {
            if (hInventoryTree[tempCodeInv] != null) {
                return hInventoryTree[tempCodeInv];
            }
            else {
                string f = QHC.CmpEq("codeinv", tempCodeInv);
                string fSQL = QHS.CmpEq("codeinv", tempCodeInv);
                if (tInventoryTree.Select(f).Length > 0) {
                    DataRow rInventoryTree = tInventoryTree.Select(f)[0];
                    hInventoryTree[tempCodeInv] = rInventoryTree["idinv"];
                    return hInventoryTree[tempCodeInv];
                }
                else {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventoryTree, null, fSQL, null, true);
                    if (tInventoryTree.Select(f).Length > 0) {
                        DataRow rInventoryTree = tInventoryTree.Select(f)[0];
                        hInventoryTree[tempCodeInv] = rInventoryTree["idinv"];
                        return hInventoryTree[tempCodeInv];
                    }
                }
            }
            return null;
        }

        private bool assegnaValoriBeneDaCaricoNuovo(DataRow rCaricoDip) {
            if (!dsFile.Tables.Contains("asset")) return true;
            int nassetacquireac = CfgFn.GetNoNullInt32(rCaricoDip["nassetacquire_ac"]);
            int idinventory = CfgFn.GetNoNullInt32(rCaricoDip["idinventory_ac"]);
            if (nassetacquireac == 0) return false;
            
            object maxIdAssetDB = Meta.Conn.DO_READ_VALUE("asset", null, "MAX(idasset)");
            object maxIdAssetDS = dsFile.Tables["asset"].Compute("MAX(idasset_ac)", null);

            int idBeneLibero = 1 + getMaxValue(maxIdAssetDB, maxIdAssetDS);

            string filtro = QHC.CmpEq("nassetacquire", rCaricoDip["nassetacquire"]);

            foreach (DataRow rCespite in dsFile.Tables["asset"].Select(filtro)) {
                rCespite["nassetacquire_ac"] = nassetacquireac;
                rCespite["idinventory"] = idinventory;
                rCespite["idasset_ac"] = idBeneLibero;
                rCespite["idpiece_ac"] = rCespite["idpiece"];

                if (rCespite["idassetunload"] != DBNull.Value) {
                    string f = QHC.CmpEq("codeassetunloadkind", rCespite["codeassetunloadkind"]);
                    if (tAssetUnloadKind.Select(f).Length > 0) {
                        DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                        DataRow rBuono = leggiBuonoScarico(rAssetUnloadKind["idassetunloadkind"],
                            rCespite["yassetunload"], rCespite["nassetunload"]);
                        if (rBuono != null) {
                            rCespite["idassetunload_ac"] = rBuono["idassetunload"];
                        }
                    }
                }

                idBeneLibero++;
            }

            return true;
        }

        private bool valorizzaNAssetAcquireAccessorio(DataRow rCaricoDip) {
            int nAssetAcquire = (int)isNull(rCaricoDip["nassetacquire"], 0);
            string filtro = QHC.CmpEq("nassetacquire", nAssetAcquire);

            DataRow [] ACCESSORI = dsFile.Tables["asset"].Select(filtro);

            string filtroSuCespite = "";
            string idpiece = "";
            foreach (DataRow rAcc in ACCESSORI) {

                filtroSuCespite = QHC.AppAnd(QHC.CmpEq("idasset", rAcc["idasset"]),
                QHC.CmpEq("idpiece", 1));

                idpiece = QueryCreator.quotedstrvalue(rAcc["idpiece"], false);
                // Il cespite principale o sta su DataSet o sta sul DB
                DataRow[] CESPITE = dsFile.Tables["asset"].Select(filtroSuCespite);
                object idAssetMain = null;
                if (CESPITE.Length > 0) {
                    if (CESPITE[0]["idasset_ac"] == DBNull.Value) continue;
                    idAssetMain = CESPITE[0]["idasset_ac"];
                }
                else {
                    string filtroSuInventory = QHS.AppAnd(QHS.CmpEq("idinventory", rAcc["idinventory_ac"]),
                    QHS.CmpEq("ninventory", rAcc["ninventory"]));

                    idAssetMain = Meta.Conn.DO_READ_VALUE("asset", filtroSuInventory, "idasset");
                }

                if ((idAssetMain == null) || (idAssetMain == DBNull.Value)) continue;

                string f = QHS.AppAnd(QHS.CmpEq("idasset", idAssetMain), QHS.CmpEq("idpiece", idpiece));
                    
                // SUL DB di destinazione qual è l'nassetacquire????
                object nAssetAcquireCurr = Meta.Conn.DO_READ_VALUE("asset", f, "nassetacquire");
                if (CfgFn.GetNoNullInt32(nAssetAcquireCurr) != 0) {
                    string fAssAcq = QHS.CmpEq("nassetacquire", nAssetAcquireCurr);
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetacquire"],
                        null, fAssAcq, null, true);
                    rCaricoDip["nassetacquire_ac"] = nAssetAcquireCurr;
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Metodo che assegna l'idbene dell'amministrazione centrale ai beni
        /// il cui carico è già presente nell'archivio dell'Amministrazione Centrale
        /// </summary>
        /// <param name="nCaricoBeneAC">Numero del carico bene</param>
        private bool assegnaValoriBeneDaCarico(int nCaricoBeneAC, int nCaricoBeneDip) {
            if (!dsFile.Tables.Contains("asset")) return true;
            string filtro = QHC.CmpEq("nassetacquire", nCaricoBeneAC);
            string filtroSQL = QHS.CmpEq("nassetacquire", nCaricoBeneAC);
           
            if (dsImporta.Tables["asset"].Select(filtro).Length == 0) {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["asset"], null, filtroSQL, null, true);
            }

            DataRow[] BeniAC = dsImporta.Tables["asset"].Select(filtro);

            foreach (DataRow rBeneAC in BeniAC) {
                string filtroBeneDip = QHC.CmpEq("nassetacquire", nCaricoBeneDip);
                DataRow[] Bene = dsFile.Tables["asset"].Select(filtroBeneDip);
                if (Bene.Length == 0) continue;
                foreach (DataRow rBene in Bene) {
                    rBene["idasset_ac"] = rBeneAC["idasset"];
                    rBene["idpiece_ac"] = rBene["idpiece"];
                    rBene["nassetacquire_ac"] = nCaricoBeneAC;

                    if (rBene["idassetunload"] != DBNull.Value) {
                        string f = QHC.CmpEq("codeassetunloadkind", rBene["codeassetunloadkind"]);
                        if (tAssetUnloadKind.Select(f).Length > 0) {
                            DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                            DataRow rBuono = leggiBuonoScarico(rAssetUnloadKind["idassetunloadkind"],
                                rBene["yassetunload"], rBene["nassetunload"]);
                            if (rBuono != null) {
                                rBene["idassetunload_ac"] = rBuono["idassetunload"];
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool assegnaValoriBeniRimanenti() {
            string testo = "Assegnazione valori ai cespiti e accessori restanti";
            aggiornaForm(testo);
            if (!dsFile.Tables.Contains("asset")) return true;
            object maxIdAssetDB = Meta.Conn.DO_READ_VALUE("asset", null, "MAX(idasset)");
            object maxIdAssetDS = dsFile.Tables["asset"].Compute("MAX(idasset_ac)", null);
            
            int idBeneLibero = 1 + getMaxValue(maxIdAssetDB, maxIdAssetDS);
            int nCiclo = 0;
            foreach (DataRow rBene in dsFile.Tables["asset"].Rows) {
                nCiclo++;
                if ((nCiclo % 100) == 0) Application.DoEvents();
                if (rBene["idasset_ac"] != DBNull.Value) continue;

                if (rBene["!codeinventory"] != DBNull.Value) {
                    object idInventory = ottieniIdInventory(rBene["!codeinventory"]);
                    if (idInventory != null) {
                        rBene["idinventory_ac"] = idInventory;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Cespite\nCodifica dell'inventario assente");
                        return false;
                    }
                }


                int numAccessorio = CfgFn.GetNoNullInt32(rBene["idpiece"]);
                // Se ho un accessorio cerco nel dataset di input se c'é anche il cespite principale. Nel caso ci sia
                // prendo l'idasset_ac del cespite principale altrimenti cercherò nel DB se esiste quell'accessorio
                // Se esiste nel DB prendo l'idasset dal DB altrimenti ne assegno uno nuovo

                // Interrogazione del DataSet
                if (numAccessorio > 1) {
                    string fMain = QHC.AppAnd(QHC.CmpEq("idasset", rBene["idasset"]), QHC.CmpEq("idpiece", 1));
                    if (dsFile.Tables["asset"].Select(fMain).Length > 0) {
                        DataRow rCespitePrincipale = dsFile.Tables["asset"].Select(fMain)[0];

                        rBene["idasset_ac"] = rCespitePrincipale["idasset_ac"];
                        rBene["idpiece_ac"] = rBene["idpiece"];
                        string fAcquire = QHC.CmpEq("nassetacquire", rBene["nassetacquire"]);
                        if (dsFile.Tables["assetacquire"].Select(fAcquire).Length > 0) {
                            DataRow rCarico = dsFile.Tables["assetacquire"].Select(fAcquire)[0];
                            rBene["nassetacquire_ac"] = rCarico["nassetacquire_ac"];
                        }
                        else {
                            string filterasset = QHS.AppAnd(
                                QHS.CmpEq("idasset", rBene["idasset_ac"]), QHS.CmpEq("idpiece", rBene["idpiece_ac"]));
                            rBene["nassetacquire_ac"] = Meta.Conn.DO_READ_VALUE("asset", filterasset, "nassetacquire");
                        }

                        if (rBene["idassetunload"] != DBNull.Value) {
                            string f = QHC.CmpEq("codeassetunloadkind", rBene["codeassetunloadkind"]);
                            if (tAssetUnloadKind.Select(f).Length > 0) {
                                DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                                DataRow rBuono = leggiBuonoScarico(rAssetUnloadKind["idassetunloadkind"],
                                    rBene["yassetunload"], rBene["nassetunload"]);
                                if (rBuono != null) {
                                    rBene["idassetunload_ac"] = rBuono["idassetunload"];
                                }
                            }
                        }
                        continue;
                    }
                }

                // Interrogazione del DB
                // Nel caso di accessori, una volta calcolato il nuovo idasset,
                // l'idpiece sarà uguale a quello del DB di partenza (quello del dipartimento)
                string filtroBene = QHS.AppAnd(QHS.CmpEq("ninventory", rBene["ninventory"]),
                    QHS.CmpEq("idinventory", rBene["idinventory_ac"]));

                DataTable tAssetTemp = Meta.Conn.RUN_SELECT("assetview", "idasset,idpiece",
                    null, filtroBene, null, true);

                if (tAssetTemp == null) {
                    MessageBox.Show(this, "Errore nell'estrazione dei dati da assetview", "Errore");
                    return false;
                }
                string fCespite = "";

                if (tAssetTemp.Rows.Count > 0) {
                    DataRow rAssetTemp = tAssetTemp.Rows[0];
                    rBene["idasset_ac"] = rAssetTemp["idasset"];
                    rBene["idpiece_ac"] = rBene["idpiece"];

                    if (rBene["idassetunload"] != DBNull.Value) {
                        string f = QHC.CmpEq("codeassetunloadkind", rBene["codeassetunloadkind"]);
                        if (tAssetUnloadKind.Select(f).Length > 0) {
                            DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                            DataRow rBuono = leggiBuonoScarico(rAssetUnloadKind["idassetunloadkind"],
                                rBene["yassetunload"], rBene["nassetunload"]);
                            if (rBuono != null) {
                                rBene["idassetunload_ac"] = rBuono["idassetunload"];
                            }
                        }
                    }

                    // Avendo lavorato con la vista mi riempio la tabella asset di dsImporta per ricerche future
                    fCespite = QHC.AppAnd(QHC.CmpEq("idasset", rAssetTemp["idasset"]), 
                        QHC.CmpEq("idpiece", rAssetTemp["idpiece"]));

                    if (dsImporta.Tables["asset"].Select(fCespite).Length == 0) {
                        string fCespiteSQL = QHS.AppAnd(QHS.CmpEq("idasset", rAssetTemp["idasset"]),
                        QHS.CmpEq("idpiece", rAssetTemp["idpiece"]));

                        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["asset"], null,
                            fCespiteSQL, null, true);
                    }

                    if ((int)isNull(rBene["idpiece"],0) > 1) {
                        string fAccessorio = QHC.AppAnd(QHC.CmpEq("idasset", rAssetTemp["idasset"]),
                            QHC.CmpEq("idpiece", rBene["idpiece"]));
                        if (dsImporta.Tables["asset"].Select(fAccessorio).Length == 0) {

                            string fAccessorioSQL = QHS.AppAnd(QHS.CmpEq("idasset", rAssetTemp["idasset"]),
                            QHS.CmpEq("idpiece", rBene["idpiece"]));

                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["asset"],
                                null, fAccessorioSQL, null, true);
                        }
                    }
                }
                else {
                    rBene["idasset_ac"] = idBeneLibero;
                    rBene["idpiece_ac"] = rBene["idpiece"];

                    if (rBene["idassetunload"] != DBNull.Value) {
                        string f = QHC.CmpEq("codeassetunloadkind", rBene["codeassetunloadkind"]);
                        if (tAssetUnloadKind.Select(f).Length > 0) {
                            DataRow rAssetUnloadKind = tAssetUnloadKind.Select(f)[0];
                            DataRow rBuono = leggiBuonoScarico(rAssetUnloadKind["idassetunloadkind"],
                                rBene["yassetunload"], rBene["nassetunload"]);
                            if (rBuono != null) {
                                rBene["idassetunload_ac"] = rBuono["idassetunload"];
                            }
                        }
                    }

                    idBeneLibero++;
                }

                // Se anche il carico del cespite è presente nel dataset dsFile allora prendo quel valore
                // altrimenti prenderò quello di dsImporta
                string filtroCarico = QHC.CmpEq("nassetacquire", rBene["nassetacquire"]);
                DataRow [] Carico = dsFile.Tables["assetacquire"].Select(filtroCarico);
                if (Carico.Length > 0) {
                    rBene["nassetacquire_ac"] = Carico[0]["nassetacquire_ac"];
                }
                else {
                    if (fCespite != "") {
                        DataRow [] Asset = dsImporta.Tables["asset"].Select(fCespite);
                        if (Asset.Length > 0) {
                            rBene["nassetacquire_ac"] = Asset[0]["nassetacquire"];
                        }
                        else {
                            MessageBox.Show(this, "Attenzione non è stato individuato il carico associato al cespite");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool assegnaValoriRivalutazioneBene() {
            string testo = "Assegnazione valori alle rivalutazioni valore cespiti";
            aggiornaForm(testo);

            if (!dsFile.Tables.Contains("assetamortization")) return true;

            object nAmortizationDB = Meta.Conn.DO_READ_VALUE("assetamortization", null, "max(namortization)");
            object nAmortizationDS = dsFile.Tables["assetamortization"].Compute("max(namortization_ac)", null);
            int nRivalutazioneLibero = 1 + getMaxValue(nAmortizationDB, nAmortizationDS);

            foreach (DataRow rRivalutazione in dsFile.Tables["assetamortization"].Rows) {

                if (rRivalutazione["idinventoryamortization"] != DBNull.Value) {
                    object idInventoryAmortization = ottieniIdInventoryAmortization(rRivalutazione["!codeinventoryamortization"]);
                    if (idInventoryAmortization != null) {
                        rRivalutazione["idinventoryamortization_ac"] = idInventoryAmortization;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Ammortamento\nNon è presente il codice dell'ammortamento, procedura interrotta!");
                        return false;
                    }
                }

                if (rRivalutazione["!idinventory"] != DBNull.Value) {
                    rRivalutazione["idinventory_ac"] = ottieniIdInventory(rRivalutazione["!codeinventory"]);
                }

                if (rRivalutazione["idassetunload"] != DBNull.Value) {
                    object idassetunloadkind = ottieniIdAssetUnload(rRivalutazione["codeassetunloadkind"]);
                    if (idassetunloadkind != null) {
                        DataRow rBuono = leggiBuonoScarico(idassetunloadkind,
                            rRivalutazione["!yassetunload"], rRivalutazione["!nassetunload"]);
                        if (rBuono != null) {
                            rRivalutazione["idassetunload_ac"] = rBuono["idassetunload"];
                        }
                        else {
                            MessageBox.Show(this, "Sezione Ammortamento\nCodifica del buono di scarico assente");
                            return false;
                        }
                    }
                    else {
                        MessageBox.Show(this, "Sezione Ammortamento\nNon è presente il codice del buono di scarico, procedura interrotta!");
                        return false;
                    }
                }

                string filtro = QHC.AppAnd(QHC.CmpEq("idasset", rRivalutazione["idasset"]),
                    QHC.CmpEq("idpiece", rRivalutazione["idpiece"]));

                string filtroRivalutazione = "";
                // Caso in cui esiste il cespite nel dataset di input
                DataRow[] Bene = dsFile.Tables["asset"].Select(filtro);
                if (Bene.Length > 0) {
                    DataRow rBene = Bene[0];
                    
                    string filtroRivalutazioneDB =
                        QHS.AppAnd(QHS.CmpEq("idasset", rBene["idasset_ac"]),
                        QHS.CmpEq("idpiece", rBene["idpiece_ac"]),
                        QHS.CmpEq("adate", rRivalutazione["adate"]));

                    filtroRivalutazione = QHC.AppAnd(QHC.CmpEq("idasset", rBene["idasset_ac"]),
                        QHC.CmpEq("idpiece", rBene["idpiece_ac"]),
                        QHC.CmpEq("adate", rRivalutazione["adate"]));

                    if (dsImporta.Tables["assetamortization"].Select(filtroRivalutazione).Length == 0) {
                        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetamortization"],
                            null, filtroRivalutazioneDB, null, true);
                    }

                    DataRow[] rRivalutazioniAC = dsImporta.Tables["assetamortization"].Select(filtroRivalutazione);
                    if (rRivalutazioniAC.Length > 0) {
                        rRivalutazione["namortization_ac"] = rRivalutazioniAC[0]["namortization"];
                        rRivalutazione["idasset_ac"] = rRivalutazioniAC[0]["idasset"];
                        rRivalutazione["idpiece_ac"] = rRivalutazioniAC[0]["idpiece"];
                    }
                    else {
                        rRivalutazione["namortization_ac"] = nRivalutazioneLibero;
                        nRivalutazioneLibero++;
                        rRivalutazione["idasset_ac"] = rBene["idasset_ac"];
                        rRivalutazione["idpiece_ac"] = rBene["idpiece_ac"];
                    }
                    continue;
                }

                string querySQL =
                "SELECT AA.namortization, AA.idasset, AA.idpiece, AA.idinventoryamortization " +
                " FROM assetamortization AA "
                + " JOIN assetview A ON A.idasset = AA.idasset "
                + " AND A.idpiece = AA.idpiece "
                + " WHERE " + QHS.AppAnd(QHS.CmpEq("A.idinventory", rRivalutazione["idinventory_ac"]),
                    QHS.CmpEq("A.ninventory", rRivalutazione["!ninventory"]),
                    QHS.CmpEq("AA.adate", rRivalutazione["adate"]));

                DataTable tAssetAmortization = Meta.Conn.SQLRunner(querySQL);
                if (tAssetAmortization == null) {
                    MessageBox.Show(this, "Errore nell'estrazione dei dati per la tabella ASSETAMORTIZATION", "Errore");
                    return false;
                }
                if (tAssetAmortization.Rows.Count > 0) {
                    DataRow rAA = tAssetAmortization.Rows[0];
                    rRivalutazione["namortization_ac"] = rAA["namortization"];
                    rRivalutazione["idasset_ac"] = rAA["idasset"];
                    rRivalutazione["idpiece_ac"] = rAA["idpiece"];

                    // riempio le rispettive tabelle in dsImporta in modo da poter riusare queste informazioni in seguito
                    string fAsset = QHC.AppAnd(QHC.CmpEq("idasset", rAA["idasset"]),
                        QHC.CmpEq("idpiece", rAA["idpiece"]));
                    string fAssetSQL = QHS.AppAnd(QHS.CmpEq("idasset", rAA["idasset"]),
                        QHS.CmpEq("idpiece", rAA["idpiece"])); 
                    if (dsImporta.Tables["asset"].Select(fAsset).Length == 0) {
                        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["asset"], null, fAssetSQL,
                            null, true);
                    }

                    string fAssetAmortization = QHC.CmpEq("namortization", rAA["namortization"]);
                    string fAssetAmortizationSQL = QHS.CmpEq("namortization", rAA["namortization"]);
                    if (dsImporta.Tables["assetamortization"].Select(fAssetAmortization).Length == 0) {
                        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetamortization"],
                            null, fAssetAmortizationSQL, null, true);
                    }
                }
                else {
                    string q2 = "SELECT idasset, idpiece FROM assetview "
                    + " WHERE " + 
                    QHS.AppAnd(QHS.CmpEq("idinventory", rRivalutazione["idinventory_ac"]),
                    QHS.CmpEq("ninventory", rRivalutazione["!ninventory"]));
                    DataTable tAsset = Meta.Conn.SQLRunner(q2);
                    if (tAsset == null) {
                        MessageBox.Show(this, "Errore nell'estrazione dei dati per la tabella ASSET per ASSETAMORTIZATION", "Errore");
                        return false;
                    }
                    rRivalutazione["namortization_ac"] = nRivalutazioneLibero;

                    if (tAsset.Rows.Count > 0) {
                        DataRow rAsset = tAsset.Rows[0];
                        rRivalutazione["idasset_ac"] = rAsset["idasset"];
                        rRivalutazione["idpiece_ac"] = rAsset["idpiece"];

                        string fAsset2 = QHC.AppAnd(QHC.CmpEq("idasset", rAsset["idasset"]),
                            QHC.CmpEq("idpiece", rAsset["idpiece"]));
                        string fAsset2SQL = QHC.AppAnd(QHC.CmpEq("idasset", rAsset["idasset"]),
                            QHC.CmpEq("idpiece", rAsset["idpiece"]));

                        if (dsImporta.Tables["asset"].Select(fAsset2).Length == 0) {
                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["asset"], null,
                                fAsset2SQL, null, true);
                        }
                    }
                    nRivalutazioneLibero++;
                }
            }
            return true;
        }

        private bool assegnaValoriBuonoCarico() {
            string testo = "Assegnazione valori dei buoni di carico";
            aggiornaForm(testo);

            if (!dsFile.Tables.Contains("assetload")) return true;

            object nAssetLoadDB = Meta.Conn.DO_READ_VALUE("assetload", null, "max(idassetload)");
            object nAssetLoadDS = dsFile.Tables["assetload"].Compute("max(idassetload_ac)", null);
            int nBuonoLibero = 1 + getMaxValue(nAssetLoadDB, nAssetLoadDS);
            
            bool aggiornaAnagrafica = dsFile.Tables["assetload"].Columns.Contains("idreg");

            foreach (DataRow rBuono in dsFile.Tables["assetload"].Rows) {
                
                if (rBuono["idassetloadkind"] != DBNull.Value){
                    object idAssetLoadKind = ottieniIdAssetLoad(rBuono["!codeassetloadkind"]);
                    if (idAssetLoadKind != null) {
                        rBuono["idassetloadkind_ac"] = idAssetLoadKind;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Buono Carico\nCodifica Buono assente");
                        return false;
                    }
                }

                if (rBuono["idmot"] != DBNull.Value) {
                    object idMot = ottieniIdMotiveLoad(rBuono["!codemot"]);
                    if (idMot != null) {
                        rBuono["idmot_ac"] = idMot;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Buono Carico\nCodifica Causale di carico assente");
                        return false;
                    }
                }

                if (aggiornaAnagrafica) {
                    if (rBuono["idreg"] != DBNull.Value) {
                        string filtro = QHC.CmpEq("idreg", rBuono["idreg"]);
                        if (dsFile.Tables["registry"].Select(filtro).Length > 0) {
                            DataRow rCredDeb = dsFile.Tables["registry"].Select(filtro)[0];
                            rBuono["idreg_ac"] = rCredDeb["idreg_ac"];
                        }
                    }
                }

                string filter = QHC.AppAnd(QHC.CmpEq("idassetloadkind", rBuono["idassetloadkind_ac"]),
                    QHC.CmpEq("yassetload", rBuono["yassetload"]), QHC.CmpEq("nassetload", rBuono["nassetload"]));

                
                if (dsImporta.Tables["assetload"].Select(filter).Length > 0) {
                    DataRow r = dsImporta.Tables["assetload"].Select(filter)[0];
                    rBuono["idassetload_ac"] = r["idassetload"];
                }
                else {
                    string filterSQL = QHS.AppAnd(QHS.CmpEq("idassetloadkind", rBuono["idassetloadkind_ac"]),
                    QHS.CmpEq("yassetload", rBuono["yassetload"]), QHS.CmpEq("nassetload", rBuono["nassetload"]));
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetload"], null,
                        filterSQL, null, true);

                    if (dsImporta.Tables["assetload"].Select(filter).Length > 0) {
                        DataRow r = dsImporta.Tables["assetload"].Select(filter)[0];
                        rBuono["idassetload_ac"] = r["idassetload"];
                    }
                    else {
                        rBuono["idassetload_ac"] = nBuonoLibero++;

                        // Nel caso la riga in dsImporta non ci fosse, l'aggiungo già da ora, in modo che
                        // nei metodi a venire posso adoperarla senza problemi
                        DataRow rBuonoAdded = dsImporta.Tables["assetload"].NewRow();
                        foreach (DataColumn C in dsImporta.Tables["assetload"].Columns) {
                            if ((C.ColumnName == "idassetload")
                                || (C.ColumnName == "idassetloadkind")
                                || (C.ColumnName == "idmot")
                                || (C.ColumnName == "idreg")) continue;
                            if ((!rBuono.Table.Columns.Contains(C.ColumnName)) ||
                                (!rBuonoAdded.Table.Columns.Contains(C.ColumnName))) continue;
                            rBuonoAdded[C.ColumnName] = rBuono[C.ColumnName];
                        }
                        rBuonoAdded["idassetload"] = rBuono["idassetload_ac"];
                        rBuonoAdded["idassetloadkind"] = rBuono["idassetloadkind_ac"];
                        rBuonoAdded["idmot"] = rBuono["idmot_ac"];
                        rBuonoAdded["idreg"] = rBuono["idreg_ac"];
                        rBuonoAdded["ct"] = DateTime.Now;
                        rBuonoAdded["cu"] = "IMPORT";
                        rBuonoAdded["lt"] = DateTime.Now;
                        rBuonoAdded["lu"] = "IMPORT";
                        rBuonoAdded["transmitted"] = "S";
                        
                        dsImporta.Tables["assetload"].Rows.Add(rBuonoAdded);
                    }
                }
                
            }
            return true;
        }

        private bool assegnaValoriBuonoScarico() {
            string testo = "Assegnazione valori dei buoni di scarico";
            aggiornaForm(testo);

            if (!dsFile.Tables.Contains("assetunload")) return true;

            object nAssetUnloadDB = Meta.Conn.DO_READ_VALUE("assetunload", null, "max(idassetunload)");
            object nAssetUnloadDS = dsFile.Tables["assetunload"].Compute("max(idassetunload_ac)", null);
            int nBuonoLibero = 1 + getMaxValue(nAssetUnloadDB, nAssetUnloadDS);

            bool aggiornaAnagrafica = dsFile.Tables["assetunload"].Columns.Contains("idreg");

            foreach (DataRow rBuono in dsFile.Tables["assetunload"].Rows) {
                if (rBuono["idassetunloadkind"] != DBNull.Value) {
                    object idAssetUnloadKind = ottieniIdAssetUnload(rBuono["!codeassetunloadkind"]);
                    if (idAssetUnloadKind != null) {
                        rBuono["idassetunloadkind_ac"] = idAssetUnloadKind;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Buono Scarico\nCodifica Buono assente");
                        return false;
                    }
                }

                if (rBuono["idmot"] != DBNull.Value) {
                    object idMot = ottieniIdMotiveUnload(rBuono["!codemot"]);
                    if (idMot != null) {
                        rBuono["idmot_ac"] = idMot;
                    }
                    else {
                        MessageBox.Show(this, "Sezione Buono Scarico\nCodifica Causale di scarico assente");
                        return false;
                    }
                }

                if (aggiornaAnagrafica) {
                    if (rBuono["idreg"] != DBNull.Value) {
                        string filtro = QHC.CmpEq("idreg", rBuono["idreg"]);
                        if (dsFile.Tables["registry"].Select(filtro).Length > 0) {
                            DataRow rCredDeb = dsFile.Tables["registry"].Select(filtro)[0];
                            rBuono["idreg_ac"] = rCredDeb["idreg_ac"];
                        }
                    }
                }

                string filter = QHC.AppAnd(QHC.CmpEq("idassetunloadkind", rBuono["idassetunloadkind_ac"]),
                    QHC.CmpEq("yassetunload", rBuono["yassetunload"]), QHC.CmpEq("nassetunload", rBuono["nassetunload"]));

                if (dsImporta.Tables["assetunload"].Select(filter).Length > 0) {
                    DataRow r = dsImporta.Tables["assetunload"].Select(filter)[0];
                    rBuono["idassetunload_ac"] = r["idassetunload"];
                }
                else {
                    string filterSQL = QHS.AppAnd(QHS.CmpEq("idassetunloadkind", rBuono["idassetunloadkind_ac"]),
                    QHS.CmpEq("yassetunload", rBuono["yassetunload"]), QHS.CmpEq("nassetunload", rBuono["nassetunload"]));
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetunload"], null,
                        filterSQL, null, true);

                    if (dsImporta.Tables["assetunload"].Select(filter).Length > 0) {
                        DataRow r = dsImporta.Tables["assetunload"].Select(filter)[0];
                        rBuono["idassetunload_ac"] = r["idassetunload"];
                    }
                    else {
                        rBuono["idassetunload_ac"] = nBuonoLibero++;

                        // Nel caso la riga in dsImporta non ci fosse, l'aggiungo già da ora, in modo che
                        // nei metodi a venire posso adoperarla senza problemi
                        DataRow rBuonoAdded = dsImporta.Tables["assetunload"].NewRow();
                        foreach (DataColumn C in dsImporta.Tables["assetunload"].Columns) {
                            if ((C.ColumnName == "idassetunload")
                                || (C.ColumnName == "idassetunloadkind")
                                || (C.ColumnName == "idmot")
                                || (C.ColumnName == "idreg")) continue;
                            if ((!rBuono.Table.Columns.Contains(C.ColumnName)) ||
                                (!rBuonoAdded.Table.Columns.Contains(C.ColumnName))) continue;
                            rBuonoAdded[C.ColumnName] = rBuono[C.ColumnName];
                        }
                        rBuonoAdded["idassetunload"] = rBuono["idassetunload_ac"];
                        rBuonoAdded["idassetunloadkind"] = rBuono["idassetunloadkind_ac"];
                        rBuonoAdded["idmot"] = rBuono["idmot_ac"];
                        rBuonoAdded["idreg"] = rBuono["idreg_ac"];
                        rBuonoAdded["ct"] = DateTime.Now;
                        rBuonoAdded["cu"] = "IMPORT";
                        rBuonoAdded["lt"] = DateTime.Now;
                        rBuonoAdded["lu"] = "IMPORT";
                        rBuonoAdded["transmitted"] = "S";
                        dsImporta.Tables["assetunload"].Rows.Add(rBuonoAdded);
                    }
                }

                
            }
            return true;
        }

        private DataRow leggiBuonoCarico(object codice, object esercizio, object numero) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idassetloadkind", codice),
                QHC.CmpEq("yassetload", esercizio), QHC.CmpEq("nassetload", numero));
            string filtroSQL = QHS.AppAnd(QHS.CmpEq("idassetloadkind", codice),
                QHS.CmpEq("yassetload", esercizio), QHS.CmpEq("nassetload", numero));

            if (dsImporta.Tables["assetload"].Select(filtro).Length > 0) {
                DataRow r = dsImporta.Tables["assetload"].Select(filtro)[0];
                return r;
            }
            else {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetload"], null,
                    filtroSQL, null, true);
                if (dsImporta.Tables["assetload"].Select(filtro).Length > 0) {
                    DataRow r = dsImporta.Tables["assetload"].Select(filtro)[0];
                    return r;
                }
                else {
                    return null;
                }
            }
        }

        private DataRow leggiBuonoScarico(object codice, object esercizio, object numero) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idassetunloadkind", codice),
                QHC.CmpEq("yassetunload", esercizio), QHC.CmpEq("nassetunload", numero));
            string filtroSQL = QHS.AppAnd(QHS.CmpEq("idassetunloadkind", codice),
                QHS.CmpEq("yassetunload", esercizio), QHS.CmpEq("nassetunload", numero));

            if (dsImporta.Tables["assetunload"].Select(filtro).Length > 0) {
                DataRow r = dsImporta.Tables["assetunload"].Select(filtro)[0];
                return r;
            }
            else {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImporta.Tables["assetunload"], null,
                    filtroSQL, null, true);
                if (dsImporta.Tables["assetunload"].Select(filtro).Length > 0) {
                    DataRow r = dsImporta.Tables["assetunload"].Select(filtro)[0];
                    return r;
                }
                else {
                    return null;
                }
            }
        }

        private int getMaxValue(object valueDB, object valueDS) {
            int vDB = CfgFn.GetNoNullInt32(valueDB);
            int vDS = CfgFn.GetNoNullInt32(valueDS);
            return (vDB > vDS) ? vDB : vDS;
        }

        #endregion

        #region TRAVASO DATI
        private bool travasaIDatiInAmminCentrale(string codiceEnte) {
            FileStream fs = creaFileDiLog(codiceEnte);
            if (fs == null) return false;
            TextWriter tw = File.AppendText(fs.Name);
            string errMess;
            if (dsFile.Tables.Contains("assetacquire")) {
                if (!travasaCaricoBene(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }

            if (dsFile.Tables.Contains("assetload")) {
                if (!travasaBuonoCarico(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }

            if (dsFile.Tables.Contains("assetunload")) {
                if (!travasaBuonoScarico(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }

            if (dsFile.Tables.Contains("assetamortization")) {
                if (!travasaRivalutazioneBene(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }

            if (dsFile.Tables.Contains("asset")) {
                if (!travasaBeneInventariabile(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }

            if (dsFile.Tables.Contains("registry")) {
                if (!travasaAnagrafica(tw, out errMess)) {
                    tw.Close();
                    MessageBox.Show(this, errMess);
                    return false;
                }
            }
            tw.Close();
            return true;
        }

        private bool travasaCaricoBene(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura ASSETACQUIRE";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA ASSETACQUIRE");
            int righeAggiunte = 0;
            string tableName = "assetacquire";
            foreach (DataRow rCaricoBene in dsFile.Tables[tableName].Rows) {
                string filtro = QHC.CmpEq("nassetacquire", rCaricoBene["nassetacquire_ac"]);
                DataRow[] rCaricoAC = dsImporta.Tables["assetacquire"].Select(filtro);
                if (rCaricoAC.Length == 0) {
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    string[] col_tocopy = new string[] {"adate", "description",
                            "abatable", "discount", "number",
                            "startnumber", "tax", "taxable", "taxrate"};

                    foreach (string col in col_tocopy) {
                        newRow[col] = rCaricoBene[col];
                    }

                    newRow["nassetacquire"] = rCaricoBene["nassetacquire_ac"];
                    newRow["idreg"] = rCaricoBene["idreg_ac"];
                    newRow["idmot"] = rCaricoBene["idmot_ac"];
                    newRow["idinventory"] = rCaricoBene["idinventory_ac"];
                    newRow["idassetload"] = rCaricoBene["idassetload_ac"];
                    newRow["idinv"] = rCaricoBene["idinv_ac"];

                    object idAssetLoadKind = ottieniTipoBuonoCarico(rCaricoBene["idassetload_ac"]);

                    bool isPosseduto = valutaSeCespitePosseduto(idAssetLoadKind,
                        rCaricoBene["startnumber"]);
                    int flagSrc = CfgFn.GetNoNullInt32(rCaricoBene["flag"]);
                    flagSrc &= 0xF5;
                    if (isPosseduto) {
                        flagSrc |= 0x02;
                    }
                    newRow["flag"] = flagSrc;
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";
                    newRow["transmitted"] = "S";

                    dsImporta.Tables[tableName].Rows.Add(newRow);

                    string info = "Aggiunto carico cespite n. " + rCaricoBene["nassetacquire_ac"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
                else {
                    DataRow rAC = rCaricoAC[0];
                    // Consenti la modifica del buono di carico
                    if (rAC["transmitted"].ToString().ToUpper() == "S") {
                        string[] col_tocopy = new string[] {"adate", "description", "idinv",
                            "abatable", "discount", "number",
                            "startnumber", "tax", "taxable", "taxrate"};

                        foreach (string col in col_tocopy) {
                            rAC[col] = rCaricoBene[col];
                        }
                        rAC["idreg"] = rCaricoBene["idreg_ac"];
                        rAC["idmot"] = rCaricoBene["idmot_ac"];
                        rAC["idinventory"] = rCaricoBene["idinventory_ac"];
                        rAC["idassetload"] = rCaricoBene["idassetload_ac"];
                        rAC["idinv"] = rCaricoBene["idinv_ac"];

                        object idAssetLoadKind = ottieniTipoBuonoCarico(rCaricoBene["idassetload_ac"]);

                        bool isPosseduto = valutaSeCespitePosseduto(idAssetLoadKind,
                        rCaricoBene["startnumber"]);
                        int flagSrc = CfgFn.GetNoNullInt32(rCaricoBene["flag"]);
                        flagSrc &= 0xF5;
                        if (isPosseduto) {
                            flagSrc |= 0x02;
                        }
                        rAC["flag"] = flagSrc;
                        rAC["ct"] = DateTime.Now;
                        rAC["cu"] = "IMPORT";
                        rAC["lt"] = DateTime.Now;
                        rAC["lu"] = "IMPORT";
                        rAC["transmitted"] = "S";
                    }
                    else {
                        string adviceMsg = "Il Carico Cespite" + rAC["nassetacquire"]
                        + " risulta già modificato e quindi non sarà aggiornato!";
                        MessageBox.Show(this, adviceMsg, "Avvertimento");
                    }
                }
            }
            scriviMessaggioChiusura(tw, righeAggiunte);
            aggiungiRigaLog(tw, "FINE SCRITTURA ASSETACQUIRE");
            return true;
        }

        private object ottieniTipoBuonoCarico(object id) {
            if (dsFile.Tables["assetload"].Select(QHC.CmpEq("idassetload_ac", id)).Length > 0) {
                DataRow rAssetLoad = dsFile.Tables["assetload"].Select(QHC.CmpEq("idassetload_ac", id))[0];
                return rAssetLoad["idassetloadkind_ac"];
            }
            return null;
        }

        private bool valutaSeCespitePosseduto(object idassetloadkind, object startnumber) {
            string filtro = QHC.CmpEq("idassetloadkind", idassetloadkind);
            string filtroSQL = QHS.CmpEq("idassetloadkind", idassetloadkind);
            int valoreSoglia = 0;
            if (tAssetLoadKind.Select(filtro).Length == 0) {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAssetLoadKind, null, filtroSQL, null, true);
                if (tAssetLoadKind.Select(filtro).Length > 0) {
                    DataRow rAssetLoadKind = tAssetLoadKind.Select(filtro)[0];
                    valoreSoglia = CfgFn.GetNoNullInt32(rAssetLoadKind["startnumber"]);
                }
            }
            else {
                DataRow rAssetLoadKind = tAssetLoadKind.Select(filtro)[0];
                valoreSoglia = CfgFn.GetNoNullInt32(rAssetLoadKind["startnumber"]);
            }

            int numberOnAcquire = CfgFn.GetNoNullInt32(startnumber);
            return (numberOnAcquire >= valoreSoglia);
        }

        private bool travasaBuonoCarico(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura ASSETLOAD";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA ASSETLOAD");
            int righeAggiunte = 0;
            string tableName = "assetload";
            foreach (DataRow rBuonoCarico in dsFile.Tables[tableName].Rows) {
                string filtro = QHC.CmpEq("idassetload", rBuonoCarico["idassetload_ac"]);
                DataRow[] rBuonoCaricoAC = dsImporta.Tables["assetload"].Select(filtro);
                if (rBuonoCaricoAC.Length == 0) {
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    string[] col_tocopy = new string[] {"yassetload", "nassetload", "adate",
                        "description", "doc", "docdate", "enactment", "enactmentdate", "printdate",
                        "ratificationdate"};

                    foreach (string col in col_tocopy) {
                        newRow[col] = rBuonoCarico[col];
                    }
                    newRow["idassetload"] = rBuonoCarico["idassetload_ac"];
                    newRow["idassetloadkind"] = rBuonoCarico["idassetloadkind_ac"];
                    newRow["idmot"] = rBuonoCarico["idmot_ac"];
                    newRow["idreg"] = rBuonoCarico["idreg_ac"];
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";
                    newRow["transmitted"] = "S";

                    dsImporta.Tables[tableName].Rows.Add(newRow);

                    string info = "Aggiunto buono di carico n. "
                        + rBuonoCarico["!codeassetloadkind"] + " "
                        + rBuonoCarico["yassetload"] + "/"
                        + rBuonoCarico["nassetload"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
                else {
                    DataRow rAC = rBuonoCaricoAC[0];
                    // Consenti la modifica del buono di carico
                    if (rAC["transmitted"].ToString().ToUpper() == "S") {
                        string[] col_tocopy = new string[] {"adate", "description", "doc", "docdate",
                            "enactment", "enactmentdate", "printdate", "ratificationdate"};

                        foreach (string col in col_tocopy) {
                            rAC[col] = rBuonoCarico[col];
                        }
                        rAC["idmot"] = rBuonoCarico["idmot_ac"];
                        rAC["idreg"] = rBuonoCarico["idreg_ac"];
                        rAC["ct"] = DateTime.Now;
                        rAC["cu"] = "IMPORT";
                        rAC["lt"] = DateTime.Now;
                        rAC["lu"] = "IMPORT";
                        rAC["transmitted"] = "S";
                    }
                    else {
                        string adviceMsg = "Il Buono di Carico " + rBuonoCarico["!codeassetloadkind"]
                        + " n. " + rAC["yassetload"] + "/" + rAC["nassetload"]
                        + " risulta già modificato e quindi non sarà aggiornato!";
                        MessageBox.Show(this, adviceMsg, "Avvertimento");
                    }
                }
            }
            scriviMessaggioChiusura(tw, righeAggiunte);
            aggiungiRigaLog(tw, "FINE SCRITTURA ASSETLOAD");
            return true;
        }

        private bool travasaBuonoScarico(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura ASSETUNLOAD";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA ASSETUNLOAD");
            int righeAggiunte = 0;
            string tableName = "assetunload";
            foreach (DataRow rBuonoScarico in dsFile.Tables[tableName].Rows) {
                string filtro = QHC.CmpEq("idassetunload", rBuonoScarico["idassetunload_ac"]);
                DataRow[] rBuonoScaricoAC = dsImporta.Tables["assetunload"].Select(filtro);
                if (rBuonoScaricoAC.Length == 0) {
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    string[] col_tocopy = new string[] {"yassetunload", "nassetunload", "adate",
                        "description", "doc", "docdate", "enactment", "enactmentdate", "printdate",
                        "ratificationdate"};

                    foreach (string col in col_tocopy) {
                        newRow[col] = rBuonoScarico[col];
                    }
                    newRow["idassetunload"] = rBuonoScarico["idassetunload_ac"];
                    newRow["idassetunloadkind"] = rBuonoScarico["idassetunloadkind_ac"];
                    newRow["idmot"] = rBuonoScarico["idmot_ac"];
                    newRow["idreg"] = rBuonoScarico["idreg_ac"];
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";
                    newRow["transmitted"] = "S";

                    dsImporta.Tables[tableName].Rows.Add(newRow);

                    string info = "Aggiunto buono di scarico n. "
                        + rBuonoScarico["!codeassetunloadkind"] + " "
                        + rBuonoScarico["yassetunload"] + "/"
                        + rBuonoScarico["nassetunload"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
                else {
                    DataRow rAC = rBuonoScaricoAC[0];
                    // Consenti la modifica del buono di carico
                    if (rAC["transmitted"].ToString().ToUpper() == "S") {
                        string[] col_tocopy = new string[] {"adate", "description", "doc", "docdate", "enactment",
                            "enactmentdate", "printdate", "ratificationdate"};

                        foreach (string col in col_tocopy) {
                            rAC[col] = rBuonoScarico[col];
                        }
                        rAC["idmot"] = rBuonoScarico["idmot_ac"];
                        rAC["idreg"] = rBuonoScarico["idreg_ac"];
                        rAC["ct"] = DateTime.Now;
                        rAC["cu"] = "IMPORT";
                        rAC["lt"] = DateTime.Now;
                        rAC["lu"] = "IMPORT";
                        rAC["transmitted"] = "S";
                    }
                    else {
                        string adviceMsg = "Il Buono di Scarico " + rBuonoScarico["!codeassetunloadkind"]
                        + " n. " + rAC["yassetunload"] + "/" + rAC["nassetunload"]
                        + " risulta già modificato e quindi non sarà aggiornato!";
                        MessageBox.Show(this, adviceMsg, "Avvertimento");
                    }
                }
            }
            
            scriviMessaggioChiusura(tw, righeAggiunte);
            aggiungiRigaLog(tw, "FINE SCRITTURA ASSETUNLOAD");
            return true;
        }

        private bool travasaRivalutazioneBene(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura ASSETAMORTIZATION";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA ASSETAMORTIZATION");
            int righeAggiunte = 0;
            string tableName = "assetamortization";
            foreach (DataRow rRivalutazioneBene in dsFile.Tables[tableName].Rows) {
                string filtro = QHC.CmpEq("namortization", rRivalutazioneBene["namortization_ac"]);
                DataRow[] rRivalutazioneAC = dsImporta.Tables["assetamortization"].Select(filtro);
                if (rRivalutazioneAC.Length == 0) {
                    
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    string[] col_tocopy = new string[] {"adate", "amortizationquota",
                        "description", "assetvalue", "flag"};

                    foreach (string col in col_tocopy) {
                        newRow[col] = rRivalutazioneBene[col];
                    }
                    newRow["namortization"] = rRivalutazioneBene["namortization_ac"];
                    newRow["idinventoryamortization"] = rRivalutazioneBene["idinventoryamortization_ac"];
                    newRow["idassetunload"] = rRivalutazioneBene["idassetunload_ac"];
                    newRow["idasset"] = rRivalutazioneBene["idasset_ac"];
                    newRow["idpiece"] = rRivalutazioneBene["idpiece_ac"];
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";
                    newRow["transmitted"] = "S";

                    dsImporta.Tables[tableName].Rows.Add(newRow);

                    string info = "Aggiunta rivalutazione del cespite n. " + rRivalutazioneBene["namortization_ac"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
                else {
                    DataRow rAC = rRivalutazioneAC[0];
                    // Consenti la modifica del buono di carico
                    if (rAC["transmitted"].ToString().ToUpper() == "S") {
                        if (rRivalutazioneBene["transmitted"].ToString().ToUpper() == "S") {
                            continue;
                        }
                        string[] col_tocopy = new string[] {"adate", "description", "amortizationquota",
                            "assetvalue", "idasset", "idpiece", "flag"};

                        foreach (string col in col_tocopy) {
                            rAC[col] = rRivalutazioneBene[col];
                        }

                        rAC["idinventoryamortization"] = rRivalutazioneBene["idinventoryamortization_ac"];
                        rAC["idassetunload"] = rRivalutazioneBene["idassetunload_ac"];
                        rAC["ct"] = DateTime.Now;
                        rAC["cu"] = "IMPORT";
                        rAC["lt"] = DateTime.Now;
                        rAC["lu"] = "IMPORT";
                        rAC["transmitted"] = "S";
                    }
                    else {
                        string adviceMsg = "La rivalutazione/svalutazione" + rAC["namortization"]
                        + " risulta già modificata e quindi non sarà aggiornata!";
                        MessageBox.Show(this, adviceMsg, "Avvertimento");
                    }
                }
            }
            scriviMessaggioChiusura(tw, righeAggiunte);
            aggiungiRigaLog(tw, "FINE SCRITTURA ASSETAMORTIZATION");
            return true;
        }

        private bool travasaBeneInventariabile(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura ASSET";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA ASSET");
            int righeAggiunte = 0;
            int righeModificate = 0;
            string tableName = "asset";
            foreach (DataRow rBeneInv in dsFile.Tables[tableName].Rows) {
                string filtro = QHC.AppAnd(QHC.CmpEq("idasset", rBeneInv["idasset_ac"]),
                    QHC.CmpEq("idpiece", rBeneInv["idpiece_ac"]));

                DataRow[] rBeneInvAC = dsImporta.Tables["asset"].Select(filtro);
                if (rBeneInvAC.Length == 0) {
                    string filtroCarico = QHC.CmpEq("nassetacquire", rBeneInv["nassetacquire"]);
                    DataRow [] Carico = dsFile.Tables["assetacquire"].Select(filtroCarico);
                    if (Carico.Length == 0) {
                        MessageBox.Show(this, "Il cespite non ha un carico corrispondente!", "Errore");
                        return false;
                    }
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    string[] col_tocopy = new string[] {"flag"};

                    foreach (string col in col_tocopy) {
                        newRow[col] = rBeneInv[col];
                    }
                    
                    newRow["idasset"] = rBeneInv["idasset_ac"];
                    newRow["idpiece"] = rBeneInv["idpiece_ac"];
                    newRow["idassetunload"] = rBeneInv["idassetunload_ac"];
                    newRow["nassetacquire"] = rBeneInv["nassetacquire_ac"];
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";
                    newRow["transmitted"] = "S";
                    // Il campo ninventory deve essere valorizzato solo nel caso di cespite principale e non per gli accessori
                    int numParte = CfgFn.GetNoNullInt32(rBeneInv["idpiece_ac"]);
                    if (numParte == 0) {
                        MessageBox.Show(this, "Errore critico n. accessorio non valorizzato");
                        return false;
                    }
                    if (numParte == 1) {
                        newRow["ninventory"] = rBeneInv["ninventory"];
                    }
                    dsImporta.Tables[tableName].Rows.Add(newRow);

                    string info = "Aggiunto cespite n. "
                        + rBeneInv["idasset"] + " / " + rBeneInv["idpiece"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
                else {
                    DataRow rAC = rBeneInvAC[0];
                    // Consenti la modifica del cespite
                    if (rAC["transmitted"].ToString().ToUpper() == "S") {
                        string[] col_tocopy = new string[] {"lifestart", "ninventory", "flag"};

                        foreach (string col in col_tocopy) {
                            rAC[col] = rBeneInv[col];
                        }
                        rAC["nassetacquire"] = rBeneInv["nassetacquire_ac"];
                        rAC["idassetunload"] = rBeneInv["idassetunload_ac"];
                        rAC["ct"] = DateTime.Now;
                        rAC["cu"] = "IMPORT";
                        rAC["lt"] = DateTime.Now;
                        rAC["lu"] = "IMPORT";
                        rAC["transmitted"] = "S";
                    }
                    else {
                        string adviceMsg = "Il Cespite n. " + rAC["idasset"]
                        + "/" + rAC["idpiece"]
                        + " risulta già modificato e quindi non sarà aggiornato!";
                        MessageBox.Show(this, adviceMsg, "Avvertimento");
                    }
                }
            }
            scriviMessaggioChiusura(tw, righeAggiunte);
            if (righeModificate != 0) {
                string messaggioRighe = "Sono state modificate " + righeModificate + " righe";
                aggiungiRigaLog(tw, messaggioRighe);
            }
            aggiungiRigaLog(tw, "FINE SCRITTURA ASSET");
            return true;
        }

        private bool travasaAnagrafica(TextWriter tw, out string errMess) {
            errMess = "";
            string testo = "Scrittura REGISTRY";
            aggiornaForm(testo);
            aggiungiRigaLog(tw, "INIZIO SCRITTURA TABELLA REGISTRY");
            int righeAggiunte = 0;
            string tableName = "registry";
            foreach (DataRow rCreditoreDebitore in dsFile.Tables[tableName].Rows) {
                string filtro = "(idreg = '" + rCreditoreDebitore["idreg_ac"] + "')";
                DataRow[] rCreditoreDebitoreAC = dsImporta.Tables["registry"].Select(filtro);
                if (rCreditoreDebitoreAC.Length == 0) {
                    DataRow newRow = dsImporta.Tables[tableName].NewRow();

                    newRow["idreg"] = rCreditoreDebitore["idreg_ac"];
                    newRow["title"] = rCreditoreDebitore["title"];
                    newRow["active"] = "S";
                    newRow["residence"] = 1;
                    newRow["ct"] = DateTime.Now;
                    newRow["cu"] = "IMPORT";
                    newRow["lt"] = DateTime.Now;
                    newRow["lu"] = "IMPORT";

                    dsImporta.Tables["registry"].Rows.Add(newRow);

                    string info = "Aggiunta anagrafica con codice " + rCreditoreDebitore["idreg_ac"];
                    aggiungiRigaLog(tw, info);
                    righeAggiunte++;
                }
            }
            scriviMessaggioChiusura(tw, righeAggiunte);
            aggiungiRigaLog(tw, "FINE SCRITTURA REGISTRY");
            return true;
        }

        private FileStream creaFileDiLog(string codiceEnte) {
            if (txtFolder.Text == "") return null;

            string fileName = txtFolder.Text + "\\" + codiceEnte + ".log";
            try {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                fs.Close();
                return fs;
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Errore nella creazione del file di log. Operazione Interrotta!" + ex.Message);
            }
            return null;
        }

        private void aggiungiRigaLog(TextWriter tw, string info) {
            tw.WriteLine(info);
        }

        private void scriviMessaggioChiusura(TextWriter tw, int righeAggiunte) {
            string messaggioRighe = "";
            if (righeAggiunte != 0) {
                messaggioRighe = "Sono state aggiunte " + righeAggiunte + " righe";
            }
            else {
                messaggioRighe = "Non è stata aggiunta nessuna riga";
            }
            aggiungiRigaLog(tw, messaggioRighe);
        }

        private void saveData() {
            PostData pd = new PostData();
            pd.InitClass(dsImporta, Meta.Conn);
            if (!pd.DO_POST()) {
                MessageBox.Show(this, "Errore in fase di salvataggio dei dati. Procedura annullata");
                return;
            }
            string messaggio = "Procedura terminata correttamente!\nSi consiglia, prima di procedere con un altra "
                + "importazione, di controllare la correttezza dei dati inseriti.\n";
            MessageBox.Show(this, messaggio);
        }
        #endregion

        private void aggiornaForm(string testo) {
            lblTabella.Text = testo;
            if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
            Application.DoEvents();
        }

        private void btnFolder_Click(object sender, EventArgs e) {
            DialogResult dr = dlgFolder.ShowDialog();
            if (dr == DialogResult.OK) {
                txtFolder.Text = dlgFolder.SelectedPath;
            }
        }
    }
}
