
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_intrastatcodeview
{
	/// <summary>
	/// </summary>
    public class Meta_intrastatcodeview : Meta_easydata {

        public Meta_intrastatcodeview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :base(Conn, Dispatcher, "intrastatcodeview") {
            ListingTypes.Add("default");
        }
	    private string[] mykey = new string[] { "idintrastatcode"};
	    public override string[] primaryKey() {
	        return mykey;
	    }
        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "code", "# Nomenclatura", nPos++);
                DescribeAColumn(T, "description", "Nomenclatura", nPos++);
                DescribeAColumn(T, "measurecode", "# Unità di misura", nPos++);
                DescribeAColumn(T, "measuredescription", "Unità di misura", nPos++);
            }
        }
    }

    }

