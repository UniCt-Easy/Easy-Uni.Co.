
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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



namespace QAClient {
    partial class SimpleChat {
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
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.btnGetAnswer = new System.Windows.Forms.Button();
            this.btnLogGood = new System.Windows.Forms.Button();
            this.btnLogBad = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.RichTextBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuestion.Location = new System.Drawing.Point(12, 415);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(530, 20);
            this.txtQuestion.TabIndex = 0;
            // 
            // btnGetAnswer
            // 
            this.btnGetAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAnswer.Location = new System.Drawing.Point(548, 412);
            this.btnGetAnswer.Name = "btnGetAnswer";
            this.btnGetAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnGetAnswer.TabIndex = 1;
            this.btnGetAnswer.Text = "??";
            this.btnGetAnswer.UseVisualStyleBackColor = true;
            this.btnGetAnswer.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnLogGood
            // 
            this.btnLogGood.Location = new System.Drawing.Point(629, 412);
            this.btnLogGood.Name = "btnLogGood";
            this.btnLogGood.Size = new System.Drawing.Size(45, 23);
            this.btnLogGood.TabIndex = 3;
            this.btnLogGood.Text = "??";
            this.btnLogGood.UseVisualStyleBackColor = true;
            this.btnLogGood.Click += new System.EventHandler(this.btnGood_Click);
            // 
            // btnLogBad
            // 
            this.btnLogBad.Location = new System.Drawing.Point(680, 412);
            this.btnLogBad.Name = "btnLogBad";
            this.btnLogBad.Size = new System.Drawing.Size(45, 23);
            this.btnLogBad.TabIndex = 4;
            this.btnLogBad.Text = "??";
            this.btnLogBad.UseVisualStyleBackColor = true;
            this.btnLogBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(208, 13);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.Size = new System.Drawing.Size(517, 393);
            this.txtAnswer.TabIndex = 5;
            this.txtAnswer.Text = "";
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Location = new System.Drawing.Point(12, 13);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(190, 394);
            this.lstHistory.TabIndex = 6;
            // 
            // SimpleChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 446);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnLogBad);
            this.Controls.Add(this.btnLogGood);
            this.Controls.Add(this.btnGetAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Name = "SimpleChat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnGetAnswer;
        private System.Windows.Forms.Button btnLogGood;
        private System.Windows.Forms.Button btnLogBad;
        private System.Windows.Forms.RichTextBox txtAnswer;
        private System.Windows.Forms.ListBox lstHistory;
    }
}
