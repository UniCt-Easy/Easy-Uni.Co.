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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
//Pino: using tipoclassmovimentibase; diventato inutile
//Pino: using tipoclassmovimenti; diventato inutile


namespace meta_sortingkind//meta_tipoclassmovimenti//
{
	
	public class Meta_sortingkind : Meta_easydata
	{
		public Meta_sortingkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sortingkind") 
		{
			EditTypes.Add("lista");
			EditTypes.Add("listaclassi");
            EditTypes.Add("creascriptclassificazione");
			ListingTypes.Add("listaclassi");
			ListingTypes.Add("lista");
            ListingTypes.Add("default");
        }
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") {
				Name = "Tipo di Rilevanza analitica";
				ActAsList();
				return MetaData.GetFormByDllName("sortingkind_lista");//PinoRana
			}
			return null;
		}			

    
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            switch (ListingType) {
                case "default": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "");
                        DescribeAColumn(T, "idsorkind", "#");
                        DescribeAColumn(T, "codesorkind", "Codice");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "description", "Descrizione");
                        DescribeAColumn(T, "start", "Eserc. Inizio");
                        DescribeAColumn(T, "stop", "Eserc. Fine");
                        DescribeAColumn(T, "!importo", "Importo");
                        break;
                    }

                case "listaclassi": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "");
                        DescribeAColumn(T, "codesorkind", "Codice");
                        DescribeAColumn(T, "description", "Descrizione"); 
                        break;
                    }

                case "listatipoclassi": {
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        int nPos = 1;
                        DescribeAColumn(T, "idsorkind", ".#", nPos++);
                        DescribeAColumn(T, "codesorkind", "Codice", nPos++);
                        DescribeAColumn(T, "description", "Descrizione", nPos++);
                        break;
                    }
            }
		}


		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			MetaData.SetDefault(PrimaryTable,"flagdate","N");
		}
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            //Controlla che l'elenco dei valori ammessi termini con |
            for (int i = 1; i <= 5; i++) {
                string suffix = "S" + i.ToString();
                if (R["allowed" + suffix] != DBNull.Value) {
                    if (!(R["allowed" + suffix].ToString().EndsWith("|"))) {
                        errfield = "allowed" + suffix;
                        errmess = "Il campo " + R["allowed" + suffix].ToString() + " deve terminare col carattere | ." ;
                        return false;
                    }
                }
            }
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idsorkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idsorkind");
            if (N < 9999000)
                R["idsorkind"] = 9999001;
            else
                R["idsorkind"] = N + 1;

            return R;
        }

	}


}