
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
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;


namespace meta_mandatekindsorting {
    public class Meta_mandatekindsorting : Meta_easydata {
        public Meta_mandatekindsorting(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "mandatekindsorting") {
            EditTypes.Add("detail");
            ListingTypes.Add("default");
            Name = "Classificazione Tipo Contratto Passivo";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "detail") {
                return GetFormByDllName("mandatekindsorting_detail");
            }
            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            decimal quota = CfgFn.GetNoNullDecimal(R["quota"]);
            if (quota < 0 || quota > 1) {
                errmess = "Quota non valida";
                errfield = "quota";
                return false;
            }
            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            //DescribeAColumn(T, "idsorkind", "Tipo");
            DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind");
            DescribeAColumn(T, "idsor", "");
            DescribeAColumn(T, "idmankind", "");
            DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode");
            DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description");
            DescribeAColumn(T, "quota", "Quota");
            HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
        }
    }
}
