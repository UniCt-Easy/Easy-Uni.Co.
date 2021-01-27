
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

namespace meta_itinerationexpensedownview//meta_missionemovspesadownview//
{
	/// <summary>
	/// Summary description for missionemovspesadownview.
	/// </summary>
	public class Meta_itinerationexpensedownview : Meta_easydata {
		public Meta_itinerationexpensedownview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "itinerationexpensedownview") {
			ListingTypes.Add("default");
		}
		
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
			sorting="nphase asc,ymov desc,nmov desc";
			return sorting;
			}
			return base.GetSorting (ListingType);
			
		}
		
		   
		public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T, "phase", "Fase",nPos++);
				DescribeAColumn(T, "yitineration", "Eserc. miss.",nPos++);
				DescribeAColumn(T, "nitineration", "Num. miss.",nPos++);
				DescribeAColumn(T, "ycreation", "Eserc. creazione.",nPos++);
				DescribeAColumn(T, "ymov", "Eserc. movimento.",nPos++);
				DescribeAColumn(T, "nmov", "Num. movimento",nPos++);
				DescribeAColumn(T, "movkind", "Tipo movimento",nPos++);
				DescribeAColumn(T, "finance", "Denom. Bil.",nPos++);
				DescribeAColumn(T, "upb", "U.P.B.",nPos++);
				DescribeAColumn(T, "registry", "Percipiente",nPos++);
				DescribeAColumn(T, "doc", "Documento",nPos++);
				DescribeAColumn(T, "docdate", "Data Doc.",nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "amount", "Importo Originale",nPos++);
				DescribeAColumn(T, "ayearstartamount", ".Imp.Esercizio",nPos++);
				DescribeAColumn(T, "curramount", "Imp.Corrente",nPos++);
				DescribeAColumn(T, "available", "Disponibile",nPos++);
				DescribeAColumn(T, "manager", "Responsabile",nPos++);
				DescribeAColumn(T, "adate", "Data Contabile",nPos++);
				DescribeAColumn(T, "ypay", "Eserc.Mand.",nPos++);
				DescribeAColumn(T, "npay", "Num.Mand.",nPos++);
				DescribeAColumn(T, "codeupb", ".Cod. U.P.B.");
				DescribeAColumn(T, "idexp", ".idexp");
				DescribeAColumn(T, "regmodcode", ".Tipo Modalità");
                DescribeAColumn(T, "idregistrypaymethod", ".#");
				DescribeAColumn(T, "idpaymethod", ".Codice Mod.Pag.");
				DescribeAColumn(T, "cin", ".Cin");
				DescribeAColumn(T, "idbank", ".Cod.ABI");
				DescribeAColumn(T, "idcab", ".CAB");
				DescribeAColumn(T, "cc", ".Conto");
				DescribeAColumn(T, "paymentdescr", ".Desc.Pag.");
				DescribeAColumn(T, "service", ".Prestazione");
				DescribeAColumn(T, "servicestart", ".Data Inizio Prest.");
				DescribeAColumn(T, "servicestop", ".Data Fine Prest.");
				DescribeAColumn(T, "ivaamount", ".Importo prestazione 1");
				DescribeAColumn(T, ".fulfilled", ".Mov.Cop.");
				DescribeAColumn(T, ".autotaxflag", ".Auto Rit.");
				DescribeAColumn(T, ".autoclawbackflag", ".Auto rec.");
				DescribeAColumn(T, ".autokind", ".Tipo Auto");
				DescribeAColumn(T, ".flagarrear", ".Competenza");
				DescribeAColumn(T, ".expiration", ".Data Scadenza");

			}
		}
	}
}
