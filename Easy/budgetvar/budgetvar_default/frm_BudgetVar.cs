
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace budgetvar_default//VariazioneBilancio//
{
	/// <summary>
	/// Summary description for frmVariazioneBilancio.
	/// Revised by Nino on 22/12/2002
	/// Revised by Nino on 9/1/2003
	/// </summary>
	public class Frm_budgetvar_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtDataContabile;
		public vistaForm DS;
        private System.Windows.Forms.TextBox txtSaldo;
        MetaData Meta;
        private System.Windows.Forms.GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox txtNumUfficiale;
        private CheckBox chkOfficial;
        private GroupBox groupBox7;
        private ComboBox cmbStatus;
        private TextBox textBox4;
        private Label label11;
        private TabControl tabControl1;
        private TabPage tabAnnotazioni;
        private TabPage tabDettagli;
        private Label label4;
        private TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        bool DoSendMail;
        private TabPage tabAllegati;
        private DataGrid dataGrid3;
        private Button button2;
        private Button button3;
        private Button button1;
        private TabPage tabAttributi;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private Button button4;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private GroupBox groupBox1;
        private TextBox txtNvar;
        private Label label6;
        private TextBox txtYvar;
        private Label label7;
        int CurrentStatus;
  
		public Frm_budgetvar_default()
		{
			InitializeComponent();  

			DS.budgetvardetail.ExtendedProperties["ViewTable"]= DS.budgetvardetailview;
            DS.budgetvardetailview.ExtendedProperties["RealTable"] = DS.budgetvardetail;

			DS.budgetvardetailview.Columns["ybudgetvar"].ExtendedProperties["ViewSource"]="budgetvardetail.ybudgetvar";
            DS.budgetvardetailview.Columns["nbudgetvar"].ExtendedProperties["ViewSource"] = "budgetvardetail.nbudgetvar";
            DS.budgetvardetailview.Columns["rownum"].ExtendedProperties["ViewSource"] = "budgetvardetail.rownum";
            DS.budgetvardetailview.Columns["idsor"].ExtendedProperties["ViewSource"] = "budgetvardetail.idsor";
			DS.budgetvardetailview.Columns["idupb"].ExtendedProperties["ViewSource"]="budgetvardetail.idupb";//<--
			DS.budgetvardetailview.Columns["amount"].ExtendedProperties["ViewSource"]="budgetvardetail.amount";
            DS.budgetvardetailview.Columns["description"].ExtendedProperties["ViewSource"] = "budgetvardetail.description";
            DS.budgetvardetailview.Columns["annotation"].ExtendedProperties["ViewSource"] = "budgetvardetail.annotation";
     
            DS.budgetvardetailview.Columns["cu"].ExtendedProperties["ViewSource"]="budgetvardetail.cu";
			DS.budgetvardetailview.Columns["ct"].ExtendedProperties["ViewSource"]="budgetvardetail.ct";
			DS.budgetvardetailview.Columns["lu"].ExtendedProperties["ViewSource"]="budgetvardetail.lu";
			DS.budgetvardetailview.Columns["lt"].ExtendedProperties["ViewSource"]="budgetvardetail.lt";

            DS.budgetvardetailview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sorting.sortcode";
			DS.budgetvardetailview.Columns["sorting"].ExtendedProperties["ViewSource"]="sorting.description";

            DS.budgetvardetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb.codeupb";
            DS.budgetvardetailview.Columns["upb"].ExtendedProperties["ViewSource"] = "upb.title";

            HelpForm.SetDenyNull(DS.Tables["budgetvar"].Columns["official"], true);
            HelpForm.SetDenyNull(DS.Tables["budgetvar"].Columns["idbudgetvarstatus"], true);
            HelpForm.SetDenyNull(DS.Tables["budgetvar"].Columns["idsorkind"], true);
          
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
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNumUfficiale = new System.Windows.Forms.TextBox();
            this.chkOfficial = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.DS = new budgetvar_default.vistaForm();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.tabAnnotazioni = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.tabAllegati = new System.Windows.Forms.TabPage();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNvar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYvar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            this.tabAnnotazioni.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabAllegati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.gboxResponsabile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataContabile.Location = new System.Drawing.Point(796, 99);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(101, 20);
            this.txtDataContabile.TabIndex = 8;
            this.txtDataContabile.Tag = "budgetvar.adate";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(793, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(72, 40);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(48, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "budgetvar.nbudgetvar";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prot.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(7, 138);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(368, 72);
            this.txtDescrizione.TabIndex = 9;
            this.txtDescrizione.Tag = "budgetvar.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(48, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "budgetvar.ybudgetvar";
            this.txtEsercizio.Text = "-";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.Location = new System.Drawing.Point(798, 188);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(104, 20);
            this.txtSaldo.TabIndex = 23;
            this.txtSaldo.TabStop = false;
            this.txtSaldo.Tag = "";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(793, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Saldo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(98, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(838, 270);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.Tag = "budgetvardetail.default.single";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(6, 84);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(86, 26);
            this.btnElimina.TabIndex = 14;
            this.btnElimina.TabStop = false;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 52);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(86, 26);
            this.btnModifica.TabIndex = 13;
            this.btnModifica.TabStop = false;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(6, 20);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(86, 26);
            this.btnInserisci.TabIndex = 12;
            this.btnInserisci.TabStop = false;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Location = new System.Drawing.Point(8, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 72);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variazione";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumUfficiale);
            this.groupBox4.Controls.Add(this.chkOfficial);
            this.groupBox4.Location = new System.Drawing.Point(8, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 40);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // txtNumUfficiale
            // 
            this.txtNumUfficiale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumUfficiale.Location = new System.Drawing.Point(200, 12);
            this.txtNumUfficiale.Name = "txtNumUfficiale";
            this.txtNumUfficiale.Size = new System.Drawing.Size(71, 20);
            this.txtNumUfficiale.TabIndex = 1;
            this.txtNumUfficiale.Tag = "budgetvar.nofficial";
            // 
            // chkOfficial
            // 
            this.chkOfficial.AutoSize = true;
            this.chkOfficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOfficial.Location = new System.Drawing.Point(11, 15);
            this.chkOfficial.Name = "chkOfficial";
            this.chkOfficial.Size = new System.Drawing.Size(183, 17);
            this.chkOfficial.TabIndex = 0;
            this.chkOfficial.Tag = "budgetvar.official:S:N";
            this.chkOfficial.Text = "Variazione Ufficiale Numero";
            this.chkOfficial.UseVisualStyleBackColor = true;
            this.chkOfficial.CheckedChanged += new System.EventHandler(this.chkOfficial_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.cmbStatus);
            this.groupBox7.Location = new System.Drawing.Point(666, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(294, 40);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stato";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DataSource = this.DS.budgetvarstatus;
            this.cmbStatus.DisplayMember = "description";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(6, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(275, 21);
            this.cmbStatus.TabIndex = 43;
            this.cmbStatus.Tag = "budgetvar.idbudgetvarstatus?budgetvarview.idbudgetvarstatus";
            this.cmbStatus.ValueMember = "idbudgetvarstatus";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(6, 19);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(930, 59);
            this.textBox4.TabIndex = 1;
            this.textBox4.Tag = "budgetvar.reason";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Motivazione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Controls.Add(this.tabAnnotazioni);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabAllegati);
            this.tabControl1.Location = new System.Drawing.Point(10, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 308);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.TabStop = false;
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnInserisci);
            this.tabDettagli.Controls.Add(this.btnModifica);
            this.tabDettagli.Controls.Add(this.btnElimina);
            this.tabDettagli.Controls.Add(this.dataGrid1);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettagli.Size = new System.Drawing.Size(942, 282);
            this.tabDettagli.TabIndex = 1;
            this.tabDettagli.Text = "Elenco dettagli";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // tabAnnotazioni
            // 
            this.tabAnnotazioni.Controls.Add(this.label4);
            this.tabAnnotazioni.Controls.Add(this.textBox1);
            this.tabAnnotazioni.Controls.Add(this.label11);
            this.tabAnnotazioni.Controls.Add(this.textBox4);
            this.tabAnnotazioni.Location = new System.Drawing.Point(4, 22);
            this.tabAnnotazioni.Name = "tabAnnotazioni";
            this.tabAnnotazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnnotazioni.Size = new System.Drawing.Size(942, 282);
            this.tabAnnotazioni.TabIndex = 0;
            this.tabAnnotazioni.Text = "Annotazioni";
            this.tabAnnotazioni.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Annotazioni ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(930, 156);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "budgetvar.annotation";
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(942, 282);
            this.tabAttributi.TabIndex = 4;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(499, 99);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(434, 82);
            this.gboxclass05.TabIndex = 23;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 55);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(417, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 26);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(188, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(238, 41);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(499, 6);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(434, 86);
            this.gboxclass04.TabIndex = 22;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(6, 60);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(420, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(6, 31);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(188, 8);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(238, 50);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(6, 180);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(486, 88);
            this.gboxclass03.TabIndex = 20;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(9, 62);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(469, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(9, 35);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(187, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(291, 50);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(7, 93);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(486, 88);
            this.gboxclass02.TabIndex = 21;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(6, 61);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(474, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 32);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(187, 6);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(293, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(7, 4);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(486, 88);
            this.gboxclass01.TabIndex = 19;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(6, 62);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(474, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(6, 33);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(187, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(293, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabAllegati
            // 
            this.tabAllegati.Controls.Add(this.dataGrid3);
            this.tabAllegati.Controls.Add(this.button2);
            this.tabAllegati.Controls.Add(this.button3);
            this.tabAllegati.Controls.Add(this.button1);
            this.tabAllegati.Location = new System.Drawing.Point(4, 22);
            this.tabAllegati.Name = "tabAllegati";
            this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllegati.Size = new System.Drawing.Size(942, 282);
            this.tabAllegati.TabIndex = 3;
            this.tabAllegati.Text = "Allegati";
            this.tabAllegati.UseVisualStyleBackColor = true;
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(94, 6);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.Size = new System.Drawing.Size(845, 270);
            this.dataGrid3.TabIndex = 27;
            this.dataGrid3.Tag = "budgetvarattachment.default.default";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 22);
            this.button2.TabIndex = 26;
            this.button2.Tag = "delete";
            this.button2.Text = "Elimina";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 22);
            this.button3.TabIndex = 25;
            this.button3.TabStop = false;
            this.button3.Tag = "edit.default";
            this.button3.Text = "Modifica...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 24;
            this.button1.TabStop = false;
            this.button1.Tag = "insert.default";
            this.button1.Text = "Inserisci...";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Controls.Add(this.button4);
            this.gboxResponsabile.Location = new System.Drawing.Point(293, 78);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(490, 40);
            this.gboxResponsabile.TabIndex = 7;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(114, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(370, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 25;
            this.button4.TabStop = false;
            this.button4.Tag = "choose.manager.default";
            this.button4.Text = "Responsabile";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNvar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtYvar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(423, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variazione di bilancio collegata";
            // 
            // txtNvar
            // 
            this.txtNvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNvar.Location = new System.Drawing.Point(72, 42);
            this.txtNvar.Name = "txtNvar";
            this.txtNvar.ReadOnly = true;
            this.txtNvar.Size = new System.Drawing.Size(71, 20);
            this.txtNvar.TabIndex = 2;
            this.txtNvar.Tag = "budgetvar.nvar";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Numero";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYvar
            // 
            this.txtYvar.Location = new System.Drawing.Point(72, 16);
            this.txtYvar.Name = "txtYvar";
            this.txtYvar.ReadOnly = true;
            this.txtYvar.Size = new System.Drawing.Size(48, 20);
            this.txtYvar.TabIndex = 1;
            this.txtYvar.TabStop = false;
            this.txtYvar.Tag = "budgetvar.yvar.year";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Esercizio";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_budgetvar_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(972, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxResponsabile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label8);
            this.Name = "Frm_budgetvar_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variazione di previsione annuale";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDettagli.ResumeLayout(false);
            this.tabAnnotazioni.ResumeLayout(false);
            this.tabAnnotazioni.PerformLayout();
            this.tabAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            this.tabAllegati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public void MetaData_BeforePost()
        {
            if (DS.budgetvar.Rows.Count == 0) return;

            // Add - Invio Mail al cambio stato
            DataRow CurrRow = DS.budgetvar.Rows[0];
            DoSendMail = false;
            if (CurrRow.RowState != DataRowState.Deleted)
            {
                CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idbudgetvarstatus"]);
                int OriginalStatus;
                if (!Meta.InsertMode)
                    OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idbudgetvarstatus", DataRowVersion.Original]);
                else
                    OriginalStatus = CurrentStatus;


                if (CurrentStatus != OriginalStatus && (CurrentStatus == 3 || CurrentStatus == 4 || CurrentStatus == 5 || CurrentStatus == 6))
                    DoSendMail = true;
                else
                    DoSendMail = false;
            }
        }

        //se lo stato è Edit e ci sono modifiche in budgetvardetail su idsor/idupb
        //non deve essere possibile approvare la variazione
        bool DettaglioModificato(){
            if (DS.budgetvardetail.Rows.Count==0) return false;
            foreach (DataRow rDettaglio in DS.budgetvardetail.Rows){
                if (rDettaglio.RowState == DataRowState.Modified){
                    if (!rDettaglio["idsor", DataRowVersion.Original].Equals(rDettaglio["idsor", DataRowVersion.Current]))
                        return true;
                    if (!rDettaglio["idupb", DataRowVersion.Original].Equals(rDettaglio["idupb", DataRowVersion.Current]))
                        return true;
                }
            }
            return false;
        }

        public void MetaData_AfterPost()
        {
            if (DoSendMail) {
                DataRow CurrentRow = DS.budgetvar.Rows[0];

                string MsgBody = "";


                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.Conn = Meta.Conn;

                if (CurrentRow["idman"] == DBNull.Value) return;
                int idman = CfgFn.GetNoNullInt32(CurrentRow["idman"]);
                string filter = QHS.CmpEq("idman", idman);

                DataTable T = Meta.Conn.RUN_SELECT("manager", "*", null, filter, null, false);
                if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

                string mailto = T.Rows[0]["email"].ToString();
                if (mailto == "") return;
                string currstatustext = "";
                switch (CurrentStatus) {
                    case 3:
                        currstatustext = "Da Correggere";
                        break;
                    case 4:
                        currstatustext = "Inserita";
                        break;
                    case 5:
                        currstatustext = "Approvato";
                        break;
                    case 6:
                        currstatustext = "Annullato";
                        break;
                }
                SM.To = mailto;
                MsgBody = "La variazione di budget numero " + CurrentRow["nbudgetvar"] + " relativa all'esercizio " + CurrentRow["ybudgetvar"] + "\r\n";
                MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

                if (true) { //CurrentStatus == 3) {
                    MsgBody += " Dettagli:\r\n";
                    if (CurrentRow["description"].ToString() != "") MsgBody += CurrentRow["description"].ToString() + "\r\n";
                    if (CurrentRow["annotation"].ToString() != "") MsgBody += CurrentRow["annotation"].ToString() + "\r\n";
                    MsgBody += "\r\n\r\n";
                    foreach (DataRow RD in DS.budgetvardetail.Select()) {
                        MsgBody += GetTextForbudgetvarDetail(RD);
                        if (RD["description"].ToString() != "") MsgBody += RD["description"].ToString() + "\r\n";
                        if (RD["annotation"].ToString() != "") MsgBody += RD["annotation"].ToString() + "\r\n";
                    }
                    MsgBody += "\r\n";

                }
                SM.Subject = "Notifica cambiamento di stato variazione di budget";
                SM.MessageBody = MsgBody;

                if (!SM.Send()) {
                    if (SM.ErrorMessage != "") MetaFactory.factory.getSingleton<IMessageShower>().Show(SM.ErrorMessage, "Errore");
                }


                DoSendMail = false;
            }
 
        }


        string GetTextForbudgetvarDetail(DataRow R) {
            string S = "";
            object idsor = R["idsor"];
            DataRow Sorting = DS.sorting.Select(QHC.CmpEq("idsor", idsor))[0];
            S += "Voce Classificazione " + Sorting["sortcode"].ToString() + " - " + Sorting["description"].ToString() + "\r\n";
            object idupb = R["idupb"];
            DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
            S += "UPB " + Upb["codeupb"].ToString() + " - " + Upb["title"].ToString() + "\r\n";
            S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c")+ "\r\n";;
            return S;

        }


        public void  MetaData_AfterClear(){
            txtEsercizio.Text= Meta.Conn.GetEsercizio().ToString();
			txtSaldo.Text="";
            chkOfficial.CheckState = CheckState.Indeterminate;
            txtNumUfficiale.ReadOnly = false;
            DisabilitaUfficiale(false);

            txtYvar.ReadOnly = false;
            txtNvar.ReadOnly = false;
            
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
      
		public void MetaData_AfterLink() {


            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DS.budgetvarstatus.ExtendedProperties["sort_by"] = "idbudgetvarstatus";
            

            string filter = (string)Meta.ExtraParameter;
            string filtercodice = QHS.CmpEq("idsorkind", filter);

            Meta.StartFilter = filtercodice;
            GetData.SetStaticFilter(DS.sorting, filtercodice);
            GetData.SetStaticFilter(DS.budgetvar, filtercodice);
    
            GetData.SetStaticFilter(DS.budgetvardetailview, filtercodice);
            GetData.CacheTable(DS.sortingkind, filtercodice, null, false);

            MetaData.SetDefault(DS.budgetvar, "idsorkind", filter);
            // inizialmente usiamo lo stesso flag usato per le variazioni di bilancio
            object default_idbudgetvarstatus = Conn.DO_READ_VALUE("config", 
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "default_idfinvarstatus");
            MetaData.SetDefault(DS.budgetvar, "idbudgetvarstatus", default_idbudgetvarstatus);

         
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this,1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
		}

        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

        void SetGBoxClass0(int num, object sortingkind) {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                G.Visible = false;
                ComboBox C = (ComboBox)GetCtrlByName("cmbCodice0" + nums);
                C.Tag = null;
                C.DataSource = null;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting0" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice0" + nums);
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting0" + nums + ".tree." + filter;
                DS.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        public void MetaData_AfterActivation() {			
            //sets labels for RadioButtons, reading them from persbilancio
            if (DS.sortingkind.Rows.Count == 0) return;
            DataRow CurrTipo = DS.sortingkind.Rows[0];
            Meta.Name = "Variazioni budget per \"" + CurrTipo["description"] + "\"";

            string SqlFilter=QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.config, SqlFilter,null,false);
            Meta.myGetData.ReadCached();
            if (DS.Tables["config"].Rows.Count==0) return;
            DataRow R = DS.Tables["config"].Rows[0];
        }

        private object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            // I selettori del campo NOFFICIAL sono YBUDGETVAR e OFFICIAL
            int ybudgetvar = CfgFn.GetNoNullInt32(R["ybudgetvar"]);
            string official = R["official"].ToString().ToUpper();
            // Se la variazione non è ufficiale non calcolo il campo
            if (official != "S") {
                return null;
            }

            string filter = QHS.AppAnd(QHS.CmpEq("ybudgetvar", ybudgetvar), QHS.CmpEq("official", 'S'));
            object nOff = Conn.DO_READ_VALUE("budgetvar", filter, "MAX(nofficial)");
            if (nOff == null) return null;

            int nOfficial = 1 + CfgFn.GetNoNullInt32(nOff);

            return nOfficial;
        }

        private void DisabilitaUfficiale(bool disable) {
            if (disable || Meta.InsertMode)
            {
                txtNumUfficiale.PasswordChar = ' ';
            }
            else
            {
                 txtNumUfficiale.PasswordChar = Convert.ToChar(0);
            }
            txtNumUfficiale.ReadOnly = disable || Meta.InsertMode;
            if (disable) {
                RowChange.MarkAsAutoincrement(DS.Tables["budgetvar"].Columns["nofficial"], null, null, 7);
                RowChange.MarkAsCustomAutoincrement(DS.Tables["budgetvar"].Columns["nofficial"], new RowChange.CustomCalcAutoID(CalcID));
            }
            else {
                RowChange.ClearAutoIncrement(DS.Tables["budgetvar"].Columns["nofficial"]);
                RowChange.ClearCustomAutoIncrement(DS.Tables["budgetvar"].Columns["nofficial"]);
            }

            if (Meta.InsertMode) {
             
                txtNumUfficiale.Clear();
            }
        }

      
        private void valorizzaTxtNumUfficiale() {
            if (DS.budgetvar.Rows.Count == 0) return;
            if (!Meta.EditMode) return;

            DataRow Curr = DS.budgetvar.Rows[0];
            string ufficiale = (chkOfficial.Checked) ? "S" : "N";

            if (ufficiale == "S") {
                if (Curr["nofficial", DataRowVersion.Original] != DBNull.Value) {
                    int oldValue = CfgFn.GetNoNullInt32(Curr["nofficial", DataRowVersion.Original]);
                    txtNumUfficiale.Text = oldValue.ToString();
                }
            }
            else {
                txtNumUfficiale.Text = "";
            }
        }

        public void MetaData_BeforeFill() {
            if (DS.budgetvar.Rows.Count == 0) return;
            if (DS.Tables["config"].Rows.Count == 0) return;
            DataRow Curr = DS.budgetvar.Rows[0];
            string ufficiale = Curr["official"].ToString().ToUpper();
            bool disabilita = (ufficiale == "S") && Meta.InsertMode;
            DisabilitaUfficiale(disabilita);
        }

      
		public void MetaData_AfterFill() {
			decimal somma =MetaData.SumColumn(DS.budgetvardetail, "amount");

            decimal saldo = somma ;
			txtSaldo.Text=saldo.ToString("c");

            txtYvar.ReadOnly = true;
            txtNvar.ReadOnly = true;

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.budgetvar.Rows[0];
            
            /*
             * Se ci sono delle modifiche ai dettagli non posso passare ad Approvata, o viceversa.
             * Va controllato il vecchio e nuovo stato, se lo stato precedente è 'approvato' ( original value), il nuovo non può essere cambiato,
             * si potrebbe anche disabilitare il bottone in questo caso.
             * */

            if (T.TableName == "budgetvarstatus"){
                if (!Meta.DrawStateIsDone) return;
                if (R == null) return;
                if ((Meta.EditMode) && DettaglioModificato()){
                    int CurrentStatus = CfgFn.GetNoNullInt32(R["idbudgetvarstatus"]); // 5 = Approvata
                    if (CurrentStatus == 5){
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("La variazione non può essere Approvata se sono stati modificati dettagli. Salvare le modifiche e poi approvare la variazione.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        HelpForm.SetComboBoxValue(cmbStatus, Curr["idbudgetvarstatus", DataRowVersion.Original]);
                    }
                }
            }
        }
		 
        private void chkOfficial_CheckedChanged(object sender, EventArgs e) {
            if (Meta.InsertMode) {
                DisabilitaUfficiale(chkOfficial.Checked);
            }
            if (Meta.EditMode) {
                valorizzaTxtNumUfficiale();
            }
        }

     
    }
}
