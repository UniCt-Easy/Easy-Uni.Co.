
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
using System.IO;
using metadatalibrary;
using System.Collections;
using LiveUpdate;

namespace assetacquire_export {
    public partial class FrmAssetAcquire_Export : MetaDataForm {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        bool esportaAnagrafica = false;
        DataSet dsEsporta = new DataSet();

        ISaveFileDialog saveFile;
        IFolderBrowserDialog folderDlg;

        public FrmAssetAcquire_Export() {
            InitializeComponent();
            saveFile = createSaveFileDialog(_saveFile);
            folderDlg = createFolderBrowserDialog(_folderDlg);
        }

        int nPassi = 6;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Text = "Esportazione Dati Patrimonio";
            ClearDataSet.RemoveConstraints(dsEsporta);
            GetData.CacheTable(DS.inventoryagency, null, "description", true);
            dsEsporta.DataSetName = "dsEsporta";
        }

        public void MetaData_AfterActivation() {
            aggiustaFormCaption();
        }

        public void MetaData_AfterClear() {
            aggiustaFormCaption();
        }

        private void aggiustaFormCaption() {
            string formCaption = this.Text;
            string token = "(Ricerca)";
            if (formCaption.EndsWith(token)) {
                this.Text = formCaption.Replace(token, "");
            }
        }

        object enteScelto;
        object codiceEnteScelto;
        private void btnEsporta_Click(object sender, System.EventArgs e) {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = nPassi;
            int indiceEnte = cmbEnte.SelectedIndex;
            if (cmbEnte.SelectedIndex <= 0) {
	            Meta.showClientMsg("Selezionare l'ente", "Errore", MessageBoxButtons.OK);
	            return;
            }
            enteScelto = cmbEnte.SelectedValue;
            codiceEnteScelto = DS.inventoryagency.Select(QHC.CmpEq("idinventoryagency", enteScelto))[0]["codeinventoryagency"];
            string path = txtPath.Text;

            string messaggio = "Mancano i seguenti dati per eseguire l'esportazione:";
            bool visualizzaMessaggio = false;

            if (indiceEnte <= 0) {
                messaggio += "\nEnte Inventariale";
                visualizzaMessaggio = true;
            }

            if (path == "") {
                messaggio += "\nIl percorso del file da salvare";
                visualizzaMessaggio = true;
            }

            if (visualizzaMessaggio) {
                show(this, messaggio);
                return;
            }
            dsEsporta.Clear();
            progressBar1.Value = 0;

            esportaAnagrafica = chkAnagrafica.Checked;
            if (!riempiTabelle()) {
                show(this, "Si è verificato un errore. Processo Interrotto. Il file non verrà generato", "Errore");
                return;
            }
            salvaFile();
        }

        private void aggiornaForm(string testo) {
            lblTabella.Text = testo;
            if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
            Application.DoEvents();
        }

        private void salvaFile() {
            if ((codiceEnteScelto == null) || (codiceEnteScelto == DBNull.Value)) {
                show(this, "Attenzione!, l'ente selezionato non esiste in archivio! Chiamare l'assistenza");
                return;
            }
            string path = txtPath.Text;
            string fileName = path + "\\" + codiceEnteScelto.ToString() + ".exp";
            try {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                dsEsporta.WriteXml(fs, XmlWriteMode.WriteSchema);
                fs.Close();
            }
            catch (Exception ex) {
                show(this, "Impossibile generare il file\n" + ex.Message);
                return;
            }

            valorizzaFlagTransmitted();

            show(this, "File generato correttamente. Il percorso dove trovare il file è: " + fileName);
            azzeraDataSet();
            dsEsporta.Clear();
        }

