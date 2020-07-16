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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;

namespace meta_casualcontractview_ep {
	public class Meta_casualcontractview_ep : Meta_easydata {
		public Meta_casualcontractview_ep(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "casualcontractview_ep") {
			//EditTypes.Add("default");
			ListingTypes.Add("epdebit");
		}

		/// <summary>
		/// Impostare la chiave, serve per le viste, non per le tabelle!!
		/// </summary>
		private string[] mykey = new string[] {"ycon", "ncon"};

		public override string[] primaryKey() {
			return mykey;
		}


		public override string GetStaticFilter(string ListingType) {
			string filteresercizio = "(ayear='" + GetSys("esercizio") + "')";
			return filteresercizio;
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			//if (ListingType == "lista")
			//    return base.SelectOne(ListingType, filter, "tabellaview", Exclude);
			//else
			return base.SelectOne(ListingType, filter, "tabella", Exclude);
		}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "epdebit") {
				foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
				int pos = 1;
				DescribeAColumn(T, "ycon", "Eserc. Contratto", pos++);
				DescribeAColumn(T, "ncon", "Num. Contratto", pos++);
				DescribeAColumn(T, "registry", "Percipiente", pos++);
				DescribeAColumn(T, "description", "Descrizione", pos++);
				DescribeAColumn(T, "codeser", "Cod. Prestazione", pos++);
				DescribeAColumn(T, "service", "Prestazione", pos++);
				DescribeAColumn(T, "start", "Data Inizio", pos++);
				DescribeAColumn(T, "stop", "Data Fine", pos++);
				DescribeAColumn(T, "adate", "Data Contabile", pos++);
				DescribeAColumn(T, "feegross", "Importo Totale", pos++);
				DescribeAColumn(T, "total", "Costo totale", pos++);
				DescribeAColumn(T, "completed", "Contabilizzabile", pos++);
				DescribeAColumn(T, "iduniqueregister", "Prog.Registro Unico", pos++);
				DescribeAColumn(T, "expiration", "Scadenza", pos++);
				DescribeAColumn(T, "codemotive", "Cod.Causale di costo", pos++);
				DescribeAColumn(T, "accmotive", "Causale di costo", pos++);
				DescribeAColumn(T, "codemotivedebit", "Cod.Causale di debito", pos++);
				DescribeAColumn(T, "accmotivedebit", "Causale di debito", pos++);
				DescribeAColumn(T, "codemotivedebit_crg", "Cod.Causale di debito aggiornata", pos++);
				DescribeAColumn(T, "accmotive_crg", "Causale di debito aggiornata", pos++);
				DescribeAColumn(T, "idaccmotivedebit_datacrg", "Data Correz. Causale di debito", pos++);
				DescribeAColumn(T, "impegno", "Impegno", pos++);
				DescribeAColumn(T, "pagamento", "Pagamento", pos++);
				DescribeAColumn(T, "mandato", "Mandato", pos++);
				DescribeAColumn(T, "elenco_trasm", "Elenco trasm.", pos++);
				DescribeAColumn(T, "residuo", "Da impegnare", pos++);
				DescribeAColumn(T, "importo_impegno", "Importo impegno", pos++);
				DescribeAColumn(T, "importo_pagamento", "Importo Pagamento", pos++);
				DescribeAColumn(T, "chiusura_debito", "Chiusura debito", pos++);
				DescribeAColumn(T, "contributi_pagati", "Chiusura debito contributi", pos++);
				DescribeAColumn(T, "scrittura_elenco", "n. scrittura elenco trasm.", pos++);
				DescribeAColumn(T, "scrittura_esito", "n. scrittura esito", pos++);
				DescribeAColumn(T, "chiusura_debito_contributi", "Chiusura debito contributi ", pos++);
				DescribeAColumn(T, "contributi_da_esitare", "Contributi da esitare", pos++);
				DescribeAColumn(T, "importo_da_esitare", "Debito da esitare", pos++);
			}
		}
	}
}
