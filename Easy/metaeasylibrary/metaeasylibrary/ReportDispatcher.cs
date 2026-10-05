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
using System.Data;
using System.Collections;
using metadatalibrary;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Text;




namespace metaeasylibrary
{
	/*
	 * Nota:
	 * Conn.usr["localreportdir"] = report directory
	
	*/
	/// <summary>
	/// Summary description for ReportDispatcher.
	/// </summary>
	public class ReportDispatcherClass 
	{

		static string GetReportPathFromDataAccess(DataAccess Conn){
			string ReportPath;
			if (Conn.GetUsr("localreportdir")!=null)
				ReportPath = Conn.GetUsr("localreportdir").ToString();
			else
				ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Report\\";
			if (!ReportPath.EndsWith("\\"))
				ReportPath += "\\";
			return ReportPath;
		}

		//Calcola i parametri extra (formule aggiuntive) da passare al report
		static Hashtable GetExtraParameterForReport(DataAccess Conn, DataRow ModuleReport){
			Hashtable ParamExtra  = new Hashtable();
            QueryHelper QHS = Conn.GetQueryHelper();
            DateTime aday = (DateTime)Conn.GetSys("datacontabile");
            string filter = QHS.AppAnd(QHS.CmpEq("reportname", ModuleReport["reportname"]),
                         QHS.NullOrLe("start", aday), QHS.NullOrGt("stop", aday));

			DataTable CustReport = DataAccess.RUN_SELECT(Conn,"reportadditionalparam","*",null,
				filter,null,null,true);
			if (CustReport!=null){
				//Crea una HashTable contenente i valori dei parametri extra da passare al report.
				foreach(DataRow ParExtra in CustReport.Rows) {	
					ParamExtra.Add(ParExtra["paramname"].ToString().Trim(),ParExtra["paramvalue"]);
				}
			}
            string filter2 = QHS.AppAnd(QHS.NullOrLe("start", aday), QHS.NullOrGt("stop", aday));

            DataTable T = DataAccess.RUN_SELECT(Conn, "generalreportparameter", "*", null, filter2, 
                                null, null, true);
			if (T!=null){
				foreach(DataRow R in T.Rows){
					ParamExtra[R["idparam"].ToString()]=R["paramvalue"].ToString();
				}
				//ParamExtra["PartitaIvaUniversita"]= ActivationKey["p_iva"].ToString();
				//ParamExtra["License_P_Iva"]= ActivationKey["p_iva"].ToString();
			}
			return ParamExtra;
		}

		/// <summary>
		/// Evaluates a ReportDocument, returns null if errors (ErrMess is the reason)
		/// </summary>
		/// <param name="Conn"></param>
		/// <param name="ModuleReport"></param>
		/// <param name="Params"></param>
		/// <param name="ErrMess"></param>
		/// <returns></returns>
		public static ReportDocument GetReport(DataAccess Conn,
				DataRow ModuleReport,
				Hashtable Params,
				out string ErrMess  
				)
		{
			ErrMess=null;
			string 	ReportFileName = GetReportPathFromDataAccess(Conn) + 
				ModuleReport["filename"].ToString();

			Hashtable ParamExtra = GetExtraParameterForReport(Conn, ModuleReport);

			if (!File.Exists(ReportFileName)){
				ErrMess= "Il file "+ReportFileName+" non esiste.";
				return null;
			}

			ReportDocument ReportDoc = new ReportDocument();

			int timeout=300;
			if (ModuleReport.Table.Columns.Contains("timeout")){
				if (ModuleReport["timeout"]!=DBNull.Value){
					timeout = Convert.ToInt32(ModuleReport["timeout"]);
					if (timeout==0) 
						timeout=300;
					else 
						timeout=timeout*60;
				}			
			}

			try {
				// Open a temporary copy of the report.
				ReportDoc.Load(ReportFileName, OpenReportMethod.OpenReportByTempCopy);
			}
			catch (Exception e) {
				ErrMess = "Impossibile caricare il report " + ReportFileName+
					"\nDettaglio: "+QueryCreator.GetPrintable(e.ToString());
				return null;
			}

			try {


				try {
					SetReport(ReportDoc, (Easy_DataAccess)  Conn, Params, ParamExtra,timeout);
				}
				catch (Exception  E){					
					ErrMess = "Impossibile impostare il report principale " + ReportFileName+
						"\nDettaglio: "+QueryCreator.GetPrintable(E.ToString());
					return null;
				}

				//mi scorro tutti i subreport (se presenti) del report principale
				ReportDefinition repDef = ReportDoc.ReportDefinition;
				foreach (Section sec in repDef.Sections) {
					foreach (ReportObject repObj in sec.ReportObjects) {
						if (repObj.Kind != ReportObjectKind.SubreportObject) continue;
						SubreportObject subRep = (SubreportObject) repObj;
						ReportDocument SubReport = subRep.OpenSubreport(subRep.SubreportName);
						SetReport(SubReport, (Easy_DataAccess) Conn, Params, ParamExtra,timeout);
					}
				}


				SetDefaultOrientation(ref ReportDoc, ModuleReport);

				//margini per centrare il report
				SetReportMargins(ref ReportDoc);

				return ReportDoc;
			}
			catch (Exception  E){
				ErrMess = "Impossibile impostare il report " + ReportFileName+
					"\nDettaglio: "+QueryCreator.GetPrintable( E.ToString());
				return null;
			}

		}

