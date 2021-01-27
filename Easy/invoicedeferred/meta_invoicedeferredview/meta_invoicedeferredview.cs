
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_invoicedeferredview{
	public class Meta_invoicedeferredview : Meta_easydata {
		public Meta_invoicedeferredview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicedeferredview") {		
			ListingTypes.Add("liquidazione_debito");
			ListingTypes.Add("liquidazione_credito");
            ListingTypes.Add("fatture_vendita");
            ListingTypes.Add("fatture_acquisti_comm");
            ListingTypes.Add("fatture_acquisti_prom");
            ListingTypes.Add("fatture_acquisti_ist_intraextra");
            ListingTypes.Add("fatture_acquisti_ist_split");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
            if (ListingType == "fatture_vendita"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "adate", "Data registrazione", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                DescribeAColumn(T, "tax", "Imposta", nPos++);
                DescribeAColumn(T, "total", "Totale (IVA inclusa)", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "flagvariation", "Nota variaz.", nPos++);
                DescribeAColumn(T, "ivatotalpayed", "IVA liquidata", nPos++);

                FilterRows(T);
            }
            if ((ListingType == "fatture_acquisti_comm") ||(ListingType == "fatture_acquisti_prom") 
                ||(ListingType == "fatture_acquisti_ist_intraextra") ||(ListingType == "fatture_acquisti_ist_split")) {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
				DescribeAColumn(T,"invoicekind","Tipo documento",nPos++);
				DescribeAColumn(T,"yinv","Esercizio",nPos++);
				DescribeAColumn(T,"ninv","Numero",nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "adate", "Data registrazione", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                DescribeAColumn(T, "tax", "Imposta", nPos++);
                DescribeAColumn(T, "unabatable", "Indetraibile", nPos++);
                DescribeAColumn(T, "total", "Totale (IVA inclusa)", nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
				DescribeAColumn(T,"registry","Cliente/Fornitore",nPos++);
				DescribeAColumn(T,"flagvariation","Nota variaz.",nPos++);
                DescribeAColumn(T, "ivatotalpayed", "IVA liquidata", nPos++);

                FilterRows(T);
            }
		}


		public override bool FilterRow(DataRow R, string list_type) {
            //  if (istituzionale && !flagintracom && !flagsplit) continue;
            //  if ((commercil o pomiscuo) && flagsplit && tipoFatturavendita)  continue;

            if (list_type == "fatture_vendita") {
                if (
                    (R["registerclass"].ToString() == "V") && // Vendita
                    (
                       ((R["flagactivity"].ToString() == "1") && (R["flag_enable_split_payment"].ToString() == "S")) // Istituzionale e soggetta a Split
                    || ((R["flagactivity"].ToString() == "1") && (R["flagintracom"].ToString() != "N"))//Istituzionale e Intracom
                    || ((R["flagactivity"].ToString() == "2") && (R["flag_enable_split_payment"].ToString() == "N")) //Commerciale e non soggetta a Split
                    || ((R["flagactivity"].ToString() == "3") && (R["flag_enable_split_payment"].ToString() == "N"))//Promiscuo e non soggetta a Split
                    )
                    ) {return true;
                }
				return false;
			}
			if (list_type=="fatture_acquisti_comm") {
                // Acquisto e Commerciale
                if ((R["registerclass"].ToString() == "A") && (R["flagactivity"].ToString() == "2")) {
                    return true;
                }
				return false;
			}
			if (list_type=="fatture_acquisti_prom") {
                // Acquisto e Promiscuo
                if ((R["registerclass"].ToString() == "A") && (R["flagactivity"].ToString() == "3")) {
                    return true;
                }
				return false;
			}
            
            if (list_type=="fatture_acquisti_ist_intraextra") {
                // Acquisto e Istituzionale e Intracom, e non Spli perchè li prendo dopo
                if ((R["registerclass"].ToString() == "A") && (R["flagactivity"].ToString() == "1") && (R["flagintracom"].ToString() != "N") && (R["flag_enable_split_payment"].ToString() == "N")) {
                    return true;
                }
				return false;
			}
            if (list_type=="fatture_acquisti_ist_split") {
                // Acquisto Istituzionale e soggetta a Split , e non intracom perchè li ho presi prima
                if ((R["registerclass"].ToString() == "A") && (R["flagactivity"].ToString() == "1") && (R["flag_enable_split_payment"].ToString() == "S") && (R["flagintracom"].ToString() == "N")) {
                    return true;
                }
				return false;
			}

            return true;
		}

	}
}
