/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Text;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Security.Policy;


namespace metaeasylibrary {
    public  class TestProcedureMessageCollection : ProcedureMessageCollection {
        public TestProcedureMessageCollection() {

        }
        /// <summary>
        /// Adds a message to the list, updating CanIgnore status
        /// </summary>
        /// <param name="Msg"></param>
        public override void Add(ProcedureMessage Msg) {
            base.Add(Msg);
            Msg.CanIgnore = true;
            Msg.PostMsgs = this.PostMsgs;
            CanIgnore = true;
        }

        /// <summary>
        ///  Appends a list of messages to this
        /// </summary>
        /// <param name="otherList"></param>
        public override void Add(ProcedureMessageCollection otherList) {
            foreach (ProcedureMessage p in otherList) {
                p.CanIgnore = true;
                base.Add(p);
                CanIgnore = true;
            }
        }
    }

    public class Easy_PostData_NoBL : PostData {
        override public string GetOptimisticClause(DataRow R) {
            if (R.Table.PrimaryKey != null) {
                if ((R.Table.Columns["lu"] != null) &&
                    (R.Table.Columns["lt"] != null) &&
                    R.Table.PrimaryKey.Length > 0) {
                    int keylen = R.Table.PrimaryKey.Length;
                    DataColumn[] Cs = new DataColumn[keylen + 2];
                    for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
                    Cs[keylen] = R.Table.Columns["lu"];
                    Cs[keylen + 1] = R.Table.Columns["lt"];
                    return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
                }
            }
            return base.GetOptimisticClause(R);
        }

        //public override RowChange GetNewRowChange(DataRow R) {
	       // return new EasyRowChange(R);
        //}
    }

    public class Easy_PostDataTest : Easy_PostData {
        public override ProcedureMessageCollection GetEmptyMessageCollection() {
            return new TestProcedureMessageCollection();
        }

        public Easy_PostDataTest() {
            autoIgnore = true;
        }

        override protected bool Can_Post(DataRow R){
				 
            return true;
        }

        public override RowChange GetNewRowChange(DataRow R) {
	        return new EasyRowChange(R);
        }
    }

    public class Easy_PostData :PostData {
        public static List<string> rulesToIgnore = new List<string>();
        public static List<EasyProcedureMessage> ignoredRules = new List<EasyProcedureMessage>();
		public override ProcedureMessageCollection GetEmptyMessageCollection() {
			return new EasyProcedureMessageCollection();
		}

        override public string GetOptimisticClause(DataRow R) {
            if (R.Table.PrimaryKey != null) {
                if ((R.Table.Columns["lu"] != null) &&
                    (R.Table.Columns["lt"] != null) &&
                    R.Table.PrimaryKey.Length > 0) {
                    int keylen = R.Table.PrimaryKey.Length;
                    DataColumn[] Cs = new DataColumn[keylen + 2];
                    for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
                    Cs[keylen] = R.Table.Columns["lu"];
                    Cs[keylen + 1] = R.Table.Columns["lt"];
                    return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
                }
            }
            return base.GetOptimisticClause(R);
        }

        override protected bool Can_Post(DataRow R){
			if (!base.Can_Post(R)) return false;
					 
			return true;
		}

		override protected DataJournaling GetJournal(DataAccess Conn, RowChangeCollection Cs){
			return new EasyDataJournaling(Cs.connectionToUse, Cs);
		}

	    override protected DataJournaling getJournal(IDataAccess Conn, RowChangeCollection Cs){
	        return new EasyDataJournaling(Cs.connectionToUse, Cs);
	    }

		override protected ProcedureMessageCollection  DO_CALL_CHECKS(bool Post, RowChangeCollection RowChanges) {
		    ProcedureMessageCollection result = new EasyProcedureMessageCollection();
		    foreach (singleDatasetPost p in allPost) {
		        var rules = EasyProcedureMessageCollection.DO_CALL_CHECKS(RowChanges.connectionToUse, (EasyAudits) p.Rules,
		            Post, RowChanges);
		        if (rulesToIgnore.Count == 0) {
		            result.Add(rules);
		            continue;
		        }

		        List<EasyProcedureMessage> ignored = new List<EasyProcedureMessage>();
		        foreach (EasyProcedureMessage rule in rules) {
		            if (rule == null) continue;
		            if (rulesToIgnore.Contains(rule.AuditID)) {
		                ignored.Add(rule);
		            }
		        }

		        if (ignored.Count == 0) {
		            result.Add(rules);
		            continue;
		        }

		        foreach (var r in ignored) {
		            ignoredRules.Add(r);
		            rules.Remove(r);
		        }

		        rules.recalcIgnoreFlag();
                result.Add(rules);
            }
		    return result;

		}

		override protected MetaDataRules GetRules(RowChangeCollection Cs){
			return new EasyAudits(Cs.connectionToUse,Cs);
		}

		public override RowChange GetNewRowChange(DataRow R) {
			return new EasyRowChange(R);
		}



	}


	public class EasyRowChange:  RowChange {
        public const  string sp_prefix = "check_";
		public EasyRowChange(DataRow DR):base(DR){ 
		}
		/// <summary>
		/// Get the name of Stored procedure to call in pre-check phase
		/// </summary>
		/// <returns></returns>
		public override	 String PreProcNameToCall(){
            return sp_prefix + PostingTable + "_" + ShortStatus() + "_pre";
		}
		/// <summary>
		/// get the name of Stored procedure to call in post-check phase
		/// </summary>
		/// <returns></returns>
		public override String PostProcNameToCall(){
            return sp_prefix + PostingTable + "_" + ShortStatus() + "_post";
		}
     

		/// <summary>Gets a filter of TableName AND dboperation (I/U/D)</summary>
		/// <returns>filter String</returns>
		public override String FilterTableOp(){
			return "(tablename='"+TableName+"')AND(opkind='"+ShortStatus()+"')";
		}
 
		/// <summary>
		/// Gets a filter on Posting Table and DB operation 
		/// </summary>
		/// <returns></returns>
		public override String FilterPostTableOp(){
			return "(tablename='"+PostingTable+"')AND(opkind='"+ShortStatus()+"')";
		}



		/// <summary>
		/// Completes the row to be changed with createuser,createtimestamp,
		/// lastmoduser, lastmodtimestamp fields, depending on the operation type.
		/// </summary>
		/// <param name="Acc"></param>
		[Obsolete]
		public  override void PrepareForPosting(string user,DataAccess Acc,bool DoCalcAutoID){
			//SqlDateTime Stamp = new SqlDateTime(System.DateTime.Now);
			DateTime Stamp = DateTime.Now;
            string role = Acc.GetSys("codeflowchart") as string;
            int lenUser = user.Length;
            int restAvailable = 64 - lenUser - 2;
            if (role != null) {
	            if (role.Length > restAvailable) role = role.Substring(0, restAvailable);
	            user += "{" + role + "}";
            }
            

			switch (ShortStatus()){
				case short_insert_descr:
					if (DoCalcAutoID) CalcAutoID(DR, Acc);
					if (DR.Table.Columns["cu"]!=null) DR["cu"] =user;                    
					if (DR.Table.Columns["ct"]!=null) DR["ct"] = Stamp;
					if (DR.Table.Columns["lu"]!=null) DR["lu"] =user;
			        if (DR.Table.Columns["lt"] != null) {
			            var typeStamp = DR.Table.Columns["lt"].DataType;
			            if (typeStamp == typeof(Int64) || typeStamp == typeof(UInt64)) {
			                DR["lt"] = Stamp.ToBinary();
			            }
			            else {
                            DR["lt"] = Stamp;
                        }
                        
			        }
					break;
				case short_update_descr:
					if (DR.Table.Columns["lu"]!=null){
						DR["lu"] =user;
					}
					if (DR.Table.Columns["lt"]!=null){
                        var typeStamp = DR.Table.Columns["lt"].DataType;
                        if (typeStamp == typeof(Int64) || typeStamp == typeof(UInt64)) {
                            DR["lt"] = Stamp.ToBinary();
                        }
                        else {
                            DR["lt"] = Stamp;
                        }
                    }
					break;
				case short_delete_descr:
					//nothing to do!
					break;
			}
            try {
                GetData.CalculateRow(DR);
            }
            catch {
            }
       
		}


	    public override void prepareForPosting(string user, IDataAccess Acc, bool DoCalcAutoID) {
	        //SqlDateTime Stamp = new SqlDateTime(System.DateTime.Now);
	        DateTime Stamp = DateTime.Now;
	        string role = Acc.Security.GetSys("codeflowchart") as string;
	        int lenUser = user.Length;
	        int restAvailable = 64 - lenUser - 2;
	        if (role != null) {
		        if (role.Length > restAvailable) role = role.Substring(0, restAvailable);
		        user += "{" + role + "}";
	        }
	        switch (ShortStatus()) {
	            case short_insert_descr:
	                if (DoCalcAutoID) CalcAutoID(DR, Acc);
	                if (DR.Table.Columns["cu"] != null) DR["cu"] = user;
	                if (DR.Table.Columns["ct"] != null) DR["ct"] = Stamp;
	                if (DR.Table.Columns["lu"] != null) DR["lu"] = user;
	                if (DR.Table.Columns["lt"] != null) {
	                    var typeStamp = DR.Table.Columns["lt"].DataType;
	                    if (typeStamp == typeof(Int64) || typeStamp == typeof(UInt64)) {
	                        DR["lt"] = Stamp.ToBinary();
	                    }
	                    else {
	                        DR["lt"] = Stamp;
	                    }

	                }
	                break;
	            case short_update_descr:
	                if (DR.Table.Columns["lu"] != null) {
	                    DR["lu"] = user;
	                }
	                if (DR.Table.Columns["lt"] != null) {
	                    var typeStamp = DR.Table.Columns["lt"].DataType;
	                    if (typeStamp == typeof(Int64) || typeStamp == typeof(UInt64)) {
	                        DR["lt"] = Stamp.ToBinary();
	                    }
	                    else {
	                        DR["lt"] = Stamp;
	                    }
	                }
	                break;
	            case short_delete_descr:
	                //nothing to do!
	                break;
	        }
	        try {
	            GetData.CalculateRow(DR);
	        }
	        catch {
	        }

	    }

    }



	public class EasyDataJournaling : DataJournaling{
		private VistaEasyJournaling Data;
	    IDataAccess Conn;

		/// <summary>
		/// se = true registra anche il vecchio valore in una colonna oldvalue
		/// </summary>
		public const bool LogOld = true;

		public EasyDataJournaling(IDataAccess Conn, RowChangeCollection Cs){
			this.Conn=Conn;
			CreateDataSet(Conn,Cs);            
		}

        object truncateString(object S,int len) {
            if (S == DBNull.Value)
                return S;
            string s = S.ToString();
            if (s.Length <= len)
                return s;
            return s.Substring(0, len);
        }
		/// <summary>
		/// Log "FieldToLog" field of RowChange
		/// </summary>
		/// <param name="R">RowChange to log</param>
		/// <param name="FieldToLog">Field to log</param>
		private void do_SingleLog(RowChange R, DataRow FieldToLog){
			string ColName = FieldToLog["dbfield"].ToString();
            
			//checks if FieldToLog belongs to R
			if (R.DR.Table.Columns[ColName]!=null){

				//Checks a particular situation where log has not to be actually done
				//i.e. don't log update if old and new values are equal
				if (R.ShortStatus().Equals(RowChange.short_update_descr) &&
					(R.DR[ColName,DataRowVersion.Original].ToString().Equals(
					R.DR[ColName,DataRowVersion.Current].ToString()))
					) return;

                if (R.ShortStatus().Equals(RowChange.short_insert_descr) &&
                    (R.DR[ColName, DataRowVersion.Current]==DBNull.Value))
                    return;
                if (R.ShortStatus().Equals(RowChange.short_delete_descr) &&
                    (R.DR[ColName, DataRowVersion.Original] == DBNull.Value))
                    return;
			    if (R.ShortStatus().Equals(RowChange.short_delete_descr) && (LogOld == false)) {
			        return;
			    }
                DataRow NewRowLog = Data.journal.NewRow();
				NewRowLog["operationdatetime"] =   DateTime.Now;
				NewRowLog["tablename"] = R.PostingTable;
				NewRowLog["opkind"] = R.ShortStatus();
				NewRowLog["fieldname"]= truncateString(ColName,50);
                NewRowLog["iddbdepartment"] = Conn.Security.GetSys("userdb");
                string idflow= Conn.Security.GetSys("idflowchart") as string;
                if (idflow != null) NewRowLog["idflowchart"] = idflow;
				NewRowLog["primarykey"] = truncateString(R.PrimaryKey(),255);
				NewRowLog["dbuser"] = Conn.Security.GetSys("user");
				NewRowLog["computername"] = Conn.Security.GetSys("computername");
				NewRowLog["computeruser"] = Conn.Security.GetSys("computeruser");
                                                                              

				switch (R.ShortStatus()){
					case RowChange.short_delete_descr:                        
						if (LogOld) {
							NewRowLog["oldvalue"]=truncateString(R.DR[ColName,DataRowVersion.Original],255);
							//new value = null
						}
						else {
#pragma warning disable CS0162 //Unreacheablecode detected
                            NewRowLog["value"]=R.DR[ColName,DataRowVersion.Original];
#pragma warning restore CS0162 //Unreacheablecode detected
                            //oldvalue unused
                        }
                        break;
					case RowChange.short_insert_descr:
						NewRowLog["value"]=truncateString(R.DR[ColName,DataRowVersion.Current],255);
						//old value = null
						break;
					case RowChange.short_update_descr:
						NewRowLog["value"] = truncateString(R.DR[ColName,DataRowVersion.Current].ToString(),255);
						if (LogOld) NewRowLog["oldvalue"] = truncateString(R.DR[ColName,DataRowVersion.Original].ToString(),255);
						break;
				}
				Data.journal.Rows.Add(NewRowLog);               
			}
		}

		/// <summary>
		/// Append log messages basing on the specified audits
		/// </summary>
		/// <param name="Tran">Transaction in which operation are nested</param>
		/// <returns>true if OK</returns>
		override public DataRowCollection DO_Journaling(RowChangeCollection Changes){
			Data.journal.Clear();
			foreach (RowChange R in Changes){
				//checks if there is some logging job to do about R
				DataRow[] OneAudit = Data.journaltablesetup.Select(R.FilterPostTableOp());
				if (OneAudit.Length == 1){
                    DataRow[] FieldsToLog = OneAudit[0].GetChildRows("journaltablesetupjournalfieldsetup");
					foreach (DataRow FieldToLog in FieldsToLog){                        
						//Log all specified field
						do_SingleLog(R, FieldToLog);
					}
				}

			}		
			return Data.journal.Rows;
		}

