
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_accountlookupview
{
    /// <summary>
    /// Summary description for Meta_accountlookupview.
    /// </summary>
    public class Meta_accountlookupview : Meta_easydata
    {
        public Meta_accountlookupview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "accountlookupview")
        {
            Name = "Conversione Voci del Piano dei Conti Annuale";
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "oldidacc", "newidacc" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "oldidacc", "");
                DescribeAColumn(T, "oldayear", "Esercizio");
                DescribeAColumn(T, "oldcodeacc", "Codice Prec.");
                DescribeAColumn(T, "oldtitle", "Denominazione Prec.");
                DescribeAColumn(T, "newidacc", "");
                DescribeAColumn(T, "newcodeacc", "Codice Att.");
                DescribeAColumn(T, "newtitle", "Denominazione Att.");
            }
        }
    }
}
