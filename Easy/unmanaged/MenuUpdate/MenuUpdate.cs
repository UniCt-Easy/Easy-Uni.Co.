
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
using funzioni_configurazione;//funzioni_configurazione

namespace MenuUpdate{//MenuUpdate//

	/// <summary>
	/// Classe di aggiornamento del menu.
	/// Convenzione: 
    ///     chi chiama i metodi di questa classe deve accertarsi di bloccare prima il menu con MenuUpdateClass.SetRunning(true)
    ///     poi deve acquisire il semaforo con SetRunning(true), aggiornare il menu e rilasciarlo con SetRunning(false), 
    ///         dopo aver chiamato il metodo SetMenuUpdated().
	/// </summary>
	public class MenuUpdateClass {
        private static object SemaforoRunning = new object();
        private static bool IsRunning = false;
        private static bool MustUpdateMenu = false;

        public static bool mustUpdateMenu(){
            if (Running()) return false;
            return MustUpdateMenu;
        }
        public static void SetMenuToUpdate(){
                if (Running()) return;
                MustUpdateMenu=true;
        }
        public static void SetMenuUpdated(){
                MustUpdateMenu=false;
        }
		public MenuUpdateClass() {
		}

        static public bool Running() {
            lock (SemaforoRunning) {
                return IsRunning;
            }
        }

        static public bool SetRunning(bool value) {
            if (value) {
                lock (SemaforoRunning) {
                    if (IsRunning) return false;
                    IsRunning = true;
                    return true;
                }
            }
            else {
                lock (SemaforoRunning) {
                    IsRunning = false;
                    return true;
                }
            }
        }

        

		/// <summary>
		/// Aggiunge/modifica/elimina una o più sottovoci di menu alla tabella "menu" e salva le modifiche sul database
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="MenuCode">MenuCode della voce PARENT (deve essere unica nel DataTable MenuItems)</param>
		/// <param name="MenuItems">DataTable contenente le voci da aggiornare</param>
		static private bool UpdateMenuItems(DataTable MenuItems, DataAccess Conn, string MenuCode) {
			DataSet DS = new MenuDataSet();
			PostData MenuPostData = new Easy_PostData();
		    QueryHelper qhs = Conn.GetQueryHelper();
			// mi estraggo l'id_menu da usare come paridmenu
			DataTable T = Conn.RUN_SELECT("menu", "idmenu", null, 
                qhs.DoPar(qhs.CmpEq("menucode",MenuCode)), //"(menucode="+QueryCreator.quotedstrvalue(MenuCode,true)+")", 
			    null, true);
            if (T.Rows.Count == 0 || T.Rows.Count > 1) {
                return false;
            }

			DataRow ParentMenu = T.Rows[0];
			object livsupid= ParentMenu["idmenu"];
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.Tables["menu"], "ordernumber",
			    qhs.DoPar(qhs.CmpEq("paridmenu",livsupid)), //"(paridmenu="+QueryCreator.quotedstrvalue(livsupid,true)+")", 
			    null, true);

			RowChange.MarkAsAutoincrement(DS.Tables["menu"].Columns["idmenu"],null,null,7);
			
			DataTable CurrMenu = DS.Tables["menu"];
			
			//Elimino le righe di CurrMenu non presenti in MenuItems
			// cancellazione
			foreach (DataRow DR in CurrMenu.Rows) {
				string finddel = QueryCreator.WHERE_COLNAME_CLAUSE(DR,
					new string[]{"metadata","edittype","parameter"}, 
					DataRowVersion.Default, false);
				DataRow[] menurows = MenuItems.Select(finddel);
				if (menurows.Length == 0) DR.Delete();
			}
			foreach (DataRow R in MenuItems.Select()) {
                if (R.RowState == DataRowState.Deleted) continue;
                if (R.RowState == DataRowState.Detached) continue;

				//Applica le modifiche e gli inserimenti in CurrMenu
				string findcurr = QueryCreator.WHERE_COLNAME_CLAUSE(R,
					new string[]{"metadata","edittype","parameter"}, 
					DataRowVersion.Default, false);
				DataRow [] Found= CurrMenu.Select(findcurr);
				if (Found.Length>=1){
					//E' una modifica
					Found[0]["menucode"]= R["menucode"];
					Found[0]["title"]=R["title"];
                    Found[0]["ordernumber"] = R["ordernumber"];
                    for (int i = 1; i < Found.Length; i++) {
                        Found[i].Delete();
                    }
				}
				else {
					//E' un inserimento
					

					DataRow NewR = CurrMenu.NewRow();
					RowChange.CalcTemporaryID(NewR, CurrMenu.Columns["idmenu"]);
					NewR["paridmenu"] = livsupid;
					NewR["edittype"]=R["edittype"];
                    NewR["ordernumber"] =R["ordernumber"];
					NewR["metadata"]=R["metadata"];
					NewR["modal"]=R["modal"];
					NewR["parameter"]=R["parameter"];
					NewR["userid"]=R["userid"];
					NewR["title"]=R["title"];
					CurrMenu.Rows.Add(NewR);
				}
			}

