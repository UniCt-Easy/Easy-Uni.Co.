/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace Chat.Client {
    partial class WebChat {
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
            this.easygenius = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.easygenius)).BeginInit();
            this.SuspendLayout();
            // 
            // easygenius
            // 
            this.easygenius.AllowExternalDrop = true;
            this.easygenius.CreationProperties = null;
            this.easygenius.DefaultBackgroundColor = System.Drawing.Color.White;
            this.easygenius.Location = new System.Drawing.Point(0, 0);
            this.easygenius.Name = "easygenius";
            this.easygenius.Size = new System.Drawing.Size(1264, 861);
            this.easygenius.TabIndex = 0;
            this.easygenius.ZoomFactor = 1D;
            // 
            // WebChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 861);
            this.Controls.Add(this.easygenius);
            this.Name = "WebChat";
            this.Text = "Assistente virtuale";
            ((System.ComponentModel.ISupportInitialize)(this.easygenius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 easygenius;
    }
}