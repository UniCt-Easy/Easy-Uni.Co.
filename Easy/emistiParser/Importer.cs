
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
using System.Data;
using System.IO;

using meta_emisti_rec_01;
using meta_emisti_rec_02;
using meta_emisti_rec_03;
using meta_emisti_rec_04;
using meta_emisti_rec_05;
using meta_emisti_rec_06;
using meta_emisti_rec_07;
using meta_emisti_rec_08;
using meta_emisti_rec_09;
using meta_emisti_rec_10;

using metadatalibrary;
using ServizioPa.Models;
using ServizioPa.Repository;

namespace emistiParser {

    public enum Record {

        Testa,
        Anagrafica,
        Assegni,
        RitenutePrevidenziali,
        RitenuteExtraErariali,
        RitenuteCategoria,
        ArretratiAssegni,
        ArretratiRitenute,
        Accessori,
        RitenutePrevidenzialiAccessori,
        RitenutaAcconto,

        Unknown,
    }

    public class ParseError {

        public readonly Record RecordType;
        public readonly int LineNumber;
        public readonly string Line;

        public readonly string Message;

        public ParseError(Record type, int lineNumber, string line, string message) {

            RecordType = type;
            LineNumber = lineNumber;
            Line = line;
            Message = message;
        }
    }

    public static class EmistiImporter {

