/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
//Pino: using transactionrule; diventato inutile

namespace meta_journaltablesetup//meta_transactionrule//
{
	/// <summary>
	/// Summary description for transactionrule.
	/// </summary>
	public class Meta_journaltablesetup : Meta_easydata {
		public Meta_journaltablesetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "journaltablesetup") {
			EditTypes.Add("default");
			ListingTypes.Add("default");   
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Evento transazione";
				return MetaData.GetFormByDllName("journaltablesetup_default");//PinoRana
			}
			return null;
		}	
		

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable,"opkind","I");
		}



		public override bool IsValid (DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			string filterkey=QueryCreator.WHERE_KEY_CLAUSE(R,DataRowVersion.Current,false);
			DataRow []RR =R.Table.Select(filterkey);
			if (RR.Length > 1)
			{
				errmess="Attenzione! L'operazione selezionata Ë stata gi‡ assegnata alla tabella scelta";
				errfield="opkind";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				
				DescribeAColumn(T, "tablename", "Tabella");
				DescribeAColumn(T, "opkind", "Operazione");
				
			}
		}
	

	}

}

