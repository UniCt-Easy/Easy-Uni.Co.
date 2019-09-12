/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
//Pino: using customgroupoperation; diventato inutile
//Pino: using customgroupprint; diventato inutile
//Pino: using wizard_customgroupoperation_report; diventato inutile
//Pino: using wizard_customgroupoperation_tabelle; diventato inutile

namespace meta_customgroupoperation//meta_customgroupoperation//
{
	/// <summary>
	/// Summary description for customgroupoperation.
	/// </summary>
	public class Meta_customgroupoperation : Meta_easydata
	{
		public Meta_customgroupoperation(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "customgroupoperation") {		
			EditTypes.Add("default");
			EditTypes.Add("print");
			EditTypes.Add("wiz_print");
			EditTypes.Add("wiz_tabelle");
			ListingTypes.Add("default");
			ListingTypes.Add("print");
			
			//
			// TODO: Add constructor logic here
			//
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Gestione Sicurezza Tabelle per i gruppi";
				DefaultListType="default";
				return MetaData.GetFormByDllName("customgroupoperation_default");//PinoRana
			}
			if (FormName=="print") {
				Name="Gestione Sicurezza Tabelle per le stampe";
				DefaultListType="print";
				return MetaData.GetFormByDllName("customgroupoperation_print");//PinoRana
				
			}
			if (FormName=="wiz_print") {
				//Name="Wizard Gestione Sicurezza Tabelle per le stampe";
				SearchEnabled=false;
				return MetaData.GetFormByDllName("customgroupoperation_wiz_print");//PinoRana
			}
			if (FormName=="wiz_tabelle") {
				//Name="Wizard Gestione Sicurezza Tabelle per le stampe";
				SearchEnabled=false;
				return MetaData.GetFormByDllName("customgroupoperation_wiz_tabelle");//PinoRana
			}

			return null;
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"idgroup","Codice gruppo");
				DescribeAColumn(T,"tablename","Nome tabella");
				DescribeAColumn(T,"operation","Operazione");
				DescribeAColumn(T,"defaultisdeny","Default");
				DescribeAColumn(T,"allowcondition","Condizione di consenti");
				DescribeAColumn(T,"denycondition","Condizione di divieto");
			}
			if (ListingType=="print"){
				DescribeAColumn(T,"idgroup","Codice gruppo");
				DescribeAColumn(T,"tablename","Nome Report");
				DescribeAColumn(T,"operation","");
				DescribeAColumn(T,"defaultisdeny","Default");
				DescribeAColumn(T,"allowcondition","Condizione di consenti");
				DescribeAColumn(T,"denycondition","Condizione di divieto");
			}
			return;
		}
	}
}

