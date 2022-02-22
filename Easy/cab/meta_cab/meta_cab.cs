
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


namespace meta_cab//meta_sportellobanca//
{
	/// <summary>
	/// MetaData for sportellobanca
	/// </summary>
	public class Meta_cab : Meta_easydata
	{
        public Meta_cab(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "cab") {		
            Name= "CAB (Filiale)";
//          EditTypes.Add("default");			
//			EditTypes.Add("lista");
			ListingTypes.Add("default");
			EditTypes.Add("default_anag");			
//			EditTypes.Add("lista_anag");
			ListingTypes.Add("default_anag");
            ListingTypes.Add("checkimport");
		}
        protected override Form GetForm(string FormName){

			if (FormName=="default_anag") {
				return GetFormByDllName("cab_default_anag");
				//return new frmsportellobanca_anagrafica();
			}
/*Pino: il form è stato spostato in meta_sportellobancaview.
  			if (FormName=="lista_anag") {
				Name="Sportelli di una Banca";
				ActAsList();             
				return new frmsportellobancalista_anagrafica();
			}*/
			return null;
        }
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "flagusable", "S");
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "idcab", "Sportello", nPos++);
                DescribeAColumn(T, "idbank", "Banca", nPos++);
				if (T.DataSet != null && T.DataSet.Tables["bank"]!=null) 
					DescribeAColumn(T, "idbank", "", -1);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "CAP", nPos++);
			}
			if (ListingType=="default_anag") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idcab", "Sportello", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "CAP", nPos++);
                DescribeAColumn(T, "!comune", "Comune", "geo_city.title", nPos++);
			}
            if (ListingType == "checkimport")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idcab", "Sportello", nPos++);
                DescribeAColumn(T, "idbank", "Banca", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
        }   	
    }		
	            	

}
