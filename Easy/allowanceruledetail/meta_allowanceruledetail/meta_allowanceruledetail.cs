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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_allowanceruledetail {
    public class Meta_allowanceruledetail : Meta_easydata {
        public Meta_allowanceruledetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "allowanceruledetail") {
            EditTypes.Add("single");
            ListingTypes.Add("single");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Dettaglio per classi stipendiali";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("allowanceruledetail_single");
            }
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idallowancerule");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                DescribeAColumn(T, "idallowancerule", "Id.regola");
                DescribeAColumn(T, "iddetail", "Id.dettaglio");
                DescribeAColumn(T, "idposition", "");
                DescribeAColumn(T, "!qualifica", "Qualifica", "position.description");
                DescribeAColumn(T, "minincomeclass", "Min.classe stip.");
                DescribeAColumn(T, "maxincomeclass", "Max.classe stip.");
                DescribeAColumn(T, "amount", "Importo");
                DescribeAColumn(T, "advancepercentage", "Perc.anticipo");
                HelpForm.SetFormatForColumn(T.Columns["advancepercentage"], "p");
            }
            return;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            DataRow rPosition = R.GetParentRow("position_allowanceruledetail");
            int minincomeclass = CfgFn.GetNoNullInt32(R["minincomeclass"]);
            int maxincomeclass = CfgFn.GetNoNullInt32(R["maxincomeclass"]);
            int max = CfgFn.GetNoNullInt32(rPosition["maxincomeclass"]);
            if (minincomeclass < 0) {
                errmess = "La classe minima deve essere maggiore o uguale a zero";
                errfield = "minincomeclass";
                return false;
            }
            if (minincomeclass > maxincomeclass) {
                errmess = "La classe minima deve essere <= della classe massima";
                errfield = "minincomeclass";
                return false;
            }
            if (maxincomeclass > max) {
                errmess = "Per la qualifica '" + rPosition["description"] + "' la massima classe stipendiale Ë " + max;
                errfield = "maxincomeclass";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }
    }
}
