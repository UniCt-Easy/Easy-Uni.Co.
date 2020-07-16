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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_incomelastview {//meta_entrataview//
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_incomelastview : Meta_easydata {
        public Meta_incomelastview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "incomelastview") {
            Name = "Movimento di entrata";
            ListingTypes.Add("documentocollegato");
            ListingTypes.Add("assegnazionecredito");
            ListingTypes.Add("assegnautocreditiincassi");
            ListingTypes.Add("autospesa");
            ListingTypes.Add("autogenerati");
            ListingTypes.Add("reversaleautomatica");
            ListingTypes.Add("elencofaseprec");
            //ListingTypes.Add("movimentiaperti");
            //ListingTypes.Add("movbancariocollegato");
            ListingTypes.Add("elenco");
            ListingTypes.Add("autogeneratips"); //by leo
        }
        private string[] mykey = new string[] { "idinc" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "documentocollegato") {
                if (R["kpro"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }
        public override bool CanSelect(DataRow R) {
            if (R.Table.Columns["ayear"] != null) {
                if (R["ayear"].ToString() != GetSys("esercizio").ToString()) {
                    MessageBox.Show("L'entrata selezionata non Ë presente in questo esercizio quindi non Ë selezionabile.");
                    return false;
                }
            }
            return base.CanSelect(R);
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "elencofaseprec" || ListingType == "default") {
                sorting = "phase asc,ymov desc,nmov desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "elencofaseprec" || ListingType == "default") {
                filteresercizio = "(ayear='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            switch (ListingType) {
                case "autogeneratips": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        DescribeAColumn(T, "idinc", ".identrata");
                        DescribeAColumn(T, "!livprecedente", "Livello Superiore");
                        DescribeAColumn(T, "phase", "Fase");
                        DescribeAColumn(T, "registry", "Versante");
                        DescribeAColumn(T, "codefin", "Bilancio");
                        DescribeAColumn(T, "codeupb", "UPB");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "amount", "Importo");
                        break;
                    }

                case "movimentiaperti": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        DescribeAColumn(T, "ymov", "Eserc. mov.", 1);
                        DescribeAColumn(T, "nmov", "Num. mov.", 2);
                        DescribeAColumn(T, "codefin", "Voce di bilancio", 3);
                        DescribeAColumn(T, "codeupb", "U.P.B.", 4);
                        DescribeAColumn(T, "registry", "Versante", 5);
                        DescribeAColumn(T, "manager", "Responsabile", 6);
                        DescribeAColumn(T, "description", "Descrizione", 7);
                        DescribeAColumn(T, "curramount", "Importo Corrente", 8);
                        DescribeAColumn(T, "available", "Disponibile", 9);
                        DescribeAColumn(T, "adate", "Data cont.", 10);
                        DescribeAColumn(T, "doc", "Documento", -1);
                        DescribeAColumn(T, "expiration", "Data scad.", -1);
                        break;
                    }

                case "documentocollegato": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        DescribeAColumn(T, "ymov", "Eserc.");
                        DescribeAColumn(T, "nmov", "Numero");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "registry", "Versante");
                        DescribeAColumn(T, "codefin", "Bilancio");
                        DescribeAColumn(T, "codeupb", "U.P.B.");
                        DescribeAColumn(T, "manager", "Resp. bil.");
                        DescribeAColumn(T, "curramount", "Importo");
                        FilterRows(T);
                        break;
                    }
                case "autospesa": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        DescribeAColumn(T, "idinc", ".identrata");
                        DescribeAColumn(T, "phase", "Fase");
                        DescribeAColumn(T, "nmov", "Numero");
                        DescribeAColumn(T, "registry", "Versante");
                        DescribeAColumn(T, "codefin", "Bilancio");
                        //				DescribeAColumn(T, "codeupb", "U.P.B.");
                        DescribeAColumn(T, "amount", "Importo Iniziale");
                        DescribeAColumn(T, "curramount", "Importo Corrente");
                        DescribeAColumn(T, "ypro", "Eserc. Reversale");
                        DescribeAColumn(T, "npro", "Num. Reversale");
                        break;
                    }

                case "autogenerati": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        DescribeAColumn(T, "!livprecedente", "Livello Superiore");
                        DescribeAColumn(T, "idinc", ".identrata");
                        DescribeAColumn(T, "phase", "Fase");
                        DescribeAColumn(T, "registry", "Versante");
                        DescribeAColumn(T, "codefin", "Bilancio");
                        //				DescribeAColumn(T, "codeupb", "U.P.B.");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "amount", "Importo Iniziale");
                        DescribeAColumn(T, "curramount", "Importo Corrente");
                        break;
                    }

                case "assegnazionecredito": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        DescribeAColumn(T, "ymov", "Eserc. mov.");
                        DescribeAColumn(T, "nmov", "Num. mov.");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "registry", "Versante");
                        DescribeAColumn(T, "codefin", "Voce bil.");
                        DescribeAColumn(T, "codeupb", "U.P.B.");
                        DescribeAColumn(T, "manager", "Resp. bil.");
                        DescribeAColumn(T, "curramount", "Imp. corrente");
                        DescribeAColumn(T, "available", "Disponibile");
                        DescribeAColumn(T, "expiration", "Data scad.");
                        DescribeAColumn(T, "adate", "Data cont.");
                        break;
                    }

                case "assegnautocreditiincassi": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        DescribeAColumn(T, "phase", "Fase", 1);
                        DescribeAColumn(T, "ymov", "Eserc. mov.", 2);
                        DescribeAColumn(T, "nmov", "Num. mov.", 3);
                        DescribeAColumn(T, "description", "Descrizione", 4);
                        DescribeAColumn(T, "registry", "Versante", 5);
                        DescribeAColumn(T, "codefin", "Bilancio", 6);
                        DescribeAColumn(T, "codeupb", "U.P.B.", 7);
                        DescribeAColumn(T, "curramount", "Imp. corrente", 8);
                        DescribeAColumn(T, "unpartitioned", "Da assegnare", 9);
                        break;
                    }

                case "reversaleautomatica": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        DescribeAColumn(T, "idinc", ".identrata", 1);
                        DescribeAColumn(T, "ymov", "Eserc.", 2);
                        DescribeAColumn(T, "nmov", "Numero", 3);
                        DescribeAColumn(T, "registry", "Versante", 4);
                        DescribeAColumn(T, "codefin", "Bilancio", 5);
                        DescribeAColumn(T, "codeupb", "U.P.B.", 6);
                        DescribeAColumn(T, "manager", "Resp. bil.", 7);
                        DescribeAColumn(T, "description", "Descrizione", 8);
                        DescribeAColumn(T, "curramount", "Importo", 9);
                        break;
                    }
                /*if (ListingType=="movbancario") {
                    foreach(DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "");
                    }
                    DescribeAColumn(T, "ymov", "Eserc.");
                    DescribeAColumn(T, "nmov", "Numero");
                    DescribeAColumn(T, "description", "Descrizione");
                    DescribeAColumn(T, "registry", "Versante");
                    DescribeAColumn(T, "codefin", "Bilancio");
                    DescribeAColumn(T, "codeupb", "U.P.B.");
                    DescribeAColumn(T, "manager", "Resp. bil.");
                    DescribeAColumn(T, "curramount", "Importo");
                }
                if (ListingType=="movbancariocollegato") {
                    foreach(DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "",-1);
                    }
                    DescribeAColumn(T, "ymov", "Eserc.",1);
                    DescribeAColumn(T, "nmov", "Numero",2);
                    DescribeAColumn(T, "description", "Descrizione",3);
                    DescribeAColumn(T, "registry", "Versante",4);
                    DescribeAColumn(T, "codefin", "Bilancio",5);
                    DescribeAColumn(T, "codeupb", "U.P.B.",6);
                    DescribeAColumn(T, "manager", "Resp. bil.",7);
                    DescribeAColumn(T, "curramount", "Importo",8);
                    FilterRows(T);
                }*/

                case "elencofaseprec": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        DescribeAColumn(T, "ymov", "Eserc. mov.", 1);
                        DescribeAColumn(T, "nmov", "Num. mov.", 2);
                        DescribeAColumn(T, "codefin", "Voce bilancio", 3);
                        DescribeAColumn(T, "codeupb", "U.P.B.", 4);
                        DescribeAColumn(T, "description", "Descrizione", 5);
                        DescribeAColumn(T, "registry", "Versante", 6);
                        DescribeAColumn(T, "centercode", "CentroSpesa", 7);
                        DescribeAColumn(T, "curramount", "Imp. corrente", 8);
                        DescribeAColumn(T, "available", "Disponibile", 9);
                        DescribeAColumn(T, "adate", "Data cont.", 10);
                        break;
                    }
                     case "elenco": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "phase", "Fase", nPos++);
                        DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "curramount", "Importo", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
                        DescribeAColumn(T, "performed", "Esitato", nPos++);
                        DescribeAColumn(T, "notperformed", "Non esitato", nPos++);
						DescribeAColumn(T, "net", "Netto", nPos++);
                        DescribeAColumn(T, "nbill", "Bolletta", nPos++);
                        DescribeAColumn(T, "npro", "Reversale", nPos++);
                        DescribeAColumn(T, "idpro", "Numero movimento bancario", nPos++);
						FilterRows(T);
                        break;
                    }
                case "default": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int npos = 1;
                        DescribeAColumn(T, "phase", "Fase", npos++);
                        DescribeAColumn(T, "ymov", "Eserc.Mov.", npos++);
                        DescribeAColumn(T, "nmov", "Num.Mov.", npos++);
                        DescribeAColumn(T, "codefin", "Voce Bil.", npos++);
                        DescribeAColumn(T, "finance", "Denom. Bil.", npos++);
                        DescribeAColumn(T, "codeupb", "Cod. U.P.B.", npos++);
                        DescribeAColumn(T, "upb", "U.P.B.", npos++);
                        DescribeAColumn(T, "registry", "Versante", npos++);
                        DescribeAColumn(T, "manager", "Responsabile", npos++);
                        DescribeAColumn(T, "ypro", "Eserc.Rev.", npos++);
                        DescribeAColumn(T, "npro", "Num.Rev.", npos++);
                        DescribeAColumn(T, "doc", "Documento", npos++);
                        DescribeAColumn(T, "docdate", "Data Doc.", npos++);
                        DescribeAColumn(T, "description", "Descrizione", npos++);
                        DescribeAColumn(T, "amount", "Importo Originale", npos++);
                        DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", npos++);
                        DescribeAColumn(T, "curramount", "Imp.Corrente", npos++);
                        DescribeAColumn(T, "available", "Disponibile", npos++);
                        DescribeAColumn(T, "unpartitioned", "Da Assegnare", npos++);
                        DescribeAColumn(T, "fulfilled", ".Mov.Cop.", -1);
                        DescribeAColumn(T, "autokind", ".Tipo Auto", -1);
                        DescribeAColumn(T, "flagarrear", ".Competenza", -1);
                        DescribeAColumn(T, "expiration", ".Data Scadenza", -1);
                        DescribeAColumn(T, "adate", "Data Contabile", npos++);
                        DescribeAColumn(T, "nbill", "Bolletta", npos++);
                        break;
                    }
            }
        }
    }
}