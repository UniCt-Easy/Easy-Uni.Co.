
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_finunified
{
	/// <summary>
	/// Summary description for meta_mandatekind.
	/// </summary>
	public class Meta_finunified: Meta_easydata 
	{
		public Meta_finunified(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "finunified")
		{		
		ListingTypes.Add("default");
		}
        //		public override string GetStaticFilter(string ListingType)
        //		{
        //			string filteresercizio;
        //			if (ListingType=="default")	
        //			{
        //				filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
        //				return filteresercizio;
        //			}
        //			return base.GetStaticFilter (ListingType);
        //		}

        string[] mykey = new string[] { "idfin"};
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			int npos = 1;
			if ( ListingType=="default")
			{
			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"finpart","Parte", npos++);
				DescribeAColumn(T,"codefin", "Codice", npos++);
				DescribeAColumn(T, "title","Denominazione", npos++);
				DescribeAColumn(T, "manager", "Responsabile", npos++);
                DescribeAColumn(T, "cupcode", "Codice Unico di Progetto", npos++);
				DescribeAColumn(T, "codeacc", "Cod. Conto EP", npos++);
				DescribeAColumn(T, "account", "Conto EP", npos++);
				DescribeAColumn(T, "prevision", "Prev. Iniziale", npos++);
				DescribeAColumn(T,"currentprevision","Prev. Attuale", npos++);	
				DescribeAColumn(T,"availableprevision","Prev. Disponibile", npos++);
				if (Conn!=null)
				{

                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind == 3){
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.", npos++);
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.", npos++);
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa",npos++);
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa", npos++);
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa", npos++);
					}
				}
			}
		}
	}
	
}