		public static void SetDefaultOrientation(ref ReportDocument ReportDoc, DataRow ModuleReport){

			//Orientamento del report
			if (ModuleReport["orientation"].ToString().ToUpper()=="P"){
				ReportDoc.FormatEngine.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				ReportDoc.PrintOptions.PaperOrientation= PaperOrientation.Portrait;
			}
			else  {
				ReportDoc.FormatEngine.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				ReportDoc.PrintOptions.PaperOrientation= PaperOrientation.Landscape;
			}

			//Paper Size del report
			if (ModuleReport.Table.Columns.Contains("papersize")){
				string papersize= ModuleReport["papersize"].ToString();
				if (papersize.ToUpper()== "A3"){
					ReportDoc.FormatEngine.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA3;
					ReportDoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
				}
				if (papersize.ToUpper()== "A4"){
					ReportDoc.FormatEngine.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4;
					ReportDoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
				}				

			}
			//ReportDoc.PrintOptions.PaperSize = GetCRSize(pg.PaperSize.Kind);

		}

	    public static bool setReportLogon(ReportDocument Rpt, Easy_DataAccess Conn) {
            string DSNName = Conn.GetSys("dsn").ToString();
            //come server name bisogna assegnare il data source name
            //string server = DSNName;
            string server = Conn.GetSys("server").ToString().Trim();

            string dbname = Conn.GetSys("database").ToString().Trim();
            string username = Conn.GetSys("userdb").ToString();
            string userpwd = "";
            if (Conn.GetSys("passworddb") != null) {
                byte[] B = (byte[])Conn.GetSys("passworddb");
                userpwd = Conn.MyDecryptKey(B);
            }

            TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            //Crystal Report Properties
            CrystalDecisions.CrystalReports.Engine.Database crDatabase;
            CrystalDecisions.CrystalReports.Engine.Tables crTables;

            //Imposto dati per la connessione
            crConnectionInfo.ServerName = server;
            crConnectionInfo.DatabaseName = dbname;
            //int o = crConnectionInfo.Attributes.Collection.IndexOf("Integrated Security");
            //if (o>0) crConnectionInfo.Attributes.Collection.RemoveAt(o);
            //CrystalDecisions.ReportAppServer.DatadefModel.PropertyBag

            //in caso di trusted connection username vale ""
            if (Conn.SSPI) {
                //Pair = new CrystalDecisions.Shared.NameValuePair2("Integrated Security","SSPI");
                //crConnectionInfo.Attributes.Collection.Add(Pair);
                crConnectionInfo.UserID = "";
                crConnectionInfo.Password = "YOUR_SECRET";
            }
            else {
                //Pair = new CrystalDecisions.Shared.NameValuePair2("Integrated Security","false");
                //crConnectionInfo.Attributes.Collection.Add(Pair);
                crConnectionInfo.UserID = username;
                crConnectionInfo.Password = userpwd;
            }
            crDatabase = Rpt.Database;
            crTables = crDatabase.Tables;

            //Imposto la location per tutte le tabelle del (sub)report in elaborazione
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables) {

                //MetaFactory.factory.getSingleton<IMessageShower>().Show(crTable.Name);

                //applico i nuovi dati per la connessione
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);

                //ricavo il nome della tabella
                string Ta = crTable.Location;

                int lastdotpos = Ta.LastIndexOf(".");
                if (lastdotpos == -1) lastdotpos = Ta.LastIndexOf("(");
                int lastsemicolpos = Ta.LastIndexOf(";");
                Ta = Ta.Substring(lastdotpos + 1, lastsemicolpos - lastdotpos - 1);
                Ta = dbname + "." + username + "." + Ta; //dbname+".dbo."+ Ta;

