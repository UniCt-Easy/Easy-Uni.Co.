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
using System.Drawing;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.IO;
using download;//download
using utility;//utility
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Drawing.Printing;
using System.Linq;
using security_function;
using funzioni_configurazione;
using System.Net;
using System.Collections.Specialized;

namespace resultparameter_default{//Report//
	/// <summary>
	/// Summary description for frmReportParameter.
	/// </summary>
	public class frmReportParameter : System.Windows.Forms.Form {
	
		private System.Windows.Forms.Button btnStampa;
		private System.Windows.Forms.Button btnAnnulla;
		private System.ComponentModel.Container components = null;
		private string Module;
		private string ReportName;
		string ReportTitle;
		private /*Rana:Report.*/ReportVista reportVista1;
		public /*Rana:Report.*/vistaForm DS;
		private Easy_DataAccess myDA;
		private DataTable myPrymaryTable;
		private bool InsertMode;
		const string DummyPrimaryKey = "reportname";
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Button btnParamUfficiali;
		MetaData Meta;
		bool RefillCustomReportParam=false;
		enum appfmts {_dateshort=13, _datetimeshort, _datelong, _datetimelong, 
					_time, _timestamp, _datetimeansi, _dateansi, _datedbf, _general=22, 
					_number,  _currency, _serial=25, _longserial, _percentage, 
					_highpercentage, _year=29, _twodigit, _threedigit, _generalus, 
					_twodecimal, _twodecimalsep, _threedecimal, _threedecimalsep, _integer=37, 
					_none=38, _euro, _sixdecimalsep};

		ArrayList ComboToPreset;
		
		//per la gestione dell'autochoose non da libreria
		Hashtable hashChoose = new Hashtable();
		//contatore per Alias
		int AliasCount=0;

		int VPosition = 15;
		int HPosition = 10;
		int LabelHeight = 16;
		int TextHeight = 30;
		int HelpHeight = 36;
		int ControlWidth = 300;
		private Button btnDiagnostic;
		int RigaSuccessiva = 44;
		private DataRow ModuleReport=null;
		private DataRow[] Parameters;
		Http http=null;
		string ReportDir="";
		string[] siti = null;
		private Button btnPatch;
		private Button btnAcrobat;
		private static string m_CheckReportLog="";
        private CheckBox chkClose;
        bool OnePrintObbligatorio = false;
        QueryHelper QHS;
        CQueryHelper QHC;

		public frmReportParameter() {
			InitializeComponent();
			InsertMode = false;
			ComboToPreset = new ArrayList();
            isInited = true;
		}
        DataAccess Conn;

		private string  FillReportVista(string ModuleNameReportName,DataAccess DA) {
			ClearDataSet.RemoveConstraints(reportVista1);
			GetData MyGetData = new GetData();
            this.Conn = DA;
			MyGetData.InitClass(reportVista1,DA,"report");
			DataRow DR = reportVista1.report.NewRow();
			
			Module = HelpForm.GetField(ModuleNameReportName,0);
			ReportName = HelpForm.GetField(ModuleNameReportName,1);

//			if (Module.ToLower().Trim().EndsWith("-ufficiali"))
//				btnParamUfficiali.Visible=true;
//			else 
//				btnParamUfficiali.Visible=false;
			
			DR["reportname"] = ReportName;
            string clearError = DA.LastError;
            MyGetData.SEARCH_BY_KEY(DR);
            if (reportVista1.report.Rows.Count == 0) {
                string err = DA.LastError;
                if (err != null) {
                    return "Errore nell'accesso al db:" + err;
                }
                return "Occorre eseguire un File\\Menu\\Aggiorna Menu.";
            }
			MyGetData.DO_GET(false,null);
			MyGetData.DO_GET_TABLE(reportVista1.customselection,null,null,false,null);
            OnePrintObbligatorio = !security_function.Sec_Function.funzioneConsentita(DA, "multiprint");
			return null;
		}

		/// <summary>
		/// Create primary table in DS and assign to "myPrimaryTable"
		/// </summary>
		/// <param name="ReportParameters"></param>
		void CreatePrimaryTable(DataRow[] ReportParameters){
			myPrymaryTable = new DataTable("resultparameter");
			
			//Create a dummy primary key
			DataColumn DCPK = new DataColumn(DummyPrimaryKey,typeof(string));
			DCPK.DefaultValue = ReportName;
			myPrymaryTable.Columns.Add(DCPK);
			myPrymaryTable.PrimaryKey = new DataColumn[]{DCPK};
			
			//Add parameters as primary table fields
			foreach (DataRow Param in ReportParameters){
				System.Type ColType = GetTypeFromSysType(Param["systype"].ToString());
				string ColName = Param["paramname"].ToString();
				DataColumn Col = new DataColumn(ColName,ColType);

				object Def= DefaultForParameter(Param);
				if (Def!=DBNull.Value) Col.DefaultValue= Def;
				
				//il campo è gestito se è flag combo = 'S' o se 
				//il campo selectioncode (manage/chhose) non è null
				bool Gestito=((Param["iscombobox"].ToString().ToUpper()=="S") ||
					(Param["selectioncode"].ToString()!=""));

				bool ConvertNullToPerc=(Gestito && 
					(Param["noselectionforall"].ToString().ToUpper() == "S"));

				Col.ExtendedProperties["ConvertNullToPerc"]= ConvertNullToPerc;
				///TODO: Verificare Gestione AllowDBNull
				Col.AllowDBNull = (Param["hintkind"].ToString()=="NOHINT") || ConvertNullToPerc;

				myPrymaryTable.Columns.Add(Col);
                if (OnePrintObbligatorio && Col.ColumnName == "oneprint") {
                    Col.DefaultValue = "S";
                }
                
			}
            ControllaObbligatorietaResp();
            ControllaObbligatorietaUpb();
			DS.Tables.Add(myPrymaryTable);
		}

        object CalcDefaultForManager() {
            //if (Session["CodiceResponsabile"] != null) return Session["CodiceResponsabile"];
            string filter = Conn.SelectCondition("manager", true);
            filter = QHS.AppAnd(filter, QHS.CmpEq("active", "S"));
            DataTable Man = Conn.RUN_SELECT("manager", "idman", null, filter, null, false);
            if (Man.Rows.Count == 1) return Man.Rows[0]["idman"];
            return DBNull.Value;
        }

        void ControllaObbligatorietaResp() {
            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
            if (!GestioneClass.UsesAttribues(Conn)) return;
            if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp
            bool manager_obbligatorio = true; 
            object all_man = Conn.GetUsr("all_man");
            if (all_man != null && all_man.ToString().ToUpper() == "S") manager_obbligatorio=false;
            

            if (myPrymaryTable.Columns.Contains("idman")) {
                DataColumn C1 = myPrymaryTable.Columns["idman"];
                C1.AllowDBNull = !manager_obbligatorio;
                C1.Caption = "Responsabile";
                HelpForm.SetDenyZero(C1, manager_obbligatorio);
                C1.DefaultValue = CalcDefaultForManager();
            }

            if (myPrymaryTable.Columns.Contains("idmanager")) {
                DataColumn C2 = myPrymaryTable.Columns["idmanager"];
                C2.AllowDBNull = !manager_obbligatorio;
                C2.Caption = "Responsabile";
                HelpForm.SetDenyZero(C2, manager_obbligatorio);
                C2.DefaultValue = CalcDefaultForManager();
            }

        }



        void ControllaObbligatorietaUpb() {
            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
            if (!GestioneClass.UsesAttribues(Conn)) return;
            if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp
            if (myPrymaryTable.Columns.Contains("idman")) return; //c'è il responsabile, basta limitare quello
            object all_upb = Conn.GetUsr("all_upb");
            if (all_upb != null && all_upb.ToString().ToUpper() == "S") return;
            if (myPrymaryTable.Columns.Contains("idupb")) {
                DataColumn C1 = myPrymaryTable.Columns["idupb"];
                C1.AllowDBNull = false;
                C1.Caption = "UPB";
            }
        }


		/// <summary>
		/// Aggiunge una label
		/// </summary>
		/// <param name="Param">riga di reportparameter</param>
		/// <returns>La label appena creata</returns>
		private Label InserisciLabel(DataRow Param) {
			Label LB = new Label();
			this.Controls.Add(LB);
			LB.Location = (new Point(HPosition,VPosition));
			LB.Width = ControlWidth;
			LB.Height = LabelHeight;
			//Leggo la descrizione dal DataRow
			LB.Text = Param["description"].ToString().Trim();
			LB.TextAlign = ContentAlignment.TopLeft;
			return LB;
		}

		/// <summary>
		/// Aggiunge un TextBox
		/// </summary>
		/// <param name="Param">riga di reportparameter</param>
		/// <returns>Il TextBox appena creato</returns>
		private TextBox InserisciTextBox(DataRow Param) {
			TextBox TBP = new TextBox();
			this.Controls.Add(TBP);
			TBP.Location = new Point(HPosition,VPosition+LabelHeight);
			TBP.Width = ControlWidth;
			TBP.Height = TextHeight;
			TBP.TextAlign= HorizontalAlignment.Right;
			TBP.Tag = myPrymaryTable.TableName + "."+ Param["paramname"].ToString();
			string fmt = Param["tag"].ToString();
			//if (fmt=="")fmt="g";
			if (fmt!=null) TBP.Tag += "."+fmt;
			return TBP;
		}

