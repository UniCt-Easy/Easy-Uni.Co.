
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;
                               
namespace meta_expenselastmandatedetail
{
    public class Meta_expenselastmandatedetail : Meta_easydata {
        public Meta_expenselastmandatedetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "expenselastmandatedetail") {
        }

protected override Form GetForm(string FormName) {
			if (FormName == "detail") {
				Name = "Pagamento contratto passivo";
				return MetaData.GetFormByDllName("expenselastmandatedetail_detail");
			}
			return null;
}

public override void SetDefaults(DataTable PrimaryTable) {
    base.SetDefaults(PrimaryTable);

}


/// <summary>
/// FilterRow, si usa per i grid filtrati
/// </summary>
/// <param name="R"></param>
/// <param name="list_type"></param>
/// <returns></returns>
public override bool FilterRow(DataRow R, string list_type) {

    return true;
}

public override bool IsValid(DataRow R, out string errmess, out string errfield) {
    if (!base.IsValid(R, out errmess, out errfield)) return false;

    return true;
}

public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
    return base.SelectOne(ListingType, filter, "expenselastmandatedetail", Exclude);
}


public override void DescribeColumns(DataTable T, string ListingType) {
    base.DescribeColumns(T, ListingType);

			switch (ListingType) {
				case "detail": {
						foreach (DataColumn C in T.Columns) {
							DescribeAColumn(T, C.ColumnName, "", -1);
						}
						int nPos = 1;
						DescribeAColumn(T, "!mankind", "Tipo", "mandatekind.description",nPos++);
						DescribeAColumn(T, "yman", "Anno contratto", nPos++);
						DescribeAColumn(T, "nman", "N. contratto", nPos++);
						DescribeAColumn(T, "rownum", "N.Riga", nPos++);
						DescribeAColumn(T, "amount", "Importo", nPos++);
						DescribeAColumn(T, "!description", "Descrizione", "mandatedetail_pagamenti.detaildescription", nPos++);
						break;
					}
			}
		}
	}
}
