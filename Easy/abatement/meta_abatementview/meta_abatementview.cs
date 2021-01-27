
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_abatementview//meta_tipodetrazioneview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_abatementview : Meta_easydata
	{
		public Meta_abatementview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "abatementview") 
		{		
			Name = "Codici Detrazioni per Esercizio";
			ListingTypes.Add("default");
		}

	    private string[] mykey = new string[] { "idabatement", "ayear"};
	    public override string[] primaryKey() {
	        return mykey;
	    }
        public override string GetStaticFilter(string ListingType) 
		{
			string filteresercizio;
			if (ListingType=="default") 
			{
				filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idabatement","");
				DescribeAColumn(T,"abatementcode","Codice Detrazione");
				DescribeAColumn(T,"ayear","Esercizio");
				DescribeAColumn(T,"calculationkind","Tipo di Calcolo");
				DescribeAColumn(T,"taxref","Codice Ritenuta");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"longdescription","Descrizione Estesa");
				DescribeAColumn(T,"validitystart","Data Inizio Validità");
				DescribeAColumn(T,"validitystop","Data Fine Validità");
				DescribeAColumn(T,"evaluatesp","SP di calcolo");
				DescribeAColumn(T,"evaluationorder","Ordine di Valutazione");
				DescribeAColumn(T,"abatementtitle","Descrizione Cod. Detrazione");
				DescribeAColumn(T,"exemption","Franchigia");
				DescribeAColumn(T,"maximal","Massimale");
				DescribeAColumn(T,"rate","Aliquota");
				DescribeAColumn(T,"appliance","Applicazione");
				HelpForm.SetFormatForColumn(T.Columns["rate"],"p");
			}
		}
	}
}