		/// <summary>
		/// Gets the set of all audit and auditcheck related to RowChanges
		/// </summary>
		/// <param name="Conn">Open connection</param>
		void CreateDataSet(IDataAccess Conn, RowChangeCollection Cs){
			Data = new VistaEasyJournaling();

			foreach (RowChange RC in Cs){
				if (Data.tableop.Select(RC.FilterPostTableOp()).Length>0) continue;
				DataRow newR = Data.tableop.NewRow();
				newR["tablename"]= RC.PostingTable;
				newR["opkind"]=RC.ShortStatus();
                Data.tableop.Rows.Add(newR) ;
				newR.AcceptChanges();
			}
			GetData myGetD = new GetData();
			myGetD.InitClass(Data, Conn, "tableop");
			ClearDataSet.RemoveConstraints(Data);
			myGetD.DO_GET(false,null);

		}
	}

	/// <summary>
	/// Interface to the Easy Business Audits and Enforcements
	/// </summary>
	public class EasyAudits : MetaDataRules{
	    IDataAccess Conn;

		/// <summary>
		/// Aggregates of auditcheck
		/// There is a Business Audit for every kind of operation of any table in the DataBase.
		/// </summary>
		public DataTable Business {
			get {
				return Data.Tables["audit"];
			}
		}

		/// <summary>
		/// Single condition on a database operation, included in a Business Audit
		/// </summary>
		public DataTable Enforcement {
			get {
				return Data.Tables["auditcheckview"];
			}
		}

		/// <summary>
		/// Parameters for a Business Audit
		/// </summary>
		public DataTable Parameter {
			get {
				return Data.Tables["auditparameter"];
			}
		}

    
		internal VistaEasyAudits Data;

		public EasyAudits(IDataAccess Conn, RowChangeCollection Cs){
			this.Conn=Conn;
			CreateDataSet(Conn, Cs);
		}
    
		/// <summary>
        /// Calcola l'insieme di tutte le audit e auditcheck relative ad un insieme di RowChanges
		/// Non considera l'applicabilità degli auditcheck relativa alla configurazione annuale 
		/// </summary>
		/// <param name="Conn">Open connection</param>
		void CreateDataSet(IDataAccess Conn,RowChangeCollection Cs){
			Data = new VistaEasyAudits();
			Data.CaseSensitive=false;
			foreach(DataTable T in Data.Tables) T.CaseSensitive=false;

			foreach (RowChange RC in Cs){
				if (Data.tableop.Select(RC.FilterPostTableOp()).Length>0) continue;
				DataRow newR = Data.tableop.NewRow();
				newR["tablename"]= RC.PostingTable;
				newR["opkind"]=RC.ShortStatus();
                Data.tableop.Rows.Add(newR);
				newR.AcceptChanges();
			}
			Data.auditcheckview.ExtendedProperties["sort_by"]="idaudit ASC, idcheck ASC";
			GetData myGetD = new GetData();
			Data.auditcheckview.setStaticFilter("(sqlcmd IS NOT NULL)AND(severity<>'I')");
			myGetD.InitClass(Data, Conn, "tableop");
			ClearDataSet.RemoveConstraints(Data);
			myGetD.DO_GET(false,null);
		}



		#region Creazione Business Rules
		const string anewline = "\n";

		/// <summary>
		/// Gets all parameters (old values and new values) still present in sqlcmd 
		/// </summary>
		/// <param name="sqlcmd"></param>
		/// <returns>An array of strings</returns>
		static ArrayList GetNewKeys(string sqlcmd){
			int h= metaprofiler.StartTimer("GetNewKeys");
			ArrayList res = new ArrayList();
			//Add old value parameters
			int start =0;
			while (start < sqlcmd.Length){
				int next= GetNextUncommentedString(sqlcmd,"&<", start);
				if (next==-1) break;
				int afterparam= GetNextUncommentedString(sqlcmd,">&", next+1);
				if (afterparam==-1) break;
				start=afterparam+2;
				string key= sqlcmd.Substring(next, start-next);
				res.Add(key);
			}
			//Add old value parameters
			start =0;
			while (start < sqlcmd.Length){
				int next= GetNextUncommentedString(sqlcmd,"%<", start);
				if (next==-1) break;
				int afterparam= GetNextUncommentedString(sqlcmd,">%", next+1);
				if (afterparam==-1) break;
				start=afterparam+2;
				string key= sqlcmd.Substring(next, start-next);
				res.Add(key);
			}

			metaprofiler.StopTimer(h);
			return res;
		}




		

		#region Individuazione dei parametri presenti in un elenco di check (la tabella auditchecks)

		/// <summary>
		/// Given the table auditcheck evaluates the table parameter and the Hashtable Substitutions
		/// </summary>
		/// <param name="CR"></param>
		static void EvaluateParameters(DataAccess Conn, VistaEasyAudits CR, 
			string tablename, 
			string opkind,
			out Hashtable Substitutions,bool PreCheck){
			int h= metaprofiler.StartTimer("EvaluateParameters");
			int totparameters=0;
			Hashtable PossibleSubstitutions = new Hashtable();
			foreach (string k in Conn.Security.EnumSysKeys()){
				if (k=="esercizio"){
					//PossibleSubstitutions["%<esercizio>%"]="@sys_"+k;
					PossibleSubstitutions["%<sys_esercizio>%"]="@sys_"+k;
				}
				else {
					PossibleSubstitutions["%<sys_"+k+">%"]="@sys_"+k;
				}
			}
			
			Substitutions = new Hashtable();
			//Substitutions["%<esercizio>%"]="@AccountingYear";
			foreach(DataRow audit in CR.auditcheckview.Rows){
				string sqlcmd= audit["sqlcmd"].ToString();
				sqlcmd= sqlcmd.Replace("%<esercizio>%","%<sys_esercizio>%");
				foreach(string key in Substitutions.Keys){
					sqlcmd = sqlcmd.Replace(key, Substitutions[key].ToString());
				}
				foreach(string key in PossibleSubstitutions.Keys){
					if (Substitutions[key]!=null) continue; //substitution already added (should not happen!)
					if (sqlcmd.IndexOf(key)>=0){
						Substitutions[key]=PossibleSubstitutions[key];
						sqlcmd = sqlcmd.Replace(key, Substitutions[key].ToString());
						totparameters++;
						string filter="(tablename='"+tablename+"')AND(opkind='"+opkind+"')AND"+
							"(parameterid='"+totparameters.ToString()+"')";
						DataRow []parfound= CR.auditparameter.Select(filter	);
						DataRow newPar;
						if (parfound.Length>0){
							newPar= parfound[0];
						}
						else {
							newPar= CR.auditparameter.NewRow();
							newPar["tablename"]=tablename;
							newPar["opkind"]= opkind;
						}
						newPar["isprecheck"]= PreCheck?"S":"N";
						newPar["parameterid"]= totparameters;
						newPar["flagoldvalue"]="-";
						newPar["paramtable"]= "sys";
						newPar["paramcolumn"]= key.Replace("%<","").Replace(">%","");

						if (parfound.Length==0){
							CR.auditparameter.Rows.Add(newPar);	
						}
					}
				}

				ArrayList NewKeys= GetNewKeys(sqlcmd);
				foreach (string key in NewKeys){
					if (Substitutions[key]!=null) continue;
				
					totparameters++;
					DataRow newPar;
					string filter2="(tablename='"+tablename+"')AND(opkind='"+opkind+"')AND"+
						"(parameterid='"+totparameters.ToString()+"')";

					DataRow []parfound= CR.auditparameter.Select(filter2);
					if (parfound.Length>0){
						newPar= parfound[0];
					}
					else {
						newPar= CR.auditparameter.NewRow();
						newPar["tablename"]= tablename;
						newPar["opkind"]= opkind;
						newPar["parameterid"]= totparameters;
					}
					newPar["isprecheck"]= PreCheck?"S":"N";
					string subst="";
					if (key.StartsWith("&<")){
						subst = "@OLD";
						newPar["flagoldvalue"]="S";
					}
					else {
						subst = "@NEW";
						newPar["flagoldvalue"]="N";
					}
					
					string tablefield = key.Substring(2,key.Length-4).Trim();
					string []fields = tablefield.Split(new char[]{'.'});
					if(fields.Length>0){
						if (fields.Length>1){
							string tablefound=fields[0].Trim().ToLower();
							newPar["paramtable"]=tablefound;
							if (tablefound!=tablename) subst+= "_"+tablefound;					
							newPar["paramcolumn"]=fields[1].Trim().ToLower();
						}
						else {
							newPar["paramtable"]=tablename;
							newPar["paramcolumn"]=fields[0].Trim().ToLower();
						}				
						if (parfound.Length==0) 
							CR.auditparameter.Rows.Add(newPar);	
					}
					subst+= "_"+newPar["paramcolumn"].ToString();
					Substitutions.Add(key,subst);
					sqlcmd = sqlcmd.Replace(key, subst);
				}

				audit["sqlcmd"]=sqlcmd;
			}

			//int newparameterid2=oparameters+nparameters;
			string filter3="(tablename='"+tablename+"')AND(opkind='"+opkind+"')AND"+
				"(parameterid>'"+totparameters.ToString()+"')";
			DataRow []ToDelete= CR.auditparameter.Select(filter3);
			foreach(DataRow R in ToDelete) R.Delete();
			metaprofiler.StopTimer(h);
		}
		#endregion


		static bool isIdentifier(char C){
			if (Char.IsLetterOrDigit(C)) return true;
			if (C=='@') return true;
			if (C=='_') return true;
			return false;
		}

		//Combinazione di StripComments e NormalizeExpression
		public static string Compact(string sqlcmd){
			int hNorm= metaprofiler.StartTimer("Compact!");
			bool prevwasidentifier=false;
			bool spacetoadd=false;
			string res="";
			int index=0;
			//sqlcmd = StripComments(sqlcmd);
			int len = sqlcmd.Length;
			while (index< len){
				//Salta i commenti --
				if (sqlcmd.Substring(index).StartsWith("--")){
					int next1 = sqlcmd.IndexOf("\n",index);
					int next2 = sqlcmd.IndexOf("\r",index);
					if ((next1==-1)&&(next2==-1)) {
						metaprofiler.StopTimer(hNorm);
						return res;
					}

					//Aver trovato un commento equivale ad aver trovato uno spazio
					if (prevwasidentifier) spacetoadd =true;
					prevwasidentifier=false;

					if (next1==-1){
						index=next2+1;
						continue;
					}
					if (next2==-1){
						index=next1+1;
						continue;
					}
					if (next1<next2) 
						index=next1+1;
					else
						index=next2+1;
					continue;
				}

				//salta i commenti del tipo /*  .. */
				if (sqlcmd.Substring(index).StartsWith("/*")){
					int next= sqlcmd.IndexOf("*/",index);
					if (next==-1) {
						metaprofiler.StopTimer(hNorm);
						return res;
					}
					//Aver trovato un commento equivale ad aver trovato uno spazio
					if (prevwasidentifier) spacetoadd =true;
					prevwasidentifier=false;
					index = next+2;
					continue;
				}

				char C = sqlcmd[index];

				if ((C!=' ')&&(C!='\n')&&(C!='\r')&&(C!='\t')){
					if (isIdentifier(C)||(C=='[')||(C==']')||(C=='{')||(C=='}')) {
						if (spacetoadd) res+=" ";
						spacetoadd=false;

						prevwasidentifier=true;
					}
					else {
						prevwasidentifier=false;
						spacetoadd=false;

					}
					res+=C;

					if (C=='\''){
						//skips  the string constant 
						index++;
						//skips the string
						while (index<len){
							if (sqlcmd[index]!='\'') {
								res+= sqlcmd[index];
								index++;
								continue;
							}
							//it could be an end-string character
							if (((index+1)<len)&&(sqlcmd[index+1]=='\'')){
								//it isn't
								res+= sqlcmd[index];
								index++;
								res+= sqlcmd[index];
								index++;
								continue;
							}
							res+= sqlcmd[index];
							break;
						}
					}

				}
				else {//Converte tutti gli spazi precedenti in uno spazio
					if (prevwasidentifier) spacetoadd =true;
					prevwasidentifier=false;
				}
				index++;
			}
			metaprofiler.StopTimer(hNorm);
			return res;
		}



		public static string StripComments(string sqlcmd){
			int h= metaprofiler.StartTimer("StripComments");
			int index=0;
			string res="";
			if (sqlcmd==null) {
				metaprofiler.StopTimer(h);
				return null;
			}
			while (index < sqlcmd.Length){
				if (sqlcmd.Substring(index).StartsWith("--")){
					int next1 = sqlcmd.IndexOf("\n",index);
					int next2 = sqlcmd.IndexOf("\r",index);
					if ((next1==-1)&&(next2==-1)) {
						metaprofiler.StopTimer(h);
						return res;
					}
					if (next1==-1){
						index=next2+1;
						continue;
					}
					if (next2==-1){
						index=next1+1;
						continue;
					}
					if (next1<next2) 
						index=next1+1;
					else
						index=next2+1;
					continue;
				}

				if (sqlcmd.Substring(index).StartsWith("/*")){
					int next= sqlcmd.IndexOf("*/",index);
					if (next==-1) {
						metaprofiler.StopTimer(h);
						return res;
					}
					index = next+2;
					continue;
				}
				res+= sqlcmd[index];
				index++;
			}

			metaprofiler.StopTimer(h);
			return res;
		}

		public static string NormalizeExpression(string sqlcmd){
			if (sqlcmd==null) return "";
			int hNorm= metaprofiler.StartTimer("NormalizeExpression");
			bool prevwasidentifier=false;
			bool spacetoadd=false;
			string res="";
			int index=0;
			sqlcmd = StripComments(sqlcmd);
			int len = sqlcmd.Length;
			while (index< len){
				char C = sqlcmd[index];

				if ((C!=' ')&&(C!='\n')&&(C!='\r')&&(C!='\t')){
					if (isIdentifier(C)) {
						if (spacetoadd) res+=" ";
						spacetoadd=false;

						prevwasidentifier=true;
					}
					else {
						prevwasidentifier=false;
						spacetoadd=false;

					}
					res+=C;

					if (C=='\''){
						//skips  the string constant 
						index++;
						//skips the string
						while (index<len){
							if (sqlcmd[index]!='\'') {
								res+= sqlcmd[index];
								index++;
								continue;
							}
							//it could be an end-string character
							if (((index+1)<len)&&(sqlcmd[index+1]=='\'')){
								//it isn't
								res+= sqlcmd[index];
								index++;
								res+= sqlcmd[index];
								index++;
								continue;
							}
							res+= sqlcmd[index];
							break;
						}
					}

				}
				else {//Converte tutti gli spazi precedenti in uno spazio
					if (prevwasidentifier) spacetoadd =true;
					prevwasidentifier=false;



				}
				index++;
			}
			metaprofiler.StopTimer(hNorm);
			return res;
		}


	


