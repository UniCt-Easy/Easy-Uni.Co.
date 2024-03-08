
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



namespace advice_default {
    partial class FrmCrontabSummary {
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(2, 3);
            this.monthCalendar.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(489, 44);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(306, 439);
            this.listBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(489, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Lista delle occorrenze";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmCrontabSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 501);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.monthCalendar);
            this.Name = "FrmCrontabSummary";
            this.Text = "Riepilogo schedulazione";
            this.Load += new System.EventHandler(this.FrmCrontabSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}
