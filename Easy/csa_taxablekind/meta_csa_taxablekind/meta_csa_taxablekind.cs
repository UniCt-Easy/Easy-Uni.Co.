
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_taxablekind
{

	public class Meta_csa_taxablekind : Meta_easydata 
	{
		public Meta_csa_taxablekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_taxablekind") {		
			Name= "Voci di Comunicazione 8000 - Tipo Imponibile";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				ActAsList();    
				return MetaData.GetFormByDllName("csa_taxablekind_default");
				
			}
			return null;
		}			
    
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			DescribeAColumn(T,"csataxablecode","Voce8000");
			DescribeAColumn(T,"description","Descrizione");
            DescribeAColumn(T, "active", "Attivo");
		}
        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }
	}


}