        private void valorizzaFlagTransmitted() {
            StringBuilder SB = new StringBuilder();

            // Update su ASSET
            string q1 =
                "UPDATE asset SET transmitted = 'S' "
                + " WHERE (transmitted = 'N') OR  EXISTS "
                + " (SELECT ac.nassetacquire FROM assetacquire ac "
                + " JOIN inventory i "
                + " ON i.idinventory = ac.idinventory "
                + " WHERE ("
                + " ac.nassetacquire = asset.nassetacquire AND "
                + " (" + QHS.IsNull("asset.transmitted") + " AND "
                + " ((" + QHS.IsNotNull("asset.idassetunload") + " OR " + QHS.DoPar(QHS.AppAnd(QHS.IsNull("asset.idassetunload"), QHS.BitClear("asset.flag", 0))) + ") "
                + " OR ((ac.idassetload IS NOT NULL) OR " + QHS.DoPar(QHS.AppAnd(QHS.IsNull("ac.idassetload"), QHS.BitClear("ac.flag", 0))) + ")))) "
                + " AND i.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true)
                + ")";

            ArrayList elencoBeni = new ArrayList();

            string filter = "";
            foreach (DataRow rBene in dsEsporta.Tables["assetamortization"].Rows) {
                string idasset_piece = rBene["idasset"].ToString() + "," + rBene["idpiece"].ToString();
                if (elencoBeni.Contains(idasset_piece)) continue;
                elencoBeni.Add(idasset_piece);

                filter = QHS.AppOr(filter, 
                    QHS.DoPar(
                    QHS.AppAnd(QHS.CmpEq("idasset", rBene["idasset"]), QHS.CmpEq("idpiece", rBene["idpiece"]))));
            }

            if (filter != "") {
                q1 = QHS.AppOr(q1, QHS.DoPar(filter));
            }

            SB.Append(q1);
            SB.Append("\n\rGO\n\r");

            // Update su ASSETACQUIRE
            string q2 =
                "UPDATE assetacquire SET transmitted = 'S' "
                + " WHERE EXISTS "
                + "(SELECT i.idinventory FROM inventory i "
                + " WHERE "
                + " ((assetacquire.transmitted IS NULL) "
                + "	AND ((assetacquire.idassetload IS NOT NULL) "
                + " OR " + QHS.DoPar(QHS.AppAnd(QHS.IsNull("assetacquire.idassetload"), QHS.BitClear("assetacquire.flag",0))) + "))"
                + " AND i.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true)
                + " AND assetacquire.idinventory = i.idinventory)"
                + " OR (transmitted = 'N')";

            SB.Append(q2);
            SB.Append("\n\rGO\n\r");

            // Update su ASSETAMORTIZATION
            string q3 =
                "UPDATE assetamortization SET transmitted = 'S' "
                + " WHERE EXISTS "
                + "(SELECT A.idasset FROM asset A "
                + " JOIN assetacquire ac "
                + " ON ac.nassetacquire = A.nassetacquire "
                + " JOIN inventory I "
                + " ON I.idinventory = ac.idinventory "
                + " WHERE ((assetamortization.transmitted IS NULL) "
                + " AND ((assetamortization.idassetunload IS NOT NULL) "
                + " OR " + QHS.DoPar(QHS.AppAnd(QHS.IsNull("assetamortization.idassetunload"), QHS.BitClear("assetamortization.flag", 0))) + "))"
                + " AND I.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true)
                + " AND assetamortization.idasset = A.idasset AND assetamortization.idpiece = A.idpiece)"
                + " OR (transmitted = 'N')";

            SB.Append(q3);
            SB.Append("\n\rGO\n\r");

            // Update su ASSETLOAD
            string q4 =
                "UPDATE assetload SET transmitted = 'S' "
                + " WHERE EXISTS "
                + " (SELECT TBC.idassetloadkind FROM assetloadkind TBC "
                + " JOIN inventory I ON I.idinventory = TBC.idinventory "
                + " WHERE (ISNULL(assetload.transmitted,'N') = 'N') "
                + " AND (I.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true)
                + ") AND TBC.idassetloadkind = assetload.idassetloadkind)";

            SB.Append(q4);
            SB.Append("\n\rGO\n\r");
            // Update su ASSETUNLOAD
            string q5 =
                "UPDATE assetunload SET transmitted = 'S' "
                + " WHERE EXISTS "
                + " (SELECT TBC.idassetunloadkind FROM assetunloadkind TBC "
                + " JOIN inventory I ON I.idinventory = TBC.idinventory "
                + " WHERE (ISNULL(assetunload.transmitted,'N') = 'N') "
                + " AND (I.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true)
                + ") AND TBC.idassetunloadkind = assetunload.idassetunloadkind)";

            SB.Append(q5);
            SB.Append("\n\rGO\n\r");

            if (SB.ToString() != "") {
                string error;
                Download.RUN_SCRIPT(Meta.Conn, SB, out error);
            }
            
        }

