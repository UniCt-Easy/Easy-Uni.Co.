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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_itinerationauthagency
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_itinerationauthagency : Meta_easydata 
	{
        public Meta_itinerationauthagency (DataAccess Conn, MetaDataDispatcher Dispatcher):
        base(Conn, Dispatcher, "itinerationauthagency") {		
			ListingTypes.Add("default");
            ListingTypes.Add("webdefault");
		}



        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flagstatus", "D");
        }

        public override void CalculateFields (DataRow R, string list_type) {
            if (R["flagstatus"].ToString().ToUpper() == "S") {
                R["!status"] = "Approvata";
            }
            else {
                if (R["flagstatus"].ToString().ToUpper() == "N") {
                    R["!status"] = "Non Approvata";
                }
                else {
                    R["!status"] = "Da Esaminare";
                }
            }
         }

        public override string GetSorting(string ListingType)
        {
            if (ListingType == "webdefault") return "!priority asc";
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "iditineration", ".#", nPos++);
                DescribeAColumn(T, "!title", "Denominazione", "authagency.title", nPos++);
                DescribeAColumn(T, "!description", "Descrizione", "authagency.description", nPos++);
                DescribeAColumn(T, "!status", "Stato Aut.", nPos++);
                DescribeAColumn(T, "flagstatus", ".Stato", nPos++);
                DescribeAColumn(T, "annotationsrejectapproval", "Annotazioni Rifiuto/Approvazione", nPos++);
                ComputeRowsAs(T, "default");
            }

            if (ListingType == "webdefault")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!title", "Denominazione", "authagency.title", nPos++);
                DescribeAColumn(T, "!description", "Descrizione", "authagency.description", nPos++);
                DescribeAColumn(T, "!status", "Stato Aut.", nPos++);
                //DescribeAColumn(T, "!priority", "Priorit‡", "authagency.priority", nPos++);
                ComputeRowsAs(T, "default");
            }


        }

	}
	
}
