/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Collections;
using System.Globalization;

namespace admpay_spt {
    public partial class FrmAdmPay_Spt : Form {
        MetaData Meta;
        DataSet dsImport;
        DataTable tToExcel;
        CQueryHelper QHC;
        QueryHelper QHS;
        char[] buffer = new char[410];
        public FrmAdmPay_Spt() {
            InitializeComponent();
        }

        private void btnInputFile_Click(object sender, EventArgs e) {
            DialogResult dr = openInputFileDlg.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show("Non Ë stato scelto alcun file");
                txtInputFile.Text = "";
                return;
            }

            string fileName = openInputFileDlg.FileName;
            txtInputFile.Text = fileName;
        }

        private void btnFileReversali_Click(object sender, EventArgs e) {
            parseFile();
            if (elaboraOutput("R")) {
                exportclass.DataTableToExcel(tToExcel, true);
            }
            tToExcel.Clear();
            DS.Clear();
            lblTask.Text = null;
            progressBar1.Value = 0;
            Cursor = null;
        }

        private void btnFileLordi_Click(object sender, EventArgs e) {
            parseFile();
            if (elaboraOutput("L")) {
                exportclass.DataTableToExcel(tToExcel, true);
            }
            tToExcel.Clear();
            DS.Clear();
            lblTask.Text = null;
            progressBar1.Value = 0;
            Cursor = null;
        }

        private void btnFileContr_Click(object sender, EventArgs e) {
            parseFile();
            if (elaboraOutput("V")) {
                exportclass.DataTableToExcel(tToExcel, true);
            }
            tToExcel.Clear();
            DS.Clear();
            lblTask.Text = null;
            progressBar1.Value = 0;
            Cursor = null;
        }

