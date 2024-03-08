
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


using System.Collections;
using System.Data;

namespace HubConnector
{
    public static class Extentions
    {
        /// <summary>
        /// Converte una DataRow in una Hashtable.
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Hashtable contenente i dati della DataRow.</returns>
        public static Hashtable ToHashtable(this DataRow row)
        {

            Hashtable tmpTable = new Hashtable();

            // scrittura dei valori dei campi della DataRow nella Hashtable
            foreach (DataColumn col in row.Table.Columns)
            {
                tmpTable.Add(col.ColumnName, row[col.ColumnName]);
            }

            return tmpTable;
        }
    }
}
