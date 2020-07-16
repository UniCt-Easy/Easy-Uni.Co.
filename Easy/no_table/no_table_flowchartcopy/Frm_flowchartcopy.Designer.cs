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

namespace no_table_flowchartcopy
{
    partial class Frm_flowchartcopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_flowchartcopy));
            this.DS = new no_table_flowchartcopy.vistaForm();
            this.txtdbsource = new System.Windows.Forms.TextBox();
            this.txtstartayear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdbdest = new System.Windows.Forms.TextBox();
            this.txtstopayear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btntrasferisci = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtdbsource
            // 
            this.txtdbsource.Location = new System.Drawing.Point(148, 12);
            this.txtdbsource.Name = "txtdbsource";
            this.txtdbsource.Size = new System.Drawing.Size(120, 20);
            this.txtdbsource.TabIndex = 11;
            // 
            // txtstartayear
            // 
            this.txtstartayear.Location = new System.Drawing.Point(148, 38);
            this.txtstartayear.Name = "txtstartayear";
            this.txtstartayear.Size = new System.Drawing.Size(57, 20);
            this.txtstartayear.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 78);
            this.label1.TabIndex = 15;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Dipartimento Da cui copiare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Dipartimento IN cui copiare";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Esercizio DA cui copiare";
            // 
            // txtdbdest
            // 
            this.txtdbdest.Location = new System.Drawing.Point(146, 80);
            this.txtdbdest.Name = "txtdbdest";
            this.txtdbdest.Size = new System.Drawing.Size(120, 20);
            this.txtdbdest.TabIndex = 13;
            // 
            // txtstopayear
            // 
            this.txtstopayear.Location = new System.Drawing.Point(145, 112);
            this.txtstopayear.Name = "txtstopayear";
            this.txtstopayear.Size = new System.Drawing.Size(57, 20);
            this.txtstopayear.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Esercizio IN cui copiare";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtstopayear);
            this.groupBox1.Controls.Add(this.txtstartayear);
            this.groupBox1.Controls.Add(this.txtdbdest);
            this.groupBox1.Controls.Add(this.txtdbsource);
            this.groupBox1.Location = new System.Drawing.Point(35, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 158);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 39);
            this.label6.TabIndex = 20;
            this.label6.Text = "Lasciare vuoto se si vuole \r\neffettuare il trasferimento\r\n in tutti gli anni.";
            // 
            // btntrasferisci
            // 
            this.btntrasferisci.Location = new System.Drawing.Point(140, 259);
            this.btntrasferisci.Name = "btntrasferisci";
            this.btntrasferisci.Size = new System.Drawing.Size(152, 29);
            this.btntrasferisci.TabIndex = 22;
            this.btntrasferisci.Text = "Trasferisci Organigramma";
            this.btntrasferisci.UseVisualStyleBackColor = true;
            this.btntrasferisci.Click += new System.EventHandler(this.btntrasferisci_Click);
            // 
            // Frm_flowchartcopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 295);
            this.Controls.Add(this.btntrasferisci);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_flowchartcopy";
            this.Text = "Frm_flowchartcopy";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdbsource;
        private System.Windows.Forms.TextBox txtstartayear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdbdest;
        private System.Windows.Forms.TextBox txtstopayear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btntrasferisci;
        private System.Windows.Forms.Label label6;
        public vistaForm DS;
    }
}