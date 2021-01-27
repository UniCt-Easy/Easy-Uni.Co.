
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using ep_functions;

namespace entrydetail_single {
	/// <summary>
	/// Summary description for FrmEntryDetail_single.
	/// </summary>
	public class FrmEntryDetail_single : System.Windows.Forms.Form {
		MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
	
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtClienteFornitore;
		public entrydetail_single.vistaForm DS;
		private System.Windows.Forms.GroupBox gboxClienteFornitore;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.RadioButton rdbDare;
		private System.Windows.Forms.RadioButton rdbAvere;
		private System.Windows.Forms.GroupBox gboxConto;
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
		private System.Windows.Forms.GroupBox grbAccmotive;
		private System.Windows.Forms.Button btnAccmotive;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.TextBox txtDenominazioneCausale;
		private System.Windows.Forms.TextBox txtCausale;
        private GroupBox gboxcompetency;
        private Label Fine;
        private Label Inizio;
        private TextBox txtStopComp;
        private TextBox txtStartComp;
        public TextBox txtUPB;
        private TextBox textBox4;
        private Label label10;
        private Label label11;
        private TextBox textBox5;
        private GroupBox gboxImponibile;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private Label label34;
        private Label label33;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Button btnLinkEpAcc;
        private Button btnRemoveEpAcc;
        private TextBox txtNumAccertamento;
        private TextBox txtEsercizioAccertamento;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmEntryDetail_single() {
			InitializeComponent();
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

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.account,filter);

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
				//	myHeight=390;
				//	gboxclass3.Visible=false;
				//}
    //            if ((idsorkind2 == DBNull.Value) && (idsorkind3 == DBNull.Value)) {
    //                myHeight=330;
				//	gboxclass2.Visible=false;
				//}
    //            if ((idsorkind1 == DBNull.Value) && (idsorkind2 == DBNull.Value) && (idsorkind3 == DBNull.Value)) {
				//	myHeight=310;
				//	gboxclass1.Visible=false;
				//}
				//if (Height!=myHeight) Height=myHeight;
                 
			}	
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
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.entrydetail.Rows[0];

