
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
using System.Globalization;

namespace mod770_details_consolidamento {
    public partial class FrmMod770details_consolidamento : Form {
        //MetaData Meta;

        public FrmMod770details_consolidamento() {
            InitializeComponent();
            txtFile770.Text = saveFileDialog1.FileName;
            txtCartella.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnScegliCartella_Click(object sender, EventArgs e) {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtCartella.Text = folderBrowserDialog1.SelectedPath;
            }
        }

//        private void btnConsolida_Click(object sender, EventArgs e) {
//            DirectoryInfo di = new DirectoryInfo(txtCartella.Text);
//            int idDip = 0;
//            foreach (FileInfo f in di.GetFiles()) {
//                StreamReader sr = new StreamReader(f.FullName, Encoding.Default);
//                Console.WriteLine(f);
//                char[] buffer = new char[1900];
//                sr.Read(buffer, 0, 1900);
//                idDip++;
////                int idDip = Int32.Parse(new string(buffer, 529, 100));
//                leggiHeaderAoBoZ(new StringReader(new string(buffer, 0, 1900)), 1);
//                int tipoRecord = sr.Peek();
//                while ((tipoRecord = sr.Peek()) != -1) {
//                    switch (tipoRecord) {
//                        case 'B':
//                        case 'Z':
//                            leggiHeaderAoBoZ(sr, idDip);
//                            break;
//                        case 'G':
//                        case 'H':
//                            int progressivoComunicazione = leggiHeaderGoH(sr, idDip);
//                            leggiRecord(sr, idDip, progressivoComunicazione);
//                            break;
//                    }
//                    tipoRecord = sr.Peek();
//                }
//                sr.Close();
//                foreach (DataRow r in DS.modello770.Select("quadro in ('AU','DA','DB','DC','DD')")) {
//                    if (r["stringa"] != DBNull.Value) {
//                        r["stringa"] = ((string)r["stringa"]).TrimEnd(null);
//                        Console.WriteLine(r["progr"] + " " + r["quadro"] + r["riga"] + r["colonna"] + " '" + r["stringa"] + r["intero"] + r["data"] + "'");
//                    }
//                }
//            }
//        }
        //public void MetaData_AfterLink() {
        //    Meta = MetaData.GetMetaData(this);
        //    GetData.CacheTable(DS.mod770_details, "ayear=2007", null, false);
        //}

        /// <summary>
        /// Legge i campi posizionali dei record A oppure B oppure Z e li scrive nella tabella modello770
        /// </summary>
        /// <param name="tr">TextReader da cui leggere</param>
        /// <param name="idDip">id. del dipartimento</param>
        //private void leggiHeaderAoBoZ(TextReader tr, int idDip) {
        //    leggiHeader(tr, idDip, 1);
        //    tr.ReadLine();
        //}
        /// <summary>
        /// Legge i campi posizionali di record G oppure H e li scrive nella tabella modello770
        /// </summary>
        /// <param name="tr">TextReader da cui leggere</param>
        /// <param name="idDip">id. del dipartimento</param>
        /// <returns>progressivo della comunicazione</returns>
        //private int leggiHeaderGoH(TextReader tr, int idDip) {
        //    char[] buffer = new char[89];
        //    tr.Read(buffer, 0, 89);
        //    int progressivoComunicazione = Int32.Parse(new string(buffer, 17, 8));
        //    string filtro = "(iddip=" + idDip
        //        + ") and (progr=" + progressivoComunicazione
        //        + ") and (quadro='HR" + buffer[0]
        //        + "')";
        //    DataRow[] old = DS.modello770.Select(filtro);
        //    //			Console.WriteLine(old.Length+" FILTRO "+filtro);
        //    if (old.Length == 0) {
        //        leggiHeader(new StringReader(new string(buffer)), idDip, progressivoComunicazione);
        //    }
        //    return progressivoComunicazione;
        //}

