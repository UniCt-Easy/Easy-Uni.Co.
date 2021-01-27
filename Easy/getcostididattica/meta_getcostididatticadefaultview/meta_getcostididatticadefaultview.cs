
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_getcostididatticadefaultview
{
    public class Meta_getcostididatticadefaultview : Meta_easydata 
	{
        public Meta_getcostididatticadefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "getcostididatticadefaultview") {
				Name = "Riepilogo dei costi degli affidamenti";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"aa","idaffidamento","idcontrattokind","idcorsostudio","iddidprog","iddidprogcurr","idreg_docenti","idsede"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "getcostididattica_corsostudio asc , getcostididattica_sede asc , aa asc , aaprogrammata asc , getcostididattica_curriculum asc , getcostididattica_insegnamento asc , getcostididattica_modulo asc , getcostididattica_affidamento asc , getcostididattica_docente asc , getcostididattica_ruolo asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
