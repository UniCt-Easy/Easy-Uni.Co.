/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Data;
using funzioni_configurazione;//funzioni_configurazione
using metadatalibrary;
using System.Windows.Forms;

namespace itinerationFunctions//FunzioniMissione//
{
    public struct CfgItineration {
        public decimal italianexemption; //imp. esente italia
        public decimal foreignexemption;
        public decimal foreignhours;
        public object incomeclass;
        public object idposition;
        public object idwor;
        public object incomeclassvalidity;
        public object matricula;
        public object foreigngroupnumber;
        public decimal totaltaxrate;
        public string foreignclass;

    }
    /// <summary>
    /// Summary description for MissFun.
    /// </summary>
    public class MissFun {

        public MissFun() {
            //
            // TODO: Add constructor logic here
            //

        }


        public const string CampoDataPerGruppoEstero = "adate";
        public const string CampoDataPerGeneralita = "adate";
        public const string CampoDataPerRitenute = "adate";
        public const string CampoDataPerPosGiuridica = "start";
        public const string CampoDataPerDiaria = "start";

        /// <summary>
        /// NFraz.GG = (giorni + ore/24)
        /// </summary>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static double GetNFrazionarioGiorni(DataRow Tappa) {
            double ngg = CfgFn.GetNoNullDouble(Tappa["days"]);
            double nhh = CfgFn.GetNoNullDouble(Tappa["hours"]);
            return ngg + (nhh / 24.0);
        }
        /// <summary>
        /// Quota Esente Tappa EURO = (1-[perc.rid.quota esente])* [imp.esente] * [n. giorni fraz.]
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static decimal QuotaEsenteTappa(DataRow Missione, DataRow Tappa, CfgItineration Cfg) {
            double percquotaesentegg = CfgFn.GetNoNullDouble(Tappa["reductionpercentage"]);
            double ggfraz = GetNFrazionarioGiorni(Tappa);
            decimal QuotaEsente = 0;
            if (TappaIsItalia(Tappa)) {
                QuotaEsente = CfgFn.GetNoNullDecimal(Cfg.italianexemption);
            }
            else {
                QuotaEsente = CfgFn.GetNoNullDecimal(Cfg.foreignexemption);
            }
            if (percquotaesentegg > 1) percquotaesentegg = 1;
            decimal QuotaEsTappa = Convert.ToDecimal((1 - percquotaesentegg) * ggfraz) * QuotaEsente;
            QuotaEsTappa = CfgFn.RoundValuta(QuotaEsTappa);
            if (QuotaEsTappa > IndennitaTotale(Tappa)) {
                QuotaEsTappa = IndennitaTotale(Tappa);
            }
            return QuotaEsTappa;
        }

        public static decimal IF_QuotaEsente(DateTime Start, DateTime Stop, CfgItineration Cfg, decimal amount) {
            double ggfraz = IF_CalcolaFrazGiorni(Start, Stop);
            decimal QuotaEsente = CfgFn.GetNoNullDecimal(Cfg.foreignexemption);
            decimal QuotaEsTappa = Convert.ToDecimal(ggfraz) * QuotaEsente;
            if (QuotaEsTappa > amount) QuotaEsTappa = amount;
            return QuotaEsTappa;
        }

        /// <summary>
        /// Totale EURO quote esenti tappe
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappe"></param>
        /// <returns></returns>
        public static decimal TotQuoteEsentiTappe(DataRow Missione, DataTable Tappe, CfgItineration Cfg) {
            decimal SUM = 0;
            foreach (DataRow Tappa in Tappe.Select()) {
                SUM += QuotaEsenteTappa(Missione, Tappa, Cfg);
            }
            return SUM;
        }


        public static decimal IF_TotQuoteEsentiSpese(DataTable Spese, DataTable TipoSpesa, CfgItineration Cfg) {
            CQueryHelper QHC = new CQueryHelper();
            decimal SUM = 0;
            foreach (DataRow Spesa in Spese.Select()) {

                object iditinerationrefundkind = Spesa["iditinerationrefundkind"];
                if (iditinerationrefundkind == DBNull.Value) continue;
                DataRow[] r = TipoSpesa.Select(QHC.CmpEq("iditinerationrefundkind", iditinerationrefundkind));
                if (r.Length == 0) continue;
                if (CfgFn.GetNoNullInt32(r[0]["iditinerationrefundkindgroup"]) != 5) continue; //non è un rimborso forfettario

                if (Spesa["starttime"] == DBNull.Value || Spesa["stoptime"] == DBNull.Value) continue;
                SUM += IF_QuotaEsente((DateTime)Spesa["starttime"], (DateTime)Spesa["stoptime"], Cfg, CfgFn.GetNoNullDecimal(Spesa["amount"]));
            }
            return SUM;
        }

        /// <summary>
        /// Totale EURO quote imponibili
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappe"></param>
        /// <returns></returns>
        public static decimal TotQuoteImponibiliTappe(DataRow Missione, DataTable Tappe, CfgItineration Cfg) {
            decimal SUM = 0;
            foreach (DataRow Tappa in Tappe.Select()) {
                SUM += ImponibileTappa(Missione, Tappa, Cfg);
            }
            return SUM;
        }

