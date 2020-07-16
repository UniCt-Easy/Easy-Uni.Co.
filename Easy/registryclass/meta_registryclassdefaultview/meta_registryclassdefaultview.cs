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


namespace meta_registryclassdefaultview
{
    public class Meta_registryclassdefaultview : Meta_easydata 
	{
        public Meta_registryclassdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryclassdefaultview") {
				Name = "Tipologia fiscale";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idregistryclass"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//$IsValid$

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idregistryclass", "Codice", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "registryclass_flagbadgecode", "Codice badge visibile", nPos++);
						DescribeAColumn(T, "registryclass_active", "Attivo", nPos++);
						DescribeAColumn(T, "registryclass_flagbadgecode_forced", "Codice badge obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagCF", "Codice fiscale visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagcf_forced", "Codice fiscale obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagcfbutton", "Bottone \"calcola codice fiscale\" visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagextmatricula", "Matricola esterna visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagextmatricula_forced", "Matricola esterna obbligatoria", nPos++);
						DescribeAColumn(T, "registryclass_flagfiscalresidence", "Campo residenza visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagfiscalresidence_forced", "inserimento residenza obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagforeigncf", "Codice fiscale estero visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagforeigncf_forced", "Codice fiscale estero obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flaghuman", "Persona fisica", nPos++);
						DescribeAColumn(T, "registryclass_flaginfofromcfbutton", "Bottone \"Comune, Data da C.F.\" visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagmaritalstatus", "Campo stato civile visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagmaritalstatus_forced", "Campo stato civile obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagmaritalsurname", "Cognome acquisito visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagmaritalsurname_forced", "Cognome acquisito obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagothers", "campo non usato", nPos++);
						DescribeAColumn(T, "registryclass_flagothers_forced", "campo non usato", nPos++);
						DescribeAColumn(T, "registryclass_flagp_iva", "Partita iva visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagp_iva_forced", "Partita iva obbligatoria", nPos++);
						DescribeAColumn(T, "registryclass_flagqualification", "campo \"Titolo\" visibile", nPos++);
						DescribeAColumn(T, "registryclass_flagqualification_forced", "campo \"Titolo\" obbligatorio", nPos++);
						DescribeAColumn(T, "registryclass_flagresidence", "Usato congiuntamente a flagresidence_forced per stabilire se l'indirizzo di residenza è obbligatorio, Da solo non ha un gran significato poiché non esiste un campo indirizzo di residenza", nPos++);
						DescribeAColumn(T, "registryclass_flagresidence_forced", "Informazioni sulla residenza obbligatorie", nPos++);
						DescribeAColumn(T, "registryclass_flagtitle", "Campo Denominazione diverso da cognome+nome, inserito manualmente", nPos++);
						DescribeAColumn(T, "registryclass_flagtitle_forced", "Non usato, il campo denominazione  è sempre obbligatorio in un modo o nell'altro", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
