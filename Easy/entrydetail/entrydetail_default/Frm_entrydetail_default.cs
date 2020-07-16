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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using ep_functions;

namespace entrydetail_default {
	/// <summary>
	/// Summary description for Frm_entrydetail_default.
	/// </summary>
	public class Frm_entrydetail_default : System.Windows.Forms.Form {
		MetaData Meta;
		bool inChiusura = false;
		public entrydetail_default.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Button btnVariazione;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox gboxClienteFornitore;
		private System.Windows.Forms.TextBox txtClienteFornitore;
		private System.Windows.Forms.GroupBox gboxConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdbDare;
		private System.Windows.Forms.RadioButton rdbAvere;
		private System.Windows.Forms.TextBox txtImporto;
	 
		public System.Windows.Forms.GroupBox gboxclass3;
		public System.Windows.Forms.Button btnCodice3;
		private System.Windows.Forms.TextBox txtDenom3;
		private System.Windows.Forms.TextBox txtCodice3;
		public System.Windows.Forms.GroupBox gboxclass2;
		public System.Windows.Forms.Button btnCodice2;
		private System.Windows.Forms.TextBox txtDenom2;
		private System.Windows.Forms.TextBox txtCodice2;
		public System.Windows.Forms.GroupBox gboxclass1;
		public System.Windows.Forms.Button btnCodice1;
		private System.Windows.Forms.TextBox txtDenom1;
		private System.Windows.Forms.TextBox txtCodice1;
		DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.TextBox txtCausale;
        private GroupBox gboxcompetency;
        private Label label4;
        private Label label2;
        private TextBox txtStopComp;
        private TextBox txtStartComp;
        private Label label6;
        public ComboBox cmbEntryKind;
        private TextBox txtDescrizione;
        private Label label7;
        private GroupBox groupBox4;
        private Label label9;
        private Label label8;
        private TextBox textBox3;
        private TextBox textBox2;
        public TextBox txtUPB;
        private TextBox textBox4;
        private Label label10;
        private Label label11;
        private TextBox textBox1;
        private GroupBox gboxImponibile;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private Label label34;
        private Label label33;
        private GroupBox groupBox5;
        private Label label12;
        private Label label13;
        private Button btnLinkEpAcc;
        private Button btnRemoveEpAcc;
        private TextBox txtNumAccertamento;
        private TextBox txtEsercizioAccertamento;
        private TextBox textBox5;
        private Label label26;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_entrydetail_default() {
			InitializeComponent();
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

        public void MetaData_AfterClear() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            gboxClienteFornitore.Visible = true;
            gboxUPB.Visible = true;
            gboxcompetency.Visible = true;
            groupBox2.Enabled = true;
            VisualizzaControlliImpegnoBudget();
            VisualizzaControlliAccertamentoBudget();
            txtNumero.ReadOnly = false;
        }

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
		    Meta.canSave = false;
            int currAyear = (int)Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", currAyear);
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
			GetData.SetStaticFilter(DS.account,filter);
            string filterEntry = QHS.CmpEq("yentry", currAyear);
            GetData.SetStaticFilter(DS.entrydetail, filterEntry);

			DataAccess.SetTableForReading(DS.sorting1,"sorting");
			DataAccess.SetTableForReading(DS.sorting2,"sorting");
			DataAccess.SetTableForReading(DS.sorting3,"sorting");
			DataTable tExpSetup= Conn.RUN_SELECT("config","*",null,
				filter,null,null,true);
			if ((tExpSetup!=null)&&(tExpSetup.Rows.Count>0)){
				DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
				SetGBoxClass(1,idsorkind1);
				SetGBoxClass(2,idsorkind2);
				SetGBoxClass(3,idsorkind3);
                //int myHeight=Height;
                //if (idsorkind3==DBNull.Value){
                //    myHeight = 482; 
                //    gboxclass3.Visible=false;
                //}
                //if ((idsorkind2 == DBNull.Value) && (idsorkind3==DBNull.Value)){
                //    myHeight = 410; 
                //    gboxclass2.Visible=false;
                //}
                //if ((idsorkind1 == DBNull.Value) && (idsorkind2 == DBNull.Value) && (idsorkind3 == DBNull.Value)) {
                //    myHeight = 360;
                //    gboxclass1.Visible=false;
                //}
                //if (Height!=myHeight) Height=myHeight;
			}

