
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


using Backend.CommonBackend;
using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Backend.Data {
    public partial class dsmeta_estimatesorting_default :DataSet, IDataSetInit {
        public void initCustom(Dispatcher dispatcher) {

            var Meta = dispatcher.GetMeta("estimatesorting");
            var QHS = dispatcher.QueryHelper;
            string filterCT = QHS.CmpEq("tablename", "estimate");
            GetData.CacheTable(sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            // CAPIRE come portare quesat riga: per ora emsso come staticFilter
            // QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
            sortingapplicabilityview.setStaticFilter(filterI);

        }
    }
}