            if (Curr["idepexp"] == DBNull.Value)
            {
                btnLinkEpExp.Visible = true;
                btnRemoveEpExp.Visible = false;
            }
            else
            {
                btnLinkEpExp.Visible = false;
                btnRemoveEpExp.Visible = true;
                // Se la scrittura è collegata a documento non si può cambiare manualmente
                // l'impegno di budget ma si deve fare dal documento
                if (Curr["idrelated"] != DBNull.Value) {
                    btnRemoveEpExp.Enabled = false;
                }
            }

        }

        void VisualizzaControlliAccertamentoBudget() {
            if (Meta.IsEmpty) return;
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
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			if (T.TableName == "account") {
				if (Meta.DrawStateIsDone) {
					EnableDisableGBox();
			}
			}
		}

		private void EnableDisableGBox() {
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
				if (Curr["idreg"]!=DBNull.Value) Curr["idreg"] = DBNull.Value;
				DS.registry.Clear();
			}
			else {
				gboxClienteFornitore.Visible = true;
			}
			if ((rAcc["flagupb"] == DBNull.Value)
				|| (rAcc["flagupb"].ToString().ToUpper() == "N")){
				gboxUPB.Visible = false;
                if (Curr["idupb"] != DBNull.Value)  Curr["idupb"] = DBNull.Value;
                Meta.SetAutoField(DBNull.Value, txtUPB);
			}
			else {
				gboxUPB.Visible = true;
			}
            if ((rAcc["flagcompetency"] == DBNull.Value)
                || (rAcc["flagcompetency"].ToString().ToUpper() == "N"))
            {
                gboxcompetency.Visible = false;
                if (Curr["competencystart"] != DBNull.Value) Curr["competencystart"] = DBNull.Value;
                if (Curr["competencystop"] != DBNull.Value)  Curr["competencystop"] = DBNull.Value;
            }
            else
            {
                gboxcompetency.Visible = true;
                if ((Curr["idrelated"] != DBNull.Value) &&
                       (
                           (Curr["idrelated"].ToString().Substring(0, 3) == "inv") ||
                           (Curr["idrelated"].ToString().Substring(0, 3) == "man") ||
                           (Curr["idrelated"].ToString().Substring(0, 5) == "estim")
                       )) {
                    txtStartComp.Enabled = false;
                    txtStopComp.Enabled = false;
                }
                else {
                    txtStartComp.Enabled = true;
                    txtStopComp.Enabled = true;
                }
            }

            

        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDare = new System.Windows.Forms.RadioButton();
            this.rdbAvere = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gboxClienteFornitore = new System.Windows.Forms.GroupBox();
            this.txtClienteFornitore = new System.Windows.Forms.TextBox();
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
            this.grbAccmotive = new System.Windows.Forms.GroupBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.btnAccmotive = new System.Windows.Forms.Button();
            this.txtDenominazioneCausale = new System.Windows.Forms.TextBox();
            this.gboxcompetency = new System.Windows.Forms.GroupBox();
            this.Fine = new System.Windows.Forms.Label();
            this.Inizio = new System.Windows.Forms.Label();
            this.txtStopComp = new System.Windows.Forms.TextBox();
            this.txtStartComp = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            this.DS = new entrydetail_single.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLinkEpAcc = new System.Windows.Forms.Button();
            this.btnRemoveEpAcc = new System.Windows.Forms.Button();
            this.txtNumAccertamento = new System.Windows.Forms.TextBox();
            this.txtEsercizioAccertamento = new System.Windows.Forms.TextBox();
            this.gboxUPB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.gboxClienteFornitore.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.grbAccmotive.SuspendLayout();
            this.gboxcompetency.SuspendLayout();
            this.gboxImponibile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(465, 4);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(386, 113);
            this.gboxUPB.TabIndex = 2;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 87);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(365, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 32);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(235, 49);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(6, 61);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(120, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "entrydetail.amount.valuesigned";
            this.groupBox2.Text = "Importo";
            // 
            // rdbDare
            // 
            this.rdbDare.Location = new System.Drawing.Point(168, 24);
            this.rdbDare.Name = "rdbDare";
            this.rdbDare.Size = new System.Drawing.Size(61, 16);
            this.rdbDare.TabIndex = 9;
            this.rdbDare.Tag = "-";
            this.rdbDare.Text = "Dare";
            // 
            // rdbAvere
            // 
            this.rdbAvere.Checked = true;
            this.rdbAvere.Location = new System.Drawing.Point(168, 48);
            this.rdbAvere.Name = "rdbAvere";
            this.rdbAvere.Size = new System.Drawing.Size(61, 16);
            this.rdbAvere.TabIndex = 8;
            this.rdbAvere.TabStop = true;
            this.rdbAvere.Tag = "+";
            this.rdbAvere.Text = "Avere";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(16, 32);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 7;
            this.txtImporto.Tag = "entrydetail.amount";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(756, 549);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(94, 25);
            this.btnAnnulla.TabIndex = 13;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(656, 548);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 25);
            this.btnOK.TabIndex = 12;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button1);
            this.gboxConto.Location = new System.Drawing.Point(12, 86);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(441, 113);
            this.gboxConto.TabIndex = 3;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(126, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(305, 64);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 87);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(423, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "account.codeacc?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.account.tree";
            this.button1.Text = "Conto";
            // 
            // gboxClienteFornitore
            // 
            this.gboxClienteFornitore.Controls.Add(this.txtClienteFornitore);
            this.gboxClienteFornitore.Location = new System.Drawing.Point(12, 280);
            this.gboxClienteFornitore.Name = "gboxClienteFornitore";
            this.gboxClienteFornitore.Size = new System.Drawing.Size(441, 48);
            this.gboxClienteFornitore.TabIndex = 6;
            this.gboxClienteFornitore.TabStop = false;
            this.gboxClienteFornitore.Tag = "AutoChoose.txtClienteFornitore.default.(active=\'S\') ";
            this.gboxClienteFornitore.Text = "Cliente/Fornitore";
            // 
            // txtClienteFornitore
            // 
            this.txtClienteFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClienteFornitore.Location = new System.Drawing.Point(8, 16);
            this.txtClienteFornitore.Name = "txtClienteFornitore";
            this.txtClienteFornitore.Size = new System.Drawing.Size(425, 20);
            this.txtClienteFornitore.TabIndex = 0;
            this.txtClienteFornitore.Tag = "registry.title?entrydetailview.registry";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(465, 363);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(386, 108);
            this.gboxclass3.TabIndex = 11;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice3.Location = new System.Drawing.Point(6, 56);
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
            this.txtDenom3.Location = new System.Drawing.Point(128, 24);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(252, 56);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice3.Location = new System.Drawing.Point(6, 82);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(374, 20);
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
            this.gboxclass2.Location = new System.Drawing.Point(465, 237);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(386, 120);
            this.gboxclass2.TabIndex = 10;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice2.Location = new System.Drawing.Point(10, 68);
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
            this.txtDenom2.Location = new System.Drawing.Point(128, 24);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(250, 67);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 94);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(372, 20);
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
            this.gboxclass1.Location = new System.Drawing.Point(465, 125);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(386, 110);
            this.gboxclass1.TabIndex = 9;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice1.Location = new System.Drawing.Point(6, 58);
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
            this.txtDenom1.Location = new System.Drawing.Point(128, 24);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(250, 57);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice1.Location = new System.Drawing.Point(6, 84);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(372, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // grbAccmotive
            // 
            this.grbAccmotive.Controls.Add(this.txtCausale);
            this.grbAccmotive.Controls.Add(this.txtCodiceCausale);
            this.grbAccmotive.Controls.Add(this.btnAccmotive);
            this.grbAccmotive.Location = new System.Drawing.Point(14, 362);
            this.grbAccmotive.Name = "grbAccmotive";
            this.grbAccmotive.Size = new System.Drawing.Size(439, 110);
            this.grbAccmotive.TabIndex = 8;
            this.grbAccmotive.TabStop = false;
            this.grbAccmotive.Tag = "AutoManage.txtCodiceCausale.tree";
            // 
            // txtCausale
            // 
            this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCausale.Location = new System.Drawing.Point(120, 9);
            this.txtCausale.Multiline = true;
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(311, 69);
            this.txtCausale.TabIndex = 2;
            this.txtCausale.TabStop = false;
            this.txtCausale.Tag = "accmotive.title?x";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceCausale.Location = new System.Drawing.Point(8, 84);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(425, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotive.codemotive?x";
            // 
            // btnAccmotive
            // 
            this.btnAccmotive.Location = new System.Drawing.Point(10, 54);
            this.btnAccmotive.Name = "btnAccmotive";
            this.btnAccmotive.Size = new System.Drawing.Size(104, 24);
            this.btnAccmotive.TabIndex = 0;
            this.btnAccmotive.TabStop = false;
            this.btnAccmotive.Tag = "manage.accmotive.tree";
            this.btnAccmotive.Text = "Causale";
            // 
            // txtDenominazioneCausale
            // 
            this.txtDenominazioneCausale.Location = new System.Drawing.Point(128, 10);
            this.txtDenominazioneCausale.Name = "txtDenominazioneCausale";
            this.txtDenominazioneCausale.Size = new System.Drawing.Size(100, 20);
            this.txtDenominazioneCausale.TabIndex = 0;
            // 
            // gboxcompetency
            // 
            this.gboxcompetency.Controls.Add(this.Fine);
            this.gboxcompetency.Controls.Add(this.Inizio);
            this.gboxcompetency.Controls.Add(this.txtStopComp);
            this.gboxcompetency.Controls.Add(this.txtStartComp);
            this.gboxcompetency.Location = new System.Drawing.Point(284, 206);
            this.gboxcompetency.Name = "gboxcompetency";
            this.gboxcompetency.Size = new System.Drawing.Size(169, 70);
            this.gboxcompetency.TabIndex = 5;
            this.gboxcompetency.TabStop = false;
            this.gboxcompetency.Text = "Periodo di competenza";
            // 
            // Fine
            // 
            this.Fine.AutoSize = true;
            this.Fine.Location = new System.Drawing.Point(6, 48);
            this.Fine.Name = "Fine";
            this.Fine.Size = new System.Drawing.Size(27, 13);
            this.Fine.TabIndex = 3;
            this.Fine.Text = "Fine";
            // 
            // Inizio
            // 
            this.Inizio.AutoSize = true;
            this.Inizio.Location = new System.Drawing.Point(6, 16);
            this.Inizio.Name = "Inizio";
            this.Inizio.Size = new System.Drawing.Size(31, 13);
            this.Inizio.TabIndex = 2;
            this.Inizio.Text = "Inizio";
            // 
            // txtStopComp
            // 
            this.txtStopComp.Location = new System.Drawing.Point(43, 44);
            this.txtStopComp.Name = "txtStopComp";
            this.txtStopComp.Size = new System.Drawing.Size(116, 20);
            this.txtStopComp.TabIndex = 1;
            this.txtStopComp.Tag = "entrydetail.competencystop.d";
            // 
            // txtStartComp
            // 
            this.txtStartComp.Location = new System.Drawing.Point(43, 13);
            this.txtStartComp.Name = "txtStartComp";
            this.txtStartComp.Size = new System.Drawing.Size(116, 20);
            this.txtStartComp.TabIndex = 0;
            this.txtStartComp.Tag = "entrydetail.competencystart.d";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 28);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(378, 52);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "entrydetail.description";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Descrizione";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Codice importazione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(120, 331);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(163, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.Tag = "entrydetail.importcode";
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.label34);
            this.gboxImponibile.Controls.Add(this.label33);
            this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
            this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
            this.gboxImponibile.Controls.Add(this.txtNumImpegno);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImponibile.Location = new System.Drawing.Point(14, 478);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(498, 42);
            this.gboxImponibile.TabIndex = 44;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Impegno di Budget";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(113, 19);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpExp.Location = new System.Drawing.Point(239, 10);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(110, 23);
            this.btnLinkEpExp.TabIndex = 5;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpExp.Location = new System.Drawing.Point(355, 10);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(137, 23);
            this.btnRemoveEpExp.TabIndex = 4;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(163, 15);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.ReadOnly = true;
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.TabStop = false;
            this.txtNumImpegno.Tag = "epexp.nepexp";
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(60, 16);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.ReadOnly = true;
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 2;
            this.txtEsercizioImpegno.TabStop = false;
            this.txtEsercizioImpegno.Tag = "epexp.yepexp";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLinkEpAcc);
            this.groupBox1.Controls.Add(this.btnRemoveEpAcc);
            this.groupBox1.Controls.Add(this.txtNumAccertamento);
            this.groupBox1.Controls.Add(this.txtEsercizioAccertamento);
            this.groupBox1.Location = new System.Drawing.Point(12, 526);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 42);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Accertamento di Budget";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Esercizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpAcc
            // 
            this.btnLinkEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpAcc.Location = new System.Drawing.Point(239, 10);
            this.btnLinkEpAcc.Name = "btnLinkEpAcc";
            this.btnLinkEpAcc.Size = new System.Drawing.Size(110, 23);
            this.btnLinkEpAcc.TabIndex = 5;
            this.btnLinkEpAcc.TabStop = false;
            this.btnLinkEpAcc.Text = "Collega";
            this.btnLinkEpAcc.Click += new System.EventHandler(this.btnLinkEpAcc_Click);
            // 
            // btnRemoveEpAcc
            // 
            this.btnRemoveEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpAcc.Location = new System.Drawing.Point(355, 10);
            this.btnRemoveEpAcc.Name = "btnRemoveEpAcc";
            this.btnRemoveEpAcc.Size = new System.Drawing.Size(137, 23);
            this.btnRemoveEpAcc.TabIndex = 4;
            this.btnRemoveEpAcc.TabStop = false;
            this.btnRemoveEpAcc.Text = "Scollega";
            this.btnRemoveEpAcc.Click += new System.EventHandler(this.btnUnLinkEpAcc_Click);
            // 
            // txtNumAccertamento
            // 
            this.txtNumAccertamento.Location = new System.Drawing.Point(163, 15);
            this.txtNumAccertamento.Name = "txtNumAccertamento";
            this.txtNumAccertamento.ReadOnly = true;
            this.txtNumAccertamento.Size = new System.Drawing.Size(64, 20);
            this.txtNumAccertamento.TabIndex = 3;
            this.txtNumAccertamento.TabStop = false;
            this.txtNumAccertamento.Tag = "epacc.nepacc";
            // 
            // txtEsercizioAccertamento
            // 
            this.txtEsercizioAccertamento.Location = new System.Drawing.Point(60, 16);
            this.txtEsercizioAccertamento.Name = "txtEsercizioAccertamento";
            this.txtEsercizioAccertamento.ReadOnly = true;
            this.txtEsercizioAccertamento.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioAccertamento.TabIndex = 2;
            this.txtEsercizioAccertamento.TabStop = false;
            this.txtEsercizioAccertamento.Tag = "epacc.yepacc";
            // 
            // FrmEntryDetail_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(858, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxImponibile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gboxcompetency);
            this.Controls.Add(this.grbAccmotive);
            this.Controls.Add(this.gboxclass3);
            this.Controls.Add(this.gboxclass2);
            this.Controls.Add(this.gboxclass1);
            this.Controls.Add(this.gboxClienteFornitore);
            this.Controls.Add(this.gboxConto);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "FrmEntryDetail_single";
            this.Text = "FrmEntryDetail_single";
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.gboxClienteFornitore.ResumeLayout(false);
            this.gboxClienteFornitore.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.grbAccmotive.ResumeLayout(false);
            this.grbAccmotive.PerformLayout();
            this.gboxcompetency.ResumeLayout(false);
            this.gboxcompetency.PerformLayout();
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void svuotaDatiConto() {
			txtCodiceConto.Text = "";
			txtDenominazioneConto.Text = "";
			DS.account.Clear();
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

        
        private void btnLinkEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.entrydetail.Rows[0];
            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);

            // Se la scrittura è collegata a documento non si può cambiare manualmente
            // l'impegno di budget ma si deve fare dal documento
            //if (curr["idrelated"] != DBNull.Value) return;

            // Verifico che la scrittura sia imputata a un costo di costo oppure a un'immobilizzazione, 
            // solo allora potrò associare
            // un impegno di budget tra quelli con disponibile > 0 e sullo stesso conto
            //bool isSelectableAccount = ep.GetAccountSelectableForEpExp(curr["idacc"]);
            //if (!isSelectableAccount) return;

            int nphase = 2; // Impegno
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

            if (curr["idupb"]!=DBNull.Value) filter = QHS.AppAnd(filter,QHS.CmpEq("idupb", curr["idupb"]));
            if (curr["idreg"] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", curr["idreg"]));
            //  Filter = QHS.AppAnd(Filter, EP.GetFilterForEpexp(Meta, Curr["idrelated"].ToString()));
            //if (isSelectableAccount) {
            //    filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", curr["idacc"]));
            //    filter = QHS.AppAnd(filter, QHS.CmpGt("curramount - totalcost", 0));  // condizione sul disponibile
            //}

            if (ep.isCosto(curr["idacc"])) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", curr["idacc"]));
            }

            string VistaScelta = "epexpview";

            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow myDr = mepexp.SelectOne("default", filter, null, null);

            if (myDr != null)
            {
                curr["idepexp"] = myDr["idepexp"];
                Meta.FreshForm();
            }

        }

        private void btnLinkEpAcc_Click(object sender, EventArgs e) {
        if (Meta.IsEmpty) return;
        DataRow curr = DS.entrydetail.Rows[0];
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

            if (ep.isRicavo(curr["idacc"])) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", curr["idacc"]));
            }

        if (curr["idupb"] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", curr["idupb"]));
            if (curr["idreg"] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", curr["idreg"]));
            //String fAmount = QHS.CmpGt("curramount - totalrevenue", 0); // condizione sul disponibile
            //filter = QHS.AppAnd(filter, fAmount);

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
