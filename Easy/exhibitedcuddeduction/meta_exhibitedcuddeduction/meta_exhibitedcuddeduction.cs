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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_exhibitedcuddeduction//meta_dettagliodeduzionecudpresentato//
{
	/// <summary>
	/// Summary description for Meta_dettagliodeduzionecudpresentato.
	/// </summary>
	public class Meta_exhibitedcuddeduction : Meta_easydata
	{
		public Meta_exhibitedcuddeduction(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "exhibitedcuddeduction") 
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				Name = "Dettaglio Deduzioni CUD Presentato";
				return MetaData.GetFormByDllName("exhibitedcuddeduction_default");
			}
			return null;
		}
/*
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) 
		{
			RowChange.SetSelector(T, "idcon");
			RowChange.SetSelector(T, "idexhibitedcud");
			RowChange.SetSelector(T, "iddeduction");
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}
*/
		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (CfgFn.GetNoNullInt32(R["iddeduction"]) <= 0)
			{
				errmess = "Il tipo deduzione deve essere necessariamente scelto";
				errfield = "iddeduction";
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
				DescribeAColumn(T,"iddeduction","");
				DescribeAColumn(T,"!descrdeduzione","Descr. Deduzione","deductioncode.description");
				DescribeAColumn(T,"amount","Importo");
			}
		}
	}
}
