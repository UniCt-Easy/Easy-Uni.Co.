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
using metaeasylibrary;
using metadatalibrary;

namespace meta_parasubcontractfamilyview//meta_familiareview//
{
	/// <summary>
	/// Summary description for Meta_familiareview.
	/// </summary>
	public class Meta_parasubcontractfamilyview : Meta_easydata
	{
		public Meta_parasubcontractfamilyview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "parasubcontractfamilyview")
		{
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idcon","");
				DescribeAColumn(T,"idreg","");
				DescribeAColumn(T,"idfamily","");
				DescribeAColumn(T,"ayear","");
				DescribeAColumn(T,"surname","Cognome");
				DescribeAColumn(T,"forename","Nome");
				DescribeAColumn(T,"idaffinity","Cod. Parentela");
				DescribeAColumn(T,"affinity","Descr. Parentela");
				DescribeAColumn(T,"idcitybirth","");
				DescribeAColumn(T,"city","Comune");
				DescribeAColumn(T,"province","Provincia");
				DescribeAColumn(T,"idnation","");
				DescribeAColumn(T,"nation","Stato");
				DescribeAColumn(T,"birthdate","Data di Nascita");
				DescribeAColumn(T,"gender","Sesso");
				DescribeAColumn(T,"flagforeign","Straniero");
				DescribeAColumn(T,"cf","Codice Fiscale");
				DescribeAColumn(T,"startapplication","Data Inizio Applicazione");
				DescribeAColumn(T,"stopapplication","Data Fine Applicazione");
				DescribeAColumn(T,"percapplicazione","% Applicazione");
				DescribeAColumn(T,"starthandicap","Data Inizio Portatore Handicap");
				DescribeAColumn(T,"foreignresident","Residenza Estera");
				DescribeAColumn(T,"flagdependent","A Carico");
			}
		}
	}
}
