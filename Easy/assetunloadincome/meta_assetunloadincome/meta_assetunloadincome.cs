
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_assetunloadincome{//meta_buonoscaricoentrata//
	/// <summary>
	/// Summary description for Meta_buonocaricospesa.
	/// </summary>
	public class Meta_assetunloadincome : Meta_easydata {
		public Meta_assetunloadincome(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher,"assetunloadincome") {

			ListingTypes.Add("buonodiscarico");
			Name="Movimenti di entrata collegati a buoni di scarico";
		}

		public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="buonodiscarico") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "!ymov", "Eserc. movimento", "incomeview.ymov", nPos++);
                DescribeAColumn(T, "!nmov", "Num. movimento", "incomeview.nmov", nPos++);
                DescribeAColumn(T, "!incomedescription", "Descrizione", "incomeview.description", nPos++);
                //DescribeAColumn(T, "!incomenpro", "Num. doc. incasso", "incomeview.npro", nPos++);
                DescribeAColumn(T, "!incomedoc", "Documento", "incomeview.documento", nPos++);
                DescribeAColumn(T,"!amount","Importo","incomeview.amount", nPos++);
                //DescribeAColumn(T,"!available","Disponibile","incomeview.available");
				HelpForm.SetFormatForColumn(T.Columns["!amount"],"c");
                //HelpForm.SetFormatForColumn(T.Columns["!available"], "c");
				ComputeRowsAs(T,ListingType);
			}
		}

		public override void CalculateFields(DataRow R, string list_type) {
			if (list_type=="buonodiscarico") {
				if (R["!amount"].ToString()=="") R["!amount"]=0;
				if (R["!available"].ToString()=="") R["!available"]=0;
			}
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);

//			SetDefault(PrimaryTable,"!importorecuperi",0);
		}
	}
}
