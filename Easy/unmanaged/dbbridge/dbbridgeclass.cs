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
using metadatalibrary;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dbbridge//dbbridge//
{

	public class Alias{
		public const string AliasPrefix="Alias#";

		public string real;
		public string alias;
		public Alias(string real, string alias){
			this.real=real;
			this.alias = alias;
		}
	}

	public class Aliases {
		Stack Levels;
		public ArrayList AliasList;
		public Aliases(){
			Levels= new Stack();  //stack dei livelli per ogni alias 
			AliasList= new ArrayList();
		}
		public void AddAlias(string table, string alias){
			AliasList.Add(new Alias(table.ToLower(),alias.ToLower()));
		}
		public void IncLevel(){
			int CurrAliases = AliasList.Count;
			Levels.Push(CurrAliases);
		}
		public void DecLevel(){
			if (Levels.Count==0) return;
			int SavedAliases = (int) Levels.Pop();
			while (AliasList.Count>SavedAliases) AliasList.RemoveAt(AliasList.Count-1);
		}

		/// <summary>
		/// Restituisce il nome reale della tabella ossia rimosso dall'alias eventualmente esistente
		///  o null se la tabella non aveva alias
		/// </summary>
		/// <param name="alias"></param>
		/// <returns></returns>
		public string Unalias(string alias){
			alias = alias.ToLower();
			for (int i=AliasList.Count-1; i>=0; i--){
				Alias A = (Alias) AliasList[i];
				if (A.alias== alias){
					return A.real;
				}
			}
			return null;
		}

	}

	public struct NuovoNomeVariabileTemporanea 
	{
		public int occur;
		public string newName;

		public NuovoNomeVariabileTemporanea(string nuovoNome) 
		{
			occur = 1;
			newName = nuovoNome;
		}
	}

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class DBBridge
	{
		DataAccess Conn;

		public static Hashtable tempVar;
		/// <summary>
		/// Tables[vecchionometabella]=nuovonometabella
		/// </summary>
		static Hashtable Tables; 
		/// <summary>
		/// Tables[vecchiatabella.vecchiocampo]= nuovocampo
		/// </summary>
		static Hashtable Columns;

		/// <summary>
		/// Procedures[vecchiasp]= nuovasp
		/// </summary>
		static Hashtable Procedures;

		/// <summary>
		/// Params[oldparam]=param
		/// </summary>
		static Hashtable Params;

		Hashtable CurrParams;

		public StringBuilder compiled;
		/// <summary>
		/// TablesAlias[NomeAliasTabella] = NomeVecchiaTabella 
		/// </summary>
		public Aliases TablesAlias; 
		/// <summary>
		/// ColumnAlias[NomeAliasTabella.AliasCampo] = NomeVecchioCampo
		/// </summary>
		Aliases ColumnsAlias; 
		protected SPBridge SPB;

		public DBBridge(DataAccess Conn)
		{
			//
			// TODO: Add constructor logic here
			//
			this.Conn= Conn;
			CurrParams = new Hashtable();

			if (Tables==null) 
			{
				tempVar = new Hashtable();
				Tables= new Hashtable();
				DataTable table = Conn.RUN_SELECT("tablename","oldtable,newtable",null,null,null,false);
				foreach (DataRow tableR in table.Rows)
				{
					Tables[tableR["oldtable"].ToString().ToLower()] = tableR["newtable"].ToString();
				}
		
				Columns = new Hashtable();
				DataTable cols = Conn.RUN_SELECT("colname","oldtable,oldcol,newcol",null,null,null,false);
				foreach (DataRow colR in cols.Rows)
				{
					Columns[ colR["oldtable"].ToString().ToLower()+"."+colR["oldcol"].ToString().ToLower()]= 
						colR["newcol"].ToString();
				}
				
				Params = new Hashtable();
				DataTable myparams = Conn.RUN_SELECT("params","oldname,newname",null,null,null,false);
				foreach (DataRow parR in myparams.Rows)
				{
					Params[parR["oldname"].ToString().ToLower()] = parR["newname"].ToString();
				}
				
				Procedures = new Hashtable();
				DataTable myprocs = Conn.RUN_SELECT("procedures","oldname,newname",null,null,null,false);
				foreach (DataRow procR in myprocs.Rows)
				{
					Procedures[procR["oldname"].ToString().ToLower()] = procR["newname"].ToString();
				}
			}
		}

		public virtual void Init(string spbody){
			compiled = new StringBuilder("");
			TablesAlias = new Aliases();
			ColumnsAlias = new Aliases();
			SPB = new SPBridge(spbody);
		}



		void DecLevel(){
			TablesAlias.DecLevel();

		}
		void IncLevel(){
			TablesAlias.IncLevel();
		}

		public void CompileExpressions(int minlevel){
			CompileExpressions(false,minlevel);
		}

		public void CompileExpressions(){
			CompileExpressions(false,0);
		}

		public string GetCompiled(){
			return compiled.ToString();
		}

		/// <summary>
		/// Compila un elenco di espressioni, ossia expr,expr,expr... e termina se trova una parentesi chiusa 
		///		non aperta. Compila anche qualsiasi cosa trova prima di una parentesi tonda chiusa non aperta.
		///	Se OneTerm=true esce anche se trova una virgola a livello 0.
		///	Restituisce true se è uscito a causa di una virgola, false altrimenti
		/// </summary>
		public bool CompileExpressions(bool OneTerm,int minlevel){
			string skipped;
			int mylevel=0;
			int blocklevel=0;
			SPToken SPT = SPB.NextToken(out skipped);
			while (SPT.kind!=tokenkind.EOF){
				if (OneTerm && (mylevel==0) && (blocklevel==0) && (SPT.val==",")){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					return true;
				}
				if (SPT.kind == tokenkind.openbracket){
					compiled.Append(skipped);
					IncLevel();
					compiled.Append(SPT.val);
					mylevel++;
					SPT = SPB.NextToken(out skipped);
					continue;
				}
				if (SPT.kind== tokenkind.closebracket){
					compiled.Append(skipped);
					DecLevel();
					compiled.Append(SPT.val);
					mylevel--;
					if (mylevel<0) return false;
					SPT = SPB.NextToken(out skipped);
					continue;
				}
				if (SPT.kind == tokenkind.keyword){
					switch (SPT.val.ToLower()){
						case "insert":  
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileInsert();
										break;
						case "select":  
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileSelect();
										break;
						case "update":  
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileUpdate();
										break;
						case "delete":  
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileDelete();
										break;
						case "case":	
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										blocklevel++;
										//CompileCase();
										break;
						case "begin":	
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										blocklevel++;
										break;
						case "end":	
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										blocklevel--;
										break;
						case "create":  compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileCreate();
										break;
						case "alter":   compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileCreate();
										break;
						case "exec": 
						case "execute": 
										compiled.Append(skipped);
										compiled.Append(SPT.val);
										CompileExecute();
										break;
						default :
										compiled.Append(skipped);
										compiled.Append(SPT.val); //le altre keyword vengono semplicemente copiate
										break;
					}
					SPT = SPB.NextToken(out skipped);
					continue;
				}

				//Compila "nomecampo" o "nometabella.nomecampo" o "nomealias.nomecampo"
				if (SPT.kind == tokenkind.identifier){
					compiled.Append(skipped);
					compiled.Append(CompileColumnName(SPT.val,minlevel));
					SPT = SPB.NextToken(out skipped);
					continue;
				}
				else  {
					compiled.Append(skipped);
					compiled.Append( SPT.val);
					SPT = SPB.NextToken(out skipped);
					continue;
				}

			}
			compiled.Append(skipped);
			return false;
		}

		/// <summary>
		/// Compila "aliased table" in "aliased table" se alias presente,
		///		o "nuovo nome tabella" se alias non presente
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string CompileTableName(string dbo_table){
			string []parts = dbo_table.Split(new char[]{'.'});
			string dbocomplete="";
			string tablecomplete=null;
			string table="";
			if (parts.Length>1){
				dbocomplete=parts[0];
				tablecomplete=parts[1];
			}
			else {
				tablecomplete=parts[0];
			}
			if (tablecomplete!=null) {
				table = (tablecomplete.Replace("[","")).Replace("]","");
			}

			string unaliased = TablesAlias.Unalias(table);
			if ((unaliased!=null)&&(unaliased.ToLower()!=table.ToLower())) return dbo_table;
			if (Tables[table.ToLower()]==null) return CompileProcedureName(dbo_table); // dbo_table;
			if ((tablecomplete == null)||(Tables[table.ToLower()]==null)) 
			{
				Console.WriteLine(table);
			}
			if (dbocomplete!="")
				return dbocomplete+ "." + tablecomplete.Replace(table, Tables[table.ToLower()].ToString());
			else 
				return tablecomplete.Replace(table, Tables[table.ToLower()].ToString());
		}

		/// <summary>
		/// Compila "[dbo].[proc]" in "[dbo].[newproc]" 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string CompileProcedureName(string dbo_proc){
			string []parts = dbo_proc.Split(new char[]{'.'});
			string dbocomplete="";
			string proccomplete=null;
			string proc="";
			if (parts.Length>1){
				dbocomplete=parts[0];
				proccomplete=parts[1];
			}
			else {
				proccomplete=parts[0];
			}
			if (proccomplete!=null) {
				proc = (proccomplete.Replace("[","")).Replace("]","");
			}

			if (Procedures[proc.ToLower()]==null) return dbo_proc;
			if (dbocomplete!="")
				return dbocomplete+ "." + proccomplete.Replace(proc, Procedures[proc.ToLower()].ToString());
			else 
				return proccomplete.Replace(proc, Procedures[proc.ToLower()].ToString());
		}

		string CompileTempVar(string var){
			object o = tempVar[var];
			if (o==null) 
			{
				tempVar[var] = new NuovoNomeVariabileTemporanea(var);
			} 
			else 
			{
				NuovoNomeVariabileTemporanea n = (NuovoNomeVariabileTemporanea) o;
				n.occur++;
			}
			if (CurrParams[var.ToLower()]!=null) return CurrParams[var.ToLower()].ToString();
			if (var.ToLower()=="@esercizio") return "@ayear";
			if (var.ToLower()=="@idspesa") return "@idexp";
			if (var.ToLower()=="@identrata") return "@idinc";
			if (var.ToLower()=="@idbilancio") return "@idfin";
			if (var.ToLower()=="@codicebilancio") return "@fincode";
			if (var.ToLower()=="@codicecentrospesa") return "@idcen";
			if (var.ToLower()=="@idbilpluriennale") return "@idmul";
			if (var.ToLower()=="@codicebilpluriennale") return "@mulfincode";
			if (var.ToLower()=="@tempidspesa") return "@tmpidexp";
			if (var.ToLower()=="@tempidentrata") return "@tmpidinc";
			if (var.ToLower()=="@tempidbilancio") return "@tmpidfin";
			if (var.ToLower()=="@tempidbilpluriennale") return "@tmpidmul";
			if (var.ToLower()=="@tempcodicebilpluriennale") return "@tmpmulfincode";
			if (var.ToLower()=="@tempcodicebilancio") return "@tmpfincode";
			if (var.ToLower()=="@tempcodicecentrospesa") return "@tmpcencode";
			if (var.ToLower()=="@importo") return "@amount";
			if (var.ToLower()=="@codicecreddeb") return "@idreg";
			if (var.ToLower()=="@esercmovimento") return "@ymov";
			if (var.ToLower()=="@nummovimento") return "@nmov";
			if (var.ToLower().StartsWith("@codice")) 
				return var.ToLower().Replace("@codice","@cod");
			if (var.ToLower().StartsWith("@temp")) return var.Replace("@temp","@tmp");
			if (var.ToLower().StartsWith("@fase")) return var.Replace("@fase","@phase");

			return var;
		}

		string GetSimpleTableName(string dbo_table){
			string []parts = dbo_table.Split(new char[]{'.'});
			string table="";
			string tablecomplete="";
			if (parts.Length>1){
				tablecomplete=parts[1].ToLower();
			}
			else {
				tablecomplete=parts[0].ToLower();
			}
			if (tablecomplete!=null) {
				table = (tablecomplete.Replace("[","")).Replace("]","");
			}
			return table;
		}



		string CompileInsideBrack(string tablecol){
			string start= tablecol.Substring(0,2);
			string stop = tablecol.Substring(tablecol.Length-2,2);
			tablecol= tablecol.Substring(2,tablecol.Length-4);
			string []parts = tablecol.Split(new char[]{'.'});
			if (parts.Length<2){
				return start+tablecol+stop;
			}
			string table = parts[0].ToLower().Trim();
			string col = parts[1].ToLower().Trim();
			string outtable= table;
			string outcol= col;
			if (Tables[table]!=null) outtable= Tables[table].ToString();
			if (Columns[table+"."+col]!=null) outcol= Columns[table+"."+col].ToString();
			return start+ outtable+"."+outcol+ stop;
		}

		/// <summary>
		/// Compila "aliased table"."aliased column" 
		/// </summary>
		/// <param name="tablecol"></param>
		/// <param name="minlevel"></param>
		/// <returns></returns>
		public string CompileColumnName(string tablecol){//table,col
			return CompileColumnName(tablecol,0);
		}


		/// <summary>
		/// Compila "aliased table"."aliased column" in 
		///		"nuova tabella"."nuova colonna" se alias su tabella presente e alias colonna non presente
		///		"aliased table"."nuova colonna" se alias su tabella non presente e alias colonna non presente
		///		o
		///		"nuova colonna" se tabella non presente
		/// </summary>
		/// <param name="tablecol"></param>
		/// <param name="minlevel">livello minimo (incluso) per l'uso delle tabelle</param>
		/// <returns></returns>
		public string CompileColumnName(string tablecol,int minlevel){//table,col

			//Deve interpretare col come [dbo].[table],
			//  o [dbo].[table].[colname] o [table].[colname]  o colname 
			//  oppure le stesse senza le parentesi quadre ed ottenere il risultato corretto.
			// La stessa modifica deve essere fatta anche a CompileTableName così da essere coerente
			//  con il contenuto di col (calcolato da GetKeywordOrIdentifier), ossia che può
			//  contenere le parentesi [] o DBO prima di tablename.


			if (tablecol.StartsWith("@")){
				return CompileTempVar( tablecol);
			}
			if (tablecol.StartsWith("%<")||tablecol.StartsWith("&<")){
				return CompileInsideBrack(tablecol);
			}
			string []parts = tablecol.Split(new char[]{'.'});
			string table=null;
			string dbocomplete=null;
			string tablecomplete=null;
			string col=null;
			string dbo="";
			string colcomplete=null;
			if (parts.Length==1){
				colcomplete=parts[0];	}
			else {
				if (parts.Length==2){
					tablecomplete= parts[0];
					colcomplete= parts[1];
				}
				else {
					dbocomplete= parts[0];
					tablecomplete= parts[1];
					colcomplete= parts[2];
				}
			}

			if (tablecomplete!=null) 
				table = (tablecomplete.Replace("[","")).Replace("]","");
			if (colcomplete!=null)
				col = (colcomplete.Replace("[","")).Replace("]","");
			if (dbocomplete!=null)
				dbo = dbocomplete+".";


			if (table!=null){
				string unaliasedtable= TablesAlias.Unalias(table);
				if (unaliasedtable==null) unaliasedtable=table;
				string aliascol= unaliasedtable+"."+col.ToLower();
				if (ColumnsAlias.Unalias(aliascol)!=null){ //se table.col è alias, restituisce l'alias stesso
					return col;
				}
				string unaliased = TablesAlias.Unalias(table.ToLower()); //unaliased= vecchio nome tabella
				if ((unaliased==null)||(unaliased.ToLower()== table.ToLower())){

					//La tabella non era un alias  --> anche il nome della tabella è da convertire 
					if (Columns[aliascol]==null)
						return dbo+CompileTableName(tablecomplete)+"."+colcomplete;
					
					return dbo+CompileTableName(tablecomplete)+"."+
						colcomplete.Replace(col, Columns[aliascol].ToString());
				}
				else {
					//La tabella era un alias   --> non converte il nome della tabella 
					if (Columns[aliascol]==null){
						return dbo+tablecol; //table+"."+col;
					}
					return dbo+tablecomplete+"."+colcomplete.Replace(col, Columns[aliascol].ToString());
						//Columns[tabcol].ToString();
				}
			}
			
			//Non è stata fornita la table-->prova con le tables esistenti. Questo presume che anche
			// le tabelle cui non è associato un alias, ma che sono usate nelle istruzioni, abbiano
			// un alias fittizio con nome alias uguale al nome della tabella
			for (int i= TablesAlias.AliasList.Count-1; i>=minlevel; i--){
				Alias A = (Alias) TablesAlias.AliasList[i];
				string aliascol= A.alias.ToLower()+"."+col.ToLower();
				if (ColumnsAlias.Unalias(aliascol)!=null){ //se colonna è alias, restituisce l'alias stesso
					return col;
				}
				string tabcol= A.real.ToLower()+"."+col.ToLower();
				if (Columns[tabcol]!=null){
					return 
						dbo+colcomplete.Replace(col, Columns[tabcol].ToString());
						//Columns[tabcol].ToString(); //converte eventualmente il nome della tabella
				}
				DataTable TT = Conn.CreateTableByName(A.real,"*");
				if (TT.Columns[col.ToLower()]!=null){
					return dbo+colcomplete;
				}
			}
			return dbo+tablecol;
		}

/*
DELETE 
    [ FROM ] 
        { table_name WITH ( < table_hint_limited > [ ...n ] ) 
         | view_name 
         | rowset_function_limited 
        } 

        [ FROM { < table_source > } [ ,...n ] ] 

    [ WHERE 
        { < search_condition > 
        | { [ CURRENT OF 
                { { [ GLOBAL ] cursor_name } 
                    | cursor_variable_name 
                } 
            ] }
        } 
    ] 
    [ OPTION ( < query_hint > [ ,...n ] ) ] 
	
*/

		public void CompileDelete(){
			string skipped;
			SPToken SPT;

			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			IncLevel();

			//salta eventuale from
			if (SPT.val.ToLower()=="from"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileFrom(); //prende il primo o il secondo (se primo assente) caso di FROM
				mark= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if (SPT.val.ToLower()=="from"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					//prende il secondo caso di from
					CompileFrom();
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
			}

			if(SPT.val.ToLower()=="where"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				int mark2= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if (SPT.val.ToLower()=="current"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped); //of
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped); //of
					compiled.Append(skipped);
					compiled.Append(SPT.val);  //GLOBAL o identifier
					if (SPT.val.ToLower()=="global"){
						SPT = SPB.NextToken(out skipped); 
						compiled.Append(skipped);
						compiled.Append(SPT.val);  //identifier
					}
				}
				else {
					SPB.GotoMark(mark2);
					CompileSingleExpression();
				}
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			//	[ OPTION ( < query_hint > [ ,...n ] ) ] 
			if (SPT.val.ToLower()=="option"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);  // (
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileExpressions();
				mark = SPB.GetMark();
			}
			SPB.GotoMark(mark);
			DecLevel();

			


		}


		/// <summary>
		/// INSERT [INTO] table_or_view [(column_list)] data_values
		/// 
		/// INSERT INTO MyBooks
		///		SELECT title_id, title, type
		///		FROM titles
		///		WHERE type = 'mod_cook'
		/// 
		/// INSERT INTO Northwind.dbo.Shippers (CompanyName, Phone)
		///		VALUES (N'Snowflake Shipping', N'(503)555-7233')
		///		
		///		
		///	INSERT INTO MyBooks
		///		EXECUTE 
		///		  [@var =]
		///		  SP_name | SP_name_var
		///		    [ [ @parameter = ] { value | @variable [ OUTPUT ] | [ DEFAULT ] ] {, ...}
		///		[ WITH RECOMPILE ] 
		/// </summary>
		/// <param name="SPT"></param>
		public void CompileInsert(){
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped);
			compiled.Append(skipped);
			if (SPT.kind==tokenkind.EOF) return;
			if (SPT.val.ToLower()=="into"){
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				if (SPT==null) return;
			}
			string maintable = GetSimpleTableName( SPT.val.ToLower());
			compiled.Append(CompileTableName(SPT.val));
			IncLevel();
			TablesAlias.AddAlias(maintable,maintable); //nella insert non è previsto un alias per il nome della tabella
		

            // Ora può seguire (lista campi) oppure VALUES(lista valori) oppure istruzione SELECT oppure EXEC[UTE]
			SPT = SPB.NextToken(out skipped);
			compiled.Append(skipped);
			if (SPT==null) return;

			if (SPT.val=="("){ //Aggiunge la lista dei campi 
				compiled.Append(SPT.val);
				CompileExpressions();
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
			}

			//ORA DEVE SEGUIRE o: VALUES(lista valori) oppure istruzione SELECT oppure EXEC[UTE] o (EXPRESSION)
			if (SPT.kind==tokenkind.EOF) return;
			compiled.Append(SPT.val);
			if (SPT.val.ToLower()=="("){
				CompileExpressions();
				return;
			}

			if (SPT.val.ToLower()=="values"){
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				compiled.Append( SPT.val);
				if (SPT.val!="(") QueryCreator.ShowError(null,"Attesa parentesi tonda aperta dopo values",compiled.ToString());
				CompileExpressions(); //effettua una DecLevel()
				//DecLevel();
				return;
			}
			if (SPT.val.ToLower()=="select"){
				CompileSelect();
				DecLevel();
				return;
			}
			if ((SPT.val.ToLower()=="execute")||(SPT.val.ToLower()=="exec")){
				CompileExecute();
				DecLevel();
				return;
			}
			DecLevel();
			QueryCreator.ShowError(null,SPT.val+" trovato dopo INSERT (INATTESO)",compiled.ToString());
		} 

		/// <summary>
		/// Compila la clausola FROM, assumendo la parola FROM già letta
		///		[ FROM { < table_source > } [ ,...n ] ] 
		/// 
		///   < table_source > ::= 
		///   table_name [ [ AS ] table_alias ] [ WITH ( < table_hint > [ ,...n ] ) ] 
		///   | view_name [ [ AS ] table_alias ] [ WITH ( < view_hint > [ ,...n ] ) ] 
		///   | rowset_function [ [ AS ] table_alias ] 
		///   | user_defined_function [ [ AS ] table_alias ]
		///   | derived_table [ AS ] table_alias [ ( column_alias [ ,...n ] ) ] 
		///   | < joined_table > 
		///
		///   < joined_table > ::= 
		///   < table_source > < join_type > < table_source > ON < search_condition > 
		///   | < table_source > CROSS JOIN < table_source > 
		///   | [ ( ] < joined_table > [ ) ]
		///	
		///   < join_type > ::= 
		///   [ INNER | { { LEFT | RIGHT | FULL } [ OUTER] } ] 
		///   [ < join_hint > ] 
		///   JOIN
		///   
		///   < join_hint > ::= 
		///      {LOOP | HASH | MERGE | REMOTE }
		/// </summary>
		public void CompileFrom(){
			string skipped;
			SPToken SPT ;
			//compiled.Append(skipped);
			while (true){ // continua fin quando trova una virgola
				CompileTableSource();
				int mark= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if (SPT.val!=","){
					SPB.GotoMark(mark);
					return;
				}
				//Aggiunge la virgola all'output
				compiled.Append(skipped);
				compiled.Append(SPT.val);
			}
		}

		string GetCompiledTable(string unaliasedtable){
			if (Tables[unaliasedtable.ToLower()]==null)return unaliasedtable.ToLower();
			string table= Tables[unaliasedtable.ToLower()].ToString();
			return table;
		}

		/// <summary>
		///   < simple table source  > ::= 
		///   table_name [ [ AS ] table_alias ] [ WITH ( < table_hint > [ ,...n ] ) ] //CASO 5
		///   | view_name [ [ AS ] table_alias ] [ WITH ( < view_hint > [ ,...n ] ) ] //CASO 4
		///   | rowset_function [ [ AS ] table_alias ]   //CASO 2
		///   | user_defined_function [ [ AS ] table_alias ] //CASO 3
		///   | derived_table [ AS ] table_alias [ ( column_alias [ ,...n ] ) ] //CASO 1
		///
		/// </summary>
		public void CompileSimpleTableSource(){  //Solo CASO 1,2,3,4,5
			//Prende l'identificatore
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped);
			compiled.Append(skipped);
			if (SPT.kind== tokenkind.openbracket){  //CASO 1
				//Table Source è una subquery inclusa tra parentesi-> la compila
				compiled.Append(SPT.val);
				CompileTableSourceSubQuery();
				return;
			}
			else {
			}

			if (SPT.kind!= tokenkind.identifier){
				QueryCreator.ShowError(null, SPT.val+" trovato invece di un identificatore ",compiled.ToString());
			}
			string maintable= SPT.val.ToLower(); //tablename || view_name || rowset function || user def. 
			string maintableoriginal = SPT.val;
			string simpletable = GetSimpleTableName(maintable);

			//Vede se è una chiamata a funzione
			int mark = SPB.GetMark();
			bool WasFunctionCall=false;

			SPT = SPB.NextToken(out skipped);
			if (SPT.kind== tokenkind.openbracket){
				//compiled.Append(maintable); usa la seguente, per coprire JOIN table (NOLOCK) che esiste!!
				compiled.Append(CompileTableName(maintableoriginal));
				//Era una chiamata a funzione --> chiude la chiamata a funzione (CASO 2,3)
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				IncLevel();
				CompileExpressions();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				WasFunctionCall=true; //In questi casi non c'è la clausola WITH...
			}
			else {
				compiled.Append(CompileTableName(maintableoriginal));
			}
			//CASO 4,5: (in comune a 2,3 ha [[AS] table_alias]
			//Compila [[AS] table_alias]
			if ((SPT.kind== tokenkind.keyword)&&(SPT.val.ToLower()=="as")){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);			
			}
			if(SPT.kind== tokenkind.identifier){
				if (WasFunctionCall){
					//Alias.AliasPrefix+maintable+TablesAlias.AliasList.Count;
					TablesAlias.AddAlias(simpletable.ToLower(), SPT.val);
				}
				else {
					string tabName = simpletable.ToLower();					
					if ((tabName!="inserted") && (tabName!="deleted") && (tabName!="updated")){
						TablesAlias.AddAlias(tabName,SPT.val);
					}
					else {
						string unaliased= TablesAlias.Unalias(tabName);
						TablesAlias.AddAlias(unaliased,tabName);
					}
				}
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);			
			}
			else { //Non ha trovato [AS] identifier --> crea comunque un alias fittizio
				if (WasFunctionCall){
					string AliasName = simpletable.ToLower(); // Alias.AliasPrefix+maintable+TablesAlias.AliasList.Count;
					TablesAlias.AddAlias(AliasName, AliasName); //ex ,SPT.val
				}
				else {
					string tabName = simpletable.ToLower();
					string TableCompiled= simpletable.ToLower();
					if (Tables[maintable.ToLower()]!=null) TableCompiled= Tables[maintable.ToLower()].ToString();
					if ((tabName!="inserted") && (tabName!="deleted") && (tabName!="updated")){
						TablesAlias.AddAlias(tabName, TableCompiled); //ex ,SPT.val
					}
					else {
						string unaliased= TablesAlias.Unalias(tabName);
						TablesAlias.AddAlias(unaliased,tabName);
					}

				}
			}

			if (WasFunctionCall || ((SPT.val.ToLower()!="with")&&(SPT.kind!=tokenkind.openbracket))){ //CASO 2, 3: Qui non c'è clausola WITH
				SPB.GotoMark(mark);
				return;
			}


			if (SPT.val.ToLower()=="with"){
				//Compila la clausola WITH
				compiled.Append(skipped); //mette il with
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);	
			}


			compiled.Append(skipped);  //mette la parentesi tonda aperta
			compiled.Append(SPT.val); 
			int level= 1;
			while (level>=1){ //mette tutto quello che c'è tra le parentesi
				SPT = SPB.NextToken(out skipped);	
				compiled.Append(skipped);  //mette la parentesi tonda aperta
				compiled.Append(SPT.val); 
				if (SPT.kind== tokenkind.openbracket) level++;
				if (SPT.kind== tokenkind.closebracket) level--;
				if (SPT.kind==tokenkind.EOF) break;
			}
		}


		/// <summary>
		///   < table_source > ::= 
		///    < simple table source (casi 1-5) >
		///   | < joined_table > 
		///   
		///   < joined_table > ::= 
		///   < table_source > < join_type > < table_source > ON < search_condition > 
		///   | < table_source > CROSS JOIN < table_source > 
		///   | [ ( ] < joined_table > [ ) ]
		///	
		///   < join_type > ::= 
		///   [ INNER | { { LEFT | RIGHT | FULL } [ OUTER] } ] 
		///   [ < join_hint > ] 
		///   JOIN
		///   
		///   < join_hint > ::= 
		///      {LOOP | HASH | MERGE | REMOTE }
		/// </summary>
		public void CompileTableSource(){
			CompileSimpleTableSource();
			while (true){ //prosegue eventualmente con la lista di JOIN
				string skipped;
				int mark = SPB.GetMark();
				bool IsCrossJoin = false;
				SPToken SPT = SPB.NextToken(out skipped);
				int markstart= SPB.GetMark();
				//Compila < join type > = [ INNER | { { LEFT | RIGHT | FULL } [ OUTER] } ] 
				if (SPT.val.ToLower()== "inner"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
				else {
					if ((SPT.val.ToLower()== "left")||(SPT.val.ToLower()== "right")||(SPT.val.ToLower()== "full")){
						compiled.Append(skipped);
						compiled.Append(SPT.val);
						mark = SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
					}
					if (SPT.val.ToLower()== "outer"){
						compiled.Append(skipped);
						compiled.Append(SPT.val);
						mark = SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
					}
				}
				//Compila [ < join_hint > ] =  {LOOP | HASH | MERGE | REMOTE }
				if ((SPT.val.ToLower()== "loop")||(SPT.val.ToLower()== "hash")||
					(SPT.val.ToLower()== "merge")||(SPT.val.ToLower()== "remote")){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
				if (SPT.val.ToLower()== "cross"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					IsCrossJoin=true;
				}
				if (SPT.val.ToLower()== "join"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
				}
				else {
					int mark2= SPB.GetMark();
					if (mark2!=markstart) {
						QueryCreator.ShowError(null,"Atteso JOIN",compiled.ToString());
					}
					SPB.GotoMark(mark);
					return;  //E' da cui che esce se la lista dei join finisce
				}
			
				CompileSimpleTableSource();

				if (!IsCrossJoin) {

					//Compila ON <search condition>
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					if (SPT.val.ToLower()!="on"){
						QueryCreator.ShowError(null,"Atteso on",compiled.ToString());
						SPB.GotoMark(mark);
						return;
					}
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					CompileSingleExpression();
				}

			}

		}


		bool IsOperator(SPToken SP){
			string []operators= new string[]{
												"<",">","=","!","and","or","not", "is","in", //"null",
												"+","-","/","*","|","&","%","between","like"
											};
			string val = SP.val.ToLower();
			foreach (string op in operators){
				if (op==val) return true;
			}
			return false;
		}

		public void CompileSingleExpression(){
			CompileSingleExpression(0);
		}

		/// <summary>
		/// Compila una espressione singola, ossia una sequenza di operatori e operandi. La regola che 
		///  stabilisce se qualcosa fa o meno parte dell'espressione è che dopo un operatore ci vuole un altro 
		///  operatore od un operando, dopo un operando ci vuole un operatore. Un identificatore
		///   è considerato un operando. Un identificatore seguito da parentesi aperta  include anche tutta 
		///   l'espressione tra parentesi. Altrimenti una espressione tra parentesi è assimilata ad un 
		///   identificatore (ossia un operando). Una costante è considerata un operando.
		/// </summary>
		public void CompileSingleExpression(int minlevel){
			string skipped;
			bool AllowData=true;
			int mark= SPB.GetMark();
			SPToken SPT = SPB.NextToken(out skipped);
			
			while (SPT.kind!=tokenkind.EOF){ //skipped è da aggiungere solo se SPT è accettato
				bool NextIsToRead=true;
				if ((SPT.kind == tokenkind.openbracket)&& AllowData){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					IncLevel();
					CompileExpressions(minlevel);
					AllowData=false;
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					continue;
				}
				if (IsOperator(SPT)){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					AllowData=true;
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					continue;
				}

			         
				if ((
						(SPT.kind== tokenkind.identifier)||
						(SPT.kind==tokenkind.constant)||
						(SPT.val.ToLower()=="null")||
						((SPT.kind==tokenkind.keyword)&&(SPBridge.IsStandardFunction(SPT.val)))
					)
					&& AllowData){
					compiled.Append(skipped);
					if (SPT.kind==tokenkind.constant){
						compiled.Append(SPT.val);
						mark= SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
						continue;
					}
					mark= SPB.GetMark();
					SPToken SPTNext = SPB.NextToken(out skipped);
					if (SPTNext.kind== tokenkind.openbracket){
						compiled.Append(SPT.val);
						compiled.Append(skipped);
						compiled.Append(SPTNext.val);
						IncLevel();
						CompileExpressions(minlevel);
						AllowData=false;
					}
					else {
						compiled.Append( CompileColumnName(SPT.val,minlevel));
						SPT = SPTNext;
						NextIsToRead=false;
						AllowData=false;
					}
					if (NextIsToRead){
						mark= SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
					}
					continue;		
				}
				if ((SPT.val.ToLower()=="case")&& AllowData){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					CompileCase();
					AllowData= false;
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					continue;
				}
				break;
			}
			SPB.GotoMark(mark);
		}



		/// <summary>
		/// Compila Expr [, Expr, Expr..]
		/// </summary>
		public void CompileExpressionList(){
			SPToken SPT;
			string skipped;
			CompileSingleExpression();
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			while (SPT.val==","){
				compiled.Append( skipped);
				compiled.Append( SPT.val);
				CompileSingleExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			SPB.GotoMark(mark);
		}
		/// <summary>
		///  Assume la parentesi tonda aperta di derived_table già letta 
		///    derived_table [ AS ] table_alias [ ( column_alias [ ,...n ] ) ] 
		/// </summary>
		public void CompileTableSourceSubQuery(){
			string skipped;
			SPToken SPT;
			IncLevel();
			CompileExpressions();
			//Salta l'eventuale [AS] 
			SPT = SPB.NextToken(out skipped);
			compiled.Append(skipped);
			if (SPT.val.ToLower()=="as"){
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
			}
			//Ora in SPT c'è il table_alias, che non va tradotto!
			string AliasTableName=Alias.AliasPrefix+SPT.val;
			TablesAlias.AddAlias(AliasTableName,SPT.val);
			compiled.Append(SPT.val);
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if (SPT.kind != tokenkind.openbracket){
				//Non segue la lista dei column alias
				SPB.GotoMark(mark);
				return;
			}
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			//Segue la lista dei column alias, che vanno aggiunti agli alias di colonna correnti,
			// cosi da non essere confusi con altri nomi di colonna generici
			while (true){
				//Prende il primo column alias
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				ColumnsAlias.AddAlias(Alias.AliasPrefix+SPT.val.ToLower(),SPT.val.ToLower());
				compiled.Append(SPT.val);
				//Prende il primo column alias
				SPT = SPB.NextToken(out skipped); //prende la virgola o la parentesi tonda chiusa
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				if (SPT.kind== tokenkind.closebracket) return;
			}
		}


		/*
SELECT statement ::= 
    < query_expression > 
    [ ORDER BY { order_by_expression | column_position [ ASC | DESC ] } 
        [ ,...n ]    ] 
    [ COMPUTE 
        { { AVG | COUNT | MAX | MIN | SUM } ( expression ) } [ ,...n ] 
        [ BY expression [ ,...n ] ] 
    ] 
    [ FOR { BROWSE | XML { RAW | AUTO | EXPLICIT } 
            [ , XMLDATA ] 
            [ , ELEMENTS ]
            [ , BINARY base64 ]
        } 
    ] 
    [ OPTION ( < query_hint > [ ,...n ]) ] 

< query expression > ::= 
    { < query specification > | ( < query expression > ) } 
    [ UNION [ ALL ] < query specification | ( < query expression > ) [...n ] ] 

< query specification > ::= 
    SELECT [ ALL | DISTINCT ] 
        [ { TOP integer | TOP integer PERCENT } [ WITH TIES ] ] 
        < select_list > 
    [ INTO new_table ] 
    [ FROM { < table_source > } [ ,...n ] ] 
    [ WHERE < search_condition > ] 
    [ GROUP BY [ ALL ] group_by_expression [ ,...n ] 
        [ WITH { CUBE | ROLLUP } ]
    ]
    [ HAVING < search_condition > ] 
*/
		/// <summary>
		/// Assume SELECT già letto
		/// </summary>
		public void CompileSelect(){
			string skipped;
			SPToken SPT;
			//compiled.Append("\n\r");
			//compiled.Append("--SELECT\n\r");

			IncLevel();
			CompileQueryExpression();
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if (SPT.val.ToLower()=="order"){
				SPB.GotoMark(mark);
				CompileOrderBy();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			if (SPT.val.ToLower()=="compute"){
				SPB.GotoMark(mark);
				CompileCompute();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			if (SPT.val.ToLower()=="for"){
				SPB.GotoMark(mark);
				CompileForBrowseXml();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			if (SPT.val.ToLower()=="option"){
				SPB.GotoMark(mark);
				CompileOption();
				mark = SPB.GetMark();
			}
			SPB.GotoMark(mark);
			DecLevel();
			//compiled.Append("\n\r");
			//compiled.Append("--END SELECT\n\r");

		}

		/// <summary>
		///     [ ORDER BY { order_by_expression | column_position [ ASC | DESC ] } 
		///			[ ,...n ]    ] 
		/// </summary>
		public void CompileOrderBy(){
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped); //prende ORDER
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			SPT = SPB.NextToken(out skipped); //prende BY
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			while (true){ 
				CompileSingleExpression();
				int mark= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if ((SPT.val.ToLower()=="asc")||(SPT.val.ToLower()=="desc")){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
				if (SPT.val!= ","){
					SPB.GotoMark(mark);
					return;
				}
				compiled.Append(skipped);
				compiled.Append(SPT.val); //mette la virgola
				/*
				
				//Prende order_by_expression o column_position
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				if (SPT.kind== tokenkind.identifier){
					compiled.Append(CompileColumnName( SPT.val));
				}
				else {
					compiled.Append(SPT.val);
				}
				int mark= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if ((SPT.val.ToLower()=="asc")||(SPT.val.ToLower()=="desc")){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark= SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
				if (SPT.val!= ","){
					SPB.GotoMark(mark);
					return;
				}
				compiled.Append(skipped);
				compiled.Append(SPT.val); //mette la virgola
				
				*/

			}

		} 

		
		/// <summary>
		///     [ COMPUTE 
		///      { AVG | COUNT | MAX | MIN | SUM } ( expression ) } [ ,...n ] 
		///      [ BY expression [ ,...n ] ] 
		///     ] 
		/// </summary>
		public void CompileCompute(){
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped); //prende COMPUTE
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped); //prende AVG|... o ( o BY
			if ((SPT.val.ToLower()!="by") && (SPT.kind!=tokenkind.openbracket)){ 
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				//se ha preso AVG|... prende qualcos'altro
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped); //prende ( o BY
			}
			if (SPT.kind== tokenkind.openbracket){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				IncLevel();
				CompileExpressions();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped); //prende BY
				compiled.Append(skipped);
				compiled.Append(SPT.val);
			}
			if (SPT.val.ToLower()=="by"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileExpressionList();
				mark = SPB.GetMark();
			}
			SPB.GotoMark(mark);

		}

		
		/// <summary>
		///     [ FOR { BROWSE | XML { RAW | AUTO | EXPLICIT } 
		///				[ , XMLDATA ] 
		///				[ , ELEMENTS ]
		///				[ , BINARY base64 ]
		///			  } 
		///     ] 

		/// </summary>
		public void CompileForBrowseXml(){
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped); //prende FOR
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped); //prende BROWSE|XML
			if ( (SPT.val.ToLower()!="browse")&&(SPT.val.ToLower()!="xml")){
				SPB.GotoMark(mark);
				return;
			}
			compiled.Append(skipped);  //mette browse/xml
			compiled.Append(SPT.val);
			mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped); //prende RAW | AUTO | EXPLICIT
			if ((SPT.val.ToLower()=="raw") ||(SPT.val.ToLower()=="auto")||(SPT.val.ToLower()=="explicit")){
				compiled.Append(skipped); //mette RAW | AUTO | EXPLICIT
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped); //prende RAW | AUTO | EXPLICIT
			}
			while ((SPT.val.ToLower()=="xmldata")||(SPT.val.ToLower()=="elements")||
				(SPT.val.ToLower()=="binary")){
				compiled.Append(skipped); //mette RAW | AUTO | EXPLICIT
				compiled.Append(SPT.val);
				if (SPT.val.ToLower()=="binary"){
					SPT = SPB.NextToken(out skipped); //prende base64
					compiled.Append(skipped); //mette RAW | AUTO | EXPLICIT
					compiled.Append(SPT.val);
				}
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped); //prende ,
				if (SPT.val==","){
					compiled.Append(skipped); //mette ,
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped); //prende il successivo
				}
			}
			SPB.GotoMark(mark);
		}

		
		/// <summary>
		///     [ OPTION ( < query_hint > [ ,...n ]) ] 
		/// </summary>
		public void CompileOption(){
			string skipped;
			SPToken SPT = SPB.NextToken(out skipped); //prende OPTION
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			SPT = SPB.NextToken(out skipped); //prende (
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			IncLevel();
			CompileExpressions();
		}

		
	
		///		EXEC[UTE]
		///		  [@var =]
		///		  SP_name | SP_name_var
		///		    [ [ @parameter = ]  value | @variable [ OUTPUT ] | [ DEFAULT ] ] {, ...}
		///		[ WITH RECOMPILE ] 
		///		EXEC[UTE](....)
		public void CompileExecute(){
			string skipped;
			SPToken SPT =SPB.NextToken(out skipped); //prende @var o SP_name o SP_name_var o (
			compiled.Append(skipped);
			if (SPT.kind==tokenkind.openbracket){ //EXEC(.....)
				compiled.Append(SPT.val);
				IncLevel();
				CompileExpressions();
				return;
			}
			int mark = SPB.GetMark();
			SPToken SPTNext= SPB.NextToken(out skipped);
			if (SPTNext.val=="="){ //era @var =
				compiled.Append(CompileTempVar(SPT.val));
				compiled.Append(skipped);
				compiled.Append(SPTNext.val) ; //mette '='
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
			}
			else {
				SPB.GotoMark(mark);
			}
			//Ora in SPT c'è SP_name o SP_name_var
			compiled.Append(CompileProcedureName(SPT.val));

			//Ora c'è una (eventuale) serie di [ @parameter = ]  value | @variable [ OUTPUT ] | [ DEFAULT ]
			mark=SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if ((SPT.kind== tokenkind.constant)||(SPT.val.StartsWith("@"))){
				//inizia la serie
				while (true){
					compiled.Append(skipped);
					
					mark= SPB.GetMark();
					SPTNext = SPB.NextToken(out skipped); 
					if (SPTNext.val=="="){
						//era @parameter=
						compiled.Append(CompileParamName(SPT.val));
						compiled.Append(skipped);
						compiled.Append(SPTNext.val); //mette =
						SPT = SPB.NextToken(out skipped);
						compiled.Append(skipped);
					}
					else {
						//era value || variable
						SPB.GotoMark(mark);
					}
					//in SPT = value || variable || DEFAULT
					if (SPT.kind== tokenkind.identifier){
						compiled.Append(CompileColumnName(SPT.val));
					}
					else {
						compiled.Append(SPT.val);
					}
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
					//salta evenuale OUTPUT
					if (SPT.val.ToLower()=="output"){
						compiled.Append(skipped);
						compiled.Append(SPT.val);
						mark=SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
					}
					//Ora o virgola oppure esce dalla serie
					if (SPT.val!=","){
						break;
					}
					compiled.Append(skipped);
					compiled.Append(SPT.val);//mette la virgola
					SPT = SPB.NextToken(out skipped);
				}
			}

			///		salta eventuale WITH RECOMPILE  
			if (SPT.val.ToLower()=="with"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				mark= SPB.GetMark();
			}

			SPB.GotoMark(mark);
		}

		/// <summary>
		/// 		< query expression > ::= { 
		/// 		< query specification > | ( < query expression > ) } 
		/// 		[ UNION [ ALL ] < query specification | ( < query expression > ) [...n ] ] 
		/// Assume SELECT già letto
		/// </summary>
		public void CompileQueryExpression(){
			string skipped;
			SPToken SPT;
			CompileQuerySpecification();
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if (SPT.val.ToLower()=="union"){
				//mette union
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				//salta l'eventuale "all"
				if (SPT.val.ToLower()=="all"){
					//mette all
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
				}
				SPB.GotoMark(mark);
				SPT = SPB.NextToken(out skipped); 
				compiled.Append(skipped);
				compiled.Append(SPT.val);  //lo mette poiché CompileQueryExpression lo assume già letto
				CompileQueryExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);				
			}
			SPB.GotoMark(mark);
		}

		/// <summary>
		///    SELECT [ ALL | DISTINCT ] 
		///           [ { TOP integer | TOP integer PERCENT } [ WITH TIES ] ] 
		///     < select_list > 
		///    [ INTO new_table ] 
		///    [ FROM { < table_source > } [ ,...n ] ] 
		///    [ WHERE < search_condition > ] 
		///    [  GROUP BY [ ALL ] group_by_expression [ ,...n ] 
		///        [ WITH { CUBE | ROLLUP } ]
		///    ]
		///    [ HAVING < search_condition > ] 
		///    Assume SELECT già letto
		/// </summary>
		public void CompileQuerySpecification(){
			string skipped;
			SPToken SPT;
			//Salta ALL|DISTINCT
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if ((SPT.val.ToLower()=="all")||(SPT.val.ToLower()=="distinct")){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			//Salta [ { TOP integer | TOP integer PERCENT } [ WITH TIES ] ] 
			if (SPT.val.ToLower()=="top"){
				compiled.Append(skipped);  //mette top
				compiled.Append(SPT.val);
				//Salta integer
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);  //mette integer
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				//salta PERCENT ove presente
				if (SPT.val.ToLower()=="percent"){
					compiled.Append(skipped);  //mette integer
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
				//salta WITH TIES ove presente
				if (SPT.val.ToLower()=="with "){
					compiled.Append(skipped);  //mette with
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped);
					compiled.Append(skipped);  //mette ties
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
			} //salta top

			SPB.GotoMark(mark);
			int LenBeforeCompileSelect = compiled.Length;
			int markOfSelectList = SPB.GetMark();
			CompileSelectList(0);
			int LenAfterCompileSelect = compiled.Length;
			
			mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			if (SPT.val.ToLower()=="into"){
				compiled.Append(skipped);  //mette into
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);  //mette newtable
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			int currlevel = TablesAlias.AliasList.Count;
			//Mette From
			if (SPT.val.ToLower()=="from"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileFrom();
				mark = SPB.GetMark();
			}
			SPB.GotoMark(mark);

			int markAfterFrom = mark;

			//Ora prende la parte di compiled dopo Len
			string CompiledAfterSelectList= compiled.ToString().Substring(LenAfterCompileSelect);

			//Ora tronca compiled per eliminare tutto quello che aveva fatto da CompileSelect
			compiled.Length= LenBeforeCompileSelect;
			//Ricompila la Select List
			SPB.GotoMark(markOfSelectList);
			CompileSelectList(currlevel);

			//ri-appende quello che aveva compilato prima
			compiled.Append(CompiledAfterSelectList);

			SPB.GotoMark(markAfterFrom);

			//Prosegue allegramente con il resto della select
			mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);

			//compila la parte where se presente
			if (SPT.val.ToLower()=="where"){
				compiled.Append(skipped);  //mette where
				compiled.Append(SPT.val);
				CompileSingleExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			//    [  GROUP BY [ ALL ] group_by_expression [ ,...n ] 
			//        [ WITH { CUBE | ROLLUP } ]
			//Compila la parte group by
			if (SPT.val.ToLower()=="group"){
				compiled.Append(skipped);  //mette group
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);  //mette by
				compiled.Append(SPT.val);
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				//salta ALL se presente
				if (SPT.val.ToLower()=="all"){
					compiled.Append(skipped);  //mette all
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
				}
				SPB.GotoMark(mark);
				CompileExpressionList();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				//salta [ WITH { CUBE | ROLLUP } ]
				if (SPT.val.ToLower()=="with"){
					compiled.Append(skipped);  //mette group
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped);
					compiled.Append(skipped);  //mette CUBE o ROLLUP
					compiled.Append(SPT.val);
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
			}

			//salta HAVING...
			//    [ HAVING < search_condition > ] 

			if (SPT.val.ToLower()=="having"){
				compiled.Append(skipped);  //mette having
				compiled.Append(SPT.val);  
				CompileSingleExpression();
				mark = SPB.GetMark();
			}

			SPB.GotoMark(mark);
		}


		/// <summary>
		/// <select list> ::= expression [[AS] identifier] {,<select list>}
		/// </summary>
		public void CompileSelectList(int minlevel){
			string skipped;
			SPToken SPT;
			while (true){
				bool VarEqual=false;
				string VarFound="";
				//salta eventuale @var  = 
				int mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if ((SPT.kind==tokenkind.identifier)||(SPT.kind==tokenkind.constant)){
					string skipped2;
					SPToken SPTNext= SPB.NextToken(out skipped2);
					if (SPTNext.val=="="){
						VarEqual=true;
						compiled.Append(skipped);
						if (SPT.kind==tokenkind.identifier)
							compiled.Append(CompileColumnName(SPT.val));
						else
							compiled.Append(SPT.val); //non compila le costanti

						compiled.Append(skipped2);
						compiled.Append(SPTNext.val);
						VarFound= CompileColumnName(SPT.val,minlevel);
						VarEqual=true;
					}
					else {
						SPB.GotoMark(mark);
					}
				}
				else {
					SPB.GotoMark(mark);
				}

				CompileSingleExpression(minlevel);
				mark = SPB.GetMark();

				if (!VarEqual){
					//Salta l'[AS identifier] ove presente
					SPT = SPB.NextToken(out skipped);
					if (SPT.val.ToLower()=="as"){
						compiled.Append(skipped);
						compiled.Append(SPT.val);
						mark = SPB.GetMark();
						SPT = SPB.NextToken(out skipped);
					}

					if (SPT.kind==tokenkind.identifier) {
						//salta identifier
						if (InsideCreateView && TablesAlias.AliasList.Count<=2){
							compiled.Append(skipped);
							string newcol= Columns[MainViewTable+"."+SPT.val] as string;
							if (newcol==null) newcol=SPT.val;
							compiled.Append(newcol);
							ColumnsAlias.AddAlias(MainViewTable, SPT.val);
							mark = SPB.GetMark();
							SPT = SPB.NextToken(out skipped);
						}
						else {
							compiled.Append(skipped);
							compiled.Append(SPT.val);
							ColumnsAlias.AddAlias("no table", SPT.val);

							mark = SPB.GetMark();
							SPT = SPB.NextToken(out skipped);
						}
					}
					else {
						if (SPT.kind== tokenkind.constant){
							compiled.Append(skipped);
							compiled.Append(SPT.val);
							mark = SPB.GetMark();
							SPT = SPB.NextToken(out skipped);
						}
					}
				}
				else {
					SPT = SPB.NextToken(out skipped);
					ColumnsAlias.AddAlias("no table", VarFound);
				}
				

				if (SPT.val != ","){
					SPB.GotoMark(mark);
					break;
				}
				compiled.Append(skipped);
				compiled.Append(SPT.val);
			}
		}


		/// <summary>
		/// UPDATE 
		///     { 
		///            table_name WITH ( < table_hint_limited > [ ...n ] ) 
		///							| view_name 
		///							| rowset_function_limited 
		///	     }
		/// SET
		///         { column_name = { expression | DEFAULT | NULL } 
		///		      | @variable = expression
		///		      | @variable = column = expression } [ ,...n ] 
		///	{ { [ FROM { < table_source > } [ ,...n ] ] 
		///		[ WHERE 
		///			< search_condition > ] } 
		///		| 
		///		[ WHERE CURRENT OF 
		///			 { { [ GLOBAL ] cursor_name } | cursor_variable_name } 
		///	    ] } 
		///	[ OPTION ( < query_hint > [ ,...n ] ) ] 
		/// 
		///  < table_hint_limited > ::= 
		///  {    FASTFIRSTROW 
		///      | HOLDLOCK 
		///      | PAGLOCK 
		///      | READCOMMITTED 
		///      | REPEATABLEREAD 
		///      | ROWLOCK 
		///      | SERIALIZABLE 
		///      | TABLOCK 
		///      | TABLOCKX 
		///      | UPDLOCK 
		///   } 
		///   < table_hint > ::= 
		///    {    INDEX ( index_val [ ,...n ] ) 
		///        | FASTFIRSTROW 
		///        | HOLDLOCK 
		///        | NOLOCK 
		///        | PAGLOCK 
		///        | READCOMMITTED 
		///        | READPAST 
		///        | READUNCOMMITTED 
		///        | REPEATABLEREAD 
		///        | ROWLOCK 
		///        | SERIALIZABLE 
		///        | TABLOCK 
		///        | TABLOCKX 
		///        | UPDLOCK 
		///    }
		///  < query_hint > ::= 
		///      {    { HASH | ORDER } GROUP 
		///          | { CONCAT | HASH | MERGE } UNION 
		///          | {LOOP | MERGE | HASH } JOIN 
		///          | FAST number_rows 
		///          | FORCE ORDER 
		///          | MAXDOP 
		///          | ROBUST PLAN 
		///          | KEEP PLAN 
		///     } 

		/// </summary>
		public void CompileUpdate(){
			//compiled.Append("\n\r");
			//compiled.Append("--UPDATE\n\r");
			IncLevel();
			SPToken SPT;
			string skipped;
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);

			if (SPT.kind==tokenkind.openbracket){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				IncLevel();
				CompileExpressions();
				return;
			}
			//     { 
			//            table_name WITH ( < table_hint_limited > [ ...n ] ) 
			//							| view_name 
			//							| rowset_function_limited 
			//	     }
			string maintable=null;
			if (SPT.val.ToString().ToLower()!= "set"){
	
				compiled.Append(skipped);
				maintable= GetSimpleTableName(SPT.val);
				TablesAlias.AddAlias(maintable,maintable);
				compiled.Append(CompileTableName(SPT.val));

				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);

				//salta eventuale chiamata a funzione
				if (SPT.kind == tokenkind.openbracket){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					IncLevel();
					CompileExpressions();
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}


				//salta eventuale WITH
				if (SPT.val.ToLower()=="with"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);

					SPT = SPB.NextToken(out skipped);//prende la parentesi tonda aperta
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					IncLevel();
					CompileExpressions();
					mark = SPB.GetMark();
					SPT = SPB.NextToken(out skipped);
				}
			}

			/// SET
			///         { column_name = { expression | DEFAULT | NULL } 
			///		      | @variable = expression
			///		      | @variable = column = expression } [ ,...n ] 
			
			if (SPT.val.ToLower()!="set"){
				QueryCreator.ShowError(null,"Atteso SET ",compiled.ToString());
			}
			compiled.Append(skipped);
			compiled.Append(SPT.val);

			int LenBeforeCompileSelect = compiled.Length;
			int markOfSelectList = SPB.GetMark();
			CompileAssignList(maintable);  // var=expr ,...
			int LenAfterCompileSelect = compiled.Length;

			//	{ { [ FROM { < table_source > } [ ,...n ] ] 
			//		[ WHERE 
			//			< search_condition > ] } 
			//		| 
			///		[ WHERE CURRENT OF 
			///			 { { [ GLOBAL ] cursor_name } | cursor_variable_name } 
			///	    ] } 
			mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);

			if (SPT.val.ToLower()=="from"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileFrom();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			int markAfterFrom = SPB.GetMark();

			//Ora prende la parte di compiled dopo Len
			string CompiledAfterSelectList= compiled.ToString().Substring(LenAfterCompileSelect);

			//Ora tronca compiled per eliminare tutto quello che aveva fatto da CompileSelect
			compiled.Length= LenBeforeCompileSelect;
			//Ricompila la Select List
			SPB.GotoMark(markOfSelectList);
			string unaliasedmainTable = TablesAlias.Unalias(maintable);
			CompileAssignList(unaliasedmainTable);

			//ri-appende quello che aveva compilato prima
			compiled.Append(CompiledAfterSelectList);

			SPB.GotoMark(markAfterFrom);

			if(SPT.val.ToLower()=="where"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				int mark2= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if (SPT.val.ToLower()=="current"){
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped); //of
					compiled.Append(skipped);
					compiled.Append(SPT.val);
					SPT = SPB.NextToken(out skipped); //of
					compiled.Append(skipped);
					compiled.Append(SPT.val);  //GLOBAL o identifier
					if (SPT.val.ToLower()=="global"){
						SPT = SPB.NextToken(out skipped); 
						compiled.Append(skipped);
						compiled.Append(SPT.val);  //identifier
					}
				}
				else {
					SPB.GotoMark(mark2);
					CompileSingleExpression();
				}
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}

			//	[ OPTION ( < query_hint > [ ,...n ] ) ] 
			if (SPT.val.ToLower()=="option"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped);  // (
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				IncLevel();
				CompileExpressions();
				mark = SPB.GetMark();
			}
			SPB.GotoMark(mark);
			//compiled.Append("\n\r");
			//compiled.Append("--END UPDATE\n\r");
			DecLevel();

		}

		void CompileAssignList(string maintable){
			string skipped;
			SPToken SPT;
			while (true){
				//Prende column_name o varname
				SPT = SPB.NextToken(out skipped);
				//si assume SPT un identificatore o nome variabile
				compiled.Append(skipped);

				string trycol = maintable+"."+SPT.val.ToLower();
				if (Columns[trycol]!=null){
					compiled.Append( Columns[trycol].ToString());
				}
				else {
					if (SPT.val.ToLower().StartsWith("@")){
						compiled.Append(CompileTempVar(SPT.val.ToLower()));
					}
					else {
						compiled.Append(SPT.val.ToLower());
					}

					//compiled.Append( CompileColumnName(SPT.val));
				}

				//Prende =
				SPT = SPB.NextToken(out skipped);
				compiled.Append(skipped);
				compiled.Append(SPT.val);

				//Prende Expression
				CompileSingleExpression();

				int mark= SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
				if (SPT.val!=","){
					SPB.GotoMark(mark);
					break;
				}
				//mette la virgola e continua la lista di assegnazioni
				compiled.Append(skipped);
				compiled.Append(SPT.val);	
			}

		}
		/*
		CASE input_expression 
			WHEN when_expression THEN result_expression 
									 [ ...n ] 
									 [ 
		ELSE else_result_expression 
										 ] 
		END 

			Searched CASE function:

		CASE
			WHEN Boolean_expression THEN result_expression 
											 [ ...n ] 
		[ 
		ELSE else_result_expression 
			] 
		END
		*/
		public void CompileCase(){
			string skipped;
			SPToken SPT;
			int mark = SPB.GetMark();
			SPT = SPB.NextToken(out skipped);
			//se non è when o end allora deve essere input expression, che va compilata a parte
			if ((SPT.val.ToLower()!="when") && (SPT.val.ToLower()!="end")&& (SPT.val.ToLower()!="else")){
				SPB.GotoMark(mark);
				CompileSingleExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			//Ora attende una serie di WHEN expression then expression
			while (SPT.val.ToLower()=="when"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileSingleExpression();
				SPT = SPB.NextToken(out skipped);  //prende THEN
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				if (SPT.val.ToLower()!="then")
					QueryCreator.ShowError(null,"Atteso THEN",compiled.ToString());
				CompileSingleExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			//Salta else espressione se presente
			if (SPT.val.ToLower()=="else"){
				compiled.Append(skipped);
				compiled.Append(SPT.val);
				CompileSingleExpression();
				mark = SPB.GetMark();
				SPT = SPB.NextToken(out skipped);
			}
			if (SPT.val.ToLower()!="end")
				QueryCreator.ShowError(null,"Atteso END",compiled.ToString());
			compiled.Append(skipped);
			compiled.Append(SPT.val);			
		}


/*
	<table element> ::=
      <column definition>
    | <table constraint definition>
 
<column definition> ::=
    <column name> { <data type> | <domain name> }
    [  DEFAULT <default option> ]
    [ <column constraint definition>... ]
    [ <collate clause> ]


<default option> ::=
      <literal>
    | <datetime value function>
    | USER
    | CURRENT_USER
    | SESSION_USER
    | SYSTEM_USER
    | NULL

<column constraint definition> ::=
    [ CONSTRAINT <constraint name> ]
    <column constraint>
      [ <constraint attributes> ]

<constraint name> ::= <qualified name>

<column constraint> ::=
      NOT NULL
    | UNIQUE | PRIMARY KEY
    | REFERENCES <referenced table and columns>   [ MATCH <match type> ]   [ <referential triggered action> ]
    | CHECK <left paren> <search condition> <right paren>

        

<referenced table and columns> ::=
     <table name> [ <left paren> <reference column list> <right paren> ]
    
        
<match type> ::=
      FULL
    | PARTIAL

<referential triggered action> ::=
      ON UPDATE <referential action> [ ON DELETE <referential action> ]
    | ON DELETE <referential action> [ ON UPDATE <referential action> ]


<referential action> ::=
      CASCADE
    | SET NULL
    | SET DEFAULT
    | NO ACTION

<constraint attributes> ::=
      <constraint check time> [ [ NOT ] DEFERRABLE ]
    | [ NOT ] DEFERRABLE [ <constraint check time> ]

<constraint check time> ::=
      INITIALLY DEFERRED
    | INITIALLY IMMEDIATE
*/


/*
		CREATE TABLE 
			[ database_name.[ owner ] . | owner. ] table_name 
			   ( { < column_definition > 
				 | column_name AS computed_column_expression 
			  | < table_constraint > ::= [ CONSTRAINT constraint_name ] }

		| [ { PRIMARY KEY | UNIQUE } [ ,...n ] 
	) 
	
< column_definition > ::= { column_name data_type } 
    [ COLLATE < collation_name > ] 
    [ [ DEFAULT constant_expression ] 
        | [ IDENTITY [ ( seed , increment ) [ NOT FOR REPLICATION ] ] ]
    ] 
    [ ROWGUIDCOL] 
    [ < column_constraint > ] [ ...n ] 

< column_constraint > ::= [ CONSTRAINT constraint_name ] 
    { [ NULL | NOT NULL ] 
        | [ { PRIMARY KEY | UNIQUE } 
            [ CLUSTERED | NONCLUSTERED ] 
            [ WITH FILLFACTOR = fillfactor ] 
            [ON {filegroup | DEFAULT} ] ] 
        ] 
        | [ [ FOREIGN KEY ] 
            REFERENCES ref_table [ ( ref_column ) ] 
            [ ON DELETE { CASCADE | NO ACTION } ] 
            [ ON UPDATE { CASCADE | NO ACTION } ] 
            [ NOT FOR REPLICATION ] 
        ] 
        | CHECK [ NOT FOR REPLICATION ] 
        ( logical_expression ) 
    } 

< table_constraint > ::= [ CONSTRAINT constraint_name ] 
    { [ { PRIMARY KEY | UNIQUE } 
        [ CLUSTERED | NONCLUSTERED ] 
        { ( column [ ASC | DESC ] [ ,...n ] ) } 
        [ WITH FILLFACTOR = fillfactor ] 
        [ ON { filegroup | DEFAULT } ] 
    ] 
    | FOREIGN KEY 
        [ ( column [ ,...n ] ) ] 
        REFERENCES ref_table [ ( ref_column [ ,...n ] ) ] 
        [ ON DELETE { CASCADE | NO ACTION } ] 
        [ ON UPDATE { CASCADE | NO ACTION } ] 
        [ NOT FOR REPLICATION ] 
    | CHECK [ NOT FOR REPLICATION ] 
        ( search_conditions ) 
    } 


*/

		public void CompileCreateTable(){
			string skipped;
			SPToken SPT;

			//prende tablename
			SPT= SPB.NextToken(out skipped);
			compiled.Append(skipped);
			compiled.Append(CompileTableName(SPT.val));  //lo compila
			string maintable = GetSimpleTableName(SPT.val);

			TablesAlias.AddAlias(maintable,maintable); //Alias nel livello corrente

			SPT = SPB.NextToken(out skipped); //prende  ( e la mette
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			if (SPT.val!="("){
				QueryCreator.ShowError(null,"Attesa ( in CREATE TABLE",compiled.ToString());
			}
			IncLevel();
			CompileExpressions();
			
		}

/*
	< column_definition > ::= { column_name data_type } 
	[ COLLATE < collation_name > ] 
	[ [ DEFAULT constant_expression ] 
	| [ IDENTITY [ ( seed , increment ) [ NOT FOR REPLICATION ] ] ]
	] 
	[ ROWGUIDCOL] 
	[ < column_constraint > ] [ ...n ] 
*/

/*
CREATE TRIGGER trigger_name 
ON { table | view } 
[ WITH ENCRYPTION ] 
{ 
    { { FOR | AFTER | INSTEAD OF } { [ INSERT ] [ , ] [ UPDATE ] } 
        [ WITH APPEND ] 
        [ NOT FOR REPLICATION ] 
        AS 
        [ { IF UPDATE ( column ) 
            [ { AND | OR } UPDATE ( column ) ] 
                [ ...n] 
        | IF ( COLUMNS_UPDATED ( ) { bitwise_operator } updated_bitmask ) 
                { comparison_operator } column_bitmask [ ...n ] 
        } ] 
        sql_statement [ ...n ] 
    } 
} 
*/
		public void CompileCreateTrigger(){
			string skipped;
			SPToken SPT;
			SPT = SPB.NextToken(out skipped); //trigger name
			compiled.Append(skipped);
			compiled.Append(CompileProcedureName( SPT.val));
			SPT = SPB.NextToken(out skipped); //ON
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			SPT = SPB.NextToken(out skipped); //table
			compiled.Append(skipped);
			string maintable= GetSimpleTableName(SPT.val);
			TablesAlias.AddAlias(maintable,maintable);
			TablesAlias.AddAlias(maintable,"inserted");
			TablesAlias.AddAlias(maintable,"deleted");
			compiled.Append(CompileTableName(SPT.val));
			SPT = SPB.NextToken(out skipped); //AS
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			while (SPT.val.ToLower()!="as"){
				SPT = SPB.NextToken(out skipped); //AS
				compiled.Append(skipped);
				compiled.Append(SPT.val);
			}
			IncLevel();
			CompileExpressions();
		}

/*
		CREATE PROC [ EDURE ] procedure_name [ ; number ] 
		[ { @parameter data_type } 
			[ VARYING ] [ = default ] [ OUTPUT ] 
		] [ ,...n ] 

	[ WITH { 
      RECOMPILE | ENCRYPTION | RECOMPILE , ENCRYPTION } ] 

[ FOR REPLICATION ] 

AS sql_statement [ ...n ] 
*/

		public void CompileProcedure(){
			string skipped;
			SPToken SPT;
			SPT = SPB.NextToken(out skipped); //procedure_name 
			CurrParams = new Hashtable();
			compiled.Append(skipped);
			compiled.Append(CompileProcedureName( SPT.val));
			SPT = SPB.NextToken(out skipped); //ON
			compiled.Append(skipped);

			while (SPT.val.ToLower()!="as"){
				if (SPT.kind== tokenkind.identifier) {//compila @parameter datatype
					string newpar= CompileParamName(SPT.val);
					CurrParams[SPT.val.ToLower()]=newpar;
					compiled.Append(newpar);
					SPT = SPB.NextToken(out skipped); 
					compiled.Append(skipped);		
					while ((SPT.val!=",")&&(SPT.val.ToLower()!="as")){
						compiled.Append(SPT.val);
						SPT = SPB.NextToken(out skipped); 
						compiled.Append(skipped);		
					}
					continue;
				}
				//salta  WITH... e FOR REPLICATION vari
				compiled.Append(SPT.val);
				SPT = SPB.NextToken(out skipped); 
				compiled.Append(skipped);		
			}
			compiled.Append(SPT.val); // appende AS
			IncLevel();
			CompileExpressions();
			CurrParams= new Hashtable();
		}

		string CompileParamName(string par){
			if (Params[par.ToLower()]==null) return par;
			return Params[par.ToLower()].ToString();
		}


/*
CREATE VIEW [ < database_name > . ] [ < owner > . ] view_name [ ( column [ ,...n ] ) ] 
[ WITH < view_attribute > [ ,...n ] ] 
AS 
select_statement 
[ WITH CHECK OPTION ] 
*/		 

		bool InsideCreateView=false;
		string MainViewTable=null;
		public void CompileCreateView(){
			InsideCreateView=true;
			string skipped;
			SPToken SPT;
			SPT = SPB.NextToken(out skipped); //view_name
			compiled.Append(skipped);
			string maintable= GetSimpleTableName(SPT.val);
			MainViewTable=maintable;
			TablesAlias.AddAlias(maintable,maintable);
			compiled.Append(CompileTableName(SPT.val));
			IncLevel();
			CompileExpressions();
		}

		public void CompileCreate(){
			string skipped;
			SPToken SPT;
			SPT = SPB.NextToken(out skipped);
			compiled.Append(skipped);
			compiled.Append(SPT.val);
			if (SPT.val.ToLower()=="procedure"){
				CompileProcedure();
				return;
			}
			if (SPT.val.ToLower()=="table"){
				CompileCreateTable();
				return;
			}
			if (SPT.val.ToLower()=="trigger"){
				CompileCreateTrigger();
				return;
			}
			if (SPT.val.ToLower()=="view"){
				CompileCreateView();
				return;
			}
			return;
			
		}



		private static ArrayList DivideScript(string script){
			ArrayList CmdList= new ArrayList();
			StringReader Sread= new StringReader(script.ToString());
			string currline;
			StringBuilder Cmd=null;
			while ((currline = Sread.ReadLine())!=null){
				if (currline.TrimEnd().ToUpper()=="GO"){
					if (Cmd!=null) CmdList.Add(Cmd);
					Cmd=null;
					continue;
				}
				if (Cmd==null)
					Cmd = new StringBuilder(currline);
				else
					Cmd.Append("\n"+currline);
			}
			if (Cmd!=null && Cmd.ToString()!="") CmdList.Add(Cmd);
			return CmdList;
		}

		public static string Compile(DataAccess Conn, string spbody,Aliases StartTablesAlias){
			StringBuilder AllCompiled = new StringBuilder();
			StringReader Sread= new StringReader(spbody);
				
			string currline = Sread.ReadLine();
			string nextline = Sread.ReadLine();
			StringBuilder Cmd=null;
			while (currline!=null){
				if (nextline!=null)	currline+="\r\n";
				if (currline.TrimEnd().ToUpper()=="GO"){
					if (Cmd!=null) {
						DBBridge DBB = new DBBridge(Conn);
						DBB.Init(Cmd.ToString());
						if (StartTablesAlias!=null){
							DBB.TablesAlias= StartTablesAlias;
						}
						DBB.CompileExpressions();
						AllCompiled.Append(DBB.compiled);
						AllCompiled.Append(currline);
					}
					Cmd=null;
					currline= nextline;
					nextline=Sread.ReadLine();
					continue;
				}
				if (Cmd==null)
					Cmd = new StringBuilder(currline);
				else
					Cmd.Append(currline);
				currline= nextline;
				nextline= Sread.ReadLine();
			}

			if (Cmd!=null && Cmd.ToString()!="") {
				DBBridge DBB = new DBBridge(Conn);
				DBB.Init(Cmd.ToString());
				if (StartTablesAlias!=null){
					DBB.TablesAlias= StartTablesAlias;
				}
				DBB.CompileExpressions();
				AllCompiled.Append(DBB.compiled);
			}
			return AllCompiled.ToString();
		}
		
	}

	public enum tokenkind {constant,keyword,identifier,punctuator,separator,openbracket,closebracket,unknown,EOF};

	public class SPToken{	
		public tokenkind kind;
		public string val;
		public SPToken(tokenkind kind, string val){
			this.kind= kind;
			this.val=val;
		}
	}



	public class SPBridge {
		public static bool IsStandardFunction(string identifier){
			string []stdfun= new string[]{
				"avg","binary_cheksum","checksum_agg","count","count_big","exists","grouping","max","min","sum",
						"stddev","stdevp","var","varp",
				"ascii","char","charindex","difference","left","len","lower","ltrim","nchar","patindex","replace",
						"quotename","replicate","reverse","right","rtrim","soundex","space","str","stuff",
						"substring","unicode","upper",
				"cast","convert","coalesce","datalength","formatmessage","getansinull","host_id","host_name",
					"ident_current","ident_incr","ident_seed","identity","isdate","isnull","isnumeric",
					 "newid","nullif","parsename","permissions","rowcount_big","serverproperty","sessionproperty",
					 "session_user","stats_date","system_user","user_name",
				"cursor_status",
				"dateadd","datediff","datename","datepart","day","getdate","getutcdate","month","year",
				"abs","acos","asin","atan","atn2","ceiling","cos","cot","degrees","exp","floor",
					"log","log10","pi","power","radians","rand","round","sign","sin","square","sqrt","tan",
				"col_length","col_name","columnproperty","databaseproperty","databasepropertyex",
					"fulltextcatalogproperty","fulltextserviceproperty","index_col","indexkey_property",
					"indexproperty","object_id","object_name","objectproperty","sql_variant_property","typeproperty",
				"openquery","openrowset","opendatasource","openxml"
										 };
			string id= identifier.ToLower();
			foreach (string s in stdfun){
				if (s==id) return true;
			}
			return false;
		}
		protected int currpos;
		protected int len;
		protected string spbody;
		Hashtable keywords;
		public SPBridge(string spbody){
			currpos=0;
			this.spbody=spbody;
			if (spbody==null) this.spbody="";
			len=this.spbody.Length;
			keywords= new Hashtable();
			DataSet D = new DataSet();
			D.ReadXml("system_SQLkeys.xml");
			foreach (DataRow R in D.Tables["sqlcmd"].Rows){
				keywords[R["cmd"].ToString()]="1";
			}
		}

		protected virtual SPToken GetKeywordOrIdentifier(){
			string id=spbody[currpos].ToString();
			currpos++;
			while (currpos<len){
				if (Char.IsLetterOrDigit(spbody,currpos)||(spbody[currpos]=='@')
						||(spbody[currpos]=='_')||(spbody[currpos]=='#')||
						(spbody[currpos]=='.')||(spbody[currpos]=='[')||(spbody[currpos]==']')){
					id+=spbody[currpos];
					currpos++;
					continue;
				}
				break;
			}
			if (keywords[id.ToLower()]==null){
				return new SPToken(tokenkind.identifier, id);
			}
			else {
				return new SPToken(tokenkind.keyword, id);
			}
		}



		protected SPToken GetNumber(){
			string num= spbody[currpos].ToString();
			currpos++;
			bool dotwasfound=false;
			while (currpos<len){
				if (Char.IsDigit(spbody,currpos)){
					num+=spbody[currpos];
					currpos++;
					continue;
				}
				if (dotwasfound) break;
				if (spbody[currpos]!='.') break;
				num+=spbody[currpos];
				currpos++;
				dotwasfound=true;
			}
			return new SPToken(tokenkind.constant,num);
		}

		protected SPToken GetStringConstant(){
			string str= "'";
			while (currpos<len){
				if (spbody[currpos]!='\'') {
					str+=spbody[currpos];
					currpos++;
					continue;
				}
				if (currpos==len-1) {
					str+="'";
					currpos++;
					break;
				}
				if (spbody[currpos+1]=='\''){
					str+="''";
					currpos+=2;
					continue;
				}
				str+="'";
				currpos++;
				break;			
			}
			return new SPToken(tokenkind.constant, str);
		}

		/// <summary>
		/// Prende un token dalla posizione corrente
		/// </summary>
		/// <returns></returns>
		protected virtual SPToken GetToken(){
			if (currpos==len) return null;
			char C= spbody[currpos];
			if (Char.IsLetter(C)||(C=='@')||(C=='_')||(C=='#')||(C=='[')) return GetKeywordOrIdentifier();
			if (Char.IsDigit(C)) return GetNumber();
			currpos++;
			if (C=='\'') return GetStringConstant();
			if (C=='(') return new SPToken(tokenkind.openbracket, "(");
			if (C==')') return new SPToken(tokenkind.closebracket,")");
			if (C == '&'){
				int mark = GetMark();
				//controlla se è del tipo &<anything>&
				SPToken SPT2 = GetToken();
				if (SPT2.val=="<"){
					//allora prende qualsiasi cosa fino al prossimo &
					int nextperc= spbody.IndexOf("&", currpos);
					string ident = "&<"+spbody.Substring(currpos, nextperc-currpos+1);
					currpos= nextperc+1;
					return new SPToken(tokenkind.identifier, ident);
				}
				GotoMark(mark); //non era del tipo <%...			
			}
			if (C == '%'){
				int mark = GetMark();
				//controlla se è del tipo %<anything>%
				SPToken SPT2 = GetToken();
				if (SPT2.val=="<"){
					//allora prende qualsiasi cosa fino al prossimo &
					int nextperc= spbody.IndexOf("%", currpos);
					string ident = "%<"+spbody.Substring(currpos, nextperc-currpos+1);
					currpos= nextperc+1;
					return new SPToken(tokenkind.identifier, ident);
				}
				GotoMark(mark); //non era del tipo <%...			
			}
		
			if (Char.IsPunctuation(C)) return new SPToken(tokenkind.punctuator,C.ToString());
			if (Char.IsSeparator(C)) return new SPToken(tokenkind.separator,C.ToString());
			if (Char.IsSymbol(C)) return new SPToken(tokenkind.punctuator,C.ToString());
			QueryCreator.ShowError(null,"Unknown char found: "+C.ToString(),"");
			return new SPToken(tokenkind.unknown,C.ToString());
		}

		/// <summary>
		/// Prende il prossimo non-commento a partire da currpos(incluso)
		/// </summary>
		/// <returns></returns>
		private int NextNonComment(){
			int mypos=currpos;
			while(mypos<len){
				if ((mypos<len-1)&&(spbody.Substring(mypos,2)=="--")){
					int next1 = spbody.IndexOf("\n",mypos);
					int next2 = spbody.IndexOf("\r",mypos);
					if ((next1==-1)&&(next2==-1)) return len;
					if (next1==-1){
						mypos=next2+1;
						continue;
					}
					if (next2==-1){
						mypos=next1+1;
						continue;
					}
					if (next1<next2) 
						mypos=next1+1;
					else
						mypos=next2+1;
					continue;
				}
				if (spbody.Substring(mypos).StartsWith("/*")){
					int next= spbody.IndexOf("*/",mypos);
					if (next==-1) return len;
					mypos = next+2;
					continue;
				}
				return mypos;
			}
			return mypos;
		}


// FARE LA MODIFICA CHE FA ACCETTARE <%table.campo%> COME IDENTIFICATORE
		/// <summary>
		/// Prende il prossimo token dalla sp, restituendo ciò che ha saltato prima del token (spazi,commenti..)
		/// </summary>
		/// <param name="skipped"></param>
		/// <returns></returns>
		public SPToken NextToken(out string skipped){
			skipped="";
			int startpos=currpos;
			while (currpos < len){
				currpos= NextNonComment();
				if (currpos>=len) break; //nessun token trovato
				if (Char.IsWhiteSpace(spbody,currpos)){
					currpos++;
					continue;
				}
				//Ha trovato un token (ossia qualcosa che non è ne uno spazio ne un commento
				skipped= spbody.Substring(startpos, currpos-startpos);
				return GetToken();
			}
			//Se passa di qui non ha trovato alcun token
			if (currpos>startpos) {
				skipped= spbody.Substring(startpos, currpos-startpos);
			}
			return new SPToken(tokenkind.EOF,"");
		}

		/// <summary>
		/// Restituisce un segnalibro alla posizione corrente del parser
		/// </summary>
		/// <returns></returns>
		public int GetMark(){
			return currpos;
		}

		/// <summary>
		/// Si posiziona 
		/// </summary>
		/// <param name="mark"></param>
		public void GotoMark(int mark){
			currpos=mark;
		}

		public static string Compile(DataAccess Conn, string spbody, Aliases StartTablesAlias){
			StringBuilder AllCompiled = new StringBuilder();
			StringReader Sread= new StringReader(spbody);
				
			string currline = Sread.ReadLine();
			string nextline = Sread.ReadLine();
			StringBuilder Cmd=null;
			while (currline!=null){
				if (nextline!=null)	currline+="\r\n";
				if (currline.TrimEnd().ToUpper()=="GO"){
					if (Cmd!=null) {
						RuleBridge DBB = new RuleBridge(Conn);
						DBB.Init(Cmd.ToString());
						if (StartTablesAlias!=null){
							DBB.TablesAlias= StartTablesAlias;
						}
						DBB.CompileExpressions();
						AllCompiled.Append(DBB.compiled);
						AllCompiled.Append(currline);
					}
					Cmd=null;
					currline= nextline;
					nextline=Sread.ReadLine();
					continue;
				}
				if (Cmd==null)
					Cmd = new StringBuilder(currline);
				else
					Cmd.Append(currline);
				currline= nextline;
				nextline= Sread.ReadLine();
			}

			if (Cmd!=null && Cmd.ToString()!="") {
				RuleBridge DBB = new RuleBridge(Conn);
				DBB.Init(Cmd.ToString());
				if (StartTablesAlias!=null){
					DBB.TablesAlias= StartTablesAlias;
				}
				DBB.CompileExpressions();
				AllCompiled.Append(DBB.compiled);
			}
			return AllCompiled.ToString();
		}
		
	
	}



	public class SPRuleBridge : SPBridge {
		public SPRuleBridge(string spbody):base(spbody){
			
		}
		/// <summary>
		/// Prende un token dalla posizione corrente
		/// </summary>
		/// <returns></returns>
		protected override SPToken GetToken(){
			if (currpos==len) return null;
			char C= spbody[currpos];
			if (Char.IsLetter(C)||(C=='@')||(C=='_')||(C=='#')) return GetKeywordOrIdentifier();
			if (Char.IsDigit(C)) return GetNumber();
			currpos++;
			if (C=='\'') return GetStringConstant();
			if (C=='(') return new SPToken(tokenkind.openbracket, "(");
			if (C==')') return new SPToken(tokenkind.closebracket,")");
			if (C == '&'){
				int mark = GetMark();
				//controlla se è del tipo &<anything>&
				SPToken SPT2 = GetToken();
				if (SPT2.val=="<"){
					//allora prende qualsiasi cosa fino al prossimo &
					int nextperc= spbody.IndexOf("&", currpos);
					string ident = "&<"+spbody.Substring(currpos, nextperc-currpos+1);
					currpos= nextperc+1;
					return new SPToken(tokenkind.identifier, ident);
				}
				GotoMark(mark); //non era del tipo <%...			
			}
			if (C == '%'){
				int mark = GetMark();
				//controlla se è del tipo %<anything>%
				SPToken SPT2 = GetToken();
				if (SPT2.val=="<"){
					//allora prende qualsiasi cosa fino al prossimo &
					int nextperc= spbody.IndexOf("%", currpos);
					string ident = "%<"+spbody.Substring(currpos, nextperc-currpos+1);
					currpos= nextperc+1;
					return new SPToken(tokenkind.identifier, ident);
				}
				GotoMark(mark); //non era del tipo <%...			
			}
		
			if (Char.IsPunctuation(C)) return new SPToken(tokenkind.punctuator,C.ToString());
			if (Char.IsSeparator(C)) return new SPToken(tokenkind.separator,C.ToString());
			if (Char.IsSymbol(C)) return new SPToken(tokenkind.punctuator,C.ToString());
			QueryCreator.ShowError(null,"Unknown char found: "+C.ToString(),"");
			return new SPToken(tokenkind.unknown,C.ToString());
		}
	}
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class RuleBridge : DBBridge{
		public RuleBridge(DataAccess Conn):base (Conn){
			
		}
		public override void Init(string spbody){
			base.Init(spbody);
			SPB = new SPRuleBridge(spbody);
		}

		public static string CompileRuleEnforcement(DataAccess Conn, string rule){
			StringBuilder AllCompiled = new StringBuilder();
			StringReader Sread = new StringReader(rule);
			
			SPRuleBridge MainBridge= new SPRuleBridge(rule);
			string skipped;
			SPToken SPT;
			while (true){
				SPT = MainBridge.NextToken(out skipped);
				AllCompiled.Append(skipped);
				AllCompiled.Append(SPT.val);
				if (SPT.val=="["){
					//prende fino alla prossima parentesi quadra chiusa non aperta
					string expr = GetNextExpression(MainBridge,"[","]");
					string compiled =Compile(Conn,expr,null);
					AllCompiled.Append( compiled);
				}
				if (SPT.val=="{"){
					//prende fino alla prossima parentesi graffa chiusa non aperta
					string expr = GetNextExpression(MainBridge,"{","}");
					AllCompiled.Append( expr);
				}
				if (SPT.kind== tokenkind.EOF)	break;
			}
			return AllCompiled.ToString();
		}

		static string GetNextExpression(SPBridge SPB, string open, string close){
			string expr="";
			string skipped;
			int nest=1;
			while (nest>0){
				SPToken SPT = SPB.NextToken(out skipped);
				expr+=skipped;
				if (SPT.val==open) nest++;
				if (SPT.val==close) nest--;
				expr+= SPT.val;
				if (SPT.kind== tokenkind.EOF) break;
			}
			return expr;
		}

	}

}
