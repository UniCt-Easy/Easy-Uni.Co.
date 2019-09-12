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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//using sezione;
using metadatalibrary;


namespace meta_division//meta_sezione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_division : Meta_easydata 
	{
		public Meta_division(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "division") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Sezione";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType= "default";
				return GetFormByDllName("division_default");
				//frmsezione F = new frmsezione();
				//return F;
			}
			return null;
		}			
	
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "iddivision", ".#", nPos++);
                DescribeAColumn(T, "codedivision", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "C.A.P.", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "country", "Provincia", nPos++);
                DescribeAColumn(T, "phoneprefix", "Prefisso tel.", nPos++);
                DescribeAColumn(T, "phonenumber", "Numero tel.", nPos++);
                DescribeAColumn(T, "faxprefix", "Prefisso fax", nPos++);
                DescribeAColumn(T, "faxnumber", "Numero fax", nPos++);
			}
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["iddivision"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "iddivision");
            if (N < 9999000)
                R["iddivision"] = 9999001;
            else
                R["iddivision"] = N + 1;

            return R;
        }
	
	}
}
