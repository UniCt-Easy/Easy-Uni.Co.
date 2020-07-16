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

﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using System.IO;
using EnvDTE;

namespace meta_vsix {
    public class WizardImplementation : IWizard {
        private UserInputForm inputForm;
        private string customMessage="dummyValue";

        // This method is called before opening any item that   
        // has the OpenInEditor attribute.  
        public void BeforeOpeningFile(ProjectItem projectItem) {
        }

        public void ProjectFinishedGenerating(Project project) {
        }

        // This method is only called for item templates,  
        // not for project templates.  
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem) {
        }

        // This method is called after the project is created.  
        public void RunFinished() {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams) {
            string projectName = replacementsDictionary["$projectname$"];
            if (!projectName.StartsWith("meta_")) {
                throw new Exception("Il nome del progetto deve iniziare con meta_");
            }
            string table = projectName.Substring(5);
            replacementsDictionary["$tableName$"] = table;
            replacementsDictionary["$projectname$"] = "meta_" + table;
            replacementsDictionary["$projectname$"] = "meta_" + table;
            string solDir = replacementsDictionary["$solutiondirectory$"];
            
            //solDir = Path.getf    solDir.Substring(0,solDir.Length - table.Length)+"meta_"+table;
            //replacementsDictionary["$solutiondirectory$"] = solDir;

            //string destDir = replacementsDictionary["$destinationdirectory$"];
            //destDir = destDir.Substring(0, destDir.Length - table.Length) + "meta_" + table;
            //replacementsDictionary["$destinationdirectory$"] = destDir;

            replacementsDictionary["$safeprojectname$"] = "meta_" + table;


        }

        // This method is only called for item templates,  
        // not for project templates.  
        public bool ShouldAddProjectItem(string filePath) {
            return true;
        }
    }

    public partial class UserInputForm : Form {
        private static string customMessage="Enter tableName here";
        private TextBox textBox1;
        private Button button1;

        public UserInputForm(string val) {
            this.Size = new System.Drawing.Size(155, 265);

            button1 = new Button();
            button1.Location = new System.Drawing.Point(90, 25);
            button1.Size = new System.Drawing.Size(50, 25);
            button1.Click += button1_Click;
            this.Controls.Add(button1);

            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(10, 25);
            textBox1.Size = new System.Drawing.Size(70, 20);
            this.Controls.Add(textBox1);
            textBox1.Text = val;
        }
        public static string CustomMessage
        {
            get
            {
                return customMessage;
            }
            set
            {
                customMessage = value;
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            customMessage = textBox1.Text;
        }
    }

}