
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Data;

namespace meta_itinerationauthview
{
    public class Meta_itinerationauthview:Meta_easydata
    {
        public Meta_itinerationauthview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
        base(Conn, Dispatcher, "itinerationauthview") {		
			ListingTypes.Add("default");
            EditTypes.Add("default");
            Name = "Autorizzazione Missione";
		}

        static string[] mykey = new string[] { "iditineration","idauthagency" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "statusimage", "Stato Missione", nPos++);
                DescribeAColumn(T, "nitineration", "N.", nPos++);
                DescribeAColumn(T, "yitineration", "Anno", nPos++);
                DescribeAColumn(T, "authstatusimage", "Autorizzazione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "annotationsrejectapproval_prec", "Nota agente prec.", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "managertitle", "Responsabile", nPos++);
               
            }
        }

        public override string GetNoRowFoundMessage(string listingtype){
            return "Non ci sono (altre) missioni in attesa di autorizzazione.";
        }
    }
}
