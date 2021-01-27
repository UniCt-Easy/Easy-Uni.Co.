
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
using metadatalibrary;
using metaeasylibrary;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
//$CustomUsing$


namespace meta_progetto
{
    public class Meta_progetto : Meta_easydata 
	{
        public Meta_progetto(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "progetto") {
				Name = "Attività e progetti";
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		//$GetSortings$

		//$GetStaticFilter$
			
		public string GenerateDetail(JValue prm1, JValue prm2, JValue prm3) {
			var errmsg = "";
			base.dbConn.CallSP("GenerateProgettoDetail", new string[3] {prm1.ToString(), prm2.ToString(), prm3.ToString() }, -1, out errmsg);
			if (string.IsNullOrEmpty(errmsg))
				return "OK. I dettagli sono stati generati";
			else
				return "KO. " + errmsg;
		}
		//$CustomCode$
    }
}
