
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

namespace meta_registrymainview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_registrymainview : Meta_easydata {
		public Meta_registrymainview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registrymainview") {		
			Name= "Anagrafica";
            DefaultListType = "anagrafica";
			ListingTypes.Add("anagrafica");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
        private string[] mykey = new string[] { "idreg"};
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            if (ListingType == "default"||ListingType=="lista"||ListingType=="anagrafica") return "title asc";
            return base.GetSorting(ListingType);
        }
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="anagrafica"){
				foreach (DataColumn C in T.Columns) 
					C.Caption="";
				int nPos = 1;
				DescribeAColumn(T,"idreg", "Codice",nPos++);
				DescribeAColumn(T,"title","Denominazione",nPos++);
				DescribeAColumn(T,"registryclass","Tipologia",nPos++);
				DescribeAColumn(T,"surname","Cognome",nPos++);
				DescribeAColumn(T,"forename","Nome",nPos++);
				DescribeAColumn(T,"maritalsurname","Cognome acquisito",nPos++);
				DescribeAColumn(T,"cf","Cod.Fiscale",nPos++);
				DescribeAColumn(T,"p_iva","Partita IVA",nPos++);
				DescribeAColumn(T,"residencekind","Residenza",nPos++);
				DescribeAColumn(T,"annotation","Descrizione",nPos++);
				DescribeAColumn(T,"birthdate","Data Nascita",nPos++);
				DescribeAColumn(T,"city","Comune di Nascita",nPos++);
				DescribeAColumn(T,"gender","Sesso",nPos++);
				DescribeAColumn(T,"foreigncf","Cod.Fisc.Estero",nPos++);
				DescribeAColumn(T,"qualification","Titolo",nPos++);
				DescribeAColumn(T,"maritalstatus","Stato civile",nPos++);
				DescribeAColumn(T,"registrykind","Classificazione",nPos++);
				DescribeAColumn(T,"active","Utilizzabile",nPos++);
				DescribeAColumn(T,"badgecode","Badge",nPos++);
				DescribeAColumn(T,"category","Categoria",nPos++);
				DescribeAColumn(T,"extmatricula","Matricola",nPos++);
                DescribeAColumn(T, "ipa_fe", "Codice IPA", nPos++);
                DescribeAColumn(T, "flag_pa", "Ente Pubblico", nPos++);
			}

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idreg", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "cf", "Cod.Fiscale", nPos++);
                DescribeAColumn(T, "nation", "Paese", nPos++);
                DescribeAColumn(T, "p_iva", "Partita IVA", nPos++);
                DescribeAColumn(T, "coderesidence", "Tipo Residenza", nPos++);
                DescribeAColumn(T, "registrykind", "Classificazione", nPos++);
                DescribeAColumn(T, "annotation", "Descrizione", nPos++);
                DescribeAColumn(T, "birthdate", "Data Nascita", nPos++);
                DescribeAColumn(T, "surname", "Cognome", nPos++);
                DescribeAColumn(T, "forename", "Nome", nPos++);
                DescribeAColumn(T, "foreigncf", "Cod.Fisc.Estero", nPos++);
                DescribeAColumn(T, "flagtax", "Soggetto Ritenute", nPos++);
                DescribeAColumn(T, "active", "Utilizzabile", nPos++);
                DescribeAColumn(T, "ipa_fe", "Codice IPA", nPos++);
                DescribeAColumn(T, "extmatricula", "Matricola", nPos++);
            }

            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "idreg", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "cf", "Cod.Fiscale", nPos++);
                DescribeAColumn(T, "p_iva", "Partita IVA", nPos++);
                DescribeAColumn(T, "extmatricula", "Matricola", nPos++);
            }
		}
	}
}
