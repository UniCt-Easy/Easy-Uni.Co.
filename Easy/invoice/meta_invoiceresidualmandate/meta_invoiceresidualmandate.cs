
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_invoiceresidualmandate 
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_invoiceresidualmandate : Meta_easydata 
	{
		public Meta_invoiceresidualmandate(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoiceresidualmandate") 
		{
			Name = "Documenti IVA da contabilizzare";
			ListingTypes.Add("default");
		}

        private string[] mykey = new string[] {"idinvkind", "yinv", "ninv", "idmankind", "idupb","idupb_iva",
                "yman", "nman", "manrownum","ycon","ncon" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetSorting(string ListingType)
		{
			string sorting;
			if (ListingType=="default")
			{
				sorting = "idinvkind asc,yinv desc,ninv desc, registry asc,upb asc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"idinvkind",".#",nPos++);
                DescribeAColumn(T, "codeinvkind", "Tipo documento", nPos++);
				DescribeAColumn(T,"yinv","Esercizio",nPos++);
				DescribeAColumn(T,"ninv","Numero",nPos++);
                DescribeAColumn(T, "doc", "Documento Coll.", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc. Coll.", nPos++);
				DescribeAColumn(T,"registry","Cliente/Fornitore",nPos++);
				DescribeAColumn(T,"upb", "UPB",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
                DescribeAColumn(T,"taxabletotal", "Tot.Imponibile", nPos++);
                DescribeAColumn(T,"ivatotal", "Tot.IVA", nPos++);
                DescribeAColumn(T, "linkedtotal", "Tot.Contabilizzato", nPos++);
                DescribeAColumn(T,"residual", "Tot.Residuo", nPos++);
				DescribeAColumn(T,"ycon","Eserc. Contr. Prof.",nPos++);
				DescribeAColumn(T,"ncon","Contr. Prof.",nPos++);
                DescribeAColumn(T,"mandatekind", "Contratto Passivo", nPos++);
                DescribeAColumn(T,"yman", "Eserc.", nPos++);
                DescribeAColumn(T,"nman", "Num.", nPos++);
                DescribeAColumn(T,"manrownum", "Riga", nPos++);
				
			}
		}
	}
}
