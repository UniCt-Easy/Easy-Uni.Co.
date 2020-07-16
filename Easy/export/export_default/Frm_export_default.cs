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
using System.ComponentModel;
using exportdata;//exportdata
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using funzioni_configurazione;

namespace export_default//ExportForm//
{
	/// <summary>
	/// Summary description for frmExport.
	/// </summary>
	public class frmExport : System.Windows.Forms.Form
	{
		public DataSet DS;
		private vistaForm ExportVista;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnStampa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private string ExportName;
		string ExportTitle;
		private DataAccess myDA;
		private DataTable myPrymaryTable;
		private bool InsertMode;
		string ExportDescription;
		const string DummyPrimaryKey = "DummyPrimaryKeyField";
        const string DummyField = "reportname";
        private CheckBox chkClose;
		MetaData Meta;
		enum appfmts {_dateshort=13, _datetimeshort, _datelong, _datetimelong, 
			_time, _timestamp, _datetimeansi, _dateansi, _datedbf, _general, 
			_number,  _currency, _serial=25, _longserial, _percentage, 
			_highpercentage, _year=29, _twodigit, _threedigit, _generalus, 
			_twodecimal, _twodecimalsep, _threedecimal, _threedecimalsep, _integer, 
			_none, _euro, _sixdecimalsep, _byte};



