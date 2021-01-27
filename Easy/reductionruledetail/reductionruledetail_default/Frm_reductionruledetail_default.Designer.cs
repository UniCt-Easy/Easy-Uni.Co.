
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


//namespace reductionruledetail_default
//{
//    partial class Frm_reductionruledetail
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.DS = new reductionruledetail_default.vistaForm();
//            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // DS
//            // 
//            this.DS.DataSetName = "vistaForm";
//            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
//            // 
//            // Frm_reductionruledetail_default
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(292, 266);
//            this.Name = "Frm_reductionruledetail_default";
//            this.Text = "Frm_reductionruledetail_default";
//            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        public vistaForm DS;

//    }
//}
namespace reductionruledetail_default
{
    partial class Frm_reductionruledetail
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
            this.DS = new reductionruledetail_default.vistaForm();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmbTipoRiduzione = new System.Windows.Forms.ComboBox();
            this.btnTipoRiduzione = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Perc.Anticipo";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "reductionruledetail.reductionpercentage.fixed.4..%.100";
            // 
            // cmbTipoRiduzione
            // 
            this.cmbTipoRiduzione.DataSource = this.DS.reduction;
            this.cmbTipoRiduzione.DisplayMember = "description";
            this.cmbTipoRiduzione.Location = new System.Drawing.Point(12, 42);
            this.cmbTipoRiduzione.Name = "cmbTipoRiduzione";
            this.cmbTipoRiduzione.Size = new System.Drawing.Size(281, 21);
            this.cmbTipoRiduzione.TabIndex = 47;
            this.cmbTipoRiduzione.Tag = "reductionruledetail.idreduction";
            this.cmbTipoRiduzione.ValueMember = "idreduction";
            // 
            // btnTipoRiduzione
            // 
            this.btnTipoRiduzione.Location = new System.Drawing.Point(12, 12);
            this.btnTipoRiduzione.Name = "btnTipoRiduzione";
            this.btnTipoRiduzione.Size = new System.Drawing.Size(104, 24);
            this.btnTipoRiduzione.TabIndex = 46;
            this.btnTipoRiduzione.TabStop = false;
            this.btnTipoRiduzione.Tag = "manage.reduction.default";
            this.btnTipoRiduzione.Text = "Tipo:";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(213, 133);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
            this.btnAnnulla.TabIndex = 49;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(117, 133);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 48;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "OK";
            // 
            // Frm_reductionruledetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 169);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbTipoRiduzione);
            this.Controls.Add(this.btnTipoRiduzione);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Name = "Frm_reductionruledetail";
            this.Text = "Frm_reductionruledetail_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmbTipoRiduzione;
        private System.Windows.Forms.Button btnTipoRiduzione;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;

    }
}