        /// <summary>
        /// Metodo che popola la tabella di ouput che sar‡ associata alla creazione del file Excel
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool elaboraOutput(string task) {
            switch (task) {
                    // Ramo Reversali:
                    // Si definisce la struttura della tabella tToExcel come segue: TIPORIT, RECORD,
                    // CODICEFISCALE, COGNOME1, NOME1, IMPORTO, CODCOMUNE.
                    // L'obiettivo di questo ramo Ë quello di ottenere tutte le ritenute c/dipendente
                    // e i recuperi in modo da inserirli nella tabella che poi sar‡ associata al file Excel
                    // Le informazioni di cui sopra, sono sparse nei vari tipi record (di conseguenza nelle varie
                    // tabelle SPT_XX, con XX numero).
                case "R": {
                        // Dati da Record 01 {irpeftotalenetta, importoirpef13ma}
                        // Dati da Record 03 {CodRitPrevAss, ImportoRitenuta}
                        // Dati da Record 04 {CodiceRitenuta, ImportoRitenuta}
                        // Dati da Record 05 {CodiceRitenutaCategoria, ImportoRitenuta}
                        // Dati da Record 06 {CodiceArretrato, ImportoRitenute}
                        // Dati da Record 07 {CodiceArretrato, ImportoRitLavoratore}
                        tToExcel = new DataTable();
                        tToExcel.Columns.Add("TIPORIT");
                        tToExcel.Columns.Add("RECORD");
                        tToExcel.Columns.Add("CODICEFISCALE");
                        tToExcel.Columns.Add("COGNOME1");
                        tToExcel.Columns.Add("NOME1");
                        tToExcel.Columns.Add("IMPORTO", typeof(decimal));
                        tToExcel.Columns.Add("CODCOMUNE");

                        string[] elencoColonne = new string[] { "codicefiscale", "cognome1",
                            "nome1"};

                        foreach (DataRow r01 in DS.SPT_01.Rows) {
                            // Copia dei dati del record 01
                            string filtro = QHC.AppAnd(QHC.CmpEq("TIPORIT", "IRPEF"), QHC.CmpEq("RECORD", "01"),
                                QHC.CmpEq("CODICEFISCALE", r01["codicefiscale"]),
                                QHC.CmpEq("COGNOME1",r01["cognome1"]), QHC.CmpEq("NOME1", r01["nome1"]));

                            DataRow rExcel;
                            if (tToExcel.Select(filtro).Length > 0) {
                                rExcel = tToExcel.Select(filtro)[0];
                                rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel["IMPORTO"]) +
                                    CfgFn.GetNoNullDecimal(r01["irpeftotalenetta"]) +
                                    CfgFn.GetNoNullDecimal(r01["importoirpef13ma"]);
                            }
                            else {
                                rExcel = tToExcel.NewRow();
                                foreach (string s in elencoColonne) {
                                    string colName = s.ToUpper();
                                    rExcel[colName] = r01[s];
                                }
                                rExcel["TIPORIT"] = "IRPEF";
                                rExcel["RECORD"] = "01";
                                rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(r01["irpeftotalenetta"]) +
                                CfgFn.GetNoNullDecimal(r01["importoirpef13ma"]);
                                tToExcel.Rows.Add(rExcel);
                            }

                            // Viene richiamato il metodo copiaDati per ricopiare i dati presenti nei record
                            // 03, 04, 05, 07 all'interno della tabella di output tExcel
                            copiaDati("03", "codritprevass", "importoritenuta", null, r01);
                            copiaDati("04", "codiceritenuta", "importoritenuta", null, r01);
                            copiaDati("05", "codiceritenutacategoria", "importoritenuta", null, r01);
                            copiaDati("07", "codritprevass", "importoritlavoratore", null, r01);

                            // Calcolo degli arretrati: affinchË si possa dettagliare l'arretrato inserendo il codice della ritenuta
                            // l'elaborazione Ë stata spostata nel Record07
                            //string fArr = QHC.AppAnd(QHC.CmpEq("numeroriga", r01["numeroriga"]),
                            //     QHC.DoPar(QHC.AppOr(QHC.CmpEq("codiceassegno", "800"),
                            //                   QHC.CmpEq("codiceassegno", "806"))));
                            //foreach (DataRow r06 in DS.SPT_06.Select(fArr))
                            //{
                            //    string f = QHC.AppAnd(QHC.CmpEq("TIPORIT", "ARRETRATO"),
                            //        QHC.CmpEq("RECORD", "06"),
                            //        QHC.CmpEq("CODICEFISCALE", r01["codicefiscale"]),
                            //        QHC.CmpEq("COGNOME1", r01["cognome1"]), QHC.CmpEq("NOME1", r01["nome1"]));

                            //    DataRow rExcel06;//E' la riga degli arretrati che sar‡ aggiunta al foglio Excel

                            //    // Calcolo delle ritenute previdenziali legate all'arretrato
                            //    decimal ritenuteArretrato = calcolaRitenutePrevArretrato(r01, r06["codiceassegno"],
                            //            r06["codicearretrato"]);

                            //    if (tToExcel.Select(f).Length > 0)
                            //    {
                            //        rExcel06 = tToExcel.Select(f)[0];
                            //        if (r06["codiceassegno"].ToString() != "800")
                            //        {
                            //            // Arretrati a Credito sulle Ritenute. 806. Ramo nuovo
                            //            //rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel06["IMPORTO"]) +
                            //            //CfgFn.GetNoNullDecimal(r06["importolordorata"]) + ritenuteArretrato;
                            //            rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel06["IMPORTO"]) + ritenuteArretrato;
                            //        }
                            //        else
                            //        {
                            //            // Arretrati a Debito sulle ritenute. 800. Come prima
                            //            //rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel06["IMPORTO"]) +
                            //            //CfgFn.GetNoNullDecimal(r06["importolordorata"])- ritenuteArretrato;
                            //            rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel06["IMPORTO"]) - ritenuteArretrato;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        rExcel06 = tToExcel.NewRow();
                            //        rExcel06["TIPORIT"] = "ARRETRATO";
                            //        rExcel06["RECORD"] = "06";
                            //        rExcel06["CODICEFISCALE"] = r01["codicefiscale"];
                            //        rExcel06["COGNOME1"] = r01["cognome1"];
                            //        rExcel06["NOME1"] = r01["nome1"];
                            //        if (r06["codiceassegno"].ToString() != "800")
                            //        {
                            //            // Arretrati a Credito sulle Ritenute. 806. Ramo nuovo
                            //            //rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(r06["importolordorata"]) + ritenuteArretrato;
                            //            rExcel06["IMPORTO"] = + ritenuteArretrato;
                            //        }
                            //        else
                            //        {
                            //            // Arretrati a Debito sulle ritenute. 800. Come prima
                            //            //rExcel06["IMPORTO"] = CfgFn.GetNoNullDecimal(r06["importolordorata"]) - ritenuteArretrato;
                            //            rExcel06["IMPORTO"] = - ritenuteArretrato;
                            //        }
                            //        tToExcel.Rows.Add(rExcel06);
                            //    }
                            //}
                        }
                        break;
                    }
                // Ramo Lordi:
                    // Si definisce la struttura della tabella tToExcel come segue: CODICEASSEGNO, SUB,
                // CODICEFISCALE, COGNOME1, NOME1, IMPORTO, CODCOMUNE.
                    // I lordi sono dati da l'importo lordo della rata meno eventuali
                    // riduzioni per part time e "te", e si sottraggono anche eventuali arretrati negativi.
                    // Per ogni riga della tabella SPT_01 si seleziona il campo numeroriga
                    // per richiamare le righe delle tabelle figlie (collegate mediante questo campo).
                    // Dalla tabella SPT_02 si estraggono le informazioni inerenti il lordo dello stipendio
                    // e delle eventuali riduzioni
                    // Dalla tabella SPT_06 si estraggono eventuali arretrati negativi che riducono il lordo.
                case "L": {
                        tToExcel = new DataTable();
                        tToExcel.Columns.Add("CODICEASSEGNO");
                        tToExcel.Columns.Add("SUB");
                        tToExcel.Columns.Add("CODICEFISCALE");
                        tToExcel.Columns.Add("COGNOME1");
                        tToExcel.Columns.Add("NOME1");
                        tToExcel.Columns.Add("IMPORTO", typeof(decimal));

                        string[] elencoColonne = new string[] { "codicefiscale", "cognome1",
                            "nome1"};
                        foreach (DataRow r01 in DS.SPT_01.Rows) {

                            string f = QHC.CmpEq("numeroriga", r01["numeroriga"]);

                            foreach (DataRow r02 in DS.SPT_02.Select(f)) {
                                DataRow rExcel = tToExcel.NewRow();
                                rExcel["CODICEASSEGNO"] = r02["codiceassegno"];
                                foreach (string s in elencoColonne) {
                                    string colName = s.ToUpper();
                                    rExcel[colName] = r01[s];
                                }
                                rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(r02["importolordorata"])
                                    - CfgFn.GetNoNullDecimal(r02["importoriduzionept"])
                                    - CfgFn.GetNoNullDecimal(r02["importoriduzionete"]);

                                tToExcel.Rows.Add(rExcel);
                            }

                            string fArr = QHC.AppAnd(f, QHC.DoPar(QHC.AppOr(QHC.CmpEq("codiceassegno", "800"),
                                                    QHC.CmpEq("codiceassegno", "806"))));
                            foreach (DataRow r06 in DS.SPT_06.Select(fArr)) {
                                DataRow rExcel = tToExcel.NewRow();//Crea un nuova riga x l'arretrato
                                rExcel["CODICEASSEGNO"] = r06["codiceassegno"];
                                rExcel["SUB"] = r06["codicearretrato"];
                                foreach (string s in elencoColonne) {
                                    string colName = s.ToUpper();
                                    rExcel[colName] = r01[s];
                                }
                                if( r06["codiceassegno"].ToString() != "800"){
                                    //Arretrato a Credito 806
                                    rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(r06["importolordorata"])
                                    - CfgFn.GetNoNullDecimal(r06["importoriduzionept"])
                                    - CfgFn.GetNoNullDecimal(r06["importoriduzionepe"]);
                                }
                                else{
                                    //Arretrato a Debito 800
                                    rExcel["IMPORTO"] = - (CfgFn.GetNoNullDecimal(r06["importolordorata"])
                                    - CfgFn.GetNoNullDecimal(r06["importoriduzionept"])
                                    - CfgFn.GetNoNullDecimal(r06["importoriduzionepe"]));
                                }
                                tToExcel.Rows.Add(rExcel);
                            }
                        }
                        break;
                    }
                // Ramo Versamenti:
                // Si definisce la struttura della tabella tToExcel come segue: TIPORIT, CODICEASSEGNO, SUB,
                // RECORD, CARICO, IMPORTO, CODCOMUNE.
                case "V": {
                        // Ritenute c/dipendente
                        // Dati da Record 01 {irpeftotalenetta, importoirpef13ma}
                        // Dati da Record 03 {CodRitPrevAss, ImportoRitenuta}
                        // Dati da Record 04 {CodiceRitenuta, ImportoRitenuta}
                        // Dati da Record 05 {CodiceRitenutaCategoria, ImportoRitenuta}
                        // Dati da Record 07 {CodiceArretrato, ImportoRitLavoratore}
                        // Ritenute c/amministrazione
                        // Dati da Record 03 {CodRitPrevAss, ImportoDatore}
                        // Dati da Record 07 {CodiceArretrato, ImportoRitDatore}
                        tToExcel = new DataTable();
                        tToExcel.Columns.Add("TIPORIT");
                        tToExcel.Columns.Add("CODICEASSEGNO");
                        tToExcel.Columns.Add("SUB");
                        tToExcel.Columns.Add("RECORD");
                        tToExcel.Columns.Add("CARICO");
                        tToExcel.Columns.Add("IMPORTO", typeof(decimal));
                        tToExcel.Columns.Add("CODCOMUNE");

                        foreach (DataRow r01 in DS.SPT_01.Rows) {
                            // Ciclo sulle ritenute c/dip
                            string filtroIrpef = QHC.AppAnd(QHC.CmpEq("TIPORIT", "IRPEF"),
                                QHC.CmpEq("RECORD", "01"), QHC.CmpEq("CODICEASSEGNO", "001"));
                            calcolaIrpefVersamenti(filtroIrpef, r01, "irpeftotalenetta");

                            string filtroIrpef13 = QHC.AppAnd(QHC.CmpEq("TIPORIT", "IRPEF"),
                                QHC.CmpEq("RECORD", "01"), QHC.CmpEq("CODICEASSEGNO", "002"));
                            calcolaIrpefVersamenti(filtroIrpef13, r01, "importoirpef13ma");

                            // Viene richiamato il metodo copiaDati per ricopiare i dati presenti nei record
                            // 03, 04, 05, 07 relativo alle ritenute c/dipendente all'interno
                            // della tabella di output tExcel
                            copiaDati("03", "codritprevass", null, "importoritenuta", null, r01, "D");
                            copiaDati("04", "codiceritenuta", null, "importoritenuta", null, r01, "D");
                            copiaDati("05", "codiceritenutacategoria", null, "importoritenuta", null, r01, "D");
                            copiaDati("07", "codritprevass", "codicearretrato", "importoritlavoratore", null, r01, "D");

                            // Viene richiamato il metodo copiaDati per ricopiare i dati presenti nei record
                            // 03, 07 relativo alle ritenute c/amministrazione all'interno
                            // della tabella di output tExcel
                            copiaDati("03", "codritprevass", null, "importodatore", null, r01, "A");
                            copiaDati("07", "codritprevass", "codicearretrato", "importoritdatore", null, r01, "A");
                        }
                        break;
                    }
            }

