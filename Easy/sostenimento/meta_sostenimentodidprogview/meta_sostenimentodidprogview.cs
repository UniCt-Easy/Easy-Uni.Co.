
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


namespace meta_sostenimentodidprogview
{
    public class Meta_sostenimentodidprogview : Meta_easydata 
	{
        public Meta_sostenimentodidprogview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sostenimentodidprogview") {
				Name = "Sostenimenti";
			EditTypes.Add("didprog");
			ListingTypes.Add("didprog");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio","iddidprog","idiscrizione","idreg","idsostenimento"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}