		public static int GetNextNonStringConst(string S, char C,int start){
			int pos = S.IndexOf(C,start);
			if (pos==-1) return -1;
            int h = metaprofiler.StartTimer("GetNextNonStringConst");
            int nextopenstr = S.IndexOf('\'',start);
			try {
				while (nextopenstr!=-1 && pos>=nextopenstr){
					int nextclosestr = S.IndexOf('\'',nextopenstr+1);
					while (nextclosestr!=-1 && nextclosestr<S.Length-1){
						if (S[nextclosestr+1]=='\'') {
							nextclosestr=S.IndexOf('\'',nextclosestr+2);
							continue;
						}
						break;
					}
					if (nextclosestr==-1) {
						metaprofiler.StopTimer(h);
						return -1;
					}
					if (pos < nextclosestr) {
						if (nextclosestr==S.Length-1){
							metaprofiler.StopTimer(h);
							return -1;
						}
						pos=S.IndexOf(C,nextclosestr);
					}
					start=nextclosestr+1;
					nextopenstr= S.IndexOf('\'',start);
				}


			}
			catch {
				metaprofiler.StopTimer(h);
				return -1;
			}
			metaprofiler.StopTimer(h);
			return pos;			
		}

		public static int GetNextUncommentedString(string S, string C,int start){
			try {
				int pos = S.IndexOf(C,start);
				while (pos>=0 && StringParser.IsInsideComment(S,start,pos)) 
					pos= S.IndexOf(C,pos+1);
				return pos;

			}
			catch {
				return -1;
			}

		}

        class ExprAggregation {
            public bool simple=true;
            public bool grouped = false;
            public bool forced = false;
            public bool SelectionEmitted = false;
            public int mincheck;
            public int maxcheck;

            public int AggregationNumber;
            public string fromcondition;
            public ArrayList Expressions;

            public ExprAggregation(string fromcondition, bool simple, bool grouped) {
                this.fromcondition = fromcondition;
                this.simple = simple;
                this.grouped = grouped;
                Expressions = new ArrayList();
                mincheck = 1000;
                maxcheck = -2;
            }
            public void AddExpression(Expression E) {
                Expressions.Add(E);
            }
            public void AddCheck(AuditCheck A) {
                //Aggiorna min/max check
                if (mincheck > A.auditindex) mincheck = A.auditindex;
                if (maxcheck < A.auditindex) maxcheck = A.auditindex;
            }
            bool DeclEmitted = false;

            public void SetForced(Expression []ExprList) {
                if (forced) return;
                forced=true;
                foreach (Expression E in Expressions) E.SetForced(ExprList);
            }

            public string EmitDeclaration() {
                string res="";
                if (DeclEmitted) return res;
                if ((mincheck!=maxcheck) && (!forced)) {
                    string flagname = " @f" + AggregationNumber.ToString().PadLeft(2, '0');
                    res += "DECLARE " + flagname + " char(1)" + anewline;
                    res += "SET " + flagname + " ='N'" + anewline;
                }
                DeclEmitted = true;
                return res;
            }

            int NAuditEmitted = -10;

            /// <summary>
            /// Emette la selezione di un gruppo di espressioni (semplici - non raggruppate), con condizione comune
            /// </summary>
            /// <param name="Expr"></param>
            /// <param name="NAudit"></param>
            /// <returns></returns>
            public string GetSelection(Expression[] Expr, int NAudit) {
                if (NAuditEmitted == NAudit) return "";
                if (forced && SelectionEmitted) return "";
                NAuditEmitted = NAudit;
                //if ((mincheck==maxcheck) && (NAudit > mincheck)) return "";//vedi (1)
                string res = "";


                foreach (Expression E in Expressions) {
                    //acquisisce prima le var. da cui dipendono tutte le espressioni del gruppo
                    foreach (int nvar in E.VarsLinked) {
                        Expression EE = Expr[nvar];
                        res += EE.GetSelection(Expr, NAudit);
                    }
                }

                string flagname = " @f" + AggregationNumber.ToString().PadLeft(2, '0');
                string pref = "";
                bool BEGINEMESSO = false;
                if ((!forced) && (NAudit > mincheck) && (maxcheck>mincheck)) {
                    res += "IF (" + flagname + "='N') ";
                    if ((!forced) && (NAudit < maxcheck) && (maxcheck > mincheck)) {
                        res += "BEGIN ";
                        BEGINEMESSO = true;
                    }
                    res += anewline;
                    pref = "\t";
                }
                foreach (Expression E0 in Expressions) {
                    if (!E0.declemitted) res += E0.GetDeclaration();
                }
                if (!simple) {
                    Expression E3 = Expressions[0] as Expression;
                    string expr2 = E3.expr;//Expression.NormalizeSELECT(E3.expr.Trim().ToLower());
                    res += pref;
                    if (expr2.StartsWith("execute ")|| expr2.StartsWith("execute(")) {
                        expr2 = expr2.Replace("@outvar", E3.varname);
                        res += expr2 + anewline;
                    }
                    else {
                        if (Char.ToLower(E3.kind) != 'b') {
                            res += "SELECT " + E3.varname + " = " + expr2 + anewline;
                        }
                        else {
                            res += "IF (" + expr2 + ") SET " + E3.varname + " = 'S'" + anewline;
                        }
                        
                    }
                }
                else {
                    res += "SELECT ";
                    bool lastwasmember = false;
                    foreach (Expression E2 in Expressions) {
                        if (E2.maxcheck < NAudit) continue;
                        if (lastwasmember) res += "," + anewline+"\t";
                        res += E2.varname + " = " + E2.selexpr;
                        lastwasmember = true;
                    }
                    if (Expressions.Count > 1) res += anewline;
                    res += " FROM " + fromcondition + anewline;                    
                }

                if ((!forced) && (NAudit < maxcheck) && (maxcheck > mincheck)) {
                    res += pref + "SET " + flagname + " ='S'" + anewline;
                }
                if (BEGINEMESSO) {
                    res += "END" + anewline;
                }
                //if (NAudit == mincheck) mincheck = -1; //(1) multipli rif. alla stessa var. nello stesso segmento
                //non devono produrre tante SELECT e/o SET!
                SelectionEmitted = true;
                return res;

            }
            
        }

		class Expression {
            public bool simple = true;
            public bool grouped = false;
            public bool forced = false;
			public bool SelectionEmitted=false;
			public int mincheck;
			public int maxcheck;
			public int Weight;
			public string varname;
            public string varRecall;
            public string expr;
			public char kind;
			public int Number;
            public string selexpr;
            public ExprAggregation Aggregation;

			public ArrayList CheckLinked;//Elenco di auditcheck in cui questa variabile è necessaria
			public ArrayList VarsLinked; //Variabili necessarie per calcolare questa espressione

			public Expression(string expr, ArrayList Aggregations, char kind,int Number){
				this.expr=NormalizeSELECT(expr.Trim().ToLower());
				this.kind=kind;
				this.Number=Number;
				VarsLinked = new ArrayList();
				varname= "@v"+Number.ToString().PadLeft(2,'0');
			    varRecall = char.ToLower(kind)=='b'? $"({varname}='S')": varname;
                
				CalculateNestedVars();
				CalculateDefaultWeight();
				CheckLinked =new ArrayList();
				mincheck=1000;
				maxcheck=-10;
                SearchAggregation(Aggregations);
			}

            void SetNewAggregation(ArrayList Aggregations, string fromcondition, bool simple) {
                Aggregation = new ExprAggregation(fromcondition, simple,grouped);
                Aggregations.Add(Aggregation);
                Aggregation.AddExpression(this);
                Aggregation.AggregationNumber = Aggregations.Count;
            }

            void SearchAggregation(ArrayList Aggregations) {
                if (simple==false) {
                    SetNewAggregation(Aggregations,"",false);
                    return;
                }

                string fromcond;
                //cerca il primo where 
                string FROM="from";
                int frompos = expr.IndexOf(FROM);
                if (frompos < 0) {
                    SetNewAggregation(Aggregations,"",false);
                    return;
                }
                selexpr = expr.Substring(0, frompos);
                fromcond = expr.Substring(frompos + FROM.Length);

                foreach (ExprAggregation EG in Aggregations) {
                    if (EG.simple == false) continue;
                    if (EG.grouped != grouped) continue;
                    if (EG.fromcondition == fromcond) {
                        Aggregation = EG;
                        EG.AddExpression(this);
                        return;
                    }
                }
                SetNewAggregation(Aggregations, fromcond, true);
            }

            public void SetForced(Expression []ExpList) {
                if (forced) return;
                forced=true;
                Aggregation.SetForced(ExpList);
                Weight = 0;
			    //E.Weight= E.expr.Length;
                foreach (int Nexpr in VarsLinked) ExpList[Nexpr].SetForced(ExpList) ;

            }

			public void AddCheck(Expression []Expr,  AuditCheck A){
                if (CheckLinked.Contains(A)) return;
                CheckLinked.Add(A);
                Aggregation.AddCheck(A);
                //Aggiorna min/max check
                if (mincheck > A.auditindex) mincheck = A.auditindex;
                if (maxcheck < A.auditindex) maxcheck = A.auditindex;
				foreach (int nexpr in VarsLinked){
					Expr[nexpr].AddCheck(Expr,A);
				}
			}

			/// <summary>
			/// Calcola euristicamente il peso iniziale di ogni variabile, considerando nullo
			///  il peso delle variabili annidate. Questo andrà poi rifinito sommando il reale peso delle
			///  variabili annidate.
			/// </summary>
			void CalculateDefaultWeight(){
				int hcalc= metaprofiler.StartTimer("CalculateDefaultWeight");
				string ex=expr;
                Weight = 0;// ex.Length;
                           //				if (ex.IndexOf("from ")<0) {
                           //					Weight=0;
                           //					metaprofiler.StopTimer(hcalc);
                           //					return;
                           //				}
                           //				Weight = ex.Length;
                           //				int nextvar= ex.IndexOf("@");
                           //				while (nextvar>=0){
                           //					int nextvarchar=nextvar+1;
                           //					while (nextvarchar<expr.Length &&
                           //						EasyAudits.IsIdentifier(ex[nextvarchar])){
                           //						nextvarchar++;
                           //					}11.00.5343
                           //					Weight-= (nextvarchar-nextvar);
                           //					nextvar = ex.IndexOf("@", nextvar+1);
                           //				}
                           //				Weight = Weight>>1;
                           //Somma 10000 per ogni FROM
                int nextfrom = ex.IndexOf("from");
                //Weight -= 10000;
				while (nextfrom>=0){
					Weight+= 10000;
					nextfrom = ex.IndexOf("from", nextfrom+1);
				}

                //Somma 10 per ogni isnull
                int nextisnull = ex.IndexOf("isnull");
                while (nextisnull >= 0) {
                    Weight += 10;
                    nextisnull = ex.IndexOf("isnull", nextisnull + 1);
                }

				//Somma 12000 per ogni JOIN
				int nextjoin = ex.IndexOf("join");
				while (nextjoin>=0){
					Weight+= 12000;
					nextjoin = ex.IndexOf("join", nextjoin+1);
				}
				//Somma 8000 per ogni SUM
				int nextsum = ex.IndexOf("sum(");
				while (nextsum>=0){
					Weight+= 8000;
                    grouped = true;
					nextsum = ex.IndexOf("sum(", nextsum+1);
				}
				//Somma 8000 per ogni MIN
				int nextmin = ex.IndexOf("min(");
				while (nextmin>=0){
					Weight+= 8000;
                    grouped = true;
                    nextmin = ex.IndexOf("min(", nextmin + 1);
				}
				//Somma 8000 per ogni MAX
				int nextmax = ex.IndexOf("max(");
				while (nextmax>=0){
					Weight+= 8000;
                    grouped = true;
                    nextmax = ex.IndexOf("max(", nextmax + 1);
				}
				//Somma 6000 per ogni COUNT
				int nextcount = ex.IndexOf("count(");
				while (nextcount>=0){
					Weight+= 6000;
                    grouped = true;
                    nextcount = ex.IndexOf("count(", nextcount + 1);
				}

				//Somma 15000 per ogni execute
				int nextexecute = ex.IndexOf("execute");
				while (nextexecute>=0){
					Weight+= 15000;
                    simple = false;
					nextexecute = ex.IndexOf("execute", nextexecute+1);
				}

                //Somma 12000 per ogni exists
                int nextexists = ex.IndexOf("exists");
                while (nextexists >= 0) {
                    Weight += 12000;
                    simple = false;
                    nextexists = ex.IndexOf("exists", nextexists + 1);
                }

                //Somma 400 per ogni >
                int nextgt = ex.IndexOf('>');
				while (nextgt>=0){
					Weight+= 400;
					nextgt = ex.IndexOf('>', nextgt+1);
				}
				//Somma 400 per ogni <
				int nextlt = ex.IndexOf('<');
				while (nextlt>=0){
					Weight+= 400;
					nextlt = ex.IndexOf('<', nextlt+1);
				}

				metaprofiler.StopTimer(hcalc);

			}

			void CalculateNestedVars(){
				int nextvar=expr.IndexOf("@v");
				while (nextvar>=0){
                    int varnumlen = 2;
                    string nvar = expr.Substring(nextvar + 2, varnumlen);
                    if (expr.Length > nextvar + varnumlen+2 && Char.IsDigit(expr[nextvar + 2+varnumlen])) {
                        nvar += expr[nextvar + 2+varnumlen];
                        varnumlen++;
                    }
					int N= Convert.ToInt32(nvar);
					if (VarsLinked.IndexOf(N)<0)VarsLinked.Add(N);
                    nextvar = expr.IndexOf("@v", nextvar + varnumlen);
				}
			}
			public static string NormalizeSELECT(string expr){
				if (expr.StartsWith("(select")){ //rimuove (select ...)
					expr = expr.Substring(7,expr.Length-7);
					int lastclosepar = expr.LastIndexOf(")");
					if (lastclosepar>=0) expr= expr.Remove(lastclosepar,1);
				}
				if (expr.StartsWith("select")){//rimuove select ...
					expr = expr.Substring(6,expr.Length-6);
				}
				return expr;
			}

            public bool declemitted = false;
			public string GetDeclaration(){
                if (declemitted) return "";
                declemitted = true;
				string decl="declare "+varname+" ";
				string xx= "-- W"+Weight;
				if (CheckLinked.Count>1) xx+=" ("+CheckLinked.Count+")";
				switch(Char.ToLower(kind)){
				    case 'a':
				        decl += "date" + xx + anewline;
				        decl += "SET " + varname + " = null" + anewline;
				        break;	
                    case 'b':
				        decl += "char(1)" + xx + anewline;
                        decl += "SET " + varname + " = 'N'" + anewline;
                        break;				        
                    case 'i': 
						decl+="int "+xx+anewline;
						decl+="SET "+varname+" = 0"+anewline;
						break;
					case 'c': 
						decl+="varchar(255) "+xx+anewline;
						decl+="SET "+varname+" = ''"+anewline;
						break;
					case 'n':
						decl+="decimal(19,6) "+xx+anewline;
						decl+="SET "+varname+" = 0.0"+anewline;
						break;
					case 'f':
						decl+="real "+xx+anewline;
						decl+="SET "+varname+" = 0.0"+anewline;
						break;
					case 'd':
						decl+="datetime "+xx+anewline;
						decl+="SET "+varname+" = null"+anewline;
						break;
					case 'v':
						decl+="decimal(23,2) "+xx+anewline;
						decl+="SET "+varname+" = 0.0"+anewline;
						break;
					default:
						decl+="varchar(255) "+xx+anewline;
						decl+="SET "+varname+" = ''"+anewline;
						break;
				}//switch
                decl+= Aggregation.EmitDeclaration();
				return decl;
			}

