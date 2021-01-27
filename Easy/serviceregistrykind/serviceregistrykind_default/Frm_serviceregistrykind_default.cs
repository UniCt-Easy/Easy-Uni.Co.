
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;

namespace serviceregistrykind_default {
    public partial class Frm_serviceregistrykind_default : Form {
        MetaData Meta;
        public Frm_serviceregistrykind_default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagconferringstructure"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagordinancelink"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagauthorizingstructure"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagauthorizinglink"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagactreference"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagannouncementlink"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagotherservice"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagprofessionalservice"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagcomponentsvariable"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagcvattachment"], true);
            HelpForm.SetDenyNull(DS.serviceregistrykind.Columns["flagemploytime"], true);

            //bool IsAdmin = false;
            //if (Meta.GetSys("manage_prestazioni") != null)
            //    IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            //Meta.CanSave = IsAdmin;
            //Meta.CanInsert = IsAdmin;
            //Meta.CanInsertCopy = IsAdmin;
            //Meta.CanCancel = IsAdmin;
        }

    }
}
