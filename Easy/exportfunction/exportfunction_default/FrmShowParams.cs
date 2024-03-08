
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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace report_default {
    public partial class FrmShowParams : MetaDataForm {
        public FrmShowParams(string SPName, DataAccess Conn) {
            InitializeComponent();
            string err;
            DataSet d = Conn.sqlRunnerDataSet("sp_help " + SPName,30, out err);
            if (err != null) {
                show( err, "Errore");
                return;
            }
            if (d == null) {
                show(  $"Stored procedure {SPName} non trovata","Errore");
                return;
            }
            gridSP.DataSource = d;
            gridSP.DataMember = d.Tables[0].TableName;
            if (d.Tables.Count > 1) {
                gridParams.DataSource = d;
                gridParams.DataMember = d.Tables[1].TableName;
            }
        }
    }
}
