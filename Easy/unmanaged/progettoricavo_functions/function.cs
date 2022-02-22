
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace progettoricavo_functions {
    public class progettoricavo_function {
        IDataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;
        public progettoricavo_function(IDataAccess conn) {
            this.Conn = conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
        }

        public void InitMetaData(vistaForm ds, object idprogetto) {
            // Imposta i default
            // Imposta autoincremento e selettori
            MetaData.SetDefault(ds.progettoricavo, "idprogetto", idprogetto);
            RowChange.MarkAsAutoincrement(ds.progettoricavo.Columns["idprogettoricavo"], null, null, 0);

            ClearDataSet.RemoveConstraints(ds);
        }

       public DataSet popolaprogettoricavo(object idprogetto, out string errore) {
            errore = string.Empty;
            try {
                vistaForm ds = new vistaForm();
                InitMetaData(ds, idprogetto);

                string erroreElaborazione;
                if (!ElaboraFattureVendita(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }

                if (!ElaboraContrattiAttivi(ds, idprogetto, out erroreElaborazione)) {
                    errore = erroreElaborazione;
                    return null;
                }

                if (!ElaboraRendicontattivitaprogetto(ds, idprogetto, out erroreElaborazione)) {
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
            var idprogettoricavo = MetaData.MaxFromColumn(ds.progettoricavo, "idprogettoricavo");
            if (idprogettoricavo < 990000000) idprogettoricavo = 990000000; // sarà valorizzato in fase di salvataggio

            string query = @"select ( ore * 
	            CASE WHEN isnull(ricavoorario, 0) <> 0 THEN ricavoorario
				WHEN costoorario_stipendio <> 0 THEN costoorario_stipendio
	            WHEN costoorario_inquadramento <> 0 THEN costoorario_inquadramento
	            WHEN costoorario_contrattokind <> 0 THEN costoorario_contrattokind
	            ELSE 0
	            END
	            ) as amount, V.* 

            from rendicontattivitaprogettoworkpackagericavoview V 
            where ( V.idprogettoricavo is null and  isnull(oredivisionecostostipendio,0) > 0) and V.idprogetto =" + (string)idprogetto;

            DataTable t = Conn.SQLRunner(query);
            if ((t != null) && (t.Rows.Count > 0)) {

                foreach (DataRow R in t.Rows) {
                    DataRow rProgettoricavo = ds.progettoricavo.NewRow();
                    //Per ogni compenso deve valorizzare i campi di PROGETTOricavo
                    //idprogettoricavo = max +1
                    idprogettoricavo++;
                    rProgettoricavo["idprogettoricavo"] = idprogettoricavo;
                    rProgettoricavo["idprogetto"] = R["idprogetto"];
                    rProgettoricavo["idprogettotipocosto"] = R["idprogettotipocosto"];// Letto da progettotiporicavocontrattokind
                    //Valorizzati a null per il Rendiconto Attività
                    rProgettoricavo["idinc"] = DBNull.Value;
                    rProgettoricavo["amount"] = R["amount"];
                    rProgettoricavo["idcontrattokind"] = R["idcontrattokind"];
                    rProgettoricavo["idrendicontattivitaprogetto"] = R["idrendicontattivitaprogetto"];
                    rProgettoricavo["idsal"] = DBNull.Value;
                    rProgettoricavo["doc"] = DBNull.Value;
                    rProgettoricavo["docdate"] = R["data"];
                    rProgettoricavo["idrelated"] = DBNull.Value;
                    rProgettoricavo["idworkpackage"] = R["idworkpackage"];
                    rProgettoricavo["cu"] = "progettoricavo_functions";
                    rProgettoricavo["ct"] = DateTime.Now;
                    rProgettoricavo["lt"] = DateTime.Now;
                    rProgettoricavo["lu"] = "progettoricavo_functions";
                    ds.progettoricavo.Rows.Add(rProgettoricavo);
                }
            }
            else {
                errore = "Non vi sono Rendiconto attivita progetto da elaborare"; //Non è un errore...
            }

            return true;
        }

        public bool ElaboraContrattiAttivi(vistaForm ds, object idprogetto, out string errore) {
            var idprogettoricavo = MetaData.MaxFromColumn(ds.progettoricavo, "idprogettoricavo");// + 1;
            if (idprogettoricavo < 990000000) idprogettoricavo = 990000000; // sarà valorizzato in fase di salvataggio
            errore = string.Empty;
            string filterInv = filterForEstimatedetail(idprogetto);

            DataTable InvDetWorkview = Conn.RUN_SELECT("estimatedetailincworkpackageview", "*", null, filterInv, null, null, true);
            if ((InvDetWorkview != null) && (InvDetWorkview.Rows.Count > 0)) {
                foreach (DataRow R in InvDetWorkview.Rows) {
                    DataRow rProgettoricavo = ds.progettoricavo.NewRow();
                    //Per ogni fattura deve valorizzare i campi di PROGETTOricavo
                    //idprogettoricavo = max +1
                    idprogettoricavo++;
                    rProgettoricavo["idprogettoricavo"] = idprogettoricavo;
                    rProgettoricavo["idprogetto"] = R["idprogetto"];
                    rProgettoricavo["idprogettotipocosto"] = R["idprogettotipocosto"];//Letto da progettotiporicavoaccmotive
                    //recupera idincIncasso
                    rProgettoricavo["idinc"] = idincIncassoDettContrattoAtt(R);
                    rProgettoricavo["amount"] = R["proceedamount"];
                    rProgettoricavo["idsal"] = DBNull.Value;
                    rProgettoricavo["doc"] = R["doc"];
                    rProgettoricavo["docdate"] = R["docdate"];
                    rProgettoricavo["idrelated"] = R["idrelated"];
                    rProgettoricavo["idworkpackage"] = R["idworkpackage"];
                    rProgettoricavo["cu"] = "progettoricavo_functions";
                    rProgettoricavo["ct"] = DateTime.Now;
                    rProgettoricavo["lt"] = DateTime.Now;
                    rProgettoricavo["lu"] = "progettoricavo_functions";
                    ds.progettoricavo.Rows.Add(rProgettoricavo);
                }
            }
            else {
                errore = "Non vi sono Contratti Attivi da elaborare"; //Non è un errore...
            }
            return true;
        }

        public bool ElaboraFattureVendita(vistaForm ds, object idprogetto, out string errore) {
            var idprogettoricavo = MetaData.MaxFromColumn(ds.progettoricavo, "idprogettoricavo");// + 1;
            if (idprogettoricavo < 990000000) idprogettoricavo = 990000000; // sarà valorizzato in fase di salvataggio
            errore = string.Empty;
            string filterInv = filterForInvoicedetail(idprogetto);
            
            DataTable InvDetWorkview = Conn.RUN_SELECT("invoicedetailincworkpackageview", "*", null, filterInv, null, null, true);
            if ((InvDetWorkview != null) && (InvDetWorkview.Rows.Count > 0)) {
                foreach (DataRow R in InvDetWorkview.Rows) {
                    DataRow rProgettoricavo = ds.progettoricavo.NewRow();
                    //Per ogni fattura deve valorizzare i campi di PROGETTOricavo
                    //idprogettoricavo = max +1
                    idprogettoricavo++;
                    rProgettoricavo["idprogettoricavo"] = idprogettoricavo;
                    rProgettoricavo["idprogetto"] = R["idprogetto"];
                    rProgettoricavo["idprogettotipocosto"] = R["idprogettotipocosto"];//Letto da progettotiporicavoaccmotive
                    //recupera idincIncasso
                    rProgettoricavo["idinc"] = idincIncassoDettFatt(R);
                    rProgettoricavo["amount"] = R["proceedamount"];
                    rProgettoricavo["idsal"] = DBNull.Value;
                    rProgettoricavo["doc"] = R["doc"];
                    rProgettoricavo["docdate"] = R["docdate"];
                    rProgettoricavo["idrelated"] = R["idrelated"];
                    rProgettoricavo["idworkpackage"] = R["idworkpackage"];
                    rProgettoricavo["cu"] = "progettoricavo_functions";
                    rProgettoricavo["ct"] = DateTime.Now;
                    rProgettoricavo["lt"] = DateTime.Now;
                    rProgettoricavo["lu"] = "progettoricavo_functions";
                    ds.progettoricavo.Rows.Add(rProgettoricavo);
                }
            }
            else {
                errore = "Non vi sono Fatture di Acquisto da elaborare"; //Non è un errore...
            }
            return true;
        }

        public object idincIncassoDettContrattoAtt(DataRow RestimDetWorkview) {
            object idinc = DBNull.Value;
            if (RestimDetWorkview["idincproceed"] != DBNull.Value) {
                idinc = RestimDetWorkview["idincproceed"];
            }
            return idinc;
        }
        public object idincIncassoDettFatt(DataRow RinvDetWorkview) {
            object idinc = DBNull.Value;
            if (RinvDetWorkview["idinc_taxable"] == RinvDetWorkview["idinc_iva"]) {
                idinc = RinvDetWorkview["idinc_taxable"];
            }
            if ((RinvDetWorkview["idinc_taxable"] != RinvDetWorkview["idinc_iva"]) && (RinvDetWorkview["idinc_taxable"] != DBNull.Value)) {
                idinc = RinvDetWorkview["idinc_taxable"];
            }
            if ((RinvDetWorkview["idinc_taxable"] != RinvDetWorkview["idinc_iva"]) && (RinvDetWorkview["idinc_iva"] != DBNull.Value)) {
                idinc = RinvDetWorkview["idinc_iva"];
            }
            return idinc;
        }
        public string filterForRendicontattivitaprogetto(object idprogetto) {
            string filter = QHS.AppAnd(QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettoricavo"));
            return filter;
        }

        public string filterForEstimatedetail(object idprogetto) {
                string filter = QHS.AppAnd(
                    QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettoricavo"),
                    QHS.IsNotNull("idincproceed")// Righe che  hanno l'incasso in Easy
                    );
                return filter;

        }
        public string filterForInvoicedetail(object idprogetto) {
                string filter = QHS.AppAnd(QHS.CmpEq("yinv", esercizio), QHS.CmpEq("flagbuysell", "V"),
                    QHS.CmpEq("idprogetto", idprogetto), QHS.IsNull("idprogettoricavo"),
                    QHS.AppOr(QHS.IsNotNull("idinc_taxable"), QHS.IsNotNull("idinc_iva")));// Righe che hanno l'incasso in Easy
                return filter;
        }

    }
}