        public static decimal IF_TotQuoteImponibiliSpese(DataTable Spese, DataTable TipoSpese, CfgItineration Cfg) {
            decimal SUM = 0;
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow Spesa in Spese.Select()) {
                SUM += IF_ImponibileSpesa(Spesa, TipoSpese, Cfg);
            }
            return SUM;

        }

        public static bool TappaIsEstero(DataRow Tappa) {
            return (Tappa["flagitalian"].ToString().ToUpper() != "S");
        }

        public static bool TappaIsItalia(DataRow Tappa) {
            return (Tappa["flagitalian"].ToString().ToUpper() == "S");
        }

        /// <summary>
        /// Indennità totale (EURO) non ridotta = [N. giorni frazionario] * [indennita corrisposta]
        /// </summary>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static double IndennitaTotaleNonRidotta(DataRow Tappa) {
            decimal indcorr = CfgFn.GetNoNullDecimal(Tappa["allowance"]);
            double ntot = GetNFrazionarioGiorni(Tappa);
            double tot = Convert.ToDouble(indcorr) * ntot;
            return tot;
        }

        /// <summary>
        /// Indennita Totale EURO = [Indennita Totale Non Ridotta] * (1-Perc.Rid.Diaria)
        ///  Ove Indennità totale non ridotta = [N. giorni frazionario] * [indennita corrisposta]
        /// </summary>
        /// <param name="Tappa">Tappa</param>
        /// <returns>Indennitò totale</returns>
        public static decimal IndennitaTotale(DataRow Tappa) {
            double riduzione = CfgFn.GetNoNullDouble(Tappa["reductionpercentage"]);
            double tot = IndennitaTotaleNonRidotta(Tappa) * (1 - riduzione);
            decimal indtot = CfgFn.RoundValuta(Convert.ToDecimal(tot));
            return indtot;
        }

        /// <summary>
        /// Base EURO per anticipo spesa
        /// </summary>
        /// <param name="Tappa"></param>
        /// <param name="Spesa"></param>
        /// <returns></returns>
        public static decimal GetBasePerAnticipoSpesa(DataRow Spesa) {
            return CfgFn.GetNoNullDecimal(Spesa["amount"]); //GIA' IN EURO
        }

        /// <summary>
        /// Anticipo spesa EURO
        /// </summary>
        /// <param name="Tappa"></param>
        /// <param name="Spesa"></param>
        /// <returns></returns>
        public static decimal GetAnticipoSpesa(DataRow Spesa) {
            string fieldperc;
            fieldperc = "advancepercentage";
            decimal perc = CfgFn.GetNoNullDecimal(Spesa[fieldperc]);
            decimal importo = MissFun.GetBasePerAnticipoSpesa(Spesa);
            decimal anticipo = CfgFn.RoundValuta(perc * importo);
            return anticipo;
        }



        /// <summary>
        /// Base Per Anticipo EURO = [IndennitaTotaleNonRidotta] eventualmente moltiplicato per [1-percridanticipo] 
        ///  ove il flag percridanticipoitalia/estero ="S"
        /// </summary>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static double GetBasePerAnticipo(DataRow Tappa) {
            double importo = IndennitaTotaleNonRidotta(Tappa);
            double percrid = CfgFn.GetNoNullDouble(Tappa["reductionpercentage"]);
            importo = importo * (1 - percrid);
            return importo;
        }

        /// <summary>
        /// Anticipo EURO = [perc.anticipo]* [Base per anticipo]
        /// </summary>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static decimal GetAnticipo(DataRow Tappa) {
            double percanticipo = CfgFn.GetNoNullDouble(Tappa["advancepercentage"]);
            double importo = GetBasePerAnticipo(Tappa);
            decimal anticipo = CfgFn.RoundValuta(Convert.ToDecimal(percanticipo * importo));
            return anticipo;
        }


        /// <summary>
        /// Totale anticipo EURO
        /// </summary>
        /// <param name="Tappe"></param>
        /// <returns></returns>
        public static decimal GetTotAnticipoTappe(DataTable Tappe) {
            decimal SUM = 0;
            foreach (DataRow Tappa in Tappe.Select()) {
                SUM += GetAnticipo(Tappa);
            }
            return SUM;
        }

        /// <summary>
        /// Tot. EURO base anticipo tappe
        /// </summary>
        /// <param name="Tappe"></param>
        /// <returns></returns>
        public static decimal GetTotBaseAnticipoTappe(DataTable Tappe) {
            decimal SUM = 0;
            foreach (DataRow Tappa in Tappe.Select()) {
                SUM += Convert.ToDecimal(GetBasePerAnticipo(Tappa));
            }
            return SUM;
        }

        /// <summary>
        /// Totale Euro anticipo spese
        /// </summary>
        /// <param name="Tappa"></param>
        /// <param name="Spese"></param>
        /// <returns></returns>
        public static decimal GetTotAnticipoSpese(DataTable Spese) {
            decimal SUM = 0;
            foreach (DataRow Spesa in Spese.Select()) {
                decimal baseanticipo = Convert.ToDecimal(GetBasePerAnticipoSpesa(Spesa));
                decimal perc = CfgFn.GetNoNullDecimal(Spesa["advancepercentage"]);
                SUM += baseanticipo * perc;
            }
            return SUM;
        }



        /// <summary>
        /// Totale Euro BASE anticipo spese
        /// </summary>
        /// <param name="Tappa"></param>
        /// <param name="Spese"></param>
        /// <returns></returns>
        public static decimal GetTotBaseAnticipoSpese(DataTable Spese) {
            decimal SUM = 0;
            foreach (DataRow Spesa in Spese.Select()) {
                SUM += Convert.ToDecimal(GetAnticipoSpesa(Spesa));
            }
            return SUM;
        }


        /// <summary>
        /// Totale Euro anticipo missione
        /// </summary>
        /// <param name="Tappe"></param>
        /// <param name="Spese"></param>
        /// <returns></returns>
        public static decimal GetTotAnticipoMissione(DataTable Tappe, DataTable Spese) {
            decimal SUM = GetTotAnticipoTappe(Tappe);
            SUM += GetTotAnticipoSpese(Spese);
            return SUM;
        }


        public static decimal IF_TotAliquotaSpese(DataTable ritenute, DataTable TAX) {
            CQueryHelper QHC = new CQueryHelper();
            if (ritenute == null) return 0;
            decimal TotAliAssDip = 0;  //A
            decimal TotAliPreDip = 0;  //P 
            decimal TotAliFisDip = 0;  //F
            foreach (DataRow Riten in ritenute.Select()) {
                object taxcode = Riten["taxcode"];
                DataRow Tax = TAX.Select(QHC.CmpEq("taxcode", taxcode))[0];
                if (Tax["flagunabatable"].ToString().ToLower() == "s") continue;
                string kind = Tax["taxkind"].ToString().ToLower();
                decimal valore = CfgFn.GetNoNullDecimal(Riten["employrate"]);
                decimal num = CfgFn.GetNoNullDecimal(Riten["employnumerator"]);
                decimal denom = CfgFn.GetNoNullDecimal(Riten["employdenominator"]);
                if (num != 0 && denom != 0) {
                    valore = valore * num / denom;
                }

                if (kind == "2") TotAliAssDip += valore;
                if (kind == "3") TotAliPreDip += valore;
                if (kind == "1") TotAliFisDip += valore;
            }
            decimal result = Decimal.Round((1 - TotAliAssDip - TotAliPreDip) * TotAliFisDip, 6) + TotAliAssDip + TotAliPreDip;

            return result;
        }




        /// <summary>
        /// Imponibile Tappa EURO = (Indennita Totale - QuotaEsente) * coeff. lordizzazione 
        ///  o 0 se negativo, ove
        ///  Indennita Totale = [Indennita corrisposta]*[1-perc.rid.diaria]*[n.giorni fraz.]
        ///  e 
        ///  Quota Esente = [1-perc.imp esente]*[quota esente]* [n.giorni  fraz]
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static decimal ImponibileTappa(DataRow Missione, DataRow Tappa, CfgItineration Cfg) {
            decimal QuotaEsente = QuotaEsenteTappa(Missione, Tappa, Cfg);
            decimal IndennitaTot = IndennitaTotale(Tappa);
            //IndennitaTot = DecToEuro(Tappa,IndennitaTot);
            double CoeffLord = CfgFn.GetNoNullDouble(Missione["grossfactor"]);
            if ((IndennitaTot - QuotaEsente) > 0) {
                return CfgFn.RoundValuta(
                        (IndennitaTot - QuotaEsente) 
                        * Convert.ToDecimal(CoeffLord)
                    );
            }
            else
                return 0;
        }

        /// <summary>
        /// Imponibile NETTO su cui va applicata l'aliquota 
        /// </summary>
        /// <param name="Spesa"></param>
        /// <param name="TipoSpesa"></param>
        /// <param name="Cfg"></param>
        /// <returns></returns>
        public static decimal IF_ImponibileSpesa(DataRow Spesa, DataTable TipoSpesa, CfgItineration Cfg) {
            object iditinerationrefundkind = Spesa["iditinerationrefundkind"];
            if (iditinerationrefundkind == DBNull.Value) return 0;
            CQueryHelper QHC = new CQueryHelper();
            DataRow[] r = TipoSpesa.Select(QHC.CmpEq("iditinerationrefundkind", iditinerationrefundkind));
            if (r.Length == 0) return 0;
            if (CfgFn.GetNoNullInt32(r[0]["iditinerationrefundkindgroup"]) != 5) return 0; //non è un rimborso forfettario
            decimal IndennitaTot = CfgFn.GetNoNullDecimal(Spesa["amount"]);
            decimal QuotaEsente = 0;
            if (Spesa["starttime"] != DBNull.Value && Spesa["stoptime"] != DBNull.Value) {
                QuotaEsente= IF_QuotaEsente((DateTime)Spesa["starttime"], (DateTime)Spesa["stoptime"], Cfg, IndennitaTot);
            }
            
            if ((IndennitaTot - QuotaEsente) > 0) {
                return CfgFn.RoundValuta(IndennitaTot - QuotaEsente);
            }
            else
                return 0;
        }

        public static decimal TotaleImponibileNonEsenteSpese(DataTable Spesa, DataTable TipoSpesa, CfgItineration Cfg) {
            decimal tot = 0;
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow R in Spesa.Select()) {
                object iditinerationrefundkind = R["iditinerationrefundkind"];
                if (iditinerationrefundkind == DBNull.Value) continue;
                DataRow[] r = TipoSpesa.Select(QHC.CmpEq("iditinerationrefundkind", iditinerationrefundkind));
                if (r.Length == 0) continue;
                if (CfgFn.GetNoNullInt32(r[0]["iditinerationrefundkindgroup"]) != 5) continue; //non è un rimborso forfettario

                decimal IndennitaTot = CfgFn.GetNoNullDecimal(R["amount"]);
                decimal QuotaEsente = IF_QuotaEsente((DateTime)R["starttime"], (DateTime)R["stoptime"], Cfg, IndennitaTot);
                if ((IndennitaTot - QuotaEsente) > 0) {
                    tot += CfgFn.RoundValuta(IndennitaTot - QuotaEsente);
                }

            }
            return tot;
        }

        /// <summary>
        /// Indennita Lorda tappa EURO
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static decimal IndennitaLordaTappa(DataRow Missione, DataRow Tappa, CfgItineration Cfg) {
            decimal QuotaEsente = QuotaEsenteTappa(Missione, Tappa, Cfg); //non moltiplicata per coeff.lord.
            decimal IndennitaTot = IndennitaTotale(Tappa); //non moltiplicata per coeff.lord.EURO
            //IndennitaTot = CfgFn.RoundValuta( DecToEuro(Tappa,IndennitaTot)); 
            //double CoeffLord = CfgFn.GetNoNullDouble(Missione["coefflord"]);
            decimal Imponibile = ImponibileTappa(Missione, Tappa, Cfg);
            if ((IndennitaTot - QuotaEsente) > 0) {
                return Imponibile + QuotaEsente;
            }
            else
                return IndennitaTot;
        }

        /// <summary>
        /// = Importo Effettivo * tasso cambio = Impoto effettivo in EURO
        /// </summary>
        /// <param name="MissioneSpesa"></param>
        /// <returns></returns>
        public static decimal SpesaSostenuta(DataRow MissioneSpesa) {
            decimal impeff = CfgFn.GetNoNullDecimal(MissioneSpesa["amount"]);//IN EURO
            return impeff; //DecToEuro(MissioneSpesa, impeff);
        }

        /// <summary>
        /// Importo Nominale * Tasso Cambio * Perc.Ind.Suppl.
        /// </summary>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static decimal IndennitaSupplementare(DataRow MissioneSpesa) {
            decimal impeff = CfgFn.GetNoNullDecimal(MissioneSpesa["extraallowance"]);//IN EURO
            return impeff;
        }

        /// <summary>
        /// Indennità chilometrica EURO
        /// </summary>
        /// <param name="Missione"></param>
        /// <returns></returns>
        public static decimal IndennitaChilometrica(DataRow Missione) {
            double KmProprio = CfgFn.GetNoNullDouble(Missione["owncarkm"]);
            double KmAmm = CfgFn.GetNoNullDouble(Missione["admincarkm"]);
            double KmPiedi = CfgFn.GetNoNullDouble(Missione["footkm"]);
            decimal ImpProprio = CfgFn.GetNoNullDecimal(Missione["owncarkmcost"]);
            decimal ImpAmm = CfgFn.GetNoNullDecimal(Missione["admincarkmcost"]);
            decimal ImpPiedi = CfgFn.GetNoNullDecimal(Missione["footkmcost"]);

            decimal TotAmm = Convert.ToDecimal(KmAmm) * ImpAmm;
            decimal TotProprio = Convert.ToDecimal(KmProprio) * ImpProprio;
            decimal TotPiedi = Convert.ToDecimal(KmPiedi) * ImpPiedi;
            return CfgFn.RoundValuta(TotAmm + TotProprio + TotPiedi);
        }
        /// <summary>
        /// Calcola il n. frazionario giorni ai fini dell'indennità forfettaria
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="Stop"></param>
        /// <returns></returns>
        public static double IF_CalcolaFrazGiorni(DateTime Start, DateTime Stop) {
            double ddatainizio = Start.ToOADate();
            double ddatafine = Stop.ToOADate();

            int nore = Convert.ToInt32(
                    Math.Floor((ddatafine - ddatainizio - Math.Floor(ddatafine - ddatainizio)) * 24.0));//+ 0.5));>>>Per i Rimb.forteffati non ci sono mezz'ore, quindi non serve aggiungere l0 0.5 per l'arrotondamenti
            int ngiorniinteri = Convert.ToInt32(Math.Floor(ddatafine - ddatainizio));

            //nore = nore - (ngiorniinteri * 24);
            //La missione deve durare almeno un giorno.
            if ((nore >= 12) && (ngiorniinteri > 0)) {
                return Convert.ToDouble(ngiorniinteri) + 0.5;
            }
            else {
                return Convert.ToDouble(ngiorniinteri);
            }

        }


        public static void RicalcolaOreGiorniTappa(DataRow Missione, DataRow Tappa, CfgItineration Cfg) {
            if (Tappa["starttime"] == DBNull.Value) return;
            if (Tappa["stoptime"] == DBNull.Value) return;

            int oreestero = CfgFn.GetNoNullInt32(Cfg.foreignhours);


            DateTime datainizio = (DateTime)Tappa["starttime"];
            DateTime datafine = (DateTime)Tappa["stoptime"];
            if (datainizio.Year < 1900 || datainizio.Year > 2100) {
                Tappa["days"] = Convert.ToDouble(9999);
                Tappa["hours"] = Convert.ToDouble(0);
                return;
            }
            if (datafine.Year < 1900 || datafine.Year > 2100) {
                Tappa["days"] = Convert.ToDouble(9999);
                Tappa["hours"] = Convert.ToDouble(0);
                return;
            }

            double ddatainizio = datainizio.ToOADate();
            double ddatafine = datafine.ToOADate();

            int ngiorni = 0;
            int ngiorniparziali = Convert.ToInt32(Math.Floor(ddatafine) - Math.Ceiling(ddatainizio));
            int ngiorniinteri = Convert.ToInt32(Math.Floor(ddatafine - ddatainizio));
            int nore = Convert.ToInt32(
                Math.Floor(
                (ddatafine - ddatainizio - Math.Floor(ddatafine - ddatainizio)) * 24.0 + 0.5
                ));

            if (Tappa["flagitalian"].ToString().ToLower() != "s") {
                double XX = (ddatainizio - Math.Floor(ddatainizio));
                //int norestart=24 - Convert.ToInt32(   XX*24.0);
                int norestart = (24 - Convert.ToInt32(XX * 24.0)) % 24;
                int norestop = Convert.ToInt32((ddatafine - Math.Floor(ddatafine)) * 24.0);
                if (Math.Floor(ddatafine) == Math.Floor(ddatainizio)) {
                    norestart = nore;
                    norestop = 0;
                    ngiorniparziali = 0;
                }
                if ((norestart >= oreestero) && (norestart > 0)) {
                    ngiorniparziali++;
                    norestart = 0;
                    nore = 0;
                }
                if ((norestop >= oreestero) && (norestop > 0)) {
                    ngiorniparziali++;
                    norestop = 0;
                    nore = 0;
                }
                ngiorni = ngiorniparziali;
                if ((norestart >= oreestero) || (norestop >= oreestero)) nore = 0;
            }
            else {
                ngiorni = ngiorniinteri;
            }

            Tappa["days"] = Convert.ToDouble(ngiorni);
            Tappa["hours"] = Convert.ToDouble(nore);

        }

        public static void RicalcolaSpese(DataAccess Conn,
            DataRow Missione,
            DataTable Spese, object idposition, object classnum
            ) {
            object iditinerationrefundrule = Conn.DO_READ_VALUE("itinerationrefundrule",
                "(start<=" + QueryCreator.quotedstrvalue(
                    Missione[MissFun.CampoDataPerGruppoEstero], true) + ")",
                       "max(iditinerationrefundrule)");
            string filter = "(iditinerationrefundrule=" + QueryCreator.quotedstrvalue(iditinerationrefundrule, true) +
                ")AND (idposition=" + QueryCreator.quotedstrvalue(idposition, true) +
                ")AND(" + QueryCreator.quotedstrvalue(classnum, true) + " BETWEEN minincomeclass and maxincomeclass)";
            DataTable TRefRule = Conn.RUN_SELECT("itinerationrefundruledetail", "*", null, filter, null, true);

            if (TRefRule.Rows.Count == 0) {
                MessageBox.Show("Configurazione anticipo spese non trovata");
                return;
            }

            foreach (DataRow Spesa in Spese.Select()) {
                string flag_geo = Spesa["flag_geo"].ToString().ToUpper();
                string filtergeo = "(flag_italy='S')";
                if (flag_geo.ToString() == "U") filtergeo = "(flag_eu='S')";
                if (flag_geo.ToString() == "E") filtergeo = "(flag_extraeu='S')";
                DataRow[] RefRule = TRefRule.Select(filtergeo);
                if (RefRule.Length > 0)
                    Spesa["advancepercentage"] = CfgFn.GetNoNullDouble(RefRule[0]["advancepercentage"]);
                else
                    MessageBox.Show("Configurazione anticipo spese non trovata (Spesa " +
                        Spesa["description"].ToString() + ")");
            }
        }

        /// <summary>
        /// Filtro da usarsi per diarie
        /// </summary>
        /// <param name="Missione"></param>
        /// <param name="Tappa"></param>
        /// <returns></returns>
        public static string GetQualificaClasseFilter(object idposition, object incomeclass) {
            string codicequalifica = idposition.ToString();
            object classe = incomeclass;

            return "(idposition=" + QueryCreator.quotedstrvalue(codicequalifica, true) + ")" +
                " AND (" + QueryCreator.quotedstrvalue(classe, true) + " between minincomeclass and maxincomeclass)";
        }

        /// <summary>
        /// Manda una mail di conseguenza all'ultimo cambiamento di  stato della missione, in particolare,
        /// un messaggio al percipiente su cosa è successo, su quale sia il nuovo stato della missione e su cosa dovrà succedere ora
        /// un messaggio all'eventuale prossimo ente autorizzatore che deve mettere mani sulla missione
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="Itineration"></param>
        /// 

        public static void SendMails(DataAccess Conn, DataRow Itineration) {
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            if (status == 0) return;

            DataRow AuthAgency = GetNextAuthAgency(Conn, Itineration);
            string emailagency = "";
            if (AuthAgency != null) {
                if (AuthAgency["ismanager"].ToString().ToUpper() == "S") {
                    emailagency = GetEmaiAddressForManager(Conn, Itineration["idman"]);
                }
                string auth_mail = AuthAgency["email"].ToString();

                if (auth_mail == "") {
                    if (Conn.GetSys("defaultdepmail") != null && Conn.GetSys("defaultdepmail").ToString() != "") {
                        auth_mail = Conn.GetSys("defaultdepmail").ToString();
                    }
                }

                if (auth_mail != "") {
                    if (emailagency != "") emailagency += ",";
                    emailagency += auth_mail;
                }
            }
            if ((emailagency != "") && (status == 5 || status == 8)) SendMailAuthAgency(Conn, Itineration, emailagency, false);

            string emailregistry = GetEmaiAddressForRegistry(Conn, Itineration["idreg"]);
            if (status >= 2) {  //era: emailregistry != "" &&
                DataRow PrevAuthAgency = GetPrevAuthAgency(Conn, Itineration);
                SendMailPercipiente(Conn, Itineration, emailregistry, AuthAgency, PrevAuthAgency, false);
            }
        }

        public static string WebSendMails(DataAccess Conn, DataRow Itineration) {
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            if (status == 0) return "";
            string errormsg = "";
            DataRow AuthAgency = GetNextAuthAgency(Conn, Itineration);
            string emailagency = "";

            if (AuthAgency != null) {
                if (AuthAgency["ismanager"].ToString().ToUpper() == "S") {
                    emailagency = GetEmaiAddressForManager(Conn, Itineration["idman"]);
                }
                if (AuthAgency["email"].ToString() != "") {
                    if (emailagency != "") emailagency += ",";
                    emailagency += AuthAgency["email"].ToString();
                }
            }
            if ((emailagency != "") && (status == 5 || status == 8)) errormsg = SendMailAuthAgency(Conn, Itineration, emailagency, true);

            string emailregistry = GetEmaiAddressForRegistry(Conn, Itineration["idreg"]);
            if (status >= 2)  //era: emailregistry != "" &&
            {
                DataRow PrevAuthAgency = GetPrevAuthAgency(Conn, Itineration);
                errormsg = errormsg + " " + SendMailPercipiente(Conn, Itineration, emailregistry, AuthAgency, PrevAuthAgency, true);
            }

            return errormsg.Trim();
        }

        static string GetNomeCognome(DataAccess Conn, object idreg) {
            return Conn.DO_READ_VALUE("registry", Conn.GetQueryHelper().CmpEq("idreg", idreg), "title").ToString();
        }
        static string GetNomeMissione(DataAccess Conn, DataRow Itineration) {
            return " missione n. " + Itineration["nitineration"].ToString() + "/" + Itineration["yitineration"].ToString() +
                " dal "+FromDateToString(Itineration["start"])+" al "+ FromDateToString(Itineration["stop"])+
                " avente descrizione \r\n" +
                Itineration["description"].ToString() + "\r\n" +
                "di " + GetNomeCognome(Conn, Itineration["idreg"]);
        }
        static string GetNomeBreveMissione(DataAccess Conn, DataRow Itineration) {
            return " missione n. " + Itineration["nitineration"].ToString() + "/" + Itineration["yitineration"].ToString() +
                " dal " + FromDateToString(Itineration["start"]) + " al " + FromDateToString(Itineration["stop"]) +
                " di " + GetNomeCognome(Conn, Itineration["idreg"]);            
        }
        static string GetNomeBreveMissionePercipiente(DataAccess Conn, DataRow Itineration) {
            return " missione n. " + Itineration["nitineration"].ToString() + "/" + Itineration["yitineration"].ToString() +
                " dal " + FromDateToString(Itineration["start"]) + " al " + FromDateToString(Itineration["stop"]);
        }


        public static string SendMailPercipiente(DataAccess Conn, DataRow Itineration, string emailaddress,
            DataRow NextAuthAgency, DataRow PrevAuthAgency, bool web_message) {
            string AVVISO_ERR = "";
            if (emailaddress == "") {
                emailaddress = GetErrorMailAddress(Conn);
                if (emailaddress == "") return "EMAIL NON INVIATA (" + GetNomeMissione(Conn, Itineration) + ") ";
                AVVISO_ERR = "EMAIL NON INVIATA: ";
            }
            object idreg = Itineration["idreg"];
            string errormsg = "";
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            if (status == 0) return "";
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Status = Conn.RUN_SELECT("itinerationstatus", "*", null, QHS.CmpEq("iditinerationstatus", status), null, true);
            string descr_status = Status.Rows[0]["description"].ToString(); //stato della missione
            //2 richiesta 3 Da correggere  4 Inserita  5,8 In fase di autorizzazione 6Approvata 7Annullata
            DateTime DataInizio = (DateTime)Itineration["start"];
            DateTime DataFine = (DateTime)Itineration["stop"];
            string svolta = (DataInizio.CompareTo(DateTime.Now)) < 0 ? " svoltasi " : " che si svolgerà ";
            svolta += "tra il " + DataInizio.ToShortDateString() + " ed il " + DataFine.ToShortDateString();

            string msg = "La " + GetNomeMissione(Conn, Itineration); //+ svolta; non serve aggiungere 'svolta' perchè le info sono già presenti in GetNomeMissione()
            if (NextAuthAgency != null) {
                if ((status == 5 || status == 8) && PrevAuthAgency != null) {
                    msg += " è stata approvata da: " + PrevAuthAgency["title"].ToString() + "\r\n";
                    if (status == 5)
                        msg += "ed è ora in attesa di autorizzazione (missione) da parte di : " + NextAuthAgency["title"].ToString();
                    else
                        msg += "ed è ora in attesa di autorizzazione (rendiconto) da parte di : " + NextAuthAgency["title"].ToString();
                }
                else {
                    msg += " è passata nello stato di \"" + descr_status + "\"\r\n";
                    msg += "ed è in attesa di autorizzazione da parte di : " + NextAuthAgency["title"].ToString();
                }
            }
            else {
                if (status == 7 && PrevAuthAgency != null) {
                    msg += " è  passata nello stato di \"" + descr_status + "\" ad opera di: " + PrevAuthAgency["title"].ToString();
                }
                else {
                    msg += " è passata nello stato di \"" + descr_status + "\"\r\n";
                }

            }
            if (Itineration["webwarn"].ToString() != "" && (status == 3 || status == 7)) {
                msg += "Avviso ricevuto:\r\n";
                msg += Itineration["webwarn"].ToString() + "\r\n";
            }
            msg = "Da: " + GetDipartimento(Conn) + "\r\n" + msg;
            object public_address = Conn.DO_READ_VALUE("web_config",null,"public_address");

            if (public_address != null && public_address != DBNull.Value) {
                msg += "\r\nPer ulteriori dettagli visitare la pagina: " + public_address.ToString() + "\r\n"; ;
            }

            QueryHelper q = Conn.GetQueryHelper();
            string StatusDescription = Conn.DO_READ_VALUE("itinerationstatus",  q.CmpEq("iditinerationstatus", status), "description").ToString();

            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.To = emailaddress;
            SM.Subject = AVVISO_ERR + "Nuovo stato :"+ StatusDescription + " per " + GetNomeBreveMissionePercipiente(Conn, Itineration); 
            SM.MessageBody = msg;
            SM.Conn = Conn;

            if ((!SM.Send()) && (SM.ErrorMessage.Trim() != "")) {
                if (!web_message)
                    QueryCreator.ShowError(null, SM.ErrorMessage, null);
                else errormsg = SM.ErrorMessage.Trim();
            }
            return errormsg;

        }

        public static string GetErrorMailAddress(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object email = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "email");
            if (email == null) email = DBNull.Value;
            return email.ToString();
        }


        public static string GetDipartimento(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object X = Conn.DO_READ_VALUE("generalreportparameter",
                                QHS.CmpEq("idparam", "DenominazioneDipartimento"), "paramvalue");
            return X.ToString();
        }
        static string FromDateToString(object o) {
            if (o == DBNull.Value) return " (non specificato) ";
            DateTime d = (DateTime)o;
            return d.ToShortDateString();
        }
        public static string SendMailAuthAgency(DataAccess Conn, DataRow Itineration, string emailaddress, bool web_message) {
            DateTime DataInizio = (DateTime)Itineration["start"];
            DateTime DataFine = (DateTime)Itineration["stop"];

            string errormsg = "";
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            if (status == 0) return "";
            if (status != 5 && status != 8) return "";

            QueryHelper q = Conn.GetQueryHelper();
            string StatusDescription = Conn.DO_READ_VALUE("itinerationstatus",  q.CmpEq("iditinerationstatus", status), "description").ToString();

            string svolta = (DataInizio.CompareTo(DateTime.Now)) < 0 ? " svoltasi " : " che si svolgerà ";
            svolta += "tra il " + DataInizio.ToShortDateString() + " ed il " + DataFine.ToShortDateString();
            string msg = "La " + GetNomeMissione(Conn, Itineration) + //svolta +  //non serve aggiungere 'svolta' perchè le info sono già presenti in GetNomeMissione()
                  " necessita di autorizzazione.";
            //msg += "Descrizione della missione:\r\n"; // In GetNomeMissione() è già presente questa info.
            //msg += Itineration["description"].ToString() + "\r\n";

            DataTable Tappe = Conn.RUN_SELECT("itinerationlapview", "*", "lapnumber", q.CmpEq("iditineration", Itineration["iditineration"]), null, false);
            if (Tappe.Rows.Count > 0) {
                msg += "Tappe:\r\n";
                foreach(DataRow r in Tappe.Rows) {
                    msg += FromDateToString(r["starttime"]) + " - " + FromDateToString(r["starttime"]) + " : " + r["description"].ToString() + "\r\n";
                }
            }
            if (Itineration["totalgross"]==DBNull.Value) {
                msg += "Importo lordo: " + CfgFn.GetNoNullDecimal(Itineration["totalgross"]).ToString("c");
            }
            if (Itineration["totadvance"] == DBNull.Value) {
                msg += "Totale anticipo: " + CfgFn.GetNoNullDecimal(Itineration["totadvance"]).ToString("c");
            }
            if (Itineration["total"] == DBNull.Value) {
                msg += "Costo totale: " + CfgFn.GetNoNullDecimal(Itineration["total"]).ToString("c");
            }

            msg += "\r\n";
            msg = "Da: " + GetDipartimento(Conn) + "\r\n" + msg;
            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.To = emailaddress;
            SM.Subject = StatusDescription + " " + GetNomeBreveMissione(Conn,Itineration);

            object public_address = Conn.DO_READ_VALUE("web_config", null, "public_address");

            if (public_address != null && public_address != DBNull.Value) {
                msg += "\r\nPer ulteriori dettagli visitare la pagina: " + public_address.ToString() + "\r\n"; ;
            }

            SM.MessageBody = msg;
            SM.Conn = Conn;

            if ((!SM.Send()) && (SM.ErrorMessage.Trim() != "")) {
                if (!web_message)
                    QueryCreator.ShowError(null, SM.ErrorMessage, null);
                else errormsg = SM.ErrorMessage.Trim();
            }
            return errormsg;
        }

        public static DataRow GetNextAuthAgency(DataAccess Conn, DataRow Itineration) {
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            if (status == 0) return null;
            if (status != 5 && status != 8) return null;


            QueryHelper QHS = Conn.GetQueryHelper();
            string sql = "";
            sql = "select itinerationauthagency.*,authagency.priority,authagency.title,authagency.ismanager,authagency.email from itinerationauthagency " +
                " join authagency  " +
                " on (itinerationauthagency.idauthagency=authagency.idauthagency) " +
                " where " + QHS.AppAnd(
                        QHS.CmpEq("itinerationauthagency.iditineration", Itineration["iditineration"]),
                        QHS.CmpEq("flagstatus", "D")
                        )
                        +
                " order by authagency.priority";
            //subfilter += " and (flagstatus='N' or flagstatus='D') ";
            //subfilter += " and authagency.priority<='" + authagencypriority.ToString() +"' ";


            DataTable ItiAgency = Conn.SQLRunner(sql, false);
            if (ItiAgency.Rows.Count == 0) return null;
            return ItiAgency.Rows[0];
        }
        public static DataRow GetPrevAuthAgency(DataAccess Conn, DataRow Itineration) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string sql = "";
            sql = "select itinerationauthagency.*,authagency.priority,authagency.title,authagency.ismanager,authagency.email from itinerationauthagency " +
                " join authagency  " +
                " on (itinerationauthagency.idauthagency=authagency.idauthagency) " +
                " where " + QHS.AppAnd(
                        QHS.CmpEq("itinerationauthagency.iditineration", Itineration["iditineration"]),
                        QHS.CmpNe("flagstatus", "D")
                        )
                        +
                " order by authagency.priority desc";
            //subfilter += " and (flagstatus='N' or flagstatus='D') ";
            //subfilter += " and authagency.priority<='" + authagencypriority.ToString() +"' ";

            DataTable ItiAgency = Conn.SQLRunner(sql, false);
            if (ItiAgency.Rows.Count == 0) return null;
            int status = CfgFn.GetNoNullInt32(Itineration["iditinerationstatus"]);
            DataRow RAgency = ItiAgency.Rows[0];

            if ((RAgency["flagstatus"].ToString().ToUpper() == "S") && (status == 5 || status == 8 || status == 6)) return RAgency;
            if ((RAgency["flagstatus"].ToString().ToUpper() == "N") && (status == 7)) return RAgency;
            return null;
        }

        public static string GetEmaiAddressForManager(DataAccess Conn, object idmanager) {
            object email = Conn.DO_READ_VALUE("manager", Conn.GetQueryHelper().CmpEq("idman", idmanager), "email");
            if (email == null) return "";
            return email.ToString();
        }

        public static string GetEmaiAddressForRegistry(DataAccess Conn, object idreg) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object email = Conn.DO_READ_VALUE("registryreference",
                    QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("flagdefault", "S")), "email");
            if (email == null) return "";
            return email.ToString();

        }
    }
}
