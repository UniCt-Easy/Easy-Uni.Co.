
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


using Backend.CommonBackend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using metadatalibrary;
using ep_functions;

namespace Backend.Data {
    public partial class dsmeta_estimate_default: DataSet, IDataSetInit {
        public void initCustom(Dispatcher dispatcher) {
            var Meta = dispatcher.GetMeta("accmotiveapplied");
            var QHS = dispatcher.QueryHelper;
            string filter = Meta.ExtraParameter as string;

            HelpForm.SetDenyNull(estimate.Columns["active"], true);
            upb_detail.setTableForReading("upb");

            GetData.CacheTable(config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            HelpForm.SetFormatForColumn(estimatedetail.Columns["number"], "N");
            HelpForm.SetDenyNull(estimate.Columns["flagintracom"], true);
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Meta.Conn);
            GetData.SetStaticFilter(accmotiveapplied_credit, filterEpOperationCred);
            GetData.SetStaticFilter(accmotiveapplied_crg, filterEpOperationCred);
            DataAccess.SetTableForReading(accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(accmotiveapplied_credit, "accmotiveapplied");
            accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;
            accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            GetData.SetStaticFilter(expirationkind, QHS.CmpNe("kind", "A"));

            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(sortingview, filtereserc);


            DataAccess.SetTableForReading(sorting01, "sorting");
            DataAccess.SetTableForReading(sorting02, "sorting");
            DataAccess.SetTableForReading(sorting03, "sorting");
            DataAccess.SetTableForReading(sorting04, "sorting");
            DataAccess.SetTableForReading(sorting05, "sorting");

            estimatesorting.ExtendedProperties["ViewTable"] = estimatesortingview;
            sortingview.ExtendedProperties["ViewTable"] = estimatesortingview;
            estimatesortingview.ExtendedProperties["RealTable"] = estimatesorting;

            foreach (DataColumn C in estimatesorting.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                estimatesortingview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "estimatesorting." + C.ColumnName;
            }

            estimatesortingview.Columns["sortingkind"].ExtendedProperties["ViewSource"] = "sortingview.sortingkind";
            estimatesortingview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sortingview.sortcode";
            estimatesortingview.Columns["sorting"].ExtendedProperties["ViewSource"] = "sortingview.description";

            estimatedetail.ExtendedProperties["ViewTable"] = estimatedetailview;
            registry.ExtendedProperties["ViewTable"] = estimatedetailview;
            ivakind.ExtendedProperties["ViewTable"] = estimatedetailview;
            upb_detail.ExtendedProperties["ViewTable"] = estimatedetailview;
            estimatedetailview.ExtendedProperties["RealTable"] = estimatedetail;

            foreach (DataColumn C in estimatedetail.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                estimatedetailview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "estimatedetail." + C.ColumnName;
            }

            estimatedetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb_detail.codeupb";
            estimatedetailview.Columns["ivakind"].ExtendedProperties["ViewSource"] = "ivakind.description";
            estimatedetailview.Columns["registry"].ExtendedProperties["ViewSource"] = "registry.title";
            
        }
    }

}