        public static IEnumerable<ParseError> Load(DataAccess conn, string filePath, dsmeta ds, string description = null) {

            ds.Clear();
            init(conn, ds);

            var import = ds.emisti_import.newRow();

            int importKey = 1;
            import.idemisti_import = importKey;

            import.yimport = (short)conn.GetEsercizio();
            import.nimport = 1;
            import.description = string.IsNullOrEmpty(description) ? string.Format("Importazione del {0} dal file {1}", DateTime.Now, Path.GetFileName(filePath)) : description;
            
            ds.emisti_import.Rows.Add(import);

            StreamReader file = new StreamReader(filePath);

            List<ParseError> pErrors = new List<ParseError>();

            string currLine = file.ReadLine();
            string nextLine = file.ReadLine();
            int nLine = 1;
            int nInstance = 0;

            while (nextLine != null) {

                if (!string.IsNullOrEmpty(currLine)) {

                    if (!int.TryParse(currLine.Substring(0, 2), out int typeID)) {

                        pErrors.Add(new ParseError(Record.Unknown, nLine, currLine, "impossibile identificare il tipo di record"));

                    } else {

                        Record recordType = (Record)typeID;

                        switch (recordType) {

                            case Record.Anagrafica:

                                Emisti_Rec_01 em_01;

                                try {
                                    em_01 = EmistiRec.CreateEmistiRow_01(currLine);

                                    if (em_01 != null) {

                                        emisti_rec_01Row tmpRow = ds.emisti_rec_01.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_01.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = ++nInstance;

                                        tmpRow.abi = em_01.Abi;
                                        //tmpRow.aliquotamedia =
                                        tmpRow.cab = em_01.Cab;
                                        tmpRow.capitolobilancio = em_01.CapitoloBilancio;
                                        tmpRow.capitolospesa = em_01.CapitoloSpesa;
                                        tmpRow.cin = em_01.Cin;
                                        tmpRow.classe = em_01.Classe;
                                        tmpRow.codicecomuneaccon = em_01.CodiceComuneAccon;
                                        tmpRow.codicecomunesaldo = em_01.CodiceComuneSaldo;
                                        tmpRow.codicefiscale = em_01.CodiceFiscale;
                                        tmpRow.codiceregimecontributivo = em_01.CodiceRegimeContributivo;
                                        tmpRow.codregioneirap = em_01.CodRegioneIrap;
                                        tmpRow.cognome1 = em_01.Cognome1;
                                        tmpRow.contocorrente = em_01.ContoCorrente;
                                        tmpRow.creditoirpef = (int)em_01.CreditoIrpef;
                                        tmpRow.dataemissione = em_01.DataEmissione;
                                        tmpRow.detrazionialtrifam = em_01.DetrazioniAltriFam;
                                        tmpRow.detrazionibase = em_01.DetrazioniBase;
                                        tmpRow.detrazioniconiuge = em_01.DetrazioniConiuge;
                                        tmpRow.detrazionifigli = em_01.DetrazioniFigli;
                                        tmpRow.dpt = em_01.Dpt;
                                        tmpRow.iban = em_01.Iban;
                                        tmpRow.imponibilerataannocorrente = em_01.ImponibileRataAnnoCorrente;
                                        tmpRow.importoannuolordo = em_01.ImportoAnnuoLordo;
                                        tmpRow.importoirpef13ma = em_01.ImportoIrpef13ma;
                                        tmpRow.importomensilelordo = em_01.ImportoMensileLordo;
                                        tmpRow.importomensilenetto = em_01.ImportoMensileNetto;
                                        tmpRow.importonetto13ma = em_01.ImportoNetto13ma;
                                        tmpRow.importoprev13ma = em_01.ImportoPrev13ma;
                                        //tmpRow.irpefaccessorieac =
                                        //tmpRow.irpefaccessorieap =
                                        tmpRow.irpefarretratiannocorrente = em_01.IRPEFArretratiAnnoCorrente;
                                        tmpRow.irpefarretratiannoprecedente = em_01.IRPEFArretratiAnnoPrecedente;
                                        tmpRow.irpefrataannocorrente = em_01.IRPEFRataAnnoCorrente;
                                        tmpRow.irpeftotalenetta = em_01.IRPEFTotaleNetta;
                                        tmpRow.iscrizione = em_01.Iscrizione;
                                        tmpRow.livello = em_01.Livello;
                                        tmpRow.modalpagamento = em_01.ModalPagamento;
                                        tmpRow.nome1 = em_01.Nome1;
                                        tmpRow.qualifica = em_01.Qualifica;
                                        tmpRow.rata = em_01.Rata;
                                        tmpRow.regimecontributivocud = em_01.RegimeContributivoCud;
                                        tmpRow.scatti = em_01.Scatti;
                                        tmpRow.tiposervizio = em_01.TipoServizio;
                                        tmpRow.totaledetrazioni = em_01.TotaleDetrazioni;
                                        tmpRow.ufficioservizio = em_01.UfficioServizio;

                                        ds.emisti_rec_01.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.Assegni:

                                Emisti_Rec_02 em_02;

                                try {
                                    em_02 = EmistiRec.CreateEmistiRow_02(currLine);

                                    if (em_02 != null) {

                                        emisti_rec_02Row tmpRow = ds.emisti_rec_02.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_02.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.codiceassegno = em_02.CodiceAssegno;
                                        tmpRow.dataemissione = em_02.DataEmissione;
                                        tmpRow.datascadassegno = em_02.DataScadAssegno;
                                        tmpRow.flagimponfiscale = em_02.FlagImponFiscale;
                                        tmpRow.importolordorata = em_02.ImportoLordoRata;
                                        tmpRow.importolordotabellare = em_02.ImportoLordoTabellare;
                                        tmpRow.importoriduzionept = em_02.ImportoRiduzionePT;
                                        tmpRow.importoriduzionete = em_02.ImportoRiduzioneTE;
                                        tmpRow.importoritprev = em_02.ImportoRitPrev;
                                        tmpRow.rata = em_02.Rata;
                                        tmpRow.sottocodiceassegno = em_02.SottocodiceAssegno;

                                        ds.emisti_rec_02.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.RitenutePrevidenziali:

                                Emisti_Rec_03 em_03;

                                try {
                                    em_03 = EmistiRec.CreateEmistiRow_03(currLine);

                                    if (em_03 != null) {

                                        emisti_rec_03Row tmpRow = ds.emisti_rec_03.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_03.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.aliquotadatore = em_03.AliquotaDatore;
                                        tmpRow.aliquotalavoratore = em_03.AliquotaLavoratore;
                                        tmpRow.codiceassegno = em_03.CodiceAssegno;
                                        tmpRow.codritprevass = em_03.CodRitPrevAss;
                                        tmpRow.dataemissione = em_03.DataEmissione;
                                        tmpRow.imponibile = em_03.Imponibile;
                                        tmpRow.importodatore = em_03.ImportoDatore;
                                        tmpRow.importoritenuta = em_03.ImportoRitenuta;
                                        tmpRow.percentualeapplicazione = em_03.PercentualeApplicazione;
                                        tmpRow.rata = em_03.Rata;

                                        ds.emisti_rec_03.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.RitenuteExtraErariali:

                                Emisti_Rec_04 em_04;

                                try {
                                    em_04 = EmistiRec.CreateEmistiRow_04(currLine);

                                    if (em_04 != null) {

                                        emisti_rec_04Row tmpRow = ds.emisti_rec_04.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_04.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.codcontratto = em_04.CodContratto;
                                        tmpRow.codiceritenuta = em_04.CodiceRitenuta;
                                        tmpRow.tiporitenuta = em_04.TipoRitenuta;
                                        tmpRow.flagriduzimpon = em_04.FlagRiduzImpon;
                                        tmpRow.progressivodebito = em_04.ProgressivoDebito;
                                        tmpRow.codrit1tantum = em_04.CodRit1Tantum;
                                        tmpRow.codritoneremens = em_04.CodRitOnereMens;
                                        tmpRow.dataemissione = em_04.DataEmissione;
                                        tmpRow.importooneremens = em_04.ImportoOnereMens;
                                        tmpRow.importorit1tantum = em_04.ImportoRit1Tantum;
                                        tmpRow.importoritenuta = em_04.ImportoRitenuta;
                                        tmpRow.importoritnetto = em_04.ImportoRitNetto;
                                        tmpRow.rata = em_04.Rata;

                                        ds.emisti_rec_04.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.RitenuteCategoria:

                                Emisti_Rec_05 em_05;

                                try {
                                    em_05 = EmistiRec.CreateEmistiRow_05(currLine);

                                    if (em_05 != null) {

                                        emisti_rec_05Row tmpRow = ds.emisti_rec_05.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_05.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.codiceassegno = em_05.CodiceAssegno;
                                        tmpRow.codiceritenutacategoria = em_05.CodiceRitenutaCategoria;
                                        tmpRow.dataemissione = em_05.DataEmissione;
                                        tmpRow.datascadritcat = DateTime.Parse(em_05.DataScadRitCat);
                                        tmpRow.importoritenuta = em_05.ImportoRitenuta;
                                        tmpRow.percapplritcat = em_05.PercApplRitCat;
                                        tmpRow.percritcat = em_05.PercRitCat;
                                        tmpRow.rata = em_05.Rata;
                                        tmpRow.tiporitcat = em_05.TipoRitCat;

                                        ds.emisti_rec_05.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.ArretratiAssegni:

                                Emisti_Rec_06 em_06;

                                try {
                                    em_06 = EmistiRec.CreateEmistiRow_06(currLine);

                                    if (em_06 != null) {

                                        emisti_rec_06Row tmpRow = ds.emisti_rec_06.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_06.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.annoriferimento = em_06.AnnoRiferimento;
                                        tmpRow.codicearretrato = em_06.CodiceArretrato;
                                        tmpRow.codiceassegno = em_06.CodiceAssegno;
                                        tmpRow.dataemissione = em_06.DataEmissione;
                                        tmpRow.datalotto = em_06.DataLotto;
                                        tmpRow.importolordorata = em_06.ImportoLordoRata;
                                        tmpRow.importoriduzionept = em_06.ImportoRiduzionePT;
                                        tmpRow.importoriduzionete = em_06.ImportoRiduzioneTE;
                                        tmpRow.importoritenute = em_06.ImportoRitenute;
                                        tmpRow.numlotto = em_06.NumLotto;
                                        tmpRow.rata = em_06.Rata;

                                        ds.emisti_rec_06.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.ArretratiRitenute:

                                Emisti_Rec_07 em_07;

                                try {
                                    em_07 = EmistiRec.CreateEmistiRow_07(currLine);

                                    if (em_07 != null) {

                                        emisti_rec_07Row tmpRow = ds.emisti_rec_07.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_07.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.annoriferimento = em_07.AnnoRiferimento;
                                        tmpRow.codicearretrato = em_07.CodiceArretrato;
                                        tmpRow.codiceassegno = em_07.CodiceAssegno;
                                        tmpRow.codritprevass = em_07.CodRitPrevAss;
                                        tmpRow.dataemissione = em_07.DataEmissione;
                                        tmpRow.datalotto = em_07.DataLotto;
                                        tmpRow.imponibile = em_07.Imponibile;
                                        tmpRow.importoritdatore = em_07.ImportoRitDatore;
                                        tmpRow.importoritlavoratore = em_07.ImportoRitLavoratore;
                                        tmpRow.numlotto = em_07.NumLotto;
                                        tmpRow.rata = em_07.Rata;

                                        ds.emisti_rec_07.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.Accessori:

                                Emisti_Rec_08 em_08;

                                try {
                                    em_08 = EmistiRec.CreateEmistiRow_08(currLine);

                                    if (em_08 != null) {

                                        emisti_rec_08Row tmpRow = ds.emisti_rec_08.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_08.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.annoriferimento = em_08.AnnoRiferimento;
                                        tmpRow.capbilstato = em_08.CapBilStato;
                                        tmpRow.codente = em_08.CodEnte;
                                        tmpRow.compenso = em_08.Compenso;
                                        tmpRow.dataemissione = em_08.DataEmissione;
                                        tmpRow.fine_comp = em_08.Fine_comp;
                                        tmpRow.idelenco = (int)em_08.IdElenco;
                                        tmpRow.importo = em_08.Importo;
                                        tmpRow.importoritenute = em_08.ImportoRitenute;
                                        tmpRow.imp_unitario = em_08.Imp_unitario;
                                        tmpRow.inizio_comp = em_08.Inizio_comp;
                                        tmpRow.numpg = em_08.NumPG;
                                        tmpRow.quantita = em_08.Quantita;
                                        tmpRow.rata = em_08.Rata;
                                        tmpRow.sottocompenso = em_08.Sottocompenso;
                                        tmpRow.tipolcompenso = em_08.TipolCompenso;
                                        tmpRow.tipotass = em_08.TipoTass;
                                        tmpRow.ufficioresponsabilecomunicante = em_08.UfficioResponsabileComunicante;
                                        tmpRow.ufficioserviziocomunicante = em_08.UfficioServizioComunicante;

                                        ds.emisti_rec_08.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.RitenutePrevidenzialiAccessori:

                                Emisti_Rec_09 em_09;

                                try {
                                    em_09 = EmistiRec.CreateEmistiRow_09(currLine);

                                    if (em_09 != null) {

                                        emisti_rec_09Row tmpRow = ds.emisti_rec_09.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_09.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.annoriferimento = em_09.AnnoRiferimento;
                                        tmpRow.capbilstato = em_09.CapBilStato;
                                        tmpRow.codritprevass = em_09.CodRitPrevAss;
                                        tmpRow.compenso = em_09.Compenso;
                                        tmpRow.dataemissione = em_09.DataEmissione;
                                        tmpRow.idelenco = (int)em_09.IdElenco;
                                        tmpRow.imponibile = em_09.Imponibile;
                                        tmpRow.importoritdatore = em_09.ImportoRitDatore;
                                        tmpRow.importoritlavoratore = em_09.ImportoRitLavoratore;
                                        tmpRow.numpg = em_09.NumPG;
                                        tmpRow.rata = em_09.Rata;
                                        tmpRow.sottocompenso = em_09.Sottocompenso;
                                        tmpRow.tipolcompenso = em_09.TipolCompenso;

                                        ds.emisti_rec_09.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                }

                                break;

                            case Record.RitenutaAcconto:

                                Emisti_Rec_10 em_10;

                                try {
                                    em_10 = EmistiRec.CreateEmistiRow_10(currLine);

                                    if (em_10 != null) {

                                        emisti_rec_10Row tmpRow = ds.emisti_rec_10.newRow();

                                        tmpRow.idemisti_import = importKey;
                                        tmpRow.nrec = ds.emisti_rec_10.Rows.Count + 1;
                                        tmpRow.progressivo_rec_01 = nInstance;

                                        tmpRow.emissione = em_10.Emissione;
                                        tmpRow.impcontrintegrcat = em_10.ImpContrIntegrCat;
                                        tmpRow.impcontrintegrinps = em_10.ImpContrIntegrInps;
                                        tmpRow.imponibileritenutaacconto = em_10.ImponibileRitenutaAcconto;
                                        tmpRow.imponibileritenutaaccontoiva = em_10.ImponibileRitenutaAccontoIva;
                                        tmpRow.importoiva = em_10.ImportoIva;
                                        tmpRow.importoritenutaacconto = em_10.ImportoRitenutaAcconto;
                                        tmpRow.perccontrintegrcat = em_10.PercContrIntegrCat;
                                        tmpRow.perccontrintegrinps = em_10.PercContrIntegrInps;
                                        tmpRow.rata = em_10.Rata;

                                        ds.emisti_rec_10.Rows.Add(tmpRow);
                                    }
                                }
                                catch (Exception e) {
                                    pErrors.Add(new ParseError(recordType, nLine, currLine, e.Message));
                                    continue;
                                }

                                break;

                            default:

                                if (nLine == 1 || nextLine == null) // testa e coda
                                    break;

                                pErrors.Add(new ParseError(Record.Unknown, nLine, currLine, "tipo di record non gestito"));
                                break;

                        }
                    }
                }

                currLine = nextLine;
                nextLine = file.ReadLine();
                nLine++;
            }

            file.Close();

            return pErrors;

        }

        public static void init(DataAccess Conn, dsmeta ds) {
            MetaData.SetDefault(ds.emisti_import, "adate", Conn.GetDataContabile().Date);
            MetaData.SetDefault(ds.emisti_import,"yimport", Conn.GetSys("esercizio"));
            MetaData.SetDefault(ds.emisti_import, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_import, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_import, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_import, "lu", Conn.GetSys("user"));
            RowChange.MarkAsAutoincrement(ds.emisti_import.Columns["idemisti_import"], null, null, 0);
            RowChange.MarkAsAutoincrement(ds.emisti_import.Columns["nimport"], null, null, 0);
            RowChange.SetMySelector(ds.emisti_import.Columns["nimport"], "yimport", 0);

            MetaData.SetDefault(ds.emisti_rec_01, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_01, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_01, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_01, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_01, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_01.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_02, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_02, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_02, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_02, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_02, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_02.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_03, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_03, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_03, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_03, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_03, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_03.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_04, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_04, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_04, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_04, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_04, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_04.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_05, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_05, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_05, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_05, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_05, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_05.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_06, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_06, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_06, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_06, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_06, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_06.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_07, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_07, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_07, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_07, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_07, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_07.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_08, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_08, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_08, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_08, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_08, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_08.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_09, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_09, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_09, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_09, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_09, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_09.Columns["nrec"], null, null, 0);

            MetaData.SetDefault(ds.emisti_rec_10, "ct", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_10, "cu", Conn.GetSys("user"));
            MetaData.SetDefault(ds.emisti_rec_10, "lt", DateTime.Now);
            MetaData.SetDefault(ds.emisti_rec_10, "lu", Conn.GetSys("user"));
            RowChange.SetSelector(ds.emisti_rec_10, "idemisti_import");
            RowChange.MarkAsAutoincrement(ds.emisti_rec_10.Columns["nrec"], null, null, 0);

            ClearDataSet.RemoveConstraints(ds);
        }
    }
}

//using MetaRowParser;

//namespace emisti {

//    class Importer {

//        public enum Record {
//            Anagrafica,                         //01
//            Assegni,                            //02
//            RitenutePrevidenziali,              //03
//            RitenuteExtra,                      //04
//            RitenuteCategoria,                  //05
//            ArretratiAssegni,                   //06
//            ArretratiRitenute,                  //07
//            Accessori,                          //08
//            RitenutePrevidenzialiAccessorie,    //09
//            emisti10                            //
//        };

//        private readonly StreamReader fileStream;
//        private readonly Dictionary<Record, dynamic> parsers = new Dictionary<Record, dynamic>();

//        public Importer(string filePath) {

//            var emisti01parser = new MetaRowParser<emisti_rec_01Row>();

//            emisti01parser.Define("rata", 0, 6);
//            emisti01parser.Define("rata", 0, 6);
//            emisti01parser.Define("rata", 0, 6);



//            parsers.Add(Record.Anagrafica, new MetaRowParser<emisti_rec_01Row>());
//            parsers.Add(Record.Assegni, new MetaRowParser<emisti_rec_02Row>());
//            parsers.Add(Record.RitenutePrevidenziali, new MetaRowParser<emisti_rec_03Row>());
//            parsers.Add(Record.RitenuteExtra, new MetaRowParser<emisti_rec_04Row>());
//            parsers.Add(Record.RitenuteCategoria, new MetaRowParser<emisti_rec_05Row>());
//            parsers.Add(Record.ArretratiAssegni, new MetaRowParser<emisti_rec_06Row>());
//            parsers.Add(Record.ArretratiRitenute, new MetaRowParser<emisti_rec_07Row>());
//            parsers.Add(Record.Accessori, new MetaRowParser<emisti_rec_08Row>());
//            parsers.Add(Record.RitenutePrevidenzialiAccessorie, new MetaRowParser<emisti_rec_09Row>());
//            parsers.Add(Record.emisti10, new MetaRowParser<emisti_rec_10Row>());
//        }

//        public void Load() {

//            string line = fileStream.ReadLine();

//            while (line != null) {

//                if (!int.TryParse(line.Substring(0, 2), out int type)) {
//                    continue;
//                }

//                parsers[(Record)type].Parse(line, );
//            }
//        }
//    }
//}
