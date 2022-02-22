
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
using funzioni_configurazione;

namespace meta_bookingdetailview
{
    public class Meta_bookingdetailview:Meta_easydata
    {
        public Meta_bookingdetailview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "bookingdetailview")
        {
            ListingTypes.Add("list");
            ListingTypes.Add("default");
            Name = "Prenotazioni";
        }

        private string[] mykey = new string[] { "idbooking","idlist","idstore" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetNoRowFoundMessage(string listingtype) {
            if (listingtype == "list") {
                return "Non ci sono (altre) prenotazioni in attesa di autorizzazione.";
            }
            return base.GetNoRowFoundMessage(listingtype);
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "list")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "ybooking", "Esercizio",nPos++);
                DescribeAColumn(T, "nbooking", "Progressivo", nPos++);
                DescribeAColumn(T, "intcode", "Cod. Art.", nPos++);
                DescribeAColumn(T,"list","Descrizione",nPos++);
                DescribeAColumn(T, "number", "Quantità", nPos++);
                DescribeAColumn(T, "listclass", "Class. Merceologica", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "authorizedimg", "Autorizzato", nPos++);
          
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
            }

            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "ybooking", "Esercizio", nPos++);
                DescribeAColumn(T, "nbooking", "Progressivo", nPos++);
                DescribeAColumn(T, "intcode", "Cod. Art.", nPos++);
                DescribeAColumn(T, "list", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Quantità", nPos++);
                DescribeAColumn(T, "fulfilled", "Evasa", nPos++);
                DescribeAColumn(T, "listclass", "Class. Merceologica", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);

                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                HelpForm.SetFormatForColumn(T.Columns["fulfilled"], "n");	
            }

        }

        public override string GetSorting(string ListingType)
        {
            string sorting;
            if (ListingType == "list")
            {
                sorting = "ybooking desc,nbooking desc, list asc, listclass asc, store asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

    }
}