        /// <summary>
        /// Legge i campi posizionali di un record e li scrive nella tabella modello770.
        /// </summary>
        /// <param name="tr">TextReader da cui leggere</param>
        /// <param name="idDip">id. del dipartimento</param>
        /// <param name="progr"></param>
        /// <returns>il progressivo della comunicazione</returns>
        //private void leggiHeader(TextReader tr, int idDip, int progr) {
        //    char[] buffer = new char[1837];
        //    char tipoRecord = (char)tr.Peek();
        //    string filtro = "(frame='HR" + tipoRecord + "')";
        //    DataRow[] record = DS.mod770_details.Select(filtro);
        //    foreach (DataRow r in record) {
        //        string formato = (string)r["format"];
        //        int lunghezza = (int)r["fieldlen"];
        //        string colonna = (string)r["colnumber"];
        //        int lettiLetti = tr.Read(buffer, 0, lunghezza);
        //        string s = new string(buffer, 0, lunghezza);
        //        //				Console.WriteLine(r["frame"]+""+r["colnumber"] + " " + lunghezza + " " + formato + " '" +s + "'");
        //        switch (formato) {
        //            case "AN"://P-N
        //            case "CF"://P-N
        //            case "PR"://P-N 
        //                if (s.Length > 0) {
        //                    aggiungiUnaRigaAl770(idDip, progr, "HR" + tipoRecord, 1, colonna,
        //                        s.Trim());
        //                }
        //                break;
        //            case "DT"://P-N
        //                //s = s.TrimStart(new char[] { '0' });
        //                if (s.TrimStart(new char[] { '0' }).Length > 0) {
        //                    aggiungiUnaRigaAl770(idDip, progr, "HR" + tipoRecord, 1, colonna,
        //                        DateTime.ParseExact(s, "ddMMyyyy", CultureInfo.CurrentCulture));
        //                }
        //                break;
        //            case "CN"://P-N
        //            case "PI"://P-N
        //            case "NU"://P-N
        //            case "CB"://P-N
        //                if (s.Length > 0) {
        //                    aggiungiUnaRigaAl770(idDip, progr, "HR" + tipoRecord, 1, r["colnumber"].ToString(),
        //                        Int32.Parse(s));
        //                }
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Con riferimento ai campi non posizionali, nel caso in cui la lunghezza del dato da inserire
        ///	dovesse eccedere i 16 lettiatteri disponibili, dovrà essere inserito un ulteriore elemento con un
        /// identico campo-codice e con un campo-valore il cui primo lettiattere dovrà essere impostato
        /// con il simbolo “+”, mentre i successivi quindici potranno essere utilizzati per la
        /// continuazione del dato da inserire.
        /// </summary>
        /// <param name="idDip">id. del dipartimento</param>
        /// <param name="progr">progressivo della comunicazione</param>
        /// <param name="quadro">quadro</param>
        /// <param name="riga">riga</param>
        /// <param name="colonna">colonna</param>
        /// <param name="buffer">buffer da cui leggere la stringa</param>
        //private void scriviStringa(int idDip, int progr, string quadro, int riga, string colonna, char[] buffer) {
        //    string filtroOld = "(iddip=" + idDip
        //        + ") and (progr=" + progr
        //        + ") and (quadro='" + quadro
        //        + "') and (riga=" + riga
        //        + ") and (colonna='" + colonna
        //        + "')";
        //    DataRow[] old = DS.modello770.Select(filtroOld);
        //    if (old.Length == 0) {
        //        aggiungiUnaRigaAl770(idDip, progr, quadro, riga, colonna, new string(buffer, 8, 16));
        //    }
        //    else {
        //        DataRow r = old[0];
        //        r["stringa"] += new string(buffer, 9, 15);
        //    }
        //}
        /// <summary>
        /// Riempie una riga con i valori indicati e la memorizza nella tabella modello770
        /// </summary>
        /// <param name="idDip">id. del dipartimento</param>
        /// <param name="progr">progressivo della comunicazione</param>
        /// <param name="quadro">quadro</param>
        /// <param name="riga">riga</param>
        /// <param name="colonna">colonna</param>
        /// <param name="valore">valore</param>
        //private void aggiungiUnaRigaAl770(int idDip, int progr, string quadro, int riga, string colonna, object valore) {
        //    DataRow r = DS.modello770.NewRow();
        //    r["iddip"] = idDip;
        //    r["progr"] = progr;
        //    r["quadro"] = quadro;
        //    r["riga"] = riga;
        //    r["colonna"] = colonna;
        //    if (valore is int) {
        //        r["intero"] = (int)valore;
        //    }
        //    r["stringa"] = valore as string;
        //    if (valore is DateTime) {
        //        r["data"] = (DateTime)valore;
        //    }
        //    DS.modello770.Rows.Add(r);
        //}