		public frmExport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InsertMode = false;
            ComboToPreset = new ArrayList();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
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
		private void InitializeComponent()
		{
            this.DS = new System.Data.DataSet();
            this.ExportVista = new export_default.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportVista)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // ExportVista
            // 
            this.ExportVista.DataSetName = "vistaFormBuild";
            this.ExportVista.EnforceConstraints = false;
            this.ExportVista.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(628, 219);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(104, 23);
            this.btnAnnulla.TabIndex = 0;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(628, 12);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(104, 23);
            this.btnStampa.TabIndex = 1;
            this.btnStampa.Text = "Esporta";
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // chkClose
            // 
            this.chkClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(628, 41);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(106, 53);
            this.chkClose.TabIndex = 2;
            this.chkClose.Text = "Chiudi finestra dopo l\'operazione";
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // frmExport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 493);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnStampa);
            this.Name = "frmExport";
            this.Text = "frmExport";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmExport_Closing);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.frmExport_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportVista)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        ArrayList ComboToPreset;

        //per la gestione dell'autochoose non da libreria
        Hashtable hashChoose = new Hashtable();
        //contatore per Alias
        int AliasCount = 0;

        int VPosition = 15;
        int HPosition = 10;
        int LabelHeight = 16;
        int TextHeight = 30;
        int HelpHeight = 36;
        int ControlWidth = 300;
        int RigaSuccessiva = 44;
        //private DataRow ModuleReport = null;
        //private DataRow[] Parameters;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;


		private string FillExportVista(string ProcedureName,DataAccess DA) {
			ClearDataSet.RemoveConstraints(ExportVista);
			GetData MyGetData = new GetData();
            this.Conn = DA;

			MyGetData.InitClass(ExportVista,DA,"exportfunction");
			DataRow DR = ExportVista.Tables["exportfunction"].NewRow();
			
			ExportName = HelpForm.GetField(ProcedureName,0);
			
			DR["procedurename"] = ProcedureName;
			
			MyGetData.SEARCH_BY_KEY(DR);
            if (ExportVista.exportfunction.Rows.Count == 0) {
                string err = DA.LastError;
                if (err != null) {
                    return "Errore nell'accesso al db:" + err;
                }
                return "Occorre eseguire un File\\Menu\\Aggiorna Menu.";
            }
            MyGetData.DO_GET(false,null);
            MyGetData.DO_GET_TABLE(ExportVista.customselection, null, null, false, null);

			ExportDescription= ExportVista.Tables["exportfunction"].Rows[0]["description"].ToString();
			return null;
		}

		/// <summary>
		/// Create primary table in DS and assign to "myPrimaryTable"
		/// </summary>
		/// <param name="ReportParameters"></param>
		void CreatePrimaryTable(string ProcedureName, DataRow[] ReportParameters, DataAccess conn){
			myPrymaryTable = new DataTable("export");
			DateTime dataContabile = (DateTime) conn.GetSys("datacontabile");
			int esercizio = (int) conn.GetSys("esercizio");
			//Create a dummy primary key
			DataColumn DCPK = new DataColumn(DummyPrimaryKey,typeof(System.Int32));
			DCPK.DefaultValue = 1;
			myPrymaryTable.Columns.Add(DCPK);
			myPrymaryTable.PrimaryKey = new DataColumn[]{DCPK};

            // Aggiunge la colonna reportname
            DataColumn DCReportName = new DataColumn(DummyField, typeof(System.String));
            DCReportName.DefaultValue = ProcedureName;
            myPrymaryTable.Columns.Add(DCReportName);

            //Add parameters as primary table fields
			foreach (DataRow Param in ReportParameters){
                System.Type ColType = GetTypeFromSysType(Param["systype"].ToString());
				string ColName = Param["paramname"].ToString();
				DataColumn Col = new DataColumn(ColName,ColType);

				object def = "null";
				try {
					def = DefaultForParameter(Param);
					Col.DefaultValue= def;
				}
				catch {
//					MessageBox.Show("Errore cercando di impostare il campo "+
//							ColName + " = " +
//							QueryCreator.quotedstrvalue(def,false)+".\r"+
//							"Dettaglio: "+E.Message,
//							"Errore");
                }

                //il campo è gestito se è flag combo = 'S' o se 
                //il campo selectioncode (manage/chhose) non è null
                bool Gestito = ((Param["iscombobox"].ToString().ToUpper() == "S") ||
                    (Param["selectioncode"].ToString() != ""));

                bool ConvertNullToPerc = (Gestito &&
                    (Param["noselectionforall"].ToString().ToUpper() == "S"));

				Col.ExtendedProperties["ConvertNullToPerc"]= ConvertNullToPerc;
				///TODO: Verificare Gestione AllowDBNull
                Col.AllowDBNull = (Param["hintkind"].ToString()=="NOHINT") || ConvertNullToPerc;

				myPrymaryTable.Columns.Add(Col);
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
            if (Man.Rows.Count >= 1) return Man.Rows[0]["idman"];
            return DBNull.Value;
        }

        void ControllaObbligatorietaResp() {
            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
            if (!GestioneClass.UsesAttribues(Conn)) return;
            if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp
            if (myPrymaryTable.Columns.Contains("idman")) {
                DataColumn C1 = myPrymaryTable.Columns["idman"];
                C1.AllowDBNull = false;
                C1.Caption = "Responsabile";
                HelpForm.SetDenyZero(C1, true);
                C1.DefaultValue = CalcDefaultForManager();
            }
            if (myPrymaryTable.Columns.Contains("idmananager")) {
                DataColumn C2 = myPrymaryTable.Columns["idmananager"];
                C2.AllowDBNull = false;
                C2.Caption = "Responsabile";
                HelpForm.SetDenyZero(C2, true);
                C2.DefaultValue = CalcDefaultForManager();
            }

        }



        void ControllaObbligatorietaUpb() {
            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
            if (!GestioneClass.UsesAttribues(Conn)) return;
            if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp
            if (myPrymaryTable.Columns.Contains("idman")) return; //c'è il responsabile, basta limitare quello
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
            LB.Location = (new Point(HPosition, VPosition));
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
            TBP.Location = new Point(HPosition, VPosition + LabelHeight);
            TBP.Width = ControlWidth;
            TBP.Height = TextHeight;
            TBP.TextAlign = HorizontalAlignment.Right;
            TBP.Tag = myPrymaryTable.TableName + "." + Param["paramname"].ToString();
            string fmt = Param["tag"].ToString();
            //if (fmt=="")fmt="g";
            if (fmt != null) TBP.Tag += "." + fmt;
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
            TBHelp.TabStop = false;
            TBHelp.ScrollBars = ScrollBars.Vertical;
            TBHelp.Height = HelpHeight;
            TBHelp.Text = help;
        }
        private GroupBox InserisciGroupBox(DataRow Param) {
            string descr = Param["description"].ToString().Trim();
            return InserisciGroupBox(Param, descr);
        }

        /// <summary>
        /// Aggiunge un GroupBox
        /// </summary>
        /// <param name="Param">riga di reportparameter</param>
        /// <returns>Il GroupBox creato</returns>
        private GroupBox InserisciGroupBox(DataRow Param, string descr) {
            GroupBox grp = new GroupBox();
            grp.Name = "gb" + Param["paramname"].ToString();
            descr = myDA.Compile(descr, true);
            grp.Text = descr;
            if (descr ==null || descr=="" || descr=="null") grp.Enabled=false;
            this.Controls.Add(grp);
            //la riduzione di VPosition serve per l'allineamento con l'help
            grp.Location = new Point(HPosition, VPosition - 4);
            grp.Height = HelpHeight + 5;
            grp.Width = ControlWidth;
            return grp;
        }

        /// <summary>
        /// Aggiunge una ComboBox
        /// </summary>
        /// <param name="Param">riga di reportparameter</param>
        /// <param name="IsAlias">True se la tabella padre esiste già nel DataSet</param>
        private void InserisciCombo(DataRow Param, bool IsAlias) {

            string tablename = Param["datasource"].ToString();
            string paramname = Param["paramname"].ToString();
            if (IsAlias) {
                tablename += AliasCount;
            }
            ComboBox CB = new ComboBox();
            this.Controls.Add(CB);
            CB.Location = new Point(HPosition, VPosition + LabelHeight);
            CB.Width = ControlWidth;
            CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CB.Tag = myPrymaryTable.TableName + "." + paramname;
            CB.DataSource = DS.Tables[tablename];
            CB.ValueMember = Param["valuemember"].ToString();
            CB.DisplayMember = Param["displaymember"].ToString();
            if ((paramname.IndexOf("level") >= 0) && (Param["hintkind"].ToString().ToUpper() == "NOHINT")) {
                ComboToPreset.Add(CB);
            }
        }

        /// <summary>
        /// Verifica se il parametro ha una gestione custom
        /// </summary>
        /// <param name="custom">tag</param>
        /// <returns>True se custom</returns>
        private bool IsCustomField(string custom) {
            if (custom == "") return false;
            //per i tipi costant, radio, check, etc... non eseguo nessun controllo
            if (!custom.ToLower().StartsWith("custom")) return true;
            //vedo se c'è una riga in customselection con codice
            QHC = new CQueryHelper();
            string selectioncode = custom.Substring(custom.IndexOf(".") + 1);
            DataRow []CustomSel = ExportVista.customselection.Select(QHC.CmpEq("selectioncode", selectioncode));
            return (CustomSel.Length != 0);
        }

		/// <summary>
		/// Metodo per la creazione del Form per l'inserimento dei parametri da
		/// passare alle storedprocedure dei Report di stampa.
		/// Questo metodo lavora su due Dataset DS e ReportVista.
		/// </summary>
		/// <param name="ModuleNameReportName"></param>
		/// <param name="DA"></param>
		/// <returns></returns>
		public bool BuildForm(string ModuleNameExportName, MetaData M) {
            Meta = M;
            MetaDataDispatcher E = M.Dispatcher;
            DataAccess DA = E.Conn;
            myDA = DA as Easy_DataAccess;
            QHC = new CQueryHelper();
            QHS = myDA.GetQueryHelper();
			//Riempie il dataset  ReportVista delle tabelle che mi servono a costruire il Form
			string result = FillExportVista(ModuleNameExportName,DA);
			//if(ExportVista.Tables["exportfunctionparam"].Rows.Count == 0)return false;
            if (result!=null) { //ExportVista.Tables["exportfunction"].Rows.Count == 0
                Meta.ExtraParameter = result;
                return false;
            }

			DataRow ModuleExport = ExportVista.Tables["exportfunction"].Rows[0];
			ExportTitle=  ModuleExport["description"].ToString();

            string ProcedureName = ModuleExport["procedurename"].ToString();

			DataRow [] Parameters = ExportVista.Tables["exportfunctionparam"].Select(null,"number asc");

            CreatePrimaryTable(ProcedureName, Parameters, DA);

            ////////////////////////////////////////////////////////////////////////////
            //Inizia la Procedura per l'inserimento dei controlli nel Form.

            VPosition += RigaSuccessiva;  //Incrementa il puntatore per la riga successiva

			int HPosition = 10;
			
			
			//Per ogni parametro ovvero per ogni riga presente nella tabella reportparameter
			foreach(DataRow Param in Parameters) {
                bool skipSizeIncrement = false;

                string selectioncode = Param["selectioncode"].ToString();
                string paramname = Param["paramname"].ToString();
                //verifica se sono in presenza di tabella alias 
                //(i campi devono contenere la stringa "|alias")
                bool IsAlias = (Param["paramname"].ToString().IndexOf("|alias") != -1);
                if (!IsAlias) {
                    string table = Param["datasource"].ToString();
                    if ((table != "") && DS.Tables.Contains(table)) IsAlias = true;
                    if (ExportVista.Tables["exportfunctionparam"].Select(QHC.CmpEq("datasource", table)).Length > 1) IsAlias = true;

                }
                if (IsAlias) ++AliasCount;

                bool customField = IsCustomField(selectioncode);

                if (customField) {
                    //E' un campo nascosto?
                    if (selectioncode.ToLower() == "costant.hidden") skipSizeIncrement = true;

                    skipSizeIncrement = !AddCustomControl(selectioncode,
                         myPrymaryTable.TableName, paramname,
                        HPosition, VPosition, Param, IsAlias);
                }
                else {
                    if (Param["iscombobox"].ToString().ToUpper() == "S") {
                        InserisciLabel(Param);
                        if (!AddTableToDS(Param, IsAlias)) {
                            Meta.ExtraParameter = " Errore nella costruzione del parametri (campo " +
                                Param["paramname"].ToString() + " su tabella " +
                                    Param["datasource"].ToString() + ")";
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
                    InserisciHelp(GetPrintable(myDA.Compile(Param["help"].ToString(), true)));
                    VPosition += RigaSuccessiva;
                }

            }//Fine foreach

            //Ridefinisce la lunghezza del form
            int myheigth = VPosition + 120;
            if (myheigth < 312) myheigth = 312;
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
            if (tag == "") return false;
            int dotpos = tag.IndexOf(".");
            string tipo = tag.Substring(0, dotpos);
            string[] token = tag.Substring(dotpos + 1).Split('|');

            switch (tipo.ToLower()) {
                case "check":
                    CheckBox ctrl = new CheckBox();
                    ctrl.Tag = tablename + "." + paramname + ":" + token[0] + ":" + token[1];
                    ctrl.Text = token[2];
                    ctrl.Width = ControlWidth - 20;
                    this.Controls.Add(ctrl);
                    ctrl.Location = new Point(HPosition, VPosition + 8);
                    break;

                case "radio":
                    GroupBox grp = InserisciGroupBox(param);

                    int i;
                    int Altezza = 15;
                    for (i = 0; i < token.Length / 2; i++) {
                        RadioButton rb = new RadioButton();
                        rb.Tag = tablename + "." + paramname + ":" + token[2 * i];
                        rb.Text = token[2 * i + 1];
                        rb.Width = ControlWidth - 20;
                        rb.Height = LabelHeight;
                        grp.Controls.Add(rb);
                        rb.Location = new Point(12, Altezza);
                        Altezza += rb.Height;
                    }
                    grp.Height = Altezza + 10;
                    this.VPosition += (grp.Height - HelpHeight - 4);

                    break;

                case "custom":
                    string selectioncode = token[0];
                    DataTable T = ExportVista.Tables["customselection"];
                    DataRow [] Rsel = T.Select(QHC.CmpEq("selectioncode", selectioncode));
                    if (Rsel.Length == 0) return false;
                    DataRow selRow = Rsel[0];
                    if (selRow == null) return false;
                    string parenttable = selRow["tablename"].ToString();
                    string editlisttype = selRow["editlisttype"].ToString();
                    string selectiontype = selRow["selectiontype"].ToString();
                    string fieldname = selRow["fieldname"].ToString();
                    string filter = myDA.Compile(selRow["filter"].ToString(), true);
                    if (filter == "(idsorkind='null')") return false; //filter = "(idsorkind is null)";
                    string filterapp = filter;
                    AddCustomTableToDS(selRow, paramname, IsAlias);
                    if (IsAlias) parenttable += AliasCount;


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

                    if (filter != "") filterapp = "." + filterapp;


                    // C(hoose) o M(anage)?
                    bool IsAutoManage = (selectiontype.ToUpper() == "M");
                    bool IsAutoChoose = (selectiontype.ToUpper() == "C");
                    bool IsComboManage = (selectiontype.ToUpper() == "U");

                    //Inserisco un groupbox
                    GroupBox gb = InserisciGroupBox(param, selRow["selectionname"].ToString());

                    //aggiungo un button
                    Button btn = new Button();
                    btn.Name = "btn" + paramname;
                    btn.Text = "Seleziona";
                    btn.Location = new Point(12, 14);
                    btn.Width = 62;
                    btn.Height = TextHeight - 9;
                    gb.Controls.Add(btn);
                    TextBox TBP = null;
                    if (IsAutoChoose || IsAutoManage) {
                        //e un textbox
                        TBP = new TextBox();
                        TBP.Name = "txt" + paramname;
                        TBP.Location = new Point(btn.Location.X + btn.Width + 1, 14);
                        TBP.Width = ControlWidth - btn.Width - 20;
                        TBP.Height = TextHeight;
                        TBP.Tag = parenttable + "." + fieldname + "?x";
                        gb.Controls.Add(TBP);
                    }
                    if (IsComboManage) {

                        btn.Tag = "manage." + parenttable + "." + editlisttype + filterapp;

                        ComboBox CBP = new ComboBox();

                        string tablename2 = param["datasource"].ToString();
                        string paramname2 = param["paramname"].ToString();
                        if (IsAlias) {
                            tablename2 += AliasCount;
                        }
                        ComboBox CB = new ComboBox();
                        CB.Location = new Point(btn.Location.X + btn.Width + 1, 14);
                        CB.Width = ControlWidth - btn.Width - 20;
                        CB.DropDownStyle = ComboBoxStyle.DropDownList;
                        CB.Tag = myPrymaryTable.TableName + "." + paramname2;
                        CB.DataSource = DS.Tables[tablename2];
                        CB.ValueMember = param["valuemember"].ToString();
                        CB.DisplayMember = param["displaymember"].ToString();
                        if ((paramname.IndexOf("level") >= 0) && (param["hintkind"].ToString().ToUpper() == "NOHINT")) {
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
                        gb.Tag = "AutoChoose." + TBP.Name + "." + editlisttype + "." + GestAttributi.GetFilterAutoChoose();

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
                    bool visible = !(token[0].ToLower() == "hidden");
                    Label lb = InserisciLabel(param);
                    lb.Visible = visible;
                    TextBox tb = InserisciTextBox(param);
                    tb.Visible = visible;
                    tb.ReadOnly = true;
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

            string parenttable = customRow["tablename"].ToString();
            string RealTable = parenttable;

            //Aggiunge il nuovo DataTable se non c'è già
            if (DS.Tables[parenttable] == null || IsAlias) {
                DataTable T = myDA.CreateTableByName(parenttable, null);
                if (IsAlias) {
                    string AliasTable = parenttable + AliasCount;
                    T.TableName = AliasTable;
                    parenttable = AliasTable;
                    DataAccess.SetTableForReading(T, RealTable);
                }
                DS.Tables.Add(T);
                string relatedcolname = customRow["relationfield"].ToString();
                DataColumn ParentCol = T.Columns[relatedcolname];
                DataColumn ChildCol = myPrymaryTable.Columns[paramname];
                string relname = parenttable + myPrymaryTable.TableName;
                DS.Relations.Add(relname, ParentCol, ChildCol, false);
            }
            DataTable ParentTable = DS.Tables[parenttable];
            string Filter = customRow["filter"].ToString().Trim();
            if (Filter != "") {
                Filter = myDA.Compile(Filter, true);
                if (Filter == "(idsorkind='null')") {
                    Filter = "(idsorkind is null)";
                }
                GetData.SetStaticFilter(ParentTable, Filter);
            }
            string Extra = customRow["extraparameter"].ToString();
            if (Extra != "") {
                Extra = myDA.Compile(Extra, true);
                Extra = Extra.Replace("='null'", " is null ");
                ParentTable.ExtendedProperties[MetaData.ExtraParams] = Extra;
            }
            //Aggiunge filtro su esercizio se chiave primaria contiene
            // un campo di nome esercizio
            if (QueryCreator.IsPrimaryKey(ParentTable, "ayear")) {
                GetData.SetStaticFilter(ParentTable, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            }
        }

		//Gli viene passata una riga della tabella "reportparameter"
		//che deve avere "flagcombo" = "S" per giustificare l'aggiunta della
		//tabella al dataset.
		//Tale tabella sarà il datasource del combobox
		//e dovrà avere una Relation con la tabella principale.
		//Il Campo con nome "combodescfield" dovrà essere campo chiave
		//della tabella che sto aggiungendo al dataset.
        private bool AddTableToDS(DataRow Param, bool IsAlias) {

            string paramname = Param["paramname"].ToString();
            string datasourceName = Param["datasource"].ToString();
            string RealTable = datasourceName;
            string CodeFieldName = Param["valuemember"].ToString();

            //Aggiunge il nuovo DataTable se non c'è già oppure se è un alias
            if (DS.Tables[datasourceName] == null || IsAlias) {
                DataTable T = myDA.CreateTableByName(datasourceName, null);
                if (IsAlias) {
                    string AliasTable = datasourceName + AliasCount;
                    T.TableName = AliasTable;
                    datasourceName = AliasTable;
                    DataAccess.SetTableForReading(T, RealTable);
                }
                DS.Tables.Add(T);
                if (T.Columns[CodeFieldName] == null) return false;
                if (myPrymaryTable.Columns[paramname] == null) return false;
                //Add datasource->PrimaryTable Relation
                DataColumn ParentCol = T.Columns[CodeFieldName];
                DataColumn ChildCol = myPrymaryTable.Columns[paramname];
                string relname = datasourceName + myPrymaryTable.TableName;
                DS.Relations.Add(relname, ParentCol, ChildCol, false);
            }

            //Per i parametri che hanno il campo filter avvalorato e che hanno il iscombobox = 'S' 
            //nella tabella reportparameter, imposto un filtro statico sulla tabella del dataset
            DataTable datasource = DS.Tables[datasourceName];
            string Filter = Param["filter"].ToString().Trim();
            if (Filter != "") {
                Filter = myDA.Compile(Filter, true);
                GetData.SetStaticFilter(datasource, Filter);
            }
            if (datasourceName.ToLower().IndexOf("level") >= 0) {
                if (datasource.Columns["nlevel"] != null) {
                    GetData.SetSorting(datasource, "nlevel");
                    if (Filter != "") {
                        GetData.CacheTable(datasource, Filter, "nlevel", true);
                    }
                    else {
                        GetData.CacheTable(datasource, null, "nlevel", true);
                    }
                }
            }

            //Aggiunge filtro su esercizio se chiave primaria contiene
            // un campo di nome esercizio
            if ((Filter == "") && (QueryCreator.IsPrimaryKey(datasource, "ayear"))) {
                GetData.SetStaticFilter(datasource, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            }
            return true;
        }


        object DefaultForParameter(DataRow Param) {
            string TipoDef = Param["hintkind"].ToString().ToUpper();
            DateTime DC = (DateTime)Meta.GetSys("datacontabile");
            switch (TipoDef) {
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
                    return new DateTime(DC.Year, 1, 1);
                case "31/12": //Ultimo giorno dell'anno
                    return new DateTime(DC.Year, 12, 31);
                case "ACCOUNTDATE": //Data Contabile
                    return DC;
                default:
                    return DBNull.Value;

            }

        }



        System.Type GetTypeFromSysType(string systype) {
            systype = systype.ToUpper();

            switch (systype) {
                case "BYTE": return typeof(System.Byte);
                case "INT16": return typeof(System.Int16);
                case "INT32": return typeof(System.Int32);
                case "DATETIME": return typeof(System.DateTime);
                case "STRING": return typeof(System.String);
                case "DECIMAL": return typeof(System.Decimal);
                case "DOUBLE": return typeof(System.Double);
                default:
                    return typeof(System.String);
            }

        }

		public void MetaData_AfterClear() {
			Text= ExportTitle;
			if(InsertMode)return;
			InsertMode = true;
			MetaData.MainAdd(this);
		}

        string GetPrintable(string msg) {
            string S = msg.Replace("\r", "\n");
            S = S.Replace("\n\n", "\n");
            S = S.Replace("\n", "\r\n");
            return S;
        }

		public void MetaData_AfterFill(){
            if (ComboToPreset != null) {
                for (int i = 0; i < ComboToPreset.Count; i++) {
                    ComboBox CB = (ComboBox)ComboToPreset[i];
                    if (CB.Items.Count > 1) CB.SelectedIndex = 1;
                }
                ComboToPreset = null;
            }

            Text = ExportTitle;
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

            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			this.Close();
			this.Dispose();
		
		}

		private void btnStampa_Click(object sender, System.EventArgs e) {
            if (DS.Tables["export"].Rows.Count==0)return;
			if(!Meta.GetFormData(false))return;
            DataSet DSCopy = DS.Copy();
			DataRow Params = DSCopy.Tables["export"].Rows[0];

            // Controllo della NON SELEZIONE. Se scelgo di non filtrare ma posso accedere solo ad alcuni upb/idfin/.. la sicurezza mi blocca. 
            if (!MyGetExport(Params)) return;
            int count=0;
            object[] ReportParams = new object[myPrymaryTable.Columns.Count - 2];	// -2, perchè c'è DummyPrimaryKey e	DummyField
            Hashtable HashParams = new Hashtable();
			foreach (DataColumn C in myPrymaryTable.Columns){
                string colname = C.ColumnName;
				if (colname == DummyPrimaryKey) continue;
                if (colname == DummyField) continue;
				bool Convert = (bool) C.ExtendedProperties["ConvertNullToPerc"];
                Type tipo = Params.Table.Columns[colname].DataType;
                if (Convert && (tipo==typeof(string)) && (Params[colname].ToString() == "")) {
                    Params[colname] = "%";
                }
                ReportParams[count++] = Params[colname];
                HashParams[colname] = Params[colname];
			}
			DS.AcceptChanges();
           
			int timeout=300;
			try {
				if (ExportVista.Tables["exportfunction"].Rows[0]["timeout"]!=DBNull.Value){
					timeout = Convert.ToInt32(
						ExportVista.Tables["exportfunction"].Rows[0]["timeout"])*60;
					if (timeout==0) timeout=300;
				}
			}
			catch {
			}
			DataSet Out=null;
            if (ExportName.StartsWith("#")) {
                string[] s = ExportName.Substring(1).Split('#');
                string assemblyName = s[0];
                string className = s[1];
                Assembly a = System.Reflection.Assembly.Load(assemblyName);
                if (a == null) {
                    MessageBox.Show("Dll " + assemblyName + " non trovata");
                    return;
                }
                System.Type T = a.GetType(assemblyName+"."+className, false, true);
                if (T == null) {
                    MessageBox.Show("Classe " + className + " non trovata nella DLL " + assemblyName);
                    return;
                }
                object O = System.Activator.CreateInstance(T);
                MethodInfo M = T.GetMethod("Execute");
                if (M == null) {
                    MessageBox.Show("Metodo Execute non trovato nella classe " + className + " della DLL " + assemblyName);
                    return;
                }
                DataTable TT = M.Invoke(O, new object[] { Meta.Conn, HashParams }) as DataTable;
                if (TT != null) {
                    Out = new DataSet("D");
                    Out.Tables.Add(TT);
                }
                else {
                    MessageBox.Show("La funzione " + className + " è stata valutata e non ha restituito alcun risultato.");
                    if (Modal)
                        DialogResult = DialogResult.OK;
                    else
                        CloseForm();
                    return;
                }

            }
            else {
                Out = Meta.Conn.CallSP(ExportName, ReportParams, false, timeout);
            }
			if ((Out==null) ||( Out.Tables.Count==0)){
				MessageBox.Show("La stored procedure "+ExportName+
					" è stata valutata e non ha restituito alcun risultato.");					
				if (Modal) 
					DialogResult = DialogResult.OK;
				else
                    CloseForm();
				return;
			}
			if (Out.Tables[0].Rows.Count==0){
				MessageBox.Show("La stored procedure "+ExportName+
					" è stata valutata e non ha restituito alcun risultato.");					
				if (Modal) 
					DialogResult = DialogResult.OK;
				else
                    CloseForm();
				return;
			}

		
			DataTable OutTable = Out.Tables[0];
			OutTable.TableName= ExportDescription.Replace("#","");

            /*
			try {
				foreach(DataRow Col in ExportVista.expstoredprocedureformat.Rows){
					int colnum = Convert.ToInt32(Col["proccolnumber"])-1;	
					DataColumn CC = OutTable.Columns[colnum];
					CC.Caption= Col["description"].ToString();
					CC.ExtendedProperties["ExcelFormat"] = Col["excelformat"].ToString();
					CC.ExtendedProperties["ExcelColPos"] = Convert.ToInt32(Col["colnumber"]);
				}
			}
			catch {}
			*/

            string fileFormat = ExportVista.Tables["exportfunction"].Rows[0]["fileformat"].ToString();
            object fileExtension = ExportVista.Tables["exportfunction"].Rows[0]["fileextension"];
			switch (fileFormat) 
			{
                case "F": exportdata.exportclass.dataTableToFixedLengthFile(OutTable, fileExtension, false); break;				
                case "T": exportdata.exportclass.dataTableToTabulationSeparatedValues(OutTable, false); break;
				case "C": exportdata.exportclass.dataTableToCommaSeparatedValues(OutTable, false); break;
				case "E": metadatalibrary.exportclass.DataTableToExcel(Out.Tables[0], true); break;
			}

			if (Modal) 
				DialogResult = DialogResult.OK;
			else 
				CloseForm();
		}

        private void CloseForm()
        {
            Form MyParent = this.MdiParent;
            if (chkClose.Checked)
            {
                Close();
            }
        }

        public void MetaData_AfterGetFormData() {
            DS.AcceptChanges();
        }

		private void frmExport_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			DS.AcceptChanges();

		}

		private void frmExport_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			DS.AcceptChanges();		
		}

		private void btnFile_Click(object sender, System.EventArgs e) {
		
		}

        bool responsabile_presente(DataRow Params) {
            if (myPrymaryTable.Columns.Contains("idman")) {
                if ((Params["idman"].ToString() == "") || (Params["idman"].ToString() == "%")) {
                    //MessageBox.Show("E' necessario scegliere un responsabile (regola di sicurezza)");
                    return false;
                }                
            }
            else {
                return false;
            }
            return true;
        }

        public bool MyGetExport(DataRow Params)
        {
            if (! myDA.CanPrint(Params))
            {
                MessageBox.Show("La stampa con questi parametri non è consentita dalle regole di sicurezza");
                return false;
            }
            //Controlla la selezione null di bilancio/responsabile/upb
            object all_fin = myDA.GetUsr("all_fin");
            if ((all_fin != null) && (all_fin.ToString().ToLower().Equals("'n'")))
            {
                if (myPrymaryTable.Columns.Contains("idfin"))
                {
                    if ((Params["idfin"].ToString() == "") || (Params["idfin"].ToString() == "%"))
                    {
                        if (!responsabile_presente(Params)) {
                            MessageBox.Show("E' necessario scegliere una voce di bilancio (regola di sicurezza).");
                            return false;
                        }
                    }
                    else
                    {
                        DataTable TableFin = new DataTable();
                        TableFin.Columns.Add("idfin", typeof(int));
                        DataRow RFin = TableFin.NewRow();
                        RFin["idfin"] = Params["idfin"];
                        TableFin.Rows.Add(RFin);
                        if (!Meta.CanSelect(RFin))
                        {
                            MessageBox.Show("La voce di bilancio non poteva essere scelta  (regola di sicurezza)");					
                            return false;
                        }
                    }
                }

                if (myPrymaryTable.Columns.Contains("codefin"))
                {
                    if ((Params["codefin"].ToString() == "") || (Params["codefin"].ToString() == "%"))
                    {
                        if (!responsabile_presente(Params)) {
                            MessageBox.Show("E' necessario scegliere una voce di bilancio (regola di sicurezza)");

                            return false;
                        }
                    }
                }
            }

            object all_upb = myDA.GetUsr("all_upb");
            if ((all_upb != null) && (all_upb.ToString().ToLower().Equals("'n'")))
            {
                if (myPrymaryTable.Columns.Contains("idupb"))
                {
                    if ((Params["idupb"].ToString() == "") || (Params["idupb"].ToString() == "%"))
                    {
                        if (!responsabile_presente(Params)) {
                            MessageBox.Show("E' necessario scegliere un UPB (regola di sicurezza)");
                            return false;
                        }
                    }
                    else
                    {
                        DataTable TableUpb = new DataTable();
                        TableUpb.Columns.Add("idupb", typeof(string));
                        DataRow RUpb = TableUpb.NewRow();
                        RUpb["idupb"] = Params["idupb"];
                        TableUpb.Rows.Add(RUpb);
                        if (!Meta.CanSelect(RUpb))
                        {
                            MessageBox.Show("L'upb non poteva essere scelto (regola di sicurezza)");
                            return false;
                        }
                    }
                }
                if (myPrymaryTable.Columns.Contains("codeupb"))
                {
                    if ((Params["codeupb"].ToString() == "") || (Params["codeupb"].ToString() == "%"))
                    {
                        if (!responsabile_presente(Params)) {
                            MessageBox.Show("E' necessario scegliere un UPB (regola di sicurezza)");
                            return false;
                        }
                    }
                }
            }

            object all_man = myDA.GetUsr("all_man");
            if ((all_man != null) && (all_man.ToString().ToLower() == "'n'"))
            {
                if (myPrymaryTable.Columns.Contains("idman"))
                {
                    if ((Params["idman"].ToString() == "") || (Params["idman"].ToString() == "%"))
                    {
                       MessageBox.Show("E' necessario scegliere un responsabile (regola di sicurezza)");
                        return false;
                    }
                }
            }

            object all_estimatekind = myDA.GetUsr("all_estimatekind");
            if ((all_estimatekind != null) && (all_estimatekind.ToString().ToLower() == "'n'"))
            {
                if (myPrymaryTable.Columns.Contains("idestimkind"))
                {
                    if ((Params["idestimkind"].ToString() == "") || (Params["idestimkind"].ToString() == "%"))
                    {
                       MessageBox.Show("E' necessario scegliere un tipo contratto attivo (regola di sicurezza)");
                        return false;
                    }
                }
            }

            object all_mandatekind = myDA.GetUsr("all_mandatekind");
            if ((all_mandatekind != null) && (all_mandatekind.ToString().ToLower() == "'n'"))
            {
                if (myPrymaryTable.Columns.Contains("idmankind"))
                {
                    if ((Params["idmankind"].ToString() == "") || (Params["idmankind"].ToString() == "%"))
                    {
                        MessageBox.Show("E' necessario scegliere un tipo contratto passivo (regola di sicurezza)");
                        return false;
                    }
                }
            }

            object all_pettycash = myDA.GetUsr("all_pettycash");
            if ((all_pettycash != null) && (all_pettycash.ToString().ToLower() == "'n'"))
            {
                if (myPrymaryTable.Columns.Contains("idpettycash"))
                {
                    if ((Params["idpettycash"].ToString() == "") || (Params["idpettycash"].ToString() == "%"))
                    {
                        MessageBox.Show( "E' necessario scegliere un tipo fondo economale (regola di sicurezza)");
                        return false;
                    }
                }
            }

            object all_invoicekind = myDA.GetUsr("all_invoicekind");
            if ((all_invoicekind != null) && (all_invoicekind.ToString().ToLower() == "'n'"))
            {
                if (myPrymaryTable.Columns.Contains("idinvkind"))
                {
                    if ((Params["idinvkind"].ToString() == "") || (Params["idinvkind"].ToString() == "%"))
                    {
                        MessageBox.Show( "E' necessario scegliere un tipo documento IVA (regola di sicurezza)");
                        return false;
                    }
                }
            }
            return true;
       }

	}
    public class GestioneClass {
        public static bool UsesAttribues(DataAccess Conn) {
            foreach (string s in new string[] { "idsortingkind01", "idsortingkind02", "idsortingkind03",
                            "idsortingkind04", "idsortingkind05" }) {
                if (Conn.GetSys(s) != DBNull.Value) return true;
            }
            return false;
        }


        public static GestioneClass GetGestioneClassForField(string field, DataAccess Conn, string parenttable) {
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
            return "manage." + parenttable + ".tree";
        }
        string GetChooseTag(string parenttable) {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return "choose." + parenttable + ".tree." + filtercomplete;
        }


        public GestioneClass(DataAccess Conn, int N, string parenttable) {
            QHS = Conn.GetQueryHelper();

            object ayear = Conn.GetSys("esercizio");
            string NtoS = N.ToString().PadLeft(2, '0'); //01 02 03 04 05
            string field_getsys_sortkind = "idsortingkind" + NtoS;
            object idsorkind = Conn.GetSys(field_getsys_sortkind);

            if (idsorkind == null || idsorkind.ToString()=="null" || idsorkind == DBNull.Value) {
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

            if (idflowchart == null || idflowchart == DBNull.Value) {
                allowSelection = true;
                allowNull = true;
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
                                " isnull(all_sorkind" + NtoS + ",'S')");
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
}
