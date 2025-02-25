
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afiprotfat_unict.Models {
    public class Config {

        public Uri Endpoint { get; set; }
        public string Channel { get; set; }
        public string Operator { get; set; }
        public int AttachmentkindId { get; set; }
        public int AddressId { get; set; }

        //https://http://ws1.unict.it/afiprotfat/test/|mail|fattura|1|7

        public Config(DataRow app_configRow) {

            var columnNames = new HashSet<string> { "code", "ct", "cu", "description", "flag", "lt", "lu", "param" };

            var tableColumnNames = new HashSet<string>(app_configRow.Table.Columns.Cast<DataColumn>().Select(col => col.ColumnName));

            if (!columnNames.IsSubsetOf(tableColumnNames)) {

                throw new Exception($"Invalid configuration, missing {string.Join(", ", columnNames.Except(tableColumnNames))}");
            }

            var values = app_configRow["param"].ToString().Split('|');

            try {

                Endpoint = new Uri(values[0]);
                Channel = values[1];
                Operator = values[2];
                AttachmentkindId = int.Parse(values[3]);
                AddressId = int.Parse(values[4]);
            }
            catch (Exception e) {

                throw new Exception($"Invalid configuration: {e.Message}", e);
            }
        }
    }
}
