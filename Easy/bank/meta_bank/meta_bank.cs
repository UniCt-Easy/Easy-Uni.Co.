
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
using System.Windows.Forms;
//Pino: using UnaBanca; diventato inutile
using metaeasylibrary;
//Pino: using Banche; diventato inutile
using metadatalibrary;



namespace meta_bank//meta_banca//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_bank : Meta_easydata {
        public Meta_bank(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "bank") {		
            Name= "ABI (Banca)";
            EditTypes.Add("default");
            EditTypes.Add("lista");
			EditTypes.Add("listasportelli_anag");
			ListingTypes.Add("default");
            DefaultListType = "default";
            ListingTypes.Add("checkimport");
        }
        protected override Form GetForm(string FormName){
            if (FormName=="default") {
                return MetaData.GetFormByDllName("bank_default");//PinoRana
            }
            if (FormName=="lista") {
             
                ActAsList();                
                return MetaData.GetFormByDllName("bank_lista");//PinoRana
            }
			//if (FormName=="listasportelli_anag") {
			//	Name="Sportelli di una Banca";
			//	SetTableToMonitor("cab");
			//	return GetFormByDllName("bank_listasportelli_anag");
				
			//}
			return null;
        }
        public override void SetDefaults(DataTable T){
            base.SetDefaults(T);
            SetDefault(T, "flagusable", "S");
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idbank", "Banca", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
            if (ListingType == "checkimport") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idbank", "Banca", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
        }
    }


}
