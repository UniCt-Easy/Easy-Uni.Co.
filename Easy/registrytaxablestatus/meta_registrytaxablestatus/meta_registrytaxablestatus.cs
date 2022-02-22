
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione


namespace meta_registrytaxablestatus
{
	/// <summary>
	/// </summary>
	public class Meta_registrytaxablestatus : Meta_easydata
	{
        public Meta_registrytaxablestatus(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "registrytaxablestatus") {
			ListingTypes.Add("default");
            Name = "Reddito Annuo Presunto";
			EditTypes.Add("anagrafica");
			ListingTypes.Add("posretr");
			ListingTypes.Add("anagrafica");
			EditTypes.Add("anagraficadetail");
			ListingTypes.Add("anagraficadetail");
            ListingTypes.Add("unione");
        }
        protected override Form GetForm(string FormName){
			if(FormName=="anagrafica")
			{
				DefaultListType="anagrafica";
				Name = "Reddito Annuo Presunto";
				return GetFormByDllName("registrytaxablestatus_anagrafica");
			}
			if(FormName=="anagraficadetail")
			{
				DefaultListType="anagraficadetail";
				Name = "Reddito Annuo Presunto";
				return GetFormByDllName("registrytaxablestatus_anagraficadetail");
			}
			return null;
        }			
   
		public override void SetDefaults(DataTable T) {
			base.SetDefaults (T);
			SetDefault(T, "active", "S");
		}

		public override DataRow SelectOne(string ListingType, 
			string filter, string searchtable, DataTable ToMerge) 
		{
			if((ListingType=="posretr") || (ListingType=="anagrafica"))
				return base.SelectOne(ListingType, filter, 
					"registrytaxablestatusview", ToMerge);
			
			return base.SelectOne(ListingType, filter, 
				searchtable, ToMerge);
		}

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			if(ListingType=="default")
			{
				if (T.DataSet.Tables["registry"]!=null) 
					DescribeAColumn(T, "idreg", "");
				DescribeAColumn(T,"start","Data");
				DescribeAColumn(T,"supposedincome","Fiscale");
			}

			if(ListingType=="anagraficadetail") {
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"start","Data");
				DescribeAColumn(T,"supposedincome","Fiscale");
			}
            if (ListingType == "unione") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "start", "Data", nPos++);
                DescribeAColumn(T, "supposedincome", "Fiscale", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }
        }
  
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
			if (codicecreddeb <= 0) {
				errmess="Inserire l'anagrafica";
				errfield="idreg";
				return false;
			}

			return true;
		}
	}
    
    

}
