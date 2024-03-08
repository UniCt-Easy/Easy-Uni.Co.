
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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//Pino: using Generalitamissioni; diventato inutile


namespace meta_itinerationparameter//meta_generalitamissioni//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationparameter : Meta_easydata 
	{
		public Meta_itinerationparameter(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "itinerationparameter") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Parametri generali per il calcolo della missione";
				//SearchEnabled = false;
				return MetaData.GetFormByDllName("itinerationparameter_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns
			(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				DescribeAColumn(T,"start","Decorrenza");
				DescribeAColumn(T,"italianexemption","Missioni in Italia");
				DescribeAColumn(T,"foreignexemption","Missioni all'Estero");
				DescribeAColumn(T,"admincarkmcost","Mezzo amministrazione");
				DescribeAColumn(T,"owncarkmcost","Mezzo proprio");
				DescribeAColumn(T,"footkmcost","A piedi");
				DescribeAColumn(T,"foreignhours","Ore");
			}
		}
	}
	
}

