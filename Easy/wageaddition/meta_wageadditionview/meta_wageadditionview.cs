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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


namespace meta_wageadditionview//meta_contrattodipview//
{
	/// <summary>
	/// Summary description for Meta_contrattodipview.
	/// </summary>
	public class Meta_wageadditionview : Meta_easydata
	{
		public Meta_wageadditionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "wageadditionview") 
		{
			ListingTypes.Add("default");
		}
	
        public override string GetStaticFilter(string ListingType)
        {
            string filteresercizio;
            if (ListingType == "default")
            {
                filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        private string[] mykey = new string[] { "ycon", "ncon","ayear" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"ycon","Eserc. Contratto",nPos++);
				DescribeAColumn(T,"ncon","Num. Contratto",nPos++);
				DescribeAColumn(T,"registry","Percipiente",nPos++);
				DescribeAColumn(T,"description","descrizione",nPos++);
				DescribeAColumn(T,"codeser","Cod. Prestazione",nPos++);
				DescribeAColumn(T,"service","Prestazione",nPos++);
				DescribeAColumn(T,"start","Data Inizio",nPos++);
				DescribeAColumn(T,"stop","Data Fine",nPos++);
				DescribeAColumn(T,"adate","Data Contabile",nPos++);
				DescribeAColumn(T,"ndays","Durata (Giorni)",nPos++);
				DescribeAColumn(T,"feegross","Importo Totale",nPos++);
				DescribeAColumn(T,"completed","N",nPos++);
				DescribeAColumn(T,"idposition","Codice Qualifica",nPos++);
				DescribeAColumn(T,"position","Descr. Qualifica",nPos++);
				DescribeAColumn(T,"idcontractlength","Codice Durata",nPos++);
				DescribeAColumn(T,"contractlength","Descr. Durata",nPos++);
				DescribeAColumn(T,"codicerapporto","Codice Rapporto",nPos++);
				DescribeAColumn(T,"descrrapporto", "Descr. Rapporto",nPos++);
			}
		}
	}
}
