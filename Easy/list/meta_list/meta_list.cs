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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_list
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_list : Meta_easydata
	{
		public Meta_list(DataAccess Conn, MetaDataDispatcher Dispatcher)
			:base(Conn, Dispatcher, "list") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Listino";
		}

		protected override Form GetForm(string FormName)
		{
			DefaultListType="default";
			if (FormName=="default") return MetaData.GetFormByDllName("list_default");
			return null;
		}			
		
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idlist"], null, null, 0);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
                return base.SelectOne(ListingType, filter, "listview", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["idpackage"] != DBNull.Value && R["unitsforpackage"] == DBNull.Value) {
                errmess = "Se  si specifica l'unità di misura per l'acquisto è necessario " +
                    "specificare anche il coefficiente di conversione.";
                errfield = "unitsforpackage";
                return false;
            }
            if (CfgFn.GetNoNullDecimal(R["nmaxorder"]) < 0)
            {
                errfield = "nmaxorder";
                errmess = "L'importo della quantità massima prenotabile non può essere negativo.";
                return false;
            }
            return true;
        }



	}
}


