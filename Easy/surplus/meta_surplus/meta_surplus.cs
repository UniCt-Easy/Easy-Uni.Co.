
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
using System.Windows.Forms;
using System.Data;
//Pino: using situazioneammin; diventato inutile
using metaeasylibrary;
using metadatalibrary;

namespace meta_surplus//meta_situazioneammin//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_surplus : Meta_easydata
	{
		public Meta_surplus(DataAccess Conn, MetaDataDispatcher Dispatcher)
			:base(Conn, Dispatcher, "surplus") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Situazione Finanziaria / Amministrativa";
		}

		protected override Form GetForm(string FormName)
		{
			DefaultListType="default";
			if (FormName=="default") return MetaData.GetFormByDllName("surplus_default");//PinoRana
			return null;
		}			
		
		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "previsiondate", GetSys("datacontabile"));
		}
	
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "");
			
			DescribeAColumn(T, "ayear", "Eserc.");
			DescribeAColumn(T, "previsiondate", "Data presunto");
			DescribeAColumn(T, "startfloatfund", "Avanzo cassa al 1/1");
			DescribeAColumn(T, "proceedstilldate", "Inc. 1/1 - Data");
			DescribeAColumn(T, "paymentstilldate", "Pag. 1/1 - Data");
			DescribeAColumn(T, "proceedstoendofyear", "Inc. pres. Data - 31/12");
			DescribeAColumn(T, "paymentstoendofyear", "Pag. pres. Data - 31/12");
			DescribeAColumn(T, "supposedpreviousrevenue", "Res. att. pres. prec.");
			DescribeAColumn(T, "supposedcurrentrevenue", "Res. att. pres. corr.");
			DescribeAColumn(T, "supposedpreviousexpenditure", "Res. pass. pres. prec.");
			DescribeAColumn(T, "supposedcurrentexpenditure", "Res. pass. pres. corr.");
			DescribeAColumn(T, "competencyproceeds", "Inc. competenza");
			DescribeAColumn(T, "residualproceeds", "Inc. residui");
			DescribeAColumn(T, "competencypayments", "Pag. competenza");
			DescribeAColumn(T, "residualpayments", "Pag. residui");
			DescribeAColumn(T, "previousrevenue", "Res. att. prec.");
			DescribeAColumn(T, "currentrevenue", "Res. att. corr.");
			DescribeAColumn(T, "previousexpenditure", "Res. pass. prec.");
			DescribeAColumn(T, "currentexpenditure", "Res. pass. corr.");
		}

	}
}


