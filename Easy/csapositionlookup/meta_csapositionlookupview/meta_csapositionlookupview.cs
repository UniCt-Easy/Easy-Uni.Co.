
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_csapositionlookupview {
    /// <summary>
    /// Summary description for meta_csapositionlookupview
    /// </summary>
    public class Meta_csapositionlookupview : Meta_easydata {
        public Meta_csapositionlookupview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "csapositionlookupview") {
            ListingTypes.Add("default");
            Name = "Look-Up Qualifiche";
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
				DescribeAColumn(T, "csa_compartment", "Comparto CSA", nPos++);
				DescribeAColumn(T, "csa_role", "Ruolo CSA", nPos++);
				DescribeAColumn(T, "csa_class", "Inquadramento CSA", nPos++);
				DescribeAColumn(T, "csa_description", "Desr.CSA", nPos++);
				DescribeAColumn(T, "codeposition", "Qualifica Easy", nPos++);
                DescribeAColumn(T, "livello", "Livello Easy", nPos++);
                DescribeAColumn(T, "inquadramento", "Inquadramento Easy",  nPos++);
				DescribeAColumn(T, "supposedtaxable", "Imponibile presunto", nPos++);
			}
        }
    }
}
