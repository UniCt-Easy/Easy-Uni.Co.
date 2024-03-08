
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


//using ServizioPa.Data;
using ServizioPa.Models;
using System;
using System.IO;
using System.Linq;

namespace ServizioPa.Repository
{
    public static class EmistiRec
    {
        //private readonly ApplicationDbContext _context;

        //public EmistiRec(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //// ==================================================================================================================
        ////                                                      01
        //// ==================================================================================================================
        //public void Elabora(Stream file)
        //{
        //    int progressivo = 1;
        //    StreamReader sr = new StreamReader(file);
        //    String line = sr.ReadLine();
        //    while (line != null)
        //    {
        //        switch (line.Substring(0, 2))
        //        {
        //            case "01":
        //                Emisti_Rec_01 em_01 = CreateEmistiRow_01(line);
        //                if (em_01 != null)
        //                {
        //                    if (_context.Emisti_Rec_01.Count() == 0)
        //                        progressivo = 1;//em_01.Progressivo = 1;
        //                    else
        //                        progressivo = _context.Emisti_Rec_01.Max(m => m.Progressivo) + 1;//em_01.Progressivo = _context.Emisti_Rec_01.Max(m => m.Progressivo) + 1;
        //                    em_01.Progressivo = progressivo;
        //                    _context.Add(em_01);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "02":
        //                Emisti_Rec_02 em_02 = CreateEmistiRow_02(line);
        //                if (em_02 != null)
        //                {
        //                    em_02.Progressivo = progressivo;
        //                    _context.Add(em_02);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "03":
        //                Emisti_Rec_03 em_03 = CreateEmistiRow_03(line);
        //                if (em_03 != null)
        //                {
        //                    //if (_context.Emisti_Rec_03.Count() == 0)
        //                    //    em_03.Progressivo = 1;
        //                    //else
        //                    //    em_03.Progressivo = _context.Emisti_Rec_03.Max(m => m.Progressivo) + 1;
        //                    em_03.Progressivo = progressivo;
        //                    _context.Add(em_03);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "04":
        //                Emisti_Rec_04 em_04 = CreateEmistiRow_04(line);
        //                if (em_04 != null)
        //                {
        //                    //if (_context.Emisti_Rec_04.Count() == 0)
        //                    //    em_04.Progressivo = 1;
        //                    //else
        //                    //    em_04.Progressivo = _context.Emisti_Rec_04.Max(m => m.Progressivo) + 1;
        //                    em_04.Progressivo = progressivo;
        //                    _context.Add(em_04);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "05":
        //                Emisti_Rec_05 em_05 = CreateEmistiRow_05(line);
        //                if (em_05 != null)
        //                {
        //                    em_05.Progressivo = progressivo;
        //                    _context.Add(em_05);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "06":
        //                Emisti_Rec_06 em_06 = CreateEmistiRow_06(line);
        //                if (em_06 != null)
        //                {
        //                    em_06.Progressivo = progressivo;
        //                    _context.Add(em_06);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "07":
        //                Emisti_Rec_07 em_07 = CreateEmistiRow_07(line);
        //                if (em_07 != null)
        //                {
        //                    em_07.Progressivo = progressivo;
        //                    _context.Add(em_07);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "08":
        //                Emisti_Rec_08 em_08 = CreateEmistiRow_08(line);
        //                if (em_08 != null)
        //                {
        //                    em_08.Progressivo = progressivo;
        //                    _context.Add(em_08);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "09":
        //                Emisti_Rec_09 em_09 = CreateEmistiRow_09(line);
        //                if (em_09 != null)
        //                {
        //                    em_09.Progressivo = progressivo;
        //                    _context.Add(em_09);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //            case "10":
        //                Emisti_Rec_10 em_10 = CreateEmistiRow_10(line);
        //                if (em_10 != null)
        //                {
        //                    em_10.Progressivo = progressivo;
        //                    _context.Add(em_10);
        //                    _context.SaveChanges();
        //                }
        //                break;
        //        }
        //        line = sr.ReadLine();
        //    }
        //    sr.Close();
        //}

