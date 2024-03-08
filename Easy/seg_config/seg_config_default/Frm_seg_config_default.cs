
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace seg_config_default {
	public partial class Frm_seg_config_default : MetaDataForm {
        public MetaData Meta;
        bool CanGoEdit;
        bool CanGoInsert;
        public Frm_seg_config_default() {
            InitializeComponent();
            CanGoEdit = true;
        }

        public void MetaData_AfterLink() {

            Meta = MetaData.GetMetaData(this);

            int numrighe = Meta.Conn.RUN_SELECT_COUNT("seg_config", null, true);
            if (numrighe == 1) {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else {
                CanGoInsert = true;
                CanGoEdit = false;
            }

            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
            //Meta.canSave = true;
            HelpForm.SetDenyNull(DS.seg_config.Columns["flag"], true);
        }
        public void MetaData_AfterClear() {
            if (CanGoInsert) {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit) {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); //edyttype associato
            }


        }

    }
}
