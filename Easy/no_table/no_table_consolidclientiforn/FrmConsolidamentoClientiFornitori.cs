
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
using funzioni_configurazione;
using System.IO;


namespace no_table_consolidclientiforn {
    public partial class FrmConsolidamentoClientiFornitori : MetaDataForm {
        MetaData Meta;
        CQueryHelper QHC;

        ISaveFileDialog saveFileDialog1;
        IFolderBrowserDialog folderBrowserDialog1;

        public FrmConsolidamentoClientiFornitori() {
            InitializeComponent();
            saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
            folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
        }

        private void btnScegliCartella_Click(object sender, EventArgs e) {
            folderBrowserDialog1.SelectedPath = txtCartella.Text;
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtCartella.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnNomeFile_Click(object sender, EventArgs e) {
            saveFileDialog1.FileName = txtFile.Text;
            DialogResult dr = saveFileDialog1.ShowDialog(this);
            txtFile.Text = saveFileDialog1.FileName;
        }

        int esercizio;
        DataRow rCliente, rFornitore;

        private void consolidaClienti(char[] record) {
            for (int i = 1; i < 1681; i += 24) {
                string campo = new string(record, i, 8);
                if (campo != "        ") {
                    string valore = new string(record, i + 8, 16);
                    switch (campo) {
                        case "CL001001": break;
                        case "CL002001": //codice fiscale (obbligatorio dal 2008)
                            if (esercizio >= 2008) {
                                DataRow[] rClienti = DS.cliente.Select(QHC.CmpEq("CL002001", valore));
                                if (rClienti.Length == 0) {
                                    rCliente = DS.cliente.NewRow();
                                    object max = DS.cliente.Compute("max(CL001001)", null);
                                    rCliente["CL001001"] = max == DBNull.Value ? 1 : 1 + (int)max;
                                    rCliente["CL002001"] = valore;
                                }
                                else {
                                    rCliente = rClienti[0];
                                }
                            }
                            break;
                        case "CL003001": //partita iva (da usare fino al 2007)
                            if (esercizio < 2008) {
                                DataRow[] rClienti = DS.cliente.Select(QHC.CmpEq("CL003001", valore));
                                if (rClienti.Length == 0) {
                                    rCliente = DS.cliente.NewRow();
                                    object max = DS.cliente.Compute("max(CL001001)", null);
                                    rCliente["CL001001"] = max==DBNull.Value ? 1 : 1+(int)max;
                                    rCliente["CL003001"] = valore;
                                    DS.cliente.Rows.Add(rCliente);
                                }
                                else {
                                    rCliente = rClienti[0];
                                }
                            }
                            break;
                        case "CL004001":
                        case "CL004002":
                        case "CL005001":
                        case "CL006001":
                        case "CL007001":
                        case "CL008001":
                        case "CL008002":
                        case "CL009001":
                        case "CL010001":
                        case "CL011001":
                            rCliente[campo] = CfgFn.GetNoNullInt32(rCliente[campo]) + int.Parse(valore);
                            break;
                        default:
                            show(this, "Errore nel record 1 dei clienti: '" + campo + "' campo sconosciuto.");
                            break;
                    }
                }
            }
        }

        private void consolidaFornitori(char[] record) {
            for (int i = 1; i < 1681; i += 24) {
                string campo = new string(record, i, 8);
                if (campo != "        ") {
                    string valore = new string(record, i + 8, 16);
                    switch (campo) {
                        case "FR001001": break;
                        case "FR002001": //codice fiscale (obbligatorio dal 2008)
                            if (esercizio >= 2008) {
                                DataRow[] rFornitori = DS.fornitore.Select(QHC.CmpEq("FR002001", valore));
                                if (rFornitori.Length == 0) {
                                    rFornitore = DS.fornitore.NewRow();
                                    object max = DS.fornitore.Compute("max(FR001001)", null);
                                    rFornitore["FR001001"] = max == DBNull.Value ? 1 : 1 + (int)max;
                                    rFornitore["FR002001"] = valore;
                                }
                                else {
                                    rFornitore = rFornitori[0];
                                }
                            }
                            break;
                        case "FR003001": //partita iva (da usare fino al 2007)
                            if (esercizio < 2008) {
                                DataRow[] rFornitori = DS.fornitore.Select(QHC.CmpEq("FR003001", valore));
                                if (rFornitori.Length == 0) {
                                    rFornitore = DS.fornitore.NewRow();
                                    object max = DS.fornitore.Compute("max(FR001001)", null);
                                    rFornitore["FR001001"] = max == DBNull.Value ? 1 : 1 + (int)max;
                                    rFornitore["FR003001"] = valore;
                                    DS.fornitore.Rows.Add(rFornitore);
                                }
                                else {
                                    rFornitore = rFornitori[0];
                                }
                            }
                            break;
                        case "FR004001":
                        case "FR004002":
                        case "FR005001":
                        case "FR006001":
                        case "FR007001":
                        case "FR008001":
                        case "FR009001":
                        case "FR009002":
                        case "FR010001":
                        case "FR011001":
                        case "FR012001":
                        case "FR013001":
                            rFornitore[campo] = CfgFn.GetNoNullInt32(rFornitore[campo]) + int.Parse(valore);
                            break;
                        default:
                            show(this, "Errore nel record 2 dei fornitori: '" + campo + "' campo sconosciuto.");
                            break;
                    }
                }
            }
        }

        private string formattaNumero(object numero, int cifre) {
            return numero.ToString().PadLeft(cifre);
        }

        private string formattaStringa(object stringa, int caratteri) {
            string s = stringa.ToString();
            if (s.Length > caratteri) return s.Substring(0, caratteri);
            return s.PadRight(caratteri);
        }

        private void scriviRecord1(StreamWriter sw) {
            int progr = 0;
            int campiScritti = 0;
            foreach (DataRow rCliente in DS.cliente.Rows) {
                foreach (DataColumn c in DS.cliente.Columns) {
                    if (rCliente[c] != DBNull.Value) {
                        if ((campiScritti % 70) == 0) {
                            sw.Write("1");
                        }
                        sw.Write(c.ColumnName);
                        switch (c.ColumnName) {
                            case "CL001001": sw.Write(formattaNumero(++progr, 16)); break;
                            case "CL002001":
                            case "CL003001": sw.Write(formattaStringa(rCliente[c], 16)); break;
                            default:
                                if (rCliente[c] != DBNull.Value) {
                                    sw.Write(formattaNumero(rCliente[c], 16));
                                }
                                break;
                        }
                        campiScritti++;
                        if ((campiScritti % 70) == 0) {
                            sw.WriteLine("A".PadLeft(117));
                        }
                    }
                }
            }
            if ((campiScritti % 70) > 0) {
                sw.WriteLine("A".PadLeft(24*(70-(campiScritti%70))+117));
            }
        }
        
        private void scriviRecord2(StreamWriter sw) {
            int progr = 0;
            int campiScritti = 0;
            foreach (DataRow rFornitore in DS.fornitore.Rows) {
                foreach (DataColumn c in DS.fornitore.Columns) {
                    if (rFornitore[c] != DBNull.Value) {
                        if ((campiScritti % 70) == 0) {
                            sw.Write("2");
                        }
                        sw.Write(c.ColumnName);
                        switch (c.ColumnName) {
                            case "FR001001": sw.Write(formattaNumero(++progr, 16)); break;
                            case "FR002001":
                            case "FR003001": sw.Write(formattaStringa(rFornitore[c], 16)); break;
                            default:
                                sw.Write(formattaNumero(rFornitore[c], 16));
                                break;
                        }
                        campiScritti++;
                        if ((campiScritti % 70) == 0) {
                            sw.WriteLine("A".PadLeft(117));
                        }
                    }
                }
            }
            if ((campiScritti % 70) > 0) {
                sw.WriteLine("A".PadLeft(24 * (70 - (campiScritti%70)) + 117));
            }
        }

        private void scriviRecord3(StreamWriter sw) {
            sw.Write("3");
            sw.Write(formattaNumero(DS.cliente.Rows.Count, 8));
            sw.Write(formattaNumero(DS.fornitore.Rows.Count, 8));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL004001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL004002)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL005001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL006001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL007001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL008001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL008002)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL009001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL010001)", null), 20));
            sw.Write(formattaNumero(DS.cliente.Compute("sum(CL011001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR004001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR004002)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR005001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR006001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR007001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR008001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR009001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR009002)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR010001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR011001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR012001)", null), 20));
            sw.Write(formattaNumero(DS.fornitore.Compute("sum(FR013001)", null), 20));
            sw.WriteLine("A".PadLeft(1341));

        }

        private string formattaPosiz(object valore, int caratteri, string formato) {
            string s = valore.ToString();
            if (s.Length > caratteri) {
                s = s.Substring(0, caratteri);
            }
            switch (formato) {
                case "AN":
                case "CF":
                case "PR":
                    return s.PadRight(caratteri);
                case "PI":
                case "NU":
                    return s.PadLeft(caratteri, '0');
                case "DT":
                    if (valore == DBNull.Value) return "00000000";
                    return ((DateTime)valore).ToString("ddMMyyyy");
                default:
                    show(this, "Formato " + formato + " sconosciuto!");
                    return null;
            }
        }

        private void scriviRecordDiTestaODiCoda(int record, StreamWriter sw, DataRow r) {
            sw.Write(record);
            sw.Write(formattaPosiz(r["h02"], 3, "AN"));
            sw.Write(formattaPosiz(r["h03"], 2, "NU"));
            sw.Write(formattaPosiz(r["h04"], 2, "NU"));
            sw.Write(formattaPosiz(r["h05"], 16, "CF"));
            sw.Write(formattaPosiz(r["h06"], 11, "PI"));
            sw.Write(formattaPosiz(r["h07"], 26, "AN"));
            sw.Write(formattaPosiz(r["h08"], 25, "AN"));
            sw.Write(formattaPosiz(r["h09"], 1, "AN"));
            sw.Write(formattaPosiz(r["h10"], 8, "DT"));
            sw.Write(formattaPosiz(r["h11"], 40, "AN"));
            sw.Write(formattaPosiz(r["h12"], 2, "PR"));
            sw.Write(formattaPosiz(r["h13"], 70, "AN"));
            sw.Write(formattaPosiz(r["h14"], 40, "AN"));
            sw.Write(formattaPosiz(r["h15"], 2, "AN"));
            sw.Write(formattaPosiz(r["h16"], 16, "CF"));
            sw.Write(formattaPosiz(r["h17"], 4, "NU"));
            sw.Write(formattaPosiz(r["h18"], 4, "NU"));
            sw.Write(formattaPosiz(r["h19"], 4, "NU"));
            sw.Write(formattaPosiz(r["h20"], 16, "CF"));
            sw.Write(formattaPosiz(r["h21"], 5, "NU"));
            sw.Write(formattaPosiz(r["h22"], 1, "NU"));
            sw.Write(formattaPosiz(r["h23"], 8, "DT"));
            sw.WriteLine("A".PadLeft(1491));
        }

        private DataTable chiamaSP(string sp, object[] parametri) {
            DataSet ds = Meta.Conn.CallSP(sp, parametri);
            if ((ds == null) || (ds.Tables.Count == 0)) {
                show(this, "Errore nella chiamata " + sp);
                return null;
            }
            return ds.Tables[0];
        }

        private void btnConsolida_Click(object sender, EventArgs e) {
            if (txtCartella.Text == "") {
                show(this, "Specificare la cartella contenente gli elenchi clienti/fornitori da consolidare");
                return;
            }
            if (txtFile.Text == "") {
                show(this, "Specificare il percorso del file da salvare");
                return;
            }
            DS.cliente.Clear();
            DS.fornitore.Clear();
            DirectoryInfo di = new DirectoryInfo(txtCartella.Text);
            char[] record = new char[1800];
            foreach (FileInfo f in di.GetFiles()) {
                StreamReader sr = new StreamReader(f.FullName, Encoding.Default);
                Console.WriteLine(f);
                do {
                    int letti = sr.Read(record, 0, 1800);
                    if (letti != 1800) {
                        sr.Close();
                        show(this, "Errore durante la lettura del file " + f.FullName + "\nLetti " + letti + " byte anzichè 1800");
                        return;
                    }
                    switch (record[0]) {
                        case '0':
                            esercizio = int.Parse(new string(record, 265, 4));
                            break;
                        case '1': consolidaClienti(record); break;
                        case '2': consolidaFornitori(record); break;
                        case '3': 
                        case '9': break;
                    }
                } while (record[0] != '9');
                sr.Close();
            }
            DataTable tRecordTestaECoda = chiamaSP("exp_elencoclientifornit_intestazione", new object[] { });
            tRecordTestaECoda.Rows[0]["h13"] = Meta.Conn.DO_READ_VALUE("license", null, "agency").ToString().ToUpper();
            tRecordTestaECoda.Rows[0]["h17"] = (int)Meta.GetSys("esercizio")-1;
            if (txtCFIntermediario.Text!=""){
            tRecordTestaECoda.Rows[0]["h20"] = txtCFIntermediario.Text;
            tRecordTestaECoda.Rows[0]["h22"] = 1;
            tRecordTestaECoda.Rows[0]["h23"] = Meta.GetSys("datacontabile");
            }
            StreamWriter sw = new StreamWriter(txtFile.Text, false, Encoding.Default);
            scriviRecordDiTestaODiCoda(0, sw, tRecordTestaECoda.Rows[0]);
            scriviRecord1(sw);
            scriviRecord2(sw);
            scriviRecord3(sw);
            scriviRecordDiTestaODiCoda(9, sw, tRecordTestaECoda.Rows[0]);
            sw.Close();
            show(this, "Elenco clienti/fornitori salvato in " + txtFile.Text);
            DS.cliente.AcceptChanges();
            DS.fornitore.AcceptChanges();
            btnClienti.Enabled = true;
            btnFornitori.Enabled = true;
        }
 
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            PostData.MarkAsTemporaryTable(DS.cliente, false);
            PostData.MarkAsTemporaryTable(DS.fornitore, false);
        }

        private void btnClienti_Click(object sender, EventArgs e) {
            if (DS.cliente.Rows.Count == 0) {
                show(this, "Non ci sono clienti nell'elenco consolidato");
            }
            exportclass.DataTableToExcel(DS.cliente, true);
        }

        private void btnFornitori_Click(object sender, EventArgs e) {
            if (DS.fornitore.Rows.Count == 0) {
                show(this, "Non ci sono fornitori nell'elenco consolidato");
            }
            exportclass.DataTableToExcel(DS.fornitore, true);
        }
    }
}
