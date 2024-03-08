
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
using System.Text;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using ep_functions;
using System.Collections;
using System.Windows.Forms;

namespace progettocosto_functions {
	public class progettocosto_function {
		IDataAccess Conn;
		CQueryHelper QHC;
		QueryHelper QHS;
		//int esercizio;
		public progettocosto_function(IDataAccess conn) {
			this.Conn = conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			//esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
		}

        public void InitMetaData(vistaForm ds, object idprogetto) {
            // Imposta i default
            // Imposta autoincremento e selettori
            MetaData.SetDefault(ds.progettocosto, "idprogetto", idprogetto);
            RowChange.MarkAsAutoincrement(ds.progettocosto.Columns["idprogettocosto"], null, null, 0);

            ClearDataSet.RemoveConstraints(ds);

        }
        //Valorizzo l'importo della tabella assetdiary in base all'utilizzo del cespite
        public DataSet CalcolaDiarioUso(object idprogetto, int mese, int esercizio, out string errore) {
            errore = string.Empty;
            try {
                vistaForm ds = new vistaForm();
                string erroreElaborazione = string.Empty;
                if (!ElaboraDiarioUso(ds, idprogetto, mese, esercizio, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                return ds;
            }
            catch (Exception ex) {
                errore = ex.ToString();
                return null ;
            }

        }


       public bool ElaboraDiarioUso(vistaForm ds, object idprogetto, int idmese, int esercizio, out string errore) {
            errore = string.Empty;

            //Costruisce il filtro di questi asset per poi fare la RUN_SELECT_INTO solo delle righe interessate
            //cioè tutti i mesi e anni precedenti
            string filterAssetDiary =
                QHC.AppOr(
                    QHC.AppAnd(
                        QHC.CmpLe("month(start)", idmese), 
                        QHC.CmpEq("year(start)", esercizio)
                    ),
                    QHC.CmpLt("year(start)", esercizio)
                );
            Conn.RUN_SELECT_INTO_TABLE(ds.assetdiaryora, null, filterAssetDiary, null, true);

            //se trovo che il mese precedente è stato già valorizzato mi fermo
            int n_amountvalorizzato = ds.assetdiaryora.Select(QHC.AppAnd(QHC.CmpLe("start", new DateTime(esercizio, idmese,28)), QHC.CmpGe("start", new DateTime(esercizio, idmese, 1)), QHC.IsNotNull("amount"))).Length;
            if (n_amountvalorizzato > 1) {
                errore = "Esistono righe con importo già valorizzato in AssetDiaryOra per il mese richiesto( "+idmese.ToString()+" )";
                return false;
            }

            //Chiama la sp che calcola l'importo e lo scrive nella tabella assetdiaryora
            DataSet DSassetdiaryora = Conn.CallSP("compute_assetdiaryora", new object[] { esercizio, idmese, idprogetto }, true, 300);
            if ((DSassetdiaryora != null) && (DSassetdiaryora.Tables.Count > 0)) {
                DataTable Tassetdiaryora_importo = DSassetdiaryora.Tables[0];
                foreach (DataRow R in Tassetdiaryora_importo.Rows) {
                    //Per ogni riga di assetdiaryora valorizza l'importo
                    string filter = QHC.AppAnd(QHC.CmpEq("idassetdiary", R["idassetdiary"]), QHC.CmpEq("idassetdiaryora", R["idassetdiaryora"]));
                    DataRow[] RR = ds.assetdiaryora.Select(filter);
                    if (RR != null && RR.Length >= 1) {
                        RR[0]["amount"] = R["amount"];
                    }
                }
            }
            else {
                errore = "Non vi sono Diario Uso da elaborare"; //Non è un errore...
            }
            return true;
        }

        public DataSet popolaprogettoCosto(object idprogetto, out string errore) {
            errore = string.Empty;
            try {
                vistaForm ds = new vistaForm();
                InitMetaData(ds, idprogetto);

                string erroreElaborazione;
                if (!ElaboraFattureAcquisto(ds, idprogetto,out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraContrattiPassivi(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraCompensiOccasionali(ds, idprogetto,   out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }

                if (!ElaboraCedolini(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }

                if (!ElaboraCompensiDipendenti(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraMissioni(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraContributi(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraRendicontattivitaprogetto(ds, idprogetto, out erroreElaborazione))
                {
                    errore = erroreElaborazione;
                    return null;
                }
                if (!ElaboraAmmortamentiDiariESal(ds, idprogetto, out erroreElaborazione))
                {
                    errore = erroreElaborazione;
                    return null;
                }
                return ds;
            }
            catch (Exception ex) {
                errore = ex.ToString();
                return null;
            }
       }

        public bool ElaboraRendicontattivitaprogetto(vistaForm ds, object idprogetto, out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string query = @"select ( ore * 
	            CASE 
				WHEN isnull(costoorario, 0) <> 0 THEN costoorario
				WHEN isnull(costostandard, 0) <> 0 THEN costostandard
				WHEN isnull(totale_costoorario, 0) <> 0 THEN totale_costoorario
				WHEN isnull(costoorario_stipendio, 0) <> 0 THEN costoorario_stipendio
				WHEN isnull(costoorario_stipendiotabellare, 0) <> 0 THEN costoorario_stipendiotabellare
	            WHEN isnull(costoorario_inquadramento, 0) <> 0 THEN costoorario_inquadramento
	            WHEN isnull(costoorario_contrattokind, 0) <> 0 THEN costoorario_contrattokind
	            ELSE 0
	            END
	            ) as amount, 
				
	            --CASE 
				--WHEN isnull(costoorario, 0) <> 0 THEN 'Costo del membro nel progetto'
				--WHEN isnull(costostandard, 0) <> 0 THEN 'Costo standard'
				--WHEN isnull(totale_costoorario, 0) <> 0 THEN 'Costo orario importato'
				--WHEN isnull(costoorario_stipendio, 0) <> 0 THEN 'Costo stipendio importato'
				--WHEN isnull(costoorario_stipendiotabellare, 0) <> 0 THEN 'Costo stipendio tabellare'
	            --WHEN isnull(costoorario_inquadramento, 0) <> 0 THEN 'Costo inquadramento'
	            --WHEN isnull(costoorario_contrattokind, 0) <> 0 THEN 'Costo figura contrattuale'
	            --ELSE 'Indefinito'
	            --END
	            --as tipo, 
				
				V.* 
            from rendicontattivitaprogettoworkpackageview V 
            where (idprogettotipocosto IS NOT NULL AND idprogettocosto IS NULL AND isnull(oredivisionecostostipendio,0) > 0) AND idprogetto =" + (string)idprogetto;

            DataTable t = Conn.SQLRunner(query);
            if ((t != null) && (t.Rows.Count > 0)) {
       
                foreach (DataRow R in t.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostocontrattokind
                    //Valorizzati a null per il Rendiconto Attività
                    rProgettoCosto["idexp"] =  DBNull.Value;
                    rProgettoCosto["idpettycash"] = DBNull.Value;
                    rProgettoCosto["yoperation"] =  DBNull.Value;
                    rProgettoCosto["noperation"] =  DBNull.Value;
                    rProgettoCosto["amount"] = R["amount"];
                    rProgettoCosto["idcontrattokind"] = R["idcontrattokind"];
                    rProgettoCosto["idrendicontattivitaprogetto"] = R["idrendicontattivitaprogetto"];
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = DBNull.Value;
                    rProgettoCosto["docdate"] = R["data"];
                    rProgettoCosto["idrelated"] = DBNull.Value;
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Rendiconto attivita progetto da elaborare"; //Non è un errore...
            }

            return true;
        }

        public bool ElaboraAmmortamentiDiariESal(vistaForm ds, object idprogetto, out string errore)
        {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string query = @"select * from ammortamentoworkpackageview V 
            where idprogettocosto is null and idprogetto =" + (string)idprogetto ;

            DataTable t = Conn.SQLRunner(query);
            if ((t != null) && (t.Rows.Count > 0))
            {

                foreach (DataRow R in t.Rows)
                {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostocontrattokind
                    //Valorizzati a null per il Rendiconto Attività
                    rProgettoCosto["idexp"] = DBNull.Value;
                    rProgettoCosto["idpettycash"] = DBNull.Value;
                    rProgettoCosto["yoperation"] = DBNull.Value;
                    rProgettoCosto["noperation"] = DBNull.Value;
                    rProgettoCosto["amount"] = R["amount"];
                    rProgettoCosto["idcontrattokind"] = DBNull.Value;
                    rProgettoCosto["idrendicontattivitaprogetto"] = DBNull.Value;
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = DBNull.Value;
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = DBNull.Value;
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["idassetdiaryora"] = R["idassetdiaryora"];
                    rProgettoCosto["idsalprogettoassetworkpackagemese"] = R["idsalprogettoassetworkpackagemese"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else
            {
                errore = "Non vi sono ammortamenti da elaborare"; //Non è un errore...
            }

            return true;
        }


        public bool ElaboraCedolini(vistaForm ds, object idprogetto, out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string filterCedolino = filterForCedolini(idprogetto);

            DataTable PayrollWorkview = Conn.RUN_SELECT("payrollworkpackageview", "*", null, filterCedolino, null, null, true);
            if ((PayrollWorkview != null) && (PayrollWorkview.Rows.Count > 0)) {
                foreach (DataRow R in PayrollWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = R["idexppayed"] ?? DBNull.Value;
                    rProgettoCosto["idpettycash"] = DBNull.Value;
                    rProgettoCosto["yoperation"] = DBNull.Value;
                    rProgettoCosto["noperation"] = DBNull.Value;
                    rProgettoCosto["amount"] = R["exppayedamount"];
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = R["doc"];
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Cedolino da elaborare"; //Non è un errore...
            }

            return true;
        }
        public bool ElaboraCompensiOccasionali(vistaForm ds, object idprogetto, out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string filterOcc = filterForOccassionali(idprogetto);
            
            DataTable CasualContractWorkview = Conn.RUN_SELECT("casualcontractworkpackageview", "*", null, filterOcc, null, null, true);
            if ((CasualContractWorkview != null) && (CasualContractWorkview.Rows.Count > 0)) {
                foreach (DataRow R in CasualContractWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = R["idexppayed"] ?? DBNull.Value;
                    rProgettoCosto["idpettycash"] = R["idpettycash"] ?? DBNull.Value;
                    rProgettoCosto["yoperation"] = R["yoperation"] ?? DBNull.Value;
                    rProgettoCosto["noperation"] = R["noperation"] ?? DBNull.Value;
                    rProgettoCosto["amount"] = PagatoOccasionale(R);
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = R["doc"];
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    errore = errore + " " + idprogettocosto.ToString();
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Compensi Occasionali da elaborare"; //Non è un errore...
            }

            return true;
        }

        public bool ElaboraMissioni(vistaForm ds, object idprogetto,   out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string filterOcc = filterForMissioni(idprogetto);

            DataTable ItinerationWorkview = Conn.RUN_SELECT("itinerationworkpackageview", "*", null, filterOcc, null, null, true);
            if ((ItinerationWorkview != null) && (ItinerationWorkview.Rows.Count > 0)) {
                foreach (DataRow R in ItinerationWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = R["idexppayed"] ?? DBNull.Value;
                    rProgettoCosto["idpettycash"] = R["idpettycash"] ?? DBNull.Value;
                    rProgettoCosto["yoperation"] = R["yoperation"] ?? DBNull.Value;
                    rProgettoCosto["noperation"] = R["noperation"] ?? DBNull.Value;
                    rProgettoCosto["amount"] = PagatoMissione(R);
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = R["doc"];
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Missioni da elaborare"; //Non è un errore...
            }

            return true;
        }

        public object idexpPagamentoDettContrattoPass(DataRow RestimDetWorkview) {
            object idexp = DBNull.Value;
            if (RestimDetWorkview["idexppayed"] != DBNull.Value) {
                idexp = RestimDetWorkview["idexppayed"];
            }
            return idexp;
        }
        public bool ElaboraContrattiPassivi(vistaForm ds, object idprogetto, out string errore) {
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio
            errore = string.Empty;
            string filterInv = filterForMandatedetail(idprogetto);

            DataTable InvDetWorkview = Conn.RUN_SELECT("mandatedetailexpworkpackageview", "*", null, filterInv, null, null, true);
            if ((InvDetWorkview != null) && (InvDetWorkview.Rows.Count > 0)) {
                foreach (DataRow R in InvDetWorkview.Rows) {
                    DataRow rProgettocosto = ds.progettocosto.NewRow();
                    //Per ogni fattura deve valorizzare i campi di PROGETTOcosto
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettocosto["idprogettocosto"] = idprogettocosto;
                    rProgettocosto["idprogetto"] = R["idprogetto"];
                    rProgettocosto["idprogettotipocosto"] = R["idprogettotipocosto"];//Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettocosto["idexp"] = idexpPagamentoDettContrattoPass(R);
                    rProgettocosto["amount"] = R["payedamount"];
                    rProgettocosto["idsal"] = DBNull.Value;
                    rProgettocosto["doc"] = R["doc"];
                    rProgettocosto["docdate"] = R["docdate"];
                    rProgettocosto["idrelated"] = R["idrelated"];
                    rProgettocosto["idworkpackage"] = R["idworkpackage"];
                    rProgettocosto["cu"] = "progettocosto_functions";
                    rProgettocosto["ct"] = DateTime.Now;
                    rProgettocosto["lt"] = DateTime.Now;
                    rProgettocosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettocosto);
                }
            }
            else {
                errore = "Non vi sono Contratti Attivi da elaborare"; //Non è un errore...
            }
            return true;
        }
        public bool ElaboraFattureAcquisto(vistaForm ds, object idprogetto,  out string errore) {
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio


            errore = string.Empty;
            string filterInv = filterForInvoicedetail(idprogetto);
            //invoicedetailworkpackageview
            DataTable InvDetWorkview = Conn.RUN_SELECT("invoicedetailexpworkpackageview", "*", null, filterInv, null, null, true);
            if ((InvDetWorkview != null) && (InvDetWorkview.Rows.Count > 0)) {
                foreach (DataRow R in InvDetWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni fattura deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];//Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = idexpPagamentoDettFatt(R);
                    rProgettoCosto["idpettycash"] = R["idpettycash"] ?? DBNull.Value; 
                    rProgettoCosto["yoperation"] = R["yoperation"] ?? DBNull.Value;
                    rProgettoCosto["noperation"] = R["noperation"] ?? DBNull.Value;
                    rProgettoCosto["amount"] = R["payedamount"];
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = R["doc"];
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"]; 
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Fatture di Acquisto da elaborare"; //Non è un errore...
            }
            return true;
        }
        public bool ElaboraContributi(vistaForm ds, object idprogetto,  out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string filterOcc = filterForContributi(idprogetto);
            DataTable WageadditionWorkview = Conn.RUN_SELECT("taxworkpackageview", "*", null, filterOcc, null, null, true);
            if ((WageadditionWorkview != null) && (WageadditionWorkview.Rows.Count > 0)) {
                foreach (DataRow R in WageadditionWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = R["idexppayed"];
                    rProgettoCosto["idpettycash"] = DBNull.Value;
                    rProgettoCosto["yoperation"] = DBNull.Value;
                    rProgettoCosto["noperation"] = DBNull.Value;
                    rProgettoCosto["amount"] = R["exppayedamount"];
                    rProgettoCosto["idsal"] = DBNull.Value;
                    //rProgettoCosto["doc"] = R["doc"];
                    //rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Contributi da elaborare"; //Non è un errore...
            }

            return true;
        }
        public bool ElaboraCompensiDipendenti(vistaForm ds, object idprogetto, out string errore) {
            errore = string.Empty;
            var idprogettocosto = MetaData.MaxFromColumn(ds.progettocosto, "idprogettocosto");// + 1;
            if (idprogettocosto < 990000000) idprogettocosto = 990000000; // sarà valorizzato in fase di salvataggio

            string filterOcc = filterForDipendenti(idprogetto);

            DataTable WageadditionWorkview = Conn.RUN_SELECT("wageadditionworkpackageview", "*", null, filterOcc, null, null, true);
            if ((WageadditionWorkview != null) && (WageadditionWorkview.Rows.Count > 0)) {
                foreach (DataRow R in WageadditionWorkview.Rows) {
                    DataRow rProgettoCosto = ds.progettocosto.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOCOSTO
                    //idprogettocosto = max +1
                    idprogettocosto++;
                    rProgettoCosto["idprogettocosto"] = idprogettocosto;
                    rProgettoCosto["idprogetto"] = R["idprogetto"];
                    rProgettoCosto["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotipocostoaccmotive
                    //recupera idexpPagamento
                    rProgettoCosto["idexp"] = R["idexppayed"];
                    rProgettoCosto["idpettycash"] =  DBNull.Value;
                    rProgettoCosto["yoperation"] =  DBNull.Value;
                    rProgettoCosto["noperation"] =  DBNull.Value;
                    rProgettoCosto["amount"] = R["exppayedamount"];
                    rProgettoCosto["idsal"] = DBNull.Value;
                    rProgettoCosto["doc"] = R["doc"];
                    rProgettoCosto["docdate"] = R["docdate"];
                    rProgettoCosto["idrelated"] = R["idrelated"];
                    rProgettoCosto["idworkpackage"] = R["idworkpackage"];
                    rProgettoCosto["cu"] = "progettocosto_functions";
                    rProgettoCosto["ct"] = DateTime.Now;
                    rProgettoCosto["lt"] = DateTime.Now;
                    rProgettoCosto["lu"] = "progettocosto_functions";
                    ds.progettocosto.Rows.Add(rProgettoCosto);
                }
            }
            else {
                errore = "Non vi sono Compesi a Dipendente da elaborare"; //Non è un errore...
            }

            return true;
        }
        
        public object PagatoOccasionale(DataRow R) {
            object importoPagato = DBNull.Value;
            if (R["idpettycash"] != DBNull.Value) {
                //Vuol dire che è stato pagato col fondo economale
                importoPagato = R["pettycashpayedamount"];
            }
            else {
                importoPagato = R["exppayedamount"];
            }
            return importoPagato;
        }
        public object PagatoMissione(DataRow R) {
            object importoPagato = DBNull.Value;
            if (R["idpettycash"] != DBNull.Value) {
                //Vuol dire che è stato pagato col fondo economale
                importoPagato = R["pettycashpayedamount"];
            }
            else {
                importoPagato = R["exppayedamount"];
            }
            return importoPagato;
        }

        public object idexpPagamentoDettFatt(DataRow RinvDetWorkview) {
            object idexp = DBNull.Value;
            if(RinvDetWorkview["idpettycash"] != DBNull.Value) {
                //Vuol dire che la fattura è stata pagata col fondo economale
                return idexp;
            }
            if (RinvDetWorkview["idexp_taxable"] == RinvDetWorkview["idexp_iva"]) {
            idexp = RinvDetWorkview["idexp_taxable"];
            }
            if ((RinvDetWorkview["idexp_taxable"] != RinvDetWorkview["idexp_iva"]) && (RinvDetWorkview["idexp_taxable"] != DBNull.Value)) {
                idexp  = RinvDetWorkview["idexp_taxable"];
            }
            if ((RinvDetWorkview["idexp_taxable"] != RinvDetWorkview["idexp_iva"]) && (RinvDetWorkview["idexp_iva"] != DBNull.Value)) {
                idexp = RinvDetWorkview["idexp_iva"];
            }
            return idexp;
        }
        public string filterForMandatedetail(object idprogetto) {
            string filter = QHS.AppAnd(
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"),
                QHS.IsNotNull("idexppayed")// Righe che  hanno il pagamento in Easy
                );
            return filter;
        }
        public string filterForRendicontattivitaprogetto(object idprogetto) {
            string filter = QHS.AppAnd(QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"));
            return filter;
        }
        public string filterForCedolini(object idprogetto) {
            string filter = QHS.AppAnd(/*QHS.CmpEq("ycon", esercizio),*/
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"), QHS.IsNotNull("idexppayed"));
            return filter;
        }
        public string filterForOccassionali(object idprogetto) {
            //se il compenso occasionale viene pagato su due impegni, devo scrivere due idexp. La prima volta che ho scritto in progettocosto, ho valorizzato l'idrelated, quindi 
            //quel compenso non lo prendo più filtrando per idrelated is null, per cui serve filtrare anche per idexp/idpettycash
            string filter = QHS.AppAnd(/*QHS.CmpEq("ycon", esercizio),*/
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"),
                QHS.AppOr(QHS.IsNotNull("idexppayed"), QHS.IsNotNull("idpettycash"))
                );
            return filter;
        }
        public string filterForMissioni(object idprogetto) {
            //se la misisone viene pagata su due impegni, devo scrivere due idexp. La prima volta che ho scritto in progettocosto, ho valorizzato l'idrelated, quindi 
            //quel compenso non lo prendo più filtrando per idrelated is null, per cui serve filtrare anche per idexp/idpettycash
            string filter = QHS.AppAnd(/*QHS.CmpEq("yitineration", esercizio),*/
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"),
                QHS.AppOr(QHS.IsNotNull("idexppayed"), QHS.IsNotNull("idpettycash"))
                );
            return filter;

        }
        public string filterForContributi(object idprogetto) {
            string filter = QHS.AppAnd(/*QHS.CmpEq("ymov", esercizio),*/
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"), QHS.IsNotNull("idexppayed"));
            return filter;
        }
        public string filterForDipendenti(object idprogetto) {
            string filter = QHS.AppAnd(/*QHS.CmpEq("ycon", esercizio),*/
                QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"), QHS.IsNotNull("idexppayed"));
            return filter;
        }

        public string filterForInvoicedetail(object idprogetto) {
             string filter = QHS.AppAnd(/*QHS.CmpEq("yinv", esercizio),*/ QHS.CmpEq("flagbuysell", "A"),
                    QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettocosto"),
                    QHS.AppOr(QHS.IsNotNull("idpettycash"), QHS.IsNotNull("idexp_taxable"), QHS.IsNotNull("idexp_iva"))// Righe che  hanno il pagamento in Easy
                    );
                return filter;
        }

    }
}
