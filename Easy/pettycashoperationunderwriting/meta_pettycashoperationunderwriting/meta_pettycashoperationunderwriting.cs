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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_pettycashoperationunderwriting {
    public class Meta_pettycashoperationunderwriting : Meta_easydata {
        public Meta_pettycashoperationunderwriting(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "pettycashoperationunderwriting") {
            EditTypes.Add("default");
			EditTypes.Add("detail");
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
		}

        protected override Form GetForm(string FormName) {

            if (FormName == "detail") {
                Name = "Finanziamento piccola spesa";
                return MetaData.GetFormByDllName("pettycashoperationunderwriting_detail");//PinoRana
            }
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Finanziamento alle Operazioni Fondo Economale";
                return GetFormByDllName("pettycashoperationunderwriting_default");
            }

            return null;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "!codeunderwriting", "Finanziamento", "underwriting.codeunderwriting", nPos++);
                DescribeAColumn(T, "!underwriting", "Finanziamento", "underwriting.title", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;


            if (CfgFn.GetNoNullDecimal(R["idunderwriting"]) == 0) {
                errmess = "Non Ë stato selezionato il finanziamento";
                errfield = "idunderwriting";
                return false;
            }
            if (R["amount"] == DBNull.Value) {
                errmess = "Non Ë stato immesso l'importo del finanziamento";
                errfield = "amount";
                return false;
            }
            if (CfgFn.GetNoNullDecimal(R["amount"]) < 0) {
                errmess = "L'importo non puÚ essere negativo";
                errfield = "amount";
                return false;
            }


            return true;
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "pettycashopunderwritingview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
    }
}
