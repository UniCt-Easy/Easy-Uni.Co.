
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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



namespace meta_apactivitykind
{
	/// <summary>
	/// Summary description for Meta_casualcontractyear.
	/// </summary>
	public class Meta_apactivitykind : Meta_easydata
	{
		public Meta_apactivitykind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "apactivitykind") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				ActAsList();
				Name = "Tipologia Incarico (per anagrafe prestazioni)";
				return MetaData.GetFormByDllName("apactivitykind_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")	
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idapactivitykind","Codice Incarico");
				DescribeAColumn(T,"description","Descrizione");
                DescribeAColumn(T, "active", "Attivo");
				DescribeAColumn(T, "description_consultant", "Descrizione Consulente");
				DescribeAColumn(T, "description_employee", "Descrizione Dipendente");
				DescribeAColumn(T, "idconsultant", "ID Oggetto Incarico Consulente");
				DescribeAColumn(T, "idemployee", "ID Oggetto Incarico Dipendente");
			}
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
            SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}
	}
}