            return true;
        }

        /// <summary>
        /// Metodo che ricevuto un arretrato (indicato per codice assegno / codice arretrato) e la riga principale al 
        /// quale Ë applicato l'arretrato ne calcola le ritenute previdenziali (presenti nel record di tipo '07')
        /// </summary>
        /// <param name="r01"></param>
        /// <param name="codiceAssegno"></param>
        /// <param name="codiceArretrato"></param>
        /// <returns></returns>
        private decimal calcolaRitenutePrevArretrato(DataRow r01, object codiceAssegno, object codiceArretrato) {
            string tiporec = "07";
            
            string tName = "SPT_" + tiporec;

            string filtro = QHC.AppAnd(QHC.CmpEq("numeroriga", r01["numeroriga"]),
                QHC.CmpEq("codiceassegno", codiceAssegno), QHC.CmpEq("codicearretrato", codiceArretrato));

            decimal totRit = 0;

            foreach (DataRow r in DS.Tables[tName].Select(filtro)) {
                totRit += CfgFn.GetNoNullDecimal(r["importoritlavoratore"]);
            }

            return totRit;
        }

        private void calcolaIrpefVersamenti(string filtro, DataRow r01, string field) {
            DataRow rExcel;
            if (tToExcel.Select(filtro).Length > 0) {
                rExcel = tToExcel.Select(filtro)[0];
                rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel["IMPORTO"]) +
                    CfgFn.GetNoNullDecimal(r01[field]);
            }
            else {
                rExcel = tToExcel.NewRow();
                rExcel["TIPORIT"] = "IRPEF";
                string codAss = (field == "irpeftotalenetta") ? "001" : "002";
                rExcel["CODICEASSEGNO"] = codAss;
                rExcel["RECORD"] = "01";
                rExcel["CARICO"] = "D";
                rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(r01[field]);
                tToExcel.Rows.Add(rExcel);
            }
        }

        /// <summary>
        /// Metodo che, ricevuto in input il codice del record (tiporec), il nome del campo (fieldcodice),
        /// il nome del campo ove Ë presente l'importo (fieldimporto), il codice della ritenuta (codicerit) e
        /// il datarow del record 01, ricopia i dati di un insieme di righe appartenenti al tipo record tiporec
        /// nella tabella di output tExcel.
        /// </summary>
        /// <param name="tiporec"></param>
        /// <param name="fieldcodice"></param>
        /// <param name="fieldimporto"></param>
        /// <param name="codicerit"></param>
        /// <param name="r01"></param>
        /// //copiaDati("04", "codiceritenuta", "importoritenuta", null, r01);
        private void copiaDati(string tiporec, string fieldcodice, string fieldimporto,
            string codicerit, DataRow r01) {
            string filter = QHC.CmpEq("numeroriga", r01["numeroriga"]);
            // Se stiamo analizzando il tipo record 07 bisogna scartare le ritenute associate ad arretrati
            // negativi, denotati dal codice 800

            //if (tiporec == "07")
            //{
            //    filter = QHC.AppAnd(filter, QHC.CmpNe("codiceassegno", "800"));
            //}
            object CodComune = null;
            string tName = "SPT_" + tiporec;
            // Per ogni riga del sottoinsieme, determinato da filter, della tabella SPT_tiporec
            // ricopia i dati nella tabella di output
            // Si verifica l'esistenza nella tabella di output di una riga con i valori chiave di quella
            // che si sta processando. Se Ë gi‡ presente si consolidano i dati correnti, sommandoli ai preesistenti
            // altrimenti si crea una nuova riga con i dati della corrente
            foreach (DataRow r in DS.Tables[tName].Select(filter)) {
                string codrit = (fieldcodice == null) ? codicerit : r[fieldcodice].ToString();
                string filtro = QHC.AppAnd(QHC.CmpEq("TIPORIT", codrit), QHC.CmpEq("RECORD", tiporec),
                    QHC.CmpEq("CODICEFISCALE", r01["codicefiscale"]),
                    QHC.CmpEq("COGNOME1",r01["cognome1"]), QHC.CmpEq("NOME1", r01["nome1"]));
                if (tiporec == "04"){
                    CodComune = leggiCodiceComune(r01, codrit);
                    filtro = QHC.AppAnd(filtro, QHC.CmpEq("CODCOMUNE", CodComune));
                }
                object codAss = (DS.Tables[tName].Columns.Contains("codiceassegno"))
                    ? r["codiceassegno"] : "001";

                string codAssStr = codAss.ToString().ToUpper();
    
                DataRow rExcel;
                if (tToExcel.Select(filtro).Length > 0) {
                    rExcel = tToExcel.Select(filtro)[0];
                    //rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel["IMPORTO"]) + CfgFn.GetNoNullDecimal(r[fieldimporto]);
                    decimal importoCurr = (codAssStr != "800")
                        ? CfgFn.GetNoNullDecimal(r[fieldimporto])
                        : -CfgFn.GetNoNullDecimal(r[fieldimporto]);

                    rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel["IMPORTO"]) +
                                          importoCurr;
                }
                else {
                    rExcel = tToExcel.NewRow();
                    rExcel["TIPORIT"] = codrit;
                    rExcel["RECORD"] = tiporec;
                    rExcel["CODICEFISCALE"] = r01["codicefiscale"];
                    rExcel["COGNOME1"] = r01["cognome1"];
                    rExcel["NOME1"] = r01["nome1"];
                    //rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(r[fieldimporto]);
                    rExcel["IMPORTO"] = (codAssStr != "800")
                       ? CfgFn.GetNoNullDecimal(r[fieldimporto])
                       : -CfgFn.GetNoNullDecimal(r[fieldimporto]);
                    rExcel["CODCOMUNE"] = CodComune;
                    tToExcel.Rows.Add(rExcel);
                }
            }
        }

        private object leggiCodiceComune(DataRow r01, string fieldvalue) {
            object CodiceComune = DBNull.Value;
            switch (fieldvalue.Trim().ToUpper()) {
                        case "CC0": {
                                CodiceComune =  r01["CodiceComuneAccon"];
                                break;
                            }
                        case "CC1": {
                                CodiceComune = r01["CodiceComuneSaldo"];
                                break;
                            }
                        case "CC2": {
                                CodiceComune = r01["CodiceComuneSaldo"];
                                break;
                            }
                        case "CCJ": {
                                CodiceComune = r01["CodiceAccontoDich"];
                                break;
                            }
                        case "CCY": {
                                CodiceComune = r01["CodiceAccontoCong"];
                                break;
                            }
                        case "CCC": {
                                CodiceComune = r01["CodiceAc"];
                                break;
                            }
                        case "CCG": {
                                CodiceComune = r01["CodiceAcCong"];
                                break;
                            }
                }
            if (CodiceComune == DBNull.Value)
                return r01["CodiceComuneRes"];
            else
                return CodiceComune;    
        }

        /// <summary>
        /// Metodo che, ricevuto in input il codice del record (tiporec), il nome del campo (fieldcodice),
        /// il nome del campo del sub del codice assegno (sub), il nome del campo ove Ë presente l'importo (fieldimporto),
        /// il codice della ritenuta (codicerit), il datarow del record 01 e il carico della ritenuta (se c/dip o c/amm) (carico),
        /// ricopia i dati di un insieme di righe appartenenti al tipo record tiporec
        /// nella tabella di output tExcel.
        /// </summary>
        /// <param name="tiporec"></param>
        /// <param name="fieldcodice"></param>
        /// <param name="fieldsub"></param>
        /// <param name="fieldimporto"></param>
        /// <param name="codicerit"></param>
        /// <param name="r01"></param>
        /// <param name="carico"></param>
        /// // copiaDati("04", "codiceritenuta", null, "importoritenuta", null, r01, "D");
        private void copiaDati(string tiporec, string fieldcodice, string fieldsub, string fieldimporto,
            string codicerit, DataRow r01, string carico) {
            string filter = QHC.CmpEq("numeroriga", r01["numeroriga"]);
            string tName = "SPT_" + tiporec;
            object CodComune = null;
            // Ciclo sul sottoinsieme della tabella di tipo record tiprec
            foreach (DataRow r in DS.Tables[tName].Select(filter)) {
                string codrit = (fieldcodice == null) ? codicerit : r[fieldcodice].ToString();

                object codAss = (DS.Tables[tName].Columns.Contains("codiceassegno"))
                    ? r["codiceassegno"] : "001";

                string filtroSub = "";

                if (fieldsub != null) {
                    if (r[fieldsub] == DBNull.Value) {
                        filtroSub = QHC.IsNull("SUB");
                    }
                    else {
                        filtroSub = QHC.CmpEq("SUB", r[fieldsub]);
                    }
                }

                string filtro = QHC.AppAnd(QHC.CmpEq("TIPORIT", codrit),
                    QHC.CmpEq("CODICEASSEGNO", codAss), filtroSub,
                    QHC.CmpEq("RECORD", tiporec), QHC.CmpEq("CARICO", carico));

                if (tiporec == "04")  {
                    CodComune = leggiCodiceComune(r01, codrit);
                    filtro = QHC.AppAnd(filtro, QHC.CmpEq("CODCOMUNE", CodComune));
                }
                DataRow rExcel;
                string codAssStr = codAss.ToString().ToUpper();
                
                if (tToExcel.Select(filtro).Length > 0) {
                    rExcel = tToExcel.Select(filtro)[0];
                    decimal importoCurr = (codAssStr != "800")
                        ? CfgFn.GetNoNullDecimal(r[fieldimporto])
                        : -CfgFn.GetNoNullDecimal(r[fieldimporto]);

                    rExcel["IMPORTO"] = CfgFn.GetNoNullDecimal(rExcel["IMPORTO"]) +
                        importoCurr;
                }
                else {
                    rExcel = tToExcel.NewRow();
                    rExcel["TIPORIT"] = codrit;
                    rExcel["CODICEASSEGNO"] = codAss;
                    rExcel["SUB"] = (fieldsub != null) ? r[fieldsub] : DBNull.Value;
                    rExcel["RECORD"] = tiporec;
                    rExcel["CARICO"] = carico;
                    rExcel["IMPORTO"] = (codAssStr != "800")
                        ? CfgFn.GetNoNullDecimal(r[fieldimporto])
                        : -CfgFn.GetNoNullDecimal(r[fieldimporto]);
                    tToExcel.Rows.Add(rExcel);
                    rExcel["CODCOMUNE"] = CodComune;
                }
            }
        }

        private bool copyTableWithLessColumn(System.Data.DataTable tSource, string[] elencoColonne, 
            string originalFieldAmount, out System.Data.DataTable tNewLayout) {
            tNewLayout = null;
            tNewLayout = creaTabellaConNuovoLayout(elencoColonne);
            tNewLayout.Columns.Add("IMPORTO");

            foreach (System.Data.DataRow rOrigine in tSource.Rows) {
                System.Data.DataRow newRow = tNewLayout.NewRow();
                foreach (System.Data.DataColumn cOrigine in tSource.Columns) {
                    if (cOrigine.ColumnName == originalFieldAmount) continue;
                    if (!tNewLayout.Columns.Contains(cOrigine.ColumnName)) continue;
                    newRow[cOrigine.ColumnName] = rOrigine[cOrigine.ColumnName];
                }
                newRow["IMPORTO"] = rOrigine[originalFieldAmount];

                tNewLayout.Rows.Add(newRow);
            }

            return true;
        }

        private System.Data.DataTable creaTabellaConNuovoLayout(string[] elencoColonne) {
            System.Data.DataTable t = new System.Data.DataTable();
            foreach (string col in elencoColonne) {
                string colOutput = col.ToUpper();
                t.Columns.Add(colOutput);
            }
            return t;
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            
            PostData.MarkAsTemporaryTable(DS.SPT_00, false);
            PostData.MarkAsTemporaryTable(DS.SPT_01, false);
            PostData.MarkAsTemporaryTable(DS.SPT_02, false);
            PostData.MarkAsTemporaryTable(DS.SPT_03, false);
            PostData.MarkAsTemporaryTable(DS.SPT_04, false);
            PostData.MarkAsTemporaryTable(DS.SPT_05, false);
            PostData.MarkAsTemporaryTable(DS.SPT_06, false);
            PostData.MarkAsTemporaryTable(DS.SPT_07, false);
            PostData.MarkAsTemporaryTable(DS.SPT_99, false);

            Meta.MainRefreshEnabled = false;
            Meta.SearchEnabled = false;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            Text = "Importazione stipendi da S.P.T.";
            dsImport = new DataSet();

            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        public void MetaData_AfterFill() {
            Text = "Importazione stipendi da S.P.T.";
        }

        public void MetaData_AfterClear() {
            Text = "Importazione stipendi da S.P.T.";
        }

        /// <summary>
        /// Metodo che effettua il parse del file ricevuto dal Ministero delle Finanze
        /// </summary>
        /// <returns></returns>
        bool parseFile() {
            StreamReader sr = getStreamReader();
            if (sr == null) {
                return false;
            }

            DS.SPT_00.Clear();
            DS.SPT_99.Clear();
            Application.DoEvents();
            Cursor = Cursors.WaitCursor;
            int numFile = 0;
            progressBar1.Maximum = (int)sr.BaseStream.Length;
            while (sr.Peek() != -1) {
                numFile++;
                DataRow rTC = DS.SPT_00.NewRow();
                if (!leggiRecordDiTesta(sr, rTC)) return false;
                DS.SPT_00.Rows.Add(rTC);
                // Nel DataSet sono definite tante tabelle quanti sono i possibili tipi di record definiti nelle 
                // specifiche tecniche fornite dal Ministero
                string tiprec = leggiIntestazioneRecord(sr, rTC);
                int nRiga = 0;
                while ((tiprec != "00") && (tiprec != "99")) {
                    switch (tiprec) {
                        case "01": {
                                DataRow r01 = DS.SPT_01.NewRow();
                                if (!leggiRec01(sr, r01, out nRiga)) return false;
                                DS.SPT_01.Rows.Add(r01);
                                break;
                            }
                        case "02": {
                                DataRow r02 = DS.SPT_02.NewRow();
                                if (!leggiRec02(sr, r02, nRiga)) return false;
                                DS.SPT_02.Rows.Add(r02);
                                break;
                            }
                        case "03": {
                                DataRow r03 = DS.SPT_03.NewRow();
                                if (!leggiRec03(sr, r03, nRiga)) return false;
                                DS.SPT_03.Rows.Add(r03);
                                break;
                            }
                        case "04": {
                                DataRow r04 = DS.SPT_04.NewRow();
                                if (!leggiRec04(sr, r04, nRiga)) return false;
                                DS.SPT_04.Rows.Add(r04);
                                break;
                            }
                        case "05": {
                                DataRow r05 = DS.SPT_05.NewRow();
                                if (!leggiRec05(sr, r05, nRiga)) return false;
                                DS.SPT_05.Rows.Add(r05);
                                break;
                            }
                        case "06": {
                                DataRow r06 = DS.SPT_06.NewRow();
                                if (!leggiRec06(sr, r06, nRiga)) return false;
                                DS.SPT_06.Rows.Add(r06);
                                break;
                            }
                        case "07": {
                                DataRow r07 = DS.SPT_07.NewRow();
                                if (!leggiRec07(sr, r07, nRiga)) return false;
                                DS.SPT_07.Rows.Add(r07);
                                break;
                            }
                    }
                    tiprec = leggiIntestazioneRecord(sr, rTC);
                    progressBar1.Value = (int)sr.BaseStream.Position;
                    Application.DoEvents();
                }

                if (tiprec != "99") {
                    QueryCreator.ShowError(this, "Mi aspettavo il record 99 invece ho ricevuto il record "
                        + tiprec, "");
                    return false;
                }
                DataRow rCoda = DS.SPT_99.NewRow();
                if (!leggiRecordDiCoda(sr, rCoda)) return false;
                DS.SPT_99.Rows.Add(rCoda);
            }

            sr.Close();
            return true;
        }

        bool leggiRecordDiTesta(TextReader tr, DataRow r) {
            r["tiporecord"] = leggiAlfanumerico(tr, 2); // Tipo Record
            r["rata"] = leggiNumerico(tr, 6);// Rata in elaborazione
            r["dataelaborazione"] = leggiDataAMG(tr, 8); //Data di elaborazione del file
            string tiprec = r["tiporecord"].ToString();
            if (tiprec != "00") {
                QueryCreator.ShowError(this, "Mi aspettavo il record 00 invece ho ricevuto il record " + tiprec, "");
                return false;
            }
            return vaiACapo(tr);
        }

        bool leggiRecordDiCoda(TextReader tr, DataRow r) {
            r["tiporecord"] = "99"; // Tipo Record
            r["rata"] = leggiNumerico(tr, 6);// Rata in elaborazione
            r["dataelaborazione"] = leggiDataAMG(tr, 8); //Data di elaborazione del file  
            r["totalepartite"] = leggiDecimale(tr, 6); //Data di elaborazione del file
            r["totaleimporto"] = leggiDecimale(tr, 15); //Data di elaborazione del file
            return vaiACapo(tr);
        }

        private bool leggiRec01(TextReader tr, DataRow r, out int nRiga) {
            nRiga = 1 + CfgFn.GetNoNullInt32(DS.SPT_01.Compute("MAX(numeroriga)", null));
            r["numeroriga"] = nRiga;
            r["tiporecord"] = "01";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["dpt"] = leggiAlfanumerico(tr, 3);
            r["codicefiscale"] = leggiAlfanumerico(tr, 16);
            r["cognome1"] = leggiAlfanumerico(tr, 30);
            r["nome1"] = leggiAlfanumerico(tr, 30);
            r["indirizzo"] = leggiAlfanumerico(tr, 50);
            r["localita"] = leggiAlfanumerico(tr, 40);
            r["cap"] = leggiAlfanumerico(tr, 5);
            r["provinciaresid"] = leggiAlfanumerico(tr, 2);
            r["modalpagamento"] = leggiNumerico(tr, 1);
            r["tiposervizio"] = leggiNumerico(tr, 2);
            r["iban"] = leggiAlfanumerico(tr, 4);
            r["cin"] = leggiAlfanumerico(tr, 1);
            r["abi"] = leggiAlfanumerico(tr, 5);
            r["cab"] = leggiAlfanumerico(tr, 5);
            r["contocorrente"] = leggiAlfanumerico(tr, 12);
            r["ufficioservizio"] = leggiAlfanumerico(tr, 4);
            r["capitolospesa"] = leggiAlfanumerico(tr, 4);
            r["capitolobilancio"] = leggiAlfanumerico(tr, 4);
            r["qualifica"] = leggiAlfanumerico(tr, 4);
            r["livello"] = leggiNumerico(tr, 3);
            r["classe"] = leggiNumerico(tr, 2);
            r["scatti"] = leggiNumerico(tr, 2);
            r["aliquotamedia"] = leggiDecimale(tr, 4);
            r["dataprossimoaps"] = leggiDataAMG(tr, 8);
            r["imponibilerataannocorrente"] = leggiDecimale(tr, 10);
            r["irpefrataannocorrente"] = leggiDecimale(tr, 10);
            r["irpefarretratiannocorrente"] = leggiDecimale(tr, 10);
            r["irpefarretratiannoprecedente"] = leggiDecimale(tr, 10);
            r["irpeftotalenetta"] = leggiDecimale(tr, 10);
            r["importoannuolordo"] = leggiDecimale(tr, 10);
            r["importomensilelordo"] = leggiDecimale(tr, 10);
            r["importomensilenetto"] = leggiDecimale(tr, 10);
            r["importonetto13ma"] = leggiDecimale(tr, 10);
            r["importoprev13ma"] = leggiDecimale(tr, 10);
            r["importoirpef13ma"] = leggiDecimale(tr, 10);
            r["percptime"] = leggiDecimale(tr, 4);
            r["numerofigli"] = leggiNumerico(tr, 2);
            r["numeroaltrifam"] = leggiNumerico(tr, 2);
            r["detrazionibase"] = leggiDecimale(tr, 10);
            r["detrazioniconiuge"] = leggiDecimale(tr, 10);
            r["detrazionifigli"] = leggiDecimale(tr, 10);
            r["detrazionialtrifam"] = leggiDecimale(tr, 10);
            r["flageffettoconiuge"] = leggiAlfanumerico(tr, 1);
            r["totaledetrazioni"] = leggiDecimale(tr, 10);
            r["numerominori3anni"] = leggiNumerico(tr, 2);
            r["codiceregimecontributivo"] = leggiAlfanumerico(tr, 1);
            r["codregioneirap"] = leggiAlfanumerico(tr, 2);
            r["aliquotamassima"] = leggiDecimale(tr, 4);
            r["aliquotamaxforzata"] = leggiDecimale(tr, 4);
            r["CodiceComuneAccon"] = leggiAlfanumerico(tr, 4);
            r["CodiceComuneSaldo"] = leggiAlfanumerico(tr, 4);
            r["CodiceAccontoDich"] = leggiAlfanumerico(tr, 4);
            r["CodiceAccontoCong"] = leggiAlfanumerico(tr, 4);
            r["CodiceAc"] = leggiAlfanumerico(tr, 4);
            r["CodiceAcCong"] = leggiAlfanumerico(tr, 4);
            r["CodiceComuneRes"] = leggiAlfanumerico(tr, 4);

            return vaiACapo(tr);
        }

        private bool leggiRec02(TextReader tr, DataRow r, int nRigaRiferimento) {
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "02";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["codiceassegno"] = leggiAlfanumerico(tr, 3);
            r["sottocodiceassegno"] = leggiAlfanumerico(tr, 3);
            r["importolordotabellare"] = leggiDecimale(tr, 10);
            r["importolordorata"] = leggiDecimale(tr, 10);
            r["importoriduzionept"] = leggiDecimale(tr, 10);
            r["importoriduzionete"] = leggiDecimale(tr, 10);
            r["importoritprev"] = leggiDecimale(tr, 10);
            r["datascadassegno"] = leggiDataAM(tr, 6);
            r["flagimponfiscale"] = leggiAlfanumerico(tr, 1);

            return vaiACapo(tr);
        }

        private bool leggiRec03(TextReader tr, DataRow r, int nRigaRiferimento) {
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "03";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["codiceassegno"] = leggiAlfanumerico(tr, 3);
            r["codritprevass"] = leggiAlfanumerico(tr, 2);
            r["aliquotalavoratore"] = leggiDecimale(tr, 5);
            r["percentualeapplicazione"] = leggiDecimale(tr, 4);
            r["imponibile"] = leggiDecimale(tr, 10);
            r["importoritenuta"] = leggiDecimale(tr, 10);
            r["aliquotadatore"] = leggiDecimale(tr, 5);
            r["importodatore"] = leggiDecimale(tr, 10);

            return vaiACapo(tr);
        }

        private bool leggiRec04(TextReader tr, DataRow r, int nRigaRiferimento) {
            string tr04 = tr.ReadLine();
            StringReader trs = new StringReader(tr04);
            int lenTr04 = tr04.Length;
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "04";
            r["iscrizione"] = leggiNumerico(trs, 8);
            r["rata"] = leggiNumerico(trs, 6);
            r["dataemissione"] = leggiDataAMG(trs, 8);
            r["codiceritenuta"] = leggiAlfanumerico(trs, 3);
            r["tiporitenuta"] = leggiAlfanumerico(trs, 1);
            r["flagriduzimpon"] = leggiAlfanumerico(trs, 1);
            r["progressivodebito"] = leggiNumerico(trs, 4);
            r["importoritenuta"] = leggiDecimale(trs, 10);
            if (lenTr04 == 49) {
                r["datascadritextra"] = leggiDataAM(trs, 6);
            }

            return ((lenTr04 != 49) && (lenTr04 != 43));
        }

        private bool leggiRec05(TextReader tr, DataRow r, int nRigaRiferimento) {
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "05";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["codiceritenutacategoria"] = leggiAlfanumerico(tr, 3);
            r["codiceassegno"] = leggiAlfanumerico(tr, 3);
            r["importoritenuta"] = leggiNumerico(tr, 10);
            r["datascadritcat"] = leggiDataAMG(tr, 8);
            r["tiporitcat"] = leggiAlfanumerico(tr, 1);
            r["percapplritcat"] = leggiDecimale(tr, 6);
            r["percritcat"] = leggiDecimale(tr, 6);

            return vaiACapo(tr);
        }

        private bool leggiRec06(TextReader tr, DataRow r, int nRigaRiferimento) {
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "06";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["codiceassegno"] = leggiAlfanumerico(tr, 3);
            r["codicearretrato"] = leggiAlfanumerico(tr, 3);
            r["datalotto"] = leggiDataAMG(tr, 8);
            r["numlotto"] = leggiNumerico(tr, 5);
            r["annoriferimento"] = leggiNumerico(tr, 4);
            r["importolordorata"] = leggiDecimale(tr, 10);
            r["importoriduzionept"] = leggiDecimale(tr, 10);
            r["importoriduzionepe"] = leggiDecimale(tr, 10);
            r["importoritenute"] = leggiDecimale(tr, 10);

            return vaiACapo(tr);
        }

        private bool leggiRec07(TextReader tr, DataRow r, int nRigaRiferimento) {
            r["numeroriga"] = nRigaRiferimento;
            r["tiporecord"] = "07";
            r["iscrizione"] = leggiNumerico(tr, 8);
            r["rata"] = leggiNumerico(tr, 6);
            r["dataemissione"] = leggiDataAMG(tr, 8);
            r["codiceassegno"] = leggiAlfanumerico(tr, 3);
            r["codicearretrato"] = leggiAlfanumerico(tr, 3);
            r["datalotto"] = leggiDataAMG(tr, 8);
            r["numlotto"] = leggiNumerico(tr, 5);
            r["annoriferimento"] = leggiNumerico(tr, 4);
            r["codritprevass"] = leggiAlfanumerico(tr, 2);
            r["imponibile"] = leggiDecimale(tr, 10);
            r["importoritlavoratore"] = leggiDecimale(tr, 10);
            r["importoritdatore"] = leggiDecimale(tr, 10);

            return vaiACapo(tr);
        }

        public StreamReader getStreamReader() {
            if (txtInputFile.Text == "") {
                MessageBox.Show(this, "Nessun file selezionato!");
                return null;
            }
            openInputFileDlg.FileName = txtInputFile.Text;
            
            FileInfo fi = new FileInfo(openInputFileDlg.FileName);
            try {
                return new StreamReader(new BufferedStream(openInputFileDlg.OpenFile(), 1048576), Encoding.Default);
            }
            catch (Exception e2) {
                QueryCreator.ShowException(this, "Errore durante l'apertura del file selezionato!", e2);
            }
            
            return null;
        }

        public string leggiAlfanumerico(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            return new string(buffer, 0, numCifre).Trim();
        }


        public bool vaiACapo(TextReader tr) {
            if (tr.Read(buffer, 0, 1) != 1) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
                return false;
            }
            // Attenzione il file di input non ha \r ma solo \n
            if (buffer[0] != 10) {
                QueryCreator.ShowError(this, "Manca l'interruzione di riga", "Manca l'interruzione di riga");
                return false;
            }
            return true;
        }

        public int leggiNumerico(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return int.Parse(s);
            }
            catch (Exception e) {
                string spazi = "".PadRight(numCifre);
                if (s != spazi) {
                    QueryCreator.ShowException(this, "ERRORE DURANTE LA LETTURA DI UN NUMERICO DAL FILE\r\n" + s, e);
                }
                return 0;
            }
        }

        public long leggiLong(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return long.Parse(s);
            }
            catch (Exception e) {
                QueryCreator.ShowException(this, "ERRORE DURANTE LA LETTURA DI UN LONG DAL FILE\r\n" + s, e);
            }
            return 0;
        }

        public decimal leggiDecimale(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre - 2)
                + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                + new string(buffer, numCifre - 2, 2);
            return decimal.Parse(s);
        }

        public string leggiSegnoConDecimaleAoD(TextReader tr, int numCifre, out decimal decimale) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            if (buffer[0] != 'A' && buffer[0] != 'D') {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da A o D");
            }

            string segno = buffer[0] == 'A' ? "" : "-";
            string s = segno
                + new string(buffer, 1, numCifre - 3)
                + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                + new string(buffer, numCifre - 2, 2);
            decimale = decimal.Parse(s);
            return buffer[0].ToString();
        }

        public string leggiSegnoConDecimalePiuOMeno(TextReader tr, int numCifre, out decimal decimale) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            if (buffer[0] != '+' && buffer[0] != '-') {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da + o -");
            }

            //			string segno = buffer[0]=='A'? "": "-";
            string s =
                new string(buffer, 0, numCifre - 2)
                + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                + new string(buffer, numCifre - 2, 2);
            decimale = decimal.Parse(s);
            return buffer[0].ToString();
        }

        public decimal leggiDecimaleConSegno(TextReader tr, int numCifre, out string segno) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            segno = buffer[numCifre - 1].ToString();
            string s = buffer[numCifre - 1]
                + new string(buffer, 0, numCifre - 3)
                + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                + new string(buffer, numCifre - 3, 2);
            return decimal.Parse(s);
        }

        public DateTime leggiDataGMA(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            try {
                return DateTime.ParseExact(new string(buffer, 0, numCifre), "ddMMyyyy", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                string s = new string(buffer, 0, numCifre);
                string zeri = "".PadRight(numCifre, '0');
                string spazi = "".PadRight(numCifre, ' ');
                if ((s != zeri) && (s != spazi)) {
                    QueryCreator.ShowException(this, "ERRORE DURANTE LA LETTURA DEL FILE: DATA GMA", e);
                }
                return new DateTime();
            }
        }

        public DateTime leggiDataAMG(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return DateTime.ParseExact(s, "yyyyMMdd", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                if ((new string(buffer, 0, numCifre) != "".PadRight(numCifre, '0')) && 
                    (new string(buffer, 0, numCifre) != "".PadRight(numCifre, ' ')))
                {
                    QueryCreator.ShowException(this, "ERRORE DURANTE LA LETTURA DEL FILE: DATA AMG\r\n" + s, e);
                }
                return new DateTime();
            }
        }

        public DateTime leggiDataAM(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(this, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return DateTime.ParseExact(s, "yyyyMM", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                if ((new string(buffer, 0, numCifre) != "".PadRight(numCifre, '0')) &&
                    (new string(buffer, 0, numCifre) != "".PadRight(numCifre, ' '))) {
                    QueryCreator.ShowException(this, "ERRORE DURANTE LA LETTURA DEL FILE: DATA AMG\r\n" + s, e);
                }
                return new DateTime();
            }
        }

        private string leggiIntestazioneRecord(TextReader tr, DataRow r) {
            return leggiAlfanumerico(tr, 2); // Tipo Record
        }
    }
}