        string getKeyFilter(DataRow R, string tName) {
            string filter = "";
            switch (tName) {
                case "asset": {
                        filter = QHS.MCmp(R, new string[] {"idasset", "idpiece"});
                        break;
                    }
                case "assetamortization": {
                        filter = QHS.CmpEq("namortization", R["namortization"]);
                        break;
                    }
                case "assetload": {
                        filter = QHS.CmpEq("idassetload", R["idassetload"]);
                        break;
                    }
                case "assetunload": {
                        filter = QHS.CmpEq("idassetunload", R["idassetunload"]);
                        break;
                    }
                case "assetacquire": {
                        filter = QHS.CmpEq("nassetacquire", R["nassetacquire"]);
                        break;
                    }
            }

            return filter;
        }

        private void azzeraDataSet() {
            dsEsporta.Clear();

            ArrayList A = new ArrayList(10);
            foreach (DataTable t in dsEsporta.Tables) {
                A.Add(t);
            }
            foreach (DataTable t in A) {
                dsEsporta.Tables.Remove(t);
            }
            dsEsporta.AcceptChanges();
        }
        /// Passo 1.
        /// <summary>
        /// Metodo che riempie le rivalutazioni bene
        /// Vengono prese tutte le rivalutazioni comprese negli esercizi di inizio e fine
        /// </summary>
        /// <param name="esercizioInizio">Esercizio di Inizio</param>
        /// <param name="esercizioFine">Esercizio di Fine</param>
        private bool riempiAssetAmortization() {
            string testo = "Rivalutazione Cespite Inventario";
            aggiornaForm(testo);
            string listaCampi = "R.namortization, R.idinventoryamortization, "
                + "IA.codeinventoryamortization AS '!codeinventoryamortization', "
                + "R.idasset, R.idpiece, R.description, "
                + "R.assetvalue, R.amortizationquota, R.adate, R.flag, R.idassetunload, " 
                + "U.idassetunloadkind AS '!idassetunloadkind', U.nassetunload AS '!nassetunload', "
                + "U.codeassetunloadkind AS '!codeassetunloadkind', "
                + "U.yassetunload AS '!yassetunload', R.transmitted, A.idinventory AS '!idinventory', "
                + "I.codeinventory AS '!codeinventory', A.ninventory AS '!ninventory' ";

            string stringaSQL = "SELECT " + listaCampi
            + " FROM assetamortization R "
            + " JOIN inventoryamortization IA "
            + " ON R.idinventoryamortization = IA.idinventoryamortization "
            + " LEFT OUTER JOIN assetunloadview U "
            + " ON U.idassetunload = R.idassetunload "
            + " JOIN assetview A "
            + " ON A.idasset = R.idasset AND A.idpiece = R.idpiece "
            + " JOIN inventory I "
            + " ON I.idinventory = A.idinventory "
            + " WHERE " + QHS.CmpEq("R.transmitted", 'N')
            + " OR (" + QHS.IsNull("R.transmitted")
            + " AND ( " + QHS.IsNotNull("R.idassetunload")
            + " OR (" + QHS.AppAnd(QHS.IsNull("R.idassetunload"), QHS.BitClear("R.flag",0)) + ")))"
            + " AND " + QHS.CmpEq("I.idinventoryagency", enteScelto);

            return scriviInTabella(stringaSQL, "assetamortization");
        }

