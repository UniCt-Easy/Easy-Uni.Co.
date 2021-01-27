
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
using System.IO;

namespace no_table_expbank {
    public partial class FrmExpBank : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        string fileExtension = "txt";

        public FrmExpBank() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
        }

        public void MetaData_AfterClear() {
            DataRow[] r = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (r.Length > 0) {
                HelpForm.SetComboBoxValue(cmbIstitutoCassiere, r[0]["idtreasurer"]);
            }
            Text = "Trasmissione elettronica delle distinte alla banca";
        }

        public void MetaData_AfterRowSelect(DataTable t, DataRow r) {
            if (r == null) return;
            txtCartella.Text = r["savepath"].ToString();
            fileExtension = r["fileextension"].ToString();
            if (fileExtension.StartsWith(".")) fileExtension = fileExtension.Substring(1);
            if (fileExtension == "") {
                fileExtension = "txt";
            }
            if (r["flagmultiexp"].ToString() != "S") {
                lblDa.Text = "N°";
                lblA.Visible = false;
                txtA.Visible = false;
            }
            else {
                lblDa.Text = "Da";
                lblA.Visible = true;
                txtA.Visible = true;
            }
        }

        private void btnGeneraFile_Click(object sender, EventArgs e) {
            GeneraFile(true);
        }

        private void GeneraFile(bool Mandati) {
            DataRow rTesoriere = HelpForm.GetLastSelected(DS.treasurer);
            if (rTesoriere == null) {
                HelpForm.FocusControl(cmbIstitutoCassiere);
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Scegliere l'istituto cassiere");
                return;
            }
            string idbank = rTesoriere["idbank"].ToString();
            bool res = false;
            foreach (string s in new string[] { "03111", "03067", "01030", "02008", "01010"}) {
                if (s == idbank) res = true;
            }
            if (!res) {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
                    "Questa maschera non dovrebbe essere usata con il cassiere selezionato. Usare, invece, la maschera alla voce di menu Cassiere - Trasmissione e Importazione Distinte XML. " +
					" Si desidera proseguire comunque l''elaborazione?", "Errore",
					  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

            string sp_export = Mandati ? rTesoriere["spexportexp"].ToString() : rTesoriere["spexportinc"].ToString();
            if (sp_export == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                    "Nella configurazione del tesoriere non è impostata la sp da chiamare per generare il file");
                return;
            }
            string flagMultiExp = rTesoriere["flagmultiexp"].ToString();
            int da = CfgFn.GetNoNullInt32(txtDa.Text);
            int a = CfgFn.GetNoNullInt32(txtA.Text);
            if (flagMultiExp == "S") {
                if (da == 0) {
                    HelpForm.FocusControl(txtDa);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il numero della prima distinta che si vuole trasmettere");
                    return;
                }
                if (a == 0) {
                    HelpForm.FocusControl(txtA);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il numero dell'ultima distinta che si vuole trasmettere");
                    return;
                }
            }
            else {
                if (da == 0) {
                    HelpForm.FocusControl(txtDa);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il numero della distinta che si vuole trasmettere");
                    return;
                }
            }
            // Controlla che il cassiere della/e distinta/e sia uguale a quello scelto nel combo.
            string Filter = "";
            if (Mandati) {
                if (flagMultiExp == "S") {
                    for (int i = da; i <= a; i++) {
                        Filter = QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", Meta.GetSys("esercizio")),
                            QHS.CmpEq("npaymenttransmission", i));
                        object idtreasurer = Meta.Conn.DO_READ_VALUE("paymenttransmission", Filter, "idtreasurer");
                        if (idtreasurer == null) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                               "La distinta n." + i.ToString() + " non è presente su db","Errore");
                            return;
                        }
                        if (idtreasurer.ToString() != rTesoriere["idtreasurer"].ToString()) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                                "La distinta n." + i.ToString() + " ha un Cassiere diverso da quello selezionato!");
                            return;
                        }

                        object flagtransmissionenabled = Meta.Conn.DO_READ_VALUE("paymenttransmission", Filter,
                            "flagtransmissionenabled");
                        object cfgflagenabletransmission = Meta.Conn.DO_READ_VALUE("config",
                            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "flagenabletransmission");

                        if (cfgflagenabletransmission != DBNull.Value) {
                            string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                            if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La trasmissione della distinta non è stata autorizzata");
                                return;
                            }
                        }

                    }
                }
                else {
                    Filter = QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", Meta.GetSys("esercizio")),
                        QHS.CmpEq("npaymenttransmission", da));
                    object idtreasurer = Meta.Conn.DO_READ_VALUE("paymenttransmission", Filter, "idtreasurer");
                    if (idtreasurer == null) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                           "La distinta n." + da.ToString() + " non è presente su db", "Errore");
                        return;
                    }
                    if (idtreasurer.ToString() != rTesoriere["idtreasurer"].ToString()) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                            "La distinta n." + da.ToString() + " ha un Cassiere diverso da quello selezionato!");
                        return;
                    }
                    object flagtransmissionenabled = Meta.Conn.DO_READ_VALUE("paymenttransmission", Filter,
                        "flagtransmissionenabled");
                    object cfgflagenabletransmission = Meta.Conn.DO_READ_VALUE("config",
                        QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "flagenabletransmission");

                    if (cfgflagenabletransmission != DBNull.Value) {
                        string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                        if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La trasmissione della distinta non è stata autorizzata");
                            return;
                        }
                    }
                }
            }
            else {
                if (flagMultiExp == "S") {
                    for (int i = da; i <= a; i++) {
                        Filter = QHS.AppAnd(QHS.CmpEq("yproceedstransmission", Meta.GetSys("esercizio")),
                            QHS.CmpEq("nproceedstransmission", i));
                        object idtreasurer = Meta.Conn.DO_READ_VALUE("proceedstransmission", Filter, "idtreasurer");
                        if (idtreasurer == null) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                               "La distinta n." + i.ToString() + " non è presente su db", "Errore");
                            return;
                        }
                        if (idtreasurer.ToString() != rTesoriere["idtreasurer"].ToString()) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                                "La distinta n." + i.ToString() + " ha un Cassiere diverso da quello selezionato!");
                            return;
                        }

                        object flagtransmissionenabled = Meta.Conn.DO_READ_VALUE("proceedstransmission", Filter,
                            "flagtransmissionenabled");
                        object cfgflagenabletransmission = Meta.Conn.DO_READ_VALUE("config",
                            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "flagenabletransmission");

                        if (cfgflagenabletransmission != DBNull.Value) {
                            string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                            if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La trasmissione della distinta non è stata autorizzata");
                                return;
                            }
                        }
                    }
                }
                else {
                    Filter = QHS.AppAnd(QHS.CmpEq("yproceedstransmission", Meta.GetSys("esercizio")),
                        QHS.CmpEq("nproceedstransmission", da));
                    object idtreasurer = Meta.Conn.DO_READ_VALUE("proceedstransmission", Filter, "idtreasurer");
                    if (idtreasurer == null) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                           "La distinta n." + da.ToString() + " non è presente su db", "Errore");
                        return;
                    }
                    if (idtreasurer.ToString() != rTesoriere["idtreasurer"].ToString()) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                            "La distinta n." + da.ToString() + " ha un Cassiere diverso da quello selezionato!");
                        return;
                    }
                    object flagtransmissionenabled = Meta.Conn.DO_READ_VALUE("proceedstransmission", Filter,
                        "flagtransmissionenabled");
                    object cfgflagenabletransmission = Meta.Conn.DO_READ_VALUE("config",
                        QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "flagenabletransmission");

                    if (cfgflagenabletransmission != DBNull.Value) {
                        string cfg_flag = cfgflagenabletransmission.ToString().ToUpper();
                        if ((cfg_flag == "S") && (flagtransmissionenabled.ToString().ToUpper() != "S")) {
                            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La trasmissione della distinta non è stata autorizzata");
                            return;
                        }
                    }
                }
            }

            object[] parametri = flagMultiExp == "S"
                ? new object[] {Meta.GetSys("esercizio"), da, a}
                : new object[] {Meta.GetSys("esercizio"), da};
            DataSet result = Meta.Conn.CallSP(sp_export, parametri, false, 300);
            if ((result == null) || (result.Tables.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La sp non ha restituito risultati");
                return;
            }
            DataTable t = result.Tables[0];
            dataGrid1.TableStyles.Clear();
            dataGrid1.DataSource = null;
            if (t.Columns.Contains("message")) {
                t.Columns["message"].Caption = "Spiegazione errore";
                HelpForm.SetDataGrid(dataGrid1, t);
                formatgrids FF = new formatgrids(dataGrid1);
                FF.AutosizeColumnWidth();
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Ci sono degli errori, pertanto non è stato generato il file!");
                return;
            }
            if (txtCartella.Text == "") {
                DialogResult dr = folderBrowserDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    txtCartella.Text = folderBrowserDialog1.SelectedPath;
                }
                else {
                    folderBrowserDialog1.SelectedPath = txtCartella.Text;
                    HelpForm.FocusControl(txtCartella);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il percorso del file");
                    return;
                }
            }

            string nomeFile = Mandati
                ? Meta.GetSys("esercizio") + "_mandato" + "_" + da
                : Meta.GetSys("esercizio") + "_reversale" + "_" + da;

            if (flagMultiExp == "S") {
                if (da != a) {
                    nomeFile = Mandati
                        ? Meta.GetSys("esercizio") + "_mandati"
                        : Meta.GetSys("esercizio") + "_reversali";
                    for (int i = da; i <= a; i++) {
                        nomeFile += "_" + i;
                    }
                }
            }
            txtFile.Text = Path.Combine(txtCartella.Text, nomeFile + "." + fileExtension);
            try {
                StreamWriter sw = new StreamWriter(txtFile.Text, false, Encoding.Default);
                foreach (DataRow r in t.Rows) {
                    sw.WriteLine(r[0]);
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception e1) {
                QueryCreator.ShowException("Errore nel salvataggio del file " + txtFile.Text, e1);
                return;
            }

            int year = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            if (flagMultiExp == "S") {
                if (da != a) {
                    for (int i = da; i <= a; i++) {
                        if (Mandati)
                            AggiornaStreamDate("PAYMENTTRANSMISSION", year, i);
                        else
                            AggiornaStreamDate("PROCEEDSTRANSMISSION", year, i);

                    }
                }
            }

            if (Mandati)
                AggiornaStreamDate("PAYMENTTRANSMISSION", year, da);
            else
                AggiornaStreamDate("PROCEEDSTRANSMISSION", year, da);

            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "File della trasmissione salvato in " + txtFile.Text);
        }

        private void AggiornaStreamDate(string tablename, int y, int n) {
            string updateTo = " UPDATE " + tablename +
                              " SET  " + tablename + ".STREAMDATE = GETDATE(), " +
                              " LT = GETDATE(), LU = 'automatico'" +
                              " WHERE Y" + tablename + " = " + y.ToString() + " AND " +
                              " N" + tablename + " = " + n.ToString() +
                              " AND STREAMDATE IS NULL ";
            string errMsg;
            Meta.Conn.SQLRunner(updateTo, -1, out errMsg);
        }

        private void btnPercorso_Click(object sender, EventArgs e) {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtCartella.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGeneraFileReversali_Click(object sender, EventArgs e) {
            GeneraFile(false);
        }

        private void btnGeneraUltimaDistMandati_Click(object sender, EventArgs e) {
            GeneraFileUltimaDistinta(true);
        }

        private void btnGeneraUltimaDistReversali_Click(object sender, EventArgs e) {
            GeneraFileUltimaDistinta(false);
        }

        private void GeneraFileUltimaDistinta(bool Mandati) {
            DataRow rTesoriere = HelpForm.GetLastSelected(DS.treasurer);
            if (rTesoriere == null) {
                HelpForm.FocusControl(cmbIstitutoCassiere);
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Scegliere l'istituto cassiere");
                return;
            }
            string sp_export = Mandati ? rTesoriere["spexportexp"].ToString() : rTesoriere["spexportinc"].ToString();
            if (sp_export == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                    "Nella configurazione del tesoriere non è impostata la sp da chiamare per generare il file");
                return;
            }

            string Filter = "";
            int nDoc = 0;
            if (Mandati) {
                Filter = QHS.AppAnd(QHS.CmpEq("ypaymenttransmission", Meta.GetSys("esercizio")),
                    QHS.CmpEq("idtreasurer", rTesoriere["idtreasurer"]));
                nDoc =
                    CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("paymenttransmission", Filter,
                        "MAX(npaymenttransmission)"));
            }
            else {
                Filter = QHS.AppAnd(QHS.CmpEq("yproceedstransmission", Meta.GetSys("esercizio")),
                    QHS.CmpEq("idtreasurer", rTesoriere["idtreasurer"]));
                nDoc =
                    CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("proceedstransmission", Filter,
                        "MAX(nproceedstransmission)"));
            }
            if (nDoc == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Non vi sono distinte.");
                return;
            }

            object[] parametri = new object[] {Meta.GetSys("esercizio"), nDoc};
            DataSet result = Meta.Conn.CallSP(sp_export, parametri, false, 300);
            if ((result == null) || (result.Tables.Count == 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La sp non ha restituito risultati");
                return;
            }
            DataTable t = result.Tables[0];
            dataGrid1.TableStyles.Clear();
            dataGrid1.DataSource = null;
            if (t.Columns.Contains("message")) {
                t.Columns["message"].Caption = "Spiegazione errore";
                HelpForm.SetDataGrid(dataGrid1, t);
                formatgrids FF = new formatgrids(dataGrid1);
                FF.AutosizeColumnWidth();
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Ci sono degli errori, pertanto non è stato generato il file!");
                return;
            }
            if (txtCartella.Text == "") {
                DialogResult dr = folderBrowserDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    txtCartella.Text = folderBrowserDialog1.SelectedPath;
                }
                else {
                    folderBrowserDialog1.SelectedPath = txtCartella.Text;
                    HelpForm.FocusControl(txtCartella);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il percorso del file");
                    return;
                }
            }

            string nomeFile = Mandati
                ? Meta.GetSys("esercizio") + "_mandato" + "_" + nDoc
                : Meta.GetSys("esercizio") + "_reversale" + "_" + nDoc;

            txtFile.Text = Path.Combine(txtCartella.Text, nomeFile + "." + fileExtension);
            try {
                StreamWriter sw = new StreamWriter(txtFile.Text, false, Encoding.Default);
                foreach (DataRow r in t.Rows) {
                    sw.WriteLine(r[0]);
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception e1) {
                QueryCreator.ShowException("Errore nel salvataggio del file " + txtFile.Text, e1);
                return;
            }
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "File della trasmissione salvato in " + txtFile.Text);
        }
    }
}
