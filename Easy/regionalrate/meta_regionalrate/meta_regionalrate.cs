
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

namespace meta_regionalrate//meta_aliquotaregionale//
{
	/// <summary>
	/// Summary description for Meta_aliquotaregionale.
	/// </summary>
	public class Meta_regionalrate : Meta_easydata
	{
		public Meta_regionalrate(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "regionalrate")
		{			
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				Name = "Aliquote Regionali";
				ActAsList();
				DefaultListType = "default";
				StartEmpty=true;
				SearchEnabled=false;
				return GetFormByDllName("regionalrate_default");
			}
			
			return null;
		}
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){

				DescribeAColumn(T,"descrizioneritenuta","Tipo ritenuta", "tax.description");
				DescribeAColumn(T,"taxcode","");
				DescribeAColumn(T,"idregion","");
				DescribeAColumn(T,"validitystart","Data");
				DescribeAColumn(T,"nbracket","Numero scaglione");
				DescribeAColumn(T,"publishmentdate","Data Pubblicazione");
				DescribeAColumn(T,"ratestart","Data decorrenza");
				DescribeAColumn(T,"enforcement","Tipo applicazione");
				DescribeAColumn(T,"rate","Aliquota");
				HelpForm.SetFormatForColumn(T.Columns["rate"],"p");
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) 
		{
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (R["nbracket"].ToString()=="0")
			{
				errfield=null;
				errmess="Non è possibile definire più volte uno scaglione\n"+
					"sulla stessa data inizio aliquota.";
				return false;
			}
			return true;
		}
	}
}
