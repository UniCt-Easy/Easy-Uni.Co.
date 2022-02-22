
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_itinerationrefundruledetailview {
    class Meta_itinerationrefundruledetailview  : Meta_easydata {
        public Meta_itinerationrefundruledetailview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "itinerationrefundruledetailview") {
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iditinerationrefundrule", "Id.regola", nPos++);
                DescribeAColumn(T, "iddetail", "Id.dettaglio", nPos++);
                DescribeAColumn(T, "itinerationrefundkindgroup", "Macro Classe", nPos++);
                DescribeAColumn(T, "position", "Qualifica", nPos++);
                DescribeAColumn(T, "minincomeclass", "Min.classe stip.", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Max.classe stip.", nPos++);
                DescribeAColumn(T, "flag_italy", "Italia", nPos++);
                DescribeAColumn(T, "flag_eu", "Unione Europea", nPos++);
                DescribeAColumn(T, "flag_extraeu", "Extra UE", nPos++);
                DescribeAColumn(T, "nhour_min", "Min. ore", nPos++);
                DescribeAColumn(T, "nhour_max", "Max. ore", nPos++);
                DescribeAColumn(T, "limit", "Limite", nPos++);
                DescribeAColumn(T, "advancepercentage", "Perc.anticipo", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["advancepercentage"], "p");
            }
            return;
        }
    }
}
