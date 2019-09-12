/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_upbdefaultview
{
    public class Meta_upbdefaultview : Meta_easydata 
	{
        public Meta_upbdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "upbdefaultview") {
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		/// <summary>
		/// Impostare la chiave, serve per le viste, non per le tabelle!!
		/// </summary>
		//private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
		//public override string[] primaryKey() {
		//    return mykey;
		//}

		private string[] mykey = new string[] {"idupb"};

		public override string[] primaryKey() {
			return mykey;
		}

		//protected override Form GetForm(string FormName) {
		//    //if (FormName == "default") {
		//    //    DefaultListType = "default";
		//    //    Name = "Descrizione Form";
		//    //    return MetaData.GetFormByDllName("upbdefaultview_default");
		//    //}
		//    return null;
		//}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			//T.setMySelector("ntabella", "nphase", 0);  //campo nphase  è selettore per calcolo di ntabella
			//T.setMySelector("ntabella", "ytabella", 0);//campo ytabella  è selettore per calcolo di ntabella
			//T.setAutoincrement("ntabella", null, null, 0);  //ntabella è campo ad autoincremento
			//T.setAutoincrement("idtabella", null, null, 0);  //idtabella è campo ad autoincremento

			//T.setMinimumTempValue("idtabella", 999900000);     //Da impostare  in caso di pericolo di conflitto
			//$Get_New_Row$
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		/// <summary>
		/// FilterRow, si usa per i grid filtrati
		/// </summary>
		/// <param name="R"></param>
		/// <param name="list_type"></param>
		/// <returns></returns>
		//public override bool FilterRow(DataRow R, string list_type) {
			//if (list_type == "form_contenitore") {
			//    if (R["chiave contenitore"] == DBNull.Value) return false;
			//    return true;
			//}

			//return true;
		//}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				//$IsValid$
			}

			return true;
		}

		//public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			//if (ListingType == "lista")
			//    return base.SelectOne(ListingType, filter, "upbdefaultviewview", Exclude);
			//else
			//return base.SelectOne(ListingType, filter, "upbdefaultview", Exclude);
		//}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idupb", "id voce upb (tabella upb)", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "upb_active", "attivo", nPos++);
						DescribeAColumn(T, "upb_assured", "Finanziamento certo (Non gestire assegnazione crediti/incassi)", nPos++);
						DescribeAColumn(T, "upb_cigcode", "Codice CIG, Codice identificativo di gara", nPos++);
						DescribeAColumn(T, "upb_codeupb", "codice upb", nPos++);
						DescribeAColumn(T, "upb_cupcode", "Codice CUP, Codice unico di progetto", nPos++);
						DescribeAColumn(T, "upb_expiration", "scadenza", nPos++);
						DescribeAColumn(T, "upb_flag", "flag vari", nPos++);
						DescribeAColumn(T, "upb_flagactivity", "Tipo attività", nPos++);
						DescribeAColumn(T, "upb_flagkind", "Funzione", nPos++);
						DescribeAColumn(T, "upb_granted", "Finanziamento concesso", nPos++);
						DescribeAColumn(T, "epupbkind_title", "ID Tipo UPB nell'economico patrimoniale (tabella epupbkind)", nPos++);
						DescribeAColumn(T, "treasurer_description", "Id cassiere (tabella treasurer)", nPos++);
						DescribeAColumn(T, "underwriter_description", "ID Ente finanziatore (tabella underwriter)", nPos++);
						DescribeAColumn(T, "upb_newcodeupb", "Codice di consolidamento", nPos++);
						DescribeAColumn(T, "upbparent_title", "chiave parent U.P.B. (tabella upb) ", nPos++);
						DescribeAColumn(T, "upb_previousappropriation", "Totale impegnato pregresso (previa informatizzazione)", nPos++);
						DescribeAColumn(T, "upb_previousassessment", "Totale accertato pregresso (previa informatizzazione)", nPos++);
						DescribeAColumn(T, "upb_printingorder", "Ordine di stampa", nPos++);
						DescribeAColumn(T, "upb_requested", "Finanziamento richiesto", nPos++);
						DescribeAColumn(T, "upb_rtf", "allegati", nPos++);
						DescribeAColumn(T, "upb_start", "data inizio", nPos++);
						DescribeAColumn(T, "upb_stop", "data fine", nPos++);
						DescribeAColumn(T, "upb_txt", "note testuali", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "epupbkind_title desc, upbparent_title desc, title desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
