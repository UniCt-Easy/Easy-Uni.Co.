
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



namespace invoice_default {
	partial class FrmWizardScegliDettagliFatturaMadre {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.lblValuta = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSelezionaTutto = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.gridDettagliFatturaMadre = new System.Windows.Forms.DataGrid();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagliFatturaMadre)).BeginInit();
			this.SuspendLayout();
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(18, 10);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabPage1;
			this.tabController.Size = new System.Drawing.Size(779, 505);
			this.tabController.TabIndex = 15;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblValuta);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnSelezionaTutto);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.gridDettagliFatturaMadre);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(779, 480);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Title = "Pagina 1 di 2";
			// 
			// lblValuta
			// 
			this.lblValuta.AutoSize = true;
			this.lblValuta.Location = new System.Drawing.Point(341, 72);
			this.lblValuta.Name = "lblValuta";
			this.lblValuta.Size = new System.Drawing.Size(217, 15);
			this.lblValuta.TabIndex = 34;
			this.lblValuta.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(315, 16);
			this.label1.TabIndex = 33;
			this.label1.Text = "Attenzione: i dettagli si riferiscono a fatture in valuta:";
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 8);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
			this.btnSelezionaTutto.TabIndex = 30;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(112, 8);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(464, 32);
			this.label16.TabIndex = 29;
			this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più dettagli da inserire in fattura";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 56);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(262, 16);
			this.label14.TabIndex = 28;
			this.label14.Text = "Dettagli da inserire in fattura";
			// 
			// gridDettagliFatturaMadre
			// 
			this.gridDettagliFatturaMadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagliFatturaMadre.CaptionVisible = false;
			this.gridDettagliFatturaMadre.DataMember = "";
			this.gridDettagliFatturaMadre.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagliFatturaMadre.Location = new System.Drawing.Point(8, 120);
			this.gridDettagliFatturaMadre.Name = "gridDettagliFatturaMadre";
			this.gridDettagliFatturaMadre.Size = new System.Drawing.Size(763, 345);
			this.gridDettagliFatturaMadre.TabIndex = 27;
			this.gridDettagliFatturaMadre.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagliFatturaMadre_Paint);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(608, 539);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(85, 23);
			this.btnNext.TabIndex = 17;
			this.btnNext.Text = "Inserisci";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(712, 539);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmWizardScegliDettagliFatturaMadre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 574);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tabController);
			this.Name = "FrmWizardScegliDettagliFatturaMadre";
			this.Text = "FrmWizardScegliDettagliFatturaMadre";
			this.tabController.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagliFatturaMadre)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		//private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Label lblValuta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGrid gridDettagliFatturaMadre;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
	}
}
