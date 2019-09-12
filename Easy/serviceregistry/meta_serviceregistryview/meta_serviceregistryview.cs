/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

	namespace meta_serviceregistryview
	{
		/// <summary>
		/// Summary description for Class1.
		/// </summary>
		public class Meta_serviceregistryview : Meta_easydata 
		{
			public Meta_serviceregistryview(DataAccess Conn, MetaDataDispatcher Dispatcher):
				base(Conn, Dispatcher, "serviceregistryview") 
			{		
				Name= "Anagarfe delle prestazioni";
				ListingTypes.Add("default");
							
			}
			public override string GetStaticFilter(string ListingType)
			{
                //////string filter_yservreg;
                //////if (ListingType=="default")	
                //////{
                //////    //////////filter_yservreg = "(yservreg='"+GetSys("esercizio").ToString()+"')";
                //////    return filter_yservreg;
                //////}
				return base.GetStaticFilter (ListingType);
			}

        private string[] mykey = new string[] { "yservreg", "nservreg" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
			{
				base.DescribeColumns(T, ListingType);
				if (ListingType=="default")
				{
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "",-1);
					int nPos = 1;
					DescribeAColumn(T,"yservreg", "Anno",nPos++);
					DescribeAColumn(T,"nservreg","Numero",nPos++);
					DescribeAColumn(T,"id_service","Codice incarico",nPos++);
					DescribeAColumn(T,"title","Denominazione",nPos++);
					DescribeAColumn(T,"surname","Cognome",nPos++);
					DescribeAColumn(T,"forename","Nome",nPos++);
					DescribeAColumn(T,"employkind","tipo incarico",nPos++);
					DescribeAColumn(T,"cf","Cod.Fiscale",nPos++);
					
					DescribeAColumn(T,"description","Descrizione",nPos++);
					DescribeAColumn(T,"p_iva","Partita IVA",nPos++);
					
					DescribeAColumn(T,"gender","Sesso",nPos++);
					DescribeAColumn(T,"apmanager","Qualifica",nPos++);
                DescribeAColumn(T, "serviceregistrykind", "Tipologia incarico", nPos++);
                DescribeAColumn(T,"apregistrykind","Tipologia conferente",nPos++);
					DescribeAColumn(T,"apactivitykind","Oggetto dell'incarico",nPos++);
					DescribeAColumn(T,"is_annulled","Annullato",nPos++);
					DescribeAColumn(T,"is_delivered","Trasmesso",nPos++);
					DescribeAColumn(T,"is_changed","Modificato",nPos++);
					DescribeAColumn(T, "is_blocked","Bloccato",nPos++);

					DescribeAColumn(T,"consultingkind","Tipologia consulente",nPos++);
					DescribeAColumn(T,"flagforeign","Consulente estero",nPos++);
					
					DescribeAColumn(T,"codcity","Codice comune",nPos++);
					DescribeAColumn(T,"city","Comune",nPos++);
					DescribeAColumn(T,"birthdate","Data nascita",nPos++);
					DescribeAColumn(T,"referencesemester","Semestre riferimento",nPos++);
					DescribeAColumn(T,"acquirekind","Modalità di acquisizione",nPos++);
					DescribeAColumn(T,"apcontractkind","Tipo rapporto",nPos++);
					DescribeAColumn(T,"financialactivity","Attività economica",nPos++);
					DescribeAColumn(T,"authorizationdate","Data autorizzazione",nPos++);
                    DescribeAColumn(T, "expectationsdate", "Data affidamento", nPos++);
					DescribeAColumn(T,"start","Data inizio",nPos++);
					DescribeAColumn(T,"stop","Data fine",nPos++);
					DescribeAColumn(T,"servicevariation","Variazioni incarico",nPos++);
					DescribeAColumn(T,"ypay","Anno pagamento",nPos++);
//					DescribeAColumn(T,"semesterpay","Semestre pagamento",nPos++);
					DescribeAColumn(T,"expectedamount","Importo previsto",nPos++);
//					DescribeAColumn(T,"payedamount","Importo pagato",nPos++);
					DescribeAColumn(T,"payment","Saldo",nPos++);
					
					DescribeAColumn(T,"officeduty","Doveri ufficio",nPos++);
					DescribeAColumn(T,"pa_code","Codice ente",nPos++);
					DescribeAColumn(T,"department","Dipartimento",nPos++);
					DescribeAColumn(T,"pa_cf","CF ente",nPos++);
					DescribeAColumn(T,"pa_title","Conferente",nPos++);
					DescribeAColumn(T,"referencerule","Riferimenti normativi",nPos++);
					DescribeAColumn(T,"annotation","Note",nPos++);
                    DescribeAColumn(T,"regulation","Regolamento all'uopo", nPos++);
                    DescribeAColumn(T,"conferring_piva","Partita IVA Conferente", nPos++);
                    DescribeAColumn(T,"conferring_forename", "Nome Conferente", nPos++);
                    DescribeAColumn(T,"conferring_surname", "Cognome Conferente", nPos++);
                    DescribeAColumn(T,"conferring_flagforeign", "Conferente Estero", nPos++);
                    DescribeAColumn(T,"conferring_birthdate", "data nascita Conferente", nPos++);
                    DescribeAColumn(T,"conferring_gender", "Sesso Conferente", nPos++);
                    DescribeAColumn(T, "conferring_codcity", "Codice comune Conferente", nPos++);
                    DescribeAColumn(T, "conferring_city", "Comune Conferente", nPos++);
                    // Dati da pubblicare
	                DescribeAColumn(T, "actreference", "Atto Conferimento", nPos++);
	                DescribeAColumn(T, "otherservice", "Altri incarichi in enti di diritto privato finanziati da P.A.", nPos++);
	                DescribeAColumn(T, "conferringstructure", "Struttura Conferente", nPos++); 	
	                DescribeAColumn(T, "ordinancelink", "Link al decreto di conferimento Incarico", nPos++);
	                DescribeAColumn(T, "authorizingstructure", "Struttura che autorizza", nPos++);
	                DescribeAColumn(T, "authorizinglink", "Link atto di autorizzazione", nPos++);	
	                DescribeAColumn(T, "announcementlink", "Link al bando", nPos++);
	                DescribeAColumn(T, "professionalservice", "Eventuali attività professionali", nPos++);	
	                DescribeAColumn(T, "componentsvariable", "Componenti variabili del compenso", nPos++);
                    DescribeAColumn(T, "employtime", "Durata incarico", nPos++);
                    DescribeAColumn(T, "notes", "Note", nPos++);

				}
			}
		}

	}