        public static Emisti_Rec_01 CreateEmistiRow_01(string line)
        {
            Emisti_Rec_01 em = new Emisti_Rec_01();

            // Tipo record
            int i = 2;
            // iscrizione
            em.Iscrizione = line.Substring(i, 8);
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.Dpt = line.Substring(i, 3);
            i += 3;
            em.CodiceFiscale = line.Substring(i, 16);
            i += 16;
            em.Cognome1 = line.Substring(i, 30);
            i += 30;
            em.Nome1 = line.Substring(i, 30);
            i += 30;
            // indirizzo-località-cap-prov
            i += 97;
            em.ModalPagamento = int.Parse(line.Substring(i, 1));
            i += 1;
            em.TipoServizio = int.Parse(line.Substring(i, 2));
            i += 2;
            em.Iban = line.Substring(i, 4);
            i += 4;
            em.Cin = line.Substring(i, 1);
            i += 1;
            em.Abi = line.Substring(i, 5);
            i += 5;
            em.Cab = line.Substring(i, 5);
            i += 5;
            em.ContoCorrente = line.Substring(i, 12);
            i += 12;
            //spazio iban
            i += 8;
            // ufficio-capitolo
            em.UfficioServizio = line.Substring(i, 4);
            i += 4;
            em.CapitoloSpesa = int.Parse(line.Substring(i, 4));
            i += 4;
            em.CapitoloBilancio = int.Parse(line.Substring(i, 4));
            i += 4;
            //            i += 12;
            em.Qualifica = line.Substring(i, 4);
            i += 4;
            em.Livello = int.Parse(line.Substring(i, 3));
            i += 3;
            em.Classe = int.Parse(line.Substring(i, 2));
            i += 2;
            em.Scatti = int.Parse(line.Substring(i, 2));
            i += 2;
            // aliquota(2+2)  DataProssimoAps (8) = 12
            i += 12;
            em.ImponibileRataAnnoCorrente = int.Parse(line.Substring(i, 10));
            i += 10;
            em.IRPEFRataAnnoCorrente = int.Parse(line.Substring(i, 10));
            i += 10;
            em.IRPEFArretratiAnnoCorrente = int.Parse(line.Substring(i, 10));
            i += 10;
            em.IRPEFArretratiAnnoPrecedente = int.Parse(line.Substring(i, 10));
            i += 10;
            em.IRPEFTotaleNetta = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoAnnuoLordo = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoMensileLordo = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoMensileNetto = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoNetto13ma = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoPrev13ma = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoIrpef13ma = int.Parse(line.Substring(i, 10));
            i += 10;
            // PercPtime (4) e NumeroFigli (2) e NumeroAltriFam (2) 
            i += 8;
            em.DetrazioniBase = int.Parse(line.Substring(i, 10));
            i += 10;
            em.DetrazioniConiuge = int.Parse(line.Substring(i, 10));
            i += 10;
            em.DetrazioniFigli = int.Parse(line.Substring(i, 10));
            i += 10;
            em.DetrazioniAltriFam = int.Parse(line.Substring(i, 10));
            i += 10;
            // FlagEffettoConiuge (1)
            i += 1;
            em.TotaleDetrazioni = int.Parse(line.Substring(i, 10));
            i += 10;
            // NumeroMinori3Anni (3)
            i += 3;
            em.CodiceRegimeContributivo = line.Substring(i, 3);
            i += 3;
            em.CodRegioneIrap = line.Substring(i, 2);
            i += 2;
            // aliquota
            i += 8;
            em.CodiceComuneAccon = line.Substring(i, 4);
            i += 4;
            em.CodiceComuneSaldo = line.Substring(i, 4);
            i += 4;
            // CodiceAccontoDich 4 CodiceAccontoCong 4 CodiceAc 4 CodiceAcCong 4
            // CodiceComuneRes 4 IrpefAccessorieAc 10 IrpefAccessorieAp 10 
            i += 40;
            em.RegimeContributivoCud = line.Substring(i, 3);
            i += 2;
            //if (line.Length == i + 10)
                em.CreditoIrpef = Int64.Parse(line.Substring(i, 10));

            foreach (var prop in typeof(Emisti_Rec_01).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
        }

        public static Emisti_Rec_02 CreateEmistiRow_02(string line) 
        {
            Emisti_Rec_02 em = new Emisti_Rec_02();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceAssegno = int.Parse(line.Substring(i, 3));
            i += 3;
            em.SottocodiceAssegno = line.Substring(i, 3);
            i += 3;
            em.ImportoLordoTabellare = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoLordoRata = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRiduzionePT = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRiduzioneTE = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitPrev = int.Parse(line.Substring(i, 10));
            i += 10;
            em.DataScadAssegno = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            if (line.Length == i + 1)
                em.FlagImponFiscale = line.Substring(i, 1);

            foreach (var prop in typeof(Emisti_Rec_02).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_03 CreateEmistiRow_03(string line)
        {
            Emisti_Rec_03 em = new Emisti_Rec_03();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceAssegno = int.Parse(line.Substring(i, 3));
            i += 3;
            em.CodRitPrevAss = line.Substring(i, 3);
            i += 3;
            em.AliquotaLavoratore = decimal.Parse(line.Substring(i, 5))/1000;
            i += 5;
            em.PercentualeApplicazione = decimal.Parse(line.Substring(i, 4))/10;
            i += 4;
            em.Imponibile = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitenuta = int.Parse(line.Substring(i, 10));
            i += 10;
            em.AliquotaDatore = decimal.Parse(line.Substring(i, 5))/1000;
            i += 5;
            if (line.Length == i + 10)
                em.ImportoDatore = int.Parse(line.Substring(i, 10));

            foreach (var prop in typeof(Emisti_Rec_03).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
        }

        public static Emisti_Rec_04 CreateEmistiRow_04(string line)
        {
            Emisti_Rec_04 em = new Emisti_Rec_04();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceRitenuta = line.Substring(i, 3);
            i += 3;
            em.TipoRitenuta = line.Substring(i, 1);
            i += 1;
            //flag riduzione Imponibile + progressivo Debito
            em.FlagRiduzImpon = line.Substring(i, 1);
            i += 1;
            em.ProgressivoDebito = int.Parse(line.Substring(i, 4));
            i += 4;
            em.ImportoRitenuta = int.Parse(line.Substring(i, 10));
            i += 10;
            //data scadenza
            i += 6;
            em.ImportoRitNetto = int.Parse(line.Substring(i, 10));
            i += 10;
            em.CodRitOnereMens = line.Substring(i, 3);
            i += 3;
            em.ImportoOnereMens = int.Parse(line.Substring(i, 10));
            i += 10;
            em.CodRit1Tantum = line.Substring(i, 3);
            i += 3;
            em.ImportoRit1Tantum = int.Parse(line.Substring(i, 10));
            i += 10;
            if (line.Length == i + 20)
                em.CodContratto = line.Substring(i, 20);

            foreach (var prop in typeof(Emisti_Rec_04).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
        }

        public static Emisti_Rec_05 CreateEmistiRow_05(string line) {

            Emisti_Rec_05 em = new Emisti_Rec_05();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceRitenutaCategoria = line.Substring(i, 3);
            i += 3;
            em.CodiceAssegno = int.Parse(line.Substring(i, 3));
            i += 3;
            em.ImportoRitenuta = int.Parse(line.Substring(i, 10));
            i += 10;
            em.DataScadRitCat = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.TipoRitCat = line.Substring(i, 1);
            i += 1;
            em.PercApplRitCat = decimal.Parse(line.Substring(i, 6))/1000;
            i += 6;
            if (line.Length == i + 6)
                em.PercRitCat = decimal.Parse(line.Substring(i, 6))/1000;

            foreach (var prop in typeof(Emisti_Rec_05).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_06 CreateEmistiRow_06(string line) {

            Emisti_Rec_06 em = new Emisti_Rec_06();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceAssegno = int.Parse(line.Substring(i, 3));
            i += 3;
            em.CodiceArretrato = line.Substring(i, 3);
            i += 3;
            em.DataLotto = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.NumLotto = int.Parse(line.Substring(i, 5));
            i += 5;
            em.AnnoRiferimento = int.Parse(line.Substring(i, 4));
            i += 4;
            em.ImportoLordoRata = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRiduzionePT = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRiduzioneTE = int.Parse(line.Substring(i, 10));
            i += 10;
            if (line.Length == i + 10)
                em.ImportoRitenute = int.Parse(line.Substring(i, 10));

            foreach (var prop in typeof(Emisti_Rec_06).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_07 CreateEmistiRow_07(string line) {

            Emisti_Rec_07 em = new Emisti_Rec_07();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.CodiceAssegno = int.Parse(line.Substring(i, 3));
            i += 3;
            em.CodiceArretrato = line.Substring(i, 3);
            i += 3;
            em.DataLotto = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.NumLotto = int.Parse(line.Substring(i, 5));
            i += 5;
            em.AnnoRiferimento = int.Parse(line.Substring(i, 4));
            i += 4;
            em.CodRitPrevAss = line.Substring(i, 3);
            i += 3;
            em.Imponibile = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitLavoratore = int.Parse(line.Substring(i, 10));
            i += 10;
            if (line.Length == i + 10)
                em.ImportoRitDatore = int.Parse(line.Substring(i, 10));

            foreach (var prop in typeof(Emisti_Rec_07).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_08 CreateEmistiRow_08(string line) {

            Emisti_Rec_08 em = new Emisti_Rec_08();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.IdElenco = Int64.Parse(line.Substring(i, 15));
            i += 15;
            em.CodEnte = int.Parse(line.Substring(i, 4));
            i += 4;
            em.CapBilStato = int.Parse(line.Substring(i, 4));
            i += 4;
            em.NumPG = int.Parse(line.Substring(i, 2));
            i += 2;
            em.TipoTass = line.Substring(i, 2);
            i += 2;
            em.AnnoRiferimento = int.Parse(line.Substring(i, 4));
            i += 4;
            em.Compenso = line.Substring(i, 4);
            i += 4;
            em.Sottocompenso = line.Substring(i, 4);
            i += 4;
            em.TipolCompenso = int.Parse(line.Substring(i, 3));
            i += 3;
            em.Importo = int.Parse(line.Substring(i, 10));
            i += 10;
            em.Inizio_comp = int.Parse(line.Substring(i, 8));
            i += 8;
            em.Fine_comp = int.Parse(line.Substring(i, 8));
            i += 8;
            em.Quantita = int.Parse(line.Substring(i, 5));
            i += 5;
            em.Imp_unitario = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitenute = int.Parse(line.Substring(i, 10));
            i += 10;
            em.UfficioResponsabileComunicante = line.Substring(i, 3);
            i += 3;
            if (line.Length == i + 4)
                em.UfficioServizioComunicante = line.Substring(i, 4);

            foreach (var prop in typeof(Emisti_Rec_08).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_09 CreateEmistiRow_09(string line) {

            Emisti_Rec_09 em = new Emisti_Rec_09();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.DataEmissione = new DateTime(int.Parse(line.Substring(i, 4)), int.Parse(line.Substring(i + 4, 2)), int.Parse(line.Substring(i + 6, 2)));
            i += 8;
            em.IdElenco = Int64.Parse(line.Substring(i, 15));
            i += 15;
            em.CapBilStato = int.Parse(line.Substring(i, 4));
            i += 4;
            em.NumPG = int.Parse(line.Substring(i, 2));
            i += 2;
            em.AnnoRiferimento = int.Parse(line.Substring(i, 4));
            i += 4;
            em.Compenso = line.Substring(i, 4);
            i += 4;
            em.Sottocompenso = line.Substring(i, 4);
            i += 4;
            em.TipolCompenso = int.Parse(line.Substring(i, 3));
            i += 3;
            em.CodRitPrevAss = line.Substring(i, 3);
            i += 3;
            em.Imponibile = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitLavoratore = int.Parse(line.Substring(i, 10));
            i += 10;
            if (line.Length == i + 10)
                em.ImportoRitDatore = int.Parse(line.Substring(i, 10));

            foreach (var prop in typeof(Emisti_Rec_09).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}

        public static Emisti_Rec_10 CreateEmistiRow_10(string line) {

            Emisti_Rec_10 em = new Emisti_Rec_10();

            // Tipo record
            int i = 2;
            // iscrizione
            i += 8;
            em.Rata = line.Substring(i, 4) + "/" + line.Substring(i + 4, 2);
            i += 6;
            em.Emissione = int.Parse(line.Substring(i, 2));
            i += 2;
            em.ImponibileRitenutaAcconto = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImponibileRitenutaAccontoIva = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoRitenutaAcconto = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImpContrIntegrCat = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImpContrIntegrInps = int.Parse(line.Substring(i, 10));
            i += 10;
            em.ImportoIva = int.Parse(line.Substring(i, 10));
            i += 10;
            em.PercContrIntegrCat = decimal.Parse(line.Substring(i, 4))/100;
            i += 4;
            if (line.Length == i + 4)
                em.PercContrIntegrInps = decimal.Parse(line.Substring(i, 4))/100;

            foreach (var prop in typeof(Emisti_Rec_10).GetProperties().Where(prop => prop.PropertyType == typeof(string))) {
                var value = prop.GetValue(em);
                if (value != null) {
                    prop.SetValue(em, value.ToString().Trim());
                }
            }

            return em;
		}
    }
}
