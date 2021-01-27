
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_flussocreditidetail {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_flussocreditidetail : Meta_easydata {
        public Meta_flussocreditidetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "flussocreditidetail") {
            EditTypes.Add("single");
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("default_ca");
            ListingTypes.Add("default_fatt");
            ListingTypes.Add("default_unlinked");
            ListingTypes.Add("posting");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("flussocreditidetail_single");
            }
            if (FormName == "default") {
                Name = "Dettaglio Flusso crediti";
                return MetaData.GetFormByDllName("flussocreditidetail_default");
            }
            return null;
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {            
            T.setMySelector("iddetail", "idflusso", 0);
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            RowChange.setMinimumTempValue(T.Columns["iddetail"],999000);
            RowChange.MarkAsAutoincrement(T.Columns["idunivoco"], null, null,-1);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            MetaData.SetDefault(PrimaryTable, "flag", 0);
            base.SetDefaults(PrimaryTable);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default_fatt") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iddetail", "Num.Dettaglio", nPos++);
                DescribeAColumn(T, "!invkind", "Fattura", "invoicekind.description", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fattura", nPos++);
                DescribeAColumn(T, "invrownum", "Num.Riga Fatt.", nPos++);
                DescribeAColumn(T, "importoversamento", "Importo", nPos++);
                DescribeAColumn(T, "number", "quantità", nPos++);
                DescribeAColumn(T, "tax", "Iva", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "p_iva", "P.Iva", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "annulment", "Data annullamento", nPos++);
				DescribeAColumn(T, "annotations", "Annotazioni", nPos++);

			}
            if (listtype == "default_ca") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iddetail", "Num.Dettaglio", nPos++);
                DescribeAColumn(T, "!estimkind", "Tipo Contratto", "estimatekind1.description", nPos++);
                DescribeAColumn(T, "yestim", "Eserc.Contratto", nPos++);
                DescribeAColumn(T, "nestim", "Num.Contratto", nPos++);
                DescribeAColumn(T, "rownum", "Num.Riga", nPos++);
                DescribeAColumn(T, "importoversamento", "Importo", nPos++);
                DescribeAColumn(T, "number", "quantità", nPos++);
                DescribeAColumn(T, "tax", "Iva", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "p_iva", "P.Iva", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "annulment", "Data annullamento", nPos++);
				DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
			}
            if (listtype == "default_unlinked") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iddetail", "Num.Dettaglio", nPos++);
                DescribeAColumn(T, "importoversamento", "Importo", nPos++);
                DescribeAColumn(T, "number", "quantità", nPos++);
                DescribeAColumn(T, "tax", "Iva", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "p_iva", "P.Iva", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
			}
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if ((ListingType == "lista")|| (ListingType == "default"))
                return base.SelectOne(ListingType, filter, "flussocreditidetailview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "flussocreditidetail", Exclude);
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type.Equals("posting")) {
                // Calcola il numero di bollettino nel caso in cui non sia stato valorizzato
                if (DBNull.Value.Equals(R["iduniqueformcode"])) {
                    R["iduniqueformcode"] = $"easyfcred{R["idflusso"]:D14}{R["idreg"]:D10}";
                    return;
                }
                //potrebbe essere stato chiamato altre volte ma prima del calcolo definitivo dei campi ad autoincremento
                if (R.RowState==DataRowState.Added && (R["iduniqueformcode"].ToString().StartsWith("easyfcred"))) {
                    R["iduniqueformcode"] = $"easyfcred{R["idflusso"]:D14}{R["idreg"]:D10}";
                    return;
                }
            }
        }
    }
}
