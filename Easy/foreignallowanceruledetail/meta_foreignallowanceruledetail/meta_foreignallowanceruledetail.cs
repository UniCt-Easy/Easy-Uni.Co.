
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

namespace meta_foreignallowanceruledetail {
    public class Meta_foreignallowanceruledetail : Meta_easydata {
        public Meta_foreignallowanceruledetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "foreignallowanceruledetail") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Dettaglio per gruppi";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("foreignallowanceruledetail_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idforeignallowancerule");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                DescribeAColumn(T, "idforeignallowancerule", "Id.regola");
                DescribeAColumn(T, "iddetail", "Id.dettaglio");
                DescribeAColumn(T, "minforeigngroupnumber", "Min.gruppo");
                DescribeAColumn(T, "maxforeigngroupnumber", "Max gruppo");
                DescribeAColumn(T, "amount", "Importo");
                DescribeAColumn(T, "advancepercentage", "Perc.anticipo");
                HelpForm.SetFormatForColumn(T.Columns["advancepercentage"], "p");
            }
            return;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            int minforeigngroupnumber = CfgFn.GetNoNullInt32(R["minforeigngroupnumber"]);
            int maxforeigngroupnumber = CfgFn.GetNoNullInt32(R["maxforeigngroupnumber"]);
            if (minforeigngroupnumber > maxforeigngroupnumber) {
                errmess = "Il minimo numero del gruppo deve essere <= del massimo";
                errfield = "minforeigngroupnumber";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }
    }
}
