
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;


namespace meta_registrylegalstatusview
{
	/// <summary>
    /// Summary description for meta_registrylegalstatusview.
	/// </summary>
	public class Meta_registrylegalstatusview : Meta_easydata 
	{
		public Meta_registrylegalstatusview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "registrylegalstatusview") 
		{
			
			ListingTypes.Add("posgiuridica");
			
		}
        private string[] mykey = new string[] { "idreg","idregistrylegalstatus" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="posgiuridica") 
			{
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "start", "Decorrenza", nPos++);
                DescribeAColumn(T, "region", "Regione", nPos++);
                DescribeAColumn(T, "position", "Qualifica", nPos++);
                DescribeAColumn(T, "start", "Data", nPos++);
                DescribeAColumn(T, "incomeclass", "Classe stip.", nPos++);
                DescribeAColumn(T, "incomeclassvalidity", "Decorr. Classe", nPos++);	
			}
		}   
	}
}
