
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_estimatelinked
{
	/// <summary>
	/// Summary description for contratto contabilizzato.
	/// </summary>
	public class Meta_estimatelinked : Meta_easydata
	{
		public Meta_estimatelinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimatelinked") {
			Name= "Contratti attivi contabilizzati";
			ListingTypes.Add("default");
		}
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting = "estimkind asc,yestim desc,nestim desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "ayear","idestimkind", "yestim", "nestim" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = "(ayear='"+GetSys("esercizio")+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T, "estimkind", "Tipo",1);
				DescribeAColumn(T, "yestim", "Esercizio",2);
				DescribeAColumn(T, "nestim", "Numero",3);
				DescribeAColumn(T, "registry", "Cliente",4);
				DescribeAColumn(T, "registryreference", ".Rif. Cliente");
				DescribeAColumn(T, "description", "Descrizione",5);
				DescribeAColumn(T, "manager", "Responsabile",6);
				DescribeAColumn(T, "adate", "Data contabile",7);
				DescribeAColumn(T, "deliveryexpiration", "Term. cons.",8);
				DescribeAColumn(T, "deliveryaddress", "Ind. cons.",9);
				DescribeAColumn(T, "paymentexpiring", "Scad.",10);
				DescribeAColumn(T, "tipopagamento", "Tipo scad.",11);
				DescribeAColumn(T, "currency", ".Valuta");
				DescribeAColumn(T, "exchangerate", ".Cambio");
				DescribeAColumn(T, "doc", "Documento",7);
				DescribeAColumn(T, "docdate", "Data doc.",8);
				DescribeAColumn(T, "officiallyprinted", ".Flag stampa");
				DescribeAColumn(T, "flagutilizzabile", ".utilizzabile");
			}
		}

	}
}
