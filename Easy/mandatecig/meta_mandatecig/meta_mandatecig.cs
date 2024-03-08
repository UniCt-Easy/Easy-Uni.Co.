
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_mandatecig {
    public class Meta_mandatecig : Meta_easydata {
        public Meta_mandatecig(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "mandatecig") {
            EditTypes.Add("detail");
            ListingTypes.Add("lista");
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "single") {
                Name = "Informazioni su un lotto ai fini AVCP";
                return GetFormByDllName("mandatecig_detail");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "contractamount", "Importo aggiudicato", nPos++);
                DescribeAColumn(T, "!capogruppo", "Capogruppo", nPos++);
                ComputeRowsAs(T, listtype);
            }
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type == "lista") {
                DataTable Partecipanti = R.Table.DataSet.Tables["mandateavcp"];
                if (R["idavcp"] != DBNull.Value) {
                    DataRow[] f = Partecipanti.Select(QHC.CmpEq("idavcp", R["idavcp"]));
                    if (f.Length == 1) {
                        R["!capogruppo"] = f[0]["title"];
                    }
                }
            }
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R["idmankind"].ToString() == "") {
                errfield = "idmankind";
                errmess = "E' necessario scegliere il tipo contratto";
                return false;
            }

            if (R["cigcode"].ToString().Trim() == "") {
                errmess = "Indicare il codice CIG del lotto.";
                errfield = "cigcode";
                return false;
            }
            if (R["cigcode"].ToString().Length != 10) {
                errmess = "Il CIG deve avere lunghezza 10.";
                errfield = "cigcode";
                return false;
            }
            if (!CfgFn.IsValidString(R["cigcode"].ToString())) {
                errmess = "Il CIG contiene caratteri non validi. I caratteri ammessi sono solo numeri e lettere";
                errfield = "cigcode";
                return false;
            }
            if (R["description"].ToString().Trim() == "") {
                errmess = "Indicare l'Oggetto del lotto identificato dal CIG";
                errfield = "description";
                return false;
            }
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            object isreq = Conn.DO_READ_VALUE("mandatekind", QHS.CmpEq("idmankind", R["idmankind"]), "isrequest");
            if (isreq == null) isreq = "N";
            if (isreq.ToString().ToUpper() == "S") {
            }
            else {
                // Dati per la trasmissione AVCP, obbligatori se valorizzato l'Aggiudicatario.
                if (R["idavcp"] == DBNull.Value) {
                    errmess = "Scegliere l'aggiudicatario";
                    errfield = "idavcp";
                    return false;
                }
                if (R["start_contract"] == DBNull.Value) {
                    errmess = "Indicare la Data di effettivo inizio lavori, servizi o forniture";
                    errfield = "start_contract";
                    return false;
                }
                //if (R["stop_contract"] == DBNull.Value) {
                //    errmess = "Indicare la Data di ultimazione lavori, servizi o forniture";
                //    errfield = "stop_contract";
                //    return false;
                //}
                if (R["idavcp_choice"] == DBNull.Value) {
                    errmess = "Specificare la Procedura di scelta del contraente";
                    errfield = "idavcp_choice";
                    return false;
                }

                if (SourceRow != null) {
                    if (SourceRow.Table.DataSet.Tables["mandatedetail"].Select(QHC.IsNull("stop")).Length > 0) {
                        if (CfgFn.GetNoNullDecimal(R["contractamount"]) == 0) {
                            errmess = "E' necessario specificare l'importo di aggiudicazione";
                            errfield = "contractamount";
                            return false;
                        }
                    }
                }
            }
            return true;

        }
    }
}
