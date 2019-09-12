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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using modulereportparameter; diventato inutile

namespace meta_report//meta_modulereport//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_report : Meta_easydata
	{
		public Meta_report(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "report") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name= "Configurazione delle stampe";
				DefaultListType="default";
				//ActAsList();        
				//SearchEnabled = false;
				return MetaData.GetFormByDllName("report_default");//PinoRana
			}
			return null;
		}	
		
		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "orientation", "P");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "modulename", "Modulo", 1);
                DescribeAColumn(T,"description","Descrizione",2);
				DescribeAColumn(T,"groupname","Gruppo",3);
				DescribeAColumn(T,"filename","File",4);
				DescribeAColumn(T,"reportname","Chiave",5);
			
			}
		}


//		public override bool IsValid(DataRow R, out string errmess, out string errfield)
//		{
//			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
//
//			if (R["codicemodalita"]==DBNull.Value)
//			{
//				errmess="Non è stata selezionata nessun tipo di modalità pagamento";
//				errfield="codicemodalita";
//				return false;
//			}
//            
//			return true;
//		}
     
	}
}
