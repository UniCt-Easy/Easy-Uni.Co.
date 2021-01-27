
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
//Pino: using classcreddebilista; diventato inutile
using metadatalibrary;



namespace meta_registrykind//meta_classcreddebi//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_registrykind : Meta_easydata 
	{
		public Meta_registrykind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registrykind") 
		{		
			EditTypes.Add("lista");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				ActAsList();
				Name= "Classificazione Anagrafica";
				return MetaData.GetFormByDllName("registrykind_lista");//PinoRana
			}
			return null;
		}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idregistrykind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idregistrykind");
            if (N < 9999000)
                R["idregistrykind"] = 9999001;
            else
                R["idregistrykind"] = N + 1;

            return R;
        }

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++); 
            }
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}
	}


}
