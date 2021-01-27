
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


namespace meta_taxratecitystartview
{
    public class Meta_taxratecitystartview : Meta_easydata
    {
        public Meta_taxratecitystartview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "taxratecitystartview")
        {
            ListingTypes.Add("default");
        }
       
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            int nPos = 1;
            DescribeAColumn(T, "city", "Comune", nPos++);
            DescribeAColumn(T, "country", "Provincia", nPos++);
            DescribeAColumn(T, "start","Data decorrenza", nPos++);
            DescribeAColumn(T, "idtaxratecitystart", "#", nPos++);
            DescribeAColumn(T, "taxablemin", "q.esente", nPos++);
            if (T.Columns.Contains("rate1")) {
	            HelpForm.SetFormatForColumn(T.Columns["rate1"],"p");
	            DescribeAColumn(T, "rate1", "aliq.1", nPos++);
            }
            DescribeAColumn(T, "max1", "I scagl.", nPos++);
            if (T.Columns.Contains("rate2")) {
	            HelpForm.SetFormatForColumn(T.Columns["rate2"],"p");
	            DescribeAColumn(T, "rate2", "aliq.1", nPos++);
            }
            DescribeAColumn(T, "max2", "II scagl.", nPos++);
            if (T.Columns.Contains("rate3")) {
	            HelpForm.SetFormatForColumn(T.Columns["rate3"],"p");
	            DescribeAColumn(T, "rate3", "aliq.3", nPos++);
            }
            DescribeAColumn(T, "max3", "III scagl", nPos++);
            if (T.Columns.Contains("rate4")) {
	            HelpForm.SetFormatForColumn(T.Columns["rate4"],"p");
	            DescribeAColumn(T, "rate4", "aliq.4", nPos++);
            }
            DescribeAColumn(T, "max4", "IV scagl", nPos++);
            if (T.Columns.Contains("rate5")) {
	            HelpForm.SetFormatForColumn(T.Columns["rate5"],"p");
	            DescribeAColumn(T, "rate5", "aliq.5", nPos++);
            }
            DescribeAColumn(T, "max5", "V scagl", nPos++);
            DescribeAColumn(T, "annotations", "Annotazioni", nPos++);


        }
        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "city ASC,start DESC,idtaxratecitystart DESC";
            }
            return base.GetSorting(ListingType);
        }
    }
}
