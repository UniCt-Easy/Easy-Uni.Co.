/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metaeasylibrary;
using metadatalibrary;

namespace notable_importazione {
    class SortingHash {
        Dictionary<string, int> DSorting;
        
        public void Clear() {
            DSorting.Clear();            
        }
        public int tipoclass;
        public SortingHash(DataAccess Conn, int tipoclass) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string filterKind = QHS.CmpEq("idsorkind", tipoclass);
            DSorting = new Dictionary<string, int>();
            this.tipoclass = tipoclass;
            if (tipoclass == 0) return;
            DataTable Sort = Conn.RUN_SELECT("sorting", "sortcode, idsor", null, filterKind, null, false);
            foreach (DataRow SortRow in Sort.Rows)
                DSorting[CleanCode(SortRow["sortcode"].ToString())] = Convert.ToInt32(SortRow["idsor"]);
            
        }

        public object GetidSor(object codice) {
            if (codice == DBNull.Value || codice==null) return DBNull.Value;
            if (codice.ToString() == "") return DBNull.Value;
            string code = CleanCode(codice.ToString());
            if (ExistsCode(code)) {
                return DSorting[code];
            }
            else {
                return DBNull.Value;
            }
        }

        public string CleanCode(string codice) {
            return codice.Trim().ToUpper();
        }

        public bool ExistsCode(string code) {
            return DSorting.ContainsKey(CleanCode(code));
        }


    }
}

