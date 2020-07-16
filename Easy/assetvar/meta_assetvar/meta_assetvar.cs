/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_assetvar//meta_variazionepatrimonio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_assetvar : Meta_easydata
	{
		public Meta_assetvar(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "assetvar") 
		{		
			Name="Variazione Patrimoniale";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("dettaglio");
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name="Variazione";
				return MetaData.GetFormByDllName("assetvar_default");//PinoRana
			}
			return null;
		}	

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, System.Data.DataTable ToMerge) {
			if (ListingType=="default" || ListingType=="dettaglio") {
				return base.SelectOne (ListingType, filter, "assetvarview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "flag", 0);
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.ClearMySelector(T, "yvar");
            RowChange.MarkAsAutoincrement(T.Columns["idassetvar"], null, null, 7);
            RowChange.SetMySelector(T.Columns["nvar"], "yvar", 0);
			RowChange.MarkAsAutoincrement(T.Columns["nvar"],null,null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (CfgFn.GetNoNullInt32(R["idinventoryagency"]) == 0) {
                errmess = "E' necessario selezionare l'ente inventariale";
                errfield = "idinventoryagency";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }
    }
}