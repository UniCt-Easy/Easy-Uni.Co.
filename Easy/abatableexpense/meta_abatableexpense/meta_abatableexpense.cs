
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_abatableexpense//meta_oneredetraibile//
{
	/// <summary>
	/// Summary description for Meta_oneredetraibile.
	/// </summary>
	public class Meta_abatableexpense : Meta_easydata
	{
		public Meta_abatableexpense(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "abatableexpense")
		{
			EditTypes.Add("contrattodetail");
			ListingTypes.Add("contrattodetail");
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="contrattodetail")
			{
				DefaultListType = "contrattodetail";
				Name = "Oneri Detraibili - Dettaglio";
				return GetFormByDllName("abatableexpense_contrattodetail");
			}
			return null;
		}			

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (CfgFn.GetNoNullInt32(R["idabatement"]) <= 0)
			{
				errmess = "Il tipo detrazione deve essere necessariamente scelto";
				errfield = "idabatement";
				return false;
			}
			if(!base.IsValid (R, out errmess, out errfield))return false;
			return true;
		}


		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType=="contrattodetail")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"ayear","Esercizio");
				DescribeAColumn(T,"idcon","");
				DescribeAColumn(T,"idabatement","");
				//DescribeAColumn(T,"!descrdetrazione","Descrizione Detrazione","tipodetrazione.descrizione");
				DescribeAColumn(T,"!descrdetrazione","Descrizione Detrazione","abatementcode.description");
				DescribeAColumn(T,"totalamount","Importo Totale");
			}
		}
	}
}