			public string GetSelection(Expression []Expr, int NAudit){
                return Aggregation.GetSelection(Expr,NAudit);

			}
		}


		/// <summary>
		/// Compiles sqlcmd contained in square brackets [ ] with variables @varN reusing 
		///  eventually existing variables
		/// </summary>
		/// <param name="Expr">list of compiled variables</param>
		/// <param name="storedproc">instructions to add to stored procedure</param>
		/// <param name="sqlcmd">sqlcmd to compile</param>
		/// <param name="start">start position from which start the compilation</param>
		/// <returns>compiled sqlcmd</returns>
		static string compileExpressions(ref Hashtable Expr, ref ArrayList Aggregates,
			ref StringBuilder storedproc, 
			string sqlcmd,
			int start){
			int h=metaprofiler.StartTimer("CompileExpressions");
			//Compiles nested expressions

			//Checks for internal squear brackets
			int nextclosebracket = GetNextNonStringConst(sqlcmd,']',start);// sqlcmd.IndexOf(']',start);
				//GetNextUncommentedChar(sqlcmd,']',start);
			if (nextclosebracket==-1) {
				//MarkEvent("Unclosed [ in sqlcmd "+sqlcmd);
				metaprofiler.StopTimer(h);
				return sqlcmd.Substring(start);
			}
			int nextopenbracket = GetNextNonStringConst(sqlcmd,'[',start);//sqlcmd.IndexOf('[',start);
				//GetNextUncommentedChar(sqlcmd,'[',start);
			while ((nextopenbracket>=0) && (nextopenbracket< nextclosebracket)){
				sqlcmd= compileExpressions(ref Expr, ref Aggregates,
                    ref storedproc, sqlcmd, nextopenbracket+1).Trim();
				//Elimina la [ stando attento a non concatenare con un AND od un OR
				if (nextopenbracket>0){
					if (isIdentifier(sqlcmd[nextopenbracket-1])){
						sqlcmd = sqlcmd.Remove(nextopenbracket,1);
						sqlcmd = sqlcmd.Insert(nextopenbracket," ");
					}
					else {
						sqlcmd = sqlcmd.Remove(nextopenbracket,1);
					}
				}
				else {
					sqlcmd = sqlcmd.Remove(nextopenbracket,1);
				}
				nextclosebracket = GetNextNonStringConst(sqlcmd,']',start);//sqlcmd.IndexOf(']',start);
					//GetNextUncommentedChar(sqlcmd,']',start);
				if (nextclosebracket==-1) {
					//MarkEvent("Unclosed [ in sqlcmd "+sqlcmd);
					metaprofiler.StopTimer(h);
					return sqlcmd.Substring(start);
				}
				nextopenbracket = GetNextNonStringConst(sqlcmd,'[',start);//sqlcmd.IndexOf('[',start);
					//GetNextUncommentedChar(sqlcmd,'[',start);
			}
			//expression = string between brackets
			string expression= sqlcmd.Substring(start,nextclosebracket-start);
			int nextgraph=-1;
			int lentoremove=4;
			char kind = 'c';
			while (true){
				int pos= nextclosebracket+1;
				while (pos<sqlcmd.Length){
					if (sqlcmd[pos]==' ') {
						pos++;
						lentoremove++;
					}
					else break;
				}
				if (pos>=sqlcmd.Length) break;
				if (sqlcmd[pos].ToString()!="{") break;
				pos=pos+1;
				while (pos<sqlcmd.Length){
					if (sqlcmd[pos]==' ') {
						pos++;
						lentoremove++;
					}
					else break;
				}
				if (pos>=sqlcmd.Length) break;
				kind=Char.ToLower(sqlcmd[pos]);
				pos=pos+1;
				while (pos<sqlcmd.Length){
					if (sqlcmd[pos]==' ') {
						pos++;
						lentoremove++;
					}
					else break;
				}
				if (pos>=sqlcmd.Length) break;				
				if (sqlcmd[pos].ToString()!="}") break;
				nextgraph=1;
				break;
			}
			
			//check if after the close bracket there is an open graph bracket
			if (nextgraph>0) {
				//A variable must be declared to replace this expression
				//string kind= sqlcmd[nextclosebracket+2].ToString().ToLower(); //C/N/D

				//string normalized = NormalizeExpression(expression);
				//string normupper= normalized.ToUpper();

				string normupper= expression;
				normupper= Expression.NormalizeSELECT(normupper.Trim());


				Expression E= Expr[normupper]as Expression;
				if (E==null){
					//Adds declaration and evaluation of expression to sp code
					int nvar= Expr.Count+1;
					E = new Expression(normupper, Aggregates, kind,nvar);
					Expr[normupper]=E;
					//storedproc.Append(E.GetDeclaration());
					//storedproc.Append(E.GetSelection());
					//Substitutes expression with previously evaluated variable
				} //if (Expr[normalized]==null)		
				sqlcmd = sqlcmd.Remove(start, expression.Length+lentoremove);                
				if (start< sqlcmd.Length){
					if (isIdentifier(sqlcmd[start])){
						sqlcmd = sqlcmd.Insert(start, ' '+E.varRecall);
					}
					else {
						sqlcmd = sqlcmd.Insert(start,E.varRecall);
					}
				}
				else {
					sqlcmd = sqlcmd.Insert(start, E.varRecall);
				}

			}
			else {
				sqlcmd = sqlcmd.Remove(start, expression.Length+1);
				if (start< sqlcmd.Length){
					if (isIdentifier(sqlcmd[start])){
						sqlcmd = sqlcmd.Insert(start, ' '+expression);
					}
					else {
						sqlcmd = sqlcmd.Insert(start,expression);
					}
				}
				else {
					sqlcmd = sqlcmd.Insert(start, expression);
				}
			}
			metaprofiler.StopTimer(h);
			return sqlcmd;
		}



		static void markEvent(string e){
            string msg = DateTime.Now.ToString("HH:mm: ss.fffffff") + ":"+e;
            Debug.WriteLine(msg);
			Debug.Flush();
		}


		static string mainAuditSqlCmd(string expression, int auditindex,int NChecks){
			if (expression.Trim()==""){
				return "-- No expressions for check "+auditindex+"."+anewline;
			}
			return "if NOT("+expression+")"+anewline+getVariableSet(auditindex,NChecks);
		}
        
		static string DropSPCommand(DataAccess Conn, string tablename, string opname, bool PreCheck){
			string spname;
			int h= metaprofiler.StartTimer("DropSPCommand");
			if (PreCheck)
                spname = EasyRowChange.sp_prefix+ tablename + "_" + opname.ToLower() + "_pre";
			else
                spname = EasyRowChange.sp_prefix  + tablename + "_" + opname.ToLower() + "_post";

			object existsp =  Conn.DO_SYS_CMD(
				"select count(*) from sysobjects where id = object_id("+
				"'"+spname+"') and OBJECTPROPERTY(id, 'IsProcedure') = 1 and uid=user_id()");
			if ((existsp==DBNull.Value)||(existsp==null)) existsp=0;
			int nexist= Convert.ToInt32(existsp);
			string res=null;
			if (nexist==1) 	res="DROP PROCEDURE "+spname;
			metaprofiler.StopTimer(h);
			return res;

		}

		static string getTypeforSysVar(string sys){
			if (sys=="sys_esercizio") return "smallint";
            if (sys == "sys_datacontabile") return "date";
            //	if (sys=="sys_expensemaxphase") return "char(1)";
			if (sys=="sys_maxexpensephase") return"tinyint";
            if (sys == "sys_maxincomephase") return "tinyint";
            if (sys == "sys_itinerationphase") return "tinyint";
            if (sys == "sys_mandatephase") return "tinyint";
            if (sys == "sys_invoiceexpensephase") return "tinyint";
            if (sys == "sys_invoiceincomephase") return "tinyint";
            if (sys == "sys_expensefinphase") return "tinyint";
            if (sys == "sys_expenseregphase") return "tinyint";
            //if (sys == "sys_expenseresfundphase") return "tinyint";
            //if (sys == "sys_expensemultiphase") return "tinyint";
            if (sys == "sys_incomefinphase") return "tinyint";
            if (sys == "sys_incomeregphase") return "tinyint";
            //if (sys == "sys_incomeresfundphase") return "tinyint";
            //if (sys == "sys_incomemultiphase") return "tinyint";
            if (sys == "sys_appropriationphase") return "tinyint";
            if (sys == "sys_assessmentphase") return "tinyint";		
			if (sys=="sys_userdb") return "varchar(30)";
			if (sys=="sys_idcustomuser") return "varchar(30)";
            if (sys == "sys_idflowchart") return "varchar(34)";
            return "varchar(100)";
			//return "UNKNOWN!!";
		}


		static string getOutputVarDeclaration(int NCheck){
			if (NCheck<=14) return "@res SMALLINT OUT";
			if (NCheck<=30) return "@res INT OUT";
			if (NCheck<=62) return "@res BIGINT OUT";
			return "@res VARCHAR("+NCheck+") OUT";
		}

		static string getResetOutputVar(int NCheck){
			if (NCheck<=62) return "SET @res=0"+anewline;
			string S="";
			return "SET @res='"+S.PadRight(NCheck,'0')+"'"+anewline;
		}

		static string getVariableSet(int index, int NChecks){
            //index è a base zero
			if (NChecks<=62) {
				Int64 X = ((Int64)1)<<index;
				string XX= X.ToString("x");
				return "SET @res=@res +0x"+ XX+anewline;
			}
			if (index==0){
				return "SET @res = '1'+substring(@res,2,"+(NChecks-1)+")"+anewline;
			}
			else {
				int prec=index; //sarebbe come index-1 visto che prec è a base 1
				int succ=index+2;  //sarebbe come index+1 visto che succ è a base 1

                if (NChecks - index - 1 > 0) {
                    return "SET @res=substring(@res,1," + prec.ToString() + ")+'1'+substring(@res," +
                        succ.ToString() + "," + (NChecks - index - 1) + ")" + anewline;
                }
                else {
                    return "SET @res=substring(@res,1," + prec.ToString() + ")+'1'" + anewline;

                }

			}



		}
        public static string GetSqlResetVar(string varname, int NCheck) {
            if (NCheck <= 62) return "set " + varname + "=0;";
            return "set " + varname + "='';";

        }
        public static string GetSqlParameterVarPrefixForResult(int NCheck) {
            if (NCheck <= 14) {
                return "s";
            }
            if (NCheck <= 30) {
                return "i";
            }
            if (NCheck <= 62) {
                return "b";
            }
            return "c";
        }

        public static string GetSqlParameterTypeNameForResult(int NCheck) {
            if (NCheck <= 14) {
                return "smallint";
            }
            if (NCheck <= 30) {
                return "int";
            }
            if (NCheck <= 62) {
                return "bigint";
            }
            return "varchar("+NCheck.ToString()+")";
        }

		public static SqlParameter GetSqlParameterForResult(int NCheck){
			if (NCheck<=14) {
				SqlParameter SQ = new SqlParameter("@res",SqlDbType.SmallInt);
				return SQ;
			}
			if (NCheck<=30) {
				SqlParameter SQ = new SqlParameter("@res",SqlDbType.Int);
				return SQ;
			}
			if (NCheck<=62) {
				SqlParameter SQ = new SqlParameter("@res",SqlDbType.BigInt);
				return SQ;
			}
			return new SqlParameter("@res",SqlDbType.VarChar,NCheck);
		}

		public static bool[] Serialize(object temp_result,int NCheck){
			bool[] res= new bool[NCheck];
			int index=0;
			if (NCheck<=30){
				int P1= Convert.ToInt32(temp_result);
				for (int i=0;i<NCheck;i++) {
					res[index] =  ((P1 & 1)!=0);
					P1 = P1>>1;
					index++;
				}
				return res;
			}
			if (NCheck<=62){
				Int64 P2= Convert.ToInt64(temp_result);
				for (int i=0;i<NCheck;i++) {
					res[index] =  ((P2 & 1)!=0);
					P2 = P2>>1;
					index++;
				}
				return res;
			}
			string result= temp_result.ToString();
			for (int i=0; i<NCheck;i++){
				if (result[i]=='1')
					res[i]=true;
				else
					res[i]=false;
			}
			return res;
		}

