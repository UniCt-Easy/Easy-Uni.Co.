
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace sdi_vendita_default{
    public partial class FrmAskProtocollo : MetaDataForm {
        public object Protocollo = DBNull.Value;
        public FrmAskProtocollo(object dummy)
        {
            InitializeComponent();
        }

        private void txtNumeroDiProtocollo_Leave(object sender, EventArgs e)
        {
            if (txtNumeroDiProtocollo.Text.Trim() == "") {
                Protocollo = DBNull.Value;
            }
            else {
                Protocollo = txtNumeroDiProtocollo.Text;
            }           
        }

      
        
       
    }
}
