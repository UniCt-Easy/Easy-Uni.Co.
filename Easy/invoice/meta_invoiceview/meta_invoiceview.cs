
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_invoiceview//meta_documentoivaview//
{
	/// <summary>
	/// Summary description for meta_documentoivaview
	/// </summary>
	public class Meta_invoiceview : Meta_easydata {
		public Meta_invoiceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoiceview") {		
			ListingTypes.Add("default");
            ListingTypes.Add("fecollegata");
			Name="Elenco documenti IVA";
		}

		public override string GetSorting(string ListingType) {
			if (ListingType=="default"){
				return "yinv DESC, ninv DESC";
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "idinvkind", "yinv", "ninv" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "fecollegata") {
                if (R["nelectronicinvoice"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default")
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
				DescribeAColumn(T,"invoicekind","Tipo documento",pos++);
				DescribeAColumn(T,"yinv","Esercizio",pos++);
				DescribeAColumn(T,"ninv","Numero",pos++);
                DescribeAColumn(T, "doc", "Documento", pos++);
                DescribeAColumn(T, "docdate", "Data doc.", pos++);
				DescribeAColumn(T,"flagbuysell","Vendite/Acquisto",pos++);
				DescribeAColumn(T,"flagdeferred","Differita",pos++);
				DescribeAColumn(T,"description","Descrizione",pos++);
				DescribeAColumn(T,"registry","Cliente/Fornitore",pos++);
                DescribeAColumn(T, "cf", "CF Cliente/Fornitore", pos++);
                DescribeAColumn(T, "p_iva", "P. IVA Cliente/Fornitore", pos++);
              	DescribeAColumn(T,"registryreference","Riferimento Cliente/Fornitore",pos++);
				DescribeAColumn(T,"flagvariation","Nota variaz.",pos++);
                DescribeAColumn(T, "expirationkind", "Tipo scad.", pos++);
				DescribeAColumn(T,"paymentexpiring","giorni scad.",pos++);
				DescribeAColumn(T,"expiring","Scadenza",pos++);
               // DescribeAColumn(T, "expensekinddescription", "Natura spesa", pos++);                
                //DescribeAColumn(T,"intracommunitytfreight","Tipo trasporto",pos++);
                //DescribeAColumn(T,"intracommunitytransaction","Tipo transazione",pos++);
                //DescribeAColumn(T,"intracommunityregime","Tipo regime",pos++);
                //DescribeAColumn(T,"nomenclatureiva","Nomenclatura",pos++);
				DescribeAColumn(T,"currency","Valuta",pos++);
                DescribeAColumn(T,"treasurer","Tesoriere", pos++);
                //DescribeAColumn(T,"nation","Paese",pos++);
				DescribeAColumn(T,"exchangerate","Cambio",pos++);
                //DescribeAColumn(T,"netweight","Massa",pos++);
                //DescribeAColumn(T,"number","Quantità",pos++);
                //DescribeAColumn(T,"statisticvalue","Val. statistico",pos++);
                //DescribeAColumn(T,"country","Prov.",pos++);
                DescribeAColumn(T, "flag_ddt", "segue DDT", pos++);
                DescribeAColumn(T,"packinglistnum","Num. doc. trasp.",pos++);
				DescribeAColumn(T,"packinglistdate","Data doc. trasp.",pos++);
				DescribeAColumn(T,"adate","Data reg.",pos++);
                //DescribeAColumn(T,"flagintra","Flag intracom.",pos++);
				DescribeAColumn(T,"officiallyprinted","Flag stampa",pos++);
				DescribeAColumn(T,"taxable","Imponibile",pos++);
				DescribeAColumn(T,"tax","Imposta",pos++);
				DescribeAColumn(T,"unabatable","Indetraibile",pos++);
				DescribeAColumn(T,"total","Totale (IVA inclusa)",pos++);
                DescribeAColumn(T, "intrastatnation_origin", "Paese di origine", pos++);
                DescribeAColumn(T,"intrastatnation_provenance","Paese di provenienza",pos++);
                DescribeAColumn(T,"country_destination", "Prov.destinazione",pos++);
                DescribeAColumn(T,"intrastatnation_destination", "Paese di destinazione",pos++);
                DescribeAColumn(T, "country_origin", "Prov.destinazione", pos++);
                DescribeAColumn(T, "intrastatkind", "Natura della transazione", pos++);
                DescribeAColumn(T, "intrastatnation_payment", "Paese di pagamento", pos++);
                DescribeAColumn(T, "blnation", ".Paese Blacklist", pos++);
                DescribeAColumn(T, "blcode", ".Cod. Paese Blacklist", pos++);
                DescribeAColumn(T, "totransmit", ".Comunicazione Blacklist", pos++);
                DescribeAColumn(T, "iduniqueregister", "Prog.Registro Unico", pos++);
                DescribeAColumn(T, "toincludeinpaymentindicator", "Includi in Indicatore Tempest. dei Pagamenti", pos++);
                DescribeAColumn(T, "touniqueregister", "Protocolla nel Registro Unico", pos++);
                DescribeAColumn(T, "idstampkind", "Bollo", pos++);
                DescribeAColumn(T, "ssntipospesa", "Tipo spesa sanitaria", pos++);
			    DescribeAColumn(T, "escludiinvio", "Escludi da invio", pos++);
			    DescribeAColumn(T, "cc_dedicato", "CC dedicato", pos++);
			    DescribeAColumn(T, "visura_camerale", "Visura Camerale", pos++);
			    DescribeAColumn(T, "durc", "Durc", pos++);
			}
            if (ListingType=="fecollegata") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int pos = 1;
                DescribeAColumn(T, "invoicekind", "Tipo documento", pos++);
                DescribeAColumn(T, "yinv", "Esercizio", pos++);
                DescribeAColumn(T, "ninv", "Numero", pos++);
                DescribeAColumn(T, "doc", "Documento", pos++);
                DescribeAColumn(T, "docdate", "Data doc.", pos++);
                DescribeAColumn(T, "flagbuysell", "Vendite/Acquisto", pos++);
                DescribeAColumn(T, "flagdeferred", "Differita", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "flagvariation", "Nota variaz.", pos++);
                DescribeAColumn(T, "paymentexpiring", "Scadenza", pos++);
                DescribeAColumn(T, "scadenza", "Tipo Scad.", pos++);
                DescribeAColumn(T, "currency", "Valuta", pos++);
                DescribeAColumn(T, "treasurer", "Tesoriere", pos++);
                DescribeAColumn(T, "adate", "Data reg.", pos++);
                DescribeAColumn(T, "taxable", "Imponibile", pos++);
                DescribeAColumn(T, "tax", "Imposta", pos++);
                DescribeAColumn(T, "unabatable", "Indetraibile", pos++);
                DescribeAColumn(T, "total", "Totale (IVA inclusa)", pos++);
                DescribeAColumn(T, "toincludeinpaymentindicator", "Includi in Indicatore Tempest. dei Pagamenti", pos++);
                DescribeAColumn(T, "touniqueregister", "Protocolla nel Registro Unico", pos++);
                FilterRows(T);
            }

		}
	}
}
