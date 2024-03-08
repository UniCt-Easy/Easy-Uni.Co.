
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
    public partial class dsmeta_estimatedetail_single :DataSet, IDataSetInit {
        public void initCustom(Dispatcher dispatcher) {
            HelpForm.SetDenyNull(estimatedetail.Columns["toinvoice"], true);
            HelpForm.SetDenyNull(estimatedetail.Columns["tax"], true);

            DataAccess.SetTableForReading(finmotive_income, "finmotive");


            DataAccess.SetTableForReading(sorting1, "sorting");
            DataAccess.SetTableForReading(sorting2, "sorting");
            DataAccess.SetTableForReading(sorting3, "sorting");
            DataAccess.SetTableForReading(income_imponibile, "income");
            DataAccess.SetTableForReading(income_iva, "income");
            DataAccess.SetTableForReading(accmotiveappliedannulment, "accmotiveapplied");
            DataAccess.SetTableForReading(upb_iva, "upb");
        }
    }
}
