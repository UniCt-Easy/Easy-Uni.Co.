
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Globalization;
using funzioni_configurazione;

namespace pettycashoperationsorted_default {
	/// <summary>
	/// Summary description for Frm_pettycashoperationsorted_default.
	/// </summary>
	public class Frm_pettycashoperationsorted_default : MetaDataForm {
		public MetaData Meta;
		decimal importototale;
		decimal importoresiduo;
		decimal importomovimento;
		decimal importooriginale;
		bool HasBeenActivated;
		bool primolivello = false;
		bool secondolivello = false;
		bool terzolivello = false;
		bool formcorto = false;
		bool inChiusura = false;
		public pettycashoperationsorted_default.vistaForm DS;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkIncompleto;
		private System.Windows.Forms.TextBox txtPercentuale;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtSubmovimento;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelignoradate;
		private System.Windows.Forms.CheckBox chkIgnoraDate;
		private System.Windows.Forms.Label labelslash;
		private System.Windows.Forms.Label datalabel;
		public System.Windows.Forms.TextBox DataFine;
		public System.Windows.Forms.TextBox DataInizio;
		private System.Windows.Forms.Label lblPercentuale;
		private System.Windows.Forms.Label lblImporto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtCodiceClass;
		private System.Windows.Forms.TextBox txtDescrizioneClass;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox valoreV5;
		public System.Windows.Forms.TextBox valoreV4;
		public System.Windows.Forms.TextBox valoreV3;
		public System.Windows.Forms.TextBox valoreV2;
		public System.Windows.Forms.TextBox valoreV1;
		public System.Windows.Forms.Label labelV5;
		public System.Windows.Forms.Label labelV4;
		public System.Windows.Forms.Label labelV3;
		public System.Windows.Forms.Label labelV2;
		public System.Windows.Forms.Label labelV1;
		public System.Windows.Forms.TextBox valoreS5;
		public System.Windows.Forms.TextBox valoreN5;
		public System.Windows.Forms.TextBox valoreS4;
		public System.Windows.Forms.TextBox valoreN4;
		public System.Windows.Forms.TextBox valoreN2;
		public System.Windows.Forms.TextBox valoreS3;
		public System.Windows.Forms.TextBox valoreS2;
		public System.Windows.Forms.TextBox valoreN1;
		public System.Windows.Forms.TextBox valoreN3;
		public System.Windows.Forms.TextBox valoreS1;
		public System.Windows.Forms.Label labelS5;
		public System.Windows.Forms.Label labelS4;
		public System.Windows.Forms.Label labelS3;
		public System.Windows.Forms.Label labelS2;
		public System.Windows.Forms.Label labelS1;
		public System.Windows.Forms.Label labelN5;
		public System.Windows.Forms.Label labelN4;
		public System.Windows.Forms.Label labelN3;
		public System.Windows.Forms.Label labelN2;
		public System.Windows.Forms.Label labelN1;
        CQueryHelper QHC;
        QueryHelper QHS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_pettycashoperationsorted_default() {
			InitializeComponent();
			HasBeenActivated=false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Meta.ExtraParameter;
			HelpForm.SetDenyNull(DS.pettycashoperationsorted.Columns["tobecontinued"],true);
		}

		public void MetaData_AfterFill(){
			AnalizzaCheckIgnoraDate();
		}

