
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
//Pino: using Localita; diventato inutile

namespace meta_foreigncountry//meta_localita//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_foreigncountry : Meta_easydata 
	{
		public Meta_foreigncountry(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "foreigncountry")
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="LocalitÓ Estere";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("foreigncountry_default");//PinoRana
			}
			return null;
		}

        public override string GetSorting(string ListingType) {
            if (ListingType == "default" ) return "description asc";
            return base.GetSorting(ListingType);
        }

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idforeigncountry", ".#", nPos++);
                DescribeAColumn(T, "codeforeigncountry", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idforeigncountry"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idforeigncountry");
            if (N < 9999000)
                R["idforeigncountry"] = 9999001;
            else
                R["idforeigncountry"] = N + 1;

            return R;
        }
	}
}

