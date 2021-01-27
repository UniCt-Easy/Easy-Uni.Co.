
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
using funzioni_configurazione;

namespace meta_paydispositiondetail {
    public class Meta_paydispositiondetail : Meta_easydata {
        public Meta_paydispositiondetail (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "paydispositiondetail") {
            ListingTypes.Add("default");
            EditTypes.Add("default");
            EditTypes.Add("main");
            DefaultListType = "detail";
        }

        protected override Form GetForm (string EditType) {
            if (EditType == "default") {
                DefaultListType = "detail";
                Name = "Disposizione di Pagamento - Dettaglio";
                return GetFormByDllName("paydispositiondetail_single");
            }
            if (EditType == "main") {
                DefaultListType = "elenco";
                Name = "Disposizione di Pagamento";
                return GetFormByDllName("paydispositiondetail_default");
            }
            return null;
        }

  

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idpaydisposition");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["iddetail"],900000);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "gender", "M");
            SetDefault(T, "flaghuman", "S");
            SetDefault(T, "flagtaxrefund", "N");
			SetDefault(T, "flag", 0);
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "elenco")
            {
                return base.SelectOne(ListingType, filter, "paydispositiondetailview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            int pos = 1;
			string fasemax = Conn.DO_READ_VALUE("expensephase", "nphase=" + GetSys("maxexpensephase"), "description").ToString();
			switch (ListingType) {
                case "default": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        pos = 1;
                        DescribeAColumn(T, "surname", "Cognome", pos++);
                        DescribeAColumn(T, "forename", "Nome", pos++);
                        DescribeAColumn(T, "cf", "Codice Fiscale", pos++);
                        DescribeAColumn(T, "amount", "Importo", pos++);
                        DescribeAColumn(T, "motive", "Causale", pos++);
                        break;
                    }

                case "detail":
                    {
                        foreach (DataColumn C in T.Columns)
                        {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        pos = 1;

                        DescribeAColumn(T, "iddetail", "Progressivo", pos++);
                        DescribeAColumn(T, "surname", "Cognome", pos++);
                        DescribeAColumn(T, "forename", "Nome", pos++);
                        DescribeAColumn(T, "title", "Denominazione", pos++);
                        DescribeAColumn(T, "cf", "Codice Fiscale", pos++);
                        DescribeAColumn(T, "p_iva", "Partita IVA", pos++);
                        DescribeAColumn(T, "amount", "Importo", pos++);
                        DescribeAColumn(T, "iban", "IBAN", pos++);
                        DescribeAColumn(T, "motive", "Causale", pos++);
                        DescribeAColumn(T, "email", "E-Mail", pos++);
                        DescribeAColumn(T, "paymentcode", "Cod. Pagamento", pos++);
						//DescribeAColumn(T, "!npro", "N. reversale", "proceeds.npro", pos++);
						//DescribeAColumn(T, "!nmovi", "N.mov. entrata", "income.nmov", pos++);

						//DescribeAColumn(T, "!phase", "Fase",fasemax, pos++);
						DescribeAColumn(T, "!ymov", "Eserc. " + fasemax, "expense.ymov",pos++);
						DescribeAColumn(T, "!nmov", "Num. " + fasemax, "expense.nmov", pos++);
						DescribeAColumn(T, "flagtaxrefund", "Rimborso Spese", pos++);
                        break;
                    }
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullDecimal(R["amount"]) <= 0) {
                errmess = "L'importo non può essere nullo, negativo o uguale a zero";
                errfield = "amount";
                return false;
            }

            if (R["flaghuman"].ToString().ToUpper() == "S") {
               
                if (R["surname"] == DBNull.Value)
                {
                    errmess = "Inserire il Cognome";
                    errfield = "surname";
                    return false;
                }

                if (R["forename"] == DBNull.Value)
                {
                    errmess = "Inserire il Nome";
                    errfield = "forename";
                    return false;
                }

                if (R["birthdate"] == DBNull.Value)
                {
                    errmess = "Inserire la data di nascita";
                    errfield = "birthdate";
                    return false;
                }

                if (R["gender"] == DBNull.Value)
                {
                    errmess = "Inserire il sesso";
                    errfield = "gender";
                    return false;
                }

                if ((CfgFn.GetNoNullInt32(R["idcity"]) == 0) && (CfgFn.GetNoNullInt32(R["idnation"]) == 0))
                {
                    errmess = "Inserire la città di nascita o lo stato estero di nascita";
                    errfield = "idcity";
                    return false;
                }

                if (R["cap"] == DBNull.Value)
                {
                    errmess = "Inserire il C.A.P.";
                    errfield = "cap";
                    return false;
                }

                if (R["address"] == DBNull.Value)
                {
                    errmess = "Inserire l'indirizzo";
                    errfield = "address";
                    return false;
                }

                if (R["location"] == DBNull.Value)
                {
                    errmess = "Inserire la località";
                    errfield = "location";
                    return false;
                }

                if (R["province"] == DBNull.Value)
                {
                    errmess = "Inserire la sigla della provincia";
                    errfield = "province";
                    return false;
                }

                // Controlli sul codice fiscale
                if (R["cf"] == DBNull.Value)
                {
                    errmess = "Inserire il codice fiscale";
                    errfield = "cf";
                    return false;
                }

                string errori;
                CalcolaCodiceFiscale.CheckCF(R["cf"].ToString(), out errori);
                if (errori != "")
                {

                    errmess = errori = "Nel codice fiscale inserito compaiono i seguenti errori:\n\r " + errori;
                    errfield = "cf";
                    return false;
                }

                string codicefiscalecalcolato;
                bool isValid;
                string errCF;
                int idgeo;
                string TipoGeo;

                // Se sono arrivato in questo punto vuol dire che idcity o idnation sono valorizzati
                if (CfgFn.GetNoNullInt32(R["idcity"]) > 0)
                {
                    idgeo = CfgFn.GetNoNullInt32(R["idcity"]);
                    TipoGeo = "C";
                }
                else
                {
                    idgeo = CfgFn.GetNoNullInt32(R["idnation"]);
                    TipoGeo = "N";
                }

                string cfNormal = CalcolaCodiceFiscale.normalizza(R["cf"].ToString().ToUpper());
                // Se arrivo a questo punto del codice vuol dire che i dati presenti nel dataset sono quantomeno diversi da null
                codicefiscalecalcolato =
                    CalcolaCodiceFiscale.Make(this.Conn,
                    R["forename"].ToString(),
                    R["surname"].ToString(),
                    (DateTime)R["birthdate"],
                    idgeo.ToString(),
                    R["gender"].ToString(),
                    TipoGeo,
                    out isValid,
                    out errCF);

                if (cfNormal != codicefiscalecalcolato)
                {
                    errmess = "Dati anagrafici errati!";
                    errfield = "cf";
                    if (cfNormal.Substring(0, 3) != codicefiscalecalcolato.Substring(0, 3))
                    {
                        errmess += "\r\nCF non coerente con il cognome";
                    }
                    if (cfNormal.Substring(3, 3) != codicefiscalecalcolato.Substring(3, 3))
                    {
                        errmess += "\r\nCF non coerente con il nome";
                    }
                    if (cfNormal.Substring(6, 2) != codicefiscalecalcolato.Substring(6, 2))
                    {
                        errmess += "\r\nCF non coerente con l'anno di nascita";
                    }
                    if (cfNormal.Substring(8, 1) != codicefiscalecalcolato.Substring(8, 1))
                    {
                        errmess += "\r\nCF non coerente con il mese di nascita";
                    }

                    int g1 = Convert.ToInt32(cfNormal.Substring(9, 2));
                    int g2 = Convert.ToInt32(codicefiscalecalcolato.Substring(9, 2));
                    string s1 = "M";
                    string s2 = "M";
                    if (g1 > 40)
                    {
                        s1 = "F";
                        g1 -= 40;
                    }
                    if (g2 > 40)
                    {
                        s2 = "F";
                        g2 -= 40;
                    }

                    if (g1 != g2)
                    {
                        errmess += "\r\nCF non coerente con il giorno di nascita";
                    }
                    if (s1 != s2)
                    {
                        errmess += "\r\nCF non coerente con il sesso";
                    }

                    if (cfNormal.Substring(11, 4) != codicefiscalecalcolato.Substring(11, 4))
                    {
                        errmess += "\r\nCF non coerente con il comune o la nazione di nascita";
                    }
                    return false;
                }
            }
            else{ //E' un'azienda
                if (R["title"] == DBNull.Value){
                    errmess = "Inserire la denominazione";
                    errfield = "title";
                    return false;
                }
                if ((R["p_iva"] == DBNull.Value) && (R["cf"] == DBNull.Value))
                {
                    errmess = "Inserire la Partita IVA o il Codice Fiscale";
                    errfield = "p_iva";
                    return false;
                }

            }

            if ((R["abi"] != DBNull.Value) && (R["abi"].ToString().Length < 5))
            {
                errmess = "Il codice A.B.I. deve essere composto da 5 numeri";
                errfield = "abi";
                return false;
            }

            if ((R["cab"] != DBNull.Value) && (R["cab"].ToString().Length < 5))
            {
                errmess = "Il codice C.A.B. deve essere composto da 5 numeri";
                errfield = "cab";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["paymethodcode"]) == 0)
            {
                errmess = "Deve essere scelta una modalità di pagamento";
                errfield = "paymethodcode";
                return false;
            }

            return true;
        }
    }
}
