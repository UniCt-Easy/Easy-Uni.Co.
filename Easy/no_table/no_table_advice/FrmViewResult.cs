
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;

namespace no_table_advice {
    public partial class FrmViewResult : MetaDataForm {
        string title;
        string message;
   
        public FrmViewResult(string title, string message) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.title = title;
            this.message = message;
            Text = "Dettaglio comunicazione";
            txtAdvice.Text = title.TrimEnd() + "\r\n" + "\r\n" + message;        
        }
	}
}