		static string getSPHeader(DataAccess Conn,string tablename, string opname, DataTable Parameters,
				bool PreCheck,int NCheck){
			int h= metaprofiler.StartTimer("GetSPHeader");
			string spname;
			if (PreCheck)
                spname = EasyRowChange.sp_prefix + tablename + "_" + opname.ToLower() + "_pre";
			else
                spname = EasyRowChange.sp_prefix + tablename + "_" + opname.ToLower() + "_post";

			object existsp =  Conn.DO_SYS_CMD(
				"select count(*) from sysobjects where id = object_id("+
				"'"+spname+"') and OBJECTPROPERTY(id, 'IsProcedure') = 1 and uid=user_id()");
			if ((existsp==DBNull.Value)||(existsp==null)) existsp=0;
			int nexist= Convert.ToInt32(existsp);
			string res="";
			if (nexist==0) 
				res="CREATE PROCEDURE ";
			else
				res="ALTER PROCEDURE ";
			res +=	spname+" "+getOutputVarDeclaration(NCheck);
			//"@result varchar(100) OUT";

			//			bool firstpar=true;
			//			string parameterfilter="(tablename in (";
			//			foreach(DataRow Par in Parameters.Rows){
			//				if (Par.RowState== DataRowState.Deleted) continue;
			//				string partable = "'"+Par["paramtable"].ToString()+"'";
			//				if (parameterfilter.IndexOf(partable)!=-1) continue;
			//				if (!firstpar) {
			//					parameterfilter+=",";
			//				}
			//				firstpar=false;
			//				parameterfilter+=partable;
			//			}
			//			parameterfilter+="))";

			//			DataTable ParamType = Conn.RUN_SELECT("columntypes","*",
			//						null,parameterfilter,null,true);

			
			//Adds newvalue parameter declaration
			int nnew=0;
			int nold=0;
			
			foreach (DataRow Par in Parameters.Select(null,"parameterid")){
				string parcol=Par["paramcolumn"].ToString();
				string partab=Par["paramtable"].ToString().ToLower();

				if (partab.ToLower()=="sys"){
					string svar = "@";
					if (!parcol.StartsWith("sys_")) svar+="sys_";
					svar+=parcol;
					res+=", "+svar+" ";
					res+= getTypeforSysVar(parcol);
					continue;
				}

				dbstructure DBS= Conn.GetStructure(partab);

				if (Par["flagoldvalue"].ToString().ToUpper()=="N"){
					string newvar= "@NEW";
					if (partab!=tablename) newvar+="_"+partab;
					newvar+= "_"+parcol;
					DataRow []foundnew = DBS.columntypes.Select("(field='"+parcol+"')");
					if (foundnew.Length==0){
						res+=", "+newvar+" varchar(255)";
						markEvent("Undefined field type ("+ partab.ToString()+"."+parcol.ToString()+") in "+ spname+ ".");
					}
					else {
						res+=", "+newvar+" "+foundnew[0]["sqldeclaration"].ToString();
					}
					nnew++;
				}
				else {
					string oldvar= "@OLD";
					if (partab!=tablename) oldvar+="_"+partab;
					oldvar+= "_"+parcol;
					DataRow []foundold = DBS.columntypes.Select("(field='"+parcol+"')");
					if (foundold.Length==0){
						res+=", "+oldvar+" varchar(255)";
						markEvent("Undefined field type ("+ partab.ToString()+parcol.ToString()+").");
					}
					else {
						res+=", "+oldvar+" "+foundold[0]["sqldeclaration"].ToString();
					}
					nold++;
				}
				res+="=null";
			}
						

			res+=" AS "+anewline;
			res+="BEGIN"+anewline;
            res += " SET NOCOUNT ON" + anewline;
			res+="-- LAST MODIFIED: "+DateTime.Now.ToShortDateString()+"  "+DateTime.Now.ToShortTimeString()+anewline;
			res+="--"+anewline;
			res+= getResetOutputVar(NCheck);
			//"SET @result = '0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'"
			//	+anewline;
			metaprofiler.StopTimer(h);
			return res;
		}


		static string getSPFooter(){
			return "END"+anewline;
		}



		class AuditSegment {
			public int Weight;
			public string sql;
			public ArrayList vars;
			public AuditSegment(string sql){
				this.sql=sql;
				vars= new ArrayList();
				CalcolaVars();
				Weight=0;
			}
			void CalcolaVars(){
				int nextvar=sql.IndexOf("@v");
				while (nextvar>=0){
                    int varlen = 2;
                    string nvar = sql.Substring(nextvar + 2, varlen);
                    if (sql.Length > nextvar + 2 + varlen && Char.IsDigit(sql[nextvar + 2 + varlen])) {
                        nvar += sql[nextvar + 2 + varlen];
                        varlen = 3;
                    }
					int N= Convert.ToInt32(nvar);
					if (vars.IndexOf(N)<0)vars.Add(N);
					nextvar= sql.IndexOf("@v",nextvar+2);
				}
			}
		}


		class AuditCheck{
			public int auditindex;
			public string idaudit;
			public string idcheck;
			public string message;
			public string sql;
			public ArrayList Segments;
			public AuditCheck(int auditindex,string idaudit, string idcheck, string message,string sql){
				this.auditindex=auditindex;
				this.idaudit=idaudit;
				this.idcheck=idcheck;
				this.message=message;
				this.sql=sql.ToLower();
				this.Segments= new ArrayList();
				calcolaSegmenti();
			}

			int findNextOR(string sql,int start){
				if (start>=sql.Length)return -1;
				int nextOR = sql.IndexOf("or",start);
				while (nextOR >0){
					char C=sql[nextOR-1];
					if (EasyAudits.isIdentifier(C)){
						nextOR= sql.IndexOf("or",nextOR+1);
						continue;
					}
					break;
				}
				return nextOR;
			}

			//Scompone l'audit in una sequenza di segmenti, tali che audit = segmento1 or segmento2 or ... 
			void calcolaSegmenti(){
				int hCalcSeg=metaprofiler.StartTimer("CalcolaSegmenti");
				int start=0;
				int startsearch=start;
				while (true){
					int nextOR = findNextOR(sql,startsearch);
					if (nextOR<0){//non ci sono più OR --> prende tutto il rimanente
						string segmento=sql.Substring(start);
						Segments.Add(new AuditSegment(segmento));
						metaprofiler.StopTimer(hCalcSeg);
						return;
					}
					int nextOpenPar = sql.IndexOf('(',startsearch);
					int nextClosePar= -1;
					if (nextOpenPar>=0) nextClosePar= StringParser.closeBlock(sql,nextOpenPar+1,'(',')');
					//Se la par. si chiude prima dell'OR, cerca la successiva aperta e la relativa chiusura
					// fino a trovare l'ultima chiusura di par. prima dell'OR
					while ((nextOpenPar>=0) && (nextOpenPar<nextOR)&&
							(nextClosePar>=0) && (nextClosePar<nextOR)
						){
						nextOpenPar= sql.IndexOf('(',nextClosePar+1);
						if (nextOpenPar>=0) nextClosePar= StringParser.closeBlock(sql,nextOpenPar+1,'(',')');
					}
					if ((nextOpenPar<0)||(nextOpenPar>nextOR)||
						    (nextClosePar<=nextOR)
						){ 
						//l'OR è prima della "(" o non vi sono "(" --> prende fino all'OR
						string segmento=sql.Substring(start,nextOR-start);
						Segments.Add(new AuditSegment(segmento));
						start=nextOR+2;
						startsearch=start;
						continue;
					}
					//Altrimenti vuol dire che l'OR trovato è tra parentesi!
					//Quindi cerca il prossimo OR fuori dalle parentesi.
					startsearch= nextClosePar+1; 				
				}


			}


			public string GetHeader(){
				string header="";
				header+= anewline;
				header+= anewline;
				//header+="----------------------------------------------------------------"+anewline;
				header+="-- idcheck: "+ stripNewLines(idcheck)+anewline;
				header+="-- idaudit: " + stripNewLines(idaudit)+anewline;
				header+="-- Message: "+stripNewLines(message)+anewline;
				//header+="----------------------------------------------------------------"+anewline;
				return header;
			}


			public string GetStatement(Expression []Expr,int totchecks){
				StringBuilder SB= new StringBuilder();
				SB.Append(GetHeader());

				string labelaudit= "end_check_"+auditindex.ToString();
				int nseg=Segments.Count;
				for (int i=0; i<nseg; i++){
					AuditSegment A = Segments[i] as AuditSegment;
					//SB.Append("-- Segment "+(i+1)+" (Weight "+A.Weight+")"+anewline);
					//emette 
					//get variabili segmento
					foreach (int nvar in A.vars){
						Expression E=Expr[nvar];
						SB.Append(E.GetSelection(Expr,auditindex));
					}
					//if (expr. segmento) GOTO dopo_audit
					if (i<nseg-1){
						SB.Append( "if ("+A.sql+")GOTO "+labelaudit+anewline);
					}
					else {
						SB.Append( "if not("+A.sql+")");
						SB.Append(getVariableSet(auditindex-1,totchecks));
					}
				}
				//dopo_audit: SET
				if (nseg>1){
					SB.Append(labelaudit+":"+anewline);
					SB.Append(anewline);
				}
				return SB.ToString();
			}
			
		}


        public const bool FILTRA_CFG_ANNUALE = true;
		/// <summary>
		/// Calcola il testo della stored procedure per una regola e la tabella dei
		///  parametri da mettere nella table parameter
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="table"></param>
		/// <param name="op"></param>
		/// <returns></returns>
		public static string GetAuditForOperation(DataAccess Conn, 
			string tablename, 
			string opname, 
			out DataTable Parameters,
			bool PreCheck, string filtercheck
			){
			VistaEasyAudits CR = new VistaEasyAudits();
			ClearDataSet.RemoveConstraints(CR);
			Parameters= CR.auditparameter;
			DataTable auditcheck = CR.auditcheckview;
			Hashtable Substitutions;

			int hh=metaprofiler.StartTimer("SELECT from auditcheck");
			//Ottiene la lista dei controlli da includere nella regola in auditcheck
            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.AppAnd(QHS.CmpEq("tablename", tablename),QHS.CmpEq("opkind", opname), 
                                    QHS.IsNotNull("sqlcmd"), QHS.CmpNe("severity", "I"));
                
			//Non filtra più la configurazione annuale  >> ora filtra di nuovo in base al flag
            if (FILTRA_CFG_ANNUALE) filter= GetData.MergeFilters(filter,filtercheck);

			if (PreCheck) 
				filter= QHS.AppAnd(filter,QHS.CmpEq("precheck","S"));
			else 
				filter= QHS.AppAnd(filter,QHS.CmpEq("precheck","N"));


			if (Conn.LocalToDB){
				Conn.RUN_SELECT_INTO_TABLE(auditcheck,"idaudit ASC, idcheck ASC", 
					filter, null, true);
			}
			else {
				DataAccess.RUN_SELECT_INTO_TABLE(Conn,auditcheck,"idaudit ASC, idcheck ASC", 
					filter, null, true);
			}
			metaprofiler.StopTimer(hh);
			hh=metaprofiler.StartTimer("SELECT from Parameters");

            filter = QHS.AppAnd(QHS.CmpEq("tablename", tablename), QHS.CmpEq("opkind", opname));
            if (PreCheck)
                filter = QHS.AppAnd(filter, QHS.CmpEq("isprecheck", "S"));
            else
                filter = QHS.AppAnd(filter, QHS.CmpEq("isprecheck", "N"));

			if (Conn.LocalToDB){
				Conn.RUN_SELECT_INTO_TABLE(Parameters,null,filter,null,true);
			}
			else {
				DataAccess.RUN_SELECT_INTO_TABLE(Conn,Parameters,null,filter,null,true);
			}
			metaprofiler.StopTimer(hh);

			//Calcola la lista dei parametri di input della stored procedure risultante
			// e compila i messaggi con i nomi dei parametri  
            // Nota: questi non dipendono, stranamente, dalla cfg. annuale
			EvaluateParameters(Conn, CR, tablename, opname, out Substitutions,PreCheck);

			int NChecks=auditcheck.Rows.Count;
			if (NChecks==0){
				return    DropSPCommand(Conn,tablename,opname, PreCheck);
			}

			StringBuilder storedproc = new StringBuilder(3000);
			storedproc.Append( getSPHeader(Conn,tablename,opname, Parameters,PreCheck,NChecks));

			
			Hashtable Expr = new Hashtable();
			AuditCheck []AuditChecks= new AuditCheck[NChecks];
            ArrayList Aggregates = new ArrayList();

			for(int auditindex=0; auditindex<NChecks; auditindex++ ){
				DataRow audit=auditcheck.Rows[auditindex];
				string sqlcmd= audit["sqlcmd"].ToString();
				if (sqlcmd.ToLower().StartsWith("--skip")){
					continue;
				}
				sqlcmd= Compact(sqlcmd).ToLower();
				//sqlcmd= StripComments(sqlcmd);
				//sqlcmd= sqlcmd.Replace("%<esercizio>%","%<sys_esercizio>%");
				//sqlcmd= sqlcmd.Replace("!=","<>");
				string sql= compileExpressions(ref Expr, ref Aggregates, ref storedproc, sqlcmd, 0);

				AuditCheck AC = new AuditCheck(auditindex+1,audit["idaudit"].ToString(),
					audit["idcheck"].ToString(),audit["message"].ToString(),sql);
				AuditChecks[auditindex]= AC;
				
				//storedproc.Append(AC.GetHeader());
				//storedproc.Append( MainAuditSqlCmd(sql, auditindex,NChecks));
				//auditindex++;
			}
			storedproc.Append(getOptimizedSp(AuditChecks, Expr).ToString());

			CR.auditcheckview.AcceptChanges();
			CR.audit.AcceptChanges();
			CR.tableop.AcceptChanges();
			storedproc.Append( getSPFooter());
			return storedproc.ToString();
		}



		static void setForced(Expression [] Expr, int num){
			Expression E = Expr[num];
			E.SetForced(Expr);
            //E.Weight = 0;
			//E.Weight= E.expr.Length;
			//foreach( int Nexpr in E.VarsLinked) SetForced(Expr, Nexpr);
		}
		static StringBuilder getOptimizedSp(AuditCheck[] Audits, Hashtable Vars){
			int hGetOpt= metaprofiler.StartTimer("GetOptimizedSp");
			StringBuilder SB= new StringBuilder();

			//Ottiene un array di variabili a partire dall'hashtable, per una migliore accessibilità.
			int nvars= Vars.Count;
			Expression [] Expr = new Expression[nvars+1]; //Elenco delle espressioni
			foreach (string k in Vars.Keys){
				Expression E = Vars[k] as Expression;
				Expr[E.Number]=E;
			}

			//Come prima cosa, se un audit è fatto da un solo segmento, le variabili di quel segmento sono
			// necessariamente da calcolare. Infatti non è possibile alcuna ottimizzazione in questo caso.
			// Dunque, il peso di tali variabili e di quelle dipendenti è assegnato a 0.
			foreach(AuditCheck A in Audits){
				if (A.Segments.Count==1){
					AuditSegment AS = A.Segments[0] as AuditSegment;
					foreach( int Nexpr in AS.vars) setForced(Expr, Nexpr);
				}
			}

			//Calcola i pesi delle variabili sommando ad ognuna i pesi delle var. collegate.
			for(int i=1; i<= nvars; i++){
				Expression E = Expr[i];
				if (E.forced) continue;
				int weight= E.Weight;
				foreach (int varindex in E.VarsLinked){
					weight+= Expr[varindex].Weight;
				}
				E.Weight=weight;
			}

			//Calcola ora i pesi di ogni segmento come somma dei pesi delle var. collegate
			foreach(AuditCheck A in Audits){
				if (A.Segments.Count==1){
                    AuditSegment A1 = A.Segments[0] as AuditSegment;
                    foreach (int nexpr in A1.vars) {
                        Expression E = Expr[nexpr];
                        E.AddCheck(Expr, A);                        
                    }
                    A1.Weight = 0;
					continue; //il peso di tali segmenti è minimo per definizione (un solo elem.!)
				}
				foreach(AuditSegment AU in A.Segments){
					if (AU.vars.Count==0){
						AU.Weight= AU.sql.Length;
					}
					else {
						int weight=0; //AU.sql.Length;
						foreach(int nexpr in AU.vars){
							Expression E= Expr[nexpr];
							weight+= E.Weight;
							E.AddCheck(Expr, A);
						}						
						AU.Weight=weight;
					}
				}
				//Ordina i segmenti in base al peso e lo mette in L
				ArrayList L= new ArrayList();
				foreach (AuditSegment AS in A.Segments){
					int i=0;
					while ((i<L.Count) && ((AuditSegment)L[i]).Weight<AS.Weight)i++;
					L.Insert(i,AS);
				}
				A.Segments=L;
				AuditSegment First = A.Segments[0] as AuditSegment;
				//Le espressioni dei primi segmenti sono comunque da considerarsi forced
				foreach( int Nexpr in First.vars) setForced(Expr, Nexpr);

			}


			//Inizia ad emettere la lettura di tutte le espressioni con peso 0, ossia quelle forzate
			// e la dichiarazione di quelle non forzate
			foreach(Expression E in Expr){
				if (E==null) continue;
				if (E.forced){
					SB.Append(E.GetDeclaration());
					SB.Append(E.GetSelection(Expr,-1));
				}
				else {
					SB.Append(E.GetDeclaration());
				}
			}

			foreach (AuditCheck AU in Audits){
				SB.Append(AU.GetStatement(Expr,Audits.Length));
			}
			metaprofiler.StopTimer(hGetOpt);
			return SB;
		}

