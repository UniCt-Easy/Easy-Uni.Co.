/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using funzioni_configurazione;

namespace meta_taxableminmax//meta_minimalemassimaleimponibile//
{
	/// <summary>
	/// Summary description for Meta_minimalemassimale.
	/// </summary>
	public class Meta_taxableminmax : Meta_easydata
	{
		public Meta_taxableminmax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxableminmax") 
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType = "default";
				ActAsList();
				Name = "Minimale/Massimale Imponibile";
				return MetaData.GetFormByDllName("taxableminmax_default");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			
			if (R["taxablecode"].ToString() == "")
			{
				errmess = "Selezionare l'imponibile di riferimento";
				errfield = "taxablecode";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["startmonth"]) <= 0)
			{
				errmess = "Selezionare il mese iniziale";
				errfield = "startmonth";
				return false;
			}
			if (CfgFn.GetNoNullInt32(R["stopmonth"]) <= 0)
			{
				errmess = "Selezionare il mese finale";
				errfield = "stopmonth";
				return false;
			}
			if(CfgFn.GetNoNullInt32(R["startmonth"]) > CfgFn.GetNoNullInt32(R["stopmonth"]))
			{
				errmess = "Il mese finale non può essere inferiore a quello iniziale";
				errfield = "stopmonth";
				return false;
			}
			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"taxablecode","Codice Imponibile");
				DescribeAColumn(T,"startmonth","Mese iniziale");
				DescribeAColumn(T,"stopmonth", "Mese finale");
				DescribeAColumn(T,"minimum", "Importo Minimale");
				DescribeAColumn(T,"maximal", "Importo Massimale");
			}
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}
	}
}
