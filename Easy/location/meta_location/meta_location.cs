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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using funzioni_configurazione;
using HelpWeb;
//$CustomUsing$


namespace meta_location
{
	public class Meta_location : Meta_easydata
	{
		public Meta_location(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "location") {
			Name = "Piano delle Ubicazioni";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("seg_child");
			ListingTypes.Add("seg_child");
			EditTypes.Add("aula");
			ListingTypes.Add("aula");
			EditTypes.Add("aula_seg_child");
			ListingTypes.Add("aula_seg_child");
			EditTypes.Add("edifici");
			ListingTypes.Add("edifici");
			//$EditTypes$
		}

		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				Name = "Piano delle Ubicazioni";
				CanInsertCopy = false;
				ActAsList();
				IsTree = true;
				DefaultListType = "default";
				return MetaData.GetFormByDllName("location_default");//PinoRana
			}
			return null;
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			DataTable Levels = T.DataSet.Tables["locationlevel"];
			if (Levels == null) return null;
			bool linear=false;
			int level;
			string codprefix;
			if (ParentRow != null) {
				level = Convert.ToInt32(ParentRow["nlevel"]) + 1;
				codprefix = ParentRow["locationcode"].ToString();
			} else {
				level = 1;
				codprefix = "";
			}
			int levelmax = CfgFn.GetNoNullInt32(Levels.Compute("max(nlevel)",null));
			if (level > levelmax) {
				MessageBox.Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			int len=6;
			//string kind = "A";
			DataRow [] levrow = Levels.Select("(nlevel="+QueryCreator.quotedstrvalue(level, false)+")");

			if (levrow.Length != 1) return null;

			len = Convert.ToInt32(levrow[0]["codelen"].ToString());
			int flag = CfgFn.GetNoNullInt32(levrow[0]["flag"]);
			bool usable = ((flag & 2) != 0);
			bool numerico = ((flag & 1) == 0);
			bool alfanumerico = ((flag & 1) != 0);
			bool restart = ((flag & 4) != 0);

			//kind = levrow[0]["codekind"].ToString();
			if (!restart) {
				linear = true;
			}
			T.Columns["locationcode"].ExtendedProperties["length"] = codprefix.Length + len;

			SetDefault(T, "nlevel", level);

			RowChange.MarkAsAutoincrement(T.Columns["idlocation"], null, null, 10);

			if (alfanumerico) {
				SetDefault(T, "locationcode", codprefix);
				RowChange.ClearAutoIncrement(T.Columns["locationcode"]);
			} else {
				RowChange.MarkAsAutoincrement(T.Columns["locationcode"],
					null, codprefix, len, linear);
			}
			return base.Get_New_Row(ParentRow, T);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "default")
				return base.SelectOne(ListingType, filter, "locationview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

		//modifiche luigi 8179
		public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
			int maxDepth = 9; bool withdescr = true;

			if (ListingType == "default") {
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "idlocation", "Id Ubicazione");
				DescribeAColumn(T, "locationcode", "Codice Ubicazione");
				DescribeAColumn(T, "description", "Ubicazione");
			}


