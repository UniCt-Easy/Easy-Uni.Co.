
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
//using rapportolavoro;
using metadatalibrary;
//Pino: using rapportolavorolista_Anagrafica; diventato inutile


namespace meta_workcontract//meta_rapportolavoro//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_workcontract : Meta_easydata 
	{
		public Meta_workcontract(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "workcontract") 
		{
			EditTypes.Add("anagrafica");
			ListingTypes.Add("default");
			ListingTypes.Add("solodescrizione");
		}
		
			public override void SetDefaults(DataTable PrimaryTable)
			{
				base.SetDefaults (PrimaryTable);
				SetDefault(PrimaryTable,"flagexemption", "S");
			}
		protected override Form GetForm(string FormName)
		{

			if (FormName=="anagrafica") {
				Name = "Tipi di rapporti di lavoro";
				ActAsList();
				return MetaData.GetFormByDllName("workcontract_anagrafica");//PinoRana
			}

			return null;
		}			
	
		
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="solodescrizione"){
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"description","Descrizione");
			}

			if (listtype=="default"){
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T, "idwor","Codice");
				DescribeAColumn(T, "description","Descrizione");
				DescribeAColumn(T, "flagexemption","Quota Esente");
			}
			
		}   

	
	}
}