            PostData.RemoveFalseUpdates(DS);
            MenuPostData.InitClass(DS, Conn);
			if (MenuPostData.DO_POST()){
                SetMenuToUpdate();
				return true;
			}
			else {
				return false;
			}
		
		}
		static private bool UpdateSubMenu(DataAccess Conn, 
			string tablename, 
			string f_parameter, 
			string f_text,
			string edittype,
			string metadata,
			string modal,
			string groupname
			){
            return UpdateSubMenu(Conn, tablename, null,
				f_parameter,f_text,edittype,metadata,modal, groupname);
		    }
		/// <summary>
		/// Aggiunge/Elimina/Aggiorna delle voci di submenu 
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="tablename">tabella (T) da cui prendere le informazioni per aggiungere le voci di menu</param>
		/// <param name="f_parameter">campo di T da usare per riempire il campo parameter 
		///		delle voci di menu</param>
		/// <param name="f_text">campo di T da usare per riempire il campo title del menu</param>
		/// <param name="edittype">edit type da usare per le voci de menu</param>
		/// <param name="metadata">metadata da usare per le voci di menu</param>
		/// <param name="modal">S se form è modale</param>
		/// <param name="groupname">codice menucode della riga di menu a cui aggiungere le righe
		///  di submenu </param>
		/// <returns></returns>
		static private bool UpdateSubMenu(DataAccess Conn, 
			string tablename, 
			string filter_tablename,
			string f_parameter, 
			string f_text,
			string edittype,
			string metadata,
			string modal,
			string groupname
			){
			DataSet DS = new DataSetForUpdateFromMenu();
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.Tables[tablename], null,filter_tablename,null,true);
			int i;
			//bool success;
			// tipoclassovimenti
			i=0;
            DS.CaseSensitive = false;
			foreach (DataRow R in DS.Tables[tablename].Select(null,f_text)) {
				DataRow menurow = DS.Tables["menu"].NewRow();
				menurow["idmenu"]=i;
				menurow["paridmenu"]=i;
				menurow["ordernumber"]=i;
				menurow["parameter"]=R[f_parameter];
				menurow["title"]=R[f_text];
				menurow["edittype"]=edittype;
				menurow["metadata"]=metadata;
				menurow["modal"]=modal;
				menurow["userid"]="";
				DS.Tables["menu"].Rows.Add(menurow);
				i++;
			}
			return MenuUpdateClass.UpdateMenuItems(DS.Tables["menu"], Conn , groupname );

		}


		
        static private bool UpdateMenuClassificazioniMovimenti(DataAccess Conn) {


/*			DataAccess Conn= BaseConn.Duplicate();

			DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
			//Elimina riga esistenti relative a tipoclassmovimenti
			//Elimina righe menu "Livello gerarchico movimenti"
			int supid = GetIDMenuByMenuCode(Conn,"codtipoclassmoviment");
			DataRow []Found = Menu.Select(
				"(supid="+QueryCreator.quotedstrvalue(supid,false)+")");
			foreach (DataRow ToDel in Found) CascadeMenuDelete(Menu, ToDel);			

			//Elimina righe menu "Classificazione movimenti"
			supid = GetIDMenuByMenuCode(Conn,"codclassmov");
			Found = Menu.Select(
				"(supid="+QueryCreator.quotedstrvalue(supid,false)+")");
			foreach (DataRow ToDel in Found) CascadeMenuDelete(Menu, ToDel);
			
			DataSet MenuPost = new DataSet();
			MenuPost.Tables.Add(Menu);
			PostData myPost = new Campus_PostData();
			myPost.InitClass(MenuPost, Conn);
			myPost.DO_POST();*/


			bool success = UpdateSubMenu(Conn, "sortingkind",
				 "idsorkind","description","default","sortinglevel","S", "codtipoclassmoviment");
            if (success) success = UpdateSubMenu(Conn, "sortingkind",
				 "idsorkind","description", "default", "sorting", "N", "codclassmov");

//			Conn.Destroy();
			return success;

		}

		static private bool UpdateMenuClassificazioniTabelle(EntityDispatcher E){	
			return true;

		}

		static string GetParameterForReport(DataRow Report)
		{
			return Report["modulename"].ToString().Replace(".","")+
				"."+Report["reportname"];				
		}

		
		/// <summary>
		/// Elimina (in memoria) tutte le voci figlie di una voce di menu.
		/// Assume la tabella del menu già letta in Menu
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="IDMenuParent">Voce parent di quella da cancellare</param>
		/// <param name="menucode">menucode della voce da cancellare</param>
		static void CascadeDeleteGroupChilds(DataTable Menu,int IDMenuParent,string menucode){
            CQueryHelper qhc= new CQueryHelper();
		    DataRow[] Found = Menu.Select(
		        qhc.AppAnd(qhc.CmpEq("paridmenu", IDMenuParent), qhc.CmpEq("menucode", menucode)));
				    //"(paridmenu="+QueryCreator.quotedstrvalue(IDMenuParent,false)+")AND("+"menucode="+
                        //QueryCreator.quotedstrvalue(menucode,false)+")");
			if (Found.Length==0) return;
			CascadeMenuDelete(Menu, Found[0]);			
		}

		/// <summary>
		/// Elimina in cascata una voce di menu e le sue figlie
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ToDelete"></param>
		static void CascadeMenuDelete(DataTable Menu, DataRow ToDelete){
            CQueryHelper qhc= new CQueryHelper();
		    string childfilter = qhc.CmpEq("paridmenu", ToDelete["idmenu"]);
			        //"(paridmenu="+ QueryCreator.quotedstrvalue(ToDelete["idmenu"],false)+")";
			DataRow []childs = Menu.Select(childfilter);
			foreach (DataRow child in childs) CascadeMenuDelete(Menu, child);
			if (ToDelete.RowState!=DataRowState.Deleted) ToDelete.Delete();
		}

		static string GetChildFilter(DataRow ParentMenu){
            var qhc= new CQueryHelper();
		    return qhc.CmpEq("paridmenu", ParentMenu["idmenu"]);
			        //"paridmenu="+QueryCreator.quotedstrvalue(ParentMenu["idmenu"],false);

		}
		static DataRow []GetChilds(DataRow ParentMenu){
			string filter= GetChildFilter(ParentMenu);
			return ParentMenu.Table.Select(filter);
		}

		/// <summary>
		/// Restituisce una nuova riga figlia di ParentMenu, assegnandone
		///  il paridmenu ed ordernumber
		/// </summary>
		/// <param name="ParentMenu"></param>
		/// <returns></returns>
		static DataRow NewMenuChild(DataRow ParentMenu){
			DataTable Menu = ParentMenu.Table;
			//finds a valid temporary ID
			int maxID = MetaData.MaxFromColumn(Menu, "idmenu");
			DataRow NewRow = Menu.NewRow();
			NewRow["idmenu"]= maxID+1;
			if (ParentMenu!=null) {
				NewRow["paridmenu"]=ParentMenu["idmenu"];
				DataRow []brothers= GetChilds(ParentMenu);
				int maxgroup=0;
				foreach (DataRow child in brothers){
					if (child.RowState== DataRowState.Deleted) continue;
					int curr = CfgFn.GetNoNullInt32(child["ordernumber"]);
					if (curr>maxgroup) maxgroup=curr;
				}
				NewRow["ordernumber"]=maxgroup+1;
			}
			else {
				NewRow["ordernumber"]=1;
			}
			NewRow["title"]=""; //temporary value
			Menu.Rows.Add(NewRow);
			return NewRow;
		}

		/// <summary>
		/// Aggiunge le voci di menu (stampe) relative ad un modulename, come figlie 
		///  della voce di menu di IDMenuStampe
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ModuleReport"></param>
		/// <param name="ModuleName"></param>
		static void AddModuleStampe(
					DataTable Menu, 
					DataTable TReport, 
					string ModuleName,
					int IDMenuStampe, int position) {
            var qhc=new CQueryHelper();
		    string parentfilter = qhc.CmpEq("idmenu", IDMenuStampe); //"(idmenu="+QueryCreator.quotedstrvalue(IDMenuStampe,false)+")";
			DataRow []MainParents= Menu.Select(parentfilter);	
			if (MainParents.Length==0) return;

			string mainmenucode = ModuleName;
		    string moduleQuery = qhc.AppAnd(GetChildFilter(MainParents[0]), qhc.CmpEq("menucode", mainmenucode));
			    //"("+ GetChildFilter(MainParents[0])+ ") and (menucode=" + QueryCreator.quotedstrvalue(mainmenucode, false)+ ")";
			DataRow[] ModuleFound = Menu.Select(moduleQuery,"title");

			DataRow ModuleMenu = (ModuleFound.Length==0) 
				? NewMenuChild(MainParents[0]) 
				: ModuleFound[0];
		    ModuleMenu["ordernumber"] = position;
			ModuleMenu["title"]= ModuleName;
			ModuleMenu["menucode"]= mainmenucode;

			RowChange.MarkAsAutoincrement(Menu.Columns["idmenu"],null,null,7);

		    string filtermodule = qhc.CmpEq("modulename", ModuleName);
			    //"(modulename="+QueryCreator.quotedstrvalue(ModuleName,false)+")";
			DataRow []Reports = TReport.Select(filtermodule, "modulename,groupname,description");
		    int repNum = 0;
		    int groupNum = 0;
		    string lastgroup = "";
			foreach(DataRow Report in Reports) {
				//Sceglie il Gruppo in cui aggiungere la voce di menu
				string groupname= Report["groupname"].ToString();
			    if (groupname != lastgroup) {
			        lastgroup = groupname;
			        groupNum += 10;
			        repNum = 0;
			    }

			    string filtergroup = qhc.AppAnd(GetChildFilter(ModuleMenu), qhc.CmpEq("menucode", groupname));
				        //GetChildFilter(ModuleMenu)+ "AND(menucode="+QueryCreator.quotedstrvalue(groupname,false)+")";
				DataRow []GroupFound= Menu.Select(filtergroup);
				DataRow Group=null;
				if (GroupFound.Length==0){
					//Crea il nuovo gruppo poiché non esiste ancora
					Group = NewMenuChild(ModuleMenu);
					Group["menucode"]= groupname;
					Group["title"]=groupname;
                    Group["ordernumber"] = groupNum;
                }
				else {
					Group= GroupFound[0];
                    Group["ordernumber"] = groupNum;
                }
		        repNum += 10;
                
			    
				//Aggiunge il report al gruppo
				string parameter = GetParameterForReport(Report);
			    string repQuery = qhc.AppAnd(GetChildFilter(Group), qhc.CmpEq("parameter", parameter));
					//+ " and parameter = " + QueryCreator.quotedstrvalue(parameter, false);
				DataRow[] RepFound = Menu.Select(repQuery);

				DataRow RepMenu = (RepFound.Length==0) 
					? NewMenuChild(Group) 
					: RepFound[0];
				RepMenu["title"]= Report["description"];
				RepMenu["modal"]="N";
				RepMenu["metadata"]="resultparameter";
				RepMenu["edittype"]="default";
				RepMenu["parameter"]= parameter;
			    RepMenu["ordernumber"] = repNum;
			}

		}


		static void pulisciReports(DataTable Menu, string gruppiDiStampe, string parameters) 
		{
			string reports = QueryCreator.ColumnValues(Menu, 
				"paridmenu in (" + gruppiDiStampe + ")",
				"idmenu",
				false);
            if(reports == "") return;

			string query3 = "idmenu in ("
				+ reports
				+ ")";
			if (parameters!=""){
				query3+=" and parameter not in ("
					+ parameters
					+ ")";
			}

			DataRow[] rToDelete = Menu.Select(query3);
			foreach (DataRow r in rToDelete) 
			{
				CascadeMenuDelete(Menu, r);			
			}
		}

		/// <summary>
		/// cancello da tutti i moduli le parti non usate
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ModuleReport"></param>
		/// <param name="moduliDiStampa">Elenco di moduli da considerare</param>
		static void pulisciGruppiDiStampe(DataTable Menu, DataTable ModuleReport, string moduliDiStampa) 
		{
            var qhc = new CQueryHelper();
			if (moduliDiStampa=="")return;
			//Calcola l'elenco di tutti gli id dei gruppi presenti
			string gruppiDiStampe = QueryCreator.ColumnValues(Menu, 
				"paridmenu in (" + moduliDiStampa + ")",
				"idmenu",
				false);

			string groupNames = "";
			string parameters = "";
		    foreach (DataRow r in ModuleReport.Rows) {
		        parameters += "," + qhc.quote(GetParameterForReport(r));
		        string groupName = "," + qhc.quote(r["groupname"]);
		        if (groupNames.IndexOf(groupName) == -1) {
		            groupNames += groupName;
		        }
		    }

		    if (parameters.Length>0) parameters=parameters.Substring(1);
			if (groupNames!=""){
				//Elimina tutti i report figli di gruppi non presenti
				string query2 = "idmenu in ("
					+ gruppiDiStampe
					+ ") and menucode not in ("
					+ groupNames.Substring(1)
					+ ")";

				DataRow[] rToDelete = Menu.Select(query2);
				foreach (DataRow r in rToDelete) {
					CascadeMenuDelete(Menu, r);			
				}
			}
			pulisciReports(Menu, gruppiDiStampe, parameters);
		}

		static void pulisciModuliDiStampe(int IDMenuStampe, DataTable Menu, DataTable ModuleReport)
		{
            var qhc = new CQueryHelper();
			// Elimina voci di menu eventuali senza padre
			string queryparidmenu = "(paridmenu is not null and paridmenu <>0)";
			DataRow[] rToDelete = Menu.Select(queryparidmenu);
			foreach (DataRow ToDelete in rToDelete) {
				DataRow[] children = Menu.Select(qhc.CmpEq("idmenu",ToDelete["paridmenu"]));			
				if ((ToDelete.RowState!=DataRowState.Deleted)&&(children.Length==0)) {
					ToDelete.Delete();
				}
			}
			//Calcola i moduli che devono essere complessivamente presenti sotto la voce 'Stampe'
			string moduli = QueryCreator.quotedstrvalue("codprocesportazione", false);
			foreach (DataRow r in ModuleReport.Rows) 
			{
				string modulo = "," + QueryCreator.quotedstrvalue(r["modulename"], false);
				if (moduli.IndexOf(modulo) == -1) 
				{
					moduli += modulo;
				}
			}
			
			//Primo passo: cancello da menu tutti i moduli che non devono apparire
		    string query1 =
		        qhc.AppAnd(qhc.CmpEq("paridmenu", IDMenuStampe), qhc.FieldNotIn("menucode", ModuleReport.Select(), "modulename"));
			     //"(paridmenu="+ QueryCreator.quotedstrvalue(IDMenuStampe, false)+ ") AND menucode not in ("+ moduli+ ")";
			DataRow[] rToDelete1 = Menu.Select(query1);
			foreach (DataRow r in rToDelete1) 
			{
				CascadeMenuDelete(Menu, r);			
			}

			//Secondo passo: cancello da tutti i moduli le parti non usate
			string moduliDiStampa = QueryCreator.ColumnValues(Menu,qhc.CmpEq("paridmenu",IDMenuStampe),
			    	//"(paridmenu=" + QueryCreator.quotedstrvalue(IDMenuStampe, false) + ")",
				"idmenu",
				false);

			pulisciGruppiDiStampe(Menu, ModuleReport, moduliDiStampa);
		}


		/// <summary>
		/// Aggiorna il menu stampe, assumendo la voce principale di Menu a cui aggiungere
		///  sia IDMenuStampe
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ModuleReport"></param>
		static void MyUpdateAllReportMenu(int IDMenuStampe, DataTable Menu, DataTable ModuleReport)
		{
			pulisciModuliDiStampe(IDMenuStampe, Menu, ModuleReport);
			
			DataRow[] AllModules = ModuleReport.Select(null,"modulename");
			string lastmodule=null;


		    int position = 0;
			foreach (DataRow Module2 in AllModules){
				if (lastmodule == Module2["modulename"].ToString()) 
					continue;
			    position += 10;
                lastmodule = Module2["modulename"].ToString();
				AddModuleStampe(Menu, ModuleReport, lastmodule, IDMenuStampe,position);
			}

		}

		/// <summary>
		/// Returns the IDmenu of the menu row having a specified groupname
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="group"></param>
		/// <returns>-1 if no records found or more than one</returns>
		public static int GetIDMenuByMenuCode(DataAccess Conn, string group){
            var qhs= Conn.GetQueryHelper();
		    string filter = qhs.CmpEq("menucode", group); //"(menucode="+QueryCreator.quotedstrvalue(group,true)+")");
			int N = Conn.RUN_SELECT_COUNT("menu", filter, true);
			if (N!=1) return -1;
			int ID = CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("menu", filter, "idmenu"));
			return ID;
		}

		private static bool UpdateAllReports(DataAccess Conn){
			try {
				DataSet DS = new DataSet();
				DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
				string filter = Conn.GetSys("filterrule") as string;
				filter= GetData.MergeFilters(filter,"(active='S')");
				DataTable ModuleReports = Conn.RUN_SELECT("report","*","modulename,reportname",filter,null,null,false);
				if (ModuleReports==null) ModuleReports = Conn.RUN_SELECT("report","*",null,null,null,null,false);
				DS.Tables.Add(Menu);
				DS.Tables.Add(ModuleReports);
				//"codstampe" è il groupname della voce "stampe" (1o livello)
				int IDStampe = GetIDMenuByMenuCode(Conn, "codstampe");
				MyUpdateAllReportMenu(IDStampe, Menu, ModuleReports);

				PostData myPost = new Easy_PostData();
                PostData.RemoveFalseUpdates(DS);
				myPost.InitClass(DS, Conn);
				if (myPost.DO_POST()){
                    SetMenuToUpdate();
					return true;
				}
				else {
					return false;
				}
			}
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
				return false;
			}
		}


		

		/// <summary>
		/// Aggiunge le voci di menu (export) relative ad un modulename, come figlie 
		///  della voce di menu di IDMenuStampe
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ModuleExport"></param>
		/// <param name="ModuleName"></param>
		static void AddModuleExport(
			DataTable Menu, 
			DataTable ExpStoredProcedure, 
			string ModuleName,
			int IDMenuExport){
            var qhc = new CQueryHelper();
			DataRow Parent= Menu.Select(qhc.CmpEq("idmenu",IDMenuExport))[0];
			string parentfilter=   qhc.CmpEq("idmenu",IDMenuExport);
			DataRow []MainParents= Menu.Select(parentfilter);	
			if (MainParents.Length==0) return;
			DataRow ModuleMenu = NewMenuChild(MainParents[0]);
			ModuleMenu["title"]= ModuleName;
			
			string mainmenucode=  ModuleName;

			ModuleMenu["menucode"]= mainmenucode;

			RowChange.MarkAsAutoincrement(Menu.Columns["idmenu"],null,null,7);
		    
			DataRow []Exports= ExpStoredProcedure.Select(qhc.CmpEq("modulename", ModuleName),"description");
			foreach(DataRow Export in Exports){		
				//Aggiunge il report al Modulo
				DataRow RepMenu = NewMenuChild(ModuleMenu);
				RepMenu["title"]= Export["description"];
				RepMenu["modal"]="N";
				RepMenu["metadata"]="export";
				RepMenu["edittype"]="default";
				RepMenu["parameter"]= Export["procedurename"];				
			}

		}


		/// <summary>
		/// Aggiorna il menu esportazioni, assumendo la voce principale di Menu a cui aggiungere
		///  sia IDMenuExport
		/// </summary>
		/// <param name="Menu"></param>
		/// <param name="ModuleReport"></param>
		static void MyUpdateAllExportMenu(int IDMenuExport, 
				DataTable Menu, 
				DataTable ExpStoredProcedure){
			DataRow []AllModules = ExpStoredProcedure.Select(null,"modulename");
			string lastmodule=null;
            var qhc= new CQueryHelper();
			//Elimina quelli vecchi non più gestiti
		    string childfilter = qhc.AppAnd(qhc.CmpEq("paridmenu", IDMenuExport), qhc.IsNull("menucode"));
			    //"(paridmenu="+QueryCreator.quotedstrvalue(IDMenuExport,false)+")AND(menucode IS NULL)";
			DataRow []childs = Menu.Select(childfilter);
			foreach (DataRow child in childs) CascadeMenuDelete(Menu, child);
			
			foreach (DataRow Module in AllModules){
			    if (Module["modulename"].ToString()=="")continue;
				if (lastmodule == Module["modulename"].ToString()) continue;
				lastmodule= Module["modulename"].ToString();
				CascadeDeleteGroupChilds(Menu, IDMenuExport, lastmodule);
			}
			lastmodule=null;

			foreach (DataRow Module2 in AllModules){
			    if (Module2["modulename"].ToString()=="")continue;
				if (lastmodule == Module2["modulename"].ToString()) continue;
				lastmodule= Module2["modulename"].ToString();
				AddModuleExport(Menu, ExpStoredProcedure, lastmodule, IDMenuExport);
			}

		}
		
		
		private static bool UpdateAllExport(DataAccess Conn) {

		    QueryHelper q = Conn.GetQueryHelper();
            var qhc= new CQueryHelper();
			try {
				DataSet DS = new DataSet();
				DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
				DataTable ExpStoredProcedure = Conn.RUN_SELECT("exportfunction","*",null,q.NullOrEq("active","S"),null,null,false);
				DS.Tables.Add(Menu);
				DS.Tables.Add(ExpStoredProcedure);
				//"codprocesportazione" è il groupname della voce "Procedure Esportazione" (2o livello)
				int IDExport = GetIDMenuByMenuCode(Conn, "codprocesportazione");
				if (IDExport==-1){
					DataRow StampeRow = Menu.Select(qhc.CmpEq("menucode","codprocesportazione"))[0];
					//Aggiunge il menu di esportazione poiché non c'è
					DataRow ExpMenuRow = NewMenuChild(StampeRow);
					ExpMenuRow["menucode"]="codprocesportazione";
					ExpMenuRow["title"]="Esportazioni";
					ExpMenuRow["ordernumber"]=20000;
					IDExport= CfgFn.GetNoNullInt32( ExpMenuRow["idmenu"]);
				}
				DataRow MyStampeRow = Menu.Select(qhc.CmpEq("menucode","codprocesportazione"))[0];
				MyStampeRow["ordernumber"]=20000;


				MyUpdateAllExportMenu(IDExport, Menu, ExpStoredProcedure);
                PostData.RemoveFalseUpdates(DS);
                PostData myPost = new Easy_PostData();
                myPost.InitClass(DS, Conn);
				if (myPost.DO_POST()){
                    SetMenuToUpdate();
					return true;
				}
				else {
					return false;
				}
			}
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
				return false;
			}
		}

		private static void MyUpdateAllMovimentoMenu(string IDMenuMovimento, 
			DataTable Menu, DataTable FaseMovimento, string movtable, string edittype){
		    var qhc= new CQueryHelper();
		    string ExistFilter = qhc.AppAnd(qhc.CmpEq("metadata", movtable), qhc.CmpEq("edittype", edittype));
			    //"(metadata="+QueryCreator.quotedstrvalue(movtable,false)+")AND("+"edittype="+QueryCreator.quotedstrvalue(edittype,false)+")";
			DataRow []ToDelete = Menu.Select(ExistFilter);
			//Cancella le voci di menu esistenti
			foreach (DataRow DD in ToDelete) DD.Delete();

			string parentfilter= "(idmenu="+QueryCreator.quotedstrvalue(IDMenuMovimento,false)+")";
			DataRow []MainParents= Menu.Select(parentfilter);	
			if (MainParents.Length==0) return;

			//Aggiunge le nuove righe di menu
			foreach(DataRow R in FaseMovimento.Select(null,"nphase")){
				DataRow NewMenu = NewMenuChild(MainParents[0]);
				NewMenu["metadata"]= movtable;
				NewMenu["edittype"]= edittype;
				NewMenu["parameter"]= R["nphase"];
				NewMenu["title"]= R["nphase"]+" - "+R["description"];
			}
		}

		private static void MyUpdateCassiereMenu(string IDMenuMovimento,DataTable Menu, DataRow Pers){
		    var qhc= new CQueryHelper();
			string ExistFilter =  qhc.AppAnd(qhc.CmpEq("metadata", "bankdispositionsetup"), qhc.CmpEq("edittype", "trasmissione"));
			    //"(metadata="+QueryCreator.quotedstrvalue("bankdispositionsetup",false)+")AND("+"edittype="+QueryCreator.quotedstrvalue("trasmissione",false)+")";
			DataRow []ToDelete = Menu.Select(ExistFilter);
			//Cancella le voci di menu esistenti
			foreach (DataRow DD in ToDelete) DD.Delete();


            ExistFilter = qhc.AppAnd(qhc.CmpEq("metadata", "no_table"), qhc.CmpEq("edittype", "expbank"));
		        //"(metadata=" + QueryCreator.quotedstrvalue("no_table", false) + ")AND(" +"edittype=" + QueryCreator.quotedstrvalue("expbank", false) + ")";
            ToDelete = Menu.Select(ExistFilter);
            foreach (DataRow DD in ToDelete) DD.Delete();


            ExistFilter = qhc.AppAnd(qhc.CmpEq("metadata", "bankdispositionsetup"), qhc.CmpEq("edittype", "importazione"));
                //"(metadata=" + QueryCreator.quotedstrvalue("bankdispositionsetup", false) + ")AND(" +"edittype=" + QueryCreator.quotedstrvalue("importazione", false) + ")";
            ToDelete = Menu.Select(ExistFilter);
            //Cancella le voci di menu esistenti
            foreach (DataRow DD in ToDelete) DD.Delete();

		    string parentfilter = qhc.CmpEq("idmenu", IDMenuMovimento); //"(idmenu=" + QueryCreator.quotedstrvalue(IDMenuMovimento, false) + ")";
            DataRow[] MainParents = Menu.Select(parentfilter);
            if (MainParents.Length == 0) return;

            string appname = Pers["appname"].ToString().Trim();
            if (Pers["electronictrasmission"].ToString().ToLower() == "s") {
                if (appname != "") {
                    DataRow NewMenu = NewMenuChild(MainParents[0]);
                    NewMenu["metadata"] = "no_table";
                    NewMenu["edittype"] = "expbank";
                    NewMenu["parameter"] = appname;
                    NewMenu["modal"] = "N";
                    NewMenu["title"] = "Trasmissione distinte";
                }

            }
            else {
                if (appname != "") {
                    //Aggiunge la nuova riga di menu
                    DataRow NewMenu = NewMenuChild(MainParents[0]);
                    NewMenu["metadata"] = "bankdispositionsetup";
                    NewMenu["edittype"] = "trasmissione";
                    NewMenu["parameter"] = appname;
                    NewMenu["modal"] = "N";
                    NewMenu["title"] = "Trasmissione distinte";
                }
            }
            

            if (Pers["electronicimport"].ToString().ToLower() != "s") return;
            if (Pers["importappname"].ToString().Trim() == "") return;

            //Aggiunge la nuova riga di menu
            DataRow NewMenu2 = NewMenuChild(MainParents[0]);
            NewMenu2["metadata"] = "bankdispositionsetup";
            NewMenu2["edittype"] = "importazione";
            NewMenu2["parameter"] = Pers["importappname"];
            NewMenu2["modal"] = "N";
            NewMenu2["title"] = "Trasmissione e Importazione esiti";
		}

        private static bool UpdateVarious(DataAccess Conn) {
            try {
                DataSet DS = new DataSet();
                DataTable Menu = Conn.RUN_SELECT("menu", "*", null, null, null, null, false);
                QueryHelper QHS = Conn.GetQueryHelper();
                object lastEserc = Conn.DO_READ_VALUE("config", QHS.IsNotNull("appname"), "max(ayear)");
                string filtereserc = QHS.CmpEq("ayear", lastEserc); //"(ayear='" + Conn.GetSys("esercizio").ToString() + "')";
                DataTable cfg = Conn.RUN_SELECT("config", "*", null, filtereserc, null, null, false);
                if ((cfg == null) || (cfg.Rows.Count == 0)) {
                    return true;
                }
                DataTable unicfg = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, false);
                if ((unicfg == null) || (unicfg.Rows.Count == 0)) {
                    return true;
                }
                DS.Tables.Add(Menu);
                DS.Tables.Add(cfg);
                DS.Tables.Add(unicfg);
                DataRow rCfg = cfg.Rows[0];
                DataRow rUniCfg =  unicfg.Rows[0];


                UpdateVarious(Menu, rCfg, rUniCfg);
                PostData.RemoveFalseUpdates(DS);
                PostData myPost = new Easy_PostData();
                myPost.InitClass(DS, Conn);
                if (myPost.DO_POST()) {
                    SetMenuToUpdate();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception e) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
                return false;
            }

        }

        private static void UpdateVarious(DataTable Menu, DataRow cfg, DataRow uniCfg) {
            CQueryHelper q = new CQueryHelper();
            int flag = CfgFn.GetNoNullInt32(uniCfg["flag"]);
            if ((flag & 2) == 0) {
                //cancella la voce sdi_vendita
                DataRow[] foundSDiVen = Menu.Select(q.AppAnd(q.CmpEq("metadata", "sdi_vendita"), q.CmpEq("edittype", "default")));
                foreach (DataRow rf in foundSDiVen) {
                    rf.Delete();
                }
            }
            else {
                //si accerta che ci sia la voce sdi_vendita
                DataRow[] foundSDiVen = Menu.Select(q.AppAnd(q.CmpEq("metadata", "sdi_vendita"), q.CmpEq("edittype", "default")));
                if (foundSDiVen.Length == 0) {
                    DataRow[] foundCodFluss = Menu.Select(q.CmpEq("menucode", "codflussife"));
                    if (foundCodFluss.Length > 0) {

                        DataRow r = NewMenuChild(foundCodFluss[0]);
                        r["metadata"] = "sdi_vendita";
                        r["edittype"] = "default";
                        r["ordernumber"] = 30;
                        r["modal"] = "N";
                    }
                }
            }

        }
		
		private static bool UpdateCassiere(DataAccess Conn){
			try {
				DataSet DS = new DataSet();
				DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
                QueryHelper QHS = Conn.GetQueryHelper();
                object lastEserc = Conn.DO_READ_VALUE("config", QHS.IsNotNull("appname"), "max(ayear)");
                string filtereserc = QHS.CmpEq("ayear", lastEserc); //"(ayear='" + Conn.GetSys("esercizio").ToString() + "')";
				DataTable PersGen = Conn.RUN_SELECT("config","*",null,filtereserc,null,null,false);
				if ((PersGen==null)||(PersGen.Rows.Count==0)) {
                    return true;
                }
				DS.Tables.Add(Menu);
				DS.Tables.Add(PersGen);
				DataRow Pers = PersGen.Rows[0];

				
				int IDSpesa = GetIDMenuByMenuCode(Conn, "codcassiere");
				MyUpdateCassiereMenu(IDSpesa.ToString(), Menu, Pers);
                PostData.RemoveFalseUpdates(DS);
				PostData myPost = new Easy_PostData();
				myPost.InitClass(DS, Conn);
				if (myPost.DO_POST()){
                    SetMenuToUpdate();
					return true;
				}
				else {
					return false;
				}
			}
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
				return false;
			}
		}

		private static bool UpdateSpesaLevels(DataAccess Conn){
			try {
				DataSet DS = new DataSet();
				DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
				DataTable FaseSpesa = Conn.RUN_SELECT("expensephase","*",null,null,null,null,false);
				DS.Tables.Add(Menu);
				DS.Tables.Add(FaseSpesa);
				int IDSpesa = GetIDMenuByMenuCode(Conn, "codspese");
				MyUpdateAllMovimentoMenu(IDSpesa.ToString(), Menu, FaseSpesa, "expense", "levels");
                PostData.RemoveFalseUpdates(DS);
				PostData myPost = new Easy_PostData();
				myPost.InitClass(DS, Conn);
				if (myPost.DO_POST()){
                    SetMenuToUpdate();
					return true;
				}
				else {
					return false;
				}
			}
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
				return false;
			}
		}

		private static bool UpdateEntrataLevels(DataAccess Conn){

			try {
				DataSet DS = new DataSet();
				DataTable Menu = Conn.RUN_SELECT("menu","*",null,null,null,null,false);
				DataTable FaseEntrata = Conn.RUN_SELECT("incomephase","*",null,null,null,null,false);
				DS.Tables.Add(Menu);
				DS.Tables.Add(FaseEntrata);
				//"codprocesportazione" è il groupname della voce "Procedure Esportazione" (2o livello)
				int IDEntrata = GetIDMenuByMenuCode(Conn, "codentrate");
				MyUpdateAllMovimentoMenu(IDEntrata.ToString(), Menu, FaseEntrata, "income", "levels");
                PostData.RemoveFalseUpdates(DS);
				PostData myPost = new Easy_PostData();
				myPost.InitClass(DS, Conn);
				if (myPost.DO_POST()){
                    SetMenuToUpdate();
					return true;
				}
				else {
					return false;
				}
			}
			catch (Exception e){
				MetaFactory.factory.getSingleton<IMessageShower>().Show(e.Message);
				return false;
			}
		}



		private  static void UpdateMenuStampe(DataAccess Conn){
			//ClearMenuStampe(E);
			UpdateAllReports(Conn);
			UpdateAllExport(Conn);
		}


		// by Leo begin
		static private bool UpdateMenuClassificazioniIndirette(DataAccess Conn) 
		{
			bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Configurazione classificazioni indirette", "traduzioneclassifica");
			if (!success) return false;

			return UpdateSubMenu(Conn, "sortingkind",null,
				"idsorkind","description", "traduzione", "sorting", "N", "traduzioneclassifica");
		}

        static private bool UpdateMenuBudgetVar(DataAccess Conn)
        {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Variazioni di Budget", "variazionibudget");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                "idsorkind", "description", "default", "budgetvar", "N", "variazionibudget");
        }

        static private bool UpdateMenuDettBudgetVar(DataAccess Conn)
        {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();

            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Dettagli Variazioni di Budget", "dettvariazionibudget");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                "idsorkind", "description", "default", "budgetvardetail", "N", "dettvariazionibudget");

        }
        
        static private bool UpdateMenuTrasfPrevInBudget(DataAccess Conn)
        {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Trasferimento Previsioni in Budget", "transfprevinbudget");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                "idsorkind", "description", "transfprevinbudget", "no_table","N", "transfprevinbudget");
        }

		static private bool UpdateMenuVarPrevEntrate(DataAccess Conn) 
		{
			bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Variazione previsione entrate", "varclassmoven");
			if (!success) return false;

			return UpdateSubMenu(Conn, "sortingkind","(nphaseincome is not null)",
				"idsorkind","description", "default", "sortingprevincomevar", "N", "varclassmoven");
		}

		static private bool UpdateMenuVarPrevSpese(DataAccess Conn) 
		{
			bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Variazione previsione spese", "varclassmovsp");
			if (!success) return false;

			return UpdateSubMenu(Conn, "sortingkind","(nphaseexpense is not null)",
				"idsorkind","description", "default", "sortingprevexpensevar", "N", "varclassmovsp");
		}

        static private bool UpdateMenuImputazioneMovimentoEntrata(DataAccess Conn) 
		{
			bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Imputazione movimento di entrata", "impmoven");
			if (!success) return false;

			return UpdateSubMenu(Conn, "sortingkind","(nphaseincome is not null)",
				"idsorkind","description", "main", "incomesorted", "N", "impmoven");
		}

        static private bool UpdateMenuImputazioneMovimentoSpesa(DataAccess Conn) 
		{
			bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Imputazione movimento di spesa", "impmovsp");
			if (!success) return false;

			return UpdateSubMenu(Conn, "sortingkind","(nphaseexpense is not null)",
				"idsorkind","description", "main", "expensesorted", "N", "impmovsp");
		}

        static private bool UpdateMenuClassificazioniStoriche(DataAccess Conn) {
            bool success = InsertMenuContainerItem(Conn, "codinfohistory", "Classificazioni", "classhist");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingkind", null,
                "idsorkind", "description", "history", "sorting", "N", "classhist");
        }

        static private bool UpdateMenuClassificazioniCreddeb(DataAccess Conn) {
            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Classificazioni Anagrafica", "classcred");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingapplicabilityview", "(tablename='registry')",
                "idsorkind", "description", "imputazione", "registrysorting", "N", "classcred");
        }
        static private bool UpdateMenuClassificazioniBilancio(DataAccess Conn) {
            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Classificazioni Bilancio", "classbila");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingapplicabilityview", "(tablename='fin')",
                "idsorkind", "description", "imputazione", "finsorting", "N", "classbila");
        }
        static private bool UpdateMenuClassificazioniUpb(DataAccess Conn) {
            bool success = InsertMenuContainerItem(Conn, "codclassificazioni", "Classificazioni U.P.B.", "classupb");
            if (!success) return false;

            return UpdateSubMenu(Conn, "sortingapplicabilityview", "(tablename='upb')",
                "idsorkind", "description", "imputazione", "upbsorting", "N", "classupb");
        }

        static public bool GeneralUpdateMenuItems(EntityDispatcher E) {
            if (E == null) return true;
            if (E.Conn == null) return true;
            DataAccess ConnClone = E.Conn.Duplicate();
            ConnClone.SetSys("filterrule",E.Conn.GetSys("filterrule"));
            bool res = true;
            try {
                res = GeneralUpdateMenuItems(ConnClone);
            }
            catch { }
            ConnClone.Destroy();
            return res;
        }

                    
        /// <summary>
		/// Aggiunge al menu tutte le righe dinamiche 
		/// </summary>
        static public  bool GeneralUpdateMenuItems(DataAccess Conn) {
			//int i;

			bool success;
			
			// tipoclassovimenti
            success = UpdateMenuClassificazioniMovimenti(Conn);
			//if (success) success = UpdateMenuClassificazioniTabelle(E);

			//by Leo
			//start
            UpdateMenuClassificazioniIndirette(Conn);
            UpdateMenuVarPrevEntrate(Conn);
            UpdateMenuVarPrevSpese(Conn);
            UpdateMenuImputazioneMovimentoEntrata(Conn);
            UpdateMenuImputazioneMovimentoSpesa(Conn);
            UpdateMenuClassificazioniStoriche(Conn);
            UpdateMenuClassificazioniBilancio(Conn);
            UpdateMenuClassificazioniCreddeb(Conn);
            UpdateMenuClassificazioniUpb(Conn);
            UpdateMenuBudgetVar(Conn);
            UpdateMenuDettBudgetVar(Conn);
            UpdateMenuTrasfPrevInBudget(Conn);
			//end

            UpdateEntrataLevels(Conn);
            UpdateSpesaLevels(Conn);
            UpdateCassiere(Conn);
            UpdateVarious(Conn);
            UpdateMenuStampe(Conn);


            SetMenuToUpdate();
			return success;
		}

		/// <summary>
		/// Inserisce una riga di menu "contenitore".
		/// Restituisce true se la riga è stata correttamente inserita oppure
		/// se essa è gia presente nel menu 
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="ParentMenuCode"></param>
		/// <param name="Text"></param>
		/// <param name="MenuCode"></param>
		/// <returns></returns>
		static public bool InsertMenuContainerItem(DataAccess Conn, string ParentMenuCode,
			string Text, string MenuCode) {
		    var qhs = Conn.GetQueryHelper();
			DataSet DS = new MenuDataSet();
			//verifica l'esistenza della riga che sto per inserire
		    string existfilter = qhs.CmpEq("menucode", MenuCode);
			        //"(menucode="+QueryCreator.quotedstrvalue(MenuCode,true)+")";
			int num = Conn.RUN_SELECT_COUNT("menu", existfilter, true);
			if (num == 1) {
                return true;
            }


			string filter =  qhs.CmpEq("menucode", ParentMenuCode); //"(menucode="+QueryCreator.quotedstrvalue(ParentMenuCode, true)+")";
			DataTable T = Conn.RUN_SELECT("menu", "*", null, filter, null, true);
			if (T==null || T.Rows.Count != 1) return false;

			RowChange.MarkAsAutoincrement(DS.Tables["menu"].Columns["idmenu"],null,null,7);
			DataRow NewMenuRow = DS.Tables["menu"].NewRow();
			NewMenuRow["idmenu"] = MetaData.MaxFromColumn(DS.Tables["menu"], "idmenu")+1;
			NewMenuRow["paridmenu"] = T.Rows[0]["idmenu"];
			if (Text=="" || Text==null)
				NewMenuRow["title"] = DBNull.Value;
			else
				NewMenuRow["title"] = Text;
			if (MenuCode=="" || MenuCode==null)
				NewMenuRow["menucode"] = DBNull.Value;
			else
				NewMenuRow["menucode"] = MenuCode;
			
			// mi calcolo l'ordenumber
            var qhc=new CQueryHelper();
		    string filterformax = qhc.CmpEq("paridmenu", T.Rows[0]["idmenu"]);
			        //"(paridmenu = "+QueryCreator.quotedstrvalue(T.Rows[0]["idmenu"], true)+")";
			DataTable MaxOrderNumberTable = Conn.RUN_SELECT("menu", "*", null, filterformax, null, true);
			
			NewMenuRow["ordernumber"]=MetaData.MaxFromColumn(MaxOrderNumberTable, "ordernumber")+1;

			DS.Tables["menu"].Rows.Add(NewMenuRow);
            SetMenuToUpdate();
			PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Conn);
			return MyPostData.DO_POST();
		}

		// ----------------- Nuova gestione Aggiornamento menu ------------------

		#region Nuova gestione Aggiornamento menu

		private static int GetIDMenuByMenuCode(DataTable Tmenu, string group){
            var qhc=new CQueryHelper();
		    //string filter = qhc.CmpEq("menucode", group);// "(menucode="+QueryCreator.quotedstrvalue(group,true)+")");
			DataRow[] rows=Tmenu.Select(qhc.CmpEq("menucode", group));
			if (rows.Length!=1) return -1;
			int ID = CfgFn.GetNoNullInt32(rows[0]["idmenu"]);
			return ID;
		}

		private static bool InsertMenuContainerItem(DataAccess Conn, string ParentMenuCode,
			string Text, string MenuCode, DataTable Tmenu) {
		    var qhc=new CQueryHelper();
			//verifica l'esistenza della riga contenitore che sto per inserire
			//string filter_container = "(menucode="+QueryCreator.quotedstrvalue(MenuCode,false)+")";
			if (Tmenu.Select(qhc.CmpEq("menucode", MenuCode)).Length==1) return true;

			//verifica esistenza voce di menu padre del contenitore che devo inserire
			//string filter_parent = "(menucode="+QueryCreator.quotedstrvalue(ParentMenuCode, false)+")";
			DataRow[] rowParentMenu=Tmenu.Select(qhc.CmpEq("menucode", ParentMenuCode));
			if (rowParentMenu.Length!=1) return false;

//			RowChange.MarkAsAutoincrement(Tmenu.Columns["idmenu"],null,null,7);

			DataRow NewMenuRow = Tmenu.NewRow();
			NewMenuRow["idmenu"] = MetaData.MaxFromColumn(Tmenu, "idmenu")+1;
			NewMenuRow["paridmenu"] = rowParentMenu[0]["idmenu"];
			if (Text=="" || Text==null)
				NewMenuRow["title"] = DBNull.Value;
			else
				NewMenuRow["title"] = Text;
			if (MenuCode=="" || MenuCode==null)
				NewMenuRow["menucode"] = DBNull.Value;
			else
				NewMenuRow["menucode"] = MenuCode;
			
			// mi calcolo l'ordenumber
			//string filterformax = "(paridmenu = "+QueryCreator.quotedstrvalue(rowParentMenu[0]["idmenu"], true)+")";
			DataRow[] rowsMenuItems=Tmenu.Select(qhc.CmpEq("paridmenu", rowParentMenu[0]["idmenu"]),"ordernumber ASC");
			int maxordernumber=0;
			if (rowsMenuItems.Length>0) maxordernumber=CfgFn.GetNoNullInt32(rowsMenuItems[rowsMenuItems.Length-1]["ordernumber"]);
			
			NewMenuRow["ordernumber"]=maxordernumber+1;

			Tmenu.Rows.Add(NewMenuRow);
			return true;
		}

		private static void UpdateMenuItems(DataTable TMenuItems, DataAccess Conn, string MenuCode, DataTable Tmenu) {
		    var qhc=new CQueryHelper();
			DataRow[] rowsMenu=Tmenu.Select(qhc.CmpEq("menucode", MenuCode));
			if (rowsMenu.Length!=1) return;

			DataRow ParentMenu = rowsMenu[0];

			object livsupid= ParentMenu["idmenu"];

			rowsMenu=Tmenu.Select(qhc.CmpEq("paridmenu=",livsupid),"ordernumber ASC");
			
			//Elimino le righe di CurrMenu non presenti in MenuItems
			// cancellazione
			foreach (DataRow DR in rowsMenu) {
				string finddel = QueryCreator.WHERE_COLNAME_CLAUSE(DR,
					new string[]{"metadata","edittype","parameter"}, 
					DataRowVersion.Default, false);
				DataRow[] menurows = TMenuItems.Select(finddel);
				if (menurows.Length == 0) DR.Delete();
			}

			//rieffettua la lettura perché alcune o tutte le righe possono essere state cancellate
			rowsMenu=Tmenu.Select(qhc.CmpEq("paridmenu=",livsupid),"ordernumber ASC");
			int maxordernumber=0;
			if (rowsMenu.Length>0) maxordernumber=CfgFn.GetNoNullInt32(rowsMenu[rowsMenu.Length-1]["ordernumber"]);

			foreach (DataRow R in TMenuItems.Rows) {
				//Applica le modifiche e gli inserimenti in CurrMenu
				string findcurr = QueryCreator.WHERE_COLNAME_CLAUSE(R,
					new string[]{"metadata","edittype","parameter"}, 
					DataRowVersion.Default, false);
				DataRow[] Found= Tmenu.Select(qhc.AppAnd(findcurr,qhc.CmpEq("paridmenu=",livsupid)));
				if (Found.Length==1){
					//E' una modifica
					Found[0]["menucode"]= R["menucode"];
					Found[0]["title"]=R["title"];
				}
				else {
					//E' un inserimento
					DataRow NewR = Tmenu.NewRow();
					RowChange.CalcTemporaryID(NewR, Tmenu.Columns["idmenu"]);
					NewR["paridmenu"] = livsupid;
					NewR["edittype"]=R["edittype"];
					NewR["ordernumber"]=maxordernumber+1;
					NewR["metadata"]=R["metadata"];
					NewR["modal"]=R["modal"];
					NewR["parameter"]=R["parameter"];
					NewR["userid"]=R["userid"];
					NewR["title"]=R["title"];
                    bool added = false;
                    int idmenu = Convert.ToInt32(NewR["idmenu"]);
                    while (!added) {
                        try {
                            Tmenu.Rows.Add(NewR);
                            added = true;
                        }
                        catch (Exception e) {
                            idmenu = idmenu + 1;
                            NewR["idmenu"] = idmenu;
                        }
                    }
					
				}
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="tablename"></param>
        /// <param name="f_parameter"></param>
        /// <param name="f_text"></param>
        /// <param name="edittype"></param>
        /// <param name="metadata"></param>
        /// <param name="modal"></param>
        /// <param name="groupname"></param>
        /// <param name="Tmenu"></param>
		private static void UpdateSubMenu(DataAccess Conn,
			string tablename, 
            string filterTable,
			string f_parameter, 
			string f_text,
			string edittype,
			string metadata,
			string modal,
			string groupname,
			DataTable Tmenu
			){
			DataSet DS = new DataSetForUpdateFromMenu();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables[tablename], null, filterTable, null, true);
			DataTable Tsource=DS.Tables[tablename];
			DataTable Tmenu_temp=DS.Tables["menu"];
			int i;
			//bool success;
			// tipoclassovimenti
			i=0;
			foreach (DataRow R in DS.Tables[tablename].Rows) {
				DataRow menurow = Tmenu_temp.NewRow();
				menurow["idmenu"]=i;
				menurow["paridmenu"]=i;
				menurow["ordernumber"]=i;
				menurow["parameter"]=R[f_parameter];
				menurow["title"]=R[f_text];
				menurow["edittype"]=edittype;
				menurow["metadata"]=metadata;
				menurow["modal"]=modal;
				menurow["userid"]="";
				Tmenu_temp.Rows.Add(menurow);
				i++;
			}
			MenuUpdateClass.UpdateMenuItems(Tmenu_temp, Conn, groupname,Tmenu );

		}

        private static void UpdateSubMenu(DataAccess Conn,
            string tablename,
            string f_parameter,
            string f_text,
            string edittype,
            string metadata,
            string modal,
            string groupname,
            DataTable Tmenu
            ) {
            DataSet DS = new DataSetForUpdateFromMenu();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables[tablename], null, null, null, true);
            DataTable Tsource = DS.Tables[tablename];
            DataTable Tmenu_temp = DS.Tables["menu"];
            int i;
            //bool success;
            // tipoclassovimenti
            i = 0;
            foreach (DataRow R in DS.Tables[tablename].Rows) {
                DataRow menurow = Tmenu_temp.NewRow();
                menurow["idmenu"] = i;
                menurow["paridmenu"] = i;
                menurow["ordernumber"] = i;
                menurow["parameter"] = R[f_parameter];
                menurow["title"] = R[f_text];
                menurow["edittype"] = edittype;
                menurow["metadata"] = metadata;
                menurow["modal"] = modal;
                menurow["userid"] = "";
                Tmenu_temp.Rows.Add(menurow);
                i++;
            }
            MenuUpdateClass.UpdateMenuItems(Tmenu_temp, Conn, groupname, Tmenu);

        }



        static private void UpdateMenuBudgetVar(DataAccess Conn, DataTable Tmenu) {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();

            if (InsertMenuContainerItem(Conn, "codclassificazioni", "Variazioni di Budget",
                "variazionibudget", Tmenu)) {
                 UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                "idsorkind", "description", "default", "budgetvar", "N", "variazionibudget", Tmenu);
            }
            return;
        }

        static private void UpdateMenuDettBudgetVar(DataAccess Conn, DataTable Tmenu) {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            if (InsertMenuContainerItem(Conn, "codclassificazioni", "Dettagli Variazioni di Budget",
                "dettvariazionibudget", Tmenu)) {
                    UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                        "idsorkind", "description", "default", "budgetvardetail", "N", "dettvariazionibudget", Tmenu);
            }
            return;

        }

        static private void UpdateMenuTrasfPrevInBudget(DataAccess Conn, DataTable Tmenu) {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            if (InsertMenuContainerItem(Conn, "codclassificazioni", "Trasferimento Previsioni in Budget",
               "transfprevinbudget", Tmenu)) {
                UpdateSubMenu(Conn, "sortingkind", QHS.BitSet("flag", 2),
                "idsorkind", "description", "transfprevinbudget", "no_table", "N", "transfprevinbudget",Tmenu);
            }
            return;
        }

		private static void UpdateMenuClassificazioniMovimenti(DataAccess Conn, DataTable Tmenu) {
			UpdateSubMenu(Conn, "sortingkind","idsorkind","description",
				"default","sortinglevel","S", "codtipoclassmoviment",Tmenu);
			UpdateSubMenu(Conn, "sortingkind", "idsorkind","description",
				"default", "sorting", "N", "codclassmov",Tmenu);
		}

		private static void UpdateMenuClassificazioniTabelle(DataAccess Conn, DataTable Tmenu){		
			return ;
			/*UpdateSubMenu(Conn, "tipoclasstabelle","codicetipoclass","descrizione",
				"default","livelloclasstabelle","S", "codtipoclasstabelle",Tmenu);
			UpdateSubMenu(Conn, "tipoclasstabelle","codicetipoclass","descrizione",
				"default", "classtabelle", "N", "codclasstab",Tmenu);
			*/
		}

		private static void UpdateMenuClassificazioniIndirette(DataAccess Conn,DataTable Tmenu) 
		{
			if (InsertMenuContainerItem(Conn, "codclassificazioni", "Classificazioni indirette", 
				"traduzioneclassifica",Tmenu)) 
			{
				UpdateSubMenu(Conn, "sortingkind","idsorkind","description", 
					"traduzione", "sorting", "N", "traduzioneclassifica",Tmenu);
			}
		}


		private static void UpdateMenuVarPrevEntrate(DataAccess Conn,DataTable Tmenu) {
			if (InsertMenuContainerItem(Conn, "codclassificazioni", "Variazione previsione entrate", 
				"varclassmoven",Tmenu)) {
				UpdateSubMenu(Conn, "sortingkind","idsorkind","description", 
					"default", "sortingprevincomevar", "N", "varclassmoven",Tmenu);
			}
		}

		private static void UpdateMenuVarPrevSpese(DataAccess Conn,DataTable Tmenu) {
			if(InsertMenuContainerItem(Conn, "codclassificazioni", "Variazione previsione spese",
				"varclassmovsp",Tmenu)) {
				UpdateSubMenu(Conn, "sortingkind","idsorkind","description", 
					"default", "sortingprevexpensevar", "N", "varclassmovsp",Tmenu);
			}
		}

		private static void UpdateMenuImputazioneMovimentoEntrata(DataAccess Conn,DataTable Tmenu) {
			if(InsertMenuContainerItem(Conn, "codclassificazioni", "Imputazione movimento di entrata", 
				"impmoven",Tmenu)) {
				UpdateSubMenu(Conn, "sortingkind","idsorkind","description", 
					"main", "incomesorted", "N", "impmoven",Tmenu);
			}
		}

		private static void UpdateMenuImputazioneMovimentoSpesa(DataAccess Conn,DataTable Tmenu) {
			if (InsertMenuContainerItem(Conn, "codclassificazioni", "Imputazione movimento di spesa", 
				"impmovsp",Tmenu)) {
				UpdateSubMenu(Conn, "sortingkind","idsorkind","description", 
					"main", "expensesorted", "N", "impmovsp",Tmenu);
			}
		}

		private static void UpdateEntrataLevels(DataAccess Conn,DataTable Tmenu) {
			DataTable FaseEntrata = Conn.RUN_SELECT("incomephase","*",null,null,null,null,false);
			int IDEntrata = GetIDMenuByMenuCode(Tmenu,"codentrate");
			MyUpdateAllMovimentoMenu(IDEntrata.ToString(), Tmenu, FaseEntrata, "income", "levels");
		}

		private static void UpdateSpesaLevels(DataAccess Conn,DataTable Tmenu){
			DataTable FaseSpesa = Conn.RUN_SELECT("expensephase","*",null,null,null,null,false);
			int IDSpesa = GetIDMenuByMenuCode(Tmenu, "codspese");
			MyUpdateAllMovimentoMenu(IDSpesa.ToString(), Tmenu, FaseSpesa, "expense", "levels");
		}

		private static void UpdateCassiere(DataAccess Conn,DataTable Tmenu) {
		    QueryHelper QHS = Conn.GetQueryHelper();
            object lastEserc = Conn.DO_READ_VALUE("config", QHS.IsNotNull("appname"), "max(ayear)");
            string filtereserc = QHS.CmpEq("ayear", lastEserc); //"(ayear='" + Conn.GetSys("esercizio").ToString() + "')";
            DataTable PersGen = Conn.RUN_SELECT("config","*",null,filtereserc,null,null,false);
			if ((PersGen==null)||(PersGen.Rows.Count==0)) return;
			DataRow Pers = PersGen.Rows[0];
			int IDSpesa = GetIDMenuByMenuCode(Tmenu, "codcassiere");
			MyUpdateCassiereMenu(IDSpesa.ToString(), Tmenu, Pers);
		}
        private static void UpdateVarious(DataAccess Conn, DataTable Tmenu) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object lastEserc = Conn.DO_READ_VALUE("config", QHS.IsNotNull("appname"), "max(ayear)");
            string filtereserc = QHS.CmpEq("ayear", lastEserc); //"(ayear='" + Conn.GetSys("esercizio").ToString() + "')";
            DataTable Cfg = Conn.RUN_SELECT("config", "*", null, filtereserc, null, null, false);
            if ((Cfg == null) || (Cfg.Rows.Count == 0))
                return;
            DataRow rCfg = Cfg.Rows[0];
            
            DataTable UniCfg = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, false);
            if ((UniCfg == null) || (UniCfg.Rows.Count == 0))
                return;
            DataRow rUniCfg = UniCfg.Rows[0];

            UpdateVarious(Tmenu, rCfg, rUniCfg);
        }

