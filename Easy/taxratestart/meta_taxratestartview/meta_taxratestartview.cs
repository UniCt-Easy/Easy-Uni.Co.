
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_taxratestartview
{
    public class Meta_taxratestartview : Meta_easydata
    {
        public Meta_taxratestartview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "taxratestartview")
        {
            ListingTypes.Add("default");
        }
      
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            int nPos = 1;
            DescribeAColumn(T, "taxref", "Cod. Imposta",nPos++);
            DescribeAColumn(T, "tax", "Descrizione", nPos++);
            DescribeAColumn(T, "start", "Data decorrenza", nPos++);
            DescribeAColumn(T, "enforcement", "Tipo applicazione", nPos++);
            DescribeAColumn(T, "taxablenumerator", "Num.Impon.", nPos++);
            DescribeAColumn(T, "taxabledenominator", "Den.Impon.", nPos++);
            HelpForm.SetFormatForColumn(T.Columns["taxablenumerator"], "n");
            HelpForm.SetFormatForColumn(T.Columns["taxabledenominator"], "n");
        }
    }
}
