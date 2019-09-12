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
using metadatalibrary;
using metaeasylibrary;


namespace meta_taxpayexpenseview//meta_liquidritenutaspesaview//
{
	/// <summary>
	/// Summary description for liquidritenutaspesaview.
	/// </summary>
	public class Meta_taxpayexpenseview : Meta_easydata 
	{
		public Meta_taxpayexpenseview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxpayexpenseview") 
		{
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "ayear", "ytaxpay", "ntaxpay", "idexp" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "phase", "Fase");
				DescribeAColumn(T, "ayear", "Esercizio");
				DescribeAColumn(T, "nmov", "Numero");
				DescribeAColumn(T, "registry", "Percipiente");
				DescribeAColumn(T, "codefin", "Bilancio");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "curramount", "Importo corrente");
			}
		}   
	}
}


