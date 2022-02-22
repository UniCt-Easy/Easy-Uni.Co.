
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
using metadatalibrary;
using metaeasylibrary;
//Pino: using dettentrateincassi; diventato inutile


namespace meta_incomelinkedproceeds{//meta_dettentrateincassi//
	/// <summary>
	/// Summary description for dettentrateincassi.
	/// </summary>
	public class Meta_incomelinkedproceeds : Meta_easydata {
		public Meta_incomelinkedproceeds(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomelinkedproceeds") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			Name = "Entrata collegate";
			DefaultListType = "default";
			if (FormName=="default") return MetaData.GetFormByDllName("incomelinkedproceeds_default");//PinoRana
			return null;
		}			
    
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			DescribeAColumn(T,"idinc","");
			DescribeAColumn(T,"idlinkedincome","Codice");
			DescribeAColumn(T,"!descrizione","Descrizione","linkedincome.description");
			DescribeAColumn(T,"amount","Importo");
		}
		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess, out errfield))return false;
			if (R["amount"]==DBNull.Value){
				errmess= "E' necessario specificare l'importo";
				errfield="amount";
				return false;
			}
			return true;
		}

	}
}
