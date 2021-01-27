
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

namespace meta_exhibitedcudabatement//meta_dettagliodetrazionecudpresentato//
{
	/// <summary>
	/// Summary description for Meta_dettagliodetrazionecudpresentato.
	/// </summary>
	public class Meta_exhibitedcudabatement : Meta_easydata
	{
		public Meta_exhibitedcudabatement(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "exhibitedcudabatement") 
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				Name = "Dettaglio Detrazioni CUD Presentato";
				return MetaData.GetFormByDllName("exhibitedcudabatement_default");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (CfgFn.GetNoNullInt32(R["idabatement"]) <= 0)
			{
				errmess = "Il tipo detrazione deve essere necessariamente scelto";
				errfield = "idabatement";
				return false;
			}
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idcon","");
				DescribeAColumn(T,"idexhibitedcud","");
				DescribeAColumn(T,"idabatement","");
				DescribeAColumn(T,"!descrdetrazione","Descr. Detrazione","abatementcode.description");
				DescribeAColumn(T,"amount","Importo");
			}
		}
	}
}