		static string stripNewLines(string S){
			S = S.Replace("\n","");
			S = S.Replace("\r","");
			return S;
		}

	    public static bool myExternalUpdateDelegate(DataSet D, out string ErrMsg) {
            ErrMsg = null;
            string sqlcmd = D.ExtendedProperties["sqlCmd"] as string;
            if (sqlcmd == null) return true;
	        DataAccess Conn = D.ExtendedProperties["Conn"] as DataAccess;
            DataTable O;
            if (sqlcmd != null) {
                O = Conn.SQLRunner(sqlcmd,true);
                if (O == null) {                    
                    ErrMsg= Conn.LastError;
                    return false;
                }
            }            
            return true;
        }

        public static string RecalcAudit(DataAccess Conn, string tablename, string OpName,string filtercheck){
            //Non filtrare i controlli in base alla con
            //filtercheck = Conn.GetSys("filterrule").ToString();

			string resmsg="Errore ricompilando le regole.";
			try {
                
				DataTable Parameters;				
				string sqlcmd = EasyAudits.GetAuditForOperation(Conn, tablename, OpName,out Parameters,true,filtercheck);
                PostData.RemoveFalseUpdates(Parameters.DataSet);
                if (!Parameters.DataSet.HasChanges()) {
                    if (sqlcmd != null) {
                        object r = Conn.SQLRunner(sqlcmd, true);
                        if (r == null) {
                            return Conn.LastError;                            
                        }
                    }
                }
                else {
                     //Easy_PostData CP = new Easy_PostData();
                    PostData CP = new PostData();
                    CP.initClass(Parameters.DataSet, Conn);
                    Parameters.DataSet.ExtendedProperties["sqlCmd"] = sqlcmd;
                    Parameters.DataSet.ExtendedProperties["Conn"] = Conn;
                    CP.DoExternalUpdate += myExternalUpdateDelegate;
                    ProcedureMessageCollection MC = null;
                    while ((MC == null) ||
                        ((MC != null) && MC.CanIgnore && (MC.Count > 0))) {
                        MC = CP.DO_POST_SERVICE();
                    }
                    if (MC.Count > 0) {
                        return resmsg;
                    }
                }

				


				sqlcmd = GetAuditForOperation(Conn, tablename, OpName, out Parameters,false,filtercheck);
                PostData.RemoveFalseUpdates(Parameters.DataSet);
                if (!Parameters.DataSet.HasChanges()) {
                    if (sqlcmd != null) {
                        object r = Conn.SQLRunner(sqlcmd, true);
                        if (r == null) {
                            return Conn.LastError;
                        }
                    }
                }
                else {
                    //CP = new Easy_PostData();
                    var CP = new PostData();
                    CP.initClass(Parameters.DataSet, Conn);
                    Parameters.DataSet.ExtendedProperties["sqlCmd"] = sqlcmd;
                    Parameters.DataSet.ExtendedProperties["Conn"] = Conn;
                    CP.DoExternalUpdate += myExternalUpdateDelegate;
                    ProcedureMessageCollection MC = null;
                    while ((MC == null) ||
                        ( MC.CanIgnore && (MC.Count > 0))) {
                        MC = CP.DO_POST_SERVICE();
                    }
                    if (MC.Count > 0) {
                        return resmsg;
                    }
                }
			
			}
			catch (Exception E) {
				return E.Message;
			}
			return null;
			
		}



		#endregion

		#region Calcolo dei messaggi relativi ad una chiamata ad una sp
		/// <summary>
		/// Evaluates all error messages that can appear for all changes to be made.
		/// </summary>
		public void DO_CALC_MESSAGES(QueryHelper QHS, RowChange R, bool[] result,bool Post){

            int nn = metaprofiler.StartTimer("DO_CALC_MESSAGES()");
			// For a Change to commit, evaluates all result-given auditcheck message
			R.EnforcementMessages= new EasyProcedureMessageCollection();

			String Filter = R.FilterPostTableOp()+ "AND(sqlcmd IS NOT NULL) and (severity<>'I')";				
			if (!Post) 
				Filter+="AND(precheck='S')"; 
			else 
				Filter+="AND(precheck='N')"; 


			if (Enforcement.Select(Filter).Length==0)
			    Conn.RUN_SELECT_INTO_TABLE(Enforcement, null, Filter, null,true);


            //In Enforcement gli auditcheck ci sono tutti, anche quelli non applicabili per via della configurazione
            Hashtable found= new Hashtable();

            if (FILTRA_CFG_ANNUALE && Conn.Security.GetSys("filterrule")!=null) {
                Filter = GetData.MergeFilters(Filter, Conn.Security.GetSys("filterrule").ToString());
            }
            else {
                string filter_local = GetData.MergeFilters(Filter, Conn.Security.GetSys("filterrule")?.ToString());
                foreach (DataRow Rfound in Enforcement.Select(filter_local)) {
                    string key = Rfound["idaudit"].ToString() + "#" + Rfound["idcheck"].ToString();
                    found[key] = "S";
                }
            }
            //Adesso Enforcements contiene TUTTI I check relativi all'operazione, non esclude più quelli inapplicabili per via della cfg
			DataRow[] Enforcements = Enforcement.Select(Filter,"idaudit ASC, idcheck ASC");

            CQueryHelper QHC = new CQueryHelper();
			for (int i=0; i<result.Length; i++){
				if (result[i]){
                    DataRow Enforce = Enforcements[i];
#pragma warning disable CS0162 //Unreacheable code detected
                    if (FILTRA_CFG_ANNUALE == false) {
                        string key = Enforce["idaudit"].ToString() + "#" + Enforce["idcheck"].ToString();
                        if (!found.ContainsKey(key)) continue; //non compila il messaggio di questo check, non è applicabile quest'anno
                    }
#pragma warning restore CS0162 //Unreacheable code detected

                    if (Business.Select(QHC.CmpEq("idaudit", Enforce["idaudit"])).Length == 0) {
                        Conn.RUN_SELECT_INTO_TABLE(Business, null, QHS.CmpEq("idaudit", Enforce["idaudit"]), null, true);
                    }
					
					//Create Message
					String auditID     = Enforce["idaudit"].ToString();
					int enforcementID = Convert.ToInt32(Enforce["idcheck"].ToString());
					String message = Enforce["message"].ToString();
					EasyProcedureMessage Msg = new EasyProcedureMessage(QHS, R, 
						auditID, enforcementID,
						message,Convert.ToInt32(Conn.Security.GetSys("esercizio")), this, Conn);
					if (Msg.Enabled){
						R.EnforcementMessages.Add(Msg);
					}
				}
			}

            metaprofiler.StopTimer(nn);
		}

		#endregion


	}

    public class onesubst {
        /// <summary>
        /// When true, substitition is wrong
        /// </summary>
        public bool error = false;

        /// <summary>
        /// tabella presente nelle parentesi angolari
        /// </summary>
        public string original;

        /// <summary>
        /// tabella principale del messaggio, ossia quella della regola
        /// </summary>
        public string tablename;
        public string field;
        public List<string> query=new List<string>();
        public List<string> cquery = new List<string>();
        public string newval;

        /// <summary>
        /// nome della tabella principale nel dataset
        /// </summary>
        public string fromtable;

        public List<string> querycols = new List<string>();
        public DataTable Data;
    }

	#region Compilazione dei MESSAGGI dei check 
	/// <summary>
	/// A single message of error/warning about a change in a DataRow
	/// </summary>
	public class EasyProcedureMessage : ProcedureMessage {
		public bool Enabled;
		public String ShortMess;
		public String Operation; //Update/Insert/Delete
		public String TableName;
		public String ErrorType; //Avvertimento / Errore
		public String AuditID;     //ex. FIN 000074 - indexes table audit 
		public String EnforcementNumber;  //ex. 0001 - indexes  auditcheck coupled with AuditName
		public bool flagsystem;
		public RowChange Related;
		public ArrayList OpenSubstitutions;
		const string NullParameter = ""; //"null";
		CQueryHelper QHC;
		QueryHelper QHS;

		static string FindPostingColumn(DataTable T, string ColForPosting) {
			foreach (DataColumn C in T.Columns) {
				if (QueryCreator.PostingColumnName(C) == ColForPosting)
					return C.ColumnName;
			}
			if (!T.Columns.Contains(ColForPosting))
				return null;
			if (QueryCreator.PostingColumnName(T.Columns[ColForPosting]) != null)
				return null;
			return ColForPosting;
		}

		string GetParameter(DataRow FocusedRow, string colname, string msgtable, string fromtable) {
			if (FocusedRow == null)
				return NullParameter;
			string ColFound = FindPostingColumn(FocusedRow.Table, colname);
			if (ColFound != null) {
				DataRowVersion ToConsider = DataRowVersion.Current;
				if (FocusedRow.RowState == DataRowState.Deleted)
					ToConsider = DataRowVersion.Original;
				if (FocusedRow.RowState == DataRowState.Detached)
					return "";
				return FocusedRow[ColFound, ToConsider].ToString();
			}

			onesubst O = new onesubst();
			O.field = colname;
			O.tablename = msgtable;
			O.original = "%<" + O.tablename + "." + O.field + ">%";
			O.fromtable = fromtable;
			OpenSubstitutions.Add(O);
			return O.original;

			/*
			string warn = " --- Warning: ("+FocusedRow.Table.TableName+")."+colname+" is missing! --- ";
			MarkEvent(warn);
			
			DataRow TryParent=null;
			int found=0;
			//Field does not belong to table, so tries in parent tables
			try {
				bool toredelete=false;
				if (FocusedRow.RowState == DataRowState.Deleted){
					//undelete the row to get access to the relations!
					FocusedRow.RejectChanges();
					toredelete=true;
				}
						
				foreach(DataRelation RParent in FocusedRow.Table.ParentRelations){
					string ParColFound = FindPostingColumn(RParent.ParentTable,colname);
					if (ParColFound==null)continue;
					DataRow[] FoundList = FocusedRow.GetParentRows(RParent);
					if (FoundList.Length==0) continue;
					TryParent= FoundList[0];
					found+= FoundList.Length;
				}

				if (toredelete){
					FocusedRow.Delete();
				}
				return GetParameter(TryParent,colname);
			}
			catch {
				return warn;
			}

            */
		}

		public override string GetKey() {
			string pre_post = PostMsgs ? "post" : "pre";
			return $"{TableName}/{pre_post}/{Operation}/{AuditID}/{EnforcementNumber} {LongMess}"; //RuleID + "@@@"  + EnforcementNumber;
		}
		/// <summary>Translate a Parameter name into a value, taking data from A and related.</summary>
		/// <param name="C"> RowChange to consider</param>
		/// <param name="EsercizioSessione" >Implicit parameter "Esercizio"</param>
		/// <param name="Parameter">Parameter to compile</param>
		/// <returns>Compiled Parameter</returns>
		String CompileParameter(RowChange C, int EsercizioSessione, String Parameter, IDataAccess Conn) {
			Parameter = Parameter.Trim();
			int DotPosition = Parameter.IndexOf(".");
			string TableName;
			if (DotPosition >= 0) {
				TableName = Parameter.Substring(0, DotPosition);
			}
			else {
				TableName = C.TableName;
			}

			foreach (DataColumn Col in C.Table.Columns) {
				if (QueryCreator.GetExpression(Col) == Parameter) {
					return GetParameter(C.DR, Col.ColumnName, TableName, C.TableName);
				}
			}

			//Checks if the parameter is in the form
			//    tablename.columnname
			// or columnname
			if (DotPosition >= 0) {
				//parameter like "tablename.columnname"
				String ColumnName = Parameter.Substring(DotPosition + 1);

				DataRow R = C.GetRelated(TableName);
			
				if (R == null) {
					    
					    DataRow R1 = C.GetSecondaryRelatedParent(TableName);
					if (R1 == null) {

						DataRow R2 = C.GetThirdRelatedParent(TableName);

						if (R2 == null) {
							onesubst O = new onesubst();
							O.field = ColumnName;
							O.original = "%<" + Parameter + ">%";
							O.tablename = TableName;
							O.fromtable = C.TableName;
							OpenSubstitutions.Add(O);
							return O.original;
						}
						return GetParameter(R2, ColumnName, TableName, C.TableName);
					}
					return GetParameter(R1, ColumnName, TableName, C.TableName);
				}
					 
				return GetParameter(R, ColumnName, TableName, C.TableName);
			}
			else {
				//parameter like "columname"
				String ColumnName = Parameter;
				if (ColumnName.Equals("ayear"))
					return EsercizioSessione.ToString();
				if (ColumnName.Equals("esercizio"))
					return EsercizioSessione.ToString();

				object O;
				if (ColumnName.ToString().ToLower().StartsWith("sys_")) {
					string colname = ColumnName.ToString().ToLower();
					O = Conn.Security.GetSys(colname.Substring(4));


					if (O == null)
						return "";
					if (O is DateTime) {
						// L'oggetto è un DateTime
						return $"{O:dd-MM-yyyy}";
					}
					else
						return O.ToString();
				}
			}

			return GetParameter(C.DR, Parameter, TableName, C.TableName);
			 

		}
    
