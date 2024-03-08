
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_accountingyear//meta_esercizio//
{
	/// <summary>
	/// Summary description for Meta_esercizio.
	/// </summary>
	public class Meta_accountingyear : Meta_easydata	{
		public Meta_accountingyear(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountingyear") {		
			Name= "Configurazione Contabile";
			EditTypes.Add("default");
			EditTypes.Add("patrimonio");
            EditTypes.Add("ep");
			EditTypes.Add("trasfclass");
			EditTypes.Add("confcontabile");
		}
		protected override System.Windows.Forms.Form GetForm(string EditType) {
			if (EditType=="default") {
				ActAsList();
				return GetFormByDllName("accountingyear_default");
			}
			if (EditType=="patrimonio")
			{
				ActAsList();
				Name="Operazioni sul patrimonio";
				return GetFormByDllName("accountingyear_patrimonio");
			}

            if (EditType == "ep") {
                ActAsList();
                Name = "Chiusura - Riapertura dell'E/P";
                return GetFormByDllName("accountingyear_ep");
            }

			if (EditType=="trasfclass"){
				ActAsList();
				return GetFormByDllName("accountingyear_trasfclass");
			}
			if (EditType=="confcontabile"){
				ActAsList();
				return GetFormByDllName("accountingyear_confcontabile");
			}
			return null;
		}
	}
}
