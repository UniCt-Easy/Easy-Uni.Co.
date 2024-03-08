
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
using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Backend.Data {
    public partial class dsmeta_registry_anagraficaweb:DataSet, IDataSetInit {
        /// <summary>
        /// 
        /// </summary>
        public void initCustom(Dispatcher dispatcher) {
            var Meta = dispatcher.GetMeta("registry");
            var QHS = dispatcher.QueryHelper;


            GetData.SetStaticFilter(sortingview, QHS.CmpEq("ayear", "2019"));
            GetData.SetStaticFilter(specialcategory770, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(registryspecialcategory770, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(registry, Meta.GetFilterForSearch(registry));
            Meta.StartFilter = Meta.GetFilterForSearch(registry);
            

            HelpForm.SetDenyNull(registry.Columns["authorization_free"], true);
            HelpForm.SetDenyNull(registry.Columns["multi_cf"], true);
            HelpForm.SetDenyNull(registry.Columns["flagbankitaliaproceeds"], true);
            HelpForm.SetDenyNull(registry.Columns["flag_pa"], true);
            HelpForm.SetDenyNull(registry.Columns["sdi_norifamm"], true);

            HelpForm.SetDenyZero(registry.Columns["residence"], true);

            string filterEpOperationCred = QHS.CmpEq("idepoperation", "registry_cred");
            GetData.SetStaticFilter(accmotiveapplied_credit, filterEpOperationCred);
            accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "registry_deb");
            GetData.SetStaticFilter(accmotiveapplied_debit, filterEpOperationDeb);
            accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            
            accmotiveapplied_debit.setTableForReading("accmotiveapplied");
            accmotiveapplied_credit.setTableForReading("accmotiveapplied");
            geo_nazione_alias.setTableForReading("geo_nation");

        }
    }
}