		void MarkEvent(string e){			
			string msg = QueryCreator.unquotedstrvalue(DateTime.Now,false)+"\r";
			Debug.Write(e+" at ",msg);
			Debug.Flush();
		}
        
                
		/// <summary>
		/// Creates an error/warning message compiling messages stored in auditcheck 
		/// </summary>
		/// <param name="C">Single DataRow Change considered, with Related compiled</param>
		/// <param name="AuditID">Business Audit to consider (= auditID column of audit and auditcheck table)</param>
		/// <param name="EnforcementID">Audit Enforcement to consider (= enforcementID column of auditcheck table)</param>
		/// <param name="Conn" >Connection to Easy DataBase</param>
		public EasyProcedureMessage(
            QueryHelper QHS,
            RowChange C,  
			String AuditID, int EnforcementNumber,
			String ToCompile, int EsercizioSessione, EasyAudits Audits,
			IDataAccess Conn){
            OpenSubstitutions = new ArrayList();
            this.QHS = QHS;
            QHC = new CQueryHelper();

			this.AuditID = AuditID;
			this.EnforcementNumber= EnforcementNumber.ToString();
            Related = C;

			TableName       =   C.TableName;
			
			String Severity;
			DataRow[] BusAudits = Audits.Business.Select(QHC.CmpEq("idaudit",AuditID));
			this.flagsystem = false;
			if (BusAudits.Length>0){
				DataRow BusinessAudit = BusAudits[0];
				//ShortMess       =   BusinessAudit["description"].ToString();
				Severity =   BusinessAudit["severity"].ToString().ToLower();
				this.flagsystem = BusinessAudit["flagsystem"].ToString()=="S" ? true : false;
			}
			else {
				//ShortMess="Errore nell'interrogazione della logica di business";
				LongMess="Errore nell'interrogazione della logica di business";
				Severity="e";
			}
			Severity = Severity.ToLower();
			if (Severity.Equals("e")) {
				this.CanIgnore=false;
				this.ErrorType="Errore";
			}
			else {
				this.CanIgnore=true;
				this.ErrorType="Avvertimento";
			}

			if (Severity.Equals("i")) {
				this.Enabled=false;
				this.ErrorType="Disabilitata";
				return; //don't loose time with further calculations
			}
			else
				this.Enabled=true;
			
			//Gets the string message to compile 
			switch (C.DR.RowState){
				case DataRowState.Added: 
					Operation = "Insert";
					break;
				case DataRowState.Deleted:
					Operation = "Delete";
					break;
				case DataRowState.Modified:
					Operation = "Update";
					break;
			}

			//Compiles the message 
			MsgParser Parser = new MsgParser(ToCompile,"%<", ">%");
			String ParamReference;
			String Skipped;
			String Compiled="";
			while (Parser.GetNext(out ParamReference, out Skipped)){
				Compiled = Compiled + Skipped;
				Compiled = Compiled + CompileParameter(C,EsercizioSessione,ParamReference,Conn);
			}
			Compiled = Compiled+ Skipped;           
			LongMess = Compiled;
		}
    

		public EasyProcedureMessage(){
		}

	}   // End Class ProcedureMessage


	#endregion


	#region Elenchi di messaggi e interrogazione della logica di business
	/// <summary>
	/// Collection of Stored Procedure Error Messages
	/// </summary>
	public class EasyProcedureMessageCollection : ProcedureMessageCollection{
        //const int MaxEnforcementPerAudit = 100;

	    public override void AddDBSystemError(string message) {
			EasyProcedureMessage CM= new EasyProcedureMessage();
			CM.CanIgnore=false;
			CM.LongMess=message;
			CM.ShortMess="Errore nella scrittura su DB.";
			Add(CM);
		}

	    public override void AddWarning(string message) {
	        EasyProcedureMessage CM= new EasyProcedureMessage();
	        CM.CanIgnore=true;
	        CM.LongMess=message;
	        CM.ShortMess=message;
	        Add(CM);
	    }

	    public bool autoIgnore = false;
		/// <summary>
		/// Presents messages to the user and eventually ask him to take a decision (ignore/cancel)
		/// </summary>
		/// <returns>true if change operation has to be done</returns>
		override public bool ShowMessages(){
			if (base.Count==0) return true;
			FrmElencoErrori Frm = new FrmElencoErrori(this);//new ProcMessages(this);
			MetaFactory.factory.getSingleton<IFormCreationListener>().create(Frm, null);
			DialogResult res = Frm.ShowDialog();
			Frm.Dispose();
			return  (res == DialogResult.OK);
		}

        struct InfoCallCheck {
            public string varname;
            public int ntotalchecks;
            public RowChange R;

        }

	    public static ProcedureMessageCollection DO_CALL_CHECKS(DataAccess Conn,
	        EasyAudits Audits,
	        bool Post,
	        RowChangeCollection RowChanges) {
	        return DO_CALL_CHECKS(Conn as IDataAccess, Audits, Post, RowChanges);

	    }
        /// <summary>
        /// Get all error messages related to the entire RowChanges list,
        ///  and merge them in a SortedList, ordered by auditID/EnforcementID
        /// </summary>
        /// <param name="Post">true if Checks are POST checks</param>
        /// <param name="Audits">Previously ignored rules</param>
        /// <returns>List of error messages</returns>
        public static ProcedureMessageCollection  DO_CALL_CHECKS(IDataAccess Conn, 
			EasyAudits Audits, 
			bool Post, 
			RowChangeCollection RowChanges){
            int NN = metaprofiler.StartTimer("DO_CALL_CHECKS");
			Hashtable LogCalls = new Hashtable(50);
			int esercizio= (int)Conn.Security.GetSys("esercizio");
			EasyAudits CAudits = (EasyAudits) Audits;
			EasyProcedureMessageCollection AllMessages = new EasyProcedureMessageCollection();
            AllMessages.PostMsgs = Post;
			Hashtable ExistSp = new Hashtable();
            QueryHelper QHS = Conn.GetQueryHelper();
            int num_audit = 0;

            List<InfoCallCheck> checks = new List<InfoCallCheck>();
            
            StringBuilder batchCmd = new StringBuilder();
            bool dberr = false;
            //Dictionary<string, bool> vardeclared = new Dictionary<string, bool>();
			foreach (RowChange R in RowChanges){

				string logcall;
				String ProcName;              

				//Gets the name of the procedure to call
				if (Post)
					ProcName = R.PostProcNameToCall();
				else
					ProcName = R.PreProcNameToCall();

				logcall=ProcName+":";
				object existsp= ExistSp[ProcName];
                if (existsp == null) {
                    existsp = 1;
                    //Ottiene la lista dei controlli da includere nella regola in auditcheck
                    string filter = "(tablename='" + R.PostingTable + "')AND(opkind='" + R.ShortStatus() + "')AND" +
                        "(sqlcmd IS NOT NULL)AND(SEVERITY<>'I')";
                    if (!Post)
                        filter += "AND(precheck='S')";
                    else
                        filter += "AND(precheck='N')";

                    string filtercheck = Conn.Security.GetSys("filterrule") as string;

                    if (EasyAudits.FILTRA_CFG_ANNUALE) {
                        filter = GetData.MergeFilters(filter, filtercheck);
                    }
                    existsp = CAudits.Enforcement.Select(filter).Length;

                    //Vede se ci sono controlli attivi e attinenti la configurazione annuale relativamente all'operazione
                    //Questo avviene solo qui localmente ai fini di verificare se sia utile o meno CHIAMARE la SP, e non ha 
                    //  a che fare con la sua creazione

                    //if (EasyAudits.FILTRA_CFG_ANNUALE == false) {
                    //    //Se non ci sono controlli attivi assumi che non ve ne siano proprio
                    //    string filter_local = GetData.MergeFilters(filter, filtercheck);
                    //    int local_nchecks = CAudits.Enforcement.Select(filter_local).Length;
                    //    if (local_nchecks == 0) existsp = 0;
                    //}

                    //}

                    ExistSp[ProcName] = existsp;
                }
				int ntotalchecks= Convert.ToInt32(existsp);
                if (ntotalchecks == 0) continue;

                string parameters = AddParametersFor(Conn, Audits, R, !Post);
                string proc_sign = ProcName + ":" + parameters;
                //Non effettua due volte la stessa chiamata!!!!
                if (LogCalls[proc_sign] != null) {
                    //MarkEvent("Skipped audit " + proc_sign);
                    continue;
                }
                LogCalls[proc_sign] = "1";


                num_audit++;

                //Modello:
                //declare @p1 smallint
                //set @p1=8
                //exec check_expenseyear_i_pre @res=@p1 output,@sys_idcustomuser=NULL,@sys_esercizio=2013,@NEW_idfin=15123,@sys_idflowchart=NULL
                //select @p1
                string varprefix = EasyAudits.GetSqlParameterVarPrefixForResult(ntotalchecks);
                string varname = "@"+varprefix+num_audit.ToString();
                string res_type = EasyAudits.GetSqlParameterTypeNameForResult(ntotalchecks);
                string resetvar = EasyAudits.GetSqlResetVar(varname, ntotalchecks);

                string cmd = "";
                
                //if (!vardeclared.ContainsKey(varname)) {
                    cmd += "declare " + varname + " " + res_type+";";
                //    vardeclared.Add(varname, true);
                //}                
                cmd += resetvar;
                cmd += "exec " + ProcName + " @res=" + varname + " output" +parameters;

                cmd += ";\r\n";


                batchCmd.Append(cmd);
				
                InfoCallCheck check;
                check.ntotalchecks = ntotalchecks;
                check.R = R;
                check.varname = varname;
                checks.Add(check);

                if (batchCmd.Length > 40000) {
                    dberr= !ExecCheckBatch(Conn, checks, batchCmd,  AllMessages, Audits, Post);
                    batchCmd = new StringBuilder();
                    checks = new List<InfoCallCheck>();
                    num_audit = 0;
                    if (dberr) break;
                }						
			}

            if (num_audit > 0) {
                dberr=!ExecCheckBatch(Conn, checks, batchCmd, AllMessages, Audits, Post);
            }
            RefineMessages(Conn, AllMessages);

            metaprofiler.StopTimer(NN);
			return AllMessages;
		}

        static bool ExecCheckBatch(IDataAccess Conn, List<InfoCallCheck> checks, StringBuilder cmd,
                        EasyProcedureMessageCollection AllMessages, EasyAudits Audits, bool post) {
            string sql = cmd.Append(getResultSelect(checks)).ToString();
            string msg = "";
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable T = Conn.SQLRunner(sql, 600, out msg);
            if ((msg != null) && (msg != "")) {
                MarkEvent("Error calling business rules. Detail:\r" + msg + "\r\n Running command:" + sql);

                EasyProcedureMessage CP = new EasyProcedureMessage(Conn.GetQueryHelper(), checks[0].R, "DBError", 0,
                    "Errore interrogando la business logic.\n" +
                    "Contattare il servizio di assistenza. Il dettaglio dell'errore è:\n" +
                    msg, Conn.Security.GetEsercizio(), Audits,Conn);
                CP.CanIgnore = false;
                AllMessages.Add(CP);
                return false;
            }

            if (T == null || T.Rows.Count == 0) {
                EasyProcedureMessage CP = new EasyProcedureMessage(QHS, checks[0].R, "DBError", 0,
                "Errore interrogando la business logic.\n" +
                "Contattare il servizio di assistenza. Il dettaglio dell'errore è:\n" +
                "Il batch di interrogazione regole non ha restituito risultati.",
                    Conn.Security.GetEsercizio(), Audits,Conn);
                CP.CanIgnore = false;
                AllMessages.Add(CP);
                return false;
            }


            DataRow R = T.Rows[0];
            //La chiamata del batch di auditcheck è andata a buon fine, prende i risultati e li converte in messaggi
            foreach (InfoCallCheck c in checks) {
                string colname = c.varname.Substring(1);
                if (!T.Columns.Contains(colname)) {
                    EasyProcedureMessage CP = new EasyProcedureMessage(Conn.GetQueryHelper(), checks[0].R, "DBError", 0,
                    "Errore interrogando la business logic.\n" +
                    "Contattare il servizio di assistenza. Il dettaglio dell'errore è:\n" +
                    "La colonna " + colname + "non è stata restituita dal batch.",
                        Conn.Security.GetEsercizio(), Audits,Conn);
                    CP.CanIgnore = false;
                    AllMessages.Add(CP);
                    return false;
                }
                object res = R[colname];
                bool[] result = EasyAudits.Serialize(res, c.ntotalchecks);
                //Takes error messages and append them to AllMessage
                DO_ADD_MESSAGES(QHS, Audits, c.R, result, AllMessages, post);
            }
            return true;
        }


        static string getResultSelect( List<InfoCallCheck> checks){
            StringBuilder sel = new StringBuilder("SELECT ");
            bool empty = true;
            foreach (InfoCallCheck c in checks) {
                if (!empty) sel.Append(",");
                empty = false;
                sel.Append(c.varname + " AS " + c.varname.Substring(1));
            }
            return sel.ToString();
        }
        static string GetQuery(QueryHelper QHS, DataTable FromT, DataRow FromR, DataTable To, int esercizio,
                            out List<string> cols) {
            cols = new List<string>(); 
            //Vede se To è una vista
            string filter = "";
            DataRowVersion Ver = DataRowVersion.Default;
            if (FromR.RowState== DataRowState.Deleted) Ver = DataRowVersion.Original;
            if (To.PrimaryKey == null || To.PrimaryKey.Length == 0) {
                //Usa la chiave di FromT + eventuale esercizio

                
                foreach (DataColumn K in FromT.PrimaryKey) {
                    if (!To.Columns.Contains(K.ColumnName)) continue;
                    filter = QHS.AppAnd(filter, QHS.CmpEq(K.ColumnName, FromR[K.ColumnName,Ver]));                    
                    cols.Add(K.ColumnName);
                }

                if (To.Columns.Contains("ayear") &&
                     !QueryCreator.IsPrimaryKey(FromT, "ayear")) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ayear", esercizio));
                    cols.Add("ayear");
                }
                return filter;
            }
            bool primarykey_incomplete = false;
            foreach (DataColumn K in To.PrimaryKey) {
                if (!FromT.Columns.Contains(K.ColumnName)) {
                    primarykey_incomplete = true;
                    continue;
                }
                filter = QHS.AppAnd(filter, QHS.CmpEq(K.ColumnName, FromR[K.ColumnName,Ver ]));
                cols.Add(K.ColumnName);
            }

