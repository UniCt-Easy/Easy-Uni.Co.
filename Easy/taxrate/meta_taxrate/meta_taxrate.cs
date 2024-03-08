
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
//using aliquotaritenuta;
//Pino: using aliquotaritenutasingle; diventato inutile
//Pino: using aliquotaritenutalistanew; diventato inutile
using metadatalibrary;

namespace meta_taxrate//meta_aliquotaritenuta//
{
		public class Meta_taxrate : Meta_easydata
	{
		public Meta_taxrate(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxrate")
		{
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
			{
				Name = "Aliquote per Scaglioni";
				ActAsList();
				StartEmpty=true;
				SearchEnabled=false;
				return MetaData.GetFormByDllName("taxrate_default");//PinoRana
			}
			
			if (FormName=="single") 
			{
				Name = "Aliquote";
				return MetaData.GetFormByDllName("taxrate_single");//PinoRana
			}
			return null;
		}
		public override void DescribeColumns(DataTable T, string ListingType){
 			base.DescribeColumns(T, ListingType);
			//AddColumn(T, "datainiziostrutturastringa", typeof(string), "strutturaaliquote.datainiziostruttura",
			//	"Data");
			DescribeAColumn(T,"descrizioneritenuta","Tipo ritenuta", "tax.description");
            DescribeAColumn(T,"taxcode","");
			DescribeAColumn(T,"validitystart","Data");
			//DescribeAColumn(T,"!datainiziostrutturastringa","Data");
			DescribeAColumn(T,"nbracket","Numero scaglione");
			DescribeAColumn(T,"ratestart","Data decorrenza");
			DescribeAColumn(T,"taxablenumerator","Quota num. imp.");
			DescribeAColumn(T,"taxabledenominator","Quota den. imp.");
			DescribeAColumn(T,"adminrate","Aliquota ammin.");
			DescribeAColumn(T,"adminnumerator","Quota num. amm.");
			DescribeAColumn(T,"admindenominator","Quota den. amm.");
			DescribeAColumn(T,"employrate","Aliquota dipend.");
			DescribeAColumn(T,"employnumerator","Quota num. dip.");
			DescribeAColumn(T,"employdenominator","Quota den. dip.");
			DescribeAColumn(T,"DELETE_noupdate","");
			DescribeAColumn(T,"DELETE_nodelete","");
			DescribeAColumn(T,"cu","");
			DescribeAColumn(T,"ct","");
			DescribeAColumn(T,"lu","");
			DescribeAColumn(T,"lt","");
			//ComputeRowsAs(T, "default");
		}
		//public override void CalculateFields(DataRow R, string list_type) 
		//{
		//	R["!datainiziostrutturastringa"] = R["datainiziostruttura"].ToString();
		//}  

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (R["nbracket"].ToString()=="0"){
				errfield=null;
				errmess="Non è possibile definire più volte uno scaglione\n"+
					"sulla stessa data inizio aliquota.";
				return false;
			}
			return true;
		}
	}
}