        /// <summary>
        /// Formatta un valore e lo scrive in una nuova riga della tabella modello770
        /// </summary>
        /// <param name="idDip"></param>
        /// <param name="progr"></param>
        /// <param name="buffer"></param>
        //private void scriviUnValore(int idDip, int progr, char[] buffer) {
        //    string quadro = new string(buffer, 0, 2);
        //    int riga = Int32.Parse(new string(buffer, 2, 3));
        //    string colonna = new string(buffer, 5, 3);
        //    string filtro = "(frame='"
        //        + quadro
        //        + "') and (colnumber='"
        //        + colonna
        //        + "')";
        //    DataRow rForm = DS.mod770_details.Select(filtro)[0];
        //    string formato = rForm["format"].ToString();
        //    switch (formato) {
        //        case "AN"://P-N
        //        case "CF"://P-N
        //        case "PR"://P-N
        //            scriviStringa(idDip, progr, quadro, riga, colonna, buffer);
        //            return;
        //        case "CN"://P-N
        //        case "PI"://P-N
        //        case "DA"://N
        //        case "NP"://N
        //        case "NU"://P-N
        //        case "PC"://N
        //        case "QU"://N
        //        case "CB"://P-N
        //        case "N1"://N
        //        case "N2"://N
        //        case "N3"://N
        //        case "N5"://N
        //        case "N10"://N
        //        case "CB12"://N
        //            aggiungiUnaRigaAl770(idDip, progr, quadro, riga, colonna,
        //                Int32.Parse(new string(buffer, 8, 16)));
        //            return;
        //        case "DT"://P-N
        //        case "DN"://N
        //            aggiungiUnaRigaAl770(idDip, progr, quadro, riga, colonna,
        //                DateTime.ParseExact(new string(buffer, 16, 8), "ddMMyyyy", CultureInfo.CurrentCulture));
        //            return;
        //        case "D6"://N
        //            aggiungiUnaRigaAl770(idDip, progr, quadro, riga, colonna,
        //                DateTime.ParseExact(new string(buffer, 18, 6), "MMyyyy", CultureInfo.CurrentCulture));
        //            return;
        //        case "D4"://N
        //            aggiungiUnaRigaAl770(idDip, progr, quadro, riga, colonna,
        //                DateTime.ParseExact(new string(buffer, 20, 4), "ddMM", CultureInfo.CurrentCulture));
        //            return;
        //    }
        //}

        /// <summary>
        /// Legge un intero record dal TextReader ed inserisce i suoi valori nella tabella modello770
        /// </summary>
        /// <param name="tr">TextReader da cui leggere</param>
        /// <param name="idDip">id. dipartimento</param>
        /// <param name="progr">progressivo della comunicazione</param>
        //private void leggiRecord(TextReader tr, int idDip, int progr) {
        //    char[] buffer = new char[24];
        //    for (int i = 0; i < 75; i++) {
        //        tr.Read(buffer, 0, 24);
        //        if (buffer[0] != ' ') {
        //            scriviUnValore(idDip, progr, buffer);
        //        }
        //    }
        //    tr.ReadLine();
        //}

        private bool consolidaRecordG(TextReader sr, FileInfo f, ref int nRecordG, TextWriter sw, string cfSoggettoDichiarante) {
            int primoRecord = nRecordG;
            char[] buffer = new char[1900];
            do {
                int letti = sr.Read(buffer, 0, 1900);
                if (letti != 1900) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                    return false;
                }
                if (!verificaSeIlFileEControllato(buffer, f))
                {
                    return false;
                }
                //string s = "G" + cfSoggettoDichiarante;
                //if (s != "H80213750583     ") {
                //    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nel codice fiscale dichiarante nel file " + f);
                //    break;
                //}
                sw.Write("G" + cfSoggettoDichiarante);
                string numrec = new string(buffer, 17, 8);
                nRecordG = primoRecord + int.Parse(numrec);
                sw.Write(nRecordG.ToString().PadLeft(8, '0'));
                sw.Write(buffer, 22, 3);
                sw.Write(buffer, 28, 1 + 16 + 8);
                string nome = Path.GetFileName(f.FullName);
                if (nome.Length > 20) {
                    nome = nome.Substring(0, 20);
                }
                sw.Write(nome.PadRight(20));
                sw.Write(buffer, 73, 1900 - 73);
            } while (sr.Peek() == 'G');
            return true;
        }