        /// Passo 2.
        /// <summary>
        /// Metodo che riempie i carichi bene.
        /// Vengono presi i carichi bene associati a buoni di carico dell'esercizio e i carichi beni
        /// collegati a buoni di scarico dell'anno
        /// </summary>
        /// <param name="esercizioInizio">Esercizio Iniziale</param>
        /// <param name="esercizioFine">Esercizio Finale</param>
        private bool riempiAssetAcquire() {
            string testo = "Carico Cespite Inventario";
            aggiornaForm(testo);
            string listaCampi = "c.nassetacquire, c.idmot, M.codemot AS '!codemot', c.idinv, it.codeinv as '!codeinv', "
                + " c.description, L.idassetloadkind AS '!idassetloadkind', c.idinventory, "
                + " L.codeassetloadkind AS '!codeassetloadkind', "
                + " i.codeinventory AS '!codeinventory', c.idassetload, "
                + " L.nassetload AS '!nassetload', c.number, c.taxable, c.tax, c.discount, L.yassetload AS '!yassetload', "
                + " c.startnumber, c.adate, c.flag, c.abatable, c.taxrate, c.transmitted ";

            if (esportaAnagrafica) {
                listaCampi += ",c.idreg";
            }
            
            string stringaSQL = 
                "SELECT " + listaCampi
                + " FROM assetacquire c "
                + " LEFT OUTER JOIN assetloadmotive M "
                + " ON M.idmot = c.idmot "
                + " LEFT OUTER JOIN assetloadview L "
                + " ON L.idassetload = c.idassetload "
                + " JOIN inventory i "
                + " ON i.idinventory = c.idinventory "
                + " JOIN inventorytree it "
                + " ON it.idinv = c.idinv "
                + " WHERE " + QHS.CmpEq("c.transmitted", 'N')
                + " OR (" + QHS.IsNull("c.transmitted")
                + "	AND (" + QHS.IsNotNull("c.idassetload")
                + " OR (" + QHS.AppAnd(QHS.IsNull("c.idassetload"), QHS.BitClear("c.flag", 0)) + ")))"
                + " AND " + QHS.CmpEq("i.idinventoryagency", enteScelto);

            ArrayList elencoBeni = new ArrayList();

            string filter = "";
            foreach (DataRow rBene in dsEsporta.Tables["assetamortization"].Rows) {
                string idasset_piece = rBene["idasset"].ToString() + "," + rBene["idpiece"].ToString();
                if (elencoBeni.Contains(idasset_piece)) continue;
                elencoBeni.Add(idasset_piece);
                filter = QHS.AppOr(filter,
                    QHS.DoPar(
                    QHS.AppAnd(QHS.CmpEq("idasset", rBene["idasset"]), QHS.CmpEq("idpiece", rBene["idpiece"]))));
            }

            if (filter != "") {
                stringaSQL += " UNION (SELECT " + listaCampi
                    + " FROM assetacquire c "
                    + " LEFT OUTER JOIN assetloadmotive M "
                    + " ON M.idmot = c.idmot "
                    + " LEFT OUTER JOIN assetloadview L "
                    + " ON L.idassetload = c.idassetload "
                    + " JOIN inventory i "
                    + " ON i.idinventory = c.idinventory "
                    + " JOIN inventorytree it "
                    + " ON it.idinv = c.idinv "
                    + " JOIN asset b "
                    + " ON c.nassetacquire = b.nassetacquire "
                    + " WHERE " + filter + ")";
            }

            return scriviInTabella(stringaSQL, "assetacquire");
        }