                //imposto la location giusta
                //per evitare eventuali errori visualizzati a runtime (meglio un report vuoto)
                if (crTable.TestConnectivity())
                    crTable.Location = Ta.ToUpper();


            }
            return true;
        }
        static void SetReport(ReportDocument Rpt, Easy_DataAccess Conn, 
			Hashtable Params, Hashtable ParamExtra,int timeout) {

            if (!setReportLogon(Rpt, Conn)) return;
		
						
			
			//Valorizzo tutti i parametri del report
			foreach(ParameterFieldDefinition PF in Rpt.DataDefinition.ParameterFields) {
				//solo se appartengono al report in elaborazione
                if (PF.ReportName != "") continue;
                if (PF.IsLinked()) continue;

                ParameterDiscreteValue val = new ParameterDiscreteValue();
				string paramname = PF.ParameterFieldName.Substring(1);

				//controllo se il valore è di tipo DBNull, in tal caso lo converto a null
				if (Params.ContainsKey(paramname))
					val.Value = GetParamValue(Params[paramname],PF.ParameterValueKind);

				//parametri di tipo link tra main report e subreport
				if ((val.Value == null) && (paramname.StartsWith("y-@")||paramname.StartsWith("f-@"))) {
					string param2 = paramname.Substring(3);
                    if (ParamExtra.ContainsKey(param2)) val.Value = 
                            GetParamValue(ParamExtra[param2], PF.ParameterValueKind);
                        //ParamExtra[param2];
				}
                ParameterValues currentValues;



                //Se il parametro ha già un valore corrente viene eliminato
				if (PF.HasCurrentValue) {
					currentValues = new ParameterValues();
					PF.ApplyCurrentValues(currentValues);
				}
				currentValues = PF.CurrentValues;
				currentValues.Add(val);
				PF.ApplyCurrentValues(currentValues);

			}//fine foreach parameter

			foreach (FormulaFieldDefinition FFD in Rpt.DataDefinition.FormulaFields) {
                if (FFD.Text != null) FFD.Text = AdjustFormula(FFD.Text);// SplitMultiLine();
				string formulaname = FFD.FormulaName.Remove(0,2).Trim();                
				formulaname = formulaname.Substring(0, formulaname.Length - 1);
				//il valore deve essere diverso da null e DBNull (modificare il QueryCreator?)
				if (ParamExtra[formulaname]!=null) {
					FFD.Text = SplitMultiLine( GetFormula(ParamExtra[formulaname],FFD.ValueType));
				}
				else {
                    if(Params[formulaname]!=null) {
                        FFD.Text = SplitMultiLine( GetFormula(Params[formulaname], FFD.ValueType));
                    }	
				}
			}

			
		}	// fine SetReport method

        static string GetFormula(object O, FieldValueType FT) {
            if(O == null) return "";
            if(O == DBNull.Value) return "";
            if(O.GetType() == typeof(DateTime)) {
                return O.ToString();
            }
            if (FT == FieldValueType.StringField) {
                return QueryCreator.quotedstrvalue(O.ToString().TrimEnd('\n','\r'), false);
            }
            return QueryCreator.unquotedstrvalue(O, false);
        }
        static string AdjustFormula(string FormulaText) {
            if (FormulaText.IndexOf("ToItalianWords") < 0) return FormulaText;
            string Formula = FormulaText;
            int pos = Formula.IndexOf("ToItalianWords");
            Formula = Formula.Remove(pos, 14);
            Formula = Formula.Insert(pos, "ToWords");
            int level = 1;
            int currpos = Formula.IndexOf('(', pos + 1);
            while (true) {
                currpos++;
                if (currpos >= Formula.Length) break;
                if (Formula[currpos] == '(') level++;
                if (Formula[currpos] == ')') level--;
                if (level == 0) break;
            }
            Formula = Formula.Insert(currpos, ",0");
            return AdjustFormula(Formula);
        }
		//elimino i default (0,63 cm espressi in migliaia di inch)
		public static void SetReportMargins(ref ReportDocument Rpt) {
			try {
				PageMargins margini = Rpt.PrintOptions.PageMargins;
				//int margine = 250;
				int horiz = (margini.leftMargin+margini.rightMargin)/2;
                margini.leftMargin = (horiz - 15 > 0) ? horiz - 15 : horiz ;
				margini.rightMargin= horiz;

				int vert = (margini.topMargin+margini.bottomMargin)/2;
               
				margini.topMargin= vert;
				margini.bottomMargin= vert;

/*
				if (margini.leftMargin>margine) 
					margini.leftMargin -= margine;
				else 
					margini.leftMargin=0;

				//questo margine è diverso perché alcuni report sono + larghi
				//per qualche millimetro
				margini.rightMargin += 235;

				if (margini.topMargin>margine) 
					margini.topMargin -= margine;
				else 
					margini.topMargin=0;
			
				margini.bottomMargin += margine;
*/

				Rpt.PrintOptions.ApplyPageMargins(margini);
			}
			catch (Exception e) {
				QueryCreator.ShowException(e);
			}
		}

        static string SplitMultiLine(string S) {
            if (!S.StartsWith("'")) return S;
            if (S.IndexOf('\n')<0 && S.IndexOf('\r') < 0) return S;
            S= S.Replace("\r","");
            S = S.TrimEnd('\n', '\r');
            S= S.Replace("\n","'+chr(13)+'");
            //if (S.EndsWith("+'")) S = S.Substring(0, S.Length - 2);
            return S;
        }
		//converto il DBNull a null
		static object GetParamValue(object paramValue,ParameterValueKind PK) {
			if (paramValue == System.DBNull.Value)
				return null;
            if (PK == ParameterValueKind.StringParameter) {
                return paramValue.ToString();
            }
            if (PK == ParameterValueKind.NumberParameter) {
                return Convert.ToDecimal(paramValue);
            }
            if (PK == ParameterValueKind.CurrencyParameter) {
                return Convert.ToDecimal(paramValue);
            }
		    if (PK == ParameterValueKind.DateParameter) {
		        return Convert.ToDateTime(paramValue);
		    }
		    if (PK == ParameterValueKind.TimeParameter) {
		        return Convert.ToDateTime(paramValue);
		    }
            if (PK == ParameterValueKind.DateTimeParameter) {
                return Convert.ToDateTime(paramValue);
            }
            return paramValue;
		}

		//Metodo che torna il corretto valore null per tipo
		static object GetNullValueType(ParameterFieldDefinition param) {
			switch (param.ParameterValueKind) {
				case ParameterValueKind.NumberParameter:
					return 0;
				case ParameterValueKind.StringParameter:
					return "";
				default:
					return null;
			}
		}

		public static  CrystalDecisions.Shared.PaperSize GetCRSize(PaperKind Formato) {
			switch(Formato) {
				case PaperKind.A3:
					return CrystalDecisions.Shared.PaperSize.PaperA3;
				case PaperKind.A4:
					return CrystalDecisions.Shared.PaperSize.PaperA4;
				case PaperKind.A4Small: 
					return CrystalDecisions.Shared.PaperSize.PaperA4Small;
				case PaperKind.A5: 
					return CrystalDecisions.Shared.PaperSize.PaperA5;
				case PaperKind.B4: 
					return CrystalDecisions.Shared.PaperSize.PaperB4;
				case PaperKind.B4Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeB4;
				case PaperKind.B5: 
					return CrystalDecisions.Shared.PaperSize.PaperB5;
				case PaperKind.B5Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeB5;
				case PaperKind.B6Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeB6;
				case PaperKind.C3Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeC3;
				case PaperKind.C4Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeC4;
				case PaperKind.C5Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeC5;
				case PaperKind.C6Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeC6;
				case PaperKind.C65Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeC65;
				case PaperKind.CSheet: 
					return CrystalDecisions.Shared.PaperSize.PaperCsheet;
					//				case PaperKind.Custom: 
					//					return CrystalDecisions.Shared.PaperSize.;
				case PaperKind.DLEnvelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeDL;
				case PaperKind.DSheet: 
					return CrystalDecisions.Shared.PaperSize.PaperDsheet;
				case PaperKind.ESheet: 
					return CrystalDecisions.Shared.PaperSize.PaperEsheet;
				case PaperKind.Executive: 
					return CrystalDecisions.Shared.PaperSize.PaperExecutive;
				case PaperKind.Folio: 
					return CrystalDecisions.Shared.PaperSize.PaperFolio;
				case PaperKind.ItalyEnvelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopeItaly;
				case PaperKind.Ledger: 
					return CrystalDecisions.Shared.PaperSize.PaperLedger;
				case PaperKind.Legal: 
					return CrystalDecisions.Shared.PaperSize.PaperLegal;
				case PaperKind.Letter: 
					return CrystalDecisions.Shared.PaperSize.PaperLetter;
				case PaperKind.LetterSmall: 
					return CrystalDecisions.Shared.PaperSize.PaperLetterSmall;
				case PaperKind.Note: 
					return CrystalDecisions.Shared.PaperSize.PaperNote;
				case PaperKind.Number10Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelope10;
				case PaperKind.Number11Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelope11;
				case PaperKind.Number12Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelope12;
				case PaperKind.Number14Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelope14;
				case PaperKind.Number9Envelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelope9;
				case PaperKind.PersonalEnvelope: 
					return CrystalDecisions.Shared.PaperSize.PaperEnvelopePersonal;
				case PaperKind.Quarto: 
					return CrystalDecisions.Shared.PaperSize.PaperQuarto;
				case PaperKind.Standard10x14: 
					return CrystalDecisions.Shared.PaperSize.Paper10x14;
				case PaperKind.Standard11x17: 
					return CrystalDecisions.Shared.PaperSize.Paper11x17;
				case PaperKind.Statement: 
					return CrystalDecisions.Shared.PaperSize.PaperStatement;
				case PaperKind.Tabloid: 
					return CrystalDecisions.Shared.PaperSize.PaperTabloid;
				default:
					return CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			}
		}

	}
}