            GetData.CacheTable(DS.entrykind, null, null, true);

		}

		object GetCtrlByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			//if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			//Label L =  (Label) Ctrl.GetValue(this);                        
			//return L;
			return Ctrl.GetValue(this);
		}


		void SetGBoxClass(int num, object sortingkind){
			if (sortingkind==DBNull.Value){
				GroupBox G  = (GroupBox) GetCtrlByName("gboxclass"+num.ToString());
				G.Visible=false;
			}
			else {
				string filter = QHS.CmpEq("idsorkind", sortingkind);
				GetData.SetStaticFilter(DS.Tables["sorting"+num.ToString()],filter);
				GroupBox gboxclass  = (GroupBox) GetCtrlByName("gboxclass"+num.ToString());
				Button btnCodice= (Button) GetCtrlByName("btnCodice"+num.ToString());
				gboxclass.Tag="AutoManage.txtCodice"+num.ToString()+".tree."+filter;
				string title= Conn.DO_READ_VALUE("sortingkind",filter,"description").ToString();
				gboxclass.Text=title;
				btnCodice.Tag="manage.sorting"+num.ToString()+".tree."+filter;
				DS.Tables["sorting"+num.ToString()].ExtendedProperties[MetaData.ExtraParams]=filter;
			}
		}

        void VisualizzaControlliImpegnoBudget()
        {
            if (Meta.IsEmpty)
            {
                btnLinkEpExp.Visible = false;
                btnRemoveEpExp.Visible = false;
                txtEsercizioImpegno.ReadOnly = false;
                txtNumImpegno.ReadOnly = false;
                txtEsercizioAccertamento.ReadOnly = false;
                txtNumAccertamento.ReadOnly = false;
                return;
            }
            DataRow Curr = DS.entrydetail.Rows[0];
            txtEsercizioImpegno.ReadOnly = true;
            txtNumImpegno.ReadOnly = true;
            txtEsercizioAccertamento.ReadOnly = true;
            txtNumAccertamento.ReadOnly = true;

            if (Curr["idepexp"] == DBNull.Value)
            {
                btnLinkEpExp.Visible = true;
                btnRemoveEpExp.Visible = false;
            }
            else
            {
                btnLinkEpExp.Visible = false;
                btnRemoveEpExp.Visible = true;
            }

        }

        void VisualizzaControlliAccertamentoBudget() {
            if (Meta.IsEmpty) {
                btnLinkEpAcc.Visible = false;
                btnRemoveEpAcc.Visible = false;
                txtEsercizioAccertamento.ReadOnly = false;
                txtNumAccertamento.ReadOnly = false;
                return;
            }
            DataRow Curr = DS.entrydetail.Rows[0];

            if (Curr["idepacc"] == DBNull.Value) {
                btnLinkEpAcc.Visible = true;
                btnRemoveEpAcc.Visible = false;
            }
            else {
                btnLinkEpAcc.Visible = false;
                btnRemoveEpAcc.Visible = true;
                // Se la scrittura è collegata a documento non si può cambiare manualmente
                // l'accertamento di budget ma si deve fare dal documento
                if (Curr["idrelated"] != DBNull.Value) {
                btnRemoveEpExp.Enabled = false;
            }
        }

        }
		public void MetaData_AfterFill() {
			EnableDisableGBox();
            VisualizzaControlliImpegnoBudget();
            VisualizzaControlliAccertamentoBudget();
		    txtNumero.ReadOnly = true;
		}
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
            if (T.TableName == "account")
            {
                EnableDisableGBox();
            }
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.DS = new entrydetail_default.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEntryKind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.btnVariazione = new System.Windows.Forms.Button();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gboxClienteFornitore = new System.Windows.Forms.GroupBox();
            this.txtClienteFornitore = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDare = new System.Windows.Forms.RadioButton();
            this.rdbAvere = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gboxcompetency = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStopComp = new System.Windows.Forms.TextBox();
            this.txtStartComp = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLinkEpAcc = new System.Windows.Forms.Button();
            this.btnRemoveEpAcc = new System.Windows.Forms.Button();
            this.txtNumAccertamento = new System.Windows.Forms.TextBox();
            this.txtEsercizioAccertamento = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gboxClienteFornitore.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxcompetency.SuspendLayout();
            this.gboxImponibile.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbEntryKind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.btnVariazione);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Scrittura";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(700, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(74, 20);
            this.textBox5.TabIndex = 38;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "entrydetail.ndetail";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(591, 92);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 13);
            this.label26.TabIndex = 39;
            this.label26.Text = "Numero Dettaglio:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Location = new System.Drawing.Point(8, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(505, 46);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Documento Collegato";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Data:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Descrizione:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(388, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "entry.docdate?entrydetailview.docdate";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "entry.doc?entrydetailview.doc";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(396, 14);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(378, 52);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.Tag = "entry.description?entrydetailview.description";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(325, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(98, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEntryKind
            // 
            this.cmbEntryKind.DataSource = this.DS.entrykind;
            this.cmbEntryKind.DisplayMember = "description";
            this.cmbEntryKind.Location = new System.Drawing.Point(143, 18);
            this.cmbEntryKind.Name = "cmbEntryKind";
            this.cmbEntryKind.Size = new System.Drawing.Size(169, 21);
            this.cmbEntryKind.TabIndex = 3;
            this.cmbEntryKind.Tag = "entry.identrykind?entrydetailview.identrykind";
            this.cmbEntryKind.ValueMember = "identrykind";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(70, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(251, 46);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 10;
            this.txtNumero.Tag = "entry.nentry?entrydetailview.nentry";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(195, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(126, 46);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 12;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "entry.yentry.year?entrydetail.yentry.year";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVariazione
            // 
            this.btnVariazione.Location = new System.Drawing.Point(8, 16);
            this.btnVariazione.Name = "btnVariazione";
            this.btnVariazione.Size = new System.Drawing.Size(72, 23);
            this.btnVariazione.TabIndex = 1;
            this.btnVariazione.Tag = "choose.entry.default";
            this.btnVariazione.Text = "Scrittura";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(792, 46);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 7;
            this.txtDataContabile.TabStop = false;
            this.txtDataContabile.Tag = "entry.adate";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(789, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gboxClienteFornitore
            // 
            this.gboxClienteFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClienteFornitore.Controls.Add(this.txtClienteFornitore);
            this.gboxClienteFornitore.Location = new System.Drawing.Point(475, 140);
            this.gboxClienteFornitore.Name = "gboxClienteFornitore";
            this.gboxClienteFornitore.Size = new System.Drawing.Size(419, 48);
            this.gboxClienteFornitore.TabIndex = 3;
            this.gboxClienteFornitore.TabStop = false;
            this.gboxClienteFornitore.Tag = "AutoChoose.txtClienteFornitore.default.(active=\'S\')";
            this.gboxClienteFornitore.Text = "Cliente/Fornitore";
            // 
            // txtClienteFornitore
            // 
            this.txtClienteFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClienteFornitore.Location = new System.Drawing.Point(8, 16);
            this.txtClienteFornitore.Name = "txtClienteFornitore";
            this.txtClienteFornitore.Size = new System.Drawing.Size(403, 20);
            this.txtClienteFornitore.TabIndex = 0;
            this.txtClienteFornitore.Tag = "registry.title?entrydetailview.registry";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button1);
            this.gboxConto.Location = new System.Drawing.Point(8, 298);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(370, 108);
            this.gboxConto.TabIndex = 7;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(139, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(223, 52);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(9, 76);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(353, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "account.codeacc?entrydetailview.codeacc";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.account.tree";
            this.button1.Text = "Conto";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(475, 189);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(419, 108);
            this.gboxUPB.TabIndex = 6;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 76);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(407, 20);
            this.txtUPB.TabIndex = 7;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(109, 16);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(258, 54);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(6, 50);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(97, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "U.P.B.";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDare);
            this.groupBox2.Controls.Add(this.rdbAvere);
            this.groupBox2.Controls.Add(this.txtImporto);
            this.groupBox2.Location = new System.Drawing.Point(8, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 81);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "entrydetail.amount.valuesigned";
            this.groupBox2.Text = "Importo";
            // 
            // rdbDare
            // 
            this.rdbDare.Location = new System.Drawing.Point(163, 18);
            this.rdbDare.Name = "rdbDare";
            this.rdbDare.Size = new System.Drawing.Size(49, 16);
            this.rdbDare.TabIndex = 2;
            this.rdbDare.Tag = "-";
            this.rdbDare.Text = "Dare";
            // 
            // rdbAvere
            // 
            this.rdbAvere.Location = new System.Drawing.Point(163, 48);
            this.rdbAvere.Name = "rdbAvere";
            this.rdbAvere.Size = new System.Drawing.Size(80, 16);
            this.rdbAvere.TabIndex = 3;
            this.rdbAvere.Tag = "+";
            this.rdbAvere.Text = "Avere";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(11, 35);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "entrydetail.amount";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(384, 444);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(520, 64);
            this.gboxclass3.TabIndex = 11;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 16);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.TabStop = false;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(295, 8);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(217, 52);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 40);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(278, 20);
            this.txtCodice3.TabIndex = 2;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(384, 374);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(520, 64);
            this.gboxclass2.TabIndex = 10;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 16);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.TabStop = false;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(295, 8);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(217, 52);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(8, 40);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(281, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(384, 298);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(521, 64);
            this.gboxclass1.TabIndex = 8;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 16);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.TabStop = false;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(295, 8);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(218, 52);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 40);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(281, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCausale);
            this.groupBox3.Controls.Add(this.txtCodiceCausale);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(8, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 109);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtCodiceCausale.tree";
            // 
            // txtCausale
            // 
            this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCausale.Location = new System.Drawing.Point(129, 12);
            this.txtCausale.Multiline = true;
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(232, 60);
            this.txtCausale.TabIndex = 2;
            this.txtCausale.TabStop = false;
            this.txtCausale.Tag = "accmotive.title";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(11, 78);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(350, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotive.codemotive?entrydetailview.codemotive";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.accmotive.tree";
            this.button2.Text = "Causale";
            // 
            // gboxcompetency
            // 
            this.gboxcompetency.Controls.Add(this.label4);
            this.gboxcompetency.Controls.Add(this.label2);
            this.gboxcompetency.Controls.Add(this.txtStopComp);
            this.gboxcompetency.Controls.Add(this.txtStartComp);
            this.gboxcompetency.Location = new System.Drawing.Point(320, 189);
            this.gboxcompetency.Name = "gboxcompetency";
            this.gboxcompetency.Size = new System.Drawing.Size(149, 80);
            this.gboxcompetency.TabIndex = 5;
            this.gboxcompetency.TabStop = false;
            this.gboxcompetency.Text = "Periodo di competenza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fine";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStopComp
            // 
            this.txtStopComp.Location = new System.Drawing.Point(44, 46);
            this.txtStopComp.Name = "txtStopComp";
            this.txtStopComp.Size = new System.Drawing.Size(85, 20);
            this.txtStopComp.TabIndex = 1;
            this.txtStopComp.Tag = "entrydetail.competencystop.d";
            // 
            // txtStartComp
            // 
            this.txtStartComp.Location = new System.Drawing.Point(44, 16);
            this.txtStartComp.Name = "txtStartComp";
            this.txtStartComp.Size = new System.Drawing.Size(85, 20);
            this.txtStartComp.TabIndex = 0;
            this.txtStartComp.Tag = "entrydetail.competencystart.d";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(98, 136);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(371, 52);
            this.textBox4.TabIndex = 2;
            this.textBox4.Tag = "entrydetail.description?entrydetailview.detaildescription";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(14, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Descrizione:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Codice importazione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 269);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "entrydetail.importcode";
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.label34);
            this.gboxImponibile.Controls.Add(this.label33);
            this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
            this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
            this.gboxImponibile.Controls.Add(this.txtNumImpegno);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImponibile.Location = new System.Drawing.Point(10, 522);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(511, 42);
            this.gboxImponibile.TabIndex = 12;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Impegno di Budget";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(124, 18);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 0;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpExp.Location = new System.Drawing.Point(254, 13);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(106, 23);
            this.btnLinkEpExp.TabIndex = 4;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpExp.Location = new System.Drawing.Point(374, 13);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(119, 23);
            this.btnRemoveEpExp.TabIndex = 5;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(174, 16);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.Tag = "epexp.nepexp?entrydetailview.nepexp";
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(61, 15);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 1;
            this.txtEsercizioImpegno.Tag = "epexp.yepexp.year?entrydetailview.yepexp.year";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.btnLinkEpAcc);
            this.groupBox5.Controls.Add(this.btnRemoveEpAcc);
            this.groupBox5.Controls.Add(this.txtNumAccertamento);
            this.groupBox5.Controls.Add(this.txtEsercizioAccertamento);
            this.groupBox5.Location = new System.Drawing.Point(8, 570);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(513, 42);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Accertamento di Budget";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(126, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Numero";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Esercizio";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpAcc
            // 
            this.btnLinkEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpAcc.Location = new System.Drawing.Point(251, 10);
            this.btnLinkEpAcc.Name = "btnLinkEpAcc";
            this.btnLinkEpAcc.Size = new System.Drawing.Size(113, 23);
            this.btnLinkEpAcc.TabIndex = 4;
            this.btnLinkEpAcc.TabStop = false;
            this.btnLinkEpAcc.Text = "Collega";
            this.btnLinkEpAcc.Click += new System.EventHandler(this.btnLinkEpAcc_Click);
            // 
            // btnRemoveEpAcc
            // 
            this.btnRemoveEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpAcc.Location = new System.Drawing.Point(370, 10);
            this.btnRemoveEpAcc.Name = "btnRemoveEpAcc";
            this.btnRemoveEpAcc.Size = new System.Drawing.Size(125, 23);
            this.btnRemoveEpAcc.TabIndex = 5;
            this.btnRemoveEpAcc.TabStop = false;
            this.btnRemoveEpAcc.Text = "Scollega";
            this.btnRemoveEpAcc.Click += new System.EventHandler(this.btnUnLinkEpAcc_Click);
            // 
            // txtNumAccertamento
            // 
            this.txtNumAccertamento.Location = new System.Drawing.Point(176, 14);
            this.txtNumAccertamento.Name = "txtNumAccertamento";
            this.txtNumAccertamento.Size = new System.Drawing.Size(64, 20);
            this.txtNumAccertamento.TabIndex = 3;
            this.txtNumAccertamento.Tag = "epacc.nepacc?entrydetailview.nepacc";
            // 
            // txtEsercizioAccertamento
            // 
            this.txtEsercizioAccertamento.Location = new System.Drawing.Point(60, 16);
            this.txtEsercizioAccertamento.Name = "txtEsercizioAccertamento";
            this.txtEsercizioAccertamento.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioAccertamento.TabIndex = 1;
            this.txtEsercizioAccertamento.Tag = "epacc.yepacc.year?entrydetailview.yepacc.year";
            // 
            // Frm_entrydetail_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(906, 636);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gboxImponibile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gboxcompetency);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gboxclass3);
            this.Controls.Add(this.gboxclass2);
            this.Controls.Add(this.gboxclass1);
            this.Controls.Add(this.gboxClienteFornitore);
            this.Controls.Add(this.gboxConto);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_entrydetail_default";
            this.Text = "Frm_entrydetail_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gboxClienteFornitore.ResumeLayout(false);
            this.gboxClienteFornitore.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxcompetency.ResumeLayout(false);
            this.gboxcompetency.PerformLayout();
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void svuotaDatiConto() {
			txtCodiceConto.Text = "";
			txtDenominazioneConto.Text = "";
			DS.account.Clear();
		}

		private void EnableDisableGBox() {
            groupBox2.Enabled = false;
			if (DS.entrydetail.Rows.Count == 0) {
				gboxClienteFornitore.Visible = false;
				gboxUPB.Visible = false;
                gboxcompetency.Visible = false;
				return;
			}

			DataRow Curr = DS.entrydetail.Rows[0];
			if (Curr["idacc"] == DBNull.Value) {
				gboxClienteFornitore.Visible = false;
				gboxUPB.Visible = false;
				Curr["idupb"] = DBNull.Value;
                Meta.SetAutoField(DBNull.Value, txtUPB);
				Curr["idreg"] = DBNull.Value;
				DS.registry.Clear();
				return;
			}
			
			string filtro = QHC.CmpEq("idacc", Curr["idacc"]);
			DataRow [] rConto = DS.account.Select(filtro);
			if (rConto.Length == 0) {
				gboxClienteFornitore.Visible = false;
				gboxUPB.Visible = false;
                gboxcompetency.Visible = false;
				return;
			}
			DataRow rAcc = rConto[0];
			if ((rAcc["flagregistry"] == DBNull.Value)
				|| (rAcc["flagregistry"].ToString().ToUpper() == "N")) {
				gboxClienteFornitore.Visible = false;
				Curr["idreg"] = DBNull.Value;
				DS.registry.Clear();
			}
			else {
				gboxClienteFornitore.Visible = true;
			}

			if ((rAcc["flagupb"] == DBNull.Value)
				|| (rAcc["flagupb"].ToString().ToUpper() == "N")){
				gboxUPB.Visible = false;
				Curr["idupb"] = DBNull.Value;
                Meta.SetAutoField(DBNull.Value, txtUPB);
            }
			else {
				gboxUPB.Visible = true;
			}

            if ((rAcc["flagcompetency"] == DBNull.Value)
                || (rAcc["flagcompetency"].ToString().ToUpper() == "N")) {
                gboxcompetency.Visible = false;
                Curr["competencystart"] = DBNull.Value;
                Curr["competencystop"] = DBNull.Value;
            }
            else {
                gboxcompetency.Visible = true;
                if ((Curr["idrelated"] != DBNull.Value) &&
                        (
                            (Curr["idrelated"].ToString().Substring(0, 3) == "inv") ||
                            (Curr["idrelated"].ToString().Substring(0, 3) == "man") ||
                            (Curr["idrelated"].ToString().Substring(0, 5) == "estim")
                        ))
                       { 
                    txtStartComp.Enabled = false;
                    txtStopComp.Enabled = false;
                }
                else {
                    txtStartComp.Enabled = true;
                    txtStopComp.Enabled = true;
                }
            }

		}

        private void textinizio_Leave(object sender, EventArgs e)
        {
            if (inChiusura) return;
            //ParseDate(textinizio);
        }

        private void textfine_Leave(object sender, EventArgs e)
        {
            if (inChiusura) return;
            //ParseDate(textfine);
        }

        private void btnLinkEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.entrydetail.Rows[0];
            MetaData.GetFormData(this, true);
                EP_functions EP = new EP_functions(Meta.Dispatcher);

            // Se la scrittura è collegata a documento non si può cambiare manualmente
            // l'impegno di budget ma si deve fare dal documento
            if (Curr["idrelated"] != DBNull.Value) return; 
          
            // Verifico che la scrittura sia imputata a un costo di costo oppure a un'immobilizzazione, 
            // solo allora potrò associare
            // un impegno di budget tra quelli con disponibile > 0 e sullo stesso conto
            //bool isCosto = EP.isCosto(Curr["idacc"]);
            

            int nphase = 2; // Impegno
            string Filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase),
                QHS.CmpEq("idacc", Curr["idacc"]));

            if (Curr["idupb"]!=DBNull.Value) Filter = QHS.AppAnd(Filter,QHS.CmpEq("idupb", Curr["idupb"]));
       
            ////  Filter = QHS.AppAnd(Filter, EP.GetFilterForEpexp(Meta, Curr["idrelated"].ToString()));
            //if (isCosto) {
            //    String fAmount = QHS.CmpGt("curramount - totalcost", 0); // condizione sul disponibile
            //    Filter = QHS.AppAnd(Filter, fAmount);
            //}

            string VistaScelta = "epexpview";

            MetaData Mepexp = Meta.Dispatcher.Get(VistaScelta);
            Mepexp.FilterLocked = true;
            Mepexp.DS = DS;
            DataRow MyDR = Mepexp.SelectOne("default", Filter, null, null);

            if (MyDR != null)
            {
                Curr["idepexp"] = MyDR["idepexp"];
                Meta.FreshForm();
            }

        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e)
        {

            DataRow Curr = DS.entrydetail.Rows[0];
            if (Curr["idrelated"] != DBNull.Value) return; 

            Curr["idepexp"] = DBNull.Value;
            DS.epexp.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            Meta.FreshForm();
        }

        private void btnLinkEpAcc_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.entrydetail.Rows[0];
            if (curr["idrelated"] != DBNull.Value) return; 

            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);

            // Se la scrittura è collegata a documento non si può cambiare manualmente
            // l'iaccertamento di budget ma si deve fare dal documento
            //if (curr["idrelated"] != DBNull.Value) return;

            // Verifico che la scrittura sia imputata a un costo di ricavo , 
            // solo allora potrò associare
            // un accertamento di budget tra quelli con disponibile > 0 e sullo stesso conto
            //bool isSelectableAccount = ep.GetAccountSelectableForEpAcc(curr["idacc"]);
            //if (!isSelectableAccount) return;

            int nphase = 2; // Impegno
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

            if (curr["idupb"] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", curr["idupb"]));
            if (curr["idreg"] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", curr["idreg"]));
            //String fAmount = QHS.CmpGt("curramount - totalrevenue", 0); // condizione sul disponibile
            //filter = QHS.AppAnd(filter, fAmount);
            if (ep.isCosto(curr["idacc"])) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", curr["idacc"]));
            }
            string VistaScelta = "epaccview";

            MetaData mepacc = Meta.Dispatcher.Get(VistaScelta);
            mepacc.FilterLocked = true;
            mepacc.DS = DS;
            DataRow myDr = mepacc.SelectOne("default", filter, null, null);

            if (myDr != null) {
            curr["idepacc"] = myDr["idepacc"];
            Meta.FreshForm();
            }
        }

        private void btnUnLinkEpAcc_Click(object sender, EventArgs e) {
            DataRow Curr = DS.entrydetail.Rows[0];
            if (Curr["idrelated"] != DBNull.Value) return; 
            Curr["idepacc"] = DBNull.Value;
            DS.epacc.Clear();
            txtEsercizioAccertamento.Text = "";
            txtNumAccertamento.Text = "";
            Meta.FreshForm();
        }
	}
}