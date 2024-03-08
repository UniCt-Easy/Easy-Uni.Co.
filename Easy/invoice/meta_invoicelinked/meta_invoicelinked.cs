
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;


namespace meta_invoicelinked//meta_documentoivacontabilizzato//
{
	/// <summary>
	/// Summary description for documentoivacontabilizzato.
	/// </summary>
	public class Meta_invoicelinked : Meta_easydata
	{
		public Meta_invoicelinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicelinked") {
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);

				DescribeAColumn(T,"invoicekind","Tipo documento",1);
				DescribeAColumn(T,"yinv","Esercizio",2);
				DescribeAColumn(T,"ninv","Numero",3);
				DescribeAColumn(T,"flagbuysell","Vendite/Acquisto",4);
				DescribeAColumn(T,"flagvariation","Nota variazione",5);
				DescribeAColumn(T,"registry","Creditore/Debitore",6);
				DescribeAColumn(T,"registryreference","Riferimento Cred./Deb.",7);
				DescribeAColumn(T,"description","Descrizione",8);
				DescribeAColumn(T,"paymentexpiring","Scadenza",9);
				DescribeAColumn(T,"idexpirationkind","Tiposcadenza",10);
				DescribeAColumn(T,"intracommunitytfreight","Tipo trasporto",11);
				DescribeAColumn(T,"intracommunitytransaction","Tipo transazione",12);
				DescribeAColumn(T,"intracommunityregime","Tipo regime",13);
				DescribeAColumn(T,"currency","Valuta",14);
				DescribeAColumn(T,"exchangerate","Cambio",15);
				DescribeAColumn(T,"nomenclatureiva","Nomenclatura",16);
				DescribeAColumn(T,"netweight","Massa",17);
				DescribeAColumn(T,"number","Quantità",18);
				DescribeAColumn(T,"statisticvalue","Val. statistico",19);
				DescribeAColumn(T,"nation","Paese",20);
				DescribeAColumn(T,"country","Prov.",21);
				DescribeAColumn(T,"doc","Documento",22);
				DescribeAColumn(T,"docdate","Data doc.",23);
				DescribeAColumn(T,"adate","Data reg.",24);
				DescribeAColumn(T,"packinglistnum","Num. doc. trasp.",25);
				DescribeAColumn(T,"packinglistdate","Data doc. trasp.",26);
				DescribeAColumn(T,"flagintra","Flag intracom.",27);
				DescribeAColumn(T,"officiallyprinted","Flag stampa",28);
			}
		}

	}
}
