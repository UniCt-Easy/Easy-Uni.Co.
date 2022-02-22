
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_deductionview//meta_tipodeduzioneview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_deductionview : Meta_easydata
	{
		public Meta_deductionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "deductionview") 
		{		
			Name = "Codici Deduzioni per Esercizio";
			ListingTypes.Add("default");
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
				DescribeAColumn(T,"iddeduction","");
				DescribeAColumn(T,"deductioncode","Codice Deduzione");
				DescribeAColumn(T,"ayear","Esercizio");
				DescribeAColumn(T,"calculationkind","Tipo di Calcolo");
				DescribeAColumn(T,"taxablecode","Codice Imponibile");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"longdescription","Descrizione Estesa");
				DescribeAColumn(T,"validitystart","Data Inizio Validità");
				DescribeAColumn(T,"validitystop","Data Fine Validità");
				DescribeAColumn(T,"evaluatesp","SP di calcolo");
				DescribeAColumn(T,"evaluationorder","Ordine di Valutazione");
				DescribeAColumn(T,"deductiontitle","Descrizione Cod. Deduzione");
				DescribeAColumn(T,"exemption","Franchigia");
				DescribeAColumn(T,"maximal","Massimale");
				DescribeAColumn(T,"rate","Aliquota");
				HelpForm.SetFormatForColumn(T.Columns["rate"],"p");
			}
		}

	}
}
