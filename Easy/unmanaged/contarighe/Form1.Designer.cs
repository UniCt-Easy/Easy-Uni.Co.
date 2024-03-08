
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


namespace contarighe {
	partial class Form1 {
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
			this.selezionaCartella = new System.Windows.Forms.FolderBrowserDialog();
			this.btnCalcola = new System.Windows.Forms.Button();
			this.barProgetti = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTotCartelle = new System.Windows.Forms.TextBox();
			this.txtFileConsiderati = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.barraFile = new System.Windows.Forms.ProgressBar();
			this.label4 = new System.Windows.Forms.Label();
			this.txtForm = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMeta = new System.Windows.Forms.TextBox();
			this.txtRigheTotali = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCodiceMeta = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCodiceForm = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtForm1000 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtRigheForm1000 = new System.Windows.Forms.TextBox();
			this.txtThreeShold = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtNFound = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtToSearch = new System.Windows.Forms.TextBox();
			this.txtElencoMetaMsgBox = new System.Windows.Forms.TextBox();
			this.btnCercaMsgBox = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.txtMetodi = new System.Windows.Forms.TextBox();
			this.btnContaMetodi = new System.Windows.Forms.Button();
			this.btnSelezionaRoot = new System.Windows.Forms.Button();
			this.txtRoot = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCalcola
			// 
			this.btnCalcola.Location = new System.Drawing.Point(27, 21);
			this.btnCalcola.Name = "btnCalcola";
			this.btnCalcola.Size = new System.Drawing.Size(75, 23);
			this.btnCalcola.TabIndex = 3;
			this.btnCalcola.Text = "Calcola";
			this.btnCalcola.UseVisualStyleBackColor = true;
			this.btnCalcola.Click += new System.EventHandler(this.btnCalcola_Click);
			// 
			// barProgetti
			// 
			this.barProgetti.Location = new System.Drawing.Point(27, 103);
			this.barProgetti.Name = "barProgetti";
			this.barProgetti.Size = new System.Drawing.Size(607, 23);
			this.barProgetti.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Cartelle  considerate";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotCartelle
			// 
			this.txtTotCartelle.Location = new System.Drawing.Point(139, 65);
			this.txtTotCartelle.Name = "txtTotCartelle";
			this.txtTotCartelle.ReadOnly = true;
			this.txtTotCartelle.Size = new System.Drawing.Size(100, 20);
			this.txtTotCartelle.TabIndex = 6;
			this.txtTotCartelle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFileConsiderati
			// 
			this.txtFileConsiderati.Location = new System.Drawing.Point(139, 138);
			this.txtFileConsiderati.Name = "txtFileConsiderati";
			this.txtFileConsiderati.ReadOnly = true;
			this.txtFileConsiderati.Size = new System.Drawing.Size(100, 20);
			this.txtFileConsiderati.TabIndex = 7;
			this.txtFileConsiderati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 141);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "File considerati";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// barraFile
			// 
			this.barraFile.Location = new System.Drawing.Point(28, 175);
			this.barraFile.Name = "barraFile";
			this.barraFile.Size = new System.Drawing.Size(606, 23);
			this.barraFile.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(264, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Form";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtForm
			// 
			this.txtForm.Location = new System.Drawing.Point(300, 137);
			this.txtForm.Name = "txtForm";
			this.txtForm.ReadOnly = true;
			this.txtForm.Size = new System.Drawing.Size(100, 20);
			this.txtForm.TabIndex = 10;
			this.txtForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(429, 141);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "meta";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMeta
			// 
			this.txtMeta.Location = new System.Drawing.Point(465, 138);
			this.txtMeta.Name = "txtMeta";
			this.txtMeta.ReadOnly = true;
			this.txtMeta.Size = new System.Drawing.Size(100, 20);
			this.txtMeta.TabIndex = 12;
			this.txtMeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRigheTotali
			// 
			this.txtRigheTotali.Location = new System.Drawing.Point(140, 219);
			this.txtRigheTotali.Name = "txtRigheTotali";
			this.txtRigheTotali.ReadOnly = true;
			this.txtRigheTotali.Size = new System.Drawing.Size(100, 20);
			this.txtRigheTotali.TabIndex = 15;
			this.txtRigheTotali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 222);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Righe totali";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(429, 222);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "meta";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceMeta
			// 
			this.txtCodiceMeta.Location = new System.Drawing.Point(465, 219);
			this.txtCodiceMeta.Name = "txtCodiceMeta";
			this.txtCodiceMeta.ReadOnly = true;
			this.txtCodiceMeta.Size = new System.Drawing.Size(100, 20);
			this.txtCodiceMeta.TabIndex = 18;
			this.txtCodiceMeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(264, 222);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(30, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Form";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceForm
			// 
			this.txtCodiceForm.Location = new System.Drawing.Point(300, 218);
			this.txtCodiceForm.Name = "txtCodiceForm";
			this.txtCodiceForm.ReadOnly = true;
			this.txtCodiceForm.Size = new System.Drawing.Size(100, 20);
			this.txtCodiceForm.TabIndex = 16;
			this.txtCodiceForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(153, 255);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(141, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "Form con più di (soglia) righe";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtForm1000
			// 
			this.txtForm1000.Location = new System.Drawing.Point(300, 251);
			this.txtForm1000.Name = "txtForm1000";
			this.txtForm1000.ReadOnly = true;
			this.txtForm1000.Size = new System.Drawing.Size(100, 20);
			this.txtForm1000.TabIndex = 20;
			this.txtForm1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(202, 284);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(92, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "Righe dei suddetti";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRigheForm1000
			// 
			this.txtRigheForm1000.Location = new System.Drawing.Point(300, 281);
			this.txtRigheForm1000.Name = "txtRigheForm1000";
			this.txtRigheForm1000.ReadOnly = true;
			this.txtRigheForm1000.Size = new System.Drawing.Size(100, 20);
			this.txtRigheForm1000.TabIndex = 22;
			this.txtRigheForm1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtThreeShold
			// 
			this.txtThreeShold.Location = new System.Drawing.Point(465, 255);
			this.txtThreeShold.Name = "txtThreeShold";
			this.txtThreeShold.Size = new System.Drawing.Size(100, 20);
			this.txtThreeShold.TabIndex = 24;
			this.txtThreeShold.Text = "1000";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(429, 258);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(34, 13);
			this.label11.TabIndex = 25;
			this.label11.Text = "soglia";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 45);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1011, 470);
			this.tabControl1.TabIndex = 26;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.txtThreeShold);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.btnCalcola);
			this.tabPage1.Controls.Add(this.txtRigheForm1000);
			this.tabPage1.Controls.Add(this.barProgetti);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.txtForm1000);
			this.tabPage1.Controls.Add(this.txtTotCartelle);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.txtFileConsiderati);
			this.tabPage1.Controls.Add(this.txtCodiceMeta);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.barraFile);
			this.tabPage1.Controls.Add(this.txtCodiceForm);
			this.tabPage1.Controls.Add(this.txtForm);
			this.tabPage1.Controls.Add(this.txtRigheTotali);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.txtMeta);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1003, 444);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Conteggi";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtNFound);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.txtToSearch);
			this.tabPage2.Controls.Add(this.txtElencoMetaMsgBox);
			this.tabPage2.Controls.Add(this.btnCercaMsgBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1003, 444);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "MsgBox Finder";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtNFound
			// 
			this.txtNFound.Location = new System.Drawing.Point(634, 22);
			this.txtNFound.Name = "txtNFound";
			this.txtNFound.Size = new System.Drawing.Size(100, 20);
			this.txtNFound.TabIndex = 8;
			this.txtNFound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(530, 25);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(98, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Occorrenze trovate";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtToSearch
			// 
			this.txtToSearch.Location = new System.Drawing.Point(106, 18);
			this.txtToSearch.Name = "txtToSearch";
			this.txtToSearch.Size = new System.Drawing.Size(316, 20);
			this.txtToSearch.TabIndex = 6;
			this.txtToSearch.Text = "MessageBox.Show";
			// 
			// txtElencoMetaMsgBox
			// 
			this.txtElencoMetaMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtElencoMetaMsgBox.Location = new System.Drawing.Point(6, 45);
			this.txtElencoMetaMsgBox.Multiline = true;
			this.txtElencoMetaMsgBox.Name = "txtElencoMetaMsgBox";
			this.txtElencoMetaMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtElencoMetaMsgBox.Size = new System.Drawing.Size(977, 380);
			this.txtElencoMetaMsgBox.TabIndex = 5;
			// 
			// btnCercaMsgBox
			// 
			this.btnCercaMsgBox.Location = new System.Drawing.Point(6, 16);
			this.btnCercaMsgBox.Name = "btnCercaMsgBox";
			this.btnCercaMsgBox.Size = new System.Drawing.Size(75, 23);
			this.btnCercaMsgBox.TabIndex = 4;
			this.btnCercaMsgBox.Text = "Cerca";
			this.btnCercaMsgBox.UseVisualStyleBackColor = true;
			this.btnCercaMsgBox.Click += new System.EventHandler(this.btnCercaMsgBox_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.txtMetodi);
			this.tabPage3.Controls.Add(this.btnContaMetodi);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1003, 444);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Conta metodi";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(127, 25);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(130, 13);
			this.label13.TabIndex = 7;
			this.label13.Text = "Conta i metodi MetaData_";
			// 
			// txtMetodi
			// 
			this.txtMetodi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMetodi.Location = new System.Drawing.Point(6, 49);
			this.txtMetodi.Multiline = true;
			this.txtMetodi.Name = "txtMetodi";
			this.txtMetodi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMetodi.Size = new System.Drawing.Size(977, 380);
			this.txtMetodi.TabIndex = 6;
			// 
			// btnContaMetodi
			// 
			this.btnContaMetodi.Location = new System.Drawing.Point(6, 20);
			this.btnContaMetodi.Name = "btnContaMetodi";
			this.btnContaMetodi.Size = new System.Drawing.Size(75, 23);
			this.btnContaMetodi.TabIndex = 5;
			this.btnContaMetodi.Text = "Cerca";
			this.btnContaMetodi.UseVisualStyleBackColor = true;
			this.btnContaMetodi.Click += new System.EventHandler(this.btnContaMetodi_Click);
			// 
			// btnSelezionaRoot
			// 
			this.btnSelezionaRoot.Location = new System.Drawing.Point(614, 16);
			this.btnSelezionaRoot.Name = "btnSelezionaRoot";
			this.btnSelezionaRoot.Size = new System.Drawing.Size(75, 23);
			this.btnSelezionaRoot.TabIndex = 2;
			this.btnSelezionaRoot.Text = "Seleziona";
			this.btnSelezionaRoot.UseVisualStyleBackColor = true;
			this.btnSelezionaRoot.Click += new System.EventHandler(this.btnSelezionaRoot_Click);
			// 
			// txtRoot
			// 
			this.txtRoot.Location = new System.Drawing.Point(82, 16);
			this.txtRoot.Name = "txtRoot";
			this.txtRoot.Size = new System.Drawing.Size(505, 20);
			this.txtRoot.TabIndex = 1;
			this.txtRoot.Text = "d:\\Easy";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cartella root";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1035, 525);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtRoot);
			this.Controls.Add(this.btnSelezionaRoot);
			this.Name = "Form1";
			this.Text = "Conta righe di codice";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FolderBrowserDialog selezionaCartella;
		private System.Windows.Forms.Button btnCalcola;
		private System.Windows.Forms.ProgressBar barProgetti;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTotCartelle;
		private System.Windows.Forms.TextBox txtFileConsiderati;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar barraFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtForm;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMeta;
		private System.Windows.Forms.TextBox txtRigheTotali;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCodiceMeta;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCodiceForm;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtForm1000;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtRigheForm1000;
		private System.Windows.Forms.TextBox txtThreeShold;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtElencoMetaMsgBox;
		private System.Windows.Forms.Button btnCercaMsgBox;
		private System.Windows.Forms.Button btnSelezionaRoot;
		private System.Windows.Forms.TextBox txtRoot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtToSearch;
		private System.Windows.Forms.TextBox txtNFound;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox txtMetodi;
		private System.Windows.Forms.Button btnContaMetodi;
		private System.Windows.Forms.Label label13;
	}
}