			base.WebDescribeTree(tree, T, ListingType);
			string filterc = QHC.CmpEq("nlevel", 1);
			string filtersql = QHS.CmpEq("nlevel", 1);
			easy_node_dispatcher D = new location_node_dispatcher(
				"locationlevel",
				"nlevel",
				"description",
				null,
				"description",
				"locationcode"
			);
		    WebTreeViewlocation M = new WebTreeViewlocation(T, tree, filterc, filtersql, maxDepth, withdescr);

		}
		//fine

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
			base.DescribeTree(tree, T, ListingType);
			string filterc=QHC.CmpEq("nlevel",1);
			string filtersql = QHS.CmpEq("nlevel", 1);
			easy_node_dispatcher D = new location_node_dispatcher(
				"locationlevel",
				"nlevel",
				"description",
				null,
				"description",
				"locationcode"
			);
			TreeViewManager M = new TreeViewClassInventario(T, tree, filterc,filtersql);

		}

		//		public override void DescribeColumns(DataTable T, string ListingType){
		//			base.DescribeColumns(T, ListingType);
		//			if (ListingType=="default"){
		//				foreach (DataColumn C in T.Columns) 
		//					DescribeAColumn(T,C.ColumnName,"");
		//
		//				DescribeAColumn(T,"locationcode","Codice");
		//				DescribeAColumn(T,"description","Descrizione");
		//			}
		//		}
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R.Table.Columns.Contains("address") && R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Address' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R.Table.Columns.Contains("annotations") && R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotations' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R.Table.Columns.Contains("cap") && R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Cap' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Location' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}

						if (R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Descrizione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Descrizione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R["idlocation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id ubicazione (tabella location)' è obbligatorio";
							errfield = "idlocation";
							return false;
						}
						if (R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}

						if (R["newlocationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'nuovo codice ubicazione (usato per migrazioni)' può essere al massimo di 50 caratteri";
							errfield = "newlocationcode";
							return false;
						}
						if (R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						if (R["rtf"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'allegati' può essere al massimo di 2147483647 caratteri";
							errfield = "rtf";
							return false;
						}
						if (R["txt"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'note testuali' può essere al massimo di 2147483647 caratteri";
							errfield = "txt";
							return false;
						}
						break;
					}
				case "seg_child": {
						if (R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Indirizzo' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Note' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'CAP' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Località' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}
						if (R["ct"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data creazione' è obbligatorio";
							errfield = "ct";
							return false;
						}
						if (R["cu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome utente creazione' è obbligatorio";
							errfield = "cu";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome utente creazione' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R["idlocation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id ubicazione (tabella location)' è obbligatorio";
							errfield = "idlocation";
							return false;
						}
						if (R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}
						if (R["lt"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data ultima modifica' è obbligatorio";
							errfield = "lt";
							return false;
						}
						if (R["lu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' è obbligatorio";
							errfield = "lu";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["newlocationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'nuovo codice ubicazione (usato per migrazioni)' può essere al massimo di 50 caratteri";
							errfield = "newlocationcode";
							return false;
						}
						if (R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						if (R["rtf"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'allegati' può essere al massimo di 2147483647 caratteri";
							errfield = "rtf";
							return false;
						}
						if (R["txt"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'note testuali' può essere al massimo di 2147483647 caratteri";
							errfield = "txt";
							return false;
						}
						break;
					}
				case "aula": {
						if (R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Indirizzo' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Note' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'CAP' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Località' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}
						if (R["ct"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data creazione' è obbligatorio";
							errfield = "ct";
							return false;
						}
						if (R["cu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome utente creazione' è obbligatorio";
							errfield = "cu";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome utente creazione' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R["idlocation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id ubicazione (tabella location)' è obbligatorio";
							errfield = "idlocation";
							return false;
						}
						if (R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}
						if (R["lt"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data ultima modifica' è obbligatorio";
							errfield = "lt";
							return false;
						}
						if (R["lu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' è obbligatorio";
							errfield = "lu";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["newlocationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'nuovo codice ubicazione (usato per migrazioni)' può essere al massimo di 50 caratteri";
							errfield = "newlocationcode";
							return false;
						}
						if (R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						if (R["rtf"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'allegati' può essere al massimo di 2147483647 caratteri";
							errfield = "rtf";
							return false;
						}
						if (R["txt"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'note testuali' può essere al massimo di 2147483647 caratteri";
							errfield = "txt";
							return false;
						}
						break;
					}
				case "aula_seg_child": {
						if (R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Address' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotations' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Cap' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Location' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}
						if (R["ct"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data creazione' è obbligatorio";
							errfield = "ct";
							return false;
						}
						if (R["cu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome utente creazione' è obbligatorio";
							errfield = "cu";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome utente creazione' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Descrizione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Descrizione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R["idlocation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id ubicazione (tabella location)' è obbligatorio";
							errfield = "idlocation";
							return false;
						}
						if (R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}
						if (R["lt"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data ultima modifica' è obbligatorio";
							errfield = "lt";
							return false;
						}
						if (R["lu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' è obbligatorio";
							errfield = "lu";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["newlocationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'nuovo codice ubicazione (usato per migrazioni)' può essere al massimo di 50 caratteri";
							errfield = "newlocationcode";
							return false;
						}
						if (R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						if (R["rtf"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'allegati' può essere al massimo di 2147483647 caratteri";
							errfield = "rtf";
							return false;
						}
						if (R["txt"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'note testuali' può essere al massimo di 2147483647 caratteri";
							errfield = "txt";
							return false;
						}
						break;
					}
				case "edifici": {
						if (R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Indirizzo' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Note' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'CAP' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Località' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}
						if (R["ct"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data creazione' è obbligatorio";
							errfield = "ct";
							return false;
						}
						if (R["cu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome utente creazione' è obbligatorio";
							errfield = "cu";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome utente creazione' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R["idlocation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id ubicazione (tabella location)' è obbligatorio";
							errfield = "idlocation";
							return false;
						}
						if (R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}
						if (R["lt"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'data ultima modifica' è obbligatorio";
							errfield = "lt";
							return false;
						}
						if (R["lu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' è obbligatorio";
							errfield = "lu";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["newlocationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'nuovo codice ubicazione (usato per migrazioni)' può essere al massimo di 50 caratteri";
							errfield = "newlocationcode";
							return false;
						}
						if (R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						if (R["rtf"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'allegati' può essere al massimo di 2147483647 caratteri";
							errfield = "rtf";
							return false;
						}
						if (R["txt"].ToString().Trim().Length > 2147483647) {
							errmess = "Attenzione! Il campo 'note testuali' può essere al massimo di 2147483647 caratteri";
							errfield = "txt";
							return false;
						}
						break;
					}
					//$IsValid$
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idlocation", "id ubicazione (tabella location)", nPos++);
						DescribeAColumn(T, "!paridlocation_location_description", "chiave parent Piano delle Ubicazioni (tabella location) ", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "address", "Address", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						DescribeAColumn(T, "annotations", "Annotations", nPos++);
						DescribeAColumn(T, "locationcode", "Codice", nPos++);
						DescribeAColumn(T, "cap", "Cap", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Idcity", nPos++);
						DescribeAColumn(T, "!idnation_geo_nation_title", "Idnation", nPos++);
						DescribeAColumn(T, "latitude", "Latitude", nPos++);
						DescribeAColumn(T, "location", "Location", nPos++);
						DescribeAColumn(T, "longitude", "Longitude", nPos++);
						break;
					}
				case "seg_child": {
						DescribeAColumn(T, "locationcode", "Codice", nPos++);
						DescribeAColumn(T, "description", "Denominazione", nPos++);
						DescribeAColumn(T, "address", "Indirizzo", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "description desc, paridlocation desc";
					}
				case "seg_child": {
						return "location, description desc, paridlocation";
					}
					//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

	}

	public class TreeViewClassInventario : TreeViewManager
	{
		public TreeViewClassInventario(DataTable T, TreeView tree, string filterc, string filtersql) :
			base(T, tree, new easy_node_dispatcher(
				"locationlevel",
				"nlevel",
				"description",
				null,
				"description",
				"locationcode"
			), filterc, filtersql) {
		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null) && (tree.Nodes.Count > 0)) {
				if (tree.Nodes[0].Tag == null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
			}

			return base.AddNode(Nodes, NewNode);
		}

		public override void FillNodes() {

			base.FillNodes();
			AutoEventsEnabled = false;
			TreeNode [] newroot= new TreeNode[1];
			newroot[0] = new TreeNode("Piano delle Ubicazioni");
			if (tree.Nodes.Count > 0) {
				if (tree.Nodes[0].Tag == null) return;
			}

			while (tree.Nodes.Count > 0) {
				TreeNode X = tree.Nodes[0];
				tree.Nodes.RemoveAt(0);
				if (X.Tag == null) continue;
				DataRow R = ((tree_node) X.Tag).Row;
				newroot[0].Nodes.Add(X);
			}
			tree.Nodes.Add(newroot[0]);
			newroot[0].Expand();
			AutoEventsEnabled = true;
		}

	}

	//modifiche luigi 8179

	public class WebTreeViewlocation : hwTreeViewManager
	{
		public WebTreeViewlocation(DataTable T, hwTreeView tree, string filterc, string filtersql, int maxlevel, bool withdescr)
			:
			base(T, tree,
			(withdescr ? new easy_node_dispatcher(null, null, null, null, "idlocation", "Ubicazione") :
							  new location_node_dispatcher(null, null, null, null, "idlocation", "Ubicazione")
			), filterc, filtersql) {
			base.DoubleClickForSelect = false;
		}
	}

	public class TreeViewlocation : TreeViewManager
	{
		public TreeViewlocation(DataTable T, TreeView tree, string filterc, string filtersql, int maxlevel, bool withdescr) :
			base(T, tree,
			(withdescr ? new easy_node_dispatcher(null, null, null, null, "idlocation", "Ubicazione") :
							  new location_node_dispatcher(null, null, null, null, "idlocation", "Ubicazione")
			), filterc, filtersql) {
			base.DoubleClickForSelect = false;
		}
	}

	//fine modifiche


	public class location_node_dispatcher : easy_node_dispatcher
	{

		public location_node_dispatcher(
			string level_table,
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string
			)
			: base(level_table,
					level_field,
					descr_level_field,
					selectable_level_field,
					descr_field, code_string) { }

		override public tree_node GetNode(DataRow Parent, DataRow Child) {
			return new location_tree_node("locationlevel", "nlevel",
				"description", null,
				"description", "locationcode", Child);
		}

	}

	public class location_tree_node : easy_tree_node
	{
		public location_tree_node(string level_table,
		   string level_field,
		   string descr_level_field,
		   string selectable_level_field,
		   string descr_field,
		   string code_string,
		   DataRow R)
			: base(level_table,
		descr_level_field,
		descr_level_field,
		selectable_level_field,
		descr_field,
		code_string,
		R) {
		}
		bool row_exists() {
			if (Row == null) return false;
			if (Row.RowState == DataRowState.Deleted) return false;
			if (Row.RowState == DataRowState.Detached) return false;
			return true;
		}
		/// <summary>
		/// True if "selectable" and with "no chidren"
		/// </summary>
		/// <returns></returns>
		override public bool CanSelect() {
			if (!row_exists()) return false;
			//if (selectable_level_field == null) return true;
			DataRow Lev = LevelRow();
			//if (Lev[selectable_level_field].ToString().ToLower() == "n") return false;
			byte flag = CfgFn.GetNoNullByte(Lev["flag"]);
			if ((flag & 2) == 0) return false;
			if (HasAutoChildren()) return false;
			return true;
		}
	}

}

