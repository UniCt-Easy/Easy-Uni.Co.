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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_upbdefaultview
{
    public class Meta_upbdefaultview : Meta_easydata 
	{
        public Meta_upbdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "upbdefaultview") {
				Name = "Unità previsionali di base";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idupb"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idupb", "id voce upb (tabella upb)", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "upb_active", "attivo", nPos++);
						DescribeAColumn(T, "upb_assured", "Finanziamento certo (Non gestire assegnazione crediti/incassi)", nPos++);
						DescribeAColumn(T, "upb_cigcode", "Codice CIG, Codice identificativo di gara", nPos++);
						DescribeAColumn(T, "upb_codeupb", "codice upb", nPos++);
						DescribeAColumn(T, "upb_cofogmpcode", "Cofogmpcode", nPos++);
						DescribeAColumn(T, "upb_cupcode", "Codice CUP, Codice unico di progetto", nPos++);
						DescribeAColumn(T, "upb_expiration", "scadenza", nPos++);
						DescribeAColumn(T, "upb_flag", "flag vari", nPos++);
						DescribeAColumn(T, "upb_flagactivity", "Tipo attività", nPos++);
						DescribeAColumn(T, "upb_flagkind", "Funzione", nPos++);
						DescribeAColumn(T, "upb_granted", "Finanziamento concesso", nPos++);
						if (T.Columns.Contains("upb_granted")) T.Columns["upb_granted"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "epupbkind_title", "Denominazione ID Tipo UPB nell'economico patrimoniale (tabella epupbkind)", nPos++);
						DescribeAColumn(T, "epupbkind_description", "Descrizione ID Tipo UPB nell'economico patrimoniale (tabella epupbkind)", nPos++);
						DescribeAColumn(T, "treasurer_description", "Id cassiere (tabella treasurer)", nPos++);
						DescribeAColumn(T, "underwriter_description", "ID Ente finanziatore (tabella underwriter)", nPos++);
						DescribeAColumn(T, "upb_newcodeupb", "Codice di consolidamento", nPos++);
						DescribeAColumn(T, "upbparent_title", "chiave parent U.P.B. (tabella upb) ", nPos++);
						DescribeAColumn(T, "upb_previousappropriation", "Totale impegnato pregresso (previa informatizzazione)", nPos++);
						if (T.Columns.Contains("upb_previousappropriation")) T.Columns["upb_previousappropriation"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "upb_previousassessment", "Totale accertato pregresso (previa informatizzazione)", nPos++);
						if (T.Columns.Contains("upb_previousassessment")) T.Columns["upb_previousassessment"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "upb_printingorder", "Ordine di stampa", nPos++);
						DescribeAColumn(T, "upb_requested", "Finanziamento richiesto", nPos++);
						if (T.Columns.Contains("upb_requested")) T.Columns["upb_requested"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "upb_rtf", "allegati", nPos++);
						DescribeAColumn(T, "upb_ri_ra_quota", "Ri_ra_quota", nPos++);
						if (T.Columns.Contains("upb_ri_ra_quota")) T.Columns["upb_ri_ra_quota"].ExtendedProperties["format"] = "fixed.6";
						DescribeAColumn(T, "upb_start", "data inizio", nPos++);
						DescribeAColumn(T, "upb_ri_rb_quota", "Ri_rb_quota", nPos++);
						if (T.Columns.Contains("upb_ri_rb_quota")) T.Columns["upb_ri_rb_quota"].ExtendedProperties["format"] = "fixed.6";
						DescribeAColumn(T, "upb_stop", "data fine", nPos++);
						DescribeAColumn(T, "upb_ri_sa_quota", "Ri_sa_quota", nPos++);
						if (T.Columns.Contains("upb_ri_sa_quota")) T.Columns["upb_ri_sa_quota"].ExtendedProperties["format"] = "fixed.6";
						DescribeAColumn(T, "upb_txt", "note testuali", nPos++);
						DescribeAColumn(T, "upb_uesiopecode", "Uesiopecode", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "title asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
