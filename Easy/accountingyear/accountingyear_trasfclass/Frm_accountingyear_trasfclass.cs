
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace accountingyear_trasfclass//Esercizio_TrasfClassResidui//
{
	/// <summary>
	/// Summary description for FrmTrasfClassResidui.
	/// </summary>
	public class FrmTrasfClassResidui : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtDescrizione;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.CheckBox chkAttivi;
		private System.Windows.Forms.CheckBox chkPassivi;
		private System.Windows.Forms.CheckBox chkOverwrite;
		private System.Windows.Forms.Button btnDoTrasf;
		public /*Rana:Esercizio_TrasfClassResidui.*/vistaForm DS;
        private Button btnRibaltaPrevisioni;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabGenerale;
        private Crownwood.Magic.Controls.TabPage tabRibaltamento;
        private Button btnResidui;
        private ComboBox cmbTipo;
        private Label label1;
		MetaData Meta;

		public FrmTrasfClassResidui()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.chkAttivi = new System.Windows.Forms.CheckBox();
            this.chkPassivi = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.btnDoTrasf = new System.Windows.Forms.Button();
            this.btnRibaltaPrevisioni = new System.Windows.Forms.Button();
            this.DS = new accountingyear_trasfclass.vistaForm();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabGenerale = new Crownwood.Magic.Controls.TabPage();
            this.tabRibaltamento = new Crownwood.Magic.Controls.TabPage();
            this.btnResidui = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGenerale.SuspendLayout();
            this.tabRibaltamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.AcceptsReturn = true;
            this.txtDescrizione.AcceptsTab = true;
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(3, 6);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(514, 147);
            this.txtDescrizione.TabIndex = 0;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Text = "textBox1";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 270);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(56, 32);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.Tag = "accountingyear.default";
            this.dataGrid1.Visible = false;
            // 
            // chkAttivi
            // 
            this.chkAttivi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAttivi.Location = new System.Drawing.Point(3, 159);
            this.chkAttivi.Name = "chkAttivi";
            this.chkAttivi.Size = new System.Drawing.Size(315, 24);
            this.chkAttivi.TabIndex = 2;
            this.chkAttivi.Text = "Trasferisci classificazioni su residui attivi";
            // 
            // chkPassivi
            // 
            this.chkPassivi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPassivi.Location = new System.Drawing.Point(3, 179);
            this.chkPassivi.Name = "chkPassivi";
            this.chkPassivi.Size = new System.Drawing.Size(315, 24);
            this.chkPassivi.TabIndex = 3;
            this.chkPassivi.Text = "Trasferisci classificazioni su residui passivi";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOverwrite.Location = new System.Drawing.Point(3, 200);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(324, 24);
            this.chkOverwrite.TabIndex = 4;
            this.chkOverwrite.Text = "Sovrascrivi classificazioni esistenti dei residui (ove presenti)";
            // 
            // btnDoTrasf
            // 
            this.btnDoTrasf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDoTrasf.Location = new System.Drawing.Point(349, 200);
            this.btnDoTrasf.Name = "btnDoTrasf";
            this.btnDoTrasf.Size = new System.Drawing.Size(168, 23);
            this.btnDoTrasf.TabIndex = 5;
            this.btnDoTrasf.Text = "Effettua trasferimento";
            this.btnDoTrasf.Click += new System.EventHandler(this.btnDoTrasf_Click);
            // 
            // btnRibaltaPrevisioni
            // 
            this.btnRibaltaPrevisioni.Location = new System.Drawing.Point(8, 70);
            this.btnRibaltaPrevisioni.Name = "btnRibaltaPrevisioni";
            this.btnRibaltaPrevisioni.Size = new System.Drawing.Size(176, 23);
            this.btnRibaltaPrevisioni.TabIndex = 6;
            this.btnRibaltaPrevisioni.Text = "Ribalta previsioni disponibili";
            this.btnRibaltaPrevisioni.UseVisualStyleBackColor = true;
            this.btnRibaltaPrevisioni.Click += new System.EventHandler(this.btnRibaltaPrevisioni_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabControl1
            // 
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabGenerale;
            this.tabControl1.Size = new System.Drawing.Size(520, 258);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabGenerale,
            this.tabRibaltamento});
            // 
            // tabGenerale
            // 
            this.tabGenerale.Controls.Add(this.txtDescrizione);
            this.tabGenerale.Controls.Add(this.btnDoTrasf);
            this.tabGenerale.Controls.Add(this.chkAttivi);
            this.tabGenerale.Controls.Add(this.chkPassivi);
            this.tabGenerale.Controls.Add(this.chkOverwrite);
            this.tabGenerale.Location = new System.Drawing.Point(0, 0);
            this.tabGenerale.Name = "tabGenerale";
            this.tabGenerale.Size = new System.Drawing.Size(520, 233);
            this.tabGenerale.TabIndex = 3;
            this.tabGenerale.Title = "Generale";
            // 
            // tabRibaltamento
            // 
            this.tabRibaltamento.Controls.Add(this.btnResidui);
            this.tabRibaltamento.Controls.Add(this.cmbTipo);
            this.tabRibaltamento.Controls.Add(this.label1);
            this.tabRibaltamento.Controls.Add(this.btnRibaltaPrevisioni);
            this.tabRibaltamento.Location = new System.Drawing.Point(0, 0);
            this.tabRibaltamento.Name = "tabRibaltamento";
            this.tabRibaltamento.Selected = false;
            this.tabRibaltamento.Size = new System.Drawing.Size(520, 233);
            this.tabRibaltamento.TabIndex = 4;
            this.tabRibaltamento.Title = "Ribaltamento";
            // 
            // btnResidui
            // 
            this.btnResidui.Location = new System.Drawing.Point(8, 99);
            this.btnResidui.Name = "btnResidui";
            this.btnResidui.Size = new System.Drawing.Size(176, 23);
            this.btnResidui.TabIndex = 21;
            this.btnResidui.Text = "Variazioni di previsione sui residui";
            this.btnResidui.UseVisualStyleBackColor = true;
            this.btnResidui.Click += new System.EventHandler(this.btnResidui_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DataSource = this.DS.sortingkind;
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(104, 18);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(384, 23);
            this.cmbTipo.TabIndex = 19;
            this.cmbTipo.Tag = "";
            this.cmbTipo.ValueMember = "idsorkind";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Classificazione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FrmTrasfClassResidui
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 317);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGrid1);
            this.Name = "FrmTrasfClassResidui";
            this.Text = "FrmTrasfClassResidui";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGenerale.ResumeLayout(false);
            this.tabGenerale.PerformLayout();
            this.tabRibaltamento.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Meta.CanSave=false;
			Meta.SearchEnabled=false;
			Meta.CanInsert=false;

            GetData.CacheTable(DS.sortingkind, null, "description", true);

			int esercizio= (int) Meta.GetSys("esercizio");
			txtDescrizione.Text=
				QueryCreator.GetPrintable(
				"Questa funzione trasferisce tutte le classificazioni di movimenti dell'anno "+esercizio.ToString()+
					" che sono residui nell'anno "+(esercizio+1)+".\n\r"+
				"In particolare, l'importo classificato nel "+(esercizio+1)+" sarà la quota parte dell'importo classificato "+
				"nel "+esercizio+" rispetto al rappporto tra l'importo corrente del movimento finanziario nel "+esercizio+
				" e l'importo corrente del "+(esercizio+1)+".\n\r"+
				"Ad esempio, se ho un impegno del "+esercizio+" di importo 1000 e di cui ho pagato 400, e classificato 1000,"+
				" nel "+(esercizio+1)+" questo sarà un movimento residuo che avrà importo ("+(esercizio+1)+") 600, e risulterà, dopo l'esecuzione di questa funzione,"+
				" classificato per un importo di 600.\n\r"+
				"Normalmente questa operazione può essere fatta dopo aver trasferito i residui e aver classificato tutti i movimenti del "+esercizio+
				". E' comunque possibile eseguirla più volte, per integrare altre classificazioni o sovrascrivere quelle precedentemente trasferite."
				);
			
		}

		private void btnDoTrasf_Click(object sender, System.EventArgs e) {			
			int esercizio= (int) Meta.GetSys("esercizio");
			string overwrite="";
			if (chkOverwrite.Checked) 
				overwrite="S";
			else
				overwrite="N";
			if (chkAttivi.Checked){
				Meta.Conn.CallSP("closeyear_copysortings",
					new object[]{esercizio,"I",overwrite},false,360000); //income

			}
			if (chkPassivi.Checked){
				Meta.Conn.CallSP("closeyear_copysortings",
					new object[]{esercizio,"E",overwrite},false, 360000);  //expense

			}

			show("Operazione effettuata");
		}

        object tipoScelto;
        private void btnRibaltaPrevisioni_Click(object sender, EventArgs e) {
            tipoScelto = cmbTipo.SelectedValue;
            if (CfgFn.GetNoNullInt32(tipoScelto) == 0) {
                show(this, "Tipo della Classificazione non scelto, Operazione interrotta!");
                return;
            }

            int esercizio = (int)Meta.GetSys("esercizio");
            Meta.Conn.CallSP("exp_prevavailable_sorting",
                    new object[] { esercizio, tipoScelto }, false);

            show("Operazione effettuata");

        }

        private void btnResidui_Click(object sender, EventArgs e) {
            tipoScelto = cmbTipo.SelectedValue;
            if (CfgFn.GetNoNullInt32(tipoScelto) == 0) {
                show(this, "Tipo della Classificazione non scelto, Operazione interrotta!");
                return;
            }

            int esercizio = (int)Meta.GetSys("esercizio");
            Meta.Conn.CallSP("compute_sortingvariation",
                    new object[] { esercizio, tipoScelto }, false);

            show("Operazione effettuata");

        }


	}
}