		/// <summary>
		/// Aggiunge un TextBox multiline
		/// </summary>
		/// <param name="help">Il testo del controllo</param>
		private void InserisciHelp(string help) {
			//Text box dell'Help
			TextBox TBHelp = new TextBox();
			this.Controls.Add(TBHelp);
				
			TBHelp.Location = (new Point(HPosition + ControlWidth + 10, VPosition));
			TBHelp.ReadOnly = true;
			TBHelp.Width = ControlWidth;
			TBHelp.Multiline = true;
			TBHelp.TabStop=false;
			TBHelp.ScrollBars = ScrollBars.Vertical;
			TBHelp.Height = HelpHeight;
			TBHelp.Text = help;
		}
		private GroupBox InserisciGroupBox(DataRow Param) {
			string descr=Param["description"].ToString().Trim();
			return InserisciGroupBox(Param,descr);
		}

		/// <summary>
		/// Aggiunge un GroupBox
		/// </summary>
		/// <param name="Param">riga di reportparameter</param>
		/// <returns>Il GroupBox creato</returns>
		private GroupBox InserisciGroupBox(DataRow Param, string descr) {
			GroupBox grp = new GroupBox();
			grp.Name="gb"+Param["paramname"].ToString();
			descr=myDA.Compile(descr,true);
			grp.Text=descr;
			if (descr ==null || descr=="" || descr=="null") grp.Enabled=false;
			this.Controls.Add(grp);
			//la riduzione di VPosition serve per l'allineamento con l'help
			grp.Location=new Point(HPosition, VPosition-4);
			grp.Height=HelpHeight+5;
			grp.Width=ControlWidth;
			return grp;
		}

		/// <summary>
		/// Aggiunge una ComboBox
		/// </summary>
		/// <param name="Param">riga di reportparameter</param>
		/// <param name="IsAlias">True se la tabella padre esiste già nel DataSet</param>
		private void InserisciCombo(DataRow Param, bool IsAlias) {
			
			string tablename=Param["datasource"].ToString();
			string paramname=Param["paramname"].ToString();
			if (IsAlias) {
				tablename+=AliasCount;
			}
			ComboBox CB = new ComboBox();
			this.Controls.Add(CB);
			CB.Location = new Point(HPosition,VPosition+LabelHeight);
			CB.Width = ControlWidth;
			CB.DropDownStyle = ComboBoxStyle.DropDownList;
			CB.Tag = myPrymaryTable.TableName+"."+paramname;
			CB.DataSource = DS.Tables[tablename];
			CB.ValueMember = Param["valuemember"].ToString();
			CB.DisplayMember = Param["displaymember"].ToString();
			if ((paramname.IndexOf("level")>=0) &&(Param["hintkind"].ToString().ToUpper()=="NOHINT")){
				ComboToPreset.Add(CB);
			}
            if ((paramname.IndexOf("idtreasurer") >= 0) && (Param["hintkind"].ToString().ToUpper() == "NOHINT")) {
                ComboToPreset.Add(CB);
            }
		}

		/// <summary>
		/// Verifica se il parametro ha una gestione custom
		/// </summary>
		/// <param name="custom">tag</param>
		/// <returns>True se custom</returns>
		private bool IsCustomField(string custom) {
			if (custom=="") return false;
			//per i tipi costant, radio, check, etc... non eseguo nessun controllo
			if (!custom.ToLower().StartsWith("custom")) return true;
			//vedo se c'è una riga in customselection con codice
			string selectioncode=custom.Substring(custom.IndexOf(".")+1);
			DataRow row = reportVista1.customselection.FindByselectioncode(selectioncode);
			return (row!=null);
		}

	    private IMetaDataDispatcher disp;
		/// <summary>
		/// Metodo per la creazione del Form per l'inserimento dei parametri da
		/// passare alle storedprocedure dei Report di stampa.
		/// Questo metodo lavora su due Dataset DS e ReportVista.
		/// </summary>
		/// <param name="ModuleNameReportName">campo modulename di reportparameter</param>
		/// <param name="DA">DataAccess</param>
		/// <returns>True se succesfull</returns>
		public bool BuildForm(string ModuleNameReportName,MetaData M) {
			Meta=M;
			MetaDataDispatcher E= M.Dispatcher;
		    disp = E;
			DataAccess DA = E.Conn;
			myDA = DA as Easy_DataAccess;
            QHC = new CQueryHelper();
            QHS = myDA.GetQueryHelper();
			//Riempie il dataset  ReportVista delle tabelle che mi servono a costruire il Form
			string result = FillReportVista(ModuleNameReportName,DA);
            //			if(reportVista1.Tables["reportparameter"].Rows.Count == 0) {form dei parametri
            //				return false;
            //			}

            if (result!=null) {             //reportVista1.Tables["report"].Rows.Count==0
                M.ExtraParameter=result;
				return false;
			}

			ModuleReport = reportVista1.Tables["report"].Rows[0];
			ReportTitle=  ModuleReport["description"].ToString();

			Parameters = reportVista1.reportparameter.Select(null,"number asc");
			
			CreatePrimaryTable(Parameters);

			////////////////////////////////////////////////////////////////////////////
			//Inizia la Procedura per l'inserimento dei controlli nel Form.
		
			VPosition +=RigaSuccessiva;  //Incrementa il puntatore per la riga successiva

			//Per ogni parametro ovvero per ogni riga presente nella tabella reportparameter
			foreach(DataRow Param in Parameters) {
				bool skipSizeIncrement=false;

				string selectioncode=Param["selectioncode"].ToString();
				string paramname=Param["paramname"].ToString();
				//verifica se sono in presenza di tabella alias 
				//(i campi devono contenere la stringa "|alias")
				bool IsAlias=(Param["paramname"].ToString().IndexOf("|alias")!=-1);
				if (!IsAlias){
					string table= Param["datasource"].ToString();
					if ((table!="")&&DS.Tables.Contains(table))IsAlias=true;
                    if (reportVista1.reportparameter.Select(QHC.CmpEq("datasource",table)).Length>1)IsAlias=true;
				}
				if (IsAlias) ++AliasCount;

				bool customField=IsCustomField(selectioncode);

				if (customField) {
					//E' un campo nascosto?
					if (selectioncode.ToLower()=="costant.hidden") skipSizeIncrement=true;

                    skipSizeIncrement = !AddCustomControl(selectioncode, 
						myPrymaryTable.TableName, paramname,
						HPosition, VPosition, Param, IsAlias);
				}
				else {
					if(Param["iscombobox"].ToString().ToUpper()=="S") {
						InserisciLabel(Param);
						if(!AddTableToDS(Param, IsAlias)){
							Meta.ExtraParameter=" Errore nella costruzione del parametri (campo "+
								Param["paramname"].ToString()+" su tabella "+			
									Param["datasource"].ToString()+")";
							return false;
						}
						InserisciCombo(Param, IsAlias);
					}
					else {
						InserisciLabel(Param);
						InserisciTextBox(Param);
					}
				}

				if (!skipSizeIncrement) {
					if (customField) {
						if (Param["help2"].ToString()!="")
							InserisciHelp(GetPrintable(myDA.Compile(Param["help2"].ToString(),true)));
						else
							InserisciHelp(GetPrintable(myDA.Compile(Param["help"].ToString(),true)));
					}
					else
						InserisciHelp(GetPrintable(myDA.Compile(Param["help"].ToString(),true)));
					//Incrementa il puntatore per la riga successiva
					VPosition +=RigaSuccessiva;
				}

			}//Fine foreach

			//Ridefinisce la lunghezza del form
			int myheigth= VPosition + 120 + btnDiagnostic.Height;
			if (myheigth<312) myheigth=312;
			this.Height = myheigth;

			return true;

		}//Fine BuildForm

