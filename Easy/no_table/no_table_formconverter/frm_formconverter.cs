/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace no_table_formconverter
{

    public partial class frm_formconverter : Form
    {
        MetaData Meta;
        public string OutputString="";
        public string Prefix;
        public int TabsControlCounter = 0;
        public int TabsHeaderCounter = 0;

        public frm_formconverter()
        {
            InitializeComponent();
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.SearchEnabled = false;

        }

        public void MetaData_AfterActivation()
        {
            if (this.Text.EndsWith("(Ricerca)"))
            {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (txtDLLName.Text == "")
            {
                MessageBox.Show(this,"Nessuna DLL specificata.");
                txtDLLName.Focus();
                return;
            }

            if (txtOutFileName.Text == "")
            {
                MessageBox.Show(this, "Nome del file non presente.");
                txtOutFileName.Focus();
                return;
            }

            if (txtNameSpace.Text == "")
            {
                MessageBox.Show(this, "Suffisso di Namespace ASPX non specificato.");
                txtNameSpace.Focus();
                return;
            }

            string DLLName = txtDLLName.Text;
            string FileName = txtOutFileName.Text;
            string AspNameSpace = txtNameSpace.Text;
            
            ConvertForm(DLLName, FileName, AspNameSpace);
        }


        public void ConvertForm(string DLLName, string FileName, string AspNameSpace)
        {
            Form Frm = MetaData.GetFormByDllName(DLLName);
            if (Frm == null)
            {
                MessageBox.Show("Form Inesistente.");
                return;
            }


            OutputString = "<div style='position:relative;width:"+Frm.Width+"px;height:"+Frm.Height+"px;'>\r\n";
            Prefix = AspNameSpace;
            ConvertForm(Frm);

            if (TabsControlCounter != 0)
            { 
                // Includere codice JS per i tabs
                OutputString += "<script type=\"text/javascript\">\r\n";
                OutputString += "// Inserire qui codice di gestione dei Tabs! \r\n";
                OutputString += "</script>\r\n";
            }
            OutputString += "</div>\r\n";

            SaveToFile(FileName);
        }

        public void ConvertForm(Form F)
        {
            if (F == null) return;
            ControlCollection CtlColl = F.Controls as ControlCollection;
            ConvertControls(CtlColl,0);

        }

        public void ConvertControls(Control.ControlCollection C,int deltaY)
        {
            if (C == null) return;
            foreach (Control Ctl in C)
            {
                System.Type Ctl_Type = Ctl.GetType();
                if (typeof(GroupBox).IsAssignableFrom(Ctl_Type))
                {
                    GroupBox G=Ctl as GroupBox;
                    string Tag="";
                    int XCoord = G.Location.X;
                    int YCoord = G.Location.Y;

                    int Width=G.Width;//-10;
                    int Height = G.Height;//-6;
                    // Draw Border
                    // Top border:
                    OutputString += "<img src=\"Immagini/pixel.gif\" alt=\"\" width=\"" + G.Width + "\" height=\"1\" style=\"position:absolute;z-index:101;left:" + XCoord + "px;top:" + YCoord + "px;\"/>\r\n";
                    // Left Border:
                    OutputString += "<img src=\"Immagini/pixel.gif\" alt=\"\" width=\"1\" height=\"" + G.Height + "\" style=\"position:absolute;z-index:101;left:" + XCoord + "px;top:" + YCoord + "px;\"/>\r\n";
                    // Right border:
                    int XplusDelta = XCoord + G.Width - 1;
                    OutputString += "<img src=\"Immagini/pixel.gif\" alt=\"\" width=\"1\" height=\"" + G.Height + "\" style=\"position:absolute;z-index:101;left:" + XplusDelta + "px;top:" + YCoord + "px;\"/>\r\n";
                    // Bottom border:
                    int YplusDelta= YCoord + G.Height -1;
                    OutputString += "<img src=\"Immagini/pixel.gif\" alt=\"\" width=\"" + G.Width + "\" height=\"1\" style=\"position:absolute;z-index:101;left:" + XCoord + "px;top:" + YplusDelta + "px;\"/>\r\n";
                    // Put Label
                    if (G.Text != "")
                    {
                        // Label Positioning
                      int XStart = XCoord + 10;
                      int YStart = YCoord - 5;
                      OutputString += "<div runat=\"server\" id=\""+ "gboxlbl"+ G.Name +"\" class=\"GroupBoxLabel\" style=\"position:absolute; z-index:104; left:" + XStart + "px;top:" + YStart + "px;\">" + G.Text + "</div>\r\n";
                    }
                    //OutputString += "<fieldset style=\"position:absolute; z-index: 101; left:" + XCoord + "px;top:" + YCoord + "px;width:" + Width + "px;height:" + Height + "px;\">\r\n";
                    //OutputString += "<legend>" + G.Text + "</legend>\r\n";
                    if (G.Tag != null && G.Tag.ToString() != "")
                    {
                        Tag = "Tag=\"" + G.Tag.ToString() + "\"";
                    }
                    string GroupingText = G.Text;
                    if (GroupingText == null || GroupingText == "")
                        GroupingText = "";
                    OutputString += "<" + Prefix + ":hwPanel CssClass=\"gbox\" "+Tag+" runat=\"server\" id=\"" + G.Name + "\" style=\"position:absolute; z-index: 101; left: " + XCoord + "px; top: " + YCoord + "px; width:" + Width + "px;height:" + Height + "px;\" width=\"" + Width + "\" height=\"" + Height + "\">\r\n";

                    if(Ctl.Controls.Count!=0)
                        ConvertControls(Ctl.Controls,0);
                    //if (G.Tag != null && G.Tag.ToString() != "")
                    OutputString += "</" + Prefix + ":hwPanel>\r\n";
                    //OutputString += "</fieldset>\r\n";
                }
                else
                    ConvertControl(Ctl,-5);

                if (typeof(TabControl).IsAssignableFrom(Ctl_Type))
                {
                    TabsControlCounter++;
                    // WARNING: Insert this control just for the first time!
                    if(TabsControlCounter==1)
                        OutputString += "<asp:TextBox runat=\"server\" style=\"display:none;\" id=\"CurrentFoldersConfig\"></asp:TextBox>\r\n";
                    OutputString += "<div id=\"TabsContainer" + TabsControlCounter + "\" style=\"position:absolute;z-index:101;left:" + Ctl.Location.X + "px;top:" + Ctl.Location.Y + "px;width:" + Ctl.Width + "px;height:" + Ctl.Height + "px;\">\r\n";

                    OutputString += "<div align=\"left\" style=\"left:"+Ctl.Location.X+"px;\" id=\"TabsHeader"+ TabsControlCounter +"\" ></div>\r\n";
                    foreach (TabPage TP in Ctl.Controls)
                    {
                        TabsHeaderCounter++;
                        OutputString += "<div title=\"" + TP.Text + "\" id=\"Tab" + TabsControlCounter + "Folder" + TabsHeaderCounter + "\" style=\"position:absolute;z-index:101;width:" + TP.Width + "px;height:" + TP.Height + "px;border:1px solid grey;\" >\r\n";
                        ConvertControls(TP.Controls, 0);
                        OutputString += "</div>\r\n";
                    }
                    TabsHeaderCounter = 0;
                    OutputString += "</div>\r\n";
                    
                }
                //if (Ctl.Controls.Count==0) continue;
                //ConvertControls(Ctl.Controls, X, Y);
            }
        }


        public void ConvertControl(Control C, int deltaY)
        {

            if (C == null) return;
            string MultiLine = "";
            string Tag="";
            string TabIndex = "";
            System.Type C_Type = C.GetType();

            
            if(C.Tag!=null) Tag=C.Tag.ToString();
            // Vediamo il tipo di controllo

            // un unica proprietà style deve contenere:
            // - tipo di posizionamento, sempre absolute;
            // - posizione assoluta (left, top);

            // width nel caso in cui si tratti di textbox
            // height nel caso si tratti di textbox multiline
            int X = C.Left;
            int Y;

            if (C.Parent == null)  //usare il Delta solo se ci sono controlli parent
                Y = C.Top;
            else
            {
                System.Type C_ParentType = C.Parent.GetType();
                if (typeof(GroupBox).IsAssignableFrom(C_ParentType))
                    Y = C.Top + deltaY;
                else
                    Y = C.Top;
            }
            string positionproperty="";
            // Copy size AND position
            if (C.TabIndex != 0) TabIndex = " TabIndex=\"" + C.TabIndex.ToString() + "\"";

            if (typeof(TextBox).IsAssignableFrom(C_Type))
            {
                TextBox T = C as TextBox;
                string ReadOnly = "";
                if (T.ReadOnly) ReadOnly = "ReadOnly=\"true\"";
                int NewWidth=T.Width-6;
                int NewHeight=T.Height-3;
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px;";
                if (T.Multiline)
                {
                    MultiLine = " TextMode=\"MultiLine\"";
                    positionproperty += "height:" + NewHeight + "px;width:" + NewWidth + "px";
                }
                else
                {
                    positionproperty += "width:" + NewWidth + "px;";
                }
                positionproperty += "\"";
                OutputString += "<" + Prefix + ":hwTextBox runat=\"server\" id=\"" + C.Name + "\" tag=\""+Tag+"\" "+positionproperty+MultiLine+TabIndex + " " + ReadOnly + "></"+Prefix+":hwTextBox>\r\n";
                return;
            }

            if (typeof(ComboBox).IsAssignableFrom(C_Type))
            {
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;\"";
                OutputString += "<" + Prefix + ":hwDropDownList runat=\"server\" AutoPostBack=\"true\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty +TabIndex + "></" + Prefix + ":hwDropDownList>\r\n";
                return;
            }

            if (typeof(RadioButton).IsAssignableFrom(C_Type))
            {
                //positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;\"";
                positionproperty = "style=\"position: absolute; z-index: 101; text-align: left; vertical-align: middle; left:" + X + "px; top:" + Y + "px; \"";
                OutputString += "<" + Prefix + ":hwRadioButton runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty + TabIndex + " Text=\"" + C.Text + "\"/>\r\n";
                return;
            }

            if (typeof(CheckBox).IsAssignableFrom(C_Type))
            {
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;\"";
                //positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; \"";
                OutputString += "<" + Prefix + ":hwCheckBox runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty + TabIndex + " Text=\"" + C.Text + "\"/>\r\n";
                return;
            }

            if (typeof(Button).IsAssignableFrom(C_Type))
            {
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;height:"+C.Height+"px;\"";
                //positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;height:auto;\"";
                OutputString += "<" + Prefix + ":hwButton runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty + TabIndex + " Text=\"" + C.Text + "\"/>\r\n";
                return;
            }
            
            if (typeof(Label).IsAssignableFrom(C_Type))
            {
                Label L = C as Label;
                string alignment = ConvertLabelAlignment(L.TextAlign);

                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;height:" + C.Height +"px;" + alignment + "\"";

                OutputString += "<" + Prefix + ":hwLabel runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty + " Text=\"" + C.Text + "\"></"+Prefix+":hwLabel>\r\n";
                //OutputString += "<label for=\""+C.Name+"\" "+positionproperty+" >"+C.Text+"</label>\r\n";
                return;
            }

            if (typeof(TreeView).IsAssignableFrom(C_Type))
            {
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;height:" + C.Height + "px;\"";
                OutputString += "<" + Prefix + ":hwTreeView runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty +TabIndex + " />\r\n";
                return;
            }

            if (typeof(DataGrid).IsAssignableFrom(C_Type))
            {
                positionproperty = "style=\"position: absolute; z-index: 101; left:" + X + "px; top:" + Y + "px; width:" + C.Width + "px;height:" + C.Height + "px;\"";
                OutputString += "<" + Prefix + ":hwDataGridWeb runat=\"server\" id=\"" + C.Name + "\" tag=\"" + Tag + "\" " + positionproperty + TabIndex + " />\r\n";
                return;
            }

        }

        public string ConvertLabelAlignment(ContentAlignment CA)
        {
            string Alignment="";
            switch (CA)
            {
                case ContentAlignment.BottomLeft:
                    Alignment = "text-align: left; vertical-align: bottom;";
                    break;
                case ContentAlignment.BottomRight:
                    Alignment = "text-align: right; vertical-align: bottom;";
                    break;
                case ContentAlignment.BottomCenter:
                    Alignment = "text-align: center; vertical-align: bottom;";
                    break;
                case ContentAlignment.MiddleLeft:
                    Alignment = "text-align: left; vertical-align: middle;";
                    break;
                case ContentAlignment.MiddleRight:
                    Alignment = "text-align: right; vertical-align: middle;";
                    break;
                case ContentAlignment.MiddleCenter:
                    Alignment = "text-align: center; vertical-align: middle;";
                    break;
                case ContentAlignment.TopLeft:
                    Alignment = "text-align: left; vertical-align: top;";
                    break;
                case ContentAlignment.TopRight:
                    Alignment = "text-align: right; vertical-align: top;";
                    break;
                case ContentAlignment.TopCenter:
                    Alignment = "text-align: center; vertical-align: top;";
                    break;
            }
            return Alignment;
        
        }
       
        public void SaveToFile(string FileName)
        {
            StreamWriter SW;
            try
            {
                SW = File.CreateText(FileName);
                SW.Write(OutputString);
                SW.Close();
                MessageBox.Show("File salvato correttamente.");
                this.Close();
                this.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemi con la scrittura del file."+"\r\n"+e.ToString());
                this.Close();
                this.Dispose();

            }
            return;
        
        }


    }
}