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


namespace meta_istanza
{
    public class Meta_istanza : Meta_easydata 
	{
        public Meta_istanza(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanza") {
				Name = "Istanze di immatricolazione -istanza";
			EditTypes.Add("imm_seg");
			ListingTypes.Add("imm_seg");
			EditTypes.Add("imm_seganagstu");
			ListingTypes.Add("imm_seganagstu");
			EditTypes.Add("imm_seganagstupre");
			ListingTypes.Add("imm_seganagstupre");
			EditTypes.Add("imm_seganagsturin");
			ListingTypes.Add("imm_seganagsturin");
			EditTypes.Add("imm_segpre");
			ListingTypes.Add("imm_segpre");
			EditTypes.Add("imm_segrin");
			ListingTypes.Add("imm_segrin");
			EditTypes.Add("seganagstusonpre");
			ListingTypes.Add("seganagstusonpre");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idistanza","idreg_studenti"};

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
