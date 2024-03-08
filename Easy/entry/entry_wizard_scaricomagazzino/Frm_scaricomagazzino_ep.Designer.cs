
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


namespace entry_wizard_scaricomagazzino
{
    partial class Frm_scaricomagazzino_ep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_scaricomagazzino_ep));
            this.DS = new entry_wizard_scaricomagazzino.vistaForm();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSave = new Crownwood.Magic.Controls.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.gridEP = new System.Windows.Forms.DataGrid();
            this.labelNewLinkedCont = new System.Windows.Forms.Label();
            this.labelAddCont = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEP)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(396, 546);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 527);
            this.panel1.TabIndex = 29;
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabIntro;
            this.tabController.Size = new System.Drawing.Size(784, 527);
            this.tabController.TabIndex = 22;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSave});
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Size = new System.Drawing.Size(784, 502);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(695, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSave
            // 
            this.tabSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSave.Controls.Add(this.label12);
            this.tabSave.Controls.Add(this.gridEP);
            this.tabSave.Controls.Add(this.labelNewLinkedCont);
            this.tabSave.Controls.Add(this.labelAddCont);
            this.tabSave.Controls.Add(this.labelMessage);
            this.tabSave.Location = new System.Drawing.Point(0, 0);
            this.tabSave.Name = "tabSave";
            this.tabSave.Selected = false;
            this.tabSave.Size = new System.Drawing.Size(784, 502);
            this.tabSave.TabIndex = 5;
            this.tabSave.Title = "Pagina 2 di 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(474, 13);
            this.label12.TabIndex = 114;
            this.label12.Text = "Avvertimento: se l\'operazione viene confermata, verranno generate le scritture in" +
                " Partita doppia.";
            // 
            // gridEP
            // 
            this.gridEP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEP.DataMember = "";
            this.gridEP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEP.Location = new System.Drawing.Point(34, 94);
            this.gridEP.Name = "gridEP";
            this.gridEP.Size = new System.Drawing.Size(728, 357);
            this.gridEP.TabIndex = 113;
            // 
            // labelNewLinkedCont
            // 
            this.labelNewLinkedCont.Location = new System.Drawing.Point(9, 404);
            this.labelNewLinkedCont.Name = "labelNewLinkedCont";
            this.labelNewLinkedCont.Size = new System.Drawing.Size(687, 32);
            this.labelNewLinkedCont.TabIndex = 112;
            // 
            // labelAddCont
            // 
            this.labelAddCont.Location = new System.Drawing.Point(9, 444);
            this.labelAddCont.Name = "labelAddCont";
            this.labelAddCont.Size = new System.Drawing.Size(704, 24);
            this.labelAddCont.TabIndex = 111;
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMessage.Location = new System.Drawing.Point(9, 372);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(766, 32);
            this.labelMessage.TabIndex = 106;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(624, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Annulla";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(284, 546);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "< Indietro";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(715, 546);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 30;
            this.btnOK.Tag = "";
            this.btnOK.Text = "Chiudi";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Frm_scaricomagazzino_ep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 579);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_scaricomagazzino_ep";
            this.Text = "Frm_scaricomagazzino_ep";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.tabSave.ResumeLayout(false);
            this.tabSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private System.Windows.Forms.Label label1;
        private Crownwood.Magic.Controls.TabPage tabSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGrid gridEP;
        private System.Windows.Forms.Label labelNewLinkedCont;
        private System.Windows.Forms.Label labelAddCont;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnOK;

    }
}