/*		private static void ClearMenuStampe(DataAccess Conn,DataTable Tmenu){
			//"codstampe" è il groupname della voce "stampe" (1o livello)
			int IDStampe = GetIDMenuByMenuCode(Tmenu, "codstampe");
			DataRow []Found = Tmenu.Select("(paridmenu="+QueryCreator.quotedstrvalue(IDStampe,false)+")");
			if (Found.Length==0) return;
			foreach (DataRow DD in Found) {
				CascadeMenuDelete(Tmenu, DD);
			}
		}*/

		private static void UpdateAllReports(DataAccess Conn,DataTable Tmenu){
			string filter = Conn.GetSys("filterrule") as string;
			filter= GetData.MergeFilters(filter,"(active='S')");
			DataTable ModuleReports = Conn.RUN_SELECT("report","*",null,filter,null,null,false);
			if (ModuleReports==null) ModuleReports = Conn.RUN_SELECT("report","*","modulename,reportname",null,null,null,false);
			//"codstampe" è il groupname della voce "stampe" (1o livello)
			int IDStampe = GetIDMenuByMenuCode(Tmenu, "codstampe");
			MyUpdateAllReportMenu(IDStampe, Tmenu, ModuleReports);
		}

		private static void UpdateAllExport(DataAccess Conn, DataTable Tmenu){
            var qhc = new CQueryHelper();
			DataTable ExpStoredProcedure = Conn.RUN_SELECT("exportfunction","*",null,null,null,null,false);
			//"codprocesportazione" è il groupname della voce "Procedure Esportazione" (2o livello)
			int IDExport = GetIDMenuByMenuCode(Tmenu, "codprocesportazione");
			if (IDExport==-1){
				DataRow StampeRow = Tmenu.Select(qhc.CmpEq("menucode","codstampe"))[0];
				//Aggiunge il menu di esportazione poiché non c'è
				DataRow ExpMenuRow = NewMenuChild(StampeRow);
				ExpMenuRow["menucode"]="codprocesportazione";
				ExpMenuRow["title"]="Esportazioni";
				IDExport= CfgFn.GetNoNullInt32(ExpMenuRow["idmenu"]);
			}
			MyUpdateAllExportMenu(IDExport, Tmenu, ExpStoredProcedure);
		}

        static void UpdateMenuStampe(DataAccess Conn, DataTable Tmenu) {
			//ClearMenuStampe(Conn,Tmenu);
			UpdateAllReports(Conn,Tmenu);
			UpdateAllExport(Conn,Tmenu);
		}

        public static string UpdateMenu(EntityDispatcher E) {
            if (E == null) return null;
            if (E.Conn == null) return null;
            DataAccess ConnClone = E.Conn.Duplicate();
            string res = null;
            try {
                res = UpdateMenu(ConnClone);
            }
            catch { }
            ConnClone.Destroy();
            return res;
        }
		/// <summary>
		/// Funzione ottimizzata di aggiornamento menu. Eseguitain MULTI-THREAD!!
		/// </summary>
		/// <param name="Conn">DataAccess</param>
		/// <returns>NULL se va abuon fine, altrimenti messaggio</returns>
        public static string UpdateMenu(DataAccess Conn) {
            try {
                DataAccess ConnClone = Conn;
                DataTable Tmenu = ConnClone.RUN_SELECT("menu", "*", null, null, null, false);
                RowChange.MarkAsAutoincrement(Tmenu.Columns["idmenu"], null, null, 7);

                UpdateMenuClassificazioniMovimenti(ConnClone, Tmenu);
                //UpdateMenuClassificazioniTabelle(ConnClone,Tmenu);
                UpdateMenuClassificazioniIndirette(ConnClone, Tmenu);
                // Rusciano G. 21.07.2005
                // Queste due righe vengono commentate in quanto non vogliamo che compaiano
                // nel menu. Eventualmente commentare anche il metodo
                //UpdateMenuImputazioneRicaviNonFinanziari(ConnClone,Tmenu);
                //UpdateMenuImputazioneCostiNonFinanziari(ConnClone,Tmenu);
                UpdateMenuVarPrevEntrate(ConnClone, Tmenu);
                UpdateMenuVarPrevSpese(ConnClone, Tmenu);
                UpdateMenuImputazioneMovimentoEntrata(ConnClone, Tmenu);
                UpdateMenuImputazioneMovimentoSpesa(ConnClone, Tmenu);
                UpdateEntrataLevels(ConnClone, Tmenu);
                UpdateSpesaLevels(ConnClone, Tmenu);
                UpdateCassiere(ConnClone, Tmenu);
                UpdateVarious(ConnClone, Tmenu);

                UpdateMenuStampe(ConnClone, Tmenu);
                UpdateMenuBudgetVar(ConnClone, Tmenu);
                UpdateMenuDettBudgetVar(ConnClone, Tmenu);
                UpdateMenuTrasfPrevInBudget(ConnClone, Tmenu);

                PostData myPost = new Easy_PostData();
                DataSet ds = new DataSet();
                ds.Tables.Add(Tmenu);
                ds.Relations.Add("myrel", Tmenu.Columns["idmenu"], Tmenu.Columns["paridmenu"], false);
                PostData.RemoveFalseUpdates(ds);
                myPost.InitClass(ds, ConnClone);
                string result = null;
                if (!myPost.DO_POST()) {
                    return ConnClone.LastError;
                }
                SetMenuToUpdate();

                return result;
            }
            catch (Exception EE) {
                return EE.Message + "\r\n" + EE.StackTrace;
            }
		}

		#endregion

	}
}
