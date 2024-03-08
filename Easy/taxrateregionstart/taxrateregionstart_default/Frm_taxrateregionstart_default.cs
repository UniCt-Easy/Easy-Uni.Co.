
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


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace taxrateregionstart_default
{
    public class Frm_taxrateregionstart_default : MetaDataForm
	{
        public Frm_taxrateregionstart_default()
		{
			InitializeComponent();
		}

        private GroupBox grpComune;
        private Label label4;
        private TextBox txtGeoRegione;

        public taxrateregionstart_default.vistaForm DS;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_taxrateregionstart_default));
            this.DS = new taxrateregionstart_default.vistaForm();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.grpScaglioni = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpComune = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGeoRegione = new System.Windows.Forms.TextBox();
            this.grpScaglioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grpComune.SuspendLayout();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // grpScaglioni
            // 
            this.grpScaglioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScaglioni.Controls.Add(this.button3);
            this.grpScaglioni.Controls.Add(this.button2);
            this.grpScaglioni.Controls.Add(this.button1);
            this.grpScaglioni.Controls.Add(this.dataGrid1);
            this.grpScaglioni.Location = new System.Drawing.Point(12, 135);
            this.grpScaglioni.Name = "grpScaglioni";
            this.grpScaglioni.Size = new System.Drawing.Size(438, 201);
            this.grpScaglioni.TabIndex = 53;
            this.grpScaglioni.TabStop = false;
            this.grpScaglioni.Text = "Scaglioni";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(352, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 46;
            this.button3.TabStop = false;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 45;
            this.button2.TabStop = false;
            this.button2.Tag = "edit.default";
            this.button2.Text = "Modifica";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.TabStop = false;
            this.button1.Tag = "insert.default";
            this.button1.Text = "Nuovo";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 45);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(422, 148);
            this.dataGrid1.TabIndex = 43;
            this.dataGrid1.Tag = "taxrateregionbracket.default.default";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(12, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 51);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo Applicazione";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(94, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "taxrateregionstart.enforcement:F";
            this.radioButton2.Text = "Fascia Fissa";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "taxrateregionstart.enforcement:P";
            this.radioButton1.Text = "Progressiva";
            // 
            // cmbTipoRitenuta
            // 
            this.cmbTipoRitenuta.DataSource = this.DS.tax;
            this.cmbTipoRitenuta.DisplayMember = "description";
            this.cmbTipoRitenuta.Location = new System.Drawing.Point(106, 20);
            this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
            this.cmbTipoRitenuta.Size = new System.Drawing.Size(344, 21);
            this.cmbTipoRitenuta.TabIndex = 55;
            this.cmbTipoRitenuta.Tag = "taxrateregionstart.taxcode";
            this.cmbTipoRitenuta.ValueMember = "taxcode";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 57;
            this.label1.Text = "Tipo Imposta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(215, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 58;
            this.label3.Text = "Inizio Struttura";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(327, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 56;
            this.textBox1.Tag = "taxrateregionstart.start";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 20);
            this.textBox2.TabIndex = 59;
            this.textBox2.Tag = "taxrateregionstart.idtaxrateregionstart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 60;
            this.label2.Text = "Progr. Struttura";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpComune
            // 
            this.grpComune.Controls.Add(this.label4);
            this.grpComune.Controls.Add(this.txtGeoRegione);
            this.grpComune.Location = new System.Drawing.Point(15, 73);
            this.grpComune.Name = "grpComune";
            this.grpComune.Size = new System.Drawing.Size(433, 48);
            this.grpComune.TabIndex = 62;
            this.grpComune.TabStop = false;
            this.grpComune.Tag = "AutoChoose.txtGeoRegione.default";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 61;
            this.label4.Text = "Regione";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtGeoRegione
            // 
            this.txtGeoRegione.Location = new System.Drawing.Point(70, 16);
            this.txtGeoRegione.Name = "txtGeoRegione";
            this.txtGeoRegione.Size = new System.Drawing.Size(350, 20);
            this.txtGeoRegione.TabIndex = 1;
            this.txtGeoRegione.Tag = "geo_region_view.title?taxrateregionstartview.region";
            // 
            // Frm_taxrateregionstart_default
            // 
            this.ClientSize = new System.Drawing.Size(462, 401);
            this.Controls.Add(this.grpComune);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cmbTipoRitenuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpScaglioni);
            this.Name = "Frm_taxrateregionstart_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS.geo_region_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpScaglioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.grpComune.ResumeLayout(false);
            this.grpComune.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ImageList images;
        private IContainer components;
        private GroupBox grpScaglioni;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGrid dataGrid1;
        private GroupBox groupBox3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox cmbTipoRitenuta;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        MetaData Meta;
        bool IsAdmin;

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            IsAdmin = false;
            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            GetData.SetSorting(DS.taxrateregionstartview, "region,start desc");
        }
    }
}
