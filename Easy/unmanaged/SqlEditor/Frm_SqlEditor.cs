/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Windows.Forms;
using System.IO;
using metadatalibrary;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

namespace SqlEditor{//SqlEditor//
	/// <summary>
	/// Summary description for frmSqlEditor.
	/// </summary>
	public class frmSqlEditor : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RichTextBox txtSQL;
		public string SQLstatement;
		Hashtable SQLKeys;
		DataAccess Conn;
		private System.Windows.Forms.TreeView treeFields;
		private System.Windows.Forms.Button btnAutomatico;
		private System.Windows.Forms.Button Generic_field_Btn;
		private System.Windows.Forms.Button BtnNewPar;
		private System.Windows.Forms.Button BtnOldPar;
		private System.Windows.Forms.Button BtnEsercizio;
		private System.Windows.Forms.Button btn_C;
		private System.Windows.Forms.Button btn_N;
		private System.Windows.Forms.Button btn_F;
		private System.Windows.Forms.Button btn_D;
		private System.Windows.Forms.Button btn_V;
		private System.Windows.Forms.ImageList icons;
		private /*Rana:SqlEditor.*/vistaForm DS;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox cmbSysType;
		bool HighLightEnabled;

	    private string maintable;

        DataTable SysType;
		public frmSqlEditor(DataAccess Conn, string SQLstatement, string maintable) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.SQLstatement= SQLstatement;
			this.Conn=Conn;

            this.maintable = maintable;
			txtSQL.Text= SQLstatement;
			SQLKeys= new Hashtable();
			HighLightEnabled=false;
			ReadSqlKeys();
			FillTreeRoots();
			SysType= new DataTable("systype");
			SysType.Columns.Add("valore",typeof(string));
			SysType.Columns.Add("descrizione",typeof(string));
			DataRow R;
			R= SysType.NewRow();
			R["valore"]= "esercizio";
			R["descrizione"]="Esercizio contabile";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "datacontabile";
			R["descrizione"]="Data contabile";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "maxexpensephase";
			R["descrizione"]="Ultima fase di spesa";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "maxincomephase";
			R["descrizione"]="Ultima fase di entrata";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "itinerationphase";
			R["descrizione"]="Fase contab.missione";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "mandatephase";
			R["descrizione"]="Fase contab.ordine";
			SysType.Rows.Add(R);
            R = SysType.NewRow();
            R["valore"] = "estimatephase";
            R["descrizione"] = "Fase contab.contratto attivo";
            SysType.Rows.Add(R);

            R = SysType.NewRow();
			R["valore"]= "expensefinphase";
			R["descrizione"]="Fase spesa bilancio";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "expenseregphase";
			R["descrizione"]="Fase spesa creditore";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "incomefinphase";
			R["descrizione"]="Fase entrata bilancio";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "incomeregphase";
			R["descrizione"]="Fase entrata creditore";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "appropriationphase";
			R["descrizione"]="Fase impegno";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "assessmentphase";
			R["descrizione"]="Fase accertamento";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "idcustomuser";
			R["descrizione"]="Id dell'utente (in customuser)";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "deferredexpensephase";
			R["descrizione"]="Fase spesa Iva differita";
			SysType.Rows.Add(R);
			R= SysType.NewRow();
			R["valore"]= "deferredincomephase";
			R["descrizione"]="Fase entrata Iva differita";
			SysType.Rows.Add(R);
            R = SysType.NewRow();
            R["valore"] = "idflowchart";
            R["descrizione"] = "Ruolo Corrente";
            SysType.Rows.Add(R);
            R = SysType.NewRow();
            R["valore"] = "codesorkind_siopespese";
            R["descrizione"] = "Codice Classificazione SIOPE Spese (code)";
            SysType.Rows.Add(R);
            R = SysType.NewRow();
            R["valore"] = "codesorkind_siopeentrate";
            R["descrizione"] = "Codice Classificazione SIOPE Entrate (code)";
            SysType.Rows.Add(R);

			cmbSysType.DataSource= SysType;
			cmbSysType.DisplayMember="descrizione";
			cmbSysType.ValueMember="valore";
			cmbSysType.SelectedIndex=1;
			cmbSysType.SelectedIndex=0;

