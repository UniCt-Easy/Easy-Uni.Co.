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
using metadatalibrary;
using metaeasylibrary;


namespace meta_registryreferenceview
{
	/// <summary>
	/// Summary description for contattoview.
	/// </summary>
	public class Meta_registryreferenceview : Meta_easydata 
	{
		public Meta_registryreferenceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "registryreferenceview") 
		{
			ListingTypes.Add("contatto");
			
		}
	    private string[] mykey = new string[] { "idreg","idregistryreference" };
	    public override string[] primaryKey() {
	        return mykey;
	    }
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="contatto") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

                int nPos = 1;
                DescribeAColumn(T, "idregistryreference", "#", nPos++);
                DescribeAColumn(T, "referencename", "Nome Contatto", nPos++);
                DescribeAColumn(T, "registry", "Denominazione", nPos++);
                DescribeAColumn(T, "registryreferencerole", "Funzione contatto", nPos++);
                DescribeAColumn(T, "phonenumber", "Numero tel.", nPos++);
                DescribeAColumn(T, "faxnumber", "Numero fax.", nPos++);
                DescribeAColumn(T, "mobilenumber", "Num. cellulare", nPos++);
                DescribeAColumn(T, "email", "Indirizzo EMail", nPos++);
                DescribeAColumn(T, "skypenumber", "Skype No.", nPos++);
                DescribeAColumn(T, "msnnumber", "MSN No.", nPos++);
                //DescribeAColumn(T, "userweb", "Login Web", nPos++);
                //DescribeAColumn(T, "passwordweb", "Password Web", nPos++);
                DescribeAColumn(T, "flagdefault", "Predefinito", nPos++);
			}
		}   
	}
}