		/// <summary>
		/// Aggiunge al Form un controllo custom, tipo check, radio, o textbox
		/// per l'AutoChoose o AutoManage
		/// </summary>
		/// <param name="tag">campo 'selectioncode' di reportparameter</param>
		/// <param name="tablename">Tabella resultparameter creata a runtime</param>
		/// <param name="paramname">nome del parametro colonna di resultparameter</param>
		/// <param name="HPosition">Posizione orizzontale del controllo da posizionare</param>
		/// <param name="VPosition">Posizione verticale del controllo da posizionare</param>
		/// <param name="param">Riga di reportparameter</param>
		/// <param name="IsAlias">True se la tabella padre esiste già nel DataSet</param>
		private bool AddCustomControl(string tag, string tablename, string paramname,
			int HPosition, int VPosition, DataRow param, bool IsAlias) {
			if (tag=="") return false;
			int dotpos=tag.IndexOf(".");
			string tipo=tag.Substring(0, dotpos);
			string[] token=tag.Substring(dotpos+1).Split('|');
            

			switch (tipo.ToLower()) {
				case "check":
					CheckBox ctrl = new CheckBox();
					ctrl.Tag=tablename+"."+paramname+":"+token[0]+":"+token[1];
					ctrl.Text=token[2];
					ctrl.Width=ControlWidth - 20;
					this.Controls.Add(ctrl);
					ctrl.Location=new Point(HPosition,VPosition+8);
                    if (OnePrintObbligatorio && paramname == "oneprint") {
                        ctrl.Enabled = false;
                    }
					break;

				case "radio":
					GroupBox grp = InserisciGroupBox(param);

					int i;
					int Altezza=15;
					for(i=0;i<token.Length/2;i++) {
						RadioButton rb = new RadioButton();
						rb.Tag=tablename+"."+paramname+":"+token[2*i];
						rb.Text=token[2*i+1];
						rb.Width=ControlWidth-20;
						rb.Height=LabelHeight;
						grp.Controls.Add(rb);
						rb.Location=new Point(12, Altezza);
						Altezza+=rb.Height;
					}
					grp.Height=Altezza+10;
					this.VPosition+=(grp.Height-HelpHeight-4);

					break;

				case "custom":
					string selectioncode=token[0];
					ReportVista.customselectionDataTable T=reportVista1.customselection;
					DataRow selRow=T.FindByselectioncode(selectioncode);
					
					if (selRow==null) return false;
					string parenttable=selRow["tablename"].ToString();
					string editlisttype=selRow["editlisttype"].ToString();
					string selectiontype=selRow["selectiontype"].ToString();
					string fieldname=selRow["fieldname"].ToString();
					string filter= myDA.Compile(selRow["filter"].ToString(),true);
                    if (filter == "(idsorkind='null')") return false; //filter = "(idsorkind is null)";
					string filterapp=filter;
					AddCustomTableToDS(selRow, paramname, IsAlias);
               		if (IsAlias) parenttable+=AliasCount;


                    GestioneClass GestAttributi = GestioneClass.GetGestioneClassForField(selectioncode, myDA, parenttable);

                    if (GestAttributi != null) {
                        selectiontype = "C";
                        myPrymaryTable.Columns[paramname].DefaultValue = GestAttributi.DefaultValue();
                        bool denynull  = !GestAttributi.AllowNull();
                        myPrymaryTable.Columns[paramname].AllowDBNull = !denynull;
                        HelpForm.SetDenyZero(myPrymaryTable.Columns[paramname], denynull);
                        HelpForm.SetDenyNull(myPrymaryTable.Columns[paramname], denynull);

                        if (GestAttributi.AllowSelection() == false) {
                            return false;
                        }


                    }

					if (filter!="")filterapp="."+filterapp;


					// C(hoose) o M(anage)?
					bool IsAutoManage = (selectiontype.ToUpper()=="M");
					bool IsAutoChoose = (selectiontype.ToUpper()=="C");
					bool IsComboManage = (selectiontype.ToUpper()=="U");

					//Inserisco un groupbox
					GroupBox gb = InserisciGroupBox(param,selRow["selectionname"].ToString());

					//aggiungo un button
					Button btn = new Button();
					btn.Name="btn"+paramname;
					btn.Text="Seleziona";
					btn.Location=new Point(12,14);
					btn.Width=62;
					btn.Height=TextHeight-9;
					gb.Controls.Add(btn);
					TextBox TBP=null;
					if (IsAutoChoose||IsAutoManage){
						//e un textbox
						TBP = new TextBox();
						TBP.Name="txt"+paramname;
						TBP.Location = new Point(btn.Location.X+btn.Width+1,14);
						TBP.Width = ControlWidth - btn.Width - 20;
						TBP.Height = TextHeight;
						TBP.Tag=parenttable+"."+fieldname+"?x";
						gb.Controls.Add(TBP);
					}
					if (IsComboManage){
						
						btn.Tag="manage."+parenttable+"."+editlisttype+filterapp;

						ComboBox CBP = new ComboBox();

						string tablename2=param["datasource"].ToString();
						string paramname2=param["paramname"].ToString();
						if (IsAlias) {
							tablename2+=AliasCount;
						}
						ComboBox CB = new ComboBox();
						CB.Location = new Point(btn.Location.X+btn.Width+1,14);
						CB.Width = ControlWidth - btn.Width - 20;
						CB.DropDownStyle = ComboBoxStyle.DropDownList;
						CB.Tag = myPrymaryTable.TableName+"."+paramname2;
						CB.DataSource = DS.Tables[tablename2];
						CB.ValueMember = param["valuemember"].ToString();
						CB.DisplayMember = param["displaymember"].ToString();
						if ((paramname.IndexOf("level")>=0) &&(param["hintkind"].ToString().ToUpper()=="NOHINT")){
							ComboToPreset.Add(CB);
						}
                        if ((paramname.IndexOf("idtreasurer") >= 0) && (param["hintkind"].ToString().ToUpper() == "NOHINT")) {
                                ComboToPreset.Add(CB);
                        }
                        gb.Controls.Add(CB);
					
						//TBP.Name="txt"+paramname;
						//TBP.Height = TextHeight;
						//TBP.Tag=parenttable+"."+fieldname+"?x";
					}
                    if (GestAttributi != null) {
                        TBP.TextAlign = HorizontalAlignment.Left;
                        btn.Tag = GestAttributi.BtnTag();
                        gb.Tag = "AutoChoose." + TBP.Name + "." + editlisttype + "."+GestAttributi.GetFilterAutoChoose();

                    }
                    else {

                        if (IsAutoManage) {
                            TBP.TextAlign = HorizontalAlignment.Right;
                            btn.Tag = "manage." + parenttable + "." + editlisttype + filterapp;
                            gb.Tag = "AutoManage." + TBP.Name + "." + editlisttype + filterapp;
                        }
                        if (IsAutoChoose) {
                            TBP.TextAlign = HorizontalAlignment.Left;
                            btn.Tag = "choose." + parenttable + "." + editlisttype + filterapp;
                            gb.Tag = "AutoChoose." + TBP.Name + "." + editlisttype + filterapp;
                        }
                    }
					break;

				case "costant":
					//controlli il cui valore è costante (es. il filtro bilancio deve essere 'E')
					bool visible=!(token[0].ToLower()=="hidden");
					Label lb = InserisciLabel(param);
					lb.Visible=visible;
					TextBox tb = InserisciTextBox(param);
					tb.Visible=visible;
					tb.ReadOnly=true;
                    if (!visible) return false;
					break;
			}
            return true;
		}

		/// <summary>
		/// Tabella parent da aggiungere al dataset in caso di AutoChoose/AutoManage
		/// </summary>
		/// <param name="customRow">riga di customselection</param>
		/// <param name="paramname">valore della colonna paramname</param>
		/// <param name="IsAlias">True se sono in presenza di tabella alias</param>
		private void AddCustomTableToDS(DataRow customRow, string paramname, bool IsAlias) {
			
			string parenttable=customRow["tablename"].ToString();
			string RealTable=parenttable;

			//Aggiunge il nuovo DataTable se non c'è già
			if(DS.Tables[parenttable] == null || IsAlias) {
				DataTable T = myDA.CreateTableByName(parenttable,null);
			    if (T.PrimaryKey.Length == 0) {
			        var m = disp.Get(parenttable);
			        if (m.primaryKey() != null && m.primaryKey().Length>0) {
			            T.PrimaryKey = (from string f in m.primaryKey() select T.Columns[f]).ToArray();
			        }
			    }
				if (IsAlias) {
					string AliasTable=parenttable+AliasCount;
					T.TableName=AliasTable;
					parenttable=AliasTable;
					DataAccess.SetTableForReading(T, RealTable);
				}
				DS.Tables.Add(T);
				string relatedcolname=customRow["relationfield"].ToString();
				DataColumn ParentCol = T.Columns[relatedcolname];
				DataColumn ChildCol = myPrymaryTable.Columns[paramname];
				string relname = parenttable+myPrymaryTable.TableName;
				DS.Relations.Add(relname, ParentCol, ChildCol, false);
			}
			DataTable ParentTable = DS.Tables[parenttable];
			string Filter = customRow["filter"].ToString().Trim();

            //Aggiunge filtro su esercizio se chiave primaria contiene
            // un campo di nome esercizio
            if (QueryCreator.IsPrimaryKey(ParentTable, "ayear")) {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            }

            if (Filter!=""){
				Filter= myDA.Compile(Filter,true);
                if (Filter == "(idsorkind='null')") {
                    Filter = "(idsorkind is null)";
                }
				GetData.SetStaticFilter(ParentTable, Filter);
			}

			string Extra = customRow["extraparameter"].ToString();
			if (Extra!=""){
				Extra= myDA.Compile(Extra,true);
			    Extra = Extra.Replace("='null'", " is null ");
				ParentTable.ExtendedProperties[MetaData.ExtraParams]=Extra;
			}

		}