        // Passo 3.
        private bool riempiAssetLoad() {
            string testo = "Buono Carico Inventario";
            aggiornaForm(testo);
            string listaCampi = "A.idassetloadkind, A.yassetload, A.nassetload, "
                + "TBC.codeassetloadkind AS '!codeassetloadkind', "
                + "A.idmot, M.codemot AS '!codemot', A.doc, A.docdate, A.txt, A.rtf, A.transmitted, "
                + "A.description, A.enactment, A.enactmentdate, A.adate, A.printdate, "
                + "A.ratificationdate, I.codeinventory AS 'I.codeinventory'";
            if (esportaAnagrafica) {
                listaCampi += ", A.idreg";
            }

            string stringaSQL = "SELECT " + listaCampi
                + " FROM assetload A"
                + " LEFT OUTER JOIN assetloadmotive M "
                + " ON M.idmot = A.idmot "
                + " JOIN assetloadkind TBC ON A.idassetloadkind = TBC.idassetloadkind "
                + " JOIN inventory I ON I.idinventory = TBC.idinventory "
                + " WHERE (ISNULL(A.transmitted,'N') = 'N') "
                + " AND (I.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto,true) + ")";

            return scriviInTabella(stringaSQL, "assetload");
        }

        // Passo 4.
        private bool riempiAssetUnload() {
            string testo = "Buono Scarico Inventario";
            aggiornaForm(testo);
            string listaCampi = "A.idassetunloadkind, A.yassetunload, A.nassetunload,  "
                + "TBC.codeassetunloadkind AS '!codeassetunloadkind', "
                + "A.idmot, M.codemot AS '!codemot', A.doc, A.docdate, A.ratificationdate, A.transmitted, "
                + "A.description, A.enactment, A.enactmentdate, A.adate, A.printdate, "
                + "A.txt, A.rtf, I.codeinventory AS 'I.codeinventory'";
            if (esportaAnagrafica) {
                listaCampi += ", A.idreg";
            }

            // Attenzione per i buoni di scarico non viene considerata la data di ratifica
            string stringaSQL = "SELECT " + listaCampi
                + " FROM assetunload A"
                + " LEFT OUTER JOIN assetunloadmotive M "
                + " ON M.idmot = A.idmot "
                + " JOIN assetunloadkind TBC ON A.idassetunloadkind = TBC.idassetunloadkind "
                + " JOIN inventory I ON I.idinventory = TBC.idinventory "
                + " WHERE (ISNULL(A.transmitted,'N') = 'N') "
                + " AND (I.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true) + ")";

            return scriviInTabella(stringaSQL, "assetunload");
        }

        // Passo 8.
        private bool riempiAsset() {
            string testo = "Bene Inventariabile";
            aggiornaForm(testo);

            string listaCampi = "b.idasset, b.idpiece, b.idassetunloadkind AS '!idassetunloadkind', b.lifestart, "
            + " b.nassetacquire, b.nassetunload, "
            + " b.ninventory, b.yassetunload, b.flag, b.flagunload, b.transmitted, k.codeassetunloadkind, "
            + " b.idinventory AS '!idinventory', i.codeinventory AS '!codeinventory', b.idassetunload ";
            string stringaSQL = "SELECT " + listaCampi
            + " FROM assetview b " 
            + " LEFT OUTER JOIN assetunloadkind k "
            + " ON k.idassetunloadkind = b.idassetunloadkind "
            + " JOIN inventory i "
            + " ON i.idinventory = b.idinventory "
            + " WHERE ((b.transmitted = 'N') OR "
            + " (ISNULL((SELECT au.transmitted FROM assetunload au "
            + " WHERE au.idassetunload = b.idassetunload),'N') = 'N' "
            + " AND b.idassetunload IS NOT NULL) OR "
            + " ((b.transmitted IS NULL) AND "
            + " (((b.idassetunload IS NOT NULL) OR ((b.idassetunload IS NULL) AND (b.flagunload = 'N'))) "
            + " OR ((b.idassetload IS NOT NULL) OR (b.idassetload IS NULL AND b.flagload = 'N'))))) "
            + " AND i.idinventoryagency = " + QueryCreator.quotedstrvalue(enteScelto, true);

            return scriviInTabella(stringaSQL, "asset");
        }

        private bool riempiTabelle() {
            if (!riempiAssetAmortization()) {
                show(this, "Errore nel caricamento della tabella ASSETAMORTIZATION!\nImpossibile proseguire");
                return false;
            }

            if (!riempiAssetAcquire()) {
                show(this, "Errore nel caricamento della tabella ASSETACQUIRE!\nImpossibile proseguire");
                return false;
            }

            if (!riempiAsset()) {
                show(this, "Errore nel caricamento della tabella ASSET!\nImpossibile proseguire");
                return false;
            }

            if (!riempiAssetLoad()) {
                show(this, "Errore nel caricamento della tabella ASSETLOAD!\nImpossibile proseguire");
                return false;
            }

            if (!riempiAssetUnload()) {
                show(this, "Errore nel caricamento della tabella ASSETUNLOAD!\nImpossibile proseguire");
                return false;
            }

            if (esportaAnagrafica) {
                if (!riempiRegistry()) {
                    show(this, "Errore nel caricamento della tabella REGISTRY!\nImpossibile proseguire");
                    return false;
                }
            }

            dsEsporta.AcceptChanges();
            return true;
        }

        // Passo 9.
        private bool riempiRegistry() {
            string testo = "Anagrafica";
            aggiornaForm(testo);
            ArrayList elencoCreditori = new ArrayList();
            foreach (DataRow rBuono in dsEsporta.Tables["assetload"].Rows) {
                if (rBuono["idreg"] == DBNull.Value) continue;
                if (elencoCreditori.Contains(rBuono["idreg"])) continue;
                elencoCreditori.Add(rBuono["idreg"]);
            }

            foreach (DataRow rBuono in dsEsporta.Tables["assetunload"].Rows) {
                if (rBuono["idreg"] == DBNull.Value) continue;
                if (elencoCreditori.Contains(rBuono["idreg"])) continue;
                elencoCreditori.Add(rBuono["idreg"]);
            }

            foreach (DataRow rCarico in dsEsporta.Tables["assetacquire"].Rows) {
                if (rCarico["idreg"] == DBNull.Value) continue;
                if (elencoCreditori.Contains(rCarico["idreg"])) continue;
                elencoCreditori.Add(rCarico["idreg"]);
            }

            if (elencoCreditori.Count == 0) return true;
            string filter = "";
            foreach (object o in elencoCreditori) {
                if (filter == "") {
                    filter = "(" + o.ToString();
                }
                else {
                    filter += "," + o.ToString();
                }
            }
            filter += ")";
            filter = "(idreg IN " + filter + ")";
            DataTable tRegistry = DataAccess.CreateTableByName(Meta.Conn, "registry", "idreg, title");
            dsEsporta.Tables.Add(tRegistry);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsEsporta.Tables["registry"], null, filter, null, true);
            if (dsEsporta.Tables["registry"] == null) return false;
            return true;
        }

        /// <summary>
        /// Metodo che scrive i dati nella tabella nomeTabella del DataSet da esportare
        /// </summary>
        /// <param name="stringaSQL">Query per il riempimento della tabella</param>
        /// <param name="nomeTabella">Nome della Tabella</param>
        /// <returns></returns>
        private bool scriviInTabella(string stringaSQL, string nomeTabella) {
            DataTable t = Meta.Conn.SQLRunner(stringaSQL);
            if (t == null) return false;
            t.TableName = nomeTabella;
            dsEsporta.Tables.Add(t);
            //foreach (DataRow r in t.Rows) {
            //    MetaData MetaTabella = MetaData.GetMetaData(this, nomeTabella);
            //    MetaTabella.SetDefaults(dsEsporta.Tables[nomeTabella]);

            //    DataRow newRow = MetaTabella.Get_New_Row(null, dsEsporta.Tables[nomeTabella]);
            //    foreach (DataColumn C in t.Columns) {
            //        newRow[C.ColumnName] = r[C];
            //    }
            //}
            return true;
        }

        private void btnPath_Click(object sender, EventArgs e) {
            DialogResult dr = folderDlg.ShowDialog();
            if (dr != DialogResult.OK) return;
            string path = folderDlg.SelectedPath;
            if (path == "") return;
            txtPath.Text = path;
        }
    }
}
