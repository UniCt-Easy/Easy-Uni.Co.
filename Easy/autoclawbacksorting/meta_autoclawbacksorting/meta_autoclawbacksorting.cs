
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_autoclawbacksorting
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_autoclawbacksorting : Meta_easydata 
	{
		public Meta_autoclawbacksorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "autoclawbacksorting") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Configurazione classificazioni automatiche recuperi";
				Form F = GetFormByDllName("autoclawbacksorting_default");
				return F;
			}
			return null;
		}		
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"ayear");
			RowChange.MarkAsAutoincrement(T.Columns["idautosort"],null,
				null,9);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}
		public override void SetDefaults(DataTable PrimaryTable) {
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
			base.SetDefaults (PrimaryTable);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "autoclawbacksortingview", Exclude);
			return base.SelectOne(ListingType, filter, "autoclawbacksorting", Exclude);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idsorkind"]) == 0) {
                errmess = "Bisogna specificare il tipo di classificazione";
                errfield = "idsorkind";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idsor"]) == 0) {
                errmess = "Bisogna specificare la voce di classificazione";
                errfield = "idsor";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idclawback"]) == 0) {
                errmess = "Bisogna specificare il recupero";
                errfield = "idclawback";
                return false;
            }
            return true;
        }
	}
}
