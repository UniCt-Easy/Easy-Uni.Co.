
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

namespace meta_deductibleexpense//meta_onerededucibile//
{
	/// <summary>
	/// Summary description for Meta_onerededucibile.
	/// </summary>
	public class Meta_deductibleexpense : Meta_easydata
	{
		public Meta_deductibleexpense(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "deductibleexpense")
		{
			EditTypes.Add("contrattodetail");
			ListingTypes.Add("contrattodetail");
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="contrattodetail")
			{
				DefaultListType = "contrattodetail";
				Name = "Oneri Deducibili - Dettaglio";
				return GetFormByDllName("deductibleexpense_contrattodetail");
			}
			return null;
		}			

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (CfgFn.GetNoNullInt32(R["iddeduction"]) <= 0)
			{
				errmess = "Il tipo deduzione deve essere necessariamente scelto";
				errfield = "iddeduction";
				return false;
			}
			if(!base.IsValid (R, out errmess, out errfield))return false;
			return true;
		}


		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType=="contrattodetail")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"ayear","Esercizio");
				DescribeAColumn(T,"idcon","");
				DescribeAColumn(T,"iddeduction","");
				//DescribeAColumn(T,"!descrdeduzione","Descrizione Deduzione","tipodeduzione.descrizione");
				DescribeAColumn(T,"!descrdeduzione","Descrizione Deduzione","deductioncode.description");
				DescribeAColumn(T,"totalamount","Importo Totale");
			}
		}
	}
}
