
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



namespace AskCurrencyExchange {
    partial class FrmAskCurrencyExchange {
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
            this.components = new System.ComponentModel.Container();
            this.listViewCurrencyExchange = new System.Windows.Forms.ListView();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewCurrencyExchange
            // 
            this.listViewCurrencyExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCurrencyExchange.HideSelection = false;
            this.listViewCurrencyExchange.Location = new System.Drawing.Point(12, 38);
            this.listViewCurrencyExchange.Name = "listViewCurrencyExchange";
            this.listViewCurrencyExchange.Size = new System.Drawing.Size(434, 464);
            this.listViewCurrencyExchange.TabIndex = 0;
            this.listViewCurrencyExchange.UseCompatibleStateImageBehavior = false;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(39, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(266, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerTo.TabIndex = 2;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(12, 18);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(24, 13);
            this.labelFrom.TabIndex = 3;
            this.labelFrom.Text = "Da:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(243, 18);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(17, 13);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "A:";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(11, 551);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(435, 33);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Seleziona";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtWarning
            // 
            this.txtWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWarning.Location = new System.Drawing.Point(12, 508);
            this.txtWarning.Multiline = true;
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(434, 37);
            this.txtWarning.TabIndex = 8;
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmAskCurrencyExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 596);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.listViewCurrencyExchange);
            this.Name = "FrmAskCurrencyExchange";
            this.Text = "FrmAskCurrencyExchange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewCurrencyExchange;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtWarning;
    }
}