            FormatRichTextBox();
            ReFormatRichTextBox();
            HighLightEnabled = true;

		}
        DataTable AllTables = null;
        //DataTable AllViews = null;
        void FillTreeRoots(){
			AllTables= Conn.RUN_SELECT("customobject","objectname","objectname",null, null,null,true);
            DataTable alltabledescr = Conn.RUN_SELECT("tabledescr", "tablename,title", null, null, null, true);
            CQueryHelper q = new CQueryHelper();
			foreach (DataRow Rtable in AllTables.Rows){
				TreeNode Root = new TreeNode(Rtable["objectname"].ToString());
			    if (alltabledescr.Rows.Count > 0) {
                    DataRow[] f = alltabledescr.Select(q.CmpEq("tablename", Rtable["objectname"]));
                    if (f.Length > 0) {
                        Root.ToolTipText = f[0]["title"].ToString();
                    }
                }
                treeFields.Nodes.Add(Root);
                list_tables.Add(Rtable["objectname"].ToString());
				Root.Nodes.Add(".");
			}

		}
        List<string> list_tables = new List<string>();

        bool checkTableDotField(string tabdotfield) {
            string[] f = tabdotfield.Split('.');
            CQueryHelper QHC = new CQueryHelper();
            if (f.Length < 2) return false;
            if (f[0].ToString().ToLower() != maintable) return false;
            //if (!list_tables.Contains(f[0])) return false;
            dbstructure DBS = Conn.GetStructure(f[0]);
            if (DBS==null) return false;
			DataRow []cols= DBS.columntypes.Select(QHC.CmpEq("field",f[1]));
			if (cols.Length==0) return false;
            return true;            
        }

        bool checkTable(string tab) {
            //if (!list_tables.Contains(tab)) return false;
            if (tab == null) return false;
            return (tab.ToLower()== maintable);
        }
		void Generate_SystemSqlkeysXml(){
			string currdir=AppDomain.CurrentDomain.BaseDirectory;
			string keyfile = currdir+"\\system_SQLkeys.txt";
			try {
				FileStream  FS = new FileStream(keyfile, FileMode.Open);
				StreamReader SR = new StreamReader(FS);
				string k= SR.ReadLine();
				while (k!=null){
					DataRow RR = DS.sqlcmd.NewRow();
					RR["cmd"]=k;
					DS.sqlcmd.Rows.Add(RR);
					k= SR.ReadLine();
				}
				SR.Close();
				FS.Close();
				DS.WriteXml(currdir+"\\system_SQLkeys.xml");
			}
			catch (Exception E){
				MessageBox.Show(E.Message);
			}
		}

		void ReadSqlKeys(){
			string currdir=AppDomain.CurrentDomain.BaseDirectory;
			if (!File.Exists(currdir+"\\system_SQLkeys.xml")){
				Generate_SystemSqlkeysXml();
			}
			if (!File.Exists(currdir+"\\system_SQLkeys.xml")){
				MessageBox.Show("File system_SQLkeys.xml non tovato.");
				return;
			}
			DS.ReadXml(currdir+"\\system_SQLkeys.xml");
			foreach (DataRow R in DS.sqlcmd.Rows){
				SQLKeys[R["cmd"].ToString()]="1";
			}
		}
		

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSqlEditor));
            this.Generic_field_Btn = new System.Windows.Forms.Button();
            this.btn_C = new System.Windows.Forms.Button();
            this.btn_N = new System.Windows.Forms.Button();
            this.btn_F = new System.Windows.Forms.Button();
            this.btn_D = new System.Windows.Forms.Button();
            this.btn_V = new System.Windows.Forms.Button();
            this.btnAutomatico = new System.Windows.Forms.Button();
            this.BtnNewPar = new System.Windows.Forms.Button();
            this.BtnOldPar = new System.Windows.Forms.Button();
            this.BtnEsercizio = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.treeFields = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.DS = new SqlEditor.vistaForm();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbSysType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // Generic_field_Btn
            // 
            this.Generic_field_Btn.Location = new System.Drawing.Point(8, 8);
            this.Generic_field_Btn.Name = "Generic_field_Btn";
            this.Generic_field_Btn.Size = new System.Drawing.Size(64, 23);
            this.Generic_field_Btn.TabIndex = 0;
            this.Generic_field_Btn.Tag = "I";
            this.Generic_field_Btn.Text = "[( )] {I}";
            this.toolTip1.SetToolTip(this.Generic_field_Btn, "Espressione di tipo int");
            this.Generic_field_Btn.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btn_C
            // 
            this.btn_C.Location = new System.Drawing.Point(147, 8);
            this.btn_C.Name = "btn_C";
            this.btn_C.Size = new System.Drawing.Size(61, 23);
            this.btn_C.TabIndex = 1;
            this.btn_C.Tag = "C";
            this.btn_C.Text = "[( )] {C}";
            this.toolTip1.SetToolTip(this.btn_C, "Espressione di tipo varchar(255)");
            this.btn_C.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btn_N
            // 
            this.btn_N.Location = new System.Drawing.Point(147, 40);
            this.btn_N.Name = "btn_N";
            this.btn_N.Size = new System.Drawing.Size(61, 23);
            this.btn_N.TabIndex = 2;
            this.btn_N.Tag = "N";
            this.btn_N.Text = "[( )] {N}";
            this.toolTip1.SetToolTip(this.btn_N, "Espressione di tipo decimal(23,6)");
            this.btn_N.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btn_F
            // 
            this.btn_F.Location = new System.Drawing.Point(80, 8);
            this.btn_F.Name = "btn_F";
            this.btn_F.Size = new System.Drawing.Size(48, 23);
            this.btn_F.TabIndex = 3;
            this.btn_F.Tag = "F";
            this.btn_F.Text = "[( )] {F}";
            this.toolTip1.SetToolTip(this.btn_F, "Espressione di tipo real");
            this.btn_F.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btn_D
            // 
            this.btn_D.Location = new System.Drawing.Point(8, 40);
            this.btn_D.Name = "btn_D";
            this.btn_D.Size = new System.Drawing.Size(64, 23);
            this.btn_D.TabIndex = 4;
            this.btn_D.Tag = "D";
            this.btn_D.Text = "[( )] {D}";
            this.toolTip1.SetToolTip(this.btn_D, "Espressione di tipo datetime");
            this.btn_D.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btn_V
            // 
            this.btn_V.Location = new System.Drawing.Point(80, 40);
            this.btn_V.Name = "btn_V";
            this.btn_V.Size = new System.Drawing.Size(48, 23);
            this.btn_V.TabIndex = 5;
            this.btn_V.Tag = "V";
            this.btn_V.Text = "[( )] {V}";
            this.toolTip1.SetToolTip(this.btn_V, "Espressione di tipo decimal(23,2)");
            this.btn_V.Click += new System.EventHandler(this.Generic_field_Btn_Click);
            // 
            // btnAutomatico
            // 
            this.btnAutomatico.Location = new System.Drawing.Point(32, 72);
            this.btnAutomatico.Name = "btnAutomatico";
            this.btnAutomatico.Size = new System.Drawing.Size(144, 24);
            this.btnAutomatico.TabIndex = 6;
            this.btnAutomatico.Text = "[( )] {AUTOMATICO}";
            this.toolTip1.SetToolTip(this.btnAutomatico, "Sceglie da solo il tipo di espressione più adatto");
            this.btnAutomatico.Click += new System.EventHandler(this.btnAutomatico_Click);
            // 
            // BtnNewPar
            // 
            this.BtnNewPar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnNewPar.Location = new System.Drawing.Point(40, 414);
            this.BtnNewPar.Name = "BtnNewPar";
            this.BtnNewPar.Size = new System.Drawing.Size(56, 23);
            this.BtnNewPar.TabIndex = 7;
            this.BtnNewPar.Tag = "%<x>%";
            this.BtnNewPar.Text = "%<P>%";
            this.toolTip1.SetToolTip(this.BtnNewPar, "Valore nuovo");
            this.BtnNewPar.Click += new System.EventHandler(this.BtnNewPar_Click);
            // 
            // BtnOldPar
            // 
            this.BtnOldPar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnOldPar.Location = new System.Drawing.Point(120, 414);
            this.BtnOldPar.Name = "BtnOldPar";
            this.BtnOldPar.Size = new System.Drawing.Size(56, 23);
            this.BtnOldPar.TabIndex = 8;
            this.BtnOldPar.Tag = "&&<x>&&";
            this.BtnOldPar.Text = "&&<O>&&";
            this.toolTip1.SetToolTip(this.BtnOldPar, "Valore precedente");
            this.BtnOldPar.Click += new System.EventHandler(this.BtnNewPar_Click);
            // 
            // BtnEsercizio
            // 
            this.BtnEsercizio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEsercizio.Location = new System.Drawing.Point(8, 446);
            this.BtnEsercizio.Name = "BtnEsercizio";
            this.BtnEsercizio.Size = new System.Drawing.Size(208, 23);
            this.BtnEsercizio.TabIndex = 9;
            this.BtnEsercizio.Text = "%<esercizio>%";
            this.toolTip1.SetToolTip(this.BtnEsercizio, "Variabile di sistema");
            this.BtnEsercizio.Click += new System.EventHandler(this.BtnEsercizio_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(120, 510);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(16, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annulla";
            // 
            // treeFields
            // 
            this.treeFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeFields.FullRowSelect = true;
            this.treeFields.HideSelection = false;
            this.treeFields.ImageIndex = 1;
            this.treeFields.ImageList = this.icons;
            this.treeFields.Location = new System.Drawing.Point(8, 104);
            this.treeFields.Name = "treeFields";
            this.treeFields.SelectedImageIndex = 0;
            this.treeFields.ShowNodeToolTips = true;
            this.treeFields.Size = new System.Drawing.Size(200, 302);
            this.treeFields.TabIndex = 13;
            this.treeFields.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFields_BeforeExpand);
            this.treeFields.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFields_AfterSelect);
            this.treeFields.DoubleClick += new System.EventHandler(this.treeFields_DoubleClick);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // txtSQL
            // 
            this.txtSQL.AcceptsTab = true;
            this.txtSQL.AllowDrop = true;
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.AutoWordSelection = true;
            this.txtSQL.DetectUrls = false;
            this.txtSQL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQL.HideSelection = false;
            this.txtSQL.Location = new System.Drawing.Point(224, 8);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtSQL.ShowSelectionMargin = true;
            this.txtSQL.Size = new System.Drawing.Size(672, 525);
            this.txtSQL.TabIndex = 15;
            this.txtSQL.Text = "";
            this.txtSQL.TextChanged += new System.EventHandler(this.txtSQL_TextChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // cmbSysType
            // 
            this.cmbSysType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSysType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSysType.Location = new System.Drawing.Point(8, 478);
            this.cmbSysType.Name = "cmbSysType";
            this.cmbSysType.Size = new System.Drawing.Size(208, 21);
            this.cmbSysType.TabIndex = 16;
            this.cmbSysType.SelectedIndexChanged += new System.EventHandler(this.cmbSysType_SelectedIndexChanged);
            // 
            // frmSqlEditor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(904, 547);
            this.Controls.Add(this.cmbSysType);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.treeFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.BtnEsercizio);
            this.Controls.Add(this.BtnOldPar);
            this.Controls.Add(this.BtnNewPar);
            this.Controls.Add(this.btnAutomatico);
            this.Controls.Add(this.btn_V);
            this.Controls.Add(this.btn_D);
            this.Controls.Add(this.btn_F);
            this.Controls.Add(this.btn_N);
            this.Controls.Add(this.btn_C);
            this.Controls.Add(this.Generic_field_Btn);
            this.Name = "frmSqlEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica Comando SQL";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		string GetIdentifier(string S, int start, out int startoftoken, out int endoftoken){
			startoftoken=start;
			int end=start+1;
			while ((end<S.Length)&&((Char.IsLetterOrDigit(S, end)||S[end]=='_')))end++;
			endoftoken=end-1;
			return S.Substring(start, endoftoken-start+1);
		}

		string GetNumber(string S, int start, out int startoftoken, out int endoftoken){
			startoftoken=start;
			int end=start+1;
			while ((end<S.Length)&&(Char.IsDigit(S, end)||(S[end]=='.')))end++;
			endoftoken=end-1;
			return S.Substring(start, endoftoken-start+1);
		}

		string GetString(string S,int start, out int startoftoken, out int endoftoken){
			startoftoken=start;
			int end=start+1;
			while (end<S.Length){
				if (S[end]!='\'') {
					end++;
					continue;
				}
				end++;
				if (end == S.Length) break;
				if (S[end]!='\'') break;
				end++;
				continue;
			}
			endoftoken=end-1;
			return S.Substring(start, endoftoken-start+1);

		}

		string GetOldTag(string S,int start, out int startoftoken, out int endoftoken){
			startoftoken=start;
			int next= S.IndexOf(">&", start+1);
			int end;
			if (next==-1) 
				end = S.Length-1;
			else
				end = next+1;
			endoftoken=end;
			return S.Substring(start, endoftoken-start+1);	
		}

		string GetNewTag(string S,int start, out int startoftoken, out int endoftoken){
			startoftoken=start;
			int next= S.IndexOf(">%", start+1);
			int end;
			if (next==-1) 
				end = S.Length-1;
			else
				end = next+1;
			endoftoken=end;
			return S.Substring(start, endoftoken-start+1);	
		}



		enum tokenkind {num, str, ident, old, _new, keyw,comment,none,table,sys,error};

        bool checkSys(string s) {
            CQueryHelper QHC = new CQueryHelper();
            if (!s.StartsWith("sys_")) return false;
            if (SysType.Select(QHC.CmpEq("valore", s.Substring(4))).Length == 0) return false;
            return true;
        }

		string GetNextToken(string S, int start, out int startoftoken, out int endoftoken, out tokenkind kind){
			int len=S.Length;
			int index=start;
			//skips blanks
			while ((index<len)&&
				(((S[index]==' ')||(S[index]=='\n')||char.IsWhiteSpace(S[index])||
				(S[index]=='\r'))||(S[index]=='\t')))index++;

			if (index==len){
				endoftoken=index-1;
				startoftoken=index-1;
				kind = tokenkind.none;
				return " ";
			}
			char first= S[index];
			if (Char.IsLetter(first)||first=='_'){
				kind = tokenkind.ident;
				string res= GetIdentifier(S, index, out startoftoken, out endoftoken);
                if (checkTable(res.ToLower())) kind= tokenkind.table;
				if (SQLKeys[res.ToLower()]!=null) kind = tokenkind.keyw;
				return res;
			}
			if (Char.IsDigit(first)){
				kind = tokenkind.num;
				return GetNumber(S, index, out startoftoken, out endoftoken);
			}
			if ((first=='%')&&(index+1<len)&&(S[index+1]=='<')){
				kind = tokenkind._new;
				string res= GetNewTag(S,index, out startoftoken, out endoftoken);
                if (res.Length > 4) {
                    string tabcol = res.Substring(2, res.Length - 4);
                    if (checkSys(tabcol)) {
                        kind = tokenkind.sys;
                    }
                    else {
                        if (!checkTableDotField(tabcol)) kind = tokenkind.error;
                    }
                }
                else {
                    kind = tokenkind.error;
                }
                return res;
			}
			if ((first=='&')&&(index+1<len)&&(S[index+1]=='<')){
				kind = tokenkind.old;
				string res= GetOldTag(S,index, out startoftoken, out endoftoken);
                if (res.Length > 4) {
                    string tabcol = res.Substring(2, res.Length - 4);
                    if (!checkTableDotField(tabcol)) kind = tokenkind.error;
                }
                else {
                    kind = tokenkind.error;
                }
                return res;

            }
			if (first=='\''){
				kind = tokenkind.str;
				return GetString(S, index, out startoftoken, out endoftoken);
			}
			if ((first=='-')||(first=='/')){
				string getcomment= GetComment(S,index,out startoftoken, out endoftoken);
				if (getcomment!=null){
					kind = tokenkind.comment;
					return getcomment;
				}
			}
			startoftoken=index;
			endoftoken=index;
			kind = tokenkind.none;
			return S[index].ToString();

		}



		string GetComment(string S, int index, out int startoftoken, out int endoftoken){
			startoftoken=index;
			endoftoken=index;
			if (index>=S.Length-1) return null;
			if (S[index]=='/'){
				if (S[index+1]!='*'){
					return null;
				}
				//cerca il tag di chiusura del commento
				int closing = S.IndexOf("*/",index+1);
				if (closing==-1){
					//Commento non chiuso
					endoftoken= S.Length-1;
					return S.Substring(index);
				}
				endoftoken= closing+1;
				return S.Substring(index, endoftoken-startoftoken+1);
			}
			if (S[index+1]!='-') return null;
			if (index>0){
				//verifica se il carattere precedente è un CR o LF
				if ((S[index-1]!='\n')&&(S[index-1]!='\r')) return null;
			}
			int nextCR = S.IndexOf('\n',index+1);
			int nextLF = S.IndexOf('\r',index+1);
			if ((nextCR==-1) && ( nextLF==-1)){
				//fine documento
				endoftoken = S.Length-1;
				return S.Substring(index);
			}
			if (nextLF==-1){
				endoftoken= nextCR-1;
				return S.Substring(startoftoken, endoftoken-startoftoken+1);
			}
			if (nextCR==-1){
				endoftoken= nextLF-1;
				return S.Substring(startoftoken, endoftoken-startoftoken+1);
			}
			if (nextCR<nextLF){
				endoftoken= nextCR-1;
				return S.Substring(startoftoken, endoftoken-startoftoken+1);
			}
			else {
				endoftoken= nextLF-1;
				return S.Substring(startoftoken, endoftoken-startoftoken+1);
			}

		}

		static void MarkEvent(string e){			
			string msg = "At "+QueryCreator.unquotedstrvalue(DateTime.Now,true)+":";
			Debug.Write(e+"\r",msg);

		}

		void FormatRichTextBox(){
			//colora i tag <% xxx %> di viola
			int index=0;
            btnOk.Visible = true;

			int starttoken;
			int endtoken;
			tokenkind kind;
			//txtSQL.SuspendLayout();
			string S = txtSQL.Text;
			while (index< S.Length){
				//MarkEvent("Start ...");
				string tok = GetNextToken(S, index, out starttoken, out endtoken, out kind);
				//MarkEvent("Token "+tok+" was got.");
				index = endtoken+1;
                if (kind == tokenkind.error) btnOk.Visible = false;
				txtSQL.Select(starttoken, endtoken-starttoken+1);
                Color myColor = Color.Black;
                Color myBackColor = Color.White;
                GetColorForKind(kind, out myColor, out myBackColor);
				txtSQL.SelectionColor= myColor;
                txtSQL.SelectionBackColor = myBackColor;
			}
			//txtSQL.ResumeLayout();


		}

        void GetColorForKind(tokenkind kind, out Color myColor, out Color myBackColor) {
            myColor = Color.Black;
            myBackColor = Color.White;
            switch (kind) {
                case tokenkind._new: myColor = Color.Magenta;
                break;
                case tokenkind.ident: myColor = Color.Black;
                break;
                case tokenkind.keyw: myColor = Color.Blue;
                break;
                case tokenkind.none: myColor = Color.Black;
                break;
                case tokenkind.num: myColor = Color.Red;
                break;
                case tokenkind.old: myColor = Color.DarkGray;
                break;
                case tokenkind.str: myColor = Color.Red;
                break;
                case tokenkind.comment: myColor = Color.Green;
                break;
                case tokenkind.error: myBackColor = Color.Red;
                break;
                case tokenkind.table: myColor = Color.LightSkyBlue;
                break;
                case tokenkind.sys: myColor = Color.HotPink;
                break;

            }
        }

		void ReFormatRichTextBox(){
			//colora i tag <% xxx %> di viola
			int index=0;
            btnOk.Visible = true;
            int starttoken;
			int endtoken;
			tokenkind kind;
			//txtSQL.SuspendLayout();
			RichTextBox TEMP = new RichTextBox();
			TEMP.Rtf = txtSQL.Rtf;

			string S = TEMP.Text;
			while (index< S.Length){
				//MarkEvent("Start ...");
				string tok = GetNextToken(S, index, out starttoken, out endtoken, out kind);
				//MarkEvent("Token "+tok+" was got.");
				index = endtoken+1;				
				TEMP.Select(starttoken, endtoken-starttoken+1);
                if (kind == tokenkind.error) btnOk.Visible = false;
                Color myColor = Color.Black;
                Color myBackColor = Color.White;
                GetColorForKind(kind, out myColor, out myBackColor);
                TEMP.SelectionColor = myColor;
                TEMP.SelectionBackColor = myBackColor;
			}
			//txtSQL.ResumeLayout();
			txtSQL.Rtf= TEMP.Rtf;

		}

		void InsertStringIntoStatement(string S){
			TextBox T = new TextBox();
			T.Text=S;
			T.SelectAll();
			T.Copy();
			txtSQL.Paste();
			/*


			string currmsg= txtSQL.Text;
			int currpos = txtSQL.SelectionStart;
			int sellen= txtSQL.SelectionLength;

			if ((currpos<0)||(currpos>currmsg.Length)) {
				currpos= currmsg.Length;
				sellen=0;
			}
			else {
				txtSQL.Paste();
				
			}
			currmsg = currmsg.Insert(currpos,S);			
			txtSQL.Text= currmsg;
			txtSQL.SelectionStart=currpos;
			txtSQL.SelectionLength=sellen;
			*/

		}
		private void treeFields_DoubleClick(object sender, System.EventArgs e) {
			TreeNode curr = treeFields.SelectedNode;
			if (curr.Nodes.Count>0) return;
			if (curr.Parent==null) return;
			string tablename = curr.Parent.Text;
			string colname=curr.Text;
			string fieldref = "%<"+tablename+"."+colname+">%";
			InsertStringIntoStatement(fieldref);

		}

		private void txtSQL_TextChanged(object sender, System.EventArgs e) {
			if (!HighLightEnabled) return;
			HighLightEnabled=false;
			int currpos = txtSQL.SelectionStart;
			int sellen= txtSQL.SelectionLength;
			ReFormatRichTextBox();
			txtSQL.SelectionStart=currpos;
			txtSQL.SelectionLength=sellen;
			HighLightEnabled=true;

		}

		string GetGoodTypeFor(string tablename, string fieldname){
			dbstructure DBS = Conn.GetStructure(tablename);
			DataRow []cols= DBS.columntypes.Select("field='"+fieldname+"'");
			if (cols.Length==0) return "?";
			string tipo= cols[0]["systemtype"].ToString();
			switch (tipo){
				case "System.Double":return "N";
				case "System.Int32":return "I";
				case "System.String":return "C";
				case "System.DateTime":return "D";
				case "System.Int16":return "I";
				case "System.Decimal": return "V";
				default: return "C";
			}
		}

		void AddSelectField(string table, string col, string kind){
			string ToAdd= "[(select "+col+" from "+table+" where )]{"+
				kind+"}";
			InsertStringIntoStatement(ToAdd);
		}


		private void btnAutomatico_Click(object sender, System.EventArgs e) {
			TreeNode curr= treeFields.SelectedNode;
			if (curr==null) return;
			if (curr.Nodes.Count>0) return;
			if (curr.Parent==null) return;
			string tablename = curr.Parent.Text;
			string colname=curr.Text;
			AddSelectField(tablename, colname, GetGoodTypeFor(tablename,colname));
		}

		private void Generic_field_Btn_Click(object sender, System.EventArgs e) {
			TreeNode curr= treeFields.SelectedNode;
			if (curr==null) return;
			if (curr.Nodes.Count>0) return;
			if (curr.Parent==null) return;
			string tablename = curr.Parent.Text;
			string colname=curr.Text;
			Button BTN = (Button) sender;
			AddSelectField(tablename, colname, BTN.Tag.ToString());
		}


		private void BtnNewPar_Click(object sender, System.EventArgs e) {
			TreeNode curr= treeFields.SelectedNode;
			if (curr==null) return;
			if (curr.Nodes.Count>0) return;
			if (curr.Parent==null) return;
			string tablename = curr.Parent.Text;
			string colname=curr.Text;
			Button BTN = (Button) sender;
			string tag = BTN.Tag.ToString();
			tag = tag.Replace("&&","&");
			string ToAdd= tag.Replace("x",tablename+"."+colname);
			InsertStringIntoStatement(ToAdd);
		
		}

		private void BtnEsercizio_Click(object sender, System.EventArgs e) {
			InsertStringIntoStatement(BtnEsercizio.Text);		
		}


		void EnableDisableBtnRelatedFields(bool enable){
			Generic_field_Btn.Enabled=enable;
			btn_C.Enabled=enable;
			btn_D.Enabled=enable;
			btn_F.Enabled=enable;
			btn_N.Enabled=enable;
			btn_V.Enabled=enable;
			btnAutomatico.Enabled=enable;

			BtnOldPar.Enabled=enable;
			BtnNewPar.Enabled=enable;

		}

		private void treeFields_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			TreeNode curr= treeFields.SelectedNode;
			if (curr==null) {
				EnableDisableBtnRelatedFields(false);
				return;
			}
			if (curr.Nodes.Count>0) {
				EnableDisableBtnRelatedFields(false);
				return;
			}
			if (curr.Parent==null) {
				EnableDisableBtnRelatedFields(false);
				return;
			}

			EnableDisableBtnRelatedFields(curr.Parent.Text.ToLower()==maintable);
		
		}

		private void treeFields_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e) {
			TreeNode Curr = e.Node;
			if (Curr.Parent!=null) return;
			if (Curr.Nodes.Count!=1) return;
			TreeNode Child = Curr.Nodes[0];
			if (Child.Text!=".") return;
			Curr.Nodes.Clear();
		    QueryHelper QHS = Conn.GetQueryHelper();
			string currtable= Curr.Text;
			dbstructure DBS = Conn.GetStructure(currtable);
			foreach(DataRow ColDesc in DBS.columntypes.Select(null,"field")) {
			    DataTable descr = Conn.RUN_SELECT("coldescr","*",null,
			        QHS.AppAnd(QHS.CmpEq("tablename", ColDesc["tablename"]), QHS.CmpEq("colname", ColDesc["field"])),
			        null,false);
                TreeNode n  = Curr.Nodes.Add(ColDesc["field"].ToString());
                if (descr.Rows.Count>0) {
                    DataRow r = descr.Rows[0];
                    string s = r["description"].ToString();
                    DataTable bit = Conn.RUN_SELECT("colbit", "*", null,
                        QHS.AppAnd(QHS.CmpEq("tablename", ColDesc["tablename"]), QHS.CmpEq("colname", ColDesc["field"])),
                        null, false);
                    foreach (DataRow rb in bit.Rows) {
                        s += "\n\r";
                        s += "bit " + rb["nbit"].ToString() + ": " + rb["title"];
                        if (rb["description"].ToString() != "") {
                            s += "\n" + rb["description"].ToString();
                        }
                    }
                    DataTable val = Conn.RUN_SELECT("colvalue", "*", null,
                        QHS.AppAnd(QHS.CmpEq("tablename", ColDesc["tablename"]), QHS.CmpEq("colname", ColDesc["field"])),
                        null, false);
                    foreach (DataRow rb in val.Rows) {
                        s += "\n\r";
                        s += "valore " + rb["value"].ToString() + ": " + rb["title"];
                        if (rb["description"].ToString() != "") {
                            s += "\n" + rb["description"].ToString();
                        }

                    }


                    if (s!="") n.ToolTipText = s;

                    
                }
                
			}
			
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			SQLstatement = txtSQL.Text.ToString();
		}

		private void cmbSysType_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (cmbSysType.SelectedIndex<0) return;
			if (cmbSysType.SelectedValue==null) return;
			BtnEsercizio.Text="%<sys_"+cmbSysType.SelectedValue.ToString()+">%";
		}

	

	}
}
