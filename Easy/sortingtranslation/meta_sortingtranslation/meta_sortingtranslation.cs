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

using System;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_sortingtranslation//meta_traduzioneclassificazioni//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_sortingtranslation : Meta_easydata
	{
		public Meta_sortingtranslation(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sortingtranslation") 
		{		
			Name="Traduzione classificazioni";
			EditTypes.Add("dettaglio");
			ListingTypes.Add("destinazione");
		}

		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			if (ListingType=="destinazione") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");
                DescribeAColumn(T, "!sortingkindmaster", "", "sorting.idsorkind");
                DescribeAColumn(T, "!sortingkindchild", "", "classmovimenti_dest.idsorkind");
				DescribeAColumn(T,"!tipo1", "Tipo sorg.", "sortingkind.description");
				DescribeAColumn(T,"!codice1", "Codice sorg.", "sorting.sortcode");
				DescribeAColumn(T,"!classificazione1", "Class. sorg.", "sorting.description");
				DescribeAColumn(T,"!tipo2", "Tipo dest.", "tipoclassmovimenti_dest.description");
				DescribeAColumn(T,"!codice2", "Codice dest.", "classmovimenti_dest.sortcode");
				DescribeAColumn(T,"!classificazione2", "Class. dest.", "classmovimenti_dest.description");
				DescribeAColumn(T,"!frazione","fraz.", "");
				ComputeRowsAs(T, ListingType);
			}
		}

		public override void CalculateFields(System.Data.DataRow R, string listtype) 
		{
			R["!frazione"]= R["numerator"]+"/"+R["denominator"];
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="dettaglio") 
			{
				return MetaData.GetFormByDllName("sortingtranslation_dettaglio");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			long numeratore = CfgFn.GetNoNullInt32(R["numerator"]);
			long denominatore = CfgFn.GetNoNullInt32(R["denominator"]);
			if (denominatore <= 0) 
			{
				errmess = "Il denominatore deve essere maggiore di zero";
				errfield = "denominator";
				return false;
			}
			if (numeratore <= 0) 
			{
				errmess = "Il numeratore deve essere maggiore di zero";
				errfield = "numerator";
				return false;
			}
			if (numeratore > denominatore) 
			{
				errmess = "Il numeratore deve essere minore o uguale al denominatore";
				errfield = "numerator";
				return false;
			}

			long sommaNum, sommaDen;
			getPorzioneAncoraDaClassificare(R, out sommaNum, out sommaDen);

			if (sommaDen == 0) 
			{
				MessageBox.Show("Impossibile controllare la somma delle frazioni.\r\nCorreggere i dati esistenti!");
			} 
			else if (sommaNum <= 0) 
			{
				MessageBox.Show("La somma delle frazioni supera 1.\r\nCorreggere i dati esistenti!");
			} 
			else if (sommaNum * denominatore < sommaDen * numeratore)
			{

				errmess = "La porzione da classificare deve essere minore o uguale a "+sommaNum+"/"+sommaDen;
				errfield = "numerator";
				return false;
			}

			return base.IsValid (R, out errmess, out errfield);
		}

		public long massimoComuneDivisore(long x, long y) 
		{
			while (y != 0) 
			{
				long m = x % y;
				x = y;
				y = m;
			}
			return x;
		}

		public void getPorzioneAncoraDaClassificare(DataRow R, out long sommaNum, out long sommaDen) 
		{
			sommaDen = 1;
			sommaNum = 1;
            DataRow DestKind = ExtraParameter as DataRow;
            if (DestKind == null) return;
            object codiceTipoClassChild = DestKind["idsorkind"];// R["!sortingkindchild"];
			object idClassChild = R["idsortingchild"];
			DataTable tradClassOrig = SourceRow.Table;
			string filtro = "(!sortingkindchild = "+QueryCreator.quotedstrvalue(codiceTipoClassChild, false)
				+ ") and (idsortingchild <> "+QueryCreator.quotedstrvalue(idClassChild, false)+")";

			foreach (DataRow r in tradClassOrig.Select(filtro)) 
			{
				if ((r["numerator"] != DBNull.Value) && (r["denominator"] != DBNull.Value))
				{
					long numeratore = (int) r["numerator"];
					long denominatore = (int) r["denominator"];
					sommaNum = sommaNum * denominatore - sommaDen * numeratore;
					sommaDen *= denominatore;
					long mcd = massimoComuneDivisore(sommaNum, sommaDen);
					if (mcd == 0) return;
					sommaNum /= mcd;
					sommaDen /= mcd;
				}
			}
			if (sommaDen < 0) {
				sommaNum = -sommaNum;
				sommaDen = -sommaDen;
			}
		}
	}
}
