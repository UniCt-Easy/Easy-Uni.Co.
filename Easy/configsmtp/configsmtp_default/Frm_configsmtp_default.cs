
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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace configsmtp_default{
    public partial class Frm_configsmtp_default : MetaDataForm {
        bool CanGoEdit;
        bool CanGoInsert;
        MetaData Meta;

        public Frm_configsmtp_default(){
            InitializeComponent();
        }

        public void MetaData_AfterLink(){
            HelpForm.SetDenyNull(DS.configsmtp.Columns["flagsend"], true);
            Meta = MetaData.GetMetaData(this);
            int numrighe = Meta.Conn.RUN_SELECT_COUNT("configsmtp", null, true);
            if (numrighe == 1){
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else{
                CanGoInsert = true;
                CanGoEdit = false;
            }
        }

        public void MetaData_AfterClear(){
            if (CanGoInsert){
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit){
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.configsmtp");
            }

        }
    }
}
