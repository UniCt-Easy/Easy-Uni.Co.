
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
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_pat {//meta_pat//
	/// <summary>
	/// Summary description for Meta_pat.
	/// </summary>
	public class Meta_pat : Meta_easydata {
		public Meta_pat(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pat") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType = "default";
				Name = "Posizione Assicurativa Territoriale";
				return MetaData.GetFormByDllName("pat_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idpat","");
				DescribeAColumn(T,"patcode","Codice Posizione Ass. Territoriale");
				DescribeAColumn(T, "cc", "Contro Codice");
				DescribeAColumn(T, "codicesede", "Codice Sede");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"validitystart", "Data Inizio Val.");
				DescribeAColumn(T,"validitystop", "Data Fine Val.");
				DescribeAColumn(T,"active", "Attivo");
				DescribeAColumn(T,"employrate","Aliquota dipendente");
				DescribeAColumn(T,"adminrate","Aliquota amministraz");
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
			}
		}
		
		private bool controllaMatricolaINAIL(string matINAIL) {
            
			matINAIL = matINAIL.PadLeft(10,'0');
			if (matINAIL == "0000000000") return false;
			foreach (char c in matINAIL) {
				if ((c<'0')||(c>'9')) {
					return false;
				}
			}
			string controcodiceDic = matINAIL.Substring(8);
			int sp = int.Parse(matINAIL.Substring(0, 1)) * 7 
				+ int.Parse(matINAIL.Substring(1, 1)) 
				+ int.Parse(matINAIL.Substring(2, 1)) * 3 
				+ int.Parse(matINAIL.Substring(3, 1)) * 5 
				+ int.Parse(matINAIL.Substring(4, 1)) * 7 
				+ int.Parse(matINAIL.Substring(5, 1)) 
				+ int.Parse(matINAIL.Substring(6, 1)) * 3 
				+ int.Parse(matINAIL.Substring(7, 1)) * 5;
			string spString = sp.ToString();
			int spLength = spString.Length;
			int spU2 = -1;
			if(spLength == 1)
				spU2 = int.Parse(spString.Substring(spLength - 1));
			else
				if(spLength > 1)
					spU2 = int.Parse(spString.Substring(spLength - 2));
			string complemento = (100 - spU2).ToString();
			int primaCifra = int.Parse(complemento.Substring(complemento.Length - 1));
			int secondaCifra = int.Parse(complemento) % 11;
			if(secondaCifra == 10)
				secondaCifra = 1;
			string controCodice = primaCifra.ToString() + secondaCifra.ToString();
			if(complemento == "100" && (controcodiceDic == "00" || controcodiceDic == "01"))
				controCodice = "00";
			return controCodice == controcodiceDic;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
		    if (R["patcode"].ToString().Length == 10) {
		        if (!controllaMatricolaINAIL(R["patcode"].ToString())) {
		            errfield = "patcode";
		            errmess = "'" + R["patcode"] + "' non è un codice PAT valido";
		            return false;
		        }
		    }

		    if (R["validitystart"]==DBNull.Value) {
				errfield="validitystart";
				errmess="La Data Inizio Validità è obbligatoria";
				return false;
			}
			
			if (R["validitystop"]==DBNull.Value) {
				errfield="validitystop";
				errmess="La Data Fine Validità è obbligatoria";
				return false;
			}

			DateTime dataInizio = (DateTime)R["validitystart"];
			DateTime dataFine = (DateTime)R["validitystop"];
			DateTime dataRifer = dataInizio.AddYears(1);

			if (dataInizio > dataFine) {
				errfield="validitystart";
				errmess="La Data Inizio Validità non può superare la Data Fine";
				return false;
			}

			if (dataFine>=dataRifer) {
				errfield="validitystop";
				errmess="Il periodo di validità non può superare un anno";
				return false;
			}

			return true;
		}
		


		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idpat"],null,null,4);
			return base.Get_New_Row(ParentRow, T);
		}
	}
}
