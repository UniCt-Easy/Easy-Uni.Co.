/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace assetsetup_uniformadati {
    partial class FrmRiepilogo {
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
            this.tabControl = new Crownwood.Magic.Controls.TabControl();
            this.tabBuono = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgAssetUnloadKind = new System.Windows.Forms.DataGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgAssetLoadKind = new System.Windows.Forms.DataGrid();
            this.tabInventario = new Crownwood.Magic.Controls.TabPage();
            this.dgInventory = new System.Windows.Forms.DataGrid();
            this.tabCausale = new Crownwood.Magic.Controls.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgAssetUnloadMotive = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgAssetLoadMotive = new System.Windows.Forms.DataGrid();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabBuono.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetUnloadKind)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetLoadKind)).BeginInit();
            this.tabInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).BeginInit();
            this.tabCausale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetUnloadMotive)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetLoadMotive)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.IDEPixelArea = true;
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabInventario;
            this.tabControl.Size = new System.Drawing.Size(611, 322);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabInventario,
            this.tabCausale,
            this.tabBuono});
            // 
            // tabBuono
            // 
            this.tabBuono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBuono.Controls.Add(this.groupBox3);
            this.tabBuono.Controls.Add(this.groupBox4);
            this.tabBuono.Location = new System.Drawing.Point(0, 0);
            this.tabBuono.Name = "tabBuono";
            this.tabBuono.Selected = false;
            this.tabBuono.Size = new System.Drawing.Size(611, 297);
            this.tabBuono.TabIndex = 4;
            this.tabBuono.Title = "Tipi di Buono";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgAssetUnloadKind);
            this.groupBox3.Location = new System.Drawing.Point(6, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 139);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "di Scarico";
            // 
            // dgAssetUnloadKind
            // 
            this.dgAssetUnloadKind.DataMember = "";
            this.dgAssetUnloadKind.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAssetUnloadKind.Location = new System.Drawing.Point(6, 20);
            this.dgAssetUnloadKind.Name = "dgAssetUnloadKind";
            this.dgAssetUnloadKind.Size = new System.Drawing.Size(593, 113);
            this.dgAssetUnloadKind.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgAssetLoadKind);
            this.groupBox4.Location = new System.Drawing.Point(3, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(605, 139);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "di Carico";
            // 
            // dgAssetLoadKind
            // 
            this.dgAssetLoadKind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAssetLoadKind.DataMember = "";
            this.dgAssetLoadKind.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAssetLoadKind.Location = new System.Drawing.Point(6, 20);
            this.dgAssetLoadKind.Name = "dgAssetLoadKind";
            this.dgAssetLoadKind.Size = new System.Drawing.Size(593, 113);
            this.dgAssetLoadKind.TabIndex = 0;
            // 
            // tabInventario
            // 
            this.tabInventario.Controls.Add(this.dgInventory);
            this.tabInventario.Location = new System.Drawing.Point(0, 0);
            this.tabInventario.Name = "tabInventario";
            this.tabInventario.Size = new System.Drawing.Size(611, 297);
            this.tabInventario.TabIndex = 5;
            this.tabInventario.Title = "Inventario";
            // 
            // dgInventory
            // 
            this.dgInventory.DataMember = "";
            this.dgInventory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgInventory.Location = new System.Drawing.Point(9, 9);
            this.dgInventory.Name = "dgInventory";
            this.dgInventory.Size = new System.Drawing.Size(593, 282);
            this.dgInventory.TabIndex = 0;
            // 
            // tabCausale
            // 
            this.tabCausale.Controls.Add(this.groupBox2);
            this.tabCausale.Controls.Add(this.groupBox1);
            this.tabCausale.Location = new System.Drawing.Point(0, 0);
            this.tabCausale.Name = "tabCausale";
            this.tabCausale.Selected = false;
            this.tabCausale.Size = new System.Drawing.Size(611, 297);
            this.tabCausale.TabIndex = 3;
            this.tabCausale.Title = "Causali";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgAssetUnloadMotive);
            this.groupBox2.Location = new System.Drawing.Point(6, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "di Scarico";
            // 
            // dgAssetUnloadMotive
            // 
            this.dgAssetUnloadMotive.DataMember = "";
            this.dgAssetUnloadMotive.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAssetUnloadMotive.Location = new System.Drawing.Point(6, 20);
            this.dgAssetUnloadMotive.Name = "dgAssetUnloadMotive";
            this.dgAssetUnloadMotive.Size = new System.Drawing.Size(593, 113);
            this.dgAssetUnloadMotive.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgAssetLoadMotive);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "di Carico";
            // 
            // dgAssetLoadMotive
            // 
            this.dgAssetLoadMotive.DataMember = "";
            this.dgAssetLoadMotive.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAssetLoadMotive.Location = new System.Drawing.Point(6, 20);
            this.dgAssetLoadMotive.Name = "dgAssetLoadMotive";
            this.dgAssetLoadMotive.Size = new System.Drawing.Size(593, 113);
            this.dgAssetLoadMotive.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(439, 354);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(548, 354);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 2;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // FrmRiepilogo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 389);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl);
            this.Name = "FrmRiepilogo";
            this.Text = "Riepilogo dei Look Up effettuati";
            this.tabControl.ResumeLayout(false);
            this.tabBuono.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetUnloadKind)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetLoadKind)).EndInit();
            this.tabInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInventory)).EndInit();
            this.tabCausale.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetUnloadMotive)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssetLoadMotive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabControl;
        private Crownwood.Magic.Controls.TabPage tabCausale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGrid dgAssetUnloadMotive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGrid dgAssetLoadMotive;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private Crownwood.Magic.Controls.TabPage tabBuono;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGrid dgAssetUnloadKind;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGrid dgAssetLoadKind;
        private Crownwood.Magic.Controls.TabPage tabInventario;
        private System.Windows.Forms.DataGrid dgInventory;
    }
}