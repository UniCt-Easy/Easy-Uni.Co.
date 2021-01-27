
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_inventorysortingamortizationyear//meta_tipoclassrivalutazioneesercizio//
{
	/// <summary>
	/// Summary description for Meta_tipoclassrivalutazioneesercizio.
	/// </summary>
	public class Meta_inventorysortingamortizationyear : Meta_easydata
	{
		public Meta_inventorysortingamortizationyear(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "inventorysortingamortizationyear") 
		{		
			EditTypes.Add("default");
            EditTypes.Add("search");
			ListingTypes.Add("default");
            ListingTypes.Add("elenco");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				Name="Quota ammortamento";
				DefaultListType = "default";
				return GetFormByDllName("inventorysortingamortizationyear_default");
			}
            if (FormName == "search")
            {
                Name = "Quota ammortamento";
                DefaultListType = "elenco";
                return GetFormByDllName("inventorysortingamortizationyear_search");
            }
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default")
			{
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
			    int ncol = 1;
                DescribeAColumn(T,"!codeinventoryamortization", "Codice", "inventoryamortization.codeinventoryamortization",ncol++);
				DescribeAColumn(T,"!description","Descrizione","inventoryamortization.description", ncol++);
				DescribeAColumn(T,"amortizationquota","Quota", ncol++);
                DescribeAColumn(T, "!active", "Attivo", "inventoryamortization.active", ncol++);
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"],"p");
			    DescribeAColumn(T,"!codemotive","Codice Causale Applicazione", "accmotive_amortization.codemotive",ncol++);
			    DescribeAColumn(T, "!accmotive", "Causale Applicazione", "accmotive_amortization.title", ncol++);
                DescribeAColumn(T, "!codemotive_unload", "Codice causale scarico", "accmotive_amortization_unload.codemotive", ncol++);
                DescribeAColumn(T, "!accmotive_unload", "Causale scarico", "accmotive_amortization_unload.title", ncol++);
            }
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "elenco")
                return base.SelectOne(ListingType, filter, "inventorysortingamortizationyearview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false; 
            decimal quota = CfgFn.GetNoNullDecimal(R["amortizationquota"]);
            if (quota == 0 || quota > 1)
            {
                errmess = "Quota non valida";
                errfield = "amortizationquota";
                return false;
            }
            return true;
        }

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}

	}
}
