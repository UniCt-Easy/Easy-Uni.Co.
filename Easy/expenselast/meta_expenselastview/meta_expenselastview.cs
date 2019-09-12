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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_expenselastview {//meta_spesaview//
    /// <summary>
    /// MetaData for spesa
    /// </summary>
    public class Meta_expenselastview : Meta_easydata {
        public Meta_expenselastview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "expenselastview") {
            Name = "Movimento di spesa";
            ListingTypes.Add("default");
            ListingTypes.Add("movimentiaperti");
            ListingTypes.Add("documentocollegato");
            ListingTypes.Add("variazionemovimento");
            ListingTypes.Add("autospesa");
            ListingTypes.Add("autogenerati");
            ListingTypes.Add("mandatoautomatico");
            ListingTypes.Add("elencofaseprec");
            ListingTypes.Add("movbancariocollegato");
            ListingTypes.Add("movbancario");
            ListingTypes.Add("autogeneratips");//by leo
            ListingTypes.Add("movimentospesa");//Rosalba
        }
        public override bool CanSelect(DataRow R) {
            if (R.Table.Columns["ayear"] != null) {
                if (R["ayear"].ToString() != GetSys("esercizio").ToString()) {
                    MessageBox.Show("La spesa selezionata non è presente in questo esercizio quindi non è selezionabile.");
                    return false;
                }
            }
            return base.CanSelect(R);
        }

        private string[] mykey = new string[] { "ayear","idexp" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "documentocollegato") {
                if (R["kpay"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "elencofaseprec" || ListingType == "default") {
                filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }


        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "elencofaseprec" || ListingType == "default") {
                sorting = "phase asc,ymov desc,nmov desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            //added by Leo
            switch (ListingType) {
                case "autogeneratips": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "idexp", ".idexp", nPos++);
                        DescribeAColumn(T, "!livprecedente", "Livello Superiore", nPos++);
                        DescribeAColumn(T, "phase", "Fase", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "amount", "Importo", nPos++);
                        break;
                    }

                case "movimentiaperti": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                        DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "doc", "Documento", nPos++);
                        DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                        DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
                        DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
						DescribeAColumn(T, "net", "Netto", nPos++);
						break;
                    }

                case "documentocollegato": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "curramount", "Importo", nPos++);
						DescribeAColumn(T, "net", "Netto", nPos++);
						FilterRows(T);
                        break;
                    }

                case "autospesa": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "phase", "Fase", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
                        DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
                        DescribeAColumn(T, "ypay", "Eserc. Mandato", nPos++);
                        DescribeAColumn(T, "npay", "Num. Mandato", nPos++);
                        break;
                    }

                case "autogenerati": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "idexp", ".idexp", nPos++);
                        DescribeAColumn(T, "!livprecedente", "Livello Superiore", nPos++);
                        DescribeAColumn(T, "phase", "Fase", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
                        DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
                        break;
                    }

                case "variazionemovimento": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                        DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Voce bil.", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "curramount", "Imp. corrente", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
                        DescribeAColumn(T, "expiration", "Data scad.", nPos++);
                        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                        break;
                    }


                case "elencofaseprec": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                        DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                        DescribeAColumn(T, "codefin", "Voce bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "curramount", "Imp. corrente", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
                        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                        break;
                    }

                case "movbancariocollegato": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "curramount", "Importo", nPos++);
                        FilterRows(T);
                        break;
                    }

                case "movbancario": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "curramount", "Importo", nPos++);
                        break;
                    }

                case "mandatoautomatico": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "idexp", ".idexp", nPos++);
                        DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                        DescribeAColumn(T, "nmov", "Numero", nPos++);
                        DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "curramount", "Importo", nPos++);
						DescribeAColumn(T, "net", "Netto", nPos++);
						break;
                    }


                case "movimentospesa": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        int nPos = 1;
                        DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                        DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                        DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
                        DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                        DescribeAColumn(T, "doc", "Documento", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
                        DescribeAColumn(T, "expiration", "Data scad.", nPos++);
                        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                        break;
                    }

                case "default": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "phase", "Fase", nPos++);
                        DescribeAColumn(T, "ymov", "Eserc.Mov.", nPos++);
                        DescribeAColumn(T, "nmov", "Num.Mov.", nPos++);
                        DescribeAColumn(T, "codefin", "Voce Bil.", nPos++);
                        DescribeAColumn(T, "finance", "Denom. Bil.", nPos++);
                        DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                        DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                        DescribeAColumn(T, "idexp", ".idexp", -1);
                        DescribeAColumn(T, "registry", "Percipiente", nPos++);
                        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                        DescribeAColumn(T, "doc", "Documento", nPos++);
                        DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        DescribeAColumn(T, "amount", "Importo Originale", nPos++);
                        DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", nPos++);
                        DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
                        DescribeAColumn(T, "available", "Disponibile", nPos++);
                        DescribeAColumn(T, "adate", "Data Contabile", nPos++);
                        DescribeAColumn(T, "ypay", "Eserc.Mand.", nPos++);
                        DescribeAColumn(T, "npay", "Num.Mand.", nPos++);
                        DescribeAColumn(T, "paymentadate", "Data Cont. Mand.", nPos++);
                        DescribeAColumn(T, "regmodcode", ".Tipo Modalità", -1);
                        DescribeAColumn(T, "idregistrypaymethod", ".#", -1);
                        DescribeAColumn(T, "idpaymethod", ".Codice Mod.Pag.", -1);
                        DescribeAColumn(T, "cin", ".Cin", -1);
                        DescribeAColumn(T, "idbank", ".Cod.ABI", -1);
                        DescribeAColumn(T, "idcab", ".CAB", -1);
                        DescribeAColumn(T, "cc", ".Conto", nPos++);
                        DescribeAColumn(T, "paymentdescr", ".Desc.Pag.", -1);
                        DescribeAColumn(T, "codeser", ".Cod. Prestazione", -1);
                        DescribeAColumn(T, "service", ".Prestazione", -1);
                        DescribeAColumn(T, "servicestart", ".Data Inizio Prest.", -1);
                        DescribeAColumn(T, "servicestop", ".Data Fine Prest.", -1);
                        DescribeAColumn(T, "ivaamount", ".Iva", -1);
                        DescribeAColumn(T, "fulfilled", ".Mov.Cop.", -1);
                        DescribeAColumn(T, "autotaxflag", ".Auto Rit.", -1);
                        DescribeAColumn(T, "autoclawbackflag", ".Auto rec.", -1);
                        DescribeAColumn(T, "autokind", ".Tipo Auto", -1);
                        DescribeAColumn(T, "flagarrear", ".Competenza", -1);
                        DescribeAColumn(T, "expiration", ".Data Scadenza", -1);
                        break;
                    }
            }
        }
    }
}