
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_pccdebitstatusdetail {
    public class Meta_pccdebitstatusdetail : Meta_easydata {
        public Meta_pccdebitstatusdetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "pccdebitstatusdetail") {
            EditTypes.Add("detail");
            ListingTypes.Add("detail");
            Name = "Stato del debito dettagliato";
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "detail") return GetFormByDllName("pccdebitstatusdetail_detail");
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idinvkind");
            RowChange.SetSelector(T, "yinv");
            RowChange.SetSelector(T, "ninv");
            RowChange.MarkAsAutoincrement(T.Columns["idpccdebitstatusdetail"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "detail") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idpccdebitstatusdetail", "Num.Riga Stato debito", nPos++);
                DescribeAColumn(T, "idpcc", "N.Trasmissione", nPos++);

                DescribeAColumn(T, "imp_nonliquidabile", "Imp. NoLiq", nPos++);
                DescribeAColumn(T, "iva_nonliquidabile", "Iva NoLiq", nPos++);

                DescribeAColumn(T, "imp_sosp_contenzioso", "Imp.SOSP contenziono", nPos++);
                DescribeAColumn(T, "iva_sosp_contenzioso", "Iva SOSP contenzioso", nPos++);
                DescribeAColumn(T, "start_sosp_contenzioso", "Data SOSP in contenzioso", nPos++);

                DescribeAColumn(T, "imp_sosp_contestazione", "Imp.SOSP per contestazione", nPos++);
                DescribeAColumn(T, "iva_sosp_contestazione", "Iva SOSP per contestazione", nPos++);
                DescribeAColumn(T, "start_sosp_contestazione", "Data SOSP per contestazione", nPos++);

                DescribeAColumn(T, "imp_sosp_regolareverifica", "Imp.SOSP regolare verifica", nPos++);
                DescribeAColumn(T, "iva_sosp_regolareverifica", "Iva SOSP regolare verifica", nPos++);
                DescribeAColumn(T, "start_sosp_regolareverifica", "Data SOSP regolare verifica", nPos++);
                
                DescribeAColumn(T, "importononcommerciale", " Importo non commerciale", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
 
            if (
                (CfgFn.GetNoNullDecimal(R["imp_sosp_contenzioso"])>0 || CfgFn.GetNoNullDecimal(R["iva_sosp_contenzioso"])>0)
                && 
                R["start_sosp_contenzioso"] == DBNull.Value){
                errmess = "Attenzione! Specificare: Data inizio sospensione in Contenzioso";
                return false;
            }

            if (
                (CfgFn.GetNoNullDecimal(R["imp_sosp_contestazione"]) > 0 || CfgFn.GetNoNullDecimal(R["iva_sosp_contestazione"]) > 0)
                &&
                   R["start_sosp_contestazione"] == DBNull.Value) {
                errmess = "Attenzione! Specificare: Data inizio sospensione per Contestazione/Adempimenti Normativi";
                return false;
            }

            if (
                (CfgFn.GetNoNullDecimal(R["imp_sosp_regolareverifica"]) > 0 || CfgFn.GetNoNullDecimal(R["iva_sosp_regolareverifica"]) > 0)
                &&
                   R["start_sosp_regolareverifica"] == DBNull.Value) {
                errmess = "Attenzione! Specificare: Data inizio sospensione per data esito regolare verifica di conformità";
                return false;
            }

            return true;
        }
    }
}
