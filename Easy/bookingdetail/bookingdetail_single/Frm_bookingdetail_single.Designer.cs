/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace bookingdetail_single
{
    partial class Frm_bookingdetail_single
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpArticolo = new System.Windows.Forms.GroupBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.grpImmagine = new System.Windows.Forms.GroupBox();
            this.txtDesArt = new System.Windows.Forms.TextBox();
            this.lblDesArt = new System.Windows.Forms.Label();
            this.txtCodArt = new System.Windows.Forms.TextBox();
            this.lblCodArt = new System.Windows.Forms.Label();
            this.lblStoreDes = new System.Windows.Forms.Label();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.grpClass = new System.Windows.Forms.GroupBox();
            this.txtDesListClass = new System.Windows.Forms.TextBox();
            this.lblDesListClass = new System.Windows.Forms.Label();
            this.txtCodeListClass = new System.Windows.Forms.TextBox();
            this.lblCodListClass = new System.Windows.Forms.Label();
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
            this.grpArticolo.SuspendLayout();
            this.grpClass.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpArticolo
            // 
            this.grpArticolo.Controls.Add(this.lblNumber);
            this.grpArticolo.Controls.Add(this.txtNumber);
            this.grpArticolo.Controls.Add(this.grpImmagine);
            this.grpArticolo.Controls.Add(this.txtDesArt);
            this.grpArticolo.Controls.Add(this.lblDesArt);
            this.grpArticolo.Controls.Add(this.txtCodArt);
            this.grpArticolo.Controls.Add(this.lblCodArt);
            this.grpArticolo.Location = new System.Drawing.Point(12, 12);
            this.grpArticolo.Name = "grpArticolo";
            this.grpArticolo.Size = new System.Drawing.Size(688, 194);
            this.grpArticolo.TabIndex = 0;
            this.grpArticolo.TabStop = false;
            this.grpArticolo.Text = "Articolo";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(198, 37);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(47, 13);
            this.lblNumber.TabIndex = 5;
            this.lblNumber.Text = "Quantit‡";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(251, 34);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 20;
            this.txtNumber.Tag = "bookingdetail.number";
            // 
            // grpImmagine
            // 
            this.grpImmagine.Location = new System.Drawing.Point(372, 11);
            this.grpImmagine.Name = "grpImmagine";
            this.grpImmagine.Size = new System.Drawing.Size(310, 177);
            this.grpImmagine.TabIndex = 4;
            this.grpImmagine.TabStop = false;
            this.grpImmagine.Text = "Immagine";
            // 
            // txtDesArt
            // 
            this.txtDesArt.Location = new System.Drawing.Point(10, 85);
            this.txtDesArt.Multiline = true;
            this.txtDesArt.Name = "txtDesArt";
            this.txtDesArt.ReadOnly = true;
            this.txtDesArt.Size = new System.Drawing.Size(341, 93);
            this.txtDesArt.TabIndex = 30;
            this.txtDesArt.Tag = "list.description";
            // 
            // lblDesArt
            // 
            this.lblDesArt.AutoSize = true;
            this.lblDesArt.Location = new System.Drawing.Point(6, 69);
            this.lblDesArt.Name = "lblDesArt";
            this.lblDesArt.Size = new System.Drawing.Size(62, 13);
            this.lblDesArt.TabIndex = 2;
            this.lblDesArt.Text = "Descrizione";
            // 
            // txtCodArt
            // 
            this.txtCodArt.Location = new System.Drawing.Point(53, 34);
            this.txtCodArt.Name = "txtCodArt";
            this.txtCodArt.ReadOnly = true;
            this.txtCodArt.Size = new System.Drawing.Size(100, 20);
            this.txtCodArt.TabIndex = 10;
            this.txtCodArt.Tag = "list.intcode";
            // 
            // lblCodArt
            // 
            this.lblCodArt.AutoSize = true;
            this.lblCodArt.Location = new System.Drawing.Point(7, 37);
            this.lblCodArt.Name = "lblCodArt";
            this.lblCodArt.Size = new System.Drawing.Size(40, 13);
            this.lblCodArt.TabIndex = 0;
            this.lblCodArt.Text = "Codice";
            // 
            // lblStoreDes
            // 
            this.lblStoreDes.AutoSize = true;
            this.lblStoreDes.Location = new System.Drawing.Point(104, 215);
            this.lblStoreDes.Name = "lblStoreDes";
            this.lblStoreDes.Size = new System.Drawing.Size(58, 13);
            this.lblStoreDes.TabIndex = 1;
            this.lblStoreDes.Text = "Magazzino";
            // 
            // txtStore
            // 
            this.txtStore.Location = new System.Drawing.Point(170, 212);
            this.txtStore.Name = "txtStore";
            this.txtStore.ReadOnly = true;
            this.txtStore.Size = new System.Drawing.Size(414, 20);
            this.txtStore.TabIndex = 40;
            this.txtStore.Tag = "store.description";
            // 
            // grpClass
            // 
            this.grpClass.Controls.Add(this.txtDesListClass);
            this.grpClass.Controls.Add(this.lblDesListClass);
            this.grpClass.Controls.Add(this.txtCodeListClass);
            this.grpClass.Controls.Add(this.lblCodListClass);
            this.grpClass.Location = new System.Drawing.Point(12, 238);
            this.grpClass.Name = "grpClass";
            this.grpClass.Size = new System.Drawing.Size(688, 87);
            this.grpClass.TabIndex = 3;
            this.grpClass.TabStop = false;
            this.grpClass.Text = "Classificazione Merceologica";
            // 
            // txtDesListClass
            // 
            this.txtDesListClass.Location = new System.Drawing.Point(266, 19);
            this.txtDesListClass.Multiline = true;
            this.txtDesListClass.Name = "txtDesListClass";
            this.txtDesListClass.ReadOnly = true;
            this.txtDesListClass.Size = new System.Drawing.Size(416, 59);
            this.txtDesListClass.TabIndex = 60;
            this.txtDesListClass.Tag = "listclass.title";
            // 
            // lblDesListClass
            // 
            this.lblDesListClass.AutoSize = true;
            this.lblDesListClass.Location = new System.Drawing.Point(198, 22);
            this.lblDesListClass.Name = "lblDesListClass";
            this.lblDesListClass.Size = new System.Drawing.Size(62, 13);
            this.lblDesListClass.TabIndex = 4;
            this.lblDesListClass.Text = "Descrizione";
            // 
            // txtCodeListClass
            // 
            this.txtCodeListClass.Location = new System.Drawing.Point(53, 19);
            this.txtCodeListClass.Name = "txtCodeListClass";
            this.txtCodeListClass.ReadOnly = true;
            this.txtCodeListClass.Size = new System.Drawing.Size(121, 20);
            this.txtCodeListClass.TabIndex = 50;
            this.txtCodeListClass.Tag = "listclass.codelistclass";
            // 
            // lblCodListClass
            // 
            this.lblCodListClass.AutoSize = true;
            this.lblCodListClass.Location = new System.Drawing.Point(7, 22);
            this.lblCodListClass.Name = "lblCodListClass";
            this.lblCodListClass.Size = new System.Drawing.Size(40, 13);
            this.lblCodListClass.TabIndex = 2;
            this.lblCodListClass.Text = "Codice";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(12, 401);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(336, 64);
            this.gboxclass3.TabIndex = 42;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 16);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(128, 8);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(200, 52);
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
            this.txtCodice3.Size = new System.Drawing.Size(112, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(364, 331);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(336, 64);
            this.gboxclass2.TabIndex = 43;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 16);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 8);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(200, 52);
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
            this.txtCodice2.Size = new System.Drawing.Size(112, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(12, 331);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(336, 64);
            this.gboxclass1.TabIndex = 41;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 16);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 8);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(200, 52);
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
            this.txtCodice1.Size = new System.Drawing.Size(112, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // Frm_bookingdetail_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 477);
            this.Controls.Add(this.gboxclass3);
            this.Controls.Add(this.gboxclass2);
            this.Controls.Add(this.gboxclass1);
            this.Controls.Add(this.grpClass);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.lblStoreDes);
            this.Controls.Add(this.grpArticolo);
            this.Name = "Frm_bookingdetail_single";
            this.Text = "Frm_bookingdetail_single";
            this.Load += new System.EventHandler(this.Frm_bookingdetail_single_Load);
            this.grpArticolo.ResumeLayout(false);
            this.grpArticolo.PerformLayout();
            this.grpClass.ResumeLayout(false);
            this.grpClass.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpArticolo;
        private System.Windows.Forms.TextBox txtDesArt;
        private System.Windows.Forms.Label lblDesArt;
        private System.Windows.Forms.TextBox txtCodArt;
        private System.Windows.Forms.Label lblCodArt;
        private System.Windows.Forms.Label lblStoreDes;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.GroupBox grpImmagine;
        private System.Windows.Forms.GroupBox grpClass;
        private System.Windows.Forms.TextBox txtDesListClass;
        private System.Windows.Forms.Label lblDesListClass;
        private System.Windows.Forms.TextBox txtCodeListClass;
        private System.Windows.Forms.Label lblCodListClass;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
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
    }
}