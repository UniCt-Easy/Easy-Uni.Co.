
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



namespace meta_registryview//meta_creditoredebitoreview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_registryview : Meta_easydata 
	{
        public Meta_registryview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "registryview") {		
            Name= "Anagrafica";
            ListingTypes.Add("default");
			ListingTypes.Add("lista");
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

				DescribeAColumn(T, "idreg", "Codice",1);
				DescribeAColumn(T,"title","Denominazione",2);
				DescribeAColumn(T,"cf","Cod.Fiscale",3);
				DescribeAColumn(T,"idland",".cod.paese",-1);
				DescribeAColumn(T,"nation","Paese",4);
				DescribeAColumn(T,"p_iva","Partita IVA",5);
				DescribeAColumn(T,"residence","Tipo Residenza",6);
				DescribeAColumn(T,"sortcode",".Cod.classificazione",-1);
				DescribeAColumn(T,"registrykind","Classificazione",7);
				DescribeAColumn(T,"idcurrency",".cod.valuta",-1);
				DescribeAColumn(T,"currency","Valuta",8);
				DescribeAColumn(T,"idlanguage",".cod.lingua",-1);
				DescribeAColumn(T,"language","Lingua",9);
				DescribeAColumn(T,"annotation","Descrizione",10);
				DescribeAColumn(T,"human","Pers.Fisica",11);
				DescribeAColumn(T,"birthdate","Data Nascita",12);
				DescribeAColumn(T,"birthplace","Luogo Nascita",13);
				DescribeAColumn(T,"birthprovince","Prov.Nascita",14);
				DescribeAColumn(T,"birthnation","Stato Nascita",15);
				DescribeAColumn(T,"surname","Cognome",16);
				DescribeAColumn(T,"forename","Nome",17);
				DescribeAColumn(T,"foreigncf","Cod.Fisc.Estero",18);
				DescribeAColumn(T,"flagtax","Soggetto Ritenute",19);
				DescribeAColumn(T,"active","Utilizzabile",20);
	
			}

			if (ListingType=="lista"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

				DescribeAColumn(T,"title","Denominazione",2);
				DescribeAColumn(T, "idreg", "Codice",1);
				DescribeAColumn(T,"cf","Cod.Fiscale",3);
				DescribeAColumn(T,"p_iva","Partita IVA",4);
				
			}
        }
	}

}
