
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
using metadatalibrary;
using metaeasylibrary;
//Pino: using ritenuteapplicate; diventato inutile



namespace meta_payedtaxf24ordview//meta_ritenuteapplicateview//
{
	/// <summary>
	/// Summary description for ritenuteapplicateview.
	/// </summary>
	public class Meta_payedtaxf24ordview : Meta_easydata 
	{
		public Meta_payedtaxf24ordview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "payedtaxf24ordview") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("trasmissione");
			Name = "";
		}
	
		public override bool FilterRow(DataRow R, string list_type)
		{
			if (list_type=="trasmissione")
			{
				if (R["idtrasmissioneritenute"]==DBNull.Value)return false;
				return true;
			}
			return true;
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name="Ritenute applicate F24 Ordinario";
				return MetaData.GetFormByDllName("payedtaxf24ordview_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);

			switch (ListingType) 
			{
				case "default":
					foreach (DataColumn C in T.Columns) 
					{
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

                    int nPos = 1;
					DescribeAColumn(T, "phase","Fase spesa", nPos++);
                    DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                    DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                    DescribeAColumn(T, "idf24ordinario", "Num. F24 Ord.", nPos++);
                    DescribeAColumn(T, "ayear", "Eserc. F24 Ord.", nPos++);
                    DescribeAColumn(T, "nmonth", "Mese F24 Ord.", nPos++);
                    DescribeAColumn(T, "registry", "Percipiente", nPos++);
                    DescribeAColumn(T, "department", "Dipartimento", nPos++);
                    DescribeAColumn(T, "expensedescription", "Descrizione pag.", nPos++);
                    DescribeAColumn(T, "adate", "Data", nPos++);
                    DescribeAColumn(T, "service", "Desc. prestazione", nPos++);
                    DescribeAColumn(T, "certificatekind", "Mod. certificazione", nPos++);
                    DescribeAColumn(T, "servicestart", "Data inizio prest.", nPos++);
                    DescribeAColumn(T, "servicestop", "Data fine prest.", nPos++);
                    DescribeAColumn(T, "description", "Desc. ritenuta", nPos++);
                    DescribeAColumn(T, "taxcategory", "Categoria", nPos++);
                    DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                    DescribeAColumn(T, "taxableoriginal", "Impon. originale", nPos++);
                    DescribeAColumn(T, "employrate", "Aliq. dip.", nPos++);
                    DescribeAColumn(T, "employnumerator", "Num. dip.", nPos++);
                    DescribeAColumn(T, "employdenominator", "Denom. dip.", nPos++);
                    DescribeAColumn(T, "employtax", "Rit. dip.", nPos++);
                    DescribeAColumn(T, "adminrate", "Aliq. amm.", nPos++);
                    DescribeAColumn(T, "adminnumerator", "Num. amm.", nPos++);
                    DescribeAColumn(T, "admindenominator", "Denom. amm.", nPos++);
                    DescribeAColumn(T, "admintax", "Rit. amm.", nPos++);
                    DescribeAColumn(T, "competencydate", "Data comp.", nPos++);
                    DescribeAColumn(T, "datetaxpay", "Data liq.", nPos++);
                    DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
                    DescribeAColumn(T, "address", "Indirizzo", nPos++);
                    DescribeAColumn(T, "cap", "C.A.P.", nPos++);
                    DescribeAColumn(T, "city", "Comune", nPos++);
                    DescribeAColumn(T, "country", "Provincia", nPos++);
                    DescribeAColumn(T, "nation", "Nazione", nPos++);
                    DescribeAColumn(T, "location", "Località", nPos++);
                    DescribeAColumn(T, "ytaxpay", "Eserc. liquidazione", nPos++);
                    DescribeAColumn(T, "ntaxpay", "Num. liquidazione", nPos++);
					DescribeAColumn(T, "start", "Data inizio liq.", nPos++);
					DescribeAColumn(T, "stop", "Data fine liq.", nPos++);
					DescribeAColumn(T, "abatements", "Detrazioni", nPos++);
					DescribeAColumn(T, "nbracket", "n. scaglione", nPos++);
					DescribeAColumn(T, "taxablegross", "Imponibile lordo", nPos++);
					DescribeAColumn(T, "taxablenet", "Imponibile netto", nPos++);
					DescribeAColumn(T, "codeser", ".Codice prestazione", nPos++);


					break;
				case "trasmissione":
					foreach (DataColumn C in T.Columns) 
					{
						DescribeAColumn(T, C.ColumnName, "", -1);
					}
                    int nPos1 = 1;
                    DescribeAColumn(T, "registry", "Percipiente", nPos1++);
                    DescribeAColumn(T, "service", "Prestazione", nPos1++);
                    DescribeAColumn(T, "taxref", "Cod. Ritenuta", nPos1++);
                    DescribeAColumn(T, "description", "Ritenuta", nPos1++);
                    DescribeAColumn(T, "taxable", "Imponibile", nPos1++);
                    DescribeAColumn(T, "employtax", "Riten. dipend.", nPos1++);
                    DescribeAColumn(T, "admintax", "Riten. ammin.", nPos1++);
                    DescribeAColumn(T, "ymov", "Esercizio", nPos1++);
                    DescribeAColumn(T, "datetaxpay", "Data liquid.", nPos1++);
                    DescribeAColumn(T, "esercdocpagamento", "Eserc. Mandato", nPos1++);
                    DescribeAColumn(T, "numdocpagamento", "Num. Mandato", nPos1++);
                    DescribeAColumn(T, "datacontabilemandato", "Data Contabile Mandato", nPos1++);
                    DescribeAColumn(T, "ytaxpay", "Eserc. Liquidazione", nPos1++);
                    DescribeAColumn(T, "ntaxpay", "Num. Liquidazione", nPos1++);
                    DescribeAColumn(T, "department", "Dipartimento", nPos1++);
                    FilterRows(T);
					break;
			}
		}
	}
}
