/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

namespace siope_functions {
    public class siope_finder {
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        object idsorkindE;
        object idsorkindS;
        MetaData Meta;
        DataRow Curr;
        MetaDataDispatcher Disp;
        DataSet DS;
        public siope_finder(MetaData Meta, DataRow Curr) {
            this.Meta = Meta;
            this.Disp = Meta.Dispatcher;
            this.DS = Meta.DS;
            this.Conn = Meta.Conn;
            this.Curr = Curr;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            idsorkindE = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Conn.GetSys("codesorkind_siopeentrate")), "idsorkind");
            idsorkindS = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Conn.GetSys("codesorkind_siopespese")), "idsorkind");
        }

        //public bool ExistSiope(object idaccmotive) {
        //    string filterClassEsistenti = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkindS), QHC.CmpEq("idaccmotive", idaccmotive));
        //    int N = Conn.RUN_SELECT_COUNT("accmotivesortingview", filterClassEsistenti, false);
        //    if (N > 1) {
        //        return true; 
        //    }
        //    else {
        //        return false;
        //    }
        //}

        //Restituisce Siope associato alla causale EP, o NULL se la causale è multi-classificata
        public DataRow SelectedSiopeRowAndValorize(DataRow rAccmotiveapplied) {
            if (rAccmotiveapplied == null) {
                //Ho cancellato la causale, azzero il siope.
                Curr["idsor_siope"] = DBNull.Value;
                return null;
            }
            if (Curr["idsor_siope"] == DBNull.Value) {
                string filterClassEsistenti = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkindS), QHC.CmpEq("idaccmotive", rAccmotiveapplied["idaccmotive"]));
                DataTable tAccmotivesortingview = Conn.RUN_SELECT("accmotivesortingview", "*", null, filterClassEsistenti, null, false);
                int countClassSiope = tAccmotivesortingview.Select().Length;
                if (countClassSiope == 1) {
                    DataRow rAccmotivesortingview = tAccmotivesortingview.Select()[0];
                    DataTable tSorting = Conn.RUN_SELECT("sorting", "*", null, QHS.CmpEq("idsor", rAccmotivesortingview["idsor"]), null, false);
                    DataRow rSorting = tSorting.Select()[0];
                    Curr["idsor_siope"] = rSorting["idsor"];
                    return rSorting;
                }
            }
            return null;
        }

        //Sceglie il cod. Siope, associato alla causale EP, tramite un filtro costruito nella FilterForSiopeSelected
        public DataRow SelectedSiopeRowByFilterAndValorize() {
            // Metodo chiamato dal Button per la selezione del Siope 
            string filterClassEsistenti = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkindS), QHC.CmpEq("idaccmotive", Curr["idaccmotive"]));
            DataTable tAccmotivesortingview = Conn.RUN_SELECT("accmotivesortingview", "*", null, filterClassEsistenti, null, false);
            int countClassSiope = tAccmotivesortingview.Select().Length;
            if (countClassSiope == 1) {
                DataRow rAccmotivesortingview = tAccmotivesortingview.Select()[0];
                DataTable tSorting = Conn.RUN_SELECT("sorting", "*", null, QHS.CmpEq("idsor", rAccmotivesortingview["idsor"]), null, false);
                DataRow rSorting = tSorting.Select()[0];
                Curr["idsor_siope"] = rSorting["idsor"];
                return rSorting;
            }
            else {
                string VistaScelta = "sortingview";
                MetaData Msortingview = Disp.Get(VistaScelta);
                Msortingview.FilterLocked = true;
                Msortingview.DS = DS;
                string listaIdsor = QHS.DistinctVal(tAccmotivesortingview.Select(), "idsor");
                string filteridsor = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")), QHS.FieldInList("idsor", listaIdsor));

                DataRow rSortingview = Msortingview.SelectOne("default", filteridsor, null, null);
                if (rSortingview != null) {
                    Curr["idsor_siope"] = rSortingview["idsor"];
                    return rSortingview;
                }
            }
            return null;
        }
        // filtro per scegliere il codice siope associato alla causale EP
        public string FilterForSiopeSelected(object idaccmotive) {
            return null;
        }
    }
}
