
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

namespace enactment_default
{
    public partial class AskConfirm : MetaDataForm
    {
        public AskConfirm(int dummy)
        {
            InitializeComponent();
            chk_do_update_enactment.Checked = true;
            chk_do_update_finvar.Checked = false;
            rdb_do_update_all_finvar_adate.Enabled = false;
            rdb_do_update_approved_finvar_adate.Enabled = false;
            rdb_do_update_all_finvar_adate.Checked = false;
            rdb_do_update_approved_finvar_adate.Checked = false;
        }

        private void chk_do_update_finvar_CheckedChanged(object sender, EventArgs e)
        {
            bool doEnable = chk_do_update_finvar.Checked;
            rdb_do_update_all_finvar_adate.Enabled = doEnable;
            rdb_do_update_approved_finvar_adate.Enabled = doEnable;

            if (!doEnable) {
                rdb_do_update_all_finvar_adate.Checked = doEnable;
                rdb_do_update_approved_finvar_adate.Checked = doEnable;
            }
        }
    }
}