		//Gli viene passata una riga della tabella "reportparameter"
		//che deve avere "iscombobox" = "S" per giustificare l'aggiunta della
		//tabella al dataset.
		//Tale tabella sarà il datasource del combobox
		//e dovrà avere una Relation con la tabella principale.
		//Il Campo con nome "displaymember" dovrà essere campo chiave
		//della tabella che sto aggiungendo al dataset.
		private bool AddTableToDS(DataRow Param, bool IsAlias) {
					
			string paramname= Param["paramname"].ToString();			
			string datasourceName = Param["datasource"].ToString();
			string RealTable=datasourceName;
			string CodeFieldName = Param["valuemember"].ToString();

			//Aggiunge il nuovo DataTable se non c'è già oppure se è un alias
			if(DS.Tables[datasourceName] == null || IsAlias) {
				DataTable T = myDA.CreateTableByName(datasourceName,null);
			    if (T.PrimaryKey.Length == 0) {
			        var m = Meta.Dispatcher.Get(datasourceName);
			        var k = m.primaryKey();
			        if (k != null && k.Length > 0) {
			            T.PrimaryKey = (from string fName in k select T.Columns[fName]).ToArray();
			        }
			    }
				if (IsAlias) {
					string AliasTable=datasourceName+AliasCount;
					T.TableName=AliasTable;
					datasourceName=AliasTable;
					DataAccess.SetTableForReading(T, RealTable);
				}
				DS.Tables.Add(T);
				if (T.Columns[CodeFieldName]==null) return false;
				if (myPrymaryTable.Columns[paramname]==null) return false;
				//Add datasource->PrimaryTable Relation
				DataColumn ParentCol = T.Columns[CodeFieldName];
				DataColumn ChildCol = myPrymaryTable.Columns[paramname];
				string relname = datasourceName+myPrymaryTable.TableName;
				DS.Relations.Add(relname, ParentCol, ChildCol, false);
			}

			//Per i parametri che hanno il campo filter avvalorato e che hanno il iscombobox = 'S' 
			//nella tabella reportparameter, imposto un filtro statico sulla tabella del dataset
			DataTable datasource = DS.Tables[datasourceName];
			string Filter = Param["filter"].ToString().Trim();
			if (Filter!=""){
				Filter= myDA.Compile(Filter, true);
				GetData.SetStaticFilter(datasource, Filter);
			}
			if (datasourceName.ToLower().IndexOf("level")>=0) {
				if (datasource.Columns["nlevel"]!=null){
					GetData.SetSorting(datasource, "nlevel");
					if (Filter!=""){
						GetData.CacheTable(datasource,Filter,"nlevel",true);
					}
					else {
						GetData.CacheTable(datasource,null,"nlevel",true);
					}
				}
			}
            if (datasourceName.ToLower().IndexOf("treasurer") >= 0) {
                if (datasource.Columns["flagdefault"] != null) {
                    GetData.SetSorting(datasource, "flagdefault DESC");
                    if (Filter != "") {
                        GetData.CacheTable(datasource, Filter, "flagdefault DESC", true);
                    }
                    else {
                        GetData.CacheTable(datasource, null, "flagdefault DESC", true);
                    }
                }
            }


			//Aggiunge filtro su esercizio se chiave primaria contiene
			// un campo di nome esercizio
			if ((Filter=="")&&(QueryCreator.IsPrimaryKey(datasource,"ayear"))){
				GetData.SetStaticFilter(datasource, $"(ayear=\'{Meta.GetSys("esercizio")}\')");
			}
			return true;
		}

		object DefaultForParameter(DataRow Param){
			string TipoDef = Param["hintkind"].ToString().ToUpper();
			DateTime DC = (DateTime) Meta.GetSys("datacontabile");
			switch(TipoDef){
				case "STRING":	//Other
					return Param["hint"].ToString();
				case "1/CURRM":   //Primo giorno del mese
					return new DateTime(DC.Year, DC.Month, 1);
				case "LASTDAY/CURRM":  //Ultimo giorno del mese
					return new DateTime(DC.Year, DC.Month, 
								DateTime.DaysInMonth(DC.Year, DC.Month));
				case "ACCOUNTYEAR": //esercizio corrente
					return Meta.GetSys("esercizio");
				case "NOHINT": //nessun valore predef.
					return DBNull.Value;
				case "1/1": //Primo giorno dell'anno
					return new DateTime(DC.Year,1,1);
				case "31/12": //Ultimo giorno dell'anno
					return new DateTime(DC.Year,12,31);
				case "ACCOUNTDATE": //Data Contabile
					return DC;
				default:
					return DBNull.Value;

			}

		}



		System.Type GetTypeFromSysType(string systype) {
			systype=systype.ToUpper();

			switch(systype) {
                case "BYTE": return typeof(byte);
                case "INT16": return typeof(short);
                case "INT32": return typeof(int); 
				case "DATETIME": return typeof(DateTime); 
				case "STRING": return typeof(string); 
				case "DECIMAL":return typeof(decimal);
				case "DOUBLE":return typeof(double);
				default:
					return typeof(string);
			}

		}


		public void MetaData_AfterClear() {
			Text= ReportTitle;
			if(InsertMode)return;
			InsertMode = true;
			MetaData.MainAdd(this);
		}

		string GetPrintable(string msg){
			string S= msg.Replace("\r","\n");
			S=S.Replace("\n\n","\n");
			S=S.Replace("\n","\r\n");
			return S;
		}

		public void MetaData_AfterActivation() {
			CheckPatch();
		}

		private void CheckPatch() {
//			DataTable T=reportVista1.report;
//			if (T==null || T.Rows.Count==0) return;
//			if (T.Rows[0]["papersize"].ToString().ToUpper()!="A3") return;
//			string reportname=T.Rows[0]["reportname"].ToString();
//			DateTime C_CRPE=new DateTime(2003,10,22);
//			DateTime C_CRQE=new DateTime(2003,8,28);
//			string commondir=Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
//			commondir+=@"\Crystal Decisions\2.0\bin\";
//			string crpe=commondir+"crpe32.dll";
//			string crqe=commondir+"crqe.dll";
//			FileInfo Fpe=new FileInfo(crpe);
//			FileInfo Fqe=new FileInfo(crqe);
//			DateTime dt_crpe=Fpe.LastWriteTime;
//			DateTime dt_crqe=Fqe.LastWriteTime;
//			if ((dt_crpe.CompareTo(C_CRPE)<0) || (dt_crqe.CompareTo(C_CRQE)<0)) {
//				btnPatch.Visible=true;
//				string msg="ATTENZIONE! E' necessario aggiornare il programma per quanto riguarda "+
//					"le stampe. Per una corretta stampa del documento è richiesto scaricare "+
//					"l'aggiornamento di Crystal Report cliccando sul bottone 'Scarica patch' in "+
//					"basso a destra o contattare il Centro Assistenza e richiederne l'installazione.";
//				MessageBox.Show(msg,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
//			}
		}

