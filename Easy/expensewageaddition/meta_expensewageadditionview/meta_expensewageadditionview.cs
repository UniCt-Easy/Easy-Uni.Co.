
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_expensewageadditionview//meta_contrattodipmovspesaview//
{
	/// <summary>
	/// Summary description for Meta_contrattodipmovspesaview.
	/// </summary>
	public class Meta_expensewageadditionview : Meta_easydata
	{
		public Meta_expensewageadditionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensewageadditionview") 
		{
			ListingTypes.Add("default");
            Name = "Altri Compensi - Mov. Spesa";
		}

		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting="nphase asc,ymov desc,nmov desc";
				return sorting;
			}
			return base.GetSorting (ListingType);	
		}

        private string[] mykey = new string[] { "idexp", "ayear", "ycon", "ncon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType) {
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            string basefilter = base.GetStaticFilter(ListingType);
            if (basefilter == null || basefilter == "") return filteresercizio;
            return QHS.AppAnd(basefilter, filteresercizio);
        }

		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
                DescribeAColumn(T, "ycon", "Esercizio Contratto", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc.Mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num.Mov.", nPos++);
                DescribeAColumn(T, "codefin", "Voce Bil.", nPos++);
                DescribeAColumn(T, "finance", "Denom. Bil.", nPos++);
                DescribeAColumn(T, "idexp", ".idexp", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "Denominazione UPB", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "ypay", "Eserc.Mand.", nPos++);
                DescribeAColumn(T, "npay", "Num.Mand.", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo Originale", nPos++);
                DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", nPos++);
                DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
                DescribeAColumn(T, "available", "Disponibile", nPos++);
                DescribeAColumn(T, "idpaymethod", ".Cod. Mod.Pag.", nPos++);
                DescribeAColumn(T, "cin", ".Cin", nPos++);
                DescribeAColumn(T, "idbank", ".Cod.ABI", nPos++);
                DescribeAColumn(T, "idcab", ".CAB", nPos++);
                DescribeAColumn(T, "cc", ".Conto", nPos++);
                DescribeAColumn(T, "paymentdescr", ".Desc.Pag.", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", ".Prestazione", nPos++);
                DescribeAColumn(T, "ivaamount", "Iva", nPos++);
                DescribeAColumn(T, "autokind", ".Tipo Auto", nPos++);
                DescribeAColumn(T, "flagarrear", ".Competenza", nPos++);
                DescribeAColumn(T, "expiration", ".Data Scadenza", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);
			}
		}
	}
}
