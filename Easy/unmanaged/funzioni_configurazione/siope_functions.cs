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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace funzioni_configurazione {
    public class siope_finder {
        IDataAccess Conn;
        QueryHelper QHS;
        object idsorkindE;
        object idsorkindS;
                
        public siope_finder(IDataAccess conn) {
            this.Conn = conn;
            QHS = Conn.GetQueryHelper();
            idsorkindE = Conn.DO_READ_VALUE("sortingkind",
                QHS.CmpEq("codesorkind", "SIOPE_E_18"), "idsorkind");
            idsorkindS = Conn.DO_READ_VALUE("sortingkind",
                QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind");
        }

        public siope_finder(DataAccess conn) {
            this.Conn = conn;
            QHS = Conn.GetQueryHelper();
            idsorkindE = Conn.DO_READ_VALUE("sortingkind",
                QHS.CmpEq("codesorkind", "SIOPE_E_18"), "idsorkind");
            idsorkindS = Conn.DO_READ_VALUE("sortingkind",
                QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind");
        }



        /// <summary>
        /// Restituisce le righe di class siope associate alla causale EP, o NULL se la causale è multi-classificata
        /// </summary>
        /// <param name="idaccmotive"></param>
        /// <param name="spese"></param>
        /// <returns></returns>
        public DataRow[] getSiopeForAccmotive(object idaccmotive,bool spese) {
            if (idaccmotive == null || idaccmotive==DBNull.Value) {
                //Ho cancellato la causale, azzero il siope.
                return null;
            }

            string filterClassEsistenti = filterForAccmotive(idaccmotive,spese);
            DataTable tAccmotivesortingview =
                    Conn.RUN_SELECT("accmotivesortingview", "idsor", null, filterClassEsistenti, null, false);
            if (tAccmotivesortingview.Rows.Count>0) return tAccmotivesortingview.Select();
            filterClassEsistenti = filterForAccmotive(idaccmotive, !spese);
            tAccmotivesortingview = Conn.RUN_SELECT("accmotivesortingview", "idsor", null, filterClassEsistenti, null, false);
            return tAccmotivesortingview.Select();
        }




        // filtro per scegliere il codice siope associato alla causale EP
        public string filterForAccmotive(object idaccmotive,bool spese) {
            return QHS.AppAnd(QHS.CmpEq("idsorkind", spese?idsorkindS:idsorkindE),
                QHS.CmpEq("idaccmotive", idaccmotive));
        }
    }
}
