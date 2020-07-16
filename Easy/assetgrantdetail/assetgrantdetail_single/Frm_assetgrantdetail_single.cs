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

﻿using metadatalibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assetgrantdetail_single {
    public partial class Frm_assetgrantdetail_single :Form {
        

        public MetaData Meta;
        private System.ComponentModel.Container components = null;
        public dsmeta DS;
        private GroupBox grpDettagli;
        private Label label1;
        private Label label2;
        private Button btnOk;
        private Button btnAnnulla;
        private TextBox txtAnnoRisc;
        private TextBox txtImporto;
        bool inChiusura = false;


        protected override void Dispose(bool disposing) {
            inChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }



        public void MetaData_AfterClear() {
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            txtAnnoRisc.Enabled = abilita;
        }


        public void MetaData_AfterFill() {

            enableControls(false);
        }




        public Frm_assetgrantdetail_single() {
            InitializeComponent();
        }



        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpDettagli = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtAnnoRisc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new assetgrantdetail_single.dsmeta();
            this.grpDettagli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDettagli
            // 
            this.grpDettagli.Controls.Add(this.txtImporto);
            this.grpDettagli.Controls.Add(this.txtAnnoRisc);
            this.grpDettagli.Controls.Add(this.label2);
            this.grpDettagli.Controls.Add(this.label1);
            this.grpDettagli.Location = new System.Drawing.Point(15, 12);
            this.grpDettagli.Name = "grpDettagli";
            this.grpDettagli.Size = new System.Drawing.Size(311, 117);
            this.grpDettagli.TabIndex = 13;
            this.grpDettagli.TabStop = false;
            this.grpDettagli.Tag = "";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(130, 59);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(112, 20);
            this.txtImporto.TabIndex = 16;
            this.txtImporto.Tag = "assetgrantdetail.amount";
            // 
            // txtAnnoRisc
            // 
            this.txtAnnoRisc.Location = new System.Drawing.Point(130, 23);
            this.txtAnnoRisc.Name = "txtAnnoRisc";
            this.txtAnnoRisc.Size = new System.Drawing.Size(112, 20);
            this.txtAnnoRisc.TabIndex = 15;
            this.txtAnnoRisc.Tag = "assetgrantdetail.ydetail";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Importo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Anno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(163, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(256, 144);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
            this.btnAnnulla.TabIndex = 14;
            this.btnAnnulla.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "dsmeta";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_assetgrantdetail_single
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(361, 199);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.grpDettagli);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_assetgrantdetail_single";
            this.grpDettagli.ResumeLayout(false);
            this.grpDettagli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        public void MetaData_AfterLink() {
            HelpForm.SetDenyNull(DS.assetgrantdetail.Columns["idgrant"], true);
        }

    }
}
