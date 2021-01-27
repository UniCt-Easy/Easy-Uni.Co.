
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace security_function {
    public class Sec_Function {

        /// <summary>
        /// Metodo che data una funzione di restrizione, ritorna se si ha il diritto di effettuare una certa operazione
        /// </summary>
        /// <param name="DA">DataAccess corrente</param>
        /// <param name="funName">Nome della funzione di restrizione</param>
        /// <returns></returns>
        public static bool funzioneConsentita(DataAccess DA, object funName) {
            object idFlowChart = DA.GetSys("idflowchart");
            if ((idFlowChart == null) || (idFlowChart == DBNull.Value)) return true;
            QueryHelper QHS = DA.GetQueryHelper();

            object idResFun = DA.DO_READ_VALUE("restrictedfunction",
                QHS.CmpEq("variablename", funName), "idrestrictedfunction");

            // Se la funzione passata come parametro non esiste ti vieto di fare l'operazione
            if ((idResFun == null) || (idResFun == DBNull.Value)) return false;

            string filter = QHS.AppAnd(QHS.CmpEq("idflowchart", idFlowChart), QHS.CmpEq("idrestrictedfunction", idResFun));
            int n = DA.RUN_SELECT_COUNT("flowchartrestrictedfunction", filter, true);
            return (n > 0);
        }
    }
}
