
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
using funzioni_configurazione;

namespace meta_upbmonthlycap {
	/// <summary>
	/// Summary description for Meta_upb.
	/// </summary>
	public class Meta_upbmonthlycap : Meta_easydata {
		public Meta_upbmonthlycap(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "upbmonthlycap") {	
            Name = "Limite mensile di Costo per U.P.B.";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {			
            if (FormName == "default") {
                Name = "Limite mensile di Costo per U.P.B.";
                DefaultListType="default";
                return GetFormByDllName("upbmonthlycap_default");
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));  
			SetDefault(PrimaryTable, "amount_reserve", 0);
			for (int i = 1; i < 13; i++) {
				SetDefault(PrimaryTable, "amount_" + i.ToString(), 0);
			}			
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			
			for (int i = 1; i < 13; i++) {
				if (CfgFn.GetNoNullDecimal(R["amount_" + i.ToString()]) < 0) {
					errmess = "Il limite mensile di costo di " + ConvertNumberToMonth(i) + " non può essere negativo.";
					errfield = "amount_" + i.ToString();
					return false;
				}
			}

			if (CfgFn.GetNoNullDecimal(R["amount_reserve"]) < 0) {
				errmess = "L'importo Riserva non può essere negativo.";
				errfield = "amount_reserve";
				return false;
			}

			if (R["idupb"] == DBNull.Value) {
				errmess = "Attenzione! L'UPB non può essere nullo.";
				errfield = "idupb";
				return false;
			}

			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)	{           
               return base.SelectOne(ListingType, filter, "upbmonthlycapview", Exclude);
		}

		private string ConvertNumberToMonth(int numMounth) {
			string mounth = "";

			switch (numMounth) {
				case 1:
					mounth = "Gennaio";
					break;
				case 2:
					mounth = "Febbraio";
					break;
				case 3:
					mounth = "Marzo";
					break;
				case 4:
					mounth = "Aprile";
					break;
				case 5:
					mounth = "Maggio";
					break;
				case 6:
					mounth = "Giugno";
					break;
				case 7:
					mounth = "Luglio";
					break;
				case 8:
					mounth = "Agosto";
					break;
				case 9:
					mounth = "Settembre";
					break;
				case 10:
					mounth = "Ottobre";
					break;
				case 11:
					mounth = "Novembre";
					break;
				case 12:
					mounth = "Dicembre";
					break;
			}

			return mounth;
		}
	}
}
