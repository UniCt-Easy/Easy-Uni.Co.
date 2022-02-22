
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_incomeinvoiceview//meta_ivamoventrataview//
{
	/// <summary>
	/// Summary description for ivamoventrataview.
	/// </summary>
	public class Meta_incomeinvoiceview : Meta_easydata
	{
		public Meta_incomeinvoiceview(DataAccess Conn, 
			MetaDataDispatcher Dispatcher):
			base(Conn,Dispatcher, "incomeinvoiceview") {
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
        private string[] mykey = new string[] { "idinc", "idinvkind", "yinv", "ninv","ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "idinvkind", ".#", nPos++);
                DescribeAColumn(T, "codeinvkind", "Codice tipo doc.", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo Documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "movkind", "Tipo Movimento", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc.Mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num.Mov.", nPos++);
                DescribeAColumn(T, "codefin", "Voce Bil.", nPos++);
                DescribeAColumn(T, "finance", "Denom.Bil.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "upb", "Denom. UPB", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "ypro", "Eserc.Rev.", nPos++);
                DescribeAColumn(T, "npro", "Num.Rev.", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Imp.Originale", nPos++);
                DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", nPos++);
                DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
                DescribeAColumn(T, "available", "Disponibile", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);
			}
			
		}   
	



	}

}