		public void MetaData_AfterFill(){
			
			if (ComboToPreset!=null){
				for (int i=0; i < ComboToPreset.Count; i++){
					ComboBox CB = (ComboBox) ComboToPreset[i];
					if (CB.Items.Count>1) CB.SelectedIndex=1;
				}
				ComboToPreset=null;
			}
			
			Text= ReportTitle;
			DS.AcceptChanges();

			

		}


		
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanSave=false;
			Meta.SearchEnabled=false;
			Meta.CanCancel=false;
		    Meta.mainRefreshEnabled = false;
		}

		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.reportVista1 = new resultparameter_default.ReportVista();
            this.DS = new resultparameter_default.vistaForm();
            this.btnStampa = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnParamUfficiali = new System.Windows.Forms.Button();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.btnPatch = new System.Windows.Forms.Button();
            this.btnAcrobat = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportVista1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // reportVista1
            // 
            this.reportVista1.DataSetName = "ReportVista";
            this.reportVista1.Locale = new System.Globalization.CultureInfo("en-US");
            this.reportVista1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnStampa
            // 
            this.btnStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStampa.Location = new System.Drawing.Point(642, 8);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(104, 24);
            this.btnStampa.TabIndex = 0;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(642, 192);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(104, 24);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(642, 40);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(104, 24);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Anteprima";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnParamUfficiali
            // 
            this.btnParamUfficiali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamUfficiali.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnParamUfficiali.Location = new System.Drawing.Point(642, 160);
            this.btnParamUfficiali.Name = "btnParamUfficiali";
            this.btnParamUfficiali.Size = new System.Drawing.Size(104, 24);
            this.btnParamUfficiali.TabIndex = 5;
            this.btnParamUfficiali.Text = "Altri Parametri";
            this.btnParamUfficiali.Click += new System.EventHandler(this.btnParamUfficiali_Click);
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiagnostic.Location = new System.Drawing.Point(642, 264);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(104, 40);
            this.btnDiagnostic.TabIndex = 6;
            this.btnDiagnostic.Text = "Correzione problemi";
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // btnPatch
            // 
            this.btnPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatch.Location = new System.Drawing.Point(530, 264);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(104, 40);
            this.btnPatch.TabIndex = 7;
            this.btnPatch.Text = "Scarica Patch";
            this.btnPatch.Visible = false;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // btnAcrobat
            // 
            this.btnAcrobat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcrobat.Location = new System.Drawing.Point(642, 72);
            this.btnAcrobat.Name = "btnAcrobat";
            this.btnAcrobat.Size = new System.Drawing.Size(104, 23);
            this.btnAcrobat.TabIndex = 8;
            this.btnAcrobat.Text = "Apri con Acrobat";
            this.btnAcrobat.Click += new System.EventHandler(this.btnAcrobat_Click);
            // 
            // chkClose
            // 
            this.chkClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(640, 101);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(106, 53);
            this.chkClose.TabIndex = 9;
            this.chkClose.Text = "Chiudi finestra dopo l\'operazione";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // frmReportParameter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(756, 308);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.btnAcrobat);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.btnDiagnostic);
            this.Controls.Add(this.btnParamUfficiali);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnStampa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmReportParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReportParameter";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmReportParameter_Closing);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.frmReportParameter_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.reportVista1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnAnnulla_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			this.Close();
			this.Dispose();
		}

	    private bool isInited = false;
		private void frmReportParameter_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
		    if (!isInited) {
                MessageBox.Show("Attendere il completamento dell'apertura della maschera prima di chiuderla", "Errore");
                e.Cancel = true;
		        return;
		    }
			DS.AcceptChanges();
			//			this.Close();
			//			this.Dispose();
		
		}

		enum formatostampa {video, pdf};

		private void frmReportParameter_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			DS.AcceptChanges();
		}

		private void btnStampa_Click(object sender, System.EventArgs e) {
			Stampa(false,formatostampa.video);
		}

		private void btnPreview_Click(object sender, System.EventArgs e) {
            object print_rs = Conn.DO_READ_VALUE("report", QHS.CmpEq("reportname", ReportName), "print_rs" );
            if (print_rs.ToString().ToUpper() == "S") {
                StampaReportingServices(true, formatostampa.video, sender, e);
            }
            else {
                Stampa(true, formatostampa.video);
            }
        }

        private void StampaReportingServices(bool Preview, formatostampa FMT, object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.Tables["resultparameter"].Rows.Count==0)return;
            if (!Meta.GetFormData(false)) return;
            object test = Conn.DO_SYS_CMD("select getdate()", true);
            if (test == null) {
                MessageBox.Show("La connessione al database è andata persa, occore ricollegarsi", "Errore");
                return;
            }
            DataSet DSCopy = DS.Copy();
            DataRow Params = DSCopy.Tables["resultparameter"].Rows[0];
            bool oneprint = false;
            bool denyprint = false;
            string flagoriginal = "";
            if (DS.Tables["resultparameter"].Columns.Contains("official"))
                flagoriginal = Params["official"].ToString().ToUpper();
            bool StampaUfficiale = false;
            if (flagoriginal == "S") StampaUfficiale = true;

            if (DS.Tables["resultparameter"].Columns.Contains("oneprint")) {
                if (Params["oneprint"].ToString().ToUpper() == "S") oneprint = true;
            }

            if (oneprint && StampaUfficiale && Preview) {
                MessageBox.Show("Non sarà possibile stampare l'anteprima poiché " +
                    "è richiesta una stampa ufficiale", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                denyprint = true;
            }

            btnStampa.Enabled = false;
            btnPreview.Enabled = false;
            btnAcrobat.Enabled = false;
            btnParamUfficiali.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            ModuleReport = reportVista1.Tables["report"].Rows[0];

            //Hashtable usata solo per EseguiSpDoUpdate
            //Hashtable ReportParams= new Hashtable();			
            foreach (DataColumn C in myPrymaryTable.Columns) {
                if (C.ColumnName == DummyPrimaryKey) continue;
                bool Convert = (bool)C.ExtendedProperties["ConvertNullToPerc"];
                Type tipo = Params.Table.Columns[C.ColumnName].DataType;
                if (Convert && (tipo == typeof(string)) && (Params[C.ColumnName].ToString() == ""))
                    Params[C.ColumnName] = "%"; 
            }

            DS.AcceptChanges();

            string elencoparametri = "";
            foreach (DataColumn c in Params.Table.Columns) {
                elencoparametri += c.ColumnName + "=" + Params[c.ColumnName].ToString() + ";";
            }

            //FrmReportingServices fRptServ = new FrmReportingServices((Easy_DataAccess)myDA, Params, ModuleReport, Meta, Preview);
            //if (Preview) {
            //    fRptServ.Show(this);
            //}
            //fRptServ.FrmReportingServices_Load(sender, e);
            BuildWebReportView(Params);
            if (chkClose.Checked) {
                Close();
            }
            else {
                btnStampa.Enabled = true;
                btnAcrobat.Enabled = true;
                btnPreview.Enabled = true;
                btnParamUfficiali.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
        }

        bool Called = false;
        private void BuildWebReportView(DataRow Params) {
            if (Called) return;
            Called = true;

            // carico l'url del server di Reporting Services -----------------------------------------
            DataTable config_reportingservices = Conn.RUN_SELECT("config_reportingservices", "*", null, null, null, false);

            string myQuerystring = "";

            foreach (DataColumn c in Params.Table.Columns) {
                if (c.ColumnName == "reportname") {
                    continue;
                }
                if (myQuerystring != "") myQuerystring += "&";
                myQuerystring += c.ColumnName + "=" + Params[c.ColumnName].ToString();
            }


            string CodeDepartment = Meta.security.GetSys("database").ToString();

            var b = DataAccess.CryptString(myQuerystring);
            var logparamCript = QueryCreator.ByteArrayToString(b);
            //------------------------------------------------
            string url = config_reportingservices.Rows[0]["urlwebreportviewer"].ToString();
            if (!url.EndsWith("/")) url += "/";

            var wb = new WebClient();
            var data = new NameValueCollection {
                ["id"] = Guid.NewGuid().ToString(),
                ["codeDepartment"] = CodeDepartment,
                ["reportName"] = Params["reportname"].ToString(),
                ["parameters"] = logparamCript
            };

            //url = "https://localhost:44317/";

            var response = wb.UploadValues(url + "GetReportInfo.aspx", "POST", data);
            string responseInString = Encoding.UTF8.GetString(response);
            if (responseInString.ToUpperInvariant().StartsWith("OK")) {
                var sInfo = new System.Diagnostics.ProcessStartInfo(url + "ShowReport.aspx?id=" + data["id"]);
                System.Diagnostics.Process.Start(sInfo);
            }
            else {
                MessageBox.Show($"Errore nell'accesso al server dei report {url} ", "Errore");
            }

            this.Close();
            this.Dispose();
        }


        private void Stampa(bool Preview, formatostampa FMT) {
		    if (Meta.IsEmpty) return;
            if (DS.Tables["resultparameter"].Rows.Count==0)return;
			if(!Meta.GetFormData(false))return;
		    object test = Conn.DO_SYS_CMD("select getdate()",true);
		    if (test==null) {
		        MessageBox.Show("La connessione al database è andata persa, occore ricollegarsi", "Errore");
		        return;
		    }
			DataSet DSCopy = DS.Copy();
			DataRow Params = DSCopy.Tables["resultparameter"].Rows[0];
            bool oneprint = false;
            bool denyprint = false;
            string flagoriginal = "";
            if (DS.Tables["resultparameter"].Columns.Contains("official"))
                flagoriginal = Params["official"].ToString().ToUpper();
            bool stampaUfficiale = flagoriginal == "S";


            if (DS.Tables["resultparameter"].Columns.Contains("oneprint")) {
                if (Params["oneprint"].ToString().ToUpper() == "S") oneprint = true;
            }


            if (oneprint && stampaUfficiale && FMT == formatostampa.pdf) {
                MessageBox.Show("Non è possibile creare il file pdf se è richiesta una stampa ufficiale protetta", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (oneprint && stampaUfficiale && Preview) {
                MessageBox.Show($"Non sarà possibile stampare l'anteprima poiché è richiesta una stampa ufficiale", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                denyprint = true;
            }

			if (RefillCustomReportParam) {
//				myDA.RUN_SELECT_INTO_TABLE(reportVista1.customreportparameter,
//					null, "(officialname="+QueryCreator.quotedstrvalue(ReportName, true)+")",
//					null, true);
			}

			btnStampa.Enabled=false;
			btnPreview.Enabled=false;
            btnAcrobat.Enabled = false;
			btnParamUfficiali.Enabled=false;

			Cursor.Current = Cursors.WaitCursor;
			
			ModuleReport = reportVista1.Tables["report"].Rows[0];

			//Hashtable usata solo per EseguiSpDoUpdate
			//Hashtable ReportParams= new Hashtable();			
			foreach (DataColumn C in myPrymaryTable.Columns){
				if (C.ColumnName == DummyPrimaryKey) continue;
				bool Convert = (bool) C.ExtendedProperties["ConvertNullToPerc"];
                Type tipo = Params.Table.Columns[C.ColumnName].DataType;
                if (Convert && (tipo == typeof(string)) && (Params[C.ColumnName].ToString() == ""))
                    Params[C.ColumnName] = "%"; //ReportParams[C.ColumnName] ="%";
				//else
				//	ReportParams[C.ColumnName]= Params[C];
			}

			DS.AcceptChanges();

            string elencoparametri = "";
            foreach (DataColumn c in Params.Table.Columns) {
                elencoparametri += c.ColumnName + "=" + Params[c.ColumnName].ToString() + ";";
            }

            Form MyParent = this.MdiParent;
           

			string papersize= ModuleReport["papersize"].ToString();

			string tempdir= System.IO.Path.GetTempPath();
			if (!tempdir.EndsWith("\\")) tempdir+="\\";
			var tempfilename= tempdir+Guid.NewGuid();
			bool askUfficiale=false;
			if (FMT == formatostampa.pdf){
				string errmess;
				var r = Easy_DataAccess.GetReport(myDA,ModuleReport,Params, out errmess);
				if (r==null){
					Cursor.Current = Cursors.Default;
					MessageBox.Show(MyParent,errmess);
                    btnStampa.Enabled = true;
                    btnPreview.Enabled = true;
                    btnAcrobat.Enabled = true;
                    btnParamUfficiali.Enabled = true;
                    return;
				}
				
				PrintDocument pdoc= new PrintDocument();
				string selectedprinter;
				if (papersize.ToUpper()=="A3"){
					selectedprinter= FrmViewReport.GetA3PrinterName();
				    if (selectedprinter == null) {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Non è stata trovata alcuna stampante installata che supporti il formato A3", "Errore");
                        return;
				    }
				    try {
				        r.PrintOptions.PrinterName = selectedprinter; //PDIAL.PrinterSettings.PrinterName;
				    }
				    catch {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("La stampante di nome "+selectedprinter+" non appare essere correttamente installata.", "Errore");
                        return;
                    }
				    ReportDispatcherClass.SetDefaultOrientation(ref r, ModuleReport);
				}

				r.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
				r.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
				tempfilename += ".pdf";

			    DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions {DiskFileName = tempfilename};
			    r.ExportOptions.DestinationOptions = diskOpts;

				try {
                    r.Export();
                    System.Diagnostics.Process.Start(tempfilename);
                }
				catch (Exception e){
                    Cursor.Current = Cursors.Default;
                    if (e.ToString().Contains("0x8000030E")) {
				        MessageBox.Show(this,
				            "E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa.\nSeguono istruzioni su come procedere.",
				            "Avviso");                        
                        System.Diagnostics.Process.Start("disinstalla_kb3102429.pdf");
                        return;
                    }

				    if (e.ToString().Contains("Impossibile aprire la connessione.")) {
				        MessageBox.Show(this, "Errore nel collegamento al db", "Errore");
				        return;
				    }
				    Meta.LogError("Errore nell'apertura della stampa pdf.\n\rParametri:\n\r" + elencoparametri, e);
				    QueryCreator.ShowException("Errore nell'apertura del file pdf", e);				    
                    return;
				}
				askUfficiale=true;
				
			}
			if (FMT == formatostampa.video){
				try {
					FrmViewReport fRep = new FrmViewReport(ModuleReport, myDA, Params,Meta);
                    if (fRep.errore) return;
                    fRep.oneprint=oneprint;
                    fRep.denyprint = denyprint;
                    if (oneprint || denyprint) {
                        fRep.crViewer.ShowExportButton = false;
                        fRep.toolBar.Buttons.RemoveAt(8);
                        fRep.toolBar.Buttons.RemoveAt(5);
                    }
                    if (Meta.destroyed) return;
                    if (Meta.formController.isClosing) return;

                    //Imposto tutte le proprietà del report
                    if (fRep.ShowReport()) {
					    if (fRep.errore) return;
					    if (Meta.destroyed) return;
					    if (Meta.formController.isClosing) return;
					    if (MyParent == null || MyParent.IsDisposed) return;
						//se sono in Anteprima visualizzo il form
						if (Preview) {
							fRep.MdiParent= MyParent;
							fRep.StartPosition= FormStartPosition.CenterParent;
							fRep.Show();
						}
						else {
                            //altrimenti chiamo direttamente la stampa
                            bool printres = fRep.StampaReport();
							if (!printres) {
								Cursor.Current = Cursors.Default;
                                btnStampa.Enabled = true;
                                btnPreview.Enabled = true;
                                btnAcrobat.Enabled = true;
                                btnParamUfficiali.Enabled = true;
                                return;
							}
							askUfficiale=true;
							//Se la stampa è ufficiale (official="S") verifico se bisogna
							//eseguire una stored procedure aggiuntiva di aggiornamento
						}
					}
				}
				catch (Exception E){
                    Cursor.Current = Cursors.Default;
                    Meta.LogError("Errore nella creazione della stampa\n\rParametri:" + elencoparametri, E);
                    QueryCreator.ShowException("Errore nella creazione della stampa", E);
                    return;
				}
			}

			if (askUfficiale && (!denyprint) &&stampaUfficiale){			
				string sp_doupdate=ModuleReport["sp_doupdate"].ToString();
				if (sp_doupdate!="") {
                    if (oneprint) {
                        EseguiSpDoUpdate(sp_doupdate, Params);
                    }
                    else {
                        string msg = "Premere OK se il documento è stato stampato correttamente e\r" +
                            "se si vuole aggiornare la data di stampa del documento.";
                        DialogResult res = MessageBox.Show(msg, "Stampa",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK) EseguiSpDoUpdate(sp_doupdate, Params);
                    }
				}			  
			}
			//if (tempfilename!=null) File.Delete(tempfilename);
			
            
            if (chkClose.Checked) {
                Close();
            }
            else {
                btnStampa.Enabled = true;
                btnAcrobat.Enabled = true;
                btnPreview.Enabled = true;
                btnParamUfficiali.Enabled = true;
            }
            Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// Per le stampe ufficiali esegue una stored procedure di aggiornamento
        /// </summary>
        /// <param name="sp_doupdate">campo sp_doupdate della tabella modulereport</param>
        /// <param name="param">valori dei parametri del report</param>
        private void EseguiSpDoUpdate(string sp_doupdate, DataRow RepParams) {
			try {
				int pos_open=sp_doupdate.IndexOf("(");
				int pos_close=sp_doupdate.IndexOf(")");
				string sp_name=sp_doupdate.Substring(0,pos_open).ToLower().Trim();
				string fields=sp_doupdate.Substring(pos_open+1,pos_close-pos_open-1);
				string[] paramname=fields.Split(',');
				object[] list=new object[paramname.Length];
				int i=0;
				foreach (string s in paramname) {
					list[i++]=RepParams[s.Trim().ToLower()];
				}
				Meta.Conn.CallSP(sp_name,list,false);
			}
			catch (Exception E) {
				QueryCreator.ShowException("Impossibile aggiornare la data di stampa del documento",E);
			}
		}

		public void MetaData_AfterGetFormData(){
			DS.AcceptChanges();
		}
		private void btnParamUfficiali_Click(object sender, System.EventArgs e) {
			MetaData MetaCustReportParam = MetaData.GetMetaData(this, "reportadditionalparam");
            DateTime aday = (DateTime) myDA.GetSys("datacontabile");
            string filter = QHS.AppAnd(QHS.CmpEq("reportname", ReportName),
                 QHS.NullOrLe("start", aday), QHS.NullOrGt("stop", aday));

            MetaCustReportParam.StartFilter=filter;
			MetaCustReportParam.ExtraParameter=ReportName;
           
            MetaCustReportParam.Edit(this.MdiParent, "default", true);
			RefillCustomReportParam =true;
		}


		#region Risoluzione Problemi tramite web

		private bool VerificaVoceMenu() {
			if (ModuleReport==null) {
				string msg="Alla voce di menu non è associato nessun report.\r"+
					"E' necessario eseguire un aggiornamento Menu";
				ShowMsg(msg);
				return false;
			}
			AddCheckReportLog("Dati di modulereport - reportname ["+
				ModuleReport["reportname"].ToString()+"] - modulename ["+
				ModuleReport["modulename"].ToString()+"]");
			return true;
		}

		private bool LeggiConfigurazione() {
			siti = new string[4];
			try {
				string currdir=AppDomain.CurrentDomain.BaseDirectory;
				if (!currdir.EndsWith("\\")) currdir += "\\";
				currdir+="updateconfig.xml";
				DataSet DS = new DataSet();
				DS.ReadXml(currdir);
				ReportDir = DS.Tables["configtable"].Rows[0]["localreportdir"].ToString();
				siti[0] = DS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
				siti[1] = DS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
				siti[2] = DS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
				siti[3] = "http://www.softwareandmore.it/";
				return true;
			}
			catch (Exception E) {
				ShowMsg("Impossibile leggere dal file di configurazione,",E.Message);
				return false;
			}
		}

		/// <summary>
		/// File = *.dll | *.xml
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		private string DownloadFile(string filename) {
			try {
				if (http==null) http=new Http(siti,AppDomain.CurrentDomain.BaseDirectory);
				if (!http.IsAvailable()) return http.GetLastError();
				string zipname = filename+".zip";
				if (!http.DownloadFile(zipname,"zip/"+zipname))
					return http.GetLastError();
				string zipdir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"zip");
				XZip.ExtractFiles(Path.Combine(zipdir,zipname),zipdir,filename,true,true);
				return null;
			} 
			catch (Exception E) {
				return E.Message;
			}
		}

		private string DownloadReport(string rpt_path, string filename, string[] siti) {
			try {
				if (http==null) http=new Http(siti,AppDomain.CurrentDomain.BaseDirectory);
				if (!http.IsAvailable()) return http.GetLastError();
				string zipname=filename+".zip";
		        string zipdir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"zip");

				DeleteFile(Path.Combine(zipdir,zipname));
				
				if (!http.DownloadFile("report/"+zipname,"zip/"+zipname)) return http.GetLastError();
				XZip.ExtractFiles(Path.Combine(zipdir,zipname),rpt_path,filename,true,false);
				return null;
			} 
			catch (Exception E) {
				return E.Message;
			}
		}

		void DeleteFile(string filename){
			if (File.Exists(filename)) {
				File.SetAttributes(filename,FileAttributes.Archive);
				File.Delete(filename);
			}

		}
		/// <summary>
		/// Scarica ed installa una stored procedure
		/// </summary>
		private string DownloadSP(DataAccess Conn, string spname) {
			try {
				if (http==null) http=new Http(siti,AppDomain.CurrentDomain.BaseDirectory);
				if (!http.IsAvailable()) return http.GetLastError();
				string sqlname = spname+".sql";
				string zipname = sqlname+".zip";
			    string zipdir=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"zip");
				DeleteFile(Path.Combine(zipdir,zipname));
				DeleteFile(Path.Combine(zipdir,sqlname));

				if (!http.DownloadFile("sp/"+zipname,"zip/"+zipname))
					return http.GetLastError();
				XZip.ExtractFiles(Path.Combine(zipdir,zipname),zipdir,sqlname,true,false);
				StringBuilder sb=XFile.LeggiTestoScript(Path.Combine(zipdir,sqlname));
				if (XDatabase.RUN_SCRIPT(Conn,sb))
					return null;
				else
					return Conn.LastError;
			} 
			catch (Exception E) {
				return E.Message;
			}
		}

		/// <summary>
		/// Restituisce True se il report ha una versione minore di quella
		/// presente nel file reportindex.xml presente sul sito
		/// </summary>
		/// <param name="filename">nome del file</param>
		private bool IsReportToUpdate(string ReportDir,string filename) {
			try {
				DataSet DSrep=new DataSet();
				DSrep.ReadXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"zip","reportindex.xml"));
				if (DSrep.Tables.Count==0) return false;
				DataTable T=DSrep.Tables[0];
				if (T.Rows.Count==0) return false;
				DataRow[] rows=T.Select("dllname='"+filename+"'");
				if (rows.Length==0) return false;
				int remote_major=Convert.ToInt32(rows[0]["major"]);
				int remote_minor=Convert.ToInt32(rows[0]["minor"]);
				FileInfo FI=new FileInfo(ReportDir+@"\"+filename);
				DateTime upd = FI.LastWriteTime;
				int local_major=XDateTime.DateToInt(upd);
				int local_minor=XDateTime.TimeToInt(upd);
				if ((remote_major > local_major) || 
					((remote_major==local_major) && (remote_minor > local_minor))) 
					return true;
				DSrep=null;
			}
			catch (Exception E) {
				QueryCreator.MarkEvent("IsReportToUpdate() Error: "+ E.Message);
			}
			return false;
		}

		private bool VerificaEsistenzaFile() {
			if (ReportDir=="") {
				ShowMsg("Non è stata specificata la cartella di configurazione dei report");
				return false;
			}
			if (!Directory.Exists(ReportDir)) {
				ShowMsg("La cartella di configurazione dei report ["+ReportDir+"] è inesistente");
				return false;
			}
			string filename=ModuleReport["filename"].ToString();
			bool solalettura=XDir.IsReadOnly(ReportDir);
			AddCheckReportLog("Cartella report ["+ReportDir+"] - Filename ["+filename+"] - Sola lettura ["+solalettura.ToString()+"]");

			if (solalettura) {
				if (!File.Exists(ReportDir+@"\"+filename)) {
					ShowMsg("Il report "+filename+" non esiste nella cartella "+ReportDir+
						"\rImpossibile proseguire con il controllo poiché l'utente\r"+
						"non ha i diritti per aggiornare la cartella dei report.");
					return false;
				}
				//cartella report sola lettura, posso solo confrontare la versione
				string s=DownloadFile("reportindex.xml");
				//se c'è stato un errore durante il download, continuo con il check
				//visto che il file del report esiste.
				if (s!=null) return true;
				//Download OK, verifico se il file è aggiornato o meno.
				if (IsReportToUpdate(ReportDir,filename)) {
					MessageBox.Show("Il report "+filename+" non è aggiornato. Impossibile proseguire\r"+
						"con il controllo poiché l'utente non ha i diritti per aggiornare la cartella dei report.",
						"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return false;
				}
			}
			else {
				//cartella in scrittura, se il file non esiste scarico senza chiedere consenso
				if (!File.Exists(ReportDir+@"\"+filename)) {
					ShowMsg("Il report "+filename+" non esiste nella cartella "+ReportDir+" - E' in corso il trasferimento.");
					string s=DownloadReport(ReportDir,filename,siti);
					if (s!=null) {
						ShowMsg("Impossibile aggiornare il report",QueryCreator.GetPrintable(s));
						return false;
					}
					return true;
				}
				//altrimenti chiedo all'utente se aggiornare o meno
				DialogResult res=MessageBox.Show("Aggiorno il report?","Info",
					MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if (res==DialogResult.Yes) {
					string s=DownloadReport(ReportDir,filename,siti);
					if (s!=null) {
						ShowMsg("Impossibile aggiornare il report",QueryCreator.GetPrintable(s));
						//il report esiste ma non può essere scaricato, vado avanti con il check
					}
				}
			}
			return true;
		}

		private bool VerificaStoredProcedure() {
			//acquisizione dati input
			if(!Meta.GetFormData(false)) return false;

			DataRow Params = DS.Tables["resultparameter"].Rows[0];

			//Leggo valori input
			Hashtable ReportParams= new Hashtable();			
			foreach (DataColumn C in myPrymaryTable.Columns){
				if (C.ColumnName == DummyPrimaryKey) continue;
				if (!C.ExtendedProperties.Contains("ConvertNullToPerc")) {
					ReportParams[C.ColumnName]= Params[C];
					continue;
				}
				bool Convert = (bool) C.ExtendedProperties["ConvertNullToPerc"];
				if (Convert && (Params[C].ToString()=="")) 
					ReportParams[C.ColumnName] ="%";
				else
					ReportParams[C.ColumnName]= Params[C];
			}

			//se sono qui il file esiste nella cartella dei report
			string filename=ModuleReport["filename"].ToString();
			string fullname=ReportDir+@"\"+filename;

			ReportDocument rpt=new ReportDocument();
			try {
				rpt.Load(fullname,OpenReportMethod.OpenReportByTempCopy);
			}
			catch (Exception E) {
				ShowMsg("Errore lettura report "+fullname,E.Message);
				return false;
			}

			if (rpt == null) {
				ShowMsg("Report non trovato " + fullname, "Errore");
				return false;
			}
            //bool update=(MessageBox.Show("Aggiorno le stored procedure del report?","Info",
            //    MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes);
		    bool update = false;

			DataAccess ConnClone=Meta.Conn.Duplicate();
			//check sp report
			if (!CheckSP(ConnClone,rpt,ReportParams,update,false)) return false;

			//check sp subreport, se esistono
			ReportDefinition repDef = rpt.ReportDefinition;
			foreach (Section sec in repDef.Sections) {
				foreach (ReportObject repObj in sec.ReportObjects) {
					if (repObj.Kind != ReportObjectKind.SubreportObject) continue;
					SubreportObject subRep = (SubreportObject) repObj;
					ReportDocument SubReport = subRep.OpenSubreport(subRep.SubreportName);
					if (!CheckSP(ConnClone,SubReport,ReportParams,update,true)) return false;
				}
			}
			ConnClone.Close();
			rpt.Close();
			rpt=null;
			return true;
		}

		/// <summary>
		/// Effettua il download e un check sull'esecuzione per la stored procedure
		/// </summary>
		/// <param name="rpt">sezione del report in esame</param>
		/// <param name="Params">Hashtable parametri input</param>
		/// <param name="update">Se True scarica la sp dal sito</param>
		/// <param name="IsSubreport">True se la sp si riferisce ad un subreport</param>
		private bool CheckSP(DataAccess Conn, ReportDocument rpt,Hashtable Params,bool update,bool IsSubreport) {
			CrystalDecisions.CrystalReports.Engine.Tables crTables=rpt.Database.Tables;

			foreach(CrystalDecisions.CrystalReports.Engine.Table crTable in crTables) {
				//ricavo il nome della tabella
				string location = crTable.Location;
				int lastdotpos = location.LastIndexOf(".");
				if (lastdotpos==-1) lastdotpos= location.LastIndexOf("(");
				int lastsemicolpos = location.LastIndexOf(";");
				location = location.Substring(lastdotpos+1, lastsemicolpos-lastdotpos-1);
				
				AddCheckReportLog("Stored procedure ["+location+"] - Subreport ["+IsSubreport.ToString()+"]");
				if (update) {
					string s=DownloadSP(Conn,location);
					if (s!=null) {
						ShowMsg("Impossibile aggiornare la stored procedure "+location,
							QueryCreator.GetPrintable(s));
					}
				}
				
				if (IsSubreport) continue;

				if (!ExecSP(Conn,location,Params)) return false;
			}
			return true;
		}

		/// <summary>
		/// Esegue due volte una chiamata alla stored procedure, prima con valori NULL
		///  e poi con i dati in input
		/// </summary>
		/// <param name="spname">nome stored procedure</param>
		/// <param name="Params">parametri input</param>
		private bool ExecSP(DataAccess Conn, string spname, Hashtable ReportParams) {
			string myname= Meta.GetSys("userdb").ToString();
			object[] rowset = new object[] {spname,1,myname,null};
			DataSet  DSsp=Conn.CallSP("sp_procedure_params_rowset",rowset,true,-1);
			if (DSsp==null || DSsp.Tables.Count==0 || DSsp.Tables[0].Rows.Count==0) {
				ShowMsg("Impossibile ottenere informazioni per la stored procedure"
					+spname, QueryCreator.GetPrintable(Conn.LastError));
				return false;
			}
			int nparamsp=DSsp.Tables[0].Rows.Count-1;
			DataRow[] rows=DSsp.Tables[0].Select("ORDINAL_POSITION > 0","ORDINAL_POSITION ASC");

			object[] list = new object[nparamsp];
			for (int i=0; i<nparamsp; i++) {
				list[i]=null;
			}
			DSsp=Conn.CallSP(spname,list,true,-1);
			if (DSsp==null) {
				ShowMsg("La chiamata alla stored procedure '"+spname+
					"' con dati NULL viene eseguita con errori",
					QueryCreator.GetPrintable(Conn.LastError));
				return false;
			}

			int j=0;
			foreach (DataRow R in rows) {
				string param=R["PARAMETER_NAME"].ToString().ToLower().Substring(1);
				if (ReportParams[param]!=null)
					list[j++]=ReportParams[param];
				else
					list[j++]=null;
			}
			DSsp=Conn.CallSP(spname,list,true,-1);
			if (DSsp==null) {
				ShowMsg("La chiamata alla stored procedure '"+spname+"' viene eseguita con errori",
					QueryCreator.GetPrintable(Conn.LastError));
				return false;
			}
			return true;			
		}

		/// <summary>
		/// Esegue una serie di controlli al fine di capire un eventuale problema
		/// </summary>
		private void btnDiagnostic_Click(object sender, System.EventArgs e) {
			ClearCheckReportLog();
			if (!VerificaVoceMenu()) return;
			if (!LeggiConfigurazione()) {
				ShowInfo();
				return;
			}
			if (!VerificaEsistenzaFile()) {
				ShowInfo();
				return;
			}
			if (!VerificaStoredProcedure()) {
				ShowInfo();
				return;
			}
			string desc=ModuleReport["description"].ToString();
			MessageBox.Show("Non è stato rilevato nessun problema relativo la stampa "
				+desc+"\r\rInformazioni:\r\r"+GetCheckReportLog(), "Info",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void ShowInfo() {
			MessageBox.Show("Informazioni relative la stampa\r\r"+GetCheckReportLog(), "Info",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		private void ShowMsg(string shortmsg) {
			ShowMsg(shortmsg,null);
		}
		private void ShowMsg(string shortmsg,string longmsg) {
			QueryCreator.ShowError(this,shortmsg,longmsg);
		}

		private static void AddCheckReportLog(string log) {
			m_CheckReportLog+=log+"\r";
		}

		private static string GetCheckReportLog() {
			return m_CheckReportLog;
		}

		private static void ClearCheckReportLog() {
			m_CheckReportLog="";
		}

		private void btnPatch_Click(object sender, System.EventArgs e) {
			string msg="Dopo aver scaricato l'aggiornamento chiudere il programma, "+
				"estrarre il file CrystalPatch01.zip\r"+
				"(con un programma tipo WinZip) in una "+
				"qualsiasi cartella e fare doppio click sul file Setup.exe\r"+
				"Dopo l'installazione riaprire il programma e riprovare a stampare.\r\r"+
				"Premere OK per scaricare l'aggiornamento.\r\r"+
				"Per qualsiasi problema non esitate a contattare il Centro Assistenza.";
			DialogResult dr=MessageBox.Show(msg,"Informazioni download Crystal Report Patch",
				MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
			if (dr==DialogResult.OK)
                System.Diagnostics.Process.Start("http://liceasy.ath.cx/CrystalPatch01.zip");
		}
		#endregion


		private void btnAcrobat_Click(object sender, System.EventArgs e) {
            object print_rs = Conn.DO_READ_VALUE("report", QHS.CmpEq("reportname", ReportName), "print_rs");
            if (print_rs.ToString().ToUpper() == "S") {
                StampaReportingServices(false, formatostampa.video, sender, e);
            }
            else {
                Stampa(false, formatostampa.pdf);
            }
		}

        private void BtnReportingServices_Click(object sender, EventArgs e) {
            
        }
    }// Fine classe frmreportParameter

    public class GestioneClass {
        public static bool UsesAttribues(DataAccess Conn) {
            foreach (string s in new string[] { "idsortingkind01", "idsortingkind02", "idsortingkind03",
                            "idsortingkind04", "idsortingkind05" }) {
                if (Conn.GetSys(s)!=DBNull.Value)  return true;
            }
            return false;
        }


        public static GestioneClass  GetGestioneClassForField(string field, DataAccess Conn,string parenttable){
            if (!UsesAttribues(Conn)) return null;
            string f = field.ToLower().Trim();
            if (f == "idsor01") return new GestioneClass(Conn, 1, parenttable);
            if (f == "idsor02") return new GestioneClass(Conn, 2, parenttable);
            if (f == "idsor03") return new GestioneClass(Conn, 3, parenttable);
            if (f == "idsor04") return new GestioneClass(Conn, 4, parenttable);
            if (f == "idsor05") return new GestioneClass(Conn, 5, parenttable);
            return null;
        }

        bool allowSelection = false;
        public bool AllowSelection() {
            return allowSelection;
        }

        bool allowNull = false;
        public bool AllowNull() {
            return allowNull;
        }

        object defaultValue = DBNull.Value;
        public object DefaultValue() {
            return defaultValue;
        }

        

        string filterkind = "";
        object filter_sec = null;
        QueryHelper QHS;

        
        public string GetFilterAutoChoose() {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return filtercomplete;
        }

        string btnTag = "";
        public string BtnTag() {
            return btnTag;
        }

        string GetManageTag(string parenttable) {
            return "manage."+parenttable+ ".tree";
        }
        string GetChooseTag(string parenttable) {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return "choose."+parenttable+".tree." + filtercomplete;
        }


        public GestioneClass(DataAccess Conn,  int N, string parenttable) {
            QHS = Conn.GetQueryHelper();

            object ayear = Conn.GetSys("esercizio");
            string NtoS = N.ToString().PadLeft(2, '0'); //01 02 03 04 05
            string field_getsys_sortkind = "idsortingkind" + NtoS;
            object idsorkind = Conn.GetSys(field_getsys_sortkind);

            if (idsorkind == null || idsorkind.ToString().ToLower()=="null" || idsorkind == DBNull.Value) {
                allowSelection = false;
                allowNull = true;
                defaultValue = DBNull.Value;
                return;
            }

            idsorkind = CfgFn.GetNoNullInt32(idsorkind);
            filterkind = QHS.CmpEq("idsorkind", idsorkind);

            
            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            if (idflowchart==null || idflowchart==DBNull.Value){
                allowSelection = true;
                allowNull=true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }


            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value) as_filter = "N";
            object all_value = "S";
            object withchilds = "N";
            if (as_filter.ToString().ToUpper() == "S") {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(all_sorkind"+NtoS+",'S')");
                if (all_value == null || all_value == DBNull.Value) {
                    all_value = "S";
                }
                if (all_value.ToString().ToUpper() == "N") {
                    withchilds = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(sorkind" + NtoS + "_withchilds,'N')");
                    if (withchilds == null || withchilds == DBNull.Value) {
                        withchilds = "N";
                    }
                }
            }

            if (all_value.ToString().ToUpper() == "S") {
                allowSelection = true;
                allowNull = true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            if (withchilds.ToString().ToUpper() != "S") {
                allowSelection = false;
                allowNull = false;
                defaultValue = idsor;
                return;
            }
            filter_sec = Conn.GetUsr("cond_sor" + NtoS);
            if (filter_sec != null) {
                string f = filter_sec.ToString().Trim();
                if (f.StartsWith("AND(")) {
                    f = f.Substring(3);
                    filter_sec = f;
                }

                if (f == "(1=1") {
                    f = "";
                    filter_sec = null;
                }

                if (f != "") {
                    f = f.Replace("idsor" + NtoS, "idsor");
                    filter_sec = f;
                }
            }

            btnTag = GetChooseTag(parenttable);
            allowSelection = true;
            allowNull = false;
            defaultValue = idsor;



        }
    }

}//Fine Namespace
