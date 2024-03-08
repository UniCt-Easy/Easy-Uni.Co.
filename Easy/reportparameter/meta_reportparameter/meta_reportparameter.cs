
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
using metadatalibrary;

namespace meta_reportparameter//meta_reportparameter//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_reportparameter : Meta_easydata
	{
		public Meta_reportparameter(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "reportparameter") 
		{
			EditTypes.Add("single");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="single")
			{
				Name= "Parametro del prospetto";
				//DefaultListType="default";
				return GetFormByDllName("reportparameter_single");
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "systype", "String");
			SetDefault(PrimaryTable, "tag", "");
			SetDefault(PrimaryTable, "hintkind", "NOHINT");
			SetDefault(PrimaryTable, "iscombobox", "N");
			SetDefault(PrimaryTable, "noselectionforall", "N");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T,"number","Numero");
				DescribeAColumn(T,"paramname","Nome");
				DescribeAColumn(T,"description","Titolo");
				DescribeAColumn(T,"systype","Tipo");
				DescribeAColumn(T,"tag","Tag");
			}
		}


		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 



			if (R["number"]==DBNull.Value)
			{
				errmess="Il campo \"Numero\" è obbligatorio";
				errfield="number";
				return false;
			}

			if (Convert.ToInt16(R["number"]) < 0 || Convert.ToInt16(R["number"]) > 100)
			{
				errmess="Il campo \"Numero\" ammette valori compresi tra 0 e 100";
				errfield="number";
				return false;
			}

			if (R["hint"]==DBNull.Value && R["hintkind"].ToString()=="O")
			{
				errmess="Il campo \"Altro valore\" è obbligatorio";
				errfield="hint";
				return false;
			}

			return true;
		}
     
	}
}