		TextBox GetTxtByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			return T;
		}
		Label GetLabByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			Label L =  (Label) Ctrl.GetValue(this);                        
			return L;
		}


		bool IsChiocciola(string suffix){
//			if (DS.sortingtranslation.Rows.Count==0) return false;
//			string field="default"+suffix;
//			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
//			if (CurrTrad[field].ToString().Trim()=="@") return true;
			return false;
		}

		bool MustAsk(string suffix){
//			if (DS.sortingtranslation.Rows.Count==0) return true;
//			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
//			string field="default"+suffix;
//			if (CurrTrad[field].ToString().Trim()=="?") return true;
			return false;
		}


		/// <summary>
		/// Restituisce un textbox ed imposta in automatico le variabili primo,secondo e terzolivello
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		TextBox GetTextBoxNum(int i){
			int col = (i-1)/5;
			int row = ((i-1) % 5)+1;
			string suffix="";
			switch (col){
				case 0:suffix="N";
					primolivello=true;
					break;
				case 1:suffix="S";
					secondolivello=true;
					break;
				case 2:suffix="V";
					terzolivello=true;
					break;
			}
			suffix+=row.ToString();
			TextBox T = GetTxtByName("valore"+suffix);
			return T;

		}

		/// <summary>
		/// Restituisce un textbox ed imposta in automatico le variabili fromcorto,
		///			primo,secondo e terzolivello
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		Label GetLabelNum(int i){
			int col = (i-1)/5;
			int row = ((i-1) % 5)+1;
			if (row>3) formcorto=false;
			string suffix="";
			switch (col){
				case 0:suffix="N";
					break;
				case 1:suffix="S";
					break;
				case 2:suffix="V";
					break;
			}
			suffix+=row.ToString();
			Label L = GetLabByName("label"+suffix);
			return L;

		}



		public void MetaData_AfterActivation(){
			if (DS.pettycashoperationsorted.Rows.Count==0) return;

			DataRow CurrRow = DS.pettycashoperationsorted.Rows[0];
			importomovimento= CfgFn.GetNoNullDecimal(CurrRow["amount"]);
			importoresiduo= CfgFn.GetNoNullDecimal(DS.pettycashoperationsorted.ExtendedProperties["importoresiduo"]);
			importototale= CfgFn.GetNoNullDecimal(DS.pettycashoperationsorted.ExtendedProperties["importototale"]);
			importooriginale= importomovimento;
			int NControls=0;

			bool read_only=false;
			
			txtImporto.ReadOnly=false; //read_only;
			txtPercentuale.ReadOnly=false; //read_only;

            object filterObj = DS.pettycashoperationsorted.ExtendedProperties["CustomParentRelation"];
            string filter = "";
            if (filterObj != null)
            {
                filter = filterObj.ToString();
                filter = filter.Replace("!", "");
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.sortingkind, null, filter, null, true);
            }

			if (DS.sortingkind.Rows.Count==0) return;
			DataRow Rtipo = DS.sortingkind.Rows[0];
			if (Rtipo["totalexpression"].ToString()==""){
				importoresiduo=importototale-importooriginale;
			}
			

			if (Rtipo["flagdate"].ToString().ToLower()!="s"){
				chkIgnoraDate.Visible = false;
				labelignoradate.Visible=false;
				datalabel.Visible = false;
				labelslash.Visible=false;
				DataInizio.Visible = false;
				DataFine.Visible= false;                
				formcorto=true;
			}
			else {
				HelpForm.SetDenyNull(DS.pettycashoperationsorted.Columns["flagnodate"],true);
				formcorto=false;
			}
			HasBeenActivated=true;

			foreach(string kind in new string[]{"n","s","v"}){
				for (int i=1; i<=5; i++) {
					string suffix= kind+i.ToString();
					if (Rtipo["label"+suffix].ToString()=="")continue;
					NControls++;
					TextBox T = GetTextBoxNum(NControls);
					T.Visible=true;
					Label L= GetLabelNum(NControls);
					L.Visible=true;
					T.Tag="pettycashoperationsorted.value"+kind+i.ToString();
					Meta.myHelpForm.AddEvents(T);

					if (kind=="V") T.Tag=T.Tag.ToString()+".N";
					L.Tag="sortingkind.label"+kind+i.ToString();

					switch (Rtipo["locked"+suffix].ToString().ToLower()) {
						case "s": {
							T.Visible = false;
							break;
						}
						case "n": {
							T.Visible = true;
							T.ReadOnly = read_only;
							break;
						}
						default: {
							T.Visible = true;
							break;
						}
					}

					if (Rtipo["forced"+suffix].ToString().ToLower()=="s") {
						if (CurrRow["value"+suffix]==DBNull.Value) {
							if (kind=="n") CurrRow["value"+suffix]=0;
							if (kind=="v") CurrRow["value"+suffix]=0;
							if (kind=="s") CurrRow["value"+suffix]="";
						}
						T.Visible = true;
						T.ReadOnly = false;
						HelpForm.SetDenyNull(DS.Tables["pettycashoperationsorted"].Columns["value"+suffix],true);
					}
				}
			}


			decimal percentuale = 100;
			if (importototale!=0) percentuale= importomovimento/importototale*100;
			decimal rounded = Math.Round(percentuale, 4);
			txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");

            GetData.SetStaticFilter(DS.sorting, filter);

			if (terzolivello){
				Width=928;
			}
			else {
				if (secondolivello){
					Width=712;
				}
				else {
					if (primolivello)
						Width=544;
					else
						Width=464;			
				}
			}
			if (formcorto) Height=288;
			CenterToScreen();			
		}



		void UpdateCampiChiocciola(){
			foreach (string kind in new string[]{"n","s","v"}){
				for (int i=1;i<=5;i++){
					string suffix=kind+i.ToString();
					if (IsChiocciola(suffix)){
						TextBox T = GetTxtByName("value"+suffix);
						T.Text= importomovimento.ToString("c");
					}
				}
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.DS = new pettycashoperationsorted_default.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.chkIncompleto = new System.Windows.Forms.CheckBox();
			this.txtPercentuale = new System.Windows.Forms.TextBox();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtSubmovimento = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelignoradate = new System.Windows.Forms.Label();
			this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
			this.labelslash = new System.Windows.Forms.Label();
			this.datalabel = new System.Windows.Forms.Label();
			this.DataFine = new System.Windows.Forms.TextBox();
			this.DataInizio = new System.Windows.Forms.TextBox();
			this.lblPercentuale = new System.Windows.Forms.Label();
			this.lblImporto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtCodiceClass = new System.Windows.Forms.TextBox();
			this.txtDescrizioneClass = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.valoreV5 = new System.Windows.Forms.TextBox();
			this.valoreV4 = new System.Windows.Forms.TextBox();
			this.valoreV3 = new System.Windows.Forms.TextBox();
			this.valoreV2 = new System.Windows.Forms.TextBox();
			this.valoreV1 = new System.Windows.Forms.TextBox();
			this.labelV5 = new System.Windows.Forms.Label();
			this.labelV4 = new System.Windows.Forms.Label();
			this.labelV3 = new System.Windows.Forms.Label();
			this.labelV2 = new System.Windows.Forms.Label();
			this.labelV1 = new System.Windows.Forms.Label();
			this.valoreS5 = new System.Windows.Forms.TextBox();
			this.valoreN5 = new System.Windows.Forms.TextBox();
			this.valoreS4 = new System.Windows.Forms.TextBox();
			this.valoreN4 = new System.Windows.Forms.TextBox();
			this.valoreN2 = new System.Windows.Forms.TextBox();
			this.valoreS3 = new System.Windows.Forms.TextBox();
			this.valoreS2 = new System.Windows.Forms.TextBox();
			this.valoreN1 = new System.Windows.Forms.TextBox();
			this.valoreN3 = new System.Windows.Forms.TextBox();
			this.valoreS1 = new System.Windows.Forms.TextBox();
			this.labelS5 = new System.Windows.Forms.Label();
			this.labelS4 = new System.Windows.Forms.Label();
			this.labelS3 = new System.Windows.Forms.Label();
			this.labelS2 = new System.Windows.Forms.Label();
			this.labelS1 = new System.Windows.Forms.Label();
			this.labelN5 = new System.Windows.Forms.Label();
			this.labelN4 = new System.Windows.Forms.Label();
			this.labelN3 = new System.Windows.Forms.Label();
			this.labelN2 = new System.Windows.Forms.Label();
			this.labelN1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(760, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 278;
			this.btnCancel.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(656, 320);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(80, 23);
			this.btnOk.TabIndex = 277;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "&OK";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(252, 189);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 24);
			this.label1.TabIndex = 280;
			this.label1.Text = "%";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkIncompleto
			// 
			this.chkIncompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkIncompleto.Location = new System.Drawing.Point(12, 330);
			this.chkIncompleto.Name = "chkIncompleto";
			this.chkIncompleto.Size = new System.Drawing.Size(152, 16);
			this.chkIncompleto.TabIndex = 279;
			this.chkIncompleto.Tag = "pettycashoperationsorted.tobecontinued:S:N";
			this.chkIncompleto.Text = "Da completare in seguito";
			// 
			// txtPercentuale
			// 
			this.txtPercentuale.Location = new System.Drawing.Point(172, 189);
			this.txtPercentuale.Name = "txtPercentuale";
			this.txtPercentuale.Size = new System.Drawing.Size(80, 20);
			this.txtPercentuale.TabIndex = 250;
			this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(12, 189);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(144, 20);
			this.txtImporto.TabIndex = 249;
			this.txtImporto.Tag = "pettycashoperationsorted.amount";
			this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(124, 117);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(248, 48);
			this.txtDescrizione.TabIndex = 248;
			this.txtDescrizione.Tag = "pettycashoperationsorted.description";
			// 
			// txtSubmovimento
			// 
			this.txtSubmovimento.Location = new System.Drawing.Point(12, 117);
			this.txtSubmovimento.Name = "txtSubmovimento";
			this.txtSubmovimento.ReadOnly = true;
			this.txtSubmovimento.Size = new System.Drawing.Size(100, 20);
			this.txtSubmovimento.TabIndex = 251;
			this.txtSubmovimento.Tag = "pettycashoperationsorted.idsubclass";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelignoradate);
			this.panel1.Controls.Add(this.chkIgnoraDate);
			this.panel1.Controls.Add(this.labelslash);
			this.panel1.Controls.Add(this.datalabel);
			this.panel1.Controls.Add(this.DataFine);
			this.panel1.Controls.Add(this.DataInizio);
			this.panel1.Location = new System.Drawing.Point(4, 229);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(352, 80);
			this.panel1.TabIndex = 256;
			// 
			// labelignoradate
			// 
			this.labelignoradate.Location = new System.Drawing.Point(32, 16);
			this.labelignoradate.Name = "labelignoradate";
			this.labelignoradate.Size = new System.Drawing.Size(312, 16);
			this.labelignoradate.TabIndex = 146;
			this.labelignoradate.Tag = "sortingkind.nodatelabel";
			this.labelignoradate.Text = "ignora date custom";
			// 
			// chkIgnoraDate
			// 
			this.chkIgnoraDate.Location = new System.Drawing.Point(12, 16);
			this.chkIgnoraDate.Name = "chkIgnoraDate";
			this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
			this.chkIgnoraDate.TabIndex = 145;
			this.chkIgnoraDate.Tag = "pettycashoperationsorted.flagnodate:S:N";
			this.chkIgnoraDate.CheckedChanged += new System.EventHandler(this.chkIgnoraDate_CheckedChanged);
			// 
			// labelslash
			// 
			this.labelslash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelslash.Location = new System.Drawing.Point(172, 50);
			this.labelslash.Name = "labelslash";
			this.labelslash.Size = new System.Drawing.Size(12, 16);
			this.labelslash.TabIndex = 144;
			this.labelslash.Text = "--";
			// 
			// datalabel
			// 
			this.datalabel.Location = new System.Drawing.Point(16, 34);
			this.datalabel.Name = "datalabel";
			this.datalabel.Size = new System.Drawing.Size(320, 16);
			this.datalabel.TabIndex = 143;
			this.datalabel.Tag = "sortingkind.labelfordate";
			this.datalabel.Text = "datalabel";
			this.datalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DataFine
			// 
			this.DataFine.Location = new System.Drawing.Point(188, 50);
			this.DataFine.Name = "DataFine";
			this.DataFine.Size = new System.Drawing.Size(144, 20);
			this.DataFine.TabIndex = 6;
			this.DataFine.Tag = "pettycashoperationsorted.stop";
			// 
			// DataInizio
			// 
			this.DataInizio.Location = new System.Drawing.Point(20, 50);
			this.DataInizio.Name = "DataInizio";
			this.DataInizio.Size = new System.Drawing.Size(144, 20);
			this.DataInizio.TabIndex = 5;
			this.DataInizio.Tag = "pettycashoperationsorted.start";
			// 
			// lblPercentuale
			// 
			this.lblPercentuale.Location = new System.Drawing.Point(172, 173);
			this.lblPercentuale.Name = "lblPercentuale";
			this.lblPercentuale.Size = new System.Drawing.Size(100, 23);
			this.lblPercentuale.TabIndex = 255;
			this.lblPercentuale.Text = "Percentuale";
			// 
			// lblImporto
			// 
			this.lblImporto.Location = new System.Drawing.Point(12, 173);
			this.lblImporto.Name = "lblImporto";
			this.lblImporto.Size = new System.Drawing.Size(100, 23);
			this.lblImporto.TabIndex = 254;
			this.lblImporto.Text = "Importo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(124, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 253;
			this.label2.Text = "Descrizione";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.txtCodiceClass);
			this.groupBox1.Controls.Add(this.txtDescrizioneClass);
			this.groupBox1.Location = new System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 80);
			this.groupBox1.TabIndex = 247;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "AutoManage.txtCodiceClass.tree";
			this.groupBox1.Text = "Selezione voce della classificazione";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 159;
			this.button1.Tag = "manage.sorting.tree";
			this.button1.Text = "Codice:";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceClass
			// 
			this.txtCodiceClass.Location = new System.Drawing.Point(112, 24);
			this.txtCodiceClass.Name = "txtCodiceClass";
			this.txtCodiceClass.Size = new System.Drawing.Size(100, 20);
			this.txtCodiceClass.TabIndex = 155;
			this.txtCodiceClass.Tag = "sorting.sortcode?x";
			// 
			// txtDescrizioneClass
			// 
			this.txtDescrizioneClass.Location = new System.Drawing.Point(224, 24);
			this.txtDescrizioneClass.Multiline = true;
			this.txtDescrizioneClass.Name = "txtDescrizioneClass";
			this.txtDescrizioneClass.ReadOnly = true;
			this.txtDescrizioneClass.Size = new System.Drawing.Size(208, 48);
			this.txtDescrizioneClass.TabIndex = 156;
			this.txtDescrizioneClass.Tag = "sorting.description";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 252;
			this.label3.Text = "Submovimento";
			// 
			// valoreV5
			// 
			this.valoreV5.Location = new System.Drawing.Point(708, 277);
			this.valoreV5.Name = "valoreV5";
			this.valoreV5.Size = new System.Drawing.Size(144, 20);
			this.valoreV5.TabIndex = 290;
			this.valoreV5.Tag = "";
			this.valoreV5.Visible = false;
			// 
			// valoreV4
			// 
			this.valoreV4.Location = new System.Drawing.Point(708, 237);
			this.valoreV4.Name = "valoreV4";
			this.valoreV4.Size = new System.Drawing.Size(144, 20);
			this.valoreV4.TabIndex = 289;
			this.valoreV4.Tag = "";
			this.valoreV4.Visible = false;
			// 
			// valoreV3
			// 
			this.valoreV3.Location = new System.Drawing.Point(708, 197);
			this.valoreV3.Name = "valoreV3";
			this.valoreV3.Size = new System.Drawing.Size(144, 20);
			this.valoreV3.TabIndex = 286;
			this.valoreV3.Tag = "";
			this.valoreV3.Visible = false;
			// 
			// valoreV2
			// 
			this.valoreV2.Location = new System.Drawing.Point(708, 157);
			this.valoreV2.Name = "valoreV2";
			this.valoreV2.Size = new System.Drawing.Size(144, 20);
			this.valoreV2.TabIndex = 285;
			this.valoreV2.Tag = "";
			this.valoreV2.Visible = false;
			// 
			// valoreV1
			// 
			this.valoreV1.Location = new System.Drawing.Point(708, 117);
			this.valoreV1.Name = "valoreV1";
			this.valoreV1.Size = new System.Drawing.Size(144, 20);
			this.valoreV1.TabIndex = 284;
			this.valoreV1.Tag = "";
			this.valoreV1.Visible = false;
			// 
			// labelV5
			// 
			this.labelV5.Location = new System.Drawing.Point(708, 261);
			this.labelV5.Name = "labelV5";
			this.labelV5.Size = new System.Drawing.Size(144, 16);
			this.labelV5.TabIndex = 288;
			this.labelV5.Tag = "";
			this.labelV5.Text = "labelV5";
			this.labelV5.Visible = false;
			// 
			// labelV4
			// 
			this.labelV4.Location = new System.Drawing.Point(708, 221);
			this.labelV4.Name = "labelV4";
			this.labelV4.Size = new System.Drawing.Size(144, 16);
			this.labelV4.TabIndex = 287;
			this.labelV4.Tag = "";
			this.labelV4.Text = "labelV4";
			this.labelV4.Visible = false;
			// 
			// labelV3
			// 
			this.labelV3.Location = new System.Drawing.Point(708, 181);
			this.labelV3.Name = "labelV3";
			this.labelV3.Size = new System.Drawing.Size(144, 16);
			this.labelV3.TabIndex = 283;
			this.labelV3.Tag = "";
			this.labelV3.Text = "labelV3";
			this.labelV3.Visible = false;
			// 
			// labelV2
			// 
			this.labelV2.Location = new System.Drawing.Point(708, 141);
			this.labelV2.Name = "labelV2";
			this.labelV2.Size = new System.Drawing.Size(144, 16);
			this.labelV2.TabIndex = 282;
			this.labelV2.Tag = "";
			this.labelV2.Text = "labelV2";
			this.labelV2.Visible = false;
			// 
			// labelV1
			// 
			this.labelV1.Location = new System.Drawing.Point(708, 101);
			this.labelV1.Name = "labelV1";
			this.labelV1.Size = new System.Drawing.Size(144, 16);
			this.labelV1.TabIndex = 281;
			this.labelV1.Tag = "";
			this.labelV1.Text = "labelV1";
			this.labelV1.Visible = false;
			// 
			// valoreS5
			// 
			this.valoreS5.Location = new System.Drawing.Point(548, 277);
			this.valoreS5.Name = "valoreS5";
			this.valoreS5.Size = new System.Drawing.Size(144, 20);
			this.valoreS5.TabIndex = 276;
			this.valoreS5.Tag = "";
			this.valoreS5.Visible = false;
			// 
			// valoreN5
			// 
			this.valoreN5.Location = new System.Drawing.Point(380, 277);
			this.valoreN5.Name = "valoreN5";
			this.valoreN5.Size = new System.Drawing.Size(144, 20);
			this.valoreN5.TabIndex = 275;
			this.valoreN5.Tag = "";
			this.valoreN5.Visible = false;
			// 
			// valoreS4
			// 
			this.valoreS4.Location = new System.Drawing.Point(548, 237);
			this.valoreS4.Name = "valoreS4";
			this.valoreS4.Size = new System.Drawing.Size(144, 20);
			this.valoreS4.TabIndex = 274;
			this.valoreS4.Tag = "";
			this.valoreS4.Visible = false;
			// 
			// valoreN4
			// 
			this.valoreN4.Location = new System.Drawing.Point(380, 237);
			this.valoreN4.Name = "valoreN4";
			this.valoreN4.Size = new System.Drawing.Size(144, 20);
			this.valoreN4.TabIndex = 273;
			this.valoreN4.Tag = "";
			this.valoreN4.Visible = false;
			// 
			// valoreN2
			// 
			this.valoreN2.Location = new System.Drawing.Point(380, 157);
			this.valoreN2.Name = "valoreN2";
			this.valoreN2.Size = new System.Drawing.Size(144, 20);
			this.valoreN2.TabIndex = 261;
			this.valoreN2.Tag = "";
			this.valoreN2.Visible = false;
			// 
			// valoreS3
			// 
			this.valoreS3.Location = new System.Drawing.Point(548, 197);
			this.valoreS3.Name = "valoreS3";
			this.valoreS3.Size = new System.Drawing.Size(144, 20);
			this.valoreS3.TabIndex = 270;
			this.valoreS3.Tag = "";
			this.valoreS3.Visible = false;
			// 
			// valoreS2
			// 
			this.valoreS2.Location = new System.Drawing.Point(548, 157);
			this.valoreS2.Name = "valoreS2";
			this.valoreS2.Size = new System.Drawing.Size(144, 20);
			this.valoreS2.TabIndex = 269;
			this.valoreS2.Tag = "";
			this.valoreS2.Visible = false;
			// 
			// valoreN1
			// 
			this.valoreN1.Location = new System.Drawing.Point(380, 117);
			this.valoreN1.Name = "valoreN1";
			this.valoreN1.Size = new System.Drawing.Size(144, 20);
			this.valoreN1.TabIndex = 260;
			this.valoreN1.Tag = "";
			this.valoreN1.Visible = false;
			// 
			// valoreN3
			// 
			this.valoreN3.Location = new System.Drawing.Point(380, 197);
			this.valoreN3.Name = "valoreN3";
			this.valoreN3.Size = new System.Drawing.Size(144, 20);
			this.valoreN3.TabIndex = 262;
			this.valoreN3.Tag = "";
			this.valoreN3.Visible = false;
			// 
			// valoreS1
			// 
			this.valoreS1.Location = new System.Drawing.Point(548, 117);
			this.valoreS1.Name = "valoreS1";
			this.valoreS1.Size = new System.Drawing.Size(144, 20);
			this.valoreS1.TabIndex = 268;
			this.valoreS1.Tag = "";
			this.valoreS1.Visible = false;
			// 
			// labelS5
			// 
			this.labelS5.Location = new System.Drawing.Point(548, 261);
			this.labelS5.Name = "labelS5";
			this.labelS5.Size = new System.Drawing.Size(144, 16);
			this.labelS5.TabIndex = 272;
			this.labelS5.Tag = "";
			this.labelS5.Text = "labelS5";
			this.labelS5.Visible = false;
			// 
			// labelS4
			// 
			this.labelS4.Location = new System.Drawing.Point(548, 221);
			this.labelS4.Name = "labelS4";
			this.labelS4.Size = new System.Drawing.Size(144, 16);
			this.labelS4.TabIndex = 271;
			this.labelS4.Tag = "";
			this.labelS4.Text = "labelS4";
			this.labelS4.Visible = false;
			// 
			// labelS3
			// 
			this.labelS3.Location = new System.Drawing.Point(548, 181);
			this.labelS3.Name = "labelS3";
			this.labelS3.Size = new System.Drawing.Size(144, 16);
			this.labelS3.TabIndex = 267;
			this.labelS3.Tag = "";
			this.labelS3.Text = "labelS3";
			this.labelS3.Visible = false;
			// 
			// labelS2
			// 
			this.labelS2.Location = new System.Drawing.Point(548, 141);
			this.labelS2.Name = "labelS2";
			this.labelS2.Size = new System.Drawing.Size(144, 16);
			this.labelS2.TabIndex = 266;
			this.labelS2.Tag = "";
			this.labelS2.Text = "labelS2";
			this.labelS2.Visible = false;
			// 
			// labelS1
			// 
			this.labelS1.Location = new System.Drawing.Point(548, 101);
			this.labelS1.Name = "labelS1";
			this.labelS1.Size = new System.Drawing.Size(144, 16);
			this.labelS1.TabIndex = 265;
			this.labelS1.Tag = "";
			this.labelS1.Text = "labelS1";
			this.labelS1.Visible = false;
			// 
			// labelN5
			// 
			this.labelN5.Location = new System.Drawing.Point(380, 261);
			this.labelN5.Name = "labelN5";
			this.labelN5.Size = new System.Drawing.Size(144, 16);
			this.labelN5.TabIndex = 264;
			this.labelN5.Tag = "";
			this.labelN5.Text = "labelN5";
			this.labelN5.Visible = false;
			// 
			// labelN4
			// 
			this.labelN4.Location = new System.Drawing.Point(380, 221);
			this.labelN4.Name = "labelN4";
			this.labelN4.Size = new System.Drawing.Size(144, 16);
			this.labelN4.TabIndex = 263;
			this.labelN4.Tag = "";
			this.labelN4.Text = "labelN4";
			this.labelN4.Visible = false;
			// 
			// labelN3
			// 
			this.labelN3.Location = new System.Drawing.Point(380, 181);
			this.labelN3.Name = "labelN3";
			this.labelN3.Size = new System.Drawing.Size(144, 16);
			this.labelN3.TabIndex = 259;
			this.labelN3.Tag = "";
			this.labelN3.Text = "labelN3";
			this.labelN3.Visible = false;
			// 
			// labelN2
			// 
			this.labelN2.Location = new System.Drawing.Point(380, 141);
			this.labelN2.Name = "labelN2";
			this.labelN2.Size = new System.Drawing.Size(144, 16);
			this.labelN2.TabIndex = 258;
			this.labelN2.Tag = "";
			this.labelN2.Text = "labelN2";
			this.labelN2.Visible = false;
			// 
			// labelN1
			// 
			this.labelN1.Location = new System.Drawing.Point(380, 101);
			this.labelN1.Name = "labelN1";
			this.labelN1.Size = new System.Drawing.Size(144, 16);
			this.labelN1.TabIndex = 257;
			this.labelN1.Tag = "";
			this.labelN1.Text = "labelN1";
			this.labelN1.Visible = false;
			// 
			// Frm_pettycashoperationsorted_default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 357);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chkIncompleto);
			this.Controls.Add(this.txtPercentuale);
			this.Controls.Add(this.txtImporto);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.txtSubmovimento);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblPercentuale);
			this.Controls.Add(this.lblImporto);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.valoreV5);
			this.Controls.Add(this.valoreV4);
			this.Controls.Add(this.valoreV3);
			this.Controls.Add(this.valoreV2);
			this.Controls.Add(this.valoreV1);
			this.Controls.Add(this.labelV5);
			this.Controls.Add(this.labelV4);
			this.Controls.Add(this.labelV3);
			this.Controls.Add(this.labelV2);
			this.Controls.Add(this.labelV1);
			this.Controls.Add(this.valoreS5);
			this.Controls.Add(this.valoreN5);
			this.Controls.Add(this.valoreS4);
			this.Controls.Add(this.valoreN4);
			this.Controls.Add(this.valoreN2);
			this.Controls.Add(this.valoreS3);
			this.Controls.Add(this.valoreS2);
			this.Controls.Add(this.valoreN1);
			this.Controls.Add(this.valoreN3);
			this.Controls.Add(this.valoreS1);
			this.Controls.Add(this.labelS5);
			this.Controls.Add(this.labelS4);
			this.Controls.Add(this.labelS3);
			this.Controls.Add(this.labelS2);
			this.Controls.Add(this.labelS1);
			this.Controls.Add(this.labelN5);
			this.Controls.Add(this.labelN4);
			this.Controls.Add(this.labelN3);
			this.Controls.Add(this.labelN2);
			this.Controls.Add(this.labelN1);
			this.Name = "Frm_pettycashoperationsorted_default";
			this.Text = "Frm_pettycashoperationsorted_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void txtPercentuale_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			// ripristina l'importo originale
			if (!txtPercentuale.Modified) return;
			if(!checkpercentuale()) {
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;
				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");                
			}
			else {
				// calcola l'importo in base alla percentuale
				decimal perc = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				importomovimento = perc* importototale /100;
				txtImporto.Text = importomovimento.ToString("c");                
			}
			UpdateCampiChiocciola();
		}

		private bool checkpercentuale() {
			bool OK = false;
			if (txtPercentuale.Text == "") return false;           
			decimal percentmax=0;
			
			if (importototale!=0) percentmax = (importoresiduo + importooriginale)/importototale*100; 
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
				"tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
			try {
				decimal percent = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0) || (percent > percentmax)) {
					OK = (show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
				else {
					OK=true;
				}
  
			}
			catch {                
				show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private void txtImporto_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			if (!txtImporto.Modified) return;              
			if(!checkimporto()) {
				// ripristina l'importo originale
				txtImporto.Text = importomovimento.ToString("c");
			}
			else {
				importomovimento= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;

				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");            
			}
			UpdateCampiChiocciola();
		}   

		private bool checkimporto() {
			bool OK = false;

			if (txtImporto.Text == "") return false;
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
					OK = true;
				}
				else{
					OK = (show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
  
			}
			catch {                
				show("E' necessario inserire un numero","Avviso",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}

		void AnalizzaCheckIgnoraDate(){
			if (chkIgnoraDate.Visible==false) return;
			if (chkIgnoraDate.CheckState== CheckState.Indeterminate) chkIgnoraDate.CheckState= CheckState.Unchecked;
			bool MostraDataInizioFine = !(chkIgnoraDate.CheckState== CheckState.Checked);			
			datalabel.Visible=MostraDataInizioFine;
			DataInizio.Visible=MostraDataInizioFine;
			DataFine.Visible=MostraDataInizioFine;
			labelslash.Visible= MostraDataInizioFine;			
		}

		private void chkIgnoraDate_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (!HasBeenActivated) return;
			AnalizzaCheckIgnoraDate();
		}
	}
}
