
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

namespace meta_servicepayment
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_servicepayment : Meta_easydata 
	{
		public Meta_servicepayment(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "servicepayment") 
		{
			EditTypes.Add("default");
            EditTypes.Add("assegnazioneautomatica");
			EditTypes.Add("detail");
            ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName) 
		{
			
			if (FormName=="detail") 
			{
				DefaultListType="detail";
				Name="Pagamento";
				return GetFormByDllName("servicepayment_detail");
			}
            if (FormName == "assegnazioneautomatica")
            {
                Name = "Assegnazione Automatica del Pagamento";
                return GetFormByDllName("servicepayment_assegnazioneautomatica");
            }

			return null;
		}			

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ypay",GetSys("esercizio"));
			SetDefault(PrimaryTable,"is_delivered", "N");
			SetDefault(PrimaryTable,"is_changed", "N");
			SetDefault(PrimaryTable,"is_blocked", "N");
		}

		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach(DataColumn C in T.Columns) 	
				{
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yservreg","Es.Incarico",nPos++);
				DescribeAColumn(T, "nservreg","N.Incarico",nPos++);				
				DescribeAColumn(T, "ypay","Es.Pagamento",nPos++);
				DescribeAColumn(T, "semesterpay","Semestre pagamento",nPos++);
//				DescribeAColumn(T, "expectedamount","Importo previsto",nPos++);
				DescribeAColumn(T, "payedamount","Importo pagato",nPos++);
//				DescribeAColumn(T, "payment","Saldo",nPos++);
				DescribeAColumn(T, "is_delivered","Pag.Trasmesso",nPos++);
				DescribeAColumn(T, "is_changed","Pag.Modificato",nPos++);
				DescribeAColumn(T, "is_blocked","Pag.Bloccato",nPos++);
			}
		}  

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
		
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

	}

}
