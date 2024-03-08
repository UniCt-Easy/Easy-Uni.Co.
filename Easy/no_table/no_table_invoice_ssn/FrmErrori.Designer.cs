
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


namespace no_table_invoice_ssn {
    partial class FrmErrori {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmErrori));
            this.labelInfo = new System.Windows.Forms.Label();
            this.listMessaggi = new System.Windows.Forms.ListView();
            this.columnNumeroDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCodice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMessaggio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(556, 27);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Di seguito sono elencati i messaggi restituiti dal servizio del sistema Tessera S" +
    "anitaria, relativamente all\'elaborazione \r\ndelle fatture inviate.\r\n";
            // 
            // listMessaggi
            // 
            this.listMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMessaggi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumeroDocumento,
            this.columnCodice,
            this.columnMessaggio});
            this.listMessaggi.Location = new System.Drawing.Point(15, 39);
            this.listMessaggi.Name = "listMessaggi";
            this.listMessaggi.Size = new System.Drawing.Size(553, 342);
            this.listMessaggi.TabIndex = 1;
            this.listMessaggi.UseCompatibleStateImageBehavior = false;
            this.listMessaggi.View = System.Windows.Forms.View.Details;
            // 
            // columnNumeroDocumento
            // 
            this.columnNumeroDocumento.Text = "Numero documento";
            this.columnNumeroDocumento.Width = 120;
            // 
            // columnCodice
            // 
            this.columnCodice.Text = "Codice messaggio";
            this.columnCodice.Width = 100;
            // 
            // columnMessaggio
            // 
            this.columnMessaggio.Text = "Messaggio del servizio";
            this.columnMessaggio.Width = 300;
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "warning");
            this.listImages.Images.SetKeyName(1, "error");
            this.listImages.Images.SetKeyName(2, "ok");
            // 
            // FrmErrori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 393);
            this.Controls.Add(this.listMessaggi);
            this.Controls.Add(this.labelInfo);
            this.Name = "FrmErrori";
            this.Text = "Messaggi del servizio Tessera Sanitaria";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ListView listMessaggi;
        private System.Windows.Forms.ColumnHeader columnNumeroDocumento;
        private System.Windows.Forms.ColumnHeader columnMessaggio;
        private System.Windows.Forms.ColumnHeader columnCodice;
        private System.Windows.Forms.ImageList listImages;
    }
}
