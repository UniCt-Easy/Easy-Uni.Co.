/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_corsostudio
{
    public class Meta_corsostudio : Meta_easydata 
	{
        public Meta_corsostudio(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "corsostudio") {
				Name = "Corsi di studio";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("dotmas");
			ListingTypes.Add("dotmas");
			EditTypes.Add("ingresso");
			ListingTypes.Add("ingresso");
			EditTypes.Add("stato");
			ListingTypes.Add("stato");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
