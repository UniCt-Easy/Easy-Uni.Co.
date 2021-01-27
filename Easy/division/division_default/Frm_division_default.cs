
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

namespace division_default {//sezione//
	/// <summary>
	/// Summary description for frmsezione.
	/// </summary>
	public class Frm_division_default : MetaDataForm {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox txtcodice;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox10;
		public vistaForm DS;
		private Crownwood.Magic.Controls.TabPage Generalita;
		private Crownwood.Magic.Controls.TabPage ClassSup;
		private System.Windows.Forms.DataGrid dgrIndirizzo;
		private System.Windows.Forms.Button btnIndElimina;
		private System.Windows.Forms.Button btnIndModifica;
		private System.Windows.Forms.Button btnIndInserisci;
		private Crownwood.Magic.Controls.TabControl MagicTab;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
        MetaData Meta;

		public Frm_division_default() {
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
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            DS.sortingview.setStaticFilter(qhs.CmpEq("ayear",esercizio));
        }
        public void MetaData_AfterClear()
        {
            txtcodice.ReadOnly = false;
        }

        public void MetaData_AfterFill()
        {
            if (Meta.EditMode)
            {
                txtcodice.ReadOnly = true;
            }
            else
            {
                txtcodice.ReadOnly = false;
            }

        }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_division_default));
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcodice = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MagicTab = new Crownwood.Magic.Controls.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ClassSup = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.dgrIndirizzo = new System.Windows.Forms.DataGrid();
            this.Generalita = new Crownwood.Magic.Controls.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DS = new division_default.vistaForm();
            this.MagicTab.SuspendLayout();
            this.ClassSup.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrIndirizzo)).BeginInit();
            this.Generalita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(104, 104);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(416, 21);
            this.textBox10.TabIndex = 30;
            this.textBox10.Tag = "division.address";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(104, 136);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(288, 21);
            this.textBox9.TabIndex = 40;
            this.textBox9.Tag = "division.city";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(48, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Comune";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(112, 264);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(168, 21);
            this.textBox8.TabIndex = 100;
            this.textBox8.Tag = "division.faxnumber";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(104, 168);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(56, 21);
            this.textBox7.TabIndex = 50;
            this.textBox7.Tag = "division.country";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fax";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcodice
            // 
            this.txtcodice.Location = new System.Drawing.Point(72, 24);
            this.txtcodice.Name = "txtcodice";
            this.txtcodice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcodice.Size = new System.Drawing.Size(72, 21);
            this.txtcodice.TabIndex = 10;
            this.txtcodice.Tag = "division.codedivision";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(72, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(464, 21);
            this.textBox5.TabIndex = 20;
            this.textBox5.Tag = "division.description";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(48, 264);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(56, 21);
            this.textBox4.TabIndex = 90;
            this.textBox4.Tag = "division.faxprefix";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(48, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 21);
            this.textBox3.TabIndex = 70;
            this.textBox3.Tag = "division.phoneprefix";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(224, 168);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 21);
            this.textBox2.TabIndex = 60;
            this.textBox2.Tag = "division.cap";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 232);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 21);
            this.textBox1.TabIndex = 80;
            this.textBox1.Tag = "division.phonenumber";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tel.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cod.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Via";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cap";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MagicTab
            // 
            this.MagicTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MagicTab.IDEPixelArea = true;
            this.MagicTab.ImageList = this.imageList1;
            this.MagicTab.Location = new System.Drawing.Point(16, 8);
            this.MagicTab.Multiline = true;
            this.MagicTab.Name = "MagicTab";
            this.MagicTab.SelectedIndex = 0;
            this.MagicTab.SelectedTab = this.Generalita;
            this.MagicTab.Size = new System.Drawing.Size(544, 353);
            this.MagicTab.TabIndex = 1;
            this.MagicTab.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.Generalita,
            this.ClassSup});
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // ClassSup
            // 
            this.ClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassSup.Controls.Add(this.groupBox3);
            this.ClassSup.ImageIndex = 0;
            this.ClassSup.Location = new System.Drawing.Point(0, 0);
            this.ClassSup.Name = "ClassSup";
            this.ClassSup.Selected = false;
            this.ClassSup.Size = new System.Drawing.Size(544, 328);
            this.ClassSup.TabIndex = 1;
            this.ClassSup.Title = "Classificazioni";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnIndInserisci);
            this.groupBox3.Controls.Add(this.btnIndModifica);
            this.groupBox3.Controls.Add(this.btnIndElimina);
            this.groupBox3.Controls.Add(this.dgrIndirizzo);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 312);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classificazioni supplementari";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndInserisci.Location = new System.Drawing.Point(256, 25);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 8;
            this.btnIndInserisci.Tag = "insert.default";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndModifica.Location = new System.Drawing.Point(336, 25);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 9;
            this.btnIndModifica.Tag = "edit.default";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIndElimina.Location = new System.Drawing.Point(416, 25);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 10;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // dgrIndirizzo
            // 
            this.dgrIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrIndirizzo.DataMember = "";
            this.dgrIndirizzo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrIndirizzo.Location = new System.Drawing.Point(8, 49);
            this.dgrIndirizzo.Name = "dgrIndirizzo";
            this.dgrIndirizzo.ReadOnly = true;
            this.dgrIndirizzo.Size = new System.Drawing.Size(512, 255);
            this.dgrIndirizzo.TabIndex = 11;
            this.dgrIndirizzo.Tag = "divisionsorting.default.default";
            // 
            // Generalita
            // 
            this.Generalita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Generalita.Controls.Add(this.pictureBox2);
            this.Generalita.Controls.Add(this.textBox10);
            this.Generalita.Controls.Add(this.label3);
            this.Generalita.Controls.Add(this.textBox4);
            this.Generalita.Controls.Add(this.txtcodice);
            this.Generalita.Controls.Add(this.textBox9);
            this.Generalita.Controls.Add(this.textBox5);
            this.Generalita.Controls.Add(this.textBox3);
            this.Generalita.Controls.Add(this.textBox2);
            this.Generalita.Controls.Add(this.textBox1);
            this.Generalita.Controls.Add(this.label5);
            this.Generalita.Controls.Add(this.label4);
            this.Generalita.Controls.Add(this.label2);
            this.Generalita.Controls.Add(this.label1);
            this.Generalita.Controls.Add(this.label10);
            this.Generalita.Controls.Add(this.textBox8);
            this.Generalita.Controls.Add(this.textBox7);
            this.Generalita.Controls.Add(this.label7);
            this.Generalita.Controls.Add(this.label9);
            this.Generalita.Controls.Add(this.groupBox1);
            this.Generalita.Controls.Add(this.groupBox2);
            this.Generalita.Location = new System.Drawing.Point(0, 0);
            this.Generalita.Name = "Generalita";
            this.Generalita.Size = new System.Drawing.Size(544, 328);
            this.Generalita.TabIndex = 0;
            this.Generalita.Title = "Principale";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(320, 208);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 104);
            this.pictureBox2.TabIndex = 101;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 88);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recapiti telefonici";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 112);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Indirizzo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(408, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_division_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(570, 376);
            this.Controls.Add(this.MagicTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "Frm_division_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sezione";
            this.MagicTab.ResumeLayout(false);
            this.ClassSup.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrIndirizzo)).EndInit();
            this.Generalita.ResumeLayout(false);
            this.Generalita.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	}
}