        private bool consolidaRecordH(TextReader sr, FileInfo f, ref int nRecordH, TextWriter sw, string cfSoggettoDichiarante) {
            int primoRecord = nRecordH;
            char[] buffer = new char[1900];
            do {
                int letti = sr.Read(buffer, 0, 1900);
                if (letti != 1900) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                    return false;
                }
                if (!verificaSeIlFileEControllato(buffer, f))
                {
                    return false;
                }
                //string s = new string(buffer, 0, 17);
                //if (s != "H80213750583     ") {
                //    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nel codice fiscale dichiarante nel file " + f);
                //    break;
                //}
                sw.Write("H" + cfSoggettoDichiarante);
                string numrec = new string(buffer, 17, 8);
                nRecordH = primoRecord + int.Parse(numrec);
                sw.Write(nRecordH.ToString().PadLeft(8, '0'));
                sw.Write(buffer, 22, 3);
                sw.Write(buffer, 28, 1 + 16 + 8);
                string nome = Path.GetFileName(f.FullName);
                if (nome.Length > 20) {
                    nome = nome.Substring(0, 20);
                }
                sw.Write(nome.PadRight(20));
                sw.Write(buffer, 73, 1900 - 73);
            } while (sr.Peek() == 'H');
            return true;
        }


        private bool consolidaRecordI(TextReader sr, FileInfo f, ref int nRecordI, TextWriter sw, string cfSoggettoDichiarante)
        {
            int primoRecord = nRecordI;
            char[] buffer = new char[1900];
            do
            {
                int letti = sr.Read(buffer, 0, 1900);
                if (letti != 1900)
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                    return false;
                }
                if (!verificaSeIlFileEControllato(buffer, f))
                {
                    return false;
                }

                sw.Write("I" + cfSoggettoDichiarante);
                string numrec = new string(buffer, 17, 8);
                nRecordI = primoRecord + int.Parse(numrec);
                sw.Write(nRecordI.ToString().PadLeft(8, '0'));
                sw.Write(buffer, 22, 3);
                sw.Write(buffer, 28, 1 + 16 + 8);
                string nome = Path.GetFileName(f.FullName);
                if (nome.Length > 20)
                {
                    nome = nome.Substring(0, 20);
                }
                sw.Write(nome.PadRight(20));
                sw.Write(buffer, 73, 1900 - 73);
            } while (sr.Peek() == 'I');
            return true;
        }


        private bool consolidaRecordJ(TextReader sr, FileInfo f, SortedDictionary<string,int> recordJ) {
            char[] buffer = new char[1900];
            int letti = sr.Read(buffer, 0, 1900);
            if (letti != 1900) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                return false;
            }
            if (!verificaSeIlFileEControllato(buffer, f))
            {
                return false;
            }
            for (int i = 89; i < 1889; i += 24) {
                string key = new string(buffer, i, 8);
                string value = new string(buffer, i + 8, 16);
                if (value != "                ") {
                    try {
                        recordJ[key] += Convert.ToInt32(value);
                    }
                    catch (KeyNotFoundException) {
                        recordJ[key] = Convert.ToInt32(value);
                    }
                }
            }
            return true;
        }

        private DirectoryInfo getDirectoryInfo() {
            try {
                return new DirectoryInfo(txtCartella.Text);
            }
            catch (ArgumentException) {
                DialogResult dr = folderBrowserDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    txtCartella.Text = folderBrowserDialog1.SelectedPath;
                    return new DirectoryInfo(txtCartella.Text);
                }
            }
            return null;
        }

        private StreamWriter getStreamWriter() {
            try {
                return new StreamWriter(txtFile770.Text, false, Encoding.Default);
            }
            catch (ArgumentException) {
                DialogResult dr = saveFileDialog1.ShowDialog(this);
                if (dr == DialogResult.OK) {
                    txtFile770.Text = saveFileDialog1.FileName;
                    return new StreamWriter(txtFile770.Text, false, Encoding.Default);
                }
            }
            return null;
        }

        private bool verificaSeIlFileEControllato(char[] buffer, FileInfo f)
        {
            string cfsw = new string(buffer, 73, 16);
            if (cfsw != "02327910580     ")
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, f.FullName + " non è stato verificato tramite il software dell'Agenzia delle Entrate", "Consolidamento interrotto!");
                return false;
            }
            return true;
        }

        private void btnConsolida_Click(object sender, EventArgs e) {
            DirectoryInfo di = getDirectoryInfo();
            if (di == null) return;
            string cfSoggettoDichiarante = "";
            bool primoFile = true;
            SortedDictionary<string, int> recordJ = new SortedDictionary<string, int>();
            char[] buffer = new char[1900];
            int nRecordG = 0;
            int nRecordH = 0;
            int nRecordI = 0;
            StringWriter swG = new StringWriter();
            StringWriter swH = new StringWriter();
            StringWriter swI = new StringWriter();
            foreach (FileInfo f in di.GetFiles()) {
                StreamReader sr = new StreamReader(f.FullName, Encoding.Default);
                Console.WriteLine(f);

                while (!sr.EndOfStream) {
                    char tipoRecord = (char)sr.Peek();
                    switch (tipoRecord) {
                        case 'A':
                        case 'B': {
                            int letti = sr.Read(buffer, 0, 1900);
                            if (letti != 1900) {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                            }
                            if (tipoRecord == 'B' && !verificaSeIlFileEControllato(buffer, f))
                            {
                                sr.Close();
                                return;
                            }
                            if (primoFile) {
                                cfSoggettoDichiarante = new string(buffer, 1, 16);
                                swG.Write(buffer);
                                primoFile = tipoRecord == 'A';
                            }
                            break;
                        }
                        case 'G':
                            if (!consolidaRecordG(sr, f, ref nRecordG, swG, cfSoggettoDichiarante)) {
                                sr.Close();
                                return;
                            }
                            break;
                        case 'H':
                            if (!consolidaRecordH(sr, f, ref nRecordH, swH, cfSoggettoDichiarante)) {
                                sr.Close();
                                return;
                            }
                            break;
                        case 'I':
                            if (!consolidaRecordI(sr, f, ref nRecordI, swI, cfSoggettoDichiarante))
                            {
                                sr.Close();
                                return;
                            }
                            break;
                        case 'J':
                            if (!consolidaRecordJ(sr, f, recordJ)) {
                                sr.Close();
                                return;
                            }
                            break;
                        case 'Z': {
                                int letti = sr.Read(buffer, 0, 1900);
                                if (letti != 1900) {
                                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Letti " + letti + " byte anzichè 1900 in " + f.Name);
                                    return;
                                }
                                break;
                            }
                        default: {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Tipo Record '" + ((char)tipoRecord) + "' sconosciuto in " + f.Name);
                                sr.Close();
                                return;
                            }
                    }
                }
                sr.Close();
            }
            StreamWriter stream = getStreamWriter();
            if (stream == null) return;
            string t = swG.ToString();
            stream.Write(t.Substring(0, 1900 + 797));
            stream.Write(nRecordG.ToString().PadLeft(8, '0'));
            stream.Write(nRecordH.ToString().PadLeft(8, '0'));
            stream.Write(t.Substring(1900 + 813));
            stream.Write(swH.ToString());
            stream.Write(swI.ToString());
            StringBuilder sbRecordJ = new StringBuilder("J" 
                + cfSoggettoDichiarante.PadRight(16)
                + "1".PadLeft(8, '0').PadRight(8 + 3 + 1 + 24 + 20 + 16));
            foreach (KeyValuePair<string, int> coppia in recordJ) {
                sbRecordJ.Append(coppia.Key);
                sbRecordJ.Append(coppia.Value.ToString().PadLeft(16));
            }
            stream.Write(sbRecordJ);
            stream.Write("A\r\n".PadLeft(1900 - sbRecordJ.Length));
            string recordZ = "Z".PadRight(15)
                + "1".PadLeft(9, '0')//Numero record di tipo ‘B’ 
                + "0".PadLeft(9, '0')//Numero record di tipo ‘D’ 
                + "0".PadLeft(9, '0')//Numero record di tipo ‘E’ 
                + "0".PadLeft(9, '0')//Numero record di tipo ‘F’ 
                + nRecordG.ToString().PadLeft(9, '0')//Numero record di tipo ‘G’ 
                + nRecordH.ToString().PadLeft(9, '0')//Numero record di tipo ‘H’ 
                + nRecordI.ToString().PadLeft(9, '0')//Numero record di tipo ‘I’ 
                + "1".PadLeft(9, '0')//Numero record di tipo ‘J’
                + "A\r\n".PadLeft(1813);//1900-15-9*8 = 1813
            stream.Write(recordZ);
            stream.Close();
            long length = new FileInfo(txtFile770.Text).Length;
            if (length % 1900 > 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "ERRORE nella lunghezza del consolidato " + txtFile770.Text
                    + "\nLunghezza=" + length + "; %1900=" + (length % 1900));
            }
            else {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Il consolidato è stato salvato nel file " + txtFile770.Text + "; lunghezza=" + length);
            }
        }

        private void btnFile_Click(object sender, EventArgs e) {
            DialogResult dr = saveFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtFile770.Text = saveFileDialog1.FileName;
            }
        }
    }
}

