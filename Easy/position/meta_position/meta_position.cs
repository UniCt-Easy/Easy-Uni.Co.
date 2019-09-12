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
//using qualifica;
//Pino: using qualificalista; diventato inutile
using metadatalibrary;



namespace meta_position//meta_qualifica//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_position : Meta_easydata 
	{
		public Meta_position(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "position") 
		{
			EditTypes.Add("lista");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				Name = "Qualifica";
				ActAsList();
				DefaultListType = "default";
				return MetaData.GetFormByDllName("position_lista");//PinoRana
			}
			if (FormName=="riepilogo") {
				Name = "Verifica Inquadramento";
				SearchEnabled = false;
				DefaultListType="riepilogo";
				return MetaData.GetFormByDllName("position_riepilogo");//PinoRana
			}

			return null;
		}			
	
		
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype == "default")
			{
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idposition", ".#", nPos++);
                DescribeAColumn(T, "codeposition", ".#", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Classe Stip. Max", nPos++);
                DescribeAColumn(T, "foreignclass", "Classe di appartenenza per Miss.all'estero", nPos++);
			}

			if ( listtype=="riepilogo") {
				foreach(DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
				}
                int nPos = 1;
                DescribeAColumn(T, "idposition", ".#", nPos++);
                DescribeAColumn(T, "codeposition", ".#", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "maxincomeclass", "Classe Stip.", nPos++);
			}   

		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idposition"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idposition");
            if (N < 9999000)
                R["idposition"] = 9999001;
            else
                R["idposition"] = N + 1;

            return R;
        }

	
	}
}