            if (To.Columns.Contains("ayear") && primarykey_incomplete &&
                 !QueryCreator.IsPrimaryKey(FromT, "ayear")) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ayear", esercizio));
                cols.Add("ayear");
            }
            return filter;

        }

        static void RefineMessages(IDataAccess Conn, EasyProcedureMessageCollection AllMsg) {
            DataSet D = new DataSet();
            QueryHelper QHS = Conn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();

            int esercizio =Conn.Security.GetEsercizio();

            //Step 1 individuazione query da applicare per tutti i messaggi
            foreach (EasyProcedureMessage EPM in AllMsg) {
                foreach (onesubst O in EPM.OpenSubstitutions) {
                    if (O.query.Count>0)
                        continue;
                    DataTable T;
                    DataTable Base;
                    if (!D.Tables.Contains(O.tablename)) {
                        T = Conn.CreateTableByName(O.tablename, "*");
                        D.Tables.Add(T);
                    }
                    else {
                        T = D.Tables[O.tablename];
                    }
                    if (!D.Tables.Contains(O.fromtable)) {
                        Base = Conn.CreateTableByName(O.fromtable, "*");
                        D.Tables.Add(Base);
                    }
                    else {
                        Base = D.Tables[O.fromtable];
                    }
                    if (Base.PrimaryKey.Length == 0 || T.PrimaryKey.Length == 0) {
                        DataTable PostingT = Conn.CreateTableByName(EPM.Related.PostingTable, "*");
                        if (Base.PrimaryKey.Length == 0)
                            QueryCreator.CheckKey(PostingT, ref Base);
                        if (T.PrimaryKey.Length == 0)
                            QueryCreator.CheckKey(PostingT, ref T);
                    }
                    List<string> cols;
                    var query = GetQuery(QHS, Base, EPM.Related.DR, T, esercizio, out cols);
                    O.query.Add( query);
                    O.cquery.Add(GetQuery(QHC, Base, EPM.Related.DR, T, esercizio, out cols));
                    if (query=="") {
                        QueryCreator.MarkEvent("Nella regola " + EPM.AuditID + " " + EPM.TableName + " " + EPM.EnforcementNumber.ToString() +
                                    " Il messaggio contiene un riferimento a " + O.tablename + "." + O.field +
                                    " che non è corretto.");
                        O.error = true;
                    }
                    if (!T.Columns.Contains(O.field)) {
                        O.error = true;
                        QueryCreator.MarkEvent("Nella regola " + EPM.AuditID + " " + EPM.TableName + " " + EPM.EnforcementNumber.ToString() +
                                   " Il messaggio contiene un riferimento a " + O.tablename + "." + O.field +
                                   " che non è corretto.");
                    }
                    O.querycols = cols;
                    foreach (onesubst OO in EPM.OpenSubstitutions) {
                        if ((OO.tablename == O.tablename) &&
                              (OO.fromtable == O.fromtable) &&
                              OO.query == null) {
                            OO.query = O.query;
                            OO.cquery = O.cquery;
                            if (!T.Columns.Contains(OO.field)) {
                                OO.error = true;
                            }
                        }
                    }

                }
            }


            //Step 2 individuo una serie di campi da leggere per ogni coppia (tabella to, query) mettendo in OR le query
            // salta le sostituzioni errate
            ArrayList mysub = new ArrayList();
            foreach (EasyProcedureMessage EPM in AllMsg) {
                foreach (onesubst O in EPM.OpenSubstitutions) {
                    string table = O.tablename;
                    string clause = QHS.DoPar(O.query[0]);
                    if (O.error) continue;

                    //Cerca in ArrayList la query su table
                    onesubst G = null;
                    foreach (onesubst OO in mysub) {
                        if (OO.query.Count > 100) {
                            if (!OO.query.Contains( clause)) {
                                continue; //non crea query troppo lunghe
                            }
                        }
                        if (OO.tablename == table) {
                            G = OO;
                            break;
                        }
                    }

                    if (G == null) {
                        G = new onesubst();
                        G.tablename = O.tablename;
                        G.querycols.AddRange(O.querycols);
                        if (!G.querycols.Contains(O.field)) {
                            G.querycols.Add(O.field);
                        }
                        G.query.Add( clause);
                        mysub.Add(G);
                    }
                    else {
                        if (!G.querycols.Contains(O.field)) {
                             G.querycols.Add( O.field);
                        }
                        if (!G.query.Contains(clause)) {
                            G.query.Add(clause);
                        }
                    }

                }
            }

            // A questo punto esegue le query
            foreach (onesubst OS in mysub) {
                OS.Data = Conn.RUN_SELECT(OS.tablename, String.Join(",",OS.querycols.ToArray()), 
                                    null, String.Join(" or ",OS.query.ToArray()), null, false);
            }

            //Compila le sostituzioni
            foreach (EasyProcedureMessage EPM in AllMsg) {
                foreach (onesubst O in EPM.OpenSubstitutions) {
                    bool wasfound = false;
                    if (O.error) {
                        O.newval = " [rif. errato a " + O.tablename + "." + O.field+"] ";
                        ErrorLogger.Logger.warnEvent(O.newval);
                        continue;
                    }
                    foreach (onesubst OS in mysub) {
                        if (OS.Data == null)
                            continue;
                        if (O.tablename != OS.tablename)
                            continue;
                        DataRow[] found = OS.Data.Select(String.Join(" or ",O.cquery.ToArray()));
                        if (found.Length == 0) {
                            continue;
                        }
                        else {
                            wasfound = true;
                            if (!OS.Data.Columns.Contains(O.field)) {
                                O.newval = "(Colonna " + "'" + O.field + "'"+ " non trovata in tabella " + "'" + OS.tablename + "'"+ ")";
								O.original = "%<" + OS.tablename + '.' + O.field + ">%";
								O.error = true;
                                string msg = O.newval+". ";
                                msg+= " OS.query=" + String.Join(" or ",OS.query.ToArray());
                                msg+= " OS.tablename=" + OS.tablename;
                                msg+= " OS.querycols=" + String.Join(",", OS.querycols.ToArray());
                                msg+= " O.tablename=" + O.tablename;
                                msg+= " O.cquery=" + String.Join(" or ", OS.cquery.ToArray());
                                msg+= " O.fromtable=" + O.fromtable;
                                ErrorLogger.Logger.warnEvent(msg);
                            }
                            else {
                                O.newval = HelpForm.StringValue(found[0][O.field], "x.y", OS.Data.Columns[O.field]);
                            }
                            break;
                        }

                    }
                    if (!wasfound) {
                        O.newval = "(Riga in " + "'" + O.tablename + "'" + " non trovata)";
                        O.error = true;
                        string msg = O.newval+". ";
                        msg+=" O.tablename=" + O.tablename;
                        msg+=" O.cquery=" + String.Join(" or ", O.cquery.ToArray());
                        msg+=" O.fromtable" + O.fromtable;
                        ErrorLogger.Logger.warnEvent(msg);
                    }
                    EPM.LongMess = EPM.LongMess.Replace(O.original, O.newval);
                }
            }

        }
        static bool commacontained(string S, string clause) {
            if (S == clause) return true;
            if (S.StartsWith(clause + ",")) return true;
            if (S.EndsWith(","+clause)) return true;
            if (S.IndexOf("," + clause + ",") > 0) return true;
            return false;
        }

        static bool orcontained(string S, string clause) {
            if (S == clause) return true;
            if (S.StartsWith(clause + "or")) return true;
            if (S.EndsWith("or"+ clause)) return true;
            if (S.IndexOf("or" + clause + "or") > 0) return true;
            return false;
        }

		static void MarkEvent(string e){
            string msg = DateTime.Now.ToString("HH:mm: ss.fffffff") + ":"+e;
            Debug.WriteLine(msg);
			Debug.Flush();
		}

		/// <summary>
		///  Evaluates the list of all input parameter for the stored procedure to
		///  call, managing the corrispondence new / old value with tags
		/// </summary>
		/// <remarks>Unchecked</remarks>
		/// <returns>true if some parameter was marked as "new"</returns>
        static string AddParametersFor(IDataAccess Conn, EasyAudits Audits, RowChange R, bool precheck) {
            QueryHelper QHS = Conn.GetQueryHelper();

            string param = ""; 
            //Retrieves Parameter data
			string filter=R.FilterPostTableOp();
			if (precheck)
				filter+="and(isprecheck='S')";
			else
				filter+="and(isprecheck='N')";

			DataRow[] PP = Audits.Parameter.Select(filter,"parameterID");
            if (PP == null) return ""; //just for sure
            if (PP.Length == 0) return "";
			            
			foreach (DataRow P in PP){ //Appends the parameter P to the list
				//P is like "tablename - opkind - parameterID - paramtable - paramcomlumn - flagoldvalue"
				//  or like "tablename - opkind - parameterID - sys        - envvarname - ignore"
				if (P["paramtable"].ToString().ToLower()=="sys"){
					string colname= P["paramcolumn"].ToString().ToLower();
					object O;
					if (colname.StartsWith("sys_")){
						O= Conn.Security.GetSys(colname.Substring(4));
					}
					else {
						O= Conn.Security.GetSys(colname) as object;
					}
					if (O==null) O=DBNull.Value;
                    string ParamName2= "@"+colname; //"@sys_"+colname;

                    param += "," + ParamName2 + "=" + QHS.quote(O);
										
					continue;
				}
                                
				bool CurrentIsNew;
				string ColumnName = P["paramcolumn"].ToString();
				//Takes the Parameter Name
				string ParamName;
				if (P["flagoldvalue"].ToString().ToUpper().Equals("S")){
					ParamName= "@OLD";					
					if (P["paramtable"].ToString().ToLower()!=P["tablename"].ToString().ToLower())
						ParamName+="_"+P["paramtable"].ToString().ToLower();
					ParamName +="_"+ColumnName;
					CurrentIsNew=false;
				}                
				else {
					ParamName= "@NEW";
					if (P["paramtable"].ToString().ToLower()!=P["tablename"].ToString().ToLower())
						ParamName+="_"+P["paramtable"].ToString().ToLower();
					ParamName +="_"+ColumnName;
					CurrentIsNew=true;
				}

				//Fetch the table row           
				DataRow RelatedRow= R.GetRelated(P["paramtable"].ToString());

				//Evaluates the version of the row to be taken
				DataRowVersion MainVer=DataRowVersion.Default;
      
				if (RelatedRow==null) {
					string desttable= P["paramtable"].ToString();
					DataSet DS = R.Table.DataSet;
					if (DS.Tables[desttable]!=null){
						if ((QueryCreator.GetParentChildRel(DS.Tables[desttable], R.Table)==null) &&
							(QueryCreator.GetParentChildRel(R.Table, DS.Tables[desttable])==null) &&
							(QueryCreator.GetMiddleTable(R.Table, DS.Tables[desttable])==null) &&
						    (DS.Tables[desttable].Rows.Count==1)) RelatedRow = DS.Tables[desttable].Rows[0];
					}
				}

				if (RelatedRow!=null){
					if (RelatedRow.RowState== DataRowState.Deleted) {
						MainVer= DataRowVersion.Original;
                        CurrentIsNew = false;

                    }
					else {
						if (P["flagoldvalue"].ToString().ToUpper().Equals("S"))
							MainVer = DataRowVersion.Original;
						else
							MainVer = DataRowVersion.Current;
						if (RelatedRow.RowState== DataRowState.Added) MainVer = DataRowVersion.Current;
					}
				}


				//Adds the parameter
				string FoundColumn= null; 
				if (RelatedRow!=null) FoundColumn = FindPostingColumn(RelatedRow.Table, ColumnName);
				if (FoundColumn!=null){                    
					//if (RelatedRow[FoundColumn,Ver]==DBNull.Value) continue;					
					if (CurrentIsNew) {
						//don't mark SomeNewFound if field is an autoincrement field
						// of a row in "add" state.
						if (precheck && IsTemporaryValue(RelatedRow,FoundColumn,false)){
							continue;
							//Params.Add(ParamName, DBNull.Value);//RelatedRow[FoundColumn,Ver]); //ex , DBNull.value
						}
						else {
                            if (RelatedRow[FoundColumn, MainVer] != DBNull.Value) {
                                param += "," + ParamName + "=" + QHS.quote(RelatedRow[FoundColumn, MainVer]);
                            }                            
						}
					}
					else {
						if (RelatedRow[FoundColumn,MainVer]!=DBNull.Value)
                            param += "," + ParamName + "=" + QHS.quote(RelatedRow[FoundColumn, MainVer]);                        
					}
				}
				else {
					continue;
					//Params.Add(ParamName, DBNull.Value); 
				}
			}
            return param;
		}


		static string FindPostingColumn(DataTable T, string ColForPosting){
		    if (T.Columns.Contains(ColForPosting)) {
                if (QueryCreator.PostingColumnName(T.Columns[ColForPosting]) == ColForPosting) return ColForPosting;
            }

            foreach (DataColumn C in T.Columns){
				if (QueryCreator.PostingColumnName(C)==ColForPosting) return C.ColumnName;
			}
			if (!T.Columns.Contains(ColForPosting)) return null;
			if (QueryCreator.PostingColumnName( T.Columns[ColForPosting])!=null) return null;
			return ColForPosting;
		}

		public static bool RelationRelatesAutoIncrFields(DataRelation Rel){
			for (int i=0; i< Rel.ParentColumns.Length; i++){
				if (RowChange.IsAutoIncrement(Rel.ParentColumns[i])) return true;
			}
			return false;
		}

		/// <summary>
		/// Establish if a field must be passed to Business audits
		/// </summary>
		/// <param name="R"></param>
		/// <param name="exclude">when true, Autoincrement properties are 
		///					not considered on R fields, but only in parents</param>
		/// <param name="ColumnName"></param>
		/// <returns></returns>
		public static bool IsTemporaryValue(DataRow R, string ColumnName, bool exclude){
			if ((!exclude) && 
				(R.RowState==DataRowState.Added) &&
				RowChange.IsAutoIncrement(R.Table.Columns[ColumnName])) return true;
			foreach (DataRelation Rel in R.Table.ParentRelations){				
				//test if Rel implies ColumnName column of R
				int foundcol=-1;
				for (int i=0;i<Rel.ChildColumns.Length;i++){
					if (Rel.ChildColumns[i].ColumnName==ColumnName){
						foundcol=i;
						break;
					}
				}
				if (foundcol==-1)continue;
                DataRow ParentRow;
                try {
                    DataRow[] ParentRows = R.GetParentRows(Rel, DataRowVersion.Current);
                    if (ParentRows == null) continue;
                    if (ParentRows.Length == 0) continue;
                    ParentRow = ParentRows[0];
                }
                catch {
                    ParentRow = R.GetParentRow(Rel);
                    if (ParentRow == null) continue;
                }
				if (ParentRow.RowState != DataRowState.Added)continue;
				if (IsTemporaryValue(ParentRow, 
					Rel.ParentColumns[foundcol].ColumnName, false))return true;
			}
			return false;
		}



		/// <summary>
		/// Appends error messages related to R to AllMess Collection
		/// </summary>
		/// <param name="R">RowChange referred by error messages</param>
		/// <param name="result">errors returned by stored procedures</param>
		/// <param name="AllMess" type = "output">updated messages List</param>
		/// <remarks>
		/// IMPORTANT:
		/// This function assumes that the order of the array result matches
		/// the order of messages stored in R.EnforcementMessages. This is 
		/// essentially the order auditID-EnforcementID</remarks>
		static void DO_ADD_MESSAGES(QueryHelper QHS, EasyAudits Audits, RowChange R, bool[] result, 
			EasyProcedureMessageCollection AllMess,bool Post){
			
			Audits.DO_CALC_MESSAGES(QHS, R, result,Post);
            foreach (ProcedureMessage msg in R.EnforcementMessages) AllMess.Add(msg);
 
		}

		new public EasyProcedureMessage GetMessage(int index){
			return (EasyProcedureMessage) base.GetMessage(index);
		}
		#endregion


	}//end class ProcedureMessageCollection



}
