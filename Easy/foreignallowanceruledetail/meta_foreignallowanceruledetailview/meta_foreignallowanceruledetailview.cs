
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
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_foreignallowanceruledetailview {
    class Meta_foreignallowanceruledetailview : Meta_easydata {
        public Meta_foreignallowanceruledetailview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "foreignallowanceruledetailview") {
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idforeignallowancerule", "Id.regola", nPos++);
                DescribeAColumn(T, "iddetail", "Id.dettaglio", nPos++);
                DescribeAColumn(T, "foreigncountry", "Località Estera", nPos++);
                DescribeAColumn(T, "minforeigngroupnumber", "Min. Gruppo Estero", nPos++);
                DescribeAColumn(T, "maxforeigngroupnumber", "Max. Gruppo Estero", nPos++);
                DescribeAColumn(T, "amount", "Importo Diaria", nPos++);
                DescribeAColumn(T, "advancepercentage", "% di Anticipo", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["advancepercentage"], "p");
            }
            return;
        }
    }
}
