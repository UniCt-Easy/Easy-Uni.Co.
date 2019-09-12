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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;

namespace meta_expenseyear//meta_imputazionespesa//
{
	/// <summary>
	/// Summary description for imputazionespesa.
	/// </summary>
	public class Meta_expenseyear : Meta_easydata
	{
		public Meta_expenseyear(DataAccess Conn, 
			MetaDataDispatcher Dispatcher):
			base(Conn,Dispatcher, "expenseyear") {
		}

		override public bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (R["amount"]==DBNull.Value){
				errmess="Non è stato immesso l'importo";
				errfield="amount";
				return false;
			}
            if (CfgFn.GetNoNullDecimal(R["amount"]) < 0) {
                errmess = "L'importo non può essere negativo";
                errfield = "amount";
                return false;
            }
			return true;
		}

	}
}
