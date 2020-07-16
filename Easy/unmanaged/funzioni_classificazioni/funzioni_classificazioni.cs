/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;

namespace funzioni_classificazioni {
    class funzioni_classificazioni {
        CQueryHelper QHC;
        QueryHelper QHS;
        Dictionary<string, int> MySorting;

        public funzioni_classificazioni(DataAccess Conn) {
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            MySorting = new Dictionary<string, int>();
        }

        public int GetidSor(DataAccess Conn,int tipoclass, string codice) {
        object idsor = DBNull.Value;
        string code = CleanCode(codice);
        if (ExistsCode(code)) {
            idsor = MySorting[codice];
                if (Convert.ToInt32(idsor) != -1) { 
                    return -1; 
                }
                else {
                    return Convert.ToInt32(idsor);
                }
            }
            else {
                idsor = Conn.DO_READ_VALUE("sorting",
                        QHS.AppAnd(QHS.CmpEq("idsorkind", tipoclass),
                        QHS.CmpEq("sortcode", code)
                        ), "idsor", null);
                if (idsor != null && idsor != DBNull.Value) {
                    MySorting[code] = Convert.ToInt32(idsor);
                    return Convert.ToInt32(idsor);
                }
                else {
                    MySorting[code] = -1;
                    return -1;
                }
            }
    }
        public string CleanCode(string codice) {
            string code = codice.ToString().ToUpper();
            code = code.ToString().Trim();
            return code;
        }

        public bool ExistsCode(string code) {
        if (MySorting.ContainsKey(code)) {
            return true;
            }
            else{
                return false;
            }
        }


    }
    }

