
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace generaSQL {
    partial class FrmSelezioneTabelle {
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
            this.btDeselezionaTabelle = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.TableList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btDeselezionaTabelle
            // 
            this.btDeselezionaTabelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeselezionaTabelle.Location = new System.Drawing.Point(110, 515);
            this.btDeselezionaTabelle.Name = "btDeselezionaTabelle";
            this.btDeselezionaTabelle.Size = new System.Drawing.Size(120, 23);
            this.btDeselezionaTabelle.TabIndex = 12;
            this.btDeselezionaTabelle.Text = "Deseleziona tutte";
            this.btDeselezionaTabelle.Click += new System.EventHandler(this.btDeselezionaTabelle_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(831, 515);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            // 
            // TableList
            // 
            this.TableList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.TableList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableList.CheckBoxes = true;
            this.TableList.Location = new System.Drawing.Point(12, 12);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(894, 497);
            this.TableList.TabIndex = 9;
            this.TableList.UseCompatibleStateImageBehavior = false;
            this.TableList.View = System.Windows.Forms.View.List;
            // 
            // FrmSelezioneTabelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 550);
            this.Controls.Add(this.btDeselezionaTabelle);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.TableList);
            this.Name = "FrmSelezioneTabelle";
            this.Text = "FrmSelezioneTabelle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDeselezionaTabelle;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.ListView TableList;
    }
